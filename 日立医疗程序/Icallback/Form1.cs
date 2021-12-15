using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Icallback
{
    public partial class Form1 : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string U8DataBaseName = "UFDATA_999_2010";
        private string RiLiDataBaseName = "RiLi";
        public string UserRole;//存储用户的角色客服经理、工程师
        public string autoUserID = "candy";
        private bool addsave = false;
        private DataTable DTCallBack;
        public Form1()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
           // U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            //ButtonInitState(UserRole);
            TaskInite("");//2011-12-07
        }
        public Form1(string taskid)
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
           // U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            TaskInite(taskid);
        }
        /// <summary>
        /// 单据加载
        /// </summary>
        /// <param name="taskid"></param>
        private void TaskInite(string taskid)
        { // 状态cState：新任务、已派遣、待审核、已审核
            ButtonInitState(UserRole);//输入控制
            
            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from CallBack where cTaskCode='" + taskid + "'");
            UnDataBinding();//解除绑定
            DataBinding();//绑定数据

            if (DTCallBack.Rows.Count == 0)
            {
                BtnAddNew.Enabled = true;//新增
            }
            else
                BtnAddNew.Enabled = false;//新增

            BtnAudit.Enabled = false;//审核
            BtnAuditList.Enabled = false;//审核列表
            BtnCancel.Enabled = false;
            BtnDelete.Enabled = false;
            BtnModify.Enabled = false;
            BtnRefresh.Enabled = false;//刷新
            BtnSave.Enabled = false;
            BtnUnAudit.Enabled = false;//弃审
            button1.Enabled = false;
            button2.Enabled = false;

            if (UserRole.Contains("003"))
            { //工程师 cCallManger 
                if (DTCallBack.Rows.Count == 0)
                {
                    return;
                }
                BtnLocation.Enabled = true;
                BtnRefresh.Enabled = true;

            
                if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣"
                     && DTCallBack.Rows[0]["cCallManger"].ToString() == this.autoUserID)//回访人姓名
                {
                    BtnModify.Enabled = true;
                    button2.Enabled = true;
                    button2.Text = "提交";
                    button1.Text = "收回";
                }
                //else if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣"
                //&& tbCallName.Text == "" && DTCallBack.Rows[0]["cCallManger"].ToString() == this.autoUserID)//回访人姓名
                //{
                //    BtnModify.Enabled = true;
                //    button2.Enabled = false;
                //    button2.Text = "提交";
                //}
                else if (DTCallBack.Rows[0]["cState"].ToString() == "待审核" && DTCallBack.Rows[0]["cCallManger"].ToString() == this.autoUserID)//回访人姓名
                {
                    BtnModify.Enabled = false;
                    button2.Enabled = true;
                    button2.Text = "收回";
                }
                else if (DTCallBack.Rows[0]["cState"].ToString() == "新任务")
                {
                    button1.Text = "提交";
                    button2.Text = "提交";
                }
                else
                {
                    button1.Text = "收回";
                    button2.Text = "收回";
                }
            }


            if (UserRole.Contains("002"))
            {   // 客服经理 : 新增、审核
                BtnAddNew.Enabled = true;
                BtnAudit.Enabled = false;
                BtnLocation.Enabled = true;
                BtnRefresh.Enabled = true;

                if (DTCallBack.Rows.Count == 0)
                {
                    return;
                }
                //if (DTCallBack.Rows.Count == 0 ||
                //    (DTCallBack.Rows[0]["cAuditDate"].ToString() != "" && DTCallBack.Rows[0]["cAuditPerson"].ToString() != ""))
                //{   //没有相关单据信息，只能新增  已审核 cAuditDate cAuditPerson
                //}
                //else if (DTCallBack.Rows[0]["cAuditMessagedate"].ToString() != "" && DTCallBack.Rows[0]["cAuditMessageId"].ToString() != "")
                //if (DTCallBack.Rows[0]["cAuditMessageId"].ToString() == "")

                if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣" &&
                    DTCallBack.Rows[0]["cStartperson"].ToString() == this.autoUserID)
                {   //已派遣 cAuditMessagedate cAuditMessageId  cStartperson 
                    BtnLocation.Enabled = true;
                    BtnRefresh.Enabled = true;
                    button1.Enabled = true;
                    button1.Text = "收回";
                }
                else if (DTCallBack.Rows[0]["cState"].ToString() == "新任务" &&
                    DTCallBack.Rows[0]["cStartperson"].ToString() == this.autoUserID)
                {   //未提交
                    button1.Text = "提交";
                    BtnRefresh.Enabled = true;
                    BtnModify.Enabled = true;
                    BtnDelete.Enabled = true;
                    button1.Enabled = true;
                }
                else if (DTCallBack.Rows[0]["cAuditDate"].ToString() != "" && DTCallBack.Rows[0]["cAuditPerson"].ToString() != "" &&
                    DTCallBack.Rows[0]["cStartperson"].ToString() == this.autoUserID)
                {   //已审核 cAuditDate cAuditPerson 
                    BtnUnAudit.Enabled = true;//弃审
                    BtnRefresh.Enabled = true;
                }
                else if (DTCallBack.Rows[0]["cAuditMessagedate"].ToString() != "" && DTCallBack.Rows[0]["cAuditMessageId"].ToString() != "" &&
                    DTCallBack.Rows[0]["cStartperson"].ToString() == this.autoUserID)
                {   //已派遣hhq cAuditMessagedate cAuditMessageId 
                    BtnAudit.Enabled = true;
                    BtnRefresh.Enabled = true;
                }
            }

        }

        public void ButtonInitState(string UserRole)
        {   //
            #region
            
            //if (UserRole.Contains("003"))
            //{   //工程师
            //    BtnAddNew.Enabled = false;
            //    BtnDelete.Enabled = false;
            //    BtnModify.Enabled = false;
            //    BtnSave.Enabled = false;
            //    BtnCancel.Enabled = false;
            //    BtnAudit.Enabled = false;
            //    BtnUnAudit.Enabled = false;
            //    BtnAuditList.Enabled = false;
            //    BtnDelete.Enabled = false;
            //}
            //if (UserRole.Contains("002"))
            //{   //客服经理
            //    BtnAddNew.Enabled = true;
            //    BtnDelete.Enabled = false;
            //    BtnModify.Enabled = false;
            //    BtnSave.Enabled = false;
            //    BtnCancel.Enabled = false;
            //    BtnAudit.Enabled = false;
            //    BtnUnAudit.Enabled = false;
            //}
            #endregion

            if (UserRole=="")
            {
                BtnAddNew.Enabled = false;
                BtnDelete.Enabled = false;
                BtnModify.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnAudit.Enabled = false;
                BtnUnAudit.Enabled = false;
                BtnLocation.Enabled = false;
            }
            tbCallName.Enabled = false ;
            tbCallPhone.Enabled = false;
            tbCallDep.Enabled = false;
            tbRegion.Enabled = false;
            dtpCallDate.Enabled = false;
            rtbCallContent.Enabled = false;
            dtpCallinput.Enabled = false;

            beCustomer.Enabled = false;
            tbCustomerName.Enabled = false;
            beEngineer.Enabled = false;
            tbEngineerName.Enabled = false;
            tbTarget.Enabled = false;
            dtpPlan.Enabled = false;
            dtpInput.Enabled = false;
        }
        public void GetUserRole(string UserID)//获取角色
        {
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
        }
        public void DataBinding()
        {
            tbTaskCode.DataBindings.Add("Text", DTCallBack,"cTaskCode");
            beCustomer.DataBindings.Add("Text", DTCallBack, "cCusCode");
            tbCustomerName.DataBindings.Add("Text", DTCallBack, "cClientName");
            beEngineer.DataBindings.Add("Text", DTCallBack, "cCallManger");
            tbEngineerName.DataBindings.Add("Text", DTCallBack, "cCallMangerName");
            tbTarget.DataBindings.Add("Text", DTCallBack, "cAim");
            dtpPlan.DataBindings.Add("Text", DTCallBack, "cPlaTime");
            dtpInput.DataBindings.Add("Text", DTCallBack, "cTaskStart");

            tbCallName.DataBindings.Add("Text", DTCallBack, "cCusName");
            tbCallPhone.DataBindings.Add("Text", DTCallBack, "cCusPhone");
            tbCallDep.DataBindings.Add("Text", DTCallBack, "cCusDep");
            tbRegion.DataBindings.Add("Text", DTCallBack, "cRegion");
            dtpCallDate.DataBindings.Add("Text", DTCallBack, "cTaskEnd");
            rtbCallContent.DataBindings.Add("Text", DTCallBack, "cCusSummary");
            dtpCallinput.DataBindings.Add("Text", DTCallBack, "cSubTime");
 
        }
        public void UnDataBinding()
        {
            tbTaskCode.DataBindings.Clear();
            beCustomer.DataBindings.Clear();
            tbCustomerName.DataBindings.Clear();
            beEngineer.DataBindings.Clear();
            tbEngineerName.DataBindings.Clear();
            tbTarget.DataBindings.Clear();
            dtpPlan.DataBindings.Clear();
            dtpInput.DataBindings.Clear();

            tbCallName.DataBindings.Clear();
            tbCallPhone.DataBindings.Clear();
            tbCallDep.DataBindings.Clear();
            tbRegion.DataBindings.Clear();
            dtpCallDate.DataBindings.Clear();
            rtbCallContent.DataBindings.Clear();
            dtpCallinput.DataBindings.Clear();
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            addsave = true;
            DTCallBack.Clear();
            TaskInite("");
            BtnAudit.Enabled = false;
            BtnUnAudit.Enabled = false;
            //tbTaskCode.Text = RiLiGlobal.GetCode.GetCallCode();//取任务编号
            tbTaskCode.Text = "保存后自动产生";
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            BtnAddNew.Enabled = false;
            BtnAuditList.Enabled = false;
            BtnLocation.Enabled = false;
            BtnRefresh.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            beCustomer.Enabled = true;
            tbCustomerName.Enabled = true;
            beEngineer.Enabled = true;
            tbEngineerName.Enabled = true;
            tbTarget.Enabled = true;
            dtpPlan.Enabled = true;
            dtpInput.Enabled = true;
            tbRegion.Enabled = true;

            tbCallName.Enabled = false;
            tbCallPhone.Enabled = false;
            tbCallDep.Enabled = false;
            dtpCallDate.Enabled = false;
            rtbCallContent.Enabled = false;
            dtpCallinput.Enabled = false;

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            addsave = false;
            BtnAddNew.Enabled = false;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            BtnAudit.Enabled = false;
            BtnUnAudit.Enabled = false;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnRefresh.Enabled = false;
            BtnLocation.Enabled = false;
            BtnAuditList.Enabled = false;

            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from CallBack where cTaskCode='" + tbTaskCode.Text + "'");

            if (UserRole.Contains("002"))
            {   // 客服经理 : 新增、审核

                if (DTCallBack.Rows.Count == 0)
                {
                    return;
                }
                if (DTCallBack.Rows[0]["cState"].ToString() == "新任务")
                {   //未提交
                    beCustomer.Enabled = true;
                    tbRegion.Enabled = true;
                    dtpPlan.Enabled = true;
                    beEngineer.Enabled = true;
                    tbTarget.Enabled = true;
                    //dtpInput.Enabled = true;//提交日期
                    return;
                }
            }

            if (UserRole.Contains("003"))
            { //工程师   cCallManger 
                if (DTCallBack.Rows.Count == 0)
                {
                    return;
                }
                if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣")
                {
                    tbCallName.Enabled = true;
                    tbCallPhone.Enabled = true;
                    tbCallDep.Enabled = true;
                    dtpCallDate.Enabled = true;
                    rtbCallContent.Enabled = true;
                    dtpCallinput.Enabled = true;
                    return; 
                }
            }
            MessageBox.Show("当前状态不是最新状态，不能修改！");
            TaskInite(tbTaskCode.Text);
            #region
            /**
            if (UserRole.Contains("003"))
            {
                tbCallName.Enabled=true;
                tbCallPhone.Enabled = true;
                tbCallDep.Enabled = true;
                tbRegion.Enabled = true;
                dtpCallDate.Enabled = true;
                rtbCallContent.Enabled = true;
                dtpCallinput.Enabled = true;
            }
            if (UserRole.Contains("002"))
            {
                beCustomer.Enabled=true;
                tbCustomerName.Enabled = true;
                beEngineer.Enabled = true;
                tbEngineerName.Enabled=true;
                tbTarget.Enabled=true;
                dtpPlan.Enabled=true;
                dtpInput.Enabled=true;
            }
            if (tbCallName.Text != "")
            {
                beCustomer.Enabled = false;
                tbCustomerName.Enabled = false;
                beEngineer.Enabled =false;
                tbEngineerName.Enabled = false;
                tbTarget.Enabled = false;
                dtpPlan.Enabled = false;
                dtpInput.Enabled = false;
            }
             **/
            #endregion
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除当前单据吗？", "删除信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            string sql = "";
            DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select cState from CallBack where cTaskCode='" + tbTaskCode.Text + "'");
            if (DTCallBack.Rows[0]["cState"].ToString() == "新任务")
            {   //未提交
                sql = "delete CallBack where cTaskCode='" + tbTaskCode.Text + "'";
                try
                {
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    DTCallBack.Clear();
                    TaskInite("");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("当前状态不是最新状态，不能删除！");
                TaskInite(tbTaskCode.Text);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要取消当前的修改吗？", "取消信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            if (addsave == true)
            {
                DTCallBack.Clear();
                TaskInite("");
            }
            else
            {
                TaskInite(tbTaskCode.Text);
            }
        }

        private void BtnAudit_Click(object sender, EventArgs e)
        {
            DateTime dt =  RiLiGlobal.RiLiDataAcc.GetNow().Date;
            string auditsql = "update CallBack set cAuditDate='" + dt + "',cAuditPerson='" + autoUserID + "',cState = '已审核' where cTaskCode='" + tbTaskCode.Text + "'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
            MessageBox.Show("审核成功");
            TaskInite(DTCallBack.Rows[0]["cTaskCode"].ToString());

        }

        private void BtnUnAudit_Click(object sender, EventArgs e)
        {
            string auditsql = "update CallBack set cAuditDate=null,cAuditPerson=null,cState = '待审核' where cTaskCode='" + tbTaskCode.Text + "'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
            MessageBox.Show("弃审成功");
            TaskInite(DTCallBack.Rows[0]["cTaskCode"].ToString());

        }

        private void BtnLocation_Click(object sender, EventArgs e)
        {
            this.baoButton3.button1_Click(sender, e);
        }

        private void BtnAuditList_Click(object sender, EventArgs e)
        {
            this.baoButton1.button1_Click(sender, e);
        }

        private void baoButton3_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            string getcode = dr["cTaskCode"].ToString();
            TaskInite(getcode);
        }

        private void baoButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            string getcode = dr["cTaskCode"].ToString();
            TaskInite(getcode);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select cState from CallBack where cTaskCode='" + tbTaskCode.Text + "'");
                if (UserRole.Contains("002") && addsave)
                {    // 客服经理
                    Check002();//保存判断 hhq
                    tbTaskCode.Text = RiLiGlobal.GetCode.GetCallCode();//取任务编号
                    sql = @"insert into CallBack(cID,cTaskCode,cCusCode,cClientName,cCallManger,
                                cCallMangerName,cPlaTime,cAim,cTaskStart,cStartperson,cState,cRegion,tbRegionCode) values(NEWID(),'"
                            + tbTaskCode.Text + "'" + ",'" + beCustomer.Text + "','" + tbCustomerName.Text + "','"
                            + beEngineer.Text + "','" + tbEngineerName.Text + "','" + dtpPlan.Value + "','"
                            + tbTarget.Text + "','" + dtpInput.Value + "','" + autoUserID + "','新任务','" + tbRegion.Text + "','"+this.tbRegionCode.Text+"')";
                }
                else if(DTCallBack.Rows.Count==0)
                {
                    return;
                }
                else if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣")
                {
                    sql += "update CallBack set cCusCode='" + beCustomer.Text + "',cClientName='" + tbCustomerName.Text +
                        "',cCallManger='" + beEngineer.Text + "',cCallMangerName='" + tbEngineerName.Text +
                        "',cPlaTime='" + dtpPlan.Value + "',cAim='" + tbTarget.Text + "',cTaskStart='" + dtpInput.Value +
                        "',cCusName='" + tbCallName.Text + "',cCusPhone='" + tbCallPhone.Text + "',cTaskEnd='" + dtpCallDate.Value +
                        "',cCusDep='" + tbCallDep.Text + "',cCusSummary='" + rtbCallContent.Text +
                        "',cSubTime='" + dtpCallinput.Value + "',tbRegionCode='" + tbRegionCode.Text + "' where cTaskCode='" + tbTaskCode.Text + "'";
                }
                else if (DTCallBack.Rows[0]["cState"].ToString() == "新任务")
                {
                      sql += "update CallBack set cCusCode='" + beCustomer.Text + "',cClientName='" + tbCustomerName.Text +
                        "',cCallManger='" + beEngineer.Text + "',cCallMangerName='" + tbEngineerName.Text +
                        "',cPlaTime='" + dtpPlan.Value + "',cAim='" + tbTarget.Text + "',cTaskStart='" + dtpInput.Value +"' where cTaskCode='" + tbTaskCode.Text + "'";
                }
                else
                {
                    MessageBox.Show("当前状态不是最新状态，保存失败！");
                    TaskInite(tbTaskCode.Text);//刷新
                    return;
                }

                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                if (addsave)
                {
                     RiLiGlobal.GetCode.SetCallCode();//增加系统的任务编号
                }
                TaskInite(tbTaskCode.Text);//刷新
                MessageBox.Show("保存成功");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }
        }
        /// <summary>
        /// 客服经理 保存判断
        /// </summary>
        public void Check002()
        {
            string mesg = string.Empty;

            if (string.IsNullOrEmpty(this.beCustomer.Text))
            {
                mesg += "[客户编码不能为空]\n";
            }
            if (string.IsNullOrEmpty(this.tbCustomerName.Text))
            {
                mesg += "[客户名称不能为空]\n";
            }
            if (string.IsNullOrEmpty(this.beEngineer.Text))
            {
                mesg += "[工程师编码不能为空]\n";
            }
            if (string.IsNullOrEmpty(this.tbRegion.Text))
            {
                mesg += "[地区不能为空]\n";
            }
            if (mesg == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception(mesg);
            }
        }
        /// <summary>
        /// 工程师 保存判断
        /// </summary>
        public void Check003()
        {
            string mesg = string.Empty;

            if (string.IsNullOrEmpty(this.tbCallName.Text))
            {
                mesg += "[回访人姓名不能为空]\n";
            }
            if (string.IsNullOrEmpty(this.rtbCallContent.Text))
            {
                mesg += "[客户反馈信息不能为空]\n";
            }

            if (mesg == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception(mesg);
            }
        }
        private void beEngineer_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            beEngineer.Text = dr["userid"].ToString();
            tbEngineerName.Text = dr["username"].ToString();
        }
        private void beCustomer_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            beCustomer.Text= dr["cCusCode"].ToString();
            tbCustomerName.Text = dr["cCusName"].ToString();

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

        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from CallBack where cTaskCode='" + tbTaskCode.Text + "'");
                if (DTCallBack.Rows.Count == 0 || BtnSave.Enabled ||
                    (DTCallBack.Rows[0]["cState"].ToString() != "新任务" && DTCallBack.Rows[0]["cState"].ToString() != "已派遣"))
                {
                    MessageBox.Show("当前状态不能提交！");
                    TaskInite(tbTaskCode.Text);//刷新
                    return;
                }
                if (button1.Text == "提交")
                {
                    string sql = "update CallBack set cState = '已派遣',cMessagedate=getDate(),cMessageId='" + autoUserID + "' where cTaskCode='" + tbTaskCode.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    Bao.Message.CMessage.SendMessage("新回访任务", "新的回访任务，请您负责实施！", beEngineer.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Call001", tbTaskCode.Text);
                    //button1.Text = "收回";
                    MessageBox.Show("成功提交工程师回访");
                    this.button1.Text = "收回";
                }
                else
                {
                    if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣")
                    {

                        string sql = "update CallBack set cMessageId='',cState = '新任务' where cTaskCode='" + tbTaskCode.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        Bao.Message.CMessage.SendMessage("回访消息收回！", "此回访任务已经收回，请您注意！", beEngineer.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Call001", tbTaskCode.Text);
                        MessageBox.Show("成功收回！");
                        button1.Text = "提交";
                    }
                    else
                    {
                        MessageBox.Show("不能收回，单据状态不是已派遣，可能原因是工程师已经提交审核");
                        return;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BtnSave.Enabled)
            {
                MessageBox.Show("请您先保存后再执行" + button2.Text+"操作！");
                return;
            }
             DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from CallBack where cTaskCode='" + tbTaskCode.Text + "'");

          
            if (button2.Text == "提交")
            {
                try
                {
                    if (DTCallBack.Rows[0]["cState"].ToString() == "已派遣")
                    {
                        string sql = "update CallBack set cAuditMessagedate='" +  RiLiGlobal.RiLiDataAcc.GetNow() + "',cAuditMessageId='" + autoUserID + "',cState = '待审核' where cTaskCode='" + tbTaskCode.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        Bao.Message.CMessage.SendMessage("回访任务完成", "回访人务完成，请您负责审核！", DTCallBack.Rows[0]["cStartperson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Call001", tbTaskCode.Text);
                        TaskInite(tbTaskCode.Text);//刷新
                        button2.Text = "收回";
                        MessageBox.Show("成功提交客服经理审核");
                    }
                    else
                    {
                        MessageBox.Show("单据不是已派遣状态，不能提交");
                        return;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else
            {
                DTCallBack = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from CallBack where cTaskCode='" + tbTaskCode.Text + "'");
                if (DTCallBack.Rows[0]["cState"].ToString() == "待审核")
                {
                    try
                    {
                        string sql = "update CallBack set cAuditMessageId=null,cCusName=null,cCusPhone=null,cTaskEnd=null,cCusDep=null,cCusSummary=null,cSubTime=null,cState = '已派遣' where cTaskCode='" + tbTaskCode.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        Bao.Message.CMessage.SendMessage("审核消息收回！", "此回访任务审核已经收回，请您注意！", DTCallBack.Rows[0]["cStartperson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Call001", tbTaskCode.Text);
                        TaskInite(tbTaskCode.Text);//刷新
                        button2.Text = "提交";
                        MessageBox.Show("成功收回！");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else
                {
                    MessageBox.Show("单据不是待审核状态，不能收回");
                }
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            tbRegion.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass";
            tbRegion.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.tbRegion.FrmHigth = 600;
            this.tbRegion.FrmWidth = 400;
            tbRegion.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass where CDCNAME=";
            tbRegion.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            tbRegion.BaoClickClose = true;
            //tbRegion.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(ZoneName_OnLookUpClosed);

            baoButton3.BaoSQL = "select cTaskCode,cClientName,cCallMangerName,cPlaTime,cAim,cTaskEnd,cAuditPerson from " + RiLiDataBaseName + "..CallBack where cCallManger='" + autoUserID + "'";
            baoButton3.BaoTitleNames = "cTaskCode=回访任务编号,cClientName=客户编号,cCallMangerName=工程师,cPlaTime=计划日期,cAim=回访目的,cTaskEnd=完成日期,cAuditPerson=审核人";
            baoButton3.FrmHigth = 400;
            baoButton3.FrmWidth = 600;
            baoButton3.BaoColumnsWidth = "cTaskCode=100,cClientName=80,cCallMangerName=80,cPlaTime=80,cAim=100,cTaskEnd=80,cAuditPerson=80";

            beCustomer.BaoSQL = "select cCusCode,cCusName from " + U8DataBaseName + ".Customer ";
            beCustomer.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            beCustomer.FrmHigth = 600;
            beCustomer.FrmWidth = 400;
            beCustomer.BaoColumnsWidth = "cCusCode=150,cCusName=250";
            beCustomer.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusCode=";

            beEngineer.BaoSQL = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003'";
            beEngineer.BaoTitleNames = "userid=人员编码,username=人员姓名";
            beEngineer.FrmHigth = 300;
            beEngineer.FrmWidth = 300;
            beEngineer.BaoColumnsWidth = "userid=100,username=100";
            beEngineer.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003' and  userid =";

            //可增加工程师的判断，只能查看自己的
            baoButton1.BaoSQL = "select cTaskCode,cClientName,cCallMangerName,cPlaTime,cAim,cTaskEnd,cAuditPerson from " + RiLiDataBaseName + "..CallBack where cAuditPerson='' or cAuditPerson is null";
            baoButton1.BaoTitleNames = "cTaskCode=回访任务编号,cClientName=客户编号,cCallMangerName=工程师,cPlaTime=计划日期,cAim=回访目的,cTaskEnd=完成日期,cAuditPerson=审核人";
            baoButton1.FrmHigth = 400;
            baoButton1.FrmWidth = 600;
            baoButton1.BaoColumnsWidth = "cTaskCode=100,cClientName=80,cCallMangerName=80,cPlaTime=80,cAim=100,cTaskEnd=80,cAuditPerson=80";

            baoButton3.BaoSQL = "select cTaskCode,cClientName,cCallMangerName,cPlaTime,cAim,cTaskEnd,cAuditPerson from " + RiLiDataBaseName + "..CallBack";
            baoButton3.BaoTitleNames = "cTaskCode=回访任务编号,cClientName=客户编号,cCallMangerName=工程师,cPlaTime=计划日期,cAim=回访目的,cTaskEnd=完成日期,cAuditPerson=审核人";
            baoButton3.FrmHigth = 400;
            baoButton3.FrmWidth = 600;
            baoButton3.BaoColumnsWidth = "cTaskCode=100,cClientName=80,cCallMangerName=80,cPlaTime=80,cAim=100,cTaskEnd=80,cAuditPerson=80";
            
        }
        /// <summary>
        /// 地区 选择关闭事件
        /// </summary>
        private void tbRegion_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.tbRegion.BaoBtnCaption = e.ReturnRow1["CDCNAME"].ToString();
            this.tbRegionCode.Text = e.ReturnRow1["cDCCODE"].ToString();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TaskInite(tbTaskCode.Text);//刷新
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private ToolTip tt;
        private ToolTip tt2;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tt != null)
                { tt.Dispose(); }
                tt = new ToolTip();
                tt.ShowAlways = true;


                tt.Show(tbTarget.Text, tbTarget);


                if (tt2 != null)
                { tt2.Dispose(); }
                tt2 = new ToolTip();
                tt2.ShowAlways = true;

                tt2.Show(rtbCallContent.Text, rtbCallContent);

            }
        }
    }
}
