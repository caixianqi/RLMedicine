using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BillBase.AuthUser;
namespace Bao.BillBase
{
    /// <summary>
    /// 该类为基本资料浏览列表的通用类
    /// </summary>
    public partial class Frmbasis : Bao.FormChildBase, Bao.Interface.IU8Contral, Bao.BillBase. IChildClose
    {
        /// <summary>
        /// 档案编辑界面
        /// </summary>
        LookUpBasis LookUpObj;
        /// <summary>
        ///  功能编号，单据类型的唯一编码，该编码在数据库表TFunctions的FunctionId字段中定义
        /// </summary>
        public string FunctionId;
        public Frmbasis()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="paramId">该编码在数据库表TFunctionChild的Param字段定义</param>
        public Frmbasis(string paramId)
        {
            InitializeComponent();
            
            System.Data.DataTable table1= LookUpBasis.GetFormType(paramId);
            LookUpObj = (LookUpBasis)Bao.DataAccess.DataAcc.CreateForm(table1.Rows[0]["DLLName"].ToString(), table1.Rows[0]["WorkName"].ToString(), null);
            LookUpObj.IParentForm = this;
            
            this.AddOwnedForm(LookUpObj);
            LookUpObj.TableList = ((IChildForm)LookUpObj).GetTableList();
            this.gridControl1 .DataSource = LookUpObj.TableList;

            System.Data.DataTable tableColTitle =LookUpObj.GetColumnTitles(paramId);

            foreach (System.Data.DataRow row1 in tableColTitle.Rows)
            {
                gridView1.Columns[row1["ColumnName"].ToString()].Caption = row1["ColumnTitle"].ToString();
                gridView1.Columns[row1["ColumnName"].ToString()].OptionsColumn.ReadOnly = true;
                gridView1.Columns[row1["ColumnName"].ToString()].Width = int.Parse(row1["Width"].ToString());
                gridView1.Columns[row1["ColumnName"].ToString()].OptionsColumn.AllowEdit = false;

            }
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName.ToUpper() == gridView1.Columns[i].Caption.ToUpper())
                {
                    this.gridView1.Columns[i].Visible = false;
                }
            }
           // toolBarBill1.BtnUpdate.Enabled =false;
            toolBarBill1.GridViewSource = this.gridView1;
        }

        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
            ((IChildForm)LookUpObj).SetValueToControl(gridView1.GetDataRow(gridView1.FocusedRowHandle),false);
            this.gridControl1.Enabled = false;
            LookUpObj.Visible = true;
            
        }

        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            ((IChildForm)LookUpObj).SetValueToControl(gridView1.GetDataRow(gridView1.FocusedRowHandle),true);
            this.gridControl1.Enabled = false;
            LookUpObj.Visible = true;

        }

        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
           //SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
           // Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
            try
            {
                if (toolBarBill1.Is_Update)
                    ((IChildForm)LookUpObj).Update();
                else
                    ((IChildForm)LookUpObj).Append();
              //  sqlTran.Commit();
            }
            catch (Exception ex)
            {
               // sqlTran.Rollback();
                throw new Exception(ex.Message);
            }
            LookUpObj.TableList = ((IChildForm)LookUpObj).GetTableList();
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = LookUpObj.TableList;
            toolBarBill1.PrintData.Tables.Clear();
            toolBarBill1.PrintData.Tables.Add(LookUpObj.TableList);
            
           

        }

        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要删除？", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
                Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
                try
                {
                    ((IChildForm)LookUpObj).Delete(gridView1.GetDataRow(gridView1.FocusedRowHandle));
                    LookUpObj.TableList.Rows.Remove(gridView1.GetDataRow(gridView1.FocusedRowHandle));
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            
        }

        #region IU8Contral 成员

        public void Authorization()
        {
            //AuthorizationUser.AuthUser(UFBaseLib.BusLib.BaseInfo.UserId, this.FunctionId, toolBarBill1);
        }

        #endregion

        private void Frmbasis_Load(object sender, EventArgs e)
        {
           // this.toolBarBill1.BtnUpdate.Enabled = true;
            this.toolBarBill1.BtnUnAudit.Visible = false;
            toolBarBill1.PrintData.Tables.Add(LookUpObj.TableList);
            
        }

        private void toolBarBill1_OnBaoExit(object sender, EventArgs e)
        {
            LookUpObj.CloseFlag = true;
            LookUpObj.Close();
            this.Close();
        }

        #region IChildClose 成员
        /// <summary>
        /// 
        /// </summary>
        public void OnClosed()
        {
           
            this.gridControl1.Enabled = true;
        }

        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            ((IChildForm)LookUpObj).SetValueToControl(gridView1.GetDataRow(gridView1.FocusedRowHandle),false);
            LookUpObj.Visible = true;
        }

        private void toolBarBill1_OnBaoSetPrintDataset(object sender, EventArgs e)
        {
            this.toolBarBill1.PrintData.Tables.Clear();
            this.toolBarBill1.PrintData.Tables.Add(LookUpObj.TableList);
        }

        private void Frmbasis_FormClosing(object sender, FormClosingEventArgs e)
        {
            LookUpObj.CloseFlag = true;
            LookUpObj.Close();
            e.Cancel = false;
            
        }
        /// <summary>
        /// 设置FunctionId
        /// </summary>
        /// <param name="mFunctionId">功能编号，单据类型的唯一编码，该编码在数据库表TFunctions的FunctionId字段中定义</param>
        public override void SetFunctionId(string mFunctionId)
        {
            FunctionId = mFunctionId;
        }
    }
}
