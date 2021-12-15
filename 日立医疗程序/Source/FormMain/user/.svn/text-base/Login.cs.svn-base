using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using WorkFlow.user;
using WorkFlow.util;

namespace WorkFlow.user
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;

		private MainForm mf=null;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public Login(MainForm mf)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			WorkFlow.util.UiUtils.InitUI(this);
			this.mf=mf;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(179, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(205, 25);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(281, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "登陆";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 25);
            this.textBox1.TabIndex = 1;
            // 
            // Login
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(483, 254);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登陆";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			((MainForm)this.MdiParent).Close();	
//			this.Close();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			SqlConnection  myCon= MainForm.getConnection(); //获得数据库连接
			SqlCommand cmd= myCon.CreateCommand();    
			String username = this.textBox1.Text; 
			String password = this.textBox2.Text;
		    String hashPass = UserRight.toMD5(password);    //调用UserRight类的md5加密算法
            cmd.CommandText = "select a.functionname, a.accessright,a.dirid, a.superadmin, b.autoid, b.name, b.userid, a.supplyID from " +
                " t_adminuser a, t_user b where b.autoid=a.userautoid and b.userid='" + username + "'";// and b.passwd='"+hashPass+"'";
			Hashtable ht = new Hashtable();
			Hashtable dirHt = new Hashtable();
			UserRight ur = new UserRight(ht, dirHt); //构造用户对象
			SqlDataReader oread = cmd.ExecuteReader();
			String realName="";
			String userID="";
			int autoID=0;
			while ( oread.Read())   //从数据库取出该用户能使用菜单项和功能模块
			{
				String functionName = oread.GetString(0);
				int accessRight = oread.GetInt32(1);
				int dirID = oread.GetInt32(2);
				int superAdmin = oread.GetInt32(3);
				autoID = oread.GetInt32(4);
				realName = oread.GetString(5);
				userID = oread.GetString(6);
				int supplyID = oread.GetInt32(7);
				if ( superAdmin == 1 ) 
				{
					ur.SuperAdmin=1;
				}
				ur.SupplyID= supplyID;
				
				SingleRight sr = new SingleRight(); 
				sr.FunctionName=functionName;
				if ( ht[functionName]==null)
				{
					ArrayList alist = new ArrayList();
					alist.Add(sr);
					ht[functionName]=alist;
				}
				else 
				{
					ArrayList alist = (ArrayList)ht[functionName];
					alist.Add(sr);					
				}				
			}
			oread.Close();
			if ( ht.Count > 0 || ur.SuperAdmin==1)
			{
				MainForm.setUserAutoID(autoID);     //主窗体
				MainForm.setUserid(userID);
				MainForm.setRealName(realName);
				MainForm.setUR(ur);
                mf.loadFlow();  //取出当前用户需要处理的流程                      
				this.writeLogin();//写入登录信息            	
				Menu mainmenu = ((MainForm)(this.MdiParent)).getMainMenu();
				for ( int i=0; i<mainmenu.MenuItems.Count;i++)
				{
					((MainForm)(this.MdiParent)).setMenuItemAccess(mainmenu.MenuItems[i],"");
					//设置主窗体菜单 该用户能使用的模块的菜单 为可用
				}
				for(int i=0;i<mf.toolBar1.Buttons.Count;i++)
				{
					mf.toolBar1.Buttons[i].Enabled=true;
					//设置主窗体 工具条里面该用户能用的模块的 按钮为可用
				}			
				this.Close();
			}
			else
			{
				MessageBox.Show("不存在这个用户或是用户密码设置不正确或者没有权限访问");
			}
			
		}

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

								this.textBox1.Text = s;
							}else if(i==1)
							{
								this.textBox2.Text = StringUtils.Decrypt(s);								
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
						sw.WriteLine(this.textBox1.Text);
						sw.WriteLine(UserRight.toMD5(this.textBox2.Text));
					}    
				}
				else
				{
					File.Create(path);
				}
			}
			catch(Exception){}
		}


		
	}
}
