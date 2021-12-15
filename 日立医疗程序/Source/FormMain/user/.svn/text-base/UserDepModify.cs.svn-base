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
	public class UserDepModify : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private SqlConnection  dbCon = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox depcombo;
		private object userautoid = null;

		public UserDepModify(object userautoid,object depid,object username)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			WorkFlow.util.UiUtils.InitUI(this);
			this.userautoid = userautoid;
			this.label2.Text = username.ToString();
			loadDep(depid);

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		private void loadDep(object olddepid)
		{
			ComboUtil.getDepCombo(this.depcombo);
			bool isFound = false;
			for(int i=0;i<this.depcombo.Items.Count;i++)
			{
				if(((ComboItem)this.depcombo.Items[i]).Value==Int32.Parse(olddepid.ToString()))
				{
					this.depcombo.SelectedIndex = i;
					isFound = true;
				}
			}
			if(!isFound)
			{
				this.depcombo.SelectedIndex = 0;
			}

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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.depcombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(53, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户姓名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(75, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(245, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 30);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "所在部门：";
            // 
            // depcombo
            // 
            this.depcombo.Location = new System.Drawing.Point(160, 62);
            this.depcombo.Name = "depcombo";
            this.depcombo.Size = new System.Drawing.Size(224, 23);
            this.depcombo.TabIndex = 11;
            this.depcombo.Text = "comboBox1";
            // 
            // UserDepModify
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 167);
            this.Controls.Add(this.depcombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDepModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户所在部门修改";
            this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dbCon==null) dbCon = MainForm.getConnection();
				int depid = ((ComboItem)this.depcombo.SelectedItem).Value;
				string sql = "update t_user set depid="+depid+", depcode = (select depcode from t_dep where autoid = "+depid+") where autoid="+this.userautoid;
				int result = Database.ExecuteNonQuery(dbCon,sql);
				if(result==1)
				{
					MessageBox.Show("修改用户所在部门成功");
					this.Close();
				}
				else
				{
					MessageBox.Show("修改用户所在部门失败，请重试");
				}
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.ToString());
			}
			
		}
	}
}
