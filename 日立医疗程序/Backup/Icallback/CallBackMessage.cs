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
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTCallBack;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public CallBackMessage()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            TaskListInite();
        }
        public void GetUserRole(string UserID)//获取角色
        {

            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
           
        }
        private void TaskListInite()
        {
            string tasksql="";
          
              
                    tasksql = "select * from " + RiLiDataBaseName + "..CallBack";
                
               
        

            //if (string.IsNullOrEmpty(tasksql))
            //{
            //    tasksql = "select * from " + RiLiDataBaseName + "..CallBack where 1=0 "; 
            //}
         
            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTCallBack;
            gridColumn1.FieldName = "cCusCode";
            gridColumn2.FieldName = "cClientName";
            gridColumn3.FieldName = "cAim";
            gridColumn4.FieldName = "cCusName";
            gridColumn5.FieldName = "cCusPhone";
            gridColumn6.FieldName = "cRegion";
            gridColumn7.FieldName = "cPlaTime";
            gridColumn8.FieldName = "cTaskEnd";
            gridColumn9.FieldName = "cCusDep";
            gridColumn10.FieldName = "cCallMangerName";
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
            TaskListInite();
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
         
          string tasksql="";


          tasksql = "select * from " + RiLiDataBaseName + "..CallBack where cMessagedate between '" + lq.dateTimePicker1.Value.ToShortDateString() + "' and '" + lq.dateTimePicker2.Value.AddSeconds(86399).ToString() + "' ";
                
               
        

            //if (string.IsNullOrEmpty(tasksql))
            //{
            //    tasksql = "select * from " + RiLiDataBaseName + "..CallBack where 1=0 "; 
            //}
         
            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();
           
        }
    }
}
