using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    public class PartsInventoryDetails :Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;


            sql = "insert into PartsInventoryDetails (AutoID,PartsInventoryID,PartType,ShippingTime,Warehouse,ExpectedArrivalDate,PartCode,iquantity,Remarks,InventoryStd,InventoryCode,InventoryEngName) Values ('" + row1["AutoID"].ToString() + "','" + row1["PartsInventoryID"].ToString() + "','" + row1["PartType"].ToString() + "','" + row1["ShippingTime"].ToString() + "','" + row1["Warehouse"].ToString() + "','" + row1["ExpectedArrivalDate"].ToString() + "','" + row1["PartCode"].ToString() + "','" + row1["iquantity"].ToString() + "','" + row1["Remarks"].ToString() + "','" + row1["InventoryStd"].ToString() + "','" + row1["InventoryCode"].ToString() + "','" + row1["InventoryEngName"].ToString() + "')";


            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "delete from PartsInventoryDetails where PartsInventoryID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [PartsInventoryDetails] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [PartsInventoryDetails] where [PartsInventoryID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["ExpectedArrivalDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
            NewRow["ShippingTime"] =  RiLiGlobal.RiLiDataAcc.GetNow();
        }
    }
}
