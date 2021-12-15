using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class BillMainData :Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [Bill]
           ([PriceCode]
           ,[PriceID]
           ,[BillID]
           ,[BillCode]
           ,[BillType]
           ,[AppPerson]
           ,[BillTitle]
           ,[TaxRegNum]
           ,[BankName]
           ,[BankAccount]
           ,[CompanyAddress]
           ,[Number]
           ,[SendBillAddress]
           ,[ContractNum]
           ,[ReceivePerson]
           ,[ZipCode]
           ,[Remarks]
           ,[BillNum]
           ,[EMSNum]
           ,[SendBillDate]
           ,BillState
           ,AuditerCode
           ,AuditerName
           ,AppPersonId
          
          )
     VALUES ";

            sql += "( '" + row1["PriceCode"].ToString() + "','" + row1["PriceID"].ToString() + "',";
            sql += "'" + row1["BillID"].ToString() + "',";
            sql += "'" + row1["BillCode"].ToString() + "',";
            sql += "'" + row1["BillType"].ToString() + "',";
            sql += "'" + row1["AppPerson"].ToString() + "',";
            sql += "'" + row1["BillTitle"].ToString() + "',";
            sql += "'" + row1["TaxRegNum"].ToString() + "',";
            sql += "'" + row1["BankName"].ToString() + "',";
            sql += "'" + row1["BankAccount"].ToString() + "',";
            sql += "'" + row1["CompanyAddress"].ToString() + "',";
            sql += "'" + row1["Number"].ToString() + "',";
            sql += "'" + row1["SendBillAddress"].ToString() + "',";
            sql += "'" + row1["ContractNum"].ToString() + "',";
            sql += "'" + row1["ReceivePerson"].ToString() + "',";
            sql += "'" + row1["ZipCode"].ToString() + "',";
            sql += "'" + row1["Remarks"].ToString() + "',";
            sql += "'" + row1["BillNum"].ToString() + "',";
            sql += "'" + row1["EMSNum"].ToString() + "',";
            sql += "'" + row1["SendBillDate"].ToString() + "',";
            sql += "'开票申请',";
            sql += "'" + row1["AuditerCode"].ToString() + "',";
            sql += "'" + row1["AuditerName"].ToString() + "',";
            sql += "'" + row1["AppPersonId"].ToString() + "')";

            return sql;
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = "UPDATE [Bill]" +
   "SET [PriceCode] =  '" + row1["PriceCode"].ToString() + "'" +
      ",[PriceID] = '" + row1["PriceID"].ToString() + "'" +
     " ,[BillType] = '" + row1["BillType"].ToString() + "'" +
     " ,[AppPerson] = '" + row1["AppPerson"].ToString() + "'" +
     " ,[BillTitle] = '" + row1["BillTitle"].ToString() + "'" +
     " ,[TaxRegNum] = '" + row1["TaxRegNum"].ToString() + "'" +
     " ,[BankName] = '" + row1["BankName"].ToString() + "'" +
     " ,[BankAccount] = '" + row1["BankAccount"].ToString() + "'" +
     " ,[CompanyAddress] = '" + row1["CompanyAddress"].ToString() + "'" +
     " ,[Number] = '" + row1["Number"].ToString() + "'" +
     " ,[SendBillAddress] = '" + row1["SendBillAddress"].ToString() + "'" +
     " ,[ContractNum] = '" + row1["ContractNum"].ToString() + "'" +
     " ,[ReceivePerson] = '" + row1["ReceivePerson"].ToString() + "'" +
     " ,[ZipCode] = '" + row1["ZipCode"].ToString() + "'" +
     " ,[Remarks] = '" + row1["Remarks"].ToString() + "'" +
     " ,[BillNum] = '" + row1["BillNum"].ToString() + "'" +
     " ,[EMSNum] = '" + row1["EMSNum"].ToString() + "'" +
     " ,[SendBillDate] = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL( row1["SendBillDate"].ToString()) + "" +

 
       " ,[SendBillRemarks] = '" + row1["SendBillRemarks"].ToString() + "'" +
" WHERE  BillID = '"+row1["BillID"].ToString()+"'";

            return sql;
        }

        public override string Audit(string BillId)
        {
            string sql = string.Empty;

            sql = "update BIll SET BillState = '审核通过',AuditTime = getdate() where BillId = '" + BillId + "'";

            return sql;
        }

        public override string UnAudit(string BillId)
        {
            string sql = string.Empty;

            sql = "update BIll SET BillState = '开票申请',AuditTime = null where BillId = '" + BillId + "'";

            return sql;
        }

        public override string DeleteSQL(string BillId)
        {
            string sql = string.Empty;

            sql += "delete from [BillDetails] where BillId = '" + BillId + "'";
            sql += "delete from [MoneyReceive] where BillId = '" + BillId + "'";
            sql += "delete from [Bill] where BillId = '" + BillId + "'";

            return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [Bill] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [Bill] where [BillID] = '" + BillId + "'";
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
                    if (item.ColumnName == "UploadReceiveDate" || item.ColumnName == "UploadSendBillDate" || item.ColumnName == "UploadDate" || item.ColumnName == "AuditTime")
                    {
                        continue;
                    }
                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
        }
    }
}
