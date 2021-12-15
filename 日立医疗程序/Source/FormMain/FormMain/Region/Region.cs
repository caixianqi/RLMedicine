using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormMain.Region
{
    public partial class Region : Bao.BillBase.LookUpBasis, Bao.BillBase.IChildForm 
    {
        public Region()
        {
            InitializeComponent();

            this.Width = 300;
            this.Height = 300;
        
        }



        #region IChildForm 成员

        public DataTable GetTableList()
        {
            string sql = "select * from Region";

          


            return RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
        }

        public void Append()
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("insert into Region (RegionName,RegionId) values ('" + this.textBox1.Text.Trim() + "',newid())");
        }

        public void Delete(DataRow row1)
        {
            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RegionToProvince where RegionId = '" + row1["RegionId"].ToString() + "'").Rows.Count > 0)
            {
                throw new Exception("该大区有下属省份，不能删除");
            }
            else
            {
                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("delete from Region where RegionId = '" + row1["RegionId"].ToString() + "'");
                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("delete from RegionToUser where RegionId = '" + row1["RegionId"].ToString() + "'");
            }
        }

        public void SetValueToControl(DataRow row1, bool Is_Update)
        {
            this.textBox1.Text = row1["RegionName"].ToString();
            this.RId.Text = row1["RegionId"].ToString();
        }

        void Bao.BillBase.IChildForm.Update()
        {


            Bao.DataAccess.DataAcc.ExecuteNotQuery("Update Region set RegionName = '"+textBox1.Text+"' where RegionId = '"+RId.Text+"'");
            
        }
        #endregion
    }
}
