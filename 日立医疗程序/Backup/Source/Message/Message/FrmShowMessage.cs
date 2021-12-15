using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.Message
{
    public partial class FrmShowMessage : Bao.FormChildBase, Bao.Interface.IU8Contral 
    {
        public System.Data.DataTable tableMessage;
        public Bao.IFromMain iform;
        public FrmShowMessage()
        {
            InitializeComponent();
        }
        public FrmShowMessage(Bao.IFromMain iform1,System.Data.DataTable messagetable)
        {
           iform=iform1;
           tableMessage = messagetable;
           InitializeComponent();
        }

        private void FrmShowMessage_Load(object sender, EventArgs e)
        {
            
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
        }

        public override void GetBillInfo(string billId)
        {
            MessageBox.Show(billId);
        }


        #region IU8Contral 成员

        public void Authorization()
        {
            
        }
        #endregion

        private void FrmShowMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["DLLName"].ToString() != "")
            {
                iform.ShowChildForm(gridView1.GetDataRow(gridView1.FocusedRowHandle));
                Bao.DataAccess.DataAcc.ExecuteNotQuery("Update TMessageAuto set IsBrows='1' where MessageId='" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["MessageId"].ToString() + "'");
                CMessage.SendReadedFlag(gridView1.GetDataRow(gridView1.FocusedRowHandle)["MessageId"].ToString());
            }
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
