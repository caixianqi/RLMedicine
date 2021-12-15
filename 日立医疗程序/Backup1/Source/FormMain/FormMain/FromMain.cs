using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.Remoting;
using System.IO;
using FormMain;
using UFBaseLib.BusLib;
namespace FormMain
{
    public partial class FromMain : Form, Bao.IFromMain
    {
        static public System.Data.DataSet Bills = new DataSet();
        public static FormExample_Index FormList = new FormExample_Index();
        public static  int  IsLoginU8 = 1;     //0:进行U8认证，1：进行独立认证,2:不进行认证
        private LoginTypeBase objLogin;
        static Bao.Message.FrmShowMessage MessageForm=new Bao.Message.FrmShowMessage();
        public static FormMain.Login.FrmUserUpdate fuu = null;
        public FromMain()
        {
            InitializeComponent();
            
        }
        //private Boolean  login()
        //{
        //    FrmLogin login = new FrmLogin();
        //    if (login.ShowDialog() == DialogResult.OK)
        //    {
                
        //        return true;
                
        //    }
        //    else
        //        return false;
           
        //}	
        private void FromMain_Load(object sender, EventArgs e)
        {
            Boolean dd = true;
            switch (IsLoginU8)
            {
                case 0:
                    objLogin = new LoginU8();
                    break;
                case 1:
                    objLogin = new LoginSelf();
                    break;
                case 2:
                    objLogin = new LoginNone();
                    break;
            }
            dd = objLogin.Login();

            if (dd == false)
            {
                Application.Exit();
                return;
            }
            Bao.DataAccess.DataAcc.GetConn();
            CreateXML();
            treeShowItem(BillList);
            #region
            ////清空消息盏
            //this.messagesNotView.Clear();
            ////获取消息设置
            //messageSet = this.messageSetBusiness.QueryByUserID(Params.LoginUser.Account);
            ////设置定时器
            //this.timerHandler = new System.Timers.ElapsedEventHandler(this.timerMsgQuery_Elapsed);
            //this.SetTimerHint(messageSet);
            #endregion
            this.timer1.Enabled = Properties.Settings.Default.Timer==true;
            this.LblUser.Text = "当前用户:" + UFBaseLib.BusLib.BaseInfo.UserName;
            //this.LblShop.Text = U8Global.U8DataAcc.U8ServerAndDataBase.Contains("UFDATA_001") ? "001(日立医疗正式库)" : "003(日立医疗正式库)";

            /*if (U8Global.U8DataAcc.U8ServerAndDataBase.Contains("UFDATA_001"))
            {
                this.LblShop.Text = "001(日立医疗正式库)";
            }

            if (U8Global.U8DataAcc.U8ServerAndDataBase.Contains("UFDATA_003"))
            {
                this.LblShop.Text = "003(日立医疗正式库)";
            }

            if (U8Global.U8DataAcc.U8ServerAndDataBase.Contains("UFDATA_005"))
            {
                this.LblShop.Text = "005(日立医疗正式库)";
            }*/


            //this.LblShop.Text = RiLiGlobal.RiLiDataAcc.AccountNum.ToString() + "日立医疗售后账套";

            this.LblShop.Text = RiLiGlobal.RiLiDataAcc.AccountNum.ToString() + "售后账套";

            this.label2.Text = "售后数据库："+RiLiGlobal.RiLiDataAcc.DataBase;



            //this.LblDate.Text = "登陆时间:" + UFBaseLib.BusLib.BaseInfo.operDate;
            #region 改变桌面图标
            string path = Application.StartupPath + @"\Pic.ini";
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path);
                try
                {
                    System.Drawing.Image aa = System.Drawing.Image.FromFile(sr.ReadLine());
                    this.BackgroundImage = aa;

                }
                catch
                { }
                finally
                {
                    sr.Close();
                }

            }
            #endregion

