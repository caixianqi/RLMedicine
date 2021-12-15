using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class WorkCount : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        WorkCountQuery wcq;
        public WorkCount()
        {
            InitializeComponent();

        
       
            
        }
        public void BindData()
        {
            //foreach (DataRow item in RiLiGlobal.RegionHelper.GetRegionList().Rows)
            //{
            //    this.gridBand1.Columns.Band.Collection.AddBand(item["RegionName"].ToString());

            //    foreach (string pname in RiLiGlobal.RegionHelper.GetRepairPersonListByRegionName(item["RegionName"].ToString()))
            //    {
            //         DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            //         bgc.Caption = pname.Replace(item["RegionName"].ToString(),string.Empty);
            //         bgc.FieldName = pname;
                      
            //         this.gridBand1.Columns.Band.Collection[item["RegionName"].ToString()].Columns.Add(bgc);
            //    }



            //}

            try
            {

                this.gridBand1.Columns.Band.Collection[0].Columns[0].Caption = "维修编号";
                this.gridBand1.Columns.Band.Collection[0].Columns[1].Caption = "报修日期";
                this.gridBand1.Columns.Band.Collection[0].Columns[3].Visible =false;
                this.gridBand1.Columns.Band.Collection[0].Columns[4].Caption = "省份";
                this.gridBand1.Columns.Band.Collection[0].Columns[5].Caption = "地级市";
                this.gridBand1.Columns.Band.Collection[0].Columns[6].Caption = "客户";
                this.gridBand1.Columns.Band.Collection[0].Columns[7].Caption = "维修单位1";
                this.gridBand1.Columns.Band.Collection[0].Columns[8].Caption = "主机";
                this.gridBand1.Columns.Band.Collection[0].Columns[9].Caption = "维修类型";
                this.gridBand1.Columns.Band.Collection[0].Columns[10].Visible = false;
                this.gridBand1.Columns.Band.Collection[0].Columns[11].Visible = false;
            }
            catch (Exception ex)
            {

            }
          
        }

        private void WorkCountInit()
        {
            string sql = "";
            string sql_condition = "";
            if (wcq != null)
            {
                if (wcq.bReport)
                {
                    sql_condition += " and  ReportRepartDate between ''" + wcq._BeginTime.ToShortDateString() + "'' and ''" + wcq._EndTime.AddSeconds(86399).ToString() + "'' ";
                }

                sql = string.Format("exec sp_WorkCount '{0}'", sql_condition);
                DataTable bacTable = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
                this.gridBand1.Collection.AddBand("维修任务");
                foreach (DataColumn item in bacTable.Columns)
                {
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    bgc.Caption = item.ColumnName;
                    bgc.FieldName = item.ColumnName;
                    bgc.RowCount = 2;
                    bgc.VisibleIndex = 1;
                    bgc.OptionsColumn.FixedWidth = true;
                    bgc.Width = 100;
                    bgc.OptionsColumn.AllowEdit = false;
                    bgc.OwnerBand = this.gridBand1.Columns.Band.Collection[0];

                    this.gridBand1.Columns.Band.Collection[0].Columns.Add(bgc);
                }


                //  this.gridBand1.Columns.Band.Collection[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                //AddPersonAndRegionColumns(bacTable);

                int index = 1;
                this.gridBand1.Columns.Band.Collection.AddBand("工程师");
                this.gridBand1.Columns.Band.Collection[index].RowCount = 2;

                this.gridBand1.Columns.Band.Collection[index].OptionsBand.FixedWidth = true;

                foreach (string pname in RiLiGlobal.RegionHelper.GetRepairPersonListByRegionName(""))
                {
                    bacTable.Columns.Add(pname);
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    bgc.Caption = pname.Replace("工程师", string.Empty);
                    bgc.FieldName = pname;
                    bgc.RowCount = 2;
                    bgc.OptionsColumn.AllowEdit = false;
                    bgc.VisibleIndex = 1;
                    bgc.Width = 80;
                    bgc.OptionsColumn.FixedWidth = true;
                    bgc.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                    bgc.BestFit();
                    bgc.OwnerBand = this.gridBand1.Columns.Band.Collection[index];
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    this.gridBand1.Columns.Band.Collection[index].Columns.Add(bgc);
                }

                //int index = 1;

                //foreach (DataRow item in RiLiGlobal.RegionHelper.GetRegionList().Rows)
                //{

                //    this.gridBand1.Columns.Band.Collection.AddBand(item["RegionName"].ToString());
                //    this.gridBand1.Columns.Band.Collection[index].RowCount = 2;


                //    foreach (string pname in RiLiGlobal.RegionHelper.GetRepairPersonListByRegionName(item["RegionName"].ToString()))
                //    {
                //        DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                //        bgc.Caption = pname.Replace(item["RegionName"].ToString(), string.Empty);
                //        bgc.FieldName = pname;
                //        bgc.RowCount = 2;
                //        bgc.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                //        bgc.VisibleIndex = 1;
                //        bgc.OptionsColumn.FixedWidth = true;
                //        bgc.OptionsColumn.AllowEdit = false;
                //        bgc.OwnerBand = this.gridBand1.Columns.Band.Collection[index];
                //        bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //        this.gridBand1.Columns.Band.Collection[index].Columns.Add(bgc);
                //    }

                //    index = index + 1;



                //}

                CountPersonNum(bacTable);

                this.gridControl1.DataSource = bacTable;

                BindData();
            }
        }

        private int InvAppCount(string code)
        {
        //{
        //    string sql = "select sum(ps.iquantity) from PartsApplication p,PartsApplicationDetails ps where ps.PartsApplicationId = p.PartsApplicationId and p.RepairMissionCode = '" + code + "'";



        //    int cout = 0; 
            
        //    int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql),out cout);

        //    return cout;

                     string sql = " select sum(ps.iquantity) from dbo.PartsInventory p,dbo.PartsInventoryDetails ps where p.PartsInventoryID = ps.PartsInventoryID and p.RepairMissionCode = '" + code + "'";

            int d1 = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql) == string.Empty ? "0" : RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql));

            return d1;
        }
        private int ActreInvUse(string code)
        {

       
            //配件不良品数量为实际使用数
            //string sql = " select sum(ps.iquantity) from dbo.PartsInventory p,dbo.PartsInventoryDetails ps where p.PartsInventoryID = ps.PartsInventoryID and p.RepairMissionCode = '" + code + "'";

            //int d1 = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql) == string.Empty ? "0" : RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql));


            string sql2 = " select sum(psi.iquantity) from dbo.PartsInventory p,dbo.PartsUseAndReturnInfo psi where  psi.PartsInventoryID = p.PartsInventoryID and p.RepairMissionCode = '" + code + "' and State = '不良品'";


            int d2 = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql2) == string.Empty ? "0" : RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql2));


            return  d2;



        }

        public void CountPersonNum(DataTable dt)
        {
             string sql = string.Empty;
             foreach (DataRow item in dt.Rows)
             {
                 sql = string.Format(@"select  ActualRepairPersonName,COUNT(ActualRepairPersonName) as icount
                                      from FaultFeedbackDetails a
                                      inner join FaultFeedback b on a.FaultFeedBackID=b.FaultFeedbackID
                                      inner join repairmission r on r.repairmissionId = b.repairmissionId  
                                      where r.RepairMissionCode = '{0}'
                                      group by ActualRepairPersonName", item["RepairMissionCode"].ToString());
                 DataTable dtnew = RiLiGlobal.RiLiDataAcc.GetDataSet(sql).Tables[0];
                 foreach (DataRow drnew in dtnew.Rows)
                 {
                     if (drnew["ActualRepairPersonName"].ToString().Length <= 0)
                         continue;
                     item[drnew["ActualRepairPersonName"].ToString()] = drnew["icount"];
                 }
             }
            //foreach (DataRow item in dt.Rows)
            //{
            //    string regionName = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());

            //    if (regionName == string.Empty)
            //        continue;
               
            //        foreach (DataColumn dc in dt.Columns)
            //        {
            //            if (dc.ColumnName.StartsWith(regionName))
            //            {
            //                item[dc.ColumnName] = RepairTimeForPerson(item["FaultFeedbackId"].ToString(), dc.ColumnName.Replace(regionName, string.Empty));
            //            }
            //        }
                
            //}
        }


        public void ProcessBacsisData(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                //item["独立"] = IsAlone(item["RepairMissionCode"].ToString());
                //item["配件出库数"] = InvAppCount(item["RepairMissionCode"].ToString());
                //item["配件实际使用个数"] = ActreInvUse(item["RepairMissionCode"].ToString());
                //item["维修次数"] = RepairTime(item["FaultFeedbackId"].ToString());
               // item["完成时间"] = CompleteTime(item["FaultFeedbackId"].ToString());
               // item["配件申请"] = IsAppInv(item["RepairMissionCode"].ToString());
               // item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
               // item["旅途时间"] = TravelTime(item["RepairMissionCode"].ToString()).ToString();
               // item["故障解决时间"] = ProcessTime(item["RepairMissionCode"].ToString()).ToString();
                //item["响应时间"] = ResponeTime(item["RepairMissionCode"].ToString()).ToString();

                item["解决方案"] = solution(item["RepairMissionID"].ToString());
                item["故障类型"] = FaultType(item["RepairMissionID"].ToString());
                //item["故障解决方式"] = FinalSlution(item["RepairMissionID"].ToString());
                item["第一次旅途时间"] = FirstTravelTime(item["RepairMissionID"].ToString());

              
            }
        }

        public int FirstTravelTime(string RepId)
        {

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + RepId + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }
            int dd = 0;
            int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select  top 1 DATEDIFF(day, StartingDate , ReachDate) from FaultFeedbackDetails where FaultFeedBackID = (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + RepId + "') order by StartingDate"), out dd);

            return dd;
        }

        private string FaultType(string rid)
        {
            string sql = "select FaultType from FaultFeedback where RepairMissionID = '" + rid + "'";


            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);
        }
        private string FinalSlution(string rid)
        {
            string sql = "select Finalsolution from FaultFeedback where RepairMissionID = '" + rid + "'";


            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);
        }

        private int ResponeTime(string code)
        {

            try
            {
                DateTime reportDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ReportRepartDate from RepairMission where RepairMissionCode = '" + code + "'"));

                string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

                DateTime dd = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select min(ReachDate) from FaultFeedbackDetails where FaultFeedBackID in (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "') "));

            

                return  int.Parse( (dd.Date - reportDate.Date).TotalDays.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        private object solution(string id)
        {
            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == "完成")
            {
                string fid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select FaultFeedbackID from FaultFeedback where RepairMissionID = '" + id + "'");

                return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select top 1 Solution from FaultFeedbackDetails where FaultFeedBackID = '" + fid + "' and State = '完成' order by CompleteDate desc");
            }
            else
            {
                return string.Empty;
            }
        }

        private int TravelTime(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from RepairMission where RepairMissionCode = '" + code + "'");

            string isexsit = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "'");

            if (isexsit == string.Empty)
            {
                return 0;
            }
            int dd = 0;
            int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("    select sum( DATEDIFF(day, StartingDate , ReachDate)) from FaultFeedbackDetails where FaultFeedBackID = (select FaultFeedBackID from FaultFeedback where RepairMissionID = '" + id + "')"), out dd);

            return dd;
        }

        private double ProcessTime(string code)
        {
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



        public DateTime CompleteTime(string faultFeedBackId)
        {
            string sql = "select CompleteDate from FaultFeedback where FaultFeedbackId = '" + faultFeedBackId + "'";

            DateTime comptime;

            DateTime.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql), out comptime);


            return comptime;


        }

        public string IsAppInv(string Repcode)
        {
            string sql = "select * from PartsApplication where RepairMissionCode = '" + Repcode + "'";

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql).Rows.Count > 0)
            {
                return "是";
            }
            else
            {
                return "否";
            }
        }


        /// <summary>
        /// 当前省份下，工程师独立处理个数
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="zoneCode"></param>
        /// <returns></returns>
        public int RepairIndentCout(string userid, string zoneCode, string userName)
        {
            int count = 0;

            //         select COUNT(*) from FaultFeedback f 
            //left outer join RepairMission r on f.RepairMissionID = r.RepairMissionID 
            //left outer join FaultFeedbackDetails fd on fd.FaultFeedBackID = f.FaultFeedbackID
            //where r.RepairPersonCode ='eng' and ProcessingStatus = '完成' and r.ZoneCode = '03'  and fd.ActualRepairPersonName = '王工'

            //  RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select count(*) from "





            return count;
        }

        public int RepairTimeForPerson(string faultFeedBackId, string username)
        {
            string sql = "select count(*) from FaultFeedbackDetails where FaultFeedBackID = '" + faultFeedBackId + "' and ActualRepairPersonName = '" + username + "'";

            int count = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql), out count);

            return count;
        }


        public int RepairTime(string faultFeedBackId)
        {

            string sql = "select count(*) from FaultFeedbackDetails where FaultFeedBackID = '" + faultFeedBackId + "' ";

            int count = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql), out count);

            return count;
        }


        public void AddPersonAndRegionColumns(DataTable dt)
        {
            foreach (DataRow item in RiLiGlobal.RegionHelper.GetRegionList().Rows)
            {
                foreach (string pname in RiLiGlobal.RegionHelper.GetRepairPersonListByRegionName(item["RegionName"].ToString()))
                {
                    dt.Columns.Add(pname);
                }
            }
        }
        #region IU8Contral 成员

        public void Authorization()
        {
          
        }

        private string IsAlone(string code)
        {


            string personname = RiLiGlobal.RiLiDataAcc.ExecuteScalar(" select [RepairPersonName] from RepairMission where RepairMissionCode = '" + code + "'");

            string RepairId = RiLiGlobal.RiLiDataAcc.ExecuteScalar(" select [RepairMissionID] from RepairMission where RepairMissionCode = '" + code + "'");


            string result = "独立";

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

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.gridBand1.Columns.Clear();
            this.gridBand1.Collection.Clear();

             wcq = new WorkCountQuery();

            wcq.ShowDialog();


            WorkCountInit();
        }

        private void 导出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();


            this.gridBand1.View.ExportToXls(sf.FileName + ".xls");

            System.Windows.Forms.MessageBox.Show("导出成功");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //            string sql = string.Empty;

        //            sql = @"select ZoneName,ZoneCode,'' as  '大区',RepairPersonCode,RepairPersonName,RepairMissionID,  '维修' as '类别',0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率' from RepairMission union
        //select tRegName,tRegCode,'' as  '大区',tInsManger,tInsMangerName,tID,'安装' as '类别',0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from InstallTask  union
        //select sReqName,sRegnCode,'' as  '大区',sSupPerson,sSupPersonName,[sID],'销售支持' as '类别' ,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from SellSupport union
        //select  cRegion, tbRegionCode,'' as  '大区',cCallManger,cCallMangerName,cID,'销售回访' as '类别' ,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from CallBack";

        //            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);


        //            string sql2 = string.Empty;

        //            sql2 = @"select ZoneName,ZoneCode,'' as  '大区',RepairPersonCode,RepairPersonName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率' from RepairMission union
        //select tRegName,tRegCode,'' as  '大区',tInsManger,tInsMangerName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from InstallTask  union
        //select sReqName,sRegnCode,'' as  '大区',sSupPerson,sSupPersonName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from SellSupport union
        //select  cRegion, tbRegionCode,'' as  '大区',cCallManger,cCallMangerName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '独立处理故障数',0 as '处理故障成功率',0 as '申请配件数',0 as '实际使用数',0 as '配件使用率'  from CallBack";

        //            DataTable lastGuiData = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql2);


        //            string[] distinctcols = new string[(lastGuiData.Columns.Count)];
        //                foreach (DataColumn dc in lastGuiData.Columns)
        //              {
        //                  distinctcols[dc.Ordinal] = dc.ColumnName;
        //              }

        //              DataTable resultData;
        //              resultData = lastGuiData.Copy().DefaultView.ToTable(true, distinctcols);


        //              foreach (DataRow item in resultData.Rows)
        //              {
        //                  item["维修次数"] = lastdata.Compute("count(RepairPersonCode)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and 类别 =  '维修'");
        //                  item["安装次数"] = lastdata.Compute("count(RepairPersonCode)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and 类别 =  '安装'");

        ////                  item["回访次数"] = lastdata.Compute("count(RepairPersonCode)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and 类别 =  '销售回访'");

        ////                  item["销售支持次数"] = lastdata.Compute("count(RepairPersonCode)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and RepairPersonCode = '" + item["RepairPersonCode"].ToString() + "' and 类别 =  '销售支持'");


        //              }
    }
}
