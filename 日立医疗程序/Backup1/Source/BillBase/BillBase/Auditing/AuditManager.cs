using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 单据业务逻辑类（为外部提供调用方法的类）
    /// </summary>
    public class AuditManager
    {
        /// <summary>
        ///  此方法为审批人员提供审批的功能
        /// </summary>
        /// <param name="billId">单据</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="auditUserId">审批人员</param>
        /// <param name="message">返回的提示信息</param>
        /// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
        /// <returns>bool为true可进入审批</returns>
        public static bool AuditBill(string billId, string functionId, string autoUserId,string flowFlag, out string message)
        {
            message = "";
            //DataTable dtUser = AuditBillManager.GetUser(autoUserId);
            //string auditUserId = dtUser.Rows[0]["UserId"].ToString().Trim();
            return AuditBillManager.AuditBill(billId.Trim(), functionId.Trim(), autoUserId, flowFlag, out message);
        }

        /// <summary>
        /// 生成审批记录 (添加单据流程至审批记录中)
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
        public static void AddFlowDefineToFlowLine(string billId, string functionId,string flowFlag)
        {
            if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(functionId, billId, "0"))
            {
                throw new Exception("已经提交了,不能重复提交");
              
            }
            AuditBillManager.AddFlowDefineToFlowLine(billId, functionId,flowFlag);
            AuditBillManager.AddInfoToFlowLineUser(billId, functionId, flowFlag);
           
            
        }

		/// <summary>
		/// 生成审批记录(添加交付物流程至审批记录中)
		/// </summary>
		/// <param name="billId">业务号</param>
		/// <param name="jFWId">交付物编号</param>
		/// <param name="functionId">交付物三位编码</param>
		/// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
        public static void AddFlowDefineToFlowLine(string billId,string jFWId, string functionId, string flowFlag)
        {
			
            if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(functionId, jFWId, "0"))
            {
                throw new Exception("已经提交了,不能重复提交");

            }
            AuditBillManager.AddFlowDefineToFlowLine(jFWId, functionId, flowFlag);
            AuditBillManager.AddInfoToFlowLineUser(billId,jFWId, functionId, flowFlag);
        }

		
		/// <summary>
		/// 生成审批记录(智力成果或以表单提交的交付物)
		/// </summary>
		/// <param name="billId">业务号</param>
		/// <param name="jFWOrZLCGId">交付物编号或智力成果编号</param>
		/// <param name="functionId">交付物三位编码</param>
		/// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
		/// <param name="IfZLCG">是否智力成果</param>
		/// <returns>返回交付物三位编码</returns>
		public static string AddFlowDefineToFlowLine(string billId, string jFWOrZLCGId, string functionId, string flowFlag, string IfZLCG) {
			string jfwid = string.Empty;
			if (string.IsNullOrEmpty(jFWOrZLCGId.Trim())) {
				jFWOrZLCGId = billId;
				string strSql = string.Format(@"IF EXISTS(SELECT * FROM JFW WHERE JFWId='{0}')
			 										SELECT a.JFWId,b.BillId,a.Id,0 AS IfZLCG FROM JFW a 
													INNER JOIN PrjJFW b ON b.PlanVersion=a.PlanVersion AND b.PrjId=a.PrjId 
													WHERE JFWId='{0}'
												ELSE 
													 SELECT a.JFWId,c.BillId,b.Id,1 AS IfZLCG FROM JFW_ZLCG a 
														INNER JOIN JFW b ON b.JFWId=a.JFWId 
														INNER JOIN PrjJFW c ON c.PlanVersion=b.PlanVersion AND c.PrjId=b.PrjId 
														WHERE CGId='{0}'", jFWOrZLCGId);
				DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(strSql);
				if (dt.Rows.Count <= 0) {
					throw new Exception("没有相关的业务号和三位编码");
				}
				jfwid = dt.Rows[0]["JFWId"].ToString().Trim();
				billId = dt.Rows[0]["BillId"].ToString().Trim();
				functionId = dt.Rows[0]["Id"].ToString().Trim();
				IfZLCG = dt.Rows[0]["IfZLCG"].ToString().Trim();
			}
			if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(functionId, jFWOrZLCGId, "0")) {
				throw new Exception("已经提交了,不能重复提交");

			}
			AuditBillManager.AddFlowDefineToFlowLine(jFWOrZLCGId, functionId, flowFlag);
			if (IfZLCG == "0")
				AuditBillManager.AddInfoToFlowLineUser(billId, jFWOrZLCGId, functionId, flowFlag);
			else {
				AuditBillManager.AddInfoToFlowLineUser(billId, jfwid, functionId, flowFlag, jFWOrZLCGId);
			}
			return functionId;
		}

		/// <summary>
		/// 收回
		/// </summary>
		/// <param name="billId"></param>
		/// <param name="functionId"></param>
		/// <param name="flowFlag"></param>
        public static void DeleFlowLine(string billId, string functionId, string flowFlag)
        {
			if(Bao.BillBase.Audit.AuditBillManager.IsAudited(functionId, billId, "0"))
				throw new Exception("该单据已审核通过，不能收回！");
			if(Bao.BillBase.Audit.AuditBillManager.IsFightBack(functionId,billId,"0"))
				throw new Exception("该单据被打回，不能收回！");
            if (Bao.BillBase.Audit.AuditBillManager.IsAuditing(functionId , billId, "0"))
                throw new Exception("该单据正在审批，不能收回！");
			//判断是否当前流程是否已经走完，如果走完，则不能收回
            int auditNum = AuditBillManager.GetMaxAuditNumByFunctionId(billId, functionId, flowFlag); //审批次数加一
            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
            Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
            try
            {
                AuditBillManager.DeleFlowLine(billId, functionId, flowFlag, auditNum);
                AuditBillManager.DeleFlowLineUser(billId, functionId, flowFlag, auditNum);
                sqlTran.Commit();

            }
            catch (Exception ee)
            {
                sqlTran.Rollback();
                throw new Exception("收回失败，原因：" + ee.Message);
            }
        }


