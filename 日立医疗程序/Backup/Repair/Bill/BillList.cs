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
    public partial class BillList :FormChildBase, Bao.Interface.IU8Contral
    {
        public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public BillList(string query)
        {
            InitializeComponent();

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("   select * from Bill where AppPersonId = '"+UFBaseLib.BusLib.BaseInfo.DBUserID+"' and " + query);

            gridView1.OptionsBehavior.Editable = false;

            this.gridControl1.DataSource = dt;


            this.gridControl1.DoubleClick += new EventHandler(gridControl1ForFault_DoubleClick);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["BillID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

          public void init()
          {
              DataTable dt = new DataTable();
              DataTable dt003 = new DataTable();
              DataTable dt002 = new DataTable();
              DataTable dt001 = new DataTable();
              DataTable dt008 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by b.UploadDate desc");
              }
               if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc ");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc"));
              }
               if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  (b.BillState = '审核通过' or b.BillState = '寄票' or b.BillState = '到款') order by b.UploadDate desc");
              }
               if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008")  || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
               {
                   dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc");
               }



               dt008.Merge(dt003);
               dt008.Merge(dt002);
               dt008.Merge(dt001);


               string[] distinctcols = new string[(dt008.Columns.Count)];
              foreach (DataColumn dc in dt008.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }


              dt008 = dt008.DefaultView.ToTable(true, distinctcols);




              foreach (DataRow item in dt008.Rows)
              {
                  string dd  =RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([Money])  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
                  if(dd == string.Empty)
                  {
                      item["到款金额"] = 0;
                  }
                      else
                      {
                          item["到款金额"] = decimal.Parse(dd);
                      }

                  string ap = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([money])  from BillDetails where BillID ='" + item["BillID"].ToString() + "'");
                  if (ap == string.Empty)
                  {
                      item["申请金额"] = 0;
                  }
                  else
                  {
                      item["申请金额"] = decimal.Parse(ap);
                  }

                  item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }


              this.gridControl1.DataSource = dt008;




              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }


          public void init(DateTime beginTime,DateTime endTime)
          {
              DataTable dt = new DataTable();
              DataTable dt003 = new DataTable();
              DataTable dt002 = new DataTable();
              DataTable dt001 = new DataTable();
              DataTable dt008 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  (b.BillState = '审核通过' or b.BillState = '寄票' or b.BillState = '到款') and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
              {
                  dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }



              dt008.Merge(dt003);
              dt008.Merge(dt002);
              dt008.Merge(dt001);


              string[] distinctcols = new string[(dt008.Columns.Count)];
              foreach (DataColumn dc in dt008.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }


              dt008 = dt008.DefaultView.ToTable(true, distinctcols);




              foreach (DataRow item in dt008.Rows)
              {
                  string dd = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([Money])  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
                  if (dd == string.Empty)
                  {
                      item["到款金额"] = 0;
                  }
                  else
                  {
                      item["到款金额"] = decimal.Parse(dd);
                  }

                  string ap = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([money])  from BillDetails where BillID ='" + item["BillID"].ToString() + "'");
                  if (ap == string.Empty)
                  {
                      item["申请金额"] = 0;
                  }
                  else
                  {
                      item["申请金额"] = decimal.Parse(ap);
                  }

                  item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }


              this.gridControl1.DataSource = dt008;




              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }

          public BillList()
        {
            InitializeComponent();


            init();
           

           
        }

     
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            gridView1.OptionsBehavior.Editable = false;
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["BillID"].ToString();

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

           Repair.Bill mision = new Bill(id);

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

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListQuery lq = new ListQuery();
            lq.label2.Text = "开票申请时间";
            lq.ShowDialog();

            init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
