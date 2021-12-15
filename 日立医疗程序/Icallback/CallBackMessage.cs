using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Icallback
{
    public partial class CallBackMessage : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public System.Data.DataTable DTCallBack;
        public string autoUserID = string.Empty;

        public CallBackMessage()
        {
            InitializeComponent();
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            TaskListInite("", "");
        }

        private void TaskListInite(string startdate, string enddate)
        {
            string tasksql= "";

            tasksql = string.Format(@"exec sp_InscallbackList '{0}', '{1}', '{2}'", startdate, enddate, autoUserID);
                
            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTCallBack;
        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                int i = this.gridView1.FocusedRowHandle;
                DataRow dss = DTCallBack.Rows[i];
                string taskid = dss["cTaskCode"].ToString();
                Form1 uc1 = new Form1(taskid);
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
            lq.label2.Text = "开始时间";
            lq.ShowDialog();

            TaskListInite(lq.dateTimePicker1.Value.ToString("yyyy-MM-dd"), lq.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
           
        }
    }
}
