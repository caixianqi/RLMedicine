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

        public static string[] engNames;//英文名称
        public string engsql;



        public static string[] invstds;//英文名称
        public string stdsql;


        public InvUserFilter()
        {
            InitializeComponent();
            CustomerCode.BaoSQL = "select cCusCode,cCusName from " + U8DataAcc.DataBase + ".Customer";
            CustomerCode.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.CustomerCode.FrmHigth = 600;
            this.CustomerCode.FrmWidth = 400;
            CustomerCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".Customer where Customer.cCusCode=";
            CustomerCode.BaoColumnsWidth = "cCusCode=150,cCusName=250";
            CustomerCode.BaoClickClose = true;
            CustomerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerCode_OnLookUpClosed);




            MainType_be.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cinvdefine7 from " + U8DataAcc.DataBase + ".Inventory where cinvcode like 'A%' and len(cinvcode) = 3";
            MainType_be.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.MainType_be.FrmHigth = 400;
            this.MainType_be.FrmWidth = 600;
            MainType_be.DecideSql = "select * from " + U8DataAcc.DataBase + ".Inventory   where cinvcode like 'A%' and len(cinvcode) = 3 and cInvName=";
            MainType_be.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=150,cinvdefine7=150";



            EngNameText.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cinvdefine7 from " + U8DataAcc.DataBase + ".Inventory where  (cinvcode like 's%' or cinvcode like 'c%' )";
            EngNameText.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.EngNameText.FrmHigth = 400;
            this.EngNameText.FrmWidth = 600;
            EngNameText.DecideSql = "select * from " + U8DataAcc.DataBase + ".Inventory   where  cinvdefine7=";
            EngNameText.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=150,cinvdefine7=150";



            InventoryStd.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd,cinvdefine7 from " + U8DataAcc.DataBase + ".Inventory where  (cinvcode like 's%' or cinvcode like 'c%' )";
            InventoryStd.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号,cinvdefine7=英文名称";
            this.InventoryStd.FrmHigth = 400;
            this.InventoryStd.FrmWidth = 600;
            InventoryStd.DecideSql = "select * from " + U8DataAcc.DataBase + ".Inventory   where cInvStd=";
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
            string sql = "select pad.inventoryCode,pad.InventoryStd,pad.InventoryEngName,pa.PartsApplicationCode,pa.PartsApplicationId,pa.RepairMissionCode,pa.CustomerName,pad.iquantity,pa.ApplicationDate,rm.ZoneCode,rm.ZoneName,rm.MachineName,rm.RepairType,'' as  '出货日期','' as  '出库仓库','' as '出库数量','' as '归还现品不良品数量','' as '归还未使用数量','' as '归还不良品数量','' as '大区',0.00 as '配件等待时间' from PartsApplicationDetails pad inner join PartsApplication pa left outer join RepairMission rm on rm.RepairMissionCode = pa.RepairMissionCode  on pa.PartsApplicationID = pad.PartsApplicationID   and pa.ApplicationDate between '" + BeginTime.Value.ToShortDateString() + "'and  '" + EndTime.Value.AddSeconds(86399).ToString() + "'";

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

            sql += accsql + engsql + stdsql;

            if (this.CustomerCode.CodeValue == string.Empty || this.CustomerCode.CodeValue == null)
            {
            }
            else
            {
                sql += "and pa.CustomerCode = '" + this.CustomerCode.CodeValue + "'";
            }

            DataTable lastdata = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            foreach (DataRow item in lastdata.Rows)
            {
                item["出货日期"] = SendTime(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                item["出库数量"] = SendCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                item["归还现品不良品数量"] = BadNowReturnCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                item["归还未使用数量"] = NoUseReturnCount(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                item["归还不良品数量"] = BadReturnCout(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());
                item["大区"] = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(item["ZoneCode"].ToString());
                item["配件等待时间"] = InvWaitTime(item["PartsApplicationCode"].ToString(), item["inventoryCode"].ToString()).ToString("0.00");
                item["出库仓库"] = OutWarehouse(item["PartsApplicationId"].ToString(), item["inventoryCode"].ToString());

            }

            this.DataSourceTable = lastdata;
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
