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
using DevExpress.XtraEditors.Repository;
using Bao.Message;

namespace Repair
{
    public partial class PartsInentory :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {
        private FrmLookUp.RiliButtonEdit MachineCode = new FrmLookUp.RiliButtonEdit();


        private FrmLookUp.RiliButtonEdit ReturnMachineCode = new FrmLookUp.RiliButtonEdit();


        private FrmLookUp.ButtonEdit WareHouseSelect = new FrmLookUp.ButtonEdit();



        public PartsInentory()
        {
         
            InitializeComponent();
            this.BO = new Repair.PartsInventoryBill();
            BO.Init("");
            init();
            IsMyBill();
           
        }


       

        public PartsInentory(string id)
        {

            InitializeComponent();
            this.BO = new Repair.PartsInventoryBill();
            BO.Init(id);
            init();
            IsMyBill();
        }


        public  void IsMyBill()
        {
            //不是助理或者800，界面将禁止
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
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

        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            IsEndCheck(); 
            this.gridView2.CloseEditor();
            this.gridView2.UpdateCurrentRow();

            this.gridView3.CloseEditor();
            this.gridView3.UpdateCurrentRow();

            base.toolBarBill1_OnBaoSave(sender, e);


        }


        public override void UpdateButtonAfter()
        {
            base.UpdateButtonAfter();
            this.RepairMissionCode.Enabled = false;
        }

        

        private void init()
        {
            //GridView高亮




            RepairMissionCode.BaoSQL = "select PartsApplicationCode,RepairMissionCode,CustomerName,CustomerCode,ApplicationPersonName,* from PartsApplication where (AuditName is not null and AuditName<>'') and PartsApplicationID not in (select PartsApplicationID from PartsInventory)";
            RepairMissionCode.BaoTitleNames = "PartsApplicationCode=配件申请单号,RepairMissionCode=维修任务编码,CustomerName=客户名称,CustomerCode=客户编码,ApplicationPersonName=申请人";
            this.RepairMissionCode.FrmHigth = 350;
            this.RepairMissionCode.FrmWidth = 650;
            RepairMissionCode.DecideSql = "select RepairMissionCode,CustomerName,CustomerCode,ApplicationPersonName,* from PartsApplication where RepairMissionCode =";
            RepairMissionCode.BaoColumnsWidth = "PartsApplicationCode=120,RepairMissionCode=120,CustomerName=150,CustomerCode=150,ApplicationPersonName=100";
            RepairMissionCode.BaoClickClose = true;
            RepairMissionCode.OnLookUpClosed +=new FrmLookUp.RiliButtonEdit.LookUpClosed(RepairMissionCode_OnLookUpClosed);


            WareHouseSelect.BaoSQL = "select * from " + U8DataAcc.DataBase + ".warehouse";


            WareHouseSelect.BaoTitleNames = "cwhname=仓库名称,cwhcode=仓库编码";
            this.WareHouseSelect.FrmHigth = 800;
            this.WareHouseSelect.FrmWidth = 800;
            WareHouseSelect.DecideSql = "select * from " + U8DataAcc.DataBase + ".warehouse where cwhcode =";
            WareHouseSelect.BaoColumnsWidth = "cwhname=150,cwhcode=150";
            WareHouseSelect.BaoClickClose = true;



            WareHouseSelect.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(WareHouseSelect_OnLookUpClosed);

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

            if (this.BO.BillId == string.Empty)
            {

            }
            else
            {
                string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateInOut] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");

                if (state == "出库完成")
                {
                    this.gridView2.OptionsBehavior.Editable = false;
                }
                else
                {
                    this.gridView2.OptionsBehavior.Editable = true ;
                }

                string state2 = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateReturn] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");

                if (state2 == "归还完成")
                {
                    this.gridView3.OptionsBehavior.Editable = false;
                }
                else
                {
                    this.gridView3.OptionsBehavior.Editable = true;
                }
            }

           

           


            this.toolBarBill1.OnBaoAddLine += new FrmLookUp.ToolBarBill.BaoAddLine(toolBarBill1_OnBaoAddLine);
            this.toolBarBill1.OnBaoDelLine += new FrmLookUp.ToolBarBill.BaoDelLine(toolBarBill1_OnBaoDelLine);
            this.toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(toolBarBill1_OnBaoDelete);

