using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class ServiceQualityDetails : Form
    {

        private string _personCode;
        public ServiceQualityDetails()
        {
            InitializeComponent();
        }
        public ServiceQualityDetails(string personCode, string begintime, string endtime, string RepairType)
        {
            _personCode = personCode;

           string   sql = @"select r.RepairMissionCode, r.RepairPersonName,r.RepairPersonCode,r.RepairType,'' as '是否配件申请', 0.00 as '首次完成时间', 0.00 as '故障解决时间',0.00 as '旅途时间',0.00  as '配件等待时间' from RepairMission r  where r.ReportRepartDate between '{0}' and '{1}'  and RepairType = '{2}'";

            sql = string.Format(sql, begintime, endtime,RepairType);


            sql += " and RepairPersonCode = '" + personCode + "' ";

          




            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            foreach (DataRow item in lastdata.Rows)
            {
                item["是否配件申请"] = GetInvState(item["RepairMissionCode"].ToString());
                item["首次完成时间"] = FirstCompleteTime(item["RepairMissionCode"].ToString()).ToString("0.00");
                item["故障解决时间"] = ProcessTime(item["RepairMissionCode"].ToString()).ToString("0.00");
                item["配件等待时间"] = InvWaitTime(item["RepairMissionCode"].ToString()).ToString("0.00");
                item["旅途时间"] = TravelTime(item["RepairMissionCode"].ToString()).ToString("0.00");

            }


            InitializeComponent();

            this.gridControl1.DataSource= lastdata;
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
        private double FirstCompleteTime(string code)
        {
            DateTime reportDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ReportRepartDate from RepairMission where RepairMissionCode = '" + code + "'"));

            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");


            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }
            //SUM（第一次服务完成日期 - 报修日期）/记录数

            DateTime dd = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select min(StartingDate) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));

            int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select count(*) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));

            return (dd - reportDate).TotalDays / cout;
        }
        private double ProcessTime(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }

            double dd = double.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day,  ReachDate, CompleteDate)) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"));

            return dd;
        }

        private double InvWaitTime(string code)
        {
            // SUM(第一次发货日期-配件申请日期)/记录数
               // sum( 出货日期-申请日期)48484
            // 1545
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");
            DateTime fistsenddate;
            DateTime invappdate;

            int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select count(*) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));

            if (cout == 0)

            { return 0; }

            string fiststring = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select min(ShippingTime) from PartsInventoryDetails where PartsInventoryID in (select PartsInventoryID from PartsInventory where RepairMissionCode = '" + code + "') ");

            if (fiststring == string.Empty)
            {
                return 0.0;
            }
            else
            {
                fistsenddate = DateTime.Parse(fiststring);
            }

            string invstring = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ApplicationDate from PartsApplication   where RepairMissionCode = '" + code + "' ");
            if (invstring == string.Empty)
            {
                return 0.0;
            }
            else
            {
                invappdate = DateTime.Parse(invstring);
            }


            return (fistsenddate - invappdate).TotalDays / cout;
        }

        private double TravelTime(string code)
        {

            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }
            double dd = double.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day, StartingDate , ReachDate)) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"));

            return dd;
        }
    }
}
