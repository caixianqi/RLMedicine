using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFBaseLib.BusLib;
using U8Global;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using Bao.Message;

namespace Repair
{
    public partial class Price : Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {
        private FrmLookUp.ButtonEdit MachineCode = new FrmLookUp.ButtonEdit();

        private RepositoryItemLookUpEdit fareselect;

        ToolTip tt;
        private SaveFileDialog saveFileDialog1;

        public Price()
        {
           
            InitializeComponent();
            this.BO = new Repair.PriceBill();
            BO.Init("");
            init();

            this.Remarks.Enabled = true;
        }

        public Price(string id)
        {
            InitializeComponent();
            this.BO = new Repair.PriceBill();
            BO.Init(id);
            init();
            IsMyBill(this.BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString());

        }


        public override void NewButtonBefor()
        {
            base.NewButtonBefor();
           

            BO.BillId = Guid.NewGuid().ToString();

            this.RepairMissionCode.Enabled = true;

            RoleController();
        }

        public override void NewButtonAfter()
        {
            this.button1.Text = "提交";
            this.button2.Text = "提交";
            base.NewButtonAfter();
            RoleController();
        }

        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            this.gridView1.CloseEditor();
            this.gridView1.UpdateCurrentRow();

          
            
            base.toolBarBill1_OnBaoSave(sender, e);

           
        }

        private void init()
        {
            //Lin修改 2019-02-20 维修类型F类改成与C类一样的流程(即加多个条件 or  RepairtypeNew = 'F')

            //Lin 2020_1_11 按客户要求，增加 H: HT苦情  CE:后盾期外，CA: A类期外  CH:华通受理 维修流程都是“C”

            /*RepairMissionCode.BaoSQL = string.Format(@"select * from RepairMission 
                                                    where  RepairPersonCode ='{0}' 
		                                                    and RepairMissionCode not in (select RepairMissionCode from Price) 
		                                                    and (RepairtypeNew = 'C' or  RepairtypeNew = 'F' or  RepairtypeNew = 'H' or  RepairtypeNew = 'CE' or  RepairtypeNew = 'CA' or  RepairtypeNew = 'CH') 
		                                                    and RepairMissionCode not in (select RepairMissionCode from FreeApplication where isnull(AuditPerson,'') <>'') 
		                                                    and isEnd is null", UFBaseLib.BusLib.BaseInfo.DBUserID );*/

            RepairMissionCode.BaoSQL = string.Format(@"select RepairMission.RepairMissionCode,RepairMission.RepairMissionID,CustomerCode,CustomerName,ManufactureCode,ZoneName,MachineName,machineModel,RepairPersonName,ReportRepartDate,(BaseGuaranteeType.code + '-' + BaseGuaranteeType.name) as RepairType,FaxNumber,jqjbcode from RepairMission 
 left join BaseGuaranteeType  on RepairMission.RepairtypeNew = BaseGuaranteeType.code
                                                    where  RepairPersonCode ='{0}' 
		                                                    and 
															RepairMissionCode not in (select RepairMissionCode from Price) 
		                                                    and (RepairtypeNew = 'C' or  RepairtypeNew = 'F' or  RepairtypeNew = 'H' or  RepairtypeNew = 'CE' or  RepairtypeNew = 'CA' or  RepairtypeNew = 'CH') 
		                                                    and RepairMissionCode not in (select RepairMissionCode from FreeApplication where isnull(AuditPerson,'') <>'') 
		                                                    and isEnd is null", UFBaseLib.BusLib.BaseInfo.DBUserID);

            RepairMissionCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName = 区域,MachineName = 主机型号,RepairType =维修类别,RepairPersonName = 工程师, ReportRepartDate = 报修日期";
            this.RepairMissionCode.FrmHigth = 400;
            this.RepairMissionCode.FrmWidth = 750;

            //RepairMissionCode.DecideSql = "select * from RepairMission where RepairPersonCode ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and RepairMissionCode =";

            RepairMissionCode.DecideSql = "select RepairMission.RepairMissionCode,RepairMission.RepairMissionID,CustomerCode,CustomerName,ManufactureCode,ZoneName,MachineName,machineModel,RepairPersonName,ReportRepartDate,(BaseGuaranteeType.code + '-' + BaseGuaranteeType.name) as RepairType,FaxNumber,jqjbcode from RepairMission left join BaseGuaranteeType  on RepairMission.RepairtypeNew = BaseGuaranteeType.code where RepairPersonCode ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and RepairMissionCode =";


            RepairMissionCode.BaoColumnsWidth = "RepairMissionCode=100,CustomerName=150,ZoneName=100,MachineName=100,RepairType=80,RepairPersonName=80,ReportRepartDate=80";
            RepairMissionCode.BaoClickClose = true;

            RepairMissionCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);


            //InventoryCode.BaoSQL = "select cinvcode,cinvname  from " + U8DataAcc.DataBase + ".inventory where cinvcode like 'A%' and len(cinvcode) = 3";
            //InventoryCode.BaoTitleNames = "cinvcode=存货编码 ,cinvname=存货名称";
            //this.InventoryCode.FrmHigth = 600;
            //this.InventoryCode.FrmWidth = 400;
            //InventoryCode.DecideSql = "select * from " + U8DataAcc.DataBase + ".inventory where cinvcode=";
            //InventoryCode.BaoColumnsWidth = "cinvcode=150,cinvname=250";
            //InventoryCode.BaoClickClose = true;
            //InventoryCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(InventoryName_OnLookUpClosed);



            //2015-04-14:客户要求，存货不做限制：(cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%' or cinvcode like 'w%' or cinvcode like 'j%')
            MachineCode.BaoSQL = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where 1=1 ";
            MachineCode.BaoTitleNames = "cinvcode=存货编码,cinvname=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 750;
            MachineCode.DecideSql = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=200,cinvdefine7=150,cInvStd=100";
            MachineCode.BaoClickClose = true;
            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);


