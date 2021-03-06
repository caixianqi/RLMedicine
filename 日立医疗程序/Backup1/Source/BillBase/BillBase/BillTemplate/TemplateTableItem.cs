using System;
using System.Collections.Generic;
using System.Text;

namespace BillBase.BillTemplate
{
    class TemplateTableItem : Bao.BillBase.EntityTableItem
    {
        /// <summary>
        /// //此处增加插入该表的SQL语句 必须重载
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <param name="row1">要增加的记录</param>
        /// <returns>SQL语句</returns>
        public override string InsertSQL(string BillId, System.Data.DataRow row1)
        {
            
            return "";
        }
        /// <summary>
        /// //此处增加删除该表的SQL语句 必须重载
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <returns>SQL语句</returns>
        public override string DeleteSQL(string BillId)
        {
            return "";
        }
        /// <summary>
        /// //此处增加查询该表的SQL语句 必须重载
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <returns>SQL语句</returns>
        public override string SelectSQL(string BillId)
        {
            return "";
        }
        /// <summary>
        /// //对NewRow的字段设置默认值；
        /// </summary>
        /// <param name="Sender">窗体对象</param>
        /// <param name="NewRow">被赋值的行</param>
        public override void SetDefaultValue(Bao.BillBase.BillBase Sender, System.Data.DataRow NewRow)
        {
            //NewRow[""]="";
        }
    }
}
