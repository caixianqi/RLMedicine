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
    public partial class PartsInentoryList : FormChildBase, Bao.Interface.IU8Contral
    {
         public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public PartsInentoryList(string RepairMissionCode)
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init(RepairMissionCode);
        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["PartsInventoryID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

        private void init(string RepairMissionCode)
          {
              gridControl1.Focus();
              string sql = string.Empty;
              if (RepairMissionCode != "")
              {
                  sql = string.Format("exec sp_PartsInventoryList '{0}','{1}','{2}','{3}','{4}'", "", "", RepairMissionCode, "", "");
              }
              else
              {
                  sql = string.Format("exec sp_PartsInventoryList '{0}','{1}','{2}','{3}','{4}'"
                                 , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);
              }

              this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);

        }
        //  public void init()
        //  {
        //      DataTable dt003 = new DataTable();
        //      DataTable dt002 = new DataTable();
        //      DataTable dt001 = new DataTable();
        //      DataTable dt008 = new DataTable();

        //      try
        //      {
        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
        //          {
        //              dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join RepairMission r on p.RepairMissionCode = r.RepairMissionCode left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID   where r.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by pa.ApplicationDate desc");

        //          }
        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
        //          {
        //              dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by pa.ApplicationDate desc");
        //              dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数'  from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") order by pa.ApplicationDate desc"));
        //          }

        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
        //          {
        //              dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode order by pa.ApplicationDate desc");
        //          }

        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
        //          {
        //              dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode  where  r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") order by pa.ApplicationDate desc");
        //          }

        //          dt001.Merge(dt008);
        //          dt001.Merge(dt002);
        //          dt001.Merge(dt003);
        //          string[] distinctcols = new string[(dt001.Columns.Count)];
        //          foreach (DataColumn dc in dt001.Columns)
        //          {
        //              distinctcols[dc.Ordinal] = dc.ColumnName;
        //          }


        //          dt001 = dt001.DefaultView.ToTable(true, distinctcols);


        //          foreach (DataRow item in dt001.Rows)
        //          {
        //              item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
        //              item["申请个数"] = AppCout(item["PartsApplicationCode"].ToString());
        //              item["出库个数"] = outCout(item["PartsInventoryID"].ToString());
        //              item["归还个数"] = returnCout(item["PartsInventoryID"].ToString());
        //          }
        //          this.gridControl1.DataSource = dt001;


        //          this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        //      }
        //      catch (Exception ex)
        //      {
        //          MessageBox.Show("初始化界面失败：" + ex.Message);
        //      }
        //  }

        //  public void init(DateTime beginTime, DateTime endTime)
        //  {
        //      DataTable dt003 = new DataTable();
        //      DataTable dt002 = new DataTable();
        //      DataTable dt001 = new DataTable();
        //      DataTable dt008 = new DataTable();

        //      if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
        //      {
        //          dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join RepairMission r on p.RepairMissionCode = r.RepairMissionCode left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID   where r.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and pa.ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

        //      }
        //      if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
        //      {
        //          dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'and pa.ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
        //          dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数'  from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and pa.ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
        //      }

        //      if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
        //      {
        //          dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode and pa.ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
        //      }

        //      if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
        //      {
        //          dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode  where  r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and pa.ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
        //      }

        //      dt001.Merge(dt008);
        //      dt001.Merge(dt002);
        //      dt001.Merge(dt003);
        //      string[] distinctcols = new string[(dt001.Columns.Count)];
        //      foreach (DataColumn dc in dt001.Columns)
        //      {
        //          distinctcols[dc.Ordinal] = dc.ColumnName;
        //      }


        //      dt001 = dt001.DefaultView.ToTable(true, distinctcols);


        //      foreach (DataRow item in dt001.Rows)
        //      {
        //          item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
        //          item["申请个数"] = AppCout(item["PartsApplicationCode"].ToString());
        //          item["出库个数"] = outCout(item["PartsInventoryID"].ToString());
        //          item["归还个数"] = returnCout(item["PartsInventoryID"].ToString());
        //      }
        //      this.gridControl1.DataSource = dt001;


        //      this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);

        //  }

        ///// <summary>
        ///// 根据维修任务编码查询显示出来
        ///// </summary>
        ///// <param name="RepairMissionCode"></param>
        //  public void init(string RepairMissionCode)
        //  {
        //      DataTable dt003 = new DataTable();
        //      DataTable dt002 = new DataTable();
        //      DataTable dt001 = new DataTable();
        //      DataTable dt008 = new DataTable();

        //      try
        //      {
        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
        //          {
        //              dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join RepairMission r on p.RepairMissionCode = r.RepairMissionCode left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID   where r.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and p.RepairMissionCode = '" + RepairMissionCode + "' order by pa.ApplicationDate desc");

        //          }
        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
        //          {
        //              dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and p.RepairMissionCode = '" + RepairMissionCode + "' order by pa.ApplicationDate desc");
        //              dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数'  from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and p.RepairMissionCode = '" + RepairMissionCode + "' and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") order by pa.ApplicationDate desc"));
        //          }

        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
        //          {
        //              dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode where p.RepairMissionCode = '" + RepairMissionCode + "' order by pa.ApplicationDate desc");
        //          }

        //          if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
        //          {
        //              dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300 p.*,pa.PartsApplicationCode,pa.ApplicationDate,r.*,'' as '大区',0 as '申请个数',0 as '出库个数',0 as '归还个数' from PartsInventory p left outer join PartsApplication pa  on pa.PartsApplicationID =  p.PartsApplicationID left outer join RepairMission r on r.RepairMissionCode = p.RepairMissionCode  where  r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and p.RepairMissionCode = '" + RepairMissionCode + "' order by pa.ApplicationDate desc");
        //          }

        //          dt001.Merge(dt008);
        //          dt001.Merge(dt002);
        //          dt001.Merge(dt003);
        //          string[] distinctcols = new string[(dt001.Columns.Count)];
        //          foreach (DataColumn dc in dt001.Columns)
        //          {
        //              distinctcols[dc.Ordinal] = dc.ColumnName;
        //          }


        //          dt001 = dt001.DefaultView.ToTable(true, distinctcols);


        //          foreach (DataRow item in dt001.Rows)
        //          {
        //              item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
        //              item["申请个数"] = AppCout(item["PartsApplicationCode"].ToString());
        //              item["出库个数"] = outCout(item["PartsInventoryID"].ToString());
        //              item["归还个数"] = returnCout(item["PartsInventoryID"].ToString());
        //          }
        //          this.gridControl1.DataSource = dt001;


        //          this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        //      }
        //      catch (Exception ex)
        //      {
        //          MessageBox.Show("初始化界面失败：" + ex.Message);
        //      }
        //  }

        //  public int AppCout(string code)
        //  {
        //      string sql = "select sum(iquantity) from PartsApplication p inner join PartsApplicationDetails pd on p.PartsApplicationID = pd.PartsApplicationID where p.PartsApplicationCode = '" + code + "'";

        //      string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

        //      if (result == string.Empty)

        //          return 0;

        //      else
        //      {
        //          return int.Parse(result);
        //      }
        //  }
        //  public int outCout(string invid)
        //  {
        //      string sql = "select sum(iquantity) from PartsInventoryDetails  where PartsInventoryID = '" + invid + "'";

        //      string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

        //      if (result == string.Empty)

        //          return 0;

        //      else
        //      {
        //          return int.Parse(result);
        //      }
            
        //  }
        //  public int returnCout(string invid)
        //  {
        //      string sql = "select sum(iquantity) from PartsUseAndReturnInfo  where PartsInventoryID = '" + invid + "'";

        //      string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

        //      if (result == string.Empty)

        //          return 0;

        //      else
        //      {
        //          return int.Parse(result);
        //      }
        
        //  }

          public PartsInentoryList()
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init("");
        }

     
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["PartsInventoryID"].ToString();

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

           Repair.PartsInentory mision = new PartsInentory(id);

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
            //lq.label2.Text = "配件申请时间";
            //lq.ShowDialog();

            //init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
