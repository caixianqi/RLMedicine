using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    class BillDetails :Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [BillDetails]      ([AutoID]
           ,[BillID]
           ,[Content]
           ,[iquantity]
           ,[money])";

            sql += "Values ('" + row1["AutoID"].ToString() + "','" + row1["BillID"].ToString() + "','" + row1["Content"].ToString() + "'," + row1["iquantity"].ToString() + "," + row1["money"].ToString() + ")";


            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "delete from [BillDetails] where BillID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [BillDetails] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [BillDetails] where [BillID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
          
        }
    }
}
