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
        private string U8DataBaseName = "UFDATA_999_2010";
        private string RiLiDataBaseName = "RiLi";
        public string UserRole;//存储用户的角色客服经理、工程师
        public string autoUserID = "candy";
        private DataTable DTinssupport;

        public SupportMessage()
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
            string tasksql;
            if (UserRole.Contains("008" ))
            {   // 总监
                tasksql = "select * from SellSupport where 1=1";
            }
            else if (UserRole.Contains("002") && UserRole.Contains("003"))
            {   //客服经理 工程师
                //客服经理
                tasksql = "select * from SellSupport";
            }
            else if (UserRole.Contains("002"))
            {   //客服经理
                tasksql = "select * from SellSupport";
            }
            else if (UserRole.Contains("003"))
            {   //工程师
                tasksql = "select * from SellSupport where sSupperson='" + autoUserID + "'";
            }
            else
            {
                //客服经理
                tasksql = "select * from SellSupport";
            }
            
            DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = DTinssupport;
            gridColumn1.FieldName = "sSupPerson";
            gridColumn2.FieldName = "sStartTime";
            gridColumn6.FieldName = "sEndTime";
            gridColumn3.FieldName = "sContent";
            gridColumn4.FieldName = "sAuditPerson";
            gridColumn7.FieldName = "sReqDep";
            gridColumn8.FieldName = "sReqName";
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
            lq.label2.Text = "计划日期";
            lq.ShowDialog();

            string tasksql = "";


            tasksql = "select * from " + RiLiDataBaseName + "..SellSupport where sMessagedate  between '" + lq.dateTimePicker1.Value.ToShortDateString() + "' and '" + lq.dateTimePicker2.Value.AddSeconds(86399).ToString() + "' ";




            //if (string.IsNullOrEmpty(tasksql))
            //{
            //    tasksql = "select * from " + RiLiDataBaseName + "..CallBack where 1=0 "; 
            //}

            DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            UnDataBinding();
            DataBinding();
        }
    }
}
