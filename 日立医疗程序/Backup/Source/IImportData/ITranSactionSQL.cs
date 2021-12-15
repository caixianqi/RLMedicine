using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.DataAccess
{
    /// <summary>
    /// 用于产生事务内的sql代码
    /// </summary>
    public interface ITranSactionSQL
    {
        /// <summary>
        /// 产生SQL语句
        /// </summary>
        /// <param name="row1">产生SQL语句所用的数据</param>
        /// <returns></returns>
        string DatatoSql(System.Data.DataRow row1);
        void  AfterCommit();

    }
    public interface IBusns
    {
        System.Data.DataTable TableItems
        {
            get;

            set;

        }
        string MastToSql();
        string ItemToSQL(System.Data.DataRow Row1);
        string AfterCommit();
    }
   
}
