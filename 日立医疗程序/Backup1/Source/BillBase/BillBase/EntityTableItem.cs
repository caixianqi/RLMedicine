using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.BillBase
{
    /// <summary>
    /// 单据子表基类
    /// </summary>
    public abstract class EntityTableItem : EntityTable  
    {

        public EntityTableItem()
        {
           
        }
        /// <summary>
        /// insert 语句
        /// </summary>
        /// <param name="BillId">单据编号</param>
        /// <param name="row1">要插入的行</param>
        /// <returns>SQL语句</returns>
        public abstract string InsertSQL(string BillId, System.Data.DataRow row1);
        public override  System.Data.DataRow NewRow(BillBase BillObj)
        {

            System.Data.DataRow row1 = Table.NewRow();
            SetDefaultValue(BillObj, row1);
            Table.Rows.Add(row1);
           
            return row1;
        }
    }
}
