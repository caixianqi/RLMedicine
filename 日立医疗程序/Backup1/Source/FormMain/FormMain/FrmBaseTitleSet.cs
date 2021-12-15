using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormMain
{
    public partial class FrmBaseTitleSet : Form
    {
        System.Data.DataTable table1;
        public FrmBaseTitleSet()
        {
            InitializeComponent();
            
            BtnFunction.BaoSQL = "select a.Param,a.FunctionName from TFunctions a "+
                                 ",TFunctionChild b where a.Param=b.param";
        }

        private void FrmBaseTitleSet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss="SELECT syscolumns.name ColumnName,systypes.name,syscolumns.isnullable,syscolumns.length "+
                        "FROM syscolumns, systypes "+
                        "WHERE syscolumns.xusertype = systypes.xusertype "+
                        "AND syscolumns.id = object_id('"+textBox1.Text+"')";

            ss = "select a.ColumnName,b.ColumnTitle,b.Width from (" + ss + ") a left outer join (select * from TColumnTitle where FunctionId='" + textBox2.Text + "') b on a.ColumnName=b.ColumnName  ";
            table1=Bao.DataAccess.DataAcc.ExecuteQuery(ss);
            gridControl1.DataSource = table1;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string ss = "delete TColumnTitle where FunctionId='" + textBox2.Text + "'";
            Bao.DataAccess.DataAcc.ExecuteNotQuery(ss);
            foreach (System.Data.DataRow row1 in table1.Rows)
            {
                if (row1.RowState != DataRowState.Deleted)
                {
                    Bao.DataAccess.DataAcc.ExecuteNotQuery(
                        "insert into TColumnTitle (FunctionId,ColumnName,ColumnTitle,Width) values ('" +
                        textBox2.Text + "','" + row1["ColumnName"].ToString().Trim() + "','" + row1["ColumnTitle"].ToString().Trim() + "','" +
                        row1["Width"].ToString().Trim() + "')"
                        );
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void btnTableName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            textBox1.Text = e.ReturnRow1["name"].ToString();
            
        }

        private void BtnFunction_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            textBox2.Text = e.ReturnRow1["Param"].ToString();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            btnTableName.BaoSQL = "select name from "+textBox3.Text.Trim()+"..sysobjects  where xtype='u'";
        }
    }
}
