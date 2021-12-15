using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SetFunctionList
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable("dTable");
        System.Data.DataSet data1 = new DataSet();
           
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add(new DataColumn("FunctionId", typeof(string)));
            dt.Columns.Add(new DataColumn("DLLName", typeof(string)));
            dt.Columns.Add(new DataColumn("WorkName", typeof(string)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("TitleGroup", typeof(string)));
            gridControl1.DataSource = dt;
            System.Data.DataRow row1 = dt.NewRow();
            dt.Rows.Add(row1);
            data1.Tables.Add(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            System.Data.DataRow row1 = dt.NewRow();
            dt.Rows.Add(row1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data1.WriteXml("SFDll.XML", System.Data.XmlWriteMode.WriteSchema);
        }
    }
}
