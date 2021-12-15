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
        public System.Data.DataTable DTSaledetail;

        public string UserRole;//存储用户的角色，销售，客服经理、工程师
        public string autoUserID = "candy";
        private bool addsave = false;
        public UserControl1()
        {            
            InitializeComponent();
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            RiLiDataBaseName = iniobj.read("database", "database", "");
            //  U8Global.IniProcess u8obj = new U8Global.IniProcess(U8Global.IniProcess.AppPath);
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
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
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
            autoUserID = UFBaseLib.BusLib.BaseInfo.DBUserID;
            GetUserRole(autoUserID);
            Frm_Init();//制件初始化
            TaskInite(taskid);
        }

        public void GetUserRole(string UserID)//获取角色
        {
            UserRole = UFBaseLib.BusLib.BaseInfo.userRole;
        }

        public void Frm_Init()
        {
            this.toolTip1.SetToolTip(this.RTB_softversion, this.RTB_softversion.Text);
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

            ClientCode_tb.BaoSQL = string.Format(@"select a.cCusCode,a.cCusAbbName as cCusName, c.ccCName,isnull(b.cDCName,c.ccCName) as cDCName
                                    from {0}.Customer a
                                    inner join {0}.DistrictClass b on a.cDCCode = b.cDCCode
                                    left join {0}.CustomerClass c on a.cCCCode = c.cCCCode
                                    where a.ccccode  like '2%' or a.ccccode like '1%'", U8DataBaseName);
            ClientCode_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称,ccCName=省份,cDCName=地级市";
            this.ClientCode_tb.FrmHigth = 600;
            this.ClientCode_tb.FrmWidth = 450;
            ClientCode_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_tb.BaoColumnsWidth = "cCusCode=100,cCusName=150,ccCName=80,cDCName=80";

            SellClient_tb.BaoSQL = "select cCusCode,cCusAbbName as cCusName from " + U8DataBaseName + ".Customer where ccccode   like '2%' or  ccccode like '1%'";
            SellClient_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.SellClient_tb.FrmHigth = 600;
            this.SellClient_tb.FrmWidth = 450;
            SellClient_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusName=";
            SellClient_tb.BaoColumnsWidth = "cCusCode=120,cCusName=280";

//            MainType_be.BaoSQL = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + @".Inventory 
//	                                where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21'))
//                                ";
//            MainType_be.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
//            this.MainType_be.FrmHigth = 400;
//            this.MainType_be.FrmWidth = 600;
//            MainType_be.DecideSql =  @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + @".Inventory 
//	                                where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21'))
//                                     and cInvStd=";
//            MainType_be.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            /*Maintypetask_tb.BaoSQL = @"select cInvCode,cinvdefine7 as cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + @".Inventory 
	                                where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21' or cinvcode='A100045'))
                                ";*/


            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            Maintypetask_tb.BaoSQL = String.Format(@"select cInvCode,cinvdefine7 as cInvAddCode,cInvName,cInvStd from {0}.Inventory 
                                     	                                where ( cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%' )", U8DataBaseName);



            Maintypetask_tb.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            this.Maintypetask_tb.FrmHigth = 400;
            this.Maintypetask_tb.FrmWidth = 600;

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            /*Maintypetask_tb.DecideSql = @"select cInvCode,cinvdefine7 as cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + @".Inventory 
	                                       where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21' or cinvcode='A100045')) and cInvStd=";*/

            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            Maintypetask_tb.DecideSql = @"select cInvCode,cinvdefine7 as cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + @".Inventory 
	                                       where ( cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%') and cInvStd=";


            Maintypetask_tb.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";





            //Maintypetask_tb.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%' and len(cinvcode) = 3";
            //Maintypetask_tb.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            //this.Maintypetask_tb.FrmHigth = 400;
            //this.Maintypetask_tb.FrmWidth = 600;
            //Maintypetask_tb.DecideSql = "select * from " + U8DataBaseName + ".Inventory   where cinvcode like 'A%' and len(cinvcode) = 3 and cInvStd=";
            //Maintypetask_tb.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";


            //MonitorType_tb.BaoSQL = "select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataBaseName + ".Inventory where cinvcode like 'A%'  and len(cinvcode) = 7";
            //MonitorType_tb.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
            //this.MonitorType_tb.FrmHigth = 400;
            //this.MonitorType_tb.FrmWidth = 600;
            //MonitorType_tb.DecideSql = "select * from " + U8DataBaseName + ".Inventory where  cinvcode like  'A%' and cInvStd=";
            //MonitorType_tb.BaoColumnsWidth = "cInvCode=100,cInvName=250,cInvStd=200";

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

            //InsManagercode_be.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and rt.RegionId in (select RegionId from RegionToUser where UserId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')";
            InsManagercode_be.BaoSQL = @"select c.UserId,c.userName,e.RoleName,f.deptName,bt.InstallUnit1,bt.InstallUnit2
                                        from Users a
                                        left join BaseDepartMent b on b.deptNum like a.deptNum+'%'
                                        left join Users c on b.deptNum = c.deptnum
                                        left join BaseInstallationUnitType bt on c.userid = bt.userid
                                        left join TroleUsers d on c.AutoUserId=d.AutoUserId
                                        left join TRole e on d.RoleId = e.RoleId
                                        left join BaseDepartMent f on c.deptNum=f.deptNum
                                        where a.UserId='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and e.RoleId='003'";
            InsManagercode_be.BaoTitleNames = "userid=人员编码,username=人员姓名,InstallUnit1=安装单位1,InstallUnit2=安装单位2";
            InsManagercode_be.FrmHigth = 400;
            InsManagercode_be.FrmWidth = 600;
            InsManagercode_be.DecideSql = @"select c.UserId,c.userName,e.RoleName,f.deptName,bt.InstallUnit1,bt.InstallUnit2
                                            from Users a
                                            left join BaseDepartMent b on b.deptNum like a.deptNum+'%'
                                            left join Users c on b.deptNum = c.deptnum
                                            left join BaseInstallationUnitType bt on c.userid = bt.userid
                                            left join TroleUsers d on c.AutoUserId=d.AutoUserId
                                            left join TRole e on d.RoleId = e.RoleId
                                            left join BaseDepartMent f on c.deptNum=f.deptNum
                                            where e.RoleId='003' and a.userid =";
            InsManagercode_be.BaoColumnsWidth = "userid=120,username=120,InstallUnit1=100,InstallUnit2=100";

            txtJiQiJB.BaoSQL = "select code,type,grade,model,cinvstd,productline from BaseMachineGrade";
            txtJiQiJB.BaoTitleNames = "code=编码,type=类型,grade=级别,model=型号,cinvstd=U8存货代码,productline=产品线";
            txtJiQiJB.FrmHigth = 600;
            txtJiQiJB.FrmWidth = 700;
            txtJiQiJB.DecideSql = "select code,type,grade,model,cinvstd,productline from BaseMachineGrade where code =";
            txtJiQiJB.BaoColumnsWidth = "code=80,type=120,grade=120,model=120,cinvstd=120,productline=80";
            txtJiQiJB.BaoClickClose = true;

            TaskCode_tb.ReadOnly = true;//任务编号

            Region_tb.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass";
            Region_tb.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.Region_tb.FrmHigth = 600;
            this.Region_tb.FrmWidth = 400;
            Region_tb.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass where cDCCODE=";
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
            DTInstalltask = this.GetDtInstalltask(taskcode); 
            DTInsaccessory = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsAccessory where aTaskCode='" + taskcode + "'");
            DTInsfeedback = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsFeedback where fTaskCode='" + taskcode + "'");
            DTInsdetail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsDetail where rTaskCode='" + taskcode + "' order by rInsEnd");
            DTSaledetail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from InsAccessoryOld where aTaskCode='" + taskcode + "'");

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
                //MonitorType_tb.Enabled = true;

                MainVersion_tb.Enabled = false;

                this.fSN2_tb.Enabled = false;

                DragoutMachineCode(taskcode);
                //RTB_softversion.Enabled = true;
            }
            if (CB_installtype.Text == "选配件安装")
            {
                Maintypetask_tb.Enabled = false;

                MonitorType_tb.Enabled = false;

                MainVersion_tb.Enabled = false;

                this.fSN2_tb.Enabled = false;

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
                    this.button1.Enabled = true;
                    BtnModify.Enabled = true;
                    BtnDelete.Enabled = true;

                }
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
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
                    //this.InstallUnit1.Enabled = false;
                    //this.InstallUnit2.Enabled = false;
                    //this.MachineLevel.Enabled = false;
                    //this.MachineType.Enabled = false;
                    //this.txtJiQiJB.Enabled = false;
                    //this.Color.Enabled = false;
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
                    //this.MachineType.Enabled = true;
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
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    this.button2.Enabled = true;
                    BtnModify.Enabled = true;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派")
                   //&& DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == autoUserID)
                {
                    this.button2.Enabled = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核")
                {
                    BtnAudit.Text = "审核";
                    BtnAudit.Enabled = true;
                    BtnAudit.Visible = true;
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已审核")
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
                    //this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(DTInstalltask.Rows[0]["tRegCode"].ToString());
                }
            }
        }

        /// <summary>
        /// 根据安装单号查找机器级别
        /// </summary>
        /// <param name="taskcode"></param>
        public void DragoutMachineCode(string taskcode)
        {
            //自动带出机器级别，有单号才带出
            if (taskcode == "" || DTInstalltask.Rows.Count <= 0)
                return;

            
            if ((DTInstalltask.Rows[0]["tState"].ToString() != "新任务" && DTInstalltask.Rows[0]["tState"].ToString() != "已指派"))
                return;

            string aMakeCode;
            string aAccCode;
            GetAccCode(DTInsaccessory, out aAccCode, out aMakeCode);

            if (aAccCode == string.Empty)
            {
                MachineModel.Text = string.Empty;
                MachineType.Text = string.Empty;
                MachineLevel.Text = string.Empty;
                txtMainCode.Text = string.Empty;
                txtMakecode.Text = string.Empty;
                txtJiQiJB.BaoBtnCaption = string.Empty;
                txtJiQiJB.Text = string.Empty;

                this.txtProductLine.Text = string.Empty;

                CB_installtype.Text = "选配件安装";
                DTInstalltask.Rows[0]["jqjbcode"] = string.Empty;
                DTInstalltask.Rows[0]["MachineModel"] = string.Empty;
                DTInstalltask.Rows[0]["MachineLevel"] = string.Empty;
                DTInstalltask.Rows[0]["MachineType"] = string.Empty; ;
                DTInstalltask.Rows[0]["Color"] = string.Empty;
                DTInstalltask.Rows[0]["tMaiCode"] = string.Empty;
                DTInstalltask.Rows[0]["tMakeCode"] = string.Empty; 
                return;
            }

            string sql = string.Format(@"select a.code,a.type,a.grade,a.model,a.productline,b.cInvAddCode 
                                            from BaseMachineGrade a 
                                            left join {1}.Inventory b on a.code=b.cinvcode
                                            where code = '{0}'", aAccCode, U8Global.U8DataAcc.U8ServerAndDataBase);
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            if (DTInstalltask != null && DTInstalltask.Rows.Count > 0 && dt != null && dt.Rows.Count > 0 && gridView2.RowCount > 0)
            {
                DataRow dr = dt.Rows[0];

                MachineModel.Text = dr["model"].ToString();
                MachineType.Text = dr["type"].ToString();
                MachineLevel.Text = dr["grade"].ToString();
                txtMainCode.Text = dr["cInvAddCode"].ToString();
                txtJiQiJB.BaoBtnCaption = dr["code"].ToString();
                txtJiQiJB.Text = dr["code"].ToString();

                this.txtProductLine.Text = dr["productline"].ToString();


                CB_installtype.Text = "主机安装";
                DTInstalltask.Rows[0]["jqjbcode"] = dr["code"].ToString();
                DTInstalltask.Rows[0]["MachineModel"] = dr["model"].ToString();
                DTInstalltask.Rows[0]["MachineLevel"] = dr["grade"].ToString();
                DTInstalltask.Rows[0]["MachineType"] = dr["type"].ToString(); ;
                DTInstalltask.Rows[0]["Color"] = dr["type"].ToString();
                DTInstalltask.Rows[0]["tMaiCode"] = dr["cInvAddCode"].ToString();
            }
            txtMakecode.Text = aMakeCode;
            DTInstalltask.Rows[0]["tMakeCode"] = aMakeCode; 
        }

        public void DataBinding()
        {
            TaskCode_tb.DataBindings.Add("Text", DTInstalltask, "tInsCode");
            txtBillDate.DataBindings.Add("Text", DTInstalltask, "billDate");
            txtInitDep.DataBindings.Add("Text", DTInstalltask, "Dept");
            ClientCode_tb.DataBindings.Add("Text", DTInstalltask, "tCusCode");
            ClientName_tb.DataBindings.Add("Text", DTInstalltask, "tCusName");
            InsConnect_tb.DataBindings.Add("Text", DTInstalltask, "tComName");
            InsPhone_tb.DataBindings.Add("Text", DTInstalltask, "tComPhone");
            SellClient_tb.DataBindings.Add("Text", DTInstalltask, "tAgeStore");
            SellManager_tb.DataBindings.Add("Text", DTInstalltask, "tAgePerson");
            Adress_tb.DataBindings.Add("Text", DTInstalltask, "tAddress");
            Region_tb.DataBindings.Add("Text", DTInstalltask, "tRegCode");
            ZoneName.DataBindings.Add("Text", DTInstalltask, "tRegName");
            //MainType_be.DataBindings.Add("Text", DTInstalltask, "tMaiCode");
            MonitorType_tb.DataBindings.Add("Text", DTInstalltask, "tMonCode");
            txtMakecode.DataBindings.Add("Text", DTInstalltask, "tMakeCode");
            DTP_Send.DataBindings.Add("Text", DTInstalltask, "tSendTime");

            this.dtimeFH1.DataBindings.Add("Text", DTInstalltask, "dtimeFH");
            this.dtimeGC1.DataBindings.Add("Text", DTInstalltask, "dtimeGC");
       
            RepairMonth.DataBindings.Add("Text", DTInstalltask, "tRepMonth");
            CB_installtype.DataBindings.Add("SelectedItem", DTInstalltask, "tInsType");
            CB_installtype.DataBindings.Add("Text", DTInstalltask, "tInsType");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            CB_U8AccountNum.DataBindings.Add("SelectedItem", DTInstalltask, "U8AccountNum");
            CB_U8AccountNum.DataBindings.Add("Text", DTInstalltask, "U8AccountNum");
            this.tSaleType_tb.DataBindings.Add("Text", DTInstalltask, "tSaleType");

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

            this.txtMessager.DataBindings.Add("Text", DTInstalltask, "MessageCode");
            this.MachineLevel.DataBindings.Add("Text", DTInstalltask, "MachineLevel");
            this.MachineModel.DataBindings.Add("Text", DTInstalltask, "MachineModel");
            this.txtMainCode.DataBindings.Add("Text", DTInstalltask, "tMaiCode");
            this.MachineType.DataBindings.Add("Text", DTInstalltask, "MachineType");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtProductLine.DataBindings.Add("Text", DTInstalltask, "ProductLine");
            

            this.txtJiQiJB.DataBindings.Add("BaoBtnCaption", DTInstalltask, "jqjbcode");
            this.Color.DataBindings.Add("Text", DTInstalltask, "Color");
            this.Color.DataBindings.Add("SelectedItem", DTInstalltask, "Color");
            this.gridControl1.DataSource = DTInsaccessory;
            this.gridControl3.DataSource = DTSaledetail;

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
            MainVersion_tb.DataBindings.Add("Text", DTInsfeedback, "fMainVersion");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            fSN2_tb.DataBindings.Add("Text", DTInsfeedback, "fSN2");

            Maintypetask_tb.DataBindings.Add("Text", DTInsfeedback, "fMainType");
            RTB_softversion.DataBindings.Add("Text", DTInsfeedback, "fSoftVersion");
            InsFeedBack_tb.DataBindings.Add("Text", DTInsfeedback, "fFeed");
            FeedBackSummary_tb.DataBindings.Add("Text", DTInsfeedback, "fsummary");
            this.gridControl2.DataSource = DTInsdetail;
            gridColumn5.FieldName = "rInsName";
            gridColumn6.FieldName = "rInsStart";
            gridColumn7.FieldName = "rInsEnd";
            gridColumn8.FieldName = "rInsSummary";

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            gridColumn25.FieldName = "rInsShop";

        }
        public void UnDataBinding()
        {

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            CB_U8AccountNum.DataBindings.Clear();
            this.tSaleType_tb.DataBindings.Clear();
            this.txtProductLine.DataBindings.Clear();
            this.fSN2_tb.DataBindings.Clear();


            txtMessager.DataBindings.Clear();
            txtMakecode.DataBindings.Clear();
            TaskCode_tb.DataBindings.Clear();
            txtBillDate.DataBindings.Clear();
            txtInitDep.DataBindings.Clear();
            ClientCode_tb.DataBindings.Clear();
            ClientName_tb.DataBindings.Clear();
            InsConnect_tb.DataBindings.Clear();
            InsPhone_tb.DataBindings.Clear();
            SellClient_tb.DataBindings.Clear();
            SellManager_tb.DataBindings.Clear();
            Adress_tb.DataBindings.Clear();
            Region_tb.DataBindings.Clear();
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
            this.txtMainCode.DataBindings.Clear();
            this.MachineModel.DataBindings.Clear();
            this.MachineType.DataBindings.Clear();
            this.txtJiQiJB.DataBindings.Clear();
            this.Color.DataBindings.Clear();
            //this.Color.Text = null;
            this.dtimeFH1.DataBindings.Clear();
            this.dtimeGC1.DataBindings.Clear();

            this.gridControl1.DataSource = null;

            PostCode_tb.DataBindings.Clear();
            ClientManager_tb.DataBindings.Clear();
            ClientPhone_tb.DataBindings.Clear();
            DTP_yanshou.DataBindings.Clear();
            DTP_fendtime.DataBindings.Clear();
            MainVersion_tb.DataBindings.Clear();
            this.fSN2_tb.DataBindings.Clear();

            Maintypetask_tb.DataBindings.Clear();
            RTB_softversion.DataBindings.Clear();
            InsFeedBack_tb.DataBindings.Clear();
            FeedBackSummary_tb.DataBindings.Clear();

            PostCode_tb.Clear();
            ClientManager_tb.Clear();
            ClientPhone_tb.Clear();
            MainVersion_tb.Clear();

            this.fSN2_tb.Clear();

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
            txtJiQiJB.Enabled = false;
            InsMangerName_tb.ReadOnly = true;
            Summary_tb.ReadOnly = true;

            this.tSaleType_tb.Enabled = true;

            PostCode_tb.ReadOnly = true;
            ClientManager_tb.ReadOnly = true;
            ClientPhone_tb.ReadOnly = true;
            MainVersion_tb.Enabled = false;

            this.fSN2_tb.Enabled = false;

            Maintypetask_tb.Enabled = false;
            //Maintypetask_tb.DataBindings.Add("Text", DTInsfeedback, "");
            RTB_softversion.ReadOnly = true;
            InsFeedBack_tb.ReadOnly = true;
            FeedBackSummary_tb.ReadOnly = true;

            ClientCode_tb.Enabled = false;
            SellClient_tb.Enabled = false;
            Region_tb.Enabled = false;
            //txtJiQiJB.Enabled = false;
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
            this.gridView1.OptionsBehavior.Editable = false;

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
        }
        void ZoneName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.Region_tb.BaoBtnCaption = e.ReturnRow1["cDCCODE"].ToString();
            this.ZoneName.Text = e.ReturnRow1["CDCNAME"].ToString();
            //this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(e.ReturnRow1["cDCCODE"].ToString());
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
                this.txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.BtnItemAdd.Enabled = true;
                this.BtnItemDel.Enabled = true;

                this.txtJiQiJB.Enabled = true;
                ClientCode_tb.Enabled = true;
                ClientName_tb.ReadOnly = false;
                InsConnect_tb.ReadOnly = false;
                InsPhone_tb.ReadOnly = false;
                SellClient_tb.Enabled = true;
                SellManager_tb.ReadOnly = false;
                Adress_tb.ReadOnly = false;
                //this.City.ReadOnly = false;

                txtJiQiJB.Enabled = true;
                MonitorType_tb.Enabled = true;
                DTP_Send.Enabled = true;
                RepairMonth.ReadOnly = false;
                txtJiQiJB.Enabled = true;
                CB_installtype.Enabled = true;
                Summary_tb.ReadOnly = false;

                this.tSaleType_tb.Enabled = false;

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
                    Maintypetask_tb.Enabled = false;
                    txtJiQiJB.Enabled = true;
                    MonitorType_tb.Enabled = true;
                    RTB_softversion.Enabled = true;

                    tSaleType_tb.Enabled = false;
                }
                if (CB_installtype.Text == "选配件安装")
                {
                    //TaskCode_tb.Text = RiLiGlobal.GetCode.GetOPCode();//配件安装

                    txtJiQiJB.Enabled = false;
                    txtJiQiJB.BaoBtnCaption = "";
                    MachineLevel.Text = "";
                    MachineModel.Text = "";
                    MachineType.Text = "";

                    MonitorType_tb.Text = "";
                    MonitorType_tb.Enabled = false;
                    RTB_softversion.Enabled = false;
                    Maintypetask_tb.Enabled = true;

                    tSaleType_tb.Enabled = true;
                }
                //TaskCode_tb.Text = "";
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
                this.gridView2.DeleteRow(this.gridView2.FocusedRowHandle);
                this.gridView2.CloseEditor();
                this.gridView2.UpdateCurrentRow();
            }
        }
        private void BtnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在，请重新操作");
                    return;
                }
               
                //if (!Common.Common.IS_SQL_Region_ManageUser(City.Text.Trim(), UFBaseLib.BusLib.BaseInfo.DBUserID))
                //{
                //    MessageBox.Show("区域不在您的管理范围，无权操作", "提示");
                //    return;                    
                //}
                if (BtnAudit.Text == "弃审")
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已审核")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    if (DTInstalltask.Rows[0]["tAuditPerson"].ToString() != autoUserID)
                    {
                        MessageBox.Show("无权弃审，审核人为：" + DTInstalltask.Rows[0]["tAuditPerson"].ToString(), "提示");
                        return;
                    }


                    //string sql = string.Format(@"select tAuditPerson from InstallTask where tInsCode= '{0}'", TaskCode_tb.Text);
                    //DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
                    //if (dt == null && dt.Rows.Count <= 0)
                    //    return;

                    string tAuditPerson = DTInstalltask.Rows[0]["tAuditPerson"].ToString();
                    if (tAuditPerson != autoUserID)
                    {
                        MessageBox.Show("该单据只能由[" + tAuditPerson + "]弃审！","温馨提示！");
                        return;
                    }

                    string auditsql = "update InstallTask set tAuditTime=null,tAuditPerson='',tState='待审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                    
                    Bao.Message.CMessage.SendMessage("安装单弃审", "安装单已弃审", InsMangerName_tb.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    MessageBox.Show("弃审成功,信息发至[" + InsMangerName_tb.Text+"]");
                    //Bao.Message.CMessage.SendMessage("核对任务", "任务已经审核，请您核对", Manager_be.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);

                }
                else
                {
                    DataTable dttmp = Common.Common.Select_SQL_UserID_ManageUser(DTInstalltask.Rows[0]["tInsManger"].ToString()); //安装工程师的上级领导
                    if (dttmp.Select("userID='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'").Length <= 0)
                    {
                        MessageBox.Show("非直属上级或指派安装单任务不在您的管理范围，无权操作", "提示");
                        return;
                    }

                    if (DTInstalltask.Rows[0]["tState"].ToString() != "待审核")
                    {
                        MessageBox.Show("该单据不是最新状态，请重新操作");
                        return;
                    }
                    string auditsql = "update InstallTask set tAuditTime=getDate(),tAuditPerson='" + autoUserID + "',tState='已审核' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(auditsql);
                    TaskInite(TaskCode_tb.Text);
                   
                    string strManager = Bao.Message.CMessage.SendMessageToRoleNoDepartment("核对任务", "任务已经审核，请您核对", "001", UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    MessageBox.Show("审核成功,信息发至[" + strManager + "]!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 加装安装单
        /// </summary>
        /// <param name="taskcode"></param>
        /// <returns></returns>
        private DataTable GetDtInstalltask(string taskcode)
        {
            string sql = string.Format(@"select isnull(a.U8AccountNum,'001') as U8AccountNum,isnull(a.ProductLine,'') as ProductLine,isnull(a.tSaleType,'') as tSaleType,[tID],[tInsCode],[tCuscode],[tCusName],[tComName],[tComPhone],[tAgeStore]
                                                                    ,[tAgePerson],[tSaleType],[tRegName],[tRegCode],[tAddress],isnull(a.tMaiCode,b.cInvAddCode) as tMaiCode,[tMonCode],[tRepMonth]
                                                                    ,[tSendTime],[tInsType],[tSummary],[tManger],[tInsManger],[tInsMangerName],[tTaskStart]
                                                                    ,[tTaskAsign],[tAuditTime],[tAuditPerson],[tCheckTime],[tCheckPerson],[tState]--,[tAccessories]
                                                                    ,[tAccType],[tAccName],[tStartPerson],[tMessageId],[tMessagedate],[tAuditMessageId],[tAuditMessagedate]
                                                                    ,[fMessageId],[fMessagedate],[InstallManagerCode],[InstallManagerName],[AsignInstallManagerDate]
                                                                    ,[City],a.[InstallUnit1],a.[InstallUnit2],[MachineLevel],[Color],[dtimefh],[dtimegc]
                                                                     ,convert(nvarchar(10),[billDate],120) as billDate
                                                                    ,[xsalecode],[xoutcode],[xwhcode],[jqjbcode],[anzhcode1],[anzhcode2],[MachineType],[ProductLine],[MachineModel],[tMakeCode]
                                                                    ,c.Dept,u.userName as MessageCode
                                                       from InstallTask a 
                                                       left join {1}.Inventory b on a.jqjbcode = b.cinvcode
                                                       left join BaseInstallationUnitType c on a.tInsManger = c.UserId
                                                       left join Users u on a.tStartPerson = u.UserId
                                                        where tInsCode='{0}'", taskcode, U8Global.U8DataAcc.U8ServerAndDataBase);

            return RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text);
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
                    string accsql = string.Format(@"select r.InstallCode,r.AccType,r.UserId,r.AccName,r.ID,u.username,1 as [type] from InstallFile r left join users u on r.userid=u.userid  where InstallCode='{0}'
                                             union 
                                         select tInsCode as InstallCode,tAccType as AccType,'' as UserId,tAccName as AccName,tID,'' as username, 0 as [type] from InstallTask where tInsCode='{0}'  and tAccessories is not null", TaskCode_tb.Text);
                    DataTable acctable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(accsql);
                    if (acctable.Rows.Count <= 0)
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

        private string GetInvDetail(string U8AccountNum, string relation)
        {
            string sql = string.Empty;
            if (relation.Length <= 0)
                relation = "1=1";

            string U8DataBaseNameBy009 = "";
            string sqlAccount = string.Format("select AccountNum,U8Server,U8DataBase from [U13SHOUHOU].dbo.RL_DBInfo where AccountNum='{0}'", U8AccountNum);
            DataTable dtAccount = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sqlAccount);

            U8DataBaseNameBy009 = string.Format("[{0}].[{1}].dbo", dtAccount.Rows[0]["U8Server"].ToString().Trim(), dtAccount.Rows[0]["U8DataBase"].ToString().Trim());

            sql = string.Format(@"select '{2}' as U8AccountNum, a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        --,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                       ,c1.cinvSN
                                        -- ,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as qty
                                        ,a2.ccode,a1.autoid,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                    left join {0}.customer a3 on a2.ccuscode = a3.ccuscode
                                    left join {0}.customer a4 on a2.cdefine11 = a4.cCusAbbName
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where {1} 
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,a2.ccode,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end,c1.cSNDefine1,a2.ddate
                                    having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)", U8DataBaseNameBy009, relation, U8AccountNum);
            return sql;
        }


        private string GetInvDetail(string relation)
        {
            string sql = string.Empty;
            if (relation.Length <= 0)
                relation = "1=1";

            string sqlAccount = "";

            string U8AccountNum = "";
            string U8DataBaseNameBy009 = "";

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            if (RiLiGlobal.RiLiDataAcc.AccountNum == "009")
            {
                 //若是009售后账套，则读取对应U8 001，003，005的合并数据
                sqlAccount = "select AccountNum,U8Server,U8DataBase from [U13SHOUHOU].dbo.RL_DBInfo where AccountNum in ('001','003','005')";
                DataTable dtAccount = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sqlAccount);
                if (dtAccount != null && dtAccount.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAccount.Rows.Count; i++)
                    {
                        U8AccountNum = dtAccount.Rows[i]["AccountNum"].ToString().Trim();

                        U8DataBaseNameBy009 = string.Format("[{0}].[{1}].dbo", dtAccount.Rows[i]["U8Server"].ToString().Trim(), dtAccount.Rows[i]["U8DataBase"].ToString().Trim());

                        sql += string.Format(@"select '{2}' as U8AccountNum, a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        --,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                       ,c1.cinvSN
                                        -- ,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as qty
                                        ,a2.ccode,a1.autoid,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                    left join {0}.customer a3 on a2.ccuscode = a3.ccuscode
                                    left join {0}.customer a4 on a2.cdefine11 = a4.cCusAbbName
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where {1} 
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,a2.ccode,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end,c1.cSNDefine1,a2.ddate
                                    having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)", U8DataBaseNameBy009, relation, U8AccountNum);

                        if (i != dtAccount.Rows.Count - 1)
                        {
                            sql += " union all ";
                        }
                    }
                }

            }
            else
            {
                sql = string.Format(@"select '{2}' as U8AccountNum, a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        --,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                       ,c1.cinvSN
                                        -- ,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as qty
                                        ,a2.ccode,a1.autoid,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                    left join {0}.customer a3 on a2.ccuscode = a3.ccuscode
                                    left join {0}.customer a4 on a2.cdefine11 = a4.cCusAbbName
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where {1} 
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,a2.ccode,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end,c1.cSNDefine1,a2.ddate
                                    having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)", U8DataBaseName, relation, RiLiGlobal.RiLiDataAcc.AccountNum);

            }

            return sql;
        }


      /*  private string GetInvDetail(string relation)
        {
            string sql = string.Empty;
            if (relation.Length <= 0)
                relation = "1=1";
            sql = string.Format(@"select a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        --,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                       ,c1.cinvSN
                                        -- ,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as qty
                                        ,a2.ccode,a1.autoid,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                    left join {0}.customer a3 on a2.ccuscode = a3.ccuscode
                                    left join {0}.customer a4 on a2.cdefine11 = a4.cCusAbbName
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where {1} 
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,a2.ccode,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end,c1.cSNDefine1,a2.ddate
                                    having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)", U8DataBaseName, relation);
            return sql;
        }*/

        private DataTable GetInvDataTable(string U8AccountNum, string relation)
        {
            string sql = GetInvDetail(U8AccountNum,relation);
            return HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(sql).Tables[0];
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

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                /*if (CB_U8AccountNum.Text.Trim() == "")
                {
                    MessageBox.Show("请选择U8来源账套!", "提示");
                    return;
                }*/

                if (ClientCode_tb.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("请先选择客户!", "提示");
                    return;
                }
                //配件明细表已存在出库单所对应的配件，就不显示出来选择
                string condition = string.Empty;
                string union_sql = string.Empty;

                //union_sql = GetInvDetail(CB_U8AccountNum.Text,string.Format("a3.cCusAbbName = '{0}'", SellClient_tb.Text.Trim()));

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                union_sql = GetInvDetail(string.Format("a3.cCusAbbName = '{0}'", SellClient_tb.Text.Trim()));

             
                /*
                foreach (DataRow dr in DTInsaccessory.Rows)
                {
                    if (IsDeleteRow(dr))
                    {
                        continue;
                    }
                    
                 
                   
                    string str = dr["sautoid"].ToString();
                    if (str != "")
                    {
                        condition += string.Format(" and am.autoid != '{0}'", str);

                        //配件明细表中对应出库单号的配件是否还有数量
                        union_sql += string.Format(@" union select ui.cInvCode,ui.cInvName,ui.cinvaddcode as cEnglishName,ui.cInvStd,am.qty, am.autoid
			                                                    from {2}.Inventory ui 
				                                                      right join (select bb.cinvcode, bb.autoid, sum(isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0)) - {1} as qty
												                                                    from {2}.rdrecords32 bb
													                                                         left join (select qty, sautoid from InsAccessory ia where ia.sautoid is not null and ia.sautoid = '{0}') iaa 
														                                                         on bb.autoid = iaa.sautoid
                                                                                                    where bb.autoid = '{0}'
                                                                                                    group by bb.cinvcode, bb.autoid
                                                                                                    having sum(isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0)) - {1} > 0) am
					                                                      on am.cinvcode = ui.cInvCode
			                                                    where (ui.cinvcode like 'A%' or ui.cinvcode like 'C%')", dr["sautoid"].ToString(), dr["qty"], U8DataBaseName);
                    }
                    
                }
                */
                //先检索出所有有数量的配件，不包括已存在配件明细表中，然后再联合在配件明细表中对应出库单号的配件是否还有数量
                /*
                AccBT.BaoSQL = string.Format(@"select ui.cInvCode,ui.cInvName,ui.cinvaddcode as cEnglishName,ui.cInvStd,am.qty, am.autoid
	                                                 from {1}.Inventory ui 
		                                                right join (select bb.cinvcode, bb.autoid, sum(isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0)) as qty
						                                                 from {1}.rdrecords32 bb
							                                                left join (select qty, sautoid 
											                                                from InsAccessory ia 
											                                                where ia.sautoid is not null) iaa 
						                                                 on bb.autoid = iaa.sautoid 
						                                                 group by bb.cinvcode, bb.autoid 
						                                                 having sum(isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0)) > 0) am
		                                                on am.cinvcode = ui.cInvCode
	                                                 where (ui.cinvcode like 'A%' or ui.cinvcode like 'C%') {0}", condition, U8DataBaseName) + union_sql;
              */
                AccBT.BaoSQL = union_sql;
                AccBT.BaoTitleNames = "cInvCode=存货编码,U8AccountNum=U8来源账套,cInvName=存货名称,cEnglishName=英文名称,cInvStd=规格型号,cinvSN=制造编号,qty=剩余数量,ccode=出库单号,ddate=出库日期,autoid=配件单号,ddate=GC出库日期,cSNDefine1=本部发货日期";
                this.AccBT.FrmHigth = 600;
                this.AccBT.FrmWidth = 1000;
                AccBT.BaoColumnsWidth = "cInvCode=100,U8AccountNum=100,cInvName=120,cEnglishName=150,cInvStd=150,cinvSN=100,qty=100,ccode=80,ddate=80,autoid=100,dtimefh=80,dtimegc=80";

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

            this.gridView2.SetRowCellValue(i, gridView2.Columns["U8AccountNum"], dr["U8AccountNum"].ToString());

            this.gridView2.SetRowCellValue(i, gridView2.Columns["aAccStd"], dr["cInvStd"].ToString());
            this.gridView2.SetRowCellValue(i, gridView2.Columns["cEnglishName"], dr["cEnglishName"].ToString());
            this.gridView2.SetRowCellValue(i, gridView2.Columns["qty"], dr["qty"]);
            this.gridView2.SetRowCellValue(i, gridView2.Columns["aMakeCode"], dr["cinvSN"]);
            this.gridView2.SetRowCellValue(i, gridView2.Columns["sautoid"], dr["autoid"].ToString());
            this.gridView2.SetRowCellValue(i, gridView2.Columns["dtimefh"], dr["cSNDefine1"]);
            this.gridView2.SetRowCellValue(i, gridView2.Columns["dtimegc"], dr["ddate"]);
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
            this.ZoneName.Text = dr["ccCName"].ToString();
            this.City.Text = dr["cDCName"].ToString();
            this.Region_tb.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString().Substring(1, 2);
            //this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.Region_tb.BaoBtnCaption + "'");
            //this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.Region_tb.BaoBtnCaption);
        }

        private void SellClient_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            SellClient_tb.Text = dr["cCusName"].ToString();
        }

        private void MainType_be_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            //MainType_be.Text = dr["cInvStd"].ToString();
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
            InstallUnit1.Text = dr["InstallUnit1"].ToString();
            InstallUnit2.Text = dr["InstallUnit2"].ToString();
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
            //mesg += CheckIsNull(this.Region_tb.Text, "区域不能为空");
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
                //mesg += CheckIsNull(this.MainType_be.Text, "主机型号不能为空");
                //mesg += CheckIsNull(this.MonitorType_tb.Text, "显示器型号不能为空");
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
            DataTable dt = (this.gridControl1.DataSource as DataTable);
            dt.AcceptChanges();
            foreach (DataRow item in dt.Rows)
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
                //mesg += CheckIsNull(this.Maintypetask_tb.Text, "主机型号不能为空");
                ////主机版本是否是数字
                //if (!reg1.IsMatch(this.MainVersion_tb.Text))
                //{
                //    mesg += "【主机版本必须是数字】";
                //}
            }
            if ((this.gridControl2.DataSource as DataTable).Rows.Count == 0)
            {
                mesg += "安装情况反馈表体明细，不能为空";
            }
            else
            {
                //1、安装起始日期>=提交日期
                //2、安装结束日期>=安装起始日期
                //3、验收日期>=安装结束日期

                //提交日期
                DateTime datetime = DateTime.Parse(DTInstalltask.Rows[0]["tAuditMessagedate"].ToString());
                DateTime AuditMessagedate = DateTime.Parse(datetime.ToShortDateString());

                //验收日期
                DateTime DTP_yanshou_dt = DateTime.Parse(DTP_yanshou.Value.ToShortDateString());

                //DataTable d = this.gridControl2.DataSource as DataTable;
                //int row = d.Rows.Count;
                foreach (DataRow item in (this.gridControl2.DataSource as DataTable).Rows)
                {
                    if (item.RowState == DataRowState.Deleted) continue;
                    DateTime InsStart = DateTime.Parse(item["rInsStart"].ToString());   //安装开始日期
                    DateTime InsEnd = DateTime.Parse(item["rInsEnd"].ToString());   //安装结束日期

                    //if (AuditMessagedate > InsStart)
                    //{
                    //    mesg += "[“安装完成开始日期”必须大于等于“指派任务日期”]";
                    //    break;
                    //}

                    if (InsStart > InsEnd)
                    {
                        mesg += "[“安装完成结束日期”必须大于等于“安装开始日期”]";
                        break;
                    }

                    if (InsStart > DTP_yanshou_dt)
                    {
                        mesg += "[“验收日期”必须大于等于“安装完成开始日期”]";
                        break;
                    }

                    if (InsEnd > DTP_yanshou_dt)
                    {
                        mesg += "[“验收日期”必须大于等于“安装完成结束日期”]";
                        break;
                    }
                }
            }
            //联系电话是否是数字
            if (!reg1.IsMatch(this.ClientPhone_tb.Text))
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
                e.Info.DisplayText = (Convert.ToInt64(e.RowHandle)+1).ToString();

            }
        }

        /// <summary>
        /// 判断行是否删除
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool IsDeleteRow(DataRow dr)
        {
            if (dr.RowState == DataRowState.Deleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //判断所选的配件是否足够（配件明细表）
        private bool DTInsaccessoryQuantityIsEnough()
        {
            DataTable dt = null;

            foreach (DataRow dr in DTInsaccessory.Rows)
            {
                if (IsDeleteRow(dr))
                {
                    continue;
                }

                int qty = dr["qty"].ToString()==""?0:Convert.ToInt32(dr["qty"].ToString());
                if (qty <= 0)
                {
                    MessageBox.Show(dr["aAccName"].ToString() + "的配件数量不能为“0”或空！", "温馨提示！");
                    return false;
                }

                ////安装单的配件已存在的数量
                //int exist_qty = 0;
                //dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(string.Format("select qty from InsAccessory where sautoid = '{0}'", dr["sautoid"].ToString()));
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    exist_qty = Convert.ToInt32(dt.Rows[0]["qty"]);
                //}

                //sg
                string sautoid_str = dr["sautoid"].ToString();
                string aID = dr["aID"].ToString();

                string U8AccountNum = "";
                if (dr["U8AccountNum"] != DBNull.Value)
                {
                    U8AccountNum = dr["U8AccountNum"].ToString();
                }

                if (U8AccountNum != "其他")
                {
                    dt = GetInvDataTable(U8AccountNum, "a1.autoid = '" + sautoid_str + "'");
                    decimal sql_qty = 0;
                    if (aID.Length > 0)
                    {
                        //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                        //string sql = "select qty from InsAccessory where aID = '" + aID + "'";

                        string sql = "select qty from InsAccessory where aID = '" + aID + "' and U8AccountNum='" + U8AccountNum + "'";
                        string tmp = RiLiGlobal.RiLiDataAcc.ExecuteScalar(sql);
                        sql_qty = Convert.ToDecimal(tmp.Length > 0 ? tmp : "0");
                    }
                    if (dt.Rows.Count > 0)
                    {
                        sql_qty += Convert.ToDecimal(dt.Rows[0]["qty"]);
                    }

                    if (sql_qty - qty < 0)
                    {
                        MessageBox.Show(string.Format("存货编码为：{0}的安装数量超出出库数据[{1}]件", dr["aAccCode"].ToString(), (qty - sql_qty).ToString()), "温馨提示！");
                        return false;
                    }
                }
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.gridView2.CloseEditor();
            this.gridView2.UpdateCurrentRow();

            this.gridView3.CloseEditor();
            this.gridView3.UpdateCurrentRow();

            if (!DTInsaccessoryQuantityIsEnough())
            {
                return;
            }

            try
            {
                string sql = "";

                

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                //获取第一个配件明细的来源账套
                if (DTInsaccessory.Rows.Count > 0)
                {
                    this.CB_U8AccountNum.Text = DTInsaccessory.Rows[0]["U8AccountNum"].ToString();
                }
                else
                {
                    this.CB_U8AccountNum.Text = "001";
                }

                //状态
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
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

                            sql = @"insert into InstallTask(tID,tInsCode,tCusCode,tCusName,
                                        tComName,tComPhone,tAgeStore,
                                        tAgePerson,tRegName,tAddress,
                                        tMaiCode,tMonCode,tRepMonth,
                                        tSendTime,tInsType,tSummary,
                                        tManger,tTaskStart,tStartPerson,tState,tRegCode,City,dtimefh,dtimegc,MachineLevel,MachineType,MachineModel,Color,tMakeCode,jqjbcode,billDate,U8AccountNum,ProductLine,tSaleType) values(NEWID(),'"
                                 + TaskCode_tb.Text + "','" + ClientCode_tb.Text + "','" + ClientName_tb.Text + "'"
                                 + ",'" + InsConnect_tb.Text + "','" + InsPhone_tb.Text + "','" + SellClient_tb.Text + "','"
                                 + SellManager_tb.Text + "','" + this.ZoneName.Text + "'" + ",'" + Adress_tb.Text + "','"
                                 + txtMainCode.Text + "','" + MonitorType_tb.Text + "','" + Convert.ToInt32(RepairMonth.Text)
                                 + "','" + DTP_Send.Value + "'" + ",'" + CB_installtype.Text + "','" + Summary_tb.Text + "','"
                                 + Manager_be.Text + "','" + DTP_TaskStart.Text + "','" + autoUserID + "','新任务','"+this.Region_tb.Text+"','"+this.City.Text+"','"
                                 + (dtimeFH1.Text == "" ? "NULL" : dtimeFH1.Text) + "','" + (dtimeGC1.Text == "" ? "NULL" : dtimeGC1.Text) + "','" + MachineLevel.Text + "','" + MachineType.Text + "','" + MachineModel.Text + "','" + Color.Text + "','" + txtMakecode.Text
                                 + "','" + txtJiQiJB.BaoBtnCaption.Trim() + "','" + txtBillDate.Text + "','" + CB_U8AccountNum.Text + "','" + txtProductLine.Text.Trim() + "','" + tSaleType_tb.Text.Trim() + "');";
                            foreach (DataRow dr in DTInsaccessory.Rows)
                            {  //发起任务明细 
                                sql += "insert into InsAccessory(aID,aTaskCode,sautoid,aAccCode,aAccName,aAccStd,aMakeCode,qty,aSummary,cEnglishName,dtimefh,dtimegc,U8AccountNum) "
                                    + "values(NEWID(),'" + TaskCode_tb.Text + "','" + dr["sautoid"].ToString() + "','" + dr["aAccCode"].ToString() + "','"
                                    + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','" + dr["aMakeCode"].ToString() + "','" + dr["qty"].ToString() + "','"
                                    + dr["aSummary"].ToString() + "','" + dr["cEnglishName"].ToString() + "','" + (dr["dtimefh"].ToString() == "" ? "null" : dr["dtimefh"].ToString()) + "','" + dr["dtimegc"].ToString() + "','" + dr["U8AccountNum"].ToString() + "'"
                                    + ")";
                            }
                        }
                    }
                    else if (DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                    {
                        sql = "update InstallTask set tCusCode='" + ClientCode_tb.Text + "',tCusName='" + ClientName_tb.Text + "',tComName='" + InsConnect_tb.Text + "',tComPhone='" + InsPhone_tb.Text + "',"
                            + "tAgeStore='" + SellClient_tb.Text + "',tAgePerson='" + SellManager_tb.Text + "',tRegCode='" + Region_tb.Text + "',City='" + City.Text + "',tRegName='" + this.ZoneName.Text + "',tAddress='" + Adress_tb.Text + "',tMaiCode='" + txtMainCode.Text + "'"
                            + ",tMonCode='" + MonitorType_tb.Text + "',tRepMonth='" + Convert.ToInt32(RepairMonth.Text) + "',tSendTime='" + DTP_Send.Value + "',tSummary='" + Summary_tb.Text + "',tManger='" + Manager_be.Text
                            + "',tTaskStart='" + DTP_TaskStart.Text + "',dtimefh='" + (dtimeFH1.Text == "" ? "NULL" : dtimeFH1.Text)
                            + "',dtimegc='" + (dtimeGC1.Text == "" ? "NULL" : dtimeGC1.Text)
                            + "',MachineLevel='" + MachineLevel.Text.Trim() + "',MachineType='" + MachineType.Text.Trim() + "',MachineModel='" + MachineModel.Text.Trim() + "',tMakeCode='" + txtMakecode.Text.Trim()
                            + "',tInsType='" + CB_installtype.Text + "',jqjbcode='" + txtJiQiJB.BaoBtnCaption.Trim() + "',Color='" + Color.Text + "',U8AccountNum='" + CB_U8AccountNum.Text + "',tSaleType='" + tSaleType_tb.Text.Trim() + "' where tInsCode='" + TaskCode_tb.Text + "'";//完善

                        sql += "delete InsAccessory where aTaskCode='" + TaskCode_tb.Text + "'";
                        foreach (DataRow dr in DTInsaccessory.Rows)
                        {
                            sql += "insert into InsAccessory(aID,aTaskCode,sautoid,aAccCode,aAccName,aAccStd,aMakeCode,qty,aSummary,cEnglishName,dtimefh,dtimegc,U8AccountNum) values(NEWID(),'" 
                                                        + TaskCode_tb.Text + "','" + dr["sautoid"].ToString() + "','" + dr["aAccCode"].ToString() + "','"
                                                        + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','"
                                                        + dr["aMakeCode"].ToString() + "','" + dr["qty"].ToString() + "','" + dr["aSummary"].ToString() + "','"
                                                        + dr["cEnglishName"].ToString() + "','" + (dr["dtimefh"].ToString() == "" ? "null" : dr["dtimefh"].ToString()) + "','" + dr["dtimegc"].ToString() + "','" + dr["U8AccountNum"].ToString() + "'"
                                                        + ")";
                        }
                    }
                }
                //是否 《部长角色》 角色
                if (UserRole.Contains("009") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派科长")
                {
                    sql += "update InstallTask set InstallManagerCode='" + this.InstallManagerCode.Text + "',InstallManagerName='" + InstallManagerName.Text + "',AsignInstallManagerDate='" + AsignInstallManagerDate.Text 
                        + "',InstallUnit1 = '" + InstallUnit1.Text 
                        + "',InstallUnit2 = '" + InstallUnit2.Text
                        + "',MachineLevel ='" + MachineLevel.Text + "',MachineType ='" + MachineType.Text + "',MachineModel ='" + MachineModel.Text + "',jqjbcode='" + txtJiQiJB.BaoBtnCaption.Trim() + "',Color ='" + Color.Text + "',tMakeCode ='" + txtMakecode.Text + "' where tInsCode='" + TaskCode_tb.Text + "'";
                }
                //是否 《客服经理》 角色
                if (UserRole.Contains("002") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    sql += "update InstallTask set tInsManger='" + InsManagercode_be.Text + "',tInsMangerName='" + InsMangerName_tb.Text + "',tTaskAsign='" + DTP_assignDate.Text
                        + "',InstallUnit1='" + this.InstallUnit1.Text.Trim() 
                        + "',InstallUnit2='" + this.InstallUnit2.Text.Trim() 
                        + "' where tInsCode='" + TaskCode_tb.Text + "'";
                }
                //是否 《工程师》 角色
                if (UserRole.Contains("003") && DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "已指派")
                {
                    Check003();
                    sql += " update InstallTask set MachineLevel='" + MachineLevel.Text.Trim() + "',MachineType='" + MachineType.Text.Trim() + "',MachineModel='" + MachineModel.Text.Trim() + "',tMaiCode='" + txtMainCode.Text.Trim() + "',tMakeCode='" + txtMakecode.Text.Trim()
                            + "',tInsType='" + CB_installtype.Text + "',jqjbcode='" + txtJiQiJB.BaoBtnCaption.Trim() + "',Color='" + Color.Text + "' where tInsCode='" + TaskCode_tb.Text + "'; ";//完善


                    sql += " delete InsFeedback where fTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " delete InsDetail where rTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " delete InsAccessory where aTaskCode='" + TaskCode_tb.Text + "';";
                    sql += " insert into InsFeedback(fID,fTaskCode,fPostCode,fCliManger,fCliPhone,fEndTime,fMainVersion,fSoftVersion,fFeed,fsummary,finput,fMainType,fSN2)"
                    + "values(NEWID(),'" + TaskCode_tb.Text + "','" + PostCode_tb.Text + "','" + ClientManager_tb.Text + "','" + ClientPhone_tb.Text + "','"
                     + DTP_yanshou.Value + "','" + MainVersion_tb.Text + "','" + RTB_softversion.Text + "','" + InsFeedBack_tb.Text + "','" + FeedBackSummary_tb.Text + "','" + DTP_fendtime.Text + "','" + Maintypetask_tb.Text + "','" + fSN2_tb.Text.Trim() + "');";

                    foreach (DataRow dr in DTInsdetail.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted) continue;

                        sql += " insert into InsDetail(rID,rTaskCode,rInsName,rInsStart,rInsEnd,rInsSummary,rInsPersionCode,rInsShop) values(NEWID(),'"
                            + TaskCode_tb.Text + "','" + dr["rInsName"].ToString() + "','" + dr["rInsStart"].ToString() + "'"
                        + ",'" + dr["rInsEnd"].ToString() + "','" + dr["rInsSummary"].ToString() + "','" + dr["rInsPersionCode"].ToString() + "','" + dr["rInsShop"].ToString() + "');";
                    }
                    foreach (DataRow dr in DTInsaccessory.Rows)
                    {  //发起任务明细 
                        sql += " insert into InsAccessory(aID,aTaskCode,sautoid,aAccCode,aAccName,aAccStd,aMakeCode,qty,aSummary,cEnglishName,dtimefh,dtimegc,U8AccountNum) values(NEWID(),'" + TaskCode_tb.Text + "','" + dr["sautoid"].ToString() + "','" + dr["aAccCode"].ToString() + "','"
                            + dr["aAccName"].ToString() + "','" + dr["aAccStd"].ToString() + "','" + dr["aMakeCode"].ToString() + "','"
                            + dr["qty"].ToString() + "','" + dr["aSummary"].ToString() + "','" + dr["cEnglishName"].ToString() + "','"
                            + (dr["dtimefh"].ToString() == "" ? "null" : dr["dtimefh"].ToString()) + "','" + dr["dtimegc"].ToString() + "','" + dr["U8AccountNum"].ToString() + "'"
                            + ")";
                    }

                   
                }

                if (sql != "")
                {
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql.Replace("'NULL'","null").Replace("'null'","null"));
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
            DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
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
                    txtJiQiJB.Enabled = true;
                    Summary_tb.ReadOnly = false;

                    this.tSaleType_tb.Enabled = false;

                    ClientCode_tb.Enabled = true;
                    SellClient_tb.Enabled = true;
                    Region_tb.Enabled = true;

                    DTP_Send.Enabled = true;
                    Manager_be.Enabled = true;
                    DTP_TaskStart.Enabled = true;
                    button1.Enabled = true;

                    if (CB_installtype.Text == "选配件安装")
                    {
                        MonitorType_tb.Enabled = false;
                        txtJiQiJB.Enabled = false;

                        this.tSaleType_tb.Enabled = true;
                    }
                    else
                    {
                        MonitorType_tb.Enabled = true;
                        txtJiQiJB.Enabled = true;
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
                    System.Windows.Forms.MessageBox.Show("已经提交给客服科长，不能修改");
                    return;
                }
            }
            if (UserRole.Contains("009"))
            {   //部长
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    BtnSave.Enabled = true;
                    addsave = false;
                    BtnCancel.Enabled = true;
                    //InsManagercode_be.Enabled = true;
                    //DTP_assignDate.Enabled = true;
                    this.InstallManagerCode.Enabled = true;
                    this.InstallManagerName.Enabled = true;
                    //this.InstallUnit1.Enabled = true;
                    //this.InstallUnit2.Enabled = true;
                    

                    //this.MachineLevel.Enabled = true;
                    //this.MachineType.Enabled = true;
                    //this.txtJiQiJB.Enabled = true;
                    //this.Color.Enabled = true;
                }
                //else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求" && !UserRole.Contains("003"))
                //{
                //    System.Windows.Forms.MessageBox.Show("已经提交指派科长，不能修改，要修改，请收回");
                //    return;
                //}
            }
            if (UserRole.Contains("002"))
            {   //客服经理
                if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
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
                    //gridColumn1.OptionsColumn.AllowEdit = false;
                    //gridColumn2.OptionsColumn.AllowEdit = false;
                    //gridColumn9.OptionsColumn.AllowEdit = false;

                    PostCode_tb.ReadOnly = false;
                    ClientManager_tb.ReadOnly = false;
                    ClientPhone_tb.ReadOnly = false;
                    DTP_yanshou.Enabled = true;
                    DTP_fendtime.Enabled = true;
                    RTB_softversion.ReadOnly = false;
                    InsFeedBack_tb.ReadOnly = false;
                    FeedBackSummary_tb.ReadOnly = false;

                    //可用配件明细表
                    BtnItemAdd.Enabled = true;
                    BtnItemDel.Enabled = true;

                    if (CB_installtype.Text == "选配件安装")
                    {
                        MainVersion_tb.Enabled = true;//主机版本
                        Maintypetask_tb.Enabled = true;//主机型号

                        this.fSN2_tb.Enabled = true;

                         txtJiQiJB.Enabled = false;
                        MonitorType_tb.Enabled = false;

                        RTB_softversion.Enabled = false;
                    }
                    else
                    {
                        MainVersion_tb.Enabled = true;//主机版本
                        Maintypetask_tb.Enabled = false;//主机型号

                        this.fSN2_tb.Enabled = true;

                        txtJiQiJB.Enabled = true;
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
                        MainVersion_tb.Enabled = false;

                        this.fSN2_tb.Enabled = false;

                        Maintypetask_tb.Enabled = false;
                        RTB_softversion.ReadOnly = true;
                        InsFeedBack_tb.ReadOnly = true;
                        FeedBackSummary_tb.ReadOnly = true;
                        button3.Enabled = false;
                    }
                }
                else if (DTInstalltask.Rows.Count > 0 && DTInstalltask.Rows[0]["tState"].ToString() == "待审核")
                {
                    System.Windows.Forms.MessageBox.Show("修改失败，单据已经提交科长审核,如要修改，请收回");
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
                MainVersion_tb.Enabled = false;
                this.fSN2_tb.Enabled = false;

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
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 

                if (DTInstalltask.Rows[0]["tState"].ToString() == "新任务")
                {
                    sql = string.Format(@"
                        begin tran
                        delete InsAccessory where aTaskCode = '{0}'
                        delete InsAccessoryOld where aTaskCode = '{0}'
                        delete InsDetail where rTaskCode = '{0}'
                        delete InsFeedback where fTaskCode = '{0}'
                        delete InstallFile where InstallCode = '{0}'
                        delete InstallTask where tInsCode = '{0}'
                        commit tran 
                    ", TaskCode_tb.Text);

                    try
                    {
                        RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql);
                        DTInsaccessory.Clear();
                        DTInsdetail.Clear();
                        DTInstalltask.Clear();
                        DTInsfeedback.Clear();
                        //ButtonInitState(UserRole);
                        TaskInite("");
                        MessageBox.Show("删除成功！", "温馨提示！");
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
                ex.SetCellValue(5, 8, TaskCode_tb.Text);  //安装任务编码
                ex.SetCellValue(5, 27, ClientName_tb.Text);  //用户名称
                ex.SetCellValue(6, 8, Adress_tb.Text);  //址址
               
                //ex.SetCellValue(7, 8, PostCode_tb.Text);  //邮政编码
                ex.SetCellValue(7, 8, ClientManager_tb.Text);    //用户负责人
                ex.SetCellValue(7, 27, ClientPhone_tb.Text);    //联系电话
                ex.SetCellValue(7, 45, PostCode_tb.Text);  //邮政编码

                ex.SetCellValue(8, 8, SellClient_tb.Text);    //销售代理店
                ex.SetCellValue(8, 45, SellManager_tb.Text);    //销售负责人
               
               
               

                DateTime dtime1 = Convert.ToDateTime("2900-01-01");
                DateTime dtime2 = Convert.ToDateTime("1900-01-01");
                foreach (DataRow dr in DTInsdetail.Rows)
                {
                    if (dtime1 >= Convert.ToDateTime(dr["rInsStart"]))
                    {
                        dtime1 = Convert.ToDateTime(dr["rInsStart"]);
                    }
                    if (dtime2 <= Convert.ToDateTime(dr["rInsEnd"]))
                    {
                        dtime2 = Convert.ToDateTime(dr["rInsEnd"]);
                    }

                }
                ex.SetCellValue(9, 8, InsMangerName_tb.Text);   //安装负责人
                if (DTInsdetail.Rows.Count > 0)
                {
                    //ex.SetCellValue(9, 27, DateTime.Parse(DTInsdetail.Rows[0]["rInsStart"].ToString()).ToShortDateString());   //安装开始上期
                    //ex.SetCellValue(9, 45, DateTime.Parse(DTInsdetail.Rows[0]["rInsEnd"].ToString()).ToShortDateString());   //安装结束日期
                    ex.SetCellValue(9, 27, dtime1.ToShortDateString());   //安装开始上期
                    ex.SetCellValue(9, 45, dtime2.ToShortDateString());   //安装结束日期
                }

                //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
               /* DataRow[] drs = DTInsaccessory.Select("((aAccCode like 'A%' or aAccCode like 'B%') and aAccCode like '%0001') or aAccCode like 'Z11%' or aAccCode like 'Z21%' or aAccCode='A100045'");*/

                //Lin 2020_07_14 新售后系统主机规则要求
                //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
                //2】 B1012015,B1012016,B1012003
                //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
                DataRow[] drs = DTInsaccessory.Select("(aAccCode like 'A11%' or aAccCode like 'A21%' or aAccCode like 'F11%' or aAccCode like 'F8101%' or aAccCode like 'F8201%' or aAccCode like 'G11%' or aAccCode like 'G8101%' or aAccCode like 'H11%' or aAccCode like 'H21%' or aAccCode like 'J81%'  or aAccCode like 'J82%' or aAccCode='B1012015' or aAccCode='B1012016' or aAccCode='B1012003' or aAccCode like 'J8101%' or aAccCode like 'J8201%' or aAccCode like 'K8101%' or aAccCode like 'L8101%' or aAccCode like 'L8201%')");


                if (drs.Length > 0)
                {
                    ex.SetCellValue(11, 25, drs[0]["aMakeCode"].ToString());   //制造编号
                }
                ex.SetCellValue(11, 8, MachineModel.Text);   //主机型号
                //ex.SetCellValue(11, 8, txtMainCode.Text);   //主机型号
                ex.SetCellValue(11, 45, MainVersion_tb.Text);   //软件版本
                //ex.SetCellValue(12, 8, MonitorType_tb.Text);   //显示器型号
                //ex.SetCellValue(21, 5, FeedBackSummary_tb.Text);    //备注
                int count = DTInsaccessory.Rows.Count;
                // int k=count/2;
                int index = 0;
                string strtmp = string.Empty;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        strtmp = DTInsaccessory.Rows[i]["aAccCode"].ToString();
                        if (((strtmp.ToUpper().StartsWith("A") || strtmp.ToUpper().StartsWith("B")) && strtmp.ToUpper().EndsWith("0001"))
                            || strtmp.ToUpper().StartsWith("Z11")
                            || strtmp.ToUpper().StartsWith("Z21"))
                        {
                            continue;
                        }
                       
                        if (index <= 9)
                        {
                            ex.SetCellValue(14 + index, 3, DTInsaccessory.Rows[i]["aAccStd"].ToString());    //品名
                            ex.SetCellValue(14 + index, 11, DTInsaccessory.Rows[i]["aMakeCode"].ToString());    //制造编号
                        }
                        else
                        {
                            ex.SetCellValue(14 + index - 10, 29, DTInsaccessory.Rows[i]["aAccStd"].ToString());
                            ex.SetCellValue(14 + index - 10, 37, DTInsaccessory.Rows[i]["aMakeCode"].ToString());
                        }
                        index++;
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
            InstallLoadFile fj1 = new InstallLoadFile(TaskCode_tb.Text, autoUserID);//autoUserID:用户ID
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

        private bool SaveJQJB()
        {
            int icount = 0;
            if (CB_installtype.Text == "主机安装")
                icount = 1;

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            //DataRow[] drs = DTInsaccessory.Select("((aAccCode like 'A%' or aAccCode like 'B%') and aAccCode like '%0001') or aAccCode like 'Z11%' or aAccCode like 'Z21%' or aAccCode='A100045' ");


            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            DataRow[] drs = DTInsaccessory.Select("(aAccCode like 'A11%' or aAccCode like 'A21%' or aAccCode like 'F11%' or aAccCode like 'F8101%' or aAccCode like 'F8201%' or aAccCode like 'G11%' or aAccCode like 'G8101%' or aAccCode like 'H11%' or aAccCode like 'H21%' or aAccCode like 'J81%'  or aAccCode like 'J82%' or aAccCode='B1012015' or aAccCode='B1012016' or aAccCode='B1012003' or aAccCode like 'J8101%' or aAccCode like 'J8201%' or aAccCode like 'K8101%' or aAccCode like 'L8101%' or aAccCode like 'L8201%' )");


            //if (drs.Length != icount)
            //{
            //    MessageBox.Show("主机安装只能一个主机，配件安装不能存在主机!");
            //    return false;
            //}
            if (icount == 0)
                return true;

            if (drs.Length != icount)
            {
                MessageBox.Show("主机安装只能一个主机，配件安装不能存在主机!");
                return false;
            }

            string sql = string.Format(@"select code,type,grade,model,cinvstd,productline from BaseMachineGrade where code = '{0}'", drs[0]["aAccCode"].ToString());
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("主机在机器级别档案中不存在!");
                return false;
            }

            sql = string.Format("update InstallTask set jqjbcode = '{1}',MachineModel='{2}',MachineLevel='{3}',MachineType='{4}',Color='{4}',tMakeCode='{5}',ProductLine='{6}' where tInsCode='{0}'"
                                         , TaskCode_tb.Text, dt.Rows[0]["code"].ToString(),dt.Rows[0]["model"].ToString()
                                         , dt.Rows[0]["grade"].ToString(), dt.Rows[0]["type"].ToString(), drs[0]["aMakeCode"].ToString(), dt.Rows[0]["productline"].ToString());
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
            return true;
        }
//        /// <summary>
//        /// 加载单号对应的科长
//        /// </summary>
//        /// <returns></returns>
//        private DataTable LoadManager(string insCode)
//        {
//            string sql = @"select distinct c.UserId,c.userName,c.Memo from InstallTask a 
//	                        inner join RegionToProvince b on a.City = b.ProvinceName
//	                        inner join Users c on b.deptNum = c.deptnum and c.ismanager=1
//	                        where a.tInsCode = '" + insCode + "'";
//            DataTable dtManager = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
//            return dtManager;
//        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check004();
            DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
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
            if (DTInstalltask.Rows.Count > 0 && Convert.ToString(DTInstalltask.Rows[0]["City"]).Length<=0)
            {
                MessageBox.Show("客户没有地级市,不能提交!");
                return;   
            }

            DataTable dtManager = Common.Common.Select_SQL_Region_ManageUser(Convert.ToString(DTInstalltask.Rows[0]["City"]), Convert.ToString(DTInstalltask.Rows[0]["tRegName"]));
            if (dtManager.Rows.Count <= 0)
            {
                MessageBox.Show("没有找到地级市对应的科长!");
                return;
            }
           
            string sql = "";
            if (button1.Text == "提交")
            {
                try
                {

                    if (!SaveJQJB())
                        return;
                    //string sql = "update InstallTask set tMessagedate = getDate(),tMessageId='" + autoUserID + "',tState = '已指派科长' where tInsCode='" + TaskCode_tb.Text + "'";
                    sql = "update InstallTask set tMessagedate = getDate(),tMessageId='" + autoUserID + "',tState = '安装请求' where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);

                    

                    TaskInite(TaskCode_tb.Text);
                   
                    this.DTP_TaskStart.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                   string strManager = string.Empty;
                    foreach (DataRow dr in dtManager.Rows)
                    {
                        if (strManager.Length > 0)
                            strManager += ",";
                        strManager += dr["userName"].ToString();
                        Bao.Message.CMessage.SendMessage("指派任务", "新的安装任务到了，请指定安装工程师", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                        
                    }
                    MessageBox.Show("成功提交科长指派任务,信息发送至[" + strManager + "].");
                    //发邮件
                    string mailmsg = string.Empty;
                    foreach(DataRow dr in dtManager.Rows) {
                        string op = "<br/>配件列表：";
                        foreach (DataRow item in DTInsaccessory.Rows)
                        {
                            op = op + "<br/>" + "规格型号：" + item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString() + "  数量：" + item["qty"].ToString();
                        }
                        mailmsg += string.Format("收件人[{0}]：", dr["userName"].ToString()) 
                                    +Message.sm_Email.SendEmail(dr["Memo"].ToString(), "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString() + op, true, 2)
                                    +"\r\n";
                    }
                    System.Windows.Forms.MessageBox.Show(mailmsg);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else //收回
            {
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
               
                if (DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    try
                    {
                        if (DTInstalltask.Rows[0]["tMessageId"].ToString() != autoUserID)
                        {
                            MessageBox.Show("无权收回，提交人为：" + DTInstalltask.Rows[0]["tMessageId"].ToString(), "提示");
                            return;
                        }
                        sql = "update InstallTask set tMessageId='',tState = '新任务',tMessagedate=null where tInsCode='" + TaskCode_tb.Text + "'";
                        RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                        TaskInite(TaskCode_tb.Text);
                        foreach (DataRow dr in dtManager.Rows)
                        {
                            Bao.Message.CMessage.SendMessage("指派消息收回！", "此指派任务已经收回，请您注意！", dr["userID"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                        }
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
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在！");
                    return;
                }
                //if (!(DTInstalltask.Rows[0]["InstallManagerCode"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
                //{   //客服经理
                //    MessageBox.Show("您没有权限");
                //    return;
                //}
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
                    MessageBox.Show("成功提交工程师[" + InsMangerName_tb.Text+ "]安装");

                    string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + InsManagercode_be.Text + "'");

                   // string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务", "医院：" + DTInstalltask.Rows[0]["tCusName"].ToString() + "指派人：" + UFBaseLib.BusLib.BaseInfo.UserName, false, 2);


                    string op = "<br/>配件列表：";

                
                    foreach (DataRow item in DTInsaccessory.Rows)
                    {
                        op = op + "<br/>" + "规格型号："+item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString() + "  数量：" + item["qty"].ToString();
                    }
                    //tInsCode,tCusName,tRegName,tComPhone,tComName,tInsType,tSummary,tMaiCode
                    string mailmsg = Message.sm_Email.SendEmail(emailaddress
                                                , "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" 
                                                + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" 
                                                + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() 
                                                + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() 
                                                + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() 
                                                + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() 
                                                + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() 
                                                + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString()+ op, true, 2);

                    System.Windows.Forms.MessageBox.Show(mailmsg);
                }
                else //收回
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "已指派")
                    {
                        MessageBox.Show("该单据不是已指派状态，不可以收回！");
                        return;
                    }
                    if (DTInstalltask.Rows[0]["tAuditMessageId"].ToString() != autoUserID)
                    {
                        MessageBox.Show("无权收回，由[" + DTInstalltask.Rows[0]["tAuditMessageId"].ToString() + "]指派!", "提示");
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
                        sql += " update InstallTask set tAuditMessageId='',tState = '安装请求',tAuditMessagedate=null where tInsCode='" + TaskCode_tb.Text + "';";
                    }
                    else
                    {
                        sql = " update InstallTask set tAuditMessageId='',tState = '安装请求',tAuditMessagedate=null where tInsCode='" + TaskCode_tb.Text + "'";
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
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
                if (DTInstalltask.Rows.Count == 0)
                {
                    MessageBox.Show("该单据不存在！");
                    return;
                }
                if (!(DTInstalltask.Rows[0]["tInsManger"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
                {
                    MessageBox.Show("您没有权限操作!");
                    return;
                }
                string accsql = string.Format(@"select r.InstallCode,r.AccType,r.UserId,r.AccName,r.ID,u.username,1 as [type] from InstallFile r left join users u on r.userid=u.userid  where InstallCode='{0}'
                                             union 
                                         select tInsCode as InstallCode,tAccType as AccType,'' as UserId,tAccName as AccName,tID,'' as username, 0 as [type] from InstallTask where tInsCode='{0}'  and tAccessories is not null", TaskCode_tb.Text);
                DataTable acctable = RiLiGlobal.RiLiDataAcc.ExecuteQuery(accsql);
                if (acctable.Rows.Count <= 0)
                {
                    MessageBox.Show("未上传附件,不能提交!");
                    return;
                }

                DataTable dtManager = Common.Common.Select_SQL_UserID_ManageUser(UFBaseLib.BusLib.BaseInfo.DBUserID);//LoadManager(TaskCode_tb.Text);//操作员对应的科长
                string strManages = string.Empty;
                //DataTable dtManager = Common.Common.Select_SQL_Region_ManageUser(DTInstalltask.Rows[0]["City"].ToString());
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
                    TaskInite(TaskCode_tb.Text);
                    foreach (DataRow dr in dtManager.Rows)
                    {
                        if (strManages.Length > 0)
                            strManages += ",";
                        strManages += dr["UserName"].ToString();
                        Bao.Message.CMessage.SendMessage("审核任务", "安装任务已经反馈，请您审核", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    }
                    MessageBox.Show("成功提交客服科长[" + strManages + "]审核");
                }
                else
                {
                    if (DTInstalltask.Rows[0]["tState"].ToString() != "待审核")
                    {
                        MessageBox.Show("该单据不是待审核状态，收回失败！");
                        return;
                    }
                    string sql = "update InstallTask set fMessageId='',tState = '已指派',fMessagedate=null where tInsCode='" + TaskCode_tb.Text + "'";
                    RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
                    TaskInite(TaskCode_tb.Text);
                    foreach (DataRow dr in dtManager.Rows)
                    {
                        if (strManages.Length > 0)
                            strManages += ",";
                        strManages += dr["UserName"].ToString();
                        Bao.Message.CMessage.SendMessage("审核任务收回", "审核任务已经收回，请您注意！", dr["userID"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Ins001", TaskCode_tb.Text);
                    }
                    button3.Text = "提交";
                    MessageBox.Show("成功从客服科长[" + strManages + "]收回！");
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
            DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
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
                            op = op + "<br/>" + "规格型号：" + item["aAccStd"].ToString() + "  制造编号：" + item["aMakeCode"].ToString() + "  数量：" + item["qty"].ToString();
                        }

                        string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的安装任务，编号：" + this.DTInstalltask.Rows[0]["tInsCode"].ToString(), "<br/>医院：" + this.DTInstalltask.Rows[0]["tCusName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.DTInstalltask.Rows[0]["tRegName"].ToString() + "<br/> 联系电话：" + this.DTInstalltask.Rows[0]["tComPhone"].ToString() + "<br/> 联系人：" + this.DTInstalltask.Rows[0]["tComName"].ToString() + "<br/> 安装类型：" + this.DTInstalltask.Rows[0]["tInsType"].ToString() + "<br/> 备注：" + this.DTInstalltask.Rows[0]["tSummary"].ToString() + "<br/> 主机机型：" + this.DTInstalltask.Rows[0]["tMaiCode"].ToString() + op, true, 2);

                        System.Windows.Forms.MessageBox.Show(mailmsg);
                        
                    }
                    else
                    {
                        MessageBox.Show("任务被销售管理部收回，无法指派客服科长");
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
                DTInstalltask = this.GetDtInstalltask(TaskCode_tb.Text); 
                if (DTInstalltask.Rows[0]["tState"].ToString() == "安装请求")
                {
                    try
                    {
                        string sql = "update InstallTask set tMessageId='',InstallUnit2 = null,InstallUnit1 = null,anzhcode1=null,anzhcode2=null,jqjbcode=null,MachineLevel = null,MachineType = null,MachineModel = null, Color = null,tState = '已指派科长' where tInsCode='" + TaskCode_tb.Text + "'";
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
                    MessageBox.Show("客服科长已经指派工程师，不可以收回！");
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

        private void txtJiQiJB_Leave(object sender, EventArgs e)
        {
            if (this.txtJiQiJB.Text.Trim().Length <= 0)
            {
                this.txtJiQiJB.BaoBtnCaption = string.Empty;
                this.MachineModel.Text = string.Empty;
                this.MachineLevel.Text = string.Empty;
                this.MachineType.Text = string.Empty;
                this.txtMainCode.Text = string.Empty;
                this.txtProductLine.Text = string.Empty;

                //修改：有两个颜色重复，所以在这里增加绑定
                this.Color.Text = string.Empty;
            }
        }

      
        private void txtJiQiJB_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            this.txtJiQiJB.BaoBtnCaption = dr["code"].ToString();
            this.MachineModel.Text = dr["model"].ToString();
            this.MachineLevel.Text = dr["grade"].ToString();
            this.MachineType.Text = dr["type"].ToString();

            this.txtProductLine.Text = dr["productline"].ToString();

            //修改：有两个颜色重复，所以在这里增加绑定
            this.Color.Text = dr["type"].ToString();
            this.txtMainCode.Text = dr["cinvstd"].ToString();
        }

        private void ClientCode_tb_OnBaoBeforClick(object sender, EventArgs e)
        {
            //if (DTInsaccessory.Rows.Count > 0)
            //{
            //    MessageBox.Show("不能选择");
            //    return;
            //}
        }

        /// <summary>
        /// 获取主机的规格型号，否则返回空
        /// </summary>
        /// <param name="saleCode"></param>
        /// <returns></returns>
        private void GetAccCode(DataTable dt, out string aAccCode, out string tMakeCode)
        {
            aAccCode = string.Empty;
            tMakeCode = "";

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            //DataRow[] drs = dt.Select("((aAccCode like 'A%' or aAccCode like 'B%') and aAccCode like '%0001') or aAccCode like 'Z11%' or aAccCode like 'Z21%' or aAccCode='A100045' ");


            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            DataRow[] drs = dt.Select("(aAccCode like 'A11%' or aAccCode like 'A21%' or aAccCode like 'F11%' or aAccCode like 'F8101%' or aAccCode like 'F8201%' or aAccCode like 'G11%' or aAccCode like 'G8101%' or aAccCode like 'H11%' or aAccCode like 'H21%' or aAccCode like 'J81%'  or aAccCode like 'J82%' or aAccCode='B1012015' or aAccCode='B1012016' or aAccCode='B1012003' or aAccCode like 'J8101%' or aAccCode like 'J8201%' or aAccCode like 'K8101%' or aAccCode like 'L8101%' or aAccCode like 'L8201%')");

            if (drs.Length > 0)
            {
                aAccCode = drs[0]["aAccCode"].ToString(); ;
                tMakeCode = drs[0]["aMakeCode"].ToString();
            }
        }

        /// <summary>
        /// 反馈结果的主机型号能否使用
        /// </summary>
        /// <param name="dt"></param>
        public void Maintypetask_tb_Enable(DataTable dt)
        {
            string aAccCode;
            string aMakeCode;

            if (UserRole.Contains("003"))
            {
                if (dt == null && dt.Rows.Count <= 0)
                    return;

                GetAccCode(dt, out aAccCode ,out aMakeCode);
                if (aAccCode == string.Empty)
                    Maintypetask_tb.Enabled = true;
                else
                    Maintypetask_tb.Enabled = false;
            }
        }

        private void RepairMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 & (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;  
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DragoutMachineCode(TaskCode_tb.Text);
        }

        private void gridView2_RowCountChanged(object sender, EventArgs e)
        {
            if (DTInsaccessory == null || (gridView2 == null || gridView2.RowCount == 0)) return;
            if (DTInsaccessory.Rows.Count > gridView2.RowCount)
            {
                DragoutMachineCode(TaskCode_tb.Text);
            }
        }
    }
}
