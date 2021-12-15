using System;

namespace WorkFlow.user
{
	/// <summary>
	/// Dep 的摘要说明。
	/// </summary>
	public class Dep
	{
		private long autoid;   //部门编号
		private string depcode;//部门编码例如"11" "10"
		private string depname;//部门名称
		private long parentid; //上级部门编号
		private long principalid;//部门主管编号
		private string mess;//部门备注
		public static int DEP_CODE_LEN=2;

		public Dep(long autoid,string depname,string depcode,long parentid,long principalid,string mess)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.autoid = autoid;
			this.depcode = depcode;
			this.depname = depname;
			this.parentid = parentid;
			this.principalid = principalid;
			this.mess = mess;
		}
		public Dep(long autoid,long parentid,string depcode,string depname)
		{
			this.autoid = autoid;
			this.parentid = parentid;
			this.depcode = depcode;
			this.depname = depname;
		}
		public long getID()
		{
			return this.autoid;
		}
		public string getDepCode()
		{
			return this.depcode;
		}
		public string getDepName()
		{
			return this.depname;
		}
		public long getParentID()
		{
			return this.parentid;
		}
		public long getPrincipalID()
		{
			return this.principalid;
		}
		public string getMess()
		{
			return this.mess;
		}
		public string getParentCode()
		{
			if(this.depcode.Length<=Dep.DEP_CODE_LEN) return "";
			else return this.depcode.Substring(Dep.DEP_CODE_LEN);
		}
		public int getCodeLen()
		{
			return this.depcode.Length;
		}
		public static string getChildMinCode()
		{
			string tmp = "";
			for(int i=0;i<Dep.DEP_CODE_LEN;i++)
			{
				tmp+="0";
			}
			return tmp;
		}
		public static string getChildMaxCode()
		{
			string tmp = "";
			for(int i=0;i<Dep.DEP_CODE_LEN;i++)
			{
				tmp+="9";
			}
			return tmp;
		}
		public static long getMaxDepBit()
		{
			long first = 1;
			for(int i=0;i<Dep.DEP_CODE_LEN;i++)
				first=first*10;
			return first;
		}
	}
}