//        /// <summary>
//        /// 收回审批流程
//        /// </summary>
//        /// <param name="billId">交付物或智力成果编号</param>
//        /// <param name="functionId">三位编码</param>
//        /// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
//        /// <param name="Ifzlcg">特殊标识</param>
//        public static void DeleFlowLine(string billId, string functionId, string flowFlag,string Ifzlcg) {
//            if (string.IsNullOrEmpty(functionId)) {
//                string strSql = string.Format(@"IF EXISTS(SELECT * FROM JFW WHERE JFWId='{0}')
// 										SELECT b.BillId,a.Id FROM JFW a 
//										INNER JOIN PrjJFW b ON b.PlanVersion=a.PlanVersion AND b.PrjId=a.PrjId 
//										WHERE JFWId='{0}'
//									ELSE 
//										 SELECT c.BillId,b.Id FROM JFW_ZLCG a 
//											INNER JOIN JFW b ON b.JFWId=a.JFWId 
//											INNER JOIN PrjJFW c ON c.PlanVersion=b.PlanVersion AND c.PrjId=b.PrjId 
//											WHERE CGId='{0}'", billId);
//                DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(strSql);
//                if (dt.Rows.Count <= 0) {
//                    throw new Exception("没有相关的业务号和三位编码");
//                }
//                //billId = dt.Rows[0]["BillId"].ToString().Trim();
//                functionId = dt.Rows[0]["id"].ToString();
//            }

//            if (Bao.BillBase.Audit.AuditBillManager.IsAuditing(functionId, billId, "0"))
//                throw new Exception("该单据正在审批，不能收回");
//            int auditNum = AuditBillManager.GetMaxAuditNumByFunctionId(billId, functionId, flowFlag); //审批次数加一
//            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
//            Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
//            try {
//                AuditBillManager.DeleFlowLine(billId, functionId, flowFlag, auditNum);
//                AuditBillManager.DeleFlowLineUser(billId, functionId, flowFlag, auditNum);
//                sqlTran.Commit();

