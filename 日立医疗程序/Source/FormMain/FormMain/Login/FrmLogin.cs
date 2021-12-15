using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using UFBaseLib.BusLib;


namespace FormMain
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class FrmLogin : System.Windows.Forms.Form
	{
        /// <summary>
        ///  登录 SQL 处理
        /// </summary>
        FormMain.LoginBAL.LoginBL bl = new FormMain.LoginBAL.LoginBL(); 

		private System.Windows.Forms.Label labUser;
		private System.Windows.Forms.Label labName;
		private System.Windows.Forms.TextBox txtPassWord;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUser;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;

        /// <summary>
        /// 登录是否成功！
        /// </summary>
        public static bool IsLogin = false;

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserID = string.Empty;

        /// <summary>
        /// 用户密码
        /// </summary>
        public static string PassWord = string.Empty;

        /// <summary>
        /// 未加密的用户密码
        /// </summary>
        public static string txtPwd = string.Empty;

        public static int LoginState;  //0：登陆错误，1：登陆成功，2：取消

        DataTable dtLogin;
        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox cboU8DataBase;

		//private MainForm mf=null;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public FrmLogin()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//WorkFlow.util.UiUtils.InitUI(this);
			//this.mf=mf;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboU8DataBase = new System.Windows.Forms.ComboBox();
            this.labName = new System.Windows.Forms.Label();
            this.labUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(160, 152);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 32);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboU8DataBase);
            this.panel1.Controls.Add(this.labName);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.labUser);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 194);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(91, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "帐套";
            // 
            // cboU8DataBase
            // 
            this.cboU8DataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboU8DataBase.FormattingEnabled = true;
            this.cboU8DataBase.Location = new System.Drawing.Point(160, 107);
            this.cboU8DataBase.Name = "cboU8DataBase";
            this.cboU8DataBase.Size = new System.Drawing.Size(203, 23);
            this.cboU8DataBase.TabIndex = 5;
            // 
            // labName
            // 
            this.labName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labName.Location = new System.Drawing.Point(91, 63);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(48, 24);
            this.labName.TabIndex = 0;
            this.labName.Text = "密码";
            // 
            // labUser
            // 
            this.labUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUser.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labUser.Location = new System.Drawing.Point(72, 22);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(67, 23);
            this.labUser.TabIndex = 0;
            this.labUser.Text = "用户名";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(160, 18);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(203, 25);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(160, 60);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(203, 25);
            this.txtPassWord.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::FormMain.Properties.Resources.Login2;
            this.panel3.Location = new System.Drawing.Point(1065, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 85);
            this.panel3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::FormMain.Properties.Resources.Login;
            this.panel2.Location = new System.Drawing.Point(859, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 83);
            this.panel2.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormMain.Properties.Resources.fujifilm_basic;
            this.pictureBox1.Location = new System.Drawing.Point(112, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1032, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
		//	((MainForm)this.MdiParent).Close();	
		//	this.Close();
            LoginState = 2;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            RiLiGlobal.RiLiDataAcc.AccountNum = cboU8DataBase.SelectedValue.ToString();
            //获取对应账套的登陆信息
            RiLiGlobal.RiLiDataAcc.GetOpenConn();

            //（Lin 2020-07-01 修改）
            U8Global.U8DataAcc.GetOpenConn(RiLiGlobal.RiLiDataAcc.AccountNum);

            //（Lin 2020-07-01 修改）重新打开连接
            Bao.DataAccess.DataAcc.GetOpenConn();

            //登录
            Login();


            //2016-06-29 tdh
            //U8Global.U8DataAcc.GetConn();
            //U8Global.U8DataAcc.GetConn(cboU8DataBase.SelectedValue.ToString());
		}

        public bool Login()
        {
            try
            {
                //用户名
                UserID = this.txtUser.Text.Trim().ToString();
                if (UserID.IndexOf("'") >= 0 || UserID.IndexOf("=")>=0 || UserID.IndexOf("|")>=0)
                {
                    MessageBox.Show("您输入的信息有误！","温馨提示！");
                    txtUser.Text = "";
                    txtPassWord.Text = "";
                    return false;
                }
                //未加密的密码
                txtPwd = txtPassWord.Text.Trim().ToString();
                //密码
                if (this.txtPassWord.Text.Trim().ToString() == "")
                    PassWord = "";
                else
                    PassWord = bl.GetMD5Encording(this.txtPassWord.Text.Trim().ToString());

                DataTable dtState = bl.Select_SQL_Users_Login_Satae(UserID, PassWord);

                string RoleList = string.Empty;

                DataTable dt_user = Common.Common.Select_SQL_Users_Role(UserID);
                if (dt_user == null || dt_user.Rows.Count <= 0)
                {
                    MessageBox.Show("不存在此用户！", "温馨提示！");
                    return false;
                }

                foreach (DataRow item in dt_user.Rows)
                {
                    RoleList = RoleList + item["RoleId"].ToString() + ",";
                }

                RoleList = RoleList.Substring(0,RoleList.Length-1);
                dtLogin = bl.Select_SQL_Users_Login(UserID, PassWord);
                if (dtLogin.Rows.Count > 0)
                {
                    BaseInfo.UserId = dtLogin.Rows[0]["AutoUserId"].ToString();
                    BaseInfo.UserName = dtLogin.Rows[0]["UserName"].ToString();
                    BaseInfo.Password = bl.GetMD5Encording(txtPassWord.Text.Trim());
                    BaseInfo.userRole = RoleList;
                    BaseInfo.DBUserID = dtLogin.Rows[0]["UserId"].ToString();
                    BaseInfo.WorkStationSerial = dtLogin.Rows[0]["Memo"].ToString();
                    
                    //BaseInfo.Password = txtPassWord.Text.Trim();
                    LoginState = 1;
                    this.Visible = false;
                    IsLogin = true;
                    //btnCancel.DialogResult = DialogResult.OK;
                }
                else if (dtState.Rows.Count > 0)
                {
                    MessageBox.Show("您的用户已经被封存！请联络系统管理员！", "温馨提示！");
                    //btnLogin.DialogResult = DialogResult.None;
                    LoginState = 0;
                    // return;
                    //this.Close();

                }
                else
                {
                    MessageBox.Show("不存在这个用户或是用户密码填写不正确！", "温馨提示！");
                    LoginState = 0;
                    txtPassWord.Text = "";
                    // MessageBox.Show("不存在这个用户或是用户密码设置不正确", "温馨提示！");
                    // btnLogin.DialogResult = DialogResult.None;
                    //  return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }


        //public void OldLogin()
        //{
        //    //Bao.DataAccess.DataAcc.GetConn();
        //    //String username = this.txtUser.Text; 
        //    //String password = this.txtPassWord.Text;
        //    ////String hashPass = UserRight.toMD5(password);    //调用UserRight类的md5加密算法

        //    //string Sql = "select DISTINCT a.AutoUserId,UserName,d.functionId,"+
        //    //            "functionName,DllName,WorkName,Title,TitleGroup  "+
        //    //            "from [Users] a,TFunctions d,UserAuth b,Auth c  "+
        //    //            "where a.AutouserId=b.AutouserId and b.authId= c.authId and c.functionid=d.functionid " +
        //    //            "and a.userId='"+txtUser.Text.Trim()+"' and a.password='"+txtPassWord.Text.Trim()+"'";
        //    //System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
        //    //if (table1.Rows.Count == 0)
        //    //{
        //    //    MessageBox.Show("不存在这个用户或是用户密码设置不正确");
        //    //    btnLogin.DialogResult = DialogResult.None;
        //    //    return;
        //    //}

        //    //BaseInfo.UserId = table1.Rows[0]["AutouserId"].ToString();
        //    //BaseInfo.UserName = table1.Rows[0]["UserName"].ToString();
        //    //BaseInfo.Password = txtPassWord.Text.Trim();
        //    ////BaseInfo.userRole = BaseInfo.UserId;//角色扮演
        //    ////BaseInfo.AccID = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套ID
        //    ////BaseInfo.AccID = BaseInfo.AccID.Substring(BaseInfo.AccID.IndexOf("@") + 1);
        //    ////BaseInfo.iYear = (string)U8LoginType.InvokeMember("cIYear", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套年度
        //    ////BaseInfo.cSubID = (string)U8LoginType.InvokeMember("cSub_Id", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//子系统号
        //    ////BaseInfo.AppServer = (string)U8LoginType.InvokeMember("cServer", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//应用服务器
        //    ////BaseInfo.DataSource = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//数据源
        //    ////BaseInfo.UfDbName = (string)U8LoginType.InvokeMember("UfDbName", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//年度库的连接串
        //    ////BaseInfo.operDate = ((DateTime)U8LoginType.InvokeMember("CurDate", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { })).ToShortDateString();//登陆界面的业务日期
        //    ////BaseInfo.LanguageID = (int)U8LoginType.InvokeMember("LanguageID", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
        //    ////BaseInfo.IsAdmin = (bool)U8LoginType.InvokeMember("IsAdmin", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
        //    ////BaseInfo.DBServerName = BaseInfo.getStrValue(BaseInfo.UfDbName, "data source");//数据库服务器名称
        //    ////BaseInfo.DBUserID = BaseInfo.getStrValue(BaseInfo.UfDbName, "user id");//数据库登陆用户名
        //    ////BaseInfo.DBPwd = BaseInfo.getStrValue(BaseInfo.UfDbName, "password");//数据库登陆密码
        //    ////BaseInfo.DBName = DBName;
        //    ////BaseInfo.DefConnStr = "server=" + BaseInfo.DBServerName.Trim() + ";database=" + BaseInfo.DBName + ";user id=" + BaseInfo.DBUserID + ";password=" + BaseInfo.DBPwd;
        //    ////BaseInfo.ProgramName = programName.Trim();


        //    //btnCancel.DialogResult = DialogResult.OK;
        //}



		string path = System.Environment.CurrentDirectory+"\\login.txt";
		private void Login_Load(object sender, System.EventArgs e)  //创建保存用户登录信息的文件
		{
			try
			{

				if(File.Exists(path))
				{
					int i=0;
					using (StreamReader sr = File.OpenText(path)) 
					{
						string s = "";
						while ((s = sr.ReadLine()) != null) 
						{
							if(i==0)
							{

								this.txtUser.Text = s;
							}else if(i==1)
							{
								//this.textBox2.Text = StringUtils.Decrypt(s);								
							}
							i++;
						}
					}

				}
				else
				{
					File.Create(path);
				}
			}
			catch(Exception){}
		}
		private void writeLogin() //保存当前用户的登录用户名和密码 下次直接进入
		{
			try
			{
				if (File.Exists(path)) 
				{
					// Create a file to write to.
					using (StreamWriter sw = File.CreateText(path)) 
					{
						sw.WriteLine(this.txtUser.Text);
						//sw.WriteLine(UserRight.toMD5(this.textBox2.Text));
					}    
				}
				else
				{
					File.Create(path);
				}
			}
			catch(Exception){}
		}

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            /*DataTable dt = bl.GetU8DataBase();
            cboU8DataBase.DataSource = dt; 
            cboU8DataBase.DisplayMember = "name";
            cboU8DataBase.ValueMember = "name";

            cboU8DataBase.SelectedIndex = dt.Rows.Count - 1;*/

            //获取日立医疗售后账套信息（Lin 2020-07-01 修改）
            DataTable dt = bl.GetLRDataBaseInfo();
            cboU8DataBase.DataSource = dt;
            cboU8DataBase.DisplayMember = "AccountName";
            cboU8DataBase.ValueMember = "AccountNum";

            cboU8DataBase.SelectedIndex =0;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginState = 2;
        }
	}
}
