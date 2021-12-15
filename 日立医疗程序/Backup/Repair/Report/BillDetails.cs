using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class BillDetails : Form
    {
        public BillDetails(string code)
        {
            InitializeComponent();

            string pricecode = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceCode from   Price  where RepairMissionCode = '" + code + "'");

            string fid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select BillId from Bill  where PriceCode = '" + pricecode + "'");

            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from BillDetails where billid = '" + fid + "'");
            this.gridControl2.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from MoneyReceive where billid = '" + fid + "'");

        }
    }
}
