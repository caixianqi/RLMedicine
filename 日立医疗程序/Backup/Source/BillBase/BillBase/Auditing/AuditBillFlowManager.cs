using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bao.BillBase.Audit
{
    /// <summary>
    ///功能描述： 此类实现单据审批流程管理（添加、删除、更新、查询）
    /// </summary>
    [Serializable]
    public class AuditBillFlowManager
    {
        /// <summary>
        /// 查询所有的审批结点
        /// </summary>
        /// <returns>所有的审批结点</returns>
        public static DataTable GetAllAuditNodes()
        {
            string sql = "select * from AuditNode";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        #region 单据审批流程
        /// <summary>
        /// 查询所有的单据审批流程
        /// </summary>
        /// <returns>所有的流程</returns>
        public static DataTable GetAllAuditFlowDefins()
        {
            string sql = "select a.*,b.*,"
                         +" AuditTypeText=case AuditType when  '0' then '人员审核' when '1' then '角色审核' end,SortId"
                         +" from AuditNode a,AuditFlowDefin b"
                         + " where a.auditNodeId=b.AuditNode order by FunctionId asc,SortId asc";
            
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;

        }

        /// <summary>
        ///根据流程编号， 查询有的单据审批流程
        /// </summary>
        /// <param name="autoFlowId">流程编号</param>
        /// <returns></returns>
        public static DataTable GetAuditFlowDefin(int autoFlowId)
        {
            string sql = "select a.*,b.*,"
                         + " AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end,SortId"
                         + " from AuditNode a,AuditFlowDefin b"
                         + " where a.auditNodeId=b.AuditNode and AutoFlowId="+autoFlowId+" order by FunctionId asc,SortId asc";

            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;

        }

        public static DataTable GetAuditFlwDefinesGroup(string functionId, string flowFlag)
        {
            string sql = "select DISTINCT b.AuditGroupId,B.AuditGroupName from AuditFlowDefin a,AuditGroup b " +
                  " where a.AuditGroupId=b.AuditGroupId and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag +
                   "' order by b.AuditGroupId ";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        #region 根据功能编号，功能类型查询流程信息

        /// <summary>
        /// 获得单据的审批流
        /// </summary>
        /// <param name="functionId"></param>
       
        /// <returns></returns>
        public static DataTable GetAuditFlwDefines(string functionId, string flowFlag,string AuditGroupId)
        {
            string sql = "";
            //if (funType == "0")
            {
                sql = "select a.*,b.*,u.*,"
                         + " AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end,SortId"
                         + " from AuditNode a right outer join AuditFlowDefin b on a.auditNodeId=b.AuditNode"+
                         " left outer join Users u on u.UserId=b.ManagerUserId "
                         + " where   FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and b.AuditGroupId='" + AuditGroupId + "'"
                         +" order by FunctionId asc,SortId asc";
            }
          

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        /// <summary>
        /// 获得交付物的审批流
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="flowFlag"></param>
        /// <returns></returns>
        public static DataTable GetAuditFlwDefines(string functionId, string flowFlag)
        {
            string sql = "";
            //if (funType == "0")
            {
                sql = "select a.*,b.*,u.*,"
                         + " AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end,SortId"
                         + " from AuditNode a right outer join AuditFlowDefin b on a.auditNodeId=b.AuditNode" +
                         " left outer join Users u on u.UserId=b.ManagerUserId "
                         + " where   FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "'"
                         + " order by FunctionId asc,SortId asc";
            }
           
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        #endregion

        /// <summary>
        /// 删除审批流程
        /// </summary>
        /// <param name="autoFlowId">审批流程编号</param>
        public static void DeleteAuditFlowDefinById(int autoFlowId)
        {
            string sql = "delete from AuditFlowDefin where AutoFlowId=" + autoFlowId;
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        
        /// <summary>
        /// 更新审批流程
        /// </summary>
        /// <param name="autoFlowId"></param>
        /// <param name="functionId"></param>
        /// <param name="auditNode"></param>
        /// <param name="parentNode"></param>
        /// <param name="AuditType"></param>
        public static void ModifyAuditFlowDefin(int autoFlowId ,string functionId,string auditNode,string AuditType,int sortId,int auditCycle,string managerUserId ,string flowFlag,string AuditGroupId)
        {
            string sql = "update AuditFlowDefin set FunctionId='"
                        + functionId + "', AuditNode='" + auditNode + "',AuditType='" + AuditType + "',SortId=" + sortId +
                        ",AuditCycle=" + auditCycle + ",ManagerUserId='" + managerUserId + "', FlowFlag='" + flowFlag + "',AuditGroupId='" + AuditGroupId + "'"
                        + " where AutoFlowId=" + autoFlowId;
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditNode">审批结点</param>
        /// <param name="AuditType"></param>
        public static void InsertAuditFlowDefin(string functionId, string auditNode, string AuditType, int SortId, int auditCycle, string managerUserId, string flowFlag, string AuditGroupId)
        {
            string sql = "insert into  AuditFlowDefin(FunctionId, AuditNode, AuditType, FixedFlow,SortId,AuditCycle,ManagerUserId,flowFlag,AuditGroupId)"
                        + " values('" + functionId.Trim() + "','" + auditNode.Trim() + "','" + AuditType.Trim() + "','0'," + SortId + "," + auditCycle + ",'" + managerUserId + "' ,'" + flowFlag + "','" + AuditGroupId + "')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 根据功能编号，查询最大的顺序号
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <returns>最大的顺序号</returns>
        public static int GetMaxSortId(string functionId,string GroupId)
        {
            string sql = "select SortId from AuditFlowDefin where FunctionId='" + functionId + "' and AuditGroupId='" + GroupId + "' order by SortId desc";
            Object objMaxSortId = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if (objMaxSortId == null || objMaxSortId.ToString().Trim() == "")
            {
                return 0;
            }
            return Convert.ToInt32(objMaxSortId);
        }

        /// <summary>
        /// 查询是否存在功能编号
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <returns>true为存在，false为不存在</returns>
        public static bool IsExistByFunctionId(string functionId)
        {
            string sql = "select count(*) from AuditFlowDefin where FunctionId='" + functionId + "'";
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据功能编号,上级审批结点，查询审批流程
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <param name="parentNode">审批结点</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAuditNodeByFunctionIdAndParentNode(string functionId, string parentNode)
        {
            string sql = "select a.*,b.*,"
                         + " AuditTypeText=case AuditType when '0' then '人员审核' when '1' then '角色审核' end"
                         + " from AuditNode a,AuditFlowDefin b"
                         + " where a.auditNodeId=b.AuditNode and FunctionId='" + functionId + " and ParentNode='"+parentNode+"'"
                         + "' order by AutoFlowId asc ";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 根据功能编号，查询此流程的尾记录
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <param name="parentNode">审批结点</param>
        /// <returns>DataRow</returns>
        public static DataRow GetThisAuditFlowEndRecordByFunctionId(string functionId)
        {
            string sql = "select a.*,b.*,"
                         + " AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end"
                         + " from AuditNode a,AuditFlowDefin b"
                         + " where a.auditNodeId=b.AuditNode and FunctionId='" + functionId
                         + "' order by AutoFlowId desc ";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt.Rows[0];
        }

        /// <summary>
        /// 根据功能编号，查询此流程的首记录
        /// </summary>
        /// <param name="functionId">功能编号</param>
        /// <param name="parentNode">审批结点</param>
        /// <returns>DataRow</returns>
        public static DataRow GetThisAuditFlowFirstRecordByFunctionId(string functionId)
        {
            string sql = "select a.*,b.*,"
                         + " AuditTypeText=case AuditType when   '0' then '人员审核' when '1' then '角色审核' end"
                         + " from AuditNode a,AuditFlowDefin b"
                         + " where a.auditNodeId=b.AuditNode and FunctionId='" + functionId
                         + "' order by AutoFlowId asc ";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt.Rows[0];
        }


        /// <summary>
        /// 根据功能编号，查询此审批流程 **
        /// </summary>
        /// <param name="functionId">功能编号</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        /// <returns>DataTable</returns>
        public static DataTable GetuditFlowByFunctionId(string functionId,string flowFlag)
        {
            string sql = "select d.*,AuditTypeText=case d.AuditType when   '0' then '人员审核' when '1' then '角色审核' end"
                   + " from AuditFlowDefin as d where FunctionId='"+functionId+"' and FlowFlag='"+flowFlag+"'"
                   + " order by SortId asc";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            return dt;
        }

        /// <summary>
        /// 根据功能编码，查询单据审批流程数量
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// /// <param name="flowFlag">流程标志</param>
        /// <returns>审批流程数量</returns>
        public static int GetFlowCountByFunctionId(string functionId,string flowFlag)
        {
            //string sql = "select count(*) from AuditFlowDefin where FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "'";
            string sql = "select count(*) from AuditFlowDefin "+
                " where FunctionId='" + functionId +
                "' and AuditGroupId in (select AuditGroupId from users where AutoUserId='" + UFBaseLib.BusLib.BaseInfo.UserId + "') or AuditGroupId =''";
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            return count;
        }

        #endregion

        /// <summary>
        /// 查询所有的单据审批流程人员设置
        /// </summary>
        /// <returns>所有审批人员</returns>
        public static DataTable GetAllAuditFlowExpressions()
        {
            string sql = "select * from  AuditFlowExpression";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获得最大的审批流程编号
        /// </summary>
        /// <returns>最大的流程编号</returns>
        public static int GetMaxAutoFlowId()
        {
            string sql = "select AutoFlowId from AuditFlowDefin order by AutoFlowId desc";
            Object objId = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if(objId == null ||  objId.ToString().Trim() == "")
            {
                return 0;
            }
            return Convert.ToInt32(objId);
        }
        
    }
}
