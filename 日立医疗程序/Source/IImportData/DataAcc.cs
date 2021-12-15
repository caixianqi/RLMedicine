using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bao.Analysis;
using System.Data;
namespace Bao.DataAccess
{
    public  class DataAcc
    {
       public static System.Data.SqlClient.SqlConnection MainConn=new SqlConnection();
       public  static System.Data.SqlClient.SqlCommand UpLoadCmd = new SqlCommand();
       public static SqlDataAdapter TranAdapter = new SqlDataAdapter();
       public static string YearD="";

       public static System.Data.SqlClient.SqlConnection U8MainConn = new SqlConnection();

       /// <summary>
       /// 本地服务器
       /// </summary>
       public static string server = string.Empty;


       /// <summary>
       /// 本地数据库名
       /// </summary>
       public static string database = string.Empty;

       /// <summary>
       /// U8服务器
       /// </summary>
       public static string U8server = string.Empty;

       /// <summary>
       /// U8数据库名
       /// </summary>
       public static string U8database = string.Empty;

       public static string ExePath =Application.StartupPath+@"\";


       /// <summary>
       /// (Lin 2020-07-01 修改) 打开连接
       /// </summary>
       public static void GetOpenConn()
       {
           //MD5解密
           Bao.DataAccess.MD5 md5 = new Bao.DataAccess.MD5();

           string user = "";
           string password = "";
           string conn = "";
           MainConn.Close();
           if (string.IsNullOrEmpty(RiLiGlobal.RiLiDataAcc.AccountNum))
           {

               if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini"))
                   throw new Exception("没有数据库连接文件。");

               IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
               // MainConn = new SqlConnection();

               server = md5.Md5Decrypt(IniObj.read("database", "server", ""));
               database = md5.Md5Decrypt(IniObj.read("database", "database", ""));
               user = md5.Md5Decrypt(IniObj.read("database", "user", ""));
               password = md5.Md5Decrypt(IniObj.read("database", "password", ""));


               // 2011-09-23 赵琨，暂时去除密码验证//password = Encrypt.DPwd(password);
               //YearD = database.Substring(database.Length - 4, 4);

               //string conn;//= "uid=sa;initial catalog=UFDATA_999_2008;data source=127.0.0.1;Connect Timeout=600";
           }
           else
           {
               DataTable dt = RiLiGlobal.RiLiDataAcc.Get_RL_DBInfo(RiLiGlobal.RiLiDataAcc.AccountNum);
               if (dt != null && dt.Rows.Count > 0)
               {
                   //Server,DataBase,User,PassWord
                   server = dt.Rows[0]["Server"].ToString().Trim();
                   database = dt.Rows[0]["DataBase"].ToString().Trim();
                   user = dt.Rows[0]["User"].ToString().Trim();
                   password = md5.Md5Decrypt(dt.Rows[0]["PassWord"].ToString().Trim());
               }
           }


           conn = "uid=" + user + ";initial catalog=" + database + ";data source=" + server + ";password=" + password + ";Connect Timeout=6000";

           MainConn.ConnectionString = conn;
           try
           {
               MainConn.Open();
           }
           catch (Exception e)
           {
               throw new Exception("连接数据库失败，原因:" + e.Message);
           }

           
           UpLoadCmd.Connection = MainConn;
           UpLoadCmd.CommandTimeout = 0;
           TranAdapter.SelectCommand = UpLoadCmd;
       }

