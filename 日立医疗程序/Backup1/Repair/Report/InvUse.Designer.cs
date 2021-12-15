namespace Repair.Report
{
    partial class InvUse
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
            this.rptControl1 = new Bao.Report.RptControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rptControl1
            // 
            this.rptControl1.AutoScroll = true;
            this.rptControl1.BaoFilterForm = null;
            this.rptControl1.BaoGridViewSource = null;
            this.rptControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rptControl1.Fr3path = null;
            this.rptControl1.FullClassName = null;
            this.rptControl1.FullDLLName = null;
            this.rptControl1.Location = new System.Drawing.Point(0, 0);
            this.rptControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rptControl1.Name = "rptControl1";
            this.rptControl1.Size = new System.Drawing.Size(943, 18);
            this.rptControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 18);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(943, 408);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn17,
            this.gridColumn26,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn18,
            this.gridColumn31,
            this.gridColumn14,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn19,
            this.gridColumn21,
            this.gridColumn20,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "大区";
            this.gridColumn13.FieldName = "大区";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 52;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "省份";
            this.gridColumn15.FieldName = "ZoneName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 77;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "配件申请单号";
            this.gridColumn16.FieldName = "PartsApplicationCode";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 101;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "配件名称";
            this.gridColumn1.FieldName = "InventoryEngName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 108;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "配件型号";
            this.gridColumn2.FieldName = "InventoryStd";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            this.gridColumn2.Width = 74;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "主机型号";
            this.gridColumn3.FieldName = "MachineModel";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 101;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "维修编号";
            this.gridColumn4.FieldName = "RepairMissionCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 111;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "维修性质";
            this.gridColumn17.FieldName = "RepairTypeNew";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            this.gridColumn17.Width = 96;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "报修日期";
            this.gridColumn26.FieldName = "ReportRepartDate";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 6;
            this.gridColumn26.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "客户";
            this.gridColumn5.FieldName = "CustomerName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 192;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "申请数量";
            this.gridColumn6.FieldName = "iquantity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 21;
            this.gridColumn6.Width = 92;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "申请日期";
            this.gridColumn7.FieldName = "ApplicationDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 14;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "出库仓库";
            this.gridColumn18.FieldName = "出库仓库";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 93;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "配件等待时间";
            this.gridColumn14.FieldName = "配件等待时间";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 116;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "出货日期";
            this.gridColumn8.FieldName = "出货日期";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 72;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "出库数量";
            this.gridColumn9.FieldName = "出库数量";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 22;
            this.gridColumn9.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "归还现品不良品数量";
            this.gridColumn10.FieldName = "归还现品不良品数量";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 24;
            this.gridColumn10.Width = 132;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "归还未使用数量";
            this.gridColumn11.FieldName = "归还未使用数量";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 25;
            this.gridColumn11.Width = 104;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "归还不良品数量";
            this.gridColumn12.FieldName = "归还不良品数量";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 26;
            this.gridColumn12.Width = 106;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "购买日期";
            this.gridColumn19.FieldName = "PurchaseDate";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 7;
            this.gridColumn19.Width = 91;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "制造编号";
            this.gridColumn21.FieldName = "ManufactureCode";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 8;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "状态";
            this.gridColumn20.FieldName = "Status";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 19;
            this.gridColumn20.Width = 86;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "归还日期";
            this.gridColumn22.FieldName = "ReturnDate";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 18;
            this.gridColumn22.Width = 103;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "开票状态";
            this.gridColumn23.FieldName = "BillState";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 20;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "借出日期";
            this.gridColumn24.FieldName = "ShippingTime";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 17;
            this.gridColumn24.Width = 100;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "出库明细";
            this.gridColumn25.FieldName = "出库明细";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 23;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "GC出库日期";
            this.gridColumn27.FieldName = "dtimegc";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 11;
            this.gridColumn27.Width = 98;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "配件申请人";
            this.gridColumn28.FieldName = "ApplicationPersonName";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 16;
            this.gridColumn28.Width = 103;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "本部发货日期";
            this.gridColumn29.FieldName = "dtimeFH";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 12;
            this.gridColumn29.Width = 112;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "本部保修期限";
            this.gridColumn30.FieldName = "dtimeFHBX";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 13;
            this.gridColumn30.Width = 119;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "配件借用备注";
            this.gridColumn31.FieldName = "Remarks";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 15;
            this.gridColumn31.Width = 120;
            // 
            // InvUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 426);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.rptControl1);
            this.Name = "InvUse";
            this.Text = "备件使用情况";
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bao.Report.RptControl rptControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
    }
}