namespace FrmLookUp
{
    partial class ToolBarBill
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarBill));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAudit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnUnAudit = new System.Windows.Forms.Button();
            this.BtnUpLoad = new System.Windows.Forms.Button();
            this.BtnUpCancel = new System.Windows.Forms.Button();
            this.BtnAuditList = new System.Windows.Forms.Button();
            this.baoBtnSelect = new FrmLookUp.BaoButton();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnExit.Image = global::FrmLookUp.Properties.Resources.close1;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(821, 0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(61, 28);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "退出";
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnPrint.Image = global::FrmLookUp.Properties.Resources.printer;
            this.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrint.Location = new System.Drawing.Point(759, 0);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(62, 28);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "打印";
            this.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnExcel.Image = global::FrmLookUp.Properties.Resources.bill;
            this.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExcel.Location = new System.Drawing.Point(660, 0);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(99, 28);
            this.BtnExcel.TabIndex = 7;
            this.BtnExcel.Text = "导出Excel";
            this.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCancel.Image = global::FrmLookUp.Properties.Resources.Cancel;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(506, 0);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(56, 28);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "撤销";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDelete.Image = global::FrmLookUp.Properties.Resources.cut1;
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(336, 0);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(56, 28);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAudit
            // 
            this.BtnAudit.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAudit.Image = global::FrmLookUp.Properties.Resources.audit;
            this.BtnAudit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAudit.Location = new System.Drawing.Point(392, 0);
            this.BtnAudit.Name = "BtnAudit";
            this.BtnAudit.Size = new System.Drawing.Size(57, 28);
            this.BtnAudit.TabIndex = 4;
            this.BtnAudit.Text = "审核";
            this.BtnAudit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAudit.UseVisualStyleBackColor = true;
            this.BtnAudit.Click += new System.EventHandler(this.BtnAudit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSave.Image = global::FrmLookUp.Properties.Resources.save_as;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(158, 0);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(54, 28);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnUpdate.Image = global::FrmLookUp.Properties.Resources.Approve_all;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdate.Location = new System.Drawing.Point(102, 0);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(56, 28);
            this.BtnUpdate.TabIndex = 2;
            this.BtnUpdate.Text = "修改";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnNew.Image = global::FrmLookUp.Properties.Resources.add_obj;
            this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNew.Location = new System.Drawing.Point(47, 0);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(55, 28);
            this.BtnNew.TabIndex = 1;
            this.BtnNew.Text = "新增";
            this.BtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnUnAudit
            // 
            this.BtnUnAudit.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnUnAudit.Image = global::FrmLookUp.Properties.Resources.delete_obj;
            this.BtnUnAudit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUnAudit.Location = new System.Drawing.Point(449, 0);
            this.BtnUnAudit.Name = "BtnUnAudit";
            this.BtnUnAudit.Size = new System.Drawing.Size(57, 28);
            this.BtnUnAudit.TabIndex = 11;
            this.BtnUnAudit.Text = "弃审";
            this.BtnUnAudit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnAudit.UseVisualStyleBackColor = true;
            this.BtnUnAudit.Click += new System.EventHandler(this.BtnUnAudit_Click);
            // 
            // BtnUpLoad
            // 
            this.BtnUpLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnUpLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpLoad.Image")));
            this.BtnUpLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpLoad.Location = new System.Drawing.Point(212, 0);
            this.BtnUpLoad.Name = "BtnUpLoad";
            this.BtnUpLoad.Size = new System.Drawing.Size(61, 28);
            this.BtnUpLoad.TabIndex = 12;
            this.BtnUpLoad.Text = "提交";
            this.BtnUpLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpLoad.UseVisualStyleBackColor = true;
            this.BtnUpLoad.Click += new System.EventHandler(this.BtnUpLoad_Click);
            // 
            // BtnUpCancel
            // 
            this.BtnUpCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnUpCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpCancel.Image")));
            this.BtnUpCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpCancel.Location = new System.Drawing.Point(273, 0);
            this.BtnUpCancel.Name = "BtnUpCancel";
            this.BtnUpCancel.Size = new System.Drawing.Size(63, 28);
            this.BtnUpCancel.TabIndex = 13;
            this.BtnUpCancel.Text = "收回";
            this.BtnUpCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpCancel.UseVisualStyleBackColor = true;
            this.BtnUpCancel.Click += new System.EventHandler(this.BtnUpCancel_Click);
            // 
            // BtnAuditList
            // 
            this.BtnAuditList.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAuditList.Image = global::FrmLookUp.Properties.Resources._4_9;
            this.BtnAuditList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAuditList.Location = new System.Drawing.Point(562, 0);
            this.BtnAuditList.Name = "BtnAuditList";
            this.BtnAuditList.Size = new System.Drawing.Size(98, 28);
            this.BtnAuditList.TabIndex = 14;
            this.BtnAuditList.Text = "审核列表";
            this.BtnAuditList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAuditList.UseVisualStyleBackColor = true;
            this.BtnAuditList.Click += new System.EventHandler(this.BtnAuditList_Click);
            // 
            // baoBtnSelect
            // 
            this.baoBtnSelect.BaoBtnCaption = "选择";
            this.baoBtnSelect.BaoClickClose = false;
            this.baoBtnSelect.BaoDataAccDLLFullPath = "";
            this.baoBtnSelect.BaoFullClassName = "";
            this.baoBtnSelect.BaoSQL = "";
            this.baoBtnSelect.BaoTitleNames = null;
            this.baoBtnSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.baoBtnSelect.Location = new System.Drawing.Point(0, 0);
            this.baoBtnSelect.Name = "baoBtnSelect";
            this.baoBtnSelect.Size = new System.Drawing.Size(47, 28);
            this.baoBtnSelect.TabIndex = 0;
            this.baoBtnSelect.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnSelect_OnLookUpClosed);
            // 
            // ToolBarBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.BtnAuditList);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnUnAudit);
            this.Controls.Add(this.BtnAudit);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpCancel);
            this.Controls.Add(this.BtnUpLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.baoBtnSelect);
            this.Name = "ToolBarBill";
            this.Size = new System.Drawing.Size(892, 28);
            this.Load += new System.EventHandler(this.ToolBarBill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public BaoButton baoBtnSelect;
        public System.Windows.Forms.Button BtnNew;
        public System.Windows.Forms.Button BtnUpdate;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnAudit;
        public System.Windows.Forms.Button BtnPrint;
        public System.Windows.Forms.Button BtnExit;
        public System.Windows.Forms.Button BtnExcel;
        public System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.Button BtnUnAudit;
        public System.Windows.Forms.Button BtnUpLoad;
        public System.Windows.Forms.Button BtnUpCancel;
        private System.Windows.Forms.Button BtnAuditList;


    }
}
