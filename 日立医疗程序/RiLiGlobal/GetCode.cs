using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RiLiGlobal
{
    public class GetCode
    {
        /// <summary>
        /// 获取安装任务编号
        /// </summary>
        public static string GetInsCode()//获取安装编号
        {
            string sql = "select * from VoucherHistory where CardNumber='00001' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            //scode = "MU"+scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            //主机安装单：以MH 开头（注：原为MU开头） + 流水号（后台可设从哪个流水号开始）
            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;
        }
        public static void SetInsCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00001' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string updatesql = "update VoucherHistory set cNumber='" + intccode + "' where CardNumber='00001'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(updatesql);
        }
        /// <summary>
        /// 获取配件安装编号
        /// </summary>
        public static string GetOPCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00002' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            
            //scode = "OP" + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            //配件安装单：以MO开头（注：原为OP开头） + 流水号 （后台可设从哪个流水号开始）
            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;
        }
        public static void SetOPCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00002' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string updatesql = "update VoucherHistory set cNumber='" + intccode + "' where CardNumber='00002'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(updatesql);
        }
        /// <summary>
        /// 获取回访任务编号
        /// </summary>
        public static string GetCallCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00003' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;
        }
        public static void SetCallCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00003' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string updatesql = "update VoucherHistory set cNumber='" + intccode + "' where CardNumber='00003'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(updatesql);

        }
        /// <summary>
        /// 获取维修任务编号
        /// </summary>
        public static string GetRepCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00004' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            //scode = "RE" + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            //维修单：以FH开头（注：原为RE开头） + 流水号 （后台可设从哪个流水号开始）
            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;
        }
        public static string GetAccCode()
        {
            return "ss";
        }
        public static string GetPriceCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00006' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            //scode = "PR" + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            //报价申请：以BR开头（注：原为PR开头） + 流水号 （后台可设从哪个流水号开始）

            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;
        }
        public static string GetInvCode()
        {
            return "ss";
        }
        /// <summary>
        /// 获取配件申请编号
        /// </summary>
        public static string GetParCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00005' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            //scode = "PA" + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            //配件申请：以PH开头（注：原为PA开头） + 流水号 （后台可设从哪个流水号开始）

            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            return scode;
        }
        /// <summary>
        /// 获取销售支持任务编号
        /// </summary>
        public static string GetSupCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00008' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string scode = "00000000";
            //scode = "SU" + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();

            scode = dt.Rows[0]["cCodeHeader"].ToString().Trim() + scode.Substring(0, (8 - intccode.ToString().Length)) + intccode.ToString();
            return scode;

        }
        public static void SetSupCode()
        {
            string sql = "select * from VoucherHistory where CardNumber='00008' ";
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);//获得单据编号
            int intccode = Convert.ToInt32(dt.Rows[0]["cNumber"].ToString()) + 1;
            string updatesql = "update VoucherHistory set cNumber='" + intccode + "' where CardNumber='00008'";
            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(updatesql);

        }
    }
}
