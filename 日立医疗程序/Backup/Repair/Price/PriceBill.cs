using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    public class PriceBill :Bao.BillBase.BillBase
    {
        public PriceBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[2];
            this.EntityTables[0] = new Repair.PriceMainData();
            this.EntityTables[1] = new Repair.PriceDetailsData();


            //设置该单据的单号字段
            this.KeyFieldName = "PriceID";
        }


        public override void AuditBefor()
        {
            
        }

        public override void AuditAfter()
        {
           
        }

        public override void UnAuditBefor()
        {
            
        }

        public override void UnAuditAfter()
        {
            
        }

        public override void NewBefor()
        {
            string err = string.Empty;

            if (this.TempId == "Pri001")
            {
                err += "[未指定维修任务]";
                throw new Exception(err);
            }
            this.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.TempId;
            this.EntityTables[0].Table.Rows[0]["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            this.EntityTables[0].Table.Rows[0]["ApplicationPerson"] = UFBaseLib.BusLib.BaseInfo.UserName;

            

          
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["RepairMissionCode"], "维修编号不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["PaymentUnit"], "付款单位不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["InventoryCode"], "机型不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["InventoryName"], "机型不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["RepairCost"], "维修费不能为空，如不涉及相关费用，请输入0");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["TravelCost"], "差旅费费不能为空，如不涉及相关费用，请输入0");

            if (this.EntityTables[1].Table.Rows.Count == 0)
            {
               // err += "报价单表体明细不能为空";
            }
            else
            {
                foreach (System.Data.DataRow maindata in this.EntityTables[1].Table.Rows[0].Table.Rows)
                {

                    err += CheckIsNull(maindata["InventoryCode"], "表体配件编号不能为空");
                    err += CheckIsNull(maindata["InventoryName"], "表体配件名称不能为空");
                    err += CheckIsNull(maindata["Type"], "类型不能为空");
                    err += CheckIsNull(maindata["IsReturn"], "不良品返还不能为空");

                }
            }

            if (!(err == string.Empty))
            {
                throw new Exception(err);

            }
            RiLiGlobal.RiLiDataAcc.GetConn();
            string maxcode = this.EntityTables[0].Table.Rows[0]["PriceCode"].ToString();

            int num = int.Parse(maxcode.Substring(2, 8));

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery("Update dbo.VoucherHistory set cnumber = " + num + " where cardnumber = '00006'");

        }

        public override void NewAfter()
        {
           
        }

        public override void UpBefor()
        {
            string err = string.Empty;

            err += CheckIsNull(EntityTables[0].Table.Rows[0]["RepairMissionCode"], "维修编号不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["PaymentUnit"], "付款单位不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["InventoryCode"], "机型不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["InventoryName"], "机型不能为空");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["RepairCost"], "维修费不能为空，如不涉及相关费用，请输入0");
            err += CheckIsNull(EntityTables[0].Table.Rows[0]["TravelCost"], "差旅费费不能为空，如不涉及相关费用，请输入0");

            if (this.EntityTables[1].Table.Rows.Count == 0)
            {
                //err += "报价单表体明细不能为空";
            }
            else
            {
                this.EntityTables[1].Table.AcceptChanges();
                foreach (System.Data.DataRow maindata in this.EntityTables[1].Table.Rows[0].Table.Rows)
                {

                    err += CheckIsNull(maindata["InventoryCode"], "表体配件编号不能为空");
                    err += CheckIsNull(maindata["InventoryName"], "表体配件名称不能为空");
                    err += CheckIsNull(maindata["Type"], "类型不能为空");
                    err += CheckIsNull(maindata["IsReturn"], "不良品返还不能为空");

                }
            }

            if (!(err == string.Empty))
            {
                throw new Exception(err);
              
            }
        }

        public override void UpAfter()
        {
           
        }

        public override void DelBefor()
        {
           //必须是收回状态

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from price where priceid = '" + this.BillId + "'");

            if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception("必须由报价申请人收回，才能删除");
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
            string maxcode = RiLiGlobal.GetCode.GetPriceCode();
            this.EntityTables[0].Table.Rows[0]["PriceCode"] = maxcode;
        }

        public override string ReturnCreateUserFieldName()
        {
            return string.Empty;
        }
    }
}
