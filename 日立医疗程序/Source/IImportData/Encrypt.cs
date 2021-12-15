using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.DataAccess {
	public class Encrypt {
		public Encrypt() {
			//
			//TODO: 在此处添加构造函数逻辑
			//
		}
		#region 64位编码
		public static string Base64Encode(string str) {
			byte[] barray;
			barray = Encoding.Default.GetBytes(str);
			return Convert.ToBase64String(barray);
		}
		#endregion

		#region 64位解码
		public static string Base64Decode(string str) {
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
		public static string EPwd(string res) {
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
		public static string DPwd(string pwd) {
			string res = "";
			try {
				res = Base64Decode(pwd);
				//功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
				res = ChangeStringPosi(res, 6, 2, 2);
				//进一步编码
				res = Base64Decode(res);
				res = res.Substring(0, res.Length - "xueray".Length);
			} catch (Exception ex) {
				res = "";
				throw ex;
			}
			return res;
		}

		#endregion

		#region 字符串中的字符位置调换
		//功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
		public static string ChangeStringPosi(string resStr, int bakPos1, int bakPos2, int length) {
			string a01 = resStr.Substring(0, resStr.Length - bakPos1);
			string a02 = resStr.Substring(resStr.Length - bakPos1, length);
			string a03 = resStr.Substring(resStr.Length - bakPos1 + length, bakPos1 - bakPos2 - length);
			string a04 = resStr.Substring(resStr.Length - length);
			return a01 + a04 + a03 + a02;
		}
		#endregion
	}
}
