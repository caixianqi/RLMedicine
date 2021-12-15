using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Install;

namespace InsMessage
{
    public partial class InstaskList : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string RiLiDataBaseName = "RiLi";
        public System.Data.DataTable DTInstalltask;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "00056";

        string u8DataBase = string.Empty;

        public InstaskList()
        {
            InitializeComponent();

           
        }


        private void InstaskList_Load(object sender, EventArgs e)
        {
            
            this.Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.LoadInstallType();
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

            RiLiGlobal.MD5 md5 = new RiLiGlobal.MD5();

            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            UserRole = GetUserRole(autoUserID);

            //2016-05-24 增加获取U8数据库 tdh

            // (Lin 2020-07-01 修改) 新增加解密
            u8DataBase = md5.Md5Decrypt(iniobj.read("database", "u8database", ""));
            string u8server = "[" + md5.Md5Decrypt(iniobj.read("database", "u8server", "")) + "]";

            u8DataBase = u8server + "." + u8DataBase + ".dbo";

            //TaskListInite(); //tyx注释
            this.LoadData();

        }

        private void LoadInstallType()
        {
            string sql = "select code,name from BaseInstallType ";
            this.cmbInstallType.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.cmbInstallType.DisplayMember = "name";
            this.cmbInstallType.ValueMember = "code";
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserRole(string UserID)
        {
            return UFBaseLib.BusLib.BaseInfo.userRole;
        }
        
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void LoadData()
        {
            gridControl1.Focus();

            string sql = string.Empty;

            //2016-05-24 增加列 tdh
            //1、 增加安装单上的【发货日期】
            //2、 增加安装单上的【销售代理店】
            //3、 增加【订单号】：取自U8系统的发货单上的订单号【根据出库单关联到发货单】
            //sql = string.Format("exec sp_InstallList '{0}','{1}','{2}','{3}'"
            //                    , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), this.cmbInstallType.SelectedValue.ToString(), autoUserID);


            //2020-07-01 Lin 增加审核开始与结束审核日期

            if (this.dateTimePicker3.Value.ToString("yyyy-MM-dd") == this.dateTimePicker4.Value.ToString("yyyy-MM-dd") && this.dateTimePicker3.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {

                sql = string.Format("exec sp_InstallListNew '{0}','{1}','{2}','{3}','{4}'"
                                    , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"),
                                    this.cmbInstallType.SelectedValue.ToString(), autoUserID, u8DataBase);
            }
            else
            {
                sql = string.Format("exec sp_InstallListNew '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                   , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"),
                                   this.cmbInstallType.SelectedValue.ToString(), autoUserID, u8DataBase, dateTimePicker3.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            }

            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            //this.gridControl1.DataSource = DTInstalltask;
            this.DataBinding();
        }

        private void TaskListInite()
        {
            string tasksql = string.Empty ;
            if (UserRole == "")
            {
                return;
            }
            try
            {
                if (UserRole.Contains("001"))
                { 
                    
                }

                if (UserRole.Contains("004"))
                {   //销售
                    tasksql = "select * from " + RiLiDataBaseName + "..InstallTask";
                }
                if (UserRole.Contains("002"))
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
                string field = " tID, tInsCode, tCuscode, tCusName, tComName, tComPhone, tAgeStore, tAgePerson, tRegName, tAddress, tMaiCode, tMonCode, tRepMonth, tSendTime, tInsType, tSummary, tManger, tInsManger, tInsMangerName, tTaskStart, InstallManagerCode,tTaskAsign, tAuditTime, tAuditPerson, tCheckTime, tCheckPerson, tState, tAccType, tAccName, (case when tAccName is not null then '已上传' else '' end) as Accessory, tStartPerson, tMessageId, tMessagedate, tAuditMessageId, InstallManagerName,tAuditMessagedate, fMessageId, fMessagedate,tRegCode,'' as '大区' ,tCheckTime,City,InstallUnit1,InstallUnit2,MachineLevel,Color, (select fMainMake from InsFeedback where fTaskCode = InstallTask.tInsCode) as fMainMake";
                if (!string.IsNullOrEmpty(tasksql))
                {
                    tasksql = tasksql.Replace("*", field);
                    DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery(tasksql);
                }
                else
                {
                    DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from " + RiLiDataBaseName + "..InstallTask where 1=0");
                }

                //RiLiGlobal.RiLiDataAcc.GetDataSet();
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
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败:" + ex.Message);
            }
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
            string field = " tID, tInsCode, tCuscode, tCusName, tComName, tComPhone, tAgeStore, tAgePerson, tRegName, tAddress, tMaiCode, tMonCode, tRepMonth, tSendTime, tInsType, tSummary, tManger, tInsManger, tInsMangerName,InstallManagerCode, tTaskStart, tTaskAsign, tAuditTime, tAuditPerson, tCheckTime, tCheckPerson, tState, tAccType, tAccName, tStartPerson, (case when tAccName is not null then '已上传' else '' end) as Accessory, tMessageId, tMessagedate, InstallManagerName,tAuditMessageId, tAuditMessagedate, fMessageId, fMessagedate,tRegCode,'' as '大区' ,tCheckTime, (select fMainMake from InsFeedback where fTaskCode = InstallTask.tInsCode) as fMainMake";
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
            //gridColumn1.FieldName = "tInsType";
            //gridColumn2.FieldName = "tInsCode";
            //gridColumn3.FieldName = "tRegName";
            //gridColumn4.FieldName = "tCusName";
            //gridColumn5.FieldName = "tStartPerson";
            //gridColumn6.FieldName = "tMessagedate";
            //gridColumn7.FieldName = "tAuditMessagedate";
            //gridColumn8.FieldName = "tInsMangerName";
            //gridColumn9.FieldName = "tAuditPersonName";
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

        public void Authorization()
        {
            
        }

        #endregion

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            //TaskListInite();//刷新
            this.LoadData();
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

        private void 附件下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FileDownload();
        }

        /// <summary>
        /// 附件下载
        /// </summary>
        private void FileDownload()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string code = row["tInsCode"].ToString();

                InstallLoadFile downFile = new InstallLoadFile(code, autoUserID);//autoUserID:用户ID
                downFile.StartPosition = FormStartPosition.CenterScreen;
                downFile.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("请选择安装任务单据！", "温馨提示！");
                return;
            }
        }

        private bool IsAccessory()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string code = row["tInsCode"].ToString();

                DataTable fjtable;
                string sql = "select tAccType from InstallTask where tInsCode='" + code + "'";
                fjtable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
                if (fjtable.Rows.Count <= 0 || fjtable.Rows[0]["tAccType"].ToString() == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }


    }
}
