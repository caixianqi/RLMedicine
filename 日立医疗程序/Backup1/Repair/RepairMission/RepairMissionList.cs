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
    public partial class RepairMissionList :FormChildBase, Bao.Interface.IU8Contral
    {
        public string SelectID;


        public Form ReturnForm;

        /// <summary>
        /// +where....
        /// </summary>
        /// <param name="query"></param>
        public RepairMissionList(string query)
        {
            InitializeComponent();

            init(query);

            //this.gridControl1.DoubleClick += new EventHandler(gridControl1ForFault_DoubleClick);

        }

          void gridControl1ForFault_DoubleClick(object sender, EventArgs e)
        {
           string id =    gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionID"].ToString();

           SelectID = id;

        
           this.Hide();
        }

        public RepairMissionList()
        {
            InitializeComponent();
            this.cmbStatus.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            init("");
           
        }

        private void init(string query)
        {
            gridControl1.Focus();

            string sql = string.Empty;
            string autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;

            if (query != "")
            {
                sql = string.Format("exec sp_RepairMissionList '{0}','{1}','{2}','{3}','{4}'", "", "", query, "", autoUserID);
            }
            else
            {
                sql = string.Format("exec sp_RepairMissionList '{0}','{1}','{2}','{3}','{4}'"
                                , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), autoUserID);
            }

            gridView1.OptionsBehavior.Editable = false;

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
        }
//        private void init()
//        {
//            DataTable dt = new DataTable();
//            DataTable dt003 = new DataTable();
//            DataTable dt002 = new DataTable();
//            DataTable dt001 = new DataTable();
//            DataTable dt008 = new DataTable();
//            //DataTable dt009 = new DataTable();
//            DataTable dt010 = new DataTable();
//            string relation = "1=1";
//            relation += " and ReportRepartDate between '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
//            if (this.cmbStatus.SelectedIndex == 0)
//                 relation += " and isnull(IsEnd,'')=''";
//            else if (this.cmbStatus.SelectedIndex == 1)
//                relation += " and IsEnd='已结案'";

//            string sql = string.Empty;
//            try
//            {
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
//                {
//                    dt010 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(@"select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区' from RepairMission 
//                                    where isnull([SubmitPersonUser],'')<>'' and " + relation + " order by ReportRepartDate desc");

//                }
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//                {
//                    dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(@"select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区' from RepairMission where RepairPersonCode = '"
//                           + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ([SubmitPersonUser] is not null and " + relation + " and [SubmitPersonUser] <>'') order by ReportRepartDate desc");

//                }
//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                {
//                    dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where [CustomerManagerCode] = '"
//                            + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and " + relation + " and ([SubmitMissonUser] is not null and [SubmitMissonUser] <>'') order by ReportRepartDate desc");
                   
                   

////                    dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery(string.Format(@"select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请' ,'' as '大区' 
////                                                                from RepairMission where city in (select b.ProvinceName from [Users] a 
////		                                                                        inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
////		                                                                        where a.userid = '{0}') and  ReportRepartDate between '{1}' and '{2}' and SubmitMissonUser is not null and SubmitMissonUser <>'' order by ReportRepartDate desc"
////                                                                ,UFBaseLib.BusLib.BaseInfo.DBUserID,begenDate,endDate)));
//                }

//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
//                {
//                    dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(@"select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  
//                                        from RepairMission where 1=1 and " + relation + " order by ReportRepartDate desc");
//                }

//                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//                {
//                    sql = string.Format(@"select top 300 *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  
//                             from RepairMission 
//                            where city in (select b.ProvinceName from [Users] a 
//                                            inner join RegionToProvince b on b.deptNum like a.deptNum + '%'
//                                            where a.userid = '{0}') 
//                                and {1} and SubmitMissonUser is not null and SubmitMissonUser <>'' 
//                            order by ReportRepartDate desc",UFBaseLib.BusLib.BaseInfo.DBUserID,relation);

//                    dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
//                }
              
//                dt001.Merge(dt008);
//                //dt001.Merge(dt009);
//                dt001.Merge(dt002);
//                dt001.Merge(dt003);
//                dt001.Merge(dt010);


//                string[] distinctcols = new string[(dt001.Columns.Count)];
//                foreach (DataColumn dc in dt001.Columns)
//                {
//                    distinctcols[dc.Ordinal] = dc.ColumnName;
//                }


//                dt001 = dt001.DefaultView.ToTable(true, distinctcols);


//                foreach (DataRow item in dt001.Rows)
//                {
//                    //item["machinename"] = item["machinename"].ToString() == "" ? item["MachineModel"].ToString() : item["machinename"].ToString();
//                    item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
//                    item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
//                    item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
//                    item["出货"] = SendCout(item["RepairMissionCode"].ToString());
//                    item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
//                    item["申请"] = AppCount(item["RepairMissionCode"].ToString());
//                    item["State"] = convertState(MissionState(item["RepairMissionID"].ToString()));
//                    //item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//                }



//                this.gridControl1.DataSource = dt001;


//                this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("初始化界面失败：" + ex.Message);
//            }

//        }


//        private void init(DateTime beginTime,DateTime endTime)
//        {
//            DataTable dt = new DataTable();
//            DataTable dt003 = new DataTable();
//            DataTable dt002 = new DataTable();
//            DataTable dt001 = new DataTable();
//            DataTable dt008 = new DataTable();
//            DataTable dt009 = new DataTable();



