using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.DataAccess
{
    /// <summary>
    /// ���ڲ��������ڵ�sql����
    /// </summary>
    public interface ITranSactionSQL
    {
        /// <summary>
        /// ����SQL���
        /// </summary>
        /// <param name="row1">����SQL������õ�����</param>
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
