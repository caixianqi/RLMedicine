using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bao.Message;
using UFBaseLib.BusLib;

namespace Repair
{
    public partial class FreeApplication :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral

    {
        public FreeApplication()
        {
          
            InitializeComponent();
            this.BO = new Repair.FreeApplicationBill();
            BO.Init("");
            init();
        }
        public FreeApplication(string id)
        {

            InitializeComponent();
            this.BO = new Repair.FreeApplicationBill();
            BO.Init(id);
            init();
            IsMyBill(this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString());
        }
        public override void IsMyBill(string RepairMissionCode)
        {
            if (UFBaseLib.BusLib.BaseInfo.DBUserID == this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString())
            {
                return;
            }
            base.IsMyBill(RepairMissionCode);

           
        }

        private void init()
        {

            //RepairMissionCode.BaoSQL = "select RepairMission.*,Price.PriceCode,Bill.BillID from RepairMission ,FaultFeedback,Price left outer join Bill on Price.PriceID = Bill.PriceID where RepairMission.RepairMissionID not in (select RepairMissionID from FreeApplication)  and FaultFeedback.RepairMissionID = RepairMission.RepairMissionID and Price.RepairMissionID = RepairMission.RepairMissionID and FaultFeedback.ProcessingStatus <> '完成'  and BillID is null ";

            /*string sql = @"select RepairMission.*,bt.Name as RepairTypeNewName,Price.PriceCode,Bill.BillID,FaultFeedback.ProcessingStatus 
                           from RepairMission left outer join FaultFeedback   on FaultFeedback.RepairMissionID = RepairMission.RepairMissionID 
                           left outer join Price left outer join Bill on Price.PriceID = Bill.PriceID  on Price.RepairMissionID =RepairMission.RepairMissionID 
                           left join BaseGuaranteeType bt on RepairMission.RepairtypeNew = bt.code
                            where RepairMission.RepairMissionID not in (select RepairMissionID from FreeApplication)   and RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID
                      + "' and (SubmitPersonUser is not null and SubmitPersonUser<>'') and  RepairMission.RepairTypeNew = 'C'  and isEnd is null  order by RepairMission.RepairMissionCode";*/

            //Lin 2020_1_11 按客户要求，增加 H: HT苦情 CE:后盾期外，CA: A类期外  CH:华通受理 维修流程都是“C”

            string sql = @"select RepairMission.*,bt.Name as RepairTypeNewName,Price.PriceCode,Bill.BillID,FaultFeedback.ProcessingStatus 
                           from RepairMission left outer join FaultFeedback   on FaultFeedback.RepairMissionID = RepairMission.RepairMissionID 
                           left outer join Price left outer join Bill on Price.PriceID = Bill.PriceID  on Price.RepairMissionID =RepairMission.RepairMissionID 
                           left join BaseGuaranteeType bt on RepairMission.RepairtypeNew = bt.code
                            where RepairMission.RepairMissionID not in (select RepairMissionID from FreeApplication)   and RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID
                        + "' and (SubmitPersonUser is not null and SubmitPersonUser<>'') and  ( RepairMission.RepairTypeNew = 'C' or RepairMission.RepairTypeNew = 'H' or RepairMission.RepairTypeNew = 'CE' or RepairMission.RepairTypeNew = 'CA' or RepairMission.RepairTypeNew = 'CH' ) and isEnd is null  order by RepairMission.RepairMissionCode";


            RepairMissionCode.BaoSQL = sql;
            RepairMissionCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName=区域,MachineName = 主机型号,RepairTypeNewName =维修类别,RepairPersonName = 工程师, ReportRepartDate = 报修日期";
            this.RepairMissionCode.FrmHigth = 300;
            this.RepairMissionCode.FrmWidth = 650;
            RepairMissionCode.DecideSql = "select a.*,bt.Name as RepairTypeNewName from RepairMission a left join BaseGuaranteeType bt on a.RepairtypeNew = bt.code  where  a.RepairMissionCode =";
            RepairMissionCode.BaoColumnsWidth = "RepairMissionCode=100,CustomerName=200,ZoneName=80,MachineName=100,RepairTypeNewName=100,RepairPersonName=80,ReportRepartDate=100";
            RepairMissionCode.BaoClickClose = true;
            RepairMissionCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);




