using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PassWordConvert {
	public partial class frmMain : Form {
		public frmMain() {
			InitializeComponent();
		}

		/// <summary>
		/// 单击加密按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConvert_Click(object sender, EventArgs e) {
			ShowAftPwd();
		}

		/// <summary>
		/// 显示加密后密码
		/// </summary>
		private void ShowAftPwd() {
			txtAftPwd.Text = Encrypt.EPwd(txtBefPwd.Text);
			txtAftPwd.Focus();
			txtAftPwd.SelectAll();
		}

		/// <summary>
		/// 退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// 加密前密码获取焦点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBefPwd_Enter(object sender, EventArgs e) {
			txtBefPwd.Focus();
			txtBefPwd.SelectAll();
			txtAftPwd.Text = string.Empty;
		}


		/// <summary>
		/// 在加密前密码数据框中，按下并释放回车键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBefPwd_KeyPress(object sender, KeyPressEventArgs e) {
			if(e.KeyChar == 13){
				ShowAftPwd();
			}
		}
	}
}
