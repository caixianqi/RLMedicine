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
           ,[fSN2]
           ,[ReportRepartDate]
           ,[PurchaseDate]
           ,[ZoneName]
           ,[ZoneCode]
           ,[RepairType]
           ,[RepairSource]
           ,[RepairContractPeople]
           ,[ContractNumber]
           ,[FaxNumber]
           ,[rInsShop]
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
            ,[Color]
            ,[RepairtypeNew] ,[dtimefh],[dtimegc] ,[dtimefhbx] ,[dtimegcbx] ,[dtimeazbx],[tdbxyd],[jqjbcode],[MachineType],[MachineLevel],[MachineModel],[xsCusName],[ProductLine] )
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
                //,<fSN2, varchar(25),>
        + "'" + row1["fSN2"].ToString() + "',"
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
                //,<rInsShop, varchar(25),>
              + "'" + row1["rInsShop"].ToString() + "',"
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
              + "'" + row1["RepairPersonName"].ToString() + "','" + row1["UserId"].ToString() + "','新任务','" + row1["CustomerDepartmentCode"].ToString() + "','" + row1["RepairUnit1"].ToString() + "','" + row1["RepairUnit2"].ToString() + "','" + row1["City"].ToString() + "','" + row1["Color"].ToString() + "'"
              + ",'" + row1["RepairtypeNew"].ToString() + "','" + row1["dtimefh_t"].ToString() + "','" + row1["dtimegc_t"].ToString() + "','" + row1["dtimefhbx_t"].ToString() + "','"
              + row1["dtimegcbx_t"].ToString() + "','" + row1["dtimeazbx_t"].ToString() + "','" + row1["tdbxyd"].ToString() + "','" + row1["jqjbcode"].ToString() + "','" + row1["MachineType"].ToString() + "','" + row1["MachineLevel"].ToString() + "','" + row1["MachineModel"].ToString()
              + "','" + row1["xsCusName"].ToString() + "','" + row1["ProductLine"].ToString() + "')";

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
                     "',[fSN2] = '" + row1["fSN2"].ToString() +
                     "',[ReportRepartDate] ='" + row1["ReportRepartDate"].ToString() +
                     "',[PurchaseDate] ='" + row1["PurchaseDate"].ToString() +
                     "',[ZoneName] = '" + row1["ZoneName"].ToString() +
                     "',[ZoneCode] = '" + row1["ZoneCode"].ToString() +
                     "',[RepairType] = '" + row1["RepairType"].ToString() +
                     "',[RepairSource] = '" + row1["RepairSource"].ToString() +
                     "',[RepairContractPeople] = '" + row1["RepairContractPeople"].ToString() +
                     "',[ContractNumber] = '" + row1["ContractNumber"].ToString() +
                     "',[FaxNumber] = '" + row1["FaxNumber"].ToString() +
                     "',[rInsShop] = '" + row1["rInsShop"].ToString() +
                     "',[CustomerManagerCode] = '" + row1["CustomerManagerCode"].ToString() +
                     "',[CustomerManagerName] = '" + row1["CustomerManagerName"].ToString() +
                     "',[SubmitMissonDate] = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL(row1["SubmitMissonDate"].ToString()) +
                     ",[FaultDetails] = '" + row1["FaultDetails"].ToString() +
                     "',[SubmitPersonDate] = " + RiLiGlobal.RiLiDataAcc.ProcessDateforSQL(row1["SubmitPersonDate"].ToString()) +
                     ",[RepairPersonCode] = '" + row1["RepairPersonCode"].ToString() +
                      "',[SubmitMissonUser] = '" + row1["SubmitMissonUser"].ToString() +
                       "',[SubmitPersonUser] = '" + row1["SubmitPersonUser"].ToString() +
                        "',[State] = '" + row1["State"].ToString() +
                         "',[RepairUnit1] = '" + row1["RepairUnit1"].ToString() +
                          "',[RepairUnit2] = '" + row1["RepairUnit2"].ToString() +
                           "',[City] = '" + row1["City"].ToString() +
                            "',[Color] = '" + row1["Color"].ToString() +
                                "',[jqjbcode] = '" + row1["jqjbcode"].ToString() +
                                    "',[MachineType] = '" + row1["MachineType"].ToString() +
                                        "',[MachineModel] = '" + row1["MachineModel"].ToString() +
                                            "',[MachineLevel] = '" + row1["MachineLevel"].ToString() +
                                             "',[ProductLine] = '" + row1["ProductLine"].ToString() +
                     "',[RepairPersonName] = '" + row1["RepairPersonName"].ToString() +
                     "',[RepairtypeNew] = '" + row1["RepairtypeNew"].ToString() +
                      "',[dtimefh] = '" + row1["dtimefh_t"].ToString() +
                       "',[dtimegc] = '" + row1["dtimegc_t"].ToString() +
                        "',[dtimefhbx] = '" + row1["dtimefhbx_t"].ToString() +
                         "',[dtimegcbx] = '" + row1["dtimegcbx_t"].ToString() +
                          "',[dtimeazbx] = '" + row1["dtimeazbx_t"].ToString() +
                           "',[tdbxyd] = '" + row1["tdbxyd"].ToString() +
                            "',[AuditMissonUser] = '" + row1["AuditMissonUser"].ToString() +
                             "',[AuditMissonDate] = '" + row1["AuditMissonDate"].ToString()+
                     "',xsCusName='"+row1["xsCusName"].ToString()+"' where RepairMissionID = '" + id + "'";

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

        /// <summary>
        /// 2014-6-10、修改日志：由于之前的日期是空的，默认显示今天，要修改为默认显示：1900-01-01
        /// </summary>
        /// <param name="BillId"></param>
        /// <returns></returns>
        public override string SelectSQL(string BillId)
        {
            string selectSQL = string.Empty;

            if (BillId == string.Empty)
            {
                selectSQL = "select *,'' as dtimefh_t,'' as dtimegc_t,'' as dtimefhbx_t,'' as dtimegcbx_t,'' as dtimeazbx_t FROM [RepairMission] where 1=2";
            }
            else
            {
                selectSQL = "select *,ISNULL(dtimefh, '1900-01-01') as dtimefh_t,ISNULL(dtimegc, '1900-01-01') as dtimegc_t,ISNULL(dtimefhbx, '1900-01-01') as dtimefhbx_t,ISNULL(dtimegcbx, '1900-01-01') as dtimegcbx_t,ISNULL(dtimeazbx, '1900-01-01') as dtimeazbx_t FROM [RepairMission] where [RepairMissionID] = '" + BillId + "'";
            }
            

            return selectSQL;
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            foreach (DataColumn item in NewRow.Table.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    if (item.ColumnName == "SubmitMissonDate" || item.ColumnName == "SubmitPersonDate")
                    {
                        continue;
                    }

                    NewRow[item.ColumnName] = RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString();
                }
            }
            NewRow["UserId"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
           
        }
    }
}
