using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bao;
using UFBaseLib.BusLib;

namespace RLBase
{
    public partial class frmJQJB : FormChildBase, Bao.Interface.IU8Contral
    {
        /// <summary>
        /// 所要查询的数据表名
        /// </summary>
        private const string TABLENAME = "BaseMachineGrade";

        /// <summary>
        /// SQL处理
        /// </summary>
        RLBase.frmSQL fSQL = new RLBase.frmSQL();

        /// <summary>
        /// 新增判断
        /// </summary>
        private bool IsNew = false;

        /// <summary>
        /// 修改判断
        /// </summary>
        private bool IsUpdate = false;

        /// <summary>
        /// 用于判断点击数据外的地方时，数据焦点行没有改变，不响应事件
        /// </summary>
        private long IsClick = -2;

        public frmJQJB()
        {
            InitializeComponent();

            //产品线 XR、CT、MR、US、BD、OT、其他
            this.cmbProductLine.DataSource = Bao.DataAccess.DataAcc.ExecuteQuery("select ProductLineName from ProductLine");
            this.cmbProductLine.DisplayMember = "ProductLineName";
            this.cmbProductLine.ValueMember = "ProductLineName";

            this.cmbProductLine.SelectedIndex = -1;

            initState();
            DataBind();
        }

        public void Authorization()
        {

        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJQJB_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        private void initState()
        {
            txtClear();
            BtnAddNew.Enabled = true;
            BtnRefresh.Enabled = true;
            BtnExit.Enabled = true;

            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnModify.Enabled = false;

            textBoxCode.Enabled = false;
            textBoxType.Enabled = false;
            textBoxGrade.Enabled = false;
            textBoxModel.Enabled = false;
            textBoxcInvStd.Enabled = false;

            this.cmbProductLine.Enabled = false;

            IsNew = false;
            IsUpdate = false;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind()
        {
            this.gridControl1.DataSource = fSQL.Select_SQL_RLBaseMachineGrade(TABLENAME);
        }

        /// <summary>
        /// 清空文本框及重置数据
        /// </summary>
        private void txtClear()
        {
            this.textBoxCode.Text = "";
            this.textBoxType.Text = "";
            this.textBoxGrade.Text = "";
            this.textBoxModel.Text = "";
            this.textBoxcInvStd.Text = "";

            gridView1.FocusedRowHandle = 99999;
            IsClick = -2;
        }

        /// <summary>
        /// 新增按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            txtClear();

            //文本框可用
            textBoxCode.Enabled = true;
            textBoxType.Enabled = true;
            textBoxGrade.Enabled = true;
            textBoxModel.Enabled = true;
            textBoxcInvStd.Enabled = true;

            this.cmbProductLine.Enabled = true;

            BtnAddNew.Enabled = false;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnRefresh.Enabled = false;

            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnExit.Enabled = true;

            //设置为新增状态
            IsNew = true;
            IsUpdate = false;
        }

        /// <summary>
        /// 修改按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModify_Click(object sender, EventArgs e)
        {
            textBoxCode.Enabled = true;
            textBoxType.Enabled = true;
            textBoxGrade.Enabled = true;
            textBoxModel.Enabled = true;
            textBoxcInvStd.Enabled = true;

            this.cmbProductLine.Enabled = true;


            BtnAddNew.Enabled = false;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnRefresh.Enabled = false;

            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnExit.Enabled = true;

            //设置为修改状态
            IsNew = false;
            IsUpdate = true;
        }

        /// <summary>
        /// 取消按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (!Is_Save())
            {
                initState();
            }
        }

