using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：实现流程的选择，并添加流程至审批的流程中
    /// </summary>
    public partial class FrmBillAuditFlowSearch : Form
    {

        private string funcId;

        public string FuncId
        {
            get { return funcId; }
            set { funcId = value; }
        }

        private string flowFlag;

        public string FlowFlag
        {
            get { return flowFlag; }
            set { flowFlag = value; }
        }


        public FrmBillAuditFlowSearch()
        {
            InitializeComponent();
        }

        public FrmBillAuditFlowSearch(string funcId,string flowFlag)
        {
            InitializeComponent();
            gridControlFlowSearchSet.DataBindings.Clear();
            //绑定审批流程号和流程名称数据表
            gridControlFlowSearchSet.DataSource = AuditFlowSearchManager.GetAllSearchFlowList(flowFlag);
            this.funcId = funcId;
            if (flowFlag == "0")
            {
                this.Text = "选择提交流程";
            }
            else
            {
                this.Text = "选择检索流程";
            }
        }


        private void gridControlFlowSearchSet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRow selRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            string message = "";
            //添加流程至审批流程中
            bool flag = AuditFlowSearchManager.SearchFlowSet(selRow["FlowId"].ToString(), funcId.Trim(),flowFlag, out message);
            if (!flag)
            {
                MessageBox.Show(message);
            }
            this.Dispose();
        }

           
    }
}
