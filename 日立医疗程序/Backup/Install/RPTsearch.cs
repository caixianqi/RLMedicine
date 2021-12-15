using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Install
{
    public partial class RPTsearch : Form
    {
        private string U8DataBaseName;
        public static string[] ClientName;//客户
        public static string[] EngineerName;//工程师
        public static string[] RegionName;//地区
        public static string[] aAccStdNames;//规格型号
        public static bool chbS1;//是否启用开始日期
        public static bool chbE1;//是否启用结束日期
        public static DateTime dtstart;
        public static DateTime dtend;
        public static bool state;
        public RPTsearch()
        {
            InitializeComponent();
            //U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.DataBase;
            ClientName = new string[0];
            EngineerName = new string[0];
            RegionName = new string[0];
            aAccStdNames = new string[0];
            listBox1.DataSource = ClientName;
            listBox2.DataSource = EngineerName;
            listBox3.DataSource = RegionName;
            dtstart = dtpS.Value.Date;
            dtend = dtpE.Value.Date;
            chbS.Checked = true;
            chbE.Checked = true;
            chbS1 = chbS.Checked;
            chbE1 = chbE.Checked;
            state = false;
        }

        private void RPTsearch_Load(object sender, EventArgs e)
        {
            ClientCode_tb.BaoSQL = "select cCusCode,cCusName from " + U8DataBaseName + ".Customer";
            ClientCode_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.ClientCode_tb.FrmHigth = 400;
            this.ClientCode_tb.FrmWidth = 400;
            ClientCode_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_tb.BaoColumnsWidth = "cCusCode=150,cCusName=250";

            InsManagercode_be.BaoSQL = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003'";
            InsManagercode_be.BaoTitleNames = "userid=人员编码,username=人员姓名";
            InsManagercode_be.FrmHigth = 400;
            InsManagercode_be.FrmWidth = 600;
            InsManagercode_be.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003' and  userid =";
            InsManagercode_be.BaoColumnsWidth = "userid=120,username=120";

            txtregion.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass";
            txtregion.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.txtregion.FrmHigth = 600;
            this.txtregion.FrmWidth = 400;
            txtregion.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE=";
            txtregion.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            txtregion.BaoClickClose = true;


            aAccStd.BaoSQL = "select distinct aAccStd,aAccName from InsAccessory";
            aAccStd.BaoTitleNames = "aAccStd=规格型号 ,aAccName=配件名称";
            this.aAccStd.FrmHigth = 300;
            this.aAccStd.FrmWidth = 500;
            aAccStd.DecideSql = "select distinct aAccStd,aAccName from InsAccessory where aAccStd=";
            aAccStd.BaoColumnsWidth = "aAccStd=150,aAccName=250";
            aAccStd.BaoClickClose = true;
        }

        private void InsManagercode_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            InsManagercode_be.Text = dr["userid"].ToString();
            InsMangerName_tb.Text = dr["username"].ToString();
        }

        private void ClientCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ClientCode_tb.Text = dr["cCusCode"].ToString();
            ClientName_tb.Text = dr["cCusName"].ToString();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtstart = dtpS.Value.Date;
            //txtdate.Text = dtstart.ToString("yyyy:MM:dd") + "--" + dtend.ToString("yyyy:MM:dd");

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtend = dtpE.Value.Date;
            //txtdate.Text = dtstart.ToString("yyyy:MM:dd") + "--" + dtend.ToString("yyyy:MM:dd");
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            int lenght = ClientName.Length;
            Array.Resize(ref ClientName, lenght + 1);
            ClientName[lenght] = ClientName_tb.Text;
            listBox1.DataSource = ClientName;
            ClientCode_tb.Text = "";
            ClientName_tb.Clear();
        }

        private void btnengineer_Click(object sender, EventArgs e)
        {
            int length = EngineerName.Length;
            Array.Resize(ref EngineerName, length + 1);
            EngineerName[length] = InsMangerName_tb.Text;
            listBox2.DataSource = EngineerName;
            InsManagercode_be.Text = "";
            InsMangerName_tb.Clear();
        }

        private void btnregion_Click(object sender, EventArgs e)
        {
            if (txtregionName.Text == "")
            {
                return;
            }
            int length = RegionName.Length;
            Array.Resize(ref RegionName, length + 1);
            RegionName[length] = txtregionName.Text;
            listBox3.DataSource = RegionName;
            txtregion.Text = "";
            txtregionName.Text = "";
        }

        private void Removed_Click(object sender, EventArgs e)
        {
            if (ClientName.Length == 0)
            {
                return;
            }
            int i = listBox1.SelectedIndex;
            int length = ClientName.Length;
            ClientName[i] = ClientName[length - 1];
            Array.Resize(ref ClientName, length-1);
            listBox1.DataSource = ClientName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EngineerName.Length == 0)
            {
                return;
            }
            int i = listBox2.SelectedIndex;
            int length = EngineerName.Length;
            EngineerName[i] = EngineerName[length - 1];
            Array.Resize(ref EngineerName, length - 1);
            listBox2.DataSource = EngineerName;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RegionName.Length == 0)
            {
                return;
            }
            int i = listBox3.SelectedIndex;
            int length = RegionName.Length;
            RegionName[i] = RegionName[length - 1];
            Array.Resize(ref RegionName, length - 1);
            listBox3.DataSource = RegionName;

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClientName = new string[0];
            EngineerName = new string[0];
            RegionName = new string[0];
            listBox1.DataSource = ClientName;
            listBox2.DataSource = EngineerName;
            listBox3.DataSource = RegionName;

        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            state = true;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbS.Checked == true)
            //{
            //    string ss = "1900-01-01";
            //    dtstart= Convert.ToDateTime(ss);
            //    dtend = DateTime.Parse("1900-01-01");
            //}
            //else
            //{
            //    dtstart = dtpS.Value;
            //    dtend = dtpE.Value;
            //}

        }

        private void txtregion_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            txtregion.Text = dr["CDCCODE"].ToString();
            txtregionName.Text = dr["CDCNAME"].ToString();
        }

        private void chbS_CheckedChanged(object sender, EventArgs e)
        {   //是否启用开始日期
            chbS1 = chbS.Checked;
        }

        private void chbE_CheckedChanged(object sender, EventArgs e)
        {   //是否启用结束日期
            chbE1 = chbE.Checked;
        }

        private void riliButtonEdit1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

        }

        private void aAccStd_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;

            aAccStdName.Text = dr["aAccStd"].ToString();
           //InsManagercode_be.Text = dr["aAccStd"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lenght = aAccStdNames.Length;
            Array.Resize(ref aAccStdNames, lenght + 1);
            aAccStdNames[lenght] = aAccStdName.Text;
            listBox4.DataSource = aAccStdNames;

            aAccStdName.Clear();
            aAccStd.Text = string.Empty;
        }
    }
}
