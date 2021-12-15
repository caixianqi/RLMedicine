using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class RepairQualityAndWorkFilter : Bao.Report.FormFilterBase
    {
        public RepairQualityAndWorkFilter()
        {
            InitializeComponent();
            this.SearchWhere = new DataTable("SearchWhere");
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");
        }

        public override string OnSQL()
        {
            return "";
        }

        private void RepairQualityAndWorkFilter_OnSearchWhere()
        {
            System.Data.DataRow row1 = SearchWhere.NewRow();

            row1["开始日期"] = this.BeginTime.Value.ToShortDateString();
            row1["结束日期"] = this.EndTime.Value.ToShortDateString();

            SearchWhere.Rows.Clear();
            SearchWhere.Rows.Add(row1);

            string sql = "select R.RepairMissionCode as '维修编号',(select max(CompleteDate) from FaultFeedbackDetails where FaultFeedbackDetails.FaultFeedBackID = f.FaultFeedBackID) as '完成日期',r.ZoneName as '省份',r.ZoneCode as '省份编码','' as '大区',r.[MachineName] as '主机型号',r.[RepairType] as '维修类别','' as '独立','' as '配件申请','' as '响应时间','' as '故障解决时间', '' as '旅途时间',0 as '维修次数',0.00 as '维修成功率',0 as '配件申请个数',0 as '实际使用个数',0.00 as '配件使用率',f.FaultType as '故障类别','' as '故障现象','' as '故障解决方案' FROM RepairMission R inner  join FaultFeedback f on f.RepairMissionID = R.RepairMissionID and f.[ProcessingStatus] = '完成' where 1 = 1  ";

            if (breport.Checked)
            {
                sql += " and [ReportRepartDate]  between '" + this.BeginTime.Value.ToShortDateString() + "' and '" + this.EndTime.Value.AddSeconds(86399).ToString() + "'";
            }

            if(bcomplete.Checked)
            {
                sql += " and [完成日期]  between '" + this.CompleteBeginTime.Value.ToShortDateString() + "' and '" + this.CompleteEndTime.Value.AddSeconds(86399).ToString() + "'";
            }


            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            foreach (DataRow item in lastdata.Rows)
            {
                item["独立"] = IsAlone(item["维修编号"].ToString());
                item["配件申请"] = GetInvState(item["维修编号"].ToString());
                item["响应时间"] = ResponeTime(item["维修编号"].ToString()).ToString("0.00");
                item["故障解决时间"] = ProcessTime(item["维修编号"].ToString()).ToString("0.00");
                item["旅途时间"] = TravelTime(item["维修编号"].ToString()).ToString("0.00");
                item["维修次数"] = RepairTimes(item["维修编号"].ToString());
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["省份编码"].ToString());
                if(RepairTimes(item["维修编号"].ToString()).ToString("0.00") == "0.00")
                {
                 
                    item["维修成功率"] = 0;
                }
                else
                {
                    item["维修成功率"] = (1.00 / RepairTimes(item["维修编号"].ToString())).ToString("0.00");
                }
                item["配件申请个数"] = InvAppCount(item["维修编号"].ToString());
                item["实际使用个数"] = ActreInvUse(item["维修编号"].ToString());
                if (InvAppCount(item["维修编号"].ToString()) == 0)
                {
                    item["配件使用率"] = 0;
                }
                else
                {
                    item["配件使用率"] =double.Parse(( double.Parse(ActreInvUse(item["维修编号"].ToString()).ToString()) /double.Parse( InvAppCount(item["维修编号"].ToString()).ToString())).ToString());
                }
                item["故障现象"] = FaultDetails(item["维修编号"].ToString());
                item["故障解决方案"] = FaultSolution(item["维修编号"].ToString());
            }

            this.DataSourceTable = lastdata;
        }

        private int ActreInvUse(string code)
        {

            //为出数-良品返还数
              string sql = " select sum(ps.iquantity) from dbo.PartsInventory p,dbo.PartsInventoryDetails ps where p.PartsInventoryID = ps.PartsInventoryID and p.RepairMissionCode = '"+code+"'";

              int d1 = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql) == string.Empty ? "0" : RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql));


              string sql2 = " select sum(psi.iquantity) from dbo.PartsInventory p,dbo.PartsUseAndReturnInfo psi where  psi.PartsInventoryID = p.PartsInventoryID and p.RepairMissionCode = '" + code + "' and State = '良品'";


              int d2 = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql2) == string.Empty ? "0" : RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql2));


              return d1 - d2;



        }

        private string IsAlone(string code)
        {

            //为出数-良品返还数
            string personname = RiLiGlobal.RiLiDataAcc.ExecuteScalar(" select [RepairPersonName] from RepairMission where RepairMissionCode = '" + code + "'");

            string RepairId = RiLiGlobal.RiLiDataAcc.ExecuteScalar(" select [RepairMissionID] from RepairMission where RepairMissionCode = '" + code + "'");


            string result ="独立";

            foreach (DataRow item in RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select [ActualRepairPersonName] from FaultFeedback a,FaultFeedbackDetails b where a.FaultFeedBackID = b.FaultFeedBackID and a.[RepairMissionID] = '" + RepairId + "'").Rows)
            {
                if (item["ActualRepairPersonName"].ToString() == personname)
                {
                    continue;
                }
                else
                {
                    result = "非独立";
                }
            }




            return result;



        }
        private string GetInvState(string code)
        {
            string sate = string.Empty;
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
            {
                sate = "已申请";
            }
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0 && RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsInventory where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
            {
                sate = "已出货";
            }
            else

            { sate = string.Empty; }

            return sate;
        }

        private double ResponeTime(string code)
        {

            try
            {
                DateTime reportDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ReportRepartDate from RepairMission where RepairMissionCode = '" + code + "'"));

                string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

                DateTime dd = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select min(ReachDate) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));



                return (dd - reportDate).TotalDays;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private double ProcessTime(string code)
        {
            try
            {
                string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

                double dd = double.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day,  ReachDate, CompleteDate)) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"));

                return dd;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private double TravelTime(string code)
        {
            try
            {
                string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

                double dd = double.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day, StartingDate , ReachDate)) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"));

                return dd;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        private int RepairTimes(string code)
        {
            try
            {
                string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");
                int dd = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select count(*) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"));
                return dd;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private int InvAppCount(string code)
        {
            string sql = "select sum(ps.iquantity) from PartsApplication p,PartsApplicationDetails ps where ps.PartsApplicationId = p.PartsApplicationId and p.RepairMissionCode = '" + code + "'";

            

                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql) == string.Empty?"0":RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql));

            return cout;
        }

        private string FaultDetails(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select top 1 FaultPhenomenon from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') order by CompleteDate desc");
        }
        private string FaultSolution(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");
            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select top 1 Solution from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') order by CompleteDate desc");
        }
        
    }
}
