using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.ErrMessage
{
    public interface  IdelegateError
    {
        /// <summary>
        /// 处理错误
        /// </summary>
        /// <param name="mErr">错误信息</param>
        void ProccErr(string mErr);
        /// <summary>
        /// 体现进度
        /// </summary>
        /// <param name="Message"></param>
        void ProcJD(double  DinJu);
    }
}
