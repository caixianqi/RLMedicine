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
            string tasksql;
            tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where 1=0";
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTInstalltask;
            gridColumn1.FieldName = "tInsType";
            gridColumn2.FieldName = "tInsCode";
            gridColumn3.FieldName = "tRegName";
            gridColumn4.FieldName = "tCusName";
            gridColumn5.FieldName = "tAgePerson";
            gridColumn8.FieldName = "tInsMangerName";
            gridColumn10.FieldName = "tState";
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
                string tasksql = string.Empty;
                string sqlClientName = string.Empty;//客户
                string sqlRegionName = string.Empty;//地区
                string sqlEngineerName = string.Empty;//工程师
                string sqlDate = string.Empty;//日期
                if (RPTsearch.ClientName.Length <= 0 && RPTsearch.EngineerName.Length <= 0 && RPTsearch.RegionName.Length <= 0
                    && !RPTsearch.chbE1 && !RPTsearch.chbS1)
                {   //不取任务数据
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where 1=0 ";
                }
                else
                {
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where 1=1 ";
                }
                if (RPTsearch.ClientName.Length > 0)
                {   //客户
                    sqlClientName = " and (";
                    for (int i = 0; i < RPTsearch.ClientName.Length; i++)
                    {
                        if (i < RPTsearch.ClientName.Length - 1)
                        {
                            sqlClientName += "tCusName='" + RPTsearch.ClientName[i] + "' or  ";
                        }
                        else
                        {
                            sqlClientName += " tCusName='" + RPTsearch.ClientName[i] + "')";
                        }
                    }
                }
                if (RPTsearch.RegionName.Length > 0)
                {   //地区
                    sqlRegionName = " and (";
                    for (int k = 0; k < RPTsearch.RegionName.Length; k++)
                    {
                        if (k < RPTsearch.RegionName.Length - 1)
                        {
                            sqlRegionName += "tRegName='" + RPTsearch.RegionName[k] + "' or ";
                        }
                        else
                        {
                            sqlRegionName += "tRegName='" + RPTsearch.RegionName[k] + "')";
                        }
                    }
                }
                if (RPTsearch.EngineerName.Length > 0)
                {   //工程师
                    sqlEngineerName = " and (";
                    for (int k = 0; k < RPTsearch.EngineerName.Length; k++)
                    {
                        if (k < RPTsearch.EngineerName.Length - 1)
                        {
                            sqlEngineerName += "tInsMangerName='" + RPTsearch.EngineerName[k] + "' or ";
                        }
                        else
                        {
                            sqlEngineerName += "tInsMangerName='" + RPTsearch.EngineerName[k] + "')";
                        }
                    }
                }
                if (RPTsearch.chbE1 || RPTsearch.chbS1)
                {   //日期
                    if (RPTsearch.chbS1)
                    {   //开始日期
                        sqlDate = sqlDate + " and  convert(varchar(10),tTaskStart,120)>='" + RPTsearch.dtstart.ToString("yyyy-MM-dd") + "'";
                    }
                    if (RPTsearch.chbE1)
                    {   //结束日期
                        sqlDate = sqlDate + " and  convert(varchar(10),tTaskStart,120)<='" + RPTsearch.dtend.ToString("yyyy-MM-dd") + "'";
                    }
                }
                if (!string.IsNullOrEmpty(sqlClientName) || !string.IsNullOrEmpty(sqlDate)
                    || !string.IsNullOrEmpty(sqlEngineerName) || !string.IsNullOrEmpty(sqlRegionName))
                {
                    tasksql = tasksql + sqlDate + sqlClientName + sqlEngineerName + sqlRegionName;
                }
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
                UnDataBinding();
                DataBinding();
            }
        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            TaskListInite();
        }
    }
}
