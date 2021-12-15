namespace Bao.BillBase.Audit
{
    partial class FrmBillAudit
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtAuditNum = new System.Windows.Forms.TextBox();
            this.txtEmpLevel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdoAgree = new System.Windows.Forms.RadioButton();
            this.rdoDisAgree = new System.Windows.Forms.RadioButton();
            this.rdoNot = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScorePanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.baoBtnpLevel = new FrmLookUp.BaoButton();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ScorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 234);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "审批次数：";
            // 
            // txtAuditNum
            // 
            this.txtAuditNum.BackColor = System.Drawing.Color.White;
            this.txtAuditNum.Enabled = false;
            this.txtAuditNum.Location = new System.Drawing.Point(115, 229);
            this.txtAuditNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuditNum.Name = "txtAuditNum";
            this.txtAuditNum.ReadOnly = true;
            this.txtAuditNum.Size = new System.Drawing.Size(80, 25);
            this.txtAuditNum.TabIndex = 2;
            // 
            // txtEmpLevel
            // 
            this.txtEmpLevel.Location = new System.Drawing.Point(208, 8);
            this.txtEmpLevel.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpLevel.Name = "txtEmpLevel";
            this.txtEmpLevel.Size = new System.Drawing.Size(80, 25);
            this.txtEmpLevel.TabIndex = 2;
            this.txtEmpLevel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "分数等级：";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "扣   分：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(180, 318);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 29);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(418, 318);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdoAgree
            // 
            this.rdoAgree.AutoSize = true;
            this.rdoAgree.Checked = true;
            this.rdoAgree.Location = new System.Drawing.Point(225, 273);
            this.rdoAgree.Margin = new System.Windows.Forms.Padding(4);
            this.rdoAgree.Name = "rdoAgree";
            this.rdoAgree.Size = new System.Drawing.Size(55, 19);
            this.rdoAgree.TabIndex = 9;
            this.rdoAgree.TabStop = true;
            this.rdoAgree.Text = "同意";
            this.rdoAgree.UseVisualStyleBackColor = true;
            // 
            // rdoDisAgree
            // 
            this.rdoDisAgree.AutoSize = true;
            this.rdoDisAgree.Location = new System.Drawing.Point(394, 273);
            this.rdoDisAgree.Margin = new System.Windows.Forms.Padding(4);
            this.rdoDisAgree.Name = "rdoDisAgree";
            this.rdoDisAgree.Size = new System.Drawing.Size(70, 19);
            this.rdoDisAgree.TabIndex = 10;
            this.rdoDisAgree.Text = "不同意";
            this.rdoDisAgree.UseVisualStyleBackColor = true;
            // 
            // rdoNot
            // 
            this.rdoNot.AutoSize = true;
            this.rdoNot.Location = new System.Drawing.Point(105, 273);
            this.rdoNot.Margin = new System.Windows.Forms.Padding(4);
            this.rdoNot.Name = "rdoNot";
            this.rdoNot.Size = new System.Drawing.Size(70, 19);
            this.rdoNot.TabIndex = 11;
            this.rdoNot.TabStop = true;
            this.rdoNot.Text = "未审核";
            this.rdoNot.UseVisualStyleBackColor = true;
            this.rdoNot.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(33, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 411);
            this.panel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ScorePanel);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.rdoNot);
            this.groupBox1.Controls.Add(this.txtAuditNum);
            this.groupBox1.Controls.Add(this.rdoDisAgree);
            this.groupBox1.Controls.Add(this.rdoAgree);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(24, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 371);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ScorePanel
            // 
            this.ScorePanel.Controls.Add(this.textBox1);
            this.ScorePanel.Controls.Add(this.label8);
            this.ScorePanel.Controls.Add(this.baoBtnpLevel);
            this.ScorePanel.Controls.Add(this.label7);
            this.ScorePanel.Controls.Add(this.txtEmpLevel);
            this.ScorePanel.Location = new System.Drawing.Point(377, 226);
            this.ScorePanel.Name = "ScorePanel";
            this.ScorePanel.Size = new System.Drawing.Size(201, 40);
            this.ScorePanel.TabIndex = 12;
            this.ScorePanel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(85, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(80, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "0";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // baoBtnpLevel
            // 
            this.baoBtnpLevel.BaoBtnCaption = "...";
            this.baoBtnpLevel.BaoClickClose = true;
            this.baoBtnpLevel.BaoDataAccDLLFullPath = "";
            this.baoBtnpLevel.BaoFullClassName = "";
            this.baoBtnpLevel.BaoSQL = "";
            this.baoBtnpLevel.BaoTitleNames = null;
            this.baoBtnpLevel.Location = new System.Drawing.Point(165, 7);
            this.baoBtnpLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baoBtnpLevel.Name = "baoBtnpLevel";
            this.baoBtnpLevel.Size = new System.Drawing.Size(33, 28);
            this.baoBtnpLevel.TabIndex = 6;
            this.baoBtnpLevel.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnpLevel_OnLookUpClosed);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(115, 15);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(463, 200);
            this.txtMemo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "意   见：";
            // 
            // FrmBillAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 444);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBillAudit";
            this.Text = "审核";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ScorePanel.ResumeLayout(false);
            this.ScorePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAuditNum;
        private System.Windows.Forms.TextBox txtEmpLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdoAgree;
        private System.Windows.Forms.RadioButton rdoDisAgree;
        private System.Windows.Forms.RadioButton rdoNot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel ScorePanel;
        public FrmLookUp.BaoButton baoBtnpLevel;
        public System.Windows.Forms.TextBox textBox1;
    }
}