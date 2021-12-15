using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bao;
using UFBaseLib.BusLib;

namespace Repair
{
    public partial class RepairMessionChanage : FormChildBase, Bao.Interface.IU8Contral
    {
        //RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
        //DateTime time = RiLiGlobal.RiLiDataAcc.GetNow();
        DataTable rmc_dt;

        string RMTypeID;
        string RmId;
        string roleID;

        bool AddNewState;
        bool ModifyState;
        public RepairMessionChanage()
        {
            InitializeComponent();
            init("");
        }

        public RepairMessionChanage(string RMTypeID)
        {
            InitializeComponent();
            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);
        }

        private void HaveRMTypeIDInit(string RMTypeID)
        {
            UnBind();
            Bind(RMTypeID);
            if (getAuditState(RMTypeID))
            {
                Audited_ControlState();
            }
            else
            {
                UnAudited_ControlState();
            }
        }

        public void Authorization()
        {
            
        }

        private void init(string RMTypeID) 
        {
            this.RMTypeID = RMTypeID;
            this.roleID = "";
            RmId = getRMID(RMTypeID);

            this.AddNewState = false;
            this.ModifyState = false;

            initControl();
            Submited_ControlState();
            ctrEnable(false);

        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void initRoleState(string RMTypeID)
        {
            UnControlState();

            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
            {
                roleID = "010";
                if (getSumbitState(RMTypeID))
                {
                    AuditPerson_ControlState();
                }
            }

            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                UnAuditPerson_ControlState();
                roleID = "009";
            }

            Submited_ControlState();
        }

        /// <summary>
        /// 获取维修变更表对应的维修单ID
        /// </summary>
        /// <param name="RMTypeID"></param>
        /// <returns></returns>
        private string getRMID(string RMTypeID)
        {
            string sql = string.Empty;
            if (RMTypeID == "")
            {
                return "";
            }

            sql = string.Format("select RMID from RepairMissionChanage where RMTypeID = '{0}'", RMTypeID);
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            if (dt.Rows.Count<= 0)
            {
                return "";
            }
            return dt.Rows[0]["RMID"].ToString();
        }

