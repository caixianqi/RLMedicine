using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase.Audit.JFWUserSet
{
    /// <summary>
    /// 功能描述：此类为窗体类，用于实现提交流程人员的管理（添加、删除、更新、查询并显示数据）
    /// </summary>
    public partial class FrmFlowUserSet : Form
    {
        //是否状态
        public bool isNew = false;
        public bool isUpdate = false;

        //用户ID
        public string userId = "";
        //审批结点
        public string auditNodeName = "";
        //功能编号
        private string funcId = "";
        //审批类型
        private string auditType = "";
        //流程编号
        private int auFlowId;

        public int AuFlowId
        {
            get { return auFlowId; }
            set { auFlowId = value; }
        }

        public string AuditType
        {
            get { return auditType; }
            set { auditType = value; }
        }

        public string FuncId
        {
            get { return funcId; }
            set { funcId = value; }
        }

        private string auType = "";

        public string AuType
        {
            get { return auType; }
            set { auType = value; }
        }

        private string auNodeName = "";

        public string AuNodeName
        {
            get { return auNodeName; }
            set { auNodeName = value; }
        }


        public FrmFlowUserSet()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


    }
}
