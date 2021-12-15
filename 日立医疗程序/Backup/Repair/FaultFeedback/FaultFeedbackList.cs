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
    public partial class FaultFeedbackList :FormChildBase, Bao.Interface.IU8Contral
    {
        public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public FaultFeedbackList(string query)
        {
            InitializeComponent();

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("    select f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType from FaultFeedback f,RepairMission m where m.RepairMissionID = f.RepairMissionID  " + query);

            gridView1.OptionsBehavior.Editable = false;

            this.gridControl1.DataSource = dt;


            this.gridControl1.DoubleClick += new EventHandler(gridControl1ForFault_DoubleClick);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["FaultFeedbackID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

          public void init()
          {

              DataTable dt003 = new DataTable();
              DataTable dt002 = new DataTable();
              DataTable dt008 = new DataTable();
              DataTable dt009 = new DataTable();
              DataTable dt001 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and (SubmitPersonUser is not null and SubmitPersonUser <>''  ) order by ReportRepartDate desc");

              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc"));
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
              {
                  dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where  m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where  m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where  m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID  order by ReportRepartDate desc");
              }

              dt003.Merge(dt009);
              dt003.Merge(dt008);
              dt003.Merge(dt002);
              dt003.Merge(dt001);

              string[] distinctcols = new string[(dt003.Columns.Count)];
              foreach (DataColumn dc in dt003.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }


              dt003 = dt003.DefaultView.ToTable(true, distinctcols);


              foreach (DataRow item in dt003.Rows)
              {
                  item["完成日期"] = CompleteDate(item["RepairMissionID"].ToString());
                  item["任务状态"] = MissionState(item["RepairMissionID"].ToString());
                  item["故障处理方案"] = solution(item["RepairMissionID"].ToString());
                  item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }


              this.gridControl1.DataSource = dt003;

              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }

          public void init(DateTime beginTime,DateTime endTime)
          {

              DataTable dt003 = new DataTable();
              DataTable dt002 = new DataTable();
              DataTable dt008 = new DataTable();
              DataTable dt009 = new DataTable();
              DataTable dt001 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and (SubmitPersonUser is not null and SubmitPersonUser <>''   ) and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
              {
                  dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where  m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where  m.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }
              if ( UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  m.*,''as '完成日期',ProcessingStatus as '任务状态',''as '故障处理方案',f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType,f.Finalsolution,'' as '大区',m.ZoneCode from RepairMission m left outer join FaultFeedback f on m.RepairMissionID = f.RepairMissionID where    ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }

              dt003.Merge(dt009);
              dt003.Merge(dt008);
              dt003.Merge(dt002);
              dt003.Merge(dt001);

              string[] distinctcols = new string[(dt003.Columns.Count)];
              foreach (DataColumn dc in dt003.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }


              dt003 = dt003.DefaultView.ToTable(true, distinctcols);


              foreach (DataRow item in dt003.Rows)
              {
                  item["完成日期"] = CompleteDate(item["RepairMissionID"].ToString());
                  item["任务状态"] = MissionState(item["RepairMissionID"].ToString());
                  item["故障处理方案"] = solution(item["RepairMissionID"].ToString());
                  item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }


              this.gridControl1.DataSource = dt003;

              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }

        /// <summary>
        /// 完成日期
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
          public string CompleteDate(string id)
          {
              if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == "完成")
              {
                 string da = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CompleteDate from FaultFeedback where  RepairMissionId = '" + id + "'");

                 DateTime result;
                 if (DateTime.TryParse(da, out result))
                 {
                     return result.ToShortDateString();
                 }
                 else
                 {
                     return string.Empty;
                 }
              }
              else
              {

                  return string.Empty;
              }
          }
          /// <summary>
          /// 任务状态
          /// </summary>
          /// <param name="code"></param>
          /// <returns></returns>
          public string MissionState(string id)
          {
              if( RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == string.Empty)
              {
                  return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from RepairMission where RepairMissionID = '" + id + "'");
              }
              else if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select AuditState from FaultFeedback where RepairMissionID = '" + id + "'") == string.Empty)
              {
                  return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'");
              }
              else
              {
                  return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select AuditState from FaultFeedback where RepairMissionID = '" + id + "'");
              }
          }
          /// 故障处理方案
          /// </summary>
          /// <param name="code"></param>
          /// <returns></returns>
          public string solution(string id)
          {
              if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == "完成")
              {
                  string fid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select FaultFeedbackID from FaultFeedback where RepairMissionID = '" + id + "'");

                  return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select top 1 Solution from FaultFeedbackDetails where FaultFeedBackID = '"+fid+"' order by CompleteDate desc");
              }
              else
              {
                  return string.Empty;
              }
          }

          public FaultFeedbackList()
        {
            InitializeComponent();

            //DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select f.FaultFeedbackID,f.RepairMissionID,m.RepairMissionCode,m.CustomerName,f.ProcessingStatus,f.FaultType from FaultFeedback f,RepairMission m where m.RepairMissionID = f.RepairMissionID ");

           
            //this.gridControl1.DataSource = dt;





            init();
           
        }

     
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            gridView1.OptionsBehavior.Editable = false;
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["FaultFeedbackID"].ToString();

            if (id.ToString() == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("该维修任务未做故障反馈");

                string rid = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionID"].ToString();



                SelectID = rid;

                Repair.RepairMission rmision = new RepairMission(rid);

                rmision.MdiParent = this.ParentForm;

                rmision.Show();
                return;
            }

            foreach (Form item in this.ParentForm.MdiChildren)
            {
                if (item is FrmBillBase)
                {
                    if (((FrmBillBase)item).BO.BillId == id)
                    {
                        item.Activate();
                        return;
                    }
                }
            }

           SelectID = id;

           Repair.FaultFeedback mision = new FaultFeedback(id);

           mision.MdiParent = this.ParentForm;

           mision.Show();
        }



        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init();
        }

        private void 导出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();


            this.gridView1.ExportToXls(sf.FileName + ".xls");

            System.Windows.Forms.MessageBox.Show("导出成功");
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {

        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListQuery lq = new ListQuery();
            lq.label2.Text = "报修日期范围";
            lq.ShowDialog();

            init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
