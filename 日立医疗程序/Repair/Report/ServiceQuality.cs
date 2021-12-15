using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class ServiceQuality : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public ServiceQuality()
        {
            InitializeComponent();
            
            this.rptControl1.FullDLLName = "Repair.dll";
            this.rptControl1.FullClassName = " Repair.Report.ServiceQualityFilter";
            rptControl1.BaoGridViewSource = this.gridView1;
        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {


            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairPersonCode"].ToString();

            string type = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairType"].ToString();




            Repair.Report.ServiceQualityDetails mision = new Repair.Report.ServiceQualityDetails(id, this.gridControl1.DataSource.ToString().Split(',')[0], this.gridControl1.DataSource.ToString().Split(',')[1], type);

          
            mision.Show();
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion
    }
}
