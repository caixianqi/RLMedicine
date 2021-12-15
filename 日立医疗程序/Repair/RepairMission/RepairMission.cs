using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using U8Global;
using UFBaseLib.BusLib;
using Bao.Message;

namespace Repair
{
    public partial class RepairMission :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {
        public RepairMission()
        {
            InitializeComponent();
            this.BO = new RepairMissionBill();
            BO.Init("");
            init();
        }
        public RepairMission(string id)
        {
            InitializeComponent();
            this.BO = new RepairMissionBill();
            BO.Init(id);
            init();
            IsMyBill(this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString());
            RelevanceDocumentsMenuStrip.Enabled = true;
        }

        public void init()
        {
            RelevanceDocumentsMenuStrip.Tag = "99999";
            foreach (Control item in this.Controls)
            {
                item.TabStop = false;
            }

            try
            {
                CustomerCode.BaoSQL = string.Format(@"select a.cCusCode,a.cCusName, c.ccCName,isnull(b.cDCName,c.ccCName) as cDCName
                                    from {0}.Customer a
                                    inner join {0}.DistrictClass b on a.cDCCode = b.cDCCode
                                    left join {0}.CustomerClass c on a.cCCCode = c.cCCCode
                                    where a.ccccode  like '2%' or a.ccccode like '1%'", U8DataAcc.U8ServerAndDataBase);
                CustomerCode.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称,ccCName=省份,cDCName=地级市";

                //CustomerCode.BaoSQL = "select cCusCode,cCusName from " + U8DataAcc.DataBase + ".Customer where ccccode  like '2%' or ccccode like '1%'";
                //CustomerCode.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
                this.CustomerCode.FrmHigth = 500;
                this.CustomerCode.FrmWidth = 500;
                CustomerCode.DecideSql = "select * from " + U8DataAcc.U8ServerAndDataBase + ".Customer where cCusCode=";
                CustomerCode.BaoColumnsWidth = "cCusCode=100,cCusName=150,ccCName=80,cDCName=80";
                CustomerCode.BaoClickClose = true;
                CustomerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerCode_OnLookUpClosed);



                CustomerDepartmentCode.BaoSQL = "select deptNum,deptName  from BaseDepartMent";
                CustomerDepartmentCode.BaoTitleNames = "deptNum=部门编码,deptName=部门名称";
                this.CustomerDepartmentCode.FrmHigth = 600;
                this.CustomerDepartmentCode.FrmWidth = 400;
                CustomerDepartmentCode.DecideSql = "select * from BaseDepartMent where deptNum=";
                CustomerDepartmentCode.BaoColumnsWidth = "deptNum=150,deptName=250";
                CustomerDepartmentCode.BaoClickClose = true;
                CustomerDepartmentCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerDepartmentName_OnLookUpClosed);


                cmbRepairTypeNew.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select code,code+'-'+name as name from BaseGuaranteeType order by code");
                cmbRepairTypeNew.DisplayMember = "name";
                cmbRepairTypeNew.ValueMember = "code";

                cmbRepairTypeEND.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select code,code+'-'+name as name from BaseGuaranteeType order by code");
                cmbRepairTypeEND.DisplayMember = "name";
                cmbRepairTypeEND.ValueMember = "code";

                //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
                /*MachineCode.BaoSQL = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataAcc.U8ServerAndDataBase + @".Inventory 
	                                where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21' or cinvcode='A100045')) ";*/


                //Lin 2020_07_14 新售后系统主机规则要求
                //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
                //2】 B1012015,B1012016,B1012003
                //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
                MachineCode.BaoSQL = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataAcc.U8ServerAndDataBase + @".Inventory 
	                                where (cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')"; 


                MachineCode.BaoTitleNames = "cInvCode=存货编码,cInvName=存货名称,cInvStd=规格型号";
                this.MachineCode.FrmHigth = 400;
                this.MachineCode.FrmWidth = 600;

                //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
                /*MachineCode.DecideSql = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataAcc.U8ServerAndDataBase + @".Inventory 
	                                where (((cinvcode like 'A%' or cinvcode like 'B%') and right(cinvcode,4) = '0001')  or (left(cinvcode,3)='Z11' or left(cinvcode,3)='Z21' or cinvcode='A100045' )) and cInvCode=";*/


                //Lin 2020_07_14 新售后系统主机规则要求
                //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
                //2】 B1012015,B1012016,B1012003
                //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15

                MachineCode.DecideSql = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataAcc.U8ServerAndDataBase + @".Inventory 
	                                where (cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%') and cInvCode=";


                MachineCode.BaoColumnsWidth = "cInvCode=100,cInvName=200,cInvStd=200";
                MachineCode.BaoClickClose = true;

                //MachineCode.BaoSQL = "select cinvcode,cinvname  from " + U8DataAcc.DataBase + ".inventory where (cinvcode like 'A%' or cinvcode like 'B%') and len(cinvcode) = 3";
                //MachineCode.BaoTitleNames = "cinvcode=存货编码 ,cinvname=存货名称";
                //this.MachineCode.FrmHigth = 600;
                //this.MachineCode.FrmWidth = 400;
                //MachineCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
                //MachineCode.BaoColumnsWidth = "cinvcode=150,cinvname=250";
                //MachineCode.BaoClickClose = true;

                MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);


                ZoneCode.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass";
                ZoneCode.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
                this.ZoneCode.FrmHigth = 600;
                this.ZoneCode.FrmWidth = 400;
                ZoneCode.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.U8ServerAndDataBase + ".DistrictClass where cDCCODE=";
                ZoneCode.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
                ZoneCode.BaoClickClose = true;

                ZoneCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(ZoneCode_OnLookUpClosed);

                CustomerManagerCode.BaoSQL = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002'";
                CustomerManagerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
                CustomerManagerCode.FrmHigth = 400;
                CustomerManagerCode.FrmWidth = 320;
                CustomerManagerCode.DecideSql = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002' and  userid =";
                CustomerManagerCode.BaoColumnsWidth = "userid=120,username=120";

                CustomerManagerCode.BaoClickClose = true;
                CustomerManagerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerManagerCode_OnLookUpClosed);

//                RepairPersonCode.BaoSQL = @"select distinct u.userid,u.username,r.RoleName,u.DeptName,bt.InstallUnit1,bt.InstallUnit2
//                                            from users u left join BaseInstallationUnitType bt on u.userid = bt.userid
//                                            left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru 
//                                            where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and rt.RegionId in (select RegionId from RegionToUser where UserId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')";
//                RepairPersonCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
//                RepairPersonCode.FrmHigth = 400;
//                RepairPersonCode.FrmWidth = 320;
//                RepairPersonCode.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and userid =";
//                RepairPersonCode.BaoColumnsWidth = "userid=120,username=120";

                RepairPersonCode.BaoSQL = @"select c.UserId,c.userName,e.RoleName,f.deptName,bt.InstallUnit1,bt.InstallUnit2
                                        from Users a
                                        left join BaseDepartMent b on b.deptNum like a.deptNum+'%'
                                        left join Users c on b.deptNum = c.deptnum
                                        left join BaseInstallationUnitType bt on c.userid = bt.userid
                                        left join TroleUsers d on c.AutoUserId=d.AutoUserId
                                        left join TRole e on d.RoleId = e.RoleId
                                        left join BaseDepartMent f on c.deptNum=f.deptNum
                                        where a.UserId='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and e.RoleId='003'";
                RepairPersonCode.BaoTitleNames = "userid=人员编码,username=人员姓名,InstallUnit1=安装单位1,InstallUnit2=安装单位2";
                RepairPersonCode.FrmHigth = 400;
                RepairPersonCode.FrmWidth = 600;
                RepairPersonCode.DecideSql = @"select c.UserId,c.userName,e.RoleName,f.deptName,bt.InstallUnit1,bt.InstallUnit2
                                            from Users a
                                            left join BaseDepartMent b on b.deptNum like a.deptNum+'%'
                                            left join Users c on b.deptNum = c.deptnum
                                            left join BaseInstallationUnitType bt on c.userid = bt.userid
                                            left join TroleUsers d on c.AutoUserId=d.AutoUserId
                                            left join TRole e on d.RoleId = e.RoleId
                                            left join BaseDepartMent f on c.deptNum=f.deptNum
                                            where e.RoleId='003' and a.userid =";
                RepairPersonCode.BaoColumnsWidth = "userid=120,username=120,InstallUnit1=100,InstallUnit2=100";


                RepairPersonCode.BaoClickClose = true;

                RepairPersonCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(RepairPersonCode_OnLookUpClosed);


                txtJiQiJB.BaoSQL = "select code,type,grade,model,cinvstd,isnull(productline,'') as productline from BaseMachineGrade";
                txtJiQiJB.BaoTitleNames = "code=编码,type=类型,grade=级别,model=型号,cinvstd=U8存货代码,productline=产品线";
                txtJiQiJB.FrmHigth = 600;
                txtJiQiJB.FrmWidth = 750;
                txtJiQiJB.DecideSql = "select code,type,grade,model,cinvstd,isnull(productline,'') as productline from BaseMachineGrade where code =";
                txtJiQiJB.BaoColumnsWidth = "code=80,type=120,grade=120,model=120,cinvstd=120,productline=100";
                txtJiQiJB.BaoClickClose = true;

                this.toolBarBill1.tssAddRow.Visible = false;
                this.toolBarBill1.tssAudit.Visible = false;
                this.toolBarBill1.tssPrint.Visible = false;
                this.toolBarBill1.tssUpLoad.Visible = false;
                this.toolBarBill1.BtnDeleteRow.Visible = false;
                this.toolBarBill1.btnEnd.Visible = false;
                this.toolBarBill1.BtnAddRow.Visible = false;
                this.toolBarBill1.BtnAudit.Visible = false;
                this.toolBarBill1.BtnUnAudit.Visible = false;
                this.toolBarBill1.BtnUpLoad.Visible = false;
                this.toolBarBill1.BtnExcel.Visible = false;
                this.toolBarBill1.BtnAuditList.Visible = false;
                this.toolBarBill1.tssLocation.Visible = false;
                this.toolBarBill1.BtnLocation.Visible = false;
                this.toolBarBill1.BtnUnUpLoad.Visible = false;


                this.toolBarBill1.OnBaoCancel += new FrmLookUp.ToolBarBill.BaoCancel(toolBarBill1_OnBaoCancel);
                this.toolBarBill1.OnAfterBaoCancel += new FrmLookUp.ToolBarBill.AfterBaoCancel(toolBarBill1_OnAfterBaoCancel);



                if (this.BO.EntityTables[0].Table.Rows.Count > 0)
                {                    
                    if (this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString() == string.Empty)
                    {
                        this.button1.Text = "提交";
                    }
                    else
                    {
                        this.button1.Text = "收回";
                    }
                    if (this.BO.EntityTables[0].Table.Rows[0]["AuditMissonUser"].ToString() == string.Empty)
                    {
                        this.button4.Text = "审核";
                    }
                    else {
                        this.button4.Text = "弃审";                        
                    }

                    if (this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() == string.Empty)
                    {
                        this.button2.Text = "提交";
                    }
                    else
                    {
                        this.button2.Text = "收回";
                    }
                }

                //根据省份指定大区
                this.RegionName.Text = string.Empty;

                if (!(this.BO.EntityTables[0].Table.Rows[0]["ZoneCode"].ToString() == string.Empty))
                {
                    this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.BO.EntityTables[0].Table.Rows[0]["ZoneCode"].ToString());
                }

