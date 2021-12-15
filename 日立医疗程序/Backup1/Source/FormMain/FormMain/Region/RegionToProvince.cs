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
        private DataTable dtDepart = null;

        public RegionToProvince()
        {
            InitializeComponent();

            this.Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.LoadGrid();
            dtDepart = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from BaseDepartMent where isend = 1  ");
            foreach (DataRow item in dtDepart.Rows)
            {
                //this.repositoryItemdeptNum1.Items.Add(item["RegionName"].ToString());
                DevExpress.XtraEditors.Controls.ComboBoxItem item1 = new DevExpress.XtraEditors.Controls.ComboBoxItem(item["deptName"].ToString());
                //item1.Value = item["deptNum"].ToString();
                this.repositoryItemdeptNum1.Items.Add(item1);
            }
            this.gridView1.OptionsBehavior.Editable = true;
            this.repositoryItemdeptNum1.SelectedIndexChanged += new EventHandler(repositoryItemdeptNum1_SelectedIndexChanged);

            //foreach (DataRow item in RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Region").Rows)
            //{
            //    this.repositoryItemComboBox1.Items.Add(item["RegionName"].ToString());
            //}
            //this.gridView1.OptionsBehavior.Editable = true;

            //this.repositoryItemComboBox1.SelectedIndexChanged += new EventHandler(repositoryItemComboBox1_SelectedIndexChanged);
        }


        private void repositoryItemdeptNum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            DataRow dr = this.gridView1.GetDataRow(row);
            int index = ((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedIndex;
           
            string sql = string.Empty;
             sql = string.Format(@"if ({3}>=0) and not exists (select 1 from RegionToProvince where ProvinceCode='{0}')
                        insert RegionToProvince(RegionToProvinceId,ProvinceCode,ProvinceName,deptNum)
                        values(NEWID(),'{0}','{1}','{2}')
                    else 
                        update RegionToProvince set deptNum='{2}' where ProvinceCode='{0}'"
                 , dr["cDCCODE"].ToString(), dr["CDCNAME"].ToString(),index<0?"":dtDepart.Rows[index]["deptNum"].ToString(),index);
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql.Replace("''", "null"));
        }

        /// <summary>
        /// 加载表
        /// </summary>
        private void LoadGrid()
        {
            //string sql = "select cDCCODE,CDCNAME,r.RegionName,rt.*  from " + U8DataAcc.DataBase + ".DistrictClass dc left outer join RegionToProvince rt inner join Region  r on r.RegionId =rt.RegionId on rt.ProvinceCode = dc.cDCCODE";

            string sql = string.Format(@"select b.RegionToProvinceId, a.cDCCODE,a.CDCNAME,deptName as deptNum 
                            from {0}.DistrictClass a
                            left join RegionToProvince b on a.cDCCODE = b.ProvinceCode
                            left join BaseDepartMent c on b.deptNum=c.deptNum order by a.cDCCODE ", U8DataAcc.U8ServerAndDataBase);

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
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
                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(("update RegionToProvince set RegionId = '" + RegionId + "' where RegionToProvinceId = '" + dr["RegionToProvinceId"].ToString() + "'").Replace("''","null"));
            }
            this.LoadGrid();
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
