using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bao.BillBase;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：实现单据审批流程的输入
    /// </summary>
    public partial class FrmBillAuditFlowInput : Form
    {
        //定义审批流程
        private Bao.BillBase.Auditing.IAuditFlowSet frmfFlowSet;


        public FrmBillAuditFlowInput()
        {
            InitializeComponent();
        }
        
        public FrmBillAuditFlowInput(Bao.BillBase.Auditing.IAuditFlowSet  frmSet)
        {
            InitializeComponent();
            frmfFlowSet = frmSet;
            txtFunctionId.Text = frmSet.FuncId.Trim();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //禁用
            CommonMethod.SetEnable(txtAutoFlowId, false);
            CommonMethod.SetEnable(txtFunctionId, false);
            CommonMethod.SetEnable(txtAuditNode, false);
            CommonMethod.SetEnable(txtSortId, false);
            CommonMethod.SetEnable(txtManagerUserName, false);
           // CommonMethod.SetEnable(txtAuditCycle, false);

            this.cboAuditType.Text = "人员审核";

            //选择审批结点
            this.baoBtnAuditNode.BaoSQL = "select AuditNodeId,AuditNode from AuditNode";
            this.baoBtnAuditNode.BaoTitleNames = "AuditNodeId=审批结点编号,AuditNode=审批结点名称";

            //选择功能编号
            this.baoBtnFunctionId.BaoSQL = "select FunctionId, FunctionName, stateText="
                                           + " case state when '0' then '暂停' when '1' then '正常' end,"
                                           + "  DLLName, WorkName, Param, Title, TitleGroup "
                                           + " from TFunctions where FunctionId='"+frmSet.FuncId.Trim()+"'";
            this.baoBtnFunctionId.BaoTitleNames = "FunctionId=功能编号,FunctionName=功能名称,stateText=状态,"
                                                + "DLLName=DLL路径和名称,WorkName=命名空间,Param=子窗体标记,Title=标题,TitleGroup=标题组";

            //选择管理员
            this.baoBtnManagerUserId.BaoSQL = "select UserId,userName,DeptName,Workpost from Users";
            this.baoBtnManagerUserId.BaoTitleNames = "UserId=用户编号,userName=用户名,DeptName=部门,Workpost=职位";

            //string functionId = "";
            //string funType="";
            //if (funType == "0")
            //{ }
            //else if (funType == "1")
            //{
            //    this.baoBtnFunctionId.BaoSQL = "select TemplateId, TemplateName, levelId, DLLPath,"
            //        +" ClassName, Id, CodeType, GS, FS, OldId from BaoProject..JFWBase";
            //    this.baoBtnFunctionId.BaoTitleNames =
            //        "Id=交付物模板三位编码,TemplateId=交付物模板编码,TemplateName=模板名称,DLLPath=DLL路径,ClassName=类全名称,FS=提交格式";
            //}
            
        }

        //验证
        public bool CheckInput()
        {
            string functionId = this.txtFunctionId.Text.Trim();
            string auditNode = this.txtAuditNode.Text.Trim();
            if (functionId == "")
            {
                throw new Exception("请您选择功能编号！");
            }
            else if (auditNode == "")
            {
                throw new Exception("请您选择审批结点！");
            }
            else if (txtSortId.Text == "")
            {
                txtSortId.Focus();
                throw new Exception("请输入流程顺序号！");
            }
            else if (!Regex.IsMatch(txtSortId.Text.Trim(), @"^\d{1,2}$"))
            {
                this.txtSortId.Focus();
                throw new Exception("流程顺序号输入必须为一或两位数字！");
            }
            else if (!Regex.IsMatch(txtAuditCycle.Text.Trim(), @"^\d{1,2}$"))
            {
                this.txtAuditCycle.Focus();
                throw new Exception("流程周期输入必须为一或两位数字！");
            }
            else if (txtManagerUserName.Text == "")
            {
                throw new Exception("请您选择管理员！");
            }
            return true;
        }

        //功能编码文本框输入更新事件
        private void txtFunctionId_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
            try
            {
                if (frmfFlowSet.IsNew)
                {
                    //获得最大流程编号
                   // frmfFlowSet.SortId = AuditBillFlowManager.GetMaxSortId(txtFunctionId.Text.Trim(),txtGroupId.Text) + 1;
                   // txtSortId.Text = frmfFlowSet.SortId.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据访问不成功！");
            }
        }

        //审批结点文本框输入更新事件
        private void txtAuditNode_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        //双击列表中的数据，并关闭窗口
        private void baoBtnFunctionId_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            txtFunctionId.Text = e.ReturnRow1["FunctionId"].ToString();           
        }

        //双击列表中的数据，并关闭窗口
        private void baoBtnAuditNode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            try
            {
                txtAuditNode.Text = e.ReturnRow1["AuditNode"].ToString();
                frmfFlowSet.AuditNode = e.ReturnRow1["AuditNodeId"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("不能取得数据！");
            }
        }

        #region 根据添加和更新改变工具栏按钮状态
        //根据添加和更新改变工具栏按钮状态
        private void ChangeToolBtnState()
        {
            //如果是添加或更新，则添加和更新不要用，保存可用;如果isNew==false,isUpdate=true，则保存可用
            if (frmfFlowSet.IsNew || frmfFlowSet.IsUpdate)
            {
                //设置工具栏按钮可用状态
                frmfFlowSet.ChangeSaveStateToEnable(true);
            }
            else
            {
                frmfFlowSet.ChangeSaveStateToEnable(false);
            }
        }
        #endregion

        private void txtSortId_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        private void FrmBillAuditFlowInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmfFlowSet.IsNew = false;
            frmfFlowSet.IsUpdate = false;
            //更新工具栏状态
            ChangeToolBtnState();
        }

        private void txtAuditCycle_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        private void txtManagerUserName_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        private void baoBtnManagerUserId_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            frmfFlowSet.ManagerUserId = e.ReturnRow1["UserId"].ToString();
            txtManagerUserName.Text = e.ReturnRow1["UserName"].ToString();
        }


    }
}
