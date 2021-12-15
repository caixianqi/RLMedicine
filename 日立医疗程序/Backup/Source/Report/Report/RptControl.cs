using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bao.Report
{
    public delegate void SearchClosed(object sender, TableEventArge e);
     [DefaultEvent("OnSearchClosed")]
    public partial class RptControl : UserControl
    {
         System.Data.DataSet dataset1 = new DataSet();
         static string ReportMode = "";
         FrmLookUp.frmColumnFilter frmFilterCol;   //�����еĴ���
         FormFilterBase objFilterForm;              //��ѯ����
         public FormFilterBase BaoFilterForm
         {
             get { return objFilterForm; }
             set { objFilterForm = value; }
         }
         public string ParentFormCaption            //�ÿؼ����ڴ���ı���
         {
             set {
                 frmFilterCol.ParentFormCaption = value;
             }
         }

        [Description("���¼��ĵĲ���e ���в�ѯ�Ľ����")]
        //public event SearchClosed OnSearchClosed;
        

         private string _FullDLLName;
        public string FullDLLName
        {
            get { return _FullDLLName; }
            set { _FullDLLName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _FullClassName;

        [Description("�����Ǽ̳���Report.dll�е�Bao.Report.FormFilterBase��Ĵ���")]
        public string FullClassName
        {
            get { return _FullClassName; }
            set { _FullClassName = value; }
        }
       
        private string _Fr3path;
        [Description("ģ���ļ����ļ����ƣ����ļ����������������Ŀ¼��")]
        public string Fr3path
        {
          get { return _Fr3path; }
          set { _Fr3path = value; }
        }
        public System.Windows.Forms.ToolStripMenuItem MentItemPrint1
        {
            get { return _MentItemPrint1; }
            set { _MentItemPrint1 = value; }
        }
        public System.Windows.Forms.ToolStripMenuItem MentItemPrint2
        {
            get { return _MentItemPrint2; }
            set { _MentItemPrint2 = value; }
        }
        public System.Windows.Forms.ToolStripMenuItem MentItemPrint3
        {
            get { return _MentItemPrint3; }
            set { _MentItemPrint3 = value; }
        }
        public System.Windows.Forms.ToolStripMenuItem MentItemPrint4
        {
            get { return _MentItemPrint4; }
            set { _MentItemPrint4 = value; }
        }
        public System.Windows.Forms.ToolStripMenuItem MentItemPrint5
        {
            get { return _MentItemPrint5; }
            set { _MentItemPrint5 = value; }
        }
        
        public RptControl()
        {
            InitializeComponent();
             //if (!DesignMode)
            frmFilterCol = new FrmLookUp.frmColumnFilter();
           
        }

        private DevExpress.XtraGrid.Views.Grid.GridView _gridViewSource;

        public DevExpress.XtraGrid.Views.Grid.GridView BaoGridViewSource
        {
            get { return _gridViewSource; }
            set {

                _gridViewSource = value;
                frmFilterCol.SourceGridView = value;
                frmFilterCol.ReadInitVisableInfo();
            }
        }

       

        private void Excepot(string FileType)
        {
            MutilRowToDataset();
            System.Data.DataTable temp = (System.Data.DataTable)BaoGridViewSource.GridControl.DataSource;
            if (BaoGridViewSource == null)
                throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
            //if (this.GridControl1 == null)
            //    throw new Exception("RptControl �ؼ���GridControl1 ���Բ���Ϊ��");
            this.saveFileDialog1.Filter = FileType+ "files (*." + FileType + ")|*." + FileType;

            BaoGridViewSource.GridControl.DataSource = dataset1.Tables[0];
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                switch (FileType)
                {
                    case "xls":
                        this.BaoGridViewSource.ExportToXls(saveFileDialog1.FileName);
                        break;
                    case "html":
                        this.BaoGridViewSource.ExportToHtml(saveFileDialog1.FileName);
                        break;
                    case "txt":
                        this.BaoGridViewSource.ExportToText(saveFileDialog1.FileName);
                        break;
                }
            }
            BaoGridViewSource.GridControl.DataSource = temp;
        }

        private void MutilRowToDataset()
        {
            #region ��ѡ�еļ�¼������һ��datatable��
            dataset1.Tables.Clear();
            System.Data.DataTable dd;

            dd = ((System.Data.DataTable)(BaoGridViewSource.GridControl.DataSource)).Clone();
            int[] aa = this.BaoGridViewSource.GetSelectedRows();

            for (int i = 0; i < aa.Length; i++)
            {

                System.Data.DataRow row1 = dd.NewRow();
                for (int j = 0; j < dd.Columns.Count; j++)
                {
                    //((System.Data.DataTable)(BaoGridViewSource.GridControl .DataSource)).Columns[j].DataType.ToString()=
                    row1[j] = ((System.Data.DataTable)(BaoGridViewSource.GridControl.DataSource)).Rows[aa[i]][j];
                }

                dd.Rows.Add(row1);
            }
            dataset1.Tables.Add(dd);
            #endregion 

        }

      
       
        private void ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (objFilterForm == null)
            {
                if (FullDLLName == "")
                    throw new Exception("RptControl �ؼ���FullDLLName ���Բ���Ϊ��");
                if (FullClassName == "")
                    throw new Exception("RptControl �ؼ���FullClassName ���Բ���Ϊ��");

                objFilterForm = (Bao.Report.FormFilterBase)Bao.DataAccess.DataAcc.CreateObject(FullDLLName, FullClassName);
            }
            this.ParentForm.AddOwnedForm(objFilterForm);
            objFilterForm.OnExecParent = gettable;
           
            objFilterForm.Show();
            objFilterForm.Activate();
            
        }
        public void  gettable()
        {
            BaoGridViewSource.GridControl.DataSource = objFilterForm.DataSourceTable;
            //if (OnSearchClosed == null)
            //    throw new Exception("������дRptControl�ؼ���OnSearchClosed�¼� ��");
            //OnSearchClosed(this, new TableEventArge(objFilterForm.dataset1 ));
        }

        private void ��ӡToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
          
        }

         private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
         {
            //if (Fr3path==null || Fr3path=="")
            //    FastReportService.Instance.ShowDesigner((int)this.Handle, objFilterForm.dataset1);
            //else

            //FastReportService.Instance.ShowDesigner(delegate(TfrxReport report) { report.MainWindowHandle = (int)this.Handle ; },
            //    null, objFilterForm.dataset1 , null, String.Format("{0}\\{1}", Application.StartupPath,Fr3path), null); 
           
         }
         private void print(string Title)
         {
            if (ReportMode=="")
            {
             Bao.DataAccess.IniProcess IniObj = new Bao.DataAccess.IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "DBini.ini");
             ReportMode = IniObj.read("Report", "Report", "");
            }   
            //if (ReportMode =="XReport")
            
                Bao.XReport.XReport.proview(Title,objFilterForm.dataset1 );
            //else
            //    Bao.FastReport.FastReport.PrintSet(Title, objFilterForm.dataset1);
            
         }
         private void PrintMuitRows(string Title)
         {
            // MutilRowToDataset();
            // Bao.FastReport.FastReport.PrintSet(Title, this.dataset1);
         }
         private void ������ToolStripMenuItem5_Click(object sender, EventArgs e)
         {
           print(this.ParentForm.Text.Trim() + ((System.Windows.Forms.ToolStripMenuItem)(sender)).Name.Trim());

         }

        

         private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (BaoGridViewSource == null)
                 throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
             //if (this.GridControl1  == null)
             //    throw new Exception("RptControl �ؼ���GridControl1 ���Բ���Ϊ��");
             this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";


             if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
             {
                 BaoGridViewSource.ExportToXls(saveFileDialog1.FileName);
             }
         }

         private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             if (BaoGridViewSource == null)
                 throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
             //if (this.GridControl1 == null)
             //    throw new Exception("RptControl �ؼ���GridControl1 ���Բ���Ϊ��");
             saveFileDialog1.Filter = "HTML files (*.html)|*.html";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
             {
                 BaoGridViewSource.ExportToHtml(saveFileDialog1.FileName);
             }

         }

         private void ������ToolStripMenuItem2_Click(object sender, EventArgs e)
         {
             if (BaoGridViewSource == null)
                 throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
             //if (this.GridControl1 == null)
             //    throw new Exception("RptControl �ؼ���GridControl1 ���Բ���Ϊ��");
             saveFileDialog1.Filter = "text files (*.txt)|*.txt";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
             {

                 BaoGridViewSource.ExportToText(saveFileDialog1.FileName);
             }

         }

         private void ������ToolStripMenuItem3_Click(object sender, EventArgs e)
         {
             if (BaoGridViewSource == null)
                 throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
             //if (this.GridControl1 == null)
             //    throw new Exception("RptControl �ؼ���GridControl1 ���Բ���Ϊ��");
             saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
             {
                 BaoGridViewSource.ExportToPdf(saveFileDialog1.FileName);
             }

         }

         private void ������ToolStripMenuItem4_Click(object sender, EventArgs e)
         {
             if (BaoGridViewSource == null)
                 throw new Exception("RptControl �ؼ���BaoGridViewSource ���Բ���Ϊ��");
             saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
             {
                 BaoGridViewSource.ExportToRtf(saveFileDialog1.FileName);
             }

         }

         private void ѡ�����ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             Excepot("xls");
            
         }

         private void ѡ�����ToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             Excepot("html");
         }

         private void ѡ�����ToolStripMenuItem2_Click(object sender, EventArgs e)
         {
             Excepot("txt");
         }

         private void ѡ�����ToolStripMenuItem3_Click(object sender, EventArgs e)
         {
             Excepot("pdf");
         }

         private void ѡ�����ToolStripMenuItem4_Click(object sender, EventArgs e)
         {
             Excepot("rtf");
         }

         private void ѡ�����ToolStripMenuItem5_Click(object sender, EventArgs e)
         {
             PrintMuitRows(this.ParentForm.Text.Trim() + ((System.Windows.Forms.ToolStripMenuItem)(sender)).Name.Trim());

         }

         private void excelToolStripMenuItem_Click(object sender, EventArgs e)
         {

         }

         private void ����ʾToolStripMenuItem_Click(object sender, EventArgs e)
         {
             this.ParentForm.AddOwnedForm(frmFilterCol);
             frmFilterCol.ParentFormCaption = this.ParentForm.Text;    
             frmFilterCol.ReadGridVisableInfo();
             frmFilterCol.Show();
         }



        }


    }

