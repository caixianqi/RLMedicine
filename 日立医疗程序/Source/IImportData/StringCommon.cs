using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bao
{
   public  class StringCommon
    {
        /// <summary>
        ///  数字转换为字母
        /// </summary>
        /// <param name="shuzi">數字</param>
        /// <returns>返回對應的ASCII字母</returns>
        public string NumToABC(int shuzi)
        {
            byte[] array2 = new byte[1];
            array2[0] = (byte)(Convert.ToInt32(shuzi));
            string zimu2 = Convert.ToString(System.Text.Encoding.ASCII.GetString(array2));
            return zimu2;
        }

        /// <summary>
        /// 字母转换为数字
        /// </summary>
        /// <param name="zimu">字母</param>
        /// <returns>返回ASCII字母對應的數字</returns>
        public int ABCToNum(string zimu)
        {
            byte[] array = new byte[1];
            array = System.Text.Encoding.ASCII.GetBytes(zimu);
            int asciicode = (short)(array[0]);
            return asciicode;
        }

        /// <summary>
        /// 字符判断是否整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsIntNum(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }


        /// <summary>
        ///  检查是否含有大写字母A-Z
        /// </summary>
        /// <param name="InputText">需要检查的字符串</param>
        /// <returns></returns>
        public bool IsBigEngStr(string str)
        {
            Regex reg = new Regex(@"^[A-Z]+$");//正则表达式
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查是否含有小写字母a-z
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsSmallEngStr(string str)
        {
            Regex reg = new Regex(@"^[a-z]+$");//正则表达式
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查是否含有大小写字母a-zA-Z
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsEngStr(string str)
        {
            Regex reg = new Regex(@"^[a-zA-Z]+$");//正则表达式
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 遍歷字符判斷是否為數字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>驗證成功，返回true，驗證失敗。返回false</returns>
        public bool isNumeric(string str)
        {
            char[] ch = new char[str.Length];
            ch = str.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] < 48 || ch[i] > 57)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 字符判斷是否可转為Int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsInt(string str)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 字符判斷是否可转為Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsDecimal(string str)
        {
            decimal result = 0.00M;
            try
            {
                result = Convert.ToDecimal(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 字符判斷是否可转為DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsDateTime(string str)
        {
            DateTime result;
            try
            {
                result = Convert.ToDateTime(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 生成數
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RandNum(int n)
        {
            char[] arrChar = new char[]{ 
										  '1','2','3','4','5','6','7','8','9'
									   };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return Convert.ToInt32(num.ToString());
        }

        /// <summary>
        /// 保留n位長度小數
        /// </summary>
        /// <param name="floatNum">浮點數字</param>
        /// <param name="lenght">要保留多少位長度的小數</param>
        /// <returns>返回n位長度的小數</returns>
        public string FormateFloat(float floatNum, int lenght)
        {
            string retFloat = string.Empty;
            string strNum = floatNum.ToString();
            string[] strArr = new string[2];
            strArr = strNum.Split('.');
            if (strArr.Length == 2)
            {
                if (strArr[1].Length > 0)
                {
                    if (strArr[1].Length > lenght)
                    {
                        retFloat = strArr[0].ToString() + "." + strArr[1].ToString().Substring(0, lenght);
                    }
                    else
                    {
                        string plugZore = strArr[1].ToString();
                        for (int i = 0; i < lenght - strArr[1].Length; i++)
                        {
                            plugZore += "0";
                        }
                        retFloat = strArr[0].ToString() + "." + plugZore;
                    }
                }
            }
            else
            {
                retFloat = strArr[0].ToString();
            }
            return retFloat;
        }


        /// <summary>
        ///  检查是否含有中文
        /// </summary>
        /// <param name="InputText">需要检查的字符串</param>
        /// <returns></returns>
        public bool isHasChzn_C(string str)
        {
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");//正则表达式
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 过滤非法字符的函数,主要是为了防止sql注入攻击
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CheckSql(string str)
        {
            string s = string.Empty;
            if (str == null)
            {
                s = string.Empty;
            }
            else
            {
                s = str.Replace("'", "").Replace("*", "").Replace("select", "")
                       .Replace("where", "").Replace(";", "").Replace("(", "").Replace(")", "").Replace("drop", "").Replace("DROP", "").Replace("and", "").Replace("or", "").Replace("delete", "").Replace("asc", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace(";", "").Replace("&", "").Replace("*", "").Replace(" ", "");
            }
            return s;
        }

        /// <summary>
        /// 檢查是否有非法字符   '\\'、 '/'、':'、 '*'、 '?'、 '"'、 '<'、 '>'、 '|'，通常用於檢查文件夾命名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool CheckIfNotLegal(string str)
        {
            char[] InvalidChars = new[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };//文件夾命名的非法字符
            char[] chr = str.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                char chri = chr[i];
                for (int j = 0; j < InvalidChars.Length; j++)
                {
                    char chrj = InvalidChars[j];
                    if (chri == chrj)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 字符串中含有 \ / : * ? '' < > | ' 的字符轉換成 _ (由於文件夾命名原因)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetValue(string str)
        {
            string value = str;
            value = value.Replace("\\", "_");
            value = value.Replace("/", "_");
            value = value.Replace(":", "_");
            value = value.Replace("*", "_");
            value = value.Replace("?", "_");
            value = value.Replace("''", "_");
            value = value.Replace("<", "_");
            value = value.Replace(">", "_");
            value = value.Replace("|", "_");
            return value;
        }

        /// <summary>
        /// 去掉特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Check_StrReplace(string str)
        {
            string s = string.Empty;
            if (str == null)
            {
                s = string.Empty;
            }
            else
            {
                s = str.Replace("&", "").Replace("\\", "").Replace("*", "").Replace("''", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("%", "").Replace("%", "");
            }
            return s;
        }

    }
}
