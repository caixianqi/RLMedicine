using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class RegionWorkCountFilter : Bao.Report.FormFilterBase
    {
        public RegionWorkCountFilter()
        {
            InitializeComponent();
            this.SearchWhere = new DataTable("SearchWhere");
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");
          
        }

        private void RegionWorkCountFilter_OnSearchWhere()
        {
            string sql = " select  '' as '大区', '维修' as billtype, r.RepairMissionCode, ZoneCode,ZoneName,fd.ActualRepairPersonName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '总计',r.* from RepairMission r inner join FaultFeedback f inner join FaultFeedbackDetails fd on f.FaultFeedbackID = fd.FaultFeedBackID on f.RepairMissionID = r.RepairMissionID  where f.CompleteDate between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.AddSeconds(86399).ToString() + "' and IsEnd = '已结案'  union " +
        "select  '' as '大区',  '安装' as billtype,ind.rTaskCode,ins.tRegCode,ins.tRegName,ind.rInsName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '总计' from InsDetail ind inner join InstallTask ins on ind.rTaskCode = ins.tInsCode where ins.fMessagedate between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.AddSeconds(86399).ToString() + "' and tState = '已核对' union " +
        "select   '' as '大区',  '销售支持'  as billtype,ssupcode,s.sRegnCode,s.sRegname,sSuppersonName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '总计' from   SellSupport s where sMessagedate  between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.AddSeconds(86399).ToString() + "'and (sAuditPerson is not null and sAuditPerson<>'')  union " +
        "select   '' as '大区',  '回访'  as billtype,cTaskCode,tbRegionCode,cRegion,cCallMangerName,0 as '维修次数',0 as '安装次数',0 as '回访次数',0 as '销售支持次数',0 as '总计' from   CallBack c where c.cMessagedate between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.AddSeconds(86399).ToString() + "' and (cAuditMessageId is not null and cAuditMessageId<>'') ";

            DataTable bacTable = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);




            DataTable cuountTable = bacTable.DefaultView.ToTable(true, "大区", "ZoneCode", "ZoneName", "ActualRepairPersonName","维修次数","安装次数","回访次数","销售支持次数","总计");

            //cuountTable.Columns.Add("维修次数");
            //cuountTable.Columns.Add("安装次数");
            //cuountTable.Columns.Add("回访次数");
            //cuountTable.Columns.Add("销售支持次数");
            //cuountTable.Columns.Add("总计");


            foreach (DataRow item in cuountTable.Rows)
            {
                item["维修次数"] = bacTable.Compute("count(billtype)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and ActualRepairPersonName = '" + item["ActualRepairPersonName"].ToString() + "' and billtype = '维修'");
                item["安装次数"] = bacTable.Compute("count(billtype)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and ActualRepairPersonName = '" + item["ActualRepairPersonName"].ToString() + "' and billtype = '安装'");
                item["回访次数"] = bacTable.Compute("count(billtype)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and ActualRepairPersonName = '" + item["ActualRepairPersonName"].ToString() + "' and billtype = '回访'");
                item["销售支持次数"] = bacTable.Compute("count(billtype)", "ZoneCode = '" + item["ZoneCode"].ToString() + "' and ActualRepairPersonName = '" + item["ActualRepairPersonName"].ToString() + "' and billtype = '销售支持'");
            }


            foreach (DataRow item in cuountTable.Rows)
            {
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
                item["总计"] = int.Parse(item["维修次数"].ToString()) + int.Parse(item["安装次数"].ToString()) + int.Parse(item["回访次数"].ToString()) + int.Parse(item["销售支持次数"].ToString());

            }

            this.DataSourceTable = cuountTable;
            

          
            
        }


    }
}
