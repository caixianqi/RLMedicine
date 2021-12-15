using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace FormMain
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class IniFile
	{

		#region 成员变量
				
		private string s_servername;
		private string s_databasename;
		private string s_username;
		private string s_passwd;
		private string s_id;
		private ArrayList s_timelist =new ArrayList();


		#endregion

		#region 属性
		public string S_ServerName
		{
			get{return  s_servername;}
			set{s_servername=value;}
		}

		public string S_ID
		{
			get{return s_id;}
			set{s_id = value;}
		}

		public string S_DatabaseName
		{
			get{return  s_databasename;}
			set{s_databasename=value;}
		}
		
		public string S_UserName
		{
			get{return  s_username;}
			set{s_username=value;}
		}

		public string S_Passwd
		{
			get{return  s_passwd;}
			set{s_passwd=value;}
		}

		public ArrayList S_TimeList
		{
			get{return s_timelist;}
			set{s_timelist=value;}
		}


		#endregion 
	
		private string path;

		public IniFile(string inipath)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			path=inipath;
         
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def, StringBuilder retVal,int size,string filePath);

        public void IniWriteValue(string Section, string Key, string Value, string filepath)//对ini文件进行写操作的函数
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }        
		public string IniReadValue(string Section,string Key,string filepath)//对ini文件进行读操作的函数
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Section,Key,"",temp, 
				255, filepath);
			return temp.ToString();

		}
        public void GetFormSet()
        {
            //数据库服务器部分
            this.S_ServerName = IniReadValue("SERVER", "SERVERNAME", path);
            this.S_DatabaseName = IniReadValue("SERVER", "DATABASENAME", path);
            this.S_UserName = IniReadValue("SERVER", "USERNAME", path);
            this.S_Passwd = IniReadValue("SERVER", "PASSWD", path);
            this.S_ID = IniReadValue("SERVER", "ID", path);
            this.S_TimeList.Clear();
            for (int i = 0; i < 99; i++)
            {
                if (IniReadValue("RQSET", i.ToString(), path).ToString() == "")
                    break;
                this.S_TimeList.Add(IniReadValue("RQSET", i.ToString(), path));

            }
        }		
//		public void DeleteSection(string Section,string filepath)   //删除
//		{ 
//			WritePrivateProfileString(Section, null, null, filepath);
//		} 

		public void GetConnectionSet()
		{
			//数据库服务器部分
			this.S_ServerName= IniReadValue("SERVER","SERVERNAME",path);
			this.S_DatabaseName=IniReadValue("SERVER","DATABASENAME",path);
			this.S_UserName=IniReadValue("SERVER","USERNAME",path);
			this.S_Passwd=IniReadValue("SERVER","PASSWD",path);
			this.S_ID = IniReadValue("SERVER","ID",path);
			this.S_TimeList.Clear();
			for (int i=0;i<99;i++)
			{
				if (IniReadValue("RQSET",i.ToString(),path).ToString()=="")
					break;
				this.S_TimeList.Add(IniReadValue("RQSET",i.ToString(),path));

			}
		}
        public void SaveFormSet()
        {
            IniWriteValue("SERVER", "SERVERNAME", this.S_ServerName, path);
            IniWriteValue("SERVER", "DATABASENAME", this.S_DatabaseName, path);
            IniWriteValue("SERVER", "USERNAME", this.S_UserName, path);
            IniWriteValue("SERVER", "PASSWD", this.S_Passwd, path);
            IniWriteValue("SERVER", "ID", this.S_ID, path);

            DeleteSection("RQSET", path);
            for (int i = 0; i < this.S_TimeList.Count; i++)
            {
                IniWriteValue("RQSET", i.ToString(), (string)S_TimeList[i], path);
            }
        }
        public void DeleteSection(string Section, string filepath)   //删除
        {
            //if (!WritePrivateProfileString(Section, null, null, filepath)) 
            //{ 
            //	throw(new ApplicationException("无法清除Ini文件中的Section")); 
            //} 
            WritePrivateProfileString(Section, null, null, filepath);
        } 
	}

}