            //现品不良、未使用、不良品
            DataTable dt = new DataTable();
            dt.Columns.Add("state");

     

            this.repositoryItemComboBox1.Items.Add("现品不良");
            this.repositoryItemComboBox1.Items.Add("未使用");
            this.repositoryItemComboBox1.Items.Add("不良品");

            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.gridControl1.Enabled = false;
            this.CustomerCode.Enabled = false;
            this.CustomerName.Enabled = false;


            if (!(BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() == string.Empty))
            {

                this.RepairMissionCode.BaoBtnCaption = BO.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();
                this.CustomerCode.Text = BO.EntityTables[0].Table.Rows[0]["CustomerCode"].ToString();
                this.CustomerName.Text = BO.EntityTables[0].Table.Rows[0]["CustomerName"].ToString();
                this.BillID.Text = BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString();
                this.CustomerCode.Enabled = false;
                this.CustomerName.Enabled = false;
                this.RepairMissionCode.Enabled = false;
                
                this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplicationDetails where PartsApplicationID = '" + BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() + "'");
                this.gridControl2.DataSource = BO.EntityTables[1].Table;
                this.gridControl3.DataSource = BO.EntityTables[2].Table;




                MachineCode.BaoSQL = "select InventoryCode,InventoryName,InventoryStd,iquantity,InventoryEngName  from PartsApplicationDetails where PartsApplicationID = '" + this.BillID.Text + "'";
                MachineCode.BaoTitleNames = "InventoryCode=存货编码,InventoryName=存货名称,InventoryStd=存货名称,iquantity = 数量,InventoryEngName = 英文名称";
                this.MachineCode.FrmHigth = 400;
                this.MachineCode.FrmWidth = 600;
                MachineCode.DecideSql = "select InventoryCode,InventoryName,InventoryStd,iquantity,InventoryEngName  from PartsApplicationDetails where PartsApplicationID = '" + this.BillID.Text + "' and InventoryCode = ";
                MachineCode.BaoColumnsWidth = "InventoryCode=100,InventoryName=100,InventoryStd=100,iquantity=100,InventoryEngName=100";
                MachineCode.BaoClickClose = true;

                MachineCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);

             

