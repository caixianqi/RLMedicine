namespace FormMain.Login
{
    partial class FrmRole
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
            this.label2 = new System.Windows.Forms.Label();
            this.RoleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoleId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Memo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(332, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "角色名称";
            // 
            // RoleName
            // 
            this.RoleName.Location = new System.Drawing.Point(404, 28);
            this.RoleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoleName.Name = "RoleName";
            this.RoleName.Size = new System.Drawing.Size(167, 25);
            this.RoleName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "角色编号";
            // 
            // RoleId
            // 
            this.RoleId.Location = new System.Drawing.Point(113, 28);
            this.RoleId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoleId.MaxLength = 5;
            this.RoleId.Name = "RoleId";
            this.RoleId.Size = new System.Drawing.Size(167, 25);
            this.RoleId.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(72, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "描述";
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(113, 78);
            this.Memo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Memo.MaxLength = 5;
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(458, 25);
            this.Memo.TabIndex = 8;
            // 
            // FrmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 142);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoleId);
            this.Name = "FrmRole";
            this.Text = "FrmRole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RoleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RoleId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Memo;
    }
}