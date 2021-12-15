using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.Message {
	public partial class FrmUnfinishedMatters : Form {
		public FrmUnfinishedMatters() {
			InitializeComponent();
		}
		public Bao.IFromMain iform;
		string strSql = string.Empty;
		DataSet dsUnfinishedMaters = new DataSet();
		private void FrmUnfinishedMatters_Load(object sender, EventArgs e) {
            this.BeginDate.Value =DateTime.Now.AddDays(-30).Date;
            this.EndDate.Value = DateTime.Now.Date;
           this.timer1.Enabled = true;   
			Init();
		}

		private void Init() {
         
              
            
            string strSql = RecieveMessage(UFBaseLib.BusLib.BaseInfo.UserId.Trim(),this.BeginDate.Value, this.EndDate.Value.AddDays(1).Date);
			dsUnfinishedMaters = Bao.DataAccess.DataAcc.GetDataSet(strSql);

			dsUnfinishedMaters.Tables[0].Columns.Add("Form", typeof(Form));
			this.gcAll.DataSource = dsUnfinishedMaters.Tables[0];
			this.gridView1.ExpandAllGroups();


            //for (int i = 0; i < this.gridView1.DataRowCount; i++)
            //{
            //    if( this.gridView1.GetDataRow(i)["Isread"] == "已读")
            //    {
            //        this.gridView1.Columns["Isread"].dis`
            //    }
             
            //}

			this.gcAll.Refresh();
		}

		/// <summary>
		/// 获取审核信息
		/// </summary>
		/// <param name="DescUserId"></param>
		/// <param name="BeginDate"></param>
		/// <param name="EndDate"></param>
		/// <param name="Conditions"></param>
		/// <returns></returns>
//        public static System.Data.DataTable RecieveMessage(string DescUserId, System.DateTime BeginDate, System.DateTime EndDate, string AuditStatus) {
//            string sql = string.Format(@"SELECT a.*, b.DLLName, b.WorkName, c.userName, 
//											  b.Title, b.TitleGroup, a.BillKeyId AS Param, 
//											  e.AuditFlag,(select UserName from Users where AutoUserId=a.SourceUserId) as SourceUserName 
//										FROM TMessageAuto a LEFT OUTER JOIN
//											  TFunctions b ON a.FunctionId = b.FunctionId LEFT OUTER JOIN
//											  Users c ON a.DescUserId = c.AutoUserId INNER JOIN
//											  AuditFlowLineUser d ON d.BillId = a.BillKeyId AND d.AuditUserId = '{0}' INNER JOIN
//											  AuditFlowLine e ON e.BillId = d.BillId AND e.AutoFlowId = d.AutoFlowId AND 
//											  e.AuditFlag = '{1}'
//										WHERE (a.DescUserId = '{0}') AND (a.MessageDate >= '{2}') AND 
//											  (a.MessageDate <= '{3}')", DescUserId, AuditStatus, BeginDate, EndDate);
//            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
//        }

		public static string RecieveMessage(string DescUserId, System.DateTime BeginDate, System.DateTime EndDate) {
//            string sql = string.Format(@"SELECT a.*, b.DLLName, b.WorkName, c.userName, 
//											  b.Title, b.TitleGroup, a.BillKeyId AS Param
//										FROM TMessageAuto a LEFT OUTER JOIN
//											  TFunctions b ON a.FunctionId = b.FunctionId LEFT OUTER JOIN
//											  Users c ON a.SourceUserId = c.AutoUserId INNER JOIN
//											  AuditFlowLineUser d ON d.BillId = a.BillKeyId AND d.AuditUserId = '{0}' INNER JOIN
//											  AuditFlowLine e ON e.BillId = d.BillId AND e.AutoFlowId = d.AutoFlowId AND 
//											  e.AuditFlag = '{1}'
//										WHERE (a.DescUserId = '{0}') AND (a.MessageDate >= '{2}') AND 
//											  (a.MessageDate <= '{3}') ", DescUserId, AuditStatus, BeginDate, EndDate);

//            string sql = string.Format(@"SELECT DISTINCT a.*, b.DLLName, b.WorkName, c.userName, 
//								  b.Title, b.TitleGroup, a.BillKeyId AS Param,case when isnull(e.AuditFlag,0) =0 then '未处理' else '已处理' end AuditFlag
//							FROM TMessageAuto a LEFT OUTER JOIN
//								  TFunctions b ON a.FunctionId = b.FunctionId LEFT OUTER JOIN
//								  Users c ON a.SourceUserId = c.AutoUserId Left outer JOIN
//								  AuditFlowLine e ON e.BillId = a.BillKeyId  and a.DescUserId=e.AuditUserId
//							WHERE (a.DescUserId = '{0}') AND (a.MessageDate >= '{1}') AND 
//								  (a.MessageDate <= '{2}') order by MessageDate desc"
//                           , DescUserId, BeginDate, EndDate);


			string sql = string.Format(@"SELECT DISTINCT a.*, b.DLLName, b.WorkName, c.userName, 
												  b.Title, b.TitleGroup, a.BillKeyId AS Param,(case when IsBrows = 0 then '未读' else '已读' end) as Isread,
										case when (isnull(e.AuditFlag,0) =0 AND (a.MessageTitle NOT LIKE '恭喜%' AND a.MessageTitle NOT LIKE '打回%' AND a.MessageTitle NOT LIKE '审核人员%'))
										OR ((a.MessageTitle NOT LIKE '恭喜%' OR a.MessageTitle NOT LIKE '打回%' OR a.MessageTitle NOT LIKE '审核人员%') AND a.IsBrows=0) then '未处理' 
										else '已处理' end AuditFlag
											FROM TMessageAuto a LEFT OUTER JOIN
												  TFunctions b ON a.FunctionId = b.FunctionId LEFT OUTER JOIN
												  Users c ON a.SourceUserId = c.AutoUserId Left outer JOIN
												  AuditFlowLine e ON e.BillId = a.BillKeyId  and a.DescUserId=e.AuditUserId
											WHERE (a.DescUserId = '{0}') AND (a.MessageDate >= '{1}') AND 
												  (a.MessageDate <= '{2}') order by MessageDate desc", DescUserId, BeginDate, EndDate);


			return sql;
		}

		/// <summary>
		/// 双击事项行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gcAll_DoubleClick(object sender, EventArgs e) {
			ShowAuditFrom(this.gridView1);
		}

		/// <summary>
		/// 显示审核界面 
		/// </summary>
		private void ShowAuditFrom(DevExpress.XtraGrid.Views.Grid.GridView gdView) {
			if (gdView.FocusedRowHandle >= 0 && Convert.ToString(gdView.GetDataRow(gdView.FocusedRowHandle)["DLLName"]) != "") {
				iform.ShowChildForm(gdView.GetDataRow(gdView.FocusedRowHandle));
				CMessage.SendReadedFlag(gdView.GetDataRow(gdView.FocusedRowHandle)["MessageId"].ToString());
			}
		}

		/// <summary>
		/// 双击事项行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gcUnaudited_DoubleClick(object sender, EventArgs e) {
		}

		/// <summary>
		/// 双击事项行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gcAgree_DoubleClick(object sender, EventArgs e) {
		}

		/// <summary>
		/// 双击事项行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gcNotAgree_DoubleClick(object sender, EventArgs e) {
		}

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Init();

           
        }
	}
}
