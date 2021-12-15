using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillBase.BillTemplate
{
    class TemplateBill:Bao.BillBase.BillBase 
    {
        public TemplateBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            //this.EntityTables = new Bao.BillBase.EntityTable[2];
            //this.EntityTables[0] = new EntityTableMain();
            // this.EntityTables[1] = new EntityTableItem();

            //设置该单据的单号字段
            //this.KeyFieldName = "BillId";
        }

        #region 时间前后的处理
        /// <summary>
        /// //审核前方法    不是必须的
        /// </summary>
        public override void AuditBefor()
        {
            
        }
        /// <summary>
        ///  //审核后方法   不是必须的
        /// </summary>
        public override void AuditAfter()
        {
          
        }
        /// <summary>
        /// //弃审前方法    不是必须的
        /// </summary>
        public override void UnAuditBefor()
        {
            
        }
        /// <summary>
        /// //弃审后方法   不是必须的
        /// </summary>
        public override void UnAuditAfter()
        {
           
        }
        /// <summary>
        /// //增加前方法   不是必须的
        /// </summary>
        public override void NewBefor()
        {
            
        }
        /// <summary>
        /// //增加后方法   不是必须的
        /// </summary>
        public override void NewAfter()
        {
            
        }
        /// <summary>
        ///  //修改前方法   不是必须的
        /// </summary>
        public override void UpBefor()
        {
           
        }
        /// <summary>
        ///  //修改后方法   不是必须的
        /// </summary>
        public override void UpAfter()
        {
           
        }
        /// <summary>
        ///  //删除前方法   不是必须的
        /// </summary>
        public override void DelBefor()
        {
           
        }
        /// <summary>
        ///  //删除后方法   不是必须的
        /// </summary>
        public override void DelAfter()
        {
           
        }
        /// <summary>
        /// //提交前方法   不是必须的
        /// </summary>
        public override void UpLoadBefor()
        {
            
        }
        /// <summary>
        /// //提交后方法   不是必须的
        /// </summary>
        public override void UpLoadAfter()
        {
            
        }
        /// <summary>
        /// //收回前方法   不是必须的
        /// </summary>
        public override void UpCancelBefor()
        {
             
        }
        /// <summary>
        /// //收回后方法   不是必须的
        /// </summary>
        public override void UpCancelAfter()
        {

        }
        #endregion
        /// <summary>
        /// //获得单号  必需重载
        /// </summary>
        /// <param name="Sender">窗体对象</param>
        public override void GetCode(Bao.BillBase.FrmBillBase Sender)
        {
            //Bao.BillBase.ICode dd;
            //dd = new Code.BillCode(this.EntityTables[0].TableName, "");
            //this.BillId = dd.GetId();
        }
        /// <summary>
        /// 得到简单人编号
        /// </summary>
        /// <returns></returns>
        public override string ReturnCreateUserFieldName()
        {    //返回用户编号
            //return this.EntityTables[0].Table.Rows[0]["CreateUserName"].ToString().Trim();
            return "";
        }
    }
}
