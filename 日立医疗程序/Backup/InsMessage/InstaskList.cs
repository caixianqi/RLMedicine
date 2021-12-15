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
    public partial class InstaskList : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTInstalltask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";
        public InstaskList()
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
            string tasksql = string.Empty ;
            if (UserRole == "")
            {
                return;
            }
            if (UserRole.Contains("004"))
            {   //销售
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask";
            }
            if (UserRole.Contains( "002"))
            {   //客服经理

               
                    tasksql = " select * from " + RiLiDataBaseName + "..InstallTask where InstallManagerCode='"
                            + autoUserID + "' and tState != '新任务'";
              
                    tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask where  tState != '新任务' and tRegCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")";
                
            }
            if (UserRole.Contains("003"))
            {   //工程师
                if (string.IsNullOrEmpty(tasksql))
                {
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tInsManger='"
                            + autoUserID + "' and tState != '新任务' and  tState != '安装请求' ";
                }
                else
                {
                    tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask where tInsManger='"
                            + autoUserID + "' and tState != '新任务' and  tState != '安装请求'";
                }
            }
            if (UserRole.Contains("001"))
            {   //800客服
                if (string.IsNullOrEmpty(tasksql))
                {
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask";
                }
                else
                {
                    tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask";
                }
            }
            if (UserRole.Contains("008") || UserRole.Contains("009"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where  tState != '新任务' and tRegCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")";
            }
            string field = " tID, tInsCode, tCuscode, tCusName, tComName, tComPhone, tAgeStore, tAgePerson, tRegName, tAddress, tMaiCode, tMonCode, tRepMonth, tSendTime, tInsType, tSummary, tManger, tInsManger, tInsMangerName, tTaskStart, InstallManagerCode,tTaskAsign, tAuditTime, tAuditPerson, tCheckTime, tCheckPerson, tState, tAccType, tAccName, tStartPerson, tMessageId, tMessagedate, tAuditMessageId, InstallManagerName,tAuditMessagedate, fMessageId, fMessagedate,tRegCode,'' as '大区' ,tCheckTime,City,InstallUnit1,InstallUnit2,MachineLevel,Color, (select fMainMake from InsFeedback where fTaskCode = InstallTask.tInsCode) as fMainMake";
            if (!string.IsNullOrEmpty(tasksql))
            {
                tasksql = tasksql.Replace("*", field);
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            }
            else
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from " + RiLiDataBaseName + "..InstallTask where 1=0");
            }

            foreach (DataRow item in DTInstalltask.Rows)
            {
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["tRegCode"].ToString());
                item["tState"] = RiLiGlobal.RiLiDataAcc.InstallStateView(item["tState"].ToString());
                DateTime fintime;

                if (DateTime.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select max(rInsEnd) from InsDetail where rTaskCode = '" + item["tInsCode"].ToString() + "'"), out fintime))
                {

                    item["fMessagedate"] = fintime.ToShortDateString();
                }
                else
                {
                    item["fMessagedate"] = DBNull.Value;
                }
                if (item["tMaiCode"].ToString() == string.Empty)
                {
                   // item["fMainMake"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainMake from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
                    item["tMaiCode"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainType from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
                }
            }

            UnDataBinding();
            DataBinding();

        }

        private void TaskListInite(DateTime beginTime,DateTime endTime)
        {
            string tasksql = string.Empty;
            if (UserRole == "")
            {
                return;
            }
            if (UserRole.Contains("004"))
            {   //销售
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where   tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
            }
            if (UserRole.Contains("002"))
            {   //客服经理

               
                    tasksql = " select * from " + RiLiDataBaseName + "..InstallTask where InstallManagerCode='"
                            + autoUserID + "' and tState != '新任务' and  tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
               tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask where  tState != '新任务' and tRegCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and  tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
                
            }
            if (UserRole.Contains("003"))
            {   //工程师
                if (string.IsNullOrEmpty(tasksql))
                {
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where tInsManger='"
                            + autoUserID + "' and tState != '新任务' and  tState != '安装请求' and  tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'  ";
                }
                else
                {
                    tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask where tInsManger='"
                            + autoUserID + "' and tState != '新任务' and  tState != '安装请求' and  tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
                }
            }
            if (UserRole.Contains("001"))
            {   //800客服
                if (string.IsNullOrEmpty(tasksql))
                {
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where   tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
                }
                else
                {
                    tasksql += "  union select * from " + RiLiDataBaseName + "..InstallTask  where tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
                }
            }
            if (UserRole.Contains("008") || UserRole.Contains("009"))
            {
                tasksql = "select * from " + RiLiDataBaseName + "..InstallTask where  tState != '新任务' and tRegCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and  tMessagedate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ";
            }
            string field = " tID, tInsCode, tCuscode, tCusName, tComName, tComPhone, tAgeStore, tAgePerson, tRegName, tAddress, tMaiCode, tMonCode, tRepMonth, tSendTime, tInsType, tSummary, tManger, tInsManger, tInsMangerName,InstallManagerCode, tTaskStart, tTaskAsign, tAuditTime, tAuditPerson, tCheckTime, tCheckPerson, tState, tAccType, tAccName, tStartPerson, tMessageId, tMessagedate, InstallManagerName,tAuditMessageId, tAuditMessagedate, fMessageId, fMessagedate,tRegCode,'' as '大区' ,tCheckTime, (select fMainMake from InsFeedback where fTaskCode = InstallTask.tInsCode) as fMainMake";
            if (!string.IsNullOrEmpty(tasksql))
            {
                tasksql = tasksql.Replace("*", field);
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
            }
            else
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from " + RiLiDataBaseName + "..InstallTask where 1=0");
            }

            foreach (DataRow item in DTInstalltask.Rows)
            {
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["tRegCode"].ToString());
                item["tState"] = RiLiGlobal.RiLiDataAcc.InstallStateView(item["tState"].ToString());
                DateTime fintime;

                if (DateTime.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select max(rInsEnd) from InsDetail where rTaskCode = '" + item["tInsCode"].ToString() + "'"), out fintime))
                {

                    item["fMessagedate"] = fintime.ToShortDateString();
                }
                else
                {
                    item["fMessagedate"] = DBNull.Value;
                }

                if (item["tMaiCode"].ToString() == string.Empty)
                {
                    //item["fMainMake"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainMake from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
                    item["tMaiCode"] = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select fMainType from InsFeedback where fTaskCode = '" + item["tInsCode"].ToString() + "'");
                }
            }

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
            gridColumn6.FieldName = "tMessagedate";
            gridColumn7.FieldName = "tAuditMessagedate";
            gridColumn8.FieldName = "tInsMangerName";
            gridColumn9.FieldName = "InstallManagerName";
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

        public void Authorization()
        {
            
        }

        #endregion

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TaskListInite();//刷新
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 导出EXECLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();


            this.gridView1.ExportToXls(sf.FileName + ".xls");

            System.Windows.Forms.MessageBox.Show("导出成功");
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Install.ListQuery lq = new Install.ListQuery();
            lq.label2.Text = "任务发起时间";
            lq.ShowDialog();

            TaskListInite(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
