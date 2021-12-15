using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.AuditFlow
{
    class AuditBaseTable : Bao.BillBase.EntityTableMain 
    {
        public AuditBaseTable()
        {
            //如果是主表则进行以下标记
             //记录本表的表名
            this.TableName = "BaoSystem..AuditFlowLine";


        }
        public override string InsertSQL(string BillId,System.Data.DataRow row1)
        {
            return "";
            //return "insert into  BaoSystem..AuditLog (BillId,FunctionId,JFWId,Memo,Flag,Score) values ('"
            //    + row1["JFWId"].ToString() + "','" + row1["FunctionId"].ToString() + "','"
            //    + row1["JFWId"].ToString()+ "','" + row1["Memo"].ToString() + "','"
            //    + row1["Flag"].ToString() + "','" + row1["Score"].ToString() + "')";
        }

        public override string UpdataSQL(System.Data.DataRow row1)
        {
            return "";
           // AuditExec exec = new AuditExec();
           // exec.Exec(UFBaseLib.BusLib.BaseInfo.DBUserID, row1["FunctionId"].ToString(), row1["JFWId"].ToString());
        }

        public override string DeleteSQL(string BillId)
        {
            return "";
            //return "delete BaoSystem..AuditLog where BillId='" + BillId + "' ";
        }

        public override string SelectSQL(string BillId)
        {
            return "select * from BaoSystem..AuditFlowLine where BillId='" + BillId + "' ";
        }

        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow row1)
        {
            row1["FunctionId"] = ((AuditBaseBill)Sender).FunctionId;
            row1["JFWId"] = ((AuditBaseBill)Sender).JFWId;

            row1["AuditFlag"] = "1";

           
        }

        public override string Audit(string BillId)
        {
            AuditExec exec = new AuditExec();
            //exec.Exec(UFBaseLib.BusLib.BaseInfo.DBUserID,,BillId)
            return "Update BaoSystem..AuditFlowLine set AuditFlag='1',AuditUserId='"+UFBaseLib.BusLib.BaseInfo.DBUserID +"' where AutoFlowId='" + BillId + "' ";
            
        }


        public override string UnAudit(string BillId)
        {
            return "Update BaoSystem..AuditFlowLine set AuditFlag='0',AuditUserId='' where AutoFlowId='" + BillId + "' ";
            
        }
    }
}
