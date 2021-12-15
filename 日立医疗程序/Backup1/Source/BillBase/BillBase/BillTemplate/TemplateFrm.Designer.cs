namespace BillBase.BillTemplate
{
    partial class TemplateFrm
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
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BtnAuditListVisable = true;
            this.toolBarBill1.BtnAuditVisable = true;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnSelectVisable = true;
            this.toolBarBill1.BtnUnAuditVisable = true;
            this.toolBarBill1.BtnUnUpLoadVisable= true;
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.BtnUpLoadVisable = true;
            this.toolBarBill1.SelectTitleName = "";
            this.toolBarBill1.Size = new System.Drawing.Size(805, 28);
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 426);
            this.Name = "FrmTemplate";
            this.Text = "FrmTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}