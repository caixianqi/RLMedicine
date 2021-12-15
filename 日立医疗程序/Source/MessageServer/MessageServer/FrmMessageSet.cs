using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.MessageServer
{
    public partial class FrmMessageSet : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private System.Data.DataTable table1;
        public FrmMessageSet()
        {
            InitializeComponent();
        }
        public void ReadOnlay(Boolean flag)
        {
            UserName.ReadOnly = flag;
            FunctionName.ReadOnly = flag;
            WeekDay.Enabled = !flag;
            MonthDay.Enabled = !flag;
            
        }
        public void Band()
        {
            
        }
        private void FrmMessageSet_Load(object sender, EventArgs e)
        {
            table1=Bao.DataAccess.DataAcc.ExecuteQuery("select a.*,b.FunctionName,c.UserName,d.Memo from BaoSystem..TMessageSet a," +
                                                "BaoSystem..Tfunctions b,BaoSystem..users c,BaoSystem..[WeekDay] d  " +
                                                "where a.FunctionId=b.FunctionId and a.AutoUserId=c.AutoUserId and a.TipsWeekDay=d.TipsWeekDay");
            this.gridControl1.DataSource = table1;
            
            this.UserName.DataBindings.Clear();
            this.FunctionName .DataBindings.Clear();
            this.WeekDay .DataBindings.Clear();
            this.MonthDay .DataBindings.Clear();
            this.FunctionId.DataBindings.Clear();
            this.AutoUserId.DataBindings.Clear();

            this.UserName.DataBindings.Add("Text", table1, "UserName");
            this.FunctionName.DataBindings.Add("Text", table1, "FunctionName");
            this.WeekDay.DataBindings.Add("Text", table1, "Memo");
            //this.WeekDay.DataBindings.Add("Text", table1, WeekDay.Items.IndexOf(WeekDay.Text));
            
            this.MonthDay.DataBindings.Add("Text", table1, "TipsMonthDay");
            this.FunctionId.DataBindings.Add("Text", table1, "FunctionId");
            this.AutoUserId.DataBindings.Add("Text", table1, "AutoUserId");

            this.BaoBtnUserName.BaoSQL = "select * from BaoSystem..Users ";
            this.BaoBtnUserName.BaoTitleNames = "UserName=用户";
            this.BaoBtnFunctionName.BaoSQL = "select * from BaoSystem..TFunctions ";
            this.BaoBtnFunctionName.BaoTitleNames = "FunctionName=功能";
            this.toolBarBill1.BtnUpdate.Enabled = true;
            this.toolBarBill1.BtnPrint.Enabled = true;
            this.toolBarBill1.BtnExcel.Enabled = true;
            
            toolBarBill1.PrintData.Tables.Clear();
            toolBarBill1.PrintData.Tables.Add(table1);
            toolBarBill1.GridViewSource = this.gridView1; 
        }

        private void toolBarBill1_Load(object sender, EventArgs e)
        {

        }

        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要删除？", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Bao.DataAccess.DataAcc.ExecuteNotQuery("delete TMessageSet where AutoUserId='" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["AutoUserId"].ToString() + "' and FunctionId='" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["FunctionId"].ToString() + "'");
                FrmMessageSet_Load(this, null);
            }
        }

        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            string sql;
            if (toolBarBill1.Is_Update)

                sql = "update BaoSystem..TMessageSet set AutoUserId='" + AutoUserId.Text + "',FunctionId='" +
                    FunctionId.Text + "',TipsWeekDay=" + WeekDay.Items.IndexOf(WeekDay.Text) + "+1,TipsMonthDay='" + MonthDay.Text + "' where autoId='" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["AutoId"].ToString() + "' ";

            else
                sql = "insert into BaoSystem..TMessageSet (AutoUserId,FunctionId,TipsWeekDay,TipsMonthDay)values ('" +
                    AutoUserId.Text + "','" + FunctionId.Text + "','" + WeekDay.Text + "','" + MonthDay.Text + "')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            ReadOnlay (true);
            FrmMessageSet_Load(this, null);
        }

        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            ReadOnlay(false);
        }

        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            ReadOnlay(false);
        }



        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void BaoBtnUserName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.AutoUserId.Text = e.ReturnRow1["AutoUserId"].ToString();
            this.UserName.Text = e.ReturnRow1["UserName"].ToString();
        }

        private void BaoBtnFunctionName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.FunctionName.Text = e.ReturnRow1["FunctionName"].ToString();
            this.FunctionId .Text = e.ReturnRow1["FunctionId"].ToString();
        }

        private void toolBarBill1_OnBaoExcel(object sender, EventArgs e)
        {
            
        }

        private void toolBarBill1_OnBaoExit(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
        
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }
    }
}
