using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8Global;
using System.Text.RegularExpressions;

namespace Install
{
    public partial class UserControl1 : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string U8DataBaseName;
        private string RiLiDataBaseName = "RiLi";

        public System.Data.DataTable DTInstalltask;
        public System.Data.DataTable DTInsaccessory;
        public System.Data.DataTable DTInsfeedback;
        public System.Data.DataTable DTInsdetail;
        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "candy";
        private bool addsave = false;
        public UserControl1()
        {
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            //  U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.DataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);//1
            Frm_Init();//2 制件初始化
            TaskInite("");//4
        }
        public UserControl1(string taskid)
        {
            InitializeComponent();

            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            // U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.DataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            Frm_Init();//制件初始化
            TaskInite(taskid);
        }
        public void GetUserRole(string UserID)//获取角色
        {
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
        }
        /// <summary>
        /// 加载单据
        /// </summary>
        private void TaskInite(string taskcode)
        {
            //输入控制 
            ButtonInitState(UserRole);
            if (UserRole == "")
            {
                MessageBox.Show("加载有错误，请重新登陆！");
                return;
            }
            //取当前项目的状态
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + taskcode + "'");
            DTInsaccessory = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsAccessory where aTaskCode='" + taskcode + "'");
            DTInsfeedback = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsFeedback where fTaskCode='" + taskcode + "'");
            DTInsdetail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsDetail where rTaskCode='" + taskcode + "' order by rInsEnd");
            UnDataBinding();
            DataBinding();

            if (DTInstalltask.Rows.Count > 0)
            {
                CB_installtype.Text = DTInstalltask.Rows[0]["tInsType"].ToString();
            }

            //收回，提交按钮设置
            if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
            {
                this.button1.Text = "提交";
                this.button4.Text = "提交";
                this.button2.Text = "提交";
                this.button3.Text = "提交";

            }

            else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
            {
                this.button1.Text = "收回";
                this.button4.Text = "提交";
                this.button2.Text = "提交";
                this.button3.Text = "提交";
            }
            else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
            {
                this.button1.Text = "收回";
                this.button4.Text = "收回";
                this.button2.Text = "提交";
                this.button3.Text = "提交";
            }
            else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派")
            {
                this.button1.Text = "收回";
                this.button4.Text = "收回";
                this.button2.Text = "收回";
                this.button3.Text = "提交";
            }
            else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核")
            {
                this.button1.Text = "收回";
                this.button4.Text = "收回";
                this.button2.Text = "收回";
                this.button3.Text = "收回";
            }
            else if (DTInstalltask.Rows.Count > 0)
            {
                this.button1.Text = "收回";
                this.button4.Text = "收回";
                this.button2.Text = "收回";
                this.button3.Text = "收回";
            }

            if (CB_installtype.Text == "主机安装")
            {
               

                Maintypetask_tb.Enabled = false;
                //MainType_be.Enabled = true;

                //MonitorType_tb.Enabled = true;

                //MainVersion_tb.Enabled = true;


                //RTB_softversion.Enabled = true;
            }
            if (CB_installtype.Text == "选配件安装")
            {
                MainType_be.Enabled = false;

                MonitorType_tb.Enabled = false;

                MainVersion_tb.Enabled = false;

                //Maintypetask_tb.Enabled = true;

                RTB_softversion.Enabled = false;
            }

            BtnModify.Enabled = false;
            btnAdd.Enabled = false;
            BtnAudit.Enabled = false;
            BtnCheck.Enabled = false;
            BtnFileAdd.Enabled = false;
            BtnOutexcel.Enabled = false;
            BtnSave.Enabled = false;
            BtnSearch.Enabled = false;
            BtnDelete.Enabled = false;

            BtnCancel.Visible = false;
            BtnModify.Visible = false;
            btnAdd.Visible = false;
            BtnAudit.Visible = false;
            BtnCheck.Visible = false;
            BtnFileAdd.Visible = false;
            BtnOutexcel.Visible = false;
            BtnSave.Visible = false;
            BtnSearch.Visible = false;
            BtnDelete.Visible = false;

            BtnRefresh.Enabled = true;

            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;


