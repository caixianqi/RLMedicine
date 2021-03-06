namespace Bao.BillBase.Audit
{
    partial class FrmJFWAuditFlowSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJFWAuditFlowSet));
            this.toolBarBill1 = new FrmLookUp.ToolBarBill();
            this.gridControlAuditDefine = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AutoFlowId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FunctionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditTypeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FixedFlow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SortId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditNodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManagerUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置人员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolBarBill1.BtnAuditListVisable = false;
            this.toolBarBill1.BtnAuditVisable = false;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnExcelVisable = false;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnPrintVisable = false;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnSelectVisable = false;
            this.toolBarBill1.BtnUnAuditVisable = false;
            this.toolBarBill1.BtnUpCancelVisable = false;
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.BtnUpLoadVisable = false;
            this.toolBarBill1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarBill1.GridViewSource = null;
            this.toolBarBill1.Location = new System.Drawing.Point(0, 0);
            this.toolBarBill1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolBarBill1.Name = "toolBarBill1";
            this.toolBarBill1.SelectClassName = "";
            this.toolBarBill1.SelectDllPath = "";
            this.toolBarBill1.SelectSQL = "";
            this.toolBarBill1.SelectTitleName = null;
            this.toolBarBill1.Size = new System.Drawing.Size(1216, 28);
            this.toolBarBill1.TabIndex = 0;
            this.toolBarBill1.OnBaoNew += new FrmLookUp.ToolBarBill.BaoNew(this.toolBarBill1_OnBaoNew);
            this.toolBarBill1.OnBaoSelect += new FrmLookUp.ToolBarBill.BaoSelect(this.toolBarBill1_OnBaoSelect);
            this.toolBarBill1.OnBaoExit += new FrmLookUp.ToolBarBill.BaoExit(this.toolBarBill1_OnBaoExit);
            this.toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(this.toolBarBill1_OnBaoDelete);
            this.toolBarBill1.OnBaoSave += new FrmLookUp.ToolBarBill.BaoSave(this.toolBarBill1_OnBaoSave);
            this.toolBarBill1.OnBaoUpdate += new FrmLookUp.ToolBarBill.BaoUpdate(this.toolBarBill1_OnBaoUpdate);
            // 
            // gridControlAuditDefine
            // 
            this.gridControlAuditDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAuditDefine.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlAuditDefine.EmbeddedNavigator.Name = "";
            this.gridControlAuditDefine.Location = new System.Drawing.Point(0, 0);
            this.gridControlAuditDefine.MainView = this.gridView1;
            this.gridControlAuditDefine.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlAuditDefine.Name = "gridControlAuditDefine";
            this.gridControlAuditDefine.Size = new System.Drawing.Size(1216, 591);
            this.gridControlAuditDefine.TabIndex = 9;
            this.gridControlAuditDefine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlAuditDefine.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlAuditDefine_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AutoFlowId,
            this.FunctionId,
            this.AuditNodeName,
            this.AuditTypeText,
            this.FixedFlow,
            this.AuditType,
            this.SortId,
            this.AuditNodeId,
            this.AuditCycle,
            this.ManagerUser,
            this.userName});
            this.gridView1.GridControl = this.gridControlAuditDefine;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // AutoFlowId
            // 
            this.AutoFlowId.Caption = "单据审批流编码";
            this.AutoFlowId.FieldName = "AutoFlowId";
            this.AutoFlowId.Name = "AutoFlowId";
            this.AutoFlowId.OptionsColumn.AllowEdit = false;
            this.AutoFlowId.Visible = true;
            this.AutoFlowId.VisibleIndex = 0;
            this.AutoFlowId.Width = 150;
            // 
            // FunctionId
            // 
            this.FunctionId.Caption = "功能编号";
            this.FunctionId.FieldName = "FunctionId";
            this.FunctionId.Name = "FunctionId";
            this.FunctionId.OptionsColumn.AllowEdit = false;
            this.FunctionId.Visible = true;
            this.FunctionId.VisibleIndex = 1;
            this.FunctionId.Width = 118;
            // 
            // AuditNodeName
            // 
            this.AuditNodeName.Caption = "审批结点";
            this.AuditNodeName.FieldName = "AuditNode";
            this.AuditNodeName.Name = "AuditNodeName";
            this.AuditNodeName.OptionsColumn.AllowEdit = false;
            this.AuditNodeName.Visible = true;
            this.AuditNodeName.VisibleIndex = 3;
            this.AuditNodeName.Width = 132;
            // 
            // AuditTypeText
            // 
            this.AuditTypeText.Caption = "人员/角色";
            this.AuditTypeText.FieldName = "AuditTypeText";
            this.AuditTypeText.Name = "AuditTypeText";
            this.AuditTypeText.OptionsColumn.AllowEdit = false;
            this.AuditTypeText.Visible = true;
            this.AuditTypeText.VisibleIndex = 4;
            this.AuditTypeText.Width = 114;
            // 
            // FixedFlow
            // 
            this.FixedFlow.Caption = "流程";
            this.FixedFlow.FieldName = "FixedFlow";
            this.FixedFlow.Name = "FixedFlow";
            this.FixedFlow.OptionsColumn.AllowEdit = false;
            // 
            // AuditType
            // 
            this.AuditType.Caption = "审批类型";
            this.AuditType.FieldName = "AuditType";
            this.AuditType.Name = "AuditType";
            this.AuditType.OptionsColumn.AllowEdit = false;
            // 
            // SortId
            // 
            this.SortId.Caption = "流程顺序号";
            this.SortId.FieldName = "SortId";
            this.SortId.Name = "SortId";
            this.SortId.OptionsColumn.AllowEdit = false;
            this.SortId.Visible = true;
            this.SortId.VisibleIndex = 2;
            this.SortId.Width = 131;
            // 
            // AuditNodeId
            // 
            this.AuditNodeId.Caption = "AuditNodeId";
            this.AuditNodeId.FieldName = "AuditNodeId";
            this.AuditNodeId.Name = "AuditNodeId";
            this.AuditNodeId.OptionsColumn.AllowEdit = false;
            // 
            // AuditCycle
            // 
            this.AuditCycle.Caption = "审批周期（天）";
            this.AuditCycle.FieldName = "AuditCycle";
            this.AuditCycle.Name = "AuditCycle";
            this.AuditCycle.OptionsColumn.AllowEdit = false;
            this.AuditCycle.Visible = true;
            this.AuditCycle.VisibleIndex = 5;
            this.AuditCycle.Width = 169;
            // 
            // ManagerUser
            // 
            this.ManagerUser.Caption = "管理员ID";
            this.ManagerUser.FieldName = "ManagerUserId";
            this.ManagerUser.Name = "ManagerUser";
            this.ManagerUser.OptionsColumn.AllowEdit = false;
            this.ManagerUser.Width = 87;
            // 
            // userName
            // 
            this.userName.Caption = "管理员";
            this.userName.FieldName = "userName";
            this.userName.Name = "userName";
            this.userName.OptionsColumn.AllowEdit = false;
            this.userName.Visible = true;
            this.userName.VisibleIndex = 6;
            this.userName.Width = 110;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置人员信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 52);
            // 
            // 配置人员信息ToolStripMenuItem
            // 
            this.配置人员信息ToolStripMenuItem.Name = "配置人员信息ToolStripMenuItem";
            this.配置人员信息ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.配置人员信息ToolStripMenuItem.Text = "配置审批人员";
            this.配置人员信息ToolStripMenuItem.Click += new System.EventHandler(this.配置人员信息ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControlAuditDefine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 591);
            this.panel1.TabIndex = 10;
            // 
            // FrmJFWAuditFlowSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBarBill1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmJFWAuditFlowSet";
            this.Text = "审批流程";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public FrmLookUp.ToolBarBill toolBarBill1;
        private DevExpress.XtraGrid.GridControl gridControlAuditDefine;
        private DevExpress.XtraGrid.Columns.GridColumn AutoFlowId;
        private DevExpress.XtraGrid.Columns.GridColumn FunctionId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditNodeName;
        private DevExpress.XtraGrid.Columns.GridColumn AuditTypeText;
        private DevExpress.XtraGrid.Columns.GridColumn FixedFlow;
        private DevExpress.XtraGrid.Columns.GridColumn AuditType;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SortId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditNodeId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditCycle;

        private DevExpress.XtraGrid.Columns.GridColumn ManagerUser;
        private DevExpress.XtraGrid.Columns.GridColumn userName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置人员信息ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;

    }
}