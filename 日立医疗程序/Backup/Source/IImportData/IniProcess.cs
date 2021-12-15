using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;


namespace Bao.DataAccess
{　
    /// <summary>
    /// 读写Ini文件
    /// </summary>
    public class IniProcess
    {
        private string path;    //包含文件名的全路经
        #region  导入Dll
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section, string key, string def,
            StringBuilder retVal, int size, string filePath);
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iniPath">//包含文件名的全路经</param>
        public IniProcess(
            string iniPath
            )
        {
            this.path = iniPath;
        }
        /// <summary>
        /// 将文本转换成ascII后写到文件中
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WritePswd(string section, string key, string value)
        {

            byte[] bt = System.Text.Encoding.UTF8.GetBytes(value);
            string asc = Encoding.ASCII.GetString(bt, 0, bt.Length);
            write(section, key, asc);
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="section">目录</param>
        /// <param name="key">主键</param>
        /// <param name="value">键值</param>
        public void write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.path);
        }
        /// <summary>
        /// 根据目录和主键读取值
        /// </summary>
        /// <param name="section">目录</param>
        /// <param name="key">主键</param>
        /// <param name="defaultValue">缺省的键值</param>
        /// <returns></returns>
        public string read(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 1024, this.path);
            return (temp.Length > 0) ? temp.ToString() : defaultValue;
        }
        public StringBuilder read(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 1024, this.path);
            return (temp.Length > 0) ?temp : null;
        }
       
        #region  测试代码
        public static void TestWrite()
        {
            IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "DBini.ini");
            System.Diagnostics.Debug.Write(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1));

            IniObj.write("database", "Connection", "abc");
        }
        public static string TestRead()
        {
            IniProcess IniObj = new IniProcess(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1) + "DBini.ini");
            System.Diagnostics.Debug.Write(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1));

            return IniObj.read("database", "Connection", "ddd");
        }
        #endregion
    }
}

