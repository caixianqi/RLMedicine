namespace Bao.BillBase.Audit.JFWUserSet
{
    partial class FrmFlowUserSetInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuditUserName = new System.Windows.Forms.TextBox();
            this.txtAuditNode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baoButtonAuditUserName = new FrmLookUp.BaoButton();
            this.SuspendLayout();
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(188, 73);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 21);
            this.txtOrderId.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "同级节点的人员审核顺序号：";
            // 
            // txtAuditUserName
            // 
            this.txtAuditUserName.Location = new System.Drawing.Point(188, 43);
            this.txtAuditUserName.Name = "txtAuditUserName";
            this.txtAuditUserName.Size = new System.Drawing.Size(100, 21);
            this.txtAuditUserName.TabIndex = 16;
            // 
            // txtAuditNode
            // 
            this.txtAuditNode.Location = new System.Drawing.Point(188, 14);
            this.txtAuditNode.Name = "txtAuditNode";
            this.txtAuditNode.Size = new System.Drawing.Size(100, 21);
            this.txtAuditNode.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "审批人员：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "审批节点：";
            // 
            // baoButtonAuditUserName
            // 
            this.baoButtonAuditUserName.BaoBtnCaption = "...";
            this.baoButtonAuditUserName.BaoClickClose = true;
            this.baoButtonAuditUserName.BaoDataAccDLLFullPath = "";
            this.baoButtonAuditUserName.BaoFullClassName = "";
            this.baoButtonAuditUserName.BaoSQL = "";
            this.baoButtonAuditUserName.BaoTitleNames = null;
            this.baoButtonAuditUserName.Location = new System.Drawing.Point(303, 43);
            this.baoButtonAuditUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.baoButtonAuditUserName.Name = "baoButtonAuditUserName";
            this.baoButtonAuditUserName.Size = new System.Drawing.Size(60, 22);
            this.baoButtonAuditUserName.TabIndex = 20;
            // 
            // FrmFlowUserSetInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 106);
            this.Controls.Add(this.baoButtonAuditUserName);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAuditUserName);
            this.Controls.Add(this.txtAuditNode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmFlowUserSetInput";
            this.Text = "提交人员输入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtAuditUserName;
        public System.Windows.Forms.TextBox txtAuditNode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FrmLookUp.BaoButton baoButtonAuditUserName;
    }
}