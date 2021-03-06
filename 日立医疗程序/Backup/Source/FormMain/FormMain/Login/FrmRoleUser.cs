using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormMain.Login
{
    public partial class FrmRoleUser : Bao.BillBase.LookUpBasis, Bao.BillBase.IChildForm 
    {
        public FrmRoleUser()
        {
            InitializeComponent();
            
           
        }

        #region IChildForm 成员

        public DataTable GetTableList()
        {
            this.IParentForm.toolBarBill1.BtnNewVisable = false;

            string ss = "select a.*,b.AutoUserId,c.UserName,c.UserId from TRole a left outer join  TRoleUsers b on a.RoleId=b.RoleId left outer join Users c on b.AutoUserId=c.AutoUserId ";
            return Bao.DataAccess.DataAcc.ExecuteQuery(ss);

        }

        public void Append()
        {
        }

        public void Delete(DataRow row1)
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("delete TRoleUsers where RoleId='" + row1["RoleId"].ToString().Trim() + "' and AutoUserId='" + row1["AutoUserId"].ToString().Trim() + "'");
        }

        public void SetValueToControl(DataRow row1, Boolean Is_Update)
        {
            RoleId.Text = row1["RoleId"].ToString();
            RoleName.Text = row1["RoleName"].ToString();
            UserName.Items.Clear();

        }

        void Bao.BillBase.IChildForm.Update()
        {
            for (int i = 0; i < UserName.Items.Count; i++)
            {
                string ss=UserName.Items[i].ToString();
                ss=ss.Substring(0,ss.LastIndexOf ("-"));

                Bao.DataAccess.DataAcc.ExecuteNotQuery ("insert into TRoleUsers (RoleId,AutoUserId) values ('" + RoleId.Text.Trim() + "','" + ss + "')");
            }
        }


        #endregion

        private void baoButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            UserName.Items.Add(e.ReturnRow1["AutoUserId"].ToString().Trim()+"-"+e.ReturnRow1["UserName"].ToString().Trim());
        }

        private void baoButton1_Enter(object sender, EventArgs e)
        {
            //baoButton1.BaoSQL = "select a.* from Users a left outer join (select * from TRoleUsers where RoleId='"+RoleId.Text.Trim()+"') b on a.AutoUserId=b.AutoUserId where  b.AutoUserId is null  ";
            //客户要求一个用户多角色，因此这里要改
            baoButton1.BaoSQL = "select a.* from Users a left outer join (select * from TRoleUsers where RoleId='" + RoleId.Text.Trim() + "') b on a.AutoUserId=b.AutoUserId  ";
            baoButton1.BaoTitleNames = "UserId=编号,UserName=名称";
        }
    }
}
