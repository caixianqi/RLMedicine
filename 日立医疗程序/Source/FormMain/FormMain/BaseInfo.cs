using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace UFBaseLib.BusLib
{
    public class BaseInfo
    {
        #region 静态属性
        #region 静态属性
        public static XmlDocument xmlDoc=null;
        /// <summary>
        /// U8登陆对象
        /// </summary>
        public static U8Login.clsLogin U8Login = null;
        public static string userRole = "demo";
        public static string ProgramName;
        /// <summary>
        /// 用户编号
        /// </summary>
        public static string UserId;//用户名
        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName;
        /// <summary>
        /// 密码
        /// </summary>
        public static string Password;//密码
        /// <summary>
        /// 帐套Id
        /// </summary>
        public static string AccID;//帐套ID
        /// <summary>
        /// 帐套年度
        /// </summary>
        public static string iYear;//帐套年度
        /// <summary>
        /// 子系统号
        /// </summary>
        public static string cSubID;//子系统号
        /// <summary>
        /// 应用服务器
        /// </summary>
        public static string AppServer;//应用服务器		
        /// <summary>
        /// 数据源
        /// </summary>
        public static string DataSource;//数据源
        /// <summary>
        /// 年度库德连接串
        /// </summary>
        public static string UfDbName;//年度库的连接串
        /// <summary>
        /// 操作日期
        /// </summary>
        public static string operDate;//登陆界面的业务日期
        /// <summary>
        /// 工作站的唯一序列号
        /// </summary>
        public static string WorkStationSerial;//工作站的唯一序列号
        /// <summary>
        /// 语言
        /// </summary>
        public static int LanguageID;//语言
        /// <summary>
        /// 是否集团帐套=true,集团版
        /// </summary>
        public static bool IsCompanyVer;//是否集团帐套=true,集团版
        /// <summary>
        /// 是否管理员
        /// </summary>
        public static bool IsAdmin;//是否管理员
        /// <summary>
        /// 数据库服务器名称
        /// </summary>
        public static string DBServerName; //数据库服务器名称
        /// <summary>
        /// 数据库登陆用户名
        /// </summary>
        public static string DBUserID;//数据库登陆用户名
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public static string DBPwd;//数据库登陆密码
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBName; //数据库名称
        /// <summary>
        /// 程序挂接类型,0=外挂 1=内嵌
        /// </summary>
        public static int ProgramType;//程序挂接类型,0=外挂 1=内嵌
        #endregion

        #endregion

        #region get 默认的数据连接字符串
        public static string m_DefConnStr;
        public static string DefConnStr
        {
            get
            {
                return m_DefConnStr;
            }
            set
            {
                m_DefConnStr = value;
            }
        }
        #endregion

        #region 字符串中获取值,如字符串 'abc="aa";'求 abc的值
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


    }
}
