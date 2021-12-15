using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    class PriceDetailsData:Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [PriceDetails]
           ([AutoID]
           ,[PriceID]
           ,[InventoryCode]
           ,[InventoryName]
           ,[Type]
           ,[Money]
           ,[IsReturn]
           ,InventoryEngName
           ,InventoryStd)
     VALUES ";

            sql = sql + "('" + row1["AutoID"].ToString() + "','" + row1["PriceID"].ToString() + "','" + row1["InventoryCode"].ToString() + "','" + row1["InventoryName"].ToString() + "','" + row1["Type"].ToString() + "'," + row1["Money"].ToString() + ",'" + row1["IsReturn"].ToString() + "','" + row1["InventoryEngName"].ToString() + "','" + row1["InventoryStd"].ToString() + "')";

            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "Delete from PriceDetails where PriceID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
                string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [PriceDetails] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [PriceDetails] where [PriceID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["AppPerson"] = UFBaseLib.BusLib.BaseInfo.UserName;
            NewRow["AppPersonId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
        }
    }
}
