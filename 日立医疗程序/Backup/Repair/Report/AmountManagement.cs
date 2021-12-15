using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class AmountManagement : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public AmountManagement()
        {
            InitializeComponent();
            this.rptControl1.FullDLLName = "Repair.dll";
            this.rptControl1.FullClassName = " Repair.Report.AmountManagementFilter";
          //  this.gridView1.Columns["省份编码"].Visible = false;
            rptControl1.BaoGridViewSource = this.gridView1;
        }

        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion

          private void gridView_ResumeCollection_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Tag = gridView1.GetDataRow(hi.RowHandle)["维修编号"].ToString();
                this.contextMenuStrip1.Show(Control.MousePosition);
            }
        }

       


        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AmountManagement_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pricecode = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceCode from   Price  where RepairMissionCode = '" + contextMenuStrip1.Tag.ToString() + "'");

            string fid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select BillId from Bill  where PriceCode = '" + pricecode + "'");

            Repair.Bill mision = new Bill(fid);

            mision.MdiParent = this.ParentForm;

            mision.Text = "开票信息";

            mision.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from   RepairMission  where RepairMissionCode = '" + contextMenuStrip1.Tag.ToString() + "'");

            string fid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedbackID from FaultFeedback  where RepairMissionID = '" + id + "'");

            Repair.FaultFeedback mision = new FaultFeedback(fid);

            mision.MdiParent = this.ParentForm;

            mision.Text = "故障解决情况";

            mision.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BillDetails bd = new BillDetails(contextMenuStrip1.Tag.ToString());

            bd.ShowDialog();
        }

        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.gridControl1.DataSource != null)
            {
                this.gridView1.Columns["医院名"].Width = 200;
                this.gridView1.Columns["维修编号"].Width = 120;
            }
        }
    }
}
