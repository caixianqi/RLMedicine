namespace FormMain.Login
{
    partial class FrmUserUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserUpdate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOKPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPassWord = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.labUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtoldPassWord = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.txtMemo);
            this.panel1.Controls.Add(this.cbxMemo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtOKPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNewPassWord);
            this.panel1.Controls.Add(this.labName);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.labUser);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.txtoldPassWord);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 222);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.White;
            this.txtMemo.Location = new System.Drawing.Point(122, 163);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(152, 21);
            this.txtMemo.TabIndex = 26;
            // 
            // cbxMemo
            // 
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Items.AddRange(new object[] {
            "",
            "操作员",
            "系统管理员",
            "其他"});
            this.cbxMemo.Location = new System.Drawing.Point(327, 164);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(153, 20);
            this.cbxMemo.TabIndex = 25;
            this.cbxMemo.Visible = false;
            this.cbxMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxMemo_KeyPress);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(56, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "密码确认";
            // 
            // txtOKPassword
            // 
            this.txtOKPassword.Location = new System.Drawing.Point(122, 133);
            this.txtOKPassword.Name = "txtOKPassword";
            this.txtOKPassword.PasswordChar = '*';
            this.txtOKPassword.Size = new System.Drawing.Size(152, 21);
            this.txtOKPassword.TabIndex = 12;
            this.txtOKPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOKPassword_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(56, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "邮箱";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户名称";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(122, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 21);
            this.txtName.TabIndex = 8;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "新密码";
            // 
            // txtNewPassWord
            // 
            this.txtNewPassWord.Location = new System.Drawing.Point(122, 102);
            this.txtNewPassWord.Name = "txtNewPassWord";
            this.txtNewPassWord.PasswordChar = '*';
            this.txtNewPassWord.Size = new System.Drawing.Size(152, 21);
            this.txtNewPassWord.TabIndex = 6;
            this.txtNewPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassWord_KeyPress);
            // 
            // labName
            // 
            this.labName.BackColor = System.Drawing.Color.White;
            this.labName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.Location = new System.Drawing.Point(56, 74);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(50, 18);
            this.labName.TabIndex = 0;
            this.labName.Text = "旧密码";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(119, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labUser
            // 
            this.labUser.BackColor = System.Drawing.Color.White;
            this.labUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUser.Location = new System.Drawing.Point(56, 14);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(50, 17);
            this.labUser.TabIndex = 0;
            this.labUser.Text = "用户名";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(122, 10);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(152, 21);
            this.txtUser.TabIndex = 1;
            // 
            // txtoldPassWord
            // 
            this.txtoldPassWord.BackColor = System.Drawing.Color.White;
            this.txtoldPassWord.Location = new System.Drawing.Point(122, 71);
            this.txtoldPassWord.Name = "txtoldPassWord";
            this.txtoldPassWord.PasswordChar = '*';
            this.txtoldPassWord.ReadOnly = true;
            this.txtoldPassWord.Size = new System.Drawing.Size(152, 21);
            this.txtoldPassWord.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::FormMain.Properties.Resources.Login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 65);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmUserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 280);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户修改";
            this.Load += new System.EventHandler(this.FrmUserUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserUpdate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtoldPassWord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPassWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOKPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxMemo;
        private System.Windows.Forms.TextBox txtMemo;
    }
}