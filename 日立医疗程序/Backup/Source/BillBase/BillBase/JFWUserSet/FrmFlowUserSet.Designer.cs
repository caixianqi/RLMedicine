namespace Bao.BillBase.Audit.JFWUserSet
{
    partial class FrmFlowUserSet
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFlowUserSet));
            this.gridControlAllUser = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.autoFlowId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SortId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditTypeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolBarBill1 = new FrmLookUp.ToolBarBill();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAllUser
            // 
            this.gridControlAllUser.EmbeddedNavigator.Name = "";
            gridLevelNode2.RelationName = "Level1";
            this.gridControlAllUser.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlAllUser.Location = new System.Drawing.Point(0, 151);
            this.gridControlAllUser.MainView = this.gridView1;
            this.gridControlAllUser.Name = "gridControlAllUser";
            this.gridControlAllUser.Size = new System.Drawing.Size(891, 244);
            this.gridControlAllUser.TabIndex = 2;
            this.gridControlAllUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.autoFlowId,
            this.AuditNodeName,
            this.SortId,
            this.UserName,
            this.OrderId,
            this.AuditUserId,
            this.AuditTypeText,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControlAllUser;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // autoFlowId
            // 
            this.autoFlowId.AppearanceCell.Options.UseTextOptions = true;
            this.autoFlowId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.autoFlowId.Caption = "审批流编码";
            this.autoFlowId.FieldName = "AutoFlowId";
            this.autoFlowId.Name = "autoFlowId";
            this.autoFlowId.OptionsColumn.AllowEdit = false;
            this.autoFlowId.OptionsColumn.ReadOnly = true;
            this.autoFlowId.Width = 115;
            // 
            // AuditNodeName
            // 
            this.AuditNodeName.Caption = "审批节点";
            this.AuditNodeName.FieldName = "AuditNode";
            this.AuditNodeName.Name = "AuditNodeName";
            this.AuditNodeName.OptionsColumn.AllowEdit = false;
            this.AuditNodeName.Visible = true;
            this.AuditNodeName.VisibleIndex = 0;
            this.AuditNodeName.Width = 148;
            // 
            // SortId
            // 
            this.SortId.AppearanceCell.Options.UseTextOptions = true;
            this.SortId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SortId.Caption = "审核顺序";
            this.SortId.FieldName = "SortId";
            this.SortId.Name = "SortId";
            this.SortId.OptionsColumn.AllowEdit = false;
            this.SortId.Visible = true;
            this.SortId.VisibleIndex = 1;
            this.SortId.Width = 101;
            // 
            // UserName
            // 
            this.UserName.Caption = "人员审批/角色审批";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.AllowEdit = false;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 3;
            this.UserName.Width = 276;
            // 
            // OrderId
            // 
            this.OrderId.AppearanceCell.Options.UseTextOptions = true;
            this.OrderId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.OrderId.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.OrderId.Caption = "同级审批节点的人员审核顺序号";
            this.OrderId.FieldName = "OrderId";
            this.OrderId.Name = "OrderId";
            this.OrderId.OptionsColumn.AllowEdit = false;
            this.OrderId.OptionsColumn.ReadOnly = true;
            this.OrderId.Visible = true;
            this.OrderId.VisibleIndex = 2;
            this.OrderId.Width = 272;
            // 
            // AuditUserId
            // 
            this.AuditUserId.Caption = "审批人员ID";
            this.AuditUserId.FieldName = "AuditUserId";
            this.AuditUserId.Name = "AuditUserId";
            this.AuditUserId.OptionsColumn.AllowEdit = false;
            this.AuditUserId.OptionsColumn.ReadOnly = true;
            this.AuditUserId.Width = 155;
            // 
            // AuditTypeText
            // 
            this.AuditTypeText.Caption = "审批类型";
            this.AuditTypeText.FieldName = "AuditTypeText";
            this.AuditTypeText.Name = "AuditTypeText";
            this.AuditTypeText.OptionsColumn.AllowEdit = false;
            this.AuditTypeText.Visible = true;
            this.AuditTypeText.VisibleIndex = 4;
            this.AuditTypeText.Width = 105;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AuditNodeId";
            this.gridColumn1.FieldName = "AuditNodeId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "AuditNode";
            this.gridColumn2.FieldName = "AuditNode";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolBarBill1.BtnAuditVisable = false;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnExcelVisable = false;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnPrintVisable = false;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnSelectVisable = false;
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarBill1.GridViewSource = null;
            this.toolBarBill1.Location = new System.Drawing.Point(0, 0);
            this.toolBarBill1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolBarBill1.Name = "toolBarBill1";
            this.toolBarBill1.SelectClassName = "";
            this.toolBarBill1.SelectDllPath = "";
            this.toolBarBill1.SelectSQL = "";
            this.toolBarBill1.SelectTitleName = null;
            this.toolBarBill1.Size = new System.Drawing.Size(891, 22);
            this.toolBarBill1.TabIndex = 1;
            // 
            // FrmFlowUserSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 395);
            this.Controls.Add(this.gridControlAllUser);
            this.Controls.Add(this.toolBarBill1);
            this.Name = "FrmFlowUserSet";
            this.Text = "提交流程人员设置";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAllUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn autoFlowId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditNodeName;
        private DevExpress.XtraGrid.Columns.GridColumn SortId;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn OrderId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditUserId;
        private DevExpress.XtraGrid.Columns.GridColumn AuditTypeText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private FrmLookUp.ToolBarBill toolBarBill1;
    }
}