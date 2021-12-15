using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.BillBase
{
    /// <summary>
    /// 获取单号
    /// </summary>
    public interface ICode
    {
        /// <summary>
        ///  获取单号
        /// </summary>
        /// <returns>单号</returns>
        string GetId();
    }
}
