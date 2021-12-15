namespace Repair
{
    partial class RepairMessionChanageList
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RepairMissionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZoneName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepairPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReportRepartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RMTypeBegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RMTypeEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CommitPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CommitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BillDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShowAuditStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChanageRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已收回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已提交ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 98);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(691, 323);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RepairMissionCode,
            this.CustomerCode,
            this.CustomerName,
            this.ZoneName,
            this.MachineName,
            this.RepairPersonName,
            this.ReportRepartDate,
            this.RMTypeBegin,
            this.RMTypeEnd,
            this.CommitPer,
            this.CommitDate,
            this.AuditPer,
            this.AuditDate,
            this.BillDate,
            this.ShowAuditStatus,
            this.ChanageRemark,
            this.AuditRemark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // RepairMissionCode
            // 
            this.RepairMissionCode.Caption = "维修编号";
            this.RepairMissionCode.FieldName = "RepairMissionCode";
            this.RepairMissionCode.Name = "RepairMissionCode";
            this.RepairMissionCode.Visible = true;
            this.RepairMissionCode.VisibleIndex = 0;
            this.RepairMissionCode.Width = 91;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Caption = "客户编码";
            this.CustomerCode.FieldName = "CustomerCode";
            this.CustomerCode.Name = "CustomerCode";
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "客户名称";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 5;
            this.CustomerName.Width = 135;
            // 
            // ZoneName
            // 
            this.ZoneName.Caption = "省份";
            this.ZoneName.FieldName = "ZoneName";
            this.ZoneName.Name = "ZoneName";
            this.ZoneName.Visible = true;
            this.ZoneName.VisibleIndex = 4;
            // 
            // MachineName
            // 
            this.MachineName.Caption = "主机型号";
            this.MachineName.FieldName = "MachineModel";
            this.MachineName.Name = "MachineName";
            this.MachineName.Visible = true;
            this.MachineName.VisibleIndex = 6;
            this.MachineName.Width = 119;
            // 
            // RepairPersonName
            // 
            this.RepairPersonName.Caption = "工程师";
            this.RepairPersonName.FieldName = "RepairPersonName";
            this.RepairPersonName.Name = "RepairPersonName";
            this.RepairPersonName.Visible = true;
            this.RepairPersonName.VisibleIndex = 7;
            // 
            // ReportRepartDate
            // 
            this.ReportRepartDate.Caption = "报修日期";
            this.ReportRepartDate.FieldName = "ReportRepartDate";
            this.ReportRepartDate.Name = "ReportRepartDate";
            this.ReportRepartDate.Visible = true;
            this.ReportRepartDate.VisibleIndex = 10;
            // 
            // RMTypeBegin
            // 
            this.RMTypeBegin.Caption = "维修类别前";
            this.RMTypeBegin.FieldName = "RMTypeBegin";
            this.RMTypeBegin.Name = "RMTypeBegin";
            this.RMTypeBegin.Visible = true;
            this.RMTypeBegin.VisibleIndex = 2;
            // 
            // RMTypeEnd
            // 
            this.RMTypeEnd.Caption = "维修性质后";
            this.RMTypeEnd.FieldName = "RMTypeEnd";
            this.RMTypeEnd.Name = "RMTypeEnd";
            this.RMTypeEnd.Visible = true;
            this.RMTypeEnd.VisibleIndex = 3;
            // 
            // CommitPer
            // 
            this.CommitPer.Caption = "提交人";
            this.CommitPer.FieldName = "CommitPer";
            this.CommitPer.Name = "CommitPer";
            this.CommitPer.Visible = true;
            this.CommitPer.VisibleIndex = 8;
            // 
            // CommitDate
            // 
            this.CommitDate.Caption = "提交日期";
            this.CommitDate.FieldName = "CommitDate";
            this.CommitDate.Name = "CommitDate";
            this.CommitDate.Visible = true;
            this.CommitDate.VisibleIndex = 11;
            // 
            // AuditPer
            // 
            this.AuditPer.Caption = "审核人";
            this.AuditPer.FieldName = "AuditPer";
            this.AuditPer.Name = "AuditPer";
            this.AuditPer.Visible = true;
            this.AuditPer.VisibleIndex = 9;
            // 
            // AuditDate
            // 
            this.AuditDate.Caption = "审核日期";
            this.AuditDate.FieldName = "AuditDate";
            this.AuditDate.Name = "AuditDate";
            this.AuditDate.Visible = true;
            this.AuditDate.VisibleIndex = 12;
            // 
            // BillDate
            // 
            this.BillDate.Caption = "单据日期";
            this.BillDate.FieldName = "BillDate";
            this.BillDate.Name = "BillDate";
            this.BillDate.Visible = true;
            this.BillDate.VisibleIndex = 13;
            // 
            // ShowAuditStatus
            // 
            this.ShowAuditStatus.Caption = "审核状态";
            this.ShowAuditStatus.FieldName = "ShowAuditStatus";
            this.ShowAuditStatus.Name = "ShowAuditStatus";
            this.ShowAuditStatus.Visible = true;
            this.ShowAuditStatus.VisibleIndex = 1;
            // 
            // ChanageRemark
            // 
            this.ChanageRemark.Caption = "变更原因";
            this.ChanageRemark.FieldName = "ChanageRemark";
            this.ChanageRemark.Name = "ChanageRemark";
            this.ChanageRemark.Visible = true;
            this.ChanageRemark.VisibleIndex = 14;
            // 
            // AuditRemark
            // 
            this.AuditRemark.Caption = "审核意见";
            this.AuditRemark.FieldName = "AuditRemark";
            this.AuditRemark.Name = "AuditRemark";
            this.AuditRemark.Visible = true;
            this.AuditRemark.VisibleIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.状态ToolStripMenuItem,
            this.导出EXCELToolStripMenuItem,
            this.BtnExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Visible = false;
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 状态ToolStripMenuItem
            // 
            this.状态ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部ToolStripMenuItem,
            this.已收回ToolStripMenuItem,
            this.已提交ToolStripMenuItem,
            this.已审核ToolStripMenuItem});
            this.状态ToolStripMenuItem.Name = "状态ToolStripMenuItem";
            this.状态ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.状态ToolStripMenuItem.Text = "单据状态";
            this.状态ToolStripMenuItem.Visible = false;
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.全部ToolStripMenuItem.Text = "全部";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // 已收回ToolStripMenuItem
            // 
            this.已收回ToolStripMenuItem.Name = "已收回ToolStripMenuItem";
            this.已收回ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.已收回ToolStripMenuItem.Text = "已收回";
            this.已收回ToolStripMenuItem.Click += new System.EventHandler(this.已收回ToolStripMenuItem_Click);
            // 
            // 已提交ToolStripMenuItem
            // 
            this.已提交ToolStripMenuItem.Name = "已提交ToolStripMenuItem";
            this.已提交ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.已提交ToolStripMenuItem.Text = "已提交";
            this.已提交ToolStripMenuItem.Click += new System.EventHandler(this.已提交ToolStripMenuItem_Click);
            // 
            // 已审核ToolStripMenuItem
            // 
            this.已审核ToolStripMenuItem.Name = "已审核ToolStripMenuItem";
            this.已审核ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.已审核ToolStripMenuItem.Text = "已审核";
            this.已审核ToolStripMenuItem.Click += new System.EventHandler(this.已审核ToolStripMenuItem_Click);
            // 
            // 导出EXCELToolStripMenuItem
            // 
            this.导出EXCELToolStripMenuItem.Name = "导出EXCELToolStripMenuItem";
            this.导出EXCELToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.导出EXCELToolStripMenuItem.Text = "导出EXCEL";
            this.导出EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出EXCELToolStripMenuItem_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(33, 17);
            this.BtnExit.Text = "退出";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker4);
            this.panel1.Controls.Add(this.dateTimePicker3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 74);
            this.panel1.TabIndex = 4;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(226, 43);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker4.TabIndex = 9;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(78, 43);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "审核日期:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "已收回",
            "已提交",
            "已审核",
            "全部"});
            this.cmbStatus.Location = new System.Drawing.Point(399, 7);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(226, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "状态:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "报修日期:";
            // 
            // RepairMessionChanageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 421);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "RepairMessionChanageList";
            this.Text = "RepairMessionChanageList";
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn RepairMissionCode;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn ZoneName;
        private DevExpress.XtraGrid.Columns.GridColumn MachineName;
        private DevExpress.XtraGrid.Columns.GridColumn RMTypeBegin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BtnExit;
        private DevExpress.XtraGrid.Columns.GridColumn RepairPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn ReportRepartDate;
        private DevExpress.XtraGrid.Columns.GridColumn RMTypeEnd;
        private DevExpress.XtraGrid.Columns.GridColumn CommitPer;
        private DevExpress.XtraGrid.Columns.GridColumn CommitDate;
        private DevExpress.XtraGrid.Columns.GridColumn AuditPer;
        private DevExpress.XtraGrid.Columns.GridColumn AuditDate;
        private DevExpress.XtraGrid.Columns.GridColumn BillDate;
        private System.Windows.Forms.ToolStripMenuItem 状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已提交ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已审核ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn ShowAuditStatus;
        private System.Windows.Forms.ToolStripMenuItem 已收回ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn ChanageRemark;
        private DevExpress.XtraGrid.Columns.GridColumn AuditRemark;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}