        /// <summary>
       /// (Lin 2020-07-01 修改) 打开连接
        /// </summary>
        public static void GetConn()
        {
            
            if (MainConn.State == System.Data.ConnectionState.Closed  )
            {
                //MD5解密
                Bao.DataAccess.MD5 md5 = new Bao.DataAccess.MD5();

                string user = "";
                string password = "";
                string conn = "";
                if (string.IsNullOrEmpty(RiLiGlobal.RiLiDataAcc.AccountNum))
                {

                    if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini"))
                        throw new Exception("没有数据库连接文件。");

                    IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
                    // MainConn = new SqlConnection();

                    server =md5.Md5Decrypt(IniObj.read("database", "server", ""));
                    database = md5.Md5Decrypt(IniObj.read("database", "database", ""));
                    user = md5.Md5Decrypt(IniObj.read("database", "user", ""));
                    password = md5.Md5Decrypt(IniObj.read("database", "password", ""));


                    // 2011-09-23 赵琨，暂时去除密码验证//password = Encrypt.DPwd(password);
                    //YearD = database.Substring(database.Length - 4, 4);

                    //string conn;//= "uid=sa;initial catalog=UFDATA_999_2008;data source=127.0.0.1;Connect Timeout=600";
                }
                else
                {
                    DataTable dt = RiLiGlobal.RiLiDataAcc.Get_RL_DBInfo(RiLiGlobal.RiLiDataAcc.AccountNum);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //Server,DataBase,User,PassWord
                        server = dt.Rows[0]["Server"].ToString().Trim();
                        database = dt.Rows[0]["DataBase"].ToString().Trim();
                        user = dt.Rows[0]["User"].ToString().Trim();
                        password = md5.Md5Decrypt(dt.Rows[0]["PassWord"].ToString().Trim());
                    }
                }


                conn = "uid=" + user + ";initial catalog=" + database + ";data source=" + server + ";password=" + password + ";Connect Timeout=6000";

                MainConn.ConnectionString = conn;
                try
                {
                    MainConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("连接数据库失败，原因:"+e.Message);
                }
                
            }
            UpLoadCmd.Connection = MainConn;
            UpLoadCmd.CommandTimeout = 0;
            TranAdapter.SelectCommand = UpLoadCmd;
        }

      /*  public static void GetConn()
        {

            if (MainConn.State == System.Data.ConnectionState.Closed)
            {
               
                if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini"))
                    throw new Exception("没有数据库连接文件。");

                IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
                // MainConn = new SqlConnection();
                server = IniObj.read("database", "server", "");
                database = IniObj.read("database", "database", "");
                string user = IniObj.read("database", "user", "");
                string password = IniObj.read("database", "password", "");
                // 2011-09-23 赵琨，暂时去除密码验证//password = Encrypt.DPwd(password);
                //YearD = database.Substring(database.Length - 4, 4);

                string conn;//= "uid=sa;initial catalog=UFDATA_999_2008;data source=127.0.0.1;Connect Timeout=600";
                

                conn = "uid=" + user + ";initial catalog=" + database + ";data source=" + server + ";password=" + password + ";Connect Timeout=6000";

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
            UpLoadCmd.CommandTimeout = 0;
            TranAdapter.SelectCommand = UpLoadCmd;
        }*/


      /*  public static void U8GetConn()
        {

            if (U8MainConn.State == System.Data.ConnectionState.Closed)
            {
                string U8user = "";
                string U8password = "";
                if (string.IsNullOrEmpty(RiLiGlobal.RiLiDataAcc.AccountNum))
                {
                    if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini"))
                        throw new Exception("没有数据库连接文件。");

                    IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
                    // MainConn = new SqlConnection();
                    U8database = IniObj.read("U8Database", "U8Url", "");
                    U8user = IniObj.read("U8Database", "U8user", "");
                    U8password = IniObj.read("U8Database", "U8password", "");
                    U8server = IniObj.read("U8Database", "U8server", "");

                }
                else
                {
                    DataTable dt = RiLiGlobal.RiLiDataAcc.Get_RL_DBInfo(RiLiGlobal.RiLiDataAcc.AccountNum);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //Server,DataBase,User,PassWord
                        server = dt.Rows[0]["Server"].ToString().Trim();
                        database = dt.Rows[0]["DataBase"].ToString().Trim();
                        user = dt.Rows[0]["User"].ToString().Trim();
                        password = dt.Rows[0]["PassWord"].ToString().Trim();
                    }
                }

                //YearD = database.Substring(database.Length - 4, 4);
                string U8conn = string.Empty;
                //= "uid=sa;initial catalog=UFDATA_999_2008;data source=127.0.0.1;Connect Timeout=600";
                U8conn = "uid=" + U8user + ";initial catalog=" + U8database + ";data source=" + U8server + ";password=" + U8password + ";Connect Timeout=10000";

                U8MainConn.ConnectionString = U8conn;
                try
                {
                    U8MainConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("连接数据库失败，原因:" + e.Message);
                }

            }
            UpLoadCmd.Connection = U8MainConn;
        }*/

