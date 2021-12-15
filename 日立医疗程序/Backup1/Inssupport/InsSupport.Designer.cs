namespace Inssupport
{
    partial class InsSupport
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsSupport));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssAdd = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAddNew = new System.Windows.Forms.ToolStripButton();
            this.BtnModify = new System.Windows.Forms.ToolStripButton();
            this.Btndel = new System.Windows.Forms.ToolStripButton();
            this.tssRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tssAddRow = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAudit = new System.Windows.Forms.ToolStripButton();
            this.BtnUnAudit = new System.Windows.Forms.ToolStripButton();
            this.tssAudit = new System.Windows.Forms.ToolStripSeparator();
            this.BtnLocation = new System.Windows.Forms.ToolStripButton();
            this.BtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.BtnExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbsReqName = new System.Windows.Forms.TextBox();
            this.sRegnCode = new System.Windows.Forms.TextBox();
            this.tbsRegName = new FrmLookUp.ButtonEdit();
            this.tbsSupCode = new System.Windows.Forms.TextBox();
            this.tbsReqName2 = new FrmLookUp.ButtonEdit();
            this.tbsReqDep = new FrmLookUp.ButtonEdit();
            this.dtsInputdate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbsRecManger = new FrmLookUp.ButtonEdit();
            this.tbsRecMangerName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtsEndTime = new System.Windows.Forms.DateTimePicker();
            this.tbsContent = new System.Windows.Forms.RichTextBox();
            this.tbsSuppersonName = new System.Windows.Forms.TextBox();
            this.tbsSupperson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtsStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.baoButton3 = new FrmLookUp.RiLiButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.Btndel,
            this.tssRefresh,
            this.BtnSave,
            this.BtnCancel,
            this.tssAddRow,
            this.BtnAudit,
            this.BtnUnAudit,
            this.tssAudit,
            this.BtnLocation,
            this.BtnRefresh,
            this.BtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(869, 25);
            this.toolStrip1.TabIndex = 75;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tssAdd
            // 
            this.tssAdd.Name = "tssAdd";
            this.tssAdd.Size = new System.Drawing.Size(6, 25);
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
            // Btndel
            // 
            this.Btndel.Image = ((System.Drawing.Image)(resources.GetObject("Btndel.Image")));
            this.Btndel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btndel.Name = "Btndel";
            this.Btndel.Size = new System.Drawing.Size(52, 22);
            this.Btndel.Text = "删除";
            this.Btndel.Click += new System.EventHandler(this.Btndel_Click);
            // 
            // tssRefresh
            // 
            this.tssRefresh.Name = "tssRefresh";
            this.tssRefresh.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(52, 22);
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(52, 22);
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tssAddRow
            // 
            this.tssAddRow.Name = "tssAddRow";
            this.tssAddRow.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAudit
            // 
            this.BtnAudit.Image = ((System.Drawing.Image)(resources.GetObject("BtnAudit.Image")));
            this.BtnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAudit.Name = "BtnAudit";
            this.BtnAudit.Size = new System.Drawing.Size(52, 22);
            this.BtnAudit.Text = "审核";
            this.BtnAudit.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // BtnUnAudit
            // 
            this.BtnUnAudit.Image = ((System.Drawing.Image)(resources.GetObject("BtnUnAudit.Image")));
            this.BtnUnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUnAudit.Name = "BtnUnAudit";
            this.BtnUnAudit.Size = new System.Drawing.Size(52, 22);
            this.BtnUnAudit.Text = "弃审";
            this.BtnUnAudit.Click += new System.EventHandler(this.BtnUnAudit_Click);
            // 
            // tssAudit
            // 
            this.tssAudit.Name = "tssAudit";
            this.tssAudit.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnLocation
            // 
            this.BtnLocation.Image = ((System.Drawing.Image)(resources.GetObject("BtnLocation.Image")));
            this.BtnLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLocation.Name = "BtnLocation";
            this.BtnLocation.Size = new System.Drawing.Size(52, 22);
            this.BtnLocation.Text = "定位";
            this.BtnLocation.Click += new System.EventHandler(this.BtnLocation_Click);
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
            this.panel1.Controls.Add(this.tbsReqName);
            this.panel1.Controls.Add(this.sRegnCode);
            this.panel1.Controls.Add(this.tbsRegName);
            this.panel1.Controls.Add(this.tbsSupCode);
            this.panel1.Controls.Add(this.tbsReqName2);
            this.panel1.Controls.Add(this.tbsReqDep);
            this.panel1.Controls.Add(this.dtsInputdate);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbsRecManger);
            this.panel1.Controls.Add(this.tbsRecMangerName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtsEndTime);
            this.panel1.Controls.Add(this.tbsContent);
            this.panel1.Controls.Add(this.tbsSuppersonName);
            this.panel1.Controls.Add(this.tbsSupperson);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtsStartTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 390);
            this.panel1.TabIndex = 76;
            // 
            // tbsReqName
            // 
            this.tbsReqName.Location = new System.Drawing.Point(470, 53);
            this.tbsReqName.Name = "tbsReqName";
            this.tbsReqName.Size = new System.Drawing.Size(111, 21);
            this.tbsReqName.TabIndex = 75;
            // 
            // sRegnCode
            // 
            this.sRegnCode.Location = new System.Drawing.Point(281, 94);
            this.sRegnCode.Name = "sRegnCode";
            this.sRegnCode.Size = new System.Drawing.Size(100, 21);
            this.sRegnCode.TabIndex = 74;
            this.sRegnCode.Visible = false;
            // 
            // tbsRegName
            // 
            this.tbsRegName.BaoBtnCaption = "";
            this.tbsRegName.BaoClickClose = false;
            this.tbsRegName.BaoColumnsWidth = null;
            this.tbsRegName.BaoDataAccDLLFullPath = "";
            this.tbsRegName.BaoFullClassName = "";
            this.tbsRegName.BaoSQL = "";
            this.tbsRegName.BaoTitleNames = null;
            this.tbsRegName.CodeValue = null;
            this.tbsRegName.DecideSql = "";
            this.tbsRegName.FrmHigth = 0;
            this.tbsRegName.FrmTitle = null;
            this.tbsRegName.FrmWidth = 0;
            this.tbsRegName.IsShowInTaskBar = false;
            this.tbsRegName.Location = new System.Drawing.Point(74, 53);
            this.tbsRegName.Name = "tbsRegName";
            this.tbsRegName.Size = new System.Drawing.Size(120, 21);
            this.tbsRegName.TabIndex = 73;
            this.tbsRegName.Tag = "9999";
            this.tbsRegName.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.tbsRegName_OnLookUpClosed);
            // 
            // tbsSupCode
            // 
            this.tbsSupCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbsSupCode.Location = new System.Drawing.Point(74, 12);
            this.tbsSupCode.Name = "tbsSupCode";
            this.tbsSupCode.ReadOnly = true;
            this.tbsSupCode.Size = new System.Drawing.Size(120, 21);
            this.tbsSupCode.TabIndex = 72;
            // 
            // tbsReqName2
            // 
            this.tbsReqName2.BaoBtnCaption = "";
            this.tbsReqName2.BaoClickClose = true;
            this.tbsReqName2.BaoColumnsWidth = null;
            this.tbsReqName2.BaoDataAccDLLFullPath = "";
            this.tbsReqName2.BaoFullClassName = "";
            this.tbsReqName2.BaoSQL = "";
            this.tbsReqName2.BaoTitleNames = null;
            this.tbsReqName2.CodeValue = null;
            this.tbsReqName2.DecideSql = "";
            this.tbsReqName2.FrmHigth = 0;
            this.tbsReqName2.FrmTitle = null;
            this.tbsReqName2.FrmWidth = 0;
            this.tbsReqName2.IsShowInTaskBar = false;
            this.tbsReqName2.Location = new System.Drawing.Point(470, 94);
            this.tbsReqName2.Name = "tbsReqName2";
            this.tbsReqName2.Size = new System.Drawing.Size(111, 21);
            this.tbsReqName2.TabIndex = 71;
            this.tbsReqName2.Tag = "99999";
            this.tbsReqName2.Visible = false;
            this.tbsReqName2.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.buttonEdit3_OnLookUpClosed);
            // 
            // tbsReqDep
            // 
            this.tbsReqDep.BaoBtnCaption = "";
            this.tbsReqDep.BaoClickClose = true;
            this.tbsReqDep.BaoColumnsWidth = null;
            this.tbsReqDep.BaoDataAccDLLFullPath = "";
            this.tbsReqDep.BaoFullClassName = "";
            this.tbsReqDep.BaoSQL = "";
            this.tbsReqDep.BaoTitleNames = null;
            this.tbsReqDep.CodeValue = null;
            this.tbsReqDep.DecideSql = "";
            this.tbsReqDep.FrmHigth = 0;
            this.tbsReqDep.FrmTitle = null;
            this.tbsReqDep.FrmWidth = 0;
            this.tbsReqDep.IsShowInTaskBar = false;
            this.tbsReqDep.Location = new System.Drawing.Point(281, 53);
            this.tbsReqDep.Name = "tbsReqDep";
            this.tbsReqDep.Size = new System.Drawing.Size(111, 21);
            this.tbsReqDep.TabIndex = 70;
            this.tbsReqDep.Tag = "99999";
            this.tbsReqDep.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.buttonEdit2_OnLookUpClosed);
            // 
            // dtsInputdate
            // 
            this.dtsInputdate.Enabled = false;
            this.dtsInputdate.Location = new System.Drawing.Point(656, 282);
            this.dtsInputdate.Name = "dtsInputdate";
            this.dtsInputdate.Size = new System.Drawing.Size(134, 21);
            this.dtsInputdate.TabIndex = 69;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 68;
            this.label12.Text = "提交日期";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(480, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbsRecManger
            // 
            this.tbsRecManger.BaoBtnCaption = "";
            this.tbsRecManger.BaoClickClose = true;
            this.tbsRecManger.BaoColumnsWidth = null;
            this.tbsRecManger.BaoDataAccDLLFullPath = "";
            this.tbsRecManger.BaoFullClassName = "";
            this.tbsRecManger.BaoSQL = "";
            this.tbsRecManger.BaoTitleNames = null;
            this.tbsRecManger.CodeValue = null;
            this.tbsRecManger.DecideSql = "";
            this.tbsRecManger.FrmHigth = 0;
            this.tbsRecManger.FrmTitle = null;
            this.tbsRecManger.FrmWidth = 0;
            this.tbsRecManger.IsShowInTaskBar = false;
            this.tbsRecManger.Location = new System.Drawing.Point(106, 282);
            this.tbsRecManger.Name = "tbsRecManger";
            this.tbsRecManger.Size = new System.Drawing.Size(112, 21);
            this.tbsRecManger.TabIndex = 66;
            this.tbsRecManger.Tag = "99999";
            this.tbsRecManger.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.Manager_be_OnLookUpClosed);
            // 
            // tbsRecMangerName
            // 
            this.tbsRecMangerName.BackColor = System.Drawing.SystemColors.Window;
            this.tbsRecMangerName.Location = new System.Drawing.Point(336, 282);
            this.tbsRecMangerName.Name = "tbsRecMangerName";
            this.tbsRecMangerName.ReadOnly = true;
            this.tbsRecMangerName.Size = new System.Drawing.Size(100, 21);
            this.tbsRecMangerName.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 64;
            this.label11.Text = "审核经理姓名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "审核经理编号";
            // 
            // dtsEndTime
            // 
            this.dtsEndTime.Location = new System.Drawing.Point(659, 53);
            this.dtsEndTime.Name = "dtsEndTime";
            this.dtsEndTime.Size = new System.Drawing.Size(131, 21);
            this.dtsEndTime.TabIndex = 62;
            // 
            // tbsContent
            // 
            this.tbsContent.Location = new System.Drawing.Point(17, 125);
            this.tbsContent.Name = "tbsContent";
            this.tbsContent.Size = new System.Drawing.Size(773, 127);
            this.tbsContent.TabIndex = 61;
            this.tbsContent.Text = "";
            // 
            // tbsSuppersonName
            // 
            this.tbsSuppersonName.BackColor = System.Drawing.SystemColors.Window;
            this.tbsSuppersonName.Location = new System.Drawing.Point(470, 12);
            this.tbsSuppersonName.Name = "tbsSuppersonName";
            this.tbsSuppersonName.ReadOnly = true;
            this.tbsSuppersonName.Size = new System.Drawing.Size(109, 21);
            this.tbsSuppersonName.TabIndex = 57;
            // 
            // tbsSupperson
            // 
            this.tbsSupperson.BackColor = System.Drawing.SystemColors.Window;
            this.tbsSupperson.Location = new System.Drawing.Point(281, 12);
            this.tbsSupperson.Name = "tbsSupperson";
            this.tbsSupperson.ReadOnly = true;
            this.tbsSupperson.Size = new System.Drawing.Size(111, 21);
            this.tbsSupperson.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "工程师姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "任务编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(588, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "结束日期 ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(587, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "开始日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "申请人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "任务详情";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "申请部门";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "区域";
            // 
            // dtsStartTime
            // 
            this.dtsStartTime.Location = new System.Drawing.Point(659, 12);
            this.dtsStartTime.Name = "dtsStartTime";
            this.dtsStartTime.Size = new System.Drawing.Size(131, 21);
            this.dtsStartTime.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "工程师编号";
            // 
            // baoButton3
            // 
            this.baoButton3.BaoBtnCaption = "…";
            this.baoButton3.BaoClickClose = true;
            this.baoButton3.BaoColumnsWidth = null;
            this.baoButton3.BaoDataAccDLLFullPath = "";
            this.baoButton3.BaoFullClassName = "";
            this.baoButton3.BaoSQL = "";
            this.baoButton3.BaoTitleNames = null;
            this.baoButton3.FrmHigth = 0;
            this.baoButton3.FrmTitle = null;
            this.baoButton3.FrmWidth = 0;
            this.baoButton3.IsShowInTaskBar = false;
            this.baoButton3.Location = new System.Drawing.Point(706, -2);
            this.baoButton3.Margin = new System.Windows.Forms.Padding(2);
            this.baoButton3.Name = "baoButton3";
            this.baoButton3.Size = new System.Drawing.Size(60, 22);
            this.baoButton3.TabIndex = 79;
            this.baoButton3.Visible = false;
            this.baoButton3.OnLookUpClosed += new FrmLookUp.RiLiButton.LookUpClosed(this.baoButton3_OnLookUpClosed);
            // 
            // InsSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 415);
            this.Controls.Add(this.baoButton3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "InsSupport";
            this.Text = "销售支持";
            this.Load += new System.EventHandler(this.InsSupport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InsSupport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator tssAdd;
        public System.Windows.Forms.ToolStripButton BtnAddNew;
        public System.Windows.Forms.ToolStripButton BtnModify;
        public System.Windows.Forms.ToolStripButton Btndel;
        public System.Windows.Forms.ToolStripSeparator tssRefresh;
        public System.Windows.Forms.ToolStripButton BtnSave;
        public System.Windows.Forms.ToolStripButton BtnCancel;
        public System.Windows.Forms.ToolStripSeparator tssAudit;
        public System.Windows.Forms.ToolStripButton BtnAudit;
        public System.Windows.Forms.ToolStripButton BtnUnAudit;
        private System.Windows.Forms.ToolStripButton BtnExit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripSeparator tssAddRow;
        private FrmLookUp.RiLiButton baoButton3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtsStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbsSuppersonName;
        private System.Windows.Forms.TextBox tbsSupperson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtsInputdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private FrmLookUp.ButtonEdit tbsRecManger;
        private System.Windows.Forms.TextBox tbsRecMangerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtsEndTime;
        private System.Windows.Forms.RichTextBox tbsContent;
        private FrmLookUp.ButtonEdit tbsReqDep;
        private FrmLookUp.ButtonEdit tbsReqName2;
        private System.Windows.Forms.TextBox tbsSupCode;
        public System.Windows.Forms.ToolStripButton BtnLocation;
        private FrmLookUp.ButtonEdit tbsRegName;
        public System.Windows.Forms.ToolStripButton BtnRefresh;
        private System.Windows.Forms.TextBox sRegnCode;
        private System.Windows.Forms.TextBox tbsReqName;

    }
}

