using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.AuditFlow
{
    public partial class frmAuditFlowSet : Form
    {
        public AuditFlowSet FlowSetObj;
        public frmAuditFlowSet(string FunctionId)
        {
            InitializeComponent();
            System.Data.DataTable Table1 = Bao.DataAccess.DataAcc.ExecuteQuery("select * from AuditNode");
            foreach(System.Data.DataRow row1 in Table1.Rows )
            {
                ItemComboBox1.Items.Add(row1["AuditNode"].ToString());
                ItemComboBox2.Items.Add(row1["AuditNode"].ToString());
            }
            FlowSetObj = new AuditFlowSet(FunctionId);
            this.gridControl1.DataSource = FlowSetObj.TableAuditFlowInfo;
        }
    }
}
