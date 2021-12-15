using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using FrmLookUp;
using DevExpress.XtraGrid.Views.Grid;
namespace Bao.BillBase
{
    /// <summary>
    /// 该类为单据的界面基类
    /// </summary>
    public partial class FrmBillBase : Bao.FormChildBase,Bao.BillBase.IAudit
    {
		public string BillType;//0：单据,1:交付物

        public string BillId;
        public Bao.BillBase.BillBase BO;
        private Bao.BillBase.Auditing.FrmAuditList AuditList = new Bao.BillBase.Auditing.FrmAuditList();
        public Form AuditBo;
        public FrmBillBase()
        {
            InitializeComponent();
            AuditList.Visible = false;

         
            this.AddOwnedForm(AuditList);
            
        }

        
        public FrmBillBase(string BillId)
        {
            this.BillId = BillId;
        }
        public virtual void IsMyBill(string RepairMissionCode)
        {
            if (RepairMissionCode == null || RepairMissionCode == string.Empty)
            {
                return;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
                string sql = "select * from RepairMission where RepairMissionCode = '" + RepairMissionCode + "' and ( CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' or RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "')";

                if (RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql).Rows.Count == 0)
                {
                    foreach (Control item in this.Controls)
                    {
                        item.Enabled = false;
                    }
                 
                }
            }


        }
        /// <summary>
        /// 显示审核界面
        /// </summary>
        /// <returns></returns>
        //public virtual Form SetAuditObj()
        //{
        //   // return  new Bao.AuditFlow.FrmAuditFenshu(this,BO.FunctionId,BO.EntityId,BO.BillId,UFBaseLib.BusLib.BaseInfo.UserId  );
        //}
        /// <summary>
        /// 验证登陆用户和单据的操作员是否为一个人
        /// </summary>
        public virtual void LoginUserIsCreateUser()
        {
            
        }

        
        /// <summary>
        /// 单击工具条的新增按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            BO.Init("");
            BaoUnDataBinding();
            BaoDataBinding();
            BO.GetCode(this);
            NewButtonBefor();
            BO.Init(BO.BillId);
            BaoUnDataBinding();
            BaoDataBinding();
            CtrEnable(true);
            NewButtonAfter();
        }

         
        /// <summary>
        /// 点击新增按钮前触发
        /// </summary>
        public virtual void NewButtonBefor()
        {
 
        }

        public virtual void NewButtonAfter()
        {
            
        }
        /// <summary>
        /// 点击修改按钮前出发
        /// </summary>
        public virtual void UpdateButtonBefor()
        { }
        /// <summary>
        /// 设置实体对象中的FunctionId的值
        /// </summary>
        /// <param name="mFunctionId"></param>
        public override void SetFunctionId(string mFunctionId)
        {
			if (BillType != "1") {//如果不是表单提交的交付物，则执行该段代码
				BO.FunctionId = mFunctionId;
				BO.TempId = mFunctionId;
			}
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {



            foreach (Bao.BillBase.EntityTable obj in BO.EntityTables)
            {

              
                this.BindingContext[obj.Table].EndCurrentEdit();
                
            }
           
			if (this.BO.BillId == "")
				throw new Exception("没有内容不能保存");

            if (e.Is_Update)
            {   
                
                if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(this.BO.FunctionId, this.BO.BillId, "0"))
                    throw new Exception("该单据已提交，不能修改");
                BO.UpdateSave();
            }
            else
            {
                BO.GetCode(this);
                BO.NewSave();
            }
            
            CtrEnable(false);
            MessageBox.Show("保存成功");
            ///李广华的审批代码
            //产生审批流程的代码调用
            
        }


        #region  表单上的控件是否可编辑
        /// <summary>
        /// 表单上的控件是否可编辑
        /// </summary>
        /// <param name="Flag"></param>
        public  void CtrEnable(Boolean Flag)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(this.Controls[i].Name);
                DG(this.Controls[i], Flag);
            }
            
        }
        private void DG(Control ctl, Boolean Flag)
        {

            if ((ctl.Name == "toolBarBill1") || ((ctl.Tag != null) && (ctl.Tag.ToString().Trim() == "99999")))
            {
                System.Diagnostics.Debug.WriteLine(ctl.Name);
                return;
            }

            
            ///
            else if (ctl is DevExpress.XtraGrid.GridControl)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn Col in ((ColumnView)((DevExpress.XtraGrid.GridControl)ctl).DefaultView).Columns)
                {
                    Col.OptionsColumn.AllowEdit = Flag;
                }
                return;
            }
            else if (ctl.CompanyName == "FrmLookUp")
            {
                ctl.Enabled = Flag;
                return;
            }
         

            else
            {

                if (ctl.Controls.Count == 0)
                {
                    ctl.Enabled = Flag;
                    System.Diagnostics.Debug.WriteLine(ctl.Name);
                }

            }

            for (int i = 0; i < ctl.Controls.Count; i++)
            {
                DG(ctl.Controls[i], Flag);
            }

        }
        #endregion
        /// <summary>
        /// 根据单号显示单据内容
        /// </summary>
        /// <param name="BillId">单号</param>
        public void ShowBill(string BillId)
        {
            this.BO.BillId =BillId;
            this.BO.Init(this.BO.BillId);
            //switch (BO.BillState)
            //{
            //    case 1:
            //        toolBarBill1.BtnAudit.Text = "反审核";
            //        break;
            //    case 0:
            //        toolBarBill1.BtnAudit.Text = "审核";
            //        break;
            //}
            this.BaoUnDataBinding();
            this.BaoDataBinding();
            CtrEnable(false);
        }
        /// <summary>
        /// 点击选择按钮前触发
        /// </summary>
        public virtual void BeforSelect()
        {
 
        }
        /// <summary>
        /// 点击选择按钮后出发
        /// </summary>
        public virtual void AfterSelect()
        {

        }

        private  void toolBarBill1_OnBaoSelect(object sender, FrmLookUp.LookUpEventArgs e)
        {
            BeforSelect();
            ShowBill(e.ReturnRow1[this.BO.KeyFieldName].ToString());
            AfterSelect();
        }

        public virtual void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            //if (Bao.BillBase.Audit.AuditBillManager.IsAuditing(this.BO.FunctionId, this.BO.BillId, "0"))
            //    throw new Exception("该单据正在审批，不能修改");
            UpdateButtonBefor();

            CtrEnable(true);

            UpdateButtonAfter();
        }

        public virtual void UpdateButtonAfter()
        {
            
        }

        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            if (this.BO.BillId == "")
                throw new Exception("没有内容不能删除");
            LoginUserIsCreateUser();
            if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(this.BO.FunctionId, this.BO.BillId, "0"))
                throw new Exception("该单据已提交，不能删除");
            if (MessageBox.Show("确定要删除！", "提示", System.Windows.Forms.MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
                Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
                try
                {
                    BO.Delete();
                    sqlTran.Commit();
                }
                catch (Exception ee)
                {
                    sqlTran.Rollback();
                    throw new Exception("删除失败，原因：" + ee.Message);
                }
                BO.Init("");
                this.BaoUnDataBinding();
                this.BaoDataBinding();
                MessageBox.Show("删除成功。");

            }
        }
        /// <summary>
        /// 将实体对象中的数据绑定到界面的控件中
        /// </summary>
        public virtual void BaoUnDataBinding()
        {

        }
        /// <summary>
        /// 界面控件和实体对象的数据解除绑定关系
        /// </summary>
        public virtual void BaoDataBinding()
        {

        }
        /// <summary>
        /// 选择按钮显示的列表中的中文显示
        /// </summary>
        /// <returns></returns>
        public virtual string BaoSelectLookUpTitleName()
        {
            return "";
        }
        /// <summary>
        /// 选择按钮的SQL语句
        /// </summary>
        /// <returns></returns>
        public virtual string BaoSelectLookUpSQL()
        {
            return "";
        }
        private void FrmBillBase_Load(object sender, EventArgs e)
        {
            this.toolBarBill1.baoBtnSelect.BaoSQL = BaoSelectLookUpSQL();
            this.toolBarBill1.baoBtnSelect.BaoTitleNames = BaoSelectLookUpTitleName();
            BaoUnDataBinding();
            BaoDataBinding();
            CtrEnable(false);
            LoadAfter();    //加载完成后
        }

        public virtual void LoadAfter()
        {

        }

        private void toolBarBill1_OnBaoSetPrintDataset(object sender, EventArgs e)
        {
            toolBarBill1.PrintData.Tables.Clear();
            int i =1;
            foreach (Bao.BillBase.EntityTable obj in BO.EntityTables)
            {
                obj.Table.TableName = "table" + i.ToString();
                toolBarBill1.PrintData.Tables.Add(obj.Table);
                i++;
            }
        }

        private void toolBarBill1_OnBaoUnAudit(object sender, EventArgs e)
        {
            if (this.BO.BillId == "")
                throw new Exception("没有内容不能弃审");
            if (MessageBox.Show("确定弃审？", "提示", System.Windows.Forms.MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                //if (Bao.BillBase.Audit.AuditBillManager.IsAudited(this.BO.FunctionId, this.BO.BillId, "0"))  //所有人审核完成
                //{
                //    SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
                //    Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
                //    try
                //    {
                //        Bao.BillBase.Audit.AuditBillManager.ModifyAuditFlowLineForAuditFlag(this.BO.BillId, this.BO.FunctionId, "2", "0");
                //        this.BO.UnAudit();            //修改该单据的审核标记，并进行审核前或审核后处理
                //        this.BO.Rating(0);
                //        sqlTran.Commit();
                //        MessageBox.Show("弃审成功。");
                //    }
                //    catch (Exception ee)
                //    {
                //        sqlTran.Rollback();
                //        throw new Exception("弃审失败，原因：" + ee.Message);
                //    }

               
                UnAudit();
                }
                else
                {
                   // MessageBox.Show("弃审功能只能在该单据审批流程完成后才能进行。");
                return;
                }
            
        }

        public virtual void UnAudit()
        {
            this.BO.UnAudit();
        }

		private void toolBarBill1_OnBaoAudit(object sender, EventArgs e) {
			if (this.BO.BillId == "")
				throw new Exception("没有内容不能审核");
			///李广华增加的审核代码 

            //string message = "";
            ////判断是否有权利审核
            //bool isPass = Bao.BillBase.Audit.AuditManager.AuditBill(this.BO.BillId, this.BO.FunctionId, UFBaseLib.BusLib.BaseInfo.UserId, "0", out message);
            //if (isPass) {
            //    int auditNum = Bao.BillBase.Audit.AuditBillManager.GetMaxAuditNumByFunctionId(this.BO.BillId, this.BO.FunctionId, "0");
            //    DataTable auditLineTable = Bao.BillBase.Audit.AuditBillManager.GetAuditFlowLineByBillIdAndFunctionIdAndAuditUserName(this.BO.BillId, this.BO.FunctionId, UFBaseLib.BusLib.BaseInfo.UserId, auditNum, "0");

            //    Bao.BillBase.Audit.FrmBillAudit fba = new Bao.BillBase.Audit.FrmBillAudit(this.BO, UFBaseLib.BusLib.BaseInfo.UserId,this.Text.Trim());
            //    DataTable dd = Bao.DataAccess.DataAcc.ExecuteQuery("select * from ScoreAudit where FunctionId='" + this.BO.FunctionId + "' and AuditNode='" + auditLineTable.Rows[0]["AuditNodeId"].ToString().Trim() + "'");
            //    if (dd.Rows.Count > 0)
            //    {
            //        fba.ScorePanel.Visible = true;
            //        if (dd.Rows[0]["FunctionId"].ToString().Trim() == "D011")
            //        {
            //            fba.baoBtnpLevel.Visible = true;

            //            fba.baoBtnpLevel.BaoSQL = "select * from dbo.PFLevel";
            //            fba.baoBtnpLevel.BaoTitleNames = "levelId=编号;levelName=名称";
            //            fba.textBox1.ReadOnly  = true;
            //            //fba.txtFee.Minimum = 0;
            //            //double  aa = 0.1;
            //            //fba.txtFee.Increment = Decimal.Parse( aa.ToString());
            //        }
            //        else
            //        {
            //            fba.baoBtnpLevel.Visible = false;
            //            fba.textBox1.ReadOnly = false;
            //            //fba.txtFee.Maximum = 3;
            //            //fba.txtFee.Minimum = 0;
            //            //fba.txtFee.Increment = 1;
            //        }
            //    }
            //    fba.ShowDialog();
            //}else{
            //        MessageBox.Show(message, "审核操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //}

            Audit();
		}

        
        #region IAudit 成员

        public virtual void  Audit()
        {
            BO.Audit();
        }

        #endregion



        private void toolBarBill1_OnBaoExit(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// XGrid控件的黏贴数据方法
        /// </summary>
        /// <param name="gridView"></param>
        public  void PastGridFieldValue(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {

            string FocusedColumnFieldName = gridView.FocusedColumn.FieldName;

            ////
            int[] aa = gridView.GetSelectedRows();

            for (int i = 0; i < aa.Length; i++)
            {

                ((System.Data.DataTable)(gridView.GridControl.DataSource)).Rows[aa[i]][FocusedColumnFieldName] = gridView.FocusedValue;

            }
        }
        
        private void toolBarBill1_OnBaoUpLoad(object sender, EventArgs e)
        {
            if (this.BO.BillId == "")
                throw new Exception("没有内容不能提交");
            LoginUserIsCreateUser();
            try
            {
                SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
                Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
                try
                {
                    this.BO.UpLoadBefor();
					if (BillType == "1") {
						Bao.BillBase.Audit.AuditManager.AddFlowDefineToFlowLine(GetPlanId(), this.BO.BillId, this.BO.FunctionId, "0");
					} else {
						Bao.BillBase.Audit.AuditManager.AddFlowDefineToFlowLine(this.BO.BillId, this.BO.FunctionId, "0");
					}
                    this.BO.UpLoadAfter();
                    ///给第一个审核人员发送消息
                    string NextAuditUserId = Bao.BillBase.Audit.AuditBillManager.FirstAuditUser(this.BO.FunctionId, this.BO.BillId, "0");
                    if (NextAuditUserId != "")
                        Bao.Message.CMessage.SendMessage("请审批" + this.Text.Trim(), "", NextAuditUserId, UFBaseLib.BusLib.BaseInfo.UserId, this.BO.TempId, this.BO.BillId);
                    sqlTran.Commit();

                    MessageBox.Show("提交成功");
                }
                catch (Exception ee)
                {
                    sqlTran.Rollback();
                    throw new Exception("提交失败，原因：" + ee.Message);
                }
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void toolBarBill1_OnBaoUpCancel(object sender, EventArgs e)
        {
            if (this.BO.BillId == "")
                throw new Exception("没有内容不能收回");
			//if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(this.BO.FunctionId, this.BO.BillId, "0") == false)
			//    throw new Exception("该单据未提交，不能收回！");
            LoginUserIsCreateUser();
            if (MessageBox.Show("确定收回？", "提示", System.Windows.Forms.MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                try
                {
                    Bao.BillBase.Audit.AuditManager.DeleFlowLine(this.BO.BillId, this.BO.FunctionId, "0");
                    MessageBox.Show("收回成功");

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }

        private void toolBarBill1_OnBaoAuditList(object sender, EventArgs e)
        {
            
            //获得最大审批次数
           // int auditNum = Bao.BillBase.Audit.AuditBillManager.GetMaxAuditNumByFunctionId(this.BO.BillId, this.BO.FunctionId,"0");
            System.Data.DataTable flowOfFlowLineTable = Bao.BillBase.Audit.AuditBillManager.GetAuditFlowOfAuditFlowLine(this.BO.BillId, this.BO.FunctionId);
            AuditList.gridControl1.DataSource = flowOfFlowLineTable;
            System.Data.DataTable flowOfFlowLineUserTable = Bao.BillBase.Audit.AuditBillManager.GetAuditFlowOfAuditFlowLineUser(this.BO.BillId, this.BO.FunctionId);
            AuditList.gridControl2.DataSource = flowOfFlowLineUserTable;
			//AuditList.Visible = true;
            //AuditList.Show();

			AuditList.Visible = false;
			AuditList.ShowDialog();
        }

        private void FrmBillBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            AuditList.CloseFlag = true;
            AuditList.Close();
            e.Cancel = false;
        }

        private void toolBarBill1_OnBeforBaoUpdate(object sender, EventArgs e)
        {

            if (this.BO.BillId == "")
                throw new Exception("没有内容不能修改");
            LoginUserIsCreateUser();

			if (Bao.BillBase.Audit.AuditBillManager.IsUpLoad(this.BO.FunctionId, this.BO.BillId, "0"))
				throw new Exception("该单据已提交，不能修改");

           
        }
		public virtual string  GetPlanId() {
			return null;
		}

        public virtual  void toolBarBill1_OnBaoCancel(object sender, EventArgs e)
        {
            CtrEnable(false);
        }

        private void toolBarBill1_OnAfterBaoCancel(object sender, EventArgs e)
        {
            CtrEnable(false);
        }


    }
}
