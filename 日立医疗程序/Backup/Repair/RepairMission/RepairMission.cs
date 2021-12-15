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
        }

        public void init()
        {
            foreach (Control item in this.Controls)
            {
                item.TabStop = false;
            }

            CustomerCode.BaoSQL = "select cCusCode,cCusName from " + U8DataAcc.DataBase + ".Customer where ccccode  like '2%'";
            CustomerCode.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.CustomerCode.FrmHigth = 500;
            this.CustomerCode.FrmWidth = 500;
            CustomerCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".Customer where cCusCode=";
            CustomerCode.BaoColumnsWidth = "cCusCode=150,cCusName=250";
            CustomerCode.BaoClickClose = true;
            CustomerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerCode_OnLookUpClosed);



            CustomerDepartmentCode.BaoSQL = "select cdepcode,cdepName  from " + U8DataAcc.DataBase + ".department";
            CustomerDepartmentCode.BaoTitleNames = "cdepcode=部门编码,cdepName=部门名称";
            this.CustomerDepartmentCode.FrmHigth = 600;
            this.CustomerDepartmentCode.FrmWidth = 400;
            CustomerDepartmentCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".department where cdepcode=";
            CustomerDepartmentCode.BaoColumnsWidth = "cdepcode=150,cdepName=250";
            CustomerDepartmentCode.BaoClickClose = true;
            CustomerDepartmentCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerDepartmentName_OnLookUpClosed);





            MachineCode.BaoSQL = "select cinvcode,cinvname  from " + U8DataAcc.DataBase + ".inventory where (cinvcode like 'A%' or cinvcode like 'B%') and len(cinvcode) = 3";
            MachineCode.BaoTitleNames = "cinvcode=存货编码 ,cinvname=存货名称";
            this.MachineCode.FrmHigth = 600;
            this.MachineCode.FrmWidth = 400;
            MachineCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=150,cinvname=250";
            MachineCode.BaoClickClose = true;

            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);


            ZoneCode.BaoSQL = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass";
            ZoneCode.BaoTitleNames = "cDCCODE=地区编码 ,CDCNAME=地区名称";
            this.ZoneCode.FrmHigth = 600;
            this.ZoneCode.FrmWidth = 400;
            ZoneCode.DecideSql = "select cDCCODE,CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE=";
            ZoneCode.BaoColumnsWidth = "cDCCODE=150,CDCNAME=250";
            ZoneCode.BaoClickClose = true;

            ZoneCode.OnLookUpClosed+=new FrmLookUp.ButtonEdit.LookUpClosed(ZoneCode_OnLookUpClosed);
          




            CustomerManagerCode.BaoSQL = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002'";
            CustomerManagerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            CustomerManagerCode.FrmHigth = 400;
            CustomerManagerCode.FrmWidth = 320;
            CustomerManagerCode.DecideSql = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '002' and  userid =";
            CustomerManagerCode.BaoColumnsWidth = "userid=120,username=120";

            CustomerManagerCode.BaoClickClose = true;
            CustomerManagerCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(CustomerManagerCode_OnLookUpClosed);




            RepairPersonCode.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and rt.RegionId in (select RegionId from RegionToUser where UserId = '"+UFBaseLib.BusLib.BaseInfo.DBUserID+"')";
            RepairPersonCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            RepairPersonCode.FrmHigth = 400;
            RepairPersonCode.FrmWidth = 320;
            RepairPersonCode.DecideSql = "select userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and userid =";
            RepairPersonCode.BaoColumnsWidth = "userid=120,username=120";

            RepairPersonCode.BaoClickClose = true;

            RepairPersonCode.OnLookUpClosed +=new FrmLookUp.ButtonEdit.LookUpClosed(RepairPersonCode_OnLookUpClosed);

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
                if (this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() == string.Empty )
                {
                    this.button2.Text = "提交";
                }
                else
                {
                    this.button2.Text = "收回";
                   // this.toolBarBill1.BtnSave.Visible = false;
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


        public override void IsMyBill(string RepairMissionCode)
        {
            base.IsMyBill(RepairMissionCode);

               if (this.BO.EntityTables[0].Table.Rows[0]["UserId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID)
                {
                    foreach (Control item in this.Controls)
                    {
                        item.Enabled = true;
                    }
                }

           
        }

        void toolBarBill1_OnAfterBaoCancel(object sender, EventArgs e)
        {

            CtrEnable(false);



            if (this.BO.BillId == string.Empty)
            {



                this.RepairMissionCode.Text = null;
                this.CustomerCode.Text = null;
                this.CustomerName.Text = null;
                this.CustomerDepartmentCode.Text = null;
                this.CustomerDepartmentName.Text = null;
                this.MachineCode.Text = null;
                this.MachineName.Text = null;
                this.ManufactureCode.Text = null;
                this.SoftwareVersion.Text = null;
                this.ReportRepartDate.Text = null;
                this.PurchaseDate.Text = null;
                this.ZoneCode.Text = null;
                this.RepairType.Text = null;
                this.RepairSource.Text = null;
                this.RepairContractPeople.Text = null;
                this.ContractNumber.Text = null;
                this.FaxNumber.Text = null;
                this.FaultDetails.Text = null;

                this.CustomerManagerCode.Text = null;
                this.CustomerManagerName.Text = null;


                this.RepairPersonName.Text = null;
                this.RepairPersonCode.Text = null;


           
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
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.toolBarBill1.BtnAddNew.Visible = false;
            this.toolBarBill1.BtnDelete.Visible = false;


            //800客服

            //按下修改按钮的时候，根据权限显示
           
                if (BaseInfo.userRole.Contains("001"))
                {


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

                }

                //是当前的客户经理才能解锁
                if (this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID)
                {
                    this.button2.Visible = true;


                    if (toolBarBill1.BtnModify.Enabled == false)
                    {
                        foreach (Control item in groupBox2.Controls)
                        {
                            item.Enabled = true;
                        }
                    }

                }


                //加个控制，就是说，如果已经指派人了，那么这个单据的上半部分是不能改的

                if (!(this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString() == string.Empty))
                {

                    foreach (Control item in groupBox1.Controls)
                    {
                        item.Enabled = false;
                    }

                }
                this.button1.Enabled = true;

             
                if (!(this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() == string.Empty))
                {
                    foreach (Control item in groupBox2.Controls)
                    {
                        item.Enabled = false;
                    }
                }
            
            this.button1.Enabled = true;
            this.button2.Enabled = true;
        }


 

        void CustomerManagerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerManagerCode.BaoBtnCaption = e.ReturnRow1["userid"].ToString();
            this.ReManager.Text = e.ReturnRow1["userid"].ToString();
            this.CustomerManagerName.Text = e.ReturnRow1["username"].ToString();
        }

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.MachineCode.BaoBtnCaption = e.ReturnRow1["cinvcode"].ToString();
            this.MachineName.Text = e.ReturnRow1["cinvname"].ToString();
          
        }

        void CustomerDepartmentName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerDepartmentCode.BaoBtnCaption = e.ReturnRow1["cdepcode"].ToString();

            this.CustomerDepartmentName.Text = e.ReturnRow1["cdepName"].ToString();

            this.ReDepartmentCode.Text = e.ReturnRow1["cdepcode"].ToString();


          
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
             this.ReportRepartDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "ReportRepartDate");
             this.PurchaseDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "PurchaseDate");
             this.ZoneCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "ZoneCode");
             this.ZoneName.DataBindings.Add("Text", BO.EntityTables[0].Table, "ZoneName");
             this.RepairType.DataBindings.Add("SelectedValue", BO.EntityTables[0].Table, "RepairType");
             this.RepairType.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "RepairType");
             this.RepairType.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairType");
        
             this.RepairSource.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairSource");
             this.RepairContractPeople.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairContractPeople");
             this.ContractNumber.DataBindings.Add("Text", BO.EntityTables[0].Table, "ContractNumber");
             this.FaxNumber.DataBindings.Add("Text", BO.EntityTables[0].Table, "FaxNumber");
             this.FaultDetails.DataBindings.Add("Text", BO.EntityTables[0].Table, "FaultDetails");

          //   this.RepairPersonCode.DataBindings.Add("BaoBtnCaption", BO.EntityTables[0].Table, "RepairPersonCode");
             this.RepairPersonCode.button2.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
             this.ReEng.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
      //       this.RepairPersonCode.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonCode");
             this.RepairPersonName.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairPersonName");

            this.SubmitPersonDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitPersonDate");

               this.SubmitPersonUser.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitPersonUser");
               this.SubmitMissonUser.DataBindings.Add("Text", BO.EntityTables[0].Table, "SubmitMissonUser");
              this.RepairUnit1.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairUnit1");
              this.RepairUnit2.DataBindings.Add("Text", BO.EntityTables[0].Table, "RepairUnit2");
              this.City.DataBindings.Add("Text", BO.EntityTables[0].Table, "City");
              this.Color.DataBindings.Add("Text", BO.EntityTables[0].Table, "Color");
              this.Color.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "Color");
              


          
            
             
          
        }
        public override void BaoUnDataBinding()
        {


            base.BaoUnDataBinding();

            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();
            this.CustomerDepartmentCode.DataBindings.Clear();
            this.CustomerDepartmentName.DataBindings.Clear();
            this.MachineCode.DataBindings.Clear();
            this.MachineName.DataBindings.Clear();
            this.ManufactureCode.DataBindings.Clear();
            this.SoftwareVersion.DataBindings.Clear();
            this.ReportRepartDate.DataBindings.Clear();
            this.PurchaseDate.DataBindings.Clear();
            this.ZoneCode.DataBindings.Clear();
            this.ZoneName.DataBindings.Clear();
            this.RepairType.DataBindings.Clear();
            this.RepairSource.DataBindings.Clear();
            this.RepairContractPeople.DataBindings.Clear();
            this.ContractNumber.DataBindings.Clear();
            this.FaxNumber.DataBindings.Clear();
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
            this.Color.DataBindings.Clear();
           // this.Color.DataBindings.Clear();
        }
        void CustomerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerCode.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString();
         
            this.CustomerName.Text = e.ReturnRow1["cCusName"].ToString();

            this.ZoneCode.BaoBtnCaption = e.ReturnRow1["cCusCode"].ToString().Substring(1, 2);
            this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.ZoneCode.BaoBtnCaption + "'");
            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.ZoneCode.BaoBtnCaption);
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
            if (this.button1.Text == "提交")
            {
                if (this.BO.BillId == string.Empty||RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from repairmission where RepairMissionID = '" + this.BO.BillId + "'").Rows.Count == 0)
                    throw new Exception("未保存，不能提交");
                //判断逻辑，能否提交
                if ((dt.Rows[0]["CustomerManagerCode"].ToString() == string.Empty))
                {
                    throw new Exception("未指定负责经理，不能提交");
                }
                if (!(dt.Rows[0]["SubmitMissonUser"].ToString() == string.Empty))
                {
                    throw new Exception("不能重复提交");
                }


                this.SubmitMissonDate.Value =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.SubmitMissonUser.Text = UFBaseLib.BusLib.BaseInfo.DBUserID;
          

                this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修请求";
                this.BO.UpdateSave();

                System.Windows.Forms.MessageBox.Show("提交成功");
                this.RepairMissionCode.Enabled = false;
                this.CustomerCode.Enabled = false;
                this.CustomerName.Enabled = false;
                this.CustomerDepartmentCode.Enabled = false;
                this.CustomerDepartmentName.Enabled = false;
                this.MachineCode.Enabled = false;
                this.MachineName.Enabled = false;
                this.ManufactureCode.Enabled = false;
                this.SoftwareVersion.Enabled = false;
                this.ReportRepartDate.Enabled = false;
                this.PurchaseDate.Enabled = false;
                this.ZoneCode.Enabled = false;
                this.RepairType.Enabled = false;
                this.RepairSource.Enabled = false;
                this.RepairContractPeople.Enabled = false;
                this.ContractNumber.Enabled = false;
                this.FaxNumber.Enabled = false;
                this.FaultDetails.Enabled = false;
                this.RepairPersonCode.Enabled = false;
                this.SubmitPersonDate.Enabled = false;
                this.CustomerManagerCode.Enabled = false;
                this.CustomerManagerName.Enabled = false;

                //发消息给客服经理

                string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where RepairMissionID = '" + this.BO.BillId + "'");

                CMessage.SendMessage("新维修任务", "有新的维修任务，指派工程师", userid, UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);

                this.button1.Text = "收回";

                string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + userid + "'");
                string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的维修任务,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString(), "<br/> 医院：" + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话：" + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人：" + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述：" + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型：" + this.BO.EntityTables[0].Table.Rows[0]["MachineName"].ToString() + "<br/> 维修性质：" + this.BO.EntityTables[0].Table.Rows[0]["RepairType"].ToString(), true, 2);

                System.Windows.Forms.MessageBox.Show("邮件系统："+mailmsg);
            }
            else if(this.button1.Text == "收回")
            {
                //判断逻辑，能否收回

                string RepairMissionID = dt.Rows[0]["RepairMissionID"].ToString();

                string ErrMsg = string.Empty;

                if (!string.IsNullOrEmpty(dt.Rows[0]["SubmitPersonUser"].ToString()))
                {
                    ErrMsg += "[客服经理已经指派工程师，无法收回]";
                }

              

                if (ErrMsg == string.Empty)
                {


                    this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonUser"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitMissonDate"] = DBNull.Value;
                    this.BO.EntityTables[0].Table.Rows[0]["State"] = "新任务";
                    this.BO.UpdateSave();

               
                    CMessage.SendMessage("维修任务收回", "有维修任务被收回", this.BO.EntityTables[0].Table.Rows[0]["CustomerManagerCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);

                    System.Windows.Forms.MessageBox.Show("收回成功");

                    this.button1.Text = "提交";
                }
                else
                {
                       throw new Exception(ErrMsg);
                }

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
            if (dt.Rows[0]["CustomerManagerCode"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
            {
                throw new Exception("您没有权限");
            }
            if (this.button2.Text == "提交")
            {
                if (dt.Rows[0]["RepairPersonName"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("未指定工程师，不能提交");
                    return;
                }
                if (dt.Rows[0]["SubmitMissonUser"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("本次维修任务，800尚未提交，不能提交");
                    return;
                }
                this.SubmitPersonDate.Value =  RiLiGlobal.RiLiDataAcc.GetNow();
     
                this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["State"] = "已分派";

                this.SubmitPersonUser.Text = UFBaseLib.BusLib.BaseInfo.DBUserID;

                this.BO.UpdateSave();

                System.Windows.Forms.MessageBox.Show("提交成功");

              
               

                this.SubmitPersonDate.Enabled = false;
                this.RepairPersonCode.Enabled = false;
                this.RepairPersonName.Enabled = false;
                this.button2.Text = "收回";

                //发消息给工程师
                CMessage.SendMessage("新维修任务", "有新的维修任务，请跟进", this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);


                string emailaddress = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(" select Memo from Users where UserId = '" + this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"].ToString() + "'");
                string mailmsg = Message.sm_Email.SendEmail(emailaddress, "有新的维修任务,编号：" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString(), "<br/> 医院：" + this.BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString() + "<br/> 指派人：" + UFBaseLib.BusLib.BaseInfo.UserName + "<br/> 省份：" + this.BO.EntityTables[0].Table.Rows[0]["ZoneName"].ToString() + "<br/> 联系电话：" + this.BO.EntityTables[0].Table.Rows[0]["ContractNumber"].ToString() + "<br/> 联系人：" + this.BO.EntityTables[0].Table.Rows[0]["RepairContractPeople"].ToString() + "<br/> 故障描述：" + this.BO.EntityTables[0].Table.Rows[0]["FaultDetails"].ToString() + "<br/> 机型：" + this.BO.EntityTables[0].Table.Rows[0]["MachineName"].ToString() + "<br/> 维修性质：" + this.BO.EntityTables[0].Table.Rows[0]["RepairType"].ToString(), true, 2);

            
             //   System.Windows.Forms.MessageBox.Show("邮件系统：" + mailmsg);


                System.Windows.Forms.MessageBox.Show("邮件系统：" + mailmsg);

            }
            else if (this.button2.Text == "收回")
            {
                //判断逻辑，能否收回

                string RepairMissionID = this.BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString();

                string ErrMsg = string.Empty;

             

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

                    this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonUser"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["SubmitPersonDate"] = DBNull.Value;
                    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonCode"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["RepairPersonName"] = null;
                  
                    this.BO.EntityTables[0].Table.Rows[0]["State"] = "维修请求";
                    this.SubmitPersonUser.Text = string.Empty;
                  

                    this.BO.UpdateSave();
                    CMessage.SendMessage("维修任务收回", "有维修任务被收回", engcode, UFBaseLib.BusLib.BaseInfo.UserId, "Rep001", this.BO.BillId);

                    System.Windows.Forms.MessageBox.Show("收回成功");

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
            

            DataTable installData = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from InstallTask i left outer join InsFeedback ins on ins.fTaskCode = i.tInsCode  where fMainMake = '" + this.ManufactureCode.Text + "'");

            if (installData.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.CustomerCode.Text = installData.Rows[0]["tCusCode"].ToString();
                this.CustomerName.Text = installData.Rows[0]["tCusName"].ToString();
                this.MachineName.Text = installData.Rows[0]["tMaiCode"].ToString();
                this.MachineCode.Text = installData.Rows[0]["tMaiCode"].ToString();
                this.ZoneCode.BaoBtnCaption = this.CustomerCode.Text.Substring(1, 2);
                this.ZoneName.Text = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CDCNAME  from " + U8DataAcc.DataBase + ".DistrictClass where cDCCODE='" + this.ZoneCode.BaoBtnCaption + "'");
                this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(this.ZoneCode.BaoBtnCaption);
                DateTime.TryParse( installData.Rows[0]["fEndTime"].ToString(),out purcherDate);
                this.PurchaseDate.Value = purcherDate;
                this.SoftwareVersion.Text = installData.Rows[0]["fMainVersion"].ToString();
                DateTime.TryParse(installData.Rows[0]["tSendTime"].ToString(), out sendTime);
                int.TryParse(installData.Rows[0]["tRepMonth"].ToString(), out baoxiu);
                if (((roportDate - purcherDate).TotalDays < baoxiu * 30.4) && ( (roportDate - sendTime).TotalDays < baoxiu * 30.4 + 60.8))
                {
                    this.RepairType.Text = "保内";
                }
                else
                {
                    this.RepairType.Text = "保外";
                }

            }
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

        private void CustomerManagerCode_OnLookUpClosed_1(object sender, FrmLookUp.LookUpEventArgs e)
        {

        }
    }
}
