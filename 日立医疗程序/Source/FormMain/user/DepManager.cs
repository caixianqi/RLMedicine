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
	/// DepManager 的摘要说明。
	/// </summary>
	public class DepManager : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox depname;
		private System.Windows.Forms.TextBox depcode;
		private System.Windows.Forms.ComboBox principalid;
		private System.Windows.Forms.RichTextBox mess;
		private System.Windows.Forms.TreeView deptree;
		private SqlConnection  dbCon = null;
		private Hashtable depHash = new Hashtable();
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components;
		private int currentprincipalid;

		public DepManager()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepManager));
            this.deptree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.depname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.depcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.principalid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mess = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deptree
            // 
            this.deptree.ImageIndex = 0;
            this.deptree.ImageList = this.imageList1;
            this.deptree.Location = new System.Drawing.Point(11, 10);
            this.deptree.Name = "deptree";
            this.deptree.SelectedImageIndex = 0;
            this.deptree.Size = new System.Drawing.Size(320, 453);
            this.deptree.TabIndex = 0;
            this.deptree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deptree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // depname
            // 
            this.depname.Location = new System.Drawing.Point(469, 39);
            this.depname.Name = "depname";
            this.depname.Size = new System.Drawing.Size(235, 25);
            this.depname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "部门名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "部门代码：";
            // 
            // depcode
            // 
            this.depcode.Location = new System.Drawing.Point(469, 113);
            this.depcode.Name = "depcode";
            this.depcode.ReadOnly = true;
            this.depcode.Size = new System.Drawing.Size(235, 25);
            this.depcode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "部门负责人：";
            // 
            // principalid
            // 
            this.principalid.Location = new System.Drawing.Point(469, 175);
            this.principalid.Name = "principalid";
            this.principalid.Size = new System.Drawing.Size(235, 23);
            this.principalid.TabIndex = 6;
            this.principalid.Text = "comboBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "描述信息：";
            // 
            // mess
            // 
            this.mess.Location = new System.Drawing.Point(469, 247);
            this.mess.Name = "mess";
            this.mess.Size = new System.Drawing.Size(235, 123);
            this.mess.TabIndex = 8;
            this.mess.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "增加部门";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(491, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "修改部门信息";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DepManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(795, 484);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.principalid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.depcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depname);
            this.Controls.Add(this.deptree);
            this.Name = "DepManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.DepManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void showTree()
		{
			this.depHash.Clear();
			this.deptree.Nodes.Clear();
			if(dbCon==null)	dbCon = MainForm.getConnection();
			SqlCommand cmd = dbCon.CreateCommand();
			cmd.CommandText = "select autoid,depname,depcode,parentid,principalid,mess from t_dep where status=0 order by autoid asc";
			SqlDataReader reader = cmd.ExecuteReader();
			Hashtable hash = new Hashtable();
			while(reader.Read())
			{

				Dep dep = new Dep(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),
					reader.GetInt32(3),reader.GetInt32(4),reader.IsDBNull(5)?"":reader.GetString(5));
				this.depHash.Add(dep.getID(),dep);
				if(hash.ContainsKey(dep.getParentID()))
				{
					ArrayList tmp = (ArrayList)hash[dep.getParentID()];
					tmp.Add(dep);
				}
				else
				{
					ArrayList tmp = new ArrayList();
					tmp.Add(dep);
					hash.Add(dep.getParentID(),tmp);
				}
					
			}
			reader.Close();
			cmd.Dispose();
			if(hash.Keys.Count>0)
			{
				ArrayList root = (ArrayList)hash[0L];
				Dep rootDep = (Dep)root[0];
				DepNode rootNode = new DepNode(rootDep.getDepName(),rootDep.getID(),0);
				getNode(hash,rootNode,rootDep.getID());
				this.deptree.Nodes.Add(rootNode);
				this.deptree.ExpandAll();
			}
			


		}
		private void getNode(Hashtable hash,DepNode currentNode,long parentid)
		{
			ArrayList tmp = (ArrayList)hash[parentid];
			if(tmp!=null)
			{
				for(int i=0;i<tmp.Count;i++)
				{
					Dep addedDep = (Dep)tmp[i];
					DepNode depNode = new DepNode(addedDep.getDepName(),addedDep.getID(),1);
					currentNode.Nodes.Add(depNode);
					if(hash.ContainsKey(addedDep.getID()))
						getNode(hash,depNode,addedDep.getID());
						   
				}
			}
			hash.Remove(parentid);
		}
		private void DepManager_Load(object sender, System.EventArgs e)
		{
			this.showTree();	
			ComboUtil.getUserCombo(this.principalid);
			if(this.principalid.Items.Count>0)
			{
				this.principalid.SelectedIndex = 0;
			}
		}

		private void deptree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			DepNode depnode = (DepNode)e.Node;
			long depid = depnode.getDepID();
			Dep dep = (Dep)depHash[depid];
			if(dep==null) return;
			this.depname.Text = dep.getDepName();
			this.depcode.Text = dep.getDepCode();
			this.currentprincipalid = (int)dep.getPrincipalID();
			for(int i=0;i<this.principalid.Items.Count;i++)
			{
				if(((ComboItem)this.principalid.Items[i]).Value==(int)dep.getPrincipalID())
					this.principalid.SelectedIndex = i;
			}
			this.mess.Text = dep.getMess();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.deptree.SelectedNode==null)
			{
				MessageBox.Show("请选择一个上级部门");
				return;
			}
			if(this.depname.Text.Trim().Equals(""))
			{
				MessageBox.Show("请输入部门名称");
				this.depname.Focus();
				return;
			}
			DepNode depnode = (DepNode)this.deptree.SelectedNode;
			long parentid = depnode.getDepID();
			string genDepCode = this.createDepCode(parentid);
			if(genDepCode==null)
			{
				MessageBox.Show("不能创建部门代码，可能已经到达了最高编码限制");
			    return;
			}
			try
			{
				dbCon=MainForm.getConnection();
				SqlCommand cmd = dbCon.CreateCommand();
				cmd.CommandText = "insert into t_dep(depname,depcode,parentid,principalid,status,mess) values('"+
					this.depname.Text+"','"+
					createDepCode(parentid)+"',"+
					parentid+",0,0,'"+
					this.mess.Text+"')";
				int result = cmd.ExecuteNonQuery();
				if(result==1)
				{
					MessageBox.Show("部门增加成功");
					this.showTree();
				}
				cmd.Dispose();
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.ToString());
			}

				                               
		}
		private string createDepCode(long parentid)
		{
		   Dep dep = (Dep)depHash[parentid];
		   string parentcode = dep.getDepCode();
		
			for(long i=10;i<Dep.getMaxDepBit();i++)
			{
				string currentCode = parentcode+i;
				if(!hasThisCode(currentCode))
					return currentCode;
			}
			return null;
		}
		private bool hasThisCode(string currentCode)
		{
			IEnumerator idenum = depHash.Values.GetEnumerator();
			while(idenum.MoveNext())
			{
				Dep tmp = (Dep)idenum.Current;
				if(tmp.getCodeLen()==currentCode.Length && tmp.getDepCode().Equals(currentCode))
					return true;
			}
			return false;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(this.deptree.SelectedNode==null)
			{
				MessageBox.Show("请选择一个部门");
				return;
			}
			long depid = ((DepNode)this.deptree.SelectedNode).getDepID();
			try
			{
				dbCon=MainForm.getConnection();
				using(SqlTransaction trans = dbCon.BeginTransaction())
				{
					using(SqlCommand cmd = dbCon.CreateCommand())
					{
						cmd.Transaction = trans;
						bool onError = false;
						try
						{
							cmd.CommandText = "update t_user set depid="+depid+" where autoid="+((ComboItem)this.principalid.SelectedItem).Value;
							cmd.ExecuteNonQuery();

							cmd.CommandText = "update t_dep set depname='"+this.depname.Text+"',principalid="+((ComboItem)this.principalid.SelectedItem).Value+",mess='"+this.mess.Text+"' where autoid="+depid;
							int result = cmd.ExecuteNonQuery();
							if(result!=1)
							{
								onError = true;
							}
						}
						catch(Exception)
						{
							onError = true;	
						}
						if(onError)
						{
							trans.Rollback();
						}
						else
						{
							trans.Commit();
							this.showTree();
						}
					}
				}
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.ToString());
			}
		}
	}
}
