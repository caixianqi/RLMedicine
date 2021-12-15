using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    public class PartsInventoryMain :Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "insert into PartsInventory (PartsInventoryID,PartsApplicationID,RepairMissionCode,CustomerCode,CustomerName,UserId) values ('" + row1["PartsInventoryID"].ToString() + "','" + row1["PartsApplicationID"].ToString() + "','" + row1["RepairMissionCode"].ToString() + "','" + row1["CustomerCode"].ToString() + "','" + row1["CustomerName"].ToString() + "','" + row1["UserId"].ToString() + "')";

            return sql;
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "update PartsInventory set PartsApplicationID = '" + row1["PartsApplicationID"].ToString() + "',RepairMissionCode = '" + row1["RepairMissionCode"].ToString() + "',CustomerCode='" + row1["CustomerCode"].ToString() + "',CustomerName='" + row1["CustomerName"].ToString() + "' where PartsInventoryID = '" + row1["PartsInventoryID"].ToString() + "'";


            return sql;
        }

        public override string Audit(string BillId)
        {
            throw new NotImplementedException();
        }

        public override string UnAudit(string BillId)
        {
            throw new NotImplementedException();
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;
            sql += "delete from PartsInventoryDetails where PartsInventoryID = '" + BillId + "'";
            sql += "delete from PartsUseAndReturnInfo where PartsInventoryID = '" + BillId + "'";
            sql += "delete from PartsInventory where PartsInventoryID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [PartsInventory] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [PartsInventory] where [PartsInventoryID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
            NewRow["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
        
        }
    }
}
