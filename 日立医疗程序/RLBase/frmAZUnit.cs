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
using U8Global;
using RiLiGlobal;


namespace RLBase
{
    public partial class frmAZUnit : UserControl, Bao.Interface.IU8Contral
    {
        /// <summary>
        /// 安装单位1——部门表
        /// </summary>
        private DataTable dt_InstallUnit1 = null;

        /// <summary>
        /// 安装单位2——地区表
        /// </summary>
        private DataTable dt_InstallUnit2 = null;

        public frmAZUnit()
        {
            InitializeComponent();
            this.Init();
        }

        public void Authorization()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.LoadGrid();

            dt_InstallUnit1 = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select deptName from BaseDepartMent where isend = 1");
            
            string sql = string.Format(@"select cDCName from {0}.DistrictClass", U8DataAcc.U8ServerAndDataBase);
            dt_InstallUnit2 = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);

            foreach (DataRow item in dt_InstallUnit1.Rows)
            {
                DevExpress.XtraEditors.Controls.ComboBoxItem item1 = new DevExpress.XtraEditors.Controls.ComboBoxItem(item["deptName"].ToString());

                this.repositoryItemInstallUnit1_CB.Items.Add(item1);
            }

            foreach (DataRow item in dt_InstallUnit2.Rows)
            {
                DevExpress.XtraEditors.Controls.ComboBoxItem item1 = new DevExpress.XtraEditors.Controls.ComboBoxItem(item["cDCName"].ToString());

                this.repositoryItemInstallUnit2_CB.Items.Add(item1);
            }

            this.gridView1.OptionsBehavior.Editable = true;

            this.repositoryItemInstallUnit1_CB.SelectedIndexChanged += new EventHandler(repositoryItemInstallUnit1_CB_SelectedIndexChanged);
            this.repositoryItemInstallUnit2_CB.SelectedIndexChanged += new EventHandler(repositoryItemInstallUnit2_CB_SelectedIndexChanged);
            this.repositoryItemTextEdit_Dept.Validating += new CancelEventHandler(repositoryItemTextEdit_Dept_Modified);
        }

        private void repositoryItemInstallUnit1_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(sender, dt_InstallUnit1, "InstallUnit1", "deptName");
        }

        private void repositoryItemInstallUnit2_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(sender, dt_InstallUnit2, "InstallUnit2", "cDCName");
        }

        private void repositoryItemTextEdit_Dept_Modified(object sender, EventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            DataRow dr = this.gridView1.GetDataRow(row);

            string sql = string.Empty;
            sql = string.Format(@"if not exists (select UserId from BaseInstallationUnitType where UserId='{0}')
                        insert BaseInstallationUnitType (UserId, userName, Dept)
                        values('{0}', '{1}','{2}')
                    else 
                        update BaseInstallationUnitType set Dept='{2}' where UserId='{0}'"
                , dr["UserId"].ToString(), dr["userName"].ToString(), gridView1.EditingValue.ToString());
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql.Replace("''", "null"));
        }
        /// <summary>
        /// 下拉表选择变更事件处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dt_InstallUnit">部门或地区表</param>
        /// <param name="installUnit">安装单位档案表，哪个安装单位字段名称</param>
        /// <param name="field">部门或地区字段名称</param>
        private void SelectedIndexChanged(object sender, DataTable dt_InstallUnit, string installUnit, string field)
        {
            int row = this.gridView1.FocusedRowHandle;
            DataRow dr = this.gridView1.GetDataRow(row);
            int index = ((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedIndex;

            string sql = string.Empty;
            sql = string.Format(@"if ({3}>=0) and not exists (select UserId from BaseInstallationUnitType where UserId='{0}')
                        insert BaseInstallationUnitType (UserId, userName, {4})
                        values('{0}', '{1}','{2}')
                    else 
                        update BaseInstallationUnitType set {4}='{2}' where UserId='{0}'"
                , dr["UserId"].ToString(), dr["userName"].ToString(), index < 0 ? "" : dt_InstallUnit.Rows[index][field].ToString(), index, installUnit);
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql.Replace("''", "null"));
        }

        /// <summary>
        /// GridControl控件加载数据
        /// </summary>
        private void LoadGrid()
        {
            string sql = string.Format(@"select u.UserId, u.userName, b.InstallUnit1, b.InstallUnit2, b.Dept from Users u left join BaseInstallationUnitType b on u.UserId = b.UserId where u.[State]=1");
            this.gridControl1.DataSource = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
        }
    }
}
