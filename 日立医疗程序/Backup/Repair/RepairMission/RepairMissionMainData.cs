using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair
{
    class RepairMissionMainData :Bao.BillBase.EntityTableMain
    {
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            string insertSql = string.Empty;

            insertSql = @"INSERT INTO [RepairMission]
           ( [RepairMissionID]
           ,[RepairMissionCode]
           ,[CustomerCode]
           ,[CustomerName]
           ,[CustomerDepartmentName]
           ,[MachineCode]
           ,[MachineName]
           ,[ManufactureCode]
           ,[SoftwareVersion]
           ,[ReportRepartDate]
           ,[PurchaseDate]
           ,[ZoneName]
           ,[ZoneCode]
           ,[RepairType]
           ,[RepairSource]
           ,[RepairContractPeople]
           ,[ContractNumber]
           ,[FaxNumber]
           ,[CustomerManagerCode]
           ,[CustomerManagerName]
           ,[SubmitMissonDate]
           ,[FaultDetails]
           ,[SubmitPersonDate]
           ,[RepairPersonCode]
           ,[RepairPersonName]
           , [UserId]
           ,[State]
           ,[CustomerDepartmentCode]
            ,[RepairUnit1]
,[RepairUnit2]
,[City]
,[Color])
     VALUES" + "(" +

         "'" + row1["RepairMissionID"].ToString() + "',"

           //,<RepairMissionCode, varchar(50),>
        + "'" + row1["RepairMissionCode"].ToString() + "',"
                //,<CustomerCode, varchar(50),>
         + "'" + row1["CustomerCode"].ToString() + "',"
                //,<CustomerName, varchar(50),>
         + "'" + row1["CustomerName"].ToString() + "',"
                //,<CustomerDepartmentName, varchar(50),>
        + "'" + row1["CustomerDepartmentName"].ToString() + "',"
                //,<MachineCode, varchar(50),>
        + "'" + row1["MachineCode"].ToString() + "',"
                //,<MachineName, varchar(255),>
         + "'" + row1["MachineName"].ToString() + "',"
                //,<ManufactureCode, varchar(50),>
        + "'" + row1["ManufactureCode"].ToString() + "',"
                //,<SoftwareVersion, varchar(25),>
        + "'" + row1["SoftwareVersion"].ToString() + "',"
                //,<ReportRepartDate, datetime,>
         + "'" + row1["ReportRepartDate"].ToString() + "',"
                //,<PurchaseDate, datetime,>
         + "'" + row1["PurchaseDate"].ToString() + "',"
                //,<ZoneName, varchar(50),>
         + "'" + row1["ZoneName"].ToString() + "',"
         + "'" + row1["ZoneCode"].ToString() + "',"
                //,<RepairType, varchar(25),>
              + "'" + row1["RepairType"].ToString() + "',"
                //,<RepairSource, varchar(25),>
              + "'" + row1["RepairSource"].ToString() + "',"
                //,<RepairContractPeople, varchar(25),>
              + "'" + row1["RepairContractPeople"].ToString() + "',"
                //,<ContractNumber, varchar(25),>
              + "'" + row1["ContractNumber"].ToString() + "',"
                //,<FaxNumber, varchar(25),>
              + "'" + row1["FaxNumber"].ToString() + "',"
                //,<CustomerManagerCode, varchar(25),>
              + "'" + row1["CustomerManagerCode"].ToString() + "',"
                //,<CustomerManagerName, varchar(25),>
              + "'" + row1["CustomerManagerName"].ToString() + "',"
                //,<SubmitMissonDate, datetime,>
              + "'" + row1["SubmitMissonDate"].ToString() + "',"
                //,<FaultDetails, text,>
              + "'" + row1["FaultDetails"].ToString() + "',"
                //,<SubmitPersonDate, datetime,>
              + "'" + row1["SubmitPersonDate"].ToString() + "',"
                //,<RepairPersonCode, varchar(25),>
              + "'" + row1["RepairPersonCode"].ToString() + "',"
                //,<RepairPersonName, varchar(25),>)"
              + "'" + row1["RepairPersonName"].ToString() + "','" + row1["UserId"].ToString() + "','新任务','" + row1["CustomerDepartmentCode"].ToString() + "','" + row1["RepairUnit1"].ToString() + "','" + row1["RepairUnit2"].ToString() + "','" + row1["City"].ToString() + "','" + row1["Color"].ToString() + "')";

            return insertSql;
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            string id = row1["RepairMissionID"].ToString();
          

            

            

            string upadateSql = string.Empty;

            upadateSql = "UPDATE [RepairMission] Set" +

       "[RepairMissionCode] = '" + row1["RepairMissionCode"].ToString() +
     "',[CustomerCode] ='" + row1["CustomerCode"].ToString() +
      "',[CustomerName] = '" + row1["CustomerName"].ToString() +
      "',[CustomerDepartmentName] = '" + row1["CustomerDepartmentName"].ToString() +
          "',[CustomerDepartmentCode] = '" + row1["CustomerDepartmentCode"].ToString() +
      "',[MachineCode] = '" + row1["MachineCode"].ToString() +
     "',[MachineName] = '" + row1["MachineName"].ToString() +
     "',[ManufactureCode] = '" + row1["ManufactureCode"].ToString() +
     "',[SoftwareVersion] = '" + row1["SoftwareVersion"].ToString() +
     "',[ReportRepartDate] ='" + row1["ReportRepartDate"].ToString() +
     "',[PurchaseDate] ='" + row1["PurchaseDate"].ToString() +
     "',[ZoneName] = '" + row1["ZoneName"].ToString() +
     "',[ZoneCode] = '" + row1["ZoneCode"].ToString() +
     "',[RepairType] = '" + row1["RepairType"].ToString() +
     "',[RepairSource] = '" + row1["RepairSource"].ToString() +
     "',[RepairContractPeople] = '" + row1["RepairContractPeople"].ToString() +
     "',[ContractNumber] = '" + row1["ContractNumber"].ToString() +
     "',[FaxNumber] = '" + row1["FaxNumber"].ToString() +
     "',[CustomerManagerCode] = '" + row1["CustomerManagerCode"].ToString() +
     "',[CustomerManagerName] = '" + row1["CustomerManagerName"].ToString() +
     "',[SubmitMissonDate] = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL( row1["SubmitMissonDate"].ToString()) +
     ",[FaultDetails] = '" + row1["FaultDetails"].ToString() +
     "',[SubmitPersonDate] = " +RiLiGlobal.RiLiDataAcc.ProcessDateforSQL( row1["SubmitPersonDate"].ToString()) +
     ",[RepairPersonCode] = '" + row1["RepairPersonCode"].ToString() +
      "',[SubmitMissonUser] = '" + row1["SubmitMissonUser"].ToString() +
       "',[SubmitPersonUser] = '" + row1["SubmitPersonUser"].ToString() +
        "',[State] = '" + row1["State"].ToString() +
         "',[RepairUnit1] = '" + row1["RepairUnit1"].ToString() +
          "',[RepairUnit2] = '" + row1["RepairUnit2"].ToString() +
           "',[City] = '" + row1["City"].ToString() +
            "',[Color] = '" + row1["Color"].ToString() +
     "',[RepairPersonName] = '" + row1["RepairPersonName"].ToString() +"'"+
     "where RepairMissionID = '"+id+"'";

            return upadateSql;


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
          string sql = "delete from [RepairMission] where [RepairMissionID] = '" + BillId + "'";

          return sql;
        }

        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select * FROM [RepairMission] where 1=2";
            }
            else
            {
                selectSQL = "select * FROM [RepairMission] where [RepairMissionID] = '" + BillId + "'";
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
