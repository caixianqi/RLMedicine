using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Install
{
    public partial class RPTinsinformation  : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTInstalltask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public RPTsearch search;
        public int iLoad;//是否加载数据
        public RPTinsinformation()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            iLoad = 0;
            TaskListInite();
        }

        private void TaskListInite()
        {
            string tasksql = string.Empty;
            if (iLoad == 0)
            {   //初始不加载数据
                tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}','{3}'", "", "", " and 1=0 ", " and 1=0 ");  
                iLoad++;
            }
            else
            {
                tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}','{3}'", "", "", " and 1=1 ", " and 1=1 ");
            }
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);

           
            UnDataBinding();
            DataBinding();
        }

        public void Process(DataTable dt)
        {
            foreach (DataRow item in dt.DefaultView.ToTable(true, "tInsCode", "tMakeCode", "MachineModel", "tMonCode", "fMonMake", "sign").Rows)
            {
                if (item["tInsCode"].ToString().StartsWith("OP") || item["sign"].ToString() == "1")
                {
                    continue;
                }
                DataRow dr = dt.Copy().Select("tInsCode = '" + item["tInsCode"].ToString() + "'")[0];

                dr["aAccStd"] = item["MachineModel"];
                dr["aMakeCode"] = item["tMakeCode"];
                dt.Rows.Add(dr.ItemArray);

                dr["aAccStd"] = item["tMonCode"];
                dr["aMakeCode"] = item["fMonMake"];
                dt.Rows.Add(dr.ItemArray);
            }
        }
        public void DataBinding()
        {   //绑定数据行

            //foreach (DataRow item in DTInstalltask.Rows)
            //{
            //    //item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["tRegCode"].ToString());
            //    if (item["tMakeCode"].ToString() == string.Empty && item["sign"].ToString() == "0")
            //    {
            //        item["tMakeCode"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainMake from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
            //        item["MachineModel"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainType from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
            //    }
            //}
            //Process(DTInstalltask);
            this.gridControl1.DataSource = DTInstalltask;
            //gridColumn1.FieldName = "tInsCode";
            //gridColumn2.FieldName = "tInsType";
            //gridColumn3.FieldName = "tCusName";
            //gridColumn4.FieldName = "tRegName";
            //gridColumn5.FieldName = "tAddress";
            //gridColumn8.FieldName = "fPostCode";
            //gridColumn10.FieldName = "fCliManger";
            //gridColumn6.FieldName = "fCliPhone";
            //gridColumn7.FieldName = "tAgeStore";
            //gridColumn9.FieldName = "tAgePerson";
            //gridColumn11.FieldName = "tRepMonth";
            //gridColumn12.FieldName = "MachineModel";
            //gridColumn13.FieldName = "tMonCode";
            //gridColumn14.FieldName = "tMakeCode";
            //gridColumn15.FieldName = "fMonMake";
            //gridColumn16.FieldName = "fMainVersion";
            //gridColumn17.FieldName = "rInsStart";
            //gridColumn18.FieldName = "rInsEnd";
            //gridColumn19.FieldName = "fEndTime";
            //gridColumn20.FieldName = "tInsMangerName";

            foreach (GridColumn item in this.gridView1.Columns)
            {
                item.MinWidth = 100;
                item.BestFit();
            }
        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                string sign = gridView1.GetDataRow(gridView1.FocusedRowHandle)["sign"].ToString();
                string taskid = gridView1.GetDataRow(gridView1.FocusedRowHandle)["tInsCode"].ToString();

                if (sign == "0")
                {
                    Install.UserControl1 uc1 = new Install.UserControl1(taskid);
                    uc1.MdiParent = this.ParentForm;
                    uc1.Visible = true;
                }
                else
                {
                    MessageBox.Show(taskid + "编号的单据为历史单据", "温馨提示！");
                }
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
                MessageBox.Show("导出失败:" + er.Message);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            search = new RPTsearch();
            search.ShowDialog();
            if (RPTsearch.state == true)
            {
                string historytasksql = string.Empty;
                string tasksql =string.Empty;
                string sqlClientName = string.Empty;//客户
                string sqlRegionName = string.Empty;//地区
                string sqlEngineerName = string.Empty;//工程师
                string sqlaaccid = string.Empty;//规格型号
                string sqlDate = string.Empty;//日期
                string sqlCheckDate = string.Empty;//核对日期
                string sqlMakeCode = string.Empty;//制造编号

                if (RPTsearch.ClientName.Length > 0)
                {   //客户
                    sqlClientName = " and (";
                    for (int i = 0; i < RPTsearch.ClientName.Length; i++)
                    {
                        if (i < RPTsearch.ClientName.Length - 1)
                        {
                            sqlClientName += "tCusName=''" + RPTsearch.ClientName[i] + "'' or  ";
                        }
                        else
                        {
                            sqlClientName += " tCusName=''" + RPTsearch.ClientName[i] + "'')";
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
                            sqlRegionName += "tRegName=''" + RPTsearch.RegionName[k] + "'' or ";
                        }
                        else
                        {
                            sqlRegionName += "tRegName=''" + RPTsearch.RegionName[k] + "'')";
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
                            sqlEngineerName += "tInsMangerName=''" + RPTsearch.EngineerName[k] + "'' or ";
                        }
                        else
                        {
                            sqlEngineerName += "tInsMangerName=''" + RPTsearch.EngineerName[k] + "'')";
                        }
                    }
                }
                if (RPTsearch.aAccStdNames.Length > 0)
                {

                    sqlaaccid = " and (";
                    for (int k = 0; k < RPTsearch.aAccStdNames.Length; k++)
                    {
                        if (k < RPTsearch.aAccStdNames.Length - 1)
                        {
                            sqlaaccid += "aAccStd=''" + RPTsearch.aAccStdNames[k] + "'' or ";
                        }
                        else
                        {
                            sqlaaccid += "aAccStd=''" + RPTsearch.aAccStdNames[k] + "'')";
                        }
                    }
                }

                if(RPTsearch.str_MakeCode.Length > 0)
                {
                    sqlMakeCode = " and aMakeCode like ''%" + RPTsearch.str_MakeCode + "%'' "; 
                }

                if (RPTsearch.chbE1)
                {
                    sqlCheckDate = string.Format("and I.tCheckTime between ''{0}'' and ''{1}'' ", RPTsearch.dtcheckstart.ToString("yyyy-MM-dd"), RPTsearch.dtcheckend.ToString("yyyy-MM-dd"));
                }
                else
                {
                    sqlCheckDate = " and 1=1 ";
                }

                if (!string.IsNullOrEmpty(sqlClientName) || !string.IsNullOrEmpty(sqlaaccid)
                    || !string.IsNullOrEmpty(sqlEngineerName) || !string.IsNullOrEmpty(sqlRegionName) || !string.IsNullOrEmpty(sqlMakeCode))
                {
                    string condition = string.Empty;
                    condition = sqlClientName + sqlEngineerName + sqlRegionName + sqlaaccid + sqlMakeCode;

                    if(RPTsearch.chbS1)
                        tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}', '{3}'", RPTsearch.dtstart.ToString("yyyy-MM-dd"), RPTsearch.dtend.ToString("yyyy-MM-dd"),sqlCheckDate, condition);
                    else
                        tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}', '{3}'", "", "", sqlCheckDate, condition);
                }
                else
                {
                    if(RPTsearch.chbS1)
                        tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}', '{3}'", RPTsearch.dtstart.ToString("yyyy-MM-dd"), RPTsearch.dtend.ToString("yyyy-MM-dd"), sqlCheckDate, " and 1=1 ");
                    else
                        tasksql = string.Format("exec sp_RPTinsinformation '{0}','{1}','{2}', '{3}'", "", "", sqlCheckDate, " and 1=1 ");
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

        private void RPTinsinformation_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            TaskListInite();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
