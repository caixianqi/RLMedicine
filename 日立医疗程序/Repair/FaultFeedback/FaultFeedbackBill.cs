using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Repair
{
    class FaultFeedbackBill : Bao.BillBase.BillBase
    {
        public FaultFeedbackBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[2];
        
            this.EntityTables[0] = new Repair.FaultFeedbackMain();
            this.EntityTables[1] = new Repair.FaultFeedbackDetails();
            //this.EntityTables[2] = new Repair.FaultFeedbackRepairMission();
           

            //设置该单据的单号字段
            this.KeyFieldName = "FaultFeedbackID";
        }

        public override void AuditBefor()
        {

            string sql = string.Empty;
            string manager = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            sql = @"select b.RepairMissionId,b.RepairMissionCode,b.RepairTypeNew,a.* 
                                                from FaultFeedback a inner join RepairMission b on a.RepairMissionID = b.RepairMissionID where a.FaultFeedbackID = '" + this.BillId + "'";

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
            DataTable temp_dt = Common.Common.Select_SQL_UserID_ManageUser(manager);

            //if (UFBaseLib.BusLib.BaseInfo.DBUserID != manager)
            if (temp_dt.Select("userid='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'").Length <= 0)
            {
                throw new Exception("本用户没有审核权限");
            }
            if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                throw new Exception("本次故障解决情况，未提交，审核失败");
            }

            //先看是否做配件申请单
            string Code = dt.Rows[0]["RepairMissionCode"].ToString();
            string ID = dt.Rows[0]["RepairMissionId"].ToString();
            string RepairtypeNew = dt.Rows[0]["RepairtypeNew"].ToString();
            DataTable invapp = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from PartsApplication where RepairMissionCode = '" + Code + "'");
            if (invapp.Rows.Count > 0)
            {
                //验证是否出库完成
                DataTable reslut = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select StateReturn,PartsInventoryId from PartsInventory where RepairMissionCode = '" + Code + "'");
                if (reslut.Rows.Count == 0)
                {
                    throw new Exception("【存在配件申请未做出入单!】");
                }
                foreach (DataRow item in reslut.Rows)
                {
                    if (item["StateReturn"].ToString() != "归还完成")
                    {
                        throw new Exception("【还有出库单未归还完成】");
                    }
                }
            }

            //是否保外项目
            if (RepairtypeNew.ToUpper() == "C")
            {
                sql = "select IsPass from [FreeApplication] where RepairMissionId = '" + ID + "' and IsPass = '同意'";
                //是否免费
                if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql).Length == 0)
                {
                    string priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceId from Price where RepairMissionCode = '" + Code + "'");
                    if (priceid == string.Empty)
                    {
                        throw new Exception("[保外任务，未作报价单，不能审核!]");
                    }

                    string billState = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select 1 from [Bill] where PriceId = '" + priceid + "'");

                    if (billState == "")
                    {
                        throw new Exception("【未做发票申请】");
                    }

                    billState = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select AuditTime from [Bill] where PriceId = '" + priceid + "'");

                    if (billState == "")
                    {
                        throw new Exception("【发票申请未审核】");
                    }
                }
            }

            return;
        }

        public override void AuditAfter()
        {
            string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table. Rows[0]["RepairMissionId"].ToString() + "'");

            Bao.Message.CMessage.SendMessage("故障解决情况，审核通过", "故障解决情况，审核通过", userid, UFBaseLib.BusLib.BaseInfo.UserId, "Fau001", this.BillId);

            string userName = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonName from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");
            System.Windows.Forms.MessageBox.Show("审核成功,信息发送至[" + userName + "]");

            
        }

        public override void UnAuditBefor()
        {
            string manager = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FaultFeedback where FaultFeedbackID = '" + this.BillId + "'");

            DataTable re = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            if (re.Rows[0]["IsEnd"].ToString() == "已结案")
            {
                throw new Exception("维修任务已经结案，弃审失败");
            }

            DataTable temp_dt = Common.Common.Select_SQL_UserID_ManageUser(manager);
            
            //if (UFBaseLib.BusLib.BaseInfo.DBUserID == manager)
            if (temp_dt.Select("userid='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'").Length > 0 || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
            {
                string userid = this.EntityTables[0].Table.Rows[0]["AuditPerson"].ToString();

                //2014-12-02修改，因客户要求只有总监008角色才可以弃审，002科长不可以弃审

                if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
                {
                    throw new Exception("只能由总监弃审！");
                }

                //if (userid != "" && userid != UFBaseLib.BusLib.BaseInfo.DBUserID) 注释时间为2014-12-02，原因在总监也可以弃审，不用本人弃审
                //{
                //    string username = Common.Common.GetUserName(userid);
                //    throw new Exception("只能由" + username + "弃审！");
                //}

                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("本次故障解决情况，未提交，弃审失败");
                }
                else
                {
                    return;

                }
            }
            else
            {
                throw new Exception("本用户没有审核权限");
            }
        }

        public override void UnAuditAfter()
        {
            string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            Message.SendDefineMsg msg = new Message.SendDefineMsg();

            msg.ShowDialog();

            Bao.Message.CMessage.SendMessage("故障解决情况，未通过", msg.Msg, userid, UFBaseLib.BusLib.BaseInfo.UserId, "Fau001", this.BillId);

            string userName = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonName from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");
            System.Windows.Forms.MessageBox.Show("弃审成功,信息发送至[" + userName + "]");
        }

        public override void NewBefor()
        {
            CheckData();

        }

        public void CheckData()
        {
            if (this.EntityTables[1].Table.Rows.Count == 0)
            {
                throw new Exception("故障反馈表体明细不能为空");
            }

            if (this.EntityTables[0].Table.Rows[0]["ProcessingStatus"].ToString() == "完成")
            {
                if (this.EntityTables[0].Table.Rows[0]["FaultType"].ToString() == string.Empty || this.EntityTables[0].Table.Rows[0]["Finalsolution"].ToString() == string.Empty)
                {
                    throw new Exception("完成状态下，故障类型和最终解决方式不能为空");
                }
            }

        }

        public override void NewAfter()
        {
            
        }

        public override void UpBefor()
        {
            CheckData();
        }

        public override void UpAfter()
        {
            
        }

        public override void DelBefor()
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FaultFeedback where FaultFeedbackID = '" + this.BillId + "'");
            if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception("必须由工程师收回，才能删除");
            }
        }

        public override void DelAfter()
        {
            
        }

        public override void UpLoadBefor()
        {
            
        }

        public override void UpLoadAfter()
        {
          
        }

        public override void UpCancelBefor()
        {
           
        }

        public override void UpCancelAfter()
        {
            
        }

        public override void GetCode(Bao.BillBase.FrmBillBase Sender)
        {
            //Bao.BillBase.ICode dd;
            //dd = new Code.BillCode(this.EntityTables[0].TableName, "");
            //this.BillId = dd.GetId();
            //把最大的单号填进去
        

        
        }

        public override string ReturnCreateUserFieldName()
        {
            return string.Empty;
        }
    }
}
