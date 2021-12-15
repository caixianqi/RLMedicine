using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.UserAuth
{
    public partial class FrmUser : Form
    {
        System.Data.DataTable tableuser;
        public FrmUser()
        {
            InitializeComponent();
        }

        private void 授权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bao.UserAuth.FrmAuthorization aa = new Bao.UserAuth.FrmAuthorization(gridView1.GetDataRow(gridView1.FocusedRowHandle )["AutoUserId"].ToString());
            aa.Show();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LoadUser();

            this.toolBarBill1.BtnUpdate.Enabled = true;
            this.UpState(false);
        }
        private void LoadUser()
        {
            string sql = "select AutoUserId,UserId,UserName,case when state=0 then '暂停' else '正常' end State ,Memo from BaoSystem..Users ";
            tableuser = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            gridControl1.DataSource = tableuser;

            this.txtUserId.DataBindings.Clear();
            this.txtUserName.DataBindings.Clear();
            this.txtState.DataBindings.Clear();
            this.txtMemo.DataBindings.Clear();
            this.txtAutoId.DataBindings.Clear();

            this.txtUserId.DataBindings.Add("Text", tableuser, "UserId");
            this.txtUserName.DataBindings.Add("Text", tableuser, "UserName");
            this.txtState.DataBindings.Add("Text", tableuser, "State");
            this.txtMemo.DataBindings.Add("Text", tableuser, "Memo");
            this.txtAutoId.DataBindings.Add("Text", tableuser, "AutoUserId");
            
        }
        private void UpState(Boolean a)
        {
            txtUserId.Enabled = a;
            txtUserName.Enabled = a;
            txtState.Enabled = a;
            txtMemo.Enabled = a;
          

        }
        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            UpState(true);
        }

        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            UpState(true);
        }

        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            int d;
            string sql;
            if (txtState.Text =="正常")
                d=1;
            else
                d=0;
            if (toolBarBill1.Is_Update)
            
                sql = "update BaoSystem..Users set userId='" + txtUserId.Text + "',userName='" + txtUserName.Text + "',State='"+d.ToString()+"',Memo='"+txtMemo.Text +"' where autoUserId='"+txtAutoId.Text+"' ";
            
            else
                sql ="insert into BaoSystem..Users (userId,userName,State,Memo,password)values ('"+txtUserId.Text +"','"+txtUserName.Text +"','"+d.ToString()+"','"+txtMemo.Text+"','')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
            UpState(false);
            LoadUser();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
        }

    }
}