               // this.BO.TempId = BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString();

            }


         

        }

        void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = null;
        }

        void WareHouseSelect_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse(WareHouseSelect.CodeValue.ToString());




            this.gridView2.SetRowCellValue(rowid, "Warehouse", e.ReturnRow1["cwhname"].ToString());
            
        }

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse( MachineCode.CodeValue.ToString());

            if (MachineCode.Text == "gridView2")
            {

                
                this.gridView2.SetRowCellValue(rowid, "PartType", e.ReturnRow1["InventoryName"].ToString());
                this.gridView2.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["InventoryStd"].ToString());
                this.gridView2.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["InventoryCode"].ToString());
                this.gridView2.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["InventoryEngName"].ToString());
            }
            else
            {

                this.gridView3.SetRowCellValue(rowid, "PartType", e.ReturnRow1["InventoryName"].ToString());
                this.gridView3.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["InventoryStd"].ToString());
                this.gridView3.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["InventoryCode"].ToString());
                this.gridView3.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["InventoryEngName"].ToString());
            }
        }

        void toolBarBill1_OnBaoDelLine(object sender, EventArgs e)
        {
           
        }

        void toolBarBill1_OnBaoAddLine(object sender, EventArgs e)
        {
            BO.EntityTables[1].Table.Rows.Add(BO.BillId, Guid.NewGuid().ToString(),  null, null, 0, null, null);
            this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }


        void RepairMissionCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.RepairMissionCode.BaoBtnCaption = e.ReturnRow1["RepairMissionCode"].ToString();
            this.CustomerCode.Text = e.ReturnRow1["CustomerCode"].ToString();
            this.CustomerName.Text = e.ReturnRow1["CustomerName"].ToString();
            this.BillID.Text = e.ReturnRow1["PartsApplicationID"].ToString();
            this.CustomerCode.Enabled = false;
            this.CustomerName.Enabled = false;


            DataTable dt =  RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplicationDetails where PartsApplicationID = '" + e.ReturnRow1["PartsApplicationID"].ToString() + "'");

            this.gridControl1.DataSource = dt;

            //foreach (DataRow item in dt.Rows)
            //{
            //    BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, item["InventoryName"].ToString(), null, null, null, null, null, null);
            //    this.gridControl2.DataSource = BO.EntityTables[1].Table;
            //}


            //foreach (DataRow item in dt.Rows)
            //{
            //    BO.EntityTables[2].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, item["InventoryName"].ToString(), null, null, null, null, null, null);
            //    this.gridControl3.DataSource = BO.EntityTables[2].Table;
            //}
       
          
          

         //   BO.EntityTables[0].Table.Rows[0]["RepairMissionID"] = this.RepairMissionID;


            MachineCode.BaoSQL = "select InventoryCode,InventoryName,InventoryStd,iquantity,InventoryEngName  from PartsApplicationDetails where PartsApplicationID = '" + this.BillID.Text + "'";
            MachineCode.BaoTitleNames = "InventoryCode=存货编码,InventoryName=存货名称,InventoryStd=存货名称,iquantity=数量,InventoryEngName = 英文名称";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 600;
            MachineCode.DecideSql = "select InventoryCode,InventoryName,InventoryStd,iquantity,InventoryEngName  from PartsApplicationDetails where PartsApplicationID = '" + this.BillID.Text + "' and InventoryCode = ";
            MachineCode.BaoColumnsWidth = "InventoryCode=100,InventoryName=100,InventoryStd=100,iquantity=100,InventoryEngName=100";
            MachineCode.BaoClickClose = true;

            MachineCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);


            this.gridControl2.DataSource = null;
            this.gridControl3.DataSource = null;

            this.BO.TempId = e.ReturnRow1["PartsApplicationID"].ToString();


        

           

         

         
        }


       

        public override void NewButtonBefor()
        {
            base.NewButtonBefor();

            BO.BillId = Guid.NewGuid().ToString();

            this.RepairMissionCode.Enabled = true;
        }


        public override void BaoDataBinding()
        {
            base.BaoDataBinding();

            this.RepairMissionCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "RepairMissionCode");
            this.CustomerCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerCode");
            this.CustomerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CustomerName");
            this.BillID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PartsApplicationID");

            this.gridControl2.DataSource = this.BO.EntityTables[1].Table;

            this.gridControl3.DataSource = this.BO.EntityTables[2].Table;

            
          

        
          


            
        }

      

        public override void BaoUnDataBinding()
        {
            base.BaoUnDataBinding();
            base.BaoDataBinding();

            this.RepairMissionCode.DataBindings.Clear();
            this.CustomerCode.DataBindings.Clear();
            this.CustomerName.DataBindings.Clear();

            this.BillID.DataBindings.Clear();
         

         

            this.gridControl1.DataBindings.Clear();
            this.gridControl2.DataBindings.Clear();
            this.gridControl3.DataBindings.Clear();

        
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
            

            if(gv.Name == "gridView2")
            {
                        if (!(this.BO.BillId == string.Empty))
                            {
                                string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateInOut] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");

                                if (state == "出库完成")
                                {
                                    return;
                                }
                            }
            }
            else
            {
                if (!(this.BO.BillId == string.Empty))
                {
                    string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateReturn] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");

                    if (state == "归还完成")
                    {
                        return;
                    }
                }
            }
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gv.CalcHitInfo(new Point(e.X, e.Y));
            if (((e.Button & MouseButtons.Left) != 0) && (hInfo.InRow) && (!gv.IsGroupRow(hInfo.RowHandle)) && (!gv.IsFilterRow(hInfo.RowHandle)))
            {
                if (hInfo.InRowCell)
                {
                    //判断光标是否在行范围内
                    if (this.toolBarBill1.BtnModify.Enabled == false)
                    {
                     
                        if (hInfo.Column.FieldName == "InventoryCode" || hInfo.Column.FieldName == "InventoryStd" || hInfo.Column.FieldName == "InventoryEngName")
                        {
                            if (gv.Name == "gridView2")
                            {
                                this.MachineCode.CodeValue = hInfo.RowHandle.ToString();
                                this.MachineCode.Text = gv.Name;

                                this.MachineCode.ShowForm();
                            }
                            else
                            {


                                this.ReturnMachineCode.ShowTable = this.gridControl2.DataSource as DataTable;
                                this.ReturnMachineCode.FrmHigth = 400;
                                this.ReturnMachineCode.FrmWidth = 600;
                                ReturnMachineCode.BaoTitleNames = "InventoryCode=存货编码,InventoryName=存货名称,InventoryStd=存货名称,iquantity=数量,InventoryEngName=英文名称";

                            
                                ReturnMachineCode.BaoColumnsWidth = "InventoryCode=100,InventoryName=100,InventoryStd=100,iquantity=100,InventoryEngName=100";
                                this.ReturnMachineCode.CodeValue = hInfo.RowHandle.ToString();
                                this.ReturnMachineCode.Text = gv.Name;
                       
                                ReturnMachineCode.BaoClickClose = true;
                                ReturnMachineCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(ReturnMachineCode_OnLookUpClosed);



                                this.ReturnMachineCode.ShowForm();

                            }
                        }
                        else if (hInfo.Column.FieldName == "Warehouse")
                        {

                          
                            this.WareHouseSelect.CodeValue = hInfo.RowHandle.ToString();
                            this.WareHouseSelect.Text = gv.Name;

                            this.WareHouseSelect.ShowForm();

                        }
                    }
                  
                }

            }
        }

        void ReturnMachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse(ReturnMachineCode.CodeValue.ToString());
            this.gridView3.SetRowCellValue(rowid, "PartType", e.ReturnRow1["PartType"].ToString());
            this.gridView3.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["InventoryStd"].ToString());
            this.gridView3.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["InventoryCode"].ToString());
            this.gridView3.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["InventoryEngName"].ToString());
        }
        private void gridControl2_MouseDown(object sender, MouseEventArgs e)
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
                     
                        if (hInfo.Column.FieldName == "Warehouse")
                        {
                            this.WareHouseSelect.CodeValue = hInfo.RowHandle.ToString();
                            this.WareHouseSelect.Text = gv.Name;

                            this.WareHouseSelect.ShowForm();

                        }
                    }

                }

            }
        }

        public void IsEndCheck()
        {
          
           

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select RepairMissionCode from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");
            if (dt.Rows.Count == 0)
            {
                return;
            }
            RiLiGlobal.RiLiDataAcc.IsEnd(dt.Rows[0]["RepairMissionCode"].ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BO.BillId == string.Empty)
            {
                this.BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, null, null, null, null, null, null,null,null);
                this.gridControl2.DataSource = BO.EntityTables[1].Table;
                return;
            }

            string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateInOut] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");
            if (state == "出库完成")
            {
                System.Windows.Forms.MessageBox.Show("出库完成，不能增行");
            }
            else
            {
                IsEndCheck();
                this.BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, null, null, null, null, null, null, null, null);
                this.gridControl2.DataSource = BO.EntityTables[1].Table;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.BO.BillId == string.Empty)
            {
                BO.EntityTables[2].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, null, null, null, null, null, null, null, null);
                this.gridControl3.DataSource = BO.EntityTables[2].Table;
                return;
            }
            IsEndCheck();
            string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateReturn] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");
       
            if (state == "归还完成")
            {
                System.Windows.Forms.MessageBox.Show("归还完成，不能增行");
            }
            else
            {
                BO.EntityTables[2].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, null, null, null, null, null, null, null, null);
                this.gridControl3.DataSource = BO.EntityTables[2].Table;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BO.BillId == string.Empty)
            {
                this.gridView2.DeleteSelectedRows();
                return;
            }
            string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateReturn] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");
            IsEndCheck();
            if (state == "出库完成")
            {
                System.Windows.Forms.MessageBox.Show("出库完成，不能删行");
            }
            else
            {
                this.gridView2.DeleteSelectedRows();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.BO.BillId == string.Empty)
            {
                this.gridView3.DeleteSelectedRows();
                return;
            }
            IsEndCheck();
            string state = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select [StateReturn] from PartsInventory where PartsInventoryID = '" + this.BO.BillId + "'");

          
            if (state == "归还完成")
            {
                System.Windows.Forms.MessageBox.Show("归还完成，不能删行");
            }
            else
            {
                this.gridView3.DeleteSelectedRows();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (this.toolBarBill1.BtnModify.Enabled == false)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再操作");
                return;
            }
            IsEndCheck();

            //如果已经归还确认，则
           // 4848

        

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select StateReturn from PartsInventory  where PartsInventoryID = '" + this.BO.BillId + "'") == "归还完成")
            {
                System.Windows.Forms.MessageBox.Show("已经归还完成，不能取消");
                return;
            }

          

            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update PartsInventory set StateInOut = '出库中',StateInOutDate = null where PartsInventoryID = '" + this.BO.BillId + "'");

            System.Windows.Forms.MessageBox.Show("出库中");

            string appeng = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ApplicationPersonCode from PartsApplication where PartsApplicationID = '" + this.BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() + "'");

            this.gridView2.OptionsBehavior.Editable = true;

            CMessage.SendMessage("配件出入库", "出库中", appeng, UFBaseLib.BusLib.BaseInfo.UserId, "Pin001", this.BO.BillId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnModify.Enabled == false)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再操作");
                return;
            }
            IsEndCheck();

            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update PartsInventory set StateInOut = '出库完成',StateInOutDate = getdate() where PartsInventoryID = '" + this.BO.BillId + "'");

            System.Windows.Forms.MessageBox.Show("出库完成");

            this.gridView2.OptionsBehavior.Editable = false;


            string appeng = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ApplicationPersonCode from PartsApplication where PartsApplicationID = '" + this.BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() + "'");

            CMessage.SendMessage("配件出入库", "出库完成", appeng, UFBaseLib.BusLib.BaseInfo.UserId, "Pin001", this.BO.BillId);
        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (this.toolBarBill1.BtnModify.Enabled == false)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再操作");
                return;
            }
            IsEndCheck();

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select StateInOut from PartsInventory  where PartsInventoryID = '" + this.BO.BillId + "'") == "出库完成")
            {
                

                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update PartsInventory set StateReturn = '归还完成',StateReturnDate = getdate() where PartsInventoryID = '" + this.BO.BillId + "'");

                System.Windows.Forms.MessageBox.Show("归还完成");

                this.gridView3.OptionsBehavior.Editable = false;


                string appeng = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ApplicationPersonCode from PartsApplication where PartsApplicationID = '" + this.BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() + "'");

                CMessage.SendMessage("配件出入库", "归还完成", appeng, UFBaseLib.BusLib.BaseInfo.UserId, "Pin001", this.BO.BillId);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("状态为出库中，不能做归还完成操作");
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnModify.Enabled == false)
            {
                System.Windows.Forms.MessageBox.Show("请先保存再操作");
                return;
            }
            IsEndCheck();
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("update PartsInventory set StateReturn = '归还中',StateReturnDate = null where PartsInventoryID = '" + this.BO.BillId + "'");

            System.Windows.Forms.MessageBox.Show("归还中");

            this.gridView3.OptionsBehavior.Editable = true;

            string appeng = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ApplicationPersonCode from PartsApplication where PartsApplicationID = '" + this.BO.EntityTables[0].Table.Rows[0]["PartsApplicationID"].ToString() + "'");

            CMessage.SendMessage("配件出入库", "归还中", appeng, UFBaseLib.BusLib.BaseInfo.UserId, "Pin001", this.BO.BillId);
        }
        private ToolTip tt;
        private ToolTip tt2;
        private void PartsInentory_KeyDown(object sender, KeyEventArgs e)
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
                string dd1 = string.Empty;
                foreach (DataRow item in this.BO.EntityTables[1].Table.Rows)
                {
                    dd1 = dd1 + "----" + item["Remarks"].ToString();
                }

                tt.Show(dd1, gridControl2);


                if (tt2 != null)
                {
                    tt2.Dispose();


                }
             
                tt2 = new ToolTip();
                tt2.ShowAlways = true;
                string dd2 = string.Empty;
                foreach (DataRow item in this.BO.EntityTables[1].Table.Rows)
                {
                    dd2 = dd2 + "----" + item["Remarks"].ToString();
                }

                tt2.Show(dd2, gridControl3);
            }
        }
    }
}
