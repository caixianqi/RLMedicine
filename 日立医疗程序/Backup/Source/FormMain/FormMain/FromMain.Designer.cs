namespace FormMain
{
    partial class FromMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromMain));
            this.cmRep = new System.Windows.Forms.ContextMenu();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemMsg = new System.Windows.Forms.MenuItem();
            this.menuItemMsgSend = new System.Windows.Forms.MenuItem();
            this.menuItemMsgView = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mItemUser_Update = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LabVersion = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblShop = new System.Windows.Forms.Label();
            this.pictureBoxMsgHint = new System.Windows.Forms.PictureBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainTab = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.BillList = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmRep
            // 
            this.cmRep.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem12,
            this.menuItem13});
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "查询";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "修改";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "删除";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemMsg,
            this.menuItem2,
            this.menuItem14,
            this.menuItem6,
            this.menuItem3,
            this.menuItem16});
            // 
            // menuItemMsg
            // 
            this.menuItemMsg.Index = 0;
            this.menuItemMsg.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemMsgSend,
            this.menuItemMsgView});
            this.menuItemMsg.Text = "消息";
            this.menuItemMsg.Visible = false;
            // 
            // menuItemMsgSend
            // 
            this.menuItemMsgSend.Index = 0;
            this.menuItemMsgSend.Text = "发送消息";
            // 
            // menuItemMsgView
            // 
            this.menuItemMsgView.Index = 1;
            this.menuItemMsgView.Text = "查看消息";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mItemUser_Update,
            this.menuItem17});
            this.menuItem2.Text = "设置";
            // 
            // mItemUser_Update
            // 
            this.mItemUser_Update.Index = 0;
            this.mItemUser_Update.Text = "用户修改";
            this.mItemUser_Update.Click += new System.EventHandler(this.mItemUser_Update_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.Text = "个人消息中心";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem15});
            this.menuItem14.Text = "修改背景";
            this.menuItem14.Visible = false;
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "选择图片";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "恢复默认图片";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9});
            this.menuItem6.Text = "帮助";
            this.menuItem6.Visible = false;
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "文档";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "关于...";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "重注册";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 5;
            this.menuItem16.Text = "退出";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(207)))), ((int)(((byte)(189)))));
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Controls.Add(this.label2);
            this.pnl.Controls.Add(this.LabVersion);
            this.pnl.Controls.Add(this.LblDate);
            this.pnl.Controls.Add(this.LblShop);
            this.pnl.Controls.Add(this.pictureBoxMsgHint);
            this.pnl.Controls.Add(this.LblUser);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnl.Location = new System.Drawing.Point(0, 441);
            this.pnl.Margin = new System.Windows.Forms.Padding(2);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(619, 25);
            this.pnl.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(344, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 4;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabVersion
            // 
            this.LabVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LabVersion.Location = new System.Drawing.Point(273, 0);
            this.LabVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabVersion.Name = "LabVersion";
            this.LabVersion.Size = new System.Drawing.Size(112, 23);
            this.LabVersion.TabIndex = 3;
            this.LabVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblDate
            // 
            this.LblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblDate.Location = new System.Drawing.Point(385, 0);
            this.LblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(232, 23);
            this.LblDate.TabIndex = 2;
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblShop
            // 
            this.LblShop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblShop.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblShop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblShop.Location = new System.Drawing.Point(168, 0);
            this.LblShop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblShop.Name = "LblShop";
            this.LblShop.Size = new System.Drawing.Size(176, 23);
            this.LblShop.TabIndex = 1;
            this.LblShop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxMsgHint
            // 
            this.pictureBoxMsgHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.pictureBoxMsgHint.Location = new System.Drawing.Point(525, 0);
            this.pictureBoxMsgHint.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMsgHint.Name = "pictureBoxMsgHint";
            this.pictureBoxMsgHint.Size = new System.Drawing.Size(40, 22);
            this.pictureBoxMsgHint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMsgHint.TabIndex = 9;
            this.pictureBoxMsgHint.TabStop = false;
            this.pictureBoxMsgHint.Visible = false;
            // 
            // LblUser
            // 
            this.LblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblUser.Location = new System.Drawing.Point(0, 0);
            this.LblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(168, 23);
            this.LblUser.TabIndex = 0;
            this.LblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 36);
            this.panel1.TabIndex = 25;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MainTab
            // 
            this.MainTab.MdiParent = this;
            this.MainTab.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            // 
            // BillList
            // 
            this.BillList.ActiveGroup = null;
            this.BillList.Dock = System.Windows.Forms.DockStyle.Left;
            this.BillList.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3});
            this.BillList.Location = new System.Drawing.Point(0, 36);
            this.BillList.Margin = new System.Windows.Forms.Padding(2);
            this.BillList.Name = "BillList";
            this.BillList.Size = new System.Drawing.Size(172, 405);
            this.BillList.TabIndex = 28;
            this.BillList.Text = "navBarControl1";
            this.BillList.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.BillList_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "ssss";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "navBarItem2";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "navBarItem3";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(172, 36);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(2);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 405);
            this.splitterControl1.TabIndex = 29;
            this.splitterControl1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(185)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(619, 466);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.BillList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Menu = this.mainMenu1;
            this.Name = "FromMain";
            this.Text = "日立医疗（广州）有限公司售后服务系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FromMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromMain_FormClosing);
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenu cmRep;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemMsg;
        private System.Windows.Forms.MenuItem menuItemMsgSend;
        private System.Windows.Forms.MenuItem menuItemMsgView;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabVersion;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblShop;
        private System.Windows.Forms.PictureBox pictureBoxMsgHint;
        private System.Windows.Forms.Label LblUser;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MainTab;
        private DevExpress.XtraNavBar.NavBarControl BillList;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private System.Windows.Forms.MenuItem mItemUser_Update;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
    }
}