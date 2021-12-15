using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class ServiceQualityFilter : Bao.Report.FormFilterBase
    {
        FrmLookUp.SelectMany EngSelect = new FrmLookUp.SelectMany();
        public ServiceQualityFilter()
        {
            InitializeComponent();
            this.SearchWhere = new DataTable("SearchWhere");
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");

            EngSelect.OnLookUpClosed += new FrmLookUp.SelectMany.LookUpClosed(EngSelect_OnLookUpClosed);
        }
        public override string OnSQL()
        {
            return string.Empty;
        }

       
        private void AmountManagementFilter_OnSearchWhere()
        {
            
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
            DateTime dd;

            if (!DateTime.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select min(StartingDate) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "), out dd))
            {

            }
          
             

            int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select count(*) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));

            if (cout == 0)
            {
                return 0;
            }
           
              return (dd - reportDate).TotalDays/cout;
        }
        private double ProcessTime(string code)
        {
            //报修日期-完成时间即可
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }

            double dd = 0;
            double.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select  DATEDIFF(day,  ReportRepartDate, CompleteDate) from FaultFeedback f left outer join Repairmission r on f.RepairMissionID = r.RepairMissionID where f.RepairMissionID  = '" + id + "'"), out dd);

            return dd;
        }
       
        

        private void button4_Click(object sender, EventArgs e)
        {



            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003'");

            EngSelect.Init(dt, "userid ");

            EngSelect.ShowDialog();
        }

        private void EngList_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        void EngSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.EngList.Text = null;
            this.EngList.Tag = null;
            foreach (DataRow item in e.ReturnRow1.Table.Rows)
            {
                this.EngList.Text += item["username"].ToString() + ",";
                this.EngList.Tag += "'" + item["userid"].ToString() + "',";

            }
           

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

        private void ServiceQualityFilter_OnExceSQL(object sender, EventArgs e)
        {

        }

        private void ServiceQualityFilter_OnSearchWhere()
        {
            string sql = string.Empty;

            sql = @"select r.RepairMissionCode, r.RepairPersonName,r.RepairPersonCode,r.RepairType,'' as '是否配件申请', 0.00 as '首次完成时间', 0.00 as '故障解决时间',0.00 as '旅途时间' from RepairMission r  where r.ReportRepartDate between '{0}' and '{1}' ";

            sql = string.Format(sql, BeginTime.Value.ToShortDateString(), EndTime.Value.AddSeconds(86399).ToString());


            if (this.EngList.Text.Length > 0)
            {
                sql += " and RepairPersonCode in (" + this.EngList.Tag.ToString().Remove(this.EngList.Tag.ToString().Length - 1) + ") ";

            }




            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            foreach (DataRow item in lastdata.Rows)
            {
                item["是否配件申请"] = GetInvState(item["RepairMissionCode"].ToString());
                item["首次完成时间"] = FirstCompleteTime(item["RepairMissionCode"].ToString()).ToString("0.00");
                item["故障解决时间"] = ProcessTime(item["RepairMissionCode"].ToString()).ToString("0.00");
               // item["配件等待时间"] = InvWaitTime(item["RepairMissionCode"].ToString()).ToString("0.00");
                item["旅途时间"] = TravelTime(item["RepairMissionCode"].ToString()).ToString("0.00");

            }

            DataTable newlastdata = lastdata.DefaultView.ToTable(true, "RepairPersonName", "RepairPersonCode","RepairType");


            newlastdata.Columns.Add("是否配件申请");
            newlastdata.Columns.Add("首次完成时间");
            newlastdata.Columns.Add("故障解决时间");
            newlastdata.Columns.Add("配件等待时间") ;
            newlastdata.Columns.Add("旅途时间");
         





            foreach (DataRow item in newlastdata.Rows)
            {

                item["首次完成时间"] = lastdata.Compute("sum(首次完成时间)", "RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and RepairType = '" + item["RepairType"].ToString() + "'");
                item["故障解决时间"] = lastdata.Compute("sum(故障解决时间)", "RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and RepairType = '" + item["RepairType"].ToString() + "'");
                //item["配件等待时间"] = lastdata.Compute("sum(配件等待时间)", "RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and RepairType = '" + item["RepairType"].ToString() + "'");
                item["旅途时间"] = lastdata.Compute("sum(旅途时间)", "RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and RepairType = '" + item["RepairType"].ToString() + "'");
             
            }


            newlastdata.TableName = BeginTime.Value.ToShortDateString() + "," + EndTime.Value.AddSeconds(86399).ToString();
            this.DataSourceTable = newlastdata;
        }

        private double TravelTime(string code)
        {

            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }
            double dd = 0;
                double.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day, StartingDate , ReachDate)) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"),out dd);

            return dd;
        }
    }
}