            AuditerCode.BaoSQL = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and (r.RoleId = '009' or r.RoleId = '008')";
            AuditerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            AuditerCode.FrmHigth = 400;
            AuditerCode.FrmWidth = 400;
            AuditerCode.DecideSql = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and  (r.RoleId = '009' or r.RoleId = '008') and  userid =";
            AuditerCode.BaoColumnsWidth = "userid=150,username=150";

            AuditerCode.BaoClickClose = true;
            AuditerCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(AuditerCode_OnLookUpClosed);


            this.toolBarBill1.tssAddRow.Visible = false;
            this.toolBarBill1.tssAudit.Visible = false;
            this.toolBarBill1.tssPrint.Visible = false;


            this.toolBarBill1.btnEnd.Visible = false;


            this.toolBarBill1.BtnAddRow.Visible = false;
            this.toolBarBill1.BtnDeleteRow.Visible = false;
            this.toolBarBill1.BtnExcel.Visible = false;
            this.toolBarBill1.BtnAuditList.Visible = false;
            this.toolBarBill1.tssLocation.Visible = false;
            this.toolBarBill1.BtnLocation.Visible = false;
            this.toolBarBill1.BtnUnUpLoad.Visible = false;
            this.toolBarBill1.BtnUpLoad.Visible = false;
            this.toolBarBill1.BtnCancel.Enabled = false;


            this.toolBarBill1.BtnAudit.Text = "同意";
            this.toolBarBill1.BtnUnAudit.Text = "不同意";

            if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                this.button1.Text = "提交";
                this.toolBarBill1.BtnModify.Visible = true;
            }
            else
            {
                this.button1.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;
            }