//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
//            {
//                dt003 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区' from RepairMission where RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ([SubmitPersonUser] is not null and [SubmitPersonUser] <>'') and ReportRepartDate between '"+beginTime.Date.ToShortDateString()+"' and '"+endTime.AddSeconds(86399).ToString()+"'");

//            }
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
//            {
//                dt002 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where [CustomerManagerCode] = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ([SubmitMissonUser] is not null and [SubmitMissonUser] <>'') and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");

//                dt002.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));
//            }

//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
//            {
//                dt001 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//            }

//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
//            {
//                dt008 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
//            }
//            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
//            {
//                dt009 = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select  *,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请','' as '大区'  from RepairMission where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and SubmitMissonUser is not null and SubmitMissonUser <>'' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'");
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
//                item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
//                item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
//                item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
//                item["出货"] = SendCout(item["RepairMissionCode"].ToString());
//                item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
//                item["申请"] = AppCount(item["RepairMissionCode"].ToString());
//                item["State"] = convertState(MissionState(item["RepairMissionID"].ToString()));
//                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
//            }



//            this.gridControl1.DataSource = dt001;


//            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);

//        }

        /// <summary>
        /// 任务状态的定义：                           
        /// 1、800新建维修任务并且提交后--任务状态显示为“新任务”                                  
        /// 2、管理部部长审核完维修类型后--任务状态显示为“维修请求”                               
        /// 3、任务指派后==任务状态显示为“已指派”      
        /// 4、任务反馈中选择“未完成”--任务状态显示为“未完成”                                   
        /// 5、任务反馈中选择“完成”后--任务状态显示为“完成”                                       
        /// 6、工程师点提交后--任务状态显示为“待审核”        
        /// 7、审核完成后--任务状态显示为“审核”        
        /// 以上内容要求：《维修单据列表》《故障解决情况列表》《维修进度报表》中的“状态”字段保持一致。
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        //private string convertState (string state)
        //{
        //    switch (state)
        //    {
        //     case "新任务":
        //            state = "";
        //            break;
        //    case "维修请求":
        //            state = "新任务";
        //            break;
        //    case "维修已审核":
        //            state = "维修请求";
        //            break;
        //    case "已分派":
        //            state = "已指派";
        //            break;
        //    }

        //    return state;
        //}
        ///// <summary>
        ///// 任务状态
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //public string MissionState(string id)
        //{
          

        //    if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == string.Empty)
        //    {
        //        return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from RepairMission where RepairMissionID = '" + id + "'");
        //    }
        //    else
        //    {
        //        string AuditPerson = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditPerson] from [FaultFeedback] where RepairMissionId = '" + id + "'");
        //        if (AuditPerson != string.Empty)
        //            return "审核";

        //        string UploadPerson = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select UploadPerson from FaultFeedback where RepairMissionID = '" + id + "'");
        //        if (UploadPerson != string.Empty)
        //            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditState] from [FaultFeedback] where RepairMissionId = '" + id + "'");

        //        return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'");
                    
        //    }
        //}
      
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionID"].ToString();

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

           Repair.RepairMission mision = new RepairMission(id);

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
        //private object GetReMissionState(string code)
        //{
        //    string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + code + "'");

        //    return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [ProcessingStatus] from [FaultFeedback] where RepairMissionId = '" + id + "'");
        //}
        //public string GetPriceState(string code)
        //{
        //    if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from price where  RepairMissionCode = '" + code + "'").Rows.Count > 0)
        //    {
        //        return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from price where  RepairMissionCode = '" + code + "'");
        //    }

        //    else

        //    { return string.Empty; }
        //}

        //public string GetFreeState(string code)
        //{
        //    return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select IsPass from FreeApplication where RepairMissionCode = '" + code + "'");
        //}

        //public string GetBillState(string code)
        //{
        //    string Priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceCode from Price where RepairMissionCode = '" + code + "'");
        //    return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select BillState from Bill where PriceCode = '" + Priceid + "'");
        //}



        //private string GetInvState(string code)
        //{
        //    string sate = string.Empty;
        //    if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
        //    {
        //        sate = "已申请";
        //    }
        //    if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0 && RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsInventory where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
        //    {
        //        sate = "已出货";
        //    }
        //    else

        //    { sate = string.Empty; }

        //    return sate;
        //}

        //private double AppCount(string p)
        //{




        //    int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsApplication a,PartsApplicationDetails b where a.PartsApplicationID = b.PartsApplicationID and a.RepairMissionCode = '" + p + "' "));

        //    return cout;

        //}

   

        //private int ReturnCout(string p)
        //{
         
        //        int cout = 0;
                
        //        int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where    PartsInventoryID in (select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' )"),out cout);

        //        return cout;

             
        //}
        //private double SendCout(string p)
        //{
    

        //    int cout = 0;

        //    int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsInventoryDetails where    PartsInventoryID in (select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' )"), out cout);

        //    return cout;
        //}

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查询ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListQuery lq = new ListQuery();
            lq.label2.Text = "报修日期范围";
            lq.ShowDialog();

            //init(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.Date);
        }

    }
}
