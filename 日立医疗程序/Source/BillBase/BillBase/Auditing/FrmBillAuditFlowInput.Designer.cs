namespace Bao.BillBase.Audit
{
    partial class FrmBillAuditFlowInput
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.baoBtnManagerUserId = new FrmLookUp.BaoButton();
            this.txtManagerUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuditCycle = new System.Windows.Forms.TextBox();
            this.baoBtnFunctionId = new FrmLookUp.BaoButton();
            this.baoBtnAuditNode = new FrmLookUp.BaoButton();
            this.cboAuditType = new System.Windows.Forms.ComboBox();
            this.txtFunctionId = new System.Windows.Forms.TextBox();
            this.txtSortId = new System.Windows.Forms.TextBox();
            this.txtAuditNode = new System.Windows.Forms.TextBox();
            this.txtAutoFlowId = new System.Windows.Forms.TextBox();
            this.lblFunctionId = new System.Windows.Forms.Label();
            this.lblAuditType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuditNode = new System.Windows.Forms.Label();
            this.lblAutoFlowId = new System.Windows.Forms.Label();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGroupId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.baoBtnManagerUserId);
            this.panel1.Controls.Add(this.txtManagerUserName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAuditCycle);
            this.panel1.Controls.Add(this.baoBtnFunctionId);
            this.panel1.Controls.Add(this.baoBtnAuditNode);
            this.panel1.Controls.Add(this.cboAuditType);
            this.panel1.Controls.Add(this.txtFunctionId);
            this.panel1.Controls.Add(this.txtSortId);
            this.panel1.Controls.Add(this.txtAuditNode);
            this.panel1.Controls.Add(this.txtAutoFlowId);
            this.panel1.Controls.Add(this.lblFunctionId);
            this.panel1.Controls.Add(this.lblAuditType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAuditNode);
            this.panel1.Controls.Add(this.lblAutoFlowId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 220);
            this.panel1.TabIndex = 2;
            // 
            // baoBtnManagerUserId
            // 
            this.baoBtnManagerUserId.BaoBtnCaption = "...";
            this.baoBtnManagerUserId.BaoClickClose = true;
            this.baoBtnManagerUserId.BaoDataAccDLLFullPath = "";
            this.baoBtnManagerUserId.BaoFullClassName = "";
            this.baoBtnManagerUserId.BaoSQL = "";
            this.baoBtnManagerUserId.BaoTitleNames = null;
            this.baoBtnManagerUserId.Location = new System.Drawing.Point(617, 120);
            this.baoBtnManagerUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baoBtnManagerUserId.Name = "baoBtnManagerUserId";
            this.baoBtnManagerUserId.Size = new System.Drawing.Size(80, 28);
            this.baoBtnManagerUserId.TabIndex = 38;
            this.baoBtnManagerUserId.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnManagerUserId_OnLookUpClosed);
            // 
            // txtManagerUserName
            // 
            this.txtManagerUserName.Location = new System.Drawing.Point(477, 121);
            this.txtManagerUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtManagerUserName.Name = "txtManagerUserName";
            this.txtManagerUserName.Size = new System.Drawing.Size(132, 25);
            this.txtManagerUserName.TabIndex = 37;
            this.txtManagerUserName.TextChanged += new System.EventHandler(this.txtManagerUserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "管理人员：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "审批周期：";
            // 
            // txtAuditCycle
            // 
            this.txtAuditCycle.Location = new System.Drawing.Point(165, 121);
            this.txtAuditCycle.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuditCycle.Name = "txtAuditCycle";
            this.txtAuditCycle.Size = new System.Drawing.Size(159, 25);
            this.txtAuditCycle.TabIndex = 18;
            this.txtAuditCycle.TextChanged += new System.EventHandler(this.txtAuditCycle_TextChanged);
            // 
            // baoBtnFunctionId
            // 
            this.baoBtnFunctionId.BaoBtnCaption = "...";
            this.baoBtnFunctionId.BaoClickClose = true;
            this.baoBtnFunctionId.BaoDataAccDLLFullPath = "";
            this.baoBtnFunctionId.BaoFullClassName = "";
            this.baoBtnFunctionId.BaoSQL = "";
            this.baoBtnFunctionId.BaoTitleNames = null;
            this.baoBtnFunctionId.Location = new System.Drawing.Point(619, 29);
            this.baoBtnFunctionId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baoBtnFunctionId.Name = "baoBtnFunctionId";
            this.baoBtnFunctionId.Size = new System.Drawing.Size(80, 28);
            this.baoBtnFunctionId.TabIndex = 17;
            this.baoBtnFunctionId.Visible = false;
            this.baoBtnFunctionId.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnFunctionId_OnLookUpClosed);
            // 
            // baoBtnAuditNode
            // 
            this.baoBtnAuditNode.BaoBtnCaption = "...";
            this.baoBtnAuditNode.BaoClickClose = true;
            this.baoBtnAuditNode.BaoDataAccDLLFullPath = "";
            this.baoBtnAuditNode.BaoFullClassName = "";
            this.baoBtnAuditNode.BaoSQL = "";
            this.baoBtnAuditNode.BaoTitleNames = null;
            this.baoBtnAuditNode.Location = new System.Drawing.Point(616, 74);
            this.baoBtnAuditNode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baoBtnAuditNode.Name = "baoBtnAuditNode";
            this.baoBtnAuditNode.Size = new System.Drawing.Size(80, 28);
            this.baoBtnAuditNode.TabIndex = 16;
            this.baoBtnAuditNode.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnAuditNode_OnLookUpClosed);
            // 
            // cboAuditType
            // 
            this.cboAuditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuditType.FormattingEnabled = true;
            this.cboAuditType.Items.AddRange(new object[] {
            "人员审核",
            "角色审核"});
            this.cboAuditType.Location = new System.Drawing.Point(165, 76);
            this.cboAuditType.Margin = new System.Windows.Forms.Padding(4);
            this.cboAuditType.Name = "cboAuditType";
            this.cboAuditType.Size = new System.Drawing.Size(159, 23);
            this.cboAuditType.TabIndex = 15;
            // 
            // txtFunctionId
            // 
            this.txtFunctionId.Location = new System.Drawing.Point(479, 28);
            this.txtFunctionId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFunctionId.MaxLength = 20;
            this.txtFunctionId.Name = "txtFunctionId";
            this.txtFunctionId.Size = new System.Drawing.Size(132, 25);
            this.txtFunctionId.TabIndex = 13;
            this.txtFunctionId.TextChanged += new System.EventHandler(this.txtFunctionId_TextChanged);
            // 
            // txtSortId
            // 
            this.txtSortId.Location = new System.Drawing.Point(165, 160);
            this.txtSortId.Margin = new System.Windows.Forms.Padding(4);
            this.txtSortId.Name = "txtSortId";
            this.txtSortId.Size = new System.Drawing.Size(159, 25);
            this.txtSortId.TabIndex = 14;
            this.txtSortId.TextChanged += new System.EventHandler(this.txtSortId_TextChanged);
            // 
            // txtAuditNode
            // 
            this.txtAuditNode.AcceptsTab = true;
            this.txtAuditNode.Location = new System.Drawing.Point(479, 75);
            this.txtAuditNode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuditNode.Name = "txtAuditNode";
            this.txtAuditNode.Size = new System.Drawing.Size(132, 25);
            this.txtAuditNode.TabIndex = 12;
            this.txtAuditNode.TextChanged += new System.EventHandler(this.txtAuditNode_TextChanged);
            // 
            // txtAutoFlowId
            // 
            this.txtAutoFlowId.Enabled = false;
            this.txtAutoFlowId.Location = new System.Drawing.Point(167, 29);
            this.txtAutoFlowId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutoFlowId.Name = "txtAutoFlowId";
            this.txtAutoFlowId.Size = new System.Drawing.Size(159, 25);
            this.txtAutoFlowId.TabIndex = 11;
            // 
            // lblFunctionId
            // 
            this.lblFunctionId.AutoSize = true;
            this.lblFunctionId.Location = new System.Drawing.Point(391, 32);
            this.lblFunctionId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFunctionId.Name = "lblFunctionId";
            this.lblFunctionId.Size = new System.Drawing.Size(82, 15);
            this.lblFunctionId.TabIndex = 7;
            this.lblFunctionId.Text = "功能编号：";
            // 
            // lblAuditType
            // 
            this.lblAuditType.AutoSize = true;
            this.lblAuditType.Location = new System.Drawing.Point(77, 81);
            this.lblAuditType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuditType.Name = "lblAuditType";
            this.lblAuditType.Size = new System.Drawing.Size(82, 15);
            this.lblAuditType.TabIndex = 6;
            this.lblAuditType.Tag = "";
            this.lblAuditType.Text = "审批类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 8;
            this.label1.Tag = "";
            this.label1.Text = "流程顺序号：";
            // 
            // lblAuditNode
            // 
            this.lblAuditNode.AutoSize = true;
            this.lblAuditNode.Location = new System.Drawing.Point(391, 81);
            this.lblAuditNode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuditNode.Name = "lblAuditNode";
            this.lblAuditNode.Size = new System.Drawing.Size(82, 15);
            this.lblAuditNode.TabIndex = 10;
            this.lblAuditNode.Tag = "";
            this.lblAuditNode.Text = "审批节点：";
            // 
            // lblAutoFlowId
            // 
            this.lblAutoFlowId.AutoSize = true;
            this.lblAutoFlowId.Location = new System.Drawing.Point(61, 35);
            this.lblAutoFlowId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoFlowId.Name = "lblAutoFlowId";
            this.lblAutoFlowId.Size = new System.Drawing.Size(97, 15);
            this.lblAutoFlowId.TabIndex = 9;
            this.lblAutoFlowId.Tag = "";
            this.lblAutoFlowId.Text = "审批流编码：";
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(477, 165);
            this.txtGroupId.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.ReadOnly = true;
            this.txtGroupId.Size = new System.Drawing.Size(75, 25);
            this.txtGroupId.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 39;
            this.label4.Tag = "";
            this.label4.Text = "组别：";
            // 
            // FrmBillAuditFlowInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 220);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBillAuditFlowInput";
            this.Text = "审批流程输入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBillAuditFlowInput_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FrmLookUp.BaoButton baoBtnFunctionId;
        private FrmLookUp.BaoButton baoBtnAuditNode;
        public System.Windows.Forms.ComboBox cboAuditType;
        public System.Windows.Forms.TextBox txtFunctionId;
        public System.Windows.Forms.TextBox txtSortId;
        public System.Windows.Forms.TextBox txtAuditNode;
        public System.Windows.Forms.TextBox txtAutoFlowId;
        private System.Windows.Forms.Label lblFunctionId;
        private System.Windows.Forms.Label lblAuditType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAuditNode;
        private System.Windows.Forms.Label lblAutoFlowId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAuditCycle;
        private FrmLookUp.BaoButton baoBtnManagerUserId;
        public System.Windows.Forms.TextBox txtManagerUserName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Label label4;
    }
}