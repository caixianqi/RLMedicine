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
    public partial class AmountManagementFilter : Bao.Report.FormFilterBase
    {
        public static string[] RegionName;//地区
        public string resql;
        public AmountManagementFilter()
        {
            InitializeComponent();
            RegionName = new string[0];
            this.SearchWhere = new DataTable("SearchWhere");


            txtregion.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass";
            txtregion.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.txtregion.FrmHigth = 600;
            this.txtregion.FrmWidth = 400;
            txtregion.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass where cDCCODE=";
            txtregion.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            txtregion.BaoClickClose = true;
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");
        }

        public override string OnSQL()
        {
            return string.Empty;
        }
        private void AmountManagementFilter_OnExceSQL(object sender, EventArgs e)
        {
            
        }

        private void AmountManagementFilter_OnSearchWhere()
        {
            string sql = string.Empty;

            sql = @"select '' as '大区',r.ZoneCode as '省份编码',r.ZoneName as '省份', r.repairMissionCode as '维修编号',r.CustomerName as '医院名',r.MachineName as '主机型号',r.ManufactureCode as '制造编号',p.priceDate as '报价日期',p.ApplicationPerson as '报价申请人',p.InventoryName as '报价内容',p.ReviewDate as '回执日期',b.BillTitle as '发票抬头',b.UploadDate as '申请开票日期', b.AppPerson as '开票申请人',
(select sum([money]) from BillDetails bs where bs.BillId = b.billid ) as '申请金额',
b.ReceivePerson as '收件人',b.BillNum as '发票号',b.emsNum as 'EMS号码',b.UploadSendBillDate as '发票寄出日期',
(select sum([money]) from MoneyReceive  mr where mr.BillId = b.billid ) as '到款金额',

(select  DATEDIFF(day, b.SendBillDate , max( mr2.MoneyReceiveDate)) from MoneyReceive mr2   where mr2.BillId = b.billid) as '付款周期',
(select sum([money]) from BillDetails bs where bs.BillId = b.billid )-(select sum([money]) from MoneyReceive  mr where mr.BillId = b.billid ) as '余额',
(select  max( mr2.MoneyReceiveDate) from MoneyReceive mr2   where mr2.BillId = b.billid) as '最后到款日期'



 from RepairMission r left outer join Price p on p.RepairMissionID = r.RepairMissionID left outer join BILL b on b.PriceID = p.PriceID where 1=1 ";

         //   sql = string.Format(sql, BeginTime.Value.ToShortDateString(), EndTime.Value.ToShortDateString());



            if (bprice.Checked)
            {
                sql += " and p.priceDate between '" + BeginTime.Value.ToShortDateString() + "' and '" + EndTime.Value.AddDays(1).ToShortDateString() + "' ";
            }
            if (breview.Checked) 
            {
                sql += " and p.ReviewDate between '" + ReviewBeginTime.Value.ToShortDateString() + "' and '" + ReviewEndTime.Value.AddDays(1).ToShortDateString() + "' ";
            }
            if (bapp.Checked)
            {
                sql += " and b.UploadDate  between '" + AppBeginTime.Value.ToShortDateString() + "' and '" + AppEndTime.Value.AddDays(1).ToShortDateString() + "' ";
            }
            if (bregion.Checked)
            {
                if (RegionName.Length > 0)
                {
                    resql = " and (";
                    for (int k = 0; k < RegionName.Length; k++)
                    {
                        if (k < RegionName.Length - 1)
                        {
                            resql += "r.ZoneName='" + RegionName[k] + "' or ";
                        }
                        else
                        {
                            resql += "r.ZoneName='" + RegionName[k] + "')";
                        }
                    }
                }
            }

            sql += resql;


            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            //foreach (DataRow item in lastdata.Rows)
            //{
            //    item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["省份编码"].ToString());
            //}


        
            this.DataSourceTable = lastdata;
        }

        private void txtregion_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            txtregion.Text = dr["CDCCODE"].ToString();
            txtregionName.Text = dr["CDCNAME"].ToString();
        }

        private void btnregion_Click(object sender, EventArgs e)
        {
            if (txtregionName.Text == "")
            {
                return;
            }
            int length = RegionName.Length;
            Array.Resize(ref RegionName, length + 1);
            RegionName[length] = txtregionName.Text;
            listBox3.DataSource = RegionName;
            txtregion.Text = "";
            txtregionName.Text = "";
        }

        private void BtnRemoved3_Click(object sender, EventArgs e)
        {

            if (RegionName.Length == 0)
            {
                return;
            }
            int i = listBox3.SelectedIndex;
            int length = RegionName.Length;
            RegionName[i] = RegionName[length - 1];
            Array.Resize(ref RegionName, length - 1);
            listBox3.DataSource = RegionName;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EndTime_ValueChanged(object sender, EventArgs e)
        {

        }

     
    }
}
