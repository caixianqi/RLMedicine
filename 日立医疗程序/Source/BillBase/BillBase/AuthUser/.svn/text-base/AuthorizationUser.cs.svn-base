using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BillBase.AuthUser
{
    /// <summary>
    /// 控制权限的类
    /// </summary>
    public class AuthorizationUser
    {
        //公共变量
        private static DataTable dtAuth = new DataTable();
        /// <summary>
        /// 控制表单工具栏按钮的是否显示
        /// </summary>
        /// <param name="autoUserId"></param>
        /// <param name="functionId"></param>
        /// <param name="toolBarBill"></param>
        public static void AuthUser(string autoUserId,string functionId,FrmLookUp.ToolBarBill toolBarBill) 
        {
            //获取某单据的权限列表
            string sql = @"select DISTINCT a.authId,a.AuthName from BaoSystem.dbo.auth a,BaoSystem.dbo.userAuth b, BaoSystem.dbo.TRoleUsers c 
                           where c.roleId=b.AutoUserId and b.AuthId=a.AuthId 
                           and c.AutoUserId='" + autoUserId + "' and a.functionid='" + functionId.Trim() + "'";
            dtAuth = Bao.DataAccess.DataAcc.ExecuteQuery(sql);

            //对工具条进行控制

            //选择
            //如果查询该名称，某个按钮可用
            if (IsExistAuthName("选择")) {
                toolBarBill.baoBtnSelect.Visible = true;
            }
            else {
                toolBarBill.baoBtnSelect.Visible = false;
            }
            //打印
            AuthEnable(toolBarBill.BtnPrint, "打印");            
            //增加
            AuthEnable(toolBarBill.BtnNew, "增加"); 
            //修改
            AuthEnable(toolBarBill.BtnUpdate, "修改"); 
            //保存
            AuthEnable(toolBarBill.BtnSave, "保存"); 
            //提交
            AuthEnable(toolBarBill.BtnUpLoad, "提交");
            //收回
            AuthEnable(toolBarBill.BtnUpCancel,"收回");
            //删除
            AuthEnable(toolBarBill.BtnDelete, "删除");
            //审核
            AuthEnable(toolBarBill.BtnAudit, "审核");
            //反审核
            AuthEnable(toolBarBill.BtnUnAudit,"弃审");   
            //导出Excel
            AuthEnable(toolBarBill.BtnExcel, "BtnExcel");
            
        }        

        /// <summary>
        /// 实现某个按钮是否可用
        /// </summary>
        /// <param name="btn">按钮</param>
        /// <param name="btnName">名称</param>
        /// <returns></returns>
        public static void AuthEnable(System.Windows.Forms.Button btn, string btnName)
        {
            //如果查询该名称，某个按钮可用
            if ((IsExistAuthName(btnName.Trim()))) {
                btn.Visible = true;
            }
            else {
                btn.Visible = false;
            }
        }
        

        #region 查询是否存在
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="dtAuth">数据表</param>
        /// <param name="authName">授权限名</param>
        /// <returns></returns>
        public static bool IsExistAuthName(string authName)
        {
            foreach (DataRow row in dtAuth.Rows) {
                if (row["AuthName"].ToString() == authName) {
                    return true;                   
                }
            }
            return false;
        }
        #endregion
        
    }
}
