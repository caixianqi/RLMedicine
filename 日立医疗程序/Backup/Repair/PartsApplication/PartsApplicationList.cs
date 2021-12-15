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
    public partial class PartsApplicationList :FormChildBase, Bao.Interface.IU8Contral
    {
        public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public PartsApplicationList(string query)
        {
            InitializeComponent();

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("   select rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  (rm.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' or rm.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "') " + query);

            gridView1.OptionsBehavior.Editable = false;

            this.gridControl1.DataSource = dt;


            this.gridControl1.DoubleClick += new EventHandler(gridControl1ForFault_DoubleClick);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["FaultFeedbackID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

          public void init()
          {
            

              DataTable dt = new DataTable();

              DataTable dt008009 = new DataTable();

              DataTable dt001007 = new DataTable();

              DataTable dt003 = new DataTable();

              DataTable dt002 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
              {
                  dt008009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select '' as '申请状态',p.*,rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where rm.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and ApplicationPersonCode is not null and ApplicationPersonCode <>''");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001007 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select '' as '申请状态',p.*,rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID");
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  (rm.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' or rm.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  rm.ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")"));
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  ( rm.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')");
              }

              dt.Merge(dt001007);
              dt.Merge(dt002);
              dt.Merge(dt003);
              dt.Merge(dt008009);

              gridView1.OptionsBehavior.Editable = false;

              foreach (DataRow  item in dt.Rows)
              {
                  if (item["AuditName"].ToString() == string.Empty)
                  {
                      item["申请状态"] = "配件申请";
                  }
                  else
                  {
                      item["申请状态"] = "审核通过";
                  }

                  item["CustomerDepartmentName"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }
              string[] distinctcols = new string[(dt.Columns.Count)];
              foreach (DataColumn dc in dt.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }
              dt = dt.DefaultView.ToTable(true, distinctcols);


              this.gridControl1.DataSource = dt;


              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }


          public void init(DateTime beginTime,DateTime endTime)
          {
              DataTable dt = new DataTable();

              DataTable dt008009 = new DataTable();

              DataTable dt001007 = new DataTable();

              DataTable dt003 = new DataTable();

              DataTable dt002 = new DataTable();

              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
              {
                  dt008009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select '' as '申请状态',p.*,rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where rm.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and ApplicationPersonCode is not null and ApplicationPersonCode <>'' and ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }
               if (UFBaseLib.BusLib.BaseInfo.userRole.Contains( "001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
              {
                  dt001007 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select '' as '申请状态',p.*,rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }
              if( UFBaseLib.BusLib.BaseInfo.userRole.Contains( "002"))
              {
                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  (rm.CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' or rm.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')  and ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

                  dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  rm.ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")  and ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
              }
              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
              {
                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("  select '' as '申请状态',p.*, rm.*,p.PartsApplicationID,p.RepairMissionID,p.ApplicationDate,p.ApplicationPersonCode, pin.StateInOut,pin.StateReturn,p.PartsApplicationCode,pin.* from PartsApplication p left outer join RepairMission rm on rm.RepairMissionID = p.RepairMissionID left outer join PartsInventory pin on p.PartsApplicationID = pin.PartsApplicationID where  ( rm.RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')  and ApplicationDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
              }

              dt.Merge(dt001007);
              dt.Merge(dt002);
              dt.Merge(dt003);
              dt.Merge(dt008009);

              gridView1.OptionsBehavior.Editable = false;

              foreach (DataRow item in dt.Rows)
              {
                  if (item["AuditName"].ToString() == string.Empty)
                  {
                      item["申请状态"] = "配件申请";
                  }
                  else
                  {
                      item["申请状态"] = "审核通过";
                  }

                  item["CustomerDepartmentName"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
              }
              string[] distinctcols = new string[(dt.Columns.Count)];
              foreach (DataColumn dc in dt.Columns)
              {
                  distinctcols[dc.Ordinal] = dc.ColumnName;
              }
              dt = dt.DefaultView.ToTable(true, distinctcols);
              this.gridControl1.DataSource = dt;


              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
          }

          public PartsApplicationList()
          {
            InitializeComponent();
            init();    
          }

     
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;

            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["PartsApplicationID"].ToString();

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

           Repair.PartsApplication mision = new PartsApplication(id);

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
            lq.label2.Text = "配件申请时间";
            lq.ShowDialog();

            init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
