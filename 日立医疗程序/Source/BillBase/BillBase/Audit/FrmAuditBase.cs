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
    public partial class FrmAuditBase : Bao.BillBase.FrmBillBase 
    {
        
        public FrmAuditBase(Bao.BillBase.FrmBillBase Sender,string Functionid,string JFWId)
        {
            InitializeComponent();
            this.BO = new AuditBaseBill();
            ((AuditBaseBill)BO).FunctionId = Functionid;
            ((AuditBaseBill)BO).JFWId = JFWId;
            BO.Init("");
            
           
            
        }


        public override void BaoDataBinding()
        {
            //将控件与BO对象的属性邦定　Demo 如下;
            this.textBox1.DataBindings.Add("Text", BO.EntityTables[0].Table, "Memo");
            this.textBox2.DataBindings.Add("Text", BO.EntityTables[0].Table, "JFWId");

            
        }
        public override void BaoUnDataBinding()
        {   //撤销邦定
            this.textBox1.DataBindings.Clear();
            this.textBox2.DataBindings.Clear();
        }
     
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BO.EntityTables[0].Table.Rows[0]["Flag"] = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BO.EntityTables[0].Table.Rows[0]["Flag"] = "0";
        }

        private void FrmAuditBase_Load(object sender, EventArgs e)
        {
            CtrEnable(true);
            this.toolBarBill1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BO.NewSave();
            Close();
        }


    }
}
