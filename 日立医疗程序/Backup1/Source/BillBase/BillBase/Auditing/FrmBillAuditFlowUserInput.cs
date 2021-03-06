using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bao.BillBase;

namespace Bao.BillBase.Audit
{
    /// <summary>
    ///功能描述： 此为窗体类，提供设置审批人员
    /// </summary>
    public partial class FrmBillAuditFlowUserInput : Form
    {
        //定义用户显示窗口类
        private FrmBillAuditFlowUserSet frmUserSet;
        public Boolean CloseFlag = false;
        //定义流程ID
        public int aFlowId = 0;
        //审批类型
        private string aType = "";

        public string AType
        {
            get { return aType; }
            set { aType = value; }
        }

        public FrmBillAuditFlowUserInput()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 带参数构造方法
        /// </summary>
        /// <param name="fUserSet">审批人员管理窗口</param>
        public FrmBillAuditFlowUserInput(FrmBillAuditFlowUserSet fUserSet)
        {
            InitializeComponent();
            frmUserSet = fUserSet;
            baoButtonAuditUserName.button2.Click += new EventHandler(button2_Click);
            this.StartPosition = FormStartPosition.CenterScreen;
            //设置文本为不可用状态
            CommonMethod.SetEnable(txtAutoFlowId, false);
            CommonMethod.SetEnable(txtAuditUserName, false);
            CommonMethod.SetEnable(txtAuditNode, false);
            CommonMethod.SetEnable(txtOrderId, false);
            
            //设置SQL和标题
            SetBaoBtnBaoSQLandTitleName(fUserSet.AuFlowId,fUserSet.AuditType,fUserSet.FuncId.Trim(),fUserSet.AuditNodeId);
        }

        #region 设置SQL和显示表格标题
        //设置SQL和显示表格标题
        public void SetBaoBtnBaoSQLandTitleName(int autoFlowId, string auditType, string funcId, string AuditNodeId)
        {
            this.aType = auditType;

            frmUserSet.AuditType = auditType;
            if (auditType == "0")
            {
                this.baoButtonAuditUserName.BaoSQL = "select nu.*,a.*,u.* from AuditNode_User  as nu "
                                                    + "join AuditNode as a on a.AuditNodeId=nu.AuditNodeId "
                                                    + "join Users as u on nu.AutoUserId=u.AutoUserId "
                                                    + "where nu.AuditNodeId  in( select AuditNode from  AuditFlowDefin as d where AutoFlowId=" + autoFlowId + "  and d.FunctionId ='" + funcId.Trim() + "')";
                this.baoButtonAuditUserName.BaoTitleNames = "AuditNode=审批节点,userName=审批人员";
            }
            else
            {
                //this.baoButtonAuditUserName.BaoSQL = "select ru.*,u.*,e.* from AuditRole_User  as ru join Users u on u.AutoUserId=ru.AutoUserId "
                //                                    + " join AuditFlowExpression e on e.AuditUserId=u.UserId where e.AutoFlowId "
                //                                    + " in( select AutoFlowId from  AuditFlowDefin as d where AutoFlowId="+autoFlowId+"  and d.FunctionId ='"+funcId+"')";

                //this.baoButtonAuditUserName.BaoSQL = "select ru.RoleId AutoUserId ,ru.RoleName UserName,e.*,d.*,an.AuditNode as AuditNodeText from AuditRole_User  as ru  "
                //                                    + " join AuditFlowExpression e on e.AuditUserId=ru.autoUserId join AuditFlowDefin d on d.AutoFlowId=e.AutoFlowId join AuditNode an on an.AuditNodeId=d.AuditNode ";
                this.baoButtonAuditUserName.BaoSQL = "select RoleId AutoUserId,RoleName UserName,UserName UserUser from AuditRole_User a,users b where a.AutoUserId=b.AutoUserId";

                this.baoButtonAuditUserName.BaoTitleNames = "AutoUserId=角色编号,UserName=角色名称,UserUser=审批人员";
            }

            
            
        }
        #endregion

