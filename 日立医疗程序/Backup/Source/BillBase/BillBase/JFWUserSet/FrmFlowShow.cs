using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bao.BillBase;

namespace Bao.BillBase.Audit.JFWUserSet
{
    public partial class FrmFlowShow : Form
    {
        public System.Data.DataTable TUsers;
        private string funcId;
        private string jfwId;
        private string flowFlag;

        public string FlowFlag
        {
            get { return flowFlag; }
            set { flowFlag = value; }
        }

        public string FuncId
        {
            get { return funcId; }
            set { funcId = value; }
        }

        public string JFWId
        {
            get { return jfwId; }
            set { jfwId = value; }
        }
       

        public FrmFlowShow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funId">功能编号</param>
        /// <param name="mBillId">具体交付物编号</param>
        /// <param name="flowFlag">0:提交审批流程,1:检索审批流程</param>
        public FrmFlowShow(string funId,string mJFWId, string flowFlag,System.Data.DataTable  mAuditUsers)
        {
            InitializeComponent();
            this.funcId = funId;
            this.flowFlag = flowFlag;
            this.JFWId = mJFWId;
            TUsers = mAuditUsers;

            this.StartPosition = FormStartPosition.CenterScreen;


            if (flowFlag == "0")
            {
                this.Text = "提交审批流程";
            }
            else
            {
                this.Text = "检索审批流程";
            }
            try
            {
                //绑定单据审批流程数据
                dataBindingAuditDefin();
            }
            catch (Exception ee)
            {
                MessageBox.Show("数据加载不成功！"+ee.Message );
            }
        }

        #region //绑定单据审批流程数据
        //绑定数据
        public void dataBindingAuditDefin()
        {
            this.DataBindings.Clear();
            this.gridControlAuditDefine.DataSource = null;
            //if ()
            this.gridControlAuditDefine.DataSource = Bao.BillBase.Audit.AuditBillFlowManager.GetAuditFlwDefines(FuncId, "0"); //提交流程
            this.gridControl1.DataSource = TUsers;
        }
        #endregion

        private void gridControlAuditDefine_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void gridControlAuditDefine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.gridView1.FocusedRowHandle < 0)
            //{
            //    MessageBox.Show("请选择数据行！");
            //    return;
            //}
            //DataRow row = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            //int auFlowId = Convert.ToInt32(row["AutoFlowId"]);
            //string auditNodeName = row["auditNode"].ToString();
            //string auditNodeId = row["AuditNodeId"].ToString();
            //string auditType = row["AuditType"].ToString();
            //Bao.BillBase.Audit.AuditManager.OpenFrmBillAuditFlowUserSet(this.funcId.Trim(), auFlowId, auditNodeName,auditType,auditNodeId);
           
        }

        private void gridControlAuditDefine_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                TUsers.DefaultView.RowFilter =
                    "AutoFlowId='" + this.gridView1.GetDataRow(gridView1.FocusedRowHandle)["AutoFlowId"].ToString().Trim()
                     + "' and JFWId='" + this.jfwId + "'";
                if (this.gridView1.GetDataRow(gridView1.FocusedRowHandle)["AuditType"].ToString().Trim() == "0")  //选择人员
                {
                    BtnAddUser.BaoSQL = "select b.* from AuditNode_User a ,Users  b where a.AutoUserId=b.AutoUserId and AuditNodeId='" + this.gridView1.GetDataRow(gridView1.FocusedRowHandle)["AuditNodeId"].ToString().Trim() + "'";
                    BtnAddUser.BaoTitleNames = "UserId=用户编码,UserName=用户名称";
                }
                else  //选择角色
                {
                    BtnAddUser.BaoSQL = "select RoleId AutoUserId,RoleName UserName from AuditRole_User a   ";
                    BtnAddUser.BaoTitleNames = "AutoUserId=角色编码,UserName=角色名称";
                }
            }
            
        }

        private void BtnAddUser_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int i = TUsers.DefaultView.Count + 1;
            
            //foreach (System.Data.DataRow row2 in TUsers.Rows )
            //{
            //    if (int.Parse(row2["OrderId"].ToString())>i) 
            //        i=int.Parse(row2["OrderId"].ToString());
                
            //}
            System.Data.DataRow row1 = TUsers.NewRow();
            row1["AutoFlowId"] = this.gridView1.GetDataRow(gridView1.FocusedRowHandle)["AutoFlowId"].ToString().Trim();
            row1["AuditUserId"] = e.ReturnRow1["AutoUserId"].ToString();
            row1["UserName"] = e.ReturnRow1["UserName"].ToString();
            row1["JFWId"] = JFWId;
            row1["OrderId"] = i;
            TUsers.Rows.Add(row1);


        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gridView3.GetDataRow(gridView3.FocusedRowHandle).Delete();
        }
    }
}
