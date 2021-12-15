using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Bao.BillBase
{
    public  abstract  class BillBaseTwo 
    {

        public BillBaseTwo(string mTableMainName, string mKeyFieldName)
        {
            TableMainName = mTableMainName;
            KeyFieldName = mKeyFieldName;
        }
        private string _TableMainName = "";
       
        /// <summary>
        /// 主表数据库表名
        /// </summary>
        public string TableMainName
        {
            get { return _TableMainName; }
            set { _TableMainName = value; }
        }
        private string _KeyFieldName;
        /// <summary>
        /// 主键名称
        /// </summary>
        public string KeyFieldName
        {
            get { return _KeyFieldName; }
            set { _KeyFieldName = value; }
        }
        /// <summary>
        /// 主表名称
        /// </summary>
        public System.Data.DataTable TableMain;
        public System.Data.DataTable TableItems;
        /// <summary>
        /// 明细表名称
        /// </summary>
        private string _BillId;
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillId
        {
            get { return _BillId; }
            set { _BillId = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _FunctionId;

        public string FunctionId
        {
            get { return _FunctionId; }
            set { _FunctionId = value; }
        }
        /// <summary>
        /// 增加主表记录
        /// </summary>
        public void NewMain()
        {
            System.Data.DataRow row1 = TableMain.NewRow();
            SetDefaultValueMain(row1);
            TableMain.Rows.Add(row1);
            
        }
        /// <summary>
        /// 设置主表字段的缺省值
        /// </summary>
        /// <param name="MainTableRow"></param>
        public abstract void SetDefaultValueMain(System.Data.DataRow MainTableRow);
        /// <summary>
        /// 增加明细记录
        /// </summary>
        public void  NewItem()
        {
            System.Data.DataRow row1= TableItems.NewRow();
            SetDefaultvalueItem(row1);
            TableItems.Rows.Add(row1);

        }
        /// <summary>
        /// 设置明细表字段缺省值
        /// </summary>
        /// <param name="ItemTableRow"></param>
        public abstract void SetDefaultvalueItem(System.Data.DataRow ItemTableRow);
        /// <summary>
        /// 初始化主表和明细表
        /// </summary>
        /// <param name="mBillId">单据号码</param>
        public void Init(string mBillId)
        {
            TableMain = Bao.DataAccess.DataAcc.ExecuteQuery(GetSelectMainSQL(mBillId),"MainTable");
            if (TableMain.Rows.Count == 0)
            {
                NewMain();
            }

            TableItems = Bao.DataAccess.DataAcc.ExecuteQuery(GetSelectItemSQL(mBillId),"ItemTable");
            if (TableItems.Rows.Count == 0)
            {
                NewItem();
            }
            
        }
        /// <summary>
        /// 保存增加内容
        /// </summary>
        public void NewSave()
        {
            BeforAddSave();
            string Sql = "";
            Sql = GetInsertMainSQL();
            if (Sql=="")
                throw new Exception("方法GetInsertMainSQL()没有返回Insert Into 语句");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);

            foreach (System.Data.DataRow row1 in TableItems.Rows)
            {
                Sql = "";
                Sql = GetInsertItemSQL(row1);
                if (Sql == "")
                    throw new Exception("方法ItemToSQL()没有返回Insert Into 语句");
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
            }
            Sql = "";
            Sql = GetAfterInsertSQL();
            if (Sql != "")
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
            AfterAddSave();


        }

        #region 
        /// <summary>
        /// 获得主表的查询语句
        /// </summary>
        /// <param name="mBillId">单据编号</param>
        /// <returns>select 语句</returns>
        public abstract string GetSelectMainSQL(string mBillId);
        /// <summary>
        /// 获得明细表的查询语句
        /// </summary>
        /// <param name="mBillId">单据编号</param>
        /// <returns>select 语句</returns>
        public abstract string GetSelectItemSQL(string mBillId);
        /// <summary>
        /// 获得主表insert 语句
        /// </summary>
        /// <returns>insert 语句</returns>
        public abstract string GetInsertMainSQL();
        /// <summary>
        /// 获得明细表insert 语句
        /// </summary>
        /// <param name="InsertRow">要插入的明细记录</param>
        /// <returns>insert 语句</returns>
        public abstract string GetInsertItemSQL(System.Data.DataRow InsertRow);
        /// <summary>
        /// 获得单据保存后执行的SQL语句
        /// </summary>
        /// <returns>SQL 语句</returns>
        public abstract string GetAfterInsertSQL();
        /// <summary>
        /// 获得主表Update语句
        /// </summary>
        /// <returns>Update 语句</returns>
        public abstract string GetUpdateMainSQL();
        /// <summary>
        /// 获得单据保存后执行的SQL语句
        /// </summary>
        /// <returns>SQL</returns>
        public abstract string GetAfterUpdateSQL();
        /// <summary>
        /// 获得主表删除语句
        /// </summary>
        /// <returns>Delete 语句</returns>
        public abstract string GetDeleteMainSQL();
        /// <summary>
        /// 获得明细表删除语句
        /// </summary>
        /// <returns>delete 语句</returns>
        public abstract string GetDeleteItemSQL();
        /// <summary>
        /// 删除单据后执行的语句
        /// </summary>
        /// <returns></returns>
        public abstract string GetAfterDeleteSQL();
        /// <summary>
        /// 审核语句
        /// </summary>
        /// <returns></returns>
        public abstract string GetAuditSQL();
        /// <summary>
        /// 修改后执行的方法
        /// </summary>
        public abstract void AfterUpdateSave();
        /// <summary>
        /// 修改前执行的方法
        /// </summary>
        public abstract void BeforUpdateSave();
        /// <summary>
        /// 增加单据后执行的方法
        /// </summary>
        public abstract void AfterAddSave();
        /// <summary>
        /// 增加单据前执行的方法
        /// </summary>
        public abstract void BeforAddSave();
        #endregion
        /// <summary>
        /// 修改方法
        /// </summary>
        public void UpdateSave()
        {
            BeforUpdateSave();
            string Sql = "";
            Sql = GetUpdateMainSQL();
            if (Sql == "")
                throw new Exception("方法GetInsertMainSQL()没有返回Insert Into 语句");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
            Sql ="";
            Sql=GetDeleteItemSQL();
            if (Sql == "")
                throw new Exception("方法GetDeleteItemSQL()没有返回Delete 语句");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);

            foreach (System.Data.DataRow row1 in TableItems.Rows)
            {
                Sql = GetInsertItemSQL(row1);
                //if (Sql == "")
                //    throw new Exception("方法GetInsertItemSQL()没有返回Insert Into 语句");
                if (Sql!="")
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
            }

            Sql = GetAfterUpdateSQL();
            if (Sql != "")
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
            AfterUpdateSave();
        }
        public void Delete()
        {
            string Sql = "";
            Sql = GetDeleteMainSQL();
            if (Sql == "")
                throw new Exception("方法GetDeleteMainSQL()没有返回Delete 语句");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);

            Sql = GetDeleteItemSQL();
            if (Sql == "")
                throw new Exception("方法GetDeleteItemSQL()没有返回Delete语句");
            Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);


            Sql = GetAfterDeleteSQL();
            if (Sql != "")
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);
        }
        public void Audit()
        {
            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
            Bao.DataAccess.DataAcc.UpLoadCmd .Transaction = sqlTran;
            try
            {

                BeforAudit();

                string Sql = "";
                Sql = GetAuditSQL();
                if (Sql == "")
                    throw new Exception("方法GetAuditSQL()没有返回审核语句");
                Bao.DataAccess.DataAcc.ExecuteNotQuery(Sql);

                AfterAudit();
                sqlTran.Commit();
            }
            catch (Exception e)
            {

                sqlTran.Rollback();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 反审核方法
        /// </summary>
        public abstract void UnAudit();
        /// <summary>
        /// 审核后执行的方法
        /// </summary>
        public abstract void AfterAudit();
        /// <summary>
        /// 审核前执行的方法
        /// </summary>
        public abstract void BeforAudit();
    }
}
