using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：审核信息录入窗体，并提交审核结果
    /// </summary>
    public partial class FrmBillAudit : Form, Bao.BillBase.Auditing.IAuditFrm
    {
        public Bao.BillBase.Auditing.AuditBillFace BillEntity=new Bao.BillBase.Auditing.AuditBillFace();
        BillBase BillBaseObj;

        private string FrmCaption;
        //public System.Data.DataTable flowOfFlowLineTable;
        public FrmBillAudit()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 带参数的单据构造方法
        /// </summary>
        /// <param name="sender">单据实体对象</param>
        /// <param name="userId">审批人员</param>
        /// <param name="frmCaption">单据窗体标题</param>
        public FrmBillAudit(BillBase sender, string userId,string frmCaption)
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                FrmCaption = frmCaption;
                BillBaseObj = sender;
                this.BillEntity.Init(sender.BillId ,sender.FunctionId , userId, this);
                ExecuteBaoBtn();

                //禁用文本
                CommonMethod.SetEnable(txtEmpLevel, false);
                CommonMethod.SetEnable(txtAuditNum, false);
                //CommonMethod.SetEnable(txtFee, false);

                //flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(thisBillId, thisFunctionId, thisAuditNum, "0");
                //this.gridControl1 .DataSource = flowOfFlowLineTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误，原因："+ex.Message);
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="billId">单据编号</param>
        /// <param name="functionId">功能编号</param>
        /// <param name="userId">审核人</param>
        public FrmBillAudit(string billId, string functionId, string userId)
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;


                this.BillEntity.Init(billId, functionId, userId, this);
                ExecuteBaoBtn();

                //禁用文本
                CommonMethod.SetEnable(txtEmpLevel, false);
                CommonMethod.SetEnable(txtAuditNum, false);
                //CommonMethod.SetEnable(txtFee, false);

                //flowOfFlowLineTable = AuditBillManager.GetAuditFlowOfAuditFlowLine(thisBillId, thisFunctionId, thisAuditNum, "0");
                //this.gridControl1 .DataSource = flowOfFlowLineTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误，原因：" + ex.Message);
            }
        }
        //设置sql
        private void ExecuteBaoBtn()
        {
            //this.baoBtnEmpLevel.BaoSQL = "select LevelId, LevelName, Fee from BaoProject..EmpLevel";
            //this.baoBtnEmpLevel.BaoTitleNames = "LevelId=等级编号,LevelName=等级名称,Fee=分数";
        }

        //为表单赋值
       
        /// <summary>
        /// 添加审批单据
        /// </summary>
        /// <param name="audtiFlag">审批标记</param>
        /// <param name="flowFlag">流程标志，0为提交，1为检索</param> 
        //private void UpdateAuditBill(string auditFlag,string flowFlag)
        //{
        //    string memo = this.txtMemo.Text;
        //    //调用业务逻辑更新该审核的单据
        //    AuditBillManager.UpdateAuditFlowLine(autoId, thisUserId, auditFlag, scoreLevel, score, memo, flowFlag);

        //}

        #region 验证输入

        /// <summary>
        /// 验证输入数据
        /// </summary>
        /// <returns>是否正确输入</returns>
        private bool CheckInput()
        {
            if (txtEmpLevel.Text == "")
            {
                MessageBox.Show("请选择分数等级！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtMemo.Text == "")
            {
                MessageBox.Show("请输入审批意见！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemo.Focus();
                return false;
            }
            else if (System.Text.Encoding.GetEncoding("GB2312").GetBytes(txtMemo.Text).Length > 2000)
            {
                MessageBox.Show("审批意见信息太长，请控制在1000字以内！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemo.Focus();
                return false;
            }
            else if (txtAuditNum.Text.Trim() == "")
            {
              
                return false;
			} else if (rdoAgree.Checked == false && rdoDisAgree.Checked == false) {
			    MessageBox.Show("请选择同意或不同意！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			    return false;
			}
            return true;
        }
        #endregion



        /// <summary>
        /// 双击关闭选择分数等级窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void baoBtnEmpLevel_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            try
            {
                this.textBox1.Text =e.ReturnRow1["Fee"].ToString();
                //this.txtFee.Text = e.ReturnRow1["Fee"].ToString();
                this.txtEmpLevel.Text = e.ReturnRow1["LevelId"].ToString();
                this.BillEntity.scoreLevel = e.ReturnRow1["LevelId"].ToString();
                this.BillEntity.score = Convert.ToInt32(e.ReturnRow1["Fee"]);
            }
            catch (Exception)
            {

                MessageBox.Show("您选择的表中没有对应的数据！");
            }
        }

		private void btnOk_Click(object sender, EventArgs e) {
			string flowFlag = "0";
			//验证输入数据
			if (!CheckInput()) {
				return;
			}

			if (rdoNot.Checked == true) {
				//0为标记为未审核
				Bao.BillBase.Auditing.AuditBillFace.AuditState = 0;

			} else if (rdoAgree.Checked == true) {
				//1为标记审核已通过

				Bao.BillBase.Auditing.AuditBillFace.AuditState = 1;
			} else if (rdoDisAgree.Checked == true) {
				//调用业务逻辑更新该审核的单据的内容
				Bao.BillBase.Auditing.AuditBillFace.AuditState = 2;
			}
			this.BillEntity.Memo = this.txtMemo.Text;
			if (BillBaseObj != null) {
				SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
				Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
				try {
					this.BillEntity.UpdateAuditBill(Bao.BillBase.Auditing.AuditBillFace.AuditState.ToString(), flowFlag);
					////update090901
					if (Bao.BillBase.Auditing.AuditBillFace.AuditState == 1) { //同意
						if (this.textBox1.Text.Trim()!="0")
							BillBaseObj.Rating(double.Parse(this.textBox1.Text));  //评分
						if (Bao.BillBase.Audit.AuditBillManager.IsAudited(BillBaseObj.FunctionId, BillBaseObj.BillId, "0")) { //所有人审核完成
							BillBaseObj.Audit();            //修改该单据的审核标记，并进行审核前或审核后处理
							
							//所有人审核完，给申请人发送消息
							string NextAuditUserId = Bao.DataAccess.DataAcc.ExecuteScalar("select AutoUserId from users where UserName='" + BillBaseObj.ReturnCreateUserFieldName() + "' ");
							Bao.Message.CMessage.SendMessage("恭喜您, " + this.FrmCaption + " 审核通过！", "", NextAuditUserId, UFBaseLib.BusLib.BaseInfo.UserId, BillBaseObj.TempId, BillBaseObj.BillId);
						} else {///给下一个审核人员发送消息
							string NextAuditUserId = "";
							string TiShi = "";
							NextAuditUserId = Bao.BillBase.Audit.AuditBillManager.NextAuditUser(BillBaseObj.FunctionId, BillBaseObj.BillId, UFBaseLib.BusLib.BaseInfo.UserId, "0");
							TiShi = "请审批";
							if (NextAuditUserId != "")
								Bao.Message.CMessage.SendMessage(TiShi + this.FrmCaption, "", NextAuditUserId, UFBaseLib.BusLib.BaseInfo.UserId, BillBaseObj.TempId, BillBaseObj.BillId);
						}
					} else if (Bao.BillBase.Auditing.AuditBillFace.AuditState == 2) { //不同意
						BillBaseObj.Rating(0);
						string NextAuditUserId = Bao.DataAccess.DataAcc.ExecuteScalar("select AutoUserId from users where UserName='" + BillBaseObj.ReturnCreateUserFieldName() + "' ");
						Bao.Message.CMessage.SendMessage("打回" + this.FrmCaption, "", NextAuditUserId, UFBaseLib.BusLib.BaseInfo.UserId, BillBaseObj.TempId, BillBaseObj.BillId);

					}
					sqlTran.Commit();
				} catch (Exception ex) {
					sqlTran.Rollback();
					throw new Exception(ex.Message);
				}
				this.Close();
				this.Dispose();
			} else {
				this.DialogResult = DialogResult.OK;
			}
			////

		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Bao.BillBase.Auditing.AuditBillFace.AuditState = 0;
            this.Dispose();
        }

        #region IAuditFrm 成员
        /// <summary>
        /// 将单据实体中的数据付值到界面
        /// </summary>
        public void BaoDataBinding()
        {
            try
            {
                txtAuditNum.Text = BillEntity.billTable.Rows[0]["AuditNum"].ToString();
                this.BillEntity.autoId  = Convert.ToInt32(BillEntity.billTable.Rows[0]["AutoId"].ToString());
                this.BillEntity.thisAuditFlag = BillEntity.billTable.Rows[0]["AuditFlag"].ToString();
                txtMemo.Text = BillEntity.billTable.Rows[0]["Memo"].ToString();
                txtEmpLevel.Text = BillEntity.billTable.Rows[0]["ScoreLevel"].ToString();
                this.textBox1.Text = BillEntity.billTable.Rows[0]["Score"].ToString();
                if (this.BillEntity.thisAuditFlag == "0")
                {
                    rdoNot.Checked = true;
                }
                else if (this.BillEntity.thisAuditFlag == "1")
                {
                    rdoAgree.Checked = true;
                }
                else if (this.BillEntity.thisAuditFlag == "2")
                {
                    rdoDisAgree.Checked = true;
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("不能加载数据！");
            }
        }

        #endregion

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double d = double.Parse(textBox1.Text.Trim());
            if (d <= 3 && d >= 0)
            {

            }
            else
            {
                throw new Exception("必须在0--3之间。");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void baoBtnpLevel_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            textBox1.Text =e.ReturnRow1["levelNum"].ToString();
        }
    }
}
