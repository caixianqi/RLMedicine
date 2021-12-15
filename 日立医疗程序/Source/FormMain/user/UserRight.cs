using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Security.Cryptography;

namespace WorkFlow.user
{
	/// <summary>
	/// UserRight 的摘要说明。
	/// </summary>
	public class UserRight
	{
		private Hashtable ht;
		private Hashtable dirHt;
		private int superAdmin=0;
		
			
		public UserRight(Hashtable ht, Hashtable dirHt)
		{
			this.ht=ht;
			this.dirHt = dirHt;

		}

		public bool isSuperAdmin()
		{
			return superAdmin==1?true:false;
		}

		public int SuperAdmin
		{
			get
			{
				return this.superAdmin;
			}
			set 
			{
				this.superAdmin=value;
			}
		}		
		public bool hasRight(String functionName) //判断指定菜单项 用户是否具有访问权限
		{
			if ( isSuperAdmin()) //超级管理员 所有功能模块都具有访问权限
				return true;
			Object o = ht[functionName];
			if (o !=null)
			{
				return true;
			}
			else 
			{
				IDictionaryEnumerator de=ht.GetEnumerator();
				while ( de.MoveNext())
				{
					String key = de.Key.ToString();

					if ( key.IndexOf(functionName)==0 )
					{
						return true;
					}
				}
			}
			return false;
		}

		public int[] getDirIDs()
		{
										 
			if ( dirHt.Count == 0 ) 
			{
				return new int[] {-1};
			}
			else 
			{
				int[] ret = new int[dirHt.Values.Count];
				int i=0;

				IDictionaryEnumerator de=dirHt.GetEnumerator();
				while ( de.MoveNext())
				{
					ret[i++] = Int32.Parse(de.Key.ToString());
					
				}
				return ret;
			}
		 
		}

		public int supplyID;
		public int SupplyID
		{
			get 
			{
				return this.supplyID;
			}
			set 
			{
				this.supplyID=value;
			}
		}
		
		public static String toMD5 (String s) //把字符串“s”用MD5算法编码
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			
			byte[] aa = System.Text.Encoding.UTF8.GetBytes(s);
			
			byte[] res = md5.ComputeHash(aa);
					
			StringBuilder bb = new StringBuilder();

			for (int i=0; i<res.Length;i++)
			{
				if (res[i]<16)
				{
					bb.Append("0");
				}
				bb.Append(res[i].ToString("x"));
			}
			
			return bb.ToString();

		}

	}
}
