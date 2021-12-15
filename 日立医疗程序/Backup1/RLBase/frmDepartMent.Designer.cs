namespace RLBase
{
    partial class frmDepartMent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartMent));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssAdd = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAddNew = new System.Windows.Forms.ToolStripButton();
            this.BtnModify = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tssRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.BtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tssAddRow = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxIsEnd = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAdd,
            this.BtnAddNew,
            this.BtnModify,
            this.BtnDelete,
            this.tssRefresh,
            this.BtnRefresh,
            this.BtnSave,
            this.BtnCancel,
            this.tssAddRow,
            this.BtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(666, 25);
            this.toolStrip1.TabIndex = 76;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tssAdd
            // 
            this.tssAdd.Name = "tssAdd";
            this.tssAdd.Size = new System.Drawing.Size(6, 25);
            this.tssAdd.Visible = false;
            // 
            // BtnAddNew
            // 
            this.BtnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddNew.Image")));
            this.BtnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddNew.Name = "BtnAddNew";
            this.BtnAddNew.Size = new System.Drawing.Size(52, 22);
            this.BtnAddNew.Text = "新增";
            this.BtnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.Image")));
            this.BtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(52, 22);
            this.BtnModify.Text = "修改";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(52, 22);
            this.BtnDelete.Text = "删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // tssRefresh
            // 
            this.tssRefresh.Name = "tssRefresh";
            this.tssRefresh.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(52, 22);
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(52, 22);
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(52, 22);
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tssAddRow
            // 
            this.tssAddRow.Name = "tssAddRow";
            this.tssAddRow.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnExit
            // 
            this.BtnExit.Image = ((System.Drawing.Image)(resources.GetObject("BtnExit.Image")));
            this.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(52, 22);
            this.BtnExit.Text = "退出";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 329);
            this.panel1.TabIndex = 77;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(177, 329);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.checkBoxIsEnd);
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Controls.Add(this.textBoxName);
            this.panel2.Controls.Add(this.labelNum);
            this.panel2.Controls.Add(this.textBoxNum);
            this.panel2.Location = new System.Drawing.Point(183, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 329);
            this.panel2.TabIndex = 78;
            // 
            // checkBoxIsEnd
            // 
            this.checkBoxIsEnd.AutoSize = true;
            this.checkBoxIsEnd.Location = new System.Drawing.Point(44, 98);
            this.checkBoxIsEnd.Name = "checkBoxIsEnd";
            this.checkBoxIsEnd.Size = new System.Drawing.Size(84, 16);
            this.checkBoxIsEnd.TabIndex = 4;
            this.checkBoxIsEnd.Text = "是否为末级";
            this.checkBoxIsEnd.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(42, 65);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 12);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "名称：";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 62);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 2;
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(42, 28);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(41, 12);
            this.labelNum.TabIndex = 1;
            this.labelNum.Text = "编码：";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(89, 25);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(100, 21);
            this.textBoxNum.TabIndex = 0;
            // 
            // frmDepartMent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 357);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDepartMent";
            this.Text = "frmDepartMent";
            this.Load += new System.EventHandler(this.frmDepartMent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator tssAdd;
        public System.Windows.Forms.ToolStripButton BtnAddNew;
        public System.Windows.Forms.ToolStripButton BtnModify;
        public System.Windows.Forms.ToolStripButton BtnDelete;
        public System.Windows.Forms.ToolStripSeparator tssRefresh;
        public System.Windows.Forms.ToolStripButton BtnRefresh;
        public System.Windows.Forms.ToolStripButton BtnSave;
        public System.Windows.Forms.ToolStripButton BtnCancel;
        public System.Windows.Forms.ToolStripSeparator tssAddRow;
        private System.Windows.Forms.ToolStripButton BtnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxIsEnd;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.TextBox textBoxNum;
    }
}