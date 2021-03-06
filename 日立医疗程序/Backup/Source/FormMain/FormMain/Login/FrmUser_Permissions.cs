using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormMain.Login
{
    public partial class FrmUser_Permissions : Bao.FormChildBase,Bao.Interface.IU8Contral
    {
        FormMain.LoginBAL.LoginBL bl = new FormMain.LoginBAL.LoginBL();

        private string AutoUserID = string.Empty;
        private string UserId = string.Empty;
        private string UserName = string.Empty;
        private string Password = string.Empty;

        //private string Password = string.Empty; 

        //private string Password = string.Empty;

        private string AuthID = string.Empty;

        DataTable dtAuth;

        /// <summary>
        /// 选择人员
        /// </summary>
        private string sql = string.Empty;

        public FrmUser_Permissions()
        {
            InitializeComponent();
            sql = "select * from TRole ";
            
            //if (FrmLogin.UserID == "demo")
            //{
            //    sql = "select AutoUserID,UserId,UserName,[Password], State,Memo from [Users]  where UserId!='demo' ";
            //}
            //else 
            //{
            //    sql = "select AutoUserID,UserId,UserName,[Password], State,Memo from [Users]  where UserId!='demo' and  Memo!='系统管理员' "
            //    + "union    "
            //    + "select AutoUserID,UserId,UserName,[Password], State,Memo from [Users]     "
            //    + "where UserId!='" + FormMain.FrmLogin.UserID + "' and [Password]!='" + FormMain.FrmLogin.PassWord + "' and Memo!='系统管理员' ";
            //}
            baoBtnUsers.BaoSQL = sql;
           // baoBtnUsers.BaoTitleNames = "UserId=用户ID,UserName=用户名称,State=状态,Memo=备注";
            baoBtnUsers.BaoTitleNames = "RoleId=角色编号,RoleName=角色名称,Memo=备注";
            baoBtnUsers.Enabled = true;

        }


        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baoBtnUsers_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.gridControl1.Enabled = true;
            this.btnOK.Enabled = true;
            this.btnSelect_All.Enabled = true;
            this.btnSelect_Cancel.Enabled = true;

            //AutoUserID = e.ReturnRow1["AutoUserID"].ToString();
            //UserId = e.ReturnRow1["UserId"].ToString();
            //UserName = e.ReturnRow1["UserName"].ToString();
            //Password = e.ReturnRow1["Password"].ToString();

            //txtUser.Text = UserId;
            //txtName.Text = UserName;
            txtUser.Text = e.ReturnRow1["RoleId"].ToString();
            txtName.Text = e.ReturnRow1["RoleName"].ToString();

            DataBind();

            //获取人员姓名
            //txtcPsn_Name.Text = e.ReturnRow1["cPsn_Name"].ToString();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void DataBind()
        {
            ///列出所有功能
            dtAuth = bl.Select_SQL_Auth_and_TFunctions_Infos();
            dtAuth.Columns.Add("select", System.Type.GetType("System.Boolean"));
            foreach (System.Data.DataRow row1 in dtAuth.Rows)
            {
                string AuthID = row1["AuthId"].ToString();
                string IsUserAuth = bl.Select_SQL_UserAuth_AuthId(txtUser.Text, AuthID);

                if (IsUserAuth =="1")
                {
                    row1["select"] = true;
                }
                else
                {
                    row1["select"] = false;
                }
            }
            this.gridControl1.DataSource = dtAuth;
        }

        private void FrmUser_Permissions_Load(object sender, EventArgs e)
        {
            //this.gridControl1.Enabled = false;
            //this.btnOK.Enabled = false;
            //this.btnSelect_All.Enabled = false;
            //this.btnSelect_Cancel.Enabled = false;
            baoBtnUsers.Enabled = true;

            //初始化 
            dtAuth = bl.Select_SQL_Auth_and_TFunctions_Infos();
            dtAuth.Columns.Add("select", System.Type.GetType("System.Boolean"));
            foreach (System.Data.DataRow row1 in dtAuth.Rows)
            {
                row1["select"] = false;
            }
            this.gridControl1.DataSource = dtAuth;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtUser.Text == null || txtName.Text == "" || txtName.Text == null)
            {
                MessageBox.Show("请选择人员", "温馨提示！");
                this.baoBtnUsers.Focus();
            }
            else
            {
                gridView1.FocusedRowHandle -= 1;
                DialogResult Result = MessageBox.Show("您是否要对【"+txtUser.Text.Trim().ToString()+"】进行权限分配！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    //保存
                    if (Save_UserAuth())
                    {
                        MessageBox.Show("权限分配成功！", "温馨提示！");
                    }
                }
                gridView1.FocusedRowHandle += 1;
            }
        }


        private bool Save_UserAuth()
        {
            try
            {
                foreach (System.Data.DataRow row1 in dtAuth.Rows)
                {
                    string AuthID = row1["AuthId"].ToString();
                    string IsUserAuth = bl.Select_SQL_UserAuth_AuthId(txtUser.Text.Trim(), AuthID);

                    //选中的权限
                    if (Convert.ToBoolean(row1["select"]) == true)
                    {
                        if (IsUserAuth == "1")
                        {
                            //已经存在，不需要再添加
                            //row1["select"] = true;
                        }
                        else
                        {
                            //插入   选中的功能节点信息
                            bl.Insert_SQL_UserAuth(txtUser.Text.Trim(), AuthID);
                            //row1["select"] = false;
                        }
                        row1["select"] = true;
                    }
                    else
                    {
                        //删除   选中的功能节点信息
                        bl.Delete_SQL_UserAuth(txtUser.Text.Trim(), AuthID);
                        row1["select"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }




        #region IU8Contral 成员

        public void Authorization()
        {
            this.baoBtnUsers.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0007");
            this.btnSelect_All.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0008");
            this.btnSelect_Cancel.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0009");
            this.btnFX.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0010");
            this.btnOK.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS00011");
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_All_Click(object sender, EventArgs e)
        {
            IsSelect(true);
        }

        /// <summary>
        /// 全消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Cancel_Click(object sender, EventArgs e)
        {
            IsSelect(false);
        }

        /// <summary>
        /// 反选
        /// </summary>
        private void FXSelect()
        {
            gridView1.FocusedRowHandle -= 1;
            foreach (DataRow _row in dtAuth.Rows)
            {
                if (Convert.ToBoolean(_row["Select"]) == false)
                {
                    _row["Select"] = true;
                }
                else if (Convert.ToBoolean(_row["Select"]) == true)
                {
                    _row["Select"] = false;
                }
            }
            gridView1.FocusedRowHandle += 1;
        }

        /// <summary>
        ///  全选，全消 选择方法
        /// </summary>
        /// <param name="IsEnabled"></param>
        private void IsSelect(bool IsEnabled)
        {
            gridView1.FocusedRowHandle -= 1;
            foreach (System.Data.DataRow _row in dtAuth.Rows)
            {
                _row["select"] = IsEnabled;
            }
            gridView1.FocusedRowHandle += 1;
        }

        private void btnFX_Click(object sender, EventArgs e)
        {
            FXSelect();
        }

    }
}
