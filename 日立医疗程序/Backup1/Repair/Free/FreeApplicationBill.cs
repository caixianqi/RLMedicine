using System;
using System.Collections.Generic;
using System.Text;
using Bao.Message;
using System.Data;

namespace Repair
{
    public class FreeApplicationBill:Bao.BillBase.BillBase
    {

        public FreeApplicationBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[1];
            this.EntityTables[0] = new Repair.FreeApplicationData();
        

            //设置该单据的单号字段
            this.KeyFieldName = "FreeID";
        }

        public override void AuditBefor()
        {
            this.EntityTables[0].Table = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FreeApplication where FreeID = '" + this.BillId + "'");


            RiLiGlobal.RiLiDataAcc.IsEnd(this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString());
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == this.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString())
            {
                if (this.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("本张免费申请，未提交，或已经被工程师收回，审核失败");
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
           //发消息给工程师
            CMessage.SendMessage("免费申请已经通过", "免费申请已经通过经理审核，请察看", this.EntityTables[0].Table.Rows[0]["AppPersonId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BillId);

            //如果同个维修任务有报价单，则将该报价单标志清除
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  * from price where RepairMissionCode ='" + this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString() + "'").Rows.Count > 0)
            {


                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery("update price set TaxRegistrationNumber = null,Account = null,BankName = null,ReviewerID =null,RemarksForReview = null,State = '报价单作废' where RepairMissionCode = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString() + "'");
                    System.Windows.Forms.MessageBox.Show("发现该任务有报价单，并已经填写回执，本次审核，将清除该报价单的回执信息");
                
               


               // CMessage.SendMessage("免费申请已经通过,报价单回执被清空", "免费申请已经通过,报价单回执被清空", this.EntityTables[0].Table.Rows[0]["AppPersonId"].ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID, "Fre001", this.BillId);
            }
            System.Windows.Forms.MessageBox.Show("审核成功");
        }

        public override void UnAuditBefor()
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FreeApplication where FreeID = '" + this.BillId + "'");
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == this.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString())
            {
                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("本张免费申请，未提交，或已经被工程师收回，弃审失败");
                }
                return;
            }
            else
            {
                throw new Exception("本用户没有审核权限");
            }
        }

        public override void UnAuditAfter()
        {
          //发消息给工程师

      //如果同个维修任务有报价单，则将该报价单标志清除

            Message.SendDefineMsg msg = new Message.SendDefineMsg();

            msg.ShowDialog();

            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  * from price where RepairMissionCode ='" + this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString() + "'").Rows.Count > 0)
            {
                //

                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery("update price set TaxRegistrationNumber = null,Account = null,BankName = null,ReviewerID = null,State = '报价申请' where RepairMissionCode = '" + this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString() + "'");
                System.Windows.Forms.MessageBox.Show("发现该任务有报价单，本次弃审过后，报价单可继续填写回执");
            }
            CMessage.SendMessage("免费申请未通过", msg.Msg, this.EntityTables[0].Table.Rows[0]["AppPersonId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BillId);



         


            System.Windows.Forms.MessageBox.Show("弃审成功");
        }

        public override void NewBefor()
        {
            this.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.TempId;
        }

        public override void NewAfter()
        {
           
        }

        public override void UpBefor()
        {
         
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
                throw new Exception("必须由免费申请人收回，才能删除");
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
    }
}
