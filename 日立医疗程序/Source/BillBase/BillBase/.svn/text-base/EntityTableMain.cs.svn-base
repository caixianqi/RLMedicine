using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.BillBase
{
    /// <summary>
    /// 单据主表基类
    /// </summary>
    public abstract class EntityTableMain : EntityTable  
    {
        public EntityTableMain()
        {
            
        }
        public string Insert(string BillId,System.Data.DataRow row1)
        {
            //return "set nocount on "+InsertSQL(row1)+" select @@IDENTITY";
            return  InsertSQL(BillId,row1) ;
        }
        /// <summary>
        /// insert 语句
        /// </summary>
        /// <param name="BillId">单号</param>
        /// <param name="row1">要插入的行</param>
        /// <returns>SQL语句</returns>
        public abstract string InsertSQL(string BillId, System.Data.DataRow row1);
        /// <summary>
        /// Update语句
        /// </summary>
        /// <param name="row1">要修改的行</param>
        /// <returns>SQL语句</returns>
        public abstract string UpdataSQL(System.Data.DataRow row1);
       /// <summary>
       /// 修改审核标记为1
       /// </summary>
       /// <param name="BillId"></param>
       /// <returns></returns>
        public abstract string Audit(string BillId);
        /// <summary>
        /// 修改审核标记为0
        /// </summary>
        /// <param name="BillId"></param>
        /// <returns></returns>
        public abstract string UnAudit(string BillId);
        public override  System.Data.DataRow NewRow(BillBase BillObj)
        {
            System.Data.DataRow row1;
            if (Table.Rows.Count > 0)
            {
                row1 = Table.Rows[0];
                //SetDefaultValue(BillObj, row1);
            }
            else
            {
                row1 = Table.NewRow();
                SetDefaultValue(BillObj, row1);
                Table.Rows.Add(row1);
            }
           
            return row1;
        }
        /// <summary>
        /// 评分
        /// </summary>
        /// <param name="score">分数</param>
        /// <param name="BillId">单号</param>
        public virtual string Rating(double score,string BillId)
        {
            return null;
        }
        
    }
}
