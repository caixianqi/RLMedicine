using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Data;


namespace Bao.MessageServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ThreadExceptionHandler handler =
                new ThreadExceptionHandler();

            Application.ThreadException +=
                new ThreadExceptionEventHandler(
                handler.Application_ThreadException);

            //将Enter转Tab
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.EnableVisualStyles();
            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
            //DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.XtraChartsLocalizer();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.XtraEditorsLocalizer();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.XtraGridLocalizer();
            //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.XtraLayoutLocalizer();
            //DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.XtraNavBarLocalizer();
            //DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.XtraPivotGridLocalizer();
            //DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.XtraPrintingLocalizer();
            //DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.XtraReportsLocalizer();
            //DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.XtraSchedulerLocalizer();
            //DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.XtraTreeListLocalizer();
            //DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.XtraVerticalGridLocalizer();
       
            Application.Run(new FrmMessageServer());
        }
    }
    #region 异常处理
    internal class ThreadExceptionHandler
    {
        /// 
        /// Handles the thread exception.
        /// 
        public void Application_ThreadException(
            object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                // Exit the program if the user clicks Abort.
                //if (e.Exception.GetType().ToString()=="System.ApplicationException")
                {
                    DialogResult result = ShowThreadExceptionDialog(
                        e.Exception);

                    if (result == DialogResult.Abort)
                        Application.Exit();
                }
            }
            catch
            {
                // Fatal error, terminate program
                try
                {
                    MessageBox.Show("Fatal Error",
                        "Fatal Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
        /// 
        /// Creates and displays the error message.
        /// 
        private DialogResult ShowThreadExceptionDialog(Exception ex)
        {
            //			string errorMessage= 
            //				"Unhandled Exception:\n\n" +
            //				ex.Message + "\n\n" + 
            //				ex.GetType() + 
            //				"\n\nStack Trace:\n" + 
            //				ex.StackTrace;
            string errorMessage = ex.Message;
            return MessageBox.Show(errorMessage,
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }
        
    }
    #endregion

    /// <summary>
    /// 将Enter键值转换到Tab键值（控件的Tag值为"*****"的除外）
    /// </summary>
    class EnterToTab : IMessageFilter //gets the left mouse button messages
    {
        Form self;
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_CLOSE = 0xF060;
        public EnterToTab(Form Form1)
        {
            self = Form1;
            
        }
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            //if ( m.Msg ==WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)    //关闭本窗体的方法
            //{
            //    MessageBox.Show("eeee");
            //    //Minmessage = 0;
            //}
            
           
            if (m.Msg == 256)
            {

                if (self.ActiveMdiChild != null)
                {
                    if (self.ActiveMdiChild.ActiveControl.Tag == null || self.ActiveMdiChild.ActiveControl.Tag.ToString() != "*****")
                    {
                        if ((int)m.WParam == 13)
                        {
                            SendKeys.Send("{TAB}");
                            return true;
                        }
                        
                        return false;
                    }
                    
                    return false;
                }
                return false;
            }
            return false;
        }
    }


}