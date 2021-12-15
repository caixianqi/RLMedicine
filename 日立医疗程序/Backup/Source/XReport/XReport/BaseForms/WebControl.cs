using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace XtraReportsDemos
{
    public class WebControl : XtraReportsDemos.ModuleControl
	{
		[ToolboxItem(false)]
		private class WebBrowser : AxHost {
			object ocx;
			public WebBrowser() : base("8856f961-340a-11d0-a96b-00c04fd705a2") {
			}
			protected override void AttachInterfaces() {
				try {
					ocx = this.GetOcx();
				} catch {}
			}
			public void Navigate(string url) {
				if(ocx != null) {
					object nullObject = null;
					ocx.GetType().InvokeMember("Navigate2", System.Reflection.BindingFlags.InvokeMethod, 
						null, ocx, new object[] {url, nullObject, nullObject, nullObject, nullObject});
				}
			}
			protected override void WndProc(ref Message m) {
				if (m.Msg == DevExpress.XtraReports.Native.Win32.WM_SETFOCUS || m.Msg == DevExpress.XtraReports.Native.Win32.WM_KILLFOCUS)
					return;
				base.WndProc(ref m);
			}
		}
		private System.ComponentModel.IContainer components = null;
		private WebBrowser webBrowser;
		private IntPtr m_hMod;
		private IntPtr m_hMod2;
				
		public WebControl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			SetWebBrowserXPTheme();
			SetWebBrowserXPTheme();
			webBrowser = new WebBrowser();
			webBrowser.Dock = DockStyle.Fill;
			Controls.Add(webBrowser);
			webBrowser.ContainingControl = this;
		}

		private void SetWebBrowserXPTheme() {
			if ((m_hMod == IntPtr.Zero) || (m_hMod2 == IntPtr.Zero)) {
				Helper.INITCOMMONCONTROLSEX iccex = new Helper.INITCOMMONCONTROLSEX();
				iccex.dwICC = XtraReportsDemos.Helper.ICC_USEREX_CLASSES;
				XtraReportsDemos.Helper.InitCommonControlsEx(iccex);
				m_hMod = XtraReportsDemos.Helper.LoadLibrary("shell32.dll");
				m_hMod2 = XtraReportsDemos.Helper.LoadLibrary("explorer.exe");
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				XtraReportsDemos.Helper.FreeLibrary(m_hMod);
				XtraReportsDemos.Helper.FreeLibrary(m_hMod2);
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// WebControl
			// 
			this.Name = "WebControl";

		}
		#endregion

		public override void Activate() {
#if DXWhidbey
			webBrowser.Navigate("http://localhost/XtraReportsDemos_v6_2_2005/Bin/ReportWebDemo/Main.aspx");
#else
			webBrowser.Navigate("http://localhost/XtraReportsDemos_v6_2/Bin/WebNorthwindTraders/Main.aspx");	
#endif
		}
	}
}

