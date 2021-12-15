using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.AuditFlow
{
    public class AuditLine 
    {
        public void CreateLine(string FunctionId,string BillId)
        {
            
            ///相同类型的单据，单号不同走不同的审批流程
            string sql = "select DISTINCT a.AutoFlowId,b.FunctionId,b.AuditNode,b.ParentNode " +
                    " from BaoSystem..AuditFlowExpression a,BaoSystem..AuditFlowDefin b " +
                    " where a.AutoFlowId=b.AutoFlowId and b.FunctionId='" + FunctionId +
                    "'  ";
            
            System.Data.DataTable dd = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            //if (dd.Rows.Count == 0)
            //{   /// 走通用的审批流程
            //    sql = "select DISTINCT a.AutoFlowId,b.FunctionId,b.AuditNode,b.ParentNode " +
            //       " from BaoSystem..AuditFlowExpression a,BaoSystem..AuditFlowDefin b " +
            //       " where a.AutoFlowId=b.AutoFlowId and b.FunctionId='" + FunctionId +
            //       "'";
            //    dd = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            //}
            string nu1= Bao.DataAccess.DataAcc.ExecuteScalar("select max(AuditNum) AuditNum " +
                " from BaoSystem..AuditFlowLine where AutoFlowId='" + dd.Rows[0]["AutoFlowId"].ToString().Trim() +
                "' and billId='" + BillId + "'");
            if (nu1 == "") nu1 = "0";
            int num1 =int.Parse( nu1);
            num1++;
            
            foreach (System.Data.DataRow row1 in dd.Rows)                      //没有条件分支的节点直接产生审批节点
            {
                //System.Diagnostics.Debug.WriteLine(row1["FieldName"].ToString());
                //if (row1["FieldName"].ToString().Trim() == "")              
                {
                    InsertLine(row1, BillId, num1);
                }

            }
            #region
            //for (int i=0;i<FieldInfo.Length ;i++)                           //有条件分支的节点根据条件产生相应的审批节点
            //{
            //    int j = 0;
            //    string Expression="";
            //    foreach (System.Data.DataRow row1 in dd.Rows )
            //    {
            //        if (row1["FieldName"].ToString() == FieldInfo[i].FieldName )  
            //        {
            //            switch (row1["Expression"].ToString().Trim())  //一个大于且最接近的值产生工作流程
            //            { 
            //                case ">=":
            //                    if (double.Parse(row1["ExpValue"].ToString()) >= FieldInfo[i].FieldValue) 
            //                    {

            //                        InsertLine(row1, EntityId);
            //                        j++;
            //                        Expression = ">=";
            //                        break;
            //                    }
            //                    break;
            //                case ">":
            //                    if (double.Parse(row1["ExpValue"].ToString()) > FieldInfo[i].FieldValue) //一个大于且最接近的值产生工作流程
            //                    {
            //                        InsertLine(row1, EntityId);
            //                        j++;
            //                        Expression = ">";
            //                        break;
            //                    }
            //                    break;
            //                 case "<=":
            //                    if (double.Parse(row1["ExpValue"].ToString()) <= FieldInfo[i].FieldValue) //一个大于且最接近的值产生工作流程
            //                    {

            //                        InsertLine(row1, EntityId);
            //                        j++;
            //                        Expression = "<=";
            //                        break;
            //                    }
            //                    break;
            //                case "<":
            //                    if (double.Parse(row1["ExpValue"].ToString()) < FieldInfo[i].FieldValue) //一个大于且最接近的值产生工作流程
            //                    {

            //                        InsertLine(row1, EntityId);
            //                        j++;
            //                        Expression = "<";
            //                        break;
            //                    }
            //                    break;
            //                case "=":
            //                    if (double.Parse(row1["ExpValue"].ToString()) == FieldInfo[i].FieldValue) //一个大于且最接近的值产生工作流程
            //                    {

            //                        InsertLine(row1, EntityId);
            //                        j++;
            //                        Expression = "=";
            //                        break;
            //                    }
            //                    break;
            //            }
                        
                     
            //        }
            //    }
            //    if (j == 0)
            //    {
            //        throw new Exception("对于节点" + FieldInfo[i].FieldName + Expression + FieldInfo[i].FieldValue.ToString() + "没有符合条件的审批");
            //    }
            //}
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="BillId"></param>
        /// <param name="AuditNum"> 审核次数</param>
        private void InsertLine(System.Data.DataRow row1,string BillId,int AuditNum)
        {

            Bao.DataAccess.DataAcc.ExecuteNotQuery("insert into BaoSystem..AuditFlowLine(AutoFlowId,BillId,AuditNum) values ('"
                            + row1["AutoFlowId"].ToString() + "','" + BillId + "'," + AuditNum + ")");

        }
        
       
    }
    public class AuditExec
    {

        public List<string> NodeList=new List<string >();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoginUserId">登陆用户</param>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillId">单号</param>
        /// <returns> true ：要审核，0：不要审核</returns>
        public Boolean  Check(string LoginUserId, string FunctionId,  string BillId)
        {
            string sql = "select b.*,a.AuditFlag,c.FunctionId,c.AuditNode,c.ParentNode " +
                "from BaoSystem..AuditFlowLine a inner join BaoSystem..AuditFlowExpression b " +
                " on a.AutoFlowId=b.AutoFlowId " +
                " inner join  BaoSystem..AuditFlowDefin c on b.AutoFlowId=c.AutoFlowId " + 
                "where  c.FunctionId='" + FunctionId + "' and a.BillId='" + BillId +
                "'  order by ParentNode ";
            System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (table1.Rows.Count == 0)
                throw new Exception("没有审核权限");
            DG(LoginUserId, "0", table1);
            if (NodeList.Count > 0)
                return true ;
            else
                return false;
            

        }
        public System.Int16 UnAudit(string LoginUserId, string FunctionId, string BillId)
        {
            return 0;
        }
        /// <summary>
        /// 执行审批
        /// </summary>
        /// <param name="LoginUserId">审批人</param>
        /// <param name="FunctionId">功能</param>
        /// <param name="BillId">单据编号</param>
        /// <returns>0:审批流没有全部完成,1：审批流完成</returns>
        public System.Int16 Audit(string LoginUserId, string FunctionId, string BillId, string Memo, double Score)
        {
            
            string sql = "select b.*,a.AuditFlag,c.FunctionId,c.AuditNode,c.ParentNode "+
                "from BaoSystem..AuditFlowLine a inner join BaoSystem..AuditFlowExpression b "+
                " on a.AutoFlowId=b.AutoFlowId " +
                " inner join  BaoSystem..AuditFlowDefin c on b.AutoFlowId=c.AutoFlowId "+
                "where  c.FunctionId='" + FunctionId + "' and a.BillId='" + BillId +
                "'  ";

            System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            #region  
            //if (table1.Rows.Count == 0)
            //{
            //    sql = "select b.*,a.AuditFlag,c.FunctionId,c.AuditNode,c.ParentNode " +
            //    "from BaoSystem..AuditFlowLine a inner join BaoSystem..AuditFlowExpression b " +
            //    " on a.AutoFlowId=b.AutoFlowId " +
            //    " inner join  BaoSystem..AuditFlowDefin c on b.AutoFlowId=c.AutoFlowId " +
            //    "where  c.FunctionId='" + FunctionId + "' and a.BillId='" + BillId +
            //    "' and userId='" + UserId + "' ";
            //    BillId = "";
            //     table1 = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            //}
            #endregion

            DG(LoginUserId, "0", table1);
            for (int i = 0; i < NodeList.Count; i++)
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery("update BaoSystem..AuditFlowLine "+
                    " set auditFlag='1',AuditUserId='" + LoginUserId + "',Memo='" + Memo + "',Score=" + Score +
                    " from BaoSystem..AuditFlowDefin ,BaoSystem..AuditFlowLine " +
                    " where BaoSystem..AuditFlowDefin.AutoFlowId=BaoSystem..AuditFlowLine.AutoFlowId and BaoSystem..AuditFlowDefin.AuditNode='" + NodeList[i].ToString() +
                    "' and BaoSystem..AuditFlowLine.billId='" + BillId + 
                    "' and BaoSystem..AuditFlowDefin.FunctionId='" + FunctionId + "' ");
                //System.Diagnostics.Debug.WriteLine(this.NodeList[i].ToString());
            }
            sql = "select count(*) " +
                "from BaoSystem..AuditFlowLine a inner join BaoSystem..AuditFlowExpression b " +
                " on a.AutoFlowId=b.AutoFlowId " +
                " inner join  BaoSystem..AuditFlowDefin c on b.AutoFlowId=c.AutoFlowId " +
                "where  c.FunctionId='" + FunctionId + "' and a.BillId='" + BillId +
                "' and a.AuditFlag='0' ";
            table1= Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (table1.Rows[0][0].ToString() == "0")
                return 1;
            else
                return 0;
                

        }
        private void DG(string UserId, string NodeId, System.Data.DataTable table1)
        {
            foreach (System.Data.DataRow row1 in table1.Rows)
            {
                if (row1["ParentNode"].ToString() == NodeId)
                {
                    if (row1["AuditUserId"].ToString() == UserId)
                    {
                        if (row1["AuditFlag"].ToString() == "0")
                        {
                            NodeList.Add(row1["AuditNode"].ToString().Trim());
                            break;
                        }
                        else
                        {
                            DG(UserId, row1["AuditNode"].ToString(), table1);
                        }
                    }
                    else
                    {
                        if (row1["AuditFlag"].ToString() == "0")
                        {
                            throw new Exception("节点'" + row1["AuditNode"].ToString()+"'还没被 '" + row1["AuditUserId"].ToString() + "'审核。");
                        }
                        else
                        {
                            DG(UserId, row1["AuditNode"].ToString(), table1);
                           
                        }
                        break;
                    }
                }
            }

        }
     
    }
    /// <summary>
    /// 字段名和字段的值
    /// </summary>
   public  class AuditField
    {
        private string _FieldName;

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        private double _FieldValue;

        public double FieldValue
        {
            get { return _FieldValue; }
            set { _FieldValue = value; }
        }
    }
}
