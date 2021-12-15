using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase.Auditing
{
    /// <summary>
    /// 用于显示审批列表被FrmBillBase调用
    /// </summary>

    public partial class FrmAuditList : Form
    {
        public Boolean CloseFlag = false;
        public FrmAuditList()
        {
            InitializeComponent();
        }

        private void FrmAuditList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseFlag)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }
    }
}
