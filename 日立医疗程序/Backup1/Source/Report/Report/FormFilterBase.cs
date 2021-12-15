using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bao.Report
{

    public partial class FormFilterBase : Bao.FormChildBase
    {
        public DataSet dataset1=new DataSet();
        public delegate void ExecSQL(object sender, EventArgs e);
        public delegate void SearchWhere1();
        public delegate void ExecParent();
        public event ExecSQL OnExceSQL;
        public event SearchWhere1 OnSearchWhere;
        public ExecParent OnExecParent;
        private string _sql = "";
        
        public string Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        private System.Data.DataTable _SearchWhere;

        public System.Data.DataTable SearchWhere
        {
            get { return _SearchWhere; }
            set { _SearchWhere = value; }
        }
        private System.Data.DataTable _DataSourceTable;

        public System.Data.DataTable DataSourceTable
        {
            get { return _DataSourceTable; }
            set { _DataSourceTable = value; }
        }
        public DevExpress.XtraGrid.GridControl SourceGrid;
        public FormFilterBase()
        {
            InitializeComponent();
            
        }

        public virtual string OnSQL()
        {
            return "";
        }
        public void button1_Click(object sender, EventArgs e)
        {
            dataset1.Tables.Clear();
            OnSearchWhere();
            string Sql = OnSQL();
            if (Sql != "")
            {
                DataSourceTable = Bao.DataAccess.DataAcc.ExecuteQuery(Sql);

            }
            else
            {
                if (OnExceSQL != null)
                {
                    OnExceSQL(this, e);
                    if (DataSourceTable == null)
                    {
                        throw new Exception("û�ж�OnSQL ���Ը�ֵ��OnExceSQL �¼���û�н����ղ����ı�������ֵ��DataSourceTable����");
                    }
                    
                }

            }
            if (SearchWhere == null)
            {
                throw new Exception("OnSearchWhere �¼���û�н����ղ����ı�������ֵ��SearchWhere����");
            }
            dataset1.Tables.Add(DataSourceTable);
            dataset1.Tables.Add(SearchWhere);
            
            OnExecParent();

            this.Hide();
        }
      
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormFilterBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            //e.Cancel = true;
        }
       
        
        
        
    }
}