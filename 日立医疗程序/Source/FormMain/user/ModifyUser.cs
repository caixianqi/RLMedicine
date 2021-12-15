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
	/// UserDepCase 的摘要说明。
	/// </summary>
	public class UserDepCase : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox userid;
		private System.Windows.Forms.CheckBox useridCheck;
		private System.Windows.Forms.CheckBox nameCheck;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private SqlConnection  dbCon = null;
		private DataSet ds= null;


		public UserDepCase()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			UiUtils.InitUI(this);
			

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
            this.userid = new System.Windows.Forms.TextBox();
            this.useridCheck = new System.Windows.Forms.CheckBox();
            this.nameCheck = new System.Windows.Forms.CheckBox();
            this.username = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // userid
            // 
            this.userid.Location = new System.Drawing.Point(107, 10);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(181, 25);
            this.userid.TabIndex = 1;
            // 
            // useridCheck
            // 
            this.useridCheck.Location = new System.Drawing.Point(11, 10);
            this.useridCheck.Name = "useridCheck";
            this.useridCheck.Size = new System.Drawing.Size(85, 31);
            this.useridCheck.TabIndex = 2;
            this.useridCheck.Text = "用户ID";
            // 
            // nameCheck
            // 
            this.nameCheck.Location = new System.Drawing.Point(299, 10);
            this.nameCheck.Name = "nameCheck";
            this.nameCheck.Size = new System.Drawing.Size(106, 31);
            this.nameCheck.TabIndex = 3;
            this.nameCheck.Text = "用户名称";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(395, 10);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(224, 25);
            this.username.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "查询用户";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.ContextMenu = this.contextMenu1;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(11, 41);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(725, 401);
            this.dataGrid1.TabIndex = 6;
            this.dataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseUp);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "删除该用户";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "修改用户信息";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "更改用户所在部门";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // UserDepCase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(757, 470);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.nameCheck);
            this.Controls.Add(this.useridCheck);
            this.Controls.Add(this.userid);
            this.Name = "UserDepCase";
            this.Text = "用户查询修改";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			query();
		}
		private void query()
		{
			if(dbCon==null) dbCon = MainForm.getConnection();
			string sql = "select autoid 编号,userid 用户ID,name 用户名,depid 部门ID,((select depname from t_dep where autoid=t_user.depid)) 所在部门,email 邮件地址 from t_user where status=1";
			sql+=this.getCondition();
			Console.WriteLine(sql);
			SqlDataAdapter adapter = new SqlDataAdapter(sql,dbCon);
			ds = new DataSet("t_user");
			adapter.Fill(ds,"t_user");
			this.dataGrid1.SetDataBinding(ds,"t_user");
		}
		private string getCondition()
		{
			string condition = "";
			if(this.useridCheck.Checked)
			{
				condition+=" and userid like '%"+StringUtils.filterBeforeDB(this.userid.Text)+"%'";
			}
			if(this.nameCheck.Checked)
			{
				condition+="and name like '%"+StringUtils.filterBeforeDB(this.username.Text)+"%'";
			}
			return condition;
		}

		private void dataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//GridUtil.ClickOneSelAll(this.dataGrid1,e);
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			if(ds==null || this.ds.Tables[0].Rows.Count==0)
			{
				this.menuItem1.Visible = false;
				this.menuItem2.Visible = false;
				this.menuItem3.Visible = false;
			}
			else
			{
				this.menuItem1.Visible = true;
				this.menuItem2.Visible = true;
				this.menuItem3.Visible = true;
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string sql="update t_user set status=0 where autoid="+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0];         
				string sql="delete from t_user where autoid="+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0];
				int result = Database.ExecuteNonQuery(dbCon,sql);
				sql="delete from t_adminuser where userautoid="+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0];
				int result1 = Database.ExecuteNonQuery(dbCon,sql);
				if(result==1)
				{
					MessageBox.Show("删除此用户成功");
					this.query();
				}
				else
				{
					MessageBox.Show("删除用户失败，请重试");
				}
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.ToString());
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			UserInfoModify uim = new UserInfoModify(this.dataGrid1[this.dataGrid1.CurrentRowIndex,0]);
			uim.ShowDialog(this);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			int index = this.dataGrid1.CurrentRowIndex;
			UserDepModify udm = new UserDepModify(this.dataGrid1[index,0],this.dataGrid1[index,3],this.dataGrid1[index,2]);
			udm.ShowDialog(this);
		}
	}
}
