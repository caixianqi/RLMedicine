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
           
            /*RepairMissionCode.BaoSQL = string.Format(@"select RepairMission.* from RepairMission 
                                        left outer join FaultFeedback on FaultFeedback.RepairMissionID = RepairMission.RepairMissionID 
                                        where ISNULL(RepairPersonCode,'')<>'' and RepairPersonCode = '{0}' 
                                            and isnull(SubmitPersonUser,'')<>'' and  (FaultFeedback.ProcessingStatus <> '完成'  or FaultFeedback.ProcessingStatus is null) 
                                            and isEnd is null
                                        order by RepairMissionCode desc",UFBaseLib.BusLib.BaseInfo.DBUserID);*/

            RepairMissionCode.BaoSQL = string.Format(@"select  RepairMission.RepairMissionCode,RepairMission.RepairMissionID,CustomerCode,CustomerName,ManufactureCode,ZoneName,MachineName,machineModel,RepairPersonName,ReportRepartDate,(BaseGuaranteeType.code + '-' + BaseGuaranteeType.name) as RepairType from RepairMission 
                                        left outer join FaultFeedback on FaultFeedback.RepairMissionID = RepairMission.RepairMissionID 
										 left join BaseGuaranteeType  on RepairMission.RepairtypeNew = BaseGuaranteeType.code
                                        where ISNULL(RepairPersonCode,'')<>'' 
										and RepairPersonCode = '{0}' 
                                            and isnull(SubmitPersonUser,'')<>'' and  (FaultFeedback.ProcessingStatus <> '完成'  or FaultFeedback.ProcessingStatus is null) 
                                            and isEnd is null
                                        order by RepairMissionCode desc", UFBaseLib.BusLib.BaseInfo.DBUserID);
                 

            RepairMissionCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName=区域,MachineName=主机型号,RepairType=维修类别,RepairPersonName=工程师,ReportRepartDate=报修日期";
            this.RepairMissionCode.FrmHigth = 250;
            this.RepairMissionCode.FrmWidth = 750;
           
            /*RepairMissionCode.DecideSql = "select * from RepairMission where   RepairMissionCode =";*/

            RepairMissionCode.DecideSql = "select RepairMission.RepairMissionCode,RepairMission.RepairMissionID,CustomerCode,CustomerName,ManufactureCode,ZoneName,MachineName,machineModel,RepairPersonName,ReportRepartDate,(BaseGuaranteeType.code + '-' + BaseGuaranteeType.name) as RepairType from RepairMission  left join BaseGuaranteeType  on RepairMission.RepairtypeNew = BaseGuaranteeType.code where RepairMissionCode =";

            RepairMissionCode.BaoColumnsWidth = "RepairMissionCode=100,CustomerName=200,ZoneName=50,MachineName=100,RepairType=80,RepairPersonName=100,ReportRepartDate=80";
            RepairMissionCode.BaoClickClose = true;
            RepairMissionCode.OnLookUpClosed +=new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);

            this.ApplicationPersonName.ReadOnly = true;
            this.DepartmentName.ReadOnly = true;

            //2015-04-14:客户要求，存货不做限制： (cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%' or cinvcode like 'w%' or cinvcode like 'j%' )
            MachineCode.BaoSQL = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where 1=1 ";
            MachineCode.BaoTitleNames = "cinvcode=存货编码,cinvname=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 400;
            MachineCode.DecideSql = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=100,cinvdefine7=150,cInvStd=100";
            MachineCode.BaoClickClose = true;
            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);

            //Lin修改 2019-02-20  新增维修改类别
            cmbRepairTypeNew.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select code,code+'-'+name as name from BaseGuaranteeType order by code");
            cmbRepairTypeNew.DisplayMember = "name";
            cmbRepairTypeNew.ValueMember = "code";

            //MachineCode.BaoSQL = "select cinvcode,cinvname,cinvdefine7,cInvStd  from " + U8DataAcc.DataBase + ".inventory where (cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%' or cinvcode like 'w%' or cinvcode like 'j%' ) ";
            //MachineCode.BaoTitleNames = "cinvcode=存货编码,cInvStd=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            //this.MachineCode.FrmHigth = 400;
            //this.MachineCode.FrmWidth = 600;
            //MachineCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
            //MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=100,cinvdefine7=150,cInvStd =100";
            //MachineCode.BaoClickClose = true;

            //MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);


            if (BO.EntityTables[1].Table.Rows.Count > 0)
            {
                this.gridControl1.DataSource = BO.EntityTables[1].Table;
            }


            this.toolBarBill1.OnBaoAddLine += new FrmLookUp.ToolBarBill.BaoAddLine(toolBarBill1_OnBaoAddLine);
            this.toolBarBill1.OnBaoDelLine += new FrmLookUp.ToolBarBill.BaoDelLine(toolBarBill1_OnBaoDelLine);

            initButton();

        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        private void initButton() 
        {
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

            //Lin修改 2019-02-20 显示审核与弃审
            //这为原来的设置
            //this.toolBarBill1.BtnAudit.Text = "同意";
            //this.toolBarBill1.BtnUnAudit.Text = "不同意";



            if (this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"].ToString() == string.Empty)
            {
                this.button1.Text = "提交";
                this.toolBarBill1.BtnModify.Visible = true;
                this.toolBarBill1.BtnAddRow.Enabled = true;
                this.toolBarBill1.BtnDeleteRow.Enabled = true;
                this.toolBarBill1.BtnUnAudit.Enabled = true;
                this.toolBarBill1.BtnDelete.Enabled = true;

            }
            else
            {
                this.button1.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;
                this.toolBarBill1.BtnAddRow.Enabled = false;
                this.toolBarBill1.BtnDeleteRow.Enabled = false;
                this.toolBarBill1.BtnUnAudit.Enabled = false;
                this.toolBarBill1.BtnDelete.Enabled = false;
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

            //this.toolBarBill1.BtnAudit.Visible = false;
            //this.toolBarBill1.BtnUnAudit.Visible = false;

            //Lin修改 2019-02-20 显示审核与弃审
            this.toolBarBill1.BtnAudit.Visible = true;
            this.toolBarBill1.BtnUnAudit.Visible = true;
            
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
            this.ManufactureCode.Text = e.ReturnRow1["ManufactureCode"].ToString();
            //this.MachineName.Text = e.ReturnRow1["MachineName"].ToString();
            this.MachineName.Text = e.ReturnRow1["machineModel"].ToString();


            this.DepartmentName.Text = Common.Common.GetUserIDDeptName(UFBaseLib.BusLib.BaseInfo.DBUserID); // e.ReturnRow1["CustomerDepartmentName"].ToString();

            this.RepairMissionID.Text = e.ReturnRow1["RepairMissionID"].ToString();

            this.BO.TempId = e.ReturnRow1["RepairMissionID"].ToString();


            this.cmbRepairTypeNew.Text = e.ReturnRow1["RepairType"].ToString();

            this.cmbRepairTypeNew.Enabled = false;

         //   BO.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.RepairMissionID;

        

           

         

         
        }

       

        public override void NewButtonBefor()
        {
            base.NewButtonBefor();

            BO.BillId = Guid.NewGuid().ToString();

            this.button1.Text = "提交";

            this.toolBarBill1.BtnModify.Visible = true;

            //this.ApplicationDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
        }


        public override void BaoDataBinding()
        {
            base.BaoDataBinding();

            this.RepairMissionCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "RepairMissionCode");
            this.CustomerCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerCode");
            this.CustomerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerName");
            this.ManufactureCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ManufactureCode");
            this.PartsApplicationCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PartsApplicationCode");
            this.ApplicationPersonName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplicationPersonName");
            this.DepartmentName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "DepartmentName");
            this.MachineName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "MachineName");

            this.ApplicationDate.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplicationDate");
            this.ApplyingReasons.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplyingReasons");
            this.RepairMissionID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairMissionID");

            //Lin修改 2019-02-20 
            this.cmbRepairTypeNew.DataBindings.Add("SelectedValue", BO.EntityTables[0].Table, "RepairtypeNew");

            this.gridControl1.DataSource = this.BO.EntityTables[1].Table;


            
        }

        public override void BaoUnDataBinding()
        {
            base.BaoUnDataBinding();
        

            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();
            this.ManufactureCode.DataBindings.Clear();
            this.MachineName.DataBindings.Clear();
            this.PartsApplicationCode.DataBindings.Clear();
            this.ApplicationPersonName.DataBindings.Clear();
            this.DepartmentName.DataBindings.Clear();
         

            this.ApplicationDate.DataBindings.Clear();
            this.ApplyingReasons.DataBindings.Clear();
            this.RepairMissionID.DataBindings.Clear();

            //Lin修改 2019-02-20 
            this.cmbRepairTypeNew.DataBindings.Clear();

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
            DataTable dtuser = Common.Common.Select_SQL_Role_Users("011");
            string strManagers = string.Empty;
            if (this.button1.Text == "提交")
            {
                #region
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonName"] = UFBaseLib.BusLib.BaseInfo.UserName;
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                this.ApplicationDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");

                this.BO.UpdateSave();

               
                foreach (DataRow dr in dtuser.Rows)
                {
                    if (strManagers.Length > 0)
                        strManagers += ",";
                    strManagers += dr["UserName"].ToString();
                    CMessage.SendMessage("配件申请", "有新的配件申请单，请查看", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BO.BillId);
                }

                this.button1.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;

                System.Windows.Forms.MessageBox.Show("提交仓库人员至[" + strManagers + "],成功!");
                #endregion
            }
            else
            {
                //if (!(dt.Rows[0]["AuditName"].ToString() == string.Empty))
                //{
                //    throw new Exception("已经审核，不能收回");
                //}
                string isPI = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select 1 from PartsInventory where PartsApplicationID = '" + dt.Rows[0]["PartsApplicationID"].ToString() + "'"); // RepairMissionCode = '" + dt.Rows[0]["RepairMissionCode"].ToString() + "'");
                string str = dt.Rows[0]["RepairMissionCode"].ToString();
                if (isPI.Length > 0)
                {
                    throw new Exception("已经出入库单，不能收回");
                }
                this.BO.EntityTables[0].Table.Rows[0]["ApplicationPersonCode"] = string.Empty;
               

                this.BO.UpdateSave();

                this.button1.Text = "提交";
              
               
                foreach (DataRow dr in dtuser.Rows)
                {
                    if (strManagers.Length > 0)
                        strManagers += ",";
                    strManagers += dr["UserName"].ToString();
                    CMessage.SendMessageToRoleNoDepartment("配件申请被收回", "配件申请被收回", dr["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Par001", this.BO.BillId);
                }
                System.Windows.Forms.MessageBox.Show("收回成功,信息发至[" + strManagers + "]!");
                this.toolBarBill1.BtnModify.Visible = true;
            }

            initButton();
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

        private void PartsApplication_Load(object sender, EventArgs e)
        {

        }

        private void BtnOutExcel_Click(object sender, EventArgs e)
        {
            if(RepairMissionCode.Text == "")
            {
                MessageBox.Show("请选择维修单据编号", "温馨提示！");
                return;
            }
            try
            {
                string sql = string.Format(@" select RepairMissionCode,CustomerName,RepairContractPeople,ContractNumber,
		                                        MachineModel,ManufactureCode,dtimefh,dtimefhbx,dtimegc,dtimegcbx,PurchaseDate,
		                                        dtimeazbx,ReportRepartDate,FaultDetails,(b.code + '-' + b.name) as RepairtypeNew 
		                                      from RepairMission r
			                                    left join BaseGuaranteeType b on r.RepairtypeNew = b.code
                                              where RepairMissionCode = '{0}'", RepairMissionCode.Text);

                DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有此维修单号！", "温馨提示！");
                    return;
                }

                DataRow dr = dt.Rows[0];

                RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\保内申请书模板.xls");

                ex.SetCellValue(2, 4, dr["RepairMissionCode"].ToString()); //维修单号
                ex.SetCellValue(3, 3, dr["CustomerName"].ToString());  //医院名——客户名称

                ex.SetCellValue(4, 3, dr["RepairContractPeople"].ToString()); //联系人——维修联系人
                ex.SetCellValue(4, 13, dr["ContractNumber"].ToString());   //联系电话——联系电话
                ex.SetCellValue(5, 3, dr["MachineModel"].ToString());  //主机型号——主机机型2
                ex.SetCellValue(5, 11, dr["ManufactureCode"].ToString());  //SN——制造编号
                ex.SetCellValue(6, 3, dr["dtimefh"].ToString());  //本部出厂日期——本部发货日期
                ex.SetCellValue(6, 11, dr["dtimefhbx"].ToString());  //本部保修截止日期——本部保修期限
                ex.SetCellValue(7, 3, dr["dtimegc"].ToString());  //(GC)  发货日期——GC出库日期
                ex.SetCellValue(7, 11, dr["dtimegcbx"].ToString());  //(GC)保修截止——GC保修期限
                ex.SetCellValue(8, 3, dr["PurchaseDate"].ToString());  //安装日期——购买日期
                ex.SetCellValue(8, 11, dr["dtimeazbx"].ToString());  //主机保修期限——安装保修期限
                ex.SetCellValue(9, 11, dr["ReportRepartDate"].ToString());  //保内申请日期——报修日期
                ex.SetCellValue(14, 2, dr["FaultDetails"].ToString());  //故障内容——故障描述
                ex.SetCellValue(26, 6, dr["RepairtypeNew"].ToString());  //修理类型——维修类别

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
    }
}
