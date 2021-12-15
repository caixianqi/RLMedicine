﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Repair
{
    public partial class RepairMessionLoadFile : Form
    {
        string path;
        string name;
        string fjtype;
        string RiLiDataBaseName;
        DataTable acctable;
        public RepairMessionLoadFile()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
           
            ButtonInitState();

        }
        public RepairMessionLoadFile(string taskid)
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            textBox1.Text = taskid;
            TaskInite(taskid);// 初始化
            ButtonInitState();//按按初始化
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="taskid"></param>
        private void TaskInite(string taskid)
        {
            string sql = @"select r.RepairMissionCode,r.AccType,r.UserId,r.AccName,r.ID,u.username from RepairMissionFile r left join users u on r.userid=u.userid where RepairMissionCode='" + taskid + "'";
            acctable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            UnDataBinding();
            DataBinding();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void DataBinding()
        {
            this.gridControl1.DataSource = acctable;

        }
        public void UnDataBinding()
        {
            this.gridControl1.DataSource = null;
        }
        public void ButtonInitState()
        {
            BtnAddNew.Enabled = true;

            BtnDelete.Enabled = false;
            BtnLocation.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;

        }
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请选择维修任务单据！");
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
            {
                BtnAddNew.Enabled = false;
                BtnDelete.Enabled = false;
                BtnLocation.Enabled = false;
                BtnCancel.Enabled = true;
                BtnSave.Enabled = true;
                path = openFileDialog1.FileName;
                name = path.Substring(path.LastIndexOf("\\") + 1);
                this.textBox2.Text = "";
                this.textBox3.Text = openFileDialog1.FileName;
                this.textBox4.Text = name;
                fjtype = path.Substring(path.LastIndexOf(".") + 1);
            }
            else
            {
                MessageBox.Show("请选择要上传的文件");
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql;
            try
            {
                if (path == "")
                {
                    MessageBox.Show("文件路径不能为空！");
                    BtnAddNew.Enabled = true;

                    BtnDelete.Enabled = false;
                    BtnLocation.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                }

                if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini"))
                    throw new Exception("没有数据库连接文件。");
                RiLiGlobal.IniProcess IniObj = new RiLiGlobal.IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini");

                // (Lin 2020-07-01 修改) 新增加解密
                RiLiGlobal.MD5 md5 = new RiLiGlobal.MD5();

                /*string server = md5.Md5Decrypt(IniObj.read("database", "server", ""));
                string DataBase = md5.Md5Decrypt(IniObj.read("database", "database", ""));
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
                long size = fs.Length / (1024 * 1024);
                if (size >= 2)
                {
                    MessageBox.Show("你所上传的文件大于2M！上传的文件限制为2M！", "温馨提示！");
                    return;
                }
                Byte[] fjbyte = new Byte[fs.Length];
                fs.Read(fjbyte, 0, fjbyte.Length);
                fs = null;
                sql = string.Format("insert into RepairMissionFile (RepairMissionCode ,Accessories,AccType,UserId,AccName,ID) values ('{0}',@image,'{1}','{2}','{3}',{4})", textBox1.Text.Trim(), fjtype, UFBaseLib.BusLib.BaseInfo.DBUserID, name, "newid()");
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
                BtnDelete.Enabled = false;
                BtnLocation.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                MessageBox.Show("上传成功");
                TaskInite(textBox1.Text);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void BtnLocation_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("请选择附件！");
                return;
            }
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            int iTimeout = 0;
            
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

                        string sql = string.Format(@"select Accessories,AccType from RepairMissionFile where ID = '{0}'", row["ID"].ToString());
                        DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
                        
                        if (dt.Rows.Count <= 0)
                        {
                            MessageBox.Show("你所选择的文件已删除！", "温馨提示！");
                            return;
                        }

                        row = dt.Rows[0];
                        Byte[] fj = (Byte[])row["Accessories"];
                        fjtype = row["AccType"].ToString();
                        path = path + "." + fjtype;
                        FileStream fs;
                        FileInfo fi = new System.IO.FileInfo(path);
                        fs = fi.OpenWrite();
                        fs.Write(fj, 0, fj.Length);
                        fs.Close();
                        MessageBox.Show("文件下载成功");
                        path = "";
                        textBox3.Text = "";
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("请选择附件！", "删除信息");
                return;
            }

            DialogResult result = MessageBox.Show("确定要删除当前附件吗？", "删除信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            string sql = "";
            try
            {
                if (result == DialogResult.OK)
                {
                    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                    sql = "delete from RepairMissionFile where ID='" + row["ID"].ToString() + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    BtnLocation.Enabled = false;
                    BtnDelete.Enabled = false;
                    MessageBox.Show("附件删除成功");
                    TaskInite(textBox1.Text);
                    ButtonInitState();
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
                    ButtonInitState();
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
                ButtonInitState();
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

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                return;
            }

            ButtonInitState();

            BtnDelete.Enabled = true;
            BtnCancel.Enabled = true;
            BtnLocation.Enabled = true;
                
            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                //显示所单击项的数据
                textBox2.Text = row["username"].ToString();
                textBox3.Text = "";
                textBox4.Text = row["AccName"].ToString();

                path = "";
            };
        }
    }
   
        
}
