using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bao.Message
{
    public class CMessage
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgTitle">标题</param>
        /// <param name="msgBody">内容</param>
        /// <param name="DescUserId">接受者</param>
        /// <param name="SourceUserId">发送者</param>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillKeyId">单据编号</param>
        public static void SendMessage( string msgTitle, string msgBody, string UserId, string SourceUserId, string FunctionId, string BillKeyId)
        {

            string autouserid = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select autouserid from users where userid = '" + UserId + "'");

            string billcode = string.Empty;
            string hospital = string.Empty;

            SetBillCodeAndHospital(FunctionId, BillKeyId, out billcode, out hospital);

            string sql = "insert into TMessageAuto(MessageTitle,MessageBody,MessageDate,DescUserId,SourceUserId,IsBrows,BrowsDate,FunctionId,BillKeyId,BillCode,HospitalName)" +
                    " values ('" + msgTitle + "','" + msgBody + "',getdate(),'" + autouserid + "','" + SourceUserId + "','0',null,'" + FunctionId + "','" + BillKeyId + "','" + billcode + "','" + hospital + "')";
          //  Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

           

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgTitle">标题</param>
        /// <param name="msgBody">内容</param>
        /// <param name="DescRoleCode">接受者权限编码</param>
        /// <param name="DepartmentCode">接受者所在部门</param>
        /// <param name="SourceUserId">发送者</param>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillKeyId">单据编号</param>
        public static void SendMessageToRole(string msgTitle, string msgBody, string DescRoleCode,string DepartmentCode, string SourceUserId, string FunctionId, string BillKeyId)
        {

            DataTable userInfor = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("  select * from Users u, TRoleUsers t where t.autouserid = u.autouserid and t.RoleId = '" + DescRoleCode + "' and AuditGroupId = '" + DepartmentCode + "'");

            string billcode = string.Empty;
            string hospital = string.Empty;

            SetBillCodeAndHospital(FunctionId, BillKeyId, out billcode, out hospital);

            foreach (DataRow item in userInfor.Rows)
            {

                string sql = "insert into TMessageAuto(MessageTitle,MessageBody,MessageDate,DescUserId,SourceUserId,IsBrows,BrowsDate,FunctionId,BillKeyId,BillCode,HospitalName)" +
                        " values ('" + msgTitle + "','" + msgBody + "',getdate(),'" + item["autoUserId"].ToString() + "','" + SourceUserId + "','0',null,'" + FunctionId + "','" + BillKeyId + "','" + billcode + "','" + hospital + "')";
                //  Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
            }

        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgTitle">标题</param>
        /// <param name="msgBody">内容</param>
        /// <param name="DescRoleCode">接受者权限编码</param>
        /// <param name="DepartmentCode">接受者所在部门</param>
        /// <param name="SourceUserId">发送者</param>
        /// <param name="FunctionId">功能编号</param>
        /// <param name="BillKeyId">单据编号</param>
        public static string SendMessageToRoleNoDepartment(string msgTitle, string msgBody, string DescRoleCode,  string SourceUserId, string FunctionId, string BillKeyId)
        {

            DataTable userInfor = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("  select * from Users u, TRoleUsers t where t.autouserid = u.autouserid and t.RoleId = '" + DescRoleCode + "'");

            string billcode = string.Empty;
            string hospital = string.Empty;

            SetBillCodeAndHospital(FunctionId, BillKeyId, out billcode, out hospital);

            string strManager = string.Empty;
            foreach (DataRow item in userInfor.Rows)
            {

                if (strManager.Length > 0)
                    strManager += ",";
                strManager += item["userName"].ToString();
                string sql = "insert into TMessageAuto(MessageTitle,MessageBody,MessageDate,DescUserId,SourceUserId,IsBrows,BrowsDate,FunctionId,BillKeyId,BillCode,HospitalName)" +
                        " values ('" + msgTitle + "','" + msgBody + "',getdate(),'" + item["autoUserId"].ToString() + "','" + SourceUserId + "','0',null,'" + FunctionId + "','" + BillKeyId + "','" + billcode + "','" + hospital + "')";
                //  Bao.DataAccess.DataAcc.ExecuteNotQuery(sql);

                RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
            }
            return strManager;

        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="DescUserId">接收人编号</param>
        /// <param name="BeginDate">消息开始时间</param>
        /// <param name="EndDate">消息结束时间</param>
        /// <param name="IsNotReadMessage">是否未读过的消息</param>
        public static System.Data.DataTable  RecieveMessage(string DescUserId, System.DateTime BeginDate, System.DateTime EndDate, Boolean  IsNotReadMessage)
        {

            string sql = "select a.*,b.DLLName,b.WorkName,c.UserName,b.Title,b.TitleGroup,a.BillKeyId as Param,a.BillCode,a.HospitalName  " +
                " from TMessageAuto a left outer join TFunctions b on a.FunctionId=b.FunctionId "+
                "  left outer join  Users c on a.SourceUserId=c.AutoUserId  " +
                " where a.DescUserId='" + DescUserId +
                "' and MessageDate>='"+BeginDate+"' and MessageDate<='"+EndDate+"'";
            if (IsNotReadMessage)
                sql = sql + " and IsBrows='0' order by  MessageDate desc";

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

           
            return dt;
        }
        public static void SendReadedFlag(string MessageId)
        {
            string sql = "Update TMessageAuto set IsBrows='1',BrowsDate=getdate() where MessageId='" + MessageId + "' ";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
        }



        public static void SetBillCodeAndHospital(string FunctionId,string billId,out string BillCode, out string Hospital)
        {


                if (billId == string.Empty)
                {
                    BillCode = string.Empty;
                    Hospital = string.Empty;
                    return;
                }
                string repcode;
                switch (FunctionId)
                {
                    case "Bil001":
                        string PriceId = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select PriceId from bill where billId = '" + billId + "'");

                        if (PriceId == string.Empty)
                        {
                            BillCode = string.Empty;
                            Hospital = string.Empty;
                            return;
                        }
                         repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceId ='" + PriceId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Call001":
                        BillCode = billId;
                        Hospital = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select cClientName from CallBack where cTaskCode = '" + billId + "'");
                        break;
                    case "Fau001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from RepairMission r left outer join FaultFeedback f on r.RepairMissionId = f.RepairMissionId where FaultFeedbackID ='" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                      
                        break;
                    case "Fre001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from FreeApplication where FreeID = '" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Ins001":
                        repcode = billId;
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByInCode(repcode);
                        break;
                    case "Par001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from PartsApplication where PartsApplicationID = '" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Pin001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from PartsInventory where PartsInventoryID = '" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Pri001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceID = '" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Rep001":
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from RepairMission where RepairMissionID = '" + billId + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Rep005":
                        string sql = string.Format("select RMID from RepairMissionChanage where RMTypeID = '{0}'", billId);
                        DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
                        repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from RepairMission where RepairMissionID = '" + dt.Rows[0]["RMID"].ToString() + "'");
                        BillCode = repcode;
                        Hospital = RiLiGlobal.RiLiDataAcc.GetHospitalNameByReCode(repcode);
                        break;
                    case "Sell001":
                        Hospital = string.Empty;
                        BillCode = billId;
                      
                        break;
                        


                    default:
                        BillCode = string.Empty;
                        Hospital = string.Empty;
                        break;
                }
            }
        

    }
}
