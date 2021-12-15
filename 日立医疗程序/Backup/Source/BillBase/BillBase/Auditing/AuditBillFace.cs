using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bao.BillBase.Audit;
namespace Bao.BillBase.Auditing
{
    public  class AuditBillFace
    {
        public static int AuditState = 0;
        /// <summary>
        /// 分数等级
        /// </summary>
        public  string scoreLevel = ""; 
        /// <summary>
        /// 审核编号
        /// </summary>
        public int autoId = 0; 
        /// <summary>
        ///审核分数
        /// </summary>
        public int score = 0;                 
        /// <summary>
        /// //单据编号
        /// </summary>
        public string thisBillId = "";  
        /// <summary>
        /// //功能编号
        /// </summary>
        public string thisFunctionId = ""; 
        /// <summary>
        /// //用户ID 
        /// </summary>
        public string thisUserId = "";
        /// <summary>
        /// 审批次数
        /// </summary>
        public int thisAuditNum = 0;    
        /// <summary>
        /// //审核标记
        /// </summary>
        public string thisAuditFlag = "";  
        /// <summary>
        /// //批注
        /// </summary>
        public string Memo = "";                
        /// <summary>
        /// //要审批的单据
        /// </summary>
        public System.Data.DataTable billTable; 
       
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="billId">单号</param>
        /// <param name="functionId">功能编号</param>
        /// <param name="userId">用户编号</param>
        /// <param name="Ifrm">审核界面</param>
        public void Init(string billId, string functionId, string userId,IAuditFrm Ifrm)
        {
            string flowFlag = "0";
            
            //获得审批次数
            int maxAuditNum = AuditBillManager.GetMaxAuditNumByFunctionId(billId, functionId, flowFlag);

            thisBillId = billId;
            thisFunctionId = functionId;
            thisUserId = userId;
            thisAuditNum = maxAuditNum;


            //根据条件，获得此审批人员的信息
            billTable = AuditBillManager.GetAuditFlowLineByBillIdAndFunctionIdAndAuditUserName(billId, functionId, userId, maxAuditNum, flowFlag);
            Ifrm.BaoDataBinding();
        }
        /// <summary>
        /// 添加审批单据
        /// </summary>
        /// <param name="audtiFlag">审批标记,0:未审核，1：审核，2：审核不通过</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        public void UpdateAuditBill(string auditFlag, string flowFlag)
        {
            
            //调用业务逻辑更新该审核的单据
            AuditBillManager.UpdateAuditFlowLine(autoId, thisUserId, auditFlag, scoreLevel, score, Memo, flowFlag);
            if (auditFlag == "2")
            {
                AuditBillManager.ModifyAuditFlowLineForAuditFlag(thisBillId, thisFunctionId, "2", flowFlag);
                AuditBillManager.ModifyAuditFlowLineForBackBillFlag(thisBillId, thisFunctionId, billTable.Rows[0]["AutoFlowId"].ToString(), "0");

            }

        }
        
    }
}
