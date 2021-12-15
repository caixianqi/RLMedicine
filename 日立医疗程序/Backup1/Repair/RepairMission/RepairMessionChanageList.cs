using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bao;
using Bao.BillBase;

namespace Repair
{
    public partial class RepairMessionChanageList : FormChildBase, Bao.Interface.IU8Contral
    {
        private DataTable dt_DataSource = null;
        string userid;
        public RepairMessionChanageList()
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init();
        }

        public void Authorization()
        {

        }

        private void init()
        {
            gridControl1.Focus();
            string sql = "";

             //2020-07-01 Lin 增加审核开始与结束审核日期
            if (this.dateTimePicker3.Value.ToString("yyyy-MM-dd") == this.dateTimePicker4.Value.ToString("yyyy-MM-dd") && this.dateTimePicker3.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                 sql = string.Format("exec sp_RepairMessionChanageList '{0}','{1}','{2}','{3}'"
                                   , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);
            }
            else
            {
                sql = string.Format("exec sp_RepairMessionChanageList '{0}','{1}','{2}','{3}','{4}','{5}'"
                                  , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID, dateTimePicker3.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"));

            }
            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
        }
//        private void init()
//        {

//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//            {
//                userid = "010";
//            }

//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
//            {
//                userid = "009";
//            }

//            DataBind_All();
//        }

//        /// <summary>
//        /// 绑定数据
//        /// </summary>
//        public void DataBind_All()
//        {
//            string sql = string.Empty;
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate
//                                        ,  rmc.RMTypeID, rmc.RMTypeBegin, rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate
//                                        , ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end ,rm.MachineModel
//                                    From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID Where rmc.RMID is not null Order by rm.RepairMissionCode Desc");
//            }
//            else
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, 
//		                                        rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate,  rmc.RMTypeID, rmc.RMTypeBegin, 
//			                                        rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, 
//				                                        ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end ,rm.MachineModel
//		                                        From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID 
//		                                        Where  rmc.RMID is not null 
//				                                        and rm.City in (select b.ProvinceName from Users a
//		                                                                                        inner join RegionToProvince b on b.deptNum like a.deptNum+'%'
//		                                                                                        inner join TRoleUsers c on a.AutoUserId = c.AutoUserId
//		                                                                                        where a.UserId = '{0}'  and c.RoleId='{1}')
//		                                        Order by rm.RepairMissionCode Desc", UFBaseLib.BusLib.BaseInfo.DBUserID, userid);
//            }
//            this.gridControl1.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//        }

//        /// <summary>
//        /// 绑定已收回数据
//        /// </summary>
//        public void DataBind_Back()
//        {
//            string sql = string.Empty;
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, 
//                                                rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate, rmc.RMTypeID,  rmc.RMTypeBegin, 
//                                                    rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, 
//                                                        ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end 
//                                                From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID 
//                                                Where rmc.RMID is not null and isnull(rmc.CommitPer, '') = '' and isnull(rmc.AuditPer, '') = '' 
//                                                Order by rm.RepairMissionCode Desc");
//            }
//            else
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, 
//		                                        rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate,  rmc.RMTypeID, rmc.RMTypeBegin, 
//			                                        rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, 
//				                                        ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end 
//		                                        From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID 
//		                                        Where  rmc.RMID is not null and isnull(rmc.CommitPer, '') = '' and isnull(rmc.AuditPer, '') = ''
//				                                        and rm.City in (select b.ProvinceName from Users a
//		                                                                                        inner join RegionToProvince b on b.deptNum like a.deptNum+'%'
//		                                                                                        inner join TRoleUsers c on a.AutoUserId = c.AutoUserId
//		                                                                                        where a.UserId = '{0}'  and c.RoleId='{1}')
//		                                        Order by rm.RepairMissionCode Desc", UFBaseLib.BusLib.BaseInfo.DBUserID, userid);
//            }
//            this.gridControl1.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//        }

//        /// <summary>
//        /// 绑定已提交数据
//        /// </summary>
//        public void DataBind_Submit()
//        {
//            string sql = string.Empty;
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//            {
//                sql = string.Format("Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate, rmc.RMTypeID,  rmc.RMTypeBegin, rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID Where rmc.RMID is not null and isnull(rmc.CommitPer, '') <> '' and isnull(rmc.AuditPer, '') = '' Order by rm.RepairMissionCode Desc");
//            }
//            else
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, 
//		                                        rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate,  rmc.RMTypeID, rmc.RMTypeBegin, 
//			                                        rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, 
//				                                        ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end 
//		                                        From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID 
//		                                        Where  rmc.RMID is not null and isnull(rmc.CommitPer, '') <> '' and isnull(rmc.AuditPer, '') = ''
//				                                        and rm.City in (select b.ProvinceName from Users a
//		                                                                                        inner join RegionToProvince b on b.deptNum like a.deptNum+'%'
//		                                                                                        inner join TRoleUsers c on a.AutoUserId = c.AutoUserId
//		                                                                                        where a.UserId = '{0}'  and c.RoleId='{1}')
//		                                        Order by rm.RepairMissionCode Desc", UFBaseLib.BusLib.BaseInfo.DBUserID, userid);
//            }
//            this.gridControl1.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//        }

//        /// <summary>
//        /// 绑定已审核数据
//        /// </summary>
//        public void DataBind_Audit()
//        {
//            string sql = string.Empty;
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//            {
//                sql = string.Format("Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate, rmc.RMTypeID,  rmc.RMTypeBegin, rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID Where rmc.RMID is not null and isnull(rmc.CommitPer, '') <> '' and isnull(rmc.AuditPer, '') <> '' Order by rm.RepairMissionCode Desc");
//            }
//            else
//            {
//                sql = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, rm.ZoneName, rm.MachineName, 
//		                                        rm.CustomerCode, rm.RepairPersonName, rm.ReportRepartDate,  rmc.RMTypeID, rmc.RMTypeBegin, 
//			                                        rmc.RMTypeEnd, rmc.CommitPer, rmc.CommitDate, rmc.BillDate, rmc.AuditPer, rmc.AuditDate, 
//				                                        ShowAuditStatus = case when rmc.AuditStatus = '1' then '同意' when rmc.AuditStatus = '2' then '不同意' end 
//		                                        From RepairMission rm inner join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID 
//		                                        Where  rmc.RMID is not null and isnull(rmc.CommitPer, '') <> '' and isnull(rmc.AuditPer, '') <> ''
//				                                        and rm.City in (select b.ProvinceName from Users a
//		                                                                                        inner join RegionToProvince b on b.deptNum like a.deptNum+'%'
//		                                                                                        inner join TRoleUsers c on a.AutoUserId = c.AutoUserId
//		                                                                                        where a.UserId = '{0}'  and c.RoleId='{1}')
//		                                        Order by rm.RepairMissionCode Desc", UFBaseLib.BusLib.BaseInfo.DBUserID, userid);
//            }
//            this.gridControl1.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//        }

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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RMTypeID"].ToString();

            Repair.RepairMessionChanage rmc = new Repair.RepairMessionChanage(id);
            rmc.MdiParent = this.ParentForm;
            rmc.Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init();
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataBind_All();
        }

        private void 已提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataBind_Submit();
        }

        private void 已审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataBind_Audit();
        }

        private void 已收回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataBind_Back();
        }
    }
}
