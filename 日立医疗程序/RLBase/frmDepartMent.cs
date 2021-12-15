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
    public partial class frmDepartMent : FormChildBase, Bao.Interface.IU8Contral
    {
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        frmSQL fSQL = new frmSQL();

        /// <summary>
        /// 新增状态，true为新增
        /// </summary>
        private bool IsNew = false;

        /// <summary>
        /// 修改状态，true为新增
        /// </summary>
        private bool IsModify = false;

        public frmDepartMent()
        {
            InitializeComponent();
        }

        public void Authorization()
        {

        }

        /// <summary>
        /// 树控件加载节点，深度递归所有节点
        /// </summary>
        /// <param name="parentnum"></param>
        /// <param name="tnparent"></param>
        /// <returns></returns>
        private TreeNode treeView_Load(string parentnum, TreeNode tnparent)
        {
            //根据父节点查找子节点
            DataTable dt = fSQL.Select_SQL_BaseDepartMent_parentnum(parentnum);

            TreeNode tn = null;

            foreach (DataRow dr in dt.Rows)
            {
                tn = new TreeNode();
                tn.Text = dr["deptName"].ToString();
                tn.Tag = dr["deptNum"].ToString();
                //从此节点查找属于它的子节点
                TreeNode tnnew = this.treeView_Load(tn.Tag.ToString(), tn);
                if (tnnew != null)
                {
                    //如果tnparent==null，说明已经回到根节点，因为第一次调用此函数的tnparent为空
                    if (tnparent == null)
                    {
                        return tn;
                    }
                    else
                    {
                        tnparent.Nodes.Add(tnnew);
                    }
                }
            }
            return tnparent;
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartMent_Load(object sender, EventArgs e)
        {
            initState();
            TreeNode tn = this.treeView_Load("", null);
            //treeView_Load的参数“tnparent”为null，是为了不用先生成根节点，然后再调用此函数，直接在此函数生成，如果表里面没数据，会返回null，所以增加一个判断
            if (tn != null)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(tn);
                treeView1.ExpandAll();
            }
            //如果表里面没有数据，也就是说没根节点，新增和退出按钮可以使用
            else
            {
                /******************控件状态***********************/
                BtnAddNew.Enabled = true;
                BtnExit.Enabled = true;

                BtnRefresh.Enabled = false;
                BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;

                TextBoxClear();
                AllTextBoxEnable(true);
                /************************************************/
            }
        }

        /// <summary>
        /// 设置所有的文本框和复选框是否可编辑
        /// </summary>
        /// <param name="b"></param>
        private void AllTextBoxEnable(bool b)
        {
            textBoxName.Enabled = b;
            textBoxNum.Enabled = b;
            checkBoxIsEnd.Enabled = b;
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        private void initState()
        {
            /******************控件状态***********************/
            //刷新、退出可用，其他不可用
            BtnRefresh.Enabled = true;
            BtnExit.Enabled = true;

            BtnAddNew.Enabled = false;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;

            TextBoxClear();
            AllTextBoxEnable(false);
            /*************************************************/

            //新增和修改状态重置
            IsNew = false;
            IsModify = false;
        }

        /// <summary>
        /// 文本验证
        /// </summary>
        private bool Text_Verification(string num, string name)
        {
            if (num == "" || num == null)
            {
                MessageBox.Show("编码不能为空！", "温馨提示！");
                this.textBoxNum.Focus();
                return false;
            }
            else if (name == "" || name == null)
            {
                MessageBox.Show("名称不能为空！", "温馨提示！");
                this.textBoxName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private bool Is_CodeExist(string num)
        {
            DataTable dt = fSQL.Select_Is_BaseDepartMent(num);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 清空所有文本框，取消复选框勾选状态
        /// </summary>
        private void TextBoxClear()
        {
            textBoxNum.Text = "";
            textBoxName.Text = "";
            checkBoxIsEnd.Checked = false;
        }

        /// <summary>
        /// 判断复选框是否勾选，如果是，则为1，否则为0
        /// </summary>
        /// <returns></returns>
        private string IsChecked()
        {
            if (checkBoxIsEnd.Checked)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 保存处理过程
        /// </summary>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool Save(string num, string name)
        {
            //新增状态处理过程
            if (IsNew == true && IsModify == false)
            {
                if (Is_CodeExist(num))
                {
                    MessageBox.Show(num + "编码已存在！", "温馨提示！");
                    return false;
                }
                else
                {
                    //如果表里面没数据，此时新增的是根节点，而根节点的parentnum为设置空，因为加载树控件函数时，是用null表示根节点，从根节点开始加载
                    if (treeView1.Nodes.Count == 0)
                    {
                        fSQL.Insert_SQL_BaseDepartMen(num, name, null, IsChecked());
                    }
                    else
                    {
                        fSQL.Insert_SQL_BaseDepartMen(num, name, treeView1.SelectedNode.Tag.ToString(), IsChecked());
                    }

                    return true;
                }
            }
            //修改状态处理过程
            else if (IsNew == false && IsModify == true)
            {
                fSQL.Update_SQL_BaseDepartMent(num, name, IsChecked());
                return true;
            }
            else
            {
                MessageBox.Show("保存失败！", "温馨提示！");
                return false;
            }
        }

        /// <summary>
        /// 刷新树按件，并展开以及所有控件状态
        /// </summary>
        private void Refresh_frmDepartMent()
        {
            initState();
            TreeNode tn = this.treeView_Load("", null);
            //treeView_Load的参数“tnparent”为null，是为了不用先生成根节点，然后再调用此函数，直接在此函数生成，如果表里面没数据，会返回null，所以增加一个判断
            if (tn != null)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(tn);
                treeView1.ExpandAll();
            }
        }

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            //如果表里面没数据，也就是没根节点，编码自定义为null
            if (treeView1.Nodes.Count == 0)
            {
                /******************控件状态***********************/
                BtnSave.Enabled = true;
                BtnExit.Enabled = true;

                BtnCancel.Enabled = false;
                BtnAddNew.Enabled = false;
                BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnRefresh.Enabled = false;

                textBoxNum.Enabled = false;
                textBoxName.Enabled = true;
                checkBoxIsEnd.Enabled = true;

                TextBoxClear();
                /*************************************************/

                //设为新增状态
                IsNew = true;
                IsModify = false;

                return;
            }

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择节点！", "温馨提示！");
            }
            else
            {
                /******************控件状态***********************/
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnExit.Enabled = true;

                BtnAddNew.Enabled = false;
                BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnRefresh.Enabled = false;

                TextBoxClear();
                AllTextBoxEnable(true);
                /*************************************************/

                //设为新增状态
                IsNew = true;
                IsModify = false;
            }
        }

        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择节点！", "温馨提示！");
            }
            else
            {
                /******************控件状态***********************/
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnExit.Enabled = true;

                BtnAddNew.Enabled = false;
                BtnModify.Enabled = false;
                BtnDelete.Enabled = false;
                BtnRefresh.Enabled = false;

                textBoxNum.Enabled = false;
                textBoxName.Enabled = true;

                //如果此节点有子节点，复选框不可编辑
                if (treeView1.SelectedNode.Nodes.Count == 0)
                {
                    checkBoxIsEnd.Enabled = true;
                }
                else
                {
                    checkBoxIsEnd.Enabled = false;
                }
                /************************************************/

                //设为修改状态
                IsNew = false;
                IsModify = true;
            }
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("请选择节点！", "温馨提示！");
            }
            else
            {
                fSQL.Delete_SQL_BaseDepartMent(tn.Tag.ToString());
                Refresh_frmDepartMent();
                MessageBox.Show("删除成功！", "温馨提示！");
            }
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_frmDepartMent();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string num = textBoxNum.Text;
            string name = textBoxName.Text;

            if (Text_Verification(num, name))
            {
                if (Save(num, name))
                {
                    //保存成功则刷新
                    Refresh_frmDepartMent();
                }
            }
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //返回原来的状态
            initState();
        }

        /// <summary>
        /// 退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 节点选择后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            //如果为空，不作处理
            if (tn == null) return;

            /******************控件状态***********************/
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnExit.Enabled = true;

            BtnModify.Enabled = true;
            BtnRefresh.Enabled = true;

            AllTextBoxEnable(false);
            /*************************************************/

            textBoxNum.Text = tn.Tag.ToString();
            textBoxName.Text = tn.Text;

            DataTable dt = fSQL.Select_SQL_BaseDepartMent_deptnum(tn.Tag.ToString());

            //判断被选择节点是否为末级，"1(true)"为末级
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("数据不存在！", "温馨提示！");
            }
            else
            {
                if (Convert.ToBoolean(dt.Rows[0]["isend"].ToString()))
                {
                    //末级，新增按钮不可用，复选框为被选择
                    BtnAddNew.Enabled = false;
                    checkBoxIsEnd.Checked = true;
                }
                else
                {
                    BtnAddNew.Enabled = true;
                    checkBoxIsEnd.Checked = false;
                }
            }

            //如果有子节点，删除按钮就不可用
            if (tn.Nodes.Count == 0)
            {
                BtnDelete.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
            }
        }
    }
}
