using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    public class PartsInventoryBill :Bao.BillBase.BillBase
    {
        public PartsInventoryBill()
        {
             //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[3];
            this.EntityTables[0] = new Repair.PartsInventoryMain();
            this.EntityTables[1] = new Repair.PartsInventoryDetails();
            this.EntityTables[2] = new Repair.PartsUseAndReturnInfo();


            //设置该单据的单号字段
            this.KeyFieldName = "PartsInventoryID";
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


        public void CheckData()
        {
            string err = string.Empty;
            foreach (System.Data.DataRow maindata in this.EntityTables[1].Table.Rows)
            {

                err += CheckIsNull(maindata["PartType"], "出库信息：表体配件不能为空");
                err += CheckIsNull(maindata["ShippingTime"], "出库信息：出货日期不能为空");
                err += CheckIsNull(maindata["Warehouse"], "出库信息：仓库不能为空");
                err += CheckIsNull(maindata["ExpectedArrivalDate"], "出库信息：预计到达时间不能为空");
                err += CheckIsNull(maindata["PartCode"], "出库信息：配件唯一号不能为空");

                if (maindata["iquantity"].ToString() == "0" || maindata["iquantity"].ToString() == string.Empty)
                {
                    err += "[数量不能为空]";
                }

            }

            foreach (System.Data.DataRow maindata in this.EntityTables[2].Table.Rows)
            {

                err += CheckIsNull(maindata["PartType"], "归还信息：表体配件不能为空");
                err += CheckIsNull(maindata["State"], "归还信息：状态不能为空");
                err += CheckIsNull(maindata["ProcessResults"], "归还信息：处理结果不能为空");
                err += CheckIsNull(maindata["ReturnDate"], "归还信息：归还日期不能为空");

                if (maindata["iquantity"].ToString() == "0" || maindata["iquantity"].ToString() == string.Empty)
                {
                    err += "[数量不能为空]";
                }

            }

            if (err == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception(err);
            }
        }

        public override void NewBefor()
        {
            this.EntityTables[0].Table.Rows[0]["PartsApplicationID"] = this.TempId;
            this.EntityTables[0].Table.Rows[0]["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
         

            string partid = this.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString();

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select AuditName from PartsApplication where PartsApplicationID = '" + partid + "'") == string.Empty)
            {
                throw new Exception("发现配件申请单被否决，保存失败");
            }
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
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from PartsInventory where PartsInventoryId = '" + this.BillId + "'");

            string errmesg = string.Empty;

            if (dt.Rows[0]["StateInOut"].ToString() == "出库完成")
            {
                errmesg += "[本张单据出库完成，不能删除]";
            }
            if (dt.Rows[0]["StateReturn"].ToString() == "归还完成")
            {
                errmesg += "[本张单据归还完成，不能删除]";
            }

            if (errmesg == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception(errmesg);
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
