using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bao.BillBase;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：实现检索审批流程的管理（添加、删除、更新、查询）2-26
    /// </summary>
    public  class AuditFlowSearchManager
    {
        /// <summary>
        /// 查询所有的审批流程
        /// </summary>
        /// <returns>所有的流程</returns>
        public static DataTable GetAllSearchFlow()
        {
            string sql = "select s.*,n.*,u.*,AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end,"
                        +"FlowFlagText=case FlowFlag when   '0' then '提交' when '1' then '检索' end "
                        +" from SearchFlow s join AuditNode n on n.AuditNodeId=s.AuditNodeId "
                        + " left outer join  Users u on s.ManagerUserId=u.UserId order by FlowFlag asc, FlowId asc,OrderId asc";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 查询所有检索流程中的流程ID和名称
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetAllSearchFlowList(string flowFlag)
        {
            string sql = "select distinct FlowId,FlowName  from SearchFlow where FlowFlag='"+flowFlag+"'";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 根据FlowName查询检索流程
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <returns>一行数数据</returns>
        public static DataTable GetSearchFlow(string flowId, string flowName)
        {
            string sql = "select distinct FlowId,FlowName  from SearchFlow where FlowId='"+flowId+"' and FlowName='"+flowName+"'";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 根据FlowName与别的流程ID，查询检索流程
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <returns>一行数数据</returns>
        public static DataTable GetSearchFlowIsNetFlowName(string notFlowId, string flowName)
        {
            string sql = "select distinct FlowId,FlowName  from SearchFlow where FlowId<>'" + notFlowId + "' and FlowName='" + flowName + "'";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 是否已存在流程名称
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public static bool IsExistsFlowName(string flowName)
        {
            string sql = "select count(*)  from SearchFlow where FlowName='" + flowName + "'";
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            if (count > 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 将自定的流程添加到流程定义中
        /// </summary>
        /// <param name="flowId">流程号</param>
        /// <param name="functionId">功能编号</param>
        /// /// <param name="flowFlag">流程标志</param>
        /// <returns>是否成功添加</returns>
        public static bool SearchFlowSet(string flowId,string functionId,string flowFlag, out string msg)
        {
            DataTable dt = AuditBillFlowManager.GetuditFlowByFunctionId(functionId,flowFlag);
            if (dt.Rows.Count > 0)
            {
                msg = "流程添已经添加！";
                return false;
            }
            msg = "";
            string sql = "insert into AuditFlowDefin( FunctionId, AuditNode,AuditType, FixedFlow, SortId,AuditCycle,ManagerUserId,FlowFlag)"
                        + " select '" + functionId + "', AuditNodeId,AuditType,'0', OrderId,AuditCycle,ManagerUserId,FlowFlag from SearchFlow s"
                        +" where s.FlowId='"+flowId+"'";
            try
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                msg = "添加流程成功！";
                return true;
            }
            catch (Exception)
            {
                msg = "数据库访问不成功！";
                return false;
            }
        }

        /// <summary>
        ///根据审批流程ID， 获得最大顺序
        /// </summary>
        /// <param name="autoFlowId">审批流程ID</param>
        /// <returns>获得最大顺序值</returns>
        public static int GetMaxOrderId(string flowId)
        {
            string sql = "select OrderId from SearchFlow where FlowId='"+flowId+"' order by OrderId desc";
            int maxOrderId = 0;
            string strMaxOrderId = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if (strMaxOrderId != "")
            {
                maxOrderId = Convert.ToInt32(strMaxOrderId);
            }
            return maxOrderId;
        }


        /// <summary>
        /// 获得最大的的FlowId
        /// </summary>
        /// <returns></returns>
        public static int GetMaxFlowId()
        {
            string sql = "select  FlowId from SearchFlow order by  autoId desc";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            List<Int32> list = new List<Int32>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(Convert.ToInt32(dr["FlowId"]));
            }
            return 0;
        }

        /// <summary>
        /// 生成流程ID
        /// </summary>
        /// <returns></returns>
        public static string GenerateFlowId()
        {
            Int32 maxFlowId = GetMaxFlowId();
            if(maxFlowId == 0)
            {
               return "000001";
            }
            return CommonMethod.GenerateNo(maxFlowId, 6);
        }

        /// <summary>
        /// 添加检索审批流程
        /// </summary>
        /// <param name="autoId">自动编号</param>
        /// <param name="flowId">流程编号</param>
        /// <param name="auditNodeId">审批节点</param>
        /// <param name="auditType">审批类型</param>
        ///  <param name="auditCycle">周期</param>
        ///   <param name="managerUserId">管理员编号</param>
        /// <param name="orderId">审批顺序号</param>
        public static void InsertSearchFlow(string flowId, string flowName, string auditNodeId,string auditType,int orderId,int auditCycle,string managerUserId, string flowFlag)
        {
            string sql = "insert into SearchFlow(FlowId,FlowName,AuditNodeId,AuditType,OrderId,FlowFlag,AuditCycle,ManagerUserId) "
                         + "values('"+flowId+"','"+ flowName +"','"+auditNodeId+"','"+auditType+"',"+orderId+",'"+flowFlag+"',"+auditCycle+",'"+managerUserId+"')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 删除检索审批流程
        /// </summary>
        /// <param name="autoId">自动编号</param>
        public static void DeleteSearchFlow(int autoId)
        {
            string sql = "delete from SearchFlow where autoId=" + autoId;
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 更新检索审批流程
        /// </summary>
        /// <param name="autoId">自动编号</param>
        /// <param name="flowId">流程编号</param>
        /// <param name="auditNodeId">审批节点</param>
        /// <param name="auditType">审批类型</param>
        /// <param name="auditCycle">周期</param>
        /// <param name="managerUserId">管理员编号</param>
        /// <param name="orderId">审批顺序号</param>
        public static void UpdateSearchFlow(int autoId,string flowId,string auditNodeId,string auditType,int orderId,int auditCycle,string managerUserId)
        {
            string sql = "update SearchFlow set FlowId='" + flowId + "', AuditNodeId='" + auditNodeId + "', AuditType='" + auditType + "', OrderId=" + orderId + ",AuditCycle=" + auditCycle + ",ManagerUserId='"+managerUserId+"'  where autoId=" + autoId;
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 更新检索审批的菜单
        /// </summary>
        /// <param name="oldFlowName">原来的流程名称</param>
        /// <param name="newFlowName">新的流程名称</param>
        public static void UpdateSearchFlow(string flowId, string oldFlowName,string newFlowName)
        {
            string sql = "update SearchFlow set FlowName='"+newFlowName+"' where FlowId='"+flowId+"' and FlowName='"+oldFlowName+"'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        
    }
}
