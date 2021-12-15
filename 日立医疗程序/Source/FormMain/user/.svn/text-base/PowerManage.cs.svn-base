using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WorkFlow.user
{
	/// <summary>
	/// AccessManage 的摘要说明。
	/// </summary>
	public class AccessManage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Data.DataSet ds;
		private System.Data.SqlClient.SqlDataAdapter myAdapter;
		private System.Data.SqlClient.SqlDataAdapter myAdapter1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Data.SqlClient.SqlConnection  myCon;

		public AccessManage()
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(13, 44);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(371, 576);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "t_adminuser";
            this.dataGridTableStyle1.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "autoid";
            this.dataGridTextBoxColumn5.MappingName = "autoid";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 50;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "用户名";
            this.dataGridTextBoxColumn1.MappingName = "userid";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 150;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "真名";
            this.dataGridTextBoxColumn2.MappingName = "realname";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "超级管理员";
            this.dataGridTextBoxColumn3.MappingName = "superadmin";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "公司名称";
            this.dataGridTextBoxColumn6.MappingName = "shortname";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理员列表";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(409, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "操作权限";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(77, 638);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(395, 638);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(555, 638);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.CaptionVisible = false;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(395, 41);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeadersVisible = false;
            this.dataGrid2.Size = new System.Drawing.Size(426, 576);
            this.dataGrid2.TabIndex = 7;
            this.dataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "t_admin";
            this.dataGridTableStyle2.ReadOnly = true;
            this.dataGridTableStyle2.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "操作名称";
            this.dataGridTextBoxColumn4.MappingName = "functionname";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 300;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(224, 638);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 31);
            this.button5.TabIndex = 5;
            this.button5.Text = "修改";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AccessManage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(845, 682);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Name = "AccessManage";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.AccessManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AccessManage_Load(object sender, System.EventArgs e)
		{
			myCon= MainForm.getConnection();
			myAdapter = new SqlDataAdapter();
			myAdapter.TableMappings.Add("Table","t_adminuser");			
			ds=new DataSet();
			DataTable dt = new DataTable("t_adminuser");
			ds.Tables.Add(dt);
			this.dataGrid1.SetDataBinding(ds,"t_adminuser");
			//绑定dataGrid1的数据源为 名为"t_adminuser" 的DataSet 
			myAdapter1 = new SqlDataAdapter();
			myAdapter1.TableMappings.Add("Table","power");
			SqlCommand cmd1 = myCon.CreateCommand();
			myAdapter1.SelectCommand=cmd1;
			DataTable dt1 = new DataTable("power");
			ds.Tables.Add(dt1);
			this.dataGrid2.SetDataBinding(ds,"power");
            //绑定dataGrid2的数据源为 名为"power" 的DataSet 
			SqlCommand cmd = myCon.CreateCommand();
			cmd.CommandText="select autoid, userid,replace(name,null,'未知') realname, "+
				" (sum(superadmin)) superadmin, round(avg(supplyID),0) supplyid from t_user,"+
				" t_adminuser where t_user.autoid=t_adminuser.userautoid group by autoid,userid,name";
			myAdapter.SelectCommand=cmd;
			ds.Tables["t_adminuser"].Clear();
			myAdapter.Fill(ds, "t_adminuser");
            //左侧dataGrid1 显示所有管理员用户列表
			DataColumn dc = new DataColumn();
			dc.DataType = System.Type.GetType("System.String");
			dc.ColumnName = "shortname";
			ds.Tables["t_adminuser"].Columns.Add(dc);			
		}
		public void getAdminUser()
		{
			
		}
		//当在左侧管理员列表 单击某个用户时 右侧显示该用户的权限列表
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			this.dataGrid1.Select(this.dataGrid1.CurrentRowIndex);
			if(this.dataGrid1[this.dataGrid1.CurrentRowIndex,0].ToString().Trim().Equals(""))
				return;
			myAdapter1.SelectCommand.CommandText = "select (functionname) functionname "+
				"from t_adminuser where userautoid="+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0];
			ds.Tables["power"].Clear();
			myAdapter1.Fill(ds,"power");
			SqlCommand cmd = myCon.CreateCommand();
			cmd.CommandText="select dirid from t_adminuser where dirid>0 and userautoid="
				+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0];
			SqlDataReader oread = cmd.ExecuteReader();
			while ( oread.Read())
			{
				int dirID = oread.GetInt32(0);
			}
			oread.Close();				
		}
        //单击【删除】按钮 从管理员表删除 选中用户
		private void button2_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd = new SqlCommand("delete from t_adminuser where userautoid="
				+this.dataGrid1[this.dataGrid1.CurrentRowIndex,0],myCon);
			cmd.ExecuteNonQuery();
			ds.Tables["power"].Clear();
			ds.Tables["t_adminuser"].Clear();
			myAdapter.Fill(ds, "t_adminuser");
		}
        //单击【添加】按钮 打开AddAdmin 添加管理员权限窗体
		private void button1_Click(object sender, System.EventArgs e)
		{
			AddAdmin aa = new AddAdmin(myCon);
			aa.MyForm=(MainForm)this.MdiParent;
			if ( aa.ShowDialog()==DialogResult.OK)
			{
				ds.Tables["power"].Clear();
				ds.Tables["t_adminuser"].Clear();
				myAdapter.Fill(ds, "t_adminuser");
				this.getAdminUser();
			}
		}
        //单击【修改】按钮 打开AddAdmin 添加管理员权限窗体
		private void button5_Click(object sender, System.EventArgs e)
		{
			AddAdmin aa = new AddAdmin(myCon);
			aa.MyForm=(MainForm)this.MdiParent;
			aa.UserAutoID=Int32.Parse(this.dataGrid1[this.dataGrid1.CurrentRowIndex,0].ToString());
			aa.UserID = this.dataGrid1[this.dataGrid1.CurrentRowIndex,1].ToString();
			if ( aa.ShowDialog()==DialogResult.OK)
			{
				ds.Tables["power"].Clear();
				ds.Tables["t_adminuser"].Clear();
				myAdapter.Fill(ds, "t_adminuser");
				this.getAdminUser();
			}
		}
	}
}
