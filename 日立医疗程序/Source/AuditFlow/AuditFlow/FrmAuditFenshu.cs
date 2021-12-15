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
    public partial class FrmAuditFenshu : Form
    {
        public string LoginUserId;
        public string FunctionId;
        public string EntityId;
        public string BillId;
        public Bao.BillBase.IAudit  Sender;
        public FrmAuditFenshu(Bao.BillBase.IAudit mSender,string mFunctionId, string mEntityId, string mBillId, string mLoginUserId)
        {
            InitializeComponent();
            
            LoginUserId = mLoginUserId;
            FunctionId = mFunctionId;
            EntityId = mEntityId;
            BillId = mBillId;
            Sender = mSender;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuditExec aa = new AuditExec();
            if (aa.Audit(LoginUserId, FunctionId, BillId,textBox1.Text ,Double.Parse(comboBox1.Text)) == 1)
                Sender.Audit();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