            this.CustomerName.Enabled = false;

            //现品不良、未使用、不良品
       

            //IList<string> statelist = new List<string>();

            //statelist.Add("新品");
            //statelist.Add("以旧换新");
            //repositoryItemGridLookUpEdit2.NullText = "新品";
            //repositoryItemGridLookUpEdit2.Name = "请选择";

            //repositoryItemGridLookUpEdit2.DataSource = statelist;


            repositoryItemComboBox4.Items.Add("新品");
            repositoryItemComboBox4.Items.Add("以旧换新");
            this.repositoryItemComboBox4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


            //IList<string> statelist2 = new List<string>();
            //statelist2.Add("要");
            //statelist2.Add("不要");
            //repositoryItemGridLookUpEdit1.DataSource = statelist2;

            repositoryItemComboBox5.Items.Add("要");
            repositoryItemComboBox5.Items.Add("不要");
            this.repositoryItemComboBox5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            if (BO.EntityTables[1].Table.Rows.Count > 0)
            {
                this.gridControl1.DataSource = BO.EntityTables[1].Table;
            }
            this.toolBarBill1.OnBaoAddLine += new FrmLookUp.ToolBarBill.BaoAddLine(toolBarBill1_OnBaoAddLine);
            this.toolBarBill1.OnBaoDelLine += new FrmLookUp.ToolBarBill.BaoDelLine(toolBarBill1_OnBaoDelLine);
            this.toolBarBill1.OnBaoExcel += new FrmLookUp.ToolBarBill.BaoExcel(toolBarBill1_OnBaoExcel);
            this.toolBarBill1.OnAfterBaoCancel += new FrmLookUp.ToolBarBill.AfterBaoCancel(toolBarBill1_OnAfterBaoCancel);

            string date = this.BO.EntityTables[0].Table.Rows[0]["ddate"].ToString();

            this.toolBarBill1.tssAddRow.Visible = false;
            this.toolBarBill1.tssAudit.Visible = false;
            this.toolBarBill1.tssPrint.Visible = false;
            this.toolBarBill1.tssUpLoad.Visible = false;
            this.toolBarBill1.BtnExcel.Visible = true;
            this.toolBarBill1.btnEnd.Visible = false;

            this.toolBarBill1.BtnAudit.Visible = false;
            this.toolBarBill1.BtnUnAudit.Visible = false;
            this.toolBarBill1.BtnUpLoad.Visible = false;
           
            this.toolBarBill1.BtnAuditList.Visible = false;
            this.toolBarBill1.tssLocation.Visible = false;
            this.toolBarBill1.BtnLocation.Visible = false;
            this.toolBarBill1.BtnUnUpLoad.Visible = false;



