using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RLBase
{
    class frmSQL
    {
        /// <summary>
        /// 查询某个基础档案表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataTable Select_SQL_RLBase(string tableName) 
        {
            string sql = string.Format("Select code, name, comment from " + tableName);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 插入某个基础档案表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        public void Insert_SQL_RLBase(string tableName, string code, string name, string comment)
        {
            string sql = string.Format("insert [" + tableName + "](code,name,comment)  "
                                       + "select '{0}','{1}','{2}'", code, name, comment);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 更新某个基础档案表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        public void Update_SQL_RLBase(string tableName, string code, string name, string comment)
        {
            string sql = string.Format("update [" + tableName + "] set name= '{1}',comment ='{2}' where code='{0}' ", code, name, comment);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 某个基础档案表的编码是否已经存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">编码</param>
        /// <returns></returns>
        public DataTable Select_Is_RLBase(string tableName, string code)
        {
            string sql = string.Format("select code from [" + tableName + "] where code='{0}'  ", code);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

         /// <summary>
        /// 删除某个基础档案表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">用户名</param>
        public void Delete_SQL_RLBase(string tableName, string code)
        {
            string sql = string.Format("delete  [" + tableName + "] where code='{0}'", code);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 查询BaseDepartMent（部门）表所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll_SQL_BaseDepartMent()
        {
            string sql = string.Format("select deptNum, deptName, parentNum, isend from BaseDepartMent");
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 根据父节点编码，查找父节点以下的子节点
        /// </summary>
        /// <param name="numparent">父节点编码</param>
        /// <returns></returns>
        public DataTable Select_SQL_BaseDepartMent_parentnum(string parentnum)
        {
            string sql = string.Format("select deptNum, deptName, parentNum, isend from BaseDepartMent where isnull(parentNum,'')='{0}'", parentnum);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 增加节点
        /// </summary>
        /// <param name="deptNum">编码</param>
        /// <param name="deptName">名称</param>
        /// <param name="parentNum">父节点编码</param>
        /// <param name="isend">是否为末级，“1”为末级</param>
        public void Insert_SQL_BaseDepartMen(string deptNum, string deptName, string parentNum, string isend)
        {
            string sql = string.Format("insert into BaseDepartMent (deptNum,deptName,parentNum,isend) values ('{0}', '{1}', '{2}', '{3}')", deptNum, deptName, parentNum, isend);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 根据编码，查找指定数据
        /// </summary>
        /// <param name="numparent">编码</param>
        /// <returns></returns>
        public DataTable Select_SQL_BaseDepartMent_deptnum(string deptnum)
        {
            string sql = string.Format("select deptNum, deptName, parentnum, isend from BaseDepartMent where deptnum='{0}'", deptnum);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }


        /// <summary>
        /// 删除部门表的数据
        /// </summary>
        /// <param name="deptNum">编码</param>
        public void Delete_SQL_BaseDepartMent(string deptNum)
        {
            string sql = string.Format("delete [BaseDepartMent] where deptNum='{0}'", deptNum);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 更新部门表的数据
        /// </summary>
        /// <param name="deptNum">编码</param>
        /// <param name="deptName">名字</param>
        /// <param name="isend">是否为末级</param>
        public void Update_SQL_BaseDepartMent(string deptNum, string deptName, string isend)
        {
            string sql = string.Format("update [BaseDepartMent] set deptName= '{1}',isend ='{2}' where deptNum='{0}' ", deptNum, deptName, isend);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 某个部门表的数据是否已经存在
        /// </summary>
        /// <param name="num">编码</param>
        /// <returns></returns>
        public DataTable Select_Is_BaseDepartMent(string num)
        {
            string sql = string.Format("select deptnum from [BaseDepartMent] where deptnum='{0}'  ", num);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 插入机器级别表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">编码</param>
        /// <param name="type">类型</param>
        /// <param name="grade">级别</param>
        /// <param name="model">型号</param>
        /// <param name="productline">产品线</param>
        public void Insert_SQL_RLBaseMachineGrade(string code, string type, string grade, string model, string cinvstd, string productline)
        {
            string sql = string.Format("insert BaseMachineGrade (code,type,grade,model,cinvstd,productline)  "
                                       + "select '{0}','{1}','{2}','{3}','{4}','{5}'", code, type, grade, model, cinvstd, productline);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 更新机器级别表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="code">编码</param>
        /// <param name="type">类型</param>
        /// <param name="grade">级别</param>
        /// <param name="model">型号</param>
        /// <param name="productline">产品线</param>
        public void Update_SQL_RLBaseMachineGrade(string code, string type, string grade, string model, string cinvstd, string productline)
        {
            string sql = string.Format("update BaseMachineGrade set type= '{1}',grade ='{2}', model ='{3}', cinvstd = '{4}',productline='{5}' where code='{0}' ", code, type, grade, model, cinvstd, productline);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 查询机器级别表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataTable Select_SQL_RLBaseMachineGrade(string tableName)
        {
            string sql = string.Format("Select code, type, grade, model, cinvstd,productline from " + tableName);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }
    }
}
