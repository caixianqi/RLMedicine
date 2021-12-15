namespace PassWordConvert {
	partial class frmMain {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnConvert = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBefPwd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAftPwd = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(96, 115);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "加密";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(44, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "加密前密码";
			// 
			// txtBefPwd
			// 
			this.txtBefPwd.Location = new System.Drawing.Point(112, 38);
			this.txtBefPwd.Name = "txtBefPwd";
			this.txtBefPwd.Size = new System.Drawing.Size(193, 21);
			this.txtBefPwd.TabIndex = 0;
			this.txtBefPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBefPwd_KeyPress);
			this.txtBefPwd.Enter += new System.EventHandler(this.txtBefPwd_Enter);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(44, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "加密后密码";
			// 
			// txtAftPwd
			// 
			this.txtAftPwd.BackColor = System.Drawing.SystemColors.Window;
			this.txtAftPwd.Location = new System.Drawing.Point(112, 72);
			this.txtAftPwd.Name = "txtAftPwd";
			this.txtAftPwd.ReadOnly = true;
			this.txtAftPwd.Size = new System.Drawing.Size(193, 21);
			this.txtAftPwd.TabIndex = 1;
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(197, 115);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "退出";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(353, 167);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.txtAftPwd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBefPwd);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConvert);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "密码加密";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBefPwd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAftPwd;
		private System.Windows.Forms.Button btnExit;
	}
}

