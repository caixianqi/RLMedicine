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
	/// ModiPass ��ժҪ˵����
	/// </summary>
	public class ModiPass : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

			private SqlConnection  conn;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModiPass()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			if(conn==null)
				conn = MainForm.getConnection();
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "�����룺";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "�����룺";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "ȷ�������룺";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(139, 25);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(139, 25);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(128, 113);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(139, 25);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "ȷ���޸�";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "�ر�";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModiPass
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(303, 203);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModiPass";
            this.Text = "�޸�����";
            this.Load += new System.EventHandler(this.ModiPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ModiPass_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//using(SqlConnection  myCon=this.conn)
				{
					SqlCommand cmd= conn.CreateCommand();
					cmd.CommandText="select * from t_user where autoid="+MainForm.getUserAutoID()+" and passwd ='"+UserRight.toMD5(this.textBox1.Text)+"'";         
					using(SqlDataReader oread = cmd.ExecuteReader())
					{
						if(oread.Read())
						{
							string pass=this.textBox2.Text;
							string confirm=this.textBox3.Text;
							if(pass.Equals("")||confirm.Equals(""))
							{
								MessageBox.Show("����������");
								return;
							}
							if(!pass.Equals(confirm))
							{
								MessageBox.Show("������������벻һ�£�����������");
								return;
							}
							cmd.CommandText="update t_user set passwd='"+UserRight.toMD5(this.textBox2.Text)+"' where autoid="+MainForm.getUserAutoID();
							cmd.ExecuteNonQuery();

							MessageBox.Show("�����޸ĳɹ�");
							this.Close();
						}
						else
						{
							MessageBox.Show("�����벻�ԣ��㲻�ܸ�������");
							//myCon.Close();

						}
					}
		
				}
			}
			catch (Exception se)
			{
				MessageBox.Show(se.ToString());
				return;
			}


		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
