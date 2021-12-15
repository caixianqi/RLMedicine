using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Inssupport
{
    public partial class InsSupport : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
            
        private string U8DataBaseName = "UFDATA_999_2010";
        private string RiLiDataBaseName = "RiLi";
        public string UserRole;//存储用户的角色客服经理、工程师
        public string autoUserID="candy";
        private bool addsave = false;
        private DataTable DTinssupport;
        public InsSupport()
        {
            InitializeComponent();
            //2016-06-29 tdh
            //U8Global.U8DataAcc.GetConn();
            //U8Global.U8DataAcc.GetConn(U8Global.U8DataAcc.U8DataBase);

            //（Lin 2020-07-01 修改）
            U8Global.U8DataAcc.GetConn(RiLiGlobal.RiLiDataAcc.AccountNum);


            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            // U8Global.IniProcess u8obj=new U8Global.IniProcess(U8Global.IniProcess.AppPath);

            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            //ButtonInitState(UserRole);
            TaskInite("");
        }
        public InsSupport(string id)
        {
            InitializeComponent();
            //2016-06-29 tdh
            //U8Global.U8DataAcc.GetConn();
            //U8Global.U8DataAcc.GetConn(U8Global.U8DataAcc.U8DataBase);


            //（Lin 2020-07-01 修改）
            U8Global.U8DataAcc.GetConn(RiLiGlobal.RiLiDataAcc.AccountNum);


            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            //U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            TaskInite(id);
        }
        private void TaskInite(string taskid)
        {
            ButtonInitState(UserRole);
            DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from SellSupport where sSupCode='" + taskid + "'");
            UnDataBinding();
            DataBinding();

            BtnAddNew.Enabled = false;
            BtnAudit.Enabled = false;
            BtnCancel.Enabled = false;
            Btndel.Enabled = false;
            BtnLocation.Enabled = false;
            BtnSave.Enabled = false;
            BtnUnAudit.Enabled = false;
            BtnModify.Enabled = false;
            button1.Enabled = false;
          
            if (UserRole.Contains("002"))
            {   //客服经理
                BtnRefresh.Enabled = true;
                BtnLocation.Enabled = true;
                if (DTinssupport.Rows.Count >0 && DTinssupport.Rows[0]["sMessageId"].ToString() == "" && DTinssupport.Rows[0]["sMessagedate"].ToString() != "")//消息收回
                {   //未提交
                    BtnAudit.Enabled = false;
                    BtnUnAudit.Enabled = false;
                    //MessageBox.Show("此单据在修改中！还不能审核");
                }
                else if (DTinssupport.Rows.Count > 0 && DTinssupport.Rows[0]["sAuditPerson"].ToString() == "" && DTinssupport.Rows[0]["sMessageId"].ToString() != "")
                {   //未审核
                    BtnAudit.Enabled = true;
                    BtnUnAudit.Enabled = false;
                }
                else if (DTinssupport.Rows.Count > 0 && DTinssupport.Rows[0]["sAuditPerson"].ToString() != "")
                {   //已审核
                    BtnAudit.Enabled = false;
                    BtnUnAudit.Enabled = true;
                }
            }
            if (UserRole.Contains("003"))
            {   //工程师
                BtnAddNew.Enabled = true;
                BtnRefresh.Enabled = true;
                BtnLocation.Enabled = true;
                if (DTinssupport.Rows.Count > 0 && DTinssupport.Rows[0]["sMessageId"].ToString() == "")
                {
                    Btndel.Enabled = true;
                    BtnModify.Enabled = true;
                    button1.Text = "提交";
                    button1.Enabled = true;
                }
                else if (DTinssupport.Rows.Count > 0 && DTinssupport.Rows[0]["sMessageId"].ToString() != "" && DTinssupport.Rows[0]["sAuditPerson"].ToString() == "")//消息收回
                {   //未审核
                    button1.Text = "收回";
                    button1.Enabled = true;
                }
                //toolStripButton2.Enabled = false;//保存
                //toolStripButton3.Enabled = false;//取消
                // toolStripButton4.Enabled = false;//audit
            }
        }

        public void ButtonInitState(string UserRole)
        {   //hhq
            tbsRegName.Enabled = false;
            tbsReqDep.Enabled = false;
            dtsStartTime.Enabled = false;
            dtsEndTime.Enabled = false;
            tbsRegName.Enabled = false;
            tbsContent.Enabled = false;
            tbsRecManger.Enabled = false;
            tbsRecMangerName.Enabled = false;
            button1.Enabled = false;
            dtsInputdate.Enabled = false;
            tbsReqName2.Enabled = false;

            #region
            /**
            if (UserRole.Contains("002"))
            {
                BtnAddNew.Enabled = false;
                Btndel.Enabled = false;
                BtnModify.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnAudit.Enabled = false;
                BtnUnAudit.Enabled = false;
            }
            if (UserRole.Contains("003"))
            {
                BtnAddNew.Enabled = true;
                Btndel.Enabled = false;
                BtnModify.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnAudit.Enabled = false;
                BtnUnAudit.Enabled = false;
            }
            
            if(UserRole=="")
            {
                BtnAddNew.Enabled = false;
                Btndel.Enabled = false;
                BtnModify.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnAudit.Enabled = false;
                BtnUnAudit.Enabled = false;
                BtnLocation.Enabled = false;
            }
            DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from SellSupport where 1=0");
            DTinssupport.Clear();
            UnDataBinding();
            DataBinding();
            **/
            #endregion
        }
        public void GetUserRole(string UserID)//获取角色
        {
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
        }
        public void DataBinding()
        {
            this.tbsSupCode.DataBindings.Add("Text", DTinssupport, "sSupCode");
            this.tbsSupperson.DataBindings.Add("Text", DTinssupport, "sSupPerson");
            this.tbsSuppersonName.DataBindings.Add("Text", DTinssupport, "sSupPersonName");
            this.tbsRegName.DataBindings.Add("Text", DTinssupport, "sRegName");
            this.tbsRecManger.DataBindings.Add("Text", DTinssupport, "sRecManger");
            this.tbsReqDep.DataBindings.Add("Text", DTinssupport, "sReqDep");
            this.tbsReqName2.DataBindings.Add("Text", DTinssupport, "sReqName");
            this.tbsReqName.DataBindings.Add("Text", DTinssupport, "sReqName");
            this.tbsRecMangerName.DataBindings.Add("Text", DTinssupport, "sRecMangerName");
            this.dtsStartTime.DataBindings.Add("Text", DTinssupport, "sStartTime");
            this.dtsEndTime.DataBindings.Add("Text", DTinssupport, "sEndTime");
            this.dtsInputdate.DataBindings.Add("Text", DTinssupport, "sInputdate");
            this.tbsContent.DataBindings.Add("Text", DTinssupport, "sContent");
            this.sRegnCode.DataBindings.Add("Text", DTinssupport, "sRegnCode");

        }
        public void UnDataBinding()
        {
            this.tbsSupCode.DataBindings.Clear();
            this.tbsSupperson.DataBindings.Clear();
            this.tbsSuppersonName.DataBindings.Clear();
            this.tbsRegName.DataBindings.Clear();
            this.tbsRecManger.DataBindings.Clear();
            this.tbsReqDep.DataBindings.Clear();
            this.tbsReqName2.DataBindings.Clear();
            this.tbsReqName.DataBindings.Clear();
            this.tbsRecMangerName.DataBindings.Clear();
            this.dtsStartTime.DataBindings.Clear();
            this.dtsEndTime.DataBindings.Clear();
            this.dtsInputdate.DataBindings.Clear();
            this.tbsContent.DataBindings.Clear();
            this.sRegnCode.DataBindings.Clear();
        }
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            DTinssupport.Clear();
            //tbsID.Text = RiLiGlobal.GetCode.GetSupCode();
            tbsSupCode.Text = "";
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            Btndel.Enabled = false;
            BtnModify.Enabled = false;
            BtnAddNew.Enabled = false;
            button1.Enabled = false;

            tbsRegName.Enabled = true;
            tbsReqDep.Enabled = true;
            dtsStartTime.Enabled = true;
            dtsEndTime.Enabled = true;
            tbsRegName.Enabled = true;
            tbsContent.Enabled = true;
            tbsRecManger.Enabled = true;
            tbsRecMangerName.Enabled = true;
            dtsInputdate.Enabled = true;
            tbsReqName2.Enabled = true;

            addsave = true;
            tbsSupperson.Text = autoUserID;
            tbsSuppersonName.Text = UFBaseLib.BusLib.BaseInfo.UserName;
        }

        private void InsSupport_Load(object sender, EventArgs e)
        {
            tbsRegName.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass";
            tbsRegName.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.tbsRegName.FrmHigth = 600;
            this.tbsRegName.FrmWidth = 400;
            tbsRegName.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass where CDCNAME=";
            tbsRegName.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            tbsRegName.BaoClickClose = true;

            baoButton3.BaoSQL = "select sSupCode,sSupperson,sStartTime,sEndTime,sReqDep,sReqName,sAuditPerson,sAuditDate from " + RiLiDataBaseName + "..SellSupport";
            baoButton3.BaoTitleNames = "sSupperson=工程师,sStartTime=开始日期,sEndTime=结束日期,sReqDep=申请部门,sReqName=申请人 ,sAuditPerson=审核人,sAuditDate=审核日期";
            baoButton3.FrmHigth = 400;
            baoButton3.FrmWidth = 600;
            baoButton3.BaoColumnsWidth = "sSupperson=80,sStartTime=80,sEndTime=80,sReqDep=80,sReqName=80 ,sAuditPerson=80,sAuditDate=80";

            tbsReqDep.BaoSQL = "select cDepCode,cDepName from " + U8DataBaseName + ".Department ";
            tbsReqDep.BaoTitleNames = "cDepCode=部门编码,cDepName=部门名称";
            tbsReqDep.FrmHigth = 600;
            tbsReqDep.FrmWidth = 400;

            tbsReqName2.BaoSQL = "select cpersoncode,cpersonname,cDutyName,cDeptName from " + U8DataBaseName + ".hr_hi_jobInfo," + U8DataBaseName + ".person where cpsn_num=cpersoncode ";
            tbsReqName2.BaoTitleNames = "cpersoncode=人员编码,cpersonname=人员姓名";
            tbsReqName2.FrmHigth = 600;
            tbsReqName2.FrmWidth = 500;
            tbsReqName2.BaoColumnsWidth = "cpersoncode=100,cpersonname=100";


            tbsRecManger.BaoSQL = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002'";
            tbsRecManger.BaoTitleNames = "userid=人员编码,username=人员姓名";
            tbsRecManger.FrmHigth = 300;
            tbsRecManger.FrmWidth = 300;
            tbsRecManger.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002' and  userid =";
            tbsRecManger.BaoColumnsWidth = "userid=100,username=100";


            baoButton3.BaoSQL = "select sSupCode,sSupperson,sStartTime,sEndTime,sReqDep,sReqName,sAuditPerson,sAuditDate from " + RiLiDataBaseName + "..SellSupport where sSupperson='" + autoUserID + "'";
            baoButton3.BaoTitleNames = "sSupCode=任务号,sSupperson=工程师,sStartTime=开始日期,sEndTime=结束日期,sReqDep=申请部门,sReqName=申请人 ,sAuditPerson=审核人,sAuditDate=审核日期";
            baoButton3.FrmHigth = 400;
            baoButton3.FrmWidth = 680;
            baoButton3.BaoColumnsWidth = "sSupCode=80,sSupperson=80,sStartTime=80,sEndTime=80,sReqDep=80,sReqName=80 ,sAuditPerson=80,sAuditDate=80";
        }

        private void BtnLocation_Click(object sender, EventArgs e)
        {
            this.baoButton3.button1_Click(sender, e);
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            addsave = false;
            button1.Enabled = false;
            BtnAddNew.Enabled = false;
            BtnLocation.Enabled = false;
            Btndel.Enabled = false;
            BtnModify.Enabled = false;
            BtnRefresh.Enabled = false;

            tbsRegName.Enabled = true;
            tbsReqDep.Enabled = true;
            dtsStartTime.Enabled = true;
            dtsEndTime.Enabled = true;
            tbsRegName.Enabled = true;
            tbsContent.Enabled = true;
            tbsRecManger.Enabled = true;
            tbsRecMangerName.Enabled = true;
            dtsInputdate.Enabled = true;
            tbsReqName2.Enabled = true;
        }


        private void baoButton3_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            string getcode = dr["sSupCode"].ToString();
            TaskInite(getcode);

        }


        private void Btndel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除当前单据吗？", "删除信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            string sql = "";
            if (result == DialogResult.OK)
            {
                sql = "delete SellSupport where sId='" + DTinssupport.Rows[0]["sId"].ToString() + "'";
                try
                {
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    DTinssupport.Clear();
                    //ButtonInitState(UserRole);
                    TaskInite("");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                if (addsave)
                {
                    tbsSupCode.Text = RiLiGlobal.GetCode.GetSupCode();
                    sql += @"insert into SellSupport(sID,sSupCode,sSupperson,sSuppersonName,
                            sStartTime,sEndTime,sRegName,
                            sContent,sReqDep,sReqName,sRecManger,sRecMangerName,sInputdate,sRegnCode) values(NEWID(),'"
                            + tbsSupCode.Text + "','" + tbsSupperson.Text + "','" + tbsSuppersonName.Text + "'"
                            + ",'"+dtsStartTime.Value+"','" + dtsEndTime.Value + "','" + tbsRegName.Text+ "','" 
                            + tbsContent.Text + "','" + tbsReqDep.Text + "','" +tbsReqName2.Text + "','"+tbsRecManger.Text+"','"
                            + tbsRecMangerName.Text + "','" + dtsInputdate.Value + "','" + sRegnCode.Text + "')";
                    RiLiGlobal.GetCode.SetSupCode();
                }
                else
                {
                    sql += " update SellSupport set sStartTime='" + dtsStartTime.Value + "',sEndTime='" + dtsEndTime.Value + "'"
                    + ",sContent='" + tbsContent.Text + "',sReqDep='" + tbsReqDep.Text + "',sReqName='" + tbsReqName.Text
                    + "',sRegName='" + tbsRegName.Text + "',sRegnCode='" + sRegnCode.Text + "',sRecManger='" + tbsRecManger.Text + "',sRecMangerName='"
                    +tbsRecMangerName.Text+"' where sSupCode='" + tbsSupCode.Text + "'";
                }

                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                TaskInite(tbsSupCode.Text);//刷新
                MessageBox.Show("保存成功");
            }
            catch (Exception er)
            {
                if (addsave)
                {
                    tbsSupCode.Text = "";
                }
                MessageBox.Show(er.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要取消当前的修改吗？", "取消信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //string sql = "";
            if (result == DialogResult.OK)
            {
                if (tbsSupCode.Text == "")
                {
                    DTinssupport.Clear();
                    TaskInite(tbsSupCode.Text);//刷新
                    //TaskInite(DTinssupport.Rows[0]["sSupCode"].ToString());
                }
                else
                {
                    TaskInite(tbsSupCode.Text);//刷新
                }
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DateTime dt =  RiLiGlobal.RiLiDataAcc.GetNow().Date;
            string auditsql = " update SellSupport set sAuditDate='" + dt + "',sAuditPerson='" + autoUserID + "' where sID='" + DTinssupport.Rows[0]["sId"].ToString() + "'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
            TaskInite(DTinssupport.Rows[0]["sSupCode"].ToString());
            MessageBox.Show("审核成功");

        }

        private void BtnUnAudit_Click(object sender, EventArgs e)
        {
            string auditsql = "update SellSupport set sAuditDate=null,sAuditPerson='' where sID='" + DTinssupport.Rows[0]["sId"].ToString() + "'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
            TaskInite(DTinssupport.Rows[0]["sSupCode"].ToString());
            MessageBox.Show("弃审成功");
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

        //private void BtnExcel_Click(object sender, EventArgs e)
        //{
        //    this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
        //    try
        //    {

        //        if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
        //        {
        //            this.gridControl1.ExportToXls(saveFileDialog1.FileName);
        //        }
        //        MessageBox.Show("导出成功");
        //    }
        //    catch (Exception er)
        //    {
        //        MessageBox.Show(er.Message);
        //    }

        //}

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void Manager_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            tbsRecManger.Text = dr["userid"].ToString();
            tbsRecMangerName.Text = dr["username"].ToString();

        }

        private void buttonEdit2_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
           this.tbsReqDep.Text=dr["cDepName"].ToString();

        }

        private void buttonEdit3_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            this.tbsReqName2.Text=dr["cpersonname"].ToString();

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "提交")
            {
                try
                {
                    string sql = "update SellSupport set sMessagedate='" +  RiLiGlobal.RiLiDataAcc.GetNow() + "',sMessageId='" + autoUserID+ "' where sSupCode='" + tbsSupCode.Text + "'";                    
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    Bao.Message.CMessage.SendMessage("新的销售支持任务", "新的销售支持任务，请您审核！", tbsRecManger.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Sell001", tbsSupCode.Text);
                    //button1.Text = "收回";
                    TaskInite(tbsSupCode.Text);
                    MessageBox.Show("成功提交客服经理审核");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else
            {
                DTinssupport = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from SellSupport where sSupCode='" + tbsSupCode.Text + "'");
                if (DTinssupport.Rows.Count > 0 && DTinssupport.Rows[0]["sAuditPerson"].ToString() == "")
                {
                    try
                    {
                        string sql = "update SellSupport set sMessageId='' where sSupCode='" + tbsSupCode.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        Bao.Message.CMessage.SendMessage("销售支持任务消息收回！", "此销售支持任务已经收回，请您注意！", tbsRecManger.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Sell001", tbsSupCode.Text);
                        TaskInite(tbsSupCode.Text);
                        MessageBox.Show("成功收回！");
                        //button1.Text = "提交";
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }

                }
                else
                {
                    MessageBox.Show("客服经理审核不可以收回");

                }
            }

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TaskInite(tbsSupCode.Text);//刷新   
        }

        private void tbsRegName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.tbsRegName.BaoBtnCaption = e.ReturnRow1["CDCNAME"].ToString();
            this.sRegnCode.Text = e.ReturnRow1["cDCCODE"].ToString();
        }

        private ToolTip tt;
        private void InsSupport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tt != null)
                { tt.Dispose(); }
                tt = new ToolTip();
                tt.ShowAlways = true;

                tt.Show(tbsContent.Text, tbsContent);


            }
        }
    }
}
