using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class FaultFeedbackDetails : Bao.BillBase.EntityTableItem
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            string start =string.Empty;
            string rech = string.Empty;
            if (row1["StartingDate"].ToString() == string.Empty)
            {
                start = "null";
            }
            else
            {
                start = "'" + row1["StartingDate"].ToString() + "'";
            }

            if (row1["ReachDate"].ToString() == string.Empty)
            {
                rech = "null";
            }
            else
            {
                rech = "'" + row1["ReachDate"].ToString() + "'";
            }
            sql = "insert into FaultFeedbackDetails (FaultFeedBackID,AutoID,ActualRepairPersonCode,ActualRepairPersonName,StartingDate,ReachDate,FaultPhenomenon,Solution,CompleteDate,State)";

            sql = sql + " Values ('" + row1["FaultFeedBackID"].ToString() + "','" + row1["AutoID"].ToString() + "','" + row1["ActualRepairPersonCode"].ToString() + "','" + row1["ActualRepairPersonName"].ToString() + "'," + start + "," + rech + ",'" + row1["FaultPhenomenon"].ToString() + "','" + row1["Solution"].ToString() + "','" + row1["CompleteDate"].ToString() + "','" + row1["State"].ToString() + "' )";


            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "delete from FaultFeedbackDetails where FaultFeedBackID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [FaultFeedbackDetails] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [FaultFeedbackDetails] where [FaultFeedBackID] = '" + BillId + "'";
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
        }
    }
}
