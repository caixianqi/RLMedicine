using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RiLiGlobal
{
    public class  RegionHelper
    {

        /// <summary>
        /// 获取当前用户的负责区域列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static DataTable GetUserRegionList(string userid)
        {
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RegionToUser rt left outer join Region r on r.RegionId = rt.RegionId where UserId = '"+userid+"'");
        }

        /// <summary>
        /// 获取当前用户的不负责区域列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static DataTable GetUserNotRegionList(string userid)
        {
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Region where RegionId not in (select RegionId from RegionToUser where UserId = '"+userid+"')");
        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegionList()
        {
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from Region");
        }


        /// <summary>
        /// 增加负责区域
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userid"></param>
        public static void SetRegionForUser(string regionID, string userid)
        {
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("insert into RegionToUser ([RelationId] ,[UserId] ,[RegionId]) Values (newid(),'" + userid + "','" + regionID + "') ");
        }


        /// <summary>
        /// 去除负责区域
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userid"></param>
        public static void DelRegionForUser(string regionID, string userid)
        {
            RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("delete RegionToUser where UserId ='" + userid + "' and RegionId ='" + regionID + "'");
        }

        /// <summary>
        /// 根据用户ID，获取省份Id列表，形式为 'xxx','xxx'
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetProvinceIdListByUserForSQL(string userid)
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RegionToProvince rp where rp.RegionId in (select RegionId from [RegionToUser] rt where rt.UserId = '" + userid + "')");

            string ProIdList = string.Empty;

            foreach (DataRow item in dt.Rows)
            {
                ProIdList += "'" + item["ProvinceCode"].ToString() + "',";
            }
            if (ProIdList == string.Empty)
            {
                throw new Exception("当前用户，未指定负责大区，请检查");
            }
            else
            {
                return ProIdList.Substring(0,ProIdList.Length-1);
            }

        }


        /// <summary>
        /// 根据省份编码，获取大区名称
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        public static string GetRegionNamebyProvinceCode(string provinceCode)
        {
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("  select r.RegionName from RegionToProvince rp left outer join Region r on r.RegionId = rp.RegionId  where  ProvinceCode  = '"+provinceCode+"'");
        }



        /// <summary>
        /// 根据大区，获取当前大区的实际维修人
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns></returns>
        public static DataTable GetRepairPersonByRegionName(string RegionName)
        {
           

            string sql = string.Empty;

            sql = "select distinct ActualRepairPersonName from FaultFeedbackDetails fd left outer join FaultFeedback f on f.FaultFeedbackID = fd.FaultFeedBackID where f.RepairMissionID in (select RepairMissionID from RepairMission where ZoneCode in (" + GetProvinceIdListByRegionForSQL(RegionName) + "))";

            return RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);
        }

        /// <summary>
        /// 根据大区，获取当前大区的实际维修人
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns></returns>
        public static IList<string> GetRepairPersonListByRegionName(string RegionName)
        {
            string sql = string.Empty;

            IList<string> PnameList = new List<string>();

            sql = "select distinct ActualRepairPersonName from FaultFeedbackDetails fd left outer join FaultFeedback f on f.FaultFeedbackID = fd.FaultFeedBackID where f.RepairMissionID in (select RepairMissionID from RepairMission where ZoneCode in (" + GetProvinceIdListByRegionForSQL(RegionName) + "))";

            DataTable dt =  RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);


            foreach (DataRow item in dt.Rows)
            {
                if (item["ActualRepairPersonName"].ToString() == string.Empty)
                    continue;
                else
                PnameList.Add(RegionName+item["ActualRepairPersonName"].ToString());
            }


            return PnameList;
        }


        /// 根据大区，获取当前大区的实际安装人
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns></returns>
        public static IList<string> GetInstallPersonListByRegionName(string RegionName)
        {
            string sql = string.Empty;

            IList<string> PnameList = new List<string>();

            sql = "select distinct rInsName from InsDetail IND left outer join InstallTask INS on IND.rTaskCode = INS.tInsCode where INS.tRegCode in (" + GetProvinceIdListByRegionForSQL(RegionName) + ")";

            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery(sql);


            foreach (DataRow item in dt.Rows)
            {
                if (item["rInsName"].ToString() == string.Empty)
                    continue;
                else
                    PnameList.Add(RegionName + item["rInsName"].ToString());
            }


            return PnameList;
        }


        /// <summary>
        /// 根据大区名称，获取省份Id列表，形式为 'xxx','xxx'
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetProvinceIdListByRegionForSQL(string regionName)
        {
            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from RegionToProvince rp left outer join Region r on r.RegionId = rp.RegionId where r.RegionName = '"+regionName+"'");

            string ProIdList = string.Empty;

            foreach (DataRow item in dt.Rows)
            {
                ProIdList += "'" + item["ProvinceCode"].ToString() + "',";
            }
            if (ProIdList == string.Empty)
            {
                throw new Exception("大区"+regionName+"没有下属省份");
            }
            else
            {
                return ProIdList.Substring(0, ProIdList.Length - 1);
            }

        }

    }
}
