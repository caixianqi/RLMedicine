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
           
            string manager = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0] ["RepairMissionId"].ToString() + "'");

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FaultFeedback where FaultFeedbackID = '" + this.BillId + "'");
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == manager)
            {
                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("本次故障解决情况，未提交，审核失败");
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

        public override void AuditAfter()
        {
            string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table. Rows[0]["RepairMissionId"].ToString() + "'");

            Bao.Message.CMessage.SendMessage("故障解决情况，审核通过", "故障解决情况，审核通过", userid, UFBaseLib.BusLib.BaseInfo.UserId, "Fau001", this.BillId);

            System.Windows.Forms.MessageBox.Show("审核成功");

            
        }

        public override void UnAuditBefor()
        {
            string manager = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FaultFeedback where FaultFeedbackID = '" + this.BillId + "'");

            DataTable re = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RepairMission where RepairMissionID = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");

            if (re.Rows[0]["IsEnd"].ToString() == "已结案")
            {
                throw new Exception("维修任务已经结案，弃审失败");
            }
            
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == manager)
            {
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


            System.Windows.Forms.MessageBox.Show("弃审成功");
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
