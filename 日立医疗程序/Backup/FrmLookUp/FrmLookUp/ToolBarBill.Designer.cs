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
            this.BtnAddRow = new System.Windows.Forms.ToolStripButton();
            this.BtnDeleteRow = new System.Windows.Forms.ToolStripButton();
            this.tssPrint = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPrint = new System.Windows.Forms.ToolStripButton();
            this.BtnExcel = new System.Windows.Forms.ToolStripButton();
            this.tssUpLoad = new System.Windows.Forms.ToolStripSeparator();
            this.BtnUpLoad = new System.Windows.Forms.ToolStripButton();
            this.BtnUnUpLoad = new System.Windows.Forms.ToolStripButton();
            this.tssAudit = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAudit = new System.Windows.Forms.ToolStripButton();
            this.BtnUnAudit = new System.Windows.Forms.ToolStripButton();
            this.BtnAuditList = new System.Windows.Forms.ToolStripButton();
            this.tssFirst = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnEnd = new System.Windows.Forms.ToolStripButton();
            this.tssLocation = new System.Windows.Forms.ToolStripSeparator();
            this.BtnLocation = new System.Windows.Forms.ToolStripButton();
            this.tssExit = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExit = new System.Windows.Forms.ToolStripButton();
            this.baoBtnSelect = new FrmLookUp.BaoButton();
            this.toolStrip1.SuspendLayout();
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
            this.BtnAddRow,
            this.BtnDeleteRow,
            this.tssPrint,
            this.BtnPrint,
            this.BtnExcel,
            this.tssUpLoad,
            this.BtnUpLoad,
            this.BtnUnUpLoad,
            this.tssAudit,
            this.BtnAudit,
            this.BtnUnAudit,
            this.BtnAuditList,
            this.tssFirst,
            this.btnFirst,
            this.btnPreview,
            this.btnNext,
            this.btnEnd,
            this.tssLocation,
            this.BtnLocation,
            this.tssExit,
            this.BtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 25);
            this.toolStrip1.TabIndex = 74;
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
            this.BtnAddNew.Size = new System.Drawing.Size(49, 22);
            this.BtnAddNew.Text = "新增";
            this.BtnAddNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.Image")));
            this.BtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(49, 22);
            this.BtnModify.Text = "修改";
            this.BtnModify.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(49, 22);
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
            this.BtnRefresh.Size = new System.Drawing.Size(49, 22);
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.Click +=new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(49, 22);
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(49, 22);
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tssAddRow
            // 
            this.tssAddRow.Name = "tssAddRow";
            this.tssAddRow.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAddRow
            // 
            this.BtnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddRow.Image")));
            this.BtnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddRow.Name = "BtnAddRow";
            this.BtnAddRow.Size = new System.Drawing.Size(49, 22);
            this.BtnAddRow.Text = "增行";
            this.BtnAddRow.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // BtnDeleteRow
            // 
            this.BtnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeleteRow.Image")));
            this.BtnDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDeleteRow.Name = "BtnDeleteRow";
            this.BtnDeleteRow.Size = new System.Drawing.Size(49, 22);
            this.BtnDeleteRow.Text = "删行";
            this.BtnDeleteRow.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // tssPrint
            // 
            this.tssPrint.Name = "tssPrint";
            this.tssPrint.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnPrint
            // 
            this.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(33, 22);
            this.BtnPrint.Text = "打印";
            this.BtnPrint.Visible = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcel.Image")));
            this.BtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(79, 22);
            this.BtnExcel.Text = "导出Excel";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // tssUpLoad
            // 
            this.tssUpLoad.Name = "tssUpLoad";
            this.tssUpLoad.Size = new System.Drawing.Size(6, 25);
            this.tssUpLoad.Visible = false;
            // 
            // BtnUpLoad
            // 
            this.BtnUpLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpLoad.Image")));
            this.BtnUpLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUpLoad.Name = "BtnUpLoad";
            this.BtnUpLoad.Size = new System.Drawing.Size(49, 22);
            this.BtnUpLoad.Text = "提交";
            this.BtnUpLoad.Click += new System.EventHandler(this.BtnUpLoad_Click);
            // 
            // BtnUnUpLoad
            // 
            this.BtnUnUpLoad.Image = global::FrmLookUp.Properties.Resources.undo;
            this.BtnUnUpLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUnUpLoad.Name = "BtnUnUpLoad";
            this.BtnUnUpLoad.Size = new System.Drawing.Size(49, 22);
            this.BtnUnUpLoad.Text = "收回";
            this.BtnUnUpLoad.Click += new System.EventHandler(this.BtnUpCancel_Click);
            // 
            // tssAudit
            // 
            this.tssAudit.Name = "tssAudit";
            this.tssAudit.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAudit
            // 
            this.BtnAudit.Image = ((System.Drawing.Image)(resources.GetObject("BtnAudit.Image")));
            this.BtnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAudit.Name = "BtnAudit";
            this.BtnAudit.Size = new System.Drawing.Size(49, 22);
            this.BtnAudit.Text = "审核";
            this.BtnAudit.Click += new System.EventHandler(this.BtnAudit_Click);
            // 
            // BtnUnAudit
            // 
            this.BtnUnAudit.Image = ((System.Drawing.Image)(resources.GetObject("BtnUnAudit.Image")));
            this.BtnUnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUnAudit.Name = "BtnUnAudit";
            this.BtnUnAudit.Size = new System.Drawing.Size(49, 22);
            this.BtnUnAudit.Text = "弃审";
            this.BtnUnAudit.Click += new System.EventHandler(this.BtnUnAudit_Click);
            // 
            // BtnAuditList
            // 
            this.BtnAuditList.Image = ((System.Drawing.Image)(resources.GetObject("BtnAuditList.Image")));
            this.BtnAuditList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAuditList.Name = "BtnAuditList";
            this.BtnAuditList.Size = new System.Drawing.Size(73, 22);
            this.BtnAuditList.Text = "审核列表";
            this.BtnAuditList.Visible = false;
            this.BtnAuditList.Click += new System.EventHandler(this.BtnAuditList_Click);
            // 
            // tssFirst
            // 
            this.tssFirst.Name = "tssFirst";
            this.tssFirst.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(23, 22);
            this.btnFirst.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(23, 22);
            this.btnPreview.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Visible = false;
            // 
            // btnEnd
            // 
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(23, 22);
            this.btnEnd.Visible = false;
            // 
            // tssLocation
            // 
            this.tssLocation.Name = "tssLocation";
            this.tssLocation.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnLocation
            // 
            this.BtnLocation.Image = ((System.Drawing.Image)(resources.GetObject("BtnLocation.Image")));
            this.BtnLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLocation.Name = "BtnLocation";
            this.BtnLocation.Size = new System.Drawing.Size(49, 20);
            this.BtnLocation.Text = "定位";
            this.BtnLocation.Click += new System.EventHandler(this.BtnLocation_Click);
            // 
            // tssExit
            // 
            this.tssExit.Name = "tssExit";
            this.tssExit.Size = new System.Drawing.Size(6, 25);
            this.tssExit.Visible = false;
            // 
            // BtnExit
            // 
            this.BtnExit.Image = ((System.Drawing.Image)(resources.GetObject("BtnExit.Image")));
            this.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(49, 20);
            this.BtnExit.Text = "退出";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // baoBtnSelect
            // 
            this.baoBtnSelect.BaoBtnCaption = "选择";
            this.baoBtnSelect.BaoClickClose = false;
            this.baoBtnSelect.BaoColumnsWidth = null;
            this.baoBtnSelect.BaoDataAccDLLFullPath = "";
            this.baoBtnSelect.BaoFullClassName = "";
            this.baoBtnSelect.BaoSQL = "";
            this.baoBtnSelect.BaoTitleNames = null;
            this.baoBtnSelect.FrmHigth = 0;
            this.baoBtnSelect.FrmTitle = null;
            this.baoBtnSelect.FrmWidth = 0;
            this.baoBtnSelect.IsShowInTaskBar = false;
            this.baoBtnSelect.Location = new System.Drawing.Point(635, 2);
            this.baoBtnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.baoBtnSelect.Name = "baoBtnSelect";
            this.baoBtnSelect.Size = new System.Drawing.Size(38, 22);
            this.baoBtnSelect.TabIndex = 0;
            this.baoBtnSelect.Visible = false;
            this.baoBtnSelect.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoBtnSelect_OnLookUpClosed);
            // 
            // ToolBarBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.baoBtnSelect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ToolBarBill";
            this.Size = new System.Drawing.Size(974, 22);
            this.Load += new System.EventHandler(this.ToolBarBill_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BaoButton baoBtnSelect;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator tssAdd;
        private System.Windows.Forms.ToolStripSeparator tssExit;
        private System.Windows.Forms.ToolStripButton BtnExit;
        public System.Windows.Forms.ToolStripButton BtnAddNew;
        public System.Windows.Forms.ToolStripButton BtnModify;
        public System.Windows.Forms.ToolStripButton BtnDelete;
        public System.Windows.Forms.ToolStripSeparator tssRefresh;
        public System.Windows.Forms.ToolStripButton BtnRefresh;
        public System.Windows.Forms.ToolStripButton BtnSave;
        public System.Windows.Forms.ToolStripButton BtnCancel;
        public System.Windows.Forms.ToolStripSeparator tssAddRow;
        public System.Windows.Forms.ToolStripButton BtnAddRow;
        public System.Windows.Forms.ToolStripButton BtnDeleteRow;
        public System.Windows.Forms.ToolStripSeparator tssPrint;
        public System.Windows.Forms.ToolStripButton BtnPrint;
        public System.Windows.Forms.ToolStripSeparator tssUpLoad;
        public System.Windows.Forms.ToolStripButton BtnAudit;
        public System.Windows.Forms.ToolStripButton btnFirst;
        public System.Windows.Forms.ToolStripButton btnPreview;
        public System.Windows.Forms.ToolStripButton btnNext;
        public System.Windows.Forms.ToolStripButton btnEnd;
        public System.Windows.Forms.ToolStripSeparator tssLocation;
        public System.Windows.Forms.ToolStripButton BtnLocation;
        public System.Windows.Forms.ToolStripButton BtnUnAudit;
        public System.Windows.Forms.ToolStripButton BtnAuditList;
        public System.Windows.Forms.ToolStripSeparator tssFirst;
        public System.Windows.Forms.ToolStripButton BtnExcel;
        public System.Windows.Forms.ToolStripButton BtnUpLoad;
        public System.Windows.Forms.ToolStripButton BtnUnUpLoad;
        public System.Windows.Forms.ToolStripSeparator tssAudit;


    }
}
