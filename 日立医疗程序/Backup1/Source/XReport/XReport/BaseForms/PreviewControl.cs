using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Control;

namespace XtraReportsDemos
{
	/// <summary>
	/// Summary description for ModuleControl.
	/// </summary>
    public class PreviewControl : ModuleControl
    {

        #region 鲍增加
        protected override XtraReport CreateReport()
        {

            Report report = new Report(TutorialName);
            
            return report;
            
        }
        #endregion

        static readonly PrintingSystemCommand[] exportCommands = new PrintingSystemCommand[] {
                PrintingSystemCommand.ExportPdf,
                PrintingSystemCommand.ExportHtm,
                PrintingSystemCommand.ExportTxt,
                PrintingSystemCommand.ExportCsv,
                PrintingSystemCommand.ExportMht,
                PrintingSystemCommand.ExportXls,
                PrintingSystemCommand.ExportRtf,
                PrintingSystemCommand.ExportGraphic

            };
        //static readonly string[] exportStrings = new string[] {"Export to PDF",
        //                                                              "Export to HTML",
        //                                                              "Export to TXT",
        //                                                              "Export to CSV",
        //                                                              "Export to MHT",
        //                                                              "Export to XLS",
        //                                                              "Export to RTF",
        //                                                              "Export to Image"};

		class ReflectPrintControl: DevExpress.XtraPrinting.Control.PrintControl {
			public new ProgressReflector ProgressReflector 
            { 
                get { return base.ProgressReflector; }
			}
			public DevExpress.XtraEditors.ProgressBarControl ProgressBar { 
                get { return base.progressBar; }
			}
		}
        protected class DesignForm : DevExpress.XtraReports.UserDesigner.XRDesignFormEx
        {
			protected override void SaveLayout() { }
			protected override void RestoreLayout() { }
		}
        
		protected System.Windows.Forms.Panel pnlSettings;
		private XtraReportsDemos.PreviewControl.ReflectPrintControl printControl;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem;
		protected DevExpress.XtraEditors.ComboBoxEdit cmbExport;
		protected DevExpress.XtraEditors.ComboBoxEdit cmbEdit;
		private System.ComponentModel.IContainer components;
		private Cursor saveCursor;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		protected PrintBarManager fPrintBarManager;
		
		public PreviewControl() {
			InitializeComponent();	
			this.cmbExport.SelectedIndex = 0;
			printingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
			fPrintBarManager = CreatePrintBarManager(printControl);
		}
				
		public override XtraReport Report { 
			get { return fReport; } 
			set {
				if (fReport != value) {
					if (fReport != null)
						fReport.Dispose();
					fReport = value;
					if (fReport == null) 
						return;
					printingSystem.ClearContent();
					Invalidate();
					Update();
					fileName = XtraReportsDemos.Helper.GetReportPath(fReport, "repx");
					fReport.PrintingSystem = printingSystem;
                    fReport.ExportOptions.Pdf.NeverEmbeddedFonts = "";
                    fReport.CreateDocument();
                    
					//printControl.ExecCommand(PrintingSystemCommand.DocumentMap, new object[] {false});
					//previewBar.Buttons[0].Pushed = false;
				} 
			}
		}	
		
