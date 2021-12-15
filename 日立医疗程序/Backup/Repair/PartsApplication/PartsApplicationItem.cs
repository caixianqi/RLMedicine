using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    class PartsApplicationItem :Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "insert into PartsApplicationDetails (PartsApplicationID,AutoID,InventoryCode,InventoryName,iquantity,ArrivalLocation,Remarks,InventoryEngName,InventoryStd) values ('" + row1["PartsApplicationID"].ToString() + "','" + row1["AutoID"].ToString() + "','" + row1["InventoryCode"].ToString() + "','" + row1["InventoryName"].ToString() + "','" + row1["iquantity"].ToString() + "','" + row1["ArrivalLocation"].ToString() + "','" + row1["Remarks"].ToString() + "','" + row1["InventoryEngName"].ToString() + "','" + row1["InventoryStd"].ToString() + "')";

            return sql;
            
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "delete from PartsApplicationDetails where PartsApplicationID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string sql = string.Empty;

            if (BillId == string.Empty)
            {
                return "select * from PartsApplicationDetails where 1=2";
            }
            else
            {
                return "select * from PartsApplicationDetails where   PartsApplicationID = '" + BillId + "'";

            }
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
          
        }
    }
}
