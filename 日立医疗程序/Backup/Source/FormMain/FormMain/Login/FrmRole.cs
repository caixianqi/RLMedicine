using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FormMain.Login
{
    public partial class FrmRole : Bao.BillBase.LookUpBasis, Bao.BillBase.IChildForm 
    {
        public FrmRole()
        {
            InitializeComponent();
           
        }

        #region IChildForm 成员

        public DataTable GetTableList()
        {
             return Bao.DataAccess.DataAcc.ExecuteQuery("select * from TRole ");
        }
       

        public void Append()
        {
            string sql = "insert into TRole  (RoleId,RoleName,Memo) values ('" + RoleId.Text.Trim() + "','" +
                RoleName.Text.Trim() + "','" + Memo.Text.Trim()+ "')";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        public void Delete(DataRow row1)
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("delete TRole where RoleId='" + row1["RoleId"].ToString() + "'");
           
        }

        public void SetValueToControl(DataRow row1, Boolean Is_Update)
        {
            this.RoleId.Text=row1["RoleId"].ToString().Trim();
            this.RoleName.Text =row1["RoleName"].ToString().Trim();
            this.Memo.Text =row1["Memo"].ToString().Trim();
        }

        void Bao.BillBase.IChildForm.Update()
        {
            string sql = "Update TRole set RoleName='" + RoleName.Text.Trim() + "',Memo='" + Memo.Text.Trim() +
              "'  where RoleId='" + RoleId.Text.Trim() + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        #endregion
    }
}
