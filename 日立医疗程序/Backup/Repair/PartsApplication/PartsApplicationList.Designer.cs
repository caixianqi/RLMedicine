namespace Repair
{
    partial class PartsApplicationList
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(729, 429);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RepairMissionCode,
            this.gridColumn1,
            this.CustomerName,
            this.MachineName,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // RepairMissionCode
            // 
            this.RepairMissionCode.Caption = "维修编号";
            this.RepairMissionCode.FieldName = "RepairMissionCode";
            this.RepairMissionCode.Name = "RepairMissionCode";
            this.RepairMissionCode.Visible = true;
            this.RepairMissionCode.VisibleIndex = 0;
            this.RepairMissionCode.Width = 71;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "配件申请单号";
            this.gridColumn1.FieldName = "PartsApplicationCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 121;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "客户";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 4;
            this.CustomerName.Width = 176;
            // 
            // MachineName
            // 
            this.MachineName.Caption = "申请人";
            this.MachineName.FieldName = "ApplicationPersonName";
            this.MachineName.Name = "MachineName";
            this.MachineName.Visible = true;
            this.MachineName.VisibleIndex = 6;
            this.MachineName.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "主机型号";
            this.gridColumn3.FieldName = "MachineName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 76;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "大区";
            this.gridColumn4.FieldName = "CustomerDepartmentName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 68;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "区域";
            this.gridColumn5.FieldName = "ZoneName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 64;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "配件申请时间";
            this.gridColumn7.FieldName = "ApplicationDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 99;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "申请状态";
            this.gridColumn9.FieldName = "申请状态";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 86;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "出库时间";
            this.gridColumn6.FieldName = "StateInOutDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 10;
            this.gridColumn6.Width = 89;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "出库状态";
            this.gridColumn10.FieldName = "StateInOut";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 77;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "归还时间";
            this.gridColumn8.FieldName = "StateReturnDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 12;
            this.gridColumn8.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "归还状态";
            this.gridColumn11.FieldName = "StateReturn";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            this.gridColumn11.Width = 78;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.导出EXCELToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 导出EXCELToolStripMenuItem
            // 
            this.导出EXCELToolStripMenuItem.Name = "导出EXCELToolStripMenuItem";
            this.导出EXCELToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.导出EXCELToolStripMenuItem.Text = "导出EXCEL";
            this.导出EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出EXCELToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "保内/保外";
            this.gridColumn2.FieldName = "RepairType";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // PartsApplicationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 454);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PartsApplicationList";
            this.Text = "配件申请单列表";
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn RepairMissionCode;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn MachineName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.ToolStripMenuItem 导出EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}