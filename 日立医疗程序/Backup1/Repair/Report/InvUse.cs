using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class InvUse : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        public InvUse()
        {
            InitializeComponent();
            this.rptControl1.FullDLLName = "Repair.dll";
            this.rptControl1.FullClassName = " Repair.Report.InvUserFilter";
            rptControl1.BaoGridViewSource = this.gridView1;
        }

        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion
    }
}
