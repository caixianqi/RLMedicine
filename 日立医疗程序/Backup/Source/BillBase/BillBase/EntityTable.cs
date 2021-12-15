using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.BillBase
{
    /// <summary>
    /// 该类为单据所包含实体表的基类
    /// </summary>
    public abstract  class EntityTable  
    {
        public EntityTable()
        { }
        /// <summary>
        /// 实体表中的物理表载体
        /// </summary>
        public System.Data.DataTable Table;
        private string _TableName = "";
       
        /// <summary>
        /// 物理表名
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        //private string _KeyFieldName;
        ///// <summary>
        ///// 主键名称
        ///// </summary>
        //public string KeyFieldName
        //{
        //    get { return _KeyFieldName; }
        //    set { _KeyFieldName = value; }
        //}

        //protected Boolean MainFlag
        //{
        //    get;
        //    set;
        //}
        
       

       
        
        /// <summary>
        /// 删除SQL语句
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <returns></returns>
        public abstract string DeleteSQL(string BillId);
        
        /// <summary>
        /// 查询SQL语句
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <returns></returns>
        public abstract string SelectSQL(string BillId);
        
        /// <summary>
        /// 对该表的数据设置默认值
        /// </summary>
        /// <param name="Sender">实体表对象</param>
        /// <param name="NewRow">新增加的行</param>
        public abstract void SetDefaultValue(Bao.BillBase.BillBase Sender,System.Data.DataRow NewRow);
        /// <summary>
        /// 新建行
        /// </summary>
        /// <param name="BillObj">实体表对象</param>
        /// <returns>新行</returns>
        public abstract System.Data.DataRow NewRow(BillBase BillObj);
      


    }
}