            if (this.BO.EntityTables[0].Table.Rows[0]["AuditPerson"].ToString() == string.Empty)
            {
                this.toolBarBill1.BtnAudit.Enabled = true;
                this.toolBarBill1.BtnUnAudit.Enabled = true;
            }
            else
            {
                this.toolBarBill1.BtnAudit.Enabled = true;
                this.toolBarBill1.BtnUnAudit.Enabled = true;
            }
            if (BaseInfo.userRole.Contains("003"))
            {

                this.button1.Visible = true;
               
            }
          
        }

        void AuditerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.AuditerCode.BaoBtnCaption = e.ReturnRow1["userid"].ToString();
            this.AuditerName.Text = e.ReturnRow1["username"].ToString();
        }

        void RepairMissionCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.RepairMissionCode.Text = e.ReturnRow1["RepairMissionCode"].ToString();

            this.CustomerName.Text = e.ReturnRow1["CustomerName"].ToString();
            this.CustomerCode.Text = e.ReturnRow1["CustomerCode"].ToString();

            this.RepairMissionID.Text = e.ReturnRow1["RepairMissionID"].ToString();

            this.BO.TempId = e.ReturnRow1["RepairMissionID"].ToString();
        }

        public override void BaoDataBinding()
        {
            base.BaoDataBinding();

            this.RepairMissionCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "RepairMissionCode");
            this.CustomerCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerCode");
            this.CustomerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerName");
            this.AppReson.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AppReson");
            this.RepairMissionID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairMissionID");

            this.AuditerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AuditerName");
            this.AuditerCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "AuditerCode");
        }

        public override void BaoUnDataBinding()
        {
            base.BaoUnDataBinding();

            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();
            this.AppReson.DataBindings.Clear();
            this.RepairMissionID.DataBindings.Clear();
            this.AuditerCode.DataBindings.Clear();
            this.AuditerName.DataBindings.Clear();
        }

        private void FreeApplication_Load(object sender, EventArgs e)
        {

        }

      

        public override void NewButtonAfter()
        {
            base.NewButtonAfter();
        }

        public override void NewButtonBefor()
        {
            BO.BillId = Guid.NewGuid().ToString();
            this.AuditerCode.Text = null;
            this.AuditerName.Text = null;
            this.button1.Text = "提交";

        }

        public override void Audit()
        {
            base.Audit();
            this.toolBarBill1.BtnAudit.Enabled = false;
            this.toolBarBill1.BtnUnAudit.Enabled = true;

        }

      

        public override void UnAudit()
        {
            base.UnAudit();
            this.toolBarBill1.BtnAudit.Enabled = true;
            this.toolBarBill1.BtnUnAudit.Enabled = false;
        }

    



        #region IU8Contral 成员

        public void Authorization()
        {
            
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from FreeApplication where FreeID = '" + this.BO.BillId + "'");
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
            //AppPersonId
            if (dt.Rows[0]["AppPersonId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID)
            {
              
                if (this.BO.EntityTables[0].Table.Rows[0]["AuditerName"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("未指定客服部长，不能提交");
                    return;
                }

                if (this.button1.Text == "提交")
                {
                    //能否提交的判断  
                    //if (this.toolBarBill1.BtnUnAudit.Enabled)
                    //{
                    //    throw new Exception("已经提交，不能重复");
                    //}
                    //验证是不是做了发票


                    //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）发起了配件借用并使用的,不能提出"免费申请"
                    DataTable Checkdt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(string.Format("select * from PartsInventory a left join PartsUseAndReturnInfo b on a.PartsInventoryID=b.PartsInventoryID where a.RepairMissionCode ='{0}'and b.ProcessResults='已使用' ", this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"]));

                    if (Checkdt.Rows.Count > 0)
                    {
                        throw new Exception("发现配件出入库的配件借用并已使用中,将不能提出免费申请");
                    }

                    string priceid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(String.Format("select  PriceId from price where RepairMissionCode ='{0}'", this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"]));

                    if (!(priceid == string.Empty))
                    {

                        if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Bill where PriceId = '" + priceid + "'").Rows.Count > 0)
                        {
                            throw new Exception("发现该维修任务已经存在发票申请，请把发票删除后，才能做免费申请");
                        }
                    }

                    this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                    this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                    this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"] = this.AuditerCode.Text;
                    this.BO.EntityTables[0].Table.Rows[0]["AuditerName"] = this.AuditerName.Text;


                    this.BO.UpdateSave();

                   // CMessage.SendMessageToRoleNoDepartment("免费申请", "有新的免费申请，请察看", "002", UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BO.BillId);

                    CMessage.SendMessage("免费申请", "有新的免费申请，请察看",this.AuditerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BO.BillId);

                    this.button1.Text = "收回";

                    System.Windows.Forms.MessageBox.Show("提交成功,发送至[" + this.AuditerCode.Text + "]!");

                    this.toolBarBill1.BtnModify.Visible = false;
                }
                else
                {

                    //审核后，不能收回。
                    if (dt.Rows[0]["AuditPerson"].ToString() == string.Empty)
                    {

                  
                        this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = string.Empty;
                        this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] = DBNull.Value;
                        this.BO.UpdateSave();

                        this.button1.Text = "提交";

                        this.toolBarBill1.BtnModify.Visible = true;

                       


                        CMessage.SendMessage("免费申请", "免费申请被收回", this.AuditerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BO.BillId);
                        System.Windows.Forms.MessageBox.Show("收回成功,发送至[" + this.AuditerCode.Text + "]!");
                    }
                    else
                    {
                        throw new Exception("已经审核，不能收回");
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("您没有权限");
            }
        }

        private void AuditerCode_OnLookUpClosed_1(object sender, FrmLookUp.LookUpEventArgs e)
        {

        }
        private ToolTip tt;
        private void FreeApplication_KeyDown(object sender, KeyEventArgs e)
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

                tt.Show(AppReson.Text, AppReson);


            }
        }
    }
}
