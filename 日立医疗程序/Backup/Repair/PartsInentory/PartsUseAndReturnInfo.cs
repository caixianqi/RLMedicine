using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    public class PartsUseAndReturnInfo :Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "insert into PartsUseAndReturnInfo (AutoID,PartsInventoryID,PartType,PartCode,State,ProcessResults,iquantity,ReturnDate,Remarks,InventoryStd,InventoryCode,InventoryEngName) values('" + row1["AutoID"].ToString() + "','" + row1["PartsInventoryID"].ToString() + "','" + row1["PartType"].ToString() + "','" + row1["PartCode"].ToString() + "','" + row1["State"].ToString() + "','" + row1["ProcessResults"].ToString() + "','" + row1["iquantity"].ToString() + "','" + row1["ReturnDate"].ToString() + "','" + row1["Remarks"].ToString() + "','" + row1["InventoryStd"].ToString() + "','" + row1["InventoryCode"].ToString() + "','" + row1["InventoryEngName"].ToString() + "')";

            return sql;



        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;


            sql = "delete from  PartsUseAndReturnInfo where PartsInventoryID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [PartsUseAndReturnInfo] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [PartsUseAndReturnInfo] where [PartsInventoryID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["ReturnDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
            
        }
    }
}
