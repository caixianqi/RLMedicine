using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.Analysis
{
    public interface IAnalysis
    {
        /// <summary>
        /// 建立U8数据的标结构
        /// </summary>
        /// <returns></returns>
         System.Data.DataTable CreateDescTable();
        /// <summary>
        /// 根据数据库的内容将原来表中的内容解析成用友库可以识别的信息
        /// </summary>
        /// <param name="SourceTable">其他系统的数据</param>
        /// <returns>用友可识别的数据</returns>
        Boolean JieXi(System.Data.DataRow SourceRow1, System.Data.DataRow destRow1, Bao.ErrMessage.IdelegateError mErr);

        /// <summary>
        /// 解析数据前对源数据进行处理；
        /// </summary>
        /// <param name="SourceTable">原数据</param>
        /// <returns></returns>
        void  BeforJieXi(System.Data.DataTable SourceTable);
        void AfterJieXi(System.Data.DataTable DestTable);

    }
}
