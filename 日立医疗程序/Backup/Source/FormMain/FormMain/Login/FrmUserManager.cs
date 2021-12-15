using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using U8Global;
using RiLiGlobal;

namespace FormMain.Login
{
    public partial class FrmUserManager : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        /// <summary>
        /// 用户SQL处理
        /// </summary>
        FormMain.LoginBAL.LoginBL bl = new FormMain.LoginBAL.LoginBL();
        System.Data.DataTable TAuditGroups;
        /// <summary>
        /// 新增判断
        /// </summary>
        private bool IsNew = false;

        /// <summary>
        /// 修改判断
        /// </summary>
        private bool IsUpdate = false;

        /// <summary>
        /// 封存
        /// </summary>
        private bool IsState_false = false;

        /// <summary>
        /// 解存
        /// </summary>
        private bool IsState_true = false;

        private string AutoUserId = string.Empty;

        /// <summary>
        /// 用户ID
        /// </summary>
        private string UserId=string.Empty;
        /// <summary>
        /// 用户名称
        /// </summary>
        private string UserName = string.Empty;
        /// <summary>
        /// 用户密码
        /// </summary>
        private string Password=string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        private string State = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        private string Memo=string.Empty;

        private string Pwd = string.Empty;

        //定义表
        DataTable dtUser;

        /// <summary>
        /// 旧的密码
        /// </summary>
        private string OldPwd = string.Empty;

        public FrmUserManager()
        {
            InitializeComponent();
           // Properties.Settings.Default.Timer == true;

            //baoButton1.BaoSQL = "select cinvcode,cinvname  from " + U8DataAcc.DataBase + "..inventory";
            //baoButton1.BaoTitleNames = "cinvcode=存货编码 ,cinvname=存货名称";

            //baoButton1.DecideSql = "select * from " + U8DataAcc.DataBase + "..inventory where inventory.cinvcode=";
            //baoButton1.BaoColumnsWidth = "cinvcode=150,cinvname=250";
            //baoButton1.BaoClickClose = true;


            baoButton1.BaoDataAccDLLFullPath = Properties.Settings.Default.EmplDllName;
            baoButton1.BaoFullClassName = Properties.Settings.Default.EmplClassName;

            TAuditGroups = Bao.DataAccess.DataAcc.ExecuteQuery("select AuditGroupId,AuditGroupName from AuditGroup ");
            //this.AuditGroupItem.DataSource = TAuditGroups;
            //this.AuditGroupItem.DisplayMember = "AuditGroupName";
            //this.AuditGroupItem.ValueMember = "AuditGroupId";


            //baoButton2.BaoSQL = "select * from Region";
            //baoButton2.BaoTitleNames = "RegionId=编号,RegionName=名称";

        }

