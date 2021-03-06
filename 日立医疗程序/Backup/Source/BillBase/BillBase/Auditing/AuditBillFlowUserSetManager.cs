using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bao.BillBase.Audit
{
    /// <summary>
    ///功能描述： 单据审批流程人员管理（添加，删除，更新，查询）
    /// </summary>
    public class AuditBillFlowUserSetManager
    {
        private static string tableName = "AuditFlowExpression";
        /// <summary>
        /// 添加单据审批流程人员
        /// </summary>
        /// <param name="autoFlowId">单据审批流程ID</param>
        /// <param name="auditUserId">审批人员</param>
        public static void Insert(int autoFlowId, string auditUserId)
        {

            int orderId = GetMaxOrderIdByautoFlowId(autoFlowId);
            orderId = orderId + 1;
            string sql = "insert into " + tableName + "(AutoFlowId, AuditUserId, OrderId)"
                        + " values(" + autoFlowId + ",'" + auditUserId + "'," + orderId + ")";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        
        /// <summary>
        ///  更新单据审批流程人员
        /// </summary>
        /// <param name="autoFlowId">原单据审批流程ID</param>
        /// <param name="auditUserId">原审批人员</param>
        /// <param name="orderId">原顺序</param>
        /// <param name="newAuditUserId">更新的单据审批流程ID</param>
        /// <param name="newAuditUserId">更新的原审批人员</param>
        /// <param name="newOrderId">更新的顺序</param>
        public static void Update(int autoFlowId, string auditUserId, int orderId,
                        int newAutoFlowId, string newAuditUserId, int newOrderId)
        {
            try
            {
                string sql = "update  " + tableName
                 + " set AutoFlowId=" + newAutoFlowId + ",AuditUserId='" + newAuditUserId + "', OrderId=" + newOrderId + " "
                 + " where AutoFlowId=" + autoFlowId + " and AuditUserId='" + auditUserId + "' and OrderId=" + orderId;
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            }
            catch (Exception)
            {
                new Exception("要更新的数据已在表中，请重新修改！");
            }
        }

        

        /// <summary>
        /// 删除单据审批流程人员
        /// </summary>
        /// <param name="autoFlowId">流程编号</param>
        /// <param name="auditUserId">审批人员</param>
        /// <param name="orderId">人员审批顺序</param>
        public static void Delete(int autoFlowId, string auditUserId, int orderId)
        {
            string sql = "delete from " + tableName
                        + " where AutoFlowId=" + autoFlowId
                        + " and auditUserId='" + auditUserId + "' and orderId=" + orderId;
            Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }

       

        /// <summary>
        /// 查询是否存在记录数
        /// </summary>
        /// <param name="autoFlowId">流程编号</param>
        /// <param name="auditUserId">审批人员</param>
        /// <param name="orderId">人员审批顺序</param>
        /// <returns></returns>
        public static bool IsExists(int autoFlowId, string auditUserId, int orderId)
        {
            string sql = "select AutoFlowId, AuditUserId, OrderId from " + tableName
                        + " where AutoFlowId=" + autoFlowId
                        + " and auditUserId='" + auditUserId + "' and orderId=" + orderId;
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        ///// <summary>
        ///// 查询所有单据审批流程人员信息
        ///// </summary>
        ///// <returns>单据审批流程人员信息</returns>
        //public static DataTable GetAllAuditUserSets()
        //{
        //    string sql = "select e.AutoFlowId,n.AuditNode, AuditUserId, OrderId,UserName,d.SortId,d.AuditType,"
        //                   + " AuditTypeText=case d.AuditType when '0' then '人员审核' when '1' then '角色审核' end ,d.FunctionId "
        //                   + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n,"
        //                   + " Users u"
        //                   + " where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and u.UserId=e.AuditUserId "
        //                   + " order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";
        //    DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        //    return dt;
        //}

        ///// <summary>
        ///// 查询所有单据审批流程人员信息 **
        ///// </summary>
        ///// <param name="funcId">功能编码</param>
        ///// <returns></returns>
        //public static DataTable GetAuditUserSets(string funcId)
        //{
        //    string sql = "select distinct e.AutoFlowId,n.AuditNode, AuditUserId, OrderId,UserName=case d.AuditType when '0' then UserName when '1' then RoleName end,d.SortId,d.AuditType,ru.AutoUserId,"
        //                +" AuditTypeText=case d.AuditType when '0' then '人员审核' when '1' then '角色审核' end ,d.FunctionId  "
        //                +" from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n, Users u "
        //               +" ,AuditRole_User ru"
        //               +" where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and u.UserId=e.AuditUserId and ru.AutoUserId=u.AutoUserId and FunctionId='"+funcId+"' "
        //               +" order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";
        //    DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        //    return dt;
        //}

        /// <summary>
        /// 查询所有单据审批流程人员信息
        /// </summary>
        /// <param name="funcId">功能编码</param>
        /// <param name="flowId">流程ID</param>
        /// <returns></returns>
        public static DataTable GetAuditUserSets(string funcId,int autoFlowId,string AuditType)
        {
            string sql = "";
            if (AuditType == "0")
            {
                 sql = "select distinct e.AutoFlowId,n.AuditNodeId,n.AuditNode, AuditUserId,"
                         + " OrderId, UserName,d.SortId,d.AuditType,"
                            + " AuditTypeText='人员审核',d.FunctionId  "
                            + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n, Users u "
                           + "  where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and u.AutoUserId=e.AuditUserId  and FunctionId='" + funcId + "' and e.AutoFlowId=" + autoFlowId
                           + " order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";
            }
            else
            {
                sql = "select distinct e.AutoFlowId,n.AuditNodeId,n.AuditNode, AuditUserId,"
                                       + " OrderId,RoleName UserName,d.SortId,d.AuditType,ru.RoleId AutoUserId,"
                                          + " AuditTypeText='角色审核' ,d.FunctionId  "
                                          + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n, "
                                         + " AuditRole_User ru"
                                         + "  where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and ru.RoleId=e.AuditUserId and FunctionId='" + funcId + "' and e.AutoFlowId=" + autoFlowId
                                         + " order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";
            }
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        ///根据单据审批流程ID， 获得人员最大顺序
        /// </summary>
        /// <param name="autoFlowId">单据审批流程ID</param>
        /// <returns>获得人员最大顺序值</returns>
        public static int GetMaxOrderIdByautoFlowId(int autoFlowId)
        {
            string sql = "select OrderId  from " + tableName
                        + "  where AutoFlowId=" + autoFlowId
                        + " order by OrderId desc";
            int maxOrderId = 0;
            string strMaxOrderId = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if (strMaxOrderId != "")
            {
                maxOrderId = Convert.ToInt32(strMaxOrderId);
            }
            return maxOrderId;
        }

        #region 鲍增加
        /// <summary>
        /// 添加单据审批流程人员
        /// </summary>
        /// <param name="autoFlowId">单据审批流程ID</param>
        /// <param name="auditUserId">审批人员</param>
        /// <param name="mBillId">具体交付物清单单号</param>
        public static string Insert(int autoFlowId, string auditUserId, string mBillId, string mJFWId)
        {

            int orderId = GetMaxOrderIdByautoFlowId(autoFlowId);
            orderId = orderId + 1;
            string sql = "insert into " + tableName + "(AutoFlowId, AuditUserId, OrderId,BillId,JFWId)"
                        + " values(" + autoFlowId + ",'" + auditUserId + "'," + orderId + ",'" + mBillId + "','" + mJFWId + "')";
            return sql;
        }
        /// <summary>
        /// 删除审批流人员信息
        /// </summary>
        /// <param name="BillId">具体交付物清单单号</param>
        /// <returns></returns>
        public static string Delete(string BillId)
        {
            return "delete " + tableName + " where BillId='" + BillId + "' ";
        }

        /// <summary>
        /// 查询具体交付物清单的审批人员列表
        /// </summary>
        /// <param name="BillId">交付物编码</param>
        /// <returns></returns>
        public static string GetAuditUserSets(string BillId)
        {
            //string sql = "select  e.AutoFlowId,e.JFWId,n.AuditNodeId,n.AuditNode, AuditUserId, OrderId,UserName=case d.AuditType when '0' then UserName when '1' then RoleName end,d.SortId,d.AuditType,ru.AutoUserId,"
            //            + " AuditTypeText=case d.AuditType when '0' then '人员审核' when '1' then '角色审核' end ,d.FunctionId  "
            //            + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n, Users u "
            //            + " ,AuditRole_User ru"
            //            + "  where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId "
            //            +"and u.UserId=e.AuditUserId and ru.AutoUserId=u.AutoUserId and e.BillId='" + BillId +"' "
            //            + " order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";

            string sql = "select e.AutoFlowId,e.JFWId,n.AuditNodeId,n.AuditNode, AuditUserId, OrderId,UserName,d.SortId,d.AuditType,"
                        + " AuditTypeText='人员审核' ,d.FunctionId  "
                        + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n, Users u "
                        + "  where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and d.auditType='0'  "
                        + "and u.AutoUserId=e.AuditUserId and e.BillId='" + BillId + "' "
                        +" union all "
                        +"select e.AutoFlowId,e.JFWId,n.AuditNodeId,n.AuditNode, RoleId, OrderId,RoleName,d.SortId,d.AuditType,"
                        + " AuditTypeText='角色审核' ,d.FunctionId  "
                        + " from AuditFlowExpression as e, AuditFlowDefin  as d  ,AuditNode n"
                        + " ,AuditRole_User ru"
                        + "  where e.AutoFlowId=d.AutoFlowId and d.AuditNode=n.AuditNodeId and e.AuditUserId=ru.RoleId  and d.auditType='1'"
                        + "  and e.BillId='" + BillId + "' "
                        + " order  by e.AutoFlowId asc,d.SortId asc,e.OrderId asc";


            return sql;
        }
        #endregion
    }
}
