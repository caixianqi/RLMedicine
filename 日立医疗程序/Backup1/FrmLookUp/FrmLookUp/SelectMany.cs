using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrmLookUp
{
    [DefaultEvent("OnLookUpClosed")]
    public partial class SelectMany : Form
    {
        public IList<string> SelectList = new List<string>();

        public GetResultRow objResutlRow;

        public event LookUpClosed OnLookUpClosed;

        public delegate void LookUpClosed(object sender, LookUpEventArgs e);

        private DataTable SourceTable { get; set; }

        public SelectMany()
        {
            InitializeComponent();

            



        }

       

        public void Init(DataTable SelectTable,string KeyColumn)
        {
            try
            {


                SelectTable.Columns.Add("IsSelect", typeof(bool)) ;

               

               SelectTable.Columns["IsSelect"].DefaultValue = false;

                SourceTable = SelectTable.Copy();

                this.gridControl1.DataSource = SourceTable;
            }
            catch (Exception ex)
            {

            }
        }

        public void Resultrow(System.Data.DataRow row1)
        {
            if (OnLookUpClosed != null)
            {
                OnLookUpClosed(this, new LookUpEventArgs(row1));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < ((DataTable)this.gridControl1.DataSource).Rows.Count; i++)
            {
                if (SourceTable.Rows[i]["IsSelect"].ToString() == "False")
                {
                    SourceTable.Rows[i].Delete();
                }
            }
            SourceTable.AcceptChanges();

            if (SourceTable.Rows.Count == 0)
            {
                Resultrow(((DataTable)this.gridControl1.DataSource).NewRow());
                this.Close();

                return;
            
            }


            Resultrow(((DataTable)this.gridControl1.DataSource).Rows[0]);

            this.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataRow item in  SourceTable.Rows)
            {
                item["IsSelect"] = true;
            }

            this.gridControl1.DataSource = SourceTable;
        }

        private void SelectMany_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in SourceTable.Rows)
            {
                item["IsSelect"] = false;
            }

            this.gridControl1.DataSource = SourceTable;
        }
    }
}
