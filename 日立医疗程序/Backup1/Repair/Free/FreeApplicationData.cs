using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class FreeApplicationData :Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [FreeApplication]
           ([FreeID]
           ,[CustomerCode]
           ,[RepairMissionID]
           ,[RepairMissionCode]
           ,[AppReson]
           ,[CustomerName],AppPerson,AppPersonId,AuditerCode,AuditerName) Values ";

            sql = sql + "('" + BillId + "','" + row1["CustomerCode"] + "','" + row1["RepairMissionID"] + "','" + row1["RepairMissionCode"] + "','" + row1["AppReson"] + "','" + row1["CustomerName"] + "','" + row1["AppPerson"].ToString() + "','" + row1["AppPersonId"].ToString() + "','" + row1["AuditerCode"].ToString() + "','" + row1["AuditerName"].ToString() + "')";

            return sql;
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string updatesql = string.Empty;

            updatesql = "update [FreeApplication] set CustomerCode = '" + row1["CustomerCode"].ToString() + "',RepairMissionID = '" + row1["RepairMissionID"].ToString() + "',RepairMissionCode = '" + row1["RepairMissionCode"].ToString() + "',AppReson = '" + row1["AppReson"].ToString() + "',CustomerName = '" + row1["CustomerName"].ToString() + "',AuditTime = " +RiLiGlobal.RiLiDataAcc.ProcessDateforSQL( row1["AuditTime"].ToString()) + ",AuditPerson = '" + row1["AuditPerson"].ToString() + "',UploadPerson = '" + row1["UploadPerson"].ToString() + "',UploadDate = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL( row1["UploadDate"].ToString()) + ",AuditerCode = '" + row1["AuditerCode"].ToString() + "',AuditerName = '" + row1["AuditerName"].ToString() + "' where FreeID = '" + row1["FreeID"].ToString() + "'";

            return updatesql;
        }

        public override string Audit(string BillId)
        {
            string sql = string.Empty;

            sql = "update [FreeApplication] set AuditPerson = '" + UFBaseLib.BusLib.BaseInfo.UserName + "',AuditTime = '" +  RiLiGlobal.RiLiDataAcc.GetNow().ToString() + "',IsPass = '同意' where FreeID = '" + BillId + "'";

            return sql;
        }

        public override string UnAudit(string BillId)
        {
            string sql = string.Empty;

            sql = "update [FreeApplication] set AuditPerson = null,AuditTime = null,IsPass = '不同意' where FreeID = '" + BillId + "' ";

            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql = "delete from [FreeApplication]   where FreeID = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [FreeApplication] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [FreeApplication] where [FreeID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["AppPerson"] = UFBaseLib.BusLib.BaseInfo.UserName;
            NewRow["AppPersonId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    if (item.ColumnName == "UploadDate" || item.ColumnName == "AuditTime")
                    {
                        continue;
                    }
                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
        }
    }
}
