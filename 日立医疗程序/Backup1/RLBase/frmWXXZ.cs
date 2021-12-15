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
    public partial class frmWXXZ : FormChildBase, Bao.Interface.IU8Contral
    {
        /// <summary>
        /// 所要查询的数据表名
        /// </summary>
        private const string TABLENAME = "BaseRepairType";

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

        public frmWXXZ()
        {
            InitializeComponent();
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
        private void frmWXXZ_Load(object sender, EventArgs e)
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
            textBoxName.Enabled = false;
            textBoxComment.Enabled = false;

            IsNew = false;
            IsUpdate = false;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind()
        {
            this.gridControl1.DataSource = fSQL.Select_SQL_RLBase(TABLENAME);
        }

        /// <summary>
        /// 清空文本框及重置数据
        /// </summary>
        private void txtClear()
        {
            this.textBoxCode.Text = "";
            this.textBoxName.Text = "";
            this.textBoxComment.Text = "";

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
            textBoxName.Enabled = true;
            textBoxComment.Enabled = true;

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

            //新增状态，点击其他地方时，还可以输入
            IsClick = -3;
        }

        /// <summary>
        /// 修改按钮处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModify_Click(object sender, EventArgs e)
        {
            //编码框不可用，名称框可用
            textBoxCode.Enabled = true;
            textBoxName.Enabled = true;
            textBoxComment.Enabled = true;

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
            string name = this.textBoxName.Text.Trim().ToString();
            string comment = this.textBoxComment.Text.Trim().ToString();

            Save_to_DataBase(code, name, comment);
        }

        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        /// <param name="comment">备注</param>
        private bool Save_to_DataBase(string code, string name, string comment)
        {
            if (Text_Verification(code, name))
            {
                if (Save_Process(code, name, comment))
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
        private bool Text_Verification(string code, string name)
        {
            if (code == null || code == "")
            {
                MessageBox.Show("编码不能为空！", "温馨提示！");
                this.textBoxCode.Focus();
                return false;
            }
            else if (name == null || name == "")
            {
                MessageBox.Show("名称不能为空！", "温馨提示！");
                this.textBoxName.Focus();
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
        private bool Save_Process(string code, string name, string comment)
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
                        fSQL.Insert_SQL_RLBase(TABLENAME, code, name, comment);
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
                                fSQL.Update_SQL_RLBase(TABLENAME, code, name, comment);
                                return true;
                            }
                            else
                            {
                                //如果编码在表中没数据，就新增再删除原来编码数据
                                fSQL.Insert_SQL_RLBase(TABLENAME, code, name, comment);
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
            string name = textBoxName.Text;
            string comment = textBoxComment.Text;

            if ((code != null && code != "") || (name != null && name != "") || (comment != null && comment != ""))
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

                        Save_to_DataBase(code, name, comment);
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
            textBoxName.Enabled = false;
            textBoxComment.Enabled = false;

            IsNew = false;
            IsUpdate = false;

            if (gridView1.FocusedRowHandle >= 0)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                //显示所单击项的数据
                textBoxCode.Text = row["code"].ToString();
                textBoxName.Text = row["name"].ToString();
                textBoxComment.Text = row["comment"].ToString();
                IsClick = gridView1.FocusedRowHandle;
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
