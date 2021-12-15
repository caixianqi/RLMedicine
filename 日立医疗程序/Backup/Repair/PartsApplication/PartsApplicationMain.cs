﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class PartsApplicationMain :Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;


            sql = "insert into  PartsApplication (PartsApplicationID,RepairMissionID,PartsApplicationCode,CustomerCode,CustomerName,RepairMissionCode,ApplicationPersonCode,ApplicationPersonName,ApplicationDate,ApplyingReasons,UserId,AuditerCode,AuditerName) Values ('" + row1["PartsApplicationID"].ToString() + "','" + row1["RepairMissionID"].ToString() + "','" + row1["PartsApplicationCode"].ToString() + "','" + row1["CustomerCode"].ToString() + "','" + row1["CustomerName"].ToString() + "','" + row1["RepairMissionCode"].ToString() + "','" + row1["ApplicationPersonCode"].ToString() + "','" + row1["ApplicationPersonName"].ToString() + "','" + row1["ApplicationDate"].ToString() + "','" + row1["ApplyingReasons"].ToString() + "','" + row1["UserId"].ToString() + "','" + row1["AuditerCode"].ToString() + "','" + row1["AuditerName"].ToString() + "')";

            return sql;
      }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "update  PartsApplication set PartsApplicationCode='" + row1["PartsApplicationCode"].ToString() + "',CustomerCode='" + row1["CustomerCode"].ToString() + "',CustomerName='" + row1["CustomerName"].ToString() + "',RepairMissionCode='" + row1["RepairMissionCode"].ToString() + "',ApplicationPersonCode='" + row1["ApplicationPersonCode"].ToString() + "',ApplicationPersonName='" + row1["ApplicationPersonName"].ToString() + "',ApplicationDate='" + row1["ApplicationDate"].ToString() + "',ApplyingReasons='" + row1["ApplyingReasons"].ToString() + "',AuditerCode='" + row1["AuditerCode"].ToString() + "',AuditerName='" + row1["AuditerName"].ToString() + "' where PartsApplicationID = '" + row1["PartsApplicationID"].ToString() + "'";

            return sql;


        }

        public override string Audit(string BillId)
        {
            string sql = string.Empty;
            sql = "update  PartsApplication set AuditTime = '" +  RiLiGlobal.RiLiDataAcc.GetNow().ToString() + "' , AuditName = '" + UFBaseLib.BusLib.BaseInfo.UserName + "' where PartsApplicationID = '"+BillId+"'";

            return sql;
        }

        public override string UnAudit(string BillId)
        {
            string sql = string.Empty;
            sql = "update  PartsApplication set AuditTime = null , AuditName =null where PartsApplicationID = '" + BillId + "'";

            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql += "delete from PartsApplicationDetails where PartsApplicationID = '" + BillId + "'";
            sql += "delete from PartsApplication where PartsApplicationID = '" + BillId + "'";
            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [PartsApplication] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [PartsApplication] where [PartsApplicationID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            NewRow["ApplicationPersonName"] = UFBaseLib.BusLib.BaseInfo.UserName;
          
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    if (item.ColumnName == "ApplicationDate" || item.ColumnName == "AuditTime" )
                    {
                        continue;
                    }
                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
        }
    }
}
