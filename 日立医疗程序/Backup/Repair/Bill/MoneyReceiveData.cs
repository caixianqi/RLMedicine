using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    class MoneyReceiveData :Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [MoneyReceive]
           ([AutoId]
           ,[BillID]
           ,[MoneyReceiveDate]
           ,[Money]
           ,[Remarks])
     VALUES (";

            sql = sql + "'" + row1["AutoId"].ToString() + "','" + row1["BillID"].ToString() + "','" + row1["MoneyReceiveDate"].ToString() + "'," + row1["Money"].ToString() + ",'" + row1["Remarks"].ToString() + "' ) ";


            return sql;
             
            
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = "delete from [MoneyReceive] where BillID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [MoneyReceive] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [MoneyReceive] where [BillID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
           
        }
    }
}