        public static void U8GetConn()
        {

            if (U8MainConn.State == System.Data.ConnectionState.Closed)
            {

                if (!System.IO.File.Exists(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini"))
                    throw new Exception("没有数据库连接文件。");

                IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "RiliDBini.ini");
                // MainConn = new SqlConnection();
                U8database = IniObj.read("U8Database", "U8Url", "");
                string U8user = IniObj.read("U8Database", "U8user", "");
                string U8password = IniObj.read("U8Database", "U8password", "");
                U8server = IniObj.read("U8Database", "U8server", "");

                //YearD = database.Substring(database.Length - 4, 4);
                string U8conn = string.Empty;
                //= "uid=sa;initial catalog=UFDATA_999_2008;data source=127.0.0.1;Connect Timeout=600";
                U8conn = "uid=" + U8user + ";initial catalog=" + U8database + ";data source=" + U8server + ";password=" + U8password + ";Connect Timeout=10000";

                U8MainConn.ConnectionString = U8conn;
                try
                {
                    U8MainConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("连接数据库失败，原因:" + e.Message);
                }

            }
            UpLoadCmd.Connection = U8MainConn;
        }

        #region  U8连接

        public static string U8ExecuteScalar(string sqlText)
        {
            U8GetConn();
            UpLoadCmd.CommandText = sqlText;
            object ss = UpLoadCmd.ExecuteScalar();
            if (ss == null)
                return "";
            else
                return ss.ToString();
            //  return UpLoadCmd.ExecuteScalar().ToString();
        }


        public static object U8GetScalar(string sqlText)
        {
            try
            {
                U8GetConn();
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




        public static void U8ExecuteNotQuery(string sqlText)
        {
            U8GetConn();
            UpLoadCmd.CommandText = sqlText;
            UpLoadCmd.ExecuteNonQuery();
        }


        public static System.Data.DataTable U8ExecuteQuery(string sqlText)
        {
            U8GetConn();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlText, U8MainConn);

            //SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            System.Data.DataTable table1 = ds.Tables[0];
            ds.Tables.Remove(ds.Tables[0]);
            return table1;

        }

        public static System.Data.DataTable U8ExecuteQuery(string sqlText, string TableName)
        {
            U8GetConn();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, U8MainConn);
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

        #endregion

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
              return  UpLoadCmd.ExecuteReader();
         
        }
        public static string   ExecuteScalar(string sqlText)
        {
            UpLoadCmd.CommandText = sqlText;
            object  ss = UpLoadCmd.ExecuteScalar();

            if (ss == null)
                return "";
            else
                return ss.ToString();
         
        }

        public static System.Data.DataTable ExecuteQuery(string sqlText)
        {
            GetConn();
            //SqlDataAdapter adapter = new SqlDataAdapter(sqlText, MainConn);            
            
            //System.Data.DataSet  ds = new System.Data.DataSet();
            //adapter.Fill(ds);
            //System.Data.DataTable table1 = ds.Tables[0];
            //ds.Tables.Remove(ds.Tables[0]);
            //return table1 ;

            TranAdapter.SelectCommand.CommandText = sqlText;

            System.Data.DataSet  ds = new System.Data.DataSet();
            TranAdapter.Fill(ds);
            System.Data.DataTable table1 = ds.Tables[0];
            ds.Tables.Remove(ds.Tables[0]);
            return table1;
            
        }

        public static System.Data.DataTable ExecuteQuery(string sqlText,string TableName)
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
            UpLoadCmd.CommandText = sqlText;
             UpLoadCmd.ExecuteNonQuery();
        }

		/// <summary>
		/// 返回数据集
		/// </summary>
		/// <param name="sqlText"></param>
		/// <returns></returns>
		/// 
		public static System.Data.DataSet GetDataSet(string sqlText) {
			GetConn();
			try {
				TranAdapter.SelectCommand.CommandText = sqlText;
				System.Data.DataSet ds = new System.Data.DataSet();
				TranAdapter.Fill(ds, "Table");
				return ds;
			} catch (Exception e) {
				throw new Exception("执行语句（" + sqlText + "）时出错, 错误信息：" + e.Message);
			}
		}
      
        /// <summary>
        /// 查找DataTable中的特定行
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
        /// <returns></returns>
        public static System.Data.DataRow Search(System.Data.DataTable table1, string FieldName, string FieldValue)
        {

            foreach (System.Data.DataRow row1 in table1.Rows)
            {
                if (row1[FieldName].ToString().Trim().ToUpper() == FieldValue.Trim().ToUpper())
                {
                    return row1;
                }
            }
            return null;
        }
        
