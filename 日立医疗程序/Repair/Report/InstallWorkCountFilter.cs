using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class InstallWorkCountFilter : Form
    {
        public  DateTime _TaskBeginTime;
        public  DateTime _TaskEndTime;
        public  DateTime _AppointBeginTime;
        public  DateTime _AppointEndTime;
        public  DateTime _CompleteBeginTime;
        public  DateTime _CompleteEndTime;

        public  bool _bTask;

        public  bool _bAppoint;

        public  bool _bComplete;

        public  bool _State = false;

        public InstallWorkCountFilter()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AppointBeginTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AppointEndTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bTask.Checked)
            {
                _bTask = bTask.Checked;
                _TaskBeginTime = this.TaskBeginTime.Value;
                _TaskEndTime = this.TaskEndTime.Value;

            }
            if (bappoit.Checked)
            {
                _bAppoint = bappoit.Checked;
                _AppointBeginTime = this.AppointBeginTime.Value;
                _AppointEndTime = this.AppointEndTime.Value;
                

            }

            if (bcomplete.Checked)
            {
                _bComplete = bcomplete.Checked;
                _CompleteBeginTime = this.CompleteBeginTime.Value;
                _CompleteEndTime = this.CompleteEndTime.Value;
              

            }

            _State = true;

            this.Close();
        }
    }
}
