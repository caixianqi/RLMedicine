using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Bao.BillBase
{
    /// <summary>
    /// 该类为单据的实体类，可以包括多个实体表，只能有一个主实体表
    /// </summary>
    public abstract class BillBase
    {

        public  virtual string CheckIsNull(object value, string mesg)
        {
            if (value.ToString() == string.Empty)
            {
                return "["+mesg+"]";
            }
            else
            {
                return string.Empty;
            }
        }

      

      
        /// <summary>
        /// 单据实际包括的实体表集合
        /// </summary>
        public EntityTable[] EntityTables;
       // private string _BillId="";
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillId
        {
            get { return EntityTables[0].Table.Rows[0][KeyFieldName].ToString(); }
            set { EntityTables[0].Table.Rows[0][KeyFieldName] = value; }
        }
        public String EntityId;
        
        
        private string _KeyFieldName;
        /// <summary>
        /// 主键字段名称
        /// </summary>
        public string KeyFieldName
        {
            get { return _KeyFieldName; }
            set { _KeyFieldName = value; }
        }
        private int  _BillState;
        /// <summary>
        /// 0 :未审核，1 :审核
        /// </summary>
        public int BillState
        {
            get { return _BillState; }
            set { _BillState = value; }
        }
        private string _FunctionId;
        /// <summary>
        /// 功能编号，单据类型的唯一编码，该编码在数据库表TFunctions的FunctionId字段中定义
        /// </summary>
        public string FunctionId
        {
            get { return _FunctionId; }
            set { _FunctionId = value; }
        }
        /// <summary>
        /// 
        /// </summary>
		private string _TempId;

		public string TempId {
			get {
				return _TempId;
			}
			set {
				_TempId = value;
			}
		}
	    /// <summary>
	    /// 对实体表增加一个新行
	    /// </summary>
	    /// <param name="table1">实体表</param>
	    /// <returns></returns>
        public System.Data.DataRow  NewRow(EntityTable table1)
        {
            
            // System.Data.DataRow row1 = table1.Table.NewRow();
            // table1.SetDefaultValue(this,row1);
            // table1.Table.Rows.Add(row1);
            // return row1;

            return  table1.NewRow(this);
        }

        /// <summary>
        /// 得到主表对象
        /// </summary>
        /// <returns></returns>
        public EntityTableMain GetMain()
        {
            foreach(EntityTable obj in EntityTables )
            {
                if (obj is EntityTableMain)
                    return (EntityTableMain) obj;
            }
            throw new Exception("该单据没有主表信息或没有从EntityTableMain 继承");
        }
        
        /// <summary>
        /// 初始化单据
        /// </summary>
        /// <param name="mBillId">单据编号</param>
        public void Init(string mBillId)
        {
            int i=0;
            foreach (EntityTable Entity1 in EntityTables)
            {
                i++;
                Entity1.Table = Bao.DataAccess.DataAcc.ExecuteQuery(Entity1.SelectSQL(mBillId));
                Entity1.Table.TableName = "Table" + i.ToString();
                //if (Entity1.Table.Rows.Count == 0)
                //{
                //    NewRow(Entity1);
                //}
                if (Entity1 is  EntityTableMain)
                {
                    //if (mBillId=="")    //如果是新增则增加一个空行
                    NewRow(Entity1);
                    if (!(mBillId == string.Empty))
                    {
                        Entity1.Table.Rows[0][KeyFieldName] = mBillId;
                    }
                      //  Entity1.Table.Rows[0][KeyFieldName] = mBillId;

                    
                }
            }
        }
        /// <summary>
        /// 新增保存
        /// </summary>
        public void NewSave()
        {
            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
            Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
            string Sql="";
            try
            {
                NewBefor();
                
                foreach (EntityTable Entity1 in EntityTables)
                {
                    Sql = "";
                    if (Entity1 is EntityTableMain)    //主表
                    {
                        foreach (System.Data.DataRow row1 in Entity1.Table.Rows)
                        {
                            Sql = "";
                            row1.EndEdit();
                            Sql = ((EntityTableMain)Entity1).Insert(BillId,row1);
                            //System.Data.DataTable tempTable = Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
                            //BillId = tempTable.Rows[0][0].ToString();
                            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
                            // BillId = row1[KeyFieldName].ToString();
                        }
                    }
                    else//子表
                    {
                        foreach (System.Data.DataRow row1 in Entity1.Table.Rows)
                        {
                            if (row1.RowState != System.Data.DataRowState.Deleted)
                            {
                                Sql = "";
                                Sql = ((EntityTableItem)Entity1).InsertSQL(BillId, row1);

                                if (Sql == "")
                                    throw new Exception("方法ItemToSQL()没有返回Insert Into 语句");
                                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
                            }


                        }
                    }
                }
                NewAfter();
                sqlTran.Commit();
                
            }
            catch (Exception e)
            {
                sqlTran.Rollback();
                throw new Exception(e.Message + "(" + Sql + ")");
            }
        }
        /// <summary>
        /// 修改保存
        /// </summary>
        public void UpdateSave()
        {
            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
            Bao.DataAccess.DataAcc.UpLoadCmd.Transaction = sqlTran;
            string Sql="";
            try
            {
                UpBefor();
                foreach (EntityTable Entity1 in EntityTables)
                {
                    Sql = "";
                    if (Entity1 is EntityTableMain)
                    {
                        Sql = ((EntityTableMain)Entity1).UpdataSQL(Entity1.Table.Rows[0]);
                        Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
                    }
                    else
                    {
                        Bao.DataAccess.DataAcc.ExecuteNotQuery(Entity1.DeleteSQL(BillId));
                        
                        foreach (System.Data.DataRow row1 in Entity1.Table.Rows)
                        {  
                            if (row1.RowState != System.Data.DataRowState.Deleted )
                            {
                                Sql = "";
                                //row1[KeyFieldName] = BillId;
                                Sql = ((EntityTableItem)Entity1).InsertSQL(BillId, row1);
                                if (Sql == "")
                                    throw new Exception("方法ItemToSQL()没有返回Insert Into 语句");
                                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
                            }
                        }
                    }
                }
                UpAfter();
                sqlTran.Commit();
            }
            catch (Exception e)
            {
                sqlTran.Rollback();
                throw new Exception(e.Message + "(" + Sql + ")");
            }
        }
        /// <summary>
        /// 产出单据
        /// </summary>
        public void Delete()
        {
            DelBefor();
            foreach (EntityTable Entity1 in EntityTables)
            {
                string Sql = "";
                foreach (System.Data.DataRow row1 in Entity1.Table.Rows)
                {
                    Sql = "";
                    Sql = Entity1.DeleteSQL(BillId);
                    if (Sql == "")
                        throw new Exception("方法ItemToSQL()没有返回Insert Into 语句");
                    Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
                }
            }
            DelAfter();
        }
        /// <summary>
        /// 修改单据审核标记
        /// </summary>
        public void Audit()
        {

            AuditBefor();
            EntityTableMain aa = this.GetMain();

            Bao.DataAccess.DataAcc.ExecuteNotQuery(aa.Audit(this.BillId));
            AuditAfter();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        public virtual void UnAudit()
        {
           
                UnAuditBefor();
                EntityTableMain aa = this.GetMain();
                Bao.DataAccess.DataAcc.ExecuteNotQuery(aa.UnAudit(this.BillId));
                UnAuditAfter();
                
            
        }
        /// <summary>
        /// 审核前执行
        /// </summary>
        public abstract void AuditBefor();
        /// <summary>
        /// 审核后执行
        /// </summary>
        public abstract void AuditAfter();
        /// <summary>
        /// 弃审前执行
        /// </summary>
        public abstract void UnAuditBefor();
        /// <summary>
        /// 弃审后执行
        /// </summary>
        public abstract void UnAuditAfter();
        /// <summary>
        /// 新增保存前执行
        /// </summary>
        public abstract void NewBefor();
        /// <summary>
        /// 新增保存后执行
        /// </summary>
        public abstract void NewAfter();
        /// <summary>
        /// 修改保存前执行
        /// </summary>
        public abstract void UpBefor();
        /// <summary>
        /// 修改保存后执行
        /// </summary>
        public abstract void UpAfter();
        /// <summary>
        /// 删除前执行
        /// </summary>
        public abstract void DelBefor();
        /// <summary>
        /// 删除后执行
        /// </summary>
        public abstract void DelAfter();
        /// <summary>
        /// 提交前执行
        /// </summary>
        public abstract void UpLoadBefor();
        /// <summary>
        /// 提交后执行
        /// </summary>
        public abstract void UpLoadAfter();
        /// <summary>
        /// 收回前执行
        /// </summary>
        public abstract void UpCancelBefor();
        /// <summary>
        /// 收回后执行
        /// </summary>
        public abstract void UpCancelAfter();

        /// <summary>
        /// 产生单据编号
        /// </summary>
        /// <param name="Sender"></param>
        public abstract void GetCode(FrmBillBase Sender);
        /// <summary>
        /// 返回建单人名称
        /// </summary>
        public abstract string ReturnCreateUserFieldName();
        /// <summary>
        /// 审批扣分
        /// </summary>
        /// <param name="score">分数</param>
        public void Rating(double score)
        {
            EntityTableMain aa =this.GetMain();
            string ss = aa.Rating(score, this.BillId);
            if (ss != null && ss.Trim()!="")
                Bao.DataAccess.DataAcc.ExecuteNotQuery(ss);
        }
       

    }
}
