using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.AuditFlow
{
    public static class AuditFactory
    {
        public static void CreateAuditFlow(string mFunctionId)
        {
            //System.Data.DataTable dd = Bao.DataAccess.DataAcc.ExecuteQuery("select * from AuditFlowDefin where FunctionId='" + mFunctionId + "' ");
            //if (dd.Rows[0]["FixedFlow"].ToString() == "1")
            //{
            //    return new AuditFlowDynamic(mFunctionId);
            //}
            //else
            //{
            //    return new AuditFlowFixed(mFunctionId);
            //}
        }
    }
}
