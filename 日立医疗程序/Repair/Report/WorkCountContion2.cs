using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Repair.Report
{
    public partial class WorkCountContion2 : Form
    {
        private string U8DataBaseName;
        public static string[] RegionName;//地区
        public static bool state;
        public static string Sql;
        public WorkCountContion2()
        {
            InitializeComponent();
            U8DataBaseName = U8Global.U8DataAcc.DataBase;
            RegionName = new string[0];
            listBox3.DataSource = RegionName;
            state = false;
        }

        private void RPTRegiontaskContion_Load(object sender, EventArgs e)
        {
            txtregion.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass";
            txtregion.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.txtregion.FrmHigth = 600;
            this.txtregion.FrmWidth = 400;
            txtregion.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE=";
            txtregion.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            txtregion.BaoClickClose = true;
        }

        private void txtregion_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            txtregion.Text = dr["CDCCODE"].ToString();
            txtregionName.Text = dr["CDCNAME"].ToString();
        }

        /// <summary>
        /// 确定事件
        /// </summary>
        private void btnsure_Click(object sender, EventArgs e)
        {
            state = true;
            Sql = string.Empty;
            this.Close();
        }

        /// <summary>
        /// 添加
        /// </summary>
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

        /// <summary>
        /// 移除
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
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
    }
}
