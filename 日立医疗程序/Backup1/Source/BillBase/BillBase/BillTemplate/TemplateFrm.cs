using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillBase.BillTemplate
{
    public partial class TemplateFrm : Bao.BillBase.FrmBillBase, Bao.Interface.IU8Contral
    {
        public TemplateFrm()
        {
            InitializeComponent();
            ///以下语句必须写
            //this.BO = new TemplateBill();
            //BO.Init("");
            //init();
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BillId">单据编号</param>
        public TemplateFrm(string BillId)
        {
            InitializeComponent();
            ///以下语句必须写
            //this.BO = new TemplateBill();
            //BO.Init(BillId );
            //init();
          
        }
        public void Init()
        {
            //此处写该单据的初始化信息。
            //BtnEmployee.BaoSQL = "select EmpId,EmpName,b.deptName from Employee a,dept b where a.deptId=b.deptId   ";
            //BtnEmployee.BaoTitleNames = "EmpId=编号,EmpName=名称,deptName=部门";
            
        }
        /// <summary>
        /// 字段和控件绑定
        /// </summary>
        public override void BaoDataBinding()
        {
            //this.txtCreateDate.DataBindings.Add("text", BO.EntityTables[0].Table, "CreateDate");
            ////...
            //this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }
        /// <summary>
        /// 清除控件和字段的绑定
        /// </summary>
        public override void BaoUnDataBinding()
        {
            //this.txtBillId.DataBindings.Clear();
            //this.gridControl1.DataSource = null;
        }
        /// <summary>
        /// 写选择单据的SQL语句用于显示选择列表
        /// </summary>
        /// <returns>SQL语句</returns>
        public override string BaoSelectLookUpSQL()
        {
            //return "select * from KaoQin ";
            return "";
        }
        /// <summary>
        /// 选择列表的标题中文设置
        /// </summary>
        /// <returns></returns>
        public override string BaoSelectLookUpTitleName()
        {
            //return "BillId=单号,Year=年份,Month=月份,DayNum=考勤天数,SBDate=申报日期,CreateDate=建单日期,CreateuserId=建单人";
            return "";
        }
        //选择单据之前的处理
        public override void BeforSelect()
        {
            
        }
         /// <summary>
         /// 选择单据之后的处理
         /// </summary>
        public override void AfterSelect()
        {
            
        }
        /// <summary>
        ///  验证登陆用户和单据的操作员是否为一个人
        /// </summary>

        public override void LoginUserIsCreateUser()
        {
            //if (UFBaseLib.BusLib.BaseInfo.UserName.Trim() != BO.EntityTables[0].Table.Rows[0]["CreateUserId"].ToString().Trim())
            //    throw new Exception("登录人和制单人不是同一个人。");
        }
        
        #region IU8Contral 成员
        /// <summary>
        /// 权限认证
        /// </summary>
        public void Authorization()
        {
            // AuthorizationUser.AuthUser(UFBaseLib.BusLib.BaseInfo.UserId, this.FunctionId, toolBarBill1);
        }

        #endregion
    }
}
