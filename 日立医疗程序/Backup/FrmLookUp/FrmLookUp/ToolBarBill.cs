using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FrmLookUp
{
	/// <summary>
	/// 自定义工具栏
	/// </summary>
    public partial class ToolBarBill : UserControl {
		#region 变量 属性
		/// <summary>
        /// 在执行OnBeforBaoNew时对其赋值如果为true则不执行OnBaoNew事件。
        /// </summary>
        public bool AbortNew = false;
        private System.Data.DataSet _PrintData=new DataSet(); //打印窗体数据源
		string _PrintFormTitle = string.Empty; //打印窗体标题
		System.Windows.Forms.FormStartPosition _PrintFormStartPosition = new FormStartPosition(); //打印窗体初始位置
		System.Windows.Forms.FormWindowState _PrintFormWindowState = new FormWindowState(); //打印窗体初始状态
		int _PrintFormHeight = 0; //打印窗体默认高度
		int _PrintFormWidth = 0; //打印窗体默认宽度

        string ReportMode = ""; //报表模式
		private DevExpress.XtraGrid.Views.Grid.GridView _gridViewSource; //GridView数据源

		/// <summary>
		/// 打印数据源
		/// </summary>
        public System.Data.DataSet PrintData
        {
            get { return _PrintData; }
            set { _PrintData = value; }
        }

		/// <summary>
		/// 打印窗体标题
		/// </summary>
		public string PrintFormTitle {
			get {
				return _PrintFormTitle;
			}
			set {
				_PrintFormTitle = value;
			}
		}

		/// <summary>
		/// 打印窗体初始位置
		/// </summary>
		public System.Windows.Forms.FormStartPosition PrintFormStartPosition {
			get {
				return _PrintFormStartPosition;
			}
			set {
				_PrintFormStartPosition = value;
			}
		}

		/// <summary>
		/// 打印窗体初始状态
		/// </summary>
		public System.Windows.Forms.FormWindowState PrintFormWindowState {
			get {
				return _PrintFormWindowState;
			}
			set {
				_PrintFormWindowState = value;
			}
		}

		/// <summary>
		/// 打印窗体默认高度
		/// </summary>
		public int PrintFormDefaultHeight {
			get {
				return _PrintFormHeight;
			}
			set {
				_PrintFormHeight = value;
			}
		}

		/// <summary>
		/// 打印窗体默认宽度
		/// </summary>
		public int PrintFormDefaultWidth {
			get {
				return _PrintFormWidth;
			}
			set {
				_PrintFormWidth = value;
			}
		}

		/// <summary>
		/// Gridview数据源
		/// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewSource
        {
            get { return _gridViewSource; }
            set
            {
                _gridViewSource = value;
            }
        }

        private Boolean is_Update;

		/// <summary>
		/// 是否修改
		/// </summary>
        public Boolean Is_Update
        {
            get { return is_Update; }
            set { is_Update = value; }
        }
        
        /// <summary>
        /// 选择窗体查询的SQL
        /// </summary>
        public string SelectSQL
        {
            get
            { 
                return baoBtnSelect.BaoSQL; 
            }
            set
            {
                baoBtnSelect.BaoSQL = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        public string SelectDllPath
        {
            get
            {
                return baoBtnSelect.BaoDataAccDLLFullPath ;
            }
            set
            {
                baoBtnSelect.BaoDataAccDLLFullPath = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        public string SelectClassName
        {
            get
            {
                return baoBtnSelect.BaoFullClassName ;
            }
            set
            {
                baoBtnSelect.BaoFullClassName = value;
            }
        }

		/// <summary>
		/// 选择窗体字段标题
		/// </summary>
        public string SelectTitleName
        {
            get
            {
                return baoBtnSelect.BaoTitleNames ;
            }
            set
            {
                baoBtnSelect.BaoTitleNames = value;
            }
        }

        /// <summary>
        /// 定位按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssLocationVisable {
            get {
                return tssLocation.Visible;
            }
            set {
                tssLocation.Visible = value;
            }
        }
       
		/// <summary>
		/// 定位按钮是否显示
		/// </summary>
        public Boolean BtnSelectVisable
        {
            get
            {
                return BtnLocation.Visible;
            }
            set
            {
                BtnLocation.Visible = value;
            }
        }
        
		/// <summary>
		/// 新增按钮是否显示
		/// </summary>
        public Boolean BtnNewVisable
        {
           
            get
            {
                return BtnAddNew.Visible;
            }
            set
            {
                BtnAddNew.Visible = value;
            }
        }


		/// <summary>
		/// 修改按钮是否显示
		/// </summary>
        public Boolean BtnUpdateVisable
        {

            get
            {
                return BtnModify.Visible;
            }
            set
            {
                BtnModify.Visible = value;
            }
        }

        /// <summary>
        /// 刷新按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssRefreshVisable {
            get {
                return tssRefresh.Visible;
            }
            set {
                tssRefresh.Visible = value;
            }
        }

        /// <summary>
        /// 刷新按钮是否显示
        /// </summary>
        public Boolean BtnRefreshVisable {
            get {
                return BtnRefresh.Visible;
            }
            set {
                BtnRefresh.Visible = value;
            }
        }

		/// <summary>
		/// 保存按钮是否显示
		/// </summary>
        public Boolean BtnSaveVisable
        {

            get
            {
                return BtnSave.Visible;
            }
            set
            {
                BtnSave.Visible = value;
            }
        }

        /// <summary>
        /// 审核按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssAuditVisable {
            get {
                return tssAudit.Visible;
            }
            set {
                tssAudit.Visible = value;
            }
        }

		/// <summary>
		/// 审核按钮是否显示
		/// </summary>
        public Boolean BtnAuditVisable
        {

            get
            {
                return BtnAudit.Visible;
            }
            set
            {
                BtnAudit.Visible = value;
            }
        }
        public Boolean BtnDeleteVisable
        {

            get
            {
                return BtnDelete.Visible;
            }
            set
            {
                BtnDelete.Visible = value;
            }
        }

        /// <summary>
        /// 打印按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssPrintVisable {
            get {
                return tssPrint.Visible;
            }
            set {
                tssPrint.Visible = value;
            }
        }

		/// <summary>
		/// 打印按钮是否显示
		/// </summary>
        public Boolean BtnPrintVisable
        {

            get
            {
                return BtnPrint.Visible;
            }
            set
            {
                BtnPrint.Visible = value;
            }
        }

		/// <summary>
		/// 导出到Excel按钮是否显示
		/// </summary>
        public Boolean BtnExcelVisable
        {

            get
            {
                return BtnExcel.Visible;
            }
            set
            {
                BtnExcel.Visible = value;
            }
        }

        /// <summary>
        /// 提交按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssUpLoadVisable {
            get {
                return tssUpLoad.Visible;
            }
            set {
                tssUpLoad.Visible = value;
            }
        }

		/// <summary>
		/// 提交按钮是否显示
		/// </summary>
        public Boolean BtnUpLoadVisable
        {
            get
            {
                return BtnUpLoad.Visible;
            }
            set
            {
                BtnUpLoad.Visible = value;
            }
        }

		/// <summary>
		/// 收回按钮是否显示
		/// </summary>
        public Boolean BtnUnUpLoadVisable
        {
            get
            {
                return BtnUnUpLoad.Visible;
            }
            set
            {
                BtnUnUpLoad.Visible = value;
            }
        }

		/// <summary>
		/// 审核列表按钮是否显示
		/// </summary>
        public Boolean BtnAuditListVisable
        {
            get
            {
                return BtnAuditList.Visible;
            }
            set
            {
                BtnAuditList.Visible = value;
            }
            
        }

		/// <summary>
		/// 弃审按钮是否显示
		/// </summary>
        public Boolean BtnUnAuditVisable
        {
            get
            {
                return BtnUnAudit.Visible;
            }
            set
            {
                BtnUnAudit.Visible = value;
            }
        }

        /// <summary>
        /// 增行按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssAddRowVisable {
            get {
                return tssAddRow.Visible;
            }
            set {
                tssAddRow.Visible = value;
            }
        }

        /// <summary>
        /// 增行按钮是否显示
        /// </summary>
        public Boolean BtnAddLineVisable {
            get {
                return BtnAddRow.Visible;
            }
            set {
                BtnAddRow.Visible = value;
            }
        }

        /// <summary>
        /// 删行按钮是否显示
        /// </summary>
        public Boolean BtnDelLineVisable {
            get {
                return BtnDeleteRow.Visible;
            }
            set {
                BtnDeleteRow.Visible = value;
            }
        }

        /// <summary>
        /// 撤销按钮是否显示
        /// </summary>
        public Boolean BtnCancelVisable {
            get {
                return BtnCancel.Visible;
            }
            set {
                BtnCancel.Visible = value;
            }
        }

        /// <summary>
        /// 第一张按钮前的间隔栏是否显示
        /// </summary>
        public Boolean tssFirstVisable {
            get {
                return tssFirst.Visible;
            }
            set {
                tssFirst.Visible = value;
            }
        }

        /// <summary>
        /// 跳转到第一张单据按钮
        /// </summary>
        public Boolean BtnFirstVisable
        {
            get
            {
                return this.btnFirst.Visible;
            }
            set
            {
                btnFirst.Visible = value;
            }
        }
        /// <summary>
        /// 上一张单据按钮
        /// </summary>
        public Boolean BtnPreviewVisable
        {
            get
            {
                return this.btnPreview.Visible;
            }
            set
            {
                btnPreview.Visible = value;
            }
        }
        /// <summary>
        /// 下一张单据按钮
        /// </summary>
        public Boolean BtnNextVisable
        {
            get
            {
                return this.btnNext.Visible;
            }
            set
            {
                btnNext.Visible = value;
            }
        }
        /// <summary>
        /// 最后一张单据按钮
        /// </summary>
        public Boolean BtnEndVisable
        {
            get
            {
                return this.btnEnd.Visible;
            }
            set
            {
                btnEnd.Visible = value;
            }
        }
		#endregion

		#region 自定义委托 —— 事件
		public delegate void BaoSave(object sender, BillUpDateStateEventArgs e);
        public delegate void BaoAudit(object sender, EventArgs e);
        public delegate void BaoUnAudit(object sender, EventArgs e);
        public delegate void BaoUpdate(object sender, EventArgs e);
        public delegate void BaoNew(object sender, EventArgs e);
        public delegate void BaoSelect(object sender, LookUpEventArgs e);
        public delegate void BaoDelete(object sender, EventArgs e);
        public delegate void BaoExcel(object sender, EventArgs e);
        public delegate void BaoExit(object sender, EventArgs e);
        public delegate void BaoSetPrintDataset(object sender, EventArgs e);
        public delegate void BaoUpLoad(object sender, EventArgs e);
        public delegate void BaoUpCancel(object sender, EventArgs e);
        public delegate void BaoAuditList(object sender, EventArgs e);
		public delegate void BaoBringBarCode(object sender, EventArgs e);
        public delegate void BaoAddLine(object sender,EventArgs e);
        public delegate void BaoDelLine(object sender, EventArgs e);
        public delegate void BaoCancel(object sender, EventArgs e);
        public delegate void BaoRefresh(object sender, EventArgs e);

        public delegate void BeforBaoNew(object sender, EventArgs e);
        public delegate void AfterBaoNew(object sender, EventArgs e);
        public delegate void BeforBaoUpdate(object sender, EventArgs e);
        public delegate void AfterBaoSave(object sender,EventArgs e);
        public delegate void BeforBaoSave(object sender, EventArgs e);
        public delegate void AfterBaoCancel(object sender, EventArgs e);
        public delegate void BeforBaoDelete(object sender, EventArgs e);
	

        public event BaoSave OnBaoSave;
        public event BaoAudit OnBaoAudit;
        public event BaoUnAudit OnBaoUnAudit;
        public event BaoUpdate OnBaoUpdate;
        public event BaoNew OnBaoNew;
        public event BaoSelect OnBaoSelect;
        public event BaoDelete OnBaoDelete;
        public event BaoExit OnBaoExit;
        public event BaoSetPrintDataset OnBaoSetPrintDataset;
        public event BaoUpLoad OnBaoUpLoad;
        public event BaoUpCancel OnBaoUpCancel;
        public event BaoAuditList OnBaoAuditList;
		public event BaoBringBarCode OnBaoBringBarCode;
        public event BaoAddLine OnBaoAddLine;
        public event BaoDelLine OnBaoDelLine;
        public event BaoCancel OnBaoCancel;
        public event BaoRefresh OnBaoRefresh;
        public event BaoExcel OnBaoExcel;
		public event BeforBaoNew OnBeforBaoNew;
        public event AfterBaoNew OnAfterBaoNew;
		public event BeforBaoUpdate OnBeforBaoUpdate;
        public event AfterBaoSave OnAfterBaoSave;
        public event BeforBaoSave OnBeforBaoSave;
        public event AfterBaoCancel OnAfterBaoCancel;
        public event BeforBaoDelete OnBeforBaoDelete;

		#endregion     

        public ToolBarBill()
        {
            InitializeComponent();
		}

		#region 用户操作
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNew_Click(object sender, EventArgs e)
        {
            AbortNew = false;
			if (OnBeforBaoNew != null) {
				OnBeforBaoNew(sender, e);
			}

            if (AbortNew == false)
            {
                this.BtnModify .Enabled = false;
                this.BtnSave.Enabled = true;
                ((System.Windows.Forms.ToolStripButton)sender).Enabled = false;
                this.BtnPrint .Enabled = false;
                this.BtnExcel.Enabled = false;
                this.BtnAudit .Enabled = false;
                this.is_Update = false;
                this.BtnUpLoad.Enabled  = false;
				
                this.BtnAddRow .Enabled = true;
                this.BtnDeleteRow.Enabled = true;
                OnBaoNew(sender, e);
            }
            if (OnAfterBaoNew != null)
            {
                OnAfterBaoNew(sender, e);
            }
        }

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            //if (BtnAudit.Text == "反审核")
            //{
            //    MessageBox.Show("该单据已审核");
            //    return;
            //}
            if (OnBeforBaoUpdate != null)
                OnBeforBaoUpdate(sender, e);

            this.BtnAddNew .Enabled =false;
            this.BtnSave.Enabled = true;
            ((System.Windows.Forms.ToolStripButton)sender).Enabled = false;
            this.BtnPrint.Enabled =false;
            this.BtnExcel .Enabled =false;
            this.BtnAudit .Enabled =false;
            this.is_Update = true;
            this.BtnUpLoad.Enabled = false;
			this.BtnAddRow.Enabled = true;
            this.BtnDeleteRow.Enabled = true;
            OnBaoUpdate(sender, e);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnRefresh_Click(object sender, EventArgs e) {
            if (OnBaoRefresh != null) {
                OnBaoRefresh(sender, e);
            }
        }

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnSave_Click(object sender, EventArgs e)
        {
            if (OnBeforBaoSave != null) {
                OnBeforBaoSave(sender, e);
            }
            OnBaoSave(this, new BillUpDateStateEventArgs(Is_Update));
            this.BtnAddNew.Enabled = true;
            this.BtnModify.Enabled = true;
            ((System.Windows.Forms.ToolStripButton)sender).Enabled = false;
            this.BtnPrint.Enabled = true;
            this.BtnExcel.Enabled = true;
            this.BtnAudit.Enabled = true;
            this.BtnUpLoad.Enabled = true;

            this.BtnAddRow.Enabled = false;
            this.BtnDeleteRow.Enabled = false;
            if (OnAfterBaoSave != null) {
                OnAfterBaoSave(sender, e);
            }
        }

		/// <summary>
		/// 审核
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnAudit_Click(object sender, EventArgs e)
        {
            //if (((System.Windows.Forms.Button)sender).Text == "审核")
            {
                OnBaoAudit(sender, e);
               // ((System.Windows.Forms.Button)sender).Text = "反审核";
            }
            //else
            //{
            //    OnBaoUnAudit(sender, e);
            //    ((System.Windows.Forms.Button)sender).Text = "审核";

            //}
        }

		/// <summary>
		/// 打印
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnPrint_Click(object sender, EventArgs e)
        {
            try {
                if (ReportMode == "") {
                    U8Global.IniProcess IniObj = new U8Global.IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
                    ReportMode = IniObj.read("Report", "Report", "");
                }
                // if (ReportMode == "XReport")
                {
                    this.Cursor = Cursors.WaitCursor;
                    OnBaoSetPrintDataset(sender, e);
                    if (_PrintData == null)
                        throw new Exception("必须将要打印的DataSet付值");
                    //Bao.XReport.XReport.proview(this.ParentForm.Text, PrintData);
                    //Bao.XReport.XReport.proview(_PrintFormTitle, _PrintData, _PrintFormStartPosition, _PrintFormWindowState, _PrintFormHeight, _PrintFormWidth);
                }
                //else
                // {
                // Bao.FastReport.FastReport.PrintSet(this.ParentForm.Text.Trim(),PrintData );
                // OnBaoPrint(sender, e);
                // }
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.Cursor = Cursors.Default;
            }
        }

		/// <summary>
		/// 导出Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnExcel_Click(object sender, EventArgs e)
        {
            //if (GridViewSource == null)
            //    throw new Exception("RptControl 控件的GridViewSource 属性不能为空");
            //this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            //{
            //    GridViewSource.ExportToXls(saveFileDialog1.FileName);
            //}
            OnBaoExcel(sender, e);
        }

		/// <summary>
		/// 退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnExit_Click(object sender, EventArgs e)
        {
            //如果保存按钮为不激活或者保存按钮激活但是用户确定放弃保存，则退出当前界面
            if ((this.BtnSave.Enabled == false) || (this.BtnSave.Enabled == true &&
                MessageBox.Show("是否放弃保存当前数据？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)) {
                OnBaoExit(sender, e);
            } 
            //this.ParentForm.Close();
        }

		/// <summary>
		/// 选择窗体关闭后
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void baoBtnSelect_OnLookUpClosed(object sender, LookUpEventArgs e)
        {
            OnBaoSelect(sender, e);
            this.BtnAddNew .Enabled =true;
            this.BtnModify .Enabled =true;
            this.BtnAudit .Enabled =true;
            this.BtnSave .Enabled =false;
           
            this.BtnPrint .Enabled =true;
            this.BtnExcel.Enabled =true;
            this.BtnAddRow .Enabled = false;
            this.BtnDeleteRow .Enabled = false;
        }

		/// <summary>
		/// 工具栏加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void ToolBarBill_Load(object sender, EventArgs e)
        {
            this.BtnLocation.Enabled = true;
            this.BtnAudit.Enabled = true;
            this.BtnAddNew.Enabled = true;
            this.BtnModify.Enabled = true;
            this.BtnSave.Enabled = false;
            this.BtnPrint.Enabled = false;
            //this.BtnExcel.Enabled = false;

            this.BtnAddRow.Enabled = false;
            this.BtnDeleteRow.Enabled = false;
        }

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnDelete_Click(object sender, EventArgs e)
        {
            if (OnBeforBaoDelete != null)
                OnBeforBaoDelete(sender, e);
            OnBaoDelete(sender, e);
        }
		
		/// <summary>
		/// 撤销
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BtnCancel_Click(object sender, EventArgs e)
        {
            if (OnBaoCancel != null) {
                OnBaoCancel(sender, e);
            }
            //如果没有保存，点击撤销按钮，则给予提示
            if (this.BtnSave .Enabled == true && 
                MessageBox.Show("确定放弃保存当前操作？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                this.BtnAddNew.Enabled = true;
                this.BtnModify.Enabled = true;
                this.BtnCancel.Enabled = true;
                this.BtnDelete.Enabled = false;
                this.BtnSave.Enabled = false;
                this.BtnPrint.Enabled = false;
                this.BtnExcel.Enabled = false;
                this.BtnAudit.Enabled = false;
                this.BtnUpLoad.Enabled = false;

                this.BtnAddRow.Enabled = false;
                this.BtnDeleteRow.Enabled = false;


                if (OnAfterBaoCancel != null) {
                    OnAfterBaoCancel(sender, e);
                }
            }
        }

       /// <summary>
       /// 弃审
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void BtnUnAudit_Click(object sender, EventArgs e)
        {
            OnBaoUnAudit(sender, e);
        }

		/// <summary>
		/// 提交
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BtnUpLoad_Click(object sender, EventArgs e)
        {
            OnBaoUpLoad(sender, e);
            BtnUpLoad.Enabled = false;
        }
		/// <summary>
		/// 收回
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BtnUpCancel_Click(object sender, EventArgs e)
        {
            OnBaoUpCancel(sender, e);
        }

		/// <summary>
		/// 审核列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BtnAuditList_Click(object sender, EventArgs e)
        {
            OnBaoAuditList(sender, e);
        }

		/// <summary>
		/// 产生条码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void BtnBringBarCode_Click(object sender, EventArgs e) {
			OnBaoBringBarCode(sender, e);
		}

        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLine_Click(object sender, EventArgs e) {
            OnBaoAddLine(sender, e);
        }

        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelLine_Click(object sender, EventArgs e) {
            if (MessageBox.Show("确定删除当前选择行数据？", "温馨提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                OnBaoDelLine(sender, e);
            }
        }
		#endregion

        private void BtnLocation_Click(object sender, EventArgs e)
        {
            baoBtnSelect.button1_Click(sender, e);
        }
	}        
}
