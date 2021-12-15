using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Repair.Report
{
    public partial class NoInstall : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string U8DataBaseName;

        public NoInstall()
        {
            InitializeComponent();
        }

        public void Authorization()
        {

        }


        private void NoInstall_Load(object sender, EventArgs e)
        {
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;

            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

            ClientCode_tb.BaoSQL = string.Format(@"select cCusCode,cCusAbbName as cCusName 
                                    from {0}.Customer ", U8DataBaseName);
            ClientCode_tb.BaoTitleNames = "cCusCode=客户编号,cCusName=客户名称";
            this.ClientCode_tb.FrmHigth = 500;
            this.ClientCode_tb.FrmWidth = 350;
            ClientCode_tb.DecideSql = "select * from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_tb.BaoColumnsWidth = "cCusCode=100,cCusName=200";

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();

            /*search = new RPTsearch();
            search.ShowDialog();

            if (RPTsearch.state == true)
            {
                this.LoadData("");
            }*/
        }

         /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void LoadData()
        {
            gridControl1.Focus();

            //序列号
            string cInvSN = this.txtcInvSN.Text;

            //客户编码
            string cCusCode = ClientCode_tb.Text;

            string sql = "";

            if (bTask.Checked)
            {
                if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
                {
                    MessageBox.Show("查询条件出错：开始日期大于结束日期！");
                    return;
                }

                sql = string.Format("exec [dbo].[sp_NoInstallList] '{0}','{1}','{2}','{3}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), cInvSN, cCusCode);
            }
            else
            {
                sql = string.Format("exec [dbo].[sp_NoInstallList] Null,Null,'{0}','{1}'", cInvSN, cCusCode);
            }

            DataTable dt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(sql).Tables[0];
            this.gridControl1.DataSource = dt;

        }

        private void BtnOutexcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                if (dt != null && dt.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "文件另存为";
                    sfd.Filter = "Excel2007|.xls";
                    sfd.FileName = "未发起任务统计表_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    string savePath = "";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        savePath = sfd.FileName;
                    }
                    if (string.IsNullOrEmpty(savePath))
                    {
                        MessageBox.Show("请选择导出路径！");
                        return;
                    }

                    //gridView1.ExportToXls(savePath);
                    gridView1.ExportToExcelOld(savePath);

                    MessageBox.Show("数据导出成功！");

                }
                else
                {
                    MessageBox.Show("无数据可导出！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误提示:" + ex.Message + "！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void ClientCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ClientCode_tb.Text = dr["cCusCode"].ToString();
            ClientName_tb.Text = dr["cCusName"].ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtcInvSN.Text = "";
            ClientCode_tb.Text = "";
            ClientName_tb.Text = "";
            bTask.Checked = false;

            string sql = "exec [dbo].[sp_NoInstallList] Null,Null,'1=0',''";
            DataTable dt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(sql).Tables[0];
            this.gridControl1.DataSource = dt;
        }


    }
}
