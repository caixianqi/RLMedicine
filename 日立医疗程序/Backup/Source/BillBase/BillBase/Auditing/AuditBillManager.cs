using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bao.BillBase;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：此业务逻辑类，实现添加流程记录到审批记录表中，
    /// 并根据单据编号，功能编号，审批人员判断进入单据审批， 更新审批信息 
    /// </summary>
    public class AuditBillManager
    {
        #region 验证是否可以进入单据审核
        /// <summary>
        ///  审核单据
        /// </summary>
        /// <param name="billId">单据</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditUserId">审批人员ID</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        /// <param name="message">返回的提示信息</param>
        /// <returns>bool为true可进入审批</returns>
        public static bool AuditBill(string billId, string functionId, string auditUserId,string flowFlag, out string message)
        {
            message = "";
            //if (IsExistUserInAuditNode_User(auditUserId.Trim()))                      //1、判断用户是否有审批权限
            {
                //获得此最大的审批次数
                int auditNum = GetMaxAuditNumByFunctionId(billId, functionId,flowFlag);

                if (auditNum < 1)
                {
                    message = "该单据审批流程没有生成审批记录！";
                    return false;
                }
                //2、判断用户是否能在此单据流程中审批单据
                if (IsExistAuditFlowByFunctionIdAndAuditUserName(billId,functionId,auditUserId,flowFlag,auditNum))
                {
                    
                    //获得此流程在审批记录中的数据
                    DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(billId, functionId, auditNum,flowFlag);

                    //获得审批流程数
                    int flowCount = AuditBillManager.GetFlowCountByFunctionId(billId, functionId,flowFlag,auditNum);

                    //根据单据编号，功能编号，审核标记, 查询审批记录数
                    int lineCount = GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(billId, functionId, "2", auditNum,flowFlag);
                    if (lineCount == flowCount)
                    {
                        message = "单据失效，因整个流程审核不通过！";
                        return false;
                    }
                    lineCount = GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(billId, functionId, "1", auditNum,flowFlag);
                    if (lineCount == flowCount)
                    {
                        message = "已审核！";
                        return false;
                    }


                    //要审批的一单据
                    DataTable auditLineTable = GetAuditFlowLineByBillIdAndFunctionIdAndAuditUserName(billId, functionId, auditUserId, auditNum,flowFlag);
                    int aFlowId = Convert.ToInt32(auditLineTable.Rows[0]["AutoFlowId"]);
                    int orderId = Convert.ToInt32(auditLineTable.Rows[0]["OrderId"]);

                    //获得此单据记录审批流程同一审批结点的审批记录
                    DataTable auditLineDt = GetAuditFlowLineByBillIdAndFunctionIdAndAuditFlowId(billId, functionId, aFlowId, auditNum, flowFlag, UFBaseLib.BusLib.BaseInfo.UserId);
                    
                    int j = 0; 

                    foreach (DataRow row in auditLineDt.Rows)
                    {
                        if (row["OrderId"].Equals(auditLineTable.Rows[0]["OrderId"]))
                        {
                            break;
                        }
                        j++;
                    }

                    //获得审批的记录
                   // DataTable maxOrderOfFlowExpression = GetAuditCycle(billId, functionId, aFlowId, auditNum,flowFlag);
                    if(auditLineDt.Rows.Count > 0) 
                    {
                        //if (j > 0)  //如果当前的用户不为第一个人
                        {
                            System.DateTime PreNodeAuditDate;
                            int auditCycle = Convert.ToInt32(auditLineDt.Rows[0]["AuditCycle"]);
                            if (int.Parse(auditLineDt.Rows[0]["SortId"].ToString()) > 1)  //不是第一个审批节点
                            {
                                System.Data.DataRow PreAuditLine = AuditNodeLineRecord(functionId, billId, int.Parse(auditLineDt.Rows[0]["SortId"].ToString()) - 1, "0");
                                if (PreAuditLine["AuditDate"].ToString() == "")
                                {
                                    message = "单据没有流转到！";
                                    return false;
                                }
                                PreNodeAuditDate = DateTime.Parse(PreAuditLine["AuditDate"].ToString());
                            }
                            else
                            {
                                PreNodeAuditDate = System.DateTime.Parse(auditLineDt.Rows[0]["CreateDate"].ToString());
                            }
                            
                            int Days =(RiLiGlobal.RiLiDataAcc.GetNow()).Subtract(PreNodeAuditDate).Days ;
                            double DD = Days / auditCycle;
                            Days=(int)Math.Ceiling(DD);

                            if (Days < auditLineDt.Rows.Count)
                            {
                                
                                if (auditLineDt.Rows[Days]["PlanAuditUserId"].ToString() != UFBaseLib.BusLib.BaseInfo.UserId)
                                {
                                    message = "该人员不能审批！";
                                    return false;
                                }
                            }
                            //DateTime userUpdateDate = Convert.ToDateTime(auditLineDt.Rows[0]["UserUpdateDate"]);
                            
                            //userUpdateDate = userUpdateDate.AddDays(auditCycle);
                            //int diffDate =  RiLiGlobal.RiLiDataAcc.GetNow().CompareTo(userUpdateDate);
                            //if (diffDate < 0)
                            //{
                            //    message = "单据没有流转到！";
                            //    return false;
                            //}
                        }
                    }
                    

                    //获得此流程在审批流程中的数据
                    DataTable auditFlowTable = flowOfFlowLineTable;

                    if (auditLineTable.Rows.Count == 0)
                    {
                        message = "此审批流程没有添加到审批记录中！";
                        return false;
                    }
                    int i = 0;
                    foreach (DataRow row in auditFlowTable.Rows)
                    {

                        if (row["FunctionId"].Equals(auditLineTable.Rows[0]["FunctionId"]) &&
                            row["AutoFlowId"].Equals(auditLineTable.Rows[0]["AutoFlowId"])
                            )
                        {
                            break;
                        }
                        i++;
                    }
                    if (i == 0)  //为流程首记录
                    {
                        lineCount = GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(billId, functionId, "0", auditNum,flowFlag);
                        if (lineCount == flowCount)
                        {
                            message = "现在进行审核！";
                            return true;
                        }
                        if (auditLineTable.Rows[0]["AuditFlag"].ToString().Trim() == "0")
                        {
                            message = "现在进行审核！";
                            return true;
                        }
                        else
                        {
                            if (auditFlowTable.Rows.Count > i)
                            {
                                //下一审批结点记录
                                DataRow nextRow = auditFlowTable.Rows[i + 1];
                                int flowId = Convert.ToInt32(nextRow["AutoFlowId"]);
                                //根据单据审批流程编号、单据编号、审核次数，查询到一条审批记录
                                DataTable nextTable = GetAuditFlowLine(flowId,functionId, billId, auditNum,flowFlag);
                                if (nextTable.Rows[0]["AuditFlag"].ToString().Trim() == "0")
                                {
                                    //下节点未审核
                                    return true;
                                }
                                else
                                {
                                    //下节点已审核
                                    message = "您不能审核，因下节点已审核";
                                    return false;
                                }
                            }
                            else
                            {
                                //没有下节点
                                return true;
                            }
                        }
                    }
                    else
                    {
                        //前一审批结点记录
                        DataRow preRow = auditFlowTable.Rows[i - 1];
                        int auditFlowId = Convert.ToInt32(preRow["AutoFlowId"]);
                        //根据单据审批流程编号、单据编号、审核次数，查询到一条审批记录
                        DataTable preTable = GetAuditFlowLine(auditFlowId,functionId, billId, auditNum,flowFlag);

                        //如果审批标记为"0"，则为未审批，如果为"1",则为已审批
                        if (preTable.Rows[0]["AuditFlag"].ToString().Trim() == "0")
                        {
                            message = "单据没有流转到！";
                            return false;
                        }
                        else
                        {
                            if (auditLineTable.Rows[0]["AuditFlag"].ToString().Trim() == "0")
                            {
                                message = "现在进行审核！";
                                return true;
                            }
                            else if (auditLineTable.Rows[0]["AuditFlag"].ToString().Trim() == "1")
                            {
                                if (auditFlowTable.Rows.Count > i)
                                {
                                    //下一审批结点记录
                                    DataRow nextRow = auditFlowTable.Rows[i + 1];
                                    int flowId = Convert.ToInt32(nextRow["AutoFlowId"]);
                                    //根据单据审批流程编号、单据编号、审核次数，查询到一条审批记录
                                    DataTable nextTable = GetAuditFlowLine(flowId,functionId, billId, auditNum,flowFlag);
                                    if (nextTable.Rows[0]["AuditFlag"].ToString().Trim() == "0")
                                    {
                                        //下节点未审核
                                        return true;
                                    }
                                    else
                                    {
                                        //下节点已审核
                                        return false;
                                    }
                                }
                                else
                                {
                                    //没有下节点
                                    return true;
                                }
                            }
                            else
                            {
                                message = "该审核不通过";
                                return false;
                            }
                        }

                        
                    }
                }
                else
                {
                    message = "您不能在此单据流程中审核单据！";
                    return false;
                }
            }
            //else
            //{
            //    message = "您没有权审核！";
            //    return false;
            //}
          
        }

        #endregion
        public static void DeleFlowLine(string billId, string functionId, string flowFlag, int auditNum)
        {
            string sql = "delete AuditFlowLine where BillId='" + billId + "' and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum='" + auditNum + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }
        public static void  DeleFlowLineUser(string billId, string functionId, string flowFlag, int auditNum)
        {
            string sql = "delete AuditFlowLineUser where BillId='" + billId + "' and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum='" + auditNum + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }
        public static void DeleFlowLineUser(string billId,string JFWId, string functionId, string flowFlag, int auditNum)
        {
            string sql = "delete AuditFlowLineUser where BillId='" + billId + " and JFWId='" + JFWId + "' and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum='" + auditNum + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }
       
        #region  添加单据流程至审批记录中
        public static string AddFlowDefineToFlowLineSQL(string billId, string functionId, string flowFlag)
        {
            //获得此最大的审批次数
            int auditNum = GetMaxAuditNumByFunctionId(billId, functionId, flowFlag); //审批次数加一

            //获得流程数
            int flowCount = AuditBillFlowManager.GetFlowCountByFunctionId(functionId, flowFlag);
            if (flowCount == 0)
            {
                throw new Exception("该员工所对应的审核组没有审批流程设置！");
            }
            
            //根据单据编号，功能编号，审核标记, 查询审批记录数
            int lineCount = GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(billId, functionId, "0", auditNum, flowFlag);
            if (lineCount > 0)
            {
                throw new Exception("该单据未审核完！");
            }
            lineCount = GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(billId, functionId, "1", auditNum, flowFlag);
            if (lineCount == flowCount)
            {
                throw new Exception("该单据已审核！");
                
            }
            auditNum++;
            
            //审批流程数据添加至审批记录中
            string sql = "insert into AuditFlowLine(AutoFlowId, FunctionId, AuditNodeId, FlowFlag, SortId,"
                           + " AuditCycle,AuditType,AuditUserId,BillId,Memo,Score,AuditNum,ScoreLevel)"
                           + " select AutoFlowId, FunctionId, AuditNode, FlowFlag, SortId, AuditCycle,AuditType, '','" 
                           + billId.Trim() + "','',0,'" + auditNum + "',''"
                           + " from AuditFlowDefin"
                           + " where FunctionId='" + functionId + "' and FlowFlag='" + flowFlag
						   + "' and (AuditGroupId in (select AuditGroupId from users where AutoUserId='" + UFBaseLib.BusLib.BaseInfo.UserId + "') or AuditGroupId ='')";
            return sql;
        }
        /// <summary>
        ///  添加单据流程至审批记录中
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="flowFlag">流程标志</param>
        public static void AddFlowDefineToFlowLine(string billId, string functionId,string flowFlag)
        {
            string sql = AddFlowDefineToFlowLineSQL(billId,functionId,flowFlag);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            
           
        }

        #endregion

        #region 添加审批人员设置模板到实际的审批记录对应的人员表中
        /// <summary>
        /// 添加审批人员设置模板到实际的审批记录对应的人员表中
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编号</param>
        /// <param name="flowFlag">0：提交流程，1：检索流程</param>
        /// <returns></returns>
        public static void AddInfoToFlowLineUser(string billId,string functionId,string flowFlag)
        {
            //获得此最大的审批次数
            int auditNum = GetMaxAuditNumByFunctionId(billId, functionId, flowFlag); //审批次数

            string sql = "insert into AuditFlowLineUser(AutoFlowId,BillId,AuditUserId,OrderId,FunctionId, FlowFlag, AuditNum)"
                       +" select e.AutoFlowId,'"+billId+"',e.AuditUserId, e.OrderId,FunctionId, FlowFlag," + auditNum
                       +" from AuditFlowExpression e"
                       +" inner join AuditFlowDefin d on d.AutoFlowId=e.AutoFlowId"
                       + " where FunctionId='" + functionId + "' and FlowFlag='" + flowFlag
                       + "' and (e.JFWId='XXXXXXX') and (AuditGroupId in (select AuditGroupId from users where AutoUserId='"+UFBaseLib.BusLib.BaseInfo.UserId.Trim()+"') or AuditGroupId ='') ";
            try
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            }
            catch (Exception ee)
            {
                throw new Exception (ee.Message);
            }
        }

        public static void AddInfoToFlowLineUser(string billId,string jFWId, string functionId, string flowFlag)
        {
            //获得此最大的审批次数
            int auditNum = GetMaxAuditNumByFunctionId(jFWId, functionId, flowFlag); //审批次数
            //auditNum++;
            string sql = "insert into AuditFlowLineUser(AutoFlowId,BillId,AuditUserId,OrderId,FunctionId, FlowFlag, AuditNum)"
                       + " select e.AutoFlowId,'" + jFWId + "',e.AuditUserId, e.OrderId,FunctionId, FlowFlag," + auditNum
                       + " from AuditFlowExpression e"
                       + " inner join AuditFlowDefin d on d.AutoFlowId=e.AutoFlowId"
                       + " where FunctionId='" + functionId + "' and FlowFlag='" + flowFlag
                       + "' and (e.JFWId='" + jFWId + "') and (e.BillId='" + billId + "')";
            try
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

		/// <summary>
		/// 添加智力成果审批流程
		/// </summary>
		/// <param name="billId"></param>
		/// <param name="jFWId"></param>
		/// <param name="functionId"></param>
		/// <param name="flowFlag"></param>
		/// <param name="cgId"></param>
		public static void AddInfoToFlowLineUser(string billId, string jFWId, string functionId, string flowFlag,string cgId) {
			//获得此最大的审批次数
			int auditNum = GetMaxAuditNumByFunctionId(cgId, functionId, flowFlag); //审批次数
			//auditNum++;
			string sql = "insert into AuditFlowLineUser(AutoFlowId,BillId,AuditUserId,OrderId,FunctionId, FlowFlag, AuditNum)"
					   + " select e.AutoFlowId,'" + cgId + "',e.AuditUserId, e.OrderId,FunctionId, FlowFlag," + auditNum
					   + " from AuditFlowExpression e"
					   + " inner join AuditFlowDefin d on d.AutoFlowId=e.AutoFlowId"
					   + " where FunctionId='" + functionId + "' and FlowFlag='" + flowFlag
					   + "' and (e.JFWId='" + jFWId + "') and (e.BillId='" + billId + "')";
			try {
				Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
			} catch (Exception ee) {
				throw new Exception(ee.Message);
			}
		}
        #endregion

        #region 获得某审批流程的审批次数

        /// 根据审批流程功能编码，查询此单据审批的次数
        /// </summary>
        /// <param name="billId">单据编码</param>
        /// <param name="functionId">功能编码</param>
        /// <returns>审批的次数</returns>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        public static int GetMaxAuditNumByFunctionId(string billId, string functionId,string flowFlag)
        {
            string sql = " select max(AuditNum) from AuditFlowLine l" + " where l.BillId='"
                        + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='"+flowFlag+"'";
            string strNum = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if (strNum == "")
            {
                return 0;
            }
            int count = Convert.ToInt32(strNum);
            return count;
        }

        #endregion

        #region 添加审批记录**
        /// <summary>
        /// 添加审批记录
        /// </summary>
        /// <param name="autoFlowId">流程编号</param>
        /// <param name="billId">单据编号</param>
        /// <param name="aditUserId">审批人员</param>
        /// <param name="auditFlag">审批标记</param>
        /// <param name="memo">备注</param>
        /// <param name="score">分数</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="scoreLevel">审批等级</param>
        /// <param name="flowFlag">流程标志</param>
        public static void InsertAuditFlowLine(int autoFlowId, string billId, string auditUserId,
            string auditFlag, string memo, int score, int auditNum, string scoreLevel,string functionId,int sortId, string flowFlag)
        {
            string sql = "insert into AuditFlowLine(AutoFlowId, BillId, AuditUserId, AuditFlag, Memo, Score, AuditNum, ScoreLevel,FlowFlag)"
                + " values(" + autoFlowId + ",'" + billId + "','" + auditUserId + "','" + auditFlag + "','" + memo + "'," + score + "," + auditNum + ",'" + scoreLevel + "','"+functionId+"',"+sortId+",'"+flowFlag+"')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        #endregion

        #region 更新审核的单据记录

        /// <summary>
        /// 更新单据审批单据
        /// </summary>
        /// <param name="autoId">记录编号</param>
        /// <param name="auditFlag">审批标记</param>
        /// <param name="scoreLevel">分数等级</param>
        /// <param name="score">分数</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="memo">备注</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        public static void UpdateAuditFlowLine(
            int autoId,string auditUserId, string auditFlag, string scoreLevel, int score, string memo,string flowFlag)
        {
            string sql = "update AuditFlowLine set UserUpdateDate='" +  RiLiGlobal.RiLiDataAcc.GetNow().ToString() + "', AuditDate='" +  RiLiGlobal.RiLiDataAcc.GetNow().ToString() + "', AuditUserId='" + auditUserId + "',AuditFlag='" + auditFlag + "', Memo='" + memo + "'," + "scoreLevel='" + scoreLevel + "',Score=" + score + " where AutoId=" + autoId + " and FlowFlag='" + flowFlag + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

        }
        #endregion

        #region 判断用户是否可审批
        /// <summary>
        /// 查询此用户是否能审批
        /// </summary>
        /// <returns>是否存在</returns>
        public static bool IsExistUserInAuditNode_User(string auditUserId)
        {
            string sql = "select count(*) from AuditNode_User where AutouserId='" + auditUserId.Trim() + "'";
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));

            sql = "select count(*) from Users u,AuditRole_User ru  where u.AutoUserId=ru.AutoUserId and u.userId='"+auditUserId.Trim()+"'";
            int row = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            if (count > 0 || row > 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 判断用户是否可以在此审批流程中审批

        /// <summary>
        /// 判断用户是否在此审批流程在审批
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditUserName">审批人员</param>
        /// <returns>是否存在记录</returns>
        public static bool IsExistAuditFlowByFunctionIdAndAuditUserName(string billId, string functionId, string auditUserId,string flowFlag,int auditNum)
        {
            //Bao.DataAccess.DataAcc.ExecuteQuery("");
            string sql = "select count(*) from AuditFlowLineUser a,AuditFlowLine b " +
                " where a.autoFlowId=b.autoFlowId and a.BillId=b.BillId and a.AuditNum=b.AuditNum and AuditType='0'" +
                " and a.BillId='" + billId + "' and a.FunctionId='" + functionId + "' and a.AuditUserId='" + auditUserId + 
                "' and a.FlowFlag='" + flowFlag + "' and a.AuditNum=" + auditNum;
            Object objCount = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
            if (objCount == null || objCount.ToString().Trim() == "0")
            {
                sql = "select count(*) from AuditFlowLineUser a,AuditFlowLine b ,AuditRole_User c " +
                " where a.autoFlowId=b.autoFlowId and a.BillId=b.BillId and a.AuditNum=b.AuditNum and a.AuditUserid= c.RoleId and AuditType='1'" +
                " and a.BillId='" + billId + "' and a.FunctionId='" + functionId + "' and c.AutoUserId='" + auditUserId +
                "' and a.FlowFlag='" + flowFlag + "' and a.AuditNum=" + auditNum; 

                objCount = Bao.DataAccess.DataAcc.ExecuteScalar(sql);
                if (objCount == null || objCount.ToString().Trim() == "")
                    return false;
            }
            int count = Convert.ToInt32(objCount);
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 查询此审批人员要审批的单据
        /// <summary>
        /// 根据此流程的单据编号、功能编码、审批人员，审批次数、 查询此审批人员要审批的一条单据
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditUserName">审批人员</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param>
        /// <returns>一条审批记录</returns>
        public static DataTable GetAuditFlowLineByBillIdAndFunctionIdAndAuditUserName(
            string billId, string functionId, string auditUserId, int auditNum,string flowFlag)
        {
            
            string sql = "select top 1 l.*,lu.*"
               + " from AuditFlowLine l,AuditFlowLineUser lu"
               + " where l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and AuditType='0' and l.AuditNum=" + auditNum + " and lu.AuditUserId='"
               + auditUserId + "' and l.FunctionId='" + functionId + "' and lu.BillId='" + billId + "' and l.BillId='" + billId + "' and l.FlowFlag='" + flowFlag + "' order by l.SortId asc";
            
            System.Data.DataTable dt= Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "select top 1 l.*,lu.*"
                + " from AuditFlowLine l,AuditFlowLineUser lu, AuditRole_User c"
                + " where  l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and AuditType='1' and lu.AuditUserid= c.RoleId and l.AuditNum=" + auditNum + " and c.AutoUserId='"
                + auditUserId + "' and l.FunctionId='" + functionId + "' and lu.BillId='" + billId 
                +"' and l.BillId='" + billId + "' and l.FlowFlag='" + flowFlag + "' order by l.SortId asc";
                 dt= Bao.DataAccess.DataAcc.ExecuteQuery(sql);
                 if (dt.Rows.Count == 0)
                    throw new Exception("该条件没有结果:"+sql );
            }
            return dt;
        }
        #endregion

        #region 查询此审批人员要审批的单据

        /// <summary>
        /// 查询此单据记录审批流程同一审批结点的审批记录
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditFlowId">审批流程编号</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        /// <returns>一条审批记录</returns>
        public static DataTable GetAuditFlowLineByBillIdAndFunctionIdAndAuditFlowId(
            string billId, string functionId, int auditFlowId, int auditNum,string flowFlag,string AuditUserId)
        {
            string sql = " select distinct l.*,lu.AuditUserId PlanAuditUserId,lu.OrderId"
                +" from AuditFlowLine l,AuditFlowLineUser lu"
                + " where  l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and AuditType='0' and  l.AuditNum=" + auditNum + " and l.AutoFlowId="
                + auditFlowId + " and l.FunctionId='" + functionId + "' and l.BillId='" + billId + "' and l.FlowFlag='" + flowFlag + "'"// "' and lu.AuditUserId='" + AuditUserId + "'"   //增加该注释，只要是该节点的用户就能审核，不分先后次序
                +" order by lu.OrderId asc";
            System.Data.DataTable dt= Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
            {
                sql = " select distinct l.*,c.AutoUserId PlanAuditUserId,lu.OrderId"
                + " from AuditFlowLine l,AuditFlowLineUser lu, AuditRole_User c"
                + " where  l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and AuditType='1' and lu.AuditUserid= c.RoleId  and  l.AuditNum=" + auditNum + " and l.AutoFlowId="
                + auditFlowId + " and l.FunctionId='" + functionId + "' and l.BillId='" + billId + "' and l.FlowFlag='" + flowFlag + "'"// "' and c.AutoUserId='" + AuditUserId + "'"    ////增加该注释，只要是该节点的用户就能审核，不分先后次序
                + " order by lu.OrderId asc";
                dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                    throw new Exception("该用户不能审核该单据");
            }
            return dt;
        }
        #endregion


        #region  根据条件查询，审批记录中的记录数
        /// <summary>
        /// 根据条件查询，审批记录中的记录数
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编号</param>
        /// <param name="auditFlag">审批标记</param>
        /// <param name="flowFlag">流程标志</param>
        /// <returns>记录数</returns>
        public static int GetFlowCountAtFlowLineByBillIdAndFunctiojnIdAndAuditFlag(string billId, string functionId, string auditFlag, int auditNum,string flowFlag)
        {
            string sql = "select count(*) from AuditFlowLine l"
                       + " where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditFlag='"+auditFlag+"' and l.AuditNum=" + auditNum;
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            return count;
        }
        #endregion


        #region 根据此的单据编号、功能编码、审批次数，查询单据记录中的流程数据

        /// <summary>
        /// 根据此的单据编号、功能编码、审批次数，查询单据记录中的流程数据
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        /// <returns>单据记录中的流程数据</returns>
        public static DataTable GetAuditFlowOfAuditFlowLine(string billId, string functionId, int auditNum,string flowFlag)
        {
            //string sql = "select l.*  from AuditFlowLine l "
            //            + " where  l.AutoFlowId in("
            //            + "        select distinct lu.AutoFlowId from AuditFlowLineUser lu where BillId='" + billId + "' and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum=" + auditNum
            //            + "    )"
            //            + " and l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditNum=" + auditNum+" order by SortId";

            string sql = "select l.*,b.AuditNode,c.userName  from AuditFlowLine l left outer join AuditNode b  on l.AuditNodeId= b.AuditNodeId  "
                       + "left outer join users c on l.AuditUserId=c.AutoUserId "+
                       " where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditNum=" + auditNum + "  and AuditFlag!=2 order by SortId";
            
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }

		/// <summary>
		/// 根据此的单据编号、功能编码、审批次数，查询单据记录中的流程数据
		/// </summary>
		/// <param name="billId">单据编号</param>
		/// <param name="functionId">功能编码</param>
		/// <param name="auditNum">审批次数</param>
		/// <param name="flowFlag">流程标志，0为提交，1为检索</param>
		/// <returns>单据记录中的流程数据</returns>
		public static DataTable GetAuditFlowOfAuditFlowLineAll(string billId, string functionId, int auditNum, string flowFlag) {
			string sql = "select l.*,b.AuditNode,c.userName  from AuditFlowLine l left outer join AuditNode b  on l.AuditNodeId= b.AuditNodeId  "
					   + "left outer join users c on l.AuditUserId=c.AutoUserId " +
					   " where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditNum=" + auditNum + " order by SortId";

			DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
			return dt;
		}

        /// <summary>
        /// 单据实际的审批列表,包括打回和正常的审批记录
        /// </summary>
        /// <param name="billId"></param>
        /// <param name="functionId"></param>
        /// <returns></returns>
        public static DataTable GetAuditFlowOfAuditFlowLine(string billId, string functionId)
        {
            //string sql = "select l.*  from AuditFlowLine l "
            //            + " where  l.AutoFlowId in("
            //            + "        select distinct lu.AutoFlowId from AuditFlowLineUser lu where BillId='" + billId + "' and FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum=" + auditNum
            //            + "    )"
            //            + " and l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditNum=" + auditNum+" order by SortId";

            string sql = "select l.*,b.AuditNode,c.userName,case when l.backBillFlag='1' then '打回' else '' end BackName " +
                        " from AuditFlowLine l left outer join AuditNode b  on l.AuditNodeId= b.AuditNodeId  "
                       + "left outer join users c on l.AuditUserId=c.AutoUserId " +
                       " where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' order by  AuditNum, SortId";

            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }

//        /// <summary>
//        /// 智力成果实际的审批列表,包括打回和正常的审批记录
//        /// </summary>
//        /// <param name="billId">智力成果编号</param>
//        /// <param name="functionId">交付物三位编码</param>
//        /// <param name="IfZLCG">是否智力成果</param>
//        /// <returns></returns>
//        public static DataTable GetAuditFlowOfAuditFlowLine(string billId, string functionId,string IfZLCG) {
//            string sql = @"select l.*,b.AuditNode,c.userName,case when l.backBillFlag='1' then '打回' else '' end BackName 
//						 from AuditFlowLine l left outer join AuditNode b  on l.AuditNodeId= b.AuditNodeId  
//							left outer join users c on l.AuditUserId=c.AutoUserId 
//					    where l.BillId='" + billId + @"' and l.FunctionId=
//						(SELECT b.Id FROM JFW_ZLCG a 
//						INNER JOIN JFW b ON b.JFWId=a.JFWId 
//						INNER JOIN PrjJFW c ON c.PlanVersion=b.PlanVersion AND c.PrjId=b.PrjId 
//						WHERE CGId='" + billId + "') order by  AuditNum, SortId";

//            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//            return dt;
//        }

        /// <summary>
        /// 单据计划审批列表
        /// </summary>
        /// <param name="billId"></param>
        /// <param name="functionId"></param>
        /// <returns></returns>
        public static DataTable GetAuditFlowOfAuditFlowLineUser(string billId, string functionId)
        {

            string sql = "select l.*,b.AuditNode,d.AuditUserId,u.userName,orderId " +
                        "from AuditFlowLine l " +
                        "inner join AuditNode b  on l.AuditNodeId= b.AuditNodeId " +
                        "inner join AuditFlowLineUser d on l.AutoFlowId=d.AutoFlowId " +
                        "and l.BillId=d.BillId and l.AuditNum=d.AuditNum " +
                        "inner join users u on d.AuditUserId=u.AutoUserId " +
                        "where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.AuditType='0' " +
                        "union all " +
                        "select l.*,b.AuditNode,d.AuditUserId,u.roleName,orderId " +
                        "from AuditFlowLine l " +
                        "inner join AuditNode b  on l.AuditNodeId= b.AuditNodeId " +
                        "inner join AuditFlowLineUser d on l.AutoFlowId=d.AutoFlowId " +
                        "and l.BillId=d.BillId and l.AuditNum=d.AuditNum " +
                        "inner join AuditRole_User u on d.AuditUserId=u.RoleId " +
                        "where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.AuditType='1' " +
						"order by  l.AuditNum, SortId,orderId ";


            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            return dt;
        }
        #endregion

        #region 根据单据审批流程编号、单据编号、审核次数查询审批记录

        /// <summary>
        /// 根据单据审批流程编号、单据编号、审核次数查询审批记录
        /// </summary>
        /// <param name="autoFlowId">单据审批流程编号</param>
        /// <param name="billId">单据编号</param>
        /// <param name="auditNum">审核次数</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        /// <returns>审批记录</returns>
        public static DataTable GetAuditFlowLine(int autoFlowId,string functionId, string billId, int auditNum,string flowFlag)
        {
            string sql = "select * from AuditFlowLine l where AutoFlowId=" + autoFlowId + "  and l.FunctionId='" + functionId + "' and l.BillId='" + billId + "' and l.AuditNum=" + auditNum + " and l.FlowFlag='" + flowFlag + "'";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        #endregion

        #region 更新此单据审批记录的标记为不通过
       
        /// <summary>
        /// 更新此单据审批记录的标记为不通过
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditNum">审批次数</param>
        /// <param name="auditFlag">审批标记</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        public static void ModifyAuditFlowLineForAuditFlag(string billId, string functionId,string auditFlag,string flowFlag)
        {
            //string sql = "update AuditFlowLine set AuditDate='"+ RiLiGlobal.RiLiDataAcc.GetNow().ToString()+"', AuditFlag='" + auditFlag + "' where AutoFlowId in(select AutoFlowId from AuditFlowDefin d where FunctionId='" + functionId + "' ) and BillId='" + billId + "' and  FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "'";
			string sql = "update AuditFlowLine set AuditFlag='" + auditFlag + "' where AutoFlowId in(select AutoFlowId from AuditFlowDefin d where FunctionId='" + functionId + "' ) and BillId='" + billId + "' and  FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billId"></param>
        /// <param name="functionId"></param>
        /// <param name="AutoFlowId"></param>
        /// <param name="flowFlag"></param>
        /// <param name="AuditNum">第几次审核</param>
        public static void ModifyAuditFlowLineForBackBillFlag(string billId, string functionId, string AutoFlowId,string flowFlag)
        {
            int maxAuditNum = GetMaxAuditNumByFunctionId(billId, functionId, flowFlag);
			//string sql = "update AuditFlowLine set BackBillFlag='1' where AutoFlowId ='" + AutoFlowId + "' and BillId='" + billId
			//    + "' and  FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum='" + maxAuditNum + "' ";

			string sql = "update AuditFlowLine set AuditDate='" +  RiLiGlobal.RiLiDataAcc.GetNow().ToString() + "',BackBillFlag='1' where AutoFlowId ='" + AutoFlowId + "' and BillId='" + billId
			  + "' and  FunctionId='" + functionId + "' and FlowFlag='" + flowFlag + "' and AuditNum='" + maxAuditNum + "' ";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 根据用户ID，查询用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户信息</returns>
        public static DataTable GetUsersByUserId(string userId)
        {
            string sql = "select * from Users where userId='"+userId+"'";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        #endregion

        #region 根据用户autoUserId查询用户记录
        public static DataTable GetUser(string autoUserId)
        {
            return Bao.DataAccess.DataAcc.ExecuteQuery("select * from Users where AutoUserId=" + autoUserId.Trim());
        }
        #endregion 


        #region 获得审批记录中的审批流程
        /// <summary>
        /// 根据功能编码，查询单据审批流程数量
        /// </summary>
        /// <param name="functionId">功能编码</param>
        /// /// <param name="flowFlag">流程标志</param>
        /// <returns>审批流程数量</returns>
        public static int GetFlowCountByFunctionId(string billId,  string functionId, string flowFlag,int auditNum)
        {
            string sql = "select count(*) from AuditFlowLine l where l.BillId='" + billId + "' and l.FunctionId='" + functionId + "' and l.FlowFlag='" + flowFlag + "' and l.AuditNum=" + auditNum;
            int count = Convert.ToInt32(Bao.DataAccess.DataAcc.ExecuteScalar(sql));
            return count;
        }
        #endregion

        #region  鲍增加

        #region 找某结点的审核人员
        /// <summary>
        /// 找某结点的审核人员
        /// </summary>
        /// <param name="BillId"></param>
        /// <param name="AutoFlowId"></param>
        /// <param name="folwFlag"></param>
        /// <param name="auditNum"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetAuditUser(string BillId, string AutoFlowId, string folwFlag, int auditNum)
        {
            string ss = "select lu.AuditUserId from AuditFlowLine l,AuditFlowLineUser lu " +
                           "where l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and l.AuditType='0' and lu.BillId='" + BillId + "' and lu.AutoFlowId='" + AutoFlowId +
                           "' and lu.AuditNum='" + auditNum + "' and lu.FlowFlag='" + folwFlag +
                           "' order by OrderId ";
            System.Data.DataTable tuser = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
            if (tuser.Rows.Count == 0)
            {
                ss = "select c.AutoUserId AuditUserId from AuditFlowLine l,AuditFlowLineUser lu, AuditRole_User c " +
                                         "where l.AutoFlowId=lu.AutoFlowId and l.BillId=lu.BillId and l.AuditNum=lu.AuditNum and lu.AuditUserid= c.RoleId and l.AuditType='1' and lu.BillId='" + BillId + "' and lu.AutoFlowId='" + AutoFlowId +
                                         "' and lu.AuditNum='" + auditNum + "' and lu.FlowFlag='" + folwFlag +
                                         "' order by OrderId ";

              tuser = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
              if (tuser.Rows.Count == 0)
                  throw new Exception("没有审批人员");
            }
            return tuser;
           
        }
        #endregion
        #region 查找第一个审核人员
        /// <summary>
        /// 查找第一个审核人员
        /// </summary>
        /// <param name="funcId">功能编号</param>
        /// <param name="BillId">单据编号</param>
        /// <param name="folwFlag">0:提交审核权限，1：检索审核权限</param>
        /// <returns></returns>
        public static string FirstAuditUser(string funcId, string BillId, string folwFlag)
        {
            string NextUserId = "";
            ///得到最大的审批次数
            int auditNum = GetMaxAuditNumByFunctionId(BillId, funcId, folwFlag);
            DataTable dt = GetAuditFlowOfAuditFlowLine(BillId, funcId, auditNum, folwFlag);
            if (dt.Rows.Count > 0)
            {
                System.Data.DataTable tuser = GetAuditUser(BillId, dt.Rows[0]["AutoFlowId"].ToString().Trim(), folwFlag, auditNum);
                if (tuser.Rows.Count > 0)
                {
                    NextUserId = tuser.Rows[0]["AuditUserId"].ToString().Trim();
                }
                else
                {
                    NextUserId = "";
                }

            }
            return NextUserId;
        }
        #endregion
        #region 根据本审核人员找下个结点的审核人员
        /// <summary>
        /// 根据本结点找下个结点的审核人员
        /// </summary>
        /// <param name="funcId">功能编号</param>
        /// <param name="BillId">单据编号</param>
        /// <param name="UserId">本节点审核人员</param>
        /// <param name="folwFlag">0:提交审核权限，1：检索审核权限</param>
        /// <returns></returns>
        public static string NextAuditUser(string funcId, string BillId, string UserId, string folwFlag)
        {
            string NextUserId="";
            ///得到最大的审批次数

            int auditNum = GetMaxAuditNumByFunctionId(BillId, funcId, folwFlag);
            DataTable dd = GetAuditFlowLineByBillIdAndFunctionIdAndAuditUserName(BillId, funcId, UserId, auditNum, folwFlag);
           
            DataTable dt =GetAuditFlowOfAuditFlowLine(BillId, funcId, auditNum, folwFlag);
            for(int i=0;i< dt.Rows.Count ;i++)
            {
                if (dt.Rows[i]["AuditNodeId"].ToString().Trim() == dd.Rows[0]["AuditNodeId"].ToString().Trim())
                {
                    
                    if (i<dt.Rows.Count-1) //不是末级结点
                    {
                        int j = i + 1;//下一个节点
                        System.Data.DataTable tuser = GetAuditUser(BillId, dt.Rows[j]["AutoFlowId"].ToString().Trim(), folwFlag, auditNum);
                        if (tuser.Rows.Count > 0)
                        {
                            NextUserId= tuser.Rows[0]["AuditUserId"].ToString().Trim();
                        }
                        else
                        {
                            NextUserId= "";
                        }

                    }
                    else
                    {
                        NextUserId= "";
                    }
                    break;
                }

            }
            return NextUserId;

        }
        
        #endregion 
        /// <summary>
        ///  是否已提交
        /// </summary>
        /// <param name="FunctionId"></param>
        /// <param name="BillId"></param>
        /// <param name="FolwFlag"></param>
        /// <returns></returns>
        public static Boolean IsUpLoad(string FunctionId,string BillId,string FolwFlag)
        {
            int auditNum = GetMaxAuditNumByFunctionId(BillId, FunctionId, FolwFlag);
			DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(BillId, FunctionId, auditNum, FolwFlag);
			//DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLineAll(BillId, FunctionId, auditNum, FolwFlag);
            if (flowOfFlowLineTable.Rows.Count >0)
                return true;
            return false;
        }

        /// <summary>
        /// 是否正在审核
        /// </summary>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillId">单据编号</param>
        /// <param name="FolwFlag">0:提交审核权限，1：检索审核权限</param>
        /// <returns></returns>
        public static Boolean  IsAuditing(string FunctionId,string BillId,string FolwFlag)
        {
            int auditNum = GetMaxAuditNumByFunctionId(BillId, FunctionId, FolwFlag);
            //获得此流程在审批记录中的数据
            DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(BillId, FunctionId, auditNum, FolwFlag);

            foreach (System.Data.DataRow row1 in flowOfFlowLineTable.Rows)
            {
                if (row1["AuditFlag"].ToString() == "1")
                    return true;
            }
            return false;
        }

		/// <summary>
		/// 是否打回
		/// </summary>
		/// <param name="FunctionId">功能编号</param>
		/// <param name="BillId">单据编号</param>
		/// <param name="FolwFlag">0:提交审核权限，1：检索审核权限</param>
		/// <returns></returns>
		public static Boolean IsFightBack(string FunctionId, string BillId, string FolwFlag) {
			int auditNum = GetMaxAuditNumByFunctionId(BillId, FunctionId, FolwFlag);
			//获得此流程在审批记录中的数据
			DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLineAll(BillId, FunctionId, auditNum, FolwFlag);

			foreach (System.Data.DataRow row1 in flowOfFlowLineTable.Rows) {
				if (row1["AuditFlag"].ToString().Trim() == "2")
					return true;
			}
			return false;
		}

        /// <summary>
        /// 是否审核完毕
        /// </summary>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillId">单据编号</param>
        /// <param name="FolwFlag">0:提交审核权限，1：检索审核权限</param>
        /// <returns></returns>
        public static Boolean IsAudited(string FunctionId, string BillId, string FolwFlag)
        {
            int auditNum = GetMaxAuditNumByFunctionId(BillId, FunctionId, FolwFlag);
            //获得此流程在审批记录中的数据
            DataTable flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(BillId, FunctionId, auditNum, FolwFlag);
            int i=0;
            foreach (System.Data.DataRow row1 in flowOfFlowLineTable.Rows)
            {
                if (row1["AuditFlag"].ToString() == "1")
                    i++;
            }
            if (i == flowOfFlowLineTable.Rows.Count && i > 0) //当查询出的流程记录中没有记录时，也不能弃审
                return true;
            else
                return false;
        }
        public static System.Data.DataRow  AuditNodeLineRecord(string FunctionId,string BillId,int OrderId,string FolwFlag)
        {
           // string NextUserId="";
            
            ///得到最大的审批次数
            int auditNum = GetMaxAuditNumByFunctionId(BillId, FunctionId, FolwFlag);
            DataTable dt = GetAuditFlowOfAuditFlowLine(BillId, FunctionId, auditNum, FolwFlag);
            foreach (System.Data.DataRow row1 in dt.Rows)
            {
                if (int.Parse(row1["SortId"].ToString()) == OrderId)
                {
                    return row1;
                }
            }
            return null;
        }
        #endregion

    }
}
