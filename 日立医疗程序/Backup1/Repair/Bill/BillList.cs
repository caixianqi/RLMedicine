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
        public BillList(string RepairMissionCode)
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init(RepairMissionCode);

        }

        private void init(string RepairMissionCode)
        {
            gridControl1.Focus();
            string sql = string.Empty;
            if (RepairMissionCode != "")
            {
                sql = string.Format("exec sp_BillList '{0}','{1}','{2}','{3}','{4}'", "", "", RepairMissionCode, "", UFBaseLib.BusLib.BaseInfo.DBUserID);
            }
            else
            {
                sql = string.Format("exec sp_BillList '{0}','{1}','{2}','{3}','{4}'"
                               , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);
            }

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        }
          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["BillID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

//          public void init()
//          {
//              this.init("");
////              DataTable dt = new DataTable();
////              DataTable dt003 = new DataTable();
////              DataTable dt002 = new DataTable();
////              DataTable dt001 = new DataTable();
////              DataTable dt008 = new DataTable();
////              string sql = string.Empty;
////              try
////              {
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
////                  {
////                      dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by b.UploadDate desc");
////                  }
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
////                  {
////                      dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc ");

////                      //dt002.Merge(RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc"));
////                  }
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
////                  {
////                      dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  (b.BillState = '审核通过' or b.BillState = '寄票' or b.BillState = '到款') order by b.UploadDate desc");
////                  }
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
////                  {
////                      sql = string.Format(@"select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    
////                                            where b.PriceId = p.PriceId and r.city in (select b.ProvinceName from [Users] a 
////                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
////                                                            where a.userid = '{0}') and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc"
////                                         , UFBaseLib.BusLib.BaseInfo.DBUserID
////                          );
////                      dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
////                  }



////                  dt008.Merge(dt003);
////                  dt008.Merge(dt002);
////                  dt008.Merge(dt001);


////                  string[] distinctcols = new string[(dt008.Columns.Count)];
////                  foreach (DataColumn dc in dt008.Columns)
////                  {
////                      distinctcols[dc.Ordinal] = dc.ColumnName;
////                  }


////                  dt008 = dt008.DefaultView.ToTable(true, distinctcols);




////                  foreach (DataRow item in dt008.Rows)
////                  {
////                      string dd = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([Money])  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
////                      if (dd == string.Empty)
////                      {
////                          item["到款金额"] = 0;
////                      }
////                      else
////                      {
////                          item["到款金额"] = decimal.Parse(dd);
////                      }

////                      string ap = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([money])  from BillDetails where BillID ='" + item["BillID"].ToString() + "'");
////                      if (ap == string.Empty)
////                      {
////                          item["申请金额"] = 0;
////                      }
////                      else
////                      {
////                          item["申请金额"] = decimal.Parse(ap);
////                      }

////                      item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
////                  }

////                  this.gridControl1.DataSource = dt008;
////                  this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
////              }
////              catch (Exception ex)
////              {
////                  MessageBox.Show("初始化界面失败：" + ex.Message);
////              }
//          }


//          public void init(DateTime beginTime,DateTime endTime)
//          {
//              DataTable dt = new DataTable();
//              DataTable dt003 = new DataTable();
//              DataTable dt002 = new DataTable();
//              DataTable dt001 = new DataTable();
//              DataTable dt008 = new DataTable();

//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//              {
//                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//              }
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//              {
//                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");

//                  dt002.Merge(RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
//              }
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
//              {
//                  dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  (b.BillState = '审核通过' or b.BillState = '寄票' or b.BillState = '到款') and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");
//              }
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
//              {
//                  dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' and b.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//              }



//              dt008.Merge(dt003);
//              dt008.Merge(dt002);
//              dt008.Merge(dt001);


//              string[] distinctcols = new string[(dt008.Columns.Count)];
//              foreach (DataColumn dc in dt008.Columns)
//              {
//                  distinctcols[dc.Ordinal] = dc.ColumnName;
//              }


//              dt008 = dt008.DefaultView.ToTable(true, distinctcols);




//              foreach (DataRow item in dt008.Rows)
//              {
//                  string dd = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([Money])  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
//                  if (dd == string.Empty)
//                  {
//                      item["到款金额"] = 0;
//                  }
//                  else
//                  {
//                      item["到款金额"] = decimal.Parse(dd);
//                  }

//                  string ap = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([money])  from BillDetails where BillID ='" + item["BillID"].ToString() + "'");
//                  if (ap == string.Empty)
//                  {
//                      item["申请金额"] = 0;
//                  }
//                  else
//                  {
//                      item["申请金额"] = decimal.Parse(ap);
//                  }

//                  item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//              }


//              this.gridControl1.DataSource = dt008;




//              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
//          }

//        /// <summary>
//        /// 根据维修任务编码查询显示出来
//        /// </summary>
//        /// <param name="abc"></param>
//          public void init(string RepairMissionCode)
//          {
//              DataTable dt = new DataTable();
//              DataTable dt003 = new DataTable();
//              DataTable dt002 = new DataTable();
//              DataTable dt001 = new DataTable();
//              DataTable dt008 = new DataTable();
//              string sql = string.Empty;
//              string relation = "";
//              if (RepairMissionCode.Length > 0)
//              {
//                  relation = " and p.RepairMissionCode  = '" + RepairMissionCode + "'";
//              }
//              try
//              {
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//                  {
//                      dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' " + relation + " order by b.UploadDate desc");
//                  }
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                  {
//                      dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and b.UploadPerson is not null and b.UploadPerson <>'' " + relation + " order by b.UploadDate desc ");

//                      //dt002.Merge(RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and b.UploadPerson is not null and b.UploadPerson <>'' order by b.UploadDate desc"));
//                  }
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
//                  {
//                      dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区'  from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    where b.PriceId = p.PriceId and  (b.BillState = '审核通过' or b.BillState = '寄票' or b.BillState = '到款') " + relation + " order by b.UploadDate desc");
//                  }
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                  {
//                      sql = string.Format(@"select top 300 b.*,p.RepairMissionCode,r.*,0 as '申请金额',0 as '到款金额','' as '大区' from Bill b,Price p left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode    
//                                            where b.PriceId = p.PriceId and r.city in (select b.ProvinceName from [Users] a 
//                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
//                                                            where a.userid = '{0}') and b.UploadPerson is not null and b.UploadPerson <>'' {1} order by b.UploadDate desc"
//                                         , UFBaseLib.BusLib.BaseInfo.DBUserID,relation
//                          );
//                      dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
//                  }



//                  dt008.Merge(dt003);
//                  dt008.Merge(dt002);
//                  dt008.Merge(dt001);


//                  string[] distinctcols = new string[(dt008.Columns.Count)];
//                  foreach (DataColumn dc in dt008.Columns)
//                  {
//                      distinctcols[dc.Ordinal] = dc.ColumnName;
//                  }


//                  dt008 = dt008.DefaultView.ToTable(true, distinctcols);




//                  foreach (DataRow item in dt008.Rows)
//                  {
//                      item["MachineName"] = item["MachineName"].ToString() == "" ? item["machinemodel"] : item["MachineName"].ToString();
//                      //string dd = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([Money]) as Money,max(moneyreceivedate) as redate  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
//                      DataTable dtemp = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  SUM([Money]) as Money,max(moneyreceivedate) as redate  from MoneyReceive where BillID ='" + item["BillID"].ToString() + "'");
//                      if (dtemp.Rows.Count<=0)
//                      {
//                          item["到款金额"] = 0;
//                          item["UploadReceiveDate"] = DBNull.Value;
//                      }
//                      else
//                      {
//                          item["到款金额"] = decimal.Parse(dtemp.Rows[0]["Money"].ToString() == "" ? "0" : dtemp.Rows[0]["Money"].ToString());
//                          if (dtemp.Rows[0]["redate"].ToString().Length>0)
//                            item["UploadReceiveDate"] = dtemp.Rows[0]["redate"].ToString();
//                      }

//                      string ap = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select  SUM([money])  from BillDetails where BillID ='" + item["BillID"].ToString() + "'");
//                      if (ap == string.Empty)
//                      {
//                          item["申请金额"] = 0;
//                      }
//                      else
//                      {
//                          item["申请金额"] = decimal.Parse(ap) + (item["TravelCost"].ToString() == "" ? 0 : Convert.ToDecimal(item["TravelCost"]))
//                                                + (item["RepairCost"].ToString() == "" ? 0 : Convert.ToDecimal(item["RepairCost"]));
//                      }

//                      //item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//                  }

//                  this.gridControl1.DataSource = dt008;
//                  this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
//              }
//              catch (Exception ex)
//              {
//                  MessageBox.Show("初始化界面失败：" + ex.Message);
//              }
//          }

          public BillList()
        {
            InitializeComponent();

            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init("");
           
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
            init("");
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
            //ListQuery lq = new ListQuery();
            //lq.label2.Text = "开票申请时间";
            //lq.ShowDialog();

            //init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
