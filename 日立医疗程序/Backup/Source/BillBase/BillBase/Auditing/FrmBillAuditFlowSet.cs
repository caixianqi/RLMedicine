using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bao.BillBase;
using System.Text.RegularExpressions;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：此类为窗体类，用于实现单据流程的管理（添加、删除、更新、查询并显示数据）
    /// </summary>
    public partial class FrmBillAuditFlowSet : Bao.BillBase.LookUpBasis, IChildForm,Bao.BillBase.Auditing.IAuditFlowSet 
    {
        private string funcId;
        private System.Data.DataTable TAuditGroup;
        private string flowFlag;
        
        
        private FrmBillAuditFlowInput frmInput = null;//单据流程输入窗体
        DataRow selDataRow = null;                    //选中的行数据
        public bool isNew = false;                    //是否添加
        public bool isUpdate = false;                 //是否更新
        public string auditNode = "";                 //审批结点
        public int sortId = 0;                        //顺序号
        private int auCycle;                          //审批周期

        private string managerUserId;                 //管理人员


        
        public int AuCycle
        {
            get { return auCycle; }
            set { auCycle = value; }
        }

        
        
        public string FlowFlag
        {
            get { return flowFlag; }
            set 
            { 
                flowFlag = value;
                if (flowFlag == "0")
                {
                    this.Text = "提交审批流程";
                }
                else
                {
                    this.Text = "检索审批流程";
                }
            }
        }
        public FrmBillAuditFlowSet()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            BtnAuditGroup.BaoSQL = "select * from AuditGroup ";
            BtnAuditGroup.BaoTitleNames = "AuditGroupId=编号,AuditGroupName=名称";

        }
        public FrmBillAuditFlowSet(string funId,string flowFlag)
        {
            InitializeComponent();
            funcId = funId;
            this.flowFlag = flowFlag;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //创建输入窗口对象
            frmInput = new FrmBillAuditFlowInput(this);
            
            try
            {
                //绑定单据审批流程数据
                dataBindingAuditDefin();
            }
            catch (Exception)
            {
                MessageBox.Show("数据加载不成功！");
            }

            try
            {
                //获得对应的功能表行数据
                DataRow row = GetFunction(funcId);
            }
            catch (Exception)
            {
                MessageBox.Show("数据加载不成功！");
            }

            toolBarBill1.baoBtnSelect.BaoSQL = "select FunctionId, FunctionName,TitleGroup,FunctionType from TFunctions where FunctionType='1'";
            toolBarBill1.baoBtnSelect.BaoTitleNames = "FunctionId=功能编号,FunctionName=功能名称,TitleGroup=分组";
            BtnAuditGroup.BaoSQL = "select * from AuditGroup ";
            BtnAuditGroup.BaoTitleNames = "AuditGroupId=编号,AuditGroupName=名称";
   
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region //绑定单据审批流程数据
        //绑定数据
        public void dataBindingAuditDefin()
        {
            
            this.DataBindings.Clear();
            this.gridControlAuditDefine.DataSource = null;
            TAuditGroup = AuditBillFlowManager.GetAuditFlwDefinesGroup(FuncId, flowFlag);
            this.gridControl1.DataSource = TAuditGroup;
            if (TAuditGroup.Rows.Count > 0)
                this.gridControlAuditDefine.DataSource = AuditBillFlowManager.GetAuditFlwDefines(FuncId, flowFlag, TAuditGroup.Rows[0]["AuditGroupId"].ToString().Trim());
        }
        #endregion

        #region 工具栏的添加事件
        //添加
        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            isNew = true;
            isUpdate = false;
            if (frmInput.IsDisposed)
            {
                frmInput = new FrmBillAuditFlowInput(this);
            }
            //将该窗口显示在this的前面
            this.AddOwnedForm(frmInput);
            frmInput.Show();

            //清空文本
            CommonMethod.TextClear(frmInput);
            frmInput.txtFunctionId.Text = funcId;
           
            frmInput.txtGroupId.Text = gridView2.GetDataRow(gridView2.FocusedRowHandle)["AuditGroupId"].ToString();
            this.sortId = AuditBillFlowManager.GetMaxSortId(frmInput.txtFunctionId.Text.Trim(), frmInput.txtGroupId.Text) + 1;
            frmInput.txtSortId.Text = this.sortId.ToString();
            try
            {
                frmInput.txtAutoFlowId.Text = (AuditBillFlowManager.GetMaxAutoFlowId() + 1).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("数据加载不成功！");
            }
        }
        #endregion

        #region 删除事件
        //删除
        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            if (frmInput.IsDisposed)
            {
                frmInput = new FrmBillAuditFlowInput(this);
            }

            //获得表中选中的数据行
            selDataRow = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
            int autoFlowId = Convert.ToInt32(selDataRow["AutoFlowId"]);
            try
            {
                DialogResult result = MessageBox.Show(frmInput, "是否删除？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    //删除审批流程记录
                    AuditBillFlowManager.DeleteAuditFlowDefinById(autoFlowId);
                    //重新绑定数据
                    dataBindingAuditDefin();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "删除不成功，请确认删除记录"
                   , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 添加或更新单据审批流程事件
        /// <summary>
        /// 添加或更新单据审批流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            
            if (frmInput.IsDisposed)
            {
                frmInput = new FrmBillAuditFlowInput(this);
            }
            try
            {
                //验证输入数据
                if (!frmInput.CheckInput())
                {
                    return;
                }

                string auditType = frmInput.cboAuditType.Text.Trim();
                sortId = Convert.ToInt32(frmInput.txtSortId.Text.Trim());
                auCycle = Convert.ToInt32(frmInput.txtAuditCycle.Text.Trim());
                if (auditType == "人员审核")
                {
                    auditType = "0";
                }
                else
                {
                    auditType = "1";
                }

                if (isNew)   //添加
                {
                    try
                    {
                        //调用添加流程定义方法
                        AuditBillFlowManager.InsertAuditFlowDefin(frmInput.txtFunctionId.Text.Trim(),
                            auditNode, auditType, sortId, auCycle, managerUserId, flowFlag, gridView2.GetDataRow(gridView2.FocusedRowHandle)["AuditGroupId"].ToString().Trim());
                        //清空文本
                        CommonMethod.TextClear(this);
                        frmInput.cboAuditType.Text = "人员审核";
                        isNew = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(frmInput, "不能添加,因同功能编号存在相同的审批结点，请重新选择！"
                           , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(isUpdate)                                     //更新
                {
                    //获得选中的行数据
                    selDataRow = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    int autoFlowId = Convert.ToInt32(selDataRow["AutoFlowId"]);

                    try
                    {
                        //调用更新流程定义的方法
                        AuditBillFlowManager.ModifyAuditFlowDefin(
                            autoFlowId, frmInput.txtFunctionId.Text.Trim(), auditNode.Trim()
                            , auditType.Trim(), Convert.ToInt32(frmInput.txtSortId.Text.Trim()), auCycle, managerUserId, flowFlag, gridView2.GetDataRow(gridView2.FocusedRowHandle)["AuditGroupId"].ToString().Trim());
                        //启用
                        CommonMethod.SetEnable(frmInput.txtSortId, true);
                        isUpdate = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(frmInput, "不能更新,因同功能编号存在相同的审批结点，请重新选择！",
                            "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //重新绑定数据
                dataBindingAuditDefin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 为文本框设置选中的行数据
        //获取数据方法
        private void GetDataRowToFrmInput()
        {
            int selIndex = gridView1.FocusedRowHandle;
            if (selIndex >= 0)
            {
                //获得选中的行数据
                selDataRow = this.gridView1.GetDataRow(selIndex);
                frmInput.txtAutoFlowId.Text = selDataRow["AutoFlowId"].ToString();
                frmInput.txtFunctionId.Text = selDataRow["FunctionId"].ToString();
                frmInput.txtAuditNode.Text = selDataRow["AuditNode"].ToString();

                managerUserId = selDataRow["ManagerUserId"].ToString(); 

                auditNode = selDataRow["AuditNodeId"].ToString();
                frmInput.txtSortId.Text = selDataRow["SortId"].ToString();
                frmInput.txtAuditCycle.Text = selDataRow["AuditCycle"].ToString();
                auCycle = Convert.ToInt32(selDataRow["AuditCycle"]);
                string auditType = selDataRow["AuditType"].ToString();

                frmInput.txtManagerUserName.Text = selDataRow["UserName"].ToString();
                if (auditType == "0")
                {
                    frmInput.cboAuditType.Text = "人员审核";
                }
                else
                {
                    frmInput.cboAuditType.Text = "角色审核";
                }
            }
        }
        #endregion

        #region 工具栏的更新事件
        //更新
        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            
            isUpdate = true;
            try
            {
                if (frmInput.IsDisposed)
                {
                    frmInput = new FrmBillAuditFlowInput(this);
                }
                //将该窗口显示在this窗口的前面
                this.AddOwnedForm(frmInput);
                frmInput.txtGroupId.Text = gridView2.GetDataRow(gridView2.FocusedRowHandle)["AuditGroupId"].ToString();
                frmInput.Show();

                //将表中选中的数据设置到流程输入窗口的文本中
                GetDataRowToFrmInput();
                //设置文本可用状态
                CommonMethod.SetEnable(frmInput.txtSortId, true);
            }
            catch (Exception)
            {
                MessageBox.Show("数据不能成功获取！");
            }
        }
        #endregion

        #region 工具栏的退出事件
        //退出
        private void toolBarBill1_OnBaoExit(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 数据表的双击事件
        private void gridControlAuditDefine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            isUpdate = true;
            isNew = false;
            if (frmInput.IsDisposed)
            {
                frmInput = new FrmBillAuditFlowInput(this);
            }
            
            try
            {
                //获得表中选中的数据行
                GetDataRowToFrmInput();
                //将该窗口显示在this窗口的前面
                this.AddOwnedForm(frmInput);
                frmInput.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("数据不能成功获取！");
            }
        }
        #endregion

        

        private void btnFlowUserSet_Click(object sender, EventArgs e)
        {
           
        }

        private void toolBarBill1_OnBaoSelect(object sender, FrmLookUp.LookUpEventArgs e)
        {
            FuncId = e.ReturnRow1["FunctionId"].ToString();
            dataBindingAuditDefin();
        }

       

        public DataRow GetFunction(string funcId)
        {
            string sql = "select FunctionId, FunctionName,TitleGroup,FunctionType from TFunctions where FunctionType='1' and  FunctionId='"+funcId+"'";
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }


        #region IChildForm 成员

        public DataTable GetTableList()
        {
            gridControlAuditDefine.ContextMenuStrip = contextMenuStrip1;

            this.IParentForm.toolBarBill1.baoBtnSelect.Visible =false;
            this.IParentForm.toolBarBill1.BtnAudit.Visible = false;
            this.IParentForm.toolBarBill1.BtnDeleteVisable = false;
            this.IParentForm.toolBarBill1.BtnExcelVisable = false;
            this.IParentForm.toolBarBill1.BtnNewVisable = false;
            this.IParentForm.toolBarBill1.BtnPrintVisable = false;
            this.IParentForm.toolBarBill1.BtnSaveVisable = false;
            this.IParentForm.toolBarBill1.BtnUpdateVisable = false;
            this.IParentForm.toolBarBill1.BtnCancel.Visible = false;
            this.IParentForm.toolBarBill1.BtnUnAudit.Visible = false;
            return Bao.DataAccess.DataAcc.ExecuteQuery("select FunctionId,FunctionName from TFunctions where TitleGroup ='单据'");
            
          

        }

        public void Append()
        {
            
        }

        public void Delete(DataRow row1)
        {
           
        }

        public void SetValueToControl(DataRow row1,Boolean Is_Update)
        {
            funcId = row1["FunctionId"].ToString();
            this.flowFlag = "0";
            frmInput = new FrmBillAuditFlowInput(this);

            try
            {
                //绑定单据审批流程数据
                dataBindingAuditDefin();
            }
            catch (Exception ee )
            {
				MessageBox.Show("数据加载不成功！\r\n原因：" + ee.Message);
            }

            try
            {
                //获得对应的功能表行数据
                DataRow row = GetFunction(funcId);
            }
            catch (Exception)
            {
                MessageBox.Show("数据加载不成功！");
            }

            toolBarBill1.baoBtnSelect.BaoSQL = "select FunctionId, FunctionName,TitleGroup,FunctionType from TFunctions where FunctionType='1'";
            toolBarBill1.baoBtnSelect.BaoTitleNames = "FunctionId=功能编号,FunctionName=功能名称,TitleGroup=分组";

        }

        #endregion
        protected override void OnClosed(EventArgs e)
        {
            
            base.OnClosed(e);
        }

        private void 配置人员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                AuditManager.OpenFrmBillAuditFlowUserSet(
                    row1["FunctionId"].ToString(), int.Parse(row1["AutoFlowId"].ToString()), row1["AuditNode"].ToString(),
                    row1["AuditType"].ToString(), row1["AutoFlowId"].ToString());
            }
        }

        private void 配置审核界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (gridView1.FocusedRowHandle >= 0)
            //{
            //    System.Data.DataRow row1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //    Bao.BillBase.Auditing.FrmAuditBillSet dd= new Bao.BillBase.Auditing.FrmAuditBillSet(row1["FunctionId"].ToString().Trim(), row1["AuditNodeId"].ToString().Trim());
            //    dd.ShowDialog();
            //}
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
			if (gridView2.FocusedRowHandle >= 0) {
				this.gridControlAuditDefine.DataSource =
					 this.gridControlAuditDefine.DataSource = AuditBillFlowManager.GetAuditFlwDefines(FuncId, flowFlag, gridView2.GetDataRow(gridView2.FocusedRowHandle)["AuditGroupId"].ToString().Trim());
			}
        }

        private void BtnAuditGroup_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            System.Data.DataRow row1=TAuditGroup.NewRow();
            row1["AuditGroupId"] = e.ReturnRow1["AuditGroupId"].ToString().Trim();
            row1["AuditGroupName"] = e.ReturnRow1["AuditGroupName"].ToString().Trim();
            TAuditGroup.Rows.Add(row1);
        }



      #region IAuditFlowSet 成员

        public string FuncId
        {
            get { return funcId; }
            set { funcId = value; }
        }
        public bool IsNew
        {
            get
            {
                return isNew;
            }
            set
            {
                isNew = value;
            }
        }

        bool Bao.BillBase.Auditing.IAuditFlowSet.IsUpdate
        {
            get
            {
                return isUpdate;
            }
            set
            {
                isUpdate = value;
            }
        }

        public string AuditNode
        {
            get
            {
                return auditNode;
            }
            set
            {
                auditNode = value;
            }
        }

        int Bao.BillBase.Auditing.IAuditFlowSet.SortId
        {
            get
            {
                return sortId;
            }
            set
            {
                sortId = value;
            }
        }
        public string ManagerUserId
        {
            get { return managerUserId; }
            set { managerUserId = value; }
        }
        #region 改变保存状态
        //改变保存状态
        public void ChangeSaveStateToEnable(bool flag)
        {
            toolBarBill1.BtnSave.Enabled = (flag == true ? true : false);
            toolBarBill1.BtnNew.Enabled = (flag == true ? false : true);
            toolBarBill1.BtnUpdate.Enabled = (flag == true ? false : true);
        }
        #endregion
        #endregion
    }
}

