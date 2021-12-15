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
           ,[RepairCost]
           ,[TravelCost]
           ,[CompanyAddress]
           ,[CompanyArea]
           ,[CompanyProvince]
           ,[AreaCode]
           ,[Number]
           ,[SendBillAddress]
           ,[SendBillArea]
           ,[SendBillProvince]
           ,[ContractAreaCode]
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
           ,SerialNumber
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
            sql += "'" + row1["RepairCost"].ToString() + "',";
            sql += "'" + row1["TravelCost"].ToString() + "',";
            sql += "'" + row1["CompanyAddress"].ToString() + "',";
            sql += "'" + row1["CompanyArea"].ToString() + "',";
            sql += "'" + row1["CompanyProvince"].ToString() + "',";
            sql += "'" + row1["AreaCode"].ToString() + "',";
            sql += "'" + row1["Number"].ToString() + "',";
            sql += "'" + row1["SendBillAddress"].ToString() + "',";
            sql += "'" + row1["SendBillArea"].ToString() + "',";
            sql += "'" + row1["SendBillProvince"].ToString() + "',";
            sql += "'" + row1["ContractAreaCode"].ToString() + "',";
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
            sql += "'" + row1["AppPersonId"].ToString() + "',";
            sql += "(select max(isnull(SerialNumber, 0)) + 1 from [Bill]))";

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
     " ,[RepairCost] = '" + row1["RepairCost"].ToString() + "'" +
     " ,[TravelCost] = '" + row1["TravelCost"].ToString() + "'" +
     " ,[CompanyAddress] = '" + row1["CompanyAddress"].ToString() + "'" +
     " ,[CompanyArea] = '" + row1["CompanyArea"].ToString() + "'" +
     " ,[CompanyProvince] = '" + row1["CompanyProvince"].ToString() + "'" +
     " ,[AreaCode] = '" + row1["AreaCode"].ToString() + "'" +
     " ,[Number] = '" + row1["Number"].ToString() + "'" +
     " ,[SendBillAddress] = '" + row1["SendBillAddress"].ToString() + "'" +
     " ,[SendBillArea] = '" + row1["SendBillArea"].ToString() + "'" +
     " ,[SendBillProvince] = '" + row1["SendBillProvince"].ToString() + "'" +
     " ,[ContractAreaCode] = '" + row1["ContractAreaCode"].ToString() + "'" +
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

            /****************2012-12-06**新增*************************/
            string userid = string.Empty;
            string username = string.Empty;
            get_AuditerName(out userid, out username);
            NewRow["AuditerCode"] = userid;
            NewRow["AuditerName"] = username;
            /****************2012-12-06**新增*************************/

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

        /// <summary>
        /// /****************2012-12-06**新增*************************/
        /// 带出开票人对应的部长
        /// </summary>
        private void get_AuditerName(out string userid, out string username)
        {
            string sql = string.Format(@"select u.userName, u.UserId from Users u 
                                                                    left join TRoleUsers ru 
                                                                           on u.AutoUserId = ru.AutoUserId 
                                                                    left join TRole r 
                                                                            on ru.RoleId = r.RoleId
			                                where r.RoleId = '009' 
                                                     and deptNum in 
				                                                            (select b.parentNum from BaseDepartMent b 
											                                                            right join Users u1 
												                                                            on b.deptNum = u1.deptNum 
									                                                            where u1.UserId = '{0}')", UFBaseLib.BusLib.BaseInfo.DBUserID);
            //查找出申请人对应的部长
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);

            if (dt.Rows.Count > 0)
            {
                userid = dt.Rows[0]["UserId"].ToString();
                username = dt.Rows[0]["userName"].ToString();
            }
            else
            {
                userid = string.Empty;
                username = string.Empty;
            }
        }
    }
}
