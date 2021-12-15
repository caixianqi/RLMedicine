using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class WorkCountQuery : Form
    {
        public bool bReport = false;

        public bool bComplete = false;


        public bool State = false;

        public DateTime _BeginTime;

        public DateTime _EndTime;


        public DateTime _CompleteBeginTime;

        public DateTime _CompleteEndTime;



        public WorkCountQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (breport.Checked)
            {
                bReport = breport.Checked;
                _BeginTime = this.BeginTime.Value;
                _EndTime = this.EndTime.Value;


            }

            if (bcomplete.Checked)
            {
                bComplete = bcomplete.Checked;
                _CompleteBeginTime = this.CompleteBeginTime.Value;
                _CompleteEndTime = this.CompleteEndTime.Value;


            }

            this.State = true;
            this.Close();
        }

        private void WorkCountQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.State = false;
        }
    }
}
