namespace Repair
{
    partial class FreeApplication
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
            this.RepairMissionCode = new FrmLookUp.RiliButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerCode = new FrmLookUp.ButtonEdit();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RepairMissionID = new System.Windows.Forms.TextBox();
            this.AppReson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AuditerCode = new FrmLookUp.RiliButtonEdit();
            this.AuditerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarBill1
            // 
            this.toolBarBill1.BtnAddLineVisable = true;
            this.toolBarBill1.BtnAuditVisable = true;
            this.toolBarBill1.BtnCancelVisable = true;
            this.toolBarBill1.BtnDeleteVisable = true;
            this.toolBarBill1.BtnDelLineVisable = true;
            this.toolBarBill1.BtnNewVisable = true;
            this.toolBarBill1.BtnRefreshVisable = true;
            this.toolBarBill1.BtnSaveVisable = true;
            this.toolBarBill1.BtnUnAuditVisable = true;
            this.toolBarBill1.BtnUnUpLoadVisable = true;
            this.toolBarBill1.BtnUpdateVisable = true;
            this.toolBarBill1.BtnUpLoadVisable = true;
            this.toolBarBill1.SelectTitleName = "";
            this.toolBarBill1.tssAddRowVisable = true;
            this.toolBarBill1.tssAuditVisable = true;
            this.toolBarBill1.tssPrintVisable = true;
            this.toolBarBill1.tssRefreshVisable = true;
            // 
            // RepairMissionCode
            // 
            this.RepairMissionCode.BaoBtnCaption = "";
            this.RepairMissionCode.BaoClickClose = true;
            this.RepairMissionCode.BaoColumnsWidth = null;
            this.RepairMissionCode.BaoDataAccDLLFullPath = "";
            this.RepairMissionCode.BaoFullClassName = "";
            this.RepairMissionCode.BaoSQL = "";
            this.RepairMissionCode.BaoTitleNames = null;
            this.RepairMissionCode.CodeValue = null;
            this.RepairMissionCode.DecideSql = "";
            this.RepairMissionCode.FrmHigth = 0;
            this.RepairMissionCode.FrmTitle = null;
            this.RepairMissionCode.FrmWidth = 0;
            this.RepairMissionCode.IsShowInTaskBar = false;
            this.RepairMissionCode.Location = new System.Drawing.Point(107, 51);
            this.RepairMissionCode.Name = "RepairMissionCode";
            this.RepairMissionCode.ShowTable = null;
            this.RepairMissionCode.Size = new System.Drawing.Size(184, 21);
            this.RepairMissionCode.TabIndex = 2;
            this.RepairMissionCode.Tag = "999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "维修编号：";
            // 
            // CustomerCode
            // 
            this.CustomerCode.BaoBtnCaption = "";
            this.CustomerCode.BaoClickClose = false;
            this.CustomerCode.BaoColumnsWidth = null;
            this.CustomerCode.BaoDataAccDLLFullPath = "";
            this.CustomerCode.BaoFullClassName = "";
            this.CustomerCode.BaoSQL = "";
            this.CustomerCode.BaoTitleNames = null;
            this.CustomerCode.CodeValue = null;
            this.CustomerCode.DecideSql = "";
            this.CustomerCode.FrmHigth = 0;
            this.CustomerCode.FrmTitle = null;
            this.CustomerCode.FrmWidth = 0;
            this.CustomerCode.IsShowInTaskBar = false;
            this.CustomerCode.Location = new System.Drawing.Point(649, 51);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(21, 21);
            this.CustomerCode.TabIndex = 4;
            this.CustomerCode.Tag = "9999";
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(482, 51);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Size = new System.Drawing.Size(161, 21);
            this.CustomerName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "客户：";
            // 
            // RepairMissionID
            // 
            this.RepairMissionID.Location = new System.Drawing.Point(623, 423);
            this.RepairMissionID.Name = "RepairMissionID";
            this.RepairMissionID.Size = new System.Drawing.Size(73, 21);
            this.RepairMissionID.TabIndex = 7;
            this.RepairMissionID.Visible = false;
            // 
            // AppReson
            // 
            this.AppReson.Location = new System.Drawing.Point(107, 131);
            this.AppReson.Multiline = true;
            this.AppReson.Name = "AppReson";
            this.AppReson.Size = new System.Drawing.Size(563, 164);
            this.AppReson.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "申请原因：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Tag = "99999";
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AuditerCode
            // 
            this.AuditerCode.BaoBtnCaption = "";
            this.AuditerCode.BaoClickClose = false;
            this.AuditerCode.BaoColumnsWidth = null;
            this.AuditerCode.BaoDataAccDLLFullPath = "";
            this.AuditerCode.BaoFullClassName = "";
            this.AuditerCode.BaoSQL = "";
            this.AuditerCode.BaoTitleNames = null;
            this.AuditerCode.CodeValue = null;
            this.AuditerCode.DecideSql = "";
            this.AuditerCode.FrmHigth = 0;
            this.AuditerCode.FrmTitle = null;
            this.AuditerCode.FrmWidth = 0;
            this.AuditerCode.IsShowInTaskBar = false;
            this.AuditerCode.Location = new System.Drawing.Point(552, 315);
            this.AuditerCode.Name = "AuditerCode";
            this.AuditerCode.ShowTable = null;
            this.AuditerCode.Size = new System.Drawing.Size(22, 21);
            this.AuditerCode.TabIndex = 11;
            this.AuditerCode.Tag = "999";
            this.AuditerCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(this.AuditerCode_OnLookUpClosed_1);
            // 
            // AuditerName
            // 
            this.AuditerName.Location = new System.Drawing.Point(404, 315);
            this.AuditerName.Name = "AuditerName";
            this.AuditerName.ReadOnly = true;
            this.AuditerName.Size = new System.Drawing.Size(142, 21);
            this.AuditerName.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "指定部长：";
            // 
            // FreeApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 456);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AuditerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AuditerCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AppReson);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.RepairMissionID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RepairMissionCode);
            this.KeyPreview = true;
            this.Name = "FreeApplication";
            this.Text = "免费申请";
            this.Load += new System.EventHandler(this.FreeApplication_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FreeApplication_KeyDown);
            this.Controls.SetChildIndex(this.RepairMissionCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CustomerCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.RepairMissionID, 0);
            this.Controls.SetChildIndex(this.CustomerName, 0);
            this.Controls.SetChildIndex(this.AppReson, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.AuditerCode, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.AuditerName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.toolBarBill1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrmLookUp.RiliButtonEdit RepairMissionCode;
        private System.Windows.Forms.Label label1;
        private FrmLookUp.ButtonEdit CustomerCode;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RepairMissionID;
        private System.Windows.Forms.TextBox AppReson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private FrmLookUp.RiliButtonEdit AuditerCode;
        private System.Windows.Forms.TextBox AuditerName;
        private System.Windows.Forms.Label label4;
    }
}