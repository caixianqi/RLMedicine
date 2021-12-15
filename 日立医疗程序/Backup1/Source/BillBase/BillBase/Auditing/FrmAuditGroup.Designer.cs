namespace Bao.BillBase.Auditing
{
    partial class FrmAuditGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuditGroupId = new System.Windows.Forms.TextBox();
            this.txtAuditGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "审核组编号";
            // 
            // txtAuditGroupId
            // 
            this.txtAuditGroupId.Location = new System.Drawing.Point(117, 38);
            this.txtAuditGroupId.Name = "txtAuditGroupId";
            this.txtAuditGroupId.Size = new System.Drawing.Size(100, 25);
            this.txtAuditGroupId.TabIndex = 1;
            // 
            // txtAuditGroupName
            // 
            this.txtAuditGroupName.Location = new System.Drawing.Point(385, 38);
            this.txtAuditGroupName.Name = "txtAuditGroupName";
            this.txtAuditGroupName.Size = new System.Drawing.Size(180, 25);
            this.txtAuditGroupName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "审核组名称";
            // 
            // FrmAuditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 104);
            this.Controls.Add(this.txtAuditGroupName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAuditGroupId);
            this.Controls.Add(this.label1);
            this.Name = "FrmAuditGroup";
            this.Text = "FrmAuditGroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuditGroupId;
        private System.Windows.Forms.TextBox txtAuditGroupName;
        private System.Windows.Forms.Label label2;
    }
}