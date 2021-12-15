using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Install
{
    public partial class RPTInsProcess : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTInstalltask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public RPTsearch search;
        public RPTInsProcess()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            TaskListInite();

        }
 
        private void TaskListInite()
        {
            this.LoadData(" and 1=0 ");
        }


        public void DataBinding()
        {
            this.gridControl1.DataSource = DTInstalltask;
            //gridColumn1.FieldName = "tInsType";
            //gridColumn2.FieldName = "tInsCode";
            //gridColumn3.FieldName = "tRegName";
            //gridColumn4.FieldName = "tCusName";
            //gridColumn5.FieldName = "tAgePerson";
            //gridColumn8.FieldName = "tInsMangerName";
            //gridColumn10.FieldName = "tState";
        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                string taskid = gridView1.GetDataRow(gridView1.FocusedRowHandle)["tInsCode"].ToString();
                Install.UserControl1 uc1 = new Install.UserControl1(taskid);
                uc1.MdiParent = this.ParentForm;
                uc1.Visible = true;
             
            }

        }


        #region IU8Contral 成员

        void Bao.Interface.IU8Contral.Authorization()
        {
           
        }

        #endregion

        private void BtnOutexcel_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    gridControl1.ExportToXls(saveFileDialog1.FileName);             
                    MessageBox.Show("导出成功");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("导出失败:"+er.Message);
            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            search = new RPTsearch();
            search.ShowDialog();

            if (RPTsearch.state == true)
            {
                this.LoadData("");
            }
        }

        private void LoadData(string relaion)
        {
            string relaion2 = " and 1=1 ";
            if (relaion.Length == 0)
                relaion = " and 1=1 ";

            string tasksql = string.Empty;
            //string sqlClientName = string.Empty;//客户
            //string sqlRegionName = string.Empty;//地区
            //string sqlEngineerName = string.Empty;//工程师
            //string sqlDate = string.Empty;//日期
            if (RPTsearch.state)
            {
                if (RPTsearch.ClientName.Length > 0)
                {   //客户
                    relaion += " and (";
                    for (int i = 0; i < RPTsearch.ClientName.Length; i++)
                    {
                        if (i < RPTsearch.ClientName.Length - 1)
                        {
                            relaion += "tCusName=''" + RPTsearch.ClientName[i] + "'' or  ";
                        }
                        else
                        {
                            relaion += " tCusName=''" + RPTsearch.ClientName[i] + "'')";
                        }
                    }
                }
                if (RPTsearch.RegionName.Length > 0)
                {   //地区
                    relaion += " and (";
                    for (int k = 0; k < RPTsearch.RegionName.Length; k++)
                    {
                        if (k < RPTsearch.RegionName.Length - 1)
                        {
                            relaion += "tRegName=''" + RPTsearch.RegionName[k] + "'' or ";
                        }
                        else
                        {
                            relaion += "tRegName=''" + RPTsearch.RegionName[k] + "'')";
                        }
                    }
                }

                if (RPTsearch.EngineerName.Length > 0)
                {   //安装负责人
                    relaion += " and (";
                    for (int k = 0; k < RPTsearch.EngineerName.Length; k++)
                    {
                        if (k < RPTsearch.EngineerName.Length - 1)
                        {
                            relaion += "tInsMangerName=''" + RPTsearch.EngineerName[k] + "'' or ";
                        }
                        else
                        {
                            relaion += "tInsMangerName=''" + RPTsearch.EngineerName[k] + "'')";
                        }
                    }
                }
                if (RPTsearch.aAccStdNames.Length > 0)
                {   //规格型号
                    relaion2 = " and (";
                    for (int k = 0; k < RPTsearch.aAccStdNames.Length; k++)
                    {
                        if (k < RPTsearch.aAccStdNames.Length - 1)
                        {
                            relaion2 += "aAccStd=''" + RPTsearch.aAccStdNames[k] + "'' or ";
                        }
                        else
                        {
                            relaion2 += "aAccStd=''" + RPTsearch.aAccStdNames[k] + "'')";
                        }
                    }
                }

                //制造编号
                if (RPTsearch.str_MakeCode.Length > 0)
                    relaion += " and ( tMakeCode like ''%" + RPTsearch.str_MakeCode + "%'' ) ";
                //日期
                if (RPTsearch.chbS1)
                {   //安装结束日期
                    //relaion = relaion + " and  convert(varchar(10),billDate,120)>='" + RPTsearch.dtstart.ToString("yyyy-MM-dd") + "'";
                    //relaion = relaion + " and  convert(varchar(10),billDate,120)<='" + RPTsearch.dtend.ToString("yyyy-MM-dd") + "'";
                    relaion2 = relaion2 + " and  convert(varchar(10),rInsEnd,120)>=''" + RPTsearch.dtstart.ToString("yyyy-MM-dd") + "''";
                    relaion2 = relaion2 + " and  convert(varchar(10),rInsEnd,120)<=''" + RPTsearch.dtend.ToString("yyyy-MM-dd") + "''";
                }
                if (RPTsearch.chbE1)
                {   //核对日期
                    relaion = relaion + " and  convert(varchar(10),tCheckTime,120)>=''" + RPTsearch.dtcheckstart.ToString("yyyy-MM-dd") + "''";
                    relaion = relaion + " and  convert(varchar(10),tCheckTime,120)<=''" + RPTsearch.dtcheckend.ToString("yyyy-MM-dd") + "''";
                }

            }
            if (relaion == " and 1=1 ")
                if (relaion2 == " and 1=1 ")
                    relaion = " and 1=0 ";

            tasksql = string.Format(@"exec sp_RPTInsProcess '{0}', '{1}'" , relaion, relaion2);
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();
        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            TaskListInite();
        }
    }
}
