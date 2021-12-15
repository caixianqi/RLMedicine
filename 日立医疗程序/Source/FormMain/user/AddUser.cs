using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using WorkFlow.util;

namespace WorkFlow.user
{
	/// <summary>
	/// UserModify 的摘要说明。
	/// </summary>
	public class AddUser : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox userid;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		 private SqlConnection  dbCon3 = null;

		public AddUser()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			WorkFlow.util.UiUtils.InitUI(this);
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(85, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 25);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 154);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(150, 25);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(64, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(224, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(149, 206);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(150, 25);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(53, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "确认密码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userid
            // 
            this.userid.Location = new System.Drawing.Point(149, 10);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(150, 25);
            this.userid.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(64, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "用户ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(43, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "用户email";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(149, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 25);
            this.textBox4.TabIndex = 13;
            // 
            // AddUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 308);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加新用户";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			//string sql1="insert into  t_user ";
			string error="";
			if(this.userid.Text.Trim().Equals(""))
			{
				MessageBox.Show("用户ID不能为空，请重新输入");
				this.userid.Focus();
				return;
			}
			if(this.textBox1.Text=="" || this.textBox1.Text.Trim().Equals(""))
			{	
				error+="错!用户名为空\n";
				MessageBox.Show(error+"请重试!!!");
				return;}
			if(!this.textBox2.Text.Equals(this.textBox3.Text))
			{
					error+="错!密码不一致\n";
				MessageBox.Show(error+"请重试!!!");
				return;
			}			
			try
			{
				if(dbCon3==null) dbCon3 = MainForm.getConnection();
				SqlCommand cmd2 = dbCon3.CreateCommand();
				cmd2.CommandText = "select autoid from t_user where status=1 and userid='"+this.userid.Text+"'";
				SqlDataReader reader2 = cmd2.ExecuteReader();
           
				while(reader2.Read())
				{
						error+="错!用户重名\n";
						MessageBox.Show(error+"请重试!!!");
						reader2.Close();
						cmd2.Dispose();	
						return;
				}
				reader2.Close();
				cmd2.Dispose();	
				this.dbCon3.Close();
				user_Insert();	
				//addright();
			}
			catch(Exception eee)
			{
				MessageBox.Show(eee.ToString());
			}
		}
      
        private void  user_Insert()
		{
				try
				{			 

                 
				int userautoid=this.getMaxID();  
				ArrayList sqlList = new ArrayList();
			    
				 // SqlCommand cmd3 = dbCon3.CreateCommand();
				 // cmd3.CommandText
					string sql  = "insert into t_user (userid,name,passwd,email,depid,depcode)  values ('"+this.userid.Text+"','"+this.textBox1.Text+"','"+WorkFlow.user.UserRight.toMD5(this.textBox2.Text)+"','"+this.textBox4.Text+"',1001,10)";
				// cmd3.CommandText = "insert into t_coefficent  (工作日加班系数,假日加班系数,公假加班系数,备注)  values (t+"')";
				 
					//int result = cmd3.ExecuteNonQuery();
				  //if(result==1)

					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.流程管理.查询流程',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.流程管理.填写流程步骤',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.流程管理.开始一个流程',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.系统.重新登录',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.系统.修改密码',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.系统.退出',99,0,0,-1)";
					sqlList.Add(sql);
					sql="insert into t_adminuser values("+userautoid+",'.系统.关于',99,0,0,-1)";
					sqlList.Add(sql);
                     

					for(int i=0;i<sqlList.Count;i++)
					{
						Console.WriteLine(sqlList[i]);
					}				
                    dbCon3 = MainForm.getConnection();				
					if(Database.ExecuteNonQuery(dbCon3,sqlList))	
					{
						MessageBox.Show("用户插入成功!,请去指定用户所在部门");
						UserDepCase ud= new UserDepCase();
						ud.ShowDialog();
					}
                    
//					try
//					{
//						SqlConnection dbCon1 = MainForm.getConnection();
//						SqlCommand cmd2 = dbCon1.CreateCommand();
//						cmd2.CommandText = sql;
//						//SqlDataReader reader2 = cmd2.ExecuteReader();
//           
//						if(cmd2.ExecuteNonQuery()==1)
//						{
//						}
//						//reader2.Close();
//						cmd2.Dispose();		
//						this.dbCon3.Close();
//						//addright();
//						//return 1;
//					}
//					catch(Exception eee)
//					{
//						MessageBox.Show(eee.ToString());
//						//return 1;
//					}
//
//                   this.dbCon3.Close();
//				 				
//				  //cmd3.Dispose();
//				 this.Close();		
			  }
			  catch(Exception ee)
			  {
				  MessageBox.Show(ee.ToString());
				Console.WriteLine(ee.Message);
			  }
		}
		public int getMaxID()
		{
			try
			{
				dbCon3 = MainForm.getConnection();
				SqlCommand cmd2 = dbCon3.CreateCommand();
				cmd2.CommandText = "select max(autoid) from t_user";
				SqlDataReader reader2 = cmd2.ExecuteReader();
           
				if(reader2.Read())
				{
					return reader2.IsDBNull(0)?0:reader2.GetInt32(0)+1;
				}
				reader2.Close();
				cmd2.Dispose();		
				this.dbCon3.Close();
				//addright();
				return 1;
			}
			catch(Exception eee)
			{
				MessageBox.Show(eee.ToString());
				return 1;
			}
		}
	
	}
}