        public static void DataUpLoad(IBusns BO)
        {
            string Sql = "";

            SqlTransaction sqlTran = MainConn.BeginTransaction();
            UpLoadCmd.Transaction = sqlTran;
            try
            {
                Sql = BO.MastToSql();
                if (Sql != "")
                {
                    UpLoadCmd.CommandText = Sql;
                    UpLoadCmd.ExecuteNonQuery();
                }
                foreach (System.Data.DataRow row1 in BO.TableItems.Rows)
                {
                    Sql = BO.ItemToSQL(row1);
                    if (Sql != "")
                    {
                        //System.Diagnostics.Debug.WriteLine(Sql);

                        UpLoadCmd.CommandText = Sql;
                        UpLoadCmd.ExecuteNonQuery();
                    }
                }
                Sql = BO.AfterCommit();
                if (Sql != "")
                {
                    UpLoadCmd.CommandText = Sql;
                    UpLoadCmd.ExecuteNonQuery();
                }

                sqlTran.Commit();

            }
            //catch (System.Data.SqlClient.SqlException e)
            //{
            //    if (e.Number == 2627)
            //    {
            //        e.
            //        SqlError[] dd=new SqlError [10];
            //        e.Errors.CopyTo(dd, 0);
                    
            //       System.Collections.ICollection 
            //        throw new Exception(e.Message + "(" + Sql + ")");
            //    }
            //}
            catch (Exception e)
            {
                sqlTran.Rollback();

                throw new Exception(e.Message + "(" + Sql + ")");
            }
        }
        public static void DataUpLoad(ITranSactionSQL mObj, string TableName, string FieldName, string FieldValue)
        {
            
        }
        public static void DataUpLoad(ITranSactionSQL mObj, System.Data.DataTable DestTable,Bao.ErrMessage.IdelegateError mErr)
        {
            string Sql="";

            int RowCount = DestTable.Rows.Count;
            int j = 0;
            int baifen = 0;
            double h = RowCount / 100;
            
            SqlTransaction sqlTran=MainConn.BeginTransaction();
            UpLoadCmd.Transaction =sqlTran;
            try
            {
                foreach (System.Data.DataRow row1 in DestTable.Rows)
                {
                    Sql=mObj.DatatoSql(row1);
                    if (Sql !="")
                    {
                        //System.Diagnostics.Debug.WriteLine(Sql);
           
                        UpLoadCmd.CommandText = Sql;
                        UpLoadCmd.ExecuteNonQuery();
                    }
                    j++;
                    baifen++;
                    if (baifen > h)
                    {
                        baifen = 0;
                        mErr.ProcJD(j/RowCount*100);
                    }
                }
               
                sqlTran.Commit();
               
            }
            catch(Exception e)
            {
                sqlTran.Rollback();

                //throw new Bao.ErrMessage.ExceptionBao(e.Message, Sql);
                throw new Exception(e.Message + "(" + Sql + ")");
            }

         
        }
        /// <summary>
        /// 去掉字符中的不可见字符
        /// </summary>
        /// <param name="str">带有不可见字符的字符串</param>
        /// <returns></returns>
        public static string SubString2_L(string str)
        {
           // string st = "34,13,10";
            byte[] ByteFoo = System.Text.Encoding.Default.GetBytes(str);
            byte[] ByteRes=new byte[ByteFoo.Length ];
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
        /// <summary>
        /// 将字符串中的特定字符去掉,特定字符不能是双字节字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="dstr">特定字符</param>
        /// <returns></returns>
        public static string Substring3_L(string str,char  Tstr)
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
        /// <summary>
        /// 统计字符串中特定字符的个数特定字符不能是双字节字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Tstr"></param>
        /// <returns></returns>
        public static int SubNum(string str, char  Tstr)
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

           
            return  j;
        

        }
        /// <summary>
        ///  取得第Num个特定字符前的数据
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="Tstr">特定字符</param>
        /// <param name="Num">从左起特定字符出现的次数</param>
        /// <returns></returns>
        public static string Substring4_L(string str, char  Tstr,int Num)
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
        /// <summary>
        /// 如果编号按数字开头，就分两极类型，如果按字母开头就按原有的分级
        /// </summary>
        /// <param name="ItemId">编号</param>
        /// <param name="TypeFlag">类型标记，0:类型，1：项目</param>
        /// <returns></returns>
        public static string ItemHB(string ItemId, string TypeFlag)
        {
            byte[] TByte = System.Text.Encoding.Default.GetBytes(ItemId);
            char ss = '-';
            
            if (TypeFlag  == "1")            //是项目
            {
                if (TByte[0] >= 48 && TByte[0] <= 57)
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring3_L(Bao.DataAccess.DataAcc.Substring4_L(ItemId, ss, 3),'-');
                } else
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring3_L(ItemId,'-');
                }
            }
            else                                         //是类型
            {
                if (TByte[0] >= 48 && TByte[0] <= 57)
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring4_L(ItemId, ss, 2);
                }
               

            }
            return ItemId;
        }
        public static string ParentItemHB(string ItemId, string TypeFlag)
        {
            byte[] TByte = System.Text.Encoding.Default.GetBytes(ItemId);

            if (TypeFlag == "1")            //是项目
            {
                if (TByte[0] >= 48 && TByte[0] <= 57)
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring4_L(ItemId, '-', 3);
                }
            }
            else                                         //是类型
            {
                if (TByte[0] >= 48 && TByte[0] <= 57)
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring4_L(ItemId, '-', 2);
                }
                else
                {
                    ItemId = Bao.DataAccess.DataAcc.Substring4_L(ItemId, '-', SubNum(ItemId,'-'));
                }

            }
            return ItemId;
        }
        public static object CreateObject(string FullDllName, string FullClassName)
        {
            object obj;
            if (FullDllName == "" || FullDllName ==null )
                throw new Exception("FullDllName 参数不能为空");
            if (FullClassName =="" || FullClassName == null)
                throw new Exception("FullClassName 参数不能为空");
            System.Reflection.Assembly ass;
            ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + @"\" + FullDllName);
            obj= ass.CreateInstance(FullClassName);
            if (obj == null)
            {
                throw new Exception("创建对象为空，请查看是你填写的值是否正确(" + FullClassName + ")"); 
            }
            return obj;
            
        }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="acc_Id"> 帐套号 </param>
        /// <param name="iYear">年份</param>
        /// <param name="userId">用户编号</param>
        /// <param name="cAuth_id">权限编号</param>
        /// <returns></returns>
        public static Boolean U8GetHoldAuth(string acc_Id, string iYear, string userId, string cAuth_id)
        {
            string temp=DataAcc.ExecuteScalar ("select count(*)  from UFSystem..UA_HoldAuth "+
                    " where cacc_Id='" + acc_Id + "' and iYear='" + iYear + "' and cUser_Id='" + userId +
                    "' and cAuth_Id='" + cAuth_id + "' ");
            return temp.Trim() != "0";
            
        }
        //public static Boolean GetHoldAuth(string cAuth_Id)
        //{
        //    return U8GetHoldAuth(UFBaseLib.BusLib.BaseInfo.AccID, UFBaseLib.BusLib.BaseInfo.iYear, UFBaseLib.BusLib.BaseInfo.UserId, cAuth_Id);
        //}

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="cAuth_id">权限编号</param>
        /// <returns></returns>
        public static Boolean GetHoldAuth(string userId, string cAuth_id)
        {
            string temp = DataAcc.ExecuteScalar("select count(*) from UserAuth a, TRoleUsers b " +
                " where a.AutoUserId=b.RoleId and b. AutoUserId='" + userId + "' and a.AuthId='" + cAuth_id + "' ");
            return temp.Trim() != "0";
        }

        public static Boolean GetHoldAuth(string cAuth_Id)
        {
            //return GetHoldAuth(UFBaseLib.BusLib.BaseInfo.AccID, UFBaseLib.BusLib.BaseInfo.iYear, UFBaseLib.BusLib.BaseInfo.UserId, cAuth_Id);
            //获取权限
            return GetHoldAuth(UFBaseLib.BusLib.BaseInfo.UserId, cAuth_Id);
        }

        public static Boolean U8GetHoldAuth(string cAuth_Id)
        {
            return U8GetHoldAuth(UFBaseLib.BusLib.BaseInfo.AccID, UFBaseLib.BusLib.BaseInfo.iYear, UFBaseLib.BusLib.BaseInfo.UserId, cAuth_Id);
        }


        public static string MaxBillIp(string TableMainName, string prefix)
        {
            string Month = "0" +RiLiGlobal.RiLiDataAcc.GetNow().Month.ToString();
            Month = Month.Substring(Month.Length - 2);
            string day = "0" + RiLiGlobal.RiLiDataAcc.GetNow().Day.ToString();
            day = day.Substring(day.Length - 2);
            string year = RiLiGlobal.RiLiDataAcc.GetNow().Year.ToString();
            string datestr = year.Substring(year.Length - 2, 2) + Month;// +day;
            ///ip地址
            System.Net.IPAddress addr = new System.Net.IPAddress(System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].Address);
            string IPAddress = addr.ToString();
            int pos = IPAddress.LastIndexOf(".");
            IPAddress = IPAddress.Substring(pos + 1, IPAddress.Length - pos - 1);
            ///
            string MaxNum = Bao.DataAccess.DataAcc.ExecuteScalar("select max(right(BillId,4)) from " + TableMainName + " where billId like '" + prefix + datestr + "%'");
            if (MaxNum == null || MaxNum == "")
                MaxNum = "0";
            int dd = int.Parse(MaxNum) + 1;
            MaxNum = "0000" + dd.ToString();
            MaxNum = MaxNum.Substring(MaxNum.Length - 4);
            return prefix + datestr + IPAddress.Trim() + MaxNum.ToString();
        }
        /// <summary>
        /// 生成单号，单号格式：前缀+年+月+4位流水号
        /// </summary>
        /// <param name="TableMainName"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string MaxBill(string TableMainName, string prefix)
        {

            string Month = "0" +RiLiGlobal.RiLiDataAcc.GetNow().Month.ToString();
            Month = Month.Substring(Month.Length - 2);
            string day = "0" + RiLiGlobal.RiLiDataAcc.GetNow().Day.ToString();
            day = day.Substring(day.Length - 2);
            string year =  RiLiGlobal.RiLiDataAcc.GetNow().Year.ToString();
            string datestr = year.Substring(year.Length - 2, 2) + Month;// +day;
           
            string MaxNum = Bao.DataAccess.DataAcc.ExecuteScalar("select max(right(BillId,4)) from " + TableMainName + " where billId like '" + prefix + datestr + "%'");
            if (MaxNum == null || MaxNum == "")
                MaxNum = "0";
            int dd = int.Parse(MaxNum) + 1;
            MaxNum = "0000" + dd.ToString();
            MaxNum = MaxNum.Substring(MaxNum.Length - 4);
            return prefix + datestr + MaxNum.ToString();
            //string Month = "0" + System. RiLiGlobal.RiLiDataAcc.GetNow().Month.ToString();
            //Month = Month.Substring(Month.Length - 2);
            //string day = "0" + System. RiLiGlobal.RiLiDataAcc.GetNow().Day.ToString();
            //day = day.Substring(day.Length - 2);
            //string datestr = System. RiLiGlobal.RiLiDataAcc.GetNow().Year.ToString() + Month;// +day;
            /////ip地址
            //System.Net.IPAddress addr = new System.Net.IPAddress(System.Net.Dns.GetHostByName(System.Net.Dns .GetHostName()).AddressList[0].Address);
            //string IPAddress = addr.ToString();
            //int pos = IPAddress.LastIndexOf(".");
            //IPAddress = IPAddress.Substring(pos + 1, IPAddress.Length - pos - 1);
            /////
            //string MaxNum = Bao.DataAccess.DataAcc.ExecuteScalar("select cast(count(BillId) as char(4)) from " + TableMainName + " where billId like '" + prefix + datestr + "%'");
            //int dd = int.Parse(MaxNum) + 1;
            //MaxNum = "0000" + dd.ToString();
            //MaxNum = MaxNum.Substring(MaxNum.Length - 4);
            //return prefix + datestr + IPAddress.Trim() + MaxNum.ToString();
        }
        public static string MaxBill(string TableMainName,string BillIdFieldName, string prefix)
        {

            string Month = "0" + RiLiGlobal.RiLiDataAcc.GetNow().Month.ToString();
            Month = Month.Substring(Month.Length - 2);
            string day = "0" + RiLiGlobal.RiLiDataAcc.GetNow().Day.ToString();
            day = day.Substring(day.Length - 2);
            string year = RiLiGlobal.RiLiDataAcc.GetNow().Year.ToString();
            string datestr = year.Substring(year.Length - 2, 2) + Month;// +day;

            string MaxNum = Bao.DataAccess.DataAcc.ExecuteScalar("select max(right(" + BillIdFieldName + ",4)) from " + TableMainName + " where " + BillIdFieldName + " like '" + prefix + datestr + "%'");
            if (MaxNum == null || MaxNum == "")
                MaxNum = "0";
            int dd = int.Parse(MaxNum) + 1;
            MaxNum = "0000" + dd.ToString();
            MaxNum = MaxNum.Substring(MaxNum.Length - 4);
            return prefix + datestr + MaxNum.ToString();
           
        }
        public static object CreateForm(string PrgmName, string ClassName, object[] args)
        {
            System.Reflection.Assembly assm = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + PrgmName);
            if (assm == null)
            {
                throw new Exception(PrgmName+"这个DLL不存在。");
            }
            Type TypeToLoad = assm.GetType(ClassName);
            if (TypeToLoad == null)
            {
                throw new Exception(ClassName + "在" + PrgmName + "中不存在。");

            }
            //System.Diagnostics.Debug.WriteLine(ClassName);
   
             return Activator.CreateInstance(TypeToLoad, args);
           

        }
        public static string AuditBill(string TableName,string KeyFieldName,string BillId,string AuditValue)
        {
            return "update " + TableName + " set AuditFlag='" + AuditValue + "',AuditDate=getdate() where " + KeyFieldName  + "='" + BillId + "'";
        }
        /// <summary>
        /// 链接两个客户端的dataTable ,将其Join成一个Table；
        /// </summary>
        /// <param name="First">第一个DataTable</param>
        /// <param name="Second">第二个DataTable</param>
        /// <param name="FJC">第一个Table的链接列</param>
        /// <param name="SJC">第二个Table的链接列</param>
        /// <returns></returns>
        private static System.Data.DataTable Join(System.Data.DataTable First, System.Data.DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
        {
            //创建一个新的DataTable
            DataTable table = new DataTable("Join");
            // Use a DataSet to leverage DataRelation
            using (DataSet ds = new DataSet())
            {
                //把DataTable Copy到DataSet中
                ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
                DataColumn[] parentcolumns = new DataColumn[FJC.Length];
                for (int i = 0; i < parentcolumns.Length; i++)
                {
                    parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
                }
                DataColumn[] childcolumns = new DataColumn[SJC.Length];
                for (int i = 0; i < childcolumns.Length; i++)
                {
                    childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
                }
                //创建关联
                DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
                ds.Relations.Add(r);
                //为关联表创建列
                for (int i = 0; i < First.Columns.Count; i++)
                {
                    table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                }
                for (int i = 0; i < Second.Columns.Count; i++)
                {
                    //看看有没有重复的列，如果有在第二个DataTable的Column的列明后加_Second
                    if (!table.Columns.Contains(Second.Columns[i].ColumnName))
                        table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
                    else
                        table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);
                }

                table.BeginLoadData();
                foreach (DataRow firstrow in ds.Tables[0].Rows)
                {
					if (firstrow.RowState == DataRowState.Deleted)
						continue;
                    //得到行的数据
                    DataRow[] childrows = firstrow.GetChildRows(r);
                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;
                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;
                            object[] joinarray = new object[parentarray.Length + secondarray.Length];
                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                            table.LoadDataRow(joinarray, true);
                        }
                    }
                }
                table.EndLoadData();
            }
            return table;
        }
        public static System.Data.DataTable Join(System.Data.DataTable First, System.Data.DataTable Second, string FJC, string SJC)
        {
            return Join(First, Second, new DataColumn[] { First.Columns[FJC] }, new DataColumn[] { First.Columns[SJC] });
        }

        public static string Replace(string strSql, params System.Data.SqlClient.SqlParameter[] cmdParms)
        {
            foreach (System.Data.SqlClient.SqlParameter parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;

                }
                if (parameter.Value == DBNull.Value)
                    strSql = strSql.Replace(parameter.ParameterName, parameter.Value.ToString());
                else
                    strSql = strSql.Replace(parameter.ParameterName, "'" + parameter.Value.ToString() + "'");
            }
            return strSql;
        }
    }
}
