namespace Bao.BillBase.Audit
{
    partial class FrmBillAuditFlowSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBillAuditFlowSet));
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnAuditGroup = new FrmLookUp.BaoButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.gridControlAuditDefine.Location = new System.Drawing.Point(271, 0);
            this.gridControlAuditDefine.MainView = this.gridView1;
            this.gridControlAuditDefine.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlAuditDefine.Name = "gridControlAuditDefine";
            this.gridControlAuditDefine.Size = new System.Drawing.Size(945, 591);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 30);
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 591);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Controls.Add(this.BtnAuditGroup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 591);
            this.panel2.TabIndex = 11;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 27);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(271, 564);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "审批组编号";
            this.gridColumn1.FieldName = "AuditGroupId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 147;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "审批组名称";
            this.gridColumn2.FieldName = "AuditGroupName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 88;
            // 
            // BtnAuditGroup
            // 
            this.BtnAuditGroup.BaoBtnCaption = "增加审批组";
            this.BtnAuditGroup.BaoClickClose = false;
            this.BtnAuditGroup.BaoDataAccDLLFullPath = "";
            this.BtnAuditGroup.BaoFullClassName = "";
            this.BtnAuditGroup.BaoSQL = "";
            this.BtnAuditGroup.BaoTitleNames = null;
            this.BtnAuditGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAuditGroup.Location = new System.Drawing.Point(0, 0);
            this.BtnAuditGroup.Name = "BtnAuditGroup";
            this.BtnAuditGroup.Size = new System.Drawing.Size(271, 27);
            this.BtnAuditGroup.TabIndex = 11;
            this.BtnAuditGroup.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.BtnAuditGroup_OnLookUpClosed);
            // 
            // FrmBillAuditFlowSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBarBill1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBillAuditFlowSet";
            this.Text = "审批流程";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Panel panel2;
        private FrmLookUp.BaoButton BtnAuditGroup;

    }
}