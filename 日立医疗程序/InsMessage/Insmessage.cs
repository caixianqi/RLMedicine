using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsMessage
{
    public partial class Insmessage :Bao.FormChildBase,Bao.Interface.IU8Contral
    {     
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTInstalltask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public Insmessage()
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
            string tasksql =string.Empty;
            if (UserRole == "")
            {
                return;
            }
            else if (UserRole.Contains("004"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tStartPerson='" + autoUserID + "'and tState='安装请求'";
            }
            else if (UserRole.Contains("002"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tManger='" + autoUserID + "'and (tState='安装请求'or tState='待审核')";
            }
            else if (UserRole.Contains("003"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tInsManger='" + autoUserID + "'and tState='新任务'";
            }
            else if(UserRole.Contains("006"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tState='已审核'";
            }
            else
            {
                return;
            }
            if (UserRole.Contains("002") && UserRole.Contains("003"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where (tManger='" + autoUserID + "'and (tState='安装请求'or tState='待审核')) or (tInsManger='" + autoUserID + "'and tState='新任务')";

            }
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
            gridColumn5.FieldName = "tStartPerson";
            gridColumn6.FieldName = "tTaskStart";
            gridColumn7.FieldName = "tTaskAsign";
            gridColumn8.FieldName = "tInsMangerName";
            gridColumn9.FieldName = "tManger";
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
                int i = this.gridView1.FocusedRowHandle;
                DataRow dss = DTInstalltask.Rows[i];
                string taskid = dss["tInsCode"].ToString();
                Install.UserControl1 uc1 = new Install.UserControl1(taskid);
                uc1.MdiParent = this.ParentForm;
                uc1.Visible = true;
            }

        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion
    }
}
