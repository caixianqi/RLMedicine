using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inssupport
{
    public partial class SupportMessage:Bao.FormChildBase,Bao.Interface.IU8Contral
    {
        public string autoUserID = "candy";
        private DataTable DTinssupport;

        public SupportMessage()
        {
            InitializeComponent();
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            TaskListInite("", "");

        }

        private void TaskListInite(string startdate, string enddate)
        {
            string tasksql = string.Empty;
            tasksql = string.Format("exec sp_InssupportList '{0}','{1}','{2}'", startdate, enddate, autoUserID);
            DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTinssupport;
        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {

              

                string taskid = gridView1.GetDataRow(gridView1.FocusedRowHandle)["sSupCode"].ToString();
           
                Inssupport.InsSupport uc1 = new Inssupport.InsSupport(taskid);
                uc1.MdiParent = this.ParentForm;
                uc1.Visible = true;
            }
        }
        

        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TaskListInite("", "");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 导出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
              SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();


            this.gridView1.ExportToXls(sf.FileName + ".xls");

            System.Windows.Forms.MessageBox.Show("导出成功");
        }

         
        

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Install.ListQuery lq = new Install.ListQuery();
            lq.label2.Text = "计划日期";
            lq.ShowDialog();

            TaskListInite(lq.dateTimePicker1.Value.ToString("yyyy-MM-dd"), lq.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
        }
    }
}
