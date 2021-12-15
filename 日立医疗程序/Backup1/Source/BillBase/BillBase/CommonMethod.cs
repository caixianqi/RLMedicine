using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace Bao.BillBase.Audit
{
    /// <summary>
    /// 功能描述：提供通用方法
    /// </summary>
    public class CommonMethod 
    {
        //禁用，启用文本
        public static void SetEnable(TextBox txtText, bool flag)
        {
            txtText.Enabled = (flag == true ? true : false);
            txtText.BackColor = System.Drawing.Color.White;
            txtText.ReadOnly = (flag == true ? false : true);
        }


        //清空文本
        public static  void TextClear(Form frm)
        {
            foreach (Control control in frm.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                if (control is Panel)
                {
                    foreach (Control contr in (control as Panel).Controls)
                    {
                        if (contr is TextBox)
                        {
                            ((TextBox)contr).Text = "";
                        }
                    }
                }
                if (control is GroupBox)
                {
                    foreach (Control contr in (control as GroupBox).Controls)
                    {
                        if (contr is TextBox)
                        {
                            ((TextBox)contr).Text = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 生动流水编号 例如：如果参数0081，则产生0082
        /// </summary>
        /// <param name="orderNo">最后记录的编号</param>
        /// <returns>新的编号</returns>
        public static string GenerateNo(string orderNo)
        {
            int len = orderNo.Length;  //总字符串长度

            int endValue = Convert.ToInt32(orderNo);
            endValue += 1;
            string strEnd = endValue.ToString();
            int endValueLength = strEnd.Length;
            string beginValue = "";
            for (int i = 1; i <= len - endValueLength; i++)
            {
                beginValue += "0";
            }
            orderNo = beginValue + strEnd;
            return orderNo.Trim();
        }

        /// <summary>
        ///获得集合的最大值 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetMaxValue(IEnumerable<Int32> list)
        {
            return list.Max();
        }

        /// <summary>
        /// 生动流水编号 例如：如果参数0081，则产生0082
        /// </summary>
        /// <param name="maxInt">最大的整数</param>
        /// <param name="len">总字符串长度</param>
        /// <returns>新的流程号</returns>
        public static string GenerateNo(int maxInt, int len)
        {
            int endValue = maxInt;
            endValue += 1;
            string strEnd = endValue.ToString();
            int endValueLength = strEnd.Length;
            string beginValue = "";
            for (int i = 1; i <= len - endValueLength; i++)
            {
                beginValue += "0";
            }
            return (beginValue + strEnd).Trim();
        }


    }
}
