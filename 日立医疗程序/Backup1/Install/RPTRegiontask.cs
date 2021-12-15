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
    public partial class RPTRegiontask : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTtask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public RPTRegiontaskContion search;
        public int iLoad = 0;
        public RPTRegiontask()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            TaskListInite();
        }
 
        private void TaskListInite()
        {
            string tasksql = string.Empty;
            tasksql = "select tRegName,tRegCode,'' as  '大区', count(InsDetail.rInsEnd)as installcount,(select count(cTaskEnd) from CallBack where tregname=callback.cRegion)as callbackcount,"
                      + "(select count(sEndTime)  from sellsupport where tregname=sellsupport.sregname)as sellcount,(count(InsDetail.rInsEnd)+(select count(cTaskEnd) from CallBack where tregname=callback.cRegion)+(select count(sEndTime)  from sellsupport where tregname=sellsupport.sregname)) as counts from "
                      + RiLiDataBaseName + "..InsDetail,InstallTask where InstallTask.tInsCode=InsDetail.rTaskcode and 1=1 group by all tregname,tRegCode ";
            DTtask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);

            foreach (DataRow item in DTtask.Rows)
            {
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["tRegCode"].ToString());
            }
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTtask;
            gridColumn1.FieldName = "tRegName";
            gridColumn2.FieldName = "installcount";
            gridColumn3.FieldName = "installcount";
            gridColumn4.FieldName = "callbackcount";
            gridColumn5.FieldName = "sellcount";
            gridColumn8.FieldName = "counts";
           // gridColumn10.FieldName = "tState";
        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }

        private void BtnOutexcel_Click(object sender, EventArgs e)
        {

            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                }
                MessageBox.Show("导出成功");
            }
            catch (Exception er)
            {
                MessageBox.Show("导出失败:" + er.Message);
            }
        }

        /// <summary>
        /// 查询单击事件
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            RPTRegiontaskContion.Sql = "";
            search = new RPTRegiontaskContion();
            search.ShowDialog();

            if (RPTRegiontaskContion.state == true && RPTRegiontaskContion.Sql != "")
            {
                string tasksql = string.Empty;
                tasksql = tasksql + RPTRegiontaskContion.Sql;
                DTtask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
                UnDataBinding();
                DataBinding();
            }
        }

        #region IU8Contral 成员

        void Bao.Interface.IU8Contral.Authorization()
        {

        }

        #endregion

        private void RPTRegiontask_Load(object sender, EventArgs e)
        {

        }

    }
}