		public override void Activate() {
			ProgressReflector.RegisterReflector(printControl.ProgressReflector);
			try {
				base.Activate();
			} finally {
				ProgressReflector.MaximizeValue();
				ProgressReflector.UnregisterReflector(printControl.ProgressReflector);
			}
		}
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		/// 
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.cmbEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbExport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.printControl = new XtraReportsDemos.PreviewControl.ReflectPrintControl();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.cmbEdit);
            this.pnlSettings.Controls.Add(this.cmbExport);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(700, 33);
            this.pnlSettings.TabIndex = 0;
            // 
            // cmbEdit
            // 
            this.cmbEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEdit.EditValue = "comboBoxEdit1";
            this.cmbEdit.Location = new System.Drawing.Point(516, 4);
            this.cmbEdit.Name = "cmbEdit";
            this.cmbEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cmbEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "设计", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.cmbEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.cmbEdit.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbEdit_Properties_ButtonClick);
            this.cmbEdit.Size = new System.Drawing.Size(75, 23);
            this.cmbEdit.TabIndex = 2;
            this.cmbEdit.SelectedIndexChanged += new System.EventHandler(this.cmbEdit_SelectedIndexChanged);
            // 
            // cmbExport
            // 
            this.cmbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExport.Location = new System.Drawing.Point(596, 4);
            this.cmbExport.Name = "cmbExport";
            this.cmbExport.Properties.ActionButtonIndex = 1;
            this.cmbExport.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cmbExport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "导出", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 0, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.cmbExport.Properties.DropDownRows = 8;
            this.cmbExport.Properties.Items.AddRange(new object[] {
            "Export to PDF",
            "Export to HTML",
            "Export to TXT",
            "Export to CSV",
            "Export to MHT",
            "Export to XLS",
            "Export to RTF",
            "Export to Image"});
            this.cmbExport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.cmbExport.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbExport_Properties_ButtonClick);
            this.cmbExport.Size = new System.Drawing.Size(104, 23);
            this.cmbExport.TabIndex = 1;
            this.cmbExport.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.cmbExport_CloseUp);
            this.cmbExport.SelectedIndexChanged += new System.EventHandler(this.cmbExport_SelectedIndexChanged);
            // 
            // printControl
            // 
            this.printControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl.IsMetric = false;
            this.printControl.Location = new System.Drawing.Point(2, 2);
            this.printControl.Name = "printControl";
            this.printControl.PrintingSystem = this.printingSystem;
            this.printControl.Size = new System.Drawing.Size(696, 359);
            this.printControl.TabIndex = 1;
            this.printControl.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.printControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 33);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 363);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.Text = "panelControl1";
            // 
            // PreviewControl
            // 
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlSettings);
            this.Name = "PreviewControl";
            this.Size = new System.Drawing.Size(700, 396);
            this.pnlSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
        
		protected PrintBarManager CreatePrintBarManager(PrintControl pc) {
			PrintBarManager printBarManager = new PrintBarManager();
			printBarManager.Form = printControl;
			printBarManager.Initialize(pc);
			printBarManager.MainMenu.Visible = false;
			printBarManager.AllowCustomization = false;
			return printBarManager;
		}
		private void ShowDesignerForm(Form designForm, Form parentForm) {
			designForm.SetDesktopBounds(parentForm.Left, parentForm.Top, parentForm.Width, parentForm.Height);
			designForm.MinimumSize = parentForm.MinimumSize;
			parentForm.Visible = false;				
			designForm.ShowDialog();
			parentForm.SetDesktopBounds(designForm.Left, designForm.Top, designForm.Width, designForm.Height);
			parentForm.Visible = true;
		}
        
		private void cmbEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            XtraReport report = CreateReport();
            System.Diagnostics.Debug.Assert(report != null);
            LoadLayoutAndDataSet(report);
             
            //if (File.Exists(fileName))
            //    report.LoadLayout(fileName);
            /////bao
           // XtraReportsDemos.Report report = new XtraReportsDemos.Report();
            //System.Data.DataSet ds1 = new System.Data.DataSet();
            //System.Data.DataTable dt1 = new System.Data.DataTable("testtable");
            //dt1.Columns.Add("Id");
            //dt1.Columns.Add("Name");
            //dt1.Columns.Add("Demo");
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Data.DataRow row1 = dt1.NewRow();
            //    row1[0] = i.ToString();
            //    row1[1] = "名称" + i.ToString();
            //    row1[2] = "haha" + i.ToString();
            //    dt1.Rows.Add(row1);
            //}
            //MessageBox.Show(dt1.Rows[9][1].ToString());
            //ds1.Tables.Add(dt1);
            ////if (File.Exists(fileName))
            //report.LoadLayout("c:\\111.repx");
            //report.DataSource = ds1;
            
            ///end


			XRDesignFormExBase designForm = new CustomDesignForm();
			try {
                
				designForm.OpenReport(report);
				designForm.FileName = fileName;
				ShowDesignerForm(designForm, this.FindForm());
				if (designForm.FileName != fileName && File.Exists(designForm.FileName))
					File.Copy(designForm.FileName, fileName, true);
			}
			finally {
				designForm.Dispose();
				report.Dispose();
			}
			if(System.IO.File.Exists(fileName)) {
				fReport.LoadLayout(fileName);
                fReport.CreateDocument();
				InitializeControls();
			}


		}
		protected virtual void InitializeControls() {
		}
		private void RestoreProcess() {
			Cursor.Current = saveCursor;
		}	
		private void SetWaitProcess() {
			saveCursor = Cursor.Current;
			Cursor.Current = Cursors.AppStarting;
		}		
		private void ExportByIndex(int index) {
			if (fReport == null)
				return;
			ProgressReflector.RegisterReflector(printControl.ProgressReflector);
			SetWaitProcess();
			try {
                printingSystem.ExecCommand(exportCommands[index]);
			}
			finally {
				ProgressReflector.UnregisterReflector(printControl.ProgressReflector);
				RestoreProcess();		
			}
		}

		private void cmbExport_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
			if (e.Button == cmbExport.Properties.Buttons[0]) 
				ExportByIndex(cmbExport.SelectedIndex);
		}

		private void cmbExport_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (cmbExport.SelectedItem != null)
				cmbExport.Properties.Buttons[0].Caption = cmbExport.SelectedItem.ToString();
		}

		private void cmbExport_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e) {
			if(e.CloseMode != DevExpress.XtraEditors.PopupCloseMode.Normal) return;
			int index = cmbExport.Properties.Items.IndexOf(e.Value);
			if (index != -1)
				ExportByIndex(index);
		}

        private void cmbEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
    public class Helper
    {
		public const int ICC_USEREX_CLASSES = 0x00000200;

		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public class INITCOMMONCONTROLSEX {
			public int  dwSize = 8; //ndirect.DllLib.sizeOf(this);
			public int  dwICC;
		}
		[DllImport("comctl32.dll")]
		public static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string libname);
		
		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);
		
		public static string GetReportPath(DevExpress.XtraReports.UI.XtraReport fReport, string ext) {
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			string repName = fReport.Name;
			if(repName.Length == 0) repName = fReport.GetType().Name;
			string dirName = Path.GetDirectoryName(asm.Location);
			return Path.Combine(dirName, repName + "." + ext);
		}
        public static string GetRelativePath(string name) {
            return DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\\" + name);
		}
		public static string GetRelativeStyleSheetPath(string styleSheetPath) {
			int index = styleSheetPath.LastIndexOf(@"\");
			return GetRelativePath(styleSheetPath.Substring(++index));
		}
		public static Image LoadImage(string name) {
			Bitmap bmp = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("XtraReportsDemos." + name));
			bmp.MakeTransparent(Color.Magenta);
			return bmp;
		}
	}
    public class ReportNames
    {
		public const string
			MailMerge = "Mail Merge",
			OddEvenStyles= "Products by Categories",
			NorthwindTraders_Products = "Products List",
			NorthwindTraders_Catalog = "Fall Catalog",
			NorthwindTraders_Invoice = "Invoice",
			MasterDetailReport = "Suppliers",
			MultiColumnReport = "Customers",
			IListDatasource= "Fishes",
			CustomDraw = "Population",
			ShrinkGrow = "Employees",
			BarCodes_ProductLabels = "Product Labels",
			BarCodes_BarcodeTypes = "Barcode Types",
			RichText= "Cars",
			Subreports= "Customers List",
			TableReport = "Customer Order",
			TreeView= "Countries",
			Charts= "Prices",
			Shapes = "Shapes";
	}
}
