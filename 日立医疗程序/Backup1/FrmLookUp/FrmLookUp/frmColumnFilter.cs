using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FrmLookUp
{
    public partial class frmColumnFilter : Form
    {
        private System.Data.DataTable table1=new DataTable("Columns");
        public string ParentFormCaption="";
        public DevExpress.XtraGrid.Views.Grid.GridView SourceGridView;
        public frmColumnFilter()
        {
            
            InitializeComponent();
            table1.Columns.Add("ColumnCaption", System.Type.GetType("System.String"));
            table1.Columns.Add("IsVisable",System.Type.GetType("System.Boolean") );
            this.dataGridView1.DataSource = table1;
            if (!Directory.Exists(Application.StartupPath + "\\XML\\"))   
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\XML\\");  


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SetGridVisableInfo();
        }
        public void SetGridVisableInfo()
        {
            foreach (System.Data.DataRow row1 in table1.Rows)
            {
                for (int i = 0; i < SourceGridView.Columns.Count; i++)
                {
                    if (row1["ColumnCaption"].ToString().Trim() == SourceGridView.Columns[i].Caption.Trim())
                        SourceGridView.Columns[i].Visible = Boolean.Parse(row1["IsVisable"].ToString());
                }
            }
            table1.WriteXml(Application.StartupPath + "\\XML\\" + ParentFormCaption + ".xml");   
        }
        public void ReadInitVisableInfo()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\XML\\" + ParentFormCaption + ".xml"))
            {
                table1.ReadXml(Application.StartupPath + "\\XML\\" + ParentFormCaption + ".xml");
                SetGridVisableInfo();
            }
            
        }
        private void frmColumnFilter_Activated(object sender, EventArgs e)
        {
           
        }
        public void ReadGridVisableInfo()
        {
            if (SourceGridView == null)
            {
                throw new Exception("必须将要过滤的网格付给SourceGridView属性。");
            }
            table1.Rows.Clear();
            for (int i = 0; i < SourceGridView.Columns.Count; i++)
            {
                System.Data.DataRow row1 = table1.NewRow();
                row1["ColumnCaption"] = SourceGridView.Columns[i].Caption;
                row1["IsVisable"] = SourceGridView.Columns[i].Visible;
                table1.Rows.Add(row1);
            }
        }
        private void frmColumnFilter_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
