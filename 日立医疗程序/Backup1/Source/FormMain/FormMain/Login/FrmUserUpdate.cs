using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormMain.Login
{
    public partial class FrmUserUpdate : Bao.FormChildBase, Bao.Interface.IU8Contral
    { //Bao.FormChildBase ,Bao.Interface.IU8Contral
        //Form
        /// <summary>
        ///  登录 SQL 处理
        /// </summary>
        FormMain.LoginBAL.LoginBL bl = new FormMain.LoginBAL.LoginBL(); 
        private string UserID = string.Empty;
        private string UserName = string.Empty;
        private string OldPassword = string.Empty;
        private string NewPassword = string.Empty;
        /// <summary>
        /// 确认密码
        /// </summary>
        private string OKPassword = string.Empty;
        private string Memo = string.Empty;

        DataTable dtUser;

        public FrmUserUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  取消 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txtMemo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    NewPassword = txtNewPassWord.Text.Trim().ToString();
        //    if (e.KeyChar == (char)13)
        //    {
        //        if (NewPassword != "" && NewPassword != null)
        //        {
        //            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //        }
        //        else
        //        {
        //            btnOK.Focus();
        //        }
        //    }
        //}

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNewPassWord.Focus();
                //this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtNewPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            UserName = txtName.Text.Trim().ToString();
            if (e.KeyChar == (char)13)
            {
                if (UserName != "" && UserName != null)
                {
                    //this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    this.txtOKPassword.Focus();
                }
                else
                {
                    txtName.Focus();
                }
            }
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //修改个人信息
            if (Save_Users())
            {
               
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserUpdate_Load(object sender, EventArgs e)
        {
            //个人信息加载
            txt_Init();
        }

        /// <summary>
        /// 个人信息  文本信息初始化
        /// </summary>
        private void txt_Init()
        {
            txtUser.Text = FrmLogin.UserID;
            txtoldPassWord.Text = FrmLogin.PassWord;
            dtUser = bl.Select_SQL_Users_Login(FrmLogin.UserID, FrmLogin.PassWord);
            if (dtUser.Rows.Count > 0)
            {
                txtName.Text = dtUser.Rows[0]["UserName"].ToString();
                txtMemo.Text = dtUser.Rows[0]["Memo"].ToString();
                //cbxMemo.Text = dtUser.Rows[0]["Memo"].ToString();
            }
        }

        /// <summary>
        /// 修改个人用户信息
        /// </summary>
        private bool Save_Users()
        {
            try
            {
                UserID = FrmLogin.UserID;
                UserName = txtName.Text.Trim().ToString();
                string newPassWord = txtNewPassWord.Text.Trim().ToString();
                string OkPWD = txtOKPassword.Text.Trim().ToString();
                OldPassword = FrmLogin.PassWord;
                if (txtNewPassWord.Text == null || txtNewPassWord.Text == "")
                {
                    MessageBox.Show("新密码不能为空！", "温馨提示！");
                    txt_Init();
                    return false;

                }
                else if (OkPWD == null || OkPWD == "")
                {
                    MessageBox.Show("确认密码不能为空！", "温馨提示！");
                    txt_Init();
                    return false;
                }
                else if (newPassWord != OkPWD)
                {
                    MessageBox.Show("输入的密码不一致！", "温馨提示！");
                    txt_Init();
                    txtNewPassWord.Text = "";
                    txtOKPassword.Text = "";
                    return false;
                }
                else
                {
                    //NewPassword = bl.GetMD5Encording(txtNewPassWord.Text.Trim().ToString());
                    OKPassword = bl.GetMD5Encording(OkPWD.Trim().ToString());
                    Memo = txtMemo.Text.Trim().ToString();
                    //Memo = cbxMemo.Text.Trim().ToString();
                    DialogResult Result = MessageBox.Show("您是否要修改个人信息！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        bl.Update_SQL_User(UserID, UserName, OldPassword, OKPassword, Memo);
                        MessageBox.Show("密码修改成功！", "温馨提示！");
                        this.Close();
                    }
                    else
                    {
                        txt_Init();
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
             return true;
        }


        #region IU8Contral 成员

        public void Authorization()
        {
            //新增
            //btnOK.Enabled= Bao.DataAccess.DataAcc.GetHoldAuth("1");
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmUserUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain.FromMain.fuu = null;
        }

        private void cbxMemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OKPassword = txtOKPassword.Text.Trim().ToString();
            //if (e.KeyChar == (char)13)
            //{
            //    if (NewPassword == OKPassword)
            //    {
            //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
            //    }
            //    else
            //    {
            //        this.txtOKPassword.Focus();
            //    }
            //}
        }

        private void txtOKPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            NewPassword = txtNewPassWord.Text.Trim().ToString();
            OKPassword = txtOKPassword.Text.Trim().ToString();
            if (e.KeyChar == (char)13)
            {
                if (OKPassword != "" && OKPassword != null)
                {
                    if (NewPassword == OKPassword)
                    {
                        //this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        btnOK.Focus();
                    }
                    else
                    {
                        txtOKPassword.Text = "";
                        MessageBox.Show("输入的密码不一致！", "温馨提示！");
                    }
                }
                else
                {
                    this.txtOKPassword.Focus();
                }
            }
        }

    }
}
