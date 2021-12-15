using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace UFBaseLib.DBLib
{
    public class DB
    {
        #region get 默认数据库连接
        private static SqlConnection m_DefConn = new SqlConnection(BusLib.BaseInfo.DefConnStr);
        public static SqlConnection DefSqlConn
        {
            get
            {
                if (ConnectionState.Open == m_DefConn.State)
                {
                    return m_DefConn;
                }
                else
                {
                    try
                    {
                        m_DefConn.Open();
                        return m_DefConn;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        #endregion

        #region 获取工具档buttons表
        public static DataTable GetButtonDT(string frmClass)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adapter = UFBaseLib.BusLib.Bus.BuildDataAdpter("p_getUserAuthB");
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cUser_id", SqlDbType.Char, 20)).Value = UFBaseLib.BusLib.BaseInfo.UserId.Trim();
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@mFrmClass", SqlDbType.Char, 200)).Value = frmClass.Trim();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region 根据连接符串连接数据库
        public static void ConnDB(string connStr)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
