using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FormMain.LoginBAL
{
    public class LoginBL
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMD5Encording(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] _byte = Encoding.Default.GetBytes(str);
            byte[] _byteRst = md5.ComputeHash(_byte);
            StringBuilder SBuilder = new StringBuilder();
            for (int i = 0; i < _byteRst.Length; i++)
            {
                SBuilder.Append(_byteRst[i].ToString("x2"));
            }
            return SBuilder.ToString();
        }


        /// <summary>
        /// 登录验证 
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="PassWord">密码</param>
        /// <returns></returns>
        public DataTable Select_SQL_Users_Login(string UserId,string PassWord)
        {
            string Sql = string.Format("select DISTINCT a.AutoUserId,a.UserId,UserName,d.functionId,e.RoleId,a.AuditGroupId," +
                        " functionName,DllName,WorkName,Title,TitleGroup,Memo   " +
                        "from [Users] a,TFunctions d,UserAuth b,Auth c,TRoleUsers e " +
                        "where a.AutouserId=e.AutouserId and e.RoleId=b.AutouserId and b.authId= c.authId and c.functionid=d.functionid  " +
                        "and a.userId='{0} ' and a.password='{1} ' and a.State='1' ", UserId, PassWord);
           return Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
        }

 
        /// <summary>
        /// 登录验证    已封存的
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="PassWord">密码</param>
        /// <returns></returns>
        public DataTable Select_SQL_Users_Login_Satae(string UserId, string PassWord)
        {
            string Sql = string.Format("select DISTINCT a.AutoUserId,UserName,d.functionId," +
                        "functionName,DllName,WorkName,Title,TitleGroup,Memo   " +
                        "from [Users] a,TFunctions d,UserAuth b,Auth c,TRoleUsers e " +
                        "where a.AutouserId=e.AutouserId and e.RoleId=b.AutouserId and b.authId= c.authId and c.functionid=d.functionid  " +
                        "and a.userId='{0}' and a.password='{1}' and a.State='0' ", UserId, PassWord);
            return Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
        }

        /// <summary>
        /// 获取角色对应的操作员
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Role_Users(string roleID)
        {
            string sql = string.Format(@"select b.AutoUserId,b.UserId,b.userName,b.deptNum,a.RoleId from TRoleUsers a
	                        inner join Users b on a.AutoUserId = b.AutoUserId
	                        where RoleId ='{0}' and [State] = 1",roleID);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select_SQL_Users_Info()
        {
            string sql = string.Format("select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum,case State when 1 then '正常' else '已封存' end as State,Memo," +
                "b.AuditGroupId,b.AuditGroupName  from [Users]  a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId  where UserId!='demo'  ");
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select_SQL_Users_Info(string strWhere)
        {
            string sql = string.Format("select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum,case [State] when 1 then '正常' else '已封存' end as State,Memo,DeptAttribute,b.AuditGroupId,b.AuditGroupName  from [Users]  a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId  where UserId!='demo' {0} ", strWhere);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 有用户管理权限的用户，但不包括demo
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable Select_SQL_User_Infos(string UserId, string Password, string strWhere)
        {
            string sql = string.Format("select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum,case State when 1 then '正常' else '已封存' end as State,Memo,DeptAttribute,b.AuditGroupId,b.AuditGroupName " +
                " from [Users]  "
                + "a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId "
                +"where  UserId!='demo' and  Memo !='系统管理员' {2}   union       "
          + "select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum, case State when 1 then '正常' else '已封存' end as State,Memo,DeptAttribute,b.AuditGroupId,b.AuditGroupName " +
                     " from [Users] "
                     + "a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId "
                      + "where UserId!='{0}' and [Password]!='{1}' and  Memo !='系统管理员' {2} ", UserId, Password, strWhere);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 有用户管理权限的用户，但不包括demo
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable Select_SQL_User_Infos(string UserId, string Password)
        {
            string sql = string.Format("select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum,case State when 1 then '正常' else '已封存' end as State,Memo,DeptAttribute,b.AuditGroupId,b.AuditGroupName " +
                " from [Users]  "
                + "a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId "
                + "where  UserId!='demo' and  Memo !='系统管理员'   union       "
          + "select AutoUserID,UserId,UserName,[Password],a.AuditGroupId,a.DeptName,a.ismanager,a.deptNum, case State when 1 then '正常' else '已封存' end as State,Memo,DeptAttribute,b.AuditGroupId,b.AuditGroupName " +
                     " from [Users] "
                     + "a left outer join [AuditGroup] b  on a.AuditGroupId=b.AuditGroupId "
                      + "where UserId!='{0}' and [Password]!='{1}' and  Memo !='系统管理员' ", UserId, Password);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="UserId">用户名</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户密码</param>
        /// <param name="State">用户状态</param>
        /// <param name="cDepName">部门名称</param>
        /// <param name="ismanager">是否为管理员</param>
        /// <param name="deptNum">部门编码</param>
        ///  <param name="DeptAttribute">所属部门</param>
        public void Insert_SQL_Users(string UserId, string UserName, string Password, string Memo, string AuditGroupId, string cDepName, string ismanager, string deptNum, string DeptAttribute)
        {
            string sql = string.Format("insert [Users](UserId,UserName,[Password],State,Memo,AuditGroupId,DeptName,ismanager,deptNum,DeptAttribute)  "
                                       + "select '{0}','{1}','{2}','1','{3}','{4}','{5}','{6}','{7}','{8}'", UserId, UserName, Password, Memo, AuditGroupId, cDepName, ismanager, deptNum, DeptAttribute);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 用户是否已经存在
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable Select_Is_User(string UserId)
        {
            string sql = string.Format("select * from [Users] where UserId='{0}'  ", UserId);
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="oldPwd">旧用户密码</param>
        /// <param name="newPwd">新用户密码</param>
        /// <param name="Memo">备注</param>
        /// <param name="cDepName">部门名称</param>
        /// <param name="ismanager">是否为管理员</param>
        /// <param name="deptNum">部门编码</param>
        /// <param name="DeptAttribute">所属部门</param>
        public void Update_SQL_Users(string user, string oldPwd, string newPwd, string UserName, string Memo, string AuditGroupId, string DeptName, string ismanager, string deptNum, string DeptAttribute)
        {
            string sql = string.Format("update  [Users] set [Password]='{2}',UserName='{3}',Memo='{4}',AuditGroupId='{5}',DeptName = '{6}',ismanager = '{7}',deptNum = '{8}',DeptAttribute = '{9}' where UserId='{0}' and [Password]='{1}'  ", user, oldPwd, newPwd, UserName, Memo, AuditGroupId, DeptName, ismanager, deptNum, DeptAttribute);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 修改个人用户信息
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="oldPwd">久密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="Memo">备注</param>
        public void Update_SQL_User(string user, string UserName, string oldPwd, string newPwd, string Memo)
        {
            string sql = string.Format("update  [Users] set [Password]='{3}',UserName='{1}',Memo='{4}' where UserId='{0}' and [Password]='{2}'  ", user, UserName, oldPwd, newPwd, Memo);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="User">用户名</param>
        /// <param name="Password">密码</param>
        public void Delete_SQL_Users(string User, string Password, string AutoUserId)
        {
            string sql = string.Format("delete  [Users] where UserId='{0}' and [Password]='{1}' ", User, Password);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 获取用户的状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string Select_SQL_Users_State(string UserId, string Password)
        {
            string sql = string.Format("select case State when 1 then '正常' else '已封存' end as State from [Users] where UserId='{0}' and [Password]='{1}' ", UserId, Password);
            return  Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }

        /// <summary>
        /// 封存用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        public void Update_SQL_Users_State_false(string UserId, string Password)
        {
            string sql = string.Format("update  [Users] set State='0' where UserId='{0}' and [Password]='{1}' ", UserId, Password);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 解存用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        public void Update_SQL_Users_State_true(string UserId, string Password)
        {
            string sql = string.Format("update  [Users] set State='1' where UserId='{0}' and [Password]='{1}'  ", UserId, Password);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 个人修改信息权限 取数
        /// </summary>
        /// <returns></returns>
        public DataTable Select_SQL_Auth_and_TFunctions()
        {
            string sql=string.Format("select * from  Auth c inner join TFunctions d on c.FunctionId=d.FunctionId  "
                                     +"where d.FunctionId='2' and FunctionName='用户修改'");
            return  Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取用户的AutoUserID信息
        /// </summary>
        /// <param name="UserId">用户名</param>
        /// <param name="Password">用户密码</param>
        /// <returns>AutoUserID</returns>
        public string Select_SQL_Users_AutoUserID(string UserId, string Password)
        {
            string sql = string.Format("select AutoUserID from [Users]  where UserId='{0}' and [Password]='{1}'  ", UserId, Password);
            return  Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }

        /// <summary>
        /// 解存用户
        /// </summary>
        /// <param name="AutoUserId"></param>
        /// <param name="AuthID"></param>
        public void Insert_SQL_UserAuth_Info(string AutoUserId, string AuthID)
        {
            string sql = string.Format("insert UserAuth(AutoUserId,AuthID) select '{0}','{1}'  ", AutoUserId, AuthID);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 模块信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select_SQL_Auth_and_TFunctions_Infos()
        {
             string sql=string.Format("select AuthId,AuthName,c.FunctionId,FunctionName,state,DLLName,WorkName,Param,Title,TitleGroup   "
                                      +"from  Auth c inner join TFunctions d on c.FunctionId=d.FunctionId ");
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 判断用户是否已经存在该权限
        /// </summary>
        /// <param name="AutoUserId"></param>
        /// <param name="AuthId"></param>
        /// <returns></returns>
        public string Select_SQL_UserAuth_AuthId(string AutoUserId, string AuthId)
        {
            string sql = string.Format("select 1 from [UserAuth] where AutoUserId='{0}' and AuthId='{1}'  ", AutoUserId, AuthId);
            return Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }


        /// <summary>
        /// 插入 分配的权限
        /// </summary>
        /// <param name="AutoUserId"></param>
        /// <param name="AuthId"></param>
        public void Insert_SQL_UserAuth(string AutoUserId, string AuthId)
        {
            string sql = string.Format("insert [UserAuth](AutoUserId,AuthId) select '{0}','{1}'  ",AutoUserId,AuthId);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 删除 分配的权限
        /// </summary>
        /// <param name="AutoUserId"></param>
        /// <param name="AuthId"></param>
        public void Delete_SQL_UserAuth(string AutoUserId, string AuthId)
        {
            string sql = string.Format("delete [UserAuth]  where AutoUserId='{0}' and AuthId='{1}'  ", AutoUserId, AuthId);
            Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);
        }

        public DataTable GetU8DataBase()
        {
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);
            // (Lin 2020-07-01 修改) 新增加解密
            RiLiGlobal.MD5 md5 = new RiLiGlobal.MD5();

            string u8server = md5.Md5Decrypt(iniobj.read("database", "u8server", ""));
            string u8database = md5.Md5Decrypt(iniobj.read("database", "u8database", ""));

            string Sql = string.Format("select name from [{0}].Master.dbo.SysDatabases  where name like '{1}%' ",u8server, u8database.Substring(0,11));
            return Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
        }

        /// <summary>
        /// 获取日立医疗售后账套信息（Lin 2020-07-01 修改）
        /// </summary>
        /// <returns></returns>
        public DataTable GetLRDataBaseInfo()
        {
            RiLiGlobal.IniProcess iniobj = new RiLiGlobal.IniProcess(RiLiGlobal.IniProcess.AppPath);

            string Sql = " select AccountNum, AccountName from [U13SHOUHOU].dbo.RL_DBInfo where AccountNum='009'";
            return Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
        }

    }
}