        /// <summary>
        /// 获取维修变更表对应的维修变更单ID
        /// </summary>
        /// <param name="RMTypeID"></param>
        /// <returns></returns>
        private string getRMTypeID(string RmId)
        {
            string sql = string.Empty;
            if (RmId == "")
            {
                sql = string.Format("select RMTypeID from RepairMissionChanage where 1=2");
            }
            else
            {
                sql = string.Format("select RMTypeID from RepairMissionChanage where RMID = '{0}'", RmId);
            }

            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["RMTypeID"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void initControl()
        {
            toolStripPermissionState();
            Set_txtRMCode();
            //维修性质前控件
            cmbTypeEnd.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select code,code+'-'+name as name from BaseGuaranteeType order by code");
            cmbTypeEnd.DisplayMember = "name";
            cmbTypeEnd.ValueMember = "code";

            //维修性质后控件
            cmbChanageBegin.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select code,code+'-'+name as name from BaseGuaranteeType order by code");
            cmbChanageBegin.DisplayMember = "name";
            cmbChanageBegin.ValueMember = "code";

            //SubmitMissonDate.Text = time.ToLongDateString();
            //SubmitMissonDate.Tag = time.ToShortDateString();

            cmbChanageBegin.Enabled = false;
        }

        private void Bind(string RMTypeID)
        {
            this.RMTypeID = RMTypeID;
            string sql = string.Format("select RMTypeID, RMID, customerCode, CustomerName, RMTypeBegin, RMTypeEnd, ChanageRemark, CommitPer, CommitPerID, CommitDate, BillDate, AuditRemark, AuditPer, AuditDate, AuditStatus from RepairMissionChanage where RMTypeID = '{0}'", RMTypeID);
            rmc_dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            if (rmc_dt.Rows.Count <= 0)
            {
                MessageBox.Show("单据不存在！", "温馨提示！");
                return;
            }

            sql = string.Format("select RepairMissionCode from RepairMission where RepairMissionID = '{0}'", rmc_dt.Rows[0]["RMID"].ToString());
            DataTable rm_dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            txtRMCode.DataBindings.Add("BaoBtnCaption", rm_dt, "RepairMissionCode");
            txtCusCode.DataBindings.Add("Text", rmc_dt, "customerCode");
            txtCusName.DataBindings.Add("Text", rmc_dt, "CustomerName");
            cmbChanageBegin.DataBindings.Add("SelectedValue", rmc_dt, "RMTypeBegin");
            cmbTypeEnd.DataBindings.Add("SelectedValue", rmc_dt, "RMTypeEnd");
            txtChanageRemark.DataBindings.Add("Text", rmc_dt, "ChanageRemark");
            SubmitMissonDate.DataBindings.Add("Text", rmc_dt, "CommitDate");
            txtAuditRemark.DataBindings.Add("Text", rmc_dt, "AuditRemark");
        }

        private void UnBind()
        {
            txtRMCode.DataBindings.Clear();
            txtCusCode.DataBindings.Clear();
            txtCusName.DataBindings.Clear();
            cmbChanageBegin.DataBindings.Clear();
            cmbTypeEnd.DataBindings.Clear();
            SubmitMissonDate.DataBindings.Clear();
            txtChanageRemark.DataBindings.Clear();
            txtAuditRemark.DataBindings.Clear();
        }
        /// <summary>
        /// 审核人控件状态
        /// </summary>
        private void AuditPerson_ControlState()
        {
            txtAuditRemark.Enabled = true;
            btnAudit.Enabled = true;
            btnUnAudit.Enabled = true;
        }

        /// <summary>
        /// 非审核人控件状态
        /// </summary>
        private void UnAuditPerson_ControlState()
        {
            txtRMCode.Enabled = true;
            cmbTypeEnd.Enabled = true;
            txtChanageRemark.Enabled = true;
            btnCommit.Enabled = true;
        }

        /// <summary>
        /// 所有控件不可用
        /// </summary>
        private void UnControlState()
        {
            txtRMCode.Enabled = false;
            cmbTypeEnd.Enabled = false;
            cmbChanageBegin.Enabled = false;
            txtChanageRemark.Enabled = false;
            btnCommit.Enabled = false;

            txtAuditRemark.Enabled = false;
            btnAudit.Enabled = false;
            btnUnAudit.Enabled = false;
            btnBack.Enabled = false;
        }

        /// <summary>
        /// 提交控件状态
        /// </summary>
        private void Submited_ControlState()
        {
            if (!getSumbitState(RMTypeID))
            {
                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
                {
                    btnCommit.Enabled = true;
                    btnCommit.Text = "提交";
                }
            }
            else
            {
                if (!getAuditState(RMTypeID) && UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
                {
                    btnCommit.Enabled = true;
                } 
                else
                {
                    btnCommit.Enabled = false;
                }
                btnCommit.Text = "收回";

                cmbTypeEnd.Enabled = false;
                txtChanageRemark.Enabled = false;
            }
        }

        /// <summary>
        /// 已审核控件状态
        /// </summary>
        private void Audited_ControlState()
        {
            btnAudit.Enabled = false;
            btnUnAudit.Enabled = false;
            btnBack.Enabled = true;
        }

        /// <summary>
        /// 末审核控件状态
        /// </summary>
        private void UnAudited_ControlState()
        {
            btnAudit.Enabled = true;
            btnUnAudit.Enabled = true;
            btnBack.Enabled = false;
        }

        /// <summary>
        /// 提交验证
        /// </summary>
        /// <returns></returns>
        private bool Submit_Verification()
        {
            if ((txtRMCode.BaoBtnCaption == null || txtRMCode.BaoBtnCaption == "") && (RmId == null || RmId == ""))
            {
                MessageBox.Show("请选择维修单据！", "温馨提示！");
                return false;
            }

            if (cmbTypeEnd.SelectedValue == null || cmbTypeEnd.SelectedValue.ToString() == "")
            {
                MessageBox.Show("请选择维修性质（后）的值！", "温馨提示！");
                return false;
            }

            string cmbChanageBeginString;
            if (cmbChanageBegin.SelectedValue == null)
                cmbChanageBeginString = "";
            else
                cmbChanageBeginString = cmbChanageBegin.SelectedValue.ToString();

            if (cmbTypeEnd.SelectedValue.ToString() == cmbChanageBeginString)
            {
                MessageBox.Show("不能选择同样的维修性质！", "温馨提示！");
                return false;
            }

            if (txtChanageRemark.Text == null || txtChanageRemark.Text == "")
            {
                MessageBox.Show("请填写变更原因！", "温馨提示！");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 审核验证
        /// </summary>
        /// <returns></returns>
        private bool Audit_Verification()
        {
            if ((txtRMCode.BaoBtnCaption == null || txtRMCode.BaoBtnCaption == "") && (RmId == null || RmId == ""))
            {
                MessageBox.Show("请选择维修单据！", "温馨提示！");
                return false;
            }

            if (txtAuditRemark.Text == null || txtAuditRemark.Text == "")
            {
                MessageBox.Show("请填写审核意见！", "温馨提示！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 提交后，所需要的清空
        /// </summary>
        private void Clear_SubmitTxt()
        {
            RmId = "";
            RMTypeID = "";
            txtRMCode.BaoBtnCaption = "";
            txtCusCode.Text = "";
            txtCusName.Text = "";
            txtChanageRemark.Text = "";

            initRoleState(RMTypeID);

        }

        /// <summary>
        /// 审核后，所需要的清空
        /// </summary>
        private void Clear_AuditTxt()
        {
            RmId = "";
            RMTypeID = "";
            txtRMCode.BaoBtnCaption = "";
            txtCusCode.Text = "";
            txtCusName.Text = "";
            txtChanageRemark.Text = "";

            txtAuditRemark.Text = "";

            initRoleState(RMTypeID);
        }

        /// <summary>
        /// 维修编号控件设置
        /// </summary>
        private void Set_txtRMCode()
        {
            txtRMCode.BaoSQL = string.Format(@"Select rm.RepairMissionID, rm.RepairMissionCode, rm.CustomerName, 
                                                    rm.ZoneName, rm.MachineName, rm.RepairtypeNew, rm.CustomerCode,
                                                        rm.RepairPersonName, rm.ReportRepartDate, rmc.RMTypeID, rmc.RMTypeBegin,rm.City 
                                                From RepairMission rm
                                                left join RepairMissionChanage rmc on rm.RepairMissionID = rmc.RMID
                                                Where  isnull(rm.AuditMissonUser,'')<>'' and isnull(rm.IsEnd,'') <>'已结案' 
	                                                and rmc.RMID is null 
	                                                and rm.City in (select b.ProvinceName from Users a
		                                                inner join RegionToProvince b on b.deptNum like a.deptNum+'%'
		                                                inner join TRoleUsers c on a.AutoUserId = c.AutoUserId
		                                                where a.UserId = '{0}'  and c.RoleId='009'
	                                                )
                                                Order by rm.RepairMissionCode Desc", UFBaseLib.BusLib.BaseInfo.DBUserID);
            txtRMCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,ZoneName=区域,MachineName=主机型号,RepairType=维修类别,RepairPersonName=工程师,ReportRepartDate=报修日期";
            this.txtRMCode.FrmHigth = 500;
            this.txtRMCode.FrmWidth = 750;
            txtRMCode.DecideSql = "select * from RepairMission where   RepairMissionCode =";
            txtRMCode.BaoColumnsWidth = "RepairMissionCode=100,CustomerName=200,ZoneName=50,MachineName=100,RepairType=80,RepairPersonName=100,ReportRepartDate=80";
            txtRMCode.BaoClickClose = true;
            txtRMCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(txtRMCode_OnLookUpClosed);
        }

        /// <summary>
        /// 获取新增维修性质变更表行的SQL
        /// </summary>
        /// <param name="newid"></param>
        /// <param name="RMID"></param>
        /// <param name="RMCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="CustomerName"></param>
        /// <param name="RMTypeBegin"></param>
        /// <param name="RMTypeEnd"></param>
        /// <param name="ChanageRemark"></param>
        /// <param name="CommitPer"></param>
        /// <param name="CommitDate"></param>
        /// <param name="BillDate"></param>
        /// <param name="CommitPerID"></param>
        /// <returns></returns>
        private string getAddNew_SQL(string newid, string RMID, string customerCode, string CustomerName, string RMTypeBegin, string RMTypeEnd, string ChanageRemark, string BillDate)
        {
            string sql = string.Format("insert into RepairMissionChanage (RMTypeID, RMID, customerCode, CustomerName, RMTypeBegin, RMTypeEnd, ChanageRemark, BillDate) values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", newid, RMID, customerCode, CustomerName, RMTypeBegin, RMTypeEnd, ChanageRemark, BillDate);
            return sql;
        }

        private string getModifySumbit_SQL(string RMTypeID, string RMID, string customerCode, string CustomerName, string RMTypeBegin, string RMTypeEnd, string ChanageRemark, string BillDate)
        {
            string sql = string.Format("update RepairMissionChanage set RMID = '{1}', customerCode = '{2}', CustomerName = '{3}', RMTypeBegin = '{4}', RMTypeEnd = '{5}', ChanageRemark = '{6}', BillDate = '{7}'  where RMTypeID = '{0}'", RMTypeID, RmId, customerCode, CustomerName, RMTypeBegin, RMTypeEnd, ChanageRemark, BillDate);
            return sql;
        }

        private string getModifyAudit_SQL(string RMTypeID, string AuditRemark)
        {
            string sql = string.Format("update RepairMissionChanage set AuditRemark = '{0}' where RMTypeID = '{1}'", AuditRemark, RMTypeID);
            return sql;
        }
        private string getSumbit_SQLL(string RMTypeID, string CommitPer, string CommitPerID, string CommitDate)
        {
            if (CommitDate != null && CommitDate != "")
                return string.Format("update RepairMissionChanage set CommitPer = '{0}', CommitPerID = '{1}', CommitDate = '{2}' where RMTypeID = '{3}'", CommitPer, CommitPerID, CommitDate, RMTypeID); ;

            return string.Format("update RepairMissionChanage set CommitPer = '{0}', CommitPerID = '{1}', CommitDate = null where RMTypeID = '{2}'", CommitPer, CommitPerID, RMTypeID);;
        }

        /// <summary>
        /// 审核更新SQL
        /// </summary>
        /// <param name="AuditRemark"></param>
        /// <param name="AuditPer"></param>
        /// <param name="AuditDate"></param>
        /// <param name="AuditStatus"></param>
        /// <param name="RMID"></param>
        /// <returns></returns>
        private string getAudit_SQL(string AuditPer, string AuditDate, int AuditStatus, string RMTypeID)
        {
            if (AuditDate != null && AuditDate != "")
                return string.Format("update RepairMissionChanage set AuditPer = '{0}', AuditDate = '{1}', AuditStatus = '{2}' where RMTypeID = '{3}'", AuditPer, AuditDate, AuditStatus, RMTypeID);

            return string.Format("update RepairMissionChanage set AuditPer = '{0}', AuditDate = null, AuditStatus = '{1}' where RMTypeID = '{2}'", AuditPer, AuditStatus, RMTypeID); ;
        }


        /// <summary>
        /// 审核流程
        /// </summary>
        /// <param name="agress">1-同意，2-不同意</param>
        private bool Audit(int agress)
        {
            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
            {
                MessageBox.Show("只能由管理部部长审核！", "温馨提示！");
                return false;
            }
            

            if (agress != 1 && agress != 2)
            {
                MessageBox.Show("审核操作错误！", "温馨提示！");
                return false;
            }

            if (!Audit_Verification())
                return false;

            if (!RepairMissionState())
                return false;

            if (IsPrice())
            {
                MessageBox.Show("已做了报价单，如要更改，请先删除报价单！", "温馨提示！");
                return false;
            }

            if (getAuditState(RMTypeID))
            {
                MessageBox.Show("单据已审核！", "温馨提示！");
                return false;
            }

            try
            {
                string data = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                string sql = getAudit_SQL(UFBaseLib.BusLib.BaseInfo.UserName, data, agress, RMTypeID);
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                if (agress == 1)
                {
                    if (!ChangeRepairType(cmbTypeEnd.SelectedValue.ToString()))
                        return false;

                    MessageBox.Show("审核同意成功！", "温馨提示！");

                    if (rmc_dt != null && rmc_dt.Rows.Count > 0)
                    {
                        Bao.Message.CMessage.SendMessage("审核任务", "维修类型变更审核同意", rmc_dt.Rows[0]["CommitPerID"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep005", RMTypeID);
                    }
                }
                else
                {
                    MessageBox.Show("审核不同意成功！", "温馨提示！");

                    if (rmc_dt != null && rmc_dt.Rows.Count > 0)
                    {
                        Bao.Message.CMessage.SendMessage("审核任务", "维修类型变更审核不同意", rmc_dt.Rows[0]["CommitPerID"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep005", RMTypeID);
                    }

                }

                return true;
            }
            catch (System.Exception ex)
            {
                if (agress == 1)
                {
                    MessageBox.Show("审核同意失败！", "温馨提示！");
                    return false;
                }
                else
                {
                    MessageBox.Show("审核不同意失败！", "温馨提示！");
                    return false;
                }
            }
        }

        /// <summary>
        /// 更改维修性质，成功返回TRUE
        /// </summary>
        /// <returns></returns>
        private bool ChangeRepairType(string type) 
        {
            string sql = string.Format("select RepairtypeNew from RepairMission where RepairMissionID = '{0}'", RmId);
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            //表是否有数据
            if (dt.Rows.Count <= 0)
            {
                //如果写回失败，就恢复之前的没审核状态
                sql = string.Format("update RepairMissionChanage set AuditRemark = '{0}', AuditPer = '{1}', AuditDate = '{2}', AuditStatus = '{3}' where RMTypeID = '{4}'", "", "", "", "", RMTypeID);
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                MessageBox.Show("“RepairMission”表没有此单据！写回失败", "温馨提示！");
                return false;
            }

            try
            {
                //更改
                sql = string.Format("update RepairMission set RepairtypeNew = '{0}' where RepairMissionID = '{1}'", type, RmId);
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                return true;
            }
            catch (System.Exception ex)
            {
                //如果写回失败，就恢复之前的没审核状态
                sql = string.Format("update RepairMissionChanage set AuditRemark = '{0}', AuditPer = '{1}', AuditDate = '{2}', AuditStatus = '{3}' where RMTypeID = '{4}'", "", "", "", "", RMTypeID);
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                MessageBox.Show("写回失败！", "温馨提示！");
                return false;
            }
        }
        /// <summary>
        /// 检查是否已提交
        /// </summary>
        /// <param name="RMID"></param>
        /// <returns></returns>
        private bool Is_Submit(string RMTypeID)
        {
            string sql = string.Format("select RMID from RepairMissionChanage where RMTypeID='{0}' and isnull(CommitPer, '') <> ''", RMTypeID);
            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查是否已审核
        /// </summary>
        /// <param name="RMID"></param>
        /// <returns>TRUE为没审核</returns>
        //private bool Is_Audit(string RMID)
        //{
        //    string sql = string.Format("select RMID from RepairMissionChanage where RMTypeID='{0}' and (AuditStatus = 0 or isnull(AuditStatus, '') = '')", RMTypeID);
        //    DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void txtRMCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            //为什么会调用两次？
            RMTypeID = "";
            RmId = e.ReturnRow1["RepairMissionID"].ToString();
            txtRMCode.BaoBtnCaption = e.ReturnRow1["RepairMissionCode"].ToString();
            txtCusCode.Text = e.ReturnRow1["CustomerCode"].ToString();
            txtCusName.Text = e.ReturnRow1["CustomerName"].ToString();

            DataTable dt = Bao.DataAccess.DataAcc.ExecuteQuery("select RepairtypeNew from RepairMission where RepairMissionID='" + RmId + "'");
            this.cmbChanageBegin.DataBindings.Clear();
            this.cmbChanageBegin.DataBindings.Add("SelectedValue", dt, "RepairtypeNew");
        }

        private void SaveCommit()
        {
            if (!RepairMissionState())
            {
                return;
            }

            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                MessageBox.Show("只能由部长提交！", "温馨提示！");
                return;
            }

            if (IsPrice())
            {
                MessageBox.Show("已做了报价单，如要更改，请先删除报价单！", "温馨提示！");
                return;
            }
            
            if (Is_Submit(RMTypeID))
            {
                MessageBox.Show("单据已提交！", "温馨提示！");
                return;
            }

            try
            {
                string data = RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss");
                string sql = getSumbit_SQLL(RMTypeID, UFBaseLib.BusLib.BaseInfo.UserName, UFBaseLib.BusLib.BaseInfo.DBUserID, data);
                Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                string strManger = Bao.Message.CMessage.SendMessageToRoleNoDepartment("审核任务", "请求审核维修类型的变更", "010", UFBaseLib.BusLib.BaseInfo.UserId, "Rep005", RMTypeID);
                MessageBox.Show("提交成功，已发送至[" + strManger + "]！", "温馨提示！");
                SubmitMissonDate.Text = data;
                init(RMTypeID);
                HaveRMTypeIDInit(RMTypeID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提交失败！", "温馨提示！");
            }
        }

        private void SaveUnCommit()
        {
            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                MessageBox.Show("只能由部长收回！", "温馨提示！");
                return;
            }

            if (!Is_Submit(RMTypeID))
            {
                MessageBox.Show("单据已收回！", "温馨提示！");
                return;
            }

            string sql = getSumbit_SQLL(RMTypeID, "", "", "");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

            string strManger = Bao.Message.CMessage.SendMessageToRoleNoDepartment("审核任务", "已收回维修类型的变更", "010", UFBaseLib.BusLib.BaseInfo.UserId, "Rep005", RMTypeID);

            MessageBox.Show("收回成功，已发送[" + strManger + "]！", "温馨提示！");

            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (AddNewState || ModifyState)
            {
                MessageBox.Show("请保存，再提交！", "温馨提示！");
                return;
            }
            //temp code
            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能提交！", "温馨提示！");
                return;
            }

            if (getAuditState(RMTypeID))
            {
                MessageBox.Show("单据已审核，不能修改！", "温馨提示！");
                return;
            }

            if (!Submit_Verification())
            {
                return;
            }
               
            if (btnCommit.Text == "提交")
            {
                this.SaveCommit();
            }
            else if (btnCommit.Text == "收回")
            {
                this.SaveUnCommit();
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能审核！", "温馨提示！");
                return;
            }

            if (AddNewState || ModifyState)
            {
                MessageBox.Show("请保存，再审核！", "温馨提示！");
                return;
            }

            DialogResult Result = MessageBox.Show("是否同意维修类型变更？", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No)
                return;

            if (!getSumbitState(RMTypeID))
            {
                MessageBox.Show("维修类型变更已收回或末提交！", "温馨提示！");
                return;
            }

            Audit(1);

            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能审核！", "温馨提示！");
                return;
            }

            if (AddNewState || ModifyState)
            {
                MessageBox.Show("请保存，再审核！", "温馨提示！");
                return;
            }

            DialogResult Result = MessageBox.Show("是否不同意维修类型变更？", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No)
                return;

            if (!getSumbitState(RMTypeID))
            {
                MessageBox.Show("维修类型变更已收回或末提交！", "温馨提示！");
                return;
            }

            Audit(2);

            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);
        }

        /// <summary>
        /// 如果已做报价单，就返回真
        /// </summary>
        /// <returns></returns>
        private bool IsPrice()
        {
            string sql = string.Empty;
            if (RmId == "")
            {
                return false;
            }

            sql = string.Format(@"select RepairMissionCode from Price where RepairMissionId = '{0}'", RmId);
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 返回提交状态
        /// </summary>
        /// <param name="RMTypeID"></param>
        /// <returns>TRUE为已提交</returns>
        private bool getSumbitState(string RMTypeID)
        {
            DataRow dr = getStateDateTable(RMTypeID);
            if (dr == null)
                return false;

            if (dr["commitper"].ToString() == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 返回审核状态
        /// </summary>
        /// <param name="RMTypeID"></param>
        /// <returns>TRUE为已审核</returns>
        private bool getAuditState(string RMTypeID)
        {
            DataRow dr = getStateDateTable(RMTypeID);
            if (dr == null)
                return false;

            if (dr["auditper"].ToString() == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取要查询状态的数据
        /// </summary>
        /// <param name="RMTypeID"></param>
        /// <returns></returns>
        private DataRow getStateDateTable(string RMTypeID)
        {
            DataTable dt;
            if (RMTypeID == "")
            {
                return null;
            }

            string sql = string.Format(@"select commitper, auditper from repairmissionchanage where rmtypeid = '{0}'", RMTypeID);
            dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        /// <summary>
        /// 判断维修单据的状态，已审核和已结案都返回False
        /// </summary>
        /// <param name="RMID"></param>
        /// <returns></returns>
        private bool RepairMissionState()
        {
            if (RmId == "")
            {
                MessageBox.Show("单据不存在！", "温馨提示！");
                return false;
            }

            string sql = string.Empty;
            DataTable dt;
            sql = string.Format("select AuditMissonUser, IsEnd from RepairMission where RepairMissionID = '{0}'", RmId);
            dt = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("维修单据已删除！", "温馨提示！");
                return false;
            }
            DataRow dr = dt.Rows[0];
            string str = dr["AuditMissonUser"].ToString();
            if (dr["AuditMissonUser"].ToString() == "")
            {
                MessageBox.Show("维修单据不在审核状态，不能变更维修类型！", "温馨提示！");
                return false;
            }
            if (dr["IsEnd"].ToString() == "已结案")
            {
                MessageBox.Show("单据已结案，不能变更维修类型！", "温馨提示！");
                return false;
            }

            return true;
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                MessageBox.Show("你没此权限！", "温馨提示！");
                return;
            }

            this.AddNewState = true;
            this.ModifyState = false;

            ModifyDataState();
            ClearText();
            initRoleState("");
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (!IsPermission())
                return;

            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能修改！", "温馨提示！");
                return;
            }

            if (getAuditState(RMTypeID))
            {
                MessageBox.Show("单据已审核，不能修改！", "温馨提示！");
                return;
            }

            if (getSumbitState(RMTypeID))
            {
                if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
                {
                    MessageBox.Show("单据已提交，不能修改！", "温馨提示！");
                    return;
                }
            }

            this.AddNewState = false;
            this.ModifyState = true;

            ModifyDataState();
            initRoleState(RMTypeID);
            //不能修改维修单
            txtRMCode.Enabled = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!IsPermission())
                return;

            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能删除！", "温馨提示！");
                return;
            }

            if(getAuditState(RMTypeID))
            {
                MessageBox.Show("单据已审核，不能删除！", "温馨提示！");
                return;
            }

            if (getSumbitState(RMTypeID)) 
            {
                MessageBox.Show("单据已提交，不能删除！", "温馨提示！");
                return;
            }

            string sql = string.Format("delete from RepairMissionChanage where rmtypeid = '{0}'", RMTypeID);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

            MessageBox.Show("成功删除！", "温馨提示！");
            DeleteAfterState();
            ClearText();
            ctrEnable(false);

            this.AddNewState = false;
            this.ModifyState = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (RMTypeID != "")
            {
                init(RMTypeID);
                HaveRMTypeIDInit(RMTypeID);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!IsPermission())
                return;

            if (getAuditState(RMTypeID))
            {
                MessageBox.Show("单据已审核，不能保存！", "温馨提示！");
                return;
            }

            if (getSumbitState(RMTypeID))
            {
                if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
                {
                    MessageBox.Show("单据已提交，不能保存！", "温馨提示！");
                    return;
                }
            }

            if (AddNewState)
            {

                if (!Submit_Verification())
                    return;
                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
                {
                    string sql = getAddNew_SQL("NEWID()", RmId, txtCusCode.Text, txtCusName.Text,
                                                                        cmbChanageBegin.SelectedValue.ToString(), cmbTypeEnd.SelectedValue.ToString(),
                                                                                txtChanageRemark.Text, RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss"));
                    Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                    RMTypeID = getRMTypeID(RmId);
                    MessageBox.Show("新增保存成功！", "温馨提示！");
                }
            }
            else if (ModifyState)
            {
                if (RMTypeID == "")
                {
                    MessageBox.Show("没有单据，不能修改！", "温馨提示！");
                    return;
                }
                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
                {

                    if (!Submit_Verification())
                        return;

                    if (!getSumbitState(RMTypeID))
                    {
                        string sql = getModifySumbit_SQL(RMTypeID, RmId, txtCusCode.Text, txtCusName.Text, cmbChanageBegin.SelectedValue.ToString(), cmbTypeEnd.SelectedValue.ToString(), txtChanageRemark.Text, RiLiGlobal.RiLiDataAcc.GetNow().ToString("yyyy-MM-dd hh:ss"));
                        Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                    }
                }

                if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
                {
                    if (!Audit_Verification())
                        return;
                    string sql = getModifyAudit_SQL(RMTypeID, txtAuditRemark.Text);
                    Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
                }

                MessageBox.Show("修改保存成功！", "温馨提示！");
            }

            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);

            this.AddNewState = false;
            this.ModifyState = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (AddNewState || ModifyState)
            {
                DialogResult Result = MessageBox.Show("是否退出编辑状态？", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.No)
                    return;

                if (AddNewState)
                {
                    ClearText();
                    init("");
                    return;
                }

                if (ModifyState)
                {
                    init(RMTypeID);
                    HaveRMTypeIDInit(RMTypeID);
                    return;
                }

                this.AddNewState = false;
                this.ModifyState = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (AddNewState || ModifyState)
            {
                DialogResult Result = MessageBox.Show("是否退出编辑状态？", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
                else
                    return;
            }

            this.Close();
        }

        private void ModifyDataState()
        {
            BtnAddNew.Enabled = false;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnRefresh.Enabled = false;

            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void initState() 
        {
            BtnAddNew.Enabled = true;
            BtnModify.Enabled = true;
            BtnDelete.Enabled = true;
            BtnRefresh.Enabled = true;

            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
        }

        private void DeleteAfterState()
        {
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnRefresh.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;

            BtnAddNew.Enabled = true;
        }

        private void ctrEnable(Boolean b)
        {
            txtRMCode.Enabled = b;
            foreach(Control c in this.Controls)
            {
                DG(c, b);
            }
        }

        private void DG(Control ctl, Boolean f)
        {
            if (ctl.Tag != null && ctl.Tag.ToString().Trim() == "99999")
                return;

            for (int i = 0; i < ctl.Controls.Count; i++)
            {
                DG(ctl.Controls[i], f);
            }

            if (ctl.Controls.Count == 0)
                ctl.Enabled = f;
        }

        private void ClearText() 
        {
            RmId = "";
            RMTypeID = "";
            txtRMCode.BaoBtnCaption = "";
            txtCusCode.Text = "";
            txtCusName.Text = "";
            txtChanageRemark.Text = "";

            cmbChanageBegin.Text = null;
            cmbTypeEnd.Text = null;
            txtAuditRemark.Text = "";
        }

        private void toolStripPermissionState() 
        {
            initState();
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
                return;

            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
            {
                BtnAddNew.Visible = false;
                BtnDelete.Visible = false;
                return;
            }

            BtnAddNew.Visible = false;
            BtnModify.Visible = false;
            BtnDelete.Visible = false;
            BtnSave.Visible = false;
            BtnCancel.Visible = false;
        }

        private Boolean IsPermission() 
        {
            if (!(UFBaseLib.BusLib.BaseInfo.userRole.Contains("009") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("010")))
            {
                MessageBox.Show("你没此权限！", "温馨提示！");
                return false;
            }
            return true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (AddNewState || ModifyState)
            {
                MessageBox.Show("请保存，再收回！", "温馨提示！");
                return;
            }
            //temp code
            if (RMTypeID == "")
            {
                MessageBox.Show("没有单据，不能收回！", "温馨提示！");
                return;
            }

            if (!UFBaseLib.BusLib.BaseInfo.userRole.Contains("010"))
            {
                MessageBox.Show("只能由管理部部长收回！", "温馨提示！");
                return;
            }

            if (!getAuditState(RMTypeID))
            {
                MessageBox.Show("单据没有审核！", "温馨提示！");
                return;
            }

            if (IsPrice())
            {
                MessageBox.Show("已做了报价单，如要更改，请先删除报价单！", "温馨提示！");
                return;
            }

            string sql = getAudit_SQL("", "", 0, RMTypeID);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

            ChangeRepairType(cmbChanageBegin.SelectedValue.ToString());

            if (rmc_dt != null && rmc_dt.Rows.Count > 0)
            {
                Bao.Message.CMessage.SendMessage("审核任务", "维修类型变更审核已收回", rmc_dt.Rows[0]["CommitPerID"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Rep005", RMTypeID);
            }

            init(RMTypeID);
            HaveRMTypeIDInit(RMTypeID);
        }

        private void RepairMessionChanage_Load(object sender, EventArgs e)
        {

        }
    }
}
