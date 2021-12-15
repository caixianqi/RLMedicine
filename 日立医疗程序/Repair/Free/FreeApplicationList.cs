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
    public partial class FreeApplicationList : FormChildBase, Bao.Interface.IU8Contral
    {
         public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public FreeApplicationList(string RepairMissionID)
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init(RepairMissionID);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["FreeID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

        private void init(string RepairMissionID)
        {
            gridControl1.Focus();
            string sql = string.Empty;
            if (RepairMissionID != "")
            {
                sql = string.Format("exec sp_FreeApplicationList '{0}','{1}','{2}','{3}','{4}'", "", "", RepairMissionID, "", UFBaseLib.BusLib.BaseInfo.DBUserID);
            }
            else
            {
                sql = string.Format("exec sp_FreeApplicationList '{0}','{1}','{2}','{3}','{4}'"
                               , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);
            }

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        }
//          public void init(DateTime beginTime, DateTime endTime)
//          {
//              DataTable dt003 = new DataTable();
//              DataTable dt002 = new DataTable();
//              DataTable dt008 = new DataTable();
//              DataTable dt009 = new DataTable();

//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//              {
//                  dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区' from FreeApplication p ,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

//              }
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//              {
//                  dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'  and UploadPerson is not null and UploadPerson <>'' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

//                  dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")  and UploadPerson is not null and UploadPerson <>''and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' "));
//              }
             
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
//              {
//                  dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' and  p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");
//              }
//              if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
//              {
//                  dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' and  p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");
//              }


//              dt003.Merge(dt008);
//              dt003.Merge(dt002);
//              dt003.Merge(dt009);

//              string[] distinctcols = new string[(dt003.Columns.Count)];
//              foreach (DataColumn dc in dt003.Columns)
//              {
//                  distinctcols[dc.Ordinal] = dc.ColumnName;
//              }


//              dt003 = dt003.DefaultView.ToTable(true, distinctcols);


//              //foreach (DataRow item in dt003.Rows)
//              //{
//              //    item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//              //}
//              this.gridControl1.DataSource = dt003;


//              this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);

//          }


//          public void init()
//          {
//              this.init("");
////              DataTable dt003 = new DataTable();
////              DataTable dt002 = new DataTable();
////              //DataTable dt008 = new DataTable();
////              DataTable dt009 = new DataTable();
////              string sql = string.Empty;
////              try
////              {
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
////                  {
////                      dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,r.*,'' as '大区' from FreeApplication p ,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by p.UploadDate desc");

////                  }
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
////                  {
////                      dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'  and UploadPerson is not null and UploadPerson <>''  order by p.UploadDate desc");

////                      sql = string.Format(@"select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  
////                                            where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '{0}' 
////                                            and r.city in (select b.ProvinceName from [Users] a 
////                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
////                                                            where a.userid = '{0}')
////                                            and UploadPerson is not null and UploadPerson <>''  order by p.UploadDate desc", UFBaseLib.BusLib.BaseInfo.DBUserID);
////                      dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql));
////                  }

////                  //if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
////                  //{
////                  //    dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>''  order by p.UploadDate desc");
////                  //}
////                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
////                  {
////                      sql = string.Format(@"select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode
////                                            and r.city in (select b.ProvinceName from [Users] a 
////                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
////                                                            where a.userid = '{0}')
////                                            and UploadPerson is not null and UploadPerson <>''  order by p.UploadDate desc", UFBaseLib.BusLib.BaseInfo.DBUserID);
////                      dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
////                  }


////                  //dt003.Merge(dt008);
////                  dt003.Merge(dt002);
////                  dt003.Merge(dt009);

////                  string[] distinctcols = new string[(dt003.Columns.Count)];
////                  foreach (DataColumn dc in dt003.Columns)
////                  {
////                      distinctcols[dc.Ordinal] = dc.ColumnName;
////                  }


////                  dt003 = dt003.DefaultView.ToTable(true, distinctcols);


////                  foreach (DataRow item in dt003.Rows)
////                  {
////                      item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
////                  }
////                  this.gridControl1.DataSource = dt003;


////                  this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
////              }
////              catch (Exception ex)
////              {
////                  MessageBox.Show("初始化界面失败：" + ex.Message);
////              }
//          }

//        /// <summary>
//        /// 根据维修任务ID查询显示出来
//        /// </summary>
//        /// <param name="RepairMissionID"></param>
//          public void init(string RepairMissionID)
//          {
//              DataTable dt003 = new DataTable();
//              DataTable dt002 = new DataTable();
//              DataTable dt009 = new DataTable();
//              string sql = string.Empty;
//              string relation = "";
//              if (RepairMissionID.Length > 0)
//              {
//                  relation = " and p.RepairMissionID = '" + RepairMissionID + "'";
//              }
//              try
//              {
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//                  {
//                      dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,r.*,'' as '大区' from FreeApplication p ,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and AppPersonId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' " + relation + " order by p.UploadDate desc");

//                  }
//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                  {
//                      dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'  and UploadPerson is not null and UploadPerson <>'' " + relation + " order by p.UploadDate desc");

//                      sql = string.Format(@"select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  
//                                            where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '{0}' 
//                                            and r.city in (select b.ProvinceName from [Users] a 
//                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
//                                                            where a.userid = '{0}')
//                                            and UploadPerson is not null and UploadPerson <>'' {1} order by p.UploadDate desc", UFBaseLib.BusLib.BaseInfo.DBUserID,relation);
//                      dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql));
//                  }

//                  if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
//                  {
//                      sql = string.Format(@"select  top 300  p.*,r.*,'' as '大区' from FreeApplication p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode
//                                            and r.city in (select b.ProvinceName from [Users] a 
//                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
//                                                            where a.userid = '{0}')
//                                            and UploadPerson is not null and UploadPerson <>'' {1} order by p.UploadDate desc", UFBaseLib.BusLib.BaseInfo.DBUserID,relation);
//                      dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
//                  }

//                  dt003.Merge(dt002);
//                  dt003.Merge(dt009);

//                  string[] distinctcols = new string[(dt003.Columns.Count)];
//                  foreach (DataColumn dc in dt003.Columns)
//                  {
//                      distinctcols[dc.Ordinal] = dc.ColumnName;
//                  }


//                  dt003 = dt003.DefaultView.ToTable(true, distinctcols);


//                  //foreach (DataRow item in dt003.Rows)
//                  //{
//                  //    item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//                  //}
//                  this.gridControl1.DataSource = dt003;


//                  this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
//              }
//              catch (Exception ex)
//              {
//                  MessageBox.Show("初始化界面失败：" + ex.Message);
//              }
//          }

          public FreeApplicationList()
        {
            InitializeComponent();

            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init("");
          
        }

     
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {


            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["FreeID"].ToString();

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

           Repair.FreeApplication mision = new FreeApplication(id);

           mision.MdiParent = this.ParentForm;

           mision.Show();
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void shToolStripMenuItem_Click(object sender, EventArgs e)
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
            //lq.label2.Text = "免费申请时间";
            //lq.ShowDialog();

            //init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }
    }
}
