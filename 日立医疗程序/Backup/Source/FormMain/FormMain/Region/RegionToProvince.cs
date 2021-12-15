using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace FormMain.Region
{
    public partial class RegionToProvince : UserControl,Bao.Interface.IU8Contral
    {
        public RegionToProvince()
        {
            InitializeComponent();


            string sql = "select cDCCODE,CDCNAME,r.RegionName,rt.*  from " + U8DataAcc.DataBase + ".DistrictClass dc left outer join RegionToProvince rt inner join Region  r on r.RegionId =rt.RegionId on rt.ProvinceCode = dc.cDCCODE";


            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);

            foreach (DataRow item in RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Region").Rows)
            {
                this.repositoryItemComboBox1.Items.Add(item["RegionName"].ToString());
             
               


            }
            this.gridView1.OptionsBehavior.Editable = true;

            this.repositoryItemComboBox1.SelectedIndexChanged += new EventHandler(repositoryItemComboBox1_SelectedIndexChanged);
        }

        void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            string region = ((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedItem.ToString();

         

            DataRow dr = this.gridView1.GetDataRow(row);

            string RegionId = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RegionId from Region where RegionName = '" + region + "'");
           
            //如果原先不存在
            if(dr["RegionToProvinceId"].ToString() == string.Empty)
            {
              
                if (RegionId == string.Empty)
                {
                    throw new Exception("大区" + region + "不存在，请检查");
                }
                else
                {
                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("insert into RegionToProvince (RegionToProvinceId,RegionId,ProvinceCode,ProvinceName) values (newid(),'" + RegionId + "','" + dr["cDCCODE"].ToString() + "','" + dr["CDCNAME"].ToString() + "')");
                }

            
            }
            ////如果原先存在
            else
            {
                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update RegionToProvince set RegionId = '" + RegionId + "' where RegionToProvinceId = '" + dr["RegionToProvinceId"].ToString() + "'");
            }
            string sql = "select cDCCODE,CDCNAME,r.RegionName,rt.*  from " + U8DataAcc.DataBase + ".DistrictClass dc left outer join RegionToProvince rt inner join Region  r on r.RegionId =rt.RegionId on rt.ProvinceCode = dc.cDCCODE";


            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
           
           // string RegionToProvinceId = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select RegionToProvinceId from RegionToProvince where RegionToProvinceid = '"++"'")
        }


        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void RegionToProvince_Load(object sender, EventArgs e)
        {

         
        }
    }
}
