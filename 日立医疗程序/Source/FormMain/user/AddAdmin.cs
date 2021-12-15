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
	/// AddAdmin ��ժҪ˵����
	/// </summary>
	public class AddAdmin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.SqlClient.SqlConnection  myCon;
		private MainForm myForm;
		private int userAutoID;
		private String userid;
		private Hashtable funcHt = new Hashtable();
		private ArrayList idList;
		private System.Windows.Forms.GroupBox groupBox1;		
		private string[] specialRight = new string[0];

		public MainForm MyForm
		{
			get 
			{
				return myForm;
			}
			set 
			{
				myForm=value;
			}
		}

		public int UserAutoID
		{
			get 
			{
				return userAutoID;
			}
			set 
			{
				userAutoID = value;
			}
		}

		public String UserID
		{
			get 
			{
				return userid;
			}
			set 
			{
				userid=value;
			}
		}

		public AddAdmin(SqlConnection  oc)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			myCon = oc;
			idList = new ArrayList();
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "�������û���";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 25);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(299, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(213, 33);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "��Ϊ��������Ա";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(512, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "�ύ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(651, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "�ر�";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 21);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(866, 544);
            this.checkedListBox1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(11, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 597);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�����б�";
            // 
            // AddAdmin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(943, 662);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "AddAdmin";
            this.Text = "��ӹ���ԱȨ��";
            this.Load += new System.EventHandler(this.AddAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
        //�ύ�����޸��û�Ȩ��
		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( this.textBox1.Text==null||this.textBox1.Text=="")
			{
				MessageBox.Show("������ע���û�id");
				return;
			}
			SqlCommand cmd = myCon.CreateCommand();
			SqlTransaction myTrans = myCon.BeginTransaction();
			cmd.Transaction = myTrans;
			try 
			{
				int supplyID = -1;	
				if ( this.checkBox1.Checked ) // as a superadmin
				{
					cmd.CommandText = "select autoid from t_user where userid='"+this.textBox1.Text+"'";			
					int autoid= -1;
					try 
					{
						autoid = Int32.Parse(cmd.ExecuteScalar().ToString());
					}
					catch( Exception)
					{
						autoid = -1;
					}
					if ( autoid  < 0)
					{						
						myTrans.Commit();
						return;
					}
					cmd.CommandText = "delete from t_adminuser where userautoid="+autoid;
					cmd.ExecuteNonQuery();					
					cmd.CommandText = "insert into t_adminuser values("+autoid+",'.ȫ������',99,0,1,-1)";
					cmd.ExecuteNonQuery();
				}
				else // ��Ӳ���Ȩ��
				{	
					cmd.CommandText = "select autoid from t_user where userid='"+this.textBox1.Text+"'";			
					int autoid= -1;
					try 
					{
						autoid = Int32.Parse(cmd.ExecuteScalar().ToString());
					}
					catch( Exception)
					{
						autoid = -1;
					}
					if ( autoid  < 0)
					{
						myTrans.Commit();
						return;
					}
					cmd.CommandText = "delete from t_adminuser where userautoid="+autoid;
					cmd.ExecuteNonQuery();
					for ( int i=0; i<this.checkedListBox1.Items.Count;i++)
					{
						if ( this.checkedListBox1.GetItemChecked(i))
						{
							String text = "."+this.checkedListBox1.Items[i].ToString();
						
							cmd.CommandText="insert into t_adminuser values("+autoid+",'"+text+"',99,0,0,"+supplyID+")";

							cmd.ExecuteNonQuery();
						}
					}
					cmd.CommandText="insert into t_adminuser values("+autoid+",'.ϵͳ����.���µ�½',99,0,0,"+supplyID+")";
					cmd.ExecuteNonQuery();					 
				}
				myTrans.Commit();
			} 
			catch (Exception ee)
			{
				myTrans.Rollback();
				MessageBox.Show(ee.ToString());				
			}
			this.DialogResult=DialogResult.OK;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        //������޸��û�Ȩ�ޣ�������ݿ�ȡ�����û������е�����Ȩ��
		private void AddAdmin_Load(object sender, System.EventArgs e)
		{
			int supplyID = -1;
			int superAdmin = 0;
			if ( this.UserAutoID>0)  // �޸�
			{
				this.Text = "�޸Ĺ���ԱȨ��";
				this.textBox1.Text = this.UserID;
				this.textBox1.ReadOnly=true;

				SqlCommand cmd = myCon.CreateCommand();
				cmd.CommandText="select dirid, functionname,supplyid,superadmin from t_adminuser where userautoid="+this.UserAutoID;
				SqlDataReader oread = cmd.ExecuteReader();
				
				while ( oread.Read())
				{
					int dirID = oread.GetInt32(0);
					if ( dirID > 0) 
					{
					}
					String functionName = oread.GetString(1);
					funcHt[functionName]=functionName;
					supplyID = oread.GetInt32(2);
					superAdmin = oread.GetInt32(3);
					
				}
				oread.Close();
				
				if ( superAdmin == 1)
				{
					this.checkBox1.Checked=true;
				}
			}
			for ( int i=0; i< myForm.Menu.MenuItems.Count;i++)
			{
				MenuItem item = myForm.Menu.MenuItems[i];
				setFunctionList(item,"");
			}
			setSpecialFunctionList();
		}
        //��ʾϵͳ���еĹ���ģ���б�
		private void setFunctionList( MenuItem item, String pre)
		{			
			if (item.IsParent)
			{
				String newpre = pre+"."+item.Text;	
				for ( int i=0; i<item.MenuItems.Count;i++)
				{
					setFunctionList(item.MenuItems[i],newpre);
				}
			}
			else 
			{
				if ( funcHt[pre+"."+item.Text] != null)
				{
					this.checkedListBox1.Items.Add((pre+"."+item.Text).Substring(1),true);
				}
				else 
				{
					this.checkedListBox1.Items.Add((pre+"."+item.Text).Substring(1));
				}				
			}
		}
        //������޸��û�Ȩ�ޣ����ԭ���û����е�Ȩ�� ������ѡ��״̬
		private void setSpecialFunctionList()
		{
			for ( int i=0; i< this.specialRight.Length; i++ ) 
			{
				if ( funcHt[specialRight[i]] != null)
				{
					this.checkedListBox1.Items.Add(specialRight[i].Substring(1),true);
				}
				else 
				{
					this.checkedListBox1.Items.Add(specialRight[i].Substring(1));
				}
			}
		}
        //����ǳ�������Ա ���������þ���Ȩ��
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( this.checkBox1.Checked) 
			{
				this.checkedListBox1.Enabled=false;
			}
			else 
			{
				this.checkedListBox1.Enabled=true;
			}
		}

	}
}
