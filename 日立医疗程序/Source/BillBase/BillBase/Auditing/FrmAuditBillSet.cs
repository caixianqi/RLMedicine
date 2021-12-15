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
    public partial class FrmAuditBillSet : Form
    {
        string _FunctionId = "";
        string _NodeId = "";
        public FrmAuditBillSet(string FunctionId,string NodeId)
        {
            InitializeComponent();
            _FunctionId = FunctionId;
            _NodeId = NodeId;
            baoButton1.BaoSQL = "select * from BaoSystem..AuditFrmSet ";
            baoButton1.BaoTitleNames = "FrmId=界面编号,FrmName=界面名称";
            System.Data.DataTable dd = Bao.DataAccess.DataAcc.ExecuteQuery(
                    "select a.*,b.FrmName from BaoSystem..AuditNodeFrm a,BaoSystem..AuditFrmSet b "+
                    "where a.FrmId=b.FrmId and a.FunctionId='" + _FunctionId + "' and a.AuditNodeId='" + _NodeId + "' ");
            if (dd.Rows.Count > 0)
            {
                textBox1.Text = dd.Rows[0]["FrmId"].ToString().Trim();
                textBox2.Text = dd.Rows[0]["FrmName"].ToString().Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery ("Delete BaoSystem..AuditNodeFrm "+
                " where FunctionId='" + _FunctionId + "' and AuditNodeId='" + _NodeId +
                "' insert into BaoSystem..AuditNodeFrm(FunctionId,AuditNodeId,FrmId) values('" +
                _FunctionId + "','" + _NodeId + "','" + textBox1.Text.Trim() + "')"
                );
            
        }

        private void baoButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            textBox1.Text = e.ReturnRow1["FrmId"].ToString().Trim();
            textBox2.Text = e.ReturnRow1["FrmName"].ToString().Trim();

        }
    }
}
