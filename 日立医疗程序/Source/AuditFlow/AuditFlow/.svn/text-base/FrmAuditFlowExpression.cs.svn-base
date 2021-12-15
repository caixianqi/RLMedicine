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
    public partial class FrmAuditFlowExpression : Form
    {

        public Bao.AuditFlow.AuditFlowFlow ExpressionObj ;
         public FrmAuditFlowExpression(string FunctionId)
        {
            InitializeComponent();
            System.Data.DataTable Table1 = Bao.DataAccess.DataAcc.ExecuteQuery("select * from AuditNode");
            System.Data.DataTable Table2 = Bao.DataAccess.DataAcc.ExecuteQuery("select AutoUserId,UserId,UserName from BaoSystem..Users ");
            System.Data.DataTable Table3 = Bao.DataAccess.DataAcc.ExecuteQuery("select * from ");
            foreach(System.Data.DataRow row1 in Table1.Rows )
            {
                ItemComboBox1.Items.Add(row1["AuditNode"].ToString());
                ItemComboBox2.Items.Add(row1["AuditNode"].ToString());
            }
            LookUpEdit1.DataSource = Table2;
            LookUpEdit1.DisplayMember  = "UserName";
            LookUpEdit1.ValueMember = "AutoUserId";

            ExpressionObj = new AuditFlowFlow(FunctionId);
            this.gridControl1.DataSource = ExpressionObj.TableAuditFlowExpression ;
        }
    }
}
