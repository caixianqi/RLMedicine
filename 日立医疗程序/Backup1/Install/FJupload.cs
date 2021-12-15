using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Install
{
    public partial class FJupload : Form
    {
        string path;
        string name;
        string fjtype;
        string RiLiDataBaseName;
        DataTable acctable;
        string UserRole;
        public FJupload()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            string sql = "select * from InstallTask where 1=0";
            acctable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            acctable.Clear();
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
            ButtonInitState(UserRole);

        }
        public FJupload(string taskid, string userid)
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            textBox1.Text = taskid;
            GetUserRole(userid);
            TaskInite(taskid);// 初始化
            ButtonInitState(UserRole);//按按初始化
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="taskid"></param>
        private void TaskInite(string taskid)
        {
            string sql = @"select [tID],[tInsCode],[tCuscode],[tCusName],[tComName],[tComPhone],[tAgeStore]
                                                                    ,[tAgePerson],[tRegName],[tRegCode],[tAddress],[tMaiCode],[tMonCode],[tRepMonth]
                                                                    ,[tSendTime],[tInsType],[tSummary],[tManger],[tInsManger],[tInsMangerName],[tTaskStart]
                                                                    ,[tTaskAsign],[tAuditTime],[tAuditPerson],[tCheckTime],[tCheckPerson],[tState]--,[tAccessories]
                                                                    ,[tAccType],[tAccName],[tStartPerson],[tMessageId],[tMessagedate],[tAuditMessageId],[tAuditMessagedate]
                                                                    ,[fMessageId],[fMessagedate],[InstallManagerCode],[InstallManagerName],[AsignInstallManagerDate]
                                                                    ,[City],[InstallUnit1],[InstallUnit2],[MachineLevel],[Color],[dtimefh],[dtimegc],[billDate]
                                                                    ,[xsalecode],[xoutcode],[xwhcode],[jqjbcode],[anzhcode1],[anzhcode2],[MachineType],[MachineModel]    
                                                                from InstallTask where tInsCode='" + taskid + "'";
                
                //"select * from InstallTask where tInsCode='" + textBox1.Text + "'";
            acctable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            UnDataBinding();
            DataBinding();

        }
        public void DataBinding()
        {
            this.textBox1.DataBindings.Add("Text", acctable, "tInsCode");
            this.textBox2.DataBindings.Add("Text", acctable, "tInsMangerName");
            this.gridControl1.DataSource = acctable;
            gdFuJianId.FieldName = "tInsCode";
            gridColumn1.FieldName = "tInsMangerName";
            gridColumn2.FieldName = "tAccName";

        }
        public void UnDataBinding()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            this.gridControl1.DataSource = null;
        }
        public void GetUserRole(string UserID)//获取角色
        {
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
        }
        public void ButtonInitState(string userrole)
        {
            BtnAddNew.Visible = false;
            //BtnModify.Visible = false;
            BtnDelete.Visible = false;
            BtnLocation.Visible = false;
            BtnSave.Visible = false;
            BtnCancel.Visible = false;
            if (userrole.Contains("003"))
            {   //工程师
                BtnAddNew.Enabled = true;
                //BtnModify.Enabled = true;
                BtnDelete.Enabled = true;
                BtnLocation.Enabled = true;
                BtnAddNew.Visible = true;
                //BtnModify.Visible = true;
                BtnDelete.Visible = true;
                BtnLocation.Visible = true;
                BtnSave.Visible = true;
                BtnCancel.Visible = true;
            }
            else //if (userrole.Contains("001"))
            {   //800
                BtnLocation.Enabled = true;
                BtnLocation.Visible = true;
            }
            string sql = "select tState,tAccType from InstallTask where tInsCode='" + textBox1.Text + "'";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            if (dt.Rows[0]["tState"].ToString() == "完成")
            {
                //BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnAddNew.Enabled = false;
            }
            else
            {
                //BtnModify.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddNew.Enabled = true;
            }
            if (dt.Rows.Count == 0 || dt.Rows[0]["tAccType"].ToString() == "")
            {
                BtnLocation.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
            {
                BtnAddNew.Enabled = false;
                //BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnLocation.Enabled = false;
                BtnCancel.Enabled = true;
                BtnSave.Enabled = true;
                path = openFileDialog1.FileName;
                name = path.Substring(path.LastIndexOf("\\") + 1);
                this.textBox3.Text = openFileDialog1.FileName;
                fjtype = path.Substring(path.LastIndexOf(".") + 1);
            }
            else
            {
                MessageBox.Show("请选择要上传的文件");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql;
            try
            {
                if (path != "")
                {
                    if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini"))
                        throw new Exception("没有数据库连接文件。");

                    RiLiGlobal.MD5 md5 = new RiLiGlobal.MD5();

                    RiLiGlobal.IniProcess IniObj = new RiLiGlobal.IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini");

                    /*string server = md5.Md5Decrypt(IniObj.read("database", "server", ""));
                    string DataBase =md5.Md5Decrypt(IniObj.read("database", "database", ""));
                    string user = md5.Md5Decrypt(IniObj.read("database", "user", ""));
                    string password = md5.Md5Decrypt(IniObj.read("database", "password", ""));*/

                    string AccountNum = RiLiGlobal.RiLiDataAcc.AccountNum;
                    DataTable dt = RiLiGlobal.RiLiDataAcc.Get_RL_DBInfo(AccountNum);

                    string server = "";
                    string DataBase = "";
                    string user = "";
                    string password = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //Server,DataBase,User,PassWord
                        server = dt.Rows[0]["Server"].ToString().Trim();
                        DataBase = dt.Rows[0]["DataBase"].ToString().Trim();
                        user = dt.Rows[0]["User"].ToString().Trim();
                        password = md5.Md5Decrypt(dt.Rows[0]["PassWord"].ToString().Trim());
                    }
                    else
                    {
                        server = md5.Md5Decrypt(IniObj.read("database", "server", ""));
                        DataBase = md5.Md5Decrypt(IniObj.read("database", "database", ""));
                        user = md5.Md5Decrypt(IniObj.read("database", "user", ""));
                        password = md5.Md5Decrypt(IniObj.read("database", "password", ""));
                    }


                    string strConn = "uid=" + user + ";initial catalog=" + DataBase + ";data source=" + server + ";password=" + password + ";Connect Timeout=10000";
    
                    //string strConn = "database=RiLi;server=abc;User ID=sa;Password=sa";
                    SqlConnection con = new SqlConnection(strConn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(strConn, con);
                    cmd.CommandType = CommandType.Text;
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    Byte[] fjbyte = new Byte[fs.Length];
                    fs.Read(fjbyte, 0, fjbyte.Length);
                    fs = null;
                    sql = "update InstallTask set tAccessories=@image,tAccType='" + fjtype + "',tAccName='" + name + "' where tInsCode='" + textBox1.Text + "'";
                    cmd.Parameters.Add("@image", SqlDbType.Image).Value = fjbyte;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    //Byte[] fjbyte = new Byte[fs.Length];
                    //fs.Read(fjbyte, 0, fjbyte.Length);
                    //fs = null;
                    //sql = "update InstallTask set tAccessories=@file,tAccType='" + fjtype + "' where tInsCode='" + textBox1.Text + "";
                    ////sql="update InstallTask set tAccessories='"+fjbyte+"',tAccType='"+fjtype+"' where tInsCode='"+textBox1.Text+"'";
                    //RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    BtnAddNew.Enabled = true;//按钮初始始
                    //BtnModify.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnLocation.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    MessageBox.Show("上传成功");
                    TaskInite(textBox1.Text);
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void BtnLocation_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable fjtable;
            int iTimeout = 0;
            sql = "select tAccType from InstallTask where tInsCode='" + textBox1.Text + "'";
            fjtable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            if (fjtable.Rows.Count == 0 || fjtable.Rows[0]["tAccType"].ToString() == "")
            {
                MessageBox.Show("该单据不存在附件，不能下载！");
                BtnLocation.Enabled = false;
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                path = saveFileDialog1.FileName;
                this.textBox3.Text = path;
                if (File.Exists(path))
                {
                    MessageBox.Show("此文件已经存在，请选择其他名字");
                }
                else
                {
                    try
                    {
                        iTimeout = HJ.Data.SQLDBConnect.SQLDBconntion.CommandTimeOut;
                        HJ.Data.SQLDBConnect.SQLDBconntion.CommandTimeOut = 0;
                        sql = "select tAccessories,tAccType from InstallTask where tInsCode='" + textBox1.Text + "'";
                        fjtable = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(sql).Tables[0];
                       // Byte[] fj = (Byte[])obj;
                        //fjtable =RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
                        Byte[] fj = (Byte[])fjtable.Rows[0]["tAccessories"];
                        fjtype = fjtable.Rows[0]["tAccType"].ToString();
                        path = path + "." + fjtype;
                        FileStream fs;
                        FileInfo fi = new System.IO.FileInfo(path);
                        fs = fi.OpenWrite();
                        fs.Write(fj, 0, fj.Length);
                        fs.Close();
                        MessageBox.Show("文件下载成功");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("下载失败：" + ex.Message, "提示");
                    }
                    finally
                    {
                        HJ.Data.SQLDBConnect.SQLDBconntion.CommandTimeOut = iTimeout;
                    }
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
            {
                BtnAddNew.Enabled = false;
                //BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnLocation.Enabled = false;
                BtnCancel.Enabled = true;
                BtnSave.Enabled = true;
                path = openFileDialog1.FileName;
                name = path.Substring(path.LastIndexOf("\\") + 1);
                this.textBox3.Text = openFileDialog1.FileName;
                fjtype = path.Substring(path.LastIndexOf(".") + 1);
            }
            else
            {
                this.textBox3.Text = "";
                MessageBox.Show("请选择要上传的文件");
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (acctable.Rows[0]["tState"].ToString() == "完成")
            {
                MessageBox.Show("已完成，不能删除");
                return;
            }

            if (acctable.Rows[0]["tState"].ToString() == "已核对")
            {
                MessageBox.Show("已核对，不能删除");
                return;
            }

            if (acctable.Rows[0]["tState"].ToString() == "已审核")
            {
                MessageBox.Show("已审核，不能删除");
                return;
            }

            DialogResult result = MessageBox.Show("确定要删除当前附件吗？", "删除信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            string sql = "";
            try
            {
                if (result == DialogResult.OK)
                {
                    sql = "update InstallTask set tAccessories=null,tAccType='',tAccName='' where tInsCode='" + textBox1.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    textBox3.Text = "";
                    BtnLocation.Enabled = false;
                    BtnDelete.Enabled = false;
                    MessageBox.Show("附件删除成功");
                    TaskInite(textBox1.Text);
                    ButtonInitState(UserRole);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DialogResult result = MessageBox.Show("确定要取消当前的修改吗？", "取消信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    TaskInite(textBox1.Text);
                    ButtonInitState(UserRole);
                    //BtnAddNew.Enabled = true;//按钮初始始
                    //BtnModify.Enabled = true;
                    //BtnDelete.Enabled = true;
                    //BtnLocation.Enabled = true;
                    //BtnSave.Enabled = false;
                    //BtnCancel.Enabled = false;
                }
            }
            else
            {
                TaskInite(textBox1.Text);
                ButtonInitState(UserRole);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if ((this.BtnSave.Enabled == false) || (this.BtnSave.Enabled == true &&
                 MessageBox.Show("是否放弃保存当前数据？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                this.Close();
            } 

        }
    }
   
        
}
