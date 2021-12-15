using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class FaultFeedbackMain : Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = "insert into FaultFeedback (FaultFeedBackID,RepairMissionID,ProcessingStatus,CompleteDate,FaultType,Finalsolution)";

            sql = sql + " Values ('" + row1["FaultFeedBackID"].ToString() + "','" + row1["RepairMissionID"].ToString() + "','" + row1["ProcessingStatus"].ToString() + "','" + row1["CompleteDate"].ToString() + "','" + row1["FaultType"].ToString() + "','" + row1["Finalsolution"].ToString() + "')";


            return sql;
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "update  FaultFeedback set ProcessingStatus = '" + row1["ProcessingStatus"].ToString() + "',CompleteDate = '" + row1["CompleteDate"].ToString() + "',FaultType = '" + row1["FaultType"].ToString() + "',Finalsolution = '" + row1["Finalsolution"].ToString() + "',UploadPerson = '" + row1["UploadPerson"].ToString() + "',UploadTime = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL(row1["UploadTime"].ToString()) + ",AuditPerson = '" + row1["AuditPerson"].ToString() + "',AuditTime = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL(row1["AuditTime"].ToString()) + ",AuditState = '" + row1["AuditState"].ToString() + "' where FaultFeedbackID = '" + row1["FaultFeedbackID"].ToString() + "' ";

            return sql;
        }

        public override string Audit(string BillId)
        {
            string sql = string.Empty;

            sql = "update [FaultFeedback] set AuditPerson = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',AuditTime = '" + RiLiGlobal.RiLiDataAcc.GetNow() + "', AuditState = '已审核'  where FaultFeedbackID = '" + BillId + "' ";

            return sql;
        }

        public override string UnAudit(string BillId)
        {
            string sql = string.Empty;

            sql = "update [FaultFeedback] set AuditPerson = null,AuditTime = null,AuditState = '待审核'  where FaultFeedbackID = '" + BillId + "' ";

            return sql;
        }

        public override string DeleteSQL(string BillId)
        {

          

        

         
            string sql = string.Empty;


            sql += "delete from FaultFeedbackDetails where FaultFeedBackID = '" + BillId + "'";
            sql += "delete from FaultFeedback where FaultFeedBackID = '" + BillId + "'";

         

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [FaultFeedback] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [FaultFeedback] where [FaultFeedbackID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    if (item.ColumnName == "UploadTime" || item.ColumnName == "AuditTime")
                    {
                        continue;
                    }
                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
        }
    }
}
