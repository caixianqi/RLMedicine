using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class InstallWorkCount : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public InstallWorkCountFilter installFiler;

        public InstallWorkCount()
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

                this.gridBand1.Columns.Band.Collection[0].Columns[0].Visible = false;
                this.gridBand1.Columns.Band.Collection[0].Columns[1].Caption = "安装编号";
                this.gridBand1.Columns.Band.Collection[0].Columns[2].Visible = false;
                this.gridBand1.Columns.Band.Collection[0].Columns[3].Caption = "省份";
                this.gridBand1.Columns.Band.Collection[0].Columns[4].Caption = "完成日期";
                this.gridBand1.Columns.Band.Collection[0].Columns[5].Caption = "主机型号";
                //this.gridBand1.Columns.Band.Collection[0].Columns[7].Visible = false;
                
            }
            catch (Exception ex)
            {

            }
          
        }
     
        private string IsAlone(string code)
        {
            string personname = RiLiGlobal.RiLiDataAcc.ExecuteScalar(" select [tInsMangerName] from InstallTask where tInsCode = '" + code + "'");




            string result = "独立";

            foreach (DataRow item in RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select [rInsName] from InsDetail  where rTaskCode = '" + code + "'").Rows)
            {
                if (item["rInsName"].ToString() == personname)
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
        private void WorkCountInit()
        {
            //故障解决方式				故障类型	



            string bacsql = @"select tID,tInsCode,tRegCode,tRegName,(select max(rInsEnd) from InsDetail where rTaskCode = tInsCode) as fMessagedate
                            ,ins.MachineModel
                               ,case when isnull(r1.iCount1,0)=1 then '是' else '否' end as 独立
	                            ,r1.idays as '安装周期',r1.iCount as '安装次数' 
                        from InstallTask ins inner join InsFeedback ind on ins.tInsCode = ind.fTaskCode 
                        left join (select rTaskCode,sum(DATEDIFF(day,rinsstart,rinsend)) as idays,COUNT(1) as iCount,COUNT(distinct rInsName) as iCount1
                                    from InsDetail
                                        group by rTaskCode
                        ) r1 on ins.tInsCode = r1.rTaskCode
                        where tState='已核对' ";

            if (installFiler != null)
            {
                if (installFiler._bComplete)
                {
                    bacsql = bacsql + " and fMessagedate between '" + installFiler._CompleteBeginTime.ToShortDateString() + "' and '" + installFiler._CompleteEndTime.AddSeconds(86399).ToString() + "'";
                }
                if (installFiler._bAppoint)
                {
                    bacsql = bacsql + " and tAuditMessagedate between '" + installFiler._AppointBeginTime.ToShortDateString() + "' and '" + installFiler._AppointEndTime.AddSeconds(86399).ToString() + "'";
                }
                if (installFiler._bTask)
                {
                    bacsql = bacsql + " and tMessagedate between '" + installFiler._TaskBeginTime.ToShortDateString() + "' and '" + installFiler._TaskEndTime.AddSeconds(86399).ToString() + "'";
                }

                DataTable bacTable = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(bacsql);
                this.gridBand1.Collection.AddBand("安装任务");

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

                foreach (string pname in RiLiGlobal.RegionHelper.GetInstallPersonListByRegionName(""))
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

                //index = index + 1;

                //foreach (DataRow item in RiLiGlobal.RegionHelper.GetRegionList().Rows)
                //{

                //    this.gridBand1.Columns.Band.Collection.AddBand(item["RegionName"].ToString());
                //    this.gridBand1.Columns.Band.Collection[index].RowCount = 2;

                //    this.gridBand1.Columns.Band.Collection[index].OptionsBand.FixedWidth = true;

                //    foreach (string pname in RiLiGlobal.RegionHelper.GetInstallPersonListByRegionName(item["RegionName"].ToString()))
                //    {
                //        DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                //        bgc.Caption = pname.Replace(item["RegionName"].ToString(), string.Empty);
                //        bgc.FieldName = pname;
                //        bgc.RowCount = 2;
                //        bgc.OptionsColumn.AllowEdit = false;
                //        bgc.VisibleIndex = 1;
                //        bgc.Width = 80;
                //        bgc.OptionsColumn.FixedWidth = true;
                //        bgc.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                //        bgc.BestFit();
                //        bgc.OwnerBand = this.gridBand1.Columns.Band.Collection[index];
                //        bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //        this.gridBand1.Columns.Band.Collection[index].Columns.Add(bgc);
                //    }

                //    index = index + 1;

                 



                //}

                CountPersonNum(bacTable);

                ProcessBacsisData(bacTable);




                this.gridControl1.DataSource = bacTable;

                BindData();
            }
        }

        private void ProcessBacsisData(DataTable bacTable)
        {
           // foreach (DataRow item in bacTable.Rows)
            //{
                //item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode( item["tRegCode"].ToString());
               // item["独立"] = IsAlone(item["tInsCode"].ToString());
               // item["安装周期"] = InstallTime(item["tInsCode"].ToString());
               // item["安装次数"] = installs(item["tInsCode"].ToString());
                
              
           // }
        }
        public int installs(string inscode)
        {
            string sql = "select count(*) from InsDetail  where rTaskCode = '" + inscode + "'";

            int time = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql), out time);

            return time;


        }

        public string InstallTime(string inscode)
        {
            string sql = "select  sum( DATEDIFF(day,   rInsStart,  rInsEnd)) from dbo.InsDetail where rTaskCode = '"+inscode+"'";

           
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);
        }
 
        public void CountPersonNum(DataTable dt)
        {
            string sql = string.Empty;
            foreach (DataRow item in dt.Rows)
            {
                sql = string.Format( @"select rTaskCode,rInsName,COUNT(1) as icount
                            from InsDetail
					        where rTaskCode = '{0}'
                            group by rTaskCode,rInsName", item["tInsCode"].ToString());
                DataTable dtnew = RiLiGlobal.RiLiDataAcc.GetDataSet(sql).Tables[0];
                foreach (DataRow drnew in dtnew.Rows)
                {
                    if (drnew["rInsName"].ToString().Length <= 0)
                        continue;
                    item[drnew["rInsName"].ToString()] = drnew["icount"];
                }

            //    string regionName = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["tRegCode"].ToString());

            //    if (regionName == string.Empty)
            //        continue;
               
            //        foreach (DataColumn dc in dt.Columns)
            //        {
            //            if (dc.ColumnName.StartsWith(regionName))
            //            {
            //                item[dc.ColumnName] = IntallTimeForPerson(item["tInsCode"].ToString(), dc.ColumnName.Replace(regionName, string.Empty));
            //            }
            //        }
                
            }
        }


     

      



      


        public int IntallTimeForPerson(string inscode, string username)
        {
            string sql = "select count(*) from InsDetail where rTaskCode = '" + inscode + "' and rInsName = '" + username + "'";

            int count = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql), out count);

            return count;
        }





        public void AddPersonAndRegionColumns(DataTable dt)
        {
            foreach (DataRow item in RiLiGlobal.RegionHelper.GetRegionList().Rows)
            {
                foreach (string pname in RiLiGlobal.RegionHelper.GetInstallPersonListByRegionName(item["RegionName"].ToString()))
                {
                    dt.Columns.Add(pname);
                }
            }
        }
        #region IU8Contral 成员

        public void Authorization()
        {
          
        }

    

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.gridBand1.Columns.Clear();
            this.gridBand1.Collection.Clear();


            installFiler = new InstallWorkCountFilter();
            installFiler.ShowDialog();
            if (installFiler._State)
            {
                WorkCountInit();
            }
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

   
    }
}