        //人员文本更新事件
        private void txtAuditUserName_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        //顺序文本更新事件
        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {
            //更新工具栏状态
            ChangeToolBtnState();
        }

        #region 根据添加和更新改变工具栏按钮状态
        //根据添加和更新改变工具栏按钮状态
        private void ChangeToolBtnState()
        {
            //如果是添加或更新，则添加和更新不要用，保存可用;如果isNew==false,isUpdate=true，则保存可用
            if (frmUserSet.isNew || frmUserSet.isUpdate)
            {
                //设置工具栏按钮可用状态
                frmUserSet.ChangeSaveStateToEnable(true);
            }
            else
            {
                frmUserSet.ChangeSaveStateToEnable(false);
            }
        }
        #endregion

        #region 验证输入文本
        //验证输入
        public bool CheckInput()
        {
            if (txtAutoFlowId.Text == "")
            {
                throw new Exception("请选择单据审批流程编码！");
            }
            else if (txtAuditUserName.Text == "")
            {
                throw new Exception("请选择审批人员！");
            }
            else if (!Regex.IsMatch(txtOrderId.Text.Trim(), @"^\d{1,2}$"))
            {
                txtOrderId.Focus();
                throw new Exception("请输入一至两数字顺序号！");
            }
            return true;
        }
        #endregion

        //双击关闭
        private void baoButtonAuditUserName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

            if (txtAuditNode.Text.Trim() == "")
            {
                MessageBox.Show("审批结点为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            this.txtAuditUserName.Text = e.ReturnRow1["userName"].ToString();
            
            frmUserSet.userId = e.ReturnRow1["AutoUserId"].ToString();

            //if (frmUserSet.AuditType == "1")
            //{
            //    txtAuditUserName.Text = e.ReturnRow1["RoleName"].ToString();
            //}
            //else
            //{
            //    frmUserSet.auditNode = e.ReturnRow1["AuditNode"].ToString();
            //}
        }

        //双击关闭
        private void baoButtonAutoFlowId_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            
           
        }

        //流程文本更新事件
        private void txtAutoFlowId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (frmUserSet.isNew && this.txtAutoFlowId.Text.Trim() != "")
                {
                    //获得流程结点审批人员的最大顺序
                    int maxOrder = AuditBillFlowUserSetManager.GetMaxOrderIdByautoFlowId(Convert.ToInt32(this.txtAutoFlowId.Text.Trim()));
                    maxOrder += 1;
                    txtOrderId.Text = maxOrder.ToString();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("数据访问不成功！");
                throw;
            }
            //如果是添加或更新，则添加和更新不要用，保存可用;如果isNew==false,isUpdate=true，则保存可用
            if (frmUserSet.isNew || frmUserSet.isUpdate)
            {
                //设置工具栏按钮可用状态
                frmUserSet.ChangeSaveStateToEnable(true);
            }
            else
            {
                frmUserSet.ChangeSaveStateToEnable(false);
            }
            
            
        }

        private void baoButtonAuditUserName_MouseClick(object sender, MouseEventArgs e)
        {
            //设置SQL和标题
            //SetBaoBtnBaoSQLandTitleName(Convert.ToInt32(txtAutoFlowId.Text.Trim()), this.aType,frmUserSet.FuncId.Trim());
        }

        void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void baoButtonAuditUserName_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmBillAuditFlowUserInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!CloseFlag)
            //{
            //    this.Visible = false;
            //    e.Cancel = true;
            //    if (IParentForm != null)
            //        IParentForm.OnClosed();
            //}
            if (!CloseFlag)
            {
                this.Visible = false;
                frmUserSet.isNew = false;
                frmUserSet.isUpdate = false;
                //更新工具栏状态
                ChangeToolBtnState();
                this.Visible = false;
                e.Cancel = true;
                //frmUserSet.Close();
            }
        }
    }
}