            if (UserRole.Contains("004"))
            {   //销售
                #region
                //if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() != "")//已提交
                //{
                //    BtnAudit.Text = "已审核";
                //    BtnModify.Enabled = false;
                //    BtnDelete.Enabled = false;
                //}
                //else
                //{
                //    BtnAudit.Text = "未审核";
                //}
                //if (InsManagercode_be.Text != "")
                //{   //
                //    BtnModify.Enabled = false;
                //    BtnDelete.Enabled = false;
                //}
                //else
                //{
                //    BtnModify.Enabled = true;
                //    BtnDelete.Enabled = true;
                //}
                #endregion

                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                {
                    if (!string.IsNullOrEmpty(Manager_be.Text)
                        || DTInstalltask.Rows[0]["tManger"].ToString() != "")
                    {
                        this.button1.Enabled = true;
                    }
                    BtnModify.Enabled = true;
                    BtnDelete.Enabled = true;

                }
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                {
                    this.button1.Enabled = true;
                    BtnModify.Enabled = false;
                    BtnDelete.Enabled = false;
                }

                btnAdd.Enabled = true;
                BtnOutexcel.Enabled = true;
                BtnSearch.Enabled = true;

                this.button1.Visible = true;
                btnAdd.Visible = true;
                BtnOutexcel.Visible = true;
                BtnSave.Visible = true;
                BtnSearch.Visible = true;
                BtnModify.Visible = true;
                BtnDelete.Visible = true;
                BtnSave.Visible = true;
                BtnCancel.Visible = true;
            }
            if (UserRole.Contains("009"))
            {   //部长，有指派科长的权利
                //string s = DTInstalltask.Rows[0]["tState"].ToString();

             
               //如果他是部长，并且是这个被指派的部长。
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长"
                     && DTInstalltask.Rows[0]["tManger"].ToString() == autoUserID)
                {
                    this.button4.Visible = true;
                    button4.Enabled = true;
                    BtnModify.Enabled = true;
                   
                    this.InstallUnit1.Enabled = false;
                    this.InstallUnit2.Enabled = false;
                    this.MachineLevel.Enabled = false;
                    this.Color.Enabled = false;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                }
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求"
                    && DTInstalltask.Rows[0]["tManger"].ToString() == autoUserID)
                {
                    this.button4.Visible = true;
                    button4.Enabled = true;
                    BtnModify.Enabled = true;
                  
                    //this.InstallUnit1.Enabled = true;
                    //this.InstallUnit2.Enabled = true;
                    //this.MachineLevel.Enabled = true;
                    //this.Color.Enabled = true;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                }
            
            
                #region
    
                #endregion
                BtnOutexcel.Enabled = true;
                BtnSearch.Enabled = true;

                BtnOutexcel.Visible = true;
                BtnSearch.Visible = true;
                button4.Visible = true;
                BtnSave.Visible = true;
                BtnCancel.Visible = true;
                BtnModify.Visible = true;
               
                BtnFileAdd.Visible = true;
                BtnFileAdd.Enabled = true;
            }

            if (UserRole.Contains("002"))
            {   //客服经理（有审核权）hhq
                //string s = DTInstalltask.Rows[0]["tState"].ToString();
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求"
                     && DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    if (!string.IsNullOrEmpty(InsManagercode_be.Text)
                        || (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tInsManger"].ToString() != ""))//InsManagercode_be:安装负责人
                    {
                        this.button2.Enabled = true;
                    }
                    BtnModify.Enabled = true;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派"
                   && DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    this.button2.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核"
                   && DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    BtnAudit.Text = "审核";
                    BtnAudit.Enabled = true;
                    BtnAudit.Visible = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已审核"
                  && DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    BtnAudit.Text = "弃审";
                    BtnAudit.Enabled = true;
                    BtnAudit.Visible = true;
                }
                #region
                /***
                if (DTInstalltask.Rows[0]["fMessageId"].ToString() == "" && DTInstalltask.Rows[0]["fMessagedate"].ToString() != "") //消息收回
                {
                    //MessageBox.Show("此单据已经收回，不可以审核！");
                    if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() == "")
                    {
                        
                        BtnModify.Enabled = true;
                        BtnAudit.Enabled = false;
                        InsManagercode_be.Enabled = false;
                        DTP_assignDate.Enabled = false;
                    }
                }
                else
                {
                    if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() == "")
                    {
                        BtnAudit.Text = "审核";
                        BtnModify.Enabled = true;
                        BtnAudit.Enabled = true;
                        InsManagercode_be.Enabled = false;
                        DTP_assignDate.Enabled = false;
                    }
                    else
                    {
                        if (DTInstalltask.Rows[0]["tCheckPerson"].ToString() == "")
                        {
                            BtnAudit.Text = "弃审";
                            BtnModify.Enabled = false;
                            BtnAudit.Enabled = true;
                        }
                    }
                }
                 ***/
                #endregion
                BtnOutexcel.Enabled = true;
                BtnSearch.Enabled = true;

                BtnOutexcel.Visible = true;
                BtnSearch.Visible = true;
                button2.Visible = true;
                BtnSave.Visible = true;
                BtnCancel.Visible = true;
                BtnModify.Visible = true;

                BtnFileAdd.Visible = true;
                BtnFileAdd.Enabled = true;
            }
            if (UserRole.Contains("003"))
            {   //工程师
                //string g = DTInstalltask.Rows[0]["tState"].ToString();
                //string ss = DTInstalltask.Rows[0]["tInsManger"].ToString();
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派"
                    && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tInsManger"].ToString() == autoUserID)
                {
                    //if (!string.IsNullOrEmpty(this.MainMake_tb.Text) ||
                    //    (DTInsfeedback.Rows.Count > 0 && DTInsfeedback.Rows[0]["fMainMake"].ToString() != ""))//MainMake_tb：主机编号 hhq
                    //{
                    //    this.button3.Enabled = true;
                    //}

                    this.button3.Enabled = true;
                    BtnModify.Enabled = true;
                    BtnFileAdd.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核"
                      && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tInsManger"].ToString() == autoUserID)
                {
                    this.button3.Enabled = true;

                }
                BtnFileAdd.Visible = true;
                BtnOutexcel.Enabled = true;
                BtnSearch.Enabled = true;

                BtnFileAdd.Enabled = true;
                BtnOutexcel.Visible = true;
                BtnSearch.Visible = true;
                button3.Visible = true;
                BtnSave.Visible = true;
                BtnCancel.Visible = true;
                BtnModify.Visible = true;
                #region
                /***
                if (DTInstalltask.Rows[0]["tAuditMessageId"].ToString() == "" && DTInstalltask.Rows[0]["tAuditMessagedate"].ToString() != "")
                {
                    // MessageBox.Show("此单据已经收回，不可以修改任务反馈！");
                }
                else
                {

                    if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() == "")
                    {
                        BtnAudit.Text = "审核";
                        BtnModify.Enabled = true;
                        BtnFileAdd.Enabled = true;

                    }
                    else
                    {
                        if (DTInstalltask.Rows[0]["tCheckPerson"].ToString() == "")//核对后不可以修改
                        {
                            BtnFileAdd.Enabled = true;
                        }
                        else
                        {
                            BtnFileAdd.Enabled = true;
                        }
                    }

                    BtnOutexcel.Enabled = true;
                    BtnSearch.Enabled = true;
                    button3.Enabled = true;
                }
                 ***/
                #endregion

            }
            if (UserRole.Contains("001"))
            {   //800客服(有核对权)
                //string s = DTInstalltask.Rows[0]["tState"].ToString();
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已审核")
                {
                    BtnCheck.Text = "核对";
                    BtnCheck.Enabled = true;
                    BtnFileAdd.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已核对")
                {
                    BtnCheck.Text = "反核对";
                    BtnCheck.Enabled = true;
                    BtnFileAdd.Enabled = true;
                }
                BtnOutexcel.Enabled = true;
                BtnSearch.Enabled = true;

                BtnFileAdd.Visible = true;
                BtnCheck.Visible = true;
                BtnOutexcel.Visible = true;
                BtnSearch.Visible = true;
            }
            if (DTInstalltask.Rows.Count == 0)
            {
                BtnFileAdd.Enabled = false;
            }
            this.RegionName.Text = string.Empty;

            if (DTInstalltask.Rows.Count > 0)
            {

                if (!(DTInstalltask.Rows[0]["tRegCode"].ToString() == string.Empty))
                {
                    this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(DTInstalltask.Rows[0]["tRegCode"].ToString());
                }
            }
        }
        public void DataBinding()
        {
            TaskCode_tb.DataBindings.Add("Text", DTInstalltask, "tInsCode");
            ClientCode_tb.DataBindings.Add("Text", DTInstalltask, "tCusCode");
            ClientName_tb.DataBindings.Add("Text", DTInstalltask, "tCusName");
            InsConnect_tb.DataBindings.Add("Text", DTInstalltask, "tComName");
            InsPhone_tb.DataBindings.Add("Text", DTInstalltask, "tComPhone");
            SellClient_tb.DataBindings.Add("Text", DTInstalltask, "tAgeStore");
            SellManager_tb.DataBindings.Add("Text", DTInstalltask, "tAgePerson");
            Adress_tb.DataBindings.Add("Text", DTInstalltask, "tAddress");
            Region_tb.DataBindings.Add("Text", DTInstalltask, "tRegCode");
            ZoneName.DataBindings.Add("Text", DTInstalltask, "tRegName");
            MainType_be.DataBindings.Add("Text", DTInstalltask, "tMaiCode");
            MonitorType_tb.DataBindings.Add("Text", DTInstalltask, "tMonCode");
            DTP_Send.DataBindings.Add("Text", DTInstalltask, "tSendTime");
       
            RepairMonth.DataBindings.Add("Text", DTInstalltask, "tRepMonth");
            CB_installtype.DataBindings.Add("SelectedItem", DTInstalltask, "tInsType");
            CB_installtype.DataBindings.Add("Text", DTInstalltask, "tInsType");
            Summary_tb.DataBindings.Add("Text", DTInstalltask, "tSummary");
            Manager_be.DataBindings.Add("Text", DTInstalltask, "tManger");
            DTP_TaskStart.DataBindings.Add("Text", DTInstalltask, "tMessagedate");
            InsManagercode_be.DataBindings.Add("Text", DTInstalltask, "tInsManger");
            InsMangerName_tb.DataBindings.Add("Text", DTInstalltask, "tInsMangerName");
            DTP_assignDate.DataBindings.Add("Text", DTInstalltask, "tAuditMessagedate");
            AsignInstallManagerDate.DataBindings.Add("Text", DTInstalltask, "AsignInstallManagerDate");
            this.InstallManagerCode.DataBindings.Add("Text", DTInstalltask, "InstallManagerCode");
            this.InstallManagerName.DataBindings.Add("Text", DTInstalltask, "InstallManagerName");
            this.City.DataBindings.Add("Text", DTInstalltask, "City");
            this.InstallUnit1.DataBindings.Add("Text", DTInstalltask, "InstallUnit1");
            this.InstallUnit2.DataBindings.Add("Text", DTInstalltask, "InstallUnit2");
            this.MachineLevel.DataBindings.Add("Text", DTInstalltask, "MachineLevel");
            this.Color.DataBindings.Add("Text", DTInstalltask, "Color");
            this.Color.DataBindings.Add("SelectedItem", DTInstalltask, "Color");
            this.gridControl1.DataSource = DTInsaccessory;
            gridColumn1.FieldName = "aAccCode";
            gridColumn2.FieldName = "aAccName";
            gridColumn3.FieldName = "aMakeCode";
            gridColumn4.FieldName = "aSummary";
            gridColumn9.FieldName = "aAccStd";

            PostCode_tb.DataBindings.Add("Text", DTInsfeedback, "fPostCode");
            ClientManager_tb.DataBindings.Add("Text", DTInsfeedback, "fCliManger");
            ClientPhone_tb.DataBindings.Add("Text", DTInsfeedback, "fCliPhone");
            DTP_yanshou.DataBindings.Add("Text", DTInsfeedback, "fEndTime");
            DTP_fendtime.DataBindings.Add("Text", DTInstalltask, "fMessagedate");
            MainMake_tb.DataBindings.Add("Text", DTInsfeedback, "fMainMake");
            MonitorMake_tb.DataBindings.Add("Text", DTInsfeedback, "fMonMake");
            MainVersion_tb.DataBindings.Add("Text", DTInsfeedback, "fMainVersion");
            Maintypetask_tb.DataBindings.Add("Text", DTInsfeedback, "fMainType");
            RTB_softversion.DataBindings.Add("Text", DTInsfeedback, "fSoftVersion");
            InsFeedBack_tb.DataBindings.Add("Text", DTInsfeedback, "fFeed");
            FeedBackSummary_tb.DataBindings.Add("Text", DTInsfeedback, "fsummary");
            this.gridControl2.DataSource = DTInsdetail;
            gridColumn5.FieldName = "rInsName";
            gridColumn6.FieldName = "rInsStart";
            gridColumn7.FieldName = "rInsEnd";
            gridColumn8.FieldName = "rInsSummary";

        }
        public void UnDataBinding()
        {
            TaskCode_tb.DataBindings.Clear();
            ClientCode_tb.DataBindings.Clear();
            ClientName_tb.DataBindings.Clear();
            InsConnect_tb.DataBindings.Clear();
            InsPhone_tb.DataBindings.Clear();
            SellClient_tb.DataBindings.Clear();
            SellManager_tb.DataBindings.Clear();
            Adress_tb.DataBindings.Clear();
            Region_tb.DataBindings.Clear();
            MainType_be.DataBindings.Clear();
            MonitorType_tb.DataBindings.Clear();
            DTP_Send.DataBindings.Clear();
            RepairMonth.DataBindings.Clear();
            CB_installtype.DataBindings.Clear();
            Summary_tb.DataBindings.Clear();
            Manager_be.DataBindings.Clear();
            DTP_TaskStart.DataBindings.Clear();
            InsManagercode_be.DataBindings.Clear();
            InsMangerName_tb.DataBindings.Clear();
            DTP_assignDate.DataBindings.Clear();
            ZoneName.DataBindings.Clear();
            this.InstallManagerCode.DataBindings.Clear();
            this.InstallManagerName.DataBindings.Clear();
            this.AsignInstallManagerDate.DataBindings.Clear();
            this.City.DataBindings.Clear();
            this.InstallUnit1.DataBindings.Clear();
            this.InstallUnit2.DataBindings.Clear();
            this.MachineLevel.DataBindings.Clear();
            this.Color.DataBindings.Clear();
            this.Color.Text = null;

            this.gridControl1.DataSource = null;

            PostCode_tb.DataBindings.Clear();
            ClientManager_tb.DataBindings.Clear();
            ClientPhone_tb.DataBindings.Clear();
            DTP_yanshou.DataBindings.Clear();
            DTP_fendtime.DataBindings.Clear();
            MainMake_tb.DataBindings.Clear();
            MonitorMake_tb.DataBindings.Clear();
            MainVersion_tb.DataBindings.Clear();
            Maintypetask_tb.DataBindings.Clear();
            RTB_softversion.DataBindings.Clear();
            InsFeedBack_tb.DataBindings.Clear();
            FeedBackSummary_tb.DataBindings.Clear();

            PostCode_tb.Clear();
            ClientManager_tb.Clear();
            ClientPhone_tb.Clear();
            MainMake_tb.Clear();
            MonitorMake_tb.Clear();
            MainVersion_tb.Clear();
            //Maintypetask_tb.DataBindings.Add("Text", DTInsfeedback, "");
            RTB_softversion.Clear();
            InsFeedBack_tb.Clear();
            FeedBackSummary_tb.Clear();
            this.gridControl2.DataSource = null;
        }
        /// <summary>
        /// 按钮初始化
        /// </summary>
        /// <param name="role">角色</param>
        private void ButtonInitState(string role)
        {
            BtnModify.Enabled = false;
            btnAdd.Enabled = false;
            BtnAudit.Enabled = false;
            BtnCheck.Enabled = false;
            BtnFileAdd.Enabled = false;
            BtnOutexcel.Enabled = false;
            BtnSave.Enabled = false;
            BtnSearch.Enabled = false;
            BtnDelete.Enabled = false;
            BtnItemDel.Enabled = false;
            BtnItemAdd.Enabled = false;
            insdetailitem_del.Enabled = false;
            insdetailitem_add.Enabled = false;

            TaskCode_tb.ReadOnly = true;
            Adress_tb.ReadOnly = true;
            ClientName_tb.ReadOnly = true;
            InsConnect_tb.ReadOnly = true;
            InsPhone_tb.ReadOnly = true;
            SellManager_tb.ReadOnly = true;
            RepairMonth.ReadOnly = true;
            InsMangerName_tb.ReadOnly = true;
            Summary_tb.ReadOnly = true;
            PostCode_tb.ReadOnly = true;
            ClientManager_tb.ReadOnly = true;
            ClientPhone_tb.ReadOnly = true;
            MainMake_tb.ReadOnly = true;
            MonitorMake_tb.ReadOnly = true;
            MainVersion_tb.ReadOnly = true;
            Maintypetask_tb.Enabled = false;
            //Maintypetask_tb.DataBindings.Add("Text", DTInsfeedback, "");
            RTB_softversion.ReadOnly = true;
            InsFeedBack_tb.ReadOnly = true;
            FeedBackSummary_tb.ReadOnly = true;

            ClientCode_tb.Enabled = false;
            SellClient_tb.Enabled = false;
            Region_tb.Enabled = false;
            MainType_be.Enabled = false;
            MonitorType_tb.Enabled = false;
            DTP_Send.Enabled = false;
            CB_installtype.Enabled = false;
            Manager_be.Enabled = false;
            DTP_TaskStart.Enabled = false;
            InsManagercode_be.Enabled = false;
            DTP_assignDate.Enabled = false;
            DTP_yanshou.Enabled = false;
            DTP_fendtime.Enabled = false;
            BtnCancel.Enabled = false;
            this.InstallManagerCode.Enabled = false;

            //发起任务明细 
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.Editable = false;

            if (role == "")
            {
                BtnModify.Enabled = false;
                btnAdd.Enabled = false;
                BtnAudit.Enabled = false;
                BtnCheck.Enabled = false;
                BtnFileAdd.Enabled = false;
                BtnOutexcel.Enabled = false;
                BtnSave.Enabled = false;
                BtnSearch.Enabled = false;
                BtnDelete.Enabled = false;

            }
            else
            {
                #region
                /**
                if (role.Contains("004"))
                {
                    btnAdd.Enabled = true;
                    baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tStartPerson='" + autoUserID + "'";
                    //baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask";
                    baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                    baoButton1.FrmHigth = 400;
                    baoButton1.FrmWidth = 800;
                    baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100";
                }
                if (role.Contains("003"))
                {
                    BtnOutexcel.Enabled = true;
                    BtnSearch.Enabled = true;
                    baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tInsManger='" + autoUserID + "'";
                    //baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask ";
                    baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                    baoButton1.FrmHigth = 400;
                    baoButton1.FrmWidth = 800;
                    baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";
                }
                if (role.Contains("002"))
                {
                    BtnSearch.Enabled = true;
                    baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tManger='" + autoUserID + "'";
                    baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                    baoButton1.FrmHigth = 400;
                    baoButton1.FrmWidth = 800;
                    baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";

                }
                if (UserRole.Contains("001"))
                {
                    BtnFileAdd.Enabled = true;
                    BtnOutexcel.Enabled = true;
                    
                    BtnSearch.Enabled = true;
                    baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tState='完成'or tState='待核对'";

                    // baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tCheckPerson='" + autoUserID + "'or tState='待核对'";
                    baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                    baoButton1.FrmHigth = 400;
                    baoButton1.FrmWidth = 800;
                    baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";
                }
                 **/
                #endregion
            }

            //DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask ");
            //DTInsaccessory = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsAccessory ");
            //DTInsfeedback = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsFeedback");
            //DTInsdetail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsDetail");
            //DTInsaccessory.Clear();
            //DTInsdetail.Clear();
            //DTInstalltask.Clear();
            //DTInsfeedback.Clear();
            //UnDataBinding();
            //DataBinding();
        }
        void ZoneName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.Region_tb.BaoBtnCaption = e.ReturnRow1["cDCCODE"].ToString();
            this.ZoneName.Text = e.ReturnRow1["CDCNAME"].ToString();
            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(e.ReturnRow1["cDCCODE"].ToString());
        }
        /// <summary>
        /// 新增事件
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("004"))
            {
                //刷新
                TaskInite("");
                DTInsaccessory.Clear();
                DTInsdetail.Clear();
                DTInstalltask.Clear();
                DTInsfeedback.Clear();

                addsave = true;
                this.BtnCancel.Enabled = true;
                this.BtnAudit.Enabled = false;
                this.BtnModify.Enabled = false;
                this.BtnCheck.Enabled = false;
                this.BtnFileAdd.Enabled = false;
                this.BtnOutexcel.Enabled = false;
                this.BtnSearch.Enabled = false;
                this.BtnSave.Enabled = true;
                this.TaskCode_tb.Text = "保存后将自动生成";
                this.BtnItemAdd.Enabled = true;
                this.BtnItemDel.Enabled = true;


                ClientCode_tb.Enabled = true;
                ClientName_tb.ReadOnly = false;
                InsConnect_tb.ReadOnly = false;
                InsPhone_tb.ReadOnly = false;
                SellClient_tb.Enabled = true;
                SellManager_tb.ReadOnly = false;
                Adress_tb.ReadOnly = false;
                this.City.ReadOnly = false;

                MainType_be.Enabled = true;
                MonitorType_tb.Enabled = true;
                DTP_Send.Enabled = true;
                RepairMonth.ReadOnly = false;
                CB_installtype.Enabled = true;
                Summary_tb.ReadOnly = false;
                Region_tb.Enabled = true;
                Manager_be.Enabled = true;
                DTP_TaskStart.Enabled = true;
                this.button1.Text = "提交";
                this.button2.Text = "提交";
                this.button3.Text = "提交";
                //发起任务明细
                this.gridView2.OptionsBehavior.Editable = true;
            }
            else
            {
                MessageBox.Show("您没有权限新增");
            }

        }

        public void Frm_Init()
        {
            this.toolTip1.SetToolTip(this.RTB_softversion,this.RTB_softversion.Text);
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            this.toolTip1.SetToolTip(label29, "zhaokun");
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            this.gridView3.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            gridView2.IndicatorWidth = 30;
            gridView3.IndicatorWidth = 30;

            ClientCode_tb.BaoSQL = "select cCusCode,cCusName from " + U8DataBaseName + ".Customer where ccccode  like '2%'";
            ClientCode_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.ClientCode_tb.FrmHigth = 600;
            this.ClientCode_tb.FrmWidth = 450;
            ClientCode_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_tb.BaoColumnsWidth = "cCusCode=120,cCusName=280";

            SellClient_tb.BaoSQL = "select cCusCode,cCusName from " + U8DataBaseName + ".Customer where ccccode  like '1%'";
            SellClient_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.SellClient_tb.FrmHigth = 600;
            this.SellClient_tb.FrmWidth = 450;
            SellClient_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusName=";
            SellClient_tb.BaoColumnsWidth = "cCusCode=120,cCusName=280";

            MainType_be.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%' and len(cinvcode) = 3";
            MainType_be.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            this.MainType_be.FrmHigth = 400;
            this.MainType_be.FrmWidth = 600;
            MainType_be.DecideSql = "select * from " + U8DataBaseName + ".Inventory   where cinvcode like 'A%' and len(cinvcode) = 3 and cInvName=";
            MainType_be.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";

            Maintypetask_tb.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%' and len(cinvcode) = 3";
            Maintypetask_tb.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            this.Maintypetask_tb.FrmHigth = 400;
            this.Maintypetask_tb.FrmWidth = 600;
            Maintypetask_tb.DecideSql = "select * from " + U8DataBaseName + ".Inventory   where cinvcode like 'A%' and len(cinvcode) = 3 and cInvStd=";
            Maintypetask_tb.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";


            MonitorType_tb.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%'  and len(cinvcode) = 7";
            MonitorType_tb.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            this.MonitorType_tb.FrmHigth = 400;
            this.MonitorType_tb.FrmWidth = 600;
            MonitorType_tb.DecideSql = "select * from " + U8DataBaseName + ".Inventory where  cinvcode like  'A%' and cInvStd=";
            MonitorType_tb.BaoColumnsWidth = "cInvCode=100,cInvName=250,cInvStd=200";

            Manager_be.BaoSQL = "select userid,username from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '009'";
            Manager_be.BaoTitleNames = "userid=人员编码,username=人员姓名";
            Manager_be.FrmHigth = 400;
            Manager_be.FrmWidth = 300;
            Manager_be.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '009' and  userid =";
            Manager_be.BaoColumnsWidth = "userid=120,username=120";

          

            InstallManagerCode.BaoSQL = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002'";
            InstallManagerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            InstallManagerCode.FrmHigth = 400;
            InstallManagerCode.FrmWidth = 300;
            InstallManagerCode.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002' and  userid =";
            InstallManagerCode.BaoColumnsWidth = "userid=120,username=120";

            InsManagercode_be.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and rt.RegionId in (select RegionId from RegionToUser where UserId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')";
            InsManagercode_be.BaoTitleNames = "userid=人员编码,username=人员姓名";
            InsManagercode_be.FrmHigth = 400;
            InsManagercode_be.FrmWidth = 300;
            InsManagercode_be.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '003' and  userid =";
            InsManagercode_be.BaoColumnsWidth = "userid=120,username=120";

            TaskCode_tb.ReadOnly = true;//任务编号

            Region_tb.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass";
            Region_tb.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.Region_tb.FrmHigth = 600;
            this.Region_tb.FrmWidth = 400;
            Region_tb.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE=";
            Region_tb.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            Region_tb.BaoClickClose = true;
            Region_tb.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(ZoneName_OnLookUpClosed);


            if (UserRole.Contains("004"))
            {
                baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tStartPerson='" + autoUserID + "'";
                //baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask";
                baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                baoButton1.FrmHigth = 400;
                baoButton1.FrmWidth = 800;
                baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100";
            }
            if (UserRole.Contains("003"))
            {
                baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tInsManger='" + autoUserID + "'";
                //baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask ";
                baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                baoButton1.FrmHigth = 400;
                baoButton1.FrmWidth = 800;
                baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";
            }
            if (UserRole.Contains("002"))
            {
                baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tManger='" + autoUserID + "'";
                baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                baoButton1.FrmHigth = 400;
                baoButton1.FrmWidth = 800;
                baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";

            }
            if (UserRole.Contains("001"))
            {
                baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tState='完成'or tState='待核对'";
                // baoButton1.BaoSQL = "select tInsCode,tCusCode,tAgeStore,tRegName,tInsType,tStartPerson,tManger,tInsManger,tTaskStart,tAuditPerson,tCheckPerson,tState from " + RiLiDataBaseName + "..InstallTask where tCheckPerson='" + autoUserID + "'or tState='待核对'";
                baoButton1.BaoTitleNames = " tInsCode=任务编号,tCusCode=客户编号,tAgeStore=销售代理店,tRegName=区域名称,tInsType=安装类型,tStartPerson=任务发起人,tManger=负责经理,tInsManger=安装负责人,tTaskStart=任务发起日期,tAuditPerson=审核人,tCheckPerson=核对人,tState=任务状态";
                baoButton1.FrmHigth = 400;
                baoButton1.FrmWidth = 800;
                baoButton1.BaoColumnsWidth = "tInsCode=80,tCusCode=80,tAgeStore=100,tRegName=80,tInsType=80,tStartPerson=100,tManger=80,tInsManger=80,tTaskStart=80,tAuditPerson=100,tCheckPerson=100,tState=80";
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            toolStrip1.Parent = this;
        }

        private void CB_installtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addsave == true)
            {
                if (CB_installtype.Text == "主机安装")
                {
                    //TaskCode_tb.Text = RiLiGlobal.GetCode.GetInsCode();//主机安装
                    //Maintypetask_tb.Enabled = false;
                    MainType_be.Enabled = true;
                    MonitorType_tb.Enabled = true;
                    RTB_softversion.Enabled = true;
                }
                if (CB_installtype.Text == "选配件安装")
                {
                    //TaskCode_tb.Text = RiLiGlobal.GetCode.GetOPCode();//配件安装
                    MainType_be.Text = "";
                    MainType_be.Enabled = false;
                    MonitorType_tb.Text = "";
                    MonitorType_tb.Enabled = false;
                    MonitorMake_tb.Text = string.Empty;
                    MonitorMake_tb.Enabled = false;
                    RTB_softversion.Enabled = false;
                    //Maintypetask_tb.Enabled = true;
                }
                TaskCode_tb.Text = "";
            }
        }

        private void BtnItemAdd_Click(object sender, EventArgs e)
        {
            System.Data.DataRow row1 = this.DTInsaccessory.NewRow();
            this.DTInsaccessory.Rows.Add(row1);
        }
        private void BtnItemDel_Click(object sender, EventArgs e)
        {
            if (this.gridView2.FocusedRowHandle >= 0)
            {

                this.gridView2.DeleteSelectedRows();
                //int i = this.gridView2.FocusedRowHandle;
                //DataRow dss = DTInsaccessory.Rows[i];
                //DTInsaccessory.Rows.Remove(dss);
            }
        }
        private void BtnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.tState from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在，请重新操作");
                    return;
                }
                if (BtnAudit.Text == "弃审")
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已审核")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    string auditsql = "update InstallTask set tAuditTime=null,tAuditPerson='',tState='待审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("弃审成功");
                    //Bao.Message.CMessage.SendMessage("核对任务", "任务已经审核，请您核对", Manager_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);

                }
                else
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "待审核")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    string auditsql = "update InstallTask set tAuditTime=getDate(),tAuditPerson='" + autoUserID + "',tState='已审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("审核成功");
                    Bao.Message.CMessage.SendMessageToRoleNoDepartment("核对任务", "任务已经审核，请您核对", "001", UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.tState,tAccType from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在，请重新操作");
                    return;
                }


                if (BtnCheck.Text == "反核对")
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已核对")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    string auditsql = "update InstallTask set tCheckTime=null,tCheckPerson='',tState='已审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("反核对成功");
                }
                else
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已审核")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    if (DTInstalltask.Rows[0]["tAccType"].ToString() == string.Empty)
                    {
                        MessageBox.Show("附件未上传，不能核对");
                        return;
                    }
                    string auditsql = "update InstallTask set tCheckTime=getDate(),tCheckPerson='" + autoUserID + "',tState='已核对' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("核对成功");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView3.FocusedRowHandle < 0)
                {
                    return;
                }
 

                InstallPerson.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003'";
                InstallPerson.BaoTitleNames = "userid=人员编码,username=人员姓名,RoleName=职位名称,DeptName=部门";
                this.InstallPerson.FrmHigth = 400;
                this.InstallPerson.FrmWidth = 500;
              
                InstallPerson.BaoColumnsWidth = "userid=100,username=100,RoleName=150,DeptName=150";

                DataRow FocusedRow = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
                this.InstallPerson.button1_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：\r\n" + ex.Message, "系统提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// （发起任务表体）配件编号选择事件
        /// </summary>
        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView2.FocusedRowHandle < 0)
                {
                    return;
                }
                AccBT.BaoSQL = "select cInvCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%' or cinvcode like 'C%'";
                AccBT.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
                this.AccBT.FrmHigth = 400;
                this.AccBT.FrmWidth = 500;
                AccBT.BaoColumnsWidth = "cInvCode=100,cInvName=220,cInvStd=100";

                DataRow FocusedRow = this.gridView2.GetDataRow(this.gridView2.FocusedRowHandle);
                this.AccBT.button1_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：\r\n" + ex.Message, "系统提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AccBT_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            int i = this.gridView2.FocusedRowHandle;
            this.gridView2.SetFocusedRowCellValue(gridView2.Columns[0], dr["cinvcode"].ToString());
            this.gridView2.SetRowCellValue(i, gridView2.Columns[1], dr["cinvname"].ToString());
            this.gridView2.SetRowCellValue(i, gridView2.Columns["aAccStd"], dr["cInvStd"].ToString());
        }

        private void baoButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            string getcode = dr["tInsCode"].ToString();
            TaskInite(getcode);
            //if (UserRole == "")
            //{

            //}
            //else if (UserRole == "004")
            //{

            //}
            //else if (UserRole == "002")
            //{

            //}
            //else if (UserRole == "003")
            //{


            //}
            //else
            //{

            //}
        }

        private void ClientCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ClientCode_tb.Text = dr["cCusCode"].ToString();
            ClientName_tb.Text = dr["cCusName"].ToString();


            this.Region_tb.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString().Substring(1, 2);
            this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.Region_tb.BaoBtnCaption + "'");
            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.Region_tb.BaoBtnCaption);
        }

        private void SellClient_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            SellClient_tb.Text = dr["cCusName"].ToString();
        }

        private void MainType_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            MainType_be.Text = dr["cInvName"].ToString();
        }

        private void MonitorType_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            MonitorType_tb.Text = dr["cInvStd"].ToString();
        }

        private void Manager_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            Manager_be.Text = dr["userid"].ToString();
        }

        private void InsManagercode_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

            DataRow dr = e.ReturnRow1;
            InsManagercode_be.Text = dr["userid"].ToString();
            InsMangerName_tb.Text = dr["username"].ToString();
        }

        public void Check004()
        {
            string mesg = string.Empty;

            int dd = 0;
            //float ff = 0;
            if (!int.TryParse(this.RepairMonth.Text, out dd))
            {
                mesg += "[保修周期：请输入数字]";
            }
            mesg += CheckIsNull(this.InsPhone_tb.Text, "装机人联系电话不能为空");
            mesg += CheckIsNull(this.ClientCode_tb.Text, "客户不能为空");
            mesg += CheckIsNull(this.SellClient_tb.Text, "销售代理店不能为空");
            mesg += CheckIsNull(this.InsConnect_tb.Text, "装机人联系不能为空");
            mesg += CheckIsNull(this.Region_tb.Text, "区域不能为空");
            mesg += CheckIsNull(this.Adress_tb.Text, "地址不能为空");

            if ((this.gridControl1.DataSource as DataTable).Rows.Count == 0)
            {
                mesg += "[任务配件明细，不能为空]";
            }
            else
            {

                DataTable dt = this.gridControl1.DataSource as DataTable;

                dt.AcceptChanges();
                //不能输入空的存货
                foreach (DataRow item in dt.Rows)
                {
                    if (item["aAccCode"].ToString() == string.Empty)
                    {
                        mesg += "[配件明细列表，配件编号不能为空]";
                    }
                }
                
            }

            if (CB_installtype.Text == "主机安装")
            {
                mesg += CheckIsNull(this.MainType_be.Text, "主机型号不能为空");
                mesg += CheckIsNull(this.MonitorType_tb.Text, "显示器型号不能为空");
            }
            else if (CB_installtype.Text == "选配件安装")
            {

            }
            else
            {
                mesg += "[请选择安装类型]";
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

        public void Check003()
        {
            string mesg = string.Empty;
            System.Text.RegularExpressions.Regex reg1 = new Regex("^[0-9]*$");

            string cmankerCheckMsg = string.Empty;

            foreach (DataRow item in (this.gridControl1.DataSource as DataTable).Rows)
            {
                if (item["aMakeCode"].ToString() == string.Empty)
                {
                    cmankerCheckMsg = "注意，发现配件明细列表里面的制造编号未填";
                }
            }
            if (!(cmankerCheckMsg == string.Empty))
            {
                System.Windows.Forms.MessageBox.Show(cmankerCheckMsg);
            }
            //if (DTP_assignDate.Value > DTP_yanshou.Value)
            //{
            //    mesg += "验收日期不能小于指派工程师完成日期";
            //}
            if (CB_installtype.Text == "主机安装")
            {
                mesg += CheckIsNull(this.MonitorMake_tb.Text, "监视器制造编号不能为空");
                mesg += CheckIsNull(this.MainMake_tb.Text, "主机编号不能为空");
                mesg += CheckIsNull(this.InsFeedBack_tb.Text, "安装情况反馈不能为空");

                    ////主机编号是否是数字
                    //if(!reg1.IsMatch(this.MainMake_tb.Text))
                    //{
                    //    mesg += "【主机编号必须是数字】";
                    //}
                    ////显示器编号是否是数字
                    //if (!reg1.IsMatch(this.MonitorMake_tb.Text))
                    //{
                    //    mesg += "【显示器编号必须是数字】";
                    //}
               
            }
            else if (CB_installtype.Text == "选配件安装")
            {
                mesg += CheckIsNull(this.Maintypetask_tb.Text, "主机型号不能为空");
                //主机版本是否是数字
                if (!reg1.IsMatch(this.MainVersion_tb.Text))
                {
                    mesg += "【主机版本必须是数字】";
                }
            }
            if ((this.gridControl2.DataSource as DataTable).Rows.Count == 0)
            {
                mesg += "安装情况反馈表体明细，不能为空";
            }
            else
            {
                //验证“安装完成结束日期”必须大于“安装开始日期”

                foreach (DataRow item in (this.gridControl2.DataSource as DataTable).Rows)
                {
                    //if (DateTime.Parse(item["rInsStart"].ToString()) > DateTime.Parse(item["rInsEnd"].ToString()))
                    //{
                    //    mesg += "[“安装完成结束日期”必须大于“安装开始日期”]";
                    //}
                }
            }
            //联系电话是否是数字
            if (!reg1.IsMatch(this.ClientCode_tb.Text))
            {
                mesg += "【联系电话必须是数字】";
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

        public string CheckIsNull(object value, string mesg)
        {
            if (value.ToString() == string.Empty)
            {
                return "[" + mesg + "]" + "\n";
            }
            else
            {
                return string.Empty;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.gridView2.CloseEditor();
            this.gridView2.UpdateCurrentRow();

            this.gridView3.CloseEditor();
            this.gridView3.UpdateCurrentRow();

            try
            {
                string sql = "";
                //状态
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                //是否 《销售》 角色
                if (UserRole.Contains("004"))
                {
                    Check004();
                    if (DTInstalltask.Rows.Count == 0 || TaskCode_tb.Text == "")
                    {
                        if (addsave == true)
                        {
                            if (CB_installtype.Text == "主机安装")
                            {
                                TaskCode_tb.Text = RiLiGlobal.GetCode.GetInsCode();//主机安装
                            }
                            if (CB_installtype.Text == "选配件安装")
                            {
                                TaskCode_tb.Text = RiLiGlobal.GetCode.GetOPCode();//配件安装
                            }

                            if (CB_installtype.Text == "主机安装")
                            {
                                TaskCode_tb.Text = RiLiGlobal.GetCode.GetInsCode();
                            }
                            else if (CB_installtype.Text == "选配件安装")
                            {
                                TaskCode_tb.Text = RiLiGlobal.GetCode.GetOPCode();
                            }
                            sql = @"insert into InstallTask(tID,tInsCode,tCusCode,tCusName,
                                        tComName,tComPhone,tAgeStore,
                                        tAgePerson,tRegName,tAddress,
                                        tMaiCode,tMonCode,tRepMonth,
                                        tSendTime,tInsType,tSummary,
                                        tManger,tTaskStart,tStartPerson,tState,tRegCode,City) values(NEWID(),'"
                                 + TaskCode_tb.Text + "','" + ClientCode_tb.Text + "','" + ClientName_tb.Text + "'"
                                 + ",'" + InsConnect_tb.Text + "','" + InsPhone_tb.Text + "','" + SellClient_tb.Text + "','"
                                 + SellManager_tb.Text + "','" + this.ZoneName.Text + "'" + ",'" + Adress_tb.Text + "','"
                                 + MainType_be.Text + "','" + MonitorType_tb.Text + "','" + Convert.ToInt32(RepairMonth.Text)
                                 + "','" + DTP_Send.Value + "'" + ",'" + CB_installtype.Text + "','" + Summary_tb.Text + "','"
                                 + Manager_be.Text + "','" + DTP_TaskStart.Text + "','" + autoUserID + "','新任务','"+this.Region_tb.Text+"','"+this.City.Text+"')";
                            foreach (DataRow dr in DTInsaccessory.Rows)
                            {  //发起任务明细 
                                sql += "insert into InsAccessory(aID,aTaskCode,aAccCode,aAccName,aAccStd,aMakeCode,aSummary) values(NEWID(),'" + TaskCode_tb.Text + "','" + dr["aAccCode"].ToString() + "','"
                                    + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','" + dr["aMakeCode"].ToString() + "','" + dr["aSummary"].ToString() + "')";
                            }
                        }
                    }
                    else if (DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                    {
                        sql = "update InstallTask set tCusCode='" + ClientCode_tb.Text + "',tCusName='" + ClientName_tb.Text + "',tComName='" + InsConnect_tb.Text + "',tComPhone='" + InsPhone_tb.Text + "',"
                        + "tAgeStore='" + SellClient_tb.Text + "',tAgePerson='" + SellManager_tb.Text + "',tRegCode='" + Region_tb.Text + "',City='" + City.Text + "',tRegName='" + this.ZoneName.Text + "',tAddress='" + Adress_tb.Text + "',tMaiCode='" + MainType_be.Text + "'"
                        + ",tMonCode='" + MonitorType_tb.Text + "',tRepMonth='" + Convert.ToInt32(RepairMonth.Text) + "',tSendTime='" + DTP_Send.Value + "',tSummary='" + Summary_tb.Text + "',tManger='" + Manager_be.Text + "',tTaskStart='" + DTP_TaskStart.Text + "' where tInsCode='" + TaskCode_tb.Text + "'";//完善
                        sql += "delete InsAccessory where aTaskCode='" + TaskCode_tb.Text + "'";
                        foreach (DataRow dr in DTInsaccessory.Rows)
                        {
                            sql += "insert into InsAccessory(aID,aTaskCode,aAccCode,aAccName,aAccStd,aMakeCode,aSummary) values(NEWID(),'" + TaskCode_tb.Text + "','" + dr["aAccCode"].ToString() + "','"
                                                                 + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','" + dr["aMakeCode"].ToString() + "','" + dr["aSummary"].ToString() + "')";
                        }
                    }
                }
                //是否 《部长角色》 角色
                if (UserRole.Contains("009") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                {
                    sql += "update InstallTask set InstallManagerCode='" + this.InstallManagerCode.Text + "',InstallManagerName='" + InstallManagerName.Text + "',AsignInstallManagerDate='" + AsignInstallManagerDate.Text + "',InstallUnit1 = '" + InstallUnit1.Text + "',InstallUnit2 = '" + InstallUnit2.Text + "',MachineLevel ='" + MachineLevel.Text + "',Color ='" + Color.Text + "' where tInsCode='" + TaskCode_tb.Text + "'";
                }
                //是否 《客服经理》 角色
                if (UserRole.Contains("002") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    sql += "update InstallTask set tInsManger='" + InsManagercode_be.Text + "',tInsMangerName='" + InsMangerName_tb.Text + "',tTaskAsign='" + DTP_assignDate.Text + "' where tInsCode='" + TaskCode_tb.Text + "'";
                }
                //是否 《工程师》 角色
                if (UserRole.Contains("003") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派")
                {
                    Check003();
                    sql += " delete InsFeedback where fTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " delete InsDetail where rTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " delete InsAccessory where aTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " insert into InsFeedback(fID,fTaskCode,fPostCode,fCliManger,fCliPhone,fMainMake,fMonMake,fEndTime,fMainVersion,fSoftVersion,fFeed,fsummary,finput,fMainType)"
                    + "values(NEWID(),'" + TaskCode_tb.Text + "','" + PostCode_tb.Text + "','" + ClientManager_tb.Text + "','" + ClientPhone_tb.Text + "','" + MainMake_tb.Text + "','" + MonitorMake_tb.Text + "'"
                    + ",'" + DTP_yanshou.Value + "','" + MainVersion_tb.Text + "','" + RTB_softversion.Text + "','" + InsFeedBack_tb.Text + "','" + FeedBackSummary_tb.Text + "','" + DTP_fendtime.Text + "','" + Maintypetask_tb.Text + "');";

                    foreach (DataRow dr in DTInsdetail.Rows)
                    {
                        sql += " insert into InsDetail(rID,rTaskCode,rInsName,rInsStart,rInsEnd,rInsSummary,rInsPersionCode) values(NEWID(),'"
                            + TaskCode_tb.Text + "','" + dr["rInsName"].ToString() + "','" + dr["rInsStart"].ToString() + "'"
                        + ",'" + dr["rInsEnd"].ToString() + "','" + dr["rInsSummary"].ToString() + "','" + dr["rInsPersionCode"].ToString() + "');";
                    }
                    foreach (DataRow dr in DTInsaccessory.Rows)
                    {  //发起任务明细 
                        sql += " insert into InsAccessory(aID,aTaskCode,aAccCode,aAccName,aAccStd,aMakeCode,aSummary) values(NEWID(),'" + TaskCode_tb.Text + "','" + dr["aAccCode"].ToString() + "','"
                            + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','" + dr["aMakeCode"].ToString() + "','" + dr["aSummary"].ToString() + "');";
                    }

                   
                }

                if (sql != "")
                {
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    if (addsave == true)
                    {   //增加最大单据号
                        if (CB_installtype.Text == "主机安装")
                        {
                            RiLiGlobal.GetCode.SetInsCode();
                        }
                        else if (CB_installtype.Text == "选配件安装")
                        {
                            RiLiGlobal.GetCode.SetOPCode();
                        }
                    }
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("该单据不是最新状态，保存失败！");
                }
                TaskInite(TaskCode_tb.Text);//刷新
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void insdetailitem_add_Click(object sender, EventArgs e)
        {
            System.Data.DataRow row1 = this.DTInsdetail.NewRow();
            this.DTInsdetail.Rows.Add(row1);
        }

        private void insdetailitem_del_Click(object sender, EventArgs e)
        {
            if (this.gridView3.FocusedRowHandle >= 0)
            {
                this.gridView3.DeleteSelectedRows();
                //int i = this.gridView3.FocusedRowHandle;
                //DataRow dss = DTInsdetail.Rows[i];
                //DTInsdetail.Rows.Remove(dss);
            }
        }

        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModify_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            BtnModify.Enabled = false;
            BtnRefresh.Enabled = false;
            BtnAudit.Enabled = false;
            BtnCheck.Enabled = false;
            BtnDelete.Enabled = false;
            BtnFileAdd.Enabled = false;
            BtnSearch.Enabled = false;
            BtnOutexcel.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + this.TaskCode_tb.Text + "'");
            if (UserRole == "")
            {
                return;
            }
            if (UserRole.Contains("004"))
            {   //销售
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                {
                    BtnCancel.Enabled = true;
                    BtnSave.Enabled = true;
                    addsave = false;
                    CB_installtype.Enabled = false;//安装类型
                    BtnItemAdd.Enabled = true;
                    BtnItemDel.Enabled = true;

                    ClientName_tb.ReadOnly = false;
                    InsConnect_tb.ReadOnly = false;
                    InsPhone_tb.ReadOnly = false;
                    SellManager_tb.ReadOnly = false;
                    Adress_tb.ReadOnly = false;
                    RepairMonth.ReadOnly = false;
                    Summary_tb.ReadOnly = false;

                    ClientCode_tb.Enabled = true;
                    SellClient_tb.Enabled = true;
                    Region_tb.Enabled = true;

                    DTP_Send.Enabled = true;
                    Manager_be.Enabled = true;
                    DTP_TaskStart.Enabled = true;
                    button1.Enabled = true;

                    if (CB_installtype.Text == "选配件安装")
                    {
                        MainType_be.Enabled = false;
                        MonitorType_tb.Enabled = false;
                    }
                    else
                    {
                        MainType_be.Enabled = true;
                        MonitorType_tb.Enabled = true;
                    }
                    //发起任务明细
                    this.gridView2.OptionsBehavior.Editable = true;
                    //修改
                    BtnModify.Enabled = false;
                    //删除
                    BtnDelete.Enabled = false;
                    //审核
                    BtnAudit.Enabled = false;
                    //核对
                    BtnCheck.Enabled = false;
                    //定位
                    BtnSearch.Enabled = false;
                    //上传
                    BtnFileAdd.Enabled = false;
                    //导出
                    BtnOutexcel.Enabled = false;
                }
                else if (!UserRole.Contains("002") && !UserRole.Contains("003"))
                {
                    System.Windows.Forms.MessageBox.Show("已经提交给客服经理，不能修改");
                    return;
                }
            }
            if (UserRole.Contains("009"))
            {   //部长
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                {
                    BtnSave.Enabled = true;
                    addsave = false;
                    BtnCancel.Enabled = true;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                    this.InstallManagerCode.Enabled = true;
                    this.InstallManagerName.Enabled = true;
                    this.InstallUnit1.Enabled = true;
                    this.InstallUnit2.Enabled = true;
                    this.MachineLevel.Enabled = true;
                    this.Color.Enabled = true;
                }
                //else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求" && !UserRole.Contains("003"))
                //{
                //    System.Windows.Forms.MessageBox.Show("已经提交指派科长，不能修改，要修改，请收回");
                //    return;
                //}
            }
            if (UserRole.Contains("002"))
            {   //客服经理
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求" && DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    BtnSave.Enabled = true;
                    addsave = false;
                    BtnCancel.Enabled = true;
                    InsManagercode_be.Enabled = true;
                    DTP_assignDate.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派" && !UserRole.Contains("003"))
                {
                    System.Windows.Forms.MessageBox.Show("已经提交指派工程师，不能修改，要修改，请收回");
                    return;
                }
                else
                {
                    BtnSave.Enabled = true;
                    addsave = false;
                    BtnCancel.Enabled = true;
               
                }
            }
            if (UserRole.Contains("003"))
            {   // 工程师	
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派" && DTInstalltask.Rows[0]["tInsManger"].ToString() == autoUserID)
                {
                    BtnSave.Enabled = true;
                    addsave = false;
                    insdetailitem_add.Enabled = true;
                    insdetailitem_del.Enabled = true;
                    BtnCancel.Enabled = true;
                    this.gridView3.OptionsBehavior.Editable = true;
                    this.gridView2.OptionsBehavior.Editable = true;
                    gridColumn1.OptionsColumn.AllowEdit = false;
                    gridColumn2.OptionsColumn.AllowEdit = false;
                    gridColumn9.OptionsColumn.AllowEdit = false;

                    PostCode_tb.ReadOnly = false;
                    ClientManager_tb.ReadOnly = false;
                    ClientPhone_tb.ReadOnly = false;
                    DTP_yanshou.Enabled = true;
                    DTP_fendtime.Enabled = true;
                    MainMake_tb.ReadOnly = false;
                    RTB_softversion.ReadOnly = false;
                    InsFeedBack_tb.ReadOnly = false;
                    FeedBackSummary_tb.ReadOnly = false;

                 

                    if (CB_installtype.Text == "选配件安装")
                    {
                        MonitorMake_tb.ReadOnly = true;//监视器制造编号
                        MainVersion_tb.ReadOnly = false;//主机版本
                        Maintypetask_tb.Enabled = true;//主机型号
                         MainType_be.Enabled = false;

                        MonitorType_tb.Enabled = false;

                        MainVersion_tb.Enabled = false;

                        //Maintypetask_tb.Enabled = true;

                        RTB_softversion.Enabled = false;
                    }
                    else
                    {
                        MonitorMake_tb.ReadOnly = false;//监视器制造编号
                        MainVersion_tb.ReadOnly = false;//主机版本
                        Maintypetask_tb.Enabled = false;//主机型号
                        MainType_be.Enabled = false;


                        Maintypetask_tb.Enabled = false;
                        //MainType_be.Enabled = true;

                        //MonitorType_tb.Enabled = true;

                        //MainVersion_tb.Enabled = true;


                        //RTB_softversion.Enabled = true;


                    }
                    if (DTInstalltask.Rows[0]["tAuditMessageId"].ToString() == "" && DTInstalltask.Rows[0]["tAuditMessagedate"].ToString() != "")
                    {   //tAuditMessageId：审核人 tAuditMessagedate：审核日期（客服经理）
                        MessageBox.Show("此单据已经收回，不可以修改任务反馈！");
                        insdetailitem_add.Enabled = false;
                        insdetailitem_del.Enabled = false;

                        PostCode_tb.ReadOnly = true;
                        ClientManager_tb.ReadOnly = true;
                        ClientPhone_tb.ReadOnly = true;
                        DTP_yanshou.Enabled = false;
                        DTP_fendtime.Enabled = false;
                        MainMake_tb.ReadOnly = true;
                        MonitorMake_tb.ReadOnly = true;
                        MainVersion_tb.ReadOnly = true;
                        Maintypetask_tb.Enabled = false;
                        RTB_softversion.ReadOnly = true;
                        InsFeedBack_tb.ReadOnly = true;
                        FeedBackSummary_tb.ReadOnly = true;
                        button3.Enabled = false;
                    }
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核")
                {
                    System.Windows.Forms.MessageBox.Show("修改失败，单据已经提交经理审核,如要修改，请收回");
                    return;
                }
            }
            if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已审核")
            {
                MessageBox.Show("单据已经审核，不可以修改！");
                PostCode_tb.ReadOnly = true;
                ClientManager_tb.ReadOnly = true;
                ClientPhone_tb.ReadOnly = true;
                DTP_yanshou.Enabled = false;
                DTP_fendtime.Enabled = false;
                MainMake_tb.ReadOnly = true;
                MonitorMake_tb.ReadOnly = true;
                MainVersion_tb.ReadOnly = true;
                Maintypetask_tb.Enabled = false;
                RTB_softversion.ReadOnly = true;
                InsFeedBack_tb.ReadOnly = true;
                FeedBackSummary_tb.ReadOnly = true;
            }
            #region
            /**
            if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() != "")
            {
                MessageBox.Show("单据已经审核，不可以修改！");
                PostCode_tb.ReadOnly = true;
                ClientManager_tb.ReadOnly = true;
                ClientPhone_tb.ReadOnly = true;
                DTP_yanshou.Enabled = false;
                DTP_fendtime.Enabled = false;
                MainMake_tb.ReadOnly = true;
                MonitorMake_tb.ReadOnly = true;
                MainVersion_tb.ReadOnly = true;
                Maintypetask_tb.Enabled = false;
                RTB_softversion.ReadOnly = true;
                InsFeedBack_tb.ReadOnly = true;
                FeedBackSummary_tb.ReadOnly = true;
            }
            **/
            #endregion

        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.baoButton1.button1_Click(sender, e);

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要取消当前的修改吗？", "取消信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                if (addsave == true)
                {
                    DTInsaccessory.Clear();
                    DTInsdetail.Clear();
                    DTInstalltask.Clear();
                    DTInsfeedback.Clear();
                    TaskInite("");
                }
                else
                {
                    TaskInite(TaskCode_tb.Text);
                }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除当前单据吗？", "删除信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            string sql = "";
            if (result == DialogResult.OK)
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");

                if (DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                {
                    sql = "delete InsAccessory where aTaskCode='" + TaskCode_tb.Text + "'";
                    sql += "delete InstallTask where tInsCode='" + TaskCode_tb.Text + "'";
                    try
                    {
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        DTInsaccessory.Clear();
                        DTInsdetail.Clear();
                        DTInstalltask.Clear();
                        DTInsfeedback.Clear();
                        //ButtonInitState(UserRole);
                        TaskInite("");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                   
                }
                else
                {
                    MessageBox.Show("当前单据已经处理，不可以删除");
                }
            }

        }

        private void BtnOutexcel_Click(object sender, EventArgs e)
        {
            try
            {
                //RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\安装登记表.xls");
                //ex.SetCellValue(4, 3, Adress_tb.Text);
                //ex.SetCellValue(3, 3, ClientName_tb.Text);
                //ex.SetCellValue(4, 10, PostCode_tb.Text);
                //ex.SetCellValue(5, 3, ClientManager_tb.Text);
                //ex.SetCellValue(5, 10, ClientPhone_tb.Text);
                //ex.SetCellValue(6, 3, SellClient_tb.Text);
                //ex.SetCellValue(6, 10, SellManager_tb.Text);
                //ex.SetCellValue(7, 3, InsMangerName_tb.Text);


                //if (DTInsdetail.Rows.Count > 0)
                //{
                //    ex.SetCellValue(8, 3, DTInsdetail.Rows[0]["rInsName"].ToString());
                //    ex.SetCellValue(9, 4, DTInsdetail.Rows[0]["rInsStart"].ToString());
                //    ex.SetCellValue(9, 11, DTInsdetail.Rows[0]["rInsEnd"].ToString());
                //}
                //ex.SetCellValue(11, 3, MainType_be.Text);
                //ex.SetCellValue(11, 6, RTB_softversion.Text);
                //ex.SetCellValue(11, 11, MainMake_tb.Text);
                //ex.SetCellValue(12, 3, MonitorType_tb.Text);
                //ex.SetCellValue(12, 9, MonitorMake_tb.Text);
                //ex.SetCellValue(21, 1, FeedBackSummary_tb.Text);
                //int count = DTInsaccessory.Rows.Count;
                //// int k=count/2;
                //if (count > 0)
                //{
                //    for (int i = 0; i < count; i++)
                //    {
                //        if (i < 5)
                //        {
                //            ex.SetCellValue(14 + i, 2, DTInsaccessory.Rows[i]["aMakeCode"].ToString());
                //            ex.SetCellValue(14 + i, 4, DTInsaccessory.Rows[i]["aAccCode"].ToString());
                //        }
                //        else
                //        {
                //            ex.SetCellValue(14 + i - 5, 7, DTInsaccessory.Rows[i]["aMakeCode"].ToString());
                //            ex.SetCellValue(14 + i - 5, 11, DTInsaccessory.Rows[i]["aAccCode"].ToString());

                //        }
                //    }
                //}
                //this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";


                //if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                //{
                //    ex.Save(saveFileDialog1.FileName);
                //    ex.CloseExcel();
                //    MessageBox.Show("单据导出成功！");
                //}



                //RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\安装登记表.xls");
                //ex.SetCellValue(4, 3, Adress_tb.Text);
                //ex.SetCellValue(3, 3, ClientName_tb.Text);
                //ex.SetCellValue(4, 10, PostCode_tb.Text);
                //ex.SetCellValue(5, 3, ClientManager_tb.Text);
                //ex.SetCellValue(5, 10, ClientPhone_tb.Text);
                //ex.SetCellValue(6, 3, SellClient_tb.Text);
                //ex.SetCellValue(6, 10, SellManager_tb.Text);
                //ex.SetCellValue(7, 3, InsMangerName_tb.Text);

                RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\安装登记表.xls");
                ex.SetCellValue(6, 8, Adress_tb.Text);
                ex.SetCellValue(5, 8, ClientName_tb.Text);
                ex.SetCellValue(7, 45, PostCode_tb.Text);
                ex.SetCellValue(8, 8, ClientManager_tb.Text);
                ex.SetCellValue(7, 27, ClientPhone_tb.Text);
                ex.SetCellValue(8, 8, SellClient_tb.Text);
                ex.SetCellValue(8, 45, SellManager_tb.Text);
                ex.SetCellValue(9, 8, InsMangerName_tb.Text);
                if (DTInsdetail.Rows.Count > 0)
                {
                    ex.SetCellValue(11, 8, DTInsdetail.Rows[0]["rInsName"].ToString());
                    ex.SetCellValue(9, 27, DateTime.Parse(DTInsdetail.Rows[0]["rInsStart"].ToString()).ToShortDateString());
                    ex.SetCellValue(9, 45, DateTime.Parse(DTInsdetail.Rows[0]["rInsEnd"].ToString()).ToShortDateString());
                }
                ex.SetCellValue(11, 8, MainType_be.Text);
                ex.SetCellValue(11, 45, MainVersion_tb.Text);
                ex.SetCellValue(11, 26, MainMake_tb.Text);
                ex.SetCellValue(12, 8, MonitorType_tb.Text);
                ex.SetCellValue(12, 26, MonitorMake_tb.Text);
                ex.SetCellValue(21, 5, FeedBackSummary_tb.Text);
                int count = DTInsaccessory.Rows.Count;
                // int k=count/2;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (i < 9)
                        {
                            ex.SetCellValue(15 + i, 3, DTInsaccessory.Rows[i]["aAccStd"].ToString());
                            ex.SetCellValue(15 + i, 11, DTInsaccessory.Rows[i]["aMakeCode"].ToString());
                        }
                        else
                        {
                            ex.SetCellValue(15 + i-9 , 29, DTInsaccessory.Rows[i]["aAccStd"].ToString());
                            ex.SetCellValue(15 + i-9 , 37, DTInsaccessory.Rows[i]["aMakeCode"].ToString());
                        }
                    }
                }
                this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";


                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    ex.Save(saveFileDialog1.FileName);
                    ex.CloseExcel();
                    MessageBox.Show("单据导出成功！");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void BtnFileAdd_Click(object sender, EventArgs e)
        {

            FJupload fj1 = new FJupload(TaskCode_tb.Text, autoUserID);//autoUserID:用户ID
            fj1.StartPosition = FormStartPosition.CenterScreen;
            fj1.ShowDialog(this);
        }


        #region IU8Contral 成员

        public void Authorization()
        {

        }

        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //如果保存按钮为不激活或者保存按钮激活但是用户确定放弃保存，则退出当前界面
            if ((this.BtnSave.Enabled == false) || (this.BtnSave.Enabled == true &&
                MessageBox.Show("是否放弃保存当前数据？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("004"))
            {
                MessageBox.Show("您没有权限");
                return;
            }
            if (this.BtnSave.Enabled)
            {
                MessageBox.Show("请保存再操作");
                return;
            }
            if (button1.Text == "提交")
            {
                try
                {
                    string sql = "update InstallTask set tMessagedate = getDate(),tMessageId='" + autoUserID + "',tState = '已指派科长' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    this.DTP_TaskStart.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                    Bao.Message.CMessage.SendMessage("指派任务", "新的安装任务到了，请指定安装工程师", Manager_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    //button1.Text = "收回";
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("成功提交部长指派任务");




                    string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + Manager_be.Text + "'");

                    // string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务", "医院：" + DTInstalltask.Rows[0]["tCusName"].ToString() + "指派人：" + UFBaseLib.BusLib.BaseInfo.UserName, false, 2);


                    string op = "<br/>配件列表：";


                    foreach (DataRow item in DTInsaccessory.Rows)
                    {
                        op = op + "<br/>" + "规格型号：" + item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString();
                    }

                    string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString() + op, true, 2);

                    System.Windows.Forms.MessageBox.Show(mailmsg);

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else //收回
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select tState from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                {
                    try
                    {
                        string sql = "update InstallTask set tMessageId='',tState = '新任务' where tInsCode='" + TaskCode_tb.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        Bao.Message.CMessage.SendMessage("指派消息收回！", "此指派任务已经收回，请您注意！", Manager_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                        TaskInite(TaskCode_tb.Text);
                        //button1.Text = "提交";
                        MessageBox.Show("成功收回！");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else
                {
                    MessageBox.Show("部长已经指派科长，不可以收回！");
                }
            }
        }

        /// <summary>
        /// 客服经理 提交或收回
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BtnSave.Enabled)
            {
                MessageBox.Show("请保存再操作");
                return;
            }
            try
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在！");
                    return;
                }
                if (!(DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
                {   //客服经理
                    MessageBox.Show("您没有权限");
                    return;
                }
                if (button2.Text == "提交")
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                    {
                        MessageBox.Show("该单据已经被销售收回，提交失败！");
                        return;
                    }
                    if (InsManagercode_be.Text == string.Empty)
                    {
                        MessageBox.Show("请指派工程师再提交");
                        return;
                    }
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "安装请求")
                    {
                        MessageBox.Show("该单据，指派科长的流程被收回，无法提交");
                        return;
                    }
                    string sql = "update InstallTask set tAuditMessagedate=getDate(),tAuditMessageId='" + autoUserID + "',tState = '已指派' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);

                    this.DTP_assignDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                    Bao.Message.CMessage.SendMessage("新任务", "新的安装任务由您负责，请填写任务反馈！", InsManagercode_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    //button2.Text = "收回";
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("成功提交工程师安装");

                    string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + InsManagercode_be.Text + "'");

                   // string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务", "医院：" + DTInstalltask.Rows[0]["tCusName"].ToString() + "指派人：" + UFBaseLib.BusLib.BaseInfo.UserName, false, 2);


                    string op = "<br/>配件列表：";

                
                    foreach (DataRow item in DTInsaccessory.Rows)
                    {
                        op = op + "<br/>" + "规格型号："+item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString();
                    }
                  
                    string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString()+ op, true, 2);

                    System.Windows.Forms.MessageBox.Show(mailmsg);
                }
                else //收回
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已指派")
                    {
                        MessageBox.Show("该单据不是已指派状态，不可以收回！");
                        return;
                    }
                    if (MessageBox.Show("是否收回当前单据？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return;
                    }
                    DialogResult result = DialogResult.No;
                    if (ClientManager_tb.Text != "" || DTInsdetail.Rows.Count > 0)
                    {
                        result = MessageBox.Show("收回时是否清空工程师反馈的信息？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    }
                    string sql = string.Empty;
                    if (result == DialogResult.Yes)
                    {
                        sql += "delete InsFeedback where fTaskCode='" + TaskCode_tb.Text + "';";
                        sql += "delete InsDetail where rTaskCode='" + TaskCode_tb.Text + "';";
                        sql += " update InstallTask set tAuditMessageId='',tState = '安装请求' where tInsCode='" + TaskCode_tb.Text + "';";
                    }
                    else
                    {
                        sql = " update InstallTask set tAuditMessageId='',tState = '安装请求' where tInsCode='" + TaskCode_tb.Text + "'";
                    }

                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    Bao.Message.CMessage.SendMessage("指派工程师收回！", "此指派任务已经收回，请您注意！", InsManagercode_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("成功收回！");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 工程师反馈
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.BtnSave.Enabled)
            {
                MessageBox.Show("请保存再操作");
                return;
            }
            try
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select tInsManger,tState from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在！");
                    return;
                }
                if (!(DTInstalltask.Rows[0]["tInsManger"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
                {
                    MessageBox.Show("您没有权限");
                    return;
                }
                if (button3.Text == "提交")
                {
                    Check003();
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已指派")
                    {
                        MessageBox.Show("该单据不是已指派状态，提交失败！");
                        return;
                    }
                    //if (DTInstalltask.Rows[0]["tAccType"].ToString() == string.Empty)
                    //{
                    //    MessageBox.Show("附件未上传，不能提交");
                    //    return;
                    //}
                    this.DTP_fendtime.Text =  RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                    string sql = "update InstallTask  set fMessagedate=getDate(),fMessageId='" + autoUserID + "',tState = '待审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    Bao.Message.CMessage.SendMessage("审核任务", "安装任务已经反馈，请您审核", InstallManagerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    TaskInite(TaskCode_tb.Text);
                    MessageBox.Show("成功提交客服经理审核");
                }
                else
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "待审核")
                    {
                        MessageBox.Show("该单据不是待审核状态，收回失败！");
                        return;
                    }
                    string sql = "update InstallTask set fMessageId='',tState = '已指派' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    Bao.Message.CMessage.SendMessage("审核任务收回", "审核任务已经收回，请您注意！", InstallManagerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    //MessageBox.Show("成功收回！");
                    TaskInite(TaskCode_tb.Text);
                    button3.Text = "提交";
                    MessageBox.Show("成功收回");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void Maintypetask_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            Maintypetask_tb.Text = dr["cInvStd"].ToString();
        }

        private void Region_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 刷新事件
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TaskInite(TaskCode_tb.Text);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void InstallPerson_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            int i = this.gridView3.FocusedRowHandle;
          

            this.gridView3.SetRowCellValue(i, "rInsName", dr["username"].ToString());
            this.gridView3.SetRowCellValue(i, "rInsPersionCode", dr["userid"].ToString());
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select InstallTask.* from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                MessageBox.Show("您没有权限");
                return;
            }
            if (this.BtnSave.Enabled)
            {
                MessageBox.Show("请保存再操作");
                return;
            }
            if (button4.Text == "提交")
            {
                try
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                    {

                        if (this.InstallManagerCode.Text == string.Empty)
                        {
                            MessageBox.Show("请填写指派科长");
                            return;
                        }
                        string sql = "update InstallTask set AsignInstallManagerDate = getDate(),InstallManagerCode='" + this.InstallManagerCode.Text + "',InstallManagerName='" + this.InstallManagerName.Text + "',tState = '安装请求' where tInsCode='" + TaskCode_tb.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        this.AsignInstallManagerDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                        Bao.Message.CMessage.SendMessage("指派任务", "新的安装任务到了，请指定安装工程师", this.InstallManagerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                        //button1.Text = "收回";
                        TaskInite(TaskCode_tb.Text);
                        MessageBox.Show("成功提交科长指派任务");



                        string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + this.InstallManagerCode.Text + "'");

                        // string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务", "医院：" + DTInstalltask.Rows[0]["tCusName"].ToString() + "指派人：" + UFBaseLib.BusLib.BaseInfo.UserName, false, 2);


                        string op = "<br/>配件列表：";


                        foreach (DataRow item in DTInsaccessory.Rows)
                        {
                            op = op + "<br/>" + "规格型号：" + item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString();
                        }

                        string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString() + op, true, 2);

                        System.Windows.Forms.MessageBox.Show(mailmsg);
                        
                    }
                    else
                    {
                        MessageBox.Show("任务被销售管理部收回，无法指派客服经理");
                        return;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else //收回
            {
                DTInstalltask = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select tState from InstallTask where tInsCode='" + TaskCode_tb.Text + "'");
                if (DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    try
                    {
                        string sql = "update InstallTask set tMessageId='',InstallUnit2 = null,InstallUnit1 = null,MachineLevel = null,Color = null,tState = '已指派科长' where tInsCode='" + TaskCode_tb.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);

                        Bao.Message.CMessage.SendMessage("指派消息收回！", "此指派任务已经收回，请您注意！", this.InstallManagerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                        TaskInite(TaskCode_tb.Text);
                        //button1.Text = "提交";
                        MessageBox.Show("成功收回！");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else
                {
                    MessageBox.Show("客服经理已经指派工程师，不可以收回！");
                }
            }
        }

        private void InstallManagerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
           // Manager_be.Text = dr["userid"].ToString();

            this.InstallManagerCode.Text = dr["userid"].ToString();
            this.InstallManagerName.Text = dr["username"].ToString();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void RTB_softversion_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(RTB_softversion.Text, this.RTB_softversion);
        }

        private void InsFeedBack_tb_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(InsFeedBack_tb.Text, this.InsFeedBack_tb);
        }
    }
}
