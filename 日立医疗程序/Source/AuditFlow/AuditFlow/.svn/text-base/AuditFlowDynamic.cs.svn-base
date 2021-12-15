using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.AuditFlow
{
    public class AuditFlowFlow
    {
        public System.Data.DataTable TableAuditFlowExpression;
        private string FunctionId;
        public  AuditFlowFlow(string mFunctionId)
        {
            FunctionId = mFunctionId;
            TableAuditFlowExpression = Bao.DataAccess.DataAcc.ExecuteQuery("select b.FunctionId,b.AuditNode,b.ParentNode,a.* from BaoSystem..AuditFlowDefin b left outer join  BaoSystem..AuditFlowExpression a on a.AutoFlowId=b.AutoFlowId where b.FunctionId='" + FunctionId + "'");
        }
        public void Save()
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("delete BaoSystem..AuditFlowExpression "+
                    " from BaoSystem..AuditFlowExpression a,BaoSystem..AuditFlowDefin b "+
                    " where a.AutoFlowId=b.AutoFlowId and FunctionId='" + FunctionId + "'");
            foreach (System.Data.DataRow row1 in TableAuditFlowExpression.Rows)
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery("insert into BaoSystem..AuditFlowExpression(AutoFlowId,AuditUserId,OrderId,EntityId,AuditType) vlaues ('"
                    + row1["AutoFlowId"].ToString() + "','" + row1["AuditUserId"].ToString() + "','" + row1["OrderId"].ToString() +
                    "','" + row1["EntityId"].ToString() +"','" + row1["AuditType"].ToString() + "') ");
                
            }
        }
        //public AuditField[] GetFieldName(string BillId)
        //{
        //    ///相同类型的单据，单号不同走不同的审批流程
        //    System.Data.DataTable dd=Bao.DataAccess.DataAcc.ExecuteQuery("select DISTINCT  FieldName from BaoSystem..AuditFlowDefin b " +
        //                    "left outer join  BaoSystem..AuditFlowExpression a " +
        //                    "on a.AutoFlowId=b.AutoFlowId " +
        //                    " where FunctionId='" + FunctionId + "' and BillId='" + BillId + "' and fieldname <>''");
        //    if (dd.Rows.Count == 0)
        //    {   ///相同类型的单据 走通用的审批流程
        //        dd = Bao.DataAccess.DataAcc.ExecuteQuery("select DISTINCT  FieldName from BaoSystem..AuditFlowDefin b " +
        //                    "left outer join  BaoSystem..AuditFlowExpression a " +
        //                    "on a.AutoFlowId=b.AutoFlowId " +
        //                    " where FunctionId='" + FunctionId + "' and fieldname <>''");
        //    }

        //    if (dd.Rows.Count > 0)
        //    {
        //        AuditField[] bb = new AuditField[dd.Rows.Count];
        //        for (int i = 0; i < dd.Rows.Count; i++)
        //        {
        //            bb[i].FieldName = dd.Rows[i]["FieldName"].ToString().Trim();
        //        }

        //        return bb;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