        /// <summary>
        ///  新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMNew_Click(object sender, EventArgs e)
        {
            txtClear();
            TSMNew.Enabled = false;
            TSMDelete.Enabled = false;
            TSMState.Enabled = false;
            TSMUpdate.Enabled = false;
            TSMState1.Enabled = false;
            TSMSave.Enabled = true;

            this.IsNew = true;
            this.IsUpdate = false;

            //txt属性设置
            txt_Enabled(true);
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMUpdate_Click(object sender, EventArgs e)
        {
            TSMNew.Enabled = false;
            TSMDelete.Enabled = false;
            TSMState.Enabled = false;
            TSMUpdate.Enabled = false;
            TSMState1.Enabled = false;
            TSMSave.Enabled = true;

            this.IsNew = false;
            this.IsUpdate = true;
            //txt属性设置
            txt_Enabled(true);
            txtUser.Enabled = false;
            txtPassword.Text = "";
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMDelete_Click(object sender, EventArgs e)
        {
            
            this.TSMDelete.Enabled = false;
            //删除事件
            Delete_User();

        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMSave_Click(object sender, EventArgs e)
        {
             DialogResult Result = MessageBox.Show("您是否保存当前信息！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (Result == DialogResult.Yes)
             {
                 if (Text_Verification())
                 {
                     //保存信息
                     if (Save_User())
                     {
                         //txt属性设置
                         txt_Enabled(false);
                         DataBind();
                         MessageBox.Show("保存成功！", "温馨提示！");
                         TSMNew.Enabled = true;
                         TSMDelete.Enabled = true;
                         TSMState.Enabled = true;
                         TSMUpdate.Enabled = true;
                         TSMState1.Enabled = false;
                         TSMSave.Enabled = false;
                     }
                     else
                     {
                         this.TSMSave.Enabled = true;
                     }
                 }
                 else
                 {
                     if (IsNew == true)
                     {
                         this.TSMNew.Enabled = false;
                         this.TSMUpdate.Enabled = false;
                     }
                     else if (IsUpdate == true)
                     {
                         this.TSMUpdate.Enabled = false;
                         this.TSMNew.Enabled = false;
                     }
                     this.TSMDelete.Enabled = false;
                     this.TSMState.Enabled = false;
                     this.TSMState1.Enabled = false;
                     this.TSMSave.Enabled = true;
                 }
             }
        }

        /// <summary>
        /// 封存用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMState_Click(object sender, EventArgs e)
        {
             DialogResult Result = MessageBox.Show("您是否封存当前用户！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (Result == DialogResult.Yes)
             {
                 this.TSMState.Enabled = false;
                 this.TSMState1.Enabled = true;
                 IsState_false = true;
                 IsState_true = false;
                 Update_Users_State();
             }
        }

        /// <summary>
        /// 解存用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMState1_Click(object sender, EventArgs e)
        {
             DialogResult Result = MessageBox.Show("您是解存存当前用户！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (Result == DialogResult.Yes)
             {
                 this.TSMState.Enabled = true;
                 this.TSMState1.Enabled = false;

                 IsState_false = false;
                 IsState_true = true;
                 Update_Users_State();
             }
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 文本信息验证
        /// </summary>
        /// <returns></returns>
        private bool Text_Verification()
        {
            ////用户ID
            UserId = txtUser.Text.Trim().ToString();
            ////用户名称
            UserName = txtName.Text.Trim().ToString();
            //用户密码
            Pwd = txtPassword.Text.Trim().ToString();
            ////备注
            //Memo = txtMemo.Text.Trim().ToString();
            if (UserId == "" || UserId == null)
            {
                MessageBox.Show("用户名不能为空！", "温馨提示！");
                this.txtUser.Focus();
                return false;
            }
            else if (UserName==""||UserName==null)
            {
                MessageBox.Show("用户名称不能为空！", "温馨提示！");
                this.txtName.Focus();
                return false;
            }
            else if (Pwd == "" || Pwd == null)
            {
                if (IsNew == true)
                {
                    MessageBox.Show("密码不能为空！", "温馨提示！");
                    this.txtPassword.Focus();
                    return false;
                }
            }
            else
            {
                if (IsNew == true)
                {
                    DataTable dt = bl.Select_Is_User(txtUser.Text.Trim().ToString());
                    if (dt.Rows.Count > 0)
                    {
                        this.TSMNew.Enabled = false;
                        this.TSMUpdate.Enabled = false;
                        this.TSMDelete.Enabled = false;
                        this.TSMState.Enabled = false;
                        this.TSMState1.Enabled = false;
                        this.TSMSave.Enabled = true;
                        MessageBox.Show(UserId + "用户已存在！", "温馨提示！");
                        txtUser.Text = "";
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 用户保存处理方法
        /// </summary>
        private bool Save_User()
        {
            ////用户ID
            //UserId = txtUser.Text.Trim().ToString();
            ////用户名称
            //UserName = txtName.Text.Trim().ToString();
            //文本信息验证
            try
            {

                //用户密码
                Password = bl.GetMD5Encording(txtPassword.Text.Trim().ToString());
                //判断用户密码是否为空！
                //string pwd=txtPassword.Text.Trim().ToString()
                //邮箱
                Memo = txtMemo.Text.Trim().ToString();
               // Memo = cbxMemo.Text.Trim().ToString();

                if (IsNew == true)
                {
                    //新增用户
                    bl.Insert_SQL_Users(UserId, UserName, Password, Memo,string.Empty,string.Empty);
                    //分配权限
                    //Add_UserAuth_();
                }
                else if (IsUpdate == true)
                {
                    bl.Update_SQL_Users(UserId, OldPwd, Password, UserName, Memo,string.Empty,string.Empty);

                }  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }    
            return true;
        }


        /// <summary>
        /// 用户个人修改信息 权限分配
        /// </summary>
        private void Add_UserAuth_()
        {
            string AutoUserID = bl.Select_SQL_Users_AutoUserID(UserId, Password);
            DataTable dtAT = bl.Select_SQL_Auth_and_TFunctions();
            string AuthID = dtAT.Rows[0]["AuthId"].ToString();
            //用户个人修改信息 权限分配  插入信息
            bl.Insert_SQL_UserAuth_Info(AutoUserID, AuthID);
        }


        /// <summary>
        /// 用户删除处理方法
        /// </summary>
        private bool Delete_User()
        {
            DialogResult Result = MessageBox.Show("您是否要删除当前信息！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                //删除用户信息
                Delete_UserInfo();
                DataBind();
                MessageBox.Show("删除成功！", "温馨提示！");
            }
            else
            {
                return false;
            }
            return true;
        }

     

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void DataBind()
        {
            string UserID = FrmLogin.UserID;
            string Pwd=FrmLogin.PassWord;
            if (UserID == "demo")
            {
                dtUser = bl.Select_SQL_Users_Info();
            }
            else
            {
                dtUser = bl.Select_SQL_User_Infos(UserID, Pwd);
            }
            this.gridControl1.DataSource = dtUser;
        }


        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            if (FrmLogin.UserID != "demo")
            {
                this.cbxMemo.Items.Clear();
                this.cbxMemo.Items.AddRange(new object[] { "", "操作员", "其他" });
            }
            this.TSMSave.Enabled = false;
            this.TSMDelete.Enabled = false;
            this.TSMState.Enabled = false;
            this.TSMState1.Enabled = false;
            
            //数据绑定
            DataBind();
            txt_Enabled(false);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        private void Delete_UserInfo()
        {
            
             System.Data.DataRow row1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
             string num = Bao.DataAccess.DataAcc.ExecuteScalar("select count(*) from TRoleUsers where AutoUserId='" + row1["AutoUserId"].ToString() + "'");
             if (int.Parse(num) > 0)
             {
                 throw new Exception("该用户已使用，不能删除");
             } 
             AutoUserId = row1["AutoUserId"].ToString();
             UserId = row1["UserId"].ToString();
             OldPwd = row1["Password"].ToString();
             //删除当前用户信息
             bl.Delete_SQL_Users(UserId, OldPwd, AutoUserId);
             //清空文本框
             txtClear();
        }

        /// <summary>
        /// 设置txt属性
        /// </summary>
        /// <param name="IsEnabled"></param>
        private void txt_Enabled(bool IsEnabled)
        {
            txtUser.Enabled = IsEnabled;
            txtName.Enabled = IsEnabled;
            txtPassword.Enabled = IsEnabled;
            txtMemo.Enabled = IsEnabled;
            cbxMemo.Enabled = IsEnabled;
           // baoButton2.Enabled = IsEnabled;
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        private void txtClear()
        {
            txtUser.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtMemo.Text = "";
            cbxMemo.Text = "";
          //  TxtAuditGroupId.Text = "";
          //  DeptName.Text = "";
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            UserId = txtUser.Text;
            if (e.KeyChar == (char)13)
            {
                if (txtUser.Text == "" || txtUser.Text == null)
                {
                    MessageBox.Show("用户名不能为空！","温馨提示！");
                    txtUser.Focus();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            UserName = txtName.Text;
            if (e.KeyChar == (char)13)
            {
                if (UserName == "" || UserName == null)
                {
                    txtName.Focus();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

        private void txtMemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Password = txtPassword.Text;
            if (e.KeyChar == (char)13)
            {
                if (Password == "" || Password == null)
                {
                    txtPassword.Focus();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }



        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                this.TSMNew.Enabled = true;
                this.TSMUpdate.Enabled = true;
                this.TSMDelete.Enabled = true;
                //txt属性设置
                txt_Enabled(false);
                System.Data.DataRow row1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                UserId = row1["UserId"].ToString();
                UserName = row1["UserName"].ToString();
                OldPwd = row1["Password"].ToString();
                Memo = row1["Memo"].ToString();
                txtUser.Text = UserId;
                txtName.Text = UserName;
                //txtMemo.Text= Memo;
                cbxMemo.Text = Memo;
                //TxtAuditGroupId.Text = row1["AuditGroupId"].ToString().Trim();
                //DeptName.Text = row1["DeptName"].ToString().Trim();

                this.RegionListBox.Items.Clear();
                DataTable RegionList = RegionHelper.GetUserRegionList(UserId);



                foreach (DataRow item in RegionHelper.GetUserRegionList(UserId).Rows)
                {
                    this.RegionListBox.Items.Add(item["RegionName"].ToString(), CheckState.Checked);
                }

                foreach (DataRow item in RegionHelper.GetUserNotRegionList(UserId).Rows)
                {
                    this.RegionListBox.Items.Add(item["RegionName"].ToString(), CheckState.Unchecked);
                }

               
                //状态控制
                bool_Users_State();
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //this.TSMDelete.Enabled = true;
            //Delete_User();
        }

        /// <summary>
        /// 状态控制
        /// </summary>
        private void bool_Users_State()
        {
            State = bl.Select_SQL_Users_State(UserId, OldPwd);
            if (State == "正常")
            {
                TSMState.Enabled = true;
                TSMState1.Enabled = false;
            }
            else
            {
                TSMState.Enabled = false;
                TSMState1.Enabled = true;
            }
        }

        private void Update_Users_State()
        {
            if (IsState_false == true)
            {
                //封存用户
                bl.Update_SQL_Users_State_false(UserId, OldPwd);
            }
            else if (IsState_true == true)
            {
                //解存用户
                bl.Update_SQL_Users_State_true(UserId, OldPwd);
            }
            DataBind();
        }



        #region IU8Contral 成员

        public void Authorization()
        {
            this.TSMNew.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0001");
            this.TSMUpdate.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0002");
            this.TSMDelete.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0003");
            this.TSMSave.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0004");
            this.TSMState.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0005");
            this.TSMState1.Enabled = Bao.DataAccess.DataAcc.GetHoldAuth("SYS0006");
            
            //新增
            //toolBarBill1.BtnNew.Visible = Bao.DataAccess.DataAcc.GetHoldAuth("92");
        }

        #endregion

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void baoButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            txtUser.Text =e.ReturnRow1["EmpId"].ToString().Trim();
            txtName.Text =e.ReturnRow1["EmpName"].ToString().Trim();
        }

        private void baoButton2_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
         //   TxtAuditGroupId.Text = e.ReturnRow1["cDepCode"].ToString().Trim();
            //DeptName.Text = e.ReturnRow1["cDepName"].ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RegionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void RegionListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (((CheckedListBox)sender).SelectedItem == null)
            {
                return;
            }
            string regionid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RegionId from Region  where RegionName = '"+((CheckedListBox)sender).SelectedItem.ToString()+"'");
            if (e.NewValue == CheckState.Checked)
            {
                RegionHelper.SetRegionForUser(regionid, UserId);
            }
            else
            {
                RegionHelper.DelRegionForUser(regionid, UserId);
            }
        }


    }
}
