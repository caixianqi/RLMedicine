using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase
{
    /// <summary>
    /// 基本资料的编辑界面基类，所有编辑界面从该类继承
    /// </summary>
    public partial class LookUpBasis : Form
    {
        public Frmbasis IParentForm;
        public Boolean CloseFlag = false;
        public System.Data.DataTable TableList;
       
        public LookUpBasis()
        {
            InitializeComponent();
        }
        public static System.Data.DataTable GetFormType(string ParamId)
        {
            string sql = "select * from TFunctionChild where Param='"+ParamId +"' ";
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
        

        private void LookUpBasis_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseFlag)
            {
                this.Visible = false;
                e.Cancel = true;
                if (IParentForm!=null)
                IParentForm.OnClosed();
            }
        }
        public DataTable GetColumnTitles(string FunctionId)
        {
            return Bao.DataAccess.DataAcc.ExecuteQuery("select * from TColumnTitle where FunctionId='" + FunctionId + "' ");
        }
        

    }
}
