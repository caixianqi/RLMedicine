using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using U8Global;
using Bao.Message;
using UFBaseLib.BusLib;

namespace Repair
{
    public partial class PartsApplication :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {
        private FrmLookUp.ButtonEdit MachineCode = new FrmLookUp.ButtonEdit();

     

        public PartsApplication()
        {
         
            InitializeComponent();
            this.BO = new Repair.PartsApplicationBill();
            BO.Init("");
            init();
        }

        public PartsApplication(string id)
        {

            InitializeComponent();
            this.BO = new Repair.PartsApplicationBill();
            BO.Init(id);
            init();
        }
        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            this.gridView1.CloseEditor();
            this.gridView1.UpdateCurrentRow();

            //string dd = this.AuditerCode.Text;
            //string bb = this.AuditerName.Text;

            //if (dd == string.Empty || bb == string.Empty)
            //{
            //}
            //else
            //{
            //    this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"] = dd;
            //    this.BO.EntityTables[0].Table.Rows[0]["AuditerName"] = bb;


            //    this.BO.EntityTables[0].Table.AcceptChanges();
            //}


        

        
            base.toolBarBill1_OnBaoSave(sender, e);


        }

        public override void IsMyBill(string RepairMissionCode)
        {
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("007") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("008"))
            {
                return;
            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = false;
                }
            }
        }
        

        private void init()
        {
            RepairMissionCode.BaoSQL = "select RepairMission.* from RepairMission left outer join FaultFeedback on FaultFeedback.RepairMissionID = RepairMission.RepairMissionID where ((RepairPersonCode is not null) and (RepairPersonCode <>'')) and (RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "') and (SubmitPersonUser is not null and SubmitPersonUser <>'')  and  (FaultFeedback.ProcessingStatus <> '完成'  or FaultFeedback.ProcessingStatus is null) and isEnd is null";
            RepairMissionCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName=区域,MachineName=主机型号,RepairType=维修类别,RepairPersonName=工程师,ReportRepartDate=报修日期";
            this.RepairMissionCode.FrmHigth = 250;
            this.RepairMissionCode.FrmWidth = 750;
            RepairMissionCode.DecideSql = "select * from RepairMission where   RepairMissionCode =";
            RepairMissionCode.BaoColumnsWidth = "RepairMissionCode=100,CustomerName=200,ZoneName=50,MachineName=100,RepairType=80,RepairPersonName=100,ReportRepartDate=80";
            RepairMissionCode.BaoClickClose = true;
            RepairMissionCode.OnLookUpClosed +=new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);

            this.ApplicationPersonName.ReadOnly = true;


            MachineCode.BaoSQL = "select cinvcode,cinvname,cinvdefine7,cInvStd from " + U8DataAcc.DataBase + ".inventory where (cinvcode like 's%' or cinvcode like 'c%' )";
            MachineCode.BaoTitleNames = "cinvcode=存货编码,cinvname=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 400;
            MachineCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=100,cinvdefine7=150,cInvStd=100";
            MachineCode.BaoClickClose = true;
            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);



            MachineCode.BaoSQL = "select cinvcode,cinvname,cinvdefine7,cInvStd  from " + U8DataAcc.DataBase + ".inventory where (cinvcode like 's%' or cinvcode like 'c%' ) ";
            MachineCode.BaoTitleNames = "cinvcode=存货编码,cInvStd=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 600;
            MachineCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=100,cinvdefine7=150,cInvStd =100";
            MachineCode.BaoClickClose = true;

            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);



            AuditerCode.BaoSQL = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '008'";
            AuditerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            AuditerCode.FrmHigth = 400;
            AuditerCode.FrmWidth = 400;
            AuditerCode.DecideSql = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '008' and  userid =";
            AuditerCode.BaoColumnsWidth = "userid=100,username=100";
            AuditerCode.BaoClickClose = true;
            AuditerCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(AuditerCode_OnLookUpClosed);


            if (BO.EntityTables[1].Table.Rows.Count > 0)
            {
                this.gridControl1.DataSource = BO.EntityTables[1].Table;
            }


            this.toolBarBill1.OnBaoAddLine += new FrmLookUp.ToolBarBill.BaoAddLine(toolBarBill1_OnBaoAddLine);
            this.toolBarBill1.OnBaoDelLine += new FrmLookUp.ToolBarBill.BaoDelLine(toolBarBill1_OnBaoDelLine);

            this.toolBarBill1.tssAddRow.Visible = false;
            this.toolBarBill1.tssAudit.Visible = false;
            this.toolBarBill1.tssPrint.Visible = false;
         
         
            this.toolBarBill1.btnEnd.Visible = false;
         
        
      
            this.toolBarBill1.BtnExcel.Visible = false;
            this.toolBarBill1.BtnAuditList.Visible = false;
            this.toolBarBill1.tssLocation.Visible = false;
            this.toolBarBill1.BtnLocation.Visible = false;
            this.toolBarBill1.BtnUnUpLoad.Visible = false;
            this.toolBarBill1.BtnUpLoad.Visible = false;

            this.toolBarBill1.BtnAudit.Text = "同意";
            this.toolBarBill1.BtnUnAudit.Text = "不同意";

            

            if (this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString() == string.Empty)
            {
                this.button1.Text = "提交";
                this.toolBarBill1.BtnModify.Visible = true;
                this.toolBarBill1.BtnAddRow.Enabled = true;
                this.toolBarBill1.BtnDeleteRow.Enabled = true;
                this.toolBarBill1.BtnUnAudit.Enabled = true;
               
            }
            else
            {
                this.button1.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;
                this.toolBarBill1.BtnAddRow.Enabled = false;
                this.toolBarBill1.BtnDeleteRow.Enabled = false;
                this.toolBarBill1.BtnUnAudit.Enabled = false;
            }

            if (this.BO.EntityTables[0].Table.Rows[0]["AuditName"].ToString() == string.Empty)
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

            this.button1.Enabled = true;

            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
                this.toolBarBill1.BtnAddNew.Visible = true;
            }
            else
            {
                this.toolBarBill1.BtnAddNew.Visible = false;
            }

          

        }

        void AuditerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.AuditerCode.BaoBtnCaption = e.ReturnRow1["userid"].ToString();
            this.AuditerCode.Text = e.ReturnRow1["userid"].ToString();
            this.AuditerName.Text = e.ReturnRow1["username"].ToString();

          

        }

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse( MachineCode.CodeValue.ToString());
            this.gridView1.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["cinvcode"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryName", e.ReturnRow1["cinvname"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["cInvStd"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["cinvdefine7"].ToString());
        }

        void toolBarBill1_OnBaoDelLine(object sender, EventArgs e)
        {


            this.gridView1.DeleteSelectedRows();
         
        }

        void toolBarBill1_OnBaoAddLine(object sender, EventArgs e)
        {
            BO.EntityTables[1].Table.Rows.Add(BO.BillId, Guid.NewGuid().ToString(),  null, null, null,1, null, null);
           // this.gridView1.AddNewRow();
           // this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }


        void RepairMissionCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.RepairMissionCode.BaoBtnCaption = e.ReturnRow1["RepairMissionCode"].ToString();
            this.CustomerCode.Text = e.ReturnRow1["CustomerCode"].ToString();
            this.CustomerName.Text = e.ReturnRow1["CustomerName"].ToString();


            this.RepairMissionID.Text = e.ReturnRow1["RepairMissionID"].ToString();

            this.BO.TempId = e.ReturnRow1["RepairMissionID"].ToString();
          
          

         //   BO.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.RepairMissionID;

        

           

         

         
        }

       

        public override void NewButtonBefor()
        {
            base.NewButtonBefor();

            BO.BillId = Guid.NewGuid().ToString();

            this.button1.Text = "提交";

            this.toolBarBill1.BtnModify.Visible = true;
        }


        public override void BaoDataBinding()
        {
            base.BaoDataBinding();

            this.RepairMissionCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "RepairMissionCode");
            this.CustomerCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerCode");
            this.CustomerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerName");
            this.PartsApplicationCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PartsApplicationCode");
            this.ApplicationPersonName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplicationPersonName");
          

            this.ApplicationDate.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplicationDate");
            this.ApplyingReasons.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplyingReasons");
            this.RepairMissionID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairMissionID");

            this.AuditerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AuditerName");
            this.AuditerCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AuditerCode");
            this.AuditerCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "AuditerCode");


            this.gridControl1.DataSource = this.BO.EntityTables[1].Table;


            
        }

        public override void BaoUnDataBinding()
        {
            base.BaoUnDataBinding();
        

            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();
            this.PartsApplicationCode.DataBindings.Clear();
            this.ApplicationPersonName.DataBindings.Clear();
            
         

            this.ApplicationDate.DataBindings.Clear();
            this.ApplyingReasons.DataBindings.Clear();
            this.RepairMissionID.DataBindings.Clear();
            this.AuditerCode.DataBindings.Clear();
            this.AuditerName.DataBindings.Clear();

            this.gridControl1.DataBindings.Clear();
        }

        #region IU8Contral 成员

        public void Authorization()
        {
          
        }

        #endregion

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gridControl_MouseDown(object sender, MouseEventArgs e)
        {
           
            GridView gv = ((GridControl)sender).MainView as GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gv.CalcHitInfo(new Point(e.X, e.Y));
            if (((e.Button & MouseButtons.Left) != 0) && (hInfo.InRow) && (!gv.IsGroupRow(hInfo.RowHandle)) && (!gv.IsFilterRow(hInfo.RowHandle)))
            {
                if (hInfo.InRowCell)
                {
                    //判断光标是否在行范围内
                    if (this.toolBarBill1.BtnModify.Enabled == false)
                    {

                        if (hInfo.Column.FieldName == "InventoryName" || hInfo.Column.FieldName == "InventoryCode" || hInfo.Column.FieldName == "InventoryStd" || hInfo.Column.FieldName == "InventoryEngName")
                        {
                            //this.cVenCode.ShowRef();

                            //if (!(this.cVenCode.Text == string.Empty))
                            //{
                            //    gv.SetRowCellValue(hInfo.RowHandle, "FactoryCode", this.cVenCode.Text);

                            //    gv.SetRowCellValue(hInfo.RowHandle, "FactoryName", this.cVenCode.DisplayText);
                            //}
                            //this.MachineCode.LookForm = new FrmLookUp.FrmLookUpBase();

                            //this.MachineCode.LookForm.ShowDialog();
                            this.MachineCode.CodeValue = hInfo.RowHandle.ToString();

                            this.MachineCode.ShowForm();
                        }
                    }
                }

            }
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

        public override void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
           
                base.toolBarBill1_OnBaoUpdate(sender, e);
            
           
      
        }
        public override void UpdateButtonBefor()
        {
            

            base.UpdateButtonBefor();
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
           DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from PartsApplication where PartsApplicationID = '"+this.BO.BillId+"'");
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            if (!(dt.Rows[0]["UserId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
            {
                MessageBox.Show("您没有权限");
                return;
            }
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
          

            if (this.button1.Text == "提交")
            {

                if (dt.Rows[0]["AuditerName"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("未指定总监，不能提交");
                    return;
                }

                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonName"] = UFBaseLib.BusLib.BaseInfo.UserName;
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.ApplicationDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"] = this.AuditerCode.Text;
                this.BO.EntityTables[0].Table.Rows[0]["AuditerName"] = this.AuditerName.Text;

                this.BO.UpdateSave();





                CMessage.SendMessage("配件申请", "有新的配件申请单，请查看", this.AuditerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BO.BillId);
           


                this.button1.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;

                System.Windows.Forms.MessageBox.Show("提交成功");
            }
            else
            {
                if (!(dt.Rows[0]["AuditName"].ToString() == string.Empty))
                {
                    throw new Exception("已经审核，不能收回");
                }
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"] = string.Empty;
               

                this.BO.UpdateSave();

                this.button1.Text = "提交";

              
                System.Windows.Forms.MessageBox.Show("收回成功");
                this.toolBarBill1.BtnModify.Visible = true ;
                CMessage.SendMessageToRoleNoDepartment("配件申请被收回", "配件申请被收回", this.AuditerCode.Text, UFBaseLib.BusLib.BaseInfo.UserId, "Fre001", this.BO.BillId);
            }

        }

        private ToolTip tt;
        private void PartsApplication_KeyDown(object sender, KeyEventArgs e)
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


                tt.Show(ApplyingReasons.Text, ApplyingReasons);
            }
        }
    }
}
