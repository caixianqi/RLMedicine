using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace RiLiGlobal
{
    public class RiLiDataAcc
    {
        #region 静态属性

        public static System.Data.SqlClient.SqlConnection MainConn = new SqlConnection();
        public static System.Data.SqlClient.SqlCommand UpLoadCmd = new SqlCommand();
        public static System.Data.SqlClient.SqlConnection RiLiMainConn = new SqlConnection();
        
        /// <summary>
        /// 用户名
        /// </summary>
        public static string cUserId;//用户名
        /// <summary>
        /// 用户名称
        /// </summary>
        public static string cUserName;//用户名称
        /// <summary>
        /// 密码
        /// </summary>
        public static string Password;//密码
        /// <summary>
        /// 帐套ID
        /// </summary>
        public static string AccID;//帐套ID
        /// <summary>
        /// 帐套年度
        /// </summary>
        public static string iYear;//帐套年度
        /// <summary>
        /// 登录日期月份
        /// </summary>
        public static string iMonth;//登录日期月份
        /// <summary>
        /// 子系统号
        /// </summary>
        public static string cSubID;//子系统号
        /// <summary>
        /// 数据库服务器名称
        /// </summary>
        public static string dbServerName;//数据库服务器名称
        /// <summary>
        /// 帐套简称  (default)@999
        /// </summary>
        public static string DataSource;//帐套简称  (default)@999
        /// <summary>
        /// 年度库的连接串
        /// </summary>
        public static string UfDbName;//年度库的连接串
        /// <summary>
        /// 登陆界面的业务日期
        /// </summary>
        public static string CurDate;//登陆界面的业务日期
        /// <summary>
        /// 登陆界面的业务日期
        /// </summary>
        public static DateTime RiLi_CurDate;//登陆界面的业务日期
        /// <summary>
        /// 工作站的唯一序列号
        /// </summary>
        public static string WorkStationSerial;//工作站的唯一序列号

        /// <summary>
        /// 语言
        /// </summary>
        public static int LanguageRegion;//语言

        /// <summary>
        /// 是否集团帐套=true,集团版
        /// </summary>
        public static bool IsCompanyVer;//是否集团帐套=true,集团版

        /// <summary>
        /// 是否管理员
        /// </summary>
        public static bool IsAdmin;//是否管理员

        /// <summary>
        /// RiLi数据库名称
        /// </summary>
        public static string RiLiDataBase; //RiLi数据库名称

        public static string Define1;  //备注字段1
        public static string Define2;  //备注字段2
        public static string Define3;  //备注字段3
        public static int Define4;     //备注字段4
        public static decimal Define5; //备注字段5
        public static decimal Define6; //备注字段6

        public static string DataBase;  //数据库名称

        private static string uapBasePath = null;
        public static string UapBasePath
        {
            get
            {
                return uapBasePath;
            }
            set
            {
                uapBasePath = value;
            }
        }
        #endregion

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNow()
        {
            DateTime now;

             DateTime.TryParse(RiLiExecuteScalar("select GetDate()"), out now);

             return now;

        }

        public static string ProcessDateforSQL(string date)
        {
            if (date == string.Empty)
            {
                return "null";
            }
            else if (date == "1900-01-01 00:00:00.000")
            {
                return "null";
            }
           
            else
            {
                return "'" + date + "'";
            }

        }

        #region get RiLi默认的数据连接字符串

        /// <summary>
        ///  RiLi默认的数据连接字符串
        /// </summary>
        public static string DefConnStr
        {
            get
            {
                return UfDbName;
            }
            set
            {
                UfDbName = value;
            }
        }
        #endregion

        #region 字符串中获取值,如字符串 'abc="aa";'求 abc的值

        /// <summary>
        ///  字符串中获取值,如字符串 'abc="aa";'求 abc的值
        /// </summary>
        /// <param name="resStr">字符串</param>
        /// <param name="valStr"></param>
        /// <returns></returns>
        public static string getStrValue(string resStr, string valStr)
        {
            resStr = resStr.Trim();
            valStr += "=";
            int len_resStr = resStr.Length;
            int len_valStr = valStr.Length;
            int start = resStr.IndexOf(valStr) + len_valStr;
            int end = resStr.IndexOf(";", start);
            if (0 > end)
            {
                end = len_resStr;
            }
            return resStr.Substring(start, end - start).Trim('"');
        }
        #endregion

        #region  判断一个值是不是一个数字

        /// <summary>
        /// 判断一个值是不是一个数字
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNum(object val)
        {
            try
            {
                Convert.ToSingle(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 判断一个值是不是布尔型
        /// <summary>
        ///  判断一个值是不是布尔型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsBool(object val)
        {
            try
            {
                Convert.ToBoolean(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 去掉字符中的不可见字符

        /// <summary>
        /// 去掉字符中的不可见字符
        /// </summary>
        /// <param name="str">带有不可见字符的字符串</param>
        /// <returns></returns>
        public static string SubString2_L(string str)
        {
            // string st = "34,13,10";
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes = new byte[ByteFoo.Length];
            if (ByteFoo.Length == 0) return "";
            int j = 0;
            for (int i = 0; i < ByteFoo.Length; i++)
            {
                // if (st.IndexOf(ByteFoo[i].ToString())>0)
                if (ByteFoo[i] == 34 || ByteFoo[i] == 13 || ByteFoo[i] == 10)
                {

                }
                else
                {
                    ByteRes[j] = ByteFoo[i];
                    j++;
                }
            }

            //byte[] byteRes1 = new byte[j];
            //for (int i = 0; i < byteRes1.Length; i++)
            //{
            //    byteRes1[i] = ByteRes[i];
            //}
            //return System.Text.Encoding.Default.GetString(byteRes1);
            return System.Text.Encoding.Default.GetString(ByteRes, 0, j);
        }

        #endregion

        #region 将字符串中的特定字符去掉,特定字符不能是双字节字符

        /// <summary>
        /// 将字符串中的特定字符去掉,特定字符不能是双字节字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="dstr">特定字符</param>
        /// <returns></returns>
        public static string Substring3_L(string str, char Tstr)
        {
            #region 将部门编号中间的“-”去掉
            // byte[] TByte = System.Text.Encoding.Default.GetBytes(Tstr);
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes = new byte[ByteFoo.Length];

            int j = 0;
            for (int i = 0; i < ByteFoo.Length; i++)
            {

                if (ByteFoo[i] != Tstr)
                {
                    ByteRes[j] = ByteFoo[i];
                    j++;
                }
            }

            //byte[] byteRes1 = new byte[j];
            //for (int i = 0; i < byteRes1.Length; i++)
            //{
            //    byteRes1[i] = ByteRes[i];
            //}
            //return System.Text.Encoding.Default.GetString(byteRes1);
            return System.Text.Encoding.Default.GetString(ByteRes, 0, j);
            #endregion

        }

        #endregion

        #region 统计字符串中特定字符的个数特定字符不能是双字节字符

        /// <summary>
        /// 统计字符串中特定字符的个数特定字符不能是双字节字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Tstr"></param>
        /// <returns></returns>
        public static int SubNum(string str, char Tstr)
        {

            //byte[] TByte = System.Text.Encoding.Default.GetBytes(Tstr);
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes = new byte[ByteFoo.Length];

            int j = 0;
            for (int i = 0; i < ByteFoo.Length; i++)
            {
                if (ByteFoo[i] == Tstr)
                {
                    j++;
                }
            }


            return j;
        }

        #endregion

        #region  取得第Num个特定字符前的数据

        /// <summary>
        ///  取得第Num个特定字符前的数据
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="Tstr">特定字符</param>
        /// <param name="Num">从左起特定字符出现的次数</param>
        /// <returns></returns>
        public static string Substring4_L(string str, char Tstr, int Num)
        {

            // byte[] TByte = System.Text.Encoding.Default.GetBytes(Tstr);
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes = new byte[ByteFoo.Length];

            int j = 0;
            int k = 0;   //特定字符出现的次数
            for (int i = 0; i < ByteFoo.Length; i++)
            {

                if (ByteFoo[i] == Tstr)
                {
                    k++;
                    if (k >= Num)
                        break;
                }
                /*else
                {
                    ByteRes[j] = ByteFoo[i];
                    j++;
                }*/
                j++;
                ByteRes[i] = ByteFoo[i];
            }


            return System.Text.Encoding.Default.GetString(ByteRes, 0, j);

        }

        #endregion

        #region   取得第Num个特定字符后的数据

        /// <summary>
        ///  取得第Num个特定字符后的数据
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="Tstr">特定字符</param>
        /// <param name="Num">从左起特定字符出现的次数</param>
        /// <returns></returns>
        public static string SubstringR_L(string str, char Tstr, int Num)
        {
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes = new byte[ByteFoo.Length];

            int j = 0;
            int k = 0;   //特定字符出现的次数
            Boolean beginNum = false; ;
            for (int i = 0; i < ByteFoo.Length; i++)
            {
                if (ByteFoo[i] == Tstr)
                {
                    k++;
                    if (k >= Num)
                    {
                        beginNum = true;
                        continue;
                    }

                }
                if (beginNum)
                {
                    ByteRes[j] = ByteFoo[i];
                    j++;
                }

            }
            return System.Text.Encoding.Default.GetString(ByteRes, 0, j);
        }

        #endregion

        #region 导入 Excel公共方法
        /// <summary>
        /// 导入 Excel公共方法
        /// </summary>
        /// <param name="GridViewSource">GridView</param>
        /// <param name="FileName">参数，暂时没启用</param>
        public static void Import_Excel(DevExpress.XtraGrid.Views.Grid.GridView GridViewSource, string FileName)
        {
            SaveFileDialog SF = new SaveFileDialog();
            if (GridViewSource == null)
                throw new Exception("RptControl 控件的GridViewSource 属性不能为空");
            SF.Filter = "Excel files (*.xls)|*.xls";
            SF.Title = FileName;
            SF.RestoreDirectory = true;
            SF.FilterIndex = 1;
            if (SF.ShowDialog() == DialogResult.OK && SF.FileName != string.Empty)
            {
                GridViewSource.ExportToXls(SF.FileName);
                MessageBox.Show("文件导出成功", "温馨提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// DevExpress.XtraGrid.Views.Grid.GridView 导出xls文件
        /// </summary>
        /// <param name="_gridView"></param>
        /// <returns></returns>
        public static string EXToExcel(DevExpress.XtraGrid.Views.Grid.GridView _gridView)
        {
            string mess = null;
            System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog();
            //只能导出EXCEL文件
            _sfd.Filter = "xls文件 (*.xls)| *.xls";
            //是否确定保存
            try
            {
                if (System.Windows.Forms.DialogResult.OK == _sfd.ShowDialog())
                {
                    //导出文件
                    _gridView.ExportToXls(_sfd.FileName);
                    mess = "导出成功!!";
                }
                else
                {
                    mess = "取消导出!!";
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message.Trim();
            }
            //返回是否保存成功
            return mess;
        }

        #endregion

        #region  打开RiLi连接  RiLiGetConn()

        /// <summary>
        /// 打开RiLi连接  RiLiGetConn()  
        /// </summary>
        public static void RiLiGetConn()
        {

            if (RiLiMainConn.State == System.Data.ConnectionState.Closed)
            {
                if (DefConnStr != null || DefConnStr != "")
                {
                    //PROVIDER

                    RiLiMainConn.ConnectionString = DefConnStr;
                }
                try
                {
                    RiLiMainConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("连接数据库失败，原因:" + e.Message);
                }
            }
            UpLoadCmd.Connection = RiLiMainConn;
        }

        #endregion

        #region  RiLiSQL脚本 处理

        public static string RiLiExecuteScalar(string sqlText)
        {
            RiLiGetConn();
            UpLoadCmd.CommandText = sqlText;
            object ss = UpLoadCmd.ExecuteScalar();
            if (ss == null)
                return "";
            else
                return ss.ToString();
            //  return UpLoadCmd.ExecuteScalar().ToString();
        }

        public static object RiLiGetScalar(string sqlText)
        {
            try
            {
                RiLiGetConn();
                UpLoadCmd.CommandText = sqlText;
                object value = UpLoadCmd.ExecuteScalar();

                return value;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                //conn.Close();
            }
        }

        public static void RiLiExecuteNotQuery(string sqlText)
        {
            RiLiGetConn();
            UpLoadCmd.CommandText = sqlText;
            UpLoadCmd.ExecuteNonQuery();
        }

        public static System.Data.DataTable RiLiExecuteQuery(string sqlText)
        {
            GetConn();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlText, RiLiMainConn);

            //SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            System.Data.DataTable table1 = ds.Tables[0];
            ds.Tables.Remove(ds.Tables[0]);
            return table1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static System.Data.DataTable RiLiExecuteQuery(string sqlText, string TableName)
        {
            RiLiGetConn();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, RiLiMainConn);
                //SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                System.Data.DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds, TableName);
                System.Data.DataTable table1 = ds.Tables[0];
                ds.Tables.Remove(ds.Tables[0]);
                return table1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "(" + sqlText + ")");
            }
        }



        /// <summary>
        /// 返回数据集  数据查询
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        /// 
        public static DataSet RiLiGetDataSet(string sqlStr)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(DefConnStr);
                cn.Open();
                SqlDataAdapter dataApt = new SqlDataAdapter(sqlStr, cn);
                DataSet ds = new DataSet();
                dataApt.Fill(ds, "t");
                cn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行语句（" + sqlStr + "）时出错, 错误信息：" + e.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// 返回数据集  数据查询
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <returns></returns>
        public static DataSet RiLiGetDataSet(SqlCommand sqlcmd)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(DefConnStr);
                cn.Open();
                sqlcmd.Connection = cn;
                SqlDataAdapter dataApt = new SqlDataAdapter(sqlcmd);
                DataSet ds = new DataSet();
                dataApt.Fill(ds, "t");
                cn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行语句（" + sqlcmd.CommandText + "）时出错, 错误信息：" + e.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #region  打开连接   GetConn()

        /// <summary>
        /// 打开连接   GetConn()
        /// </summary>
        public static void GetConn()
        {

            if (MainConn.State == System.Data.ConnectionState.Closed)
            {


                if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini"))
                    throw new Exception("没有数据库连接文件。");
                IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiLiDBini.ini");
                string server = IniObj.read("database", "server", "");
                DataBase = IniObj.read("database", "database", "");
                //string user =DPwd( IniObj.read("database", "user", ""));
                //string password =DPwd( IniObj.read("database", "password", ""));//当加密了的时候用此两个方法解密
                string user = IniObj.read("database", "user", "");
                string password = IniObj.read("database", "password", "");
                string conn = string.Empty;
                conn = "uid=" + user + ";initial catalog=" + DataBase + ";data source=" + server + ";password=" + password + ";Connect Timeout=10000";
                MainConn.ConnectionString = conn;
                try
                {
                    MainConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("连接数据库失败，原因:" + e.Message);
                }

            }
            UpLoadCmd.Connection = MainConn;
            RiLiMainConn = MainConn;
        }

        #endregion

        #region SQL脚本 处理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sqlText)
        {
            //SqlCommand sqlComm = new SqlCommand(sqlText, MainConn);

            //SqlDataReader dr = sqlComm.ExecuteReader();
            // return dr;
            // UpLoadCmd.close();
            UpLoadCmd.CommandText = sqlText;
            return UpLoadCmd.ExecuteReader();

        }
        public static string ExecuteScalar(string sqlText)
        {
            GetConn();
            UpLoadCmd.CommandText = sqlText;
            object ss = UpLoadCmd.ExecuteScalar();
            if (ss == null)
                return "";
            else
                return ss.ToString();
            //  return UpLoadCmd.ExecuteScalar().ToString();
        }


        public static object GetScalar(string sqlText)
        {
            try
            {
                GetConn();
                UpLoadCmd.CommandText = sqlText;
                object value = UpLoadCmd.ExecuteScalar();

                return value;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                //conn.Close();
            }
        }

        public static System.Data.DataSet GetDataSet(string sqlStr)
        {
            try
            {
                GetConn();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, MainConn);
                System.Data.DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行语句（" + sqlStr + "）时出错, 错误信息：" + e.Message);
            }

        }

        public static System.Data.DataSet GetDataSet(SqlCommand sqlcmd)
        {
            GetConn();
            try
            {
                SqlDataAdapter dataApt = new SqlDataAdapter(sqlcmd);
                DataSet ds = new DataSet();
                dataApt.Fill(ds, "t");
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行语句（" + sqlcmd.CommandText + "）时出错, 错误信息：" + e.Message);
            }
        }




        public static System.Data.DataTable ExecuteQuery(string sqlText)
        {
            GetConn();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlText, MainConn);

            //SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            System.Data.DataTable table1 = ds.Tables[0];
            ds.Tables.Remove(ds.Tables[0]);
            return table1;

        }

        public static System.Data.DataTable ExecuteQuery(string sqlText, string TableName)
        {
            GetConn();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, MainConn);
                //SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                System.Data.DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds, TableName);
                System.Data.DataTable table1 = ds.Tables[0];
                ds.Tables.Remove(ds.Tables[0]);
                return table1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "(" + sqlText + ")");
            }
        }

        public static void ExecuteNotQuery(string sqlText)
        {
            GetConn();
            UpLoadCmd.CommandText = sqlText;
            UpLoadCmd.ExecuteNonQuery();
        }
        #endregion

        #region   存储过程处理

        /// <summary>
        /// 获得指定的数据更新适配器对象
        /// </summary>
        /// <param name="_insertCommand">插入命令对象</param>
        /// <param name="_updateCommand">更新命令对象</param>
        /// <param name="_deleteCommand">删除命令对象</param>
        /// <param name="_tran"></param>
        /// <returns>数据更新适配器对象</returns>
        public static SqlDataAdapter BuildDataAdpter(SqlCommand _insertCommand, SqlCommand _updateCommand, SqlCommand _deleteCommand, SqlTransaction _tran)
        {
            SqlDataAdapter _da = new SqlDataAdapter();
            _da.InsertCommand = _insertCommand;
            _da.InsertCommand.CommandTimeout = 3600;//设置超时为1小时
            _da.InsertCommand.Connection = _tran.Connection;
            _da.InsertCommand.Transaction = _tran;

            _da.UpdateCommand = _updateCommand;
            _da.UpdateCommand.CommandTimeout = 3600;
            _da.UpdateCommand.Connection = _tran.Connection;
            _da.UpdateCommand.Transaction = _tran;

            _da.DeleteCommand = _deleteCommand;
            _da.DeleteCommand.CommandTimeout = 3600;
            _da.DeleteCommand.Connection = _tran.Connection;
            _da.DeleteCommand.Transaction = _tran;

            return _da;
        }


        /// <summary>
        /// 获得指定的数据检索适配器
        /// </summary>
        /// <param name="selectCmd">SQL语句</param>
        /// <returns>数据检索适配器</returns>
        public static SqlDataAdapter BuildDataAdpter(string selectCmd)
        {
            //确认打开连接
            GetConn();
            SqlDataAdapter _da = new SqlDataAdapter(selectCmd, MainConn);
            _da.SelectCommand.CommandTimeout = 3600;//设置超时为1小时
            return _da;
        }

        /// <summary>
        /// 返回指定的数据查询命令
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>数据查询命令</returns>
        public static SqlCommand BuildCommand(string cmdText)
        {
            GetConn();
            //SqlCommand cmd = new SqlCommand(cmdText, conn);
            //cmd.CommandTimeout = 3600;
            UpLoadCmd.CommandTimeout = 3600;
            return UpLoadCmd;
        }

        /// <summary>
        /// 返回指定的数据查询命令
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="tran">事务对象</param> 
        /// <returns>数据查询命令</returns>
        public static SqlCommand BuildCommand(string cmdText, System.Data.SqlClient.SqlTransaction tran)
        {
            GetConn();
            //SqlCommand cmd = new SqlCommand(cmdText);
            //cmd.CommandTimeout = 3600;
            //cmd.Connection = tran.Connection;
            //cmd.Transaction = tran;
            //return cmd;
            UpLoadCmd.CommandTimeout = 3600;
            UpLoadCmd.Connection = tran.Connection;
            UpLoadCmd.Transaction = tran;
            return UpLoadCmd;
        }


        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="proconame">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private static SqlCommand CreateCommand(string cmdText, SqlParameter[] prams)
        {
            // 确认打开连接
            GetConn();
            //SqlCommand cmd = new SqlCommand(cmdText, conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            UpLoadCmd.CommandType = CommandType.StoredProcedure;

            // 依次把参数传入存储过程
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    UpLoadCmd.Parameters.Add(parameter);
            }

            // 加入返回参数
            UpLoadCmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return UpLoadCmd;
        }


        public static SqlCommand CreateCommand(string cmdText)
        {
            GetConn();
            //SqlCommand cmd = new SqlCommand(cmdText, conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            UpLoadCmd.CommandType = CommandType.StoredProcedure;
            return UpLoadCmd;
        }

        #endregion

        #region  RiLi 存储过程处理

        /// <summary>
        /// 获得指定的数据更新适配器对象
        /// </summary>
        /// <param name="_insertCommand">插入命令对象</param>
        /// <param name="_updateCommand">更新命令对象</param>
        /// <param name="_deleteCommand">删除命令对象</param>
        /// <param name="_tran"></param>
        /// <returns>数据更新适配器对象</returns>
        public static SqlDataAdapter RiLiBuildDataAdpter(SqlCommand _insertCommand, SqlCommand _updateCommand, SqlCommand _deleteCommand, SqlTransaction _tran)
        {
            SqlDataAdapter _da = new SqlDataAdapter();
            _da.InsertCommand = _insertCommand;
            _da.InsertCommand.CommandTimeout = 3600;//设置超时为1小时
            _da.InsertCommand.Connection = _tran.Connection;
            _da.InsertCommand.Transaction = _tran;

            _da.UpdateCommand = _updateCommand;
            _da.UpdateCommand.CommandTimeout = 3600;
            _da.UpdateCommand.Connection = _tran.Connection;
            _da.UpdateCommand.Transaction = _tran;

            _da.DeleteCommand = _deleteCommand;
            _da.DeleteCommand.CommandTimeout = 3600;
            _da.DeleteCommand.Connection = _tran.Connection;
            _da.DeleteCommand.Transaction = _tran;

            return _da;
        }


        /// <summary>
        /// 获得指定的数据检索适配器
        /// </summary>
        /// <param name="selectCmd">SQL语句</param>
        /// <returns>数据检索适配器</returns>
        public static SqlDataAdapter RiLiBuildDataAdpter(string selectCmd)
        {
            //确认打开连接
            RiLiGetConn();
            SqlDataAdapter _da = new SqlDataAdapter(selectCmd, RiLiMainConn);
            _da.SelectCommand.CommandTimeout = 3600;//设置超时为1小时
            return _da;
        }

        /// <summary>
        /// 返回指定的数据查询命令
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>数据查询命令</returns>
        public static SqlCommand RiLiBuildCommand(string cmdText)
        {
            RiLiGetConn();
            UpLoadCmd.CommandTimeout = 3600;
            return UpLoadCmd;
        }

        /// <summary>
        /// 返回指定的数据查询命令
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="tran">事务对象</param> 
        /// <returns>数据查询命令</returns>
        public static SqlCommand RiLiBuildCommand(string cmdText, System.Data.SqlClient.SqlTransaction tran)
        {
            RiLiGetConn();
            UpLoadCmd.CommandTimeout = 3600;
            UpLoadCmd.Connection = tran.Connection;
            UpLoadCmd.Transaction = tran;
            return UpLoadCmd;
        }


        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="proconame">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private static SqlCommand RiLiCreateCommand(string cmdText, SqlParameter[] prams)
        {
            // 确认打开连接
            RiLiGetConn();
            UpLoadCmd.CommandType = CommandType.StoredProcedure;

            // 依次把参数传入存储过程
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    UpLoadCmd.Parameters.Add(parameter);
            }

            // 加入返回参数
            UpLoadCmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return UpLoadCmd;
        }


        public static SqlCommand RiLiCreateCommand(string cmdText)
        {
            RiLiGetConn();
            UpLoadCmd.CommandType = CommandType.StoredProcedure;
            return UpLoadCmd;
        }

        #endregion

        #region 设置表格只读
        /// <summary>
        /// 设置表格只读
        /// </summary>
        /// <param name="_gridview"></param>
        /// <param name="isReadonly"></param>
        public static void setGridReadonly(DevExpress.XtraGrid.Views.Grid.GridView _gridview, Boolean isReadonly)
        {
            for (int i = 0; i < _gridview.Columns.Count; i++)
            {
                _gridview.Columns[i].OptionsColumn.AllowEdit = !isReadonly;
            }
        }
        #endregion

        #region 字符串中的字符位置调换

        /// <summary> 
        /// 字符串中的字符位置调换  //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
        /// </summary>
        /// <param name="resStr"></param>
        /// <param name="bakPos1"></param>
        /// <param name="bakPos2"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ChangeStringPosi(string resStr, int bakPos1, int bakPos2, int length)
        {
            string a01 = resStr.Substring(0, resStr.Length - bakPos1);
            string a02 = resStr.Substring(resStr.Length - bakPos1, length);
            string a03 = resStr.Substring(resStr.Length - bakPos1 + length, bakPos1 - bakPos2 - length);
            string a04 = resStr.Substring(resStr.Length - length);
            return a01 + a04 + a03 + a02;
        }
        #endregion

        #region 64位编码
        /// <summary>
        /// 64位编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(string str)
        {
            byte[] barray;
            barray = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(barray);
        }
        #endregion

        #region 64位解码
        /// <summary>
        /// 64位解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decode(string str)
        {
            byte[] barray;
            barray = Convert.FromBase64String(str);
            return Encoding.Default.GetString(barray);
        }
        #endregion

        #region 加密解密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static string EPwd(string res)
        {
            res += "xueray";
            string pwd = Base64Encode(res);
            //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
            pwd = ChangeStringPosi(pwd, 6, 2, 2);
            //进一步编码
            pwd = Base64Encode(pwd);
            return pwd;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string DPwd(string pwd)
        {
            string res = "";
            try
            {
                res = Base64Decode(pwd);
                //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
                res = ChangeStringPosi(res, 6, 2, 2);
                //进一步编码
                res = Base64Decode(res);
                res = res.Substring(0, res.Length - "xueray".Length);
            }
            catch (Exception ex)
            {
                res = "";
                throw ex;
            }
            return res;
        }

        #endregion

        #region 获取指定条件的数据表列值
        /// <summary>
        ///  获取指定条件的数据表列值
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="resCol"></param>
        /// <param name="ResValue"></param>
        /// <param name="tagCol"></param>
        /// <param name="tagValue"></param>
        /// <returns></returns>
        public static string getColValue(DataTable dt, string resCol, string ResValue, string tagCol, out string tagValue)
        {
            string mess = null;
            tagValue = "";
            try
            {
                DataRow[] drArr = dt.Select(resCol.Trim() + "='" + ResValue.Trim() + "'");
                if (0 < drArr.Length)
                {
                    tagValue = drArr[0][tagCol].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message.Trim();
            }

            return mess;
        }
        #endregion

        #region   数据插入Excel操作类

        /// <summary>
        /// 复制Excel模板到选择的路径并打开新的Excel
        /// </summary>
        /// <param name="_myExcel">Excel对象</param>
        /// <param name="_templatePath">模板名称</param>
        /// <returns>是否成功</returns>
        public static bool CopyAndOpenExcel(Excel.Application _myExcel, string _templateName)
        {
            string filename = "";
            SaveFileDialog mySave = new SaveFileDialog();
            mySave.Filter = "Excel文件(*.XLS)|*.xls";
            //将模板名称加当前日期作为默认文件名
            //mySave.FileName = _templateName +  RiLiGlobal.RiLiDataAcc.GetNow().Date.ToShortDateString();
            if (mySave.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            else
            {
                //string RiLiSoft="D:\\RiLi72SOFT\\UAP\\Runtime\\ZT";
                filename = mySave.FileName;
                //FileInfo mode = new FileInfo(_templatePath);
                //绝对路径
                //FileInfo mode = new FileInfo("D:\\RiLi72SOFT\\UAP\\Runtime\\ZT\\" + _templateName + ".xls");
                //相对路径
                //FileInfo mode = new FileInfo(Application.StartupPath.Trim() + "\\UAP\\Runtime\\ZT\\" + _templateName + ".xls");

                FileInfo mode = new FileInfo(Application.StartupPath.Trim() + "\\UAP\\Runtime\\" + _templateName + ".xls");
                try
                {
                    mode.CopyTo(filename, true);
                }
                catch (Exception ee)
                {
                    System.Windows.Forms.MessageBox.Show(ee.Message);
                    return false;
                }
            }

            //打开复制后的文件
            object missing = System.Reflection.Missing.Value;
            _myExcel.Application.Workbooks.Open(filename, missing, missing, missing, missing,
              missing, missing, missing, missing, missing, missing, missing, missing);

            //将Excel隐藏
            _myExcel.Visible = false;
            return true;
        }


        /// <summary>
        /// 保存并关闭Excel
        /// </summary>
        /// <param name="_myExcel">Excel对象</param>
        /// <param name="_ifClose"></param>
        /// <returns>是否保存成功</returns>
        public static bool SaveAndCloseExcel(Excel.Application _myExcel, bool _ifClose)
        {
            //将列标题和实际内容选中
            Excel.Workbook myBook = _myExcel.Workbooks[1];
            Excel.Worksheet mySheet =(Excel.Worksheet)myBook.Worksheets[1];

            //设置选择范围
            //Excel.Range r = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[14, 7]);
            //r.Select(); //选择设定范围
            //保存修改
            myBook.Save();
            _myExcel.Visible = true;
            //关闭Excel
            if (_ifClose == true)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(mySheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_myExcel);
                _myExcel.Quit();
                //_myExcel = null;
                //System.GC.Collect();
            }
            _myExcel = null;
            System.GC.Collect();
            return true;
        }

        #endregion


        ///// <summary>
        ///// 保存并关闭Excel
        ///// </summary>
        ///// <param name="_myExcel">Excel对象</param>
        ///// <param name="_ifClose"></param>
        ///// <returns>是否保存成功</returns>
        //public static bool SaveAndCloseExcel(Excel.Application _myExcel, bool _ifClose)
        //{
        //    //将列标题和实际内容选中
        //    Excel.Workbook myBook = _myExcel.Workbooks[1];
        //    Excel.Worksheet mySheet = (Excel.Worksheet)myBook.Worksheets[1];

        //    //设置选择范围
        //    //Excel.Range r = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[14, 7]);
        //    //r.Select(); //选择设定范围
        //    //保存修改
        //    myBook.Save();
        //    _myExcel.Visible = true;

        //    //关闭Excel
        //    if (_ifClose == true)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(mySheet);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(_myExcel);
        //        _myExcel.Quit();
        //        //_myExcel = null;
        //        //System.GC.Collect();
        //    }
        //    _myExcel = null;
        //    System.GC.Collect();
        //    return true;
        //}


        /// <summary>
        /// 获取 RiLi权限  
        /// </summary>
        /// <param name="acc_Id"> 帐套号 </param>
        /// <param name="iYear">年份</param>
        /// <param name="userId">用户编号</param>
        /// <param name="cAuth_id">权限编号</param>
        /// <returns></returns>
        public static Boolean GetHoldAuth(string acc_Id, string iYear, string userId, string cAuth_id)
        {
//            string sqlstr = string.Format(@"select count(*)  from UFSystem.dbo.UA_HoldAuth  where cacc_Id='{0}' 
//                                                            and iYear='{1}' and cUser_Id='{2}' and cAuth_Id='{3}' 
//                                                            union
//                                                            select count(*) from UA_HoldAuth  UH inner join  UA_role UR on UH.cUser_Id=UR.cGroup_Id 
//                                                            where cAuth_Id='{3}' and  UR.cUser_Id='{2}'
//                                                            union
//                                                            select count(*) from UA_role  where cGroup_Id='DATA-MANAGER' and cUser_Id='{2}'   "
//                                                            , acc_Id,iYear,userId,cAuth_id);
            string sqlstr = string.Format(@"declare @count1 decimal(18,0)
                                                            declare @count2 decimal(18,0)
                                                            declare @count3 decimal(18,0)
                                                             select  @count1=count(*)  from UFSystem.dbo.UA_HoldAuth  where cacc_Id='{0}' 
                                                            and iYear='{1}' and cUser_Id='{2}' and cAuth_Id='{3}' 
                                                            select  @count2=count(*) from UFSystem.dbo.UA_HoldAuth  UH 
                                                            inner join  UFSystem.dbo.UA_role UR on UH.cUser_Id=UR.cGroup_Id 
                                                            where cAuth_Id='{3}' and  UR.cUser_Id='{2}'
                                                            select  @count3=count(*) from UFSystem.dbo.UA_role  where cGroup_Id='DATA-MANAGER' and cUser_Id='{2}'  
                                                             select @count1+@count2+@count3 ",
                                               acc_Id, iYear, userId, cAuth_id);
            string temp = RiLiExecuteScalar(sqlstr);
            return temp.Trim() != "0";
        }


        /// <summary>
        /// 获取 RiLi权限  
        /// </summary>
        /// <param name="cAuth_Id"></param>
        /// <returns></returns>
        public static Boolean RiLiGetHoldAuth(string cAuth_Id)
        {
            return GetHoldAuth(RiLiDataAcc.AccID, RiLiDataAcc.iYear, RiLiDataAcc.cUserId, cAuth_Id);
        }

        /// <summary>
        /// 查询条件过滤
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static string str_SQL(string Number)
        {
            string[] dd = Number.Split(',');
            string mPrdIds = "";
            if (dd.Length > 1)
            {
                mPrdIds = "'";
                for (int i = 0; i < dd.Length; i++)
                {
                    mPrdIds = mPrdIds + dd[i] + "','";
                }
                mPrdIds = mPrdIds.Substring(0, mPrdIds.Length - 2);
            }
            else
            {
                mPrdIds = "'" + dd[0] + "'";
            }
            return mPrdIds;
        }

        /// <summary>
        /// 过滤重复的数据
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="subStr"></param>
        /// <param name="FGF"></param>
        /// <returns></returns>
        public static int Filter_Num(string Str, string subStr, char FGF)
        {

            char[] c = new char[1];
            c[0] = FGF;

            string[] ee = Str.Split(FGF);
            int j = 0;
            for (int i = 0; i < ee.Length; i++)
            {
                if (ee[i] == subStr)
                {
                    j++;
                }
            }
            return j;
        }


        /// <summary>
        /// 查询条件过滤  过滤【|】
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static string str_SQL_Shu(string Number)
        {
            string[] dd = Number.Split('|');
            string mPrdIds = "";
            if (dd.Length > 1)
            {
                mPrdIds = "'";
                for (int i = 0; i < dd.Length; i++)
                {
                    mPrdIds = mPrdIds + dd[i] + "','";
                }
                mPrdIds = mPrdIds.Substring(0, mPrdIds.Length - 2);
            }
            else
            {
                mPrdIds = "'" + dd[0] + "'";
            }
            return mPrdIds;
        }
        /// <summary>
        /// 反射方式创建对象
        /// </summary>
        /// <param name="PrgmName">DLL名称</param>
        /// <param name="ClassName">类名</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static object CreateForm(string PrgmName, string ClassName, object[] args)
        {
            System.Reflection.Assembly assm = System.Reflection.Assembly.LoadFrom(PrgmName);
            if (assm == null)
            {
                throw new Exception(PrgmName + "这个DLL不存在。");
            }
            Type TypeToLoad = assm.GetType(ClassName);
            if (TypeToLoad == null)
            {
                throw new Exception(TypeToLoad + "在" + PrgmName + "中不存在。");
            }

            return Activator.CreateInstance(TypeToLoad, args);


        }
        public static DataTable GetUserAuth(string autoUserId, string functionId)
        {
            string sql = string.Format(@"select * from UFSystem..ua_role with (nolock) 
	                                                                        where cuser_id=N'{0}' and 
		                                                                        (
			                                                                        cgroup_id='DATA-MANAGER' or  
			                                                                        cgroup_id in 
				                                                                        (
					                                                                        select cUser_Id from  UFSystem..ua_holdauth with (nolock) 
                                                                                                        where cauth_id=N'Admin' and 
                                                                                                                    Cacc_id='{1}' and iyear='{2}' and iisuser=0
				                                                                        ) 
		                                                                        ) 
                                                                   select * from  UFSystem..ua_holdauth with (nolock) 
                                                                   where cauth_id='admin' and Cacc_id='{1}' and 
                                                                                iyear='{2}' and cUser_id=N'{0}'",
                                                                UFBaseLib.BusLib.BaseInfo.UserId, UFBaseLib.BusLib.BaseInfo.AccID,
                                                                UFBaseLib.BusLib.BaseInfo.iYear);
            DataSet dsIsAdmin = GetDataSet(sql);
            //如果查询有数据，则说明当前用户为当前帐套年度的帐套主管
            if (dsIsAdmin.Tables[0].Rows.Count > 0 || dsIsAdmin.Tables[1].Rows.Count > 0)
            {
                UFBaseLib.BusLib.BaseInfo.IsAdmin = true;
            }
            //RiLi权限
            //如果是帐套主管，则拥有所有权限
            sql = string.Format(@"SELECT DISTINCT a.cAuth_Id, b.cAuth_Name
								FROM UFSystem.dbo.ua_auth_base a INNER JOIN
									  UFSystem.dbo.UA_Auth_lang b ON a.cAuth_Id = b.cAuth_ID
								WHERE (b.localeid = UFSystem.dbo.UDF_GetLocaleID()) AND (a.cSupAuth_Id = '{0}')", functionId);
            //如果不是帐套主管，则需根据用户ID查询权限
            if (UFBaseLib.BusLib.BaseInfo.IsAdmin == false)
            {
                sql += string.Format(@" AND (a.cAuth_Id IN
										  (SELECT cAuth_Id FROM UFSYSTEM..UA_HoldAuth
												WHERE cAcc_Id = '{0}' AND iYear = '{1}' AND (cUser_Id IN ('{2}') OR cUser_Id IN
												   (SELECT DISTINCT cGroup_id FROM ufsystem..UA_Role
												  WHERE cuser_id = N'{2}')))) ORDER BY a.cAuth_Id",
                               UFBaseLib.BusLib.BaseInfo.AccID,
                                   UFBaseLib.BusLib.BaseInfo.iYear, autoUserId);
            }
            return ExecuteQuery(sql);
        }

        public static string GetHospitalNameByReCode(string reCode)
        {
            string sql = "select CustomerName from RepairMission where RepairMissionCode = '" + reCode + "'";

            return  RiLiExecuteScalar(sql);
        }

        public static string GetHospitalNameByReId(string reId)
        {
            string sql = "select CustomerName from RepairMission where RepairMissionID = '" + reId + "'";

            return RiLiExecuteScalar(sql);
        }

        public static string GetHospitalNameByInCode(string code)
        {
            string sql = "select tCusName  from InstallTask where tInsCode = '"+code+"'";

            return RiLiExecuteScalar(sql);
        }

        public static void IsEnd(string repCode)
        {
            string isend = RiLiExecuteScalar("select IsEnd from RepairMission where RepairMissionCode = '"+repCode+"'");
            if (isend == "已结案")
            {
                throw new Exception("此维修任务已经结案，不可进行操作");
            }
            else
            {
                return;
            }
        }

        public static string InstallStateView(string oldstate)
        {
            if (oldstate == "安装请求")
            {
                return "已指派科长";
            }
            else if(oldstate =="已指派")
            {
                return "已指派工程师";
            }
            else if (oldstate == "已指派科长")
            {
                return "安装请求";
            }
            else
            {
                return oldstate;
            }
        }



    }
}
