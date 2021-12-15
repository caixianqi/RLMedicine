using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using U8Global;
using UFBaseLib.BusLib;

namespace Repair
{
    public partial class FaultFeedback :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {


        private RepairMissionList RepairList;

    private ToolTip tt;

        private ToolTip tt2;

        private string RepairMissionID;

        public FaultFeedback()
        {
            InitializeComponent();
            this.BO = new FaultFeedbackBill();
            BO.Init("");
            init();
        }
        public FaultFeedback(string id)
        {
            InitializeComponent();
            this.BO = new FaultFeedbackBill();
            BO.Init(id);
            init();

            if (this.BO.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() == string.Empty)
            {
                return;
            }
            else
            {

                string repairMisssionCode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from RepairMission where RepairMissionId ='" + this.BO.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString() + "'");
                IsMyBill(repairMisssionCode);
            }
        }

        public override void IsMyBill(string RepairMissionCode)
        {
            //如果不是工程师，则全禁止
            if (RepairMissionCode == null || RepairMissionCode == string.Empty)
            {
                return;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
                string sql = "select * from RepairMission where RepairMissionCode = '" + RepairMissionCode + "' and ( CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' or RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')";

                if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql).Rows.Count == 0)
                {
                    foreach (Control item in this.toolBarBill1.Controls)
                    {
                        item.Enabled = false;
                    }
                }
            }


         
           
        }

        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            this.gridView1.CloseEditor();
            this.gridView1.UpdateCurrentRow();

            //判断有没有被收回，被收回就不能保存。

            string sql = "select State from RepairMission where RepairMissionId = '"+this.BO.EntityTables[0].Table.Rows[0]["RepairMissionId"].ToString()+"'";

            string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

            if (state == "已分派")
            {



                base.toolBarBill1_OnBaoSave(sender, e);
            }
            else
            {
                throw new Exception("维修任务被收回，无法保存故障解决情况");
            }


        }

       
        public void init()
        {

            RepairMissionCode.BaoSQL = "select * from RepairMission where  RepairPersonCode ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and (SubmitPersonUser is not null and SubmitPersonUser <>''  ) and RepairMissionID not in (select RepairMissionID from FaultFeedback)";
            RepairMissionCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName=区域,MachineName=主机型号,RepairType=维修类别,RepairPersonName=工程师,ReportRepartDate=报修日期";
            this.RepairMissionCode.FrmHigth = 250;
            this.RepairMissionCode.FrmWidth = 800;
            RepairMissionCode.DecideSql = "select * from RepairMission where  RepairMissionCode =";
            RepairMissionCode.BaoColumnsWidth = "RepairMissionCode=120,CustomerName=200,ZoneName=50,MachineName=80,RepairType=100,ReportRepartDate=80,RepairPersonName=80";
            RepairMissionCode.BaoClickClose = true;

            RepairMissionCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);

            toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(toolBarBill1_OnBaoDelete);

            repositoryItemButtonEdit1.Click += new EventHandler(repositoryItemButtonEdit1_Click);



            riLiButton1.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003'";
            riLiButton1.BaoTitleNames = "userid=人员编码,username=人员姓名";
            this.riLiButton1.FrmHigth = 300;
            this.riLiButton1.FrmWidth = 300;
            riLiButton1.DecideSql = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003' and u.username=";
            riLiButton1.BaoColumnsWidth = "userid=120,username=120";


            this.StartingDate.Value =  RiLiGlobal.RiLiDataAcc.GetNow();
            this.ReachDate.Value =  RiLiGlobal.RiLiDataAcc.GetNow();
         
            foreach (Control item in this.groupBox1.Controls)
            {
                item.Enabled = false;

                if (item.Name == "RepairMissionCode")
                {
                    continue;
                }
                else
                {
                    item.Tag = "99999";
                }
            }

            foreach (Control item in this.groupBox3.Controls)
            {
                item.Enabled = false;
                item.Tag = "99999";
            }

            this.FaultType.Enabled = false;
            this.Finalsolution.Enabled = false;
            this.toolBarBill1.tssAddRow.Visible = false;
            this.toolBarBill1.tssAudit.Visible = false;
            this.toolBarBill1.tssPrint.Visible = false;
            //this.toolBarBill1.BtnAudit.Visible = false;
            //this.toolBarBill1.BtnUnAudit.Visible = false;
            this.toolBarBill1.BtnUpLoad.Visible = false;


            this.toolBarBill1.btnEnd.Visible = false;


            this.toolBarBill1.BtnAddRow.Visible = false;
            this.toolBarBill1.BtnDeleteRow.Visible = false;
            this.toolBarBill1.BtnExcel.Visible = false;
            this.toolBarBill1.BtnAuditList.Visible = false;
            this.toolBarBill1.tssLocation.Visible = false;
            this.toolBarBill1.BtnLocation.Visible = false;
            this.toolBarBill1.BtnUnUpLoad.Visible = false;

            //权限控制
            RoleController();

            toolBarBill1.OnAfterBaoCancel += new FrmLookUp.ToolBarBill.AfterBaoCancel(toolBarBill1_OnAfterBaoCancel);

            if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                this.button4.Text = "提交";
                this.toolBarBill1.BtnModify.Visible = true;
            }
            else
            {
                this.button4.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;
            }
        
   
            //定位按钮，做单据列表
            if (BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString() == string.Empty)
            {
                return;
            }

           

            DataTable mission = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from repairmission where RepairMissionID = '" + BO.EntityTables[0].Table.Rows[0]["RepairMissionID"].ToString() + "'");


            this.RepairMissionCode.Text = mission.Rows[0]["RepairMissionCode"].ToString();
            this.CustomerName.Text = mission.Rows[0]["CustomerName"].ToString();
            this.CustomerCode.BaoBtnCaption = mission.Rows[0]["CustomerCode"].ToString();
            this.CustomerDepartmentName.Text = mission.Rows[0]["CustomerDepartmentName"].ToString();
            this.MachineName.Text = mission.Rows[0]["MachineName"].ToString();
            this.CustomerManagerName.Text = mission.Rows[0]["CustomerManagerName"].ToString();
            this.ManufactureCode.Text = mission.Rows[0]["ManufactureCode"].ToString();
            this.SoftwareVersion.Text = mission.Rows[0]["SoftwareVersion"].ToString();
            this.ReportRepartDate.Text = mission.Rows[0]["ReportRepartDate"].ToString();
            this.PurchaseDate.Text = mission.Rows[0]["PurchaseDate"].ToString();
            this.ZoneName.Text = mission.Rows[0]["ZoneName"].ToString();
            this.RepairType.Text = mission.Rows[0]["RepairType"].ToString();
            this.RepairSource.Text = mission.Rows[0]["RepairSource"].ToString();
            this.RepairContractPeople.Text = mission.Rows[0]["RepairContractPeople"].ToString();
            this.ContractNumber.Text = mission.Rows[0]["ContractNumber"].ToString();
            this.FaxNumber.Text = mission.Rows[0]["FaxNumber"].ToString();
            this.FaultDetails.Text = mission.Rows[0]["FaultDetails"].ToString();
            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(mission.Rows[0]["ZoneCode"].ToString());


            if (BO.EntityTables[1].Table.Rows.Count > 0)
            {
                this.gridControl1.DataSource = BO.EntityTables[1].Table;


                string maxDate = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select MAX(ReachDate) from  FaultFeedbackDetails where FaultFeedBackID = '" + this.BO.BillId + "'");

                DateTime maxBegindate;

                DateTime.TryParse(maxDate, out maxBegindate);


                this.StartingDate.MinDate = maxBegindate;
                this.ReachDate.MinDate = maxBegindate;
                this.CompleteDate.MinDate = maxBegindate;
            
            }












        }

        void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    return;
                }


                InstallPerson.BaoSQL = "select distinct u.userid,username,RoleName,DeptName from users u left outer join RegionToUser rt on rt.UserId = u.UserId,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId and r.RoleId = '003'";
                InstallPerson.BaoTitleNames = "userid=人员编码,username=人员姓名";
                this.InstallPerson.FrmHigth = 400;
                this.InstallPerson.FrmWidth = 500;

                InstallPerson.BaoColumnsWidth = "userid=120,username=120";

                DataRow FocusedRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                this.InstallPerson.button1_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：\r\n" + ex.Message, "系统提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            CtrEnable(false);
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
            this.ZoneName.Text = null;
            this.RepairType.Text = null;
            this.RepairSource.Text = null;
            this.RepairContractPeople.Text = null;
            this.ContractNumber.Text = null;
            this.FaxNumber.Text = null;
            this.FaultDetails.Text = null;

            this.CustomerManagerCode.Text = null;
            this.CustomerManagerName.Text = null;


            this.ProcessingStatus.DataBindings.Clear();
            this.CompleteDate.DataBindings.Clear();
            this.FaultType.DataBindings.Clear();
            this.Finalsolution.DataBindings.Clear();

            this.gridControl1.DataSource = null;
           
            BO.Init("");
            BaoUnDataBinding();
            BaoDataBinding();
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
                this.ZoneName.Text = null;
                this.RepairType.Text = null;
                this.RepairSource.Text = null;
                this.RepairContractPeople.Text = null;
                this.ContractNumber.Text = null;
                this.FaxNumber.Text = null;
                this.FaultDetails.Text = null;

                this.CustomerManagerCode.Text = null;
                this.CustomerManagerName.Text = null; 


                this.ProcessingStatus.DataBindings.Clear();
                this.CompleteDate.DataBindings.Clear();
                this.FaultType.DataBindings.Clear();
                this.Finalsolution.DataBindings.Clear();

                this.gridControl1.DataBindings.Clear();
                BO.Init("");
                BaoUnDataBinding();
                BaoDataBinding();

            }
            else
            {
                string id = this.BO.BillId;
                Repair.FaultFeedback ff = new FaultFeedback(id);
                ff.MdiParent = this.MdiParent;

                this.Hide();

                ff.Show();

                this.Close();
          
              
            }
        }

        void toolBarBill1_OnBaoCancel(object sender, EventArgs e)
        {
            
        }

      

        void RepairMissionCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.RepairMissionID = e.ReturnRow1["RepairMissionID"].ToString();
            BO.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.RepairMissionID;

            DataTable mission = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from repairmission where RepairMissionID = '" + RepairMissionID + "'");

          
       
            this.RepairMissionCode.Text = mission.Rows[0]["RepairMissionCode"].ToString();
            this.CustomerCode.BaoBtnCaption = mission.Rows[0]["CustomerCode"].ToString();
            this.CustomerName.Text = mission.Rows[0]["CustomerName"].ToString();
            this.CustomerDepartmentName.Text = mission.Rows[0]["CustomerDepartmentName"].ToString();
            this.MachineName.Text = mission.Rows[0]["MachineName"].ToString();
            this.CustomerManagerName.Text = mission.Rows[0]["CustomerManagerName"].ToString();
            this.ManufactureCode.Text = mission.Rows[0]["ManufactureCode"].ToString();
            this.SoftwareVersion.Text = mission.Rows[0]["SoftwareVersion"].ToString();
            this.ReportRepartDate.Text = mission.Rows[0]["ReportRepartDate"].ToString();
            this.PurchaseDate.Text = mission.Rows[0]["PurchaseDate"].ToString();
            this.ZoneName.Text = mission.Rows[0]["ZoneName"].ToString();
            this.RepairType.Text = mission.Rows[0]["RepairType"].ToString();
            this.RepairSource.Text = mission.Rows[0]["RepairSource"].ToString();
            this.RepairContractPeople.Text = mission.Rows[0]["RepairContractPeople"].ToString();
            this.ContractNumber.Text = mission.Rows[0]["ContractNumber"].ToString();
            this.FaxNumber.Text = mission.Rows[0]["FaxNumber"].ToString();
            this.FaultDetails.Text = mission.Rows[0]["FaultDetails"].ToString();

            this.RegionName.Text = RiLiGlobal.RegionHelper.GetRegionNamebyProvinceCode(mission.Rows[0]["ZoneCode"].ToString());

        }

        public override void NewButtonBefor()
        {
            base.NewButtonBefor();

            BO.BillId = Guid.NewGuid().ToString();


            this.RepairMissionCode.Enabled = true;

          //  //弹出窗口，选择一个

          //  RepairList = new RepairMissionList(" where [RepairPersonCode] = '"+UFBaseLib.BusLib.BaseInfo.DBUserID+"'");
          ////  RepairList = new RepairMissionList("where RepairMissionID  not in  (select RepairMissionID from FaultFeedback)");
          //  RepairList.ShowDialog();

          //  if (RepairList.SelectID == string.Empty || RepairList.SelectID == null)
          //  {
          //      return;
          //  }
          //  else
          //  {
              

           

        





          //  }
          //  //权限控制
            RoleController();
         
        }


        public override void NewButtonAfter()
        {
         
          
            this.RepairMissionCode.Enabled = true ;

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
            this.ZoneName.Text = null;
            this.RepairType.Text = null;
            this.RepairSource.Text = null;
            this.RepairContractPeople.Text = null;
            this.ContractNumber.Text = null;
            this.FaxNumber.Text = null;
            this.FaultDetails.Text = null;

            this.CustomerManagerCode.Text = null;
            this.CustomerManagerName.Text = null;


            this.ProcessingStatus.Text = null;
            this.CompleteDate.Value =  RiLiGlobal.RiLiDataAcc.GetNow();
            this.FaultType.Text = null;
            this.Finalsolution.Text = null;

            this.gridControl1.DataBindings.Clear();
            this.gridControl1.DataSource = null;
           

        }


        

        public override void UpdateButtonBefor()
        {
            base.UpdateButtonBefor();
            //权限控制
            RoleController();
        }

        public override void UpdateButtonAfter()
        {
            RoleController();

            if (this.ProcessingStatus.SelectedItem.ToString() == "完成")
            {
                this.FaultType.Enabled = true;

                this.Finalsolution.Enabled = true;

            }
            else
            {
                this.FaultType.Enabled = false;
                this.FaultType.SelectedItem = null;

                this.Finalsolution.Enabled = false;
                this.Finalsolution.SelectedItem = null;

            }
        }
       

        public void RoleController()
        {
            //800客服
            if (BaseInfo.userRole == "001")
            {
               
            }
            if (BaseInfo.userRole.Contains("003"))
            {
               
          


                foreach (Control item in groupBox1.Controls)
                {
                 
                    item.Enabled = false;
                }
            }
            else
            {
                foreach (Control item in groupBox1.Controls)
                {
                    item.Enabled = false;
                }
                foreach (Control item in groupBox2.Controls)
                {
                    item.Enabled = false;
                }
            }
        }


 

        void CustomerManagerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.CustomerManagerCode.BaoBtnCaption = e.ReturnRow1["cpersoncode"].ToString();
            this.CustomerManagerName.Text = e.ReturnRow1["cpersonname"].ToString();
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
        }
        public override void BaoDataBinding()
        {
            //this.txtCreateDate.DataBindings.Add("text", BO.EntityTables[0].Table, "CreateDate");
            ////...
            //this.gridControl1.DataSource = BO.EntityTables[1].Table;
            DataTable mission;

          
            
                 mission = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from repairmission where  1=2");
            

         

       

            this.RepairMissionCode.DataBindings.Add("Text", mission, "RepairMissionCode");

            this.CustomerCode.DataBindings.Add("BaoBtnCaption", mission, "CustomerCode");

            this.CustomerName.DataBindings.Add("Text", mission, "CustomerName");

            this.CustomerDepartmentCode.DataBindings.Add("BaoBtnCaption", mission, "CustomerDepartmentCode");
            this.CustomerDepartmentName.DataBindings.Add("Text", mission, "CustomerDepartmentName");

            this.MachineCode.DataBindings.Add("BaoBtnCaption", mission, "MachineCode");
            this.MachineName.DataBindings.Add("Text", mission, "MachineName");

            this.CustomerManagerCode.DataBindings.Add("BaoBtnCaption", mission, "CustomerManagerCode");
            this.CustomerManagerName.DataBindings.Add("Text", mission, "CustomerManagerName");

            this.ManufactureCode.DataBindings.Add("Text", mission, "ManufactureCode");
            this.SoftwareVersion.DataBindings.Add("Text", mission, "SoftwareVersion");
            this.ReportRepartDate.DataBindings.Add("Text", mission, "ReportRepartDate");
            this.PurchaseDate.DataBindings.Add("Text", mission, "PurchaseDate");
            this.ZoneName.DataBindings.Add("Text", mission, "ZoneName");
            this.RepairType.DataBindings.Add("Text", mission, "PurchaseDate");
            this.RepairSource.DataBindings.Add("Text", mission, "RepairSource");
            this.RepairContractPeople.DataBindings.Add("Text", mission, "RepairContractPeople");
            this.ContractNumber.DataBindings.Add("Text", mission, "ContractNumber");
            this.FaxNumber.DataBindings.Add("Text", mission, "FaxNumber");
            this.FaultDetails.DataBindings.Add("Text", mission, "FaultDetails");
            this.UploadTime.DataBindings.Add("Text", BO.EntityTables[0].Table, "UploadTime");


             this.ProcessingStatus.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "ProcessingStatus");
           //  this.CompleteDate.DataBindings.Add("Text", BO.EntityTables[0].Table, "CompleteDate");
             this.FaultType.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "FaultType");
             this.Finalsolution.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "Finalsolution");

           

        
      
             //DataTable detail;
             ////if (BO.EntityTables[0].Table.Rows[0]["FaultFeedBackID"].ToString() == string.Empty)
             ////{
             ////     detail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FaultFeedbackDetails where  1=2");
             ////}
             ////else
             ////{
             ////     detail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FaultFeedbackDetails where FaultFeedBackID = '" + BO.EntityTables[0].Table.Rows[0]["FaultFeedBackID"].ToString() + "'");
             ////}

             //detail = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FaultFeedbackDetails where  1=2");


             //this.gridControl1.DataSource = detail;

               
          
             
            
             
          
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
            this.ZoneName.DataBindings.Clear();
            this.RepairType.DataBindings.Clear();
            this.RepairSource.DataBindings.Clear();
            this.RepairContractPeople.DataBindings.Clear();
            this.ContractNumber.DataBindings.Clear();
            this.FaxNumber.DataBindings.Clear();
            this.FaultDetails.DataBindings.Clear();
         
            this.CustomerManagerCode.DataBindings.Clear();
            
            this.CustomerManagerName.DataBindings.Clear();


            this.ProcessingStatus.DataBindings.Clear();
           // this.CompleteDate.DataBindings.Clear();
            this.FaultType.DataBindings.Clear();
            this.Finalsolution.DataBindings.Clear();
            this.UploadTime.DataBindings.Clear();
            this.gridControl1.DataBindings.Clear();
          
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

     
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProcessingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == "完成")
            {
                this.FaultType.Enabled = true;

                this.Finalsolution.Enabled = true;
              
            }
            else
            {
                this.FaultType.Enabled = false;
                this.FaultType.SelectedItem = null;

                this.Finalsolution.Enabled = false;
                this.Finalsolution.SelectedItem = null;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Control item in this.groupBox3.Controls)
            {
                item.Enabled = true ;
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.ActualRepairPersonName.Text == string.Empty || this.Solution.Text == string.Empty || this.Solution.Text == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("请填写完整实际作业者、故障现象、解决方案");
                return;
            }
            if (StartingDate.Value.Date > ReachDate.Value.Date)
            {
                System.Windows.Forms.MessageBox.Show("出发日期不能大于到达日期");
                return;
            }
            if (ReachDate.Value.Date>CompleteDate.Value.Date)
            {
                System.Windows.Forms.MessageBox.Show("到达日期不能大于服务完成日期");
                return;
            }
            if (!((this.gridControl1.DataSource as DataTable) == null))
            {


                if ((this.gridControl1.DataSource as DataTable).Select("State = '完成'").Length > 0)
                {
                    System.Windows.Forms.MessageBox.Show("表体明细里，已经有完成状态，不能再提交一个完成状态");
                    return;
                }
            }
            if (Finalsolution.Text == "电话" || Finalsolution.Text == "送修")
            {
                BO.EntityTables[1].Table.Rows.Add(BO.BillId, Guid.NewGuid().ToString(), "", this.ActualRepairPersonName.Text, null, null, this.FaultPhenomenon.Text, this.Solution.Text, this.CompleteDate.Value, this.ProcessingStatus.Text);
            }
            else
            {
                BO.EntityTables[1].Table.Rows.Add(BO.BillId, Guid.NewGuid().ToString(), "", this.ActualRepairPersonName.Text, this.StartingDate.Value, this.ReachDate.Value, this.FaultPhenomenon.Text, this.Solution.Text, this.CompleteDate.Value, this.ProcessingStatus.Text);

                this.StartingDate.MinDate = this.ReachDate.Value;
                this.ReachDate.MinDate = this.ReachDate.Value;
                this.CompleteDate.MinDate = this.ReachDate.Value;
            
            }
            this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }

        private void ReachDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.gridView1.DeleteSelectedRows();
        }

        private void Finalsolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void InstallPerson_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            int i = this.gridView1.FocusedRowHandle;


            this.gridView1.SetRowCellValue(i, "ActualRepairPersonName", dr["username"].ToString());
            this.gridView1.SetRowCellValue(i, "ActualRepairPersonCode", dr["userid"].ToString());
        }
        
        private void riLiButton1_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            this.ActualRepairPersonName.Text = dr["username"].ToString();
        }

        private void riLiButton1_Click(object sender, EventArgs e)
        {


         
         
        }

        private void riLiButton1_OnLookUpClosed_1(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            this.ActualRepairPersonName.Text = dr["username"].ToString();
            this.riLiButton1.Text = dr["username"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            if (!((this.gridControl1.DataSource as DataTable) == null))
            {
                if ((this.gridControl1.DataSource as DataTable).Select("State = '完成'").Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show("表体明细里，没有完成状态，不能提交");
                    return;
                }

              

            }

            //判断有没有权限， 只有工程师本人才能提交
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FaultFeedback where FaultFeedbackID = '"+this.BO.BillId+"'");

            string userid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionID = '" + dt.Rows[0]["RepairMissionId"].ToString() + "'");

            string manager = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where RepairMissionID = '" + dt.Rows[0]["RepairMissionId"].ToString() + "'");

            if (userid == UFBaseLib.BusLib.BaseInfo.DBUserID)
            {



                if (button4.Text == "提交")
                {
                    //提交前，判断1：维修任务是否完成
                    if (!(this.ProcessingStatus.Text == "完成"))
                    {
                        System.Windows.Forms.MessageBox.Show("主表部分，处理状态不是完成，不能提交");
                        return;
                    }

                    if ((this.gridControl1.DataSource as DataTable).Select("State = '完成'").Length > 0)
                    {

                        this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                        this.BO.EntityTables[0].Table.Rows[0]["UploadTime"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                        this.BO.EntityTables[0].Table.Rows[0]["AuditState"] = "待审核";
                        this.BO.UpdateSave();

                        this.UploadTime.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");


                        this.button4.Text = "收回";
                        this.toolBarBill1.BtnModify.Visible = false;
                        System.Windows.Forms.MessageBox.Show("提交成功");
                        //发消息

                        Bao.Message.CMessage.SendMessage("故障解决情况，提交审核", "故障解决情况，提交审核", manager, UFBaseLib.BusLib.BaseInfo.UserId, "Fau001", this.BO.BillId);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("维修任务表体没有完成状态，不能提交");
                        return;
                    }
                }
                else
                {
                    //判断客户经理有没有审核
                    if (dt.Rows[0]["AuditPerson"].ToString() == string.Empty)
                    {

                        this.button4.Text = "提交";

                        this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = null;
                        this.BO.EntityTables[0].Table.Rows[0]["UploadTime"] = DBNull.Value;
                        this.BO.EntityTables[0].Table.Rows[0]["AuditState"] = null;
                        this.BO.UpdateSave();
                        this.toolBarBill1.BtnModify.Visible = true;
                        System.Windows.Forms.MessageBox.Show("收回成功");
                        //发消息
                        Bao.Message.CMessage.SendMessage("故障解决情况，提交审核被收回", "故障解决情况，提交审核被收回", manager, UFBaseLib.BusLib.BaseInfo.UserId, "Fau001", this.BO.BillId);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("已经审核，不能收回");
                        return;
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("只有负责工程师才能提交");
            }
        }

        private void FaultDetails_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FaultFeedback_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void FaultFeedback_KeyDown(object sender, KeyEventArgs e)
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

                if (tt2 != null)
                {
                    tt2.Dispose();
                    tt2 = null;
                    return;

                }
                tt2 = new ToolTip();
                tt2.ShowAlways = true;

                tt2.Show(Solution.Text, Solution);
            }

        }
    }
}
