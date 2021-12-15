using System;
using System.Collections.Generic;
using System.Text;
using Bao.Message;

namespace Repair
{
    public class PartsApplicationBill:Bao.BillBase.BillBase
    {
        public string RepairMissionID;

        public PartsApplicationBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[2];
            this.EntityTables[0] = new Repair.PartsApplicationMain();
            this.EntityTables[1] = new Repair.PartsApplicationItem();


            //设置该单据的单号字段
            this.KeyFieldName = "PartsApplicationID";

           
        }

        public override void AuditBefor()
        {
          //判断有没有权限，没有权限就抛出异常

            //条件必须是客服经理


            //if (UFBaseLib.BusLib.BaseInfo.DBUserID == this.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString())
            //{
                if (this.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString() == string.Empty)
                {
                    throw new Exception("本张配件申请单，未提交，或已经被工程师收回，审核失败");
                }
                else
                {
                    return;
                }

            //}
            //else
            //{
                //throw new Exception("本用户没有审核权限");
            //}
        }

        public override void AuditAfter()
        {
            System.Windows.Forms.MessageBox.Show("审核成功");



            CMessage.SendMessageToRoleNoDepartment("配件申请", "有新的配件申请单已经审核通过，请查看", "001", UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BillId);
            CMessage.SendMessageToRoleNoDepartment("配件申请", "有新的配件申请单已经审核通过，请查看", "007", UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BillId);
            CMessage.SendMessage("配件申请", "有新的配件申请单已经审核通过，请查看", this.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BillId);
        }

        public override void UnAuditBefor()
        {
            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select PartsInventoryID from PartsInventory where PartsApplicationID = '" + this.BillId + "'").Rows.Count > 0)
            {
                throw new Exception("弃审失败，已经存在相应的出入库单");
            }

            //if (UFBaseLib.BusLib.BaseInfo.DBUserID == this.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString())
            //{
                if (this.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString() == string.Empty)
                {
                    throw new Exception("本张配件申请单，未提交，或已经被工程师收回，弃审失败");
                }
                else
                {
                    return;
                }
            //}
            //else
            //{
                //throw new Exception("本用户没有弃审权限");
            //}
        }

        public override void UnAuditAfter()
        {
            Message.SendDefineMsg msg = new Message.SendDefineMsg();

            msg.ShowDialog();
            System.Windows.Forms.MessageBox.Show("弃审成功");
            CMessage.SendMessage("配件申请未通过", msg.Msg, this.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BillId);
        }

        public override void NewBefor()
        {
            this.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.TempId;
            this.EntityTables[0].Table.Rows[0]["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            CheckData();
        }

        public override void NewAfter()
        {
            RiLiGlobal.RiLiDataAcc.GetConn();
            string maxcode = this.EntityTables[0].Table.Rows[0]["PartsApplicationCode"].ToString();

            int num = int.Parse(maxcode.Substring(2, 8));

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery("Update dbo.VoucherHistory set cnumber = " + num + " where cardnumber = '00005'");

            

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

            if (this.EntityTables[0].Table.Rows[0]["UserId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID)
            {
                return;
            }
            else
            {
                throw new Exception("必须由配件申请人收回，才能删除");
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
            RiLiGlobal.RiLiDataAcc.GetConn();
            string maxcode = RiLiGlobal.GetCode.GetParCode();
            this.EntityTables[0].Table.Rows[0]["PartsApplicationCode"] = maxcode;
        }

        public override string ReturnCreateUserFieldName()
        {
            return string.Empty;
        }
        public void CheckData()
        {

//配件编号					
//配件名称					
//申请人					
//数量					
//配件申请日期					
//领用仓库					
              string mesg = string.Empty;

              System.Data.DataRow main = this.EntityTables[0].Table.Rows[0];



             // mesg += CheckIsNull(main["ApplicationPersonName"], "申请人不能为空");

              if (this.EntityTables[1].Table.Rows.Count == 0)
              {
                  mesg += "表体信息不能为空";
              }
              else
              {
                  foreach (System.Data.DataRow maindata in this.EntityTables[1].Table.Rows[0].Table.Rows)
                  {

                      mesg += CheckIsNull(maindata["InventoryCode"], "表体明细：配件编号不能为空");

                      mesg += CheckIsNull(maindata["ArrivalLocation"], "表体明细：到货地点不能为空");

                      if (maindata["iquantity"].ToString() == "0")
                      {
                          mesg += "[表体明细：数量不能为0]";
                      }

                  }
              }
            System.Data.DataRow data = this.EntityTables[0].Table.Rows[0];

            mesg += CheckIsNull(data["ApplyingReasons"], "申请理由不能为空");
         

        


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
