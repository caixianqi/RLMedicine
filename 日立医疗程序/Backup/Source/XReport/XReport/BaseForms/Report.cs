using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace XtraReportsDemos
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Report(string repxName)
        {
            InitializeComponent();
            Name = repxName;
        }
        public Report()
        {
            InitializeComponent();
        }
        
    }
}
