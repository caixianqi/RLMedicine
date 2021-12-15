using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class PriceMainData:Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string sql = string.Empty;

            sql = @"INSERT INTO [Price]
           ([RepairMissionID]
           ,[RepairMissionCode]
           ,[PriceID]
           ,[PriceCode]
           ,[CustomerCode]
           ,[CustomerName]
           ,[ApplicationPerson]
           ,[PriceDate]
           ,[Contact]
           ,[InventoryName]
           ,[InventoryCode]
           ,[Remarks]
           ,[RepairCost]
           ,[TravelCost]
           ,[PaymentUnit]
           ,[TaxRegistrationNumber]
           ,[Account]
           ,[BankName]
           ,[UserId]
           ,[State]
           ,[RemarksForReview]
           ,FaxNumber
         )
     VALUES ";

            sql = sql + "('" + row1["RepairMissionID"].ToString() + "','" + row1["RepairMissionCode"].ToString() + "','" + row1["PriceID"].ToString() + "','" + row1["PriceCode"].ToString() + "','" +
                        row1["CustomerCode"].ToString() + "','" + row1["CustomerName"].ToString() + "','" + row1["ApplicationPerson"].ToString() + "','" + row1["PriceDate"].ToString() + "','" +
                        row1["Contact"].ToString() + "','" + row1["InventoryName"].ToString() + "','" + row1["InventoryCode"].ToString() + "','" + row1["Remarks"].ToString() + "','" +
                        row1["RepairCost"].ToString() + "','" + row1["TravelCost"].ToString() + "','" + row1["PaymentUnit"].ToString() + "','" + row1["TaxRegistrationNumber"].ToString() + "','" +
                        row1["Account"].ToString() + "','" + row1["BankName"].ToString() + "','" + row1["UserId"].ToString() + "','新报价','" + row1["RemarksForReview"].ToString() + "','" + row1["FaxNumber"].ToString() + "')";

            return sql;

                
              
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string sql = string.Empty;
           // 保存的时候，不要把单据状态也保存，包括用户名、时间、本身的状态、发票也要注意
            sql = "Update [Price] set RepairMissionID = '" + row1["RepairMissionID"].ToString() + "',RepairMissionCode = '" + row1["RepairMissionCode"].ToString() + "',CustomerCode='" + row1["CustomerCode"].ToString() + "',CustomerName='" + row1["CustomerName"].ToString() + "',ApplicationPerson = '" + row1["ApplicationPerson"].ToString() + "',PriceDate = '" + row1["PriceDate"].ToString() + "',Contact = '" + row1["Contact"].ToString() + "',InventoryName='" + row1["InventoryName"].ToString() + "',InventoryCode = '" + row1["InventoryCode"].ToString() + "',Remarks = '" + row1["Remarks"].ToString() + "',RepairCost = " + row1["RepairCost"].ToString() + ",TravelCost = " + row1["TravelCost"].ToString() + ",PaymentUnit = '" + row1["PaymentUnit"].ToString() + "',TaxRegistrationNumber = '" + row1["TaxRegistrationNumber"].ToString() + "',Account = '" + row1["Account"].ToString() + "',BankName = '" + row1["BankName"].ToString() + "',ddate = '" + row1["ddate"].ToString() + "',RemarksForReview = '" + row1["RemarksForReview"].ToString() + "' ,FaxNumber = '" + row1["FaxNumber"].ToString() + "' where PriceID = '" + row1["PriceID"].ToString() + "'";

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
            sql = "Delete FROM [PriceDetails] where [PriceID] = '" + BillId + "' ";
            sql += "Delete FROM [Price] where [PriceID] = '" + BillId + "'";
      
            return sql;
        }

        public override string SelectSQL(string BillId)
        {
              
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [Price] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [Price] where [PriceID] = '" + BillId + "'";
            }


            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            NewRow["PriceDate"] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
            NewRow["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    if (item.ColumnName == "MoneyReachDate" || item.ColumnName == "ReviewDate" || item.ColumnName == "UploadDate")
                    {
                        continue;
                    }

                    NewRow[item.ColumnName] =  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
        }
    }
}
