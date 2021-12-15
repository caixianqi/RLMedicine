using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class RepairQualityAndWork : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public RepairQualityAndWork()
        {
            InitializeComponent();
            this.rptControl1.FullDLLName = "Repair.dll";
            this.rptControl1.FullClassName = " Repair.Report.RepairQualityAndWorkFilter";
            rptControl1.BaoGridViewSource = this.gridView1;
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }
        private void gridView_ResumeCollection_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Tag = gridView1.GetDataRow(hi.RowHandle)["维修编号"].ToString();
                this.contextMenuStrip1.Show(Control.MousePosition);
            }
        }

        #endregion

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionID from   RepairMission  where RepairMissionCode = '" + contextMenuStrip1.Tag.ToString() + "'");

            string fid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select FaultFeedbackID from FaultFeedback  where RepairMissionID = '" + id + "'");

            Repair.FaultFeedback mision = new FaultFeedback(fid);

            mision.MdiParent = this.ParentForm;

            mision.Text = "故障解决情况";

            mision.Show();
        }
    }
}