        /// <summary>
        /// 退出按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 刷新按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 保存按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //获取文本框值
            string code = this.textBoxCode.Text.Trim().ToString();
            string type = this.textBoxType.Text.Trim().ToString();
            string grade = this.textBoxGrade.Text.Trim().ToString();
            string model = this.textBoxModel.Text.Trim().ToString();
            string cinvstd = this.textBoxcInvStd.Text.Trim().ToString();
            string productline = this.cmbProductLine.Text.Trim().ToString();
            Save_to_DataBase(code, type, grade, model, cinvstd, productline);
        }

        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="type">名称</param>
        /// <param name="grade">备注</param>
        /// <param name="model">备注</param>
        private bool Save_to_DataBase(string code, string type, string grade, string model, string cinvstd, string productline)
        {
            if (Text_Verification(code, type, grade, model, cinvstd, productline))
            {
                if (Save_Process(code, type, grade, model, cinvstd, productline))
                {
                    //保存成功后处理过程
                    txtClear();
                    initState();
                    DataBind();
                    MessageBox.Show("保存成功！", "温馨提示！");
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 文本信息验证
        /// </summary>
        /// <returns></returns>
        private bool Text_Verification(string code, string type, string grade, string model, string cinvstd, string productline)
        {
            if (code == null || code == "")
            {
                MessageBox.Show("编码不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }

            if (type == null || type == "")
            {
                MessageBox.Show("类型不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }

            if (grade == null || grade == "")
            {
                MessageBox.Show("级别不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }

            if (model == null || model == "")
            {
                MessageBox.Show("型号不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }

            if (cinvstd == null || cinvstd == "")
            {
                MessageBox.Show("U8存货代码不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }

            if (productline == null || productline == "")
            {
                MessageBox.Show("产品线不能为空！", "温馨提示！");
                this.cmbProductLine.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存处理方法
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        private bool Save_Process(string code, string type, string grade, string model, string cinvstd, string productline)
        {
            try
            {

                //新增保存处理过程
                if (IsNew == true && IsUpdate == false)
                {
                    if (Is_CodeExist(code))
                    {
                        MessageBox.Show(code + "数据已存在！", "温馨提示！");
                        return false;
                    }
                    else
                    {
                        fSQL.Insert_SQL_RLBaseMachineGrade(code, type, grade, model, cinvstd, productline);
                        return true;
                    }
                }
                //修改保存处理过程
                else if (IsNew == false && IsUpdate == true)
                {
                    //判断是否选择要修改的数据
                    if (gridView1.FocusedRowHandle >= 0)
                    {
                        DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                        //修改的编码是否已存在并且是否已修改了编码
                        if (Is_CodeExist(code) && code != row["code"].ToString())
                        {
                            MessageBox.Show("编码不能相同！", "温馨提示！");
                            return false;
                        }
                        else
                        {
                            if (Is_CodeExist(code))
                            {
                                //如果编码没变且是否存在，就修改数据
                                fSQL.Update_SQL_RLBaseMachineGrade(code, type, grade, model, cinvstd, productline);
                                return true;
                            }
                            else
                            {
                                //如果编码在表中没数据，就新增再删除原来编码数据
                                fSQL.Insert_SQL_RLBaseMachineGrade(code, type, grade, model, cinvstd, productline);
                                fSQL.Delete_SQL_RLBase(TABLENAME, row["code"].ToString());
                                return true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("还没选择需要修改的数据！", "温馨提示！");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private bool Is_CodeExist(string code)
        {
            DataTable dt = fSQL.Select_Is_RLBase(TABLENAME, code);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断信息是否保存
        /// </summary>
        /// <returns></returns>
        private bool Is_Save()
        {
            string code = textBoxCode.Text;
            string type = textBoxType.Text;
            string grade = textBoxGrade.Text;
            string model = textBoxModel.Text;
            string cinvstd = textBoxcInvStd.Text;
            string productline = this.cmbProductLine.Text;

            if ((code != null && code != "") || (type != null && type != "") || (grade != null && grade != "") || (model != null && model != "") || (cinvstd != null && cinvstd != "") || (productline != null && productline != ""))
            {
                //如果在新增或修改状态就提示
                if (IsNew == true || IsUpdate == true)
                {
                    DialogResult Result = MessageBox.Show("信息还没有保存，是否保存？", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        //防止单击其他行后，取数不对
                        if (IsClick >= 0)
                        {
                            gridView1.FocusedRowHandle = (int)IsClick;
                        }

                        Save_to_DataBase(code, type, grade, model, cinvstd, productline);
                        return true;
                    }
                    else
                    {
                        //到了保存这一步骤，可能信息填写不正确，还要在保存状态，所以以下的操作都取消
                        initState();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 网格控件（GridControl）单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0 || gridView1.FocusedRowHandle == IsClick || Is_Save())
            {
                return;
            }

            BtnCancel.Enabled = true;
            BtnExit.Enabled = true;
            BtnModify.Enabled = true;
            BtnDelete.Enabled = true;
            BtnRefresh.Enabled = true;
            BtnAddNew.Enabled = true;

            BtnSave.Enabled = false;

            //文本不可编辑
            textBoxCode.Enabled = false;
            textBoxType.Enabled = false;
            textBoxGrade.Enabled = false;
            textBoxModel.Enabled = false;
            textBoxcInvStd.Enabled = false;
            this.cmbProductLine.Enabled = false;

            IsNew = false;
            IsUpdate = false;

            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                //显示所单击项的数据
                textBoxCode.Text = row["code"].ToString();
                textBoxType.Text = row["type"].ToString();
                textBoxGrade.Text = row["grade"].ToString();
                textBoxModel.Text = row["model"].ToString();
                textBoxcInvStd.Text = row["cinvstd"].ToString();
                IsClick = gridView1.FocusedRowHandle;
                if (row["productline"].ToString() == "")
                {
                    this.cmbProductLine.SelectedIndex = -1;
                }
                else
                {
                    this.cmbProductLine.Text = row["productline"].ToString();
                }
            }
        }

        /// <summary>
        /// 删除按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete_BaseInstallationUnitFiles();
        }

        /// <summary>
        /// 删除数据的处理过程
        /// </summary>
        /// <returns></returns>
        private bool Delete_BaseInstallationUnitFiles()
        {
            DialogResult Result = MessageBox.Show("您是否要删除当前信息！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                //删除用户信息
                Delete();
                txtClear();
                initState();
                DataBind();
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除数据的方法
        /// </summary>
        private void Delete()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                fSQL.Delete_SQL_RLBase(TABLENAME, row1["code"].ToString());
                MessageBox.Show("删除成功！", "温馨提示！");
            }
            else
            {
                MessageBox.Show("数据不存在！", "温馨提示！");
            }
        }
    }
}
