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
    public partial class InvUserFilter : Bao.Report.FormFilterBase
    {
        public static string[] aAccStdNames;//主机
        public string accsql;
        public string timesql;

        public static string[] engNames;//英文名称
        public string engsql;



        public static string[] invstds;//英文名称
        public string stdsql;


        public InvUserFilter()
        {
            InitializeComponent();
            CustomerCode.BaoSQL = "select cCusCode,cCusName from " + U8DataAcc.U8ServerAndDataBase + ".Customer";
            CustomerCode.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.CustomerCode.FrmHigth = 600;
            this.CustomerCode.FrmWidth = 400;
            CustomerCode.DecideSql = "select * from " + U8DataAcc.U8ServerAndDataBase + ".Customer where Customer.cCusCode=";
            CustomerCode.BaoColumnsWidth = "cCusCode=150,cCusName=250";
            CustomerCode.BaoClickClose = true;
            CustomerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerCode_OnLookUpClosed);



            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            /*MainType_be.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory where ((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045'";*/

            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            MainType_be.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory where (cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')";

            MainType_be.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.MainType_be.FrmHigth = 400;
            this.MainType_be.FrmWidth = 600;

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            /*MainType_be.DecideSql = "select * from " + U8DataAcc.U8ServerAndDataBase + ".Inventory   where (((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045') and cInvName=";*/

            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            MainType_be.DecideSql = "select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory   where (cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%') and cInvName=";


            MainType_be.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=150,cinvdefine7=150";



            EngNameText.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory where  (cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%')";
            EngNameText.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.EngNameText.FrmHigth = 400;
            this.EngNameText.FrmWidth = 600;
            EngNameText.DecideSql = "select * from (select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory ) t where  cinvdefine7=";
            EngNameText.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=150,cinvdefine7=150";



            InventoryStd.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7 from " + U8DataAcc.U8ServerAndDataBase + ".Inventory where  (cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%' )";
            InventoryStd.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.InventoryStd.FrmHigth = 400;
            this.InventoryStd.FrmWidth = 600;
            InventoryStd.DecideSql = "select cInvCode,cInvAddCode,cInvName,cInvStd,cEnglishName as cinvdefine7  from " + U8DataAcc.U8ServerAndDataBase + ".Inventory   where cInvStd=";
            InventoryStd.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=150,cinvdefine7=150";

            this.SearchWhere = new DataTable("SearchWhere");
            SearchWhere.Columns.Add("开始日期");
            SearchWhere.Columns.Add("结束日期");

            aAccStdNames = new string[0];
            engNames = new string[0];
            invstds = new string[0];

        }

        void CustomerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerCode.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString();
            this.CustomerCode.CodeValue = e.ReturnRow1["cCusCode"].ToString();
        }

        private void InvUserFilter_OnSearchWhere()
        {
            string sql = string.Format(@"select pad.inventoryCode,pad.InventoryStd,pad.InventoryEngName,pa.PartsApplicationCode,
                            pa.PartsApplicationId,pa.RepairMissionCode,pa.CustomerName,pad.iquantity,pa.ApplicationDate,
                            rm.ZoneCode,rm.ZoneName,rm.MachineModel,rm.RepairTypeNew,bi.BillState
                            ,p2.iquantity as '出库数量' --因为出库数量已经汇总，无须再汇总
                            --,SUM(p2.iquantity) as '出库数量'
                            ,p3.iqty1 as '归还现品不良品数量',p3.iqty2 as '归还未使用数量',
                                        p3.iqty3 as '归还不良品数量',(isnull(p3.iqty1,0) + isnull(p3.iqty2,0) + isnull(p3.iqty3,0)) as '出库明细'
                            ,isnull(isnull(p1.StateReturn,p1.StateInOut),'配件申请') as [Status],rm.PurchaseDate,rm.ManufactureCode,p2.ShippingTime,p3.ReturnDate,rm.ReportRepartDate,
                            rm.dtimegc,pa.ApplicationPersonName,rm.dtimeFH,rm.dtimeFHBX,p9.Remarks
                        from PartsApplicationDetails pad 
                        inner join PartsApplication pa on pad.PartsApplicationID = pa.PartsApplicationID
                        left outer join RepairMission rm on rm.RepairMissionCode = pa.RepairMissionCode  
                         --left join BaseGuaranteeType c on rm.RepairtypeNew = c.code
                         left join PartsInventory p1 on pa.PartsApplicationID = p1.PartsApplicationID
                         left join Price pr on rm.RepairMissionCode = pr.RepairMissionCode
                         left join Bill bi on pr.PriceID = bi.PriceID
                         left join (select ShippingTime,PartsInventoryID,InventoryCode,sum(isnull(iquantity, 0)) as iquantity from PartsInventoryDetails group by PartsInventoryID,InventoryCode,ShippingTime) p2 on p1.PartsInventoryID = p2.PartsInventoryID and pad.InventoryCode = p2.InventoryCode
                         --Lin2019.9.10 按电邮要求修改
                         --提取“备件出入库”单据中，备件借用信息中的“备注”信息
                         --提取出的“备注”信息，汇总到“备件使用情况”表中
                         left join (select PartsInventoryID, InventoryCode,  Convert(nvarchar(1000),Remarks) as Remarks from PartsInventoryDetails) p9 on 
                         p1.PartsInventoryID = p9.PartsInventoryID and pad.InventoryCode = p9.InventoryCode
                         left join (
	                        select PartsInventoryID,InventoryCode,ReturnDate,sum(case when [State]='现品不良' then iquantity end) as iqty1
					                        ,sum(case when [State]='未使用' then iquantity end) as iqty2
					                        ,sum(case when [State]='不良品' then iquantity end) as iqty3
					                        --,sum(iquantity) as iquantity 
	                        from PartsUseAndReturnInfo group by PartsInventoryID,InventoryCode,ReturnDate
	                        ) p3 on p2.PartsInventoryID = p3.PartsInventoryID and p2.InventoryCode = p3.InventoryCode 
                            where 1=1 ");

            if (cb_ReportRepart.Checked)
            {
                timesql += string.Format(" and rm.ReportRepartDate between '{0}' and '{1}' ", ReportRepartDateBegin.Value.ToShortDateString(), ReportRepartDateEnd.Value.AddSeconds(86399).ToString());
            }

            if (cb_Application.Checked)
            {
                timesql += string.Format(" and pa.ApplicationDate between '{0}' and '{1}' ", BeginTime.Value.ToShortDateString(), EndTime.Value.AddSeconds(86399).ToString());
            }

            if (cb_Return.Checked)
            {
                timesql += string.Format(" and p3.ReturnDate between '{0}' and '{1}' ", ReturnDateBegin.Value.ToShortDateString(), ReturnDateEnd.Value.AddSeconds(86399).ToString());
            }
            if (bzhuji.Checked)
            {
                if (aAccStdNames.Length > 0)
                {
                    accsql = " and (";
                    for (int k = 0; k < aAccStdNames.Length; k++)
                    {
                        if (k < aAccStdNames.Length - 1)
                        {
                            accsql += "rm.MachineName='" + aAccStdNames[k] + "' or ";
                        }
                        else
                        {
                            accsql += "rm.MachineName='" + aAccStdNames[k] + "')";
                        }
                    }
                }
              
            }
            if (beng.Checked)
            {
                if (engNames.Length > 0)
                {

                    engsql = " and (";
                    for (int k = 0; k < engNames.Length; k++)
                    {
                        if (k < engNames.Length - 1)
                        {
                            engsql += "pad.InventoryEngName='" + engNames[k] + "' or ";
                        }
                        else
                        {
                            engsql += "pad.InventoryEngName='" + engNames[k] + "')";
                        }
                    }
                }
            }
            if (bstd.Checked)
            {
                if (invstds.Length > 0)
                {
                    stdsql = " and (";
                    for (int k = 0; k < invstds.Length; k++)
                    {
                        if (k < invstds.Length - 1)
                        {
                            stdsql += "pad.InventoryStd='" + invstds[k] + "' or ";
                        }
                        else
                        {
                            stdsql += "pad.InventoryStd='" + invstds[k] + "')";
                        }
                    }
                }
            }

            sql += timesql + accsql + engsql + stdsql;

            if (this.CustomerCode.CodeValue == string.Empty || this.CustomerCode.CodeValue == null)
            {
            }
            else
            {
                sql += "and pa.CustomerCode = '" + this.CustomerCode.CodeValue + "'";
            }

            sql += string.Format(@" group by pad.inventoryCode,pad.InventoryStd,pad.InventoryEngName,pa.PartsApplicationCode,
                                    pa.PartsApplicationId,pa.RepairMissionCode,pa.CustomerName,pad.iquantity,pa.ApplicationDate,p3.iqty1,p3.iqty2,p3.iqty3,
                                    rm.ZoneCode,rm.ZoneName,rm.MachineModel,rm.RepairTypeNew,p1.StateInOut,p1.StateReturn,rm.PurchaseDate,rm.ManufactureCode,
                                    bi.BillState,p2.ShippingTime,p3.ReturnDate,rm.ReportRepartDate,rm.dtimegc,pa.ApplicationPersonName,rm.dtimeFH,rm.dtimeFHBX,p9.Remarks,
                                    p2.iquantity");

            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            foreach (DataRow item in lastdata.Rows)
            {
                //item["出货日期"] = SendTime(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                //item["出库数量"] = SendCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                //item["归还现品不良品数量"] = BadNowReturnCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                //item["归还未使用数量"] = NoUseReturnCount(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                //item["归还不良品数量"] = BadReturnCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                //item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
                //item["配件等待时间"] = InvWaitTime(item["PartsApplicationCode"].ToString(), item["inventoryCode"].ToString()).ToString("0.00");
                //item["出库仓库"] = OutWarehouse(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());

            }

            this.DataSourceTable = lastdata;
            accsql = "";
            engsql = "";
            stdsql = "";
            timesql = "";
        }

        public string OutWarehouse(string pid, string cinvcode)
        {

            string fiststring = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select Warehouse from PartsInventoryDetails where PartsInventoryID in (select PartsInventoryID from PartsInventory where PartsApplicationID = '" + pid + "' and InventoryCode = '" + cinvcode + "') ");



            return fiststring;
        }
        private int InvWaitTime(string appcode,string cinvcode)
        {
            //当前配件的发货时间-申请时间 
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsApplicationID from PartsApplication where PartsApplicationCode = '" + appcode + "'");
            DateTime fistsenddate;
            DateTime invappdate;

            

            string fiststring = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ShippingTime from PartsInventoryDetails where PartsInventoryID in (select PartsInventoryID from PartsInventory where PartsApplicationID = '" + id + "' and InventoryCode = '"+cinvcode+"') ");

            if (fiststring == string.Empty)
            {
                return 0;
            }
            else
            {
                fistsenddate = DateTime.Parse(fiststring);
            }

            string invstring = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ApplicationDate from PartsApplication   where PartsApplicationCode = '" + appcode + "' ");
            if (invstring == string.Empty)
            {
                return 0;
            }
            else
            {
                invappdate = DateTime.Parse(invstring);
            }

         

            return int.Parse( (fistsenddate - invappdate.Date).TotalDays.ToString());
        }
        private int BadReturnCout(string p, string p_2)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where PartsApplicationId = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where [State] = '不良品' and InventoryCode = '" + p_2 + "' and PartsInventoryID = '" + pinvid + "'"));

                return cout;
            }
        }

        private double NoUseReturnCount(string p, string p_2)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where PartsApplicationId = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where [State] = '未使用' and InventoryCode = '" + p_2 + "' and PartsInventoryID = '" + pinvid + "'"));

                return cout;
            }
        }

        private double BadNowReturnCout(string p, string p_2)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where PartsApplicationId = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where [State] = '现品不良' and InventoryCode = '" + p_2 + "' and PartsInventoryID = '" + pinvid + "'"));

                return cout;
            }
        }

        private double SendCout(string p, string p_2)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where PartsApplicationId = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return 0;
            }
            else
            {
                int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0 end  from [PartsInventoryDetails] where  InventoryCode = '" + p_2 + "' and PartsInventoryID = '" + pinvid + "'"));

                return cout;
            }
        }

        private string SendTime(string p, string p_2)
        {
            string pinvid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PartsInventoryID from PartsInventory where PartsApplicationId = '" + p + "' ");

            if (pinvid == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                string cout = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [ShippingTime] from [PartsInventoryDetails] where  InventoryCode = '" + p_2 + "' and PartsInventoryID = '" + pinvid + "'");

                return cout;
            }
        }

        private void MainType_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            MainType_be.Text = dr["cInvName"].ToString();
            MainType_beText.Text = dr["cInvName"].ToString();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            int lenght = aAccStdNames.Length;
            Array.Resize(ref aAccStdNames, lenght + 1);
            aAccStdNames[lenght] = MainType_beText.Text;
            listBox1.DataSource = aAccStdNames;

            MainType_beText.Clear();
            MainType_be.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lenght = engNames.Length;
            Array.Resize(ref engNames, lenght + 1);
            engNames[lenght] = EngName.Text;
            listBox2.DataSource = engNames;

            EngName.Clear();
            EngNameText.BaoBtnCaption = string.Empty;
        }

        private void EngNameText_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            EngName.Text  = dr["cinvdefine7"].ToString();
            EngNameText.Text = dr["cinvdefine7"].ToString();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InventoryStd_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            InventoryStd.Text = dr["cInvStd"].ToString();
            InventoryStdText.Text = dr["cInvStd"].ToString();
            
        }

        private void BtnRemoved1_Click(object sender, EventArgs e)
        {
            this.listBox1.DataSource = null;

            Array.Clear(aAccStdNames,0,aAccStdNames.Length);
              
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.listBox2.DataSource = null;
            Array.Clear(engNames, 0, engNames.Length);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.listBox3.DataSource = null;

            Array.Clear(invstds, 0, invstds.Length);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int lenght = invstds.Length;
            Array.Resize(ref invstds, lenght + 1);
            invstds[lenght] = InventoryStd.Text;
            listBox3.DataSource = invstds;

            InventoryStd.BaoBtnCaption = string.Empty;
            InventoryStdText.Text = string.Empty;
           
        }
    }
}