                //权限控制
                RoleController();
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败：" + ex.Message);
            }

        }


        public override void IsMyBill(string RepairMissionCode)
        {
            //base.IsMyBill(RepairMissionCode);

               //if (this.BO.EntityTables[0].Table.Rows[0]["UserId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID)
               // {
               //     foreach (Control item in this.Controls)
               //     {
               //         item.Enabled = true;
               //     }
               // }

           
        }

        void toolBarBill1_OnAfterBaoCancel(object sender, EventArgs e)
        {

            CtrEnable(false);
            if (this.BO.BillId == string.Empty)
            {
                this.txtPerBill.Text = null;
                this.RepairMissionCode.Text = null;
                this.CustomerCode.Text = null;
                this.CustomerName.Text = null;
                this.txtxsCusName.Text = null;
                this.CustomerDepartmentCode.Text = null;
                this.CustomerDepartmentName.Text = null;
                this.MachineCode.Text = null;
                this.MachineName.Text = null;
                this.ManufactureCode.Text = null;
                this.SoftwareVersion.Text = null;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtfSN2.Text = null;

                this.ReportRepartDate.Text = null;
                this.PurchaseDate.Text = null;
                this.ZoneCode.Text = null;
                this.RepairType.Text = null;
                this.RepairSource.Text = null;
                this.RepairContractPeople.Text = null;
                this.ContractNumber.Text = null;
                this.FaxNumber.Text = null;

                //(kelle 2021-11-26 修改) 日立售后新系统（2021年度需求）
                this.txtGuaranteeNo.Text = null;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtrInsShop.Text = null;

                this.FaultDetails.Text = null;

                this.CustomerManagerCode.Text = null;
                this.CustomerManagerName.Text = null;


                this.RepairPersonName.Text = null;
                this.RepairPersonCode.Text = null;
                this.txtTSBXYD.Text = null;
                this.cmbRepairTypeNew.Text = null;
                this.dtimeFH.Text = null;
                this.dtimeGC.Text = null;
                this.dtimeFHBX.Text = null;
                this.dtimeGCBX.Text = null;
                this.dtimeAZBX.Text = null;

                this.txtJiQiJB.BaoBtnCaption = null;
                this.txtJiQiJB.Text = null;
                this.MachineType.Text = null;
                this.MachineModel.Text = null;
                this.MachineLevel.Text = null;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtProductLine.Text = null;

                this.Color.Text = null;

                BO.Init("");
                BaoUnDataBinding();
                BaoDataBinding();

            }
            else
            {
                string id = this.BO.BillId;
                Repair.RepairMission ff = new RepairMission(id);
                ff.MdiParent = this.MdiParent;

                this.Hide();

                ff.Show();

                this.Close();


            }
        }

        void toolBarBill1_OnBaoCancel(object sender, EventArgs e)
        {
          
        }       

        public override void NewButtonAfter()
        {
            base.NewButtonAfter();
            RoleController();
            this.toolBarBill1.BtnDelete.Enabled = false;
            this.txtTSBXYD.Text = "12";
        }

        void ZoneName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
         
        }

        public override void NewButtonBefor()
        {
            base.NewButtonBefor();

            this.button1.Text = "提交";
            this.button2.Text = "提交";
            BO.BillId = Guid.NewGuid().ToString();
            //权限控制
            RoleController();
         
        }

        public override void UpdateButtonBefor()
        {
           
           
           

            

        }

        public override void UpdateButtonAfter()
        {
            RoleController();
            this.toolBarBill1.BtnDelete.Enabled = false;
        }
       

        public void RoleController()
        {
            //先屏蔽所有的
            this.RepairPersonName.ReadOnly = true;
            foreach (Control item in groupBox1.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBox2.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBox3.Controls)
            {
                item.Enabled = false;
            }
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button4.Visible = false;
            this.toolBarBill1.BtnAddNew.Visible = false;
            this.toolBarBill1.BtnDelete.Visible = false;


            //800客服

            //按下修改按钮的时候，根据权限显示
           
                if (BaseInfo.userRole.Contains("001"))
                {
                    this.button1.Visible = true;
                    this.toolBarBill1.BtnAddNew.Visible = true;

                    //问题：800可以在维修列表上双击维修单据后，可以修改数据。
                    //解决：根据状态，是否给800修改
                    if (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "" || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "新任务" || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修请求")
                    {
                        this.button1.Enabled = true;
                        this.toolBarBill1.BtnDelete.Visible = true;
                        if (toolBarBill1.BtnModify.Enabled == false)
                        {
                            //问题：800 在收回状态时，不能修改数据
                            //触屏：只有在提交时，才可以修改，因此增加一个条件判断，否则只能收回按钮可用
                            if (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "" || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "新任务")
                            {
                                foreach (Control item in groupBox1.Controls)
                                {
                                    item.Enabled = true;
                                }
                            }
                            else
                            {
                                this.button1.Enabled = true;
                            }
                            /*
                             ------------原始代码---2012-12-05----------
                             foreach (Control item in groupBox1.Controls)
                            {
                                item.Enabled = true;
                            }
                            --------------------------------------- 
                            */
                        }
                    }
                    else
                    {
                        this.toolBarBill1.BtnDelete.Visible = false;
                        this.toolBarBill1.BtnModify.Visible = false;
                    }
                    

                    /*
                   ---------下面为原始代码---2012-12-05-----------
                    this.button1.Visible = true;
                    this.toolBarBill1.BtnAddNew.Visible = true;
                    this.toolBarBill1.BtnDelete.Visible = true;
                    if (toolBarBill1.BtnModify.Enabled == false)
                    {
                        foreach (Control item in groupBox1.Controls)
                        {
                             item.Enabled = true;
                        }
                    }
                   -------------------------------------
                    */
                }

                if (BaseInfo.userRole.Contains("010"))
                {
                    this.button4.Visible = true;
                    this.toolBarBill1.BtnAddNew.Visible = false;
                    this.toolBarBill1.BtnDelete.Visible = false;
                    this.toolBarBill1.BtnModify.Visible = false;
                    if (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修已审核"
                        || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修请求")
                    {
                        //if (this.button4.Text != "弃审") //审核后，不弃审，需要变更
                        this.button4.Enabled = true;
                        //this.toolBarBill1.BtnModify.Visible = true;
                        //this.cmbRepairTypeEND.Enabled = this.button4.Text=="审核";
                        this.toolBarBill1.BtnModify.Visible = this.button4.Text == "审核";
                        this.toolBarBill1.BtnModify.Visible = true;
                    }
                    if (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修请求")
                    {
                        
                        this.cmbRepairTypeEND.Enabled = !this.toolBarBill1.BtnModify.Enabled;
                    }
                    
                }

                //是当前的客户经理才能解锁
                //if ((BaseInfo.userRole.Contains("002") || BaseInfo.userRole.Contains("008") || BaseInfo.userRole.Contains("009")) 
                //    && (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修已审核" || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "已分派"))     //2012-12-04 修改：加多一个判断条件 -- this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "已分派"
                if (Common.Common.IS_SQL_Region_ManageUser(this.BO.EntityTables[0].Table.Rows[0]["city"].ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID)
                    && (this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "维修已审核" || this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() == "已分派")) 
                {
                    this.button2.Visible = true;
                    this.button2.Enabled = true;
                    this.toolBarBill1.BtnModify.Visible = true;
                    if (toolBarBill1.BtnModify.Enabled == false && this.BO.EntityTables[0].Table.Rows[0]["State"].ToString() != "已分派")
                    {
                        foreach (Control item in groupBox2.Controls)
                        {
                            item.Enabled = true;
                        }
                    }
                }

                //加个控制，就是说，如果已经指派人了，那么这个单据的上半部分是不能改的
            //    if (!(this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString() == string.Empty))
            //    {

            //        foreach (Control item in groupBox1.Controls)
            //        {
            //            item.Enabled = false;
            //        }

            //    }
            //    this.button1.Enabled = true;

             
            //    if (!(this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() == string.Empty))
            //    {
            //        foreach (Control item in groupBox2.Controls)
            //        {
            //            item.Enabled = false;
            //        }
            //    }
            
            //this.button1.Enabled = true;
            //this.button2.Enabled = true;
        }


 

        void CustomerManagerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerManagerCode.BaoBtnCaption = e.ReturnRow1["userid"].ToString();
            this.ReManager.Text = e.ReturnRow1["userid"].ToString();
            this.CustomerManagerName.Text = e.ReturnRow1["username"].ToString();

            this.CustomerManagerCode.button2.Text = e.ReturnRow1["userid"].ToString();
        }

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.MachineCode.BaoBtnCaption = e.ReturnRow1["cinvcode"].ToString();
            //this.MachineName.Text = e.ReturnRow1["cinvname"].ToString();
            this.MachineName.Text = e.ReturnRow1["cInvStd"].ToString();

            DragoutMachineCode(e.ReturnRow1["cinvcode"].ToString());
        }

        void CustomerDepartmentName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerDepartmentCode.BaoBtnCaption = e.ReturnRow1["deptNum"].ToString();

            this.CustomerDepartmentName.Text = e.ReturnRow1["deptName"].ToString();

            this.ReDepartmentCode.Text = e.ReturnRow1["deptNum"].ToString();


          
        }
        public override void BaoDataBinding()
        {
            //this.txtCreateDate.DataBindings.Add("text", BO.EntityTables[0].Table, "CreateDate");
            ////...
            //this.gridControl1.DataSource = BO.EntityTables[1].Table;
            this.RepairMissionCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairMissionCode");

            this.CustomerCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "CustomerCode");
            this.CustomerCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerCode");

            this.CustomerName.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerName");
            this.txtxsCusName.DataBindings.Add("Text", BO.EntityTables[0].Table, "xsCusName");

            this.CustomerDepartmentCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "CustomerDepartmentCode");

            this.CustomerDepartmentCode.button2.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerDepartmentCode");

            this.CustomerDepartmentName.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerDepartmentName");

            this.ReDepartmentCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerDepartmentName");

            this.MachineCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "MachineCode");
            this.MachineCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "MachineCode");
            this.MachineName.DataBindings.Add("Text", BO.EntityTables[0].Table, "MachineName");

            //  this.CustomerManagerCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "CustomerManagerCode");

            this.CustomerManagerCode.button2.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerManagerCode");
            
            this.ReManager.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerManagerCode");



            //  this.CustomerManagerCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerManagerCode");

            
            this.CustomerManagerName.DataBindings.Add("Text", BO.EntityTables[0].Table, "CustomerManagerName");

            this.ManufactureCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "ManufactureCode");
            this.SoftwareVersion.DataBindings.Add("Text", BO.EntityTables[0].Table, "SoftwareVersion");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtfSN2.DataBindings.Add("Text", BO.EntityTables[0].Table, "fSN2");

            this.ReportRepartDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "ReportRepartDate");
            this.PurchaseDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "PurchaseDate");
            this.ZoneCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "ZoneCode");
            this.ZoneName.DataBindings.Add("Text", BO.EntityTables[0].Table, "ZoneName");

            this.RepairType.DataBindings.Add("SelectedValue", BO.EntityTables[0].Table, "RepairType");
            this.RepairType.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "RepairType");
            this.RepairType.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairType");

            this.cmbRepairTypeNew.DataBindings.Add("SelectedValue", BO.EntityTables[0].Table, "RepairtypeNew");
            this.cmbRepairTypeEND.DataBindings.Add("SelectedValue", BO.EntityTables[0].Table, "RepairtypeNew");
            this.label32.DataBindings.Add("Text", BO.EntityTables[0].Table, "AuditMissonDate");

            this.RepairSource.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairSource");
            this.RepairContractPeople.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairContractPeople");
            this.ContractNumber.DataBindings.Add("Text", BO.EntityTables[0].Table, "ContractNumber");
            this.FaxNumber.DataBindings.Add("Text", BO.EntityTables[0].Table, "FaxNumber");

            //(kelle 2021-11-26 修改) 日立售后新系统（2021年度需求）【维修任务】界面添加【保修编号】字段
            this.txtGuaranteeNo.DataBindings.Add("Text", BO.EntityTables[0].Table, "guaranteeNo");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtrInsShop.DataBindings.Add("Text", BO.EntityTables[0].Table, "rInsShop");

            this.FaultDetails.DataBindings.Add("Text", BO.EntityTables[0].Table, "FaultDetails");

            this.txtPerBill.Text = Common.Common.GetUserName(((System.Data.DataTable)BO.EntityTables[0].Table).Rows[0]["userID"].ToString());
            //   this.RepairPersonCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "RepairPersonCode");
            this.RepairPersonCode.button2.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
            this.ReEng.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
            //       this.RepairPersonCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
            this.RepairPersonName.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonName");

            this.SubmitPersonDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitPersonDate");
            this.dtimeFH.DataBindings.Add("Text", BO.EntityTables[0].Table, "dtimefh_t");
            this.dtimeGC.DataBindings.Add("Text", BO.EntityTables[0].Table, "dtimegc_t");
            this.dtimeFHBX.DataBindings.Add("Text", BO.EntityTables[0].Table, "dtimefhbx_t");
            this.dtimeGCBX.DataBindings.Add("Text", BO.EntityTables[0].Table, "dtimegcbx_t");
            this.dtimeAZBX.DataBindings.Add("Text", BO.EntityTables[0].Table, "dtimeazbx_t");
            this.txtTSBXYD.DataBindings.Add("Text", BO.EntityTables[0].Table, "tdbxyd");

            this.SubmitPersonUser.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitPersonUser");
            this.SubmitMissonUser.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitMissonUser");
            this.RepairUnit1.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairUnit1");
            this.RepairUnit2.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairUnit2");
           

            this.City.DataBindings.Add("Text", BO.EntityTables[0].Table, "City");
            this.MachineType.DataBindings.Add("Text", BO.EntityTables[0].Table, "MachineType");
            this.MachineModel.DataBindings.Add("Text", BO.EntityTables[0].Table, "MachineModel");
            this.MachineLevel.DataBindings.Add("Text", BO.EntityTables[0].Table, "MachineLevel");

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtProductLine.DataBindings.Add("Text", BO.EntityTables[0].Table, "ProductLine");

            this.txtJiQiJB.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "jqjbcode");
            this.txtJiQiJB.DataBindings.Add("Text", BO.EntityTables[0].Table, "jqjbcode");
            this.Color.DataBindings.Add("Text", BO.EntityTables[0].Table, "Color");
            this.Color.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "Color");
            this.SubmitMissonDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitMissonDate");
        }

        public override void BaoUnDataBinding()
        {


            base.BaoUnDataBinding();
            this.SubmitMissonDate.DataBindings.Clear();
            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();
            this.txtxsCusName.DataBindings.Clear();
            this.CustomerDepartmentCode.DataBindings.Clear();
            this.CustomerDepartmentName.DataBindings.Clear();
            this.MachineCode.DataBindings.Clear();
            this.MachineName.DataBindings.Clear();
            this.ManufactureCode.DataBindings.Clear();
            this.SoftwareVersion.DataBindings.Clear();

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtfSN2.DataBindings.Clear();

            this.ReportRepartDate.DataBindings.Clear();
            this.PurchaseDate.DataBindings.Clear();
            this.ZoneCode.DataBindings.Clear();
            this.ZoneName.DataBindings.Clear();
            this.RepairType.DataBindings.Clear();
            this.RepairSource.DataBindings.Clear();
            this.RepairContractPeople.DataBindings.Clear();
            this.ContractNumber.DataBindings.Clear();
            this.FaxNumber.DataBindings.Clear();
            //(kelle 2021-11-26 修改) 日立售后新系统（2021年度需求）
            this.txtGuaranteeNo.DataBindings.Clear();

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtrInsShop.DataBindings.Clear();

            this.FaultDetails.DataBindings.Clear();
            this.RepairPersonCode.DataBindings.Clear();
            this.SubmitPersonDate.DataBindings.Clear();
            this.CustomerManagerCode.DataBindings.Clear();
            this.CustomerManagerName.DataBindings.Clear();
            this.CustomerManagerCode.button2.DataBindings.Clear();
            this.RepairPersonCode.button2.DataBindings.Clear();
            this.CustomerDepartmentCode.button2.DataBindings.Clear();
            this.RepairPersonCode.DataBindings.Clear();
            this.RepairPersonName.DataBindings.Clear();
            this.SubmitMissonUser.DataBindings.Clear();
            this.SubmitPersonUser.DataBindings.Clear();
            this.ReEng.DataBindings.Clear();
            this.ReDepartmentCode.DataBindings.Clear();
            this.ReManager.DataBindings.Clear();
            this.RepairUnit1.DataBindings.Clear();
            this.RepairUnit2.DataBindings.Clear();
           
            this.City.DataBindings.Clear();
            this.MachineType.DataBindings.Clear();
            this.MachineModel.DataBindings.Clear();
            this.MachineLevel.DataBindings.Clear();


            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtProductLine.DataBindings.Clear();

            this.txtJiQiJB.DataBindings.Clear();
            this.Color.DataBindings.Clear();

            this.cmbRepairTypeNew.DataBindings.Clear();
            this.txtTSBXYD.DataBindings.Clear();
            this.dtimeAZBX.DataBindings.Clear();
            this.dtimeFH.DataBindings.Clear();
            this.dtimeFHBX.DataBindings.Clear();
            this.dtimeGC.DataBindings.Clear();
            this.dtimeGCBX.DataBindings.Clear();

            this.cmbRepairTypeEND.DataBindings.Clear();
            this.label32.DataBindings.Clear();
        }
        void CustomerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerCode.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString();
            this.CustomerName.Text = e.ReturnRow1["cCusName"].ToString();
            this.ZoneName.Text = e.ReturnRow1["ccCName"].ToString();
            this.City.Text = e.ReturnRow1["cdCName"].ToString();

            this.ZoneCode.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString().Substring(1, 2);

            DragoutCustomerManager(e.ReturnRow1["cdCName"].ToString(), this.ZoneName.Text);
                
            
            //this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.ZoneCode.BaoBtnCaption + "'");
            //this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.ZoneCode.BaoBtnCaption);
        }

     

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ReportRepartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RepairPersonCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

            this.ReEng.Text = e.ReturnRow1["userid"].ToString();
            this.RepairPersonCode.Text = e.ReturnRow1["userid"].ToString();
            this.RepairPersonName.Text = e.ReturnRow1["username"].ToString();
            this.RepairUnit1.Text = e.ReturnRow1["InstallUnit1"].ToString();
            this.RepairUnit2.Text = e.ReturnRow1["InstallUnit2"].ToString(); 

        }

        


        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public override void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            

                base.toolBarBill1_OnBaoUpdate(sender, e);

           
            
          
        }
        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            string dd = this.CustomerManagerCode.Text;
            string bb = this.CustomerManagerName.Text;

            //购买日期>GC出库日期>本部发货日期，是正常。反过来不允许

            //purdate 购买日期
            DateTime purdate = this.PurchaseDate.Value;

            //dtimefh 本货发货日期
            DateTime dtimefh = this.dtimeFH.Value;

            //dtimegc GC出货日期
            DateTime dtimegc = this.dtimeGC.Value;

            string mesg = "";
            if (dtimegc > purdate)
           {
               mesg += "[GC出库日期不能大于购买日期]";
           }

           if (dtimefh > dtimegc)
           {
               mesg += "[本部发货日期不能大于GC出库日期]";
           }

           if (dtimefh > purdate)
           {
               mesg += "[本部发货日期不能大于购买日期]";
           }

           if (string.IsNullOrEmpty(mesg)==false)
           {
               throw new Exception(mesg);
           }


            //if (dd == string.Empty || bb == string.Empty)
            //{
            //}
            //else
            //{
            //    this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"] = dd;
            //    this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerName"] = bb;


            //    this.BO.EntityTables[0].Table.AcceptChanges();
            //}




            //if (this.RepairPersonCode.Text == string.Empty || this.RepairPersonName.Text == string.Empty)
            //{
            //}
            //else
            //{
            //    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"] = this.RepairPersonCode.Text;
            //    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonName"] = this.RepairPersonName.Text;


            //    this.BO.EntityTables[0].Table.AcceptChanges();
            //}
            base.toolBarBill1_OnBaoSave(sender, e);

            this.toolBarBill1.BtnDelete.Enabled = true;

          
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from repairmission where RepairMissionID = '" + this.BO.BillId + "'");
            if (dt.Rows[0]["UserId"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
            {
                throw new Exception("您没有权限");
            }
            DataTable dtUser = Common.Common.Select_SQL_Role_Users("010");// new DataTable();
            string strManager = string.Empty;
            if (this.button1.Text == "提交")
            {
                #region
                if (this.BO.BillId == string.Empty||RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from repairmission where RepairMissionID = '" + this.BO.BillId + "'").Rows.Count == 0)
                    throw new Exception("未保存，不能提交");

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                //判断逻辑，能否提交
                if ((dt.Rows[0]["CustomerManagerCode"].ToString() == string.Empty))
                {
                    throw new Exception("未指定负责经理，不能提交");
                }

                if (!(dt.Rows[0]["SubmitMissonUser"].ToString() == string.Empty))
                {
                    throw new Exception("不能重复提交");
                }

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                //建报修时不能直接选择[H]和[G],需要通过维修类型变更.
                //(吴嘉玲 2021-10-11 修改) 把H这个类型放开，允许直接提交 || this.BO.EntityTables[0].Table.Rows[0]["RepairtypeNew"].ToString() == "H" 
                //throw new Exception("维修类别不能选择[G]、[H]");
                if (this.BO.EntityTables[0].Table.Rows[0]["RepairtypeNew"].ToString() == "G" )
                {
                    throw new Exception("维修类别不能选择[G]");
                }
                if (this.BO.EntityTables[0].Table.Rows[0]["City"].ToString() == string.Empty)
                {
                    throw new Exception("地级市不能为空!");
                }

                this.SubmitMissonDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                this.SubmitMissonUser.Text = UFBaseLib.BusLib.BaseInfo.DBUserID;
                //this.CustomerManagerName.Text = 

                this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修请求";
                this.BO.UpdateSave();

                
                this.RepairMissionCode.Enabled = false;
                this.CustomerCode.Enabled = false;
                this.CustomerName.Enabled = false;
                this.CustomerDepartmentCode.Enabled = false;
                this.CustomerDepartmentName.Enabled = false;
                this.MachineCode.Enabled = false;
                this.MachineName.Enabled = false;
                this.ManufactureCode.Enabled = false;
                this.SoftwareVersion.Enabled = false;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtfSN2.Enabled = false;

                this.ReportRepartDate.Enabled = false;
                this.PurchaseDate.Enabled = false;
                this.ZoneCode.Enabled = false;
                this.RepairType.Enabled = false;
                this.RepairSource.Enabled = false;
                this.RepairContractPeople.Enabled = false;
                this.ContractNumber.Enabled = false;
                this.FaxNumber.Enabled = false;

                //(kelle 2021-11-26 修改) 日立售后新系统（2021年度需求）
                this.txtGuaranteeNo.Enabled = false;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtrInsShop.Enabled = false;

                this.FaultDetails.Enabled = false;
                this.RepairPersonCode.Enabled = false;
                this.SubmitPersonDate.Enabled = false;
                this.CustomerManagerCode.Enabled = false;
                this.CustomerManagerName.Enabled = false;
                this.cmbRepairTypeNew.Enabled = false;
                this.cmbRepairTypeEND.Enabled = false;
                this.txtTSBXYD.Enabled = false;
                this.dtimeGCBX.Enabled = false;
                this.dtimeGC.Enabled = false;
                this.dtimeFHBX.Enabled = false;
                this.dtimeFH.Enabled = false;
                this.dtimeAZBX.Enabled = false;

                this.txtJiQiJB.Enabled = false;
                //发消息给管理部长
    
                string mailmsg = string.Empty;
               
                foreach (DataRow dr in dtUser.Rows)
                {
                    if (strManager.Length > 0)
                        strManager += ",";
                    strManager += dr["userName"].ToString();
                    //string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where RepairMissionID = '" + this.BO.BillId + "'");
                    CMessage.SendMessage("新维修任务请求审核.", "有新的维修任务，请审核维修类型。", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);
                    this.button1.Text = "收回";

                    //string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + userid + "'");
                    if (dr["Memo"].ToString().Trim().Length <= 0)
                        continue;
                    mailmsg += "\r\n发送至：" + dr["UserName"].ToString() + Message.sm_Email.SendEmail(dr["Memo"].ToString(), "有新的维修任务需要审核,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString()
                                       ,"<br/> 医院："
                                        + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 省份："
                                        + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话："
                                        + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人："
                                        + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述："
                                        + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型："
                                        + this.BO.EntityTables[0].Table.Rows[0]["MachineModel"].ToString() + "<br/> 维修性质："
                                        + this.BO.EntityTables[0].Table.Rows[0]["RepairTypeNew"].ToString() + "<br/>", true, 2);

                    //mailmsg += Message.sm_Email.SendEmail(dr["Memo"].ToString(), "发送至：" + dr["UserName"].ToString() + "有新的维修任务,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString(), "<br/> 医院：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["MachineName"].ToString() + "<br/> 维修性质：" 
                    //        + this.BO.EntityTables[0].Table.Rows[0]["RepairTypeNew"].ToString()+"<br/>", true, 2);
                }
                if (mailmsg.Length>0)
                    System.Windows.Forms.MessageBox.Show("邮件系统："+mailmsg);

                System.Windows.Forms.MessageBox.Show("提交成功,消息发送至：[" + strManager+"]");
                #endregion
            }
            else if(this.button1.Text == "收回")
            {
                #region
                string RepairMissionID = dt.Rows[0]["RepairMissionID"].ToString();
                //判断逻辑，能否收回
                string ErrMsg = string.Empty;

                if (!string.IsNullOrEmpty(dt.Rows[0]["AuditMissonUser"].ToString()))
                {
                    ErrMsg += "[管理部部长已经审核，无法收回]";
                }

                if (ErrMsg == string.Empty)
                {
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonDate"] = DBNull.Value;
                    this.BO.EntityTables[0].Table.Rows[0]["State"] = "新任务";
                    this.BO.UpdateSave();

                    foreach (DataRow dr in dtUser.Rows)
                    {
                        if (strManager.Length > 0)
                            strManager += ",";
                        strManager += dr["userName"].ToString();

                        CMessage.SendMessage("维修任务收回", "有维修任务被收回", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);
                    }
                    System.Windows.Forms.MessageBox.Show("收回成功,信息发送至:[" + strManager + "]");

                    this.button1.Text = "提交";
                }
                else
                {
                       throw new Exception(ErrMsg);
                }
                #endregion

            }
            RoleController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from repairmission where RepairMissionID = '" + this.BO.BillId + "'");
            //if (dt.Rows[0]["CustomerManagerCode"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
            //{
            //    throw new Exception("您没有权限");
            //}
            if (this.button2.Text == "提交")
            {
                if (dt.Rows[0]["RepairPersonName"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("未指定工程师，不能提交");
                    return;
                }
                if (dt.Rows[0]["AuditMissonUser"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("管理部部长未审核，不能提交");
                    return;
                }

                //找工程师对应的上级
                DataTable temp_dt = Common.Common.Select_SQL_UserID_ManageUser(this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"].ToString());
                //DataTable dtManager = Common.Common.Select_SQL_UserID_ManageUser(UFBaseLib.BusLib.BaseInfo.DBUserID);//LoadManager(TaskCode_tb.Text);//操作员对应的科长
                if (temp_dt == null || temp_dt.Rows.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("指定的工程师没有指定的上级，不能提交");
                    return;
                }


                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求） 改为原数据的值，因整合成大部门了，取消 找工程师对应的上级

                /*this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"] = temp_dt.Rows[0]["UserId"].ToString();
                this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerName"] = temp_dt.Rows[0]["userName"].ToString();*/

                this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"] = dt.Rows[0]["CustomerManagerCode"].ToString();
                this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerName"] = dt.Rows[0]["CustomerManagerName"].ToString();



                this.SubmitPersonDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
     
                this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["State"] = "已分派";
                //this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                //this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerName"] = UFBaseLib.BusLib.BaseInfo.UserName;
                //this.BO.EntityTables[0].Table.Rows[0]["State"] = "已分派";
                

                this.ReManager.Text = UFBaseLib.BusLib.BaseInfo.DBUserID;

                this.SubmitPersonUser.Text = UFBaseLib.BusLib.BaseInfo.DBUserID;

                this.BO.UpdateSave();

                System.Windows.Forms.MessageBox.Show("提交成功,信息发送至[" + RepairPersonName.Text+"]");

              
               

                this.SubmitPersonDate.Enabled = false;
                this.RepairPersonCode.Enabled = false;
                this.RepairPersonName.Enabled = false;
                this.button2.Text = "收回";

                //发消息给工程师
                CMessage.SendMessage("新维修任务", "有新的维修任务，请跟进", this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);


                string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"].ToString() + "'");
                string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的维修任务,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString(), "<br/> 医院：" + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话：" + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人：" + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述：" + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型：" + this.BO.EntityTables[0].Table.Rows[0]["MachineModel"].ToString() + "<br/> 维修性质：" + this.BO.EntityTables[0].Table.Rows[0]["RepairTypeNew"].ToString(), true, 2);

            
             //   System.Windows.Forms.MessageBox.Show("邮件系统：" + mailmsg);


                System.Windows.Forms.MessageBox.Show("邮件系统：" + mailmsg);

            }
            else if (this.button2.Text == "收回")
            {
                //判断逻辑，能否收回

                string RepairMissionID = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString();

                string ErrMsg = string.Empty;

                if (this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
                {
                    System.Windows.Forms.MessageBox.Show("只能由提交人:[" + this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString()+"]才能收回.");
                    return;
                }

                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FaultFeedback where RepairMissionID = '" + RepairMissionID + "'").Rows.Count > 0)
                {
                    ErrMsg += "[已经填写故障解决情况，不能收回]";
                }
                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FreeApplication where RepairMissionID = '" + RepairMissionID + "'").Rows.Count > 0)
                {
                    ErrMsg += "[已经填写免费申请，不能收回]";
                }
                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where RepairMissionID = '" + RepairMissionID + "'").Rows.Count > 0)
                {
                    ErrMsg += "[已经填写配件申请，不能收回]";
                }
                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Price where RepairMissionID = '" + RepairMissionID + "'").Rows.Count > 0)
                {
                    ErrMsg += "[已经填写报价单，不能收回]";
                }


                if (ErrMsg == string.Empty)
                {
                    string engcode = this.RepairPersonCode.Text;
                    string engName = this.RepairPersonName.Text;
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonDate"] = DBNull.Value;
                    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonName"] = null;

                    //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）客户经理不能清空

                    //this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"] = null;
                    //this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerName"] = null;

                    this.BO.EntityTables[0].Table.Rows[0]["RepairUnit1"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["RepairUnit2"] = null;

                    this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修已审核";    //2012-12-04 修改：“维修请求”已修改为“维修已审核”
                    this.SubmitPersonUser.Text = string.Empty;
                  

                    this.BO.UpdateSave();
                    CMessage.SendMessage("维修任务收回", "有维修任务被收回", engcode, UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);

                    System.Windows.Forms.MessageBox.Show("收回成功,信息发送至[" + engName + "]");

                    this.button2.Text = "提交";
                }
                else
                {
                    throw new Exception(ErrMsg);
                }
            }

            RoleController();
          
        }

        private void ZoneCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
               //this.ZoneCode.BaoBtnCaption = e.ReturnRow1["CDCNAME"].ToString();
            this.ZoneCode.BaoBtnCaption = e.ReturnRow1["CDccode"].ToString();
            this.ZoneName.Text = e.ReturnRow1["CDCNAME"].ToString();
            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(e.ReturnRow1["CDccode"].ToString());
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void FaultDetails_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FaultDetails_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CustomerName = string.Empty;
            string CustomerCode = string.Empty;
            string MachineName = string.Empty;
            string MachineCode = string.Empty;
            DateTime purcherDate = DateTime.Now;
            DateTime roportDate = this.ReportRepartDate.Value;
            DateTime sendTime = DateTime.Now;
            int baoxiu = 0;
            if (this.ManufactureCode.Text.Trim().Length <= 0)
                return;
            //tCusCode  --  客户编码
            //tCusName  --  客户名称
            //tMaiCode  --  主机机型
            //fEndTime  --  验收日期（安装完成日期）
            //fMainVersion  --  软件版本
            //tSendTime  --  发货日期（安装单填写）
            //tRepMonth  --  保存期限（安装单填写）
            //dtimegc  --  GC出库日期
            //dtimefh  --  本部发货日期
            //tCusCode  --  客户编码
            //tCusCode  --  客户编码
            //fCliManger    --  负责人
            //fCliPhone --  联系电话

            /*(((ina.aAccCode like 'A%' or ina.aAccCode like 'B%') and ina.aAccCode like '%0001') or ina.aAccCode like 'Z11%' or ina.aAccCode like 'Z21%' or ina.aAccCode='A100045')*/

            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15

            /*MachineCode.BaoSQL = @"select cInvCode,cInvAddCode,cInvName,cInvStd from " + U8DataAcc.U8ServerAndDataBase + @".Inventory 
	                                where (cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003')"; */


            string sql = string.Format(@"select i.tInsCode, tCusCode,tCusName,ina.aAccCode as tMaiCode, ina.aAccStd
                                                    , (select MAX(rInsEnd) from InsDetail z where z.rTaskCode  = i.tInsCode) as fEndTime,fMainVersion,tSendTime,
			                                        tRepMonth, ins.fCliManger, ins.fCliPhone, ina.dtimegc, ina.dtimefh,i.tAgeStore,ina.aMakeCode,isnull(ins.fSN2,'') as fSN2
		                                        from InstallTask i
			                                    left outer join InsFeedback ins on ins.fTaskCode = i.tInsCode
			                                    left outer join InsAccessory ina on ina.aTaskCode = i.tInsCode
		                                        where (aMakeCode = '{0}' or (aMakeCode like '%{0}' and len(aMakeCode) = 8 + len('{0}'))) and  (ina.aAccCode  like 'A11%' or ina.aAccCode like 'A21%' or ina.aAccCode like 'F11%' or ina.aAccCode like 'F8101%' or ina.aAccCode like 'F8201%' or ina.aAccCode like 'G11%' or ina.aAccCode like 'G8101%' or ina.aAccCode like 'H11%' or ina.aAccCode like 'H21%' or ina.aAccCode like 'J81%'  or ina.aAccCode like 'J82%' or ina.aAccCode='B1012015' or ina.aAccCode='B1012016' or ina.aAccCode='B1012003' or ina.aAccCode like 'J8101%' or ina.aAccCode like 'J8201%' or ina.aAccCode like 'K8101%' or ina.aAccCode like 'L8101%' or ina.aAccCode like 'L8201%')
                              union all
                                select i.tInsCode, tCusCode,tCusName,c.code as tMaiCode, i.tMaiCode as aAccStd
                                            , (select MAX(rInsEnd) from InsDetail z where z.rTaskCode  = i.tInsCode) as fEndTime,fMainVersion,tSendTime
                                            ,tRepMonth, ins.fCliManger, ins.fCliPhone, CONVERT(nvarchar(10),i.tSendTime,120) as dtimegc, null as dtimefh
                                            ,i.tAgeStore,i.tMakeCode as aMakeCode,isnull(ins.fSN2,'') as fSN2 
                                from InstallTask i
                                left outer join InsFeedback ins on ins.fTaskCode = i.tInsCode
                                left join BaseMachineGrade c on i.tMaiCode = c.model
                                --left outer join InsAccessory ina on ina.aTaskCode = i.tInsCode
                                where (i.tMakeCode = '{0}' or (i.tMakeCode like '%{0}' and len(i.tMakeCode) = 8 + len('{0}'))) and isnull(tMaiCode,'')<>''
                                union all
                            select tInsCode, tCusCode,tCusName,b.code,tMaiCode, fEndTime,fMainVersion,tSendTime,tRepMonth,fCliManger,fCliPhone, dtimegc, dtimefh,'' as tAgeStore,fMainMake as aMakeCode,'' as fSN2
                            from HistoryInstallTask a
                            left join BaseMachineGrade b on a.aAccStd = b.cinvstd
--                            left join {1}.Customer c on c.cCusCode = a.tCusCode
                            where fMainMake='{0}' or (fMainMake like '%{0}' and len(fMainMake) = 8 + len('{0}'))", this.ManufactureCode.Text.Trim(), U8DataAcc.U8ServerAndDataBase); //“1”是历史表，“0”是安装表

            DataTable installData = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);

            if (installData.Rows.Count == 0)
            {
                return;
            }

            this.CustomerCode.Text = "";
            this.CustomerName.Text = "";    //客户名称
            this.MachineName.Text = "";
            this.MachineCode.Text = "";     //主机机型
            this.SoftwareVersion.Text = "";        //软件版本

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtfSN2.Text = ""; //SN2

            this.RepairContractPeople.Text = "";  //负责人
            this.ContractNumber.Text = "";  //联系电话
            this.txtTSBXYD.Text = "";  //保存周期  
            this.txtxsCusName.Text = "";  //销售代理客户
            this.ManufactureCode.Text = ""; //制造编号

            this.CustomerManagerName.Text = "";
            this.CustomerManagerCode.button2.Text = "";
            this.ZoneName.Text = "";  //省份
            this.City.Text = "";  //地区

            this.txtJiQiJB.BaoBtnCaption = "";
            this.txtJiQiJB.Text = "";
            this.MachineLevel.Text = "";


            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtProductLine.Text = "";

            this.MachineModel.Text = "";
            this.MachineType.Text = "";
            this.Color.Text = "";

            this.MachineName.Text = "";

            this.CustomerCode.Text = installData.Rows[0]["tCusCode"].ToString();
            this.CustomerName.Text = installData.Rows[0]["tCusName"].ToString();    //客户名称
            this.MachineName.Text = installData.Rows[0]["aAccStd"].ToString();
            this.MachineCode.Text = installData.Rows[0]["tMaiCode"].ToString();     //主机机型
            this.SoftwareVersion.Text = installData.Rows[0]["fMainVersion"].ToString();        //软件版本
            this.txtfSN2.Text = installData.Rows[0]["fSN2"].ToString(); //SN2

            this.RepairContractPeople.Text = installData.Rows[0]["fCliManger"].ToString();  //负责人
            this.ContractNumber.Text = installData.Rows[0]["fCliPhone"].ToString();  //联系电话
            this.txtTSBXYD.Text = installData.Rows[0]["tRepMonth"].ToString();  //保存周期  
            this.txtxsCusName.Text = installData.Rows[0]["tAgeStore"].ToString();  //销售代理客户
            this.ManufactureCode.Text = installData.Rows[0]["aMakeCode"].ToString(); //制造编号

            int debaoxiu = 12;
            if (txtTSBXYD.Text.Trim().Length > 0)
            {
                debaoxiu = Convert.ToInt32(txtTSBXYD.Text.Trim());
            }

            if (installData.Rows[0]["fEndTime"].ToString() != "")
            {
                DateTime.TryParse(installData.Rows[0]["fEndTime"].ToString(), out purcherDate); //购买日期
                this.PurchaseDate.Value = purcherDate;
            }

            sql = string.Format(@"select a.cCusCode,a.cCusName, c.ccCName,isnull(b.cDCName,c.ccCName) as cDCName
                                    from {0}.Customer a
                                    inner join {0}.DistrictClass b on a.cDCCode = b.cDCCode
                                    left join {0}.CustomerClass c on a.cCCCode = c.cCCCode
                                    where (a.ccccode  like '2%' or a.ccccode like '1%') and a.cCusCode='{1}'", U8DataAcc.U8ServerAndDataBase, this.CustomerCode.Text);
            DataTable dt = RiLiGlobal.RiLiDataAcc.GetDataSet(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.ZoneName.Text = dt.Rows[0]["ccCName"].ToString();  //省份
                this.City.Text = dt.Rows[0]["cDCName"].ToString();  //地区

                DragoutCustomerManager(dt.Rows[0]["cDCName"].ToString(), this.ZoneName.Text);
            }

            if (string.IsNullOrEmpty(installData.Rows[0]["dtimefh"].ToString()))
            {
                this.dtimeFH.Value = DateTime.Parse("1900-01-01");
                this.dtimeFHBX.Value = DateTime.Parse("1900-01-01");
            }
            else
            {

                this.dtimeFH.Text = installData.Rows[0]["dtimefh"].ToString();   //本部发货日期

                /*if (installData.Rows[0]["tMaiCode"].ToString().StartsWith("A") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("B"))
                    this.dtimeFHBX.Value = this.dtimeFH.Value.AddMonths(18);    //本部保修期限
                if (installData.Rows[0]["tMaiCode"].ToString().StartsWith("Z"))
                    this.dtimeFHBX.Value = this.dtimeFH.Value.AddMonths(14);    //本部保修期限*/


                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）保修到期日期在现有逻辑基础上减少1天

                this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(14)).AddDays(-1);


                //新的日期调整
                //H A0 B0 18个月
                //A1 A2 D1 Z 14月
                if (installData.Rows[0]["tMaiCode"].ToString().StartsWith("H") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("A0") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("B0"))
                {
                    this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(18)).AddDays(-1);    //本部保修期限 保修到期日期在现有逻辑基础上减少1天
                }

                if (installData.Rows[0]["tMaiCode"].ToString().StartsWith("A1") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("A2") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("D1") || installData.Rows[0]["tMaiCode"].ToString().StartsWith("Z"))
                {
                    this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(14)).AddDays(-1);    //本部保修期限 保修到期日期在现有逻辑基础上减少1天
                }

            }

            if (string.IsNullOrEmpty(installData.Rows[0]["dtimegc"].ToString()))
            {
                this.dtimeGC.Value = DateTime.Parse("1900-01-01");
                this.dtimeGCBX.Value = DateTime.Parse("1900-01-01");
            }
            else
            {
                this.dtimeGC.Text = installData.Rows[0]["dtimegc"].ToString();   //GC出库日期
                this.dtimeGCBX.Value = (dtimeGC.Value.AddMonths(debaoxiu + 2)).AddDays(-1); //GC保修期限 保修到期日期在现有逻辑基础上减少1天
            }

            this.dtimeAZBX.Value = (this.PurchaseDate.Value.AddMonths(debaoxiu)).AddDays(-1);   //安装保修期限 保修到期日期在现有逻辑基础上减少1天

            DragoutMachineCode(installData.Rows[0]["tMaiCode"].ToString());
            //this.ZoneCode.BaoBtnCaption = this.CustomerCode.Text.Substring(1, 2);
            //this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.ZoneCode.BaoBtnCaption + "'");
            //this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.ZoneCode.BaoBtnCaption);
            DateTime.TryParse(installData.Rows[0]["tSendTime"].ToString(), out sendTime);
            int.TryParse(installData.Rows[0]["tRepMonth"].ToString(), out baoxiu);
            //if (((roportDate - purcherDate).TotalDays < baoxiu * 30.4) && ( (roportDate - sendTime).TotalDays < baoxiu * 30.4 + 60.8))
            //{
            //    this.RepairType.Text = "保内";
            //}
            //else
            //{
            //    this.RepairType.Text = "保外";
            //}

        }

        private void RepairMission_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private ToolTip tt;
        private void RepairMission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tt != null)
                {
                    tt.Dispose();
                    tt = null;
                    return;
                   
                }
                tt = new ToolTip();
                tt.ShowAlways = true;

                tt.Show(FaultDetails.Text, FaultDetails);

               
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CustomerManagerName_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void RepairMission_Load(object sender, EventArgs e)
        {

        }

        private void PurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            //this.dtimeAZBX.Value = this.PurchaseDate.Value.AddMonths(12);
            this.txtTSBXYD_TextChanged(null, null);
        }

        private void dtimeGC_ValueChanged(object sender, EventArgs e)
        {
            //this.dtimeGCBX.Value = dtimeGC.Value.AddMonths(14);
            this.txtTSBXYD_TextChanged(null, null);
        }

        private void dtimeFH_ValueChanged(object sender, EventArgs e)
        {
            //this.dtimeFHBX.Value = this.dtimeFH.Value.AddMonths(14);
            this.txtTSBXYD_TextChanged(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }
            if (this.SaveAudit())
            {
                this.button4.Text = this.button4.Text == "审核" ? "弃审" : "审核";
                RoleController();
            }
        }

        /// <summary>
        /// 保存审核与弃审
        /// </summary>
        private bool SaveAudit()
        {
            try
            {
                if (!SaveAuditCondtion())
                    return false;
                if (this.button4.Text == "审核")
                {
                    return SavePerAudit();
                }
                else
                {
                    return SavePerUnAudit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.button4.Text + "时出错:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 审核条件
        /// </summary>
        /// <returns></returns>
        private bool SaveAuditCondtion()
        {
            string ErrMsg = string.Empty;

            //DataTable dt = Common.Common.Select_SQL_Region_ManageUser(this.BO.EntityTables[0].Table.Rows[0]["city"].ToString());
            //if (dt.Rows.Count <= 0)
            //{
            //    MessageBox.Show("未找到地区对应的部门科长.", "提示");
            //    return false;
            //}

            if (this.button4.Text == "弃审")
            {
                //判断逻辑，能否收回
                if (!string.IsNullOrEmpty(this.BO.EntityTables[0].Table.Rows[0]["RepairPersonName"].ToString()))
                {
                    ErrMsg += "[客服科长已经指派工程师，无法弃审]";
                    MessageBox.Show(ErrMsg);
                    return false;
                }
                if (this.BO.EntityTables[0].Table.Rows[0]["AuditMissonUser"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
                {
                    MessageBox.Show("审核人与弃核人不一致，无权操作!");
                    return false;
                }

            }
            else
            {
                if (string.IsNullOrEmpty(this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString()))
                {
                    ErrMsg += "[客服部门未提交，无法审核]";
                    MessageBox.Show(ErrMsg);
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <returns></returns>
        private bool SavePerAudit()
        {
            string RepairMissionID = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString();

            this.BO.EntityTables[0].Table.Rows[0]["AuditMissonUser"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
            this.BO.EntityTables[0].Table.Rows[0]["AuditMissonDate"] = RiLiGlobal.RiLiDataAcc.GetNow();
            this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修已审核";
            this.BO.UpdateSave();
            this.label32.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString();

            //string sql = string.Empty;
            //sql = string.Format("update RepairMission set AuditMissonUser = '{0}',AuditMissonDate=GETDATE(),State='维修已审核',RepairTypeNew='{2}' where RepairMissionID='{1}'"
            //        , UFBaseLib.BusLib.BaseInfo.UserName, RepairMissionID, this.BO.EntityTables[0].Table.Rows[0]["RepairTypeNew"].ToString());
            //RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql);

            //发消息给科长
            //string s = this.BO.EntityTables[0].Table.Rows[0]["city"].ToString();


            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            //DataTable dtUser = Common.Common.Select_SQL_Region_ManageUser(this.BO.EntityTables[0].Table.Rows[0]["city"].ToString());// new DataTable();

            //(Lin 2021-04-17 修改)发消息给指定客户经理
            DataTable dtUser = Common.Common.Select_SQL_Region_ManageUserByUserId(this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"].ToString());

            List<string> deptnum_list = new List<string>();
            //发消息给科长
            string strManager = SendAuditMessage(deptnum_list, dtUser, 0);
            
            //this.BO.EntityTables[0].Table.Rows[0]["AuditMissonUser"] = UFBaseLib.BusLib.BaseInfo.UserName;
            //this.BO.EntityTables[0].Table.Rows[0]["AuditMissonDate"] = DateTime.Now;
            //this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修已审核";
            MessageBox.Show("审核成功,信息发送至[" + strManager + "]!", "提示");
            return true;
        }

        /// <summary>
        /// 弃审
        /// </summary>
        /// <returns></returns>
        private bool SavePerUnAudit()
        {
            string RepairMissionID = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString();
            
            this.BO.EntityTables[0].Table.Rows[0]["AuditMissonUser"] = "";
            this.BO.EntityTables[0].Table.Rows[0]["AuditMissonDate"] = DBNull.Value;
            this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修请求";
            this.BO.UpdateSave();
            this.label32.Text = "";

            //string sql = string.Empty;
            //sql = string.Format("update RepairMission set AuditMissonUser = null,AuditMissonDate=null,State='维修请求' where RepairMissionID='{1}'", UFBaseLib.BusLib.BaseInfo.UserName, RepairMissionID);
            //RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql);

            // (Lin 2021-04-17 修改) 取消发消息给科长
           // DataTable dtUser = Common.Common.Select_SQL_Region_ManageUser(this.BO.EntityTables[0].Table.Rows[0]["city"].ToString());// new DataTable();

            //(Lin 2021-04-17 修改)发消息给指定客户经理
            DataTable dtUser = Common.Common.Select_SQL_Region_ManageUserByUserId(this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"].ToString());

            string mailmsg = string.Empty;

            string submitmissonuser_str = this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString();
            if (submitmissonuser_str != null)
            {
                CMessage.SendMessage("维修任务已弃审", "维修任务已被弃审", submitmissonuser_str, UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);
            }
            List<string> deptnum_list = new List<string>();
            string strManager = SendAuditMessage(deptnum_list, dtUser, 1);

            MessageBox.Show("弃审成功,信息发送至[" + strManager + "]!", "提示");
            return true;
        }


        /// <summary>
        /// 发送已审核消息
        /// </summary>
        /// <param name="dtUser">要发送的用户表</param>
        private void SendAuditMessage(DataRow dr)
        {
            string mailmsg = string.Empty;

            CMessage.SendMessage("新维修任务", "有新的维修任务，指派工程师", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);

            if (dr["Memo"].ToString().Trim().Length > 0)
                mailmsg += "\r\n发送至：" + dr["UserName"].ToString() + Message.sm_Email.SendEmail(dr["Memo"].ToString(), "有新的维修任务需要指派工程师,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString(), "<br/> 医院："
                        + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份："
                        + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话："
                        + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人："
                        + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述："
                        + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型："
                        + this.BO.EntityTables[0].Table.Rows[0]["MachineModel"].ToString() + "<br/> 维修性质："
                        + this.BO.EntityTables[0].Table.Rows[0]["RepairTypeNew"].ToString() + "<br/>", true, 2);

            if (mailmsg.Length > 0)
                System.Windows.Forms.MessageBox.Show("邮件系统：" + mailmsg);
        }

        /// <summary>
        /// 发送弃审消息
        /// </summary>
        /// <param name="dtUser">要发送的用户表</param>
        private void SendUnAuditMessage(DataRow dr)
        {
            CMessage.SendMessage("维修任务已弃审", "维修任务已被弃审", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);
        }

        /// <summary>
        /// 发送消息给用户及上级(/tyx2012-12-13审核，弃审只发给科长，上级取消)
        /// </summary>
        /// <param name="dtUser"></param>
        /// <param name="audit_State"></param>
        private string SendAuditMessage(List<string> deptnum_list, DataTable dtUser, int audit_State)
        {
            string strManager = string.Empty;
            foreach (DataRow dr in dtUser.Rows)
            {
                string temp_deptnum = dr["deptnum"].ToString();
                if (!IsSameDeptNum(deptnum_list, temp_deptnum))
                {
                    continue;
                }

                if (!IsPermissionRole(dr["userid"].ToString()))
                {
                    continue;
                }

                if (strManager.Length > 0)
                    strManager += ",";
                strManager += dr["userName"].ToString();
                switch (audit_State)
                {
                    case 0: //Audit
                        SendAuditMessage(dr);
                        break;
                    case 1: //UnAudit
                        SendUnAuditMessage(dr);
                        break;
                }

                //审核，弃审只发给科长
                //string sql = string.Format(@"select distinct UserId,userName,Memo,deptnum from users where deptnum in (select parentnum from BaseDepartMent where deptnum = '{0}')", temp_deptnum);
                //SendAuditMessage(deptnum_list, RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql), audit_State);
            }
            return strManager;
        }

        /// <summary>
        /// 是否有相同部门
        /// </summary>
        /// <param name="deptnum_list">部门列表</param>
        /// <param name="temp_deptnum">要对比的部门名称</param>
        /// <returns>不同返回True，否则返回False</returns>
        private bool IsSameDeptNum(List<string> deptnum_list, string temp_deptnum)
        {
            //部门不能为空，或者和前一个用户部门相同，否则下一个用户
            if (temp_deptnum != null && temp_deptnum != "")
            {
                foreach (string s in deptnum_list)
                {
                    if (s != temp_deptnum)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            deptnum_list.Add(temp_deptnum);
            return true;
        }

        /// <summary>
        /// 角色是否有权限
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>有权限就返回True，否则返回False</returns>
        private bool IsPermissionRole(string userid)
        {
            DataTable dtRoles = Common.Common.Select_SQL_Users_Role(userid);
            foreach (DataRow dr_Roles in dtRoles.Rows)
            {
                string RoleId = dr_Roles["RoleId"].ToString();
                if (RoleId == "002" || RoleId == "009" || RoleId == "010")
                {
                    return true;
                }
                else
                {
                    continue; ;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否打开维修任务单据
        /// </summary>
        /// <param name="RepairMissionID"></param>
        /// <param name="RepairMissionCode"></param>
        /// <returns></returns>
        private bool IsOpenRepairMissionInvoices(string RepairMissionID, string RepairMissionCode)
        {
            if (RepairMissionID.Equals("") || RepairMissionID == null)
            {
                MessageBox.Show("单据没打开！", "温馨提示！");
                return false;
            }

            if (RepairMissionCode.Equals("") || RepairMissionCode == null)
            {
                MessageBox.Show("单据没打开！", "温馨提示！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 关联单据——故障解决情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaultFeedbackTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.FaultFeedbackList listForm = new Repair.FaultFeedbackList(RepairMissionID);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }

        private void PartsApplicationTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.PartsApplicationList listForm = new Repair.PartsApplicationList(RepairMissionID);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }

        private void PartsInventoryTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.PartsInentoryList listForm = new Repair.PartsInentoryList(RepairMissionCode);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }

        private void PriceTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.PriceList listForm = new Repair.PriceList(RepairMissionID);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }

        private void BillTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.BillList listForm = new Repair.BillList(RepairMissionCode);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }

        private void FreeApplicationTSMItem_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.FreeApplicationList listForm = new Repair.FreeApplicationList(RepairMissionID);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
            else
            {
                return;
            }
        }


        private void btnPartsInentoryNewList_Click(object sender, EventArgs e)
        {
            string RepairMissionID = this.BO.BillId;
            string RepairMissionCode = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            if (IsOpenRepairMissionInvoices(RepairMissionID, RepairMissionCode))
            {
                Repair.PartsInentoryNewList listForm = new PartsInentoryNewList(RepairMissionCode);// Repair.PartsInentoryList(RepairMissionCode);
                listForm.MdiParent = this.ParentForm;
                listForm.Show();
            }
        }

        private void txtJiQiJB_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            this.txtJiQiJB.BaoBtnCaption = dr["code"].ToString();
            this.txtJiQiJB.Text = dr["code"].ToString();
            this.MachineLevel.Text = dr["grade"].ToString();

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            this.txtProductLine.Text = dr["productline"].ToString();

            this.MachineModel.Text = dr["model"].ToString();
            this.MachineType.Text = dr["type"].ToString();
            //修改：有两个颜色重复，所以在这里增加绑定
            this.Color.Text = dr["type"].ToString();

            this.MachineName.Text = dr["cinvstd"].ToString();

            txtTSBXYD_TextChanged(null, null);
        }

        private void txtJiQiJB_Leave(object sender, EventArgs e)
        {
            if (this.txtJiQiJB.Text.Trim().Length <= 0)
            {
                this.txtJiQiJB.BaoBtnCaption = string.Empty;
                this.txtJiQiJB.Text = string.Empty;
                this.MachineLevel.Text = string.Empty;

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtProductLine.Text = string.Empty;

                this.MachineModel.Text = string.Empty;
                this.MachineType.Text = string.Empty;
                //修改：有两个颜色重复，所以在这里增加绑定
                this.Color.Text = string.Empty;

                this.MachineName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 根据安装单号查找机器级别
        /// </summary>
        /// <param name="taskcode"></param>
        public void DragoutMachineCode(string aAccCode)
        {
            string sql = string.Format(@"select code,type,grade,model,cinvstd,productline from BaseMachineGrade where code = '{0}'", aAccCode);
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.txtJiQiJB.BaoBtnCaption = dr["code"].ToString();
                this.txtJiQiJB.Text = dr["code"].ToString();
                this.MachineLevel.Text = dr["grade"].ToString();
                this.MachineModel.Text = dr["model"].ToString();
                this.MachineType.Text = dr["type"].ToString();
                //修改：有两个颜色重复，所以在这里增加绑定
                this.Color.Text = dr["type"].ToString();

                this.MachineName.Text = dr["cinvstd"].ToString();

                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
                this.txtProductLine.Text = dr["productline"].ToString();

            }
        }

        /// <summary>
        /// 由地区名称带出客服经理
        /// </summary>
        /// <param name="city"></param>
        private void DragoutCustomerManager(string city)
        {

            DataTable temp_dt = Common.Common.Select_SQL_Region_ManageUser(city);
            if (temp_dt != null && temp_dt.Rows.Count > 0)
            {
                //this.CustomerManagerName.Text = temp_dt.Rows[0]["userName"].ToString();
                // this.CustomerManagerCode.button2.Text = temp_dt.Rows[0]["UserId"].ToString();
                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求） //手工默认为空值
                this.CustomerManagerName.Text = "";
                this.CustomerManagerCode.button2.Text = "";
            }
        }

        /// <summary>
        /// 由地区名称带出客服经理
        /// </summary>
        /// <param name="city"></param>
        private void DragoutCustomerManager(string RegionName, string ProvinceName)
        {

            DataTable temp_dt = Common.Common.Select_SQL_Region_ManageUser(RegionName, ProvinceName);
            if (temp_dt != null && temp_dt.Rows.Count > 0)
            {
                //this.CustomerManagerName.Text = temp_dt.Rows[0]["userName"].ToString();
                //this.CustomerManagerCode.button2.Text = temp_dt.Rows[0]["UserId"].ToString();
                //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求） //手工默认为空值
                this.CustomerManagerName.Text = "";
                this.CustomerManagerCode.button2.Text = "";
            }
        }

        private void txtTSBXYD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 & (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;  
        }

        private void txtTSBXYD_TextChanged(object sender, EventArgs e)
        {
            int debaoxiu = 12;
            string str = txtTSBXYD.Text.Trim();
            if (str != "")
            {
                debaoxiu = Convert.ToInt32(str);
                if (debaoxiu > 1000)
                {
                    debaoxiu = 1000;
                    txtTSBXYD.Text = "1000";
                }
                    
            }

            //|| this.txtJiQiJB.Text.StartsWith("B")

            //采有U13 系统中新的编码
            //1、A开头是18个月，已注明
            //2、H开头是14个月，已注明
            /*if (this.txtJiQiJB.Text.StartsWith("A"))
                this.dtimeFHBX.Value = this.dtimeFH.Value.AddMonths(18);    //本部保修期限
            if (this.txtJiQiJB.Text.StartsWith("Z"))
                this.dtimeFHBX.Value = this.dtimeFH.Value.AddMonths(14);    //本部保修期限*/


            //新的日期调整
            //H A0 B0 18个月
            //A1 A2 D1 Z 14月

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）保修到期日期在现有逻辑基础上减少1天

            this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(14)).AddDays(-1);

            if (this.txtJiQiJB.Text.StartsWith("H") || this.txtJiQiJB.Text.StartsWith("A0") || this.txtJiQiJB.Text.StartsWith("B0"))
            {
                this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(18)).AddDays(-1);
                //本部保修期限 保修到期日期在现有逻辑基础上减少1天
            }

            if (this.txtJiQiJB.Text.StartsWith("A1") || this.txtJiQiJB.Text.StartsWith("A2") || this.txtJiQiJB.Text.StartsWith("D1") || this.txtJiQiJB.Text.StartsWith("Z"))
            {
                this.dtimeFHBX.Value = (this.dtimeFH.Value.AddMonths(14)).AddDays(-1);    //本部保修期限 保修到期日期在现有逻辑基础上减少1天
            }

            this.dtimeGCBX.Value = (dtimeGC.Value.AddMonths(debaoxiu + 2)).AddDays(-1); //GC保修期限 保修到期日期在现有逻辑基础上减少1天
            this.dtimeAZBX.Value = (this.PurchaseDate.Value.AddMonths(debaoxiu)).AddDays(-1);   //安装保修期限 保修到期日期在现有逻辑基础上减少1天

        }

        private void BtnAcc_Click(object sender, EventArgs e)
        {
            if (RepairMissionCode.Text == "")
            {
                MessageBox.Show("请打开维修任务单据！");
                return;
            }

            RepairMessionLoadFile fj1 = new RepairMessionLoadFile(RepairMissionCode.Text);//autoUserID:用户ID
            fj1.StartPosition = FormStartPosition.CenterScreen;
            fj1.ShowDialog(this);
        }

        private void BtnOutExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\保内申请书模板.xlsx");

                ex.SetCellValue(2, 4, this.RepairMissionCode.Text); //维修单号
                ex.SetCellValue(3, 3, this.CustomerName.Text);  //医院名——客户名称

                ex.SetCellValue(4, 3, this.RepairContractPeople.Text); //联系人——维修联系人
                ex.SetCellValue(4, 13, this.ContractNumber.Text);   //联系电话——联系电话
                ex.SetCellValue(5, 3, this.MachineModel.Text);  //主机型号——主机机型2
                ex.SetCellValue(5, 11, this.ManufactureCode.Text);  //SN——制造编号
                ex.SetCellValue(6, 3, this.dtimeFH.Value.ToString("yyyy-mm-dd"));  //本部出厂日期——本部发货日期
                ex.SetCellValue(6, 11, this.dtimeFHBX.Value.ToString("yyyy-mm-dd"));  //本部保修截止日期——本部保修期限
                ex.SetCellValue(7, 3, this.dtimeGC.Value.ToString("yyyy-mm-dd"));  //(GC)  发货日期——GC出库日期
                ex.SetCellValue(7, 11, this.dtimeFH.Value.ToString("yyyy-mm-dd"));  //(GC)保修截止——GC保修期限
                ex.SetCellValue(8, 3, this.dtimeFH.Value.ToString("yyyy-mm-dd"));  //安装日期——购买日期
                ex.SetCellValue(8, 11, this.dtimeFH.Value.ToString("yyyy-mm-dd"));  //主机保修期限——安装保修期限
                ex.SetCellValue(9, 11, this.dtimeFH.Value.ToString("yyyy-mm-dd"));  //保内申请日期——报修日期
                ex.SetCellValue(14, 2, this.ManufactureCode.Text);  //故障内容——故障描述
                ex.SetCellValue(26, 6, this.ManufactureCode.Text);  //修理类型——维修类别


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

    }
}