            Bao.Message.FrmUnfinishedMatters UnfinishedMattersForm = new Bao.Message.FrmUnfinishedMatters();
            UnfinishedMattersForm.iform = this;
            UnfinishedMattersForm.MdiParent = this;
            UnfinishedMattersForm.Show();

        }
        /// <summary>
        /// 将功能模块列到左面列表中
        /// </summary>
        /// <param name="ListBar1"></param>
        private void treeShowItem(DevExpress.XtraNavBar.NavBarControl  ListBar1)
        {

            ListBar1.Groups.Clear();
            Bills.ReadXml(Application.StartupPath + "\\" + "SFDll.XML");
            Bills = objLogin.ReadFunction();
            Bills.Tables[0].Columns.Add("Form", typeof(Form));
            foreach (System.Data.DataRow row1 in Bills.Tables[0].Rows)
            {
                row1["Form"] = System.DBNull.Value  ;
            }

            foreach (System.Data.DataRow row1 in Bills.Tables[0].Rows)
            {
                Boolean Have=false;
                for (int i = 0; i < ListBar1.Groups.Count ; i++)
                {
                    if (row1["TitleGroup"].ToString().Trim() == ListBar1.Groups[i].Caption.Trim())
                    {
                        Have = true;
                        break;
                    }
                    
                }
                if (!Have)
                {
                    DevExpress.XtraNavBar.NavBarGroup group1 = new DevExpress.XtraNavBar.NavBarGroup(row1["TitleGroup"].ToString().Trim());
                    group1.Name = row1["TitleGroup"].ToString().Trim();
                    ListBar1.Groups.Add(group1);
                }
            }

            foreach (System.Data.DataRow row1 in Bills.Tables[0].Rows)
            {
                DevExpress.XtraNavBar.NavBarItemLink item1 = ListBar1.Groups[row1["TitleGroup"].ToString().Trim()].AddItem();
                item1.Item.Caption = row1["Title"].ToString().Trim();
                item1.Item.Hint = row1["FunctionId"].ToString();
               
            }
            
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(m_GradientBrush, ClientRectangle );
        }
        private void menuItem10_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.jpg)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    System.Drawing.Image aa = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                    this.BackgroundImage = aa;
                    string path = Application.StartupPath + @"\Pic.ini";
                    //if (!File.Exists(path))
                    //{
                    StreamWriter sw = File.CreateText(path);
                    sw.WriteLine(openFileDialog1.FileName);
                    sw.Close();
                    //}
                    //StreamReader sr = File.OpenText(path);
                    //conn.ConnectionString =sr.ReadLine();

                }
            }
        }

        private void CreateXML()
        {
            DataTable dt = new DataTable("dTable");
            dt.Columns.Add(new DataColumn("Key", typeof(string)));
            dt.Columns.Add(new DataColumn("dllName", typeof(string)));
            dt.Columns.Add(new DataColumn("WorkName", typeof(string)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Form", typeof(Form)));
            dt.Columns.Add(new DataColumn("Group", typeof(string)));

            DataRow row1 = dt.NewRow();
            row1["Key"] = "Bao01";
            row1["dllName"] = "MXZY.dll";
            row1["WorkName"] = "MXZY.TuoYunControl";
            row1["Title"] = "托运单";
            row1["Group"] = "托运管理";
            
            dt.Rows.Add(row1);

            row1 = dt.NewRow();
            row1["Key"] = "Bao02";
            row1["dllName"] = "MXZY.dll";
            row1["WorkName"] = "MXZY.CustomerAddressControl";
            row1["Title"] = "客户地址";
            row1["Group"] = "托运管理";
            
            dt.Rows.Add(row1);
            
            row1 = dt.NewRow();
            row1["Key"] = "Bao03";
            row1["dllName"] = "test.dll";
            row1["WorkName"] = "test.Form2";
            row1["Title"] = "托运单明细表";
            row1["Group"] = "托运管理";
            
            dt.Rows.Add(row1);
            
            row1 = dt.NewRow();
            row1["Key"] = "Bao04";
            row1["dllName"] = "test.dll";
            row1["WorkName"] = "test.Form4";
            row1["Title"] = "托运单汇总表";
            row1["Group"] = "托运管理";
            dt.Rows.Add(row1);

            row1 = dt.NewRow();
            row1["Key"] = "Bao05";
            row1["dllName"] = "BoxManager.dll";
            row1["WorkName"] = "BoxManager.Box";
            row1["Title"] = "出箱单";
            row1["Group"] = "箱号管理";
            dt.Rows.Add(row1);

            row1 = dt.NewRow();
            row1["Key"] = "Bao06";
            row1["dllName"] = "BoxManager.dll";
            row1["WorkName"] = "BoxManager.rptBox";
            row1["Title"] = "箱号查询";
            row1["Group"] = "箱号管理";
            dt.Rows.Add(row1);

            row1 = dt.NewRow();
            row1["Key"] = "Bao07";
            row1["dllName"] = "BoxManager.dll";
            row1["WorkName"] = "BoxManager.PrtBox";
            row1["Title"] = "箱号打印";
            row1["Group"] = "箱号管理";
            dt.Rows.Add(row1);

            row1 = dt.NewRow();
            row1["Key"] = "Bao08";
            row1["dllName"] = "BoxManager.dll";
            row1["WorkName"] = "BoxManager.BoxNeedPrd";
            row1["Title"] = "装箱产品";
            row1["Group"] = "箱号管理";
            dt.Rows.Add(row1);

            System.Data.DataSet data1 = new DataSet();
            data1.Tables.Add(dt);

            data1.WriteXml("SFDll.XML", System.Data.XmlWriteMode.WriteSchema);

        }
        /// <summary>
        /// 创建并显示子窗口
        /// </summary>
        /// <param name="row1"></param>
        public void ShowChildForm(System.Data.DataRow row1)
        {
            object[] args;
            if (row1.Table.Columns.IndexOf("Param") >= 0)
            {
                if (row1["Param"].ToString().Trim() != "")
                {
                    args = new object[1];
                    args[0] = row1["Param"].ToString().Trim();
                }
                else
                {
                    args = null;
                }
            }
            else
            {
                args = null;
            }
            object ctr1 =Bao.DataAccess.DataAcc.CreateForm( row1["dllName"].ToString(), row1["WorkName"].ToString(), args);
            ///创建不成功
            if (ctr1 == null)
            {
                throw new Exception(Application.StartupPath + "\\" + row1["dllName"].ToString() + "不存在或该Dll中没有" + row1["WorkName"].ToString() + "类");
            }

            ///这个界面必须实现Bao.Interface.IU8Contral 接口
            if (ctr1 is Bao.FormChildBase)   ///是窗体
            {
                row1["Form"] = (Bao.FormChildBase)ctr1;
                ((Bao.FormChildBase)ctr1).MdiParent = this;
                ((Bao.FormChildBase)ctr1).FormList = Bills.Tables[0];
                ((Bao.FormChildBase)ctr1).Text = row1["Title"].ToString();
                if (ctr1 is Bao.FormChildBase )
                    ((Bao.FormChildBase)ctr1).SetFunctionId(row1["FunctionId"].ToString().Trim());

            }
            else if (ctr1 is UserControl)     ///是控件
            {
                Bao.FormChildBase temp = new Bao.FormChildBase();
                temp.Dock = System.Windows.Forms.DockStyle.Fill;

                temp.Controls.Add(ctr1 as UserControl);
                ((UserControl)ctr1).Dock = System.Windows.Forms.DockStyle.Fill;
                row1["Form"] = temp;
                ((System.Windows.Forms.Form)row1["Form"]).MdiParent = this;
                temp.FormList = Bills.Tables[0];
                temp.Text = row1["Title"].ToString();

            }
            else
            {
                throw new Exception("该界面必须继承自UserControl 或 Bao.FormChildBase");
            }

            // 进行权限登陆
            objLogin.Authorization((Bao.Interface.IU8Contral)ctr1);

            //2016-06-29 tdh
            //U8Global.U8DataAcc.GetConn();
            //U8Global.U8DataAcc.GetConn(U8Global.U8DataAcc.U8DataBase);

            //（Lin 2020-07-01 修改）
            U8Global.U8DataAcc.GetConn(RiLiGlobal.RiLiDataAcc.AccountNum);


            if (row1.Table.Columns.IndexOf("BillKeyId")>0)              //是点击消息框的消息产生的窗口
                ((Bao.FormChildBase)ctr1).GetBillInfo(row1["BillKeyId"].ToString());
            ((System.Windows.Forms.Form)row1["Form"]).Show();
            ((System.Windows.Forms.Form)row1["Form"]).Activate();
 
        }
        private void BillList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            System.Data.DataRow row1 = Bao.DataAccess.DataAcc.Search(Bills.Tables[0], "FunctionId", e.Link.Item.Hint );
            if (row1 != null)           //有这个窗体
            {
                if (row1["Form"] == System.DBNull.Value)    //这个窗体未创建
                {
                    ShowChildForm(row1);//创建这个界面

                }
                else
                {
                    ((Form)(row1["Form"])).Activate();
                }
            }
           
        }

        private void FromMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "确定要退出吗？", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 定时显示消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Data.DataTable table1= Bao.Message.CMessage.RecieveMessage (BaseInfo.UserId .Trim(),System.DateTime.Parse("1900-01-01"),RiLiGlobal.RiLiDataAcc.GetNow(),true);
            if (table1.Rows.Count >0)
            {
                table1.Columns.Add("Form", typeof(Form));
                MessageForm.iform = this;
                MessageForm.tableMessage = table1;
                MessageForm.gridControl1.DataSource = null;
                MessageForm.gridControl1.DataSource = MessageForm.tableMessage;
                MessageForm.gridControl1.Refresh();
                MessageForm.Show();
                MessageForm.Location = new System.Drawing.Point(this.Size.Width - MessageForm.Size.Width, this.Size.Height - MessageForm.Size.Height);
            }
        }

       

        private void menuItem4_Click(object sender, EventArgs e)
        {
            FrmBaseTitleSet dd = new FrmBaseTitleSet();
            dd.Show();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {

        }

        private void mItemUser_Update_Click(object sender, EventArgs e)
        {
            if (fuu == null)
            {
                fuu = new FormMain.Login.FrmUserUpdate();
                fuu.ShowDialog();
            }
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {

            Boolean dd = true;
            switch (IsLoginU8)
            {
                case 0:
                    objLogin = new LoginU8();
                    break;
                case 1:
                    objLogin = new LoginSelf();
                    break;
                case 2:
                    objLogin = new LoginNone();
                    break;
            }
            dd = objLogin.Login();

            if (dd == false)
            {
                Application.Exit();
                return;
            }

			MessageForm.Visible = false;//重注册之后，隐藏先前用户的消息提示框
            treeShowItem(BillList);
            
            this.timer1.Enabled = Properties.Settings.Default.Timer == true;
            this.LblUser.Text = "当前用户:" + UFBaseLib.BusLib.BaseInfo.UserName;
            this.LblDate.Text = "登陆时间:" + UFBaseLib.BusLib.BaseInfo.operDate;

            //"日立医疗售后账套"
            this.LblShop.Text = RiLiGlobal.RiLiDataAcc.AccountNum.ToString() + "售后账套";

            this.label2.Text = "售后数据库：" + RiLiGlobal.RiLiDataAcc.DataBase;



            foreach (System.Data.DataRow row1 in Bills.Tables[0].Rows)
            {
                if (row1["Form"] != System.DBNull.Value)
                    ((Form)(row1["Form"])).Close();
            }

            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            Bao.Message.FrmUnfinishedMatters UnfinishedMattersForm = new Bao.Message.FrmUnfinishedMatters();
            UnfinishedMattersForm.iform = this;
            UnfinishedMattersForm.MdiParent = this;
            UnfinishedMattersForm.Show();


        }

		/// <summary>
		/// 待办事项
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem17_Click(object sender, EventArgs e) {
			Bao.Message.FrmUnfinishedMatters UnfinishedMattersForm = new Bao.Message.FrmUnfinishedMatters();
			UnfinishedMattersForm.iform = this;
			UnfinishedMattersForm.MdiParent = this;
			UnfinishedMattersForm.Show();
		}
    }
}