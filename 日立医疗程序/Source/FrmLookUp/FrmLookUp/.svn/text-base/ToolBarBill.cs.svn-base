using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FrmLookUp
{
    public partial class ToolBarBill : UserControl
    {
        /// <summary>
        /// 在执行OnBeforBaoNew时对其赋值如果为true则不执行OnBaoNew事件。
        /// </summary>
        public bool AbortNew = false;
        private System.Data.DataSet _PrintData=new DataSet();
        string ReportMode = "";
        public System.Data.DataSet PrintData
        {
            get { return _PrintData; }
            set { _PrintData = value; }
        }
        private DevExpress.XtraGrid.Views.Grid.GridView _gridViewSource;

        public DevExpress.XtraGrid.Views.Grid.GridView GridViewSource
        {
            get { return _gridViewSource; }
            set
            {
                _gridViewSource = value;
            }
        }

        private Boolean is_Update;

        public Boolean Is_Update
        {
            get { return is_Update; }
            //set { is_Update = value; }
        }
        
        
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
        public Boolean BtnSelectVisable
        {
            get
            {
                return baoBtnSelect.Visible ;
            }
            set
            {
                baoBtnSelect.Visible = value;
            }
        }
        
        public Boolean BtnNewVisable
        {
           
            get
            {
                return  BtnNew.Visible;
            }
            set
            {
                BtnNew.Visible = value;
            }
        }

        public Boolean BtnUpdateVisable
        {

            get
            {
                return BtnUpdate.Visible;
            }
            set
            {
                BtnUpdate.Visible = value;
            }
        }

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
        public Boolean BtnUpCancelVisable
        {
            get
            {
                return BtnUpCancel.Visible;
            }
            set
            {
                BtnUpCancel.Visible = value;
            }
        }
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
        public delegate void BeforBaoNew(object sender, EventArgs e);
        public delegate void BeforBaoUpdate(object sender, EventArgs e);
        public delegate void BaoUpLoad(object sender, EventArgs e);
        public delegate void BaoUpCancel(object sender, EventArgs e);
        public delegate void BaoAuditList(object sender, EventArgs e);

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

        /// <summary>
        /// 
        /// </summary>
        public event BeforBaoNew OnBeforBaoNew;
        public event BeforBaoUpdate OnBeforBaoUpdate;

        public ToolBarBill()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNew_Click(object sender, EventArgs e)
        {
            AbortNew = false;
            if (OnBeforBaoNew!=null)
                OnBeforBaoNew(sender, e);

            if (AbortNew == false)
            {
                this.BtnUpdate.Enabled = false;
                this.BtnSave.Enabled = true;
                ((System.Windows.Forms.Button)sender).Enabled = false;
                this.BtnPrint.Enabled = false;
                this.BtnExcel.Enabled = false;
                this.BtnAudit.Enabled = false;
                this.is_Update = false;
                this.BtnUpLoad.Enabled  = false;
                OnBaoNew(sender, e);
            }
            
        }

        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            //if (BtnAudit.Text == "反审核")
            //{
            //    MessageBox.Show("该单据已审核");
            //    return;
            //}
            if (OnBeforBaoUpdate != null)
                OnBeforBaoUpdate(sender, e);

            this.BtnNew.Enabled =false;
            this.BtnSave .Enabled =true;
             ((System.Windows.Forms.Button)sender).Enabled =false;
            this.BtnPrint.Enabled =false;
            this.BtnExcel .Enabled =false;
            this.BtnAudit .Enabled =false;
            this.is_Update = true;
            this.BtnUpLoad.Enabled = false;
            OnBaoUpdate(sender, e);
            
        }

        public void BtnSave_Click(object sender, EventArgs e)
        {
            OnBaoSave(this, new BillUpDateStateEventArgs(Is_Update));
            this.BtnNew.Enabled =true;
            this.BtnUpdate.Enabled =true;
            ((System.Windows.Forms.Button)sender).Enabled =false;
            this.BtnPrint.Enabled =true;
            this.BtnExcel .Enabled =true;
            this.BtnAudit .Enabled =true;
            this.BtnUpLoad.Enabled = true;
        }

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

        public void BtnPrint_Click(object sender, EventArgs e)
        {
            if (ReportMode == "")
            {
                Bao.DataAccess.IniProcess IniObj = new Bao.DataAccess.IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "DBini.ini");
                ReportMode = IniObj.read("Report", "Report", "");
            }
           // if (ReportMode == "XReport")
            {
                OnBaoSetPrintDataset(sender, e);
                if (_PrintData == null)
                    throw new Exception("必须将要打印的DataSet付值");
                Bao.XReport.XReport.proview(this.ParentForm.Text, PrintData);
            }
            //else
           // {
               // Bao.FastReport.FastReport.PrintSet(this.ParentForm.Text.Trim(),PrintData );
               // OnBaoPrint(sender, e);
           // }
        }

        public void BtnExcel_Click(object sender, EventArgs e)
        {
            if (GridViewSource == null)
                throw new Exception("RptControl 控件的GridViewSource 属性不能为空");
            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                GridViewSource.ExportToXls(saveFileDialog1.FileName);
            }
            //OnBaoExcel(sender, e);
        }

        public void BtnExit_Click(object sender, EventArgs e)
        {

            OnBaoExit(sender, e);
            //this.ParentForm.Close();
        }

        public void baoBtnSelect_OnLookUpClosed(object sender, LookUpEventArgs e)
        {
            OnBaoSelect(sender, e);
            this.BtnNew.Enabled =true;
            this.BtnUpdate.Enabled =true;
            this.BtnAudit .Enabled =true;
            this.BtnSave.Enabled =false;
            this.BtnPrint .Enabled =true;
            this.BtnExcel.Enabled =true;
        }

        public void ToolBarBill_Load(object sender, EventArgs e)
        {
            this.baoBtnSelect.Enabled = true;
            this.BtnAudit.Enabled  = true;
            this.BtnNew.Enabled = true;
            this.BtnUpdate.Enabled = true;
            this.BtnSave .Enabled = false;
            this.BtnPrint.Enabled = false;
            this.BtnExcel.Enabled =false;

        }

        public void BtnDelete_Click(object sender, EventArgs e)
        {
            OnBaoDelete(sender, e);
        }

        

        public void BtnCancel_Click(object sender, EventArgs e)
        {
            this.BtnNew.Enabled = true;
            this.BtnUpdate.Enabled = true;
            ((System.Windows.Forms.Button)sender).Enabled = true;
            this.BtnSave.Enabled = false;
            this.BtnPrint.Enabled = true;
            this.BtnExcel.Enabled = true;
            this.BtnAudit.Enabled = true;
            this.BtnUpLoad.Enabled = false;
        }

       
        private void BtnUnAudit_Click(object sender, EventArgs e)
        {
            OnBaoUnAudit(sender, e);
        }

        private void BtnUpLoad_Click(object sender, EventArgs e)
        {
            OnBaoUpLoad(sender, e);
            BtnUpLoad.Enabled = false;
        }

        private void BtnUpCancel_Click(object sender, EventArgs e)
        {
            OnBaoUpCancel(sender, e);
        }

        private void BtnAuditList_Click(object sender, EventArgs e)
        {
            OnBaoAuditList(sender, e);
        }
        


    }

        
}
