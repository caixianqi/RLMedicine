using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace U8Global
{
    public class U8args
    {
        public static void u8argsInput(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    UFBaseLib.BusLib.BaseInfo.UserName = args[0].Split('|')[0];
                    
                    UFBaseLib.BusLib.BaseInfo.DataSource = args[0].Split('|')[1];
                    UFBaseLib.BusLib.BaseInfo.operDate = args[0].Split('|')[2];
                    UFBaseLib.BusLib.BaseInfo.DBServerName = args[0].Split('|')[3].Replace("~", " ");
                    System.Data.SqlClient.SqlConnection conn = new
                                        System.Data.SqlClient.SqlConnection(U8Global.U8args.formatConnection(args[0].Split('|')[3].Replace("~", " ")));
                    U8Global.U8DataAcc.MainConn = conn;
                    U8Global.U8DataAcc.MainConn.Open();
                    UFBaseLib.BusLib.BaseInfo.UserId = args[0].Split('|')[4];
                    UFBaseLib.BusLib.BaseInfo.iYear = args[0].Split('|')[5];
                   
                    //UFBaseLib.BusLib.BaseInfo.i = args[0].Split('|')[6];
                    UFBaseLib.BusLib.BaseInfo.AccID = args[0].Split('|')[7];

                    //if (U8Global.U8DataAcc.GetUserAuth(UFBaseLib.BusLib.BaseInfo.UserId, "YSGL0301").Rows.Count <=0);
                    //{
                    //    //throw new Exception("用户没有权限！");
                    //    throw new Exception("用户没有权限！");
                    //    return;
                    //}
                }
                else
                {
                    //MessageBox.Show("3");
                    //HJ.Data.SQLDBConnect.DbConnectInit(GetConnection(".", "sa", "1", "UFDATA_002_2010"));
                    //HJ.Systems.Setting.OperateDate =  RiLiGlobal.RiLiDataAcc.GetNow();
                    //HJ.Systems.Setting.UserID = "demo";
                    //HJ.Systems.Setting.UserName = "demo";

                    UFBaseLib.BusLib.BaseInfo.UserName = "demo";
                    UFBaseLib.BusLib.BaseInfo.DataSource = "UFDATA_003_2011";
                    UFBaseLib.BusLib.BaseInfo.operDate = DateTime.Now.Date.ToLongDateString ();
                    UFBaseLib.BusLib.BaseInfo.DBServerName = "192.168.2.54";
                    System.Data.SqlClient.SqlConnection conn =
                                           new System.Data.SqlClient.SqlConnection(GetConnection("192.168.2.54", "UF", "1", "UFDATA_003_2011"));
                    U8Global.U8DataAcc.MainConn = conn;
                    U8Global.U8DataAcc.MainConn.Open();
                    UFBaseLib.BusLib.BaseInfo.UserId = "demo";
                    UFBaseLib.BusLib.BaseInfo.iYear = "2011";
                    //UFBaseLib.BusLib.BaseInfo.i = args[0].Split('|')[6];
                    UFBaseLib.BusLib.BaseInfo.AccID = "003";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static string formatConnection(string connstring)
        {
            string strconn = string.Empty;
            foreach (string str in connstring.Split(';'))
            {
                if (!str.ToLower().Contains("provider"))
                {
                    strconn += str + ";";
                }
            }
            return strconn;
        }
        private static string GetConnection(string sqlserver, string sa, string pwd, string databasename)
        {
            string _strconn = "workstation id=" + sqlserver + ";data source =" + sqlserver
                              + ";packet size=4096;user id="
                              + sa + ";password =" + pwd
                              + ";persist security info = true; initial catalog=" + databasename + ";Connect Timeout=30;Current Language=Simplified Chinese;";

            //string _strconn = "data source=.;user id = sa;password=1;initial catalog=ufdata_999_2010;connect timeout=30;persist security info = true;current language=simplified chinese;";
            return _strconn;
        }
    }
}
