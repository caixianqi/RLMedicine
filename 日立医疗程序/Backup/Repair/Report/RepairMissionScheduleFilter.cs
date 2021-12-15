using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Repair.Report
{
    public partial class RepairMissionScheduleFilter :Bao.Report.FormFilterBase,Bao.Interface.IU8Contral
    {
        FrmLookUp.SelectMany CustomerSelect = new FrmLookUp.SelectMany();

        FrmLookUp.SelectMany ManagerSelect = new FrmLookUp.SelectMany();

        FrmLookUp.SelectMany ZoneSelect = new FrmLookUp.SelectMany();


        FrmLookUp.SelectMany EngSelect = new FrmLookUp.SelectMany();


        public RepairMissionScheduleFilter()
        {
            InitializeComponent();

            U8Global.U8DataAcc.GetConn();
            this.SearchWhere = new DataTable("SearchWhere");
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");
            SearchWhere.Columns.Add("客户");
            SearchWhere.Columns.Add("维修负责人");
            SearchWhere.Columns.Add("区域");
            SearchWhere.Columns.Add("工程师");

         
            CustomerSelect.OnLookUpClosed += new FrmLookUp.SelectMany.LookUpClosed(CustomerSelect_OnLookUpClosed);

            ManagerSelect.OnLookUpClosed += new FrmLookUp.SelectMany.LookUpClosed(ManagerSelect_OnLookUpClosed);


            ZoneSelect.OnLookUpClosed += new FrmLookUp.SelectMany.LookUpClosed(ZoneSelect_OnLookUpClosed);

            EngSelect.OnLookUpClosed += new FrmLookUp.SelectMany.LookUpClosed(EngSelect_OnLookUpClosed);

            
        }

        void EngSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.EngList.Text = null;
            this.EngList.Tag = null;
            foreach (DataRow item in e.ReturnRow1.Table.Rows)
            {
                this.EngList.Text += item["username"].ToString() + ",";
                this.EngList.Tag += "'"+item["userid"].ToString()+"',";

            }
            this.ZoneList.Text = null;
            this.ZoneList.Tag = null;
            this.ManagerList.Text = null;
            this.ManagerList.Tag = null;
            this.CustomerList.Text = null;
            this.CustomerList.Tag = null;
         
        }

        void ZoneSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.ZoneList.Text = null;
            this.ZoneList.Tag = null;
            foreach (DataRow item in e.ReturnRow1.Table.Rows)
            {
                this.ZoneList.Text += item["区域名称"].ToString() + ",";
                this.ZoneList.Tag += "'" + item["区域名称"].ToString() + "',";

            }
            this.EngList.Text = null;
            this.EngList.Tag = null;
            this.ManagerList.Text = null;
            this.ManagerList.Tag = null;
            this.CustomerList.Text = null;
            this.CustomerList.Tag = null;

         

        }

        void ManagerSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.ManagerList.Text = null;
            this.ManagerList.Tag = null;
            foreach (DataRow item in e.ReturnRow1.Table.Rows)
            {
                this.ManagerList.Text += item["username"].ToString() + ",";
                this.ManagerList.Tag += "'" + item["userid"].ToString() + "',";

            }
            this.ZoneList.Text = null;
            this.ZoneList.Tag = null;
            this.EngList.Text = null;
            this.EngList.Tag = null;
            this.CustomerList.Text = null;
            this.CustomerList.Tag = null;
        }

        void CustomerSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerList.Text = null;
            this.CustomerList.Tag = null;
            foreach (DataRow item in e.ReturnRow1.Table.Rows)
            {
                this.CustomerList.Text += item["客户名称"].ToString() + ",";
                this.CustomerList.Tag += "'" + item["客户编码"].ToString() + "',";
            }
            this.ZoneList.Text = null;
            this.ZoneList.Tag = null;
            this.EngList.Text = null;
            this.EngList.Tag = null;
            this.ManagerList.Text = null;
            this.ManagerList.Tag = null;
         
        }

        public override string OnSQL()
        {
            return "";
        }

        private void RepairMissionScheduleFilter_OnSearchWhere()
        {
            System.Data.DataRow row1 = SearchWhere.NewRow();

            row1["开始日期"] = this.BeginTime.Value.ToShortDateString();
         
            row1["结束日期"] =DateTime.Parse( this.EndTime.Value.ToShortDateString()).AddSeconds(86399);

            SearchWhere.Rows.Clear();
            SearchWhere.Rows.Add(row1);
        }

        private void RepairMissionScheduleFilter_OnExceSQL(object sender, EventArgs e)
        {
            string ss = "select rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,rm.ZoneCode,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,PurchaseDate,ff.CompleteDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '维修进度','' as RegionName,ff.Finalsolution as '最终故障解决方式',ff.FaultType as '故障类别','' as '故障处理方案' from RepairMission rm left outer join FaultFeedback ff on ff.RepairMissionId = rm.RepairMissionId ";

            ss += "where ReportRepartDate between '" + SearchWhere.Rows[0]["开始日期"].ToString() + "' and '" + SearchWhere.Rows[0]["结束日期"].ToString() + "' ";

            if (CustomerList.Text.Length>0)
            {
                ss += " and CustomerCode in (" + this.CustomerList.Tag.ToString().Remove(this.CustomerList.Tag.ToString().Length-1) + ") ";
            }
            else if (ManagerList.Text.Length > 0)
            {
                ss += " and CustomerManagerCode in (" + this.ManagerList.Tag.ToString().Remove(this.ManagerList.Tag.ToString().Length - 1) + ") ";
            }
            else if (this.ZoneList.Text.Length>0)
            {
                ss += " and ZoneName in (" + this.ZoneList.Tag.ToString().Remove(this.ZoneList.Tag.ToString().Length - 1) + ") ";

            }
            else if (this.EngList.Text.Length > 0)
            {
                ss += " and RepairPersonCode in (" + this.EngList.Tag.ToString().Remove(this.EngList.Tag.ToString().Length - 1) + ") ";


            }
            else

            { }


            DataTable lastdata = Bao.DataAccess.DataAcc.ExecuteQuery(ss);

            foreach (DataRow item in lastdata.Rows)
            {
                item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
                item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
                item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
                item["出货"] = SendCout(item["RepairMissionCode"].ToString());
                item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
                item["申请"] = AppCount(item["RepairMissionCode"].ToString());
                item["维修进度"] = MissionState(item["RepairMissionCode"].ToString());
            
                item["故障处理方案"] = solution(item["RepairMissionCode"].ToString());
                item["RegionName"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
            }

            this.DataSourceTable = lastdata;
            //  this.DataSourceTable.Columns.Add("ddd");
        }

        private double AppCount(string p)
        {




            int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsApplication a,PartsApplicationDetails b where a.PartsApplicationID = b.PartsApplicationID and a.RepairMissionCode = '"+p+"' "));

                return cout;
            
        }

        private string GetReMissionState(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + code + "'");

            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [ProcessingStatus] from [FaultFeedback] where RepairMissionId = '" + id + "'");
        }

        private int ReturnCout(string p)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where    PartsInventoryID = '" + pinvid + "'"));

                return cout;
            }
        }
        private double SendCout(string p)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0 end  from [PartsInventoryDetails] where  PartsInventoryID = '" + pinvid + "'"));

                return cout;
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

            { sate =  string.Empty; }

            return sate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = U8Global.U8DataAcc.ExecuteQuery("select cCusCode as '客户编码',cCusName as '客户名称' from " + U8DataAcc.DataBase + ".Customer");

            CustomerSelect.Init(dt, "客户编码");

            CustomerSelect.ShowDialog();
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002'");

            ManagerSelect.Init(dt, "userid");

            ManagerSelect.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(" select ZoneName as '区域名称' from  [RepairMission]");

            ZoneSelect.Init(dt, "ZoneName");

            ZoneSelect.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           


                  DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003'");

                  EngSelect.Init(dt, "userid ");

                  EngSelect.ShowDialog();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            this.button3.Enabled = false;
            this.button6.Enabled = false;
            this.button5.Enabled = false;
            this.button4.Enabled = false;


            ((Button)sender).Enabled = true;
        }

        public string GetPriceState(string code)
        {
             if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from price where  RepairMissionCode = '" + code + "'").Rows.Count>0)
            {
                return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from price where  RepairMissionCode = '" + code + "'");
            }
      
            else

            { return "未申请"; }
        }

        public string GetFreeState(string code)
        {
            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select IsPass from FreeApplication where RepairMissionCode = '" + code + "'");
        }

        public string GetBillState(string code)
        {
            string Priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceCode from Price where RepairMissionCode = '" + code + "'");
            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select BillState from Bill where PriceCode = '" + Priceid + "'");
        }

        private void EngList_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        /// 故障处理方案
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string solution(string Code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + Code + "'");
            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == "完成")
            {
                string fid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select FaultFeedbackID from FaultFeedback where RepairMissionID = '" + id + "'");

                return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select top 1 Solution from FaultFeedbackDetails where FaultFeedBackID = '" + fid + "' order by CompleteDate desc");
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
        public string MissionState(string code)
        {


            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + code + "'");

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == string.Empty)
            {
                return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from RepairMission where RepairMissionID = '" + id + "'");
            }
            else
            {
                string AuditPerson = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditPerson] from [FaultFeedback] where RepairMissionId = '" + id + "'");



                if (AuditPerson == string.Empty)
                {
                    return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'");
                }
                else
                {
                    return "已审核";
                }

            }
        }
    }
}
