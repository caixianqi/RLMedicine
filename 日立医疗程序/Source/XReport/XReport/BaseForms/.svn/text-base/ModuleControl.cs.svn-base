using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.DXperience.Demos;

namespace XtraReportsDemos
{
	/// <summary>
	/// Summary description for ModuleControl.
	/// </summary>
    public class ModuleControl : TutorialControlBase
    {
		protected XtraReport fReport;
        protected string fileName = "";

        public System.Data.DataSet DataSource;
        public void LoadLayoutAndDataSet(XtraReport mreport)
        {
            if (File.Exists(fileName))
                mreport.LoadLayout(fileName);
            mreport.DataSource = DataSource;
        }
		public ModuleControl() {
		}
				
		public virtual XtraReport Report { 
			get { return fReport; } 
			set { fReport = value; }
		}	
			
		public virtual void Activate() {
			Report = CreateReport();
            LoadLayoutAndDataSet(Report);
            Report.CreateDocument();
			//File.Delete(fileName);
		}
		protected virtual XtraReport CreateReport() {
			return null;
		}
	}
}
