namespace Bao.BillBase.Audit
{
    partial class FrmBillAuditFlowUserInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.txtAutoFlowId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baoButtonAuditUserName = new FrmLookUp.BaoButton();
            this.txtAuditNode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(276, 94);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(132, 25);
            this.txtOrderId.TabIndex = 13;
            this.txtOrderId.TextChanged += new System.EventHandler(this.txtOrderId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "同级节点的人员审核顺序号：";
            // 
            // txtAuditUserName
            // 
            this.txtAuditUserName.Location = new System.Drawing.Point(276, 56);
            this.txtAuditUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAuditUserName.Name = "txtAuditUserName";
            this.txtAuditUserName.Size = new System.Drawing.Size(132, 25);
            this.txtAuditUserName.TabIndex = 8;
            this.txtAuditUserName.TextChanged += new System.EventHandler(this.txtAuditUserName_TextChanged);
            // 
            // txtAutoFlowId
            // 
            this.txtAutoFlowId.Location = new System.Drawing.Point(545, 19);
            this.txtAutoFlowId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAutoFlowId.Name = "txtAutoFlowId";
            this.txtAutoFlowId.Size = new System.Drawing.Size(29, 25);
            this.txtAutoFlowId.TabIndex = 9;
            this.txtAutoFlowId.Visible = false;
            this.txtAutoFlowId.TextChanged += new System.EventHandler(this.txtAutoFlowId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "审批人员：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 7;
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
            this.baoButtonAuditUserName.Location = new System.Drawing.Point(428, 55);
            this.baoButtonAuditUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baoButtonAuditUserName.Name = "baoButtonAuditUserName";
            this.baoButtonAuditUserName.Size = new System.Drawing.Size(80, 28);
            this.baoButtonAuditUserName.TabIndex = 11;
            this.baoButtonAuditUserName.Click += new System.EventHandler(this.baoButtonAuditUserName_Click);
            this.baoButtonAuditUserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.baoButtonAuditUserName_MouseClick);
            this.baoButtonAuditUserName.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoButtonAuditUserName_OnLookUpClosed);
            // 
            // txtAuditNode
            // 
            this.txtAuditNode.Location = new System.Drawing.Point(276, 20);
            this.txtAuditNode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAuditNode.Name = "txtAuditNode";
            this.txtAuditNode.Size = new System.Drawing.Size(132, 25);
            this.txtAuditNode.TabIndex = 9;
            this.txtAuditNode.TextChanged += new System.EventHandler(this.txtAutoFlowId_TextChanged);
            // 
            // FrmBillAuditFlowUserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 145);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baoButtonAuditUserName);
            this.Controls.Add(this.txtAuditUserName);
            this.Controls.Add(this.txtAuditNode);
            this.Controls.Add(this.txtAutoFlowId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmBillAuditFlowUserInput";
            this.Text = "审批流程人员输入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBillAuditFlowUserInput_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label3;
        private FrmLookUp.BaoButton baoButtonAuditUserName;
        public System.Windows.Forms.TextBox txtAuditUserName;
        public System.Windows.Forms.TextBox txtAutoFlowId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtAuditNode;
    }
}