//            } catch (Exception ee) {
//                sqlTran.Rollback();
//                throw new Exception("收回失败，原因：" + ee.Message);
//            }
//        }

        /// <summary>
        /// 打开单据审批人员设置窗口
        /// </summary>
        public static void OpenFrmBillAuditFlowUserSet(string funcId,int autoFlowID,string auditNodeName,string auditType,string auditNodeId)
        {
            FrmBillAuditFlowUserSet fbafUser = null;
            if (fbafUser == null || fbafUser.IsDisposed == true )
            {
                fbafUser = new FrmBillAuditFlowUserSet(funcId, autoFlowID, auditNodeName, auditType, auditNodeId);
            }
            fbafUser.FuncId = funcId;
            fbafUser.AuFlowId = autoFlowID;
            fbafUser.AuNodeName = auditNodeName;
            fbafUser.AuditType = auditType;
            fbafUser.AuditNodeId = auditNodeId;
            fbafUser.Show();
        }

        /// <summary>
        /// 打开交付物审批流程设置窗口
        /// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
        /// </summary>
        public static void OpenFrmJFWAuditFlowSet(string funId, string flowFlag)
        {
            Bao.BillBase.Audit.FrmJFWAuditFlowSet fbaFlow = null;

            fbaFlow = new Bao.BillBase.Audit.FrmJFWAuditFlowSet (funId, flowFlag);

            fbaFlow.FuncId = funId;
            fbaFlow.FlowFlag = flowFlag;
            fbaFlow.Show();
        }

        /// <summary>
        /// 打开单据审批流程设置窗口
        /// <param name="flowFlag">流程标志0:为提交流程 1：为检索流程</param>
        /// </summary>
        public static void OpenFrmBillAuditFlowSet(string funId,string flowFlag)
        {
            Bao.BillBase.Audit.FrmBillAuditFlowSet fbaFlow = null;

            fbaFlow = new Bao.BillBase.Audit.FrmBillAuditFlowSet(funId, flowFlag);
            
            fbaFlow.FuncId = funId;
            fbaFlow.FlowFlag = flowFlag;
            fbaFlow.Show();
        }

        /// <summary>
        /// 打开单据审核窗口
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编码</param>
        /// <param name="userId">用户ID</param>
        /// <param name="message">返回的提示信息</param>
        public static void OpenFrmAuditBill(string billId, string functionId, string autoUserId)
        {
            //DataTable dtUser = AuditBillManager.GetUser(autoUserId);
            //string auditUserId = dtUser.Rows[0]["UserId"].ToString().Trim();
            //打开窗口
            //FrmBillAudit fba = new FrmBillAudit(billId, functionId, autoUserId);
            //fba.ShowDialog();
        }

        /// <summary>
        /// 打开流程窗口
        /// </summary>
        /// <param name="funcId">功能编号</param>
        public static void OpenFrmSearchFlow(string funcId,string flowFlag)
        {
            FrmBillAuditFlowSearch fbafSearch = null;
            if (fbafSearch == null || fbafSearch.IsDisposed == true)
            {
                fbafSearch = new FrmBillAuditFlowSearch(funcId,flowFlag);
            }
            fbafSearch.FuncId = funcId;
            fbafSearch.FlowFlag = flowFlag;
            fbafSearch.Show();
        }

        /// <summary>
        /// 打开流程为设置结点人员
        /// </summary>
        /// <param name="funcId">功能编号</param>
        /// <param name="flowFlag">流程标志</param>
        public static void OpenFrmFlowShowSetUser(string funcId,string BillId, string flowFlag,System.Data.DataTable AuditUsers)
        {
            JFWUserSet.FrmFlowShow ffs = null;
            ffs = new JFWUserSet.FrmFlowShow(funcId, BillId, flowFlag, AuditUsers);
            ffs.Show();
        }


        /// <summary>
        /// 根据审批人员，时间间隔，判断单据流程是否到
        /// </summary>
        /// <param name="auditUserId">人员ID</param>
        /// <returns>是否流转到</returns>
        public static bool IsToUserIdAudit(string auditUserId)
        {
           
            return true;
        }

    }
}
