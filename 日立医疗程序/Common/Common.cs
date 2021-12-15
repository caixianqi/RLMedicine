using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Common
    {
        /// <summary>
        /// 获取角色对应的操作员
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Role_Users(string roleID)
        {
            string sql = string.Format(@"select b.AutoUserId,b.UserId,b.userName,b.deptNum,a.RoleId,b.Memo from TRoleUsers a
	                        inner join Users b on a.AutoUserId = b.AutoUserId
	                        where RoleId ='{0}' and [State] = 1", roleID);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Users_Role(string userID)
        {
            string sql = string.Format(@"	select distinct a.RoleId,b.UserId,b.userName from TRoleUsers a 
	                                        inner join  Users b on a.AutoUserId = b.AutoUserId
	                                        where b.UserId = '{0}' and [State] = 1", userID);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 根据用户获取部门名
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string GetUserIDDeptName(string userID)
        {
            string sql = string.Format(@"select DeptName from Users where UserId = '{0}'", userID);
            return Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }

        /// <summary>
        //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）,根据Id传
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Region_ManageUserByUserId(string UserId)
        {
            string sql = string.Format(@"select UserId,userName,Memo,deptnum from  Users where [State] = 1 and UserId='{0}'", UserId);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取地区对应的管理员用户
        /// 2015-01-22修改，因林卫停用，搜索出来永远是林卫，所以加条件and c.UserId != 'linwei'
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Region_ManageUser(string ProvinceName)
        {
            string sql = string.Format(@"select distinct c.UserId,c.userName,c.Memo,c.deptnum from RegionToProvince b 
                                        inner join Users c on b.deptNum = c.deptnum and c.ismanager=1
                                        where b.ProvinceName = '{0}'  and c.[State] = 1 and c.UserId != 'linwei' ", ProvinceName);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取地区对应的管理员用户
        /// 2015-01-22修改，因林卫停用，搜索出来永远是林卫，所以加条件and UserId != 'linwei'
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Region_ManageUser(string RegionName, string ProvinceName)
        {
            string sql = string.Format(@"select distinct b.ProvinceCode,SUBSTRING(b.ProvinceCode,0,3),c.UserId,c.userName,c.Memo,c.deptnum from RegionToProvince b 
											inner join Users c on b.deptNum = c.deptnum and c.ismanager=1
											where b.ProvinceName = '{0}'  and c.[State] = 1 
											and SUBSTRING(b.ProvinceCode,0,3) = (select top 1 ProvinceCode from RegionToProvince where ProvinceName = '{1}' order by ProvinceCode) and UserId != 'linwei'", RegionName, ProvinceName);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 是否区域的管理员
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public static bool IS_SQL_Region_ManageUser(string ProvinceName,string userID)
        {
            string sql = string.Format(@"select distinct c.UserId,c.userName,c.Memo,c.deptnum,d.RoleId 
                                        from RegionToProvince b 
                                        inner join Users c on  b.deptNum like c.deptnum+'%'  and c.ismanager=1
                                        inner join TRoleUsers d on c.AutoUserId = d.AutoUserId and d.RoleId = '002'
                                        where b.ProvinceName = '{0}'  and c.[State] = 1 and c.UserId='{1}'", ProvinceName,userID);

            return Bao.DataAccess.DataAcc.ExecuteScalar(sql).Length>0;
        }

        /// <summary>
        /// 获取部门对应的科长
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_Dept_ManageUser(string deptNum)
        {
            string sql = string.Format(@"select distinct c.UserId,c.userName,c.Memo from Users c
                                        where c.deptnum = '{0}'  and c.ismanager=1 and c.[State] = 1", deptNum);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取操作员对应的上级部门,
        /// </summary>
        /// <param name="deptNum"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_UserID_ManageUser(string userID)
        {
            /*string sql = string.Format(@"select distinct d.UserId,d.userName,d.Memo  
                                        from Users c
                                        inner join Users d on (case when c.ismanager=1 and len(c.deptNum)>2 then substring(c.deptNum,1,len(c.deptNum)-2) else c.deptNum end)  = d.deptNum
                                        where c.UserId='{0}' and d.ismanager=1 and d.[State] = 1 and d.UserId != 'linwei'", userID);*/

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）

            //不需要上下级部门
            string sql = string.Format(@"select distinct d.UserId,d.userName,d.Memo  
                                        from Users c
                                        inner join Users d on c.deptNum  = d.deptNum
                                        where c.UserId='{0}' and d.ismanager=1 and d.[State] = 1 and d.UserId != 'linwei'", userID);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取操作员对应的部门领导(包括所有)
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static System.Data.DataTable Select_SQL_UserID_ManageUser_ALL(string userID)
        {
            string sql = string.Format(@"select distinct d.UserId,d.userName,d.Memo from Users c
                                        inner join Users d on c.deptNum like d.deptNum+'%'
                                         where c.UserId='{0}'  and d.ismanager=1 and d.[State] = 1", userID);

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取操作员对应的名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string GetUserName(string userID)
        {
            string sql = string.Format(@"select userName from Users c
                                         where c.UserId='{0}'", userID);

            return Bao.DataAccess.DataAcc.ExecuteScalar(sql);
        }
    }
}
