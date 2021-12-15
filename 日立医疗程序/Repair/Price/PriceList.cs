﻿using System;
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
    public partial class PriceList : FormChildBase, Bao.Interface.IU8Contral
    {
         public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public PriceList(string RepairMissionID)
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init(RepairMissionID);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["PriceID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

        public PriceList()
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init("");
        }

        private void init(string RepairMissionID)
        {
            gridControl1.Focus();
            string sql = string.Empty;
            if (RepairMissionID != "")
            {
                sql = string.Format("exec sp_PriceList '{0}','{1}','{2}','{3}','{4}'", "", "", RepairMissionID, "", UFBaseLib.BusLib.BaseInfo.DBUserID);
            }
            else
            {
                sql = string.Format("exec sp_PriceList '{0}','{1}','{2}','{3}','{4}'"
                               , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);
            }

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        }
//        private void init()
//        {
//            this.init("");
////            DataTable dt003 = new DataTable();
////            DataTable dt002 = new DataTable();
////            DataTable dt001 = new DataTable();
////           // DataTable dt008 = new DataTable();
////            DataTable dt009 = new DataTable();
////            string sql = string.Empty;
////            //维修编号	客户名称	报价申请人	主机型号	所属部门	区域	报价时间	回执时间	任务状态,//报价申请/已传真报价/已经回执

////            try
////            {
////                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
////                {
////                    dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and UploadPerson is not null and UploadPerson <>'' order by p.UploadDate desc ");

////                }
////                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
////                {
////                    dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and UploadPerson is not null and UploadPerson <>'' order by p.UploadDate desc");

////                    //dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") order by p.UploadDate desc"));
////                }

////                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
////                {
////                    dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,r.*,'' as '大区'  from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and p.[UserId] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' order by p.UploadDate desc");
////                }


////                //if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
////                //{
////                //    dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' order by p.UploadDate desc");
////                //}
////                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
////                {
////                    sql = string.Format(@"select top 300 *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode 
////                                          where r.city in (select b.ProvinceName from [Users] a 
////                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
////                                                            where a.userid = '{0}')  and UploadPerson is not null and UploadPerson <>'' order by p.UploadDate desc"
////                                , UFBaseLib.BusLib.BaseInfo.DBUserID
////                        );
////                    dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
////                }
////                //dt001.Merge(dt008);
////                dt001.Merge(dt009);
////                dt001.Merge(dt002);
////                dt001.Merge(dt003);



////                string[] distinctcols = new string[(dt001.Columns.Count)];
////                foreach (DataColumn dc in dt001.Columns)
////                {
////                    distinctcols[dc.Ordinal] = dc.ColumnName;
////                }


////                dt001 = dt001.DefaultView.ToTable(true, distinctcols);


////                foreach (DataRow item in dt001.Rows)
////                {
////                    item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
////                }

////                this.gridControl1.DataSource = dt001;


////                this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show("初始化界面失败：" + ex.Message);
////            }
//        }


//        private void init(DateTime beginTime, DateTime endTime)
//        {
//            DataTable dt003 = new DataTable();
//            DataTable dt002 = new DataTable();
//            DataTable dt001 = new DataTable();
//            DataTable dt008 = new DataTable();
//            DataTable dt009 = new DataTable();

//            //维修编号	客户名称	报价申请人	主机型号	所属部门	区域	报价时间	回执时间	任务状态,//报价申请/已传真报价/已经回执


//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
//            {
//                dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and UploadPerson is not null and UploadPerson <>'' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "' ");

//            }
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//            {
//                dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and UploadPerson is not null and UploadPerson <>'' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

//                dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
//            }

//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//            {
//                dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select p.*,r.*,'' as '大区'  from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and p.[UserId] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//            }


//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
//            {
//                dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//            }
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
//            {
//                dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' and p.UploadDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//            }
//            dt001.Merge(dt008);
//            dt001.Merge(dt009);
//            dt001.Merge(dt002);
//            dt001.Merge(dt003);



//            string[] distinctcols = new string[(dt001.Columns.Count)];
//            foreach (DataColumn dc in dt001.Columns)
//            {
//                distinctcols[dc.Ordinal] = dc.ColumnName;
//            }


//            dt001 = dt001.DefaultView.ToTable(true, distinctcols);


//            foreach (DataRow item in dt001.Rows)
//            {
//                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//            }

//            this.gridControl1.DataSource = dt001;


//            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);

//        }

//        /// <summary>
//        /// 根据维修任务ID查询显示出来
//        /// </summary>
//        /// <param name="RepairMissionID"></param>
//        private void init(string RepairMissionID)
//        {
//            DataTable dt003 = new DataTable();
//            DataTable dt002 = new DataTable();
//            DataTable dt001 = new DataTable();
//            // DataTable dt008 = new DataTable();
//            DataTable dt009 = new DataTable();
//            string sql = string.Empty;
//            string relation = "";
//            if (RepairMissionID.Length > 0)
//            {
//                relation = " and p.RepairMissionID = '" + RepairMissionID + "'";
//            }
//            //维修编号	客户名称	报价申请人	主机型号	所属部门	区域	报价时间	回执时间	任务状态,//报价申请/已传真报价/已经回执

//            try
//            {
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
//                {
//                    dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and UploadPerson is not null and UploadPerson <>'' " + relation + " order by p.UploadDate desc ");

//                }
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                {
//                    dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.* ,r.*,'' as '大区' from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and r.[CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and UploadPerson is not null and UploadPerson <>'' " + relation + " order by p.UploadDate desc");

//                    //dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") order by p.UploadDate desc"));
//                }

//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//                {
//                    dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 p.*,r.*,'' as '大区'  from Price p,RepairMission r  where r.RepairMissionCode = p.RepairMissionCode and p.[UserId] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' " + relation + " order by p.UploadDate desc");
//                }


//                //if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
//                //{
//                //    dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode where r.ZoneCode in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and UploadPerson is not null and UploadPerson <>'' order by p.UploadDate desc");
//                //}
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                {
//                    sql = string.Format(@"select top 300 *,'' as '大区' from Price p  inner join RepairMission  r on r.RepairMissionCode = p.RepairMissionCode 
//                                          where r.city in (select b.ProvinceName from [Users] a 
//                                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
//                                                            where a.userid = '{0}')  and UploadPerson is not null and UploadPerson <>'' {1} order by p.UploadDate desc"
//                                , UFBaseLib.BusLib.BaseInfo.DBUserID,relation
//                        );
//                    dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
//                }
//                //dt001.Merge(dt008);
//                dt001.Merge(dt009);
//                dt001.Merge(dt002);
//                dt001.Merge(dt003);



//                string[] distinctcols = new string[(dt001.Columns.Count)];
//                foreach (DataColumn dc in dt001.Columns)
//                {
//                    distinctcols[dc.Ordinal] = dc.ColumnName;
//                }


//                dt001 = dt001.DefaultView.ToTable(true, distinctcols);


//                //foreach (DataRow item in dt001.Rows)
//                //{
//                //    item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//                //}

//                this.gridControl1.DataSource = dt001;


//                this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("初始化界面失败：" + ex.Message);
//            }
//        }


        void gridControl1_DoubleClick(object sender, EventArgs e)
        {


            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["PriceID"].ToString();

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

           Repair.Price mision = new Price(id);

           mision.MdiParent = this.ParentForm;

           mision.Show();
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();


            this.gridView1.ExportToXls(sf.FileName+".xls");

            System.Windows.Forms.MessageBox.Show("导出成功");
        }

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

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ListQuery lq = new ListQuery();
            //lq.label2.Text = "报价申请时间";
            //lq.ShowDialog();

            //init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
