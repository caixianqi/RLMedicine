using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    public class BillBill :Bao.BillBase.BillBase
    {
        public BillBill()
        {

            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[3];
            this.EntityTables[0] = new Repair.BillMainData();
            this.EntityTables[1] = new Repair.BillDetails();
            this.EntityTables[2] = new Repair.MoneyReceiveData();


            //设置该单据的单号字段
            this.KeyFieldName = "BillID";
        }

        public override void AuditBefor()
        {
            //只有审核人能审核
            string repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceId ='" + this.EntityTables[0].Table.Rows[0]["PriceId"].ToString() + "'");

            RiLiGlobal.RiLiDataAcc.IsEnd(repcode);

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Bill where BillId = '" + this.BillId + "'");
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == dt.Rows[0]["AuditerCode"].ToString())
            {
                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("本张开票申请，未提交，或已经被工程师收回，审核失败");
                }
                else if (dt.Rows[0]["BillState"].ToString() == "开票申请")
                {
                    this.EntityTables[0].Table.Rows[0]["BillState"] = "审核通过";
                    return;
                }
                else if (dt.Rows[0]["BillState"].ToString() == "审核通过")
                {
                    throw new Exception("已经审核，不可重复审核");
                }
                else
                {
                    throw new Exception("本张开票申请，助理已经填写寄票信息，不用进行审核");
                }
            }
            else
            {
                throw new Exception("本用户没有审核权限");
            }
        }

        public override void AuditAfter()
        {
            System.Windows.Forms.MessageBox.Show("审核成功");

            Bao.Message.CMessage.SendMessageToRoleNoDepartment("开票申请", "工程师的开票申请已经通过", "007", UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BillId);
        }

        public override void UnAuditBefor()
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Bill where BillId = '" + this.BillId + "'");
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == dt.Rows[0]["AuditerCode"].ToString())
            {
               
                if (dt.Rows[0]["BillState"].ToString() == "寄票")
                {
                    throw new Exception("寄票状态已经提交，不可弃审");
                }
                //if (dt.Row[]s[0]["BillState"].ToString() == "审核通过")
                //{
                    this.EntityTables[0].Table.Rows[0]["BillState"] = "开票申请";
                    return;
                //}
                //else
                //{
                //    throw new Exception("弃审失败，本张发票，不是开票申请状态");
                //}
            }
            else
            {
                throw new Exception("本用户没有审核权限");
            }
        }

        public override void UnAuditAfter()
        {
            string repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceId ='" + this.EntityTables[0].Table.Rows[0]["PriceId"].ToString() + "'");

            RiLiGlobal.RiLiDataAcc.IsEnd(repcode);

            Message.SendDefineMsg msg = new Message.SendDefineMsg();

            msg.ShowDialog();

            System.Windows.Forms.MessageBox.Show("弃审成功");

            Bao.Message.CMessage.SendMessage("开票申请未通过", msg.Msg, this.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BillId);
        }

        public override void NewBefor()
        {
            this.EntityTables[0].Table.Rows[0]["PriceId"] = this.TempId;
            CheckData();
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
            //必须是收回状态

            if (this.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception("必须由开票申请人收回，才能删除");
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
        }

        public override string ReturnCreateUserFieldName()
        {
            return string.Empty;
        }
        public void CheckData()
        {

            //维修编号					
            //客户编号					
            //客户名称					
            //区域名称					
            //维修联系人					
            //联系电话	
            //报修日期					
            //维修性质					
            //客服经理					
            //受理工程师					
            //主机型号
            //故障描述
            System.Data.DataRow maindata = this.EntityTables[0].Table.Rows[0];

            string mesg = string.Empty;
            mesg += CheckIsNull(maindata["BillTitle"], "发票抬头不能为空");
            mesg += CheckIsNull(maindata["SendBillAddress"], "寄票地址不能为空");
            mesg += CheckIsNull(maindata["ReceivePerson"], "收件人不能为空");

            if (maindata["BillType"].ToString() == "增值税专用发票")
            {
                mesg += CheckIsNull(maindata["CompanyAddress"], "增值税专用发票:公司注册地址不能为空");
                mesg += CheckIsNull(maindata["Number"], "增值税专用发票:电话不能为空");
            }

            if (this.EntityTables[1].Table.Rows.Count == 0)
            {
                mesg += "【开票申请表体明细，不能为空】";
            }
            else
            {
                foreach (System.Data.DataRow item in this.EntityTables[1].Table.Rows)
                {
                    if (item["money"].ToString() == "0")
                    {
                        mesg += "【金额不能为0】";
                    }
               
                }
            }
         

            if (string.IsNullOrEmpty(mesg))
            {
                return;
            }
            else
            {
                throw new Exception(mesg);
            }








        }
    }
}
