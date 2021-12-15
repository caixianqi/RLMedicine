namespace FormMain.Login
{
    partial class FrmUserManager
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
            this.TSMExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeptAttribute = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDeptName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.ButtonEditDept = new FrmLookUp.ButtonEdit();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.baoButton1 = new FrmLookUp.BaoButton();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.labMemo = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TSMSave = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMState = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMState1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TSMExit
            // 
            this.TSMExit.Name = "TSMExit";
            this.TSMExit.Size = new System.Drawing.Size(41, 20);
            this.TSMExit.Text = "退出";
            this.TSMExit.Click += new System.EventHandler(this.TSMExit_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 180);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(751, 149);
            this.gridControl1.TabIndex = 29;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn6, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "AutoUserID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "用户名";
            this.gridColumn2.FieldName = "UserId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.SummaryItem.DisplayFormat = "记录数:{0}";
            this.gridColumn2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 171;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "用户名称";
            this.gridColumn3.FieldName = "UserName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 171;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "用户密码";
            this.gridColumn4.FieldName = "Password";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "状态";
            this.gridColumn5.FieldName = "State";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 171;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "备注";
            this.gridColumn6.FieldName = "Memo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 217;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "部门";
            this.gridColumn7.FieldName = "DeptName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 127;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DeptAttribute);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDeptName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxAdmin);
            this.panel1.Controls.Add(this.ButtonEditDept);
            this.panel1.Controls.Add(this.txtMemo);
            this.panel1.Controls.Add(this.baoButton1);
            this.panel1.Controls.Add(this.cbxMemo);
            this.panel1.Controls.Add(this.labMemo);
            this.panel1.Controls.Add(this.labID);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.labName);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 156);
            this.panel1.TabIndex = 28;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cStatus
            // 
            this.cStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cStatus.FormattingEnabled = true;
            this.cStatus.Items.AddRange(new object[] {
            "正常",
            "已封存"});
            this.cStatus.Location = new System.Drawing.Point(431, 72);
            this.cStatus.Name = "cStatus";
            this.cStatus.Size = new System.Drawing.Size(100, 20);
            this.cStatus.TabIndex = 34;
            this.cStatus.SelectedIndexChanged += new System.EventHandler(this.cStatus_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(390, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 33;
            this.label5.Text = "状态";
            // 
            // DeptAttribute
            // 
            this.DeptAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeptAttribute.FormattingEnabled = true;
            this.DeptAttribute.Location = new System.Drawing.Point(615, 37);
            this.DeptAttribute.Name = "DeptAttribute";
            this.DeptAttribute.Size = new System.Drawing.Size(121, 20);
            this.DeptAttribute.TabIndex = 32;
            this.DeptAttribute.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(546, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "所属部门";
            // 
            // textBoxDeptName
            // 
            this.textBoxDeptName.Location = new System.Drawing.Point(431, 39);
            this.textBoxDeptName.Name = "textBoxDeptName";
            this.textBoxDeptName.Size = new System.Drawing.Size(100, 21);
            this.textBoxDeptName.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(372, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "部门名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(201, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "部门编码";
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.checkBoxAdmin.Location = new System.Drawing.Point(267, 77);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(96, 18);
            this.checkBoxAdmin.TabIndex = 27;
            this.checkBoxAdmin.Text = "是否管理员";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // ButtonEditDept
            // 
            this.ButtonEditDept.BaoBtnCaption = "";
            this.ButtonEditDept.BaoClickClose = false;
            this.ButtonEditDept.BaoColumnsWidth = null;
            this.ButtonEditDept.BaoDataAccDLLFullPath = "";
            this.ButtonEditDept.BaoFullClassName = "";
            this.ButtonEditDept.BaoSQL = "";
            this.ButtonEditDept.BaoTitleNames = null;
            this.ButtonEditDept.CodeValue = null;
            this.ButtonEditDept.DecideSql = "";
            this.ButtonEditDept.FrmHigth = 0;
            this.ButtonEditDept.FrmTitle = null;
            this.ButtonEditDept.FrmWidth = 0;
            this.ButtonEditDept.IsShowInTaskBar = false;
            this.ButtonEditDept.Location = new System.Drawing.Point(267, 37);
            this.ButtonEditDept.Name = "ButtonEditDept";
            this.ButtonEditDept.Size = new System.Drawing.Size(100, 21);
            this.ButtonEditDept.TabIndex = 26;
            this.ButtonEditDept.Tag = "9999";
            this.ButtonEditDept.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.ButtonEditDept_OnLookUpClosed);
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.White;
            this.txtMemo.Location = new System.Drawing.Point(109, 39);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(80, 21);
            this.txtMemo.TabIndex = 23;
            this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemo_KeyPress);
            // 
            // baoButton1
            // 
            this.baoButton1.BaoBtnCaption = "...";
            this.baoButton1.BaoClickClose = false;
            this.baoButton1.BaoColumnsWidth = null;
            this.baoButton1.BaoDataAccDLLFullPath = "";
            this.baoButton1.BaoFullClassName = "";
            this.baoButton1.BaoSQL = "";
            this.baoButton1.BaoTitleNames = null;
            this.baoButton1.FrmHigth = 0;
            this.baoButton1.FrmTitle = null;
            this.baoButton1.FrmWidth = 0;
            this.baoButton1.IsShowInTaskBar = false;
            this.baoButton1.Location = new System.Drawing.Point(175, 10);
            this.baoButton1.Margin = new System.Windows.Forms.Padding(2);
            this.baoButton1.Name = "baoButton1";
            this.baoButton1.Size = new System.Drawing.Size(29, 22);
            this.baoButton1.TabIndex = 25;
            this.baoButton1.OnLookUpClosed += new FrmLookUp.BaoButton.LookUpClosed(this.baoButton1_OnLookUpClosed);
            // 
            // cbxMemo
            // 
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Items.AddRange(new object[] {
            "",
            "操作员",
            "系统管理员",
            "其他"});
            this.cbxMemo.Location = new System.Drawing.Point(109, 74);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(84, 20);
            this.cbxMemo.TabIndex = 24;
            this.cbxMemo.Visible = false;
            // 
            // labMemo
            // 
            this.labMemo.AutoSize = true;
            this.labMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMemo.Location = new System.Drawing.Point(61, 37);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(35, 14);
            this.labMemo.TabIndex = 22;
            this.labMemo.Text = "邮箱";
            this.labMemo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labID.Location = new System.Drawing.Point(43, 17);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(63, 14);
            this.labID.TabIndex = 16;
            this.labID.Text = "用户编码";
            this.labID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(109, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(68, 21);
            this.txtUser.TabIndex = 18;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.Location = new System.Drawing.Point(201, 13);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(63, 14);
            this.labName.TabIndex = 17;
            this.labName.Text = "用户名称";
            this.labName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(431, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(267, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 19;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(372, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "用户密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TSMSave
            // 
            this.TSMSave.Name = "TSMSave";
            this.TSMSave.Size = new System.Drawing.Size(41, 20);
            this.TSMSave.Text = "保存";
            this.TSMSave.Click += new System.EventHandler(this.TSMSave_Click);
            // 
            // TSMDelete
            // 
            this.TSMDelete.Name = "TSMDelete";
            this.TSMDelete.Size = new System.Drawing.Size(41, 20);
            this.TSMDelete.Text = "删除";
            this.TSMDelete.Click += new System.EventHandler(this.TSMDelete_Click);
            // 
            // TSMNew
            // 
            this.TSMNew.Name = "TSMNew";
            this.TSMNew.Size = new System.Drawing.Size(41, 20);
            this.TSMNew.Text = "新增";
            this.TSMNew.Click += new System.EventHandler(this.TSMNew_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMNew,
            this.TSMUpdate,
            this.TSMDelete,
            this.TSMSave,
            this.TSMState,
            this.TSMState1,
            this.TSMExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMUpdate
            // 
            this.TSMUpdate.Name = "TSMUpdate";
            this.TSMUpdate.Size = new System.Drawing.Size(41, 20);
            this.TSMUpdate.Text = "修改";
            this.TSMUpdate.Click += new System.EventHandler(this.TSMUpdate_Click);
            // 
            // TSMState
            // 
            this.TSMState.Name = "TSMState";
            this.TSMState.Size = new System.Drawing.Size(41, 20);
            this.TSMState.Text = "封存";
            this.TSMState.Click += new System.EventHandler(this.TSMState_Click);
            // 
            // TSMState1
            // 
            this.TSMState1.Name = "TSMState1";
            this.TSMState1.Size = new System.Drawing.Size(41, 20);
            this.TSMState1.Text = "解封";
            this.TSMState1.Click += new System.EventHandler(this.TSMState1_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "所属部门";
            this.gridColumn8.FieldName = "DeptAttribute";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 125;
            // 
            // FrmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 329);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FrmUserManager";
            this.Text = "管理用户";
            this.Load += new System.EventHandler(this.FrmUserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem TSMExit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem TSMSave;
        private System.Windows.Forms.ToolStripMenuItem TSMDelete;
        private System.Windows.Forms.ToolStripMenuItem TSMNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMState;
        private System.Windows.Forms.ToolStripMenuItem TSMState1;
        private System.Windows.Forms.ToolStripMenuItem TSMUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label labMemo;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.ComboBox cbxMemo;
        private FrmLookUp.BaoButton baoButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private FrmLookUp.ButtonEdit ButtonEditDept;
        private System.Windows.Forms.TextBox textBoxDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DeptAttribute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}