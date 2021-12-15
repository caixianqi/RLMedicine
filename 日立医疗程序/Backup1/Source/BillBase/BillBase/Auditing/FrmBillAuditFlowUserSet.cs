using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：此类为窗体类，用于实现单据流程人员的管理（添加、删除、更新、查询并显示数据）
    /// </summary>
    public partial class FrmBillAuditFlowUserSet : Form
    {
        //是否状态
        public bool isNew = false;
        public bool isUpdate = false;

        //用户ID
        public string userId = "";
        //审批结点
        public string auditNode = "";
        //功能编号
        private string funcId = "";
        //审批类型
        private string auditType = "";
        //流程编号
        private int auFlowId;
        //结点ID
        private string auditNodeId;

        public string AuditNodeId
        {
            get { return auditNodeId; }
            set { auditNodeId = value; }
        }

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

        //定义人员输入窗口
        private FrmBillAuditFlowUserInput flowUserInput;

        public FrmBillAuditFlowUserSet(string funId, int autoFlowId, string auNodeName, string auditType, string auditNodeId)
        {
            InitializeComponent();
            this.funcId = funId;
            this.auNodeName = auNodeName;
            this.auditType = auditType;
            this.auditNodeId = auditNodeId;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (flowUserInput == null || flowUserInput.IsDisposed)
            {
                flowUserInput = new FrmBillAuditFlowUserInput(this);
                flowUserInput.Hide();
                this.AddOwnedForm(flowUserInput);
            }
            this.AuFlowId = autoFlowId;


            //显示该窗口的为this的子窗口

            try
            {
                //加载绑定所有数据
                DataBindAllUser();
            }
            catch (Exception)
            {
                MessageBox.Show("数据不能加载！");  
            }
            
        }

        /// <summary>
        /// 绑定所有数据
        /// </summary>
        private void DataBindAllUser()
        {
            this.gridControlAllUser.DataSource = AuditBillFlowUserSetManager.GetAuditUserSets(FuncId, auFlowId, auditType);
        }

        //为输入窗口输入文本设置内容
        public void SetValues()
        {
            DataRow selRow = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (selRow != null)
            {
                flowUserInput.txtAutoFlowId.Text = selRow["AutoFlowId"].ToString();
                flowUserInput.txtAuditUserName.Text = selRow["UserName"].ToString();
                flowUserInput.txtOrderId.Text = selRow["OrderId"].ToString();
                flowUserInput.txtAuditNode.Text = selRow["AuditNode"].ToString();
                this.auditType = selRow["AuditType"].ToString().Trim();

                this.auType = selRow["AuditType"].ToString().Trim();
                this.auditNode = selRow["AuditType"].ToString().Trim();
                this.auditNodeId = selRow["AuditNodeId"].ToString();

            }
        }

        #region //删除

        //删除事件
        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
           // flowUserInput.Show();
            //获得表中选中的数据行
            DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
            int aFlowId = Convert.ToInt32(row["AutoFlowId"]);
            string auditUserId = row["AuditUserId"].ToString();
            int orderId = Convert.ToInt32(row["OrderId"]);
            try
            {
                DialogResult result = MessageBox.Show("是否删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //调用删除人员方法
                    AuditBillFlowUserSetManager.Delete(aFlowId, auditUserId, orderId);
                    //重新绑定
                    DataBindAllUser();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("数据访问错误！");
            }
        }
        #endregion

        //双击关闭
        private void baoButtonAuditUserName_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            flowUserInput.txtAuditUserName.Text = e.ReturnRow1["userName"].ToString();           
        }

        //双击关闭
        private void baoButtonAutoFlowId_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            flowUserInput.txtAutoFlowId.Text = e.ReturnRow1["AutoFlowId"].ToString();
        }

        //新增
        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {

            isNew = true;
            DataRow selRow = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            flowUserInput.Show();
            flowUserInput.SetBaoBtnBaoSQLandTitleName(this.auFlowId, this.auditType.Trim(), this.funcId, this.auditNodeId);
            //清空文本
            CommonMethod.TextClear(flowUserInput);
            CommonMethod.SetEnable(flowUserInput.txtOrderId, false);
            
            flowUserInput.txtAuditNode.Text = auNodeName;

            //获得流程结点审批人员的最大顺序
            try
            {
                
                    //获得流程结点审批人员的最大顺序
                    int maxOrder = AuditBillFlowUserSetManager.GetMaxOrderIdByautoFlowId(auFlowId);
                    maxOrder += 1;
                    flowUserInput.txtOrderId.Text = maxOrder.ToString();
              
            }
            catch (Exception)
            {
                MessageBox.Show("数据访问不成功！");
                throw;
            }
            

        }


        #region 添加或保存
        //获得选择的数据
        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {

            try
            {
                //获取输入的数据
                 string newAuditUserId = flowUserInput.txtAuditUserName.Text.Trim();
                int newOrderId = 0;
                if (flowUserInput.txtOrderId.Text.Trim() != null)
                {
                    newOrderId = Convert.ToInt32(flowUserInput.txtOrderId.Text.Trim());
                }
                string auditUserId = "";
                int orderId = 0;
                DataRow row = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
              
                if (isNew)
                {
                    try
                    {
                        //添加单据流程审批人员
                        AuditBillFlowUserSetManager.Insert(this.auFlowId, this.userId);
                        isNew = false;
                    }
                    catch (Exception)
                    {
                        ChangeSaveStateToEnable(true);
                        MessageBox.Show("添加不成功，因同一审批结点不能存在相同的审批人员存，请重新选择！", "操作提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if(isUpdate)
                {
                    //验证输入
                    if (!flowUserInput.CheckInput())
                    {
                        return;
                    }

                    int newAutoFlowId = Convert.ToInt32(flowUserInput.txtAutoFlowId.Text.Trim());
               
                    //获得选择的数据
                    
                    if (row != null)
                    {
                        auditUserId = row["AuditUserId"].ToString();
                        orderId = Convert.ToInt32(row["OrderId"]);
                        isUpdate = false;
                        try
                        {
                            //更新单据流程审批人员
                            AuditBillFlowUserSetManager.Update(
                                int.Parse(row["AutoFlowId"].ToString()), auditUserId, orderId, newAutoFlowId, this.userId, newOrderId);
                            
                            
                        }
                        catch (Exception)
                        {
                            ChangeSaveStateToEnable(true);
                            MessageBox.Show("更新不成功，因同一审批结点不能存在相同的审批人员，请重新选择！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    CommonMethod.SetEnable(flowUserInput.txtOrderId, false);
                }
                flowUserInput.txtAuditNode.Text = auNodeName;
                
                //重新绑定
                DataBindAllUser();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        #endregion

        //点击修改
        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            
            isUpdate = true;
            SetValues();
            try
            {
                //if (flowUserInput.IsDisposed)
                //{
                //    flowUserInput = new FrmBillAuditFlowUserInput(this);
                //}

                //this.AddOwnedForm(flowUserInput);
                flowUserInput.Show();

                isNew = false;
               
                    //为输入窗体的SQL传参数
                flowUserInput.SetBaoBtnBaoSQLandTitleName(this.auFlowId,this.auditType.Trim(),this.funcId,this.auditNodeId);

                    //this.userId = row["AuditUserId"].ToString();
              
                //设置顺序文本的可用状态
                CommonMethod.SetEnable(flowUserInput.txtOrderId, true);
            }
            catch (Exception)
            {
                MessageBox.Show("获取数据不成功！");
            }
            
        }

        //退出
        private void toolBarBill1_OnBaoExit(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //双击表格
        private void gridControlAllUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            isUpdate = true;
            SetValues();
            try
            {
                //设置文本的可用状态
                CommonMethod.SetEnable(flowUserInput.txtOrderId, true);
                //设置工具栏按钮可用状态
                this.toolBarBill1.BtnSave.Enabled = true;
                this.toolBarBill1.BtnAddNew.Enabled = false;
                this.toolBarBill1.BtnModify.Enabled = false;

                
                //为输入窗体的SQL传参数
                flowUserInput.SetBaoBtnBaoSQLandTitleName(this.auFlowId, this.auditType.Trim(), this.funcId, this.auditNodeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据不成功！");
                Console.WriteLine(ex.Message);
            }
            //显示该窗口为this的子窗口
            flowUserInput.Show();

        }

        //改变保存状态
        public void ChangeSaveStateToEnable(bool flag)
        {
            toolBarBill1.BtnSave.Enabled = (flag==true ? true : false);
            toolBarBill1.BtnAddNew.Enabled = (flag == true ? false : true);
            toolBarBill1.BtnModify.Enabled = (flag == true ? false : true);
        }

        private void gridControlAllUser_Click(object sender, EventArgs e)
        {

        }

        private void FrmBillAuditFlowUserSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            flowUserInput.CloseFlag = true;
            flowUserInput.Close();
            e.Cancel = false;
        }


    }
}
