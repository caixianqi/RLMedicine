namespace Bao.BillBase
{
    partial class Frmbasis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmbasis));
            this.toolBarBill1 = new FrmLookUp.ToolBarBill();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolBarBill1.BtnAuditListVisable = false;
            this.toolBarBill1.BtnAuditVisable = false;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnExcelVisable = true;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnPrintVisable = false;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnSelectVisable = false;
            this.toolBarBill1.BtnUnAuditVisable = false;
           // this.toolBarBill1.BtnUpCancelVisable = false;
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.BtnUpLoadVisable = false;
            this.toolBarBill1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarBill1.GridViewSource = null;
            this.toolBarBill1.Location = new System.Drawing.Point(0, 0);
            this.toolBarBill1.Name = "toolBarBill1";
            this.toolBarBill1.SelectClassName = "";
            this.toolBarBill1.SelectDllPath = "";
            this.toolBarBill1.SelectSQL = "";
            this.toolBarBill1.SelectTitleName = null;
            this.toolBarBill1.Size = new System.Drawing.Size(804, 28);
            this.toolBarBill1.TabIndex = 4;
            this.toolBarBill1.OnBaoNew += new FrmLookUp.ToolBarBill.BaoNew(this.toolBarBill1_OnBaoNew);
            this.toolBarBill1.OnBaoSetPrintDataset += new FrmLookUp.ToolBarBill.BaoSetPrintDataset(this.toolBarBill1_OnBaoSetPrintDataset);
            this.toolBarBill1.OnBaoExit += new FrmLookUp.ToolBarBill.BaoExit(this.toolBarBill1_OnBaoExit);
            this.toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(this.toolBarBill1_OnBaoDelete);
            this.toolBarBill1.OnBaoSave += new FrmLookUp.ToolBarBill.BaoSave(this.toolBarBill1_OnBaoSave);
            this.toolBarBill1.OnBaoUpdate += new FrmLookUp.ToolBarBill.BaoUpdate(this.toolBarBill1_OnBaoUpdate);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(804, 458);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // Frmbasis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 486);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolBarBill1);
            this.Name = "Frmbasis";
            this.Text = "Frmbasis";
            this.Load += new System.EventHandler(this.Frmbasis_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frmbasis_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public FrmLookUp.ToolBarBill toolBarBill1;
    }
}