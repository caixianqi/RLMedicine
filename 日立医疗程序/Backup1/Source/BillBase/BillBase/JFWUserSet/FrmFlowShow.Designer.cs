namespace Bao.BillBase.Audit.JFWUserSet
{
    partial class FrmFlowShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnAddUser = new FrmLookUp.BaoButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
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
            this.gridControlAuditDefine.Size = new System.Drawing.Size(1215, 340);
            this.gridControlAuditDefine.TabIndex = 10;
            this.gridControlAuditDefine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlAuditDefine.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlAuditDefine_MouseDoubleClick);
            this.gridControlAuditDefine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControlAuditDefine_MouseClick);
            this.gridControlAuditDefine.Click += new System.EventHandler(this.gridControlAuditDefine_Click);
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // AutoFlowId
            // 
            this.AutoFlowId.Caption = "单据审批流编码";
            this.AutoFlowId.FieldName = "AutoFlowId";
            this.AutoFlowId.Name = "AutoFlowId";
            this.AutoFlowId.OptionsColumn.AllowEdit = false;
            this.AutoFlowId.Visible = true;
            this.AutoFlowId.VisibleIndex = 0;
            this.AutoFlowId.Width = 101;
            // 
            // FunctionId
            // 
            this.FunctionId.Caption = "功能编号";
            this.FunctionId.FieldName = "FunctionId";
            this.FunctionId.Name = "FunctionId";
            this.FunctionId.OptionsColumn.AllowEdit = false;
            this.FunctionId.Visible = true;
            this.FunctionId.VisibleIndex = 1;
            this.FunctionId.Width = 124;
            // 
            // AuditNodeName
            // 
            this.AuditNodeName.Caption = "审批结点";
            this.AuditNodeName.FieldName = "AuditNode";
            this.AuditNodeName.Name = "AuditNodeName";
            this.AuditNodeName.OptionsColumn.AllowEdit = false;
            this.AuditNodeName.Visible = true;
            this.AuditNodeName.VisibleIndex = 3;
            this.AuditNodeName.Width = 136;
            // 
            // AuditTypeText
            // 
            this.AuditTypeText.Caption = "人员/角色";
            this.AuditTypeText.FieldName = "AuditTypeText";
            this.AuditTypeText.Name = "AuditTypeText";
            this.AuditTypeText.OptionsColumn.AllowEdit = false;
            this.AuditTypeText.Visible = true;
            this.AuditTypeText.VisibleIndex = 4;
            this.AuditTypeText.Width = 170;
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
            this.SortId.Width = 98;
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
            this.AuditCycle.Width = 123;
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
            this.userName.Width = 139;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 340);
            this.gridControl1.MainView = this.gridView3;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1215, 249);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 30);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // gridView3
            // 
            this.gridView3.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView3.Appearance.Row.Options.UseTextOptions = true;
            this.gridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "审核人员编码";
            this.gridColumn1.FieldName = "AuditUserId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 101;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "审核人员名称";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 124;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "审核顺序";
            this.gridColumn3.FieldName = "OrderId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 136;
            // 
            // BtnAddUser
            // 
            this.BtnAddUser.BaoBtnCaption = "增加审核人员";
            this.BtnAddUser.BaoClickClose = false;
            this.BtnAddUser.BaoDataAccDLLFullPath = "";
            this.BtnAddUser.BaoFullClassName = "";
            this.BtnAddUser.BaoSQL = "";
            this.BtnAddUser.BaoTitleNames = null;
            this.BtnAddUser.Location = new System.Drawing.Point(203, 346);
            this.BtnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAddUser.Name = "BtnAddUser";
            this.BtnAddUser.Size = new System.Drawing.Size(132, 28);
            this.BtnAddUser.TabIndex = 44;
            this.BtnAddUser.Tag = "99999";
            this.BtnAddUser.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.BtnAddUser_OnLookUpClosed);
            // 
            // FrmFlowShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 589);
            this.Controls.Add(this.BtnAddUser);
            this.Controls.Add(this.gridControlAuditDefine);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmFlowShow";
            this.Text = "审批流程";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAuditDefine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAuditDefine;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AutoFlowId;
        private DevExpress.XtraGrid.Columns.GridColumn FunctionId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditNodeName;
        private DevExpress.XtraGrid.Columns.GridColumn AuditTypeText;
        private DevExpress.XtraGrid.Columns.GridColumn FixedFlow;
        private DevExpress.XtraGrid.Columns.GridColumn AuditType;
        private DevExpress.XtraGrid.Columns.GridColumn SortId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditNodeId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditCycle;
        private DevExpress.XtraGrid.Columns.GridColumn ManagerUser;
        private DevExpress.XtraGrid.Columns.GridColumn userName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private FrmLookUp.BaoButton BtnAddUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;


    }
}