            StateControl();

          

          
        }
        public void StateControl()
        {
           
            if (this.BO.EntityTables[0].Table.Rows.Count > 0)
            {
                if (!(this.BO.BillId == string.Empty))
                {
                    //查到这里有BUG，因为报价单删除后，再重新单据，它的ID就不一样，所以这里再用以前的ID查，数据已不存在。
                    //上面不是为判断表行数据大于零吗？之所以能走到，是因为它载入时候，用代码增加了一行，不懂，请调试代码，2013、01、08
                    //DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from price where priceid = '" + this.BO.BillId + "'");
                    if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
                    {
                        this.button1.Text = "提交";
                    }
                    else
                    {
                        this.button1.Text = "收回";
                        foreach (Control item in groupBox1.Controls)
                        {
                            item.Enabled = false;
                        }
                        this.button1.Enabled = true;


                    }
                    if (this.BO.EntityTables[0].Table.Rows[0]["MoneyReachPerson"].ToString() == string.Empty)
                    {
                        this.button3.Text = "提交";



                    }
                    else
                    {
                        foreach (Control item in groupBox3.Controls)
                        {
                            item.Enabled = false;
                        }
                        this.button3.Enabled = true;

                        this.button3.Text = "收回";



                    }
                    if (this.BO.EntityTables[0].Table.Rows[0]["ReviewerID"].ToString() == string.Empty)
                    {
                        this.button2.Text = "提交";



                    }
                    else
                    {
                        foreach (Control item in groupBox1.Controls)
                        {
                            item.Enabled = false;
                        }
                        this.button1.Enabled = true;

                        this.button2.Text = "收回";
                        this.toolBarBill1.BtnModify.Visible = false;


                    }
                }

            }



            this.button3.Enabled = true;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
        }

        /// <summary>
        /// 根据状态控制界面上的图标
        /// </summary>
        public override void LoadAfter()
        {
            base.LoadAfter();
          
            RoleController();
           
        }

        void toolBarBill1_OnAfterBaoCancel(object sender, EventArgs e)
        {
            CtrEnable(false);
          
            this.BaoUnDataBinding();
            this.BaoDataBinding();
           
            BO.Init(this.BO.BillId);
        }

        void toolBarBill1_OnBaoExcel(object sender, EventArgs e)
        {
            try
            {
                RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory+"RptTemplet\\报价单.xls");
                ex.SetCellValue(6, 2, this.RepairMissionCode.Text);
                ex.SetCellValue(7, 2, this.Contact.Text);
                ex.SetCellValue(8, 2, this.CustomerName.Text);
                ex.SetCellValue(9, 2, this.InventoryName.Text);


                decimal money1 = 0;
                decimal.TryParse(this.RepairCost.Text == string.Empty ? "0" : this.RepairCost.Text, out money1);
                decimal money2 = 0;
                decimal.TryParse(this.TravelCost.Text == string.Empty ? "0" : this.TravelCost.Text,out money2);
                decimal money3 = 0;
                decimal.TryParse(this.BO.EntityTables[1].Table.Compute("sum(money)", string.Empty).ToString(),out money3);

                ex.SetCellValue(12, 2, money1+money2+money3);
                ex.SetCellValue(13, 2, this.RepairCost.Text);
                ex.SetCellValue(14, 2, this.TravelCost.Text);
                ex.SetCellValue(15, 2, money3 );




                int k = this.BO.EntityTables[1].Table.Rows.Count;
                if (this.BO.EntityTables[1].Table.Rows.Count > 0)
                {
                    for (int i = 0; i < this.BO.EntityTables[1].Table.Rows.Count; i++)
                    {
                        ex.InsertRow(18 + i, 1);
                        ex.SetCellValue(18 + i, 1, this.BO.EntityTables[1].Table.Rows[i]["InventoryName"]);
                        ex.SetCellValue(18 + i, 2, this.BO.EntityTables[1].Table.Rows[i]["InventoryEngName"]);
                        ex.SetCellValue(18 + i, 3, this.BO.EntityTables[1].Table.Rows[i]["Type"]);
                        ex.SetCellValue(18 + i, 4, this.BO.EntityTables[1].Table.Rows[i]["Money"]);
                        ex.SetCellValue(18 + i, 5, this.BO.EntityTables[1].Table.Rows[i]["IsReturn"]);

                    }
                }
                ex.SetCellValue(33+k, 4, this.PriceDate.Value);
                ex.SetCellValue(38+k, 2, this.TaxRegistrationNumber.Text);
                ex.SetCellValue(39 + k, 2, this.BankName.Text);
                ex.SetCellValue(40 + k, 2, this.Account.Text);


               // ex.SetCellValue(5, 5, this.BO.EntityTables[0].Table.Rows[0]["ReviewDate"].ToString());

                this.saveFileDialog1 = new SaveFileDialog();
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

     

      

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse(MachineCode.CodeValue.ToString());
           this.gridView1.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["cinvcode"].ToString());
 
            this.gridView1.SetRowCellValue(rowid, "InventoryName", e.ReturnRow1["cinvname"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["cInvStd"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["cinvdefine7"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryNum", 1);
        }

        void InventoryName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            //this.InventoryCode.BaoBtnCaption = e.ReturnRow1["cinvcode"].ToString();
            //this.InventoryName.Text = e.ReturnRow1["cinvname"].ToString();
           
        }
        void toolBarBill1_OnBaoDelLine(object sender, EventArgs e)
        {
            this.gridView1.DeleteSelectedRows();
            this.gridView1.RefreshData();
        }

        void toolBarBill1_OnBaoAddLine(object sender, EventArgs e)
        {
            BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, null, null, 0, null);
            this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }

        void RepairMissionCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.RepairMissionCode.BaoBtnCaption = e.ReturnRow1["RepairMissionCode"].ToString();
           
            this.CustomerName.Text = e.ReturnRow1["CustomerName"].ToString();

            this.PaymentUnit.Text = e.ReturnRow1["CustomerName"].ToString();

            this.FaxNumber.Text = e.ReturnRow1["FaxNumber"].ToString();

            this.InventoryCode.Text = e.ReturnRow1["jqjbcode"].ToString();  //e.ReturnRow1["MachineCode"].ToString();

            this.InventoryName.Text = e.ReturnRow1["machineModel"].ToString();//e.ReturnRow1["MachineName"].ToString();

            this.RepairMissionID.Text = e.ReturnRow1["RepairMissionID"].ToString();

            this.BO.TempId = e.ReturnRow1["RepairMissionID"].ToString();

            //如果是在报价列表打开后，再点修改，选择其他维修单号，这个不清空
            this.PriceVouchCode.Text = string.Empty;
        }

     

        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion


        public override void BaoDataBinding()
        {
            base.BaoDataBinding();
            this.RepairMissionCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "RepairMissionCode");
            this.RepairMissionID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairMissionID");
            this.PriceVouchCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PriceCode");
            this.CustomerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerName");
            this.ApplicationPerson.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ApplicationPerson");
            this.PriceDate.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PriceDate");
            this.Contact.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "Contact");
            this.InventoryCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "InventoryCode");
            this.InventoryName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "InventoryName");
            this.Remarks.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "Remarks");
            this.RepairCost.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairCost");
            this.TravelCost.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "TravelCost");
            this.PaymentUnit.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PaymentUnit");
            this.TaxRegistrationNumber.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "TaxRegistrationNumber");
            this.Account.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "Account");
            this.BankName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BankName");
            this.MoneyReachDate.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "MoneyReachDate");
            this.RemarksForReview.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RemarksForReview");
            this.FaxNumber.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "FaxNumber");
            this.gridControl1.DataSource = this.BO.EntityTables[1].Table;
     
          
        }

        public override void BaoUnDataBinding()
        {
            foreach (Control item in groupBox1.Controls)
            {
                item.DataBindings.Clear();
            }

            foreach (Control item in groupBox2.Controls)
            {
                item.DataBindings.Clear();
            }
            this.MoneyReachDate.DataBindings.Clear();
            gridControl1.DataBindings.Clear();
            gridControl1.DataSource = null;

            this.InventoryCode.DataBindings.Clear();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        public override void UpdateButtonBefor()
        {
            
            base.UpdateButtonBefor();
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'");
            if (dt.Rows[0]["ReviewerID"].ToString() == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception("已经提交，不可修改");

                //System.Windows.Forms.MessageBox.Show("已经提交，不可修改");
                //return;
            }
        }

        public override void UpdateButtonAfter()
        {
            base.UpdateButtonAfter();

           
            this.RoleController();

            this.StateControl();

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'");
            //如果工程师未提交，则增行，删行按钮可用
            if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                this.toolBarBill1.BtnAddRow.Enabled = true;
                this.toolBarBill1.BtnDeleteRow.Enabled = true;
            }
            else
            {
                this.toolBarBill1.BtnAddRow.Enabled = false;
                this.toolBarBill1.BtnDeleteRow.Enabled = false;
            }

      

         
        }
        public void RoleController()
        {
            this.toolBarBill1.BtnAddNew.Visible = false;
            this.toolBarBill1.BtnDelete.Visible = false;
            this.toolBarBill1.BtnAddRow.Visible = false;
            this.toolBarBill1.BtnDeleteRow.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            foreach (Control item in groupBox2.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBox1.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBox3.Controls)
            {
                item.Enabled = false;

            }
            //800客服
            if (BaseInfo.userRole.Contains("001"))
            {
                this.button2.Visible = true;
                this.button3.Visible = true;
                if (toolBarBill1.BtnModify.Enabled == false)
                {
                    foreach (Control item in groupBox2.Controls)
                    {
                        item.Enabled = true;
                    }
                    foreach (Control item in groupBox3.Controls)
                    {
                        item.Enabled = true;
                    }
                }
            }
            if (BaseInfo.userRole.Contains("003"))
            {

                this.button1.Visible = true;
                this.toolBarBill1.BtnAddNew.Visible = true;
                this.toolBarBill1.BtnDelete.Visible = true;
                this.toolBarBill1.BtnAddRow.Visible = true;
                this.toolBarBill1.BtnDeleteRow.Visible = true;
                if (toolBarBill1.BtnModify.Enabled == false)
                {
                    foreach (Control item in groupBox1.Controls)
                    {
                        item.Enabled = true;
                    }
                 
                }
            }
            this.button3.Enabled = true;
            this.button1.Enabled = true;
            this.button2.Enabled = true;



            
         
           
           
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

                        if (hInfo.Column.FieldName == "InventoryName" || hInfo.Column.FieldName == "InventoryStd" || hInfo.Column.FieldName == "InventoryEngName" || hInfo.Column.FieldName == "InventoryCode")
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

    

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }
            DataTable dt  = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'");
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
            if (this.button2.Text == "提交")
            {
                //是否已经提交
                if (dt.Rows[0]["MoneyReachPerson"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("该单据是可能是处在已传真未提交状态，请先提交已传真状态");
                    return;
                }
                //是否被收回，被收回了，就提交不了了
                //if (this.TaxRegistrationNumber.Text == string.Empty || this.BankName.Text == string.Empty || this.Account.Text == string.Empty)
                //{
                //    System.Windows.Forms.MessageBox.Show("回执信息未填写完整不能提交");
                //    return;
                //}

                 //免费申请已经通过，则无法提交回执
                if (RiLiGlobal.RiLiDataAcc.ExecuteScalar("select ispass from freeapplication where [RepairMissionCode] = '" + this.RepairMissionCode.Text + "'") == "同意")
                {
                    System.Windows.Forms.MessageBox.Show("免费申请已经通过，无法提交回执");
                    return;
                }
                

                //this.BO.EntityTables[0].Table.Rows[0]["ReviewerID"] = UFBaseLib.BusLib.BaseInfo.DBUserID;

                //this.BO.EntityTables[0].Table.Rows[0]["ReviewDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();

                //this.BO.EntityTables[0].Table.Rows[0]["State"] = "已经回执";
                //this.BO.UpdateSave();



                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set ReviewerID ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',ReviewDate =getdate(),State = '已经回执' where  PriceID = '" + this.BO.BillId + "'");
                foreach (Control item in groupBox2.Controls)
                {
                    item.Enabled = false;

                }


                System.Windows.Forms.MessageBox.Show("提交成功");

                CMessage.SendMessage("回执单已经填写", "800客服已经填写了回执单", this.BO.EntityTables[0].Table.Rows[0]["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId);
                this.button2.Enabled = true;
                this.button2.Text = "收回";
                this.toolBarBill1.BtnModify.Visible = false;
            }
            else if (this.button2.Text == "收回")
            {
                //收回条件：没有开票
                string PriceID = dt.Rows[0]["PriceID"].ToString();

                string ErrMsg = string.Empty;

                //特殊情况，有可能这个报价单，状态已经被免费申请给重置了，这个时候，就提示，然后做刷新界面操作
                if (dt.Rows[0]["ReviewerID"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("本次操作失败，单据不是最新状态，可能原因是被免费申请重置,将自动刷新界面");
                    string id = this.BO.BillId;
                    Repair.Price ff = new Price(id);
                    ff.MdiParent = this.MdiParent;

                    this.Hide();

                    ff.Show();

                    this.Close();
          
                }


                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Bill where [PriceID] = '" + PriceID + "'").Rows.Count > 0)
                {
                    ErrMsg += "[已经填写发票，不能收回]";
                }
                if (ErrMsg == string.Empty)
                {
                   // this.BO.EntityTables[0].Table.Rows[0]["ReviewerID"] = null;
                   // this.BO.EntityTables[0].Table.Rows[0]["ReviewDate"] = DBNull.Value;

                   // this.BO.EntityTables[0].Table.Rows[0]["State"] = "已传真";
                   // this.BO.EntityTables[0].Table.Rows[0]["TaxRegistrationNumber"] = null;
                   // this.BO.EntityTables[0].Table.Rows[0]["RemarksForReview"] = null;
                   //// this.BO.EntityTables[0].Table.Rows[0]["ReviewDate"] = null;
                   // this.BO.EntityTables[0].Table.Rows[0]["Account"] = null;
                   // this.BO.EntityTables[0].Table.Rows[0]["BankName"] = null;



                   // this.BO.UpdateSave();




                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set ReviewerID =null,ReviewDate =null,State = '已传真',TaxRegistrationNumber = null,RemarksForReview = null,Account =null,BankName = null where  PriceID = '" + this.BO.BillId + "'");
                    this.button2.Text = "提交";
                    CMessage.SendMessage("回执单已经收回", "800客服已经收回了回执单", this.BO.EntityTables[0].Table.Rows[0]["UserId"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId);
                    this.toolBarBill1.BtnModify.Visible = true;
                    System.Windows.Forms.MessageBox.Show("收回成功");

                }


                else
                {
                    throw new Exception(ErrMsg);
                }
            }
            else
            {
                throw new Exception("本报价单回执被免费申请单作废，无法操作");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            DataTable dt= RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'");

            if (dt.Rows[0]["UserId"].ToString() != UFBaseLib.BusLib.BaseInfo.DBUserID)
            {
                throw new Exception("您没有权限");
            }
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
            if (this.button1.Text == "提交")
            {
                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select 1 from Price where PriceID = '" + this.BO.BillId + "'").Rows.Count == 0)
                    throw new Exception("未保存，不能提交");

                    /*由于注释这里后，会出现修改后，提交变成收回，收回变成提交*/
                    this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                    this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                    //this.BO.EntityTables[0].Table.Rows[0]["State"] = "报价申请";
                    /*********************************************************/

                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set UploadPerson = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',UploadDate = getdate(),State = '报价申请' where  PriceID = '" + this.BO.BillId + "'");

                    //this.BO.UpdateSave();

                   


                    string strManager = CMessage.SendMessageToRoleNoDepartment("请填写回执单和传真报价单", "工程师提交报价单，请检查", "001", UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId);
                    System.Windows.Forms.MessageBox.Show("提交成功,信息发至[" + strManager + "]!");

                    this.button1.Text = "收回";
            }
            else
            {
                if ((dt.Rows[0]["MoneyReachPerson"].ToString() == string.Empty))
                {
                    /*由于注释这里后，会出现修改后，提交变成收回，收回变成提交*/
                    this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] = DBNull.Value;
                    //this.BO.EntityTables[0].Table.Rows[0]["State"] = "新报价";
                    /*********************************************************/
                    //this.BO.UpdateSave();


                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set UploadPerson =null,UploadDate = null,State = '新报价' where  PriceID = '" + this.BO.BillId + "'");

                    


                    string strManager = CMessage.SendMessageToRoleNoDepartment("报价单被收回", "工程师收回了报价单，请检查", "001", UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId);
                    System.Windows.Forms.MessageBox.Show("收回成功,信息发至[" + strManager + "]!");

                    this.toolBarBill1.BtnModify.Visible = true;

                    this.button1.Text = "提交";

                }
                else
                {
                    throw new Exception("800已经提交报价单传真状态，不能收回");
                }
            }

           

           
        }

        private void toolBarBill1_Load(object sender, EventArgs e)
        {
            if (UFBaseLib.BusLib.BaseInfo.DBUserID != "demo")
                return;

            this.toolBarBill1.Enabled = true;
            this.toolBarBill1.BtnExcel.Enabled = true;

            this.toolBarBill1.BtnAudit.Enabled = false;
            this.toolBarBill1.BtnAddNew.Enabled = false;
            this.toolBarBill1.BtnAddRow.Enabled = false;
            this.toolBarBill1.BtnAuditList.Enabled = false;
            this.toolBarBill1.BtnCancel.Enabled = false;
            this.toolBarBill1.BtnDeleteRow.Enabled = false;
            this.toolBarBill1.BtnLocation.Enabled = false;
            this.toolBarBill1.BtnModify.Enabled = false;
            this.toolBarBill1.BtnSave.Enabled = false;
            this.toolBarBill1.BtnPrint.Enabled = false;
            this.toolBarBill1.BtnUnAudit.Enabled = false;
            this.toolBarBill1.BtnDelete.Enabled = false;
            this.toolBarBill1.btnEnd.Enabled = false;
            this.toolBarBill1.btnFirst.Enabled = false;
            this.toolBarBill1.BtnLocation.Enabled = false;
            this.toolBarBill1.btnNext.Enabled = false;
            this.toolBarBill1.btnPreview.Enabled = false;
            this.toolBarBill1.BtnRefresh.Enabled = false;
            this.toolBarBill1.BtnUnUpLoad.Enabled = false;
            this.toolBarBill1.BtnUpLoad.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {
                throw new Exception("请先保存再做操作");
            }
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'");

            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
            if (this.button3.Text == "提交")
            {
                if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Price where PriceID = '" + this.BO.BillId + "'").Rows.Count == 0)
                    throw new Exception("未保存，不能提交");

                //是否已经提交
                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("该单据，未提交，或被工程师收回，无法提交报价单");
                    return;
                }
                this.BO.EntityTables[0].Table.Rows[0]["MoneyReachPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                this.BO.EntityTables[0].Table.Rows[0]["MoneyReachDate"] = RiLiGlobal.RiLiDataAcc.GetNow();
                this.BO.EntityTables[0].Table.Rows[0]["State"] = "已传真";



                //this.BO.UpdateSave();


                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set MoneyReachPerson ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',MoneyReachDate =getdate(),State = '已传真' where  PriceID = '" + this.BO.BillId + "'");

               this.MoneyReachDate.Text = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");

                System.Windows.Forms.MessageBox.Show("提交成功");


                CMessage.SendMessage("报价单已经已传真", "本张报价单已经已传真", dt.Rows[0]["UploadPerson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId);

                this.button3.Text = "收回";
            }
            else
            {
                if (dt.Rows[0]["ReviewerID"].ToString() == string.Empty)
                {

                    this.BO.EntityTables[0].Table.Rows[0]["MoneyReachPerson"] = null;
                    this.BO.EntityTables[0].Table.Rows[0]["MoneyReachDate"] = DBNull.Value;
                    this.BO.EntityTables[0].Table.Rows[0]["State"] = "报价申请";

                    //this.BO.UpdateSave();

                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update Price set MoneyReachPerson =null,MoneyReachDate =null,State = '报价申请' where  PriceID = '" + this.BO.BillId + "'");
                    System.Windows.Forms.MessageBox.Show("收回成功");


                    CMessage.SendMessage("报价单已经已传真状态被收回", "本张报价单已经已传真状态被收回", dt.Rows[0]["UploadPerson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Pri001", this.BO.BillId); ;

                    this.button3.Text = "提交";

                }
                else
                {
                    throw new Exception("回执已经被800填写，不能收回");
                }
            }

        }

        private void RemarksForReview_MouseMove(object sender, MouseEventArgs e)
        {
            this.RemarksForReview.Enabled = true;
            this.RemarksForReview.ReadOnly = false;
        }

        private void RemarksForReview_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void Remarks_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.ShowAlways = true;

            tt.Show(((Control)sender).Text, ((Control)sender));
        }

        private void Remarks_TextChanged(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.ShowAlways = true;

            tt.Show(((Control)sender).Text, ((Control)sender));
        }

        private void Remarks_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
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

                tt.Show(Remarks.Text, Remarks);
            }
        }
    }
}
