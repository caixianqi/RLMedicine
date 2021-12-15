namespace Repair
{
    partial class PartsInentoryNewList
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPartApp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnParts = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RepairMissionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.guaranteeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.appStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepairtypeNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StateInOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StateInOutDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.appQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.outQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.returnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.导出EXCELToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Visible = false;
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 导出EXCELToolStripMenuItem
            // 
            this.导出EXCELToolStripMenuItem.Name = "导出EXCELToolStripMenuItem";
            this.导出EXCELToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.导出EXCELToolStripMenuItem.Text = "导出EXCEL";
            this.导出EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出EXCELToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(604, 296);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPartApp,
            this.btnParts});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // btnPartApp
            // 
            this.btnPartApp.Name = "btnPartApp";
            this.btnPartApp.Size = new System.Drawing.Size(142, 22);
            this.btnPartApp.Text = "配件申请单";
            this.btnPartApp.Click += new System.EventHandler(this.btnPartApp_Click);
            // 
            // btnParts
            // 
            this.btnParts.Name = "btnParts";
            this.btnParts.Size = new System.Drawing.Size(142, 22);
            this.btnParts.Text = "配件出入库单";
            this.btnParts.Click += new System.EventHandler(this.btnParts_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RepairMissionCode,
            this.guaranteeNo,
            this.appStatus,
            this.RepairtypeNew,
            this.CustomerName,
            this.gridColumn3,
            this.MachineName,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.StateInOut,
            this.StateInOutDate,
            this.gridColumn11,
            this.gridColumn8,
            this.appQty,
            this.outQty,
            this.returnQty});
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
            this.RepairMissionCode.Width = 99;
            // 
            // appStatus
            // 
            this.appStatus.Caption = "状态";
            this.appStatus.FieldName = "appStatus";
            this.appStatus.Name = "appStatus";
            this.appStatus.Visible = true;
            this.appStatus.VisibleIndex = 2;
            this.appStatus.Width = 86;
            // 
            // RepairtypeNew
            // 
            this.RepairtypeNew.Caption = "维修类别";
            this.RepairtypeNew.FieldName = "RepairtypeNew";
            this.RepairtypeNew.Name = "RepairtypeNew";
            this.RepairtypeNew.Visible = true;
            this.RepairtypeNew.VisibleIndex = 3;
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
            // gridColumn3
            // 
            this.gridColumn3.Caption = "主机型号";
            this.gridColumn3.FieldName = "MachineModel";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 138;
            // 
            // MachineName
            // 
            this.MachineName.Caption = "申请人";
            this.MachineName.FieldName = "ApplicationPersonName";
            this.MachineName.Name = "MachineName";
            this.MachineName.Visible = true;
            this.MachineName.VisibleIndex = 7;
            this.MachineName.Width = 80;
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "报修日期";
            this.gridColumn2.FieldName = "ReportRepartDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 90;
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
            // StateInOut
            // 
            this.StateInOut.Caption = "借用状态";
            this.StateInOut.FieldName = "StateInOut";
            this.StateInOut.Name = "StateInOut";
            this.StateInOut.Width = 77;
            // 
            // StateInOutDate
            // 
            this.StateInOutDate.Caption = "借出时间";
            this.StateInOutDate.FieldName = "StateInOutDate";
            this.StateInOutDate.Name = "StateInOutDate";
            this.StateInOutDate.Visible = true;
            this.StateInOutDate.VisibleIndex = 10;
            this.StateInOutDate.Width = 89;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "归还状态";
            this.gridColumn11.FieldName = "StateReturn";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 78;
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
            // appQty
            // 
            this.appQty.Caption = "申请个数";
            this.appQty.FieldName = "AppQty";
            this.appQty.Name = "appQty";
            this.appQty.Visible = true;
            this.appQty.VisibleIndex = 9;
            // 
            // outQty
            // 
            this.outQty.Caption = "借出个数";
            this.outQty.FieldName = "OutQty";
            this.outQty.Name = "outQty";
            this.outQty.Visible = true;
            this.outQty.VisibleIndex = 11;
            // 
            // returnQty
            // 
            this.returnQty.Caption = "归还个数";
            this.returnQty.FieldName = "ReQty";
            this.returnQty.Name = "returnQty";
            this.returnQty.Visible = true;
            this.returnQty.VisibleIndex = 13;
            // 
            // guaranteeNo
            // 
            this.guaranteeNo.Caption = "保修编号";
            this.guaranteeNo.FieldName = "guaranteeNo";
            this.guaranteeNo.Name = "guaranteeNo";
            this.guaranteeNo.Visible = true;
            this.guaranteeNo.VisibleIndex = 14;
            this.guaranteeNo.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 40);
            this.panel1.TabIndex = 10;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "出库中",
            "出库完成",
            "归还中",
            "归还完成",
            "配件申请",
            "审核通过",
            "全部"});
            this.cmbStatus.Location = new System.Drawing.Point(432, 12);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "状态:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(249, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "配件申请日期:";
            // 
            // PartsInentoryNewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 360);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PartsInentoryNewList";
            this.Text = "备件使用情况列表";
            this.Load += new System.EventHandler(this.PartsInentoryNewList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn RepairMissionCode;
        private DevExpress.XtraGrid.Columns.GridColumn guaranteeNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn MachineName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn RepairtypeNew;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn appStatus;
        private DevExpress.XtraGrid.Columns.GridColumn StateInOutDate;
        private DevExpress.XtraGrid.Columns.GridColumn StateInOut;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn appQty;
        private DevExpress.XtraGrid.Columns.GridColumn outQty;
        private DevExpress.XtraGrid.Columns.GridColumn returnQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnPartApp;
        private System.Windows.Forms.ToolStripMenuItem btnParts;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}