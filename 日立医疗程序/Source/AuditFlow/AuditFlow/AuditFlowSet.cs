using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.AuditFlow
{
    public class AuditFlowSet
    {
        public System.Data.DataTable TableAuditFlowInfo;
        private string FunctionId;
        public AuditFlowSet(string mFunctionId)
        {
            FunctionId = mFunctionId;
            TableAuditFlowInfo = Bao.DataAccess.DataAcc.ExecuteQuery("select * from BaoSystem..AuditFlowDefin where FunctionId='" + FunctionId + "'");
        }
        public void Save()
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("delete BaoSystem..AuditFlowDefin where FunctionId='" + FunctionId + "'");
            foreach (System.Data.DataRow  row1 in TableAuditFlowInfo.Rows)
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery("insert into BaoSystem..AuditFlowDefin (FunctionId,AuditNode,ParentNode) vlaues ('" 
                    +row1["FunctionId"].ToString() + "','" + row1["AuditNode"].ToString() + "','" +row1["ParentNode"].ToString() + "') ");
                
            }
        }
    }
}
