namespace Bao.BillBase
{
    partial class FrmBillBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBillBase));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolBarBill1 = new FrmLookUp.ToolBarBill();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolBarBill1.BtnAuditListVisable = true;
            this.toolBarBill1.BtnAuditVisable = true;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnExcelVisable = false;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnPrintVisable = false;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnSelectVisable = true;
            this.toolBarBill1.BtnUnAuditVisable = true;
            
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.BtnUpLoadVisable = true;
            this.toolBarBill1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarBill1.GridViewSource = null;
            this.toolBarBill1.Location = new System.Drawing.Point(0, 0);
            this.toolBarBill1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolBarBill1.Name = "toolBarBill1";
            this.toolBarBill1.SelectClassName = "";
            this.toolBarBill1.SelectDllPath = "";
            this.toolBarBill1.SelectSQL = "";
            this.toolBarBill1.SelectTitleName = null;
            this.toolBarBill1.Size = new System.Drawing.Size(944, 28);
            this.toolBarBill1.TabIndex = 1;
            this.toolBarBill1.OnBaoNew += new FrmLookUp.ToolBarBill.BaoNew(this.toolBarBill1_OnBaoNew);
            this.toolBarBill1.OnBaoSelect += new FrmLookUp.ToolBarBill.BaoSelect(this.toolBarBill1_OnBaoSelect);
            this.toolBarBill1.OnBeforBaoUpdate += new FrmLookUp.ToolBarBill.BeforBaoUpdate(this.toolBarBill1_OnBeforBaoUpdate);
            this.toolBarBill1.OnBaoAuditList += new FrmLookUp.ToolBarBill.BaoAuditList(this.toolBarBill1_OnBaoAuditList);
            this.toolBarBill1.OnBaoUnAudit += new FrmLookUp.ToolBarBill.BaoUnAudit(this.toolBarBill1_OnBaoUnAudit);
            this.toolBarBill1.OnBaoSetPrintDataset += new FrmLookUp.ToolBarBill.BaoSetPrintDataset(this.toolBarBill1_OnBaoSetPrintDataset);
            this.toolBarBill1.OnBaoUpCancel += new FrmLookUp.ToolBarBill.BaoUpCancel(this.toolBarBill1_OnBaoUpCancel);
            this.toolBarBill1.OnBaoUpLoad += new FrmLookUp.ToolBarBill.BaoUpLoad(this.toolBarBill1_OnBaoUpLoad);
            this.toolBarBill1.OnBaoExit += new FrmLookUp.ToolBarBill.BaoExit(this.toolBarBill1_OnBaoExit);
            this.toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(this.toolBarBill1_OnBaoDelete);
            this.toolBarBill1.OnBaoSave += new FrmLookUp.ToolBarBill.BaoSave(this.toolBarBill1_OnBaoSave);
            this.toolBarBill1.OnBaoAudit += new FrmLookUp.ToolBarBill.BaoAudit(this.toolBarBill1_OnBaoAudit);
            this.toolBarBill1.OnBaoUpdate += new FrmLookUp.ToolBarBill.BaoUpdate(this.toolBarBill1_OnBaoUpdate);
          
            // 
            // FrmBillBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 570);
            this.Controls.Add(this.toolBarBill1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBillBase";
            this.Text = "FrmBillBase";
            this.Load += new System.EventHandler(this.FrmBillBase_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBillBase_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FrmLookUp.ToolBarBill toolBarBill1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}