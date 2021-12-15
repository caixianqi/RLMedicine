using System;
using System.Collections.Generic;
using System.Text;

namespace Repair
{
    class RepairMissionBill : Bao.BillBase.BillBase
    {
        public RepairMissionBill()
        {
            //将所有的实体表增加到EntityTables成员中。
            this.EntityTables = new Bao.BillBase.EntityTable[1];
            this.EntityTables[0] = new Repair.RepairMissionMainData();
           

            //设置该单据的单号字段
            this.KeyFieldName = "RepairMissionID";
        }

        public override void AuditBefor()
        {
            
        }

        public override void AuditAfter()
        {
            
        }

        public override void UnAuditBefor()
        {
           
        }

        public override void UnAuditAfter()
        {
           
        }

        public override void NewBefor()
        {

            CheckData();
        }

        public override void NewAfter()
        {
            RiLiGlobal.RiLiDataAcc.GetConn();
            string maxcode = this.EntityTables[0].Table.Rows[0]["RepairMissionCode"].ToString();

            int num = int.Parse(maxcode.Substring(2,8));

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery("Update dbo.VoucherHistory set cnumber = "+num+" where cardnumber = '00004'");
            
        }

        public override void UpBefor()
        {
            CheckData();
        }

        public override void UpAfter()
        {
            
        }

        public override void DelBefor()
        {
            string ErrMsg = string.Empty;
            if (this.EntityTables[0].Table.Rows[0]["SubmitPersonUser"].ToString() == string.Empty)
            {

            }
            else
            {
                ErrMsg += "[已经指定工程师，要删除，请先收回]";
            }

            if (this.EntityTables[0].Table.Rows[0]["SubmitMissonUser"].ToString() == string.Empty)
            {

            }
            else
            {
                ErrMsg += "[已经分派客服经理，要删除，请先收回]";
            }

            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FaultFeedback where RepairMissionID = '" + this.BillId + "'").Rows.Count > 0)
            {
                ErrMsg += "[已经填写故障解决情况，不能删除]";
            }
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from FreeApplication where RepairMissionID = '" + this.BillId + "'").Rows.Count > 0)
            {
                ErrMsg += "[已经填写免费申请，不能删除]";
            }
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where RepairMissionID = '" + this.BillId + "'").Rows.Count > 0)
            {
                ErrMsg += "[已经填写配件申请，不能删除]";
            }
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Price where RepairMissionID = '" + this.BillId + "'").Rows.Count > 0)
            {
                ErrMsg += "[已经填写报价单，不能删除]";
            }

            if(ErrMsg == string.Empty)
            {
                return;
            }
            else
            {
                throw new Exception(ErrMsg);
            }

    
        }

        public override void DelAfter()
        {
            
        }

        public override void UpLoadBefor()
        {
            
        }

        public override void UpLoadAfter()
        {
          
        }

        public override void UpCancelBefor()
        {
           
        }

        public override void UpCancelAfter()
        {
            
        }

        public override void GetCode(Bao.BillBase.FrmBillBase Sender)
        {
            //Bao.BillBase.ICode dd;
            //dd = new Code.BillCode(this.EntityTables[0].TableName, "");
            //this.BillId = dd.GetId();
            //把最大的单号填进去
            RiLiGlobal.RiLiDataAcc.GetConn();
            string maxcode = RiLiGlobal.GetCode.GetRepCode();
            this.EntityTables[0].Table.Rows[0]["RepairMissionCode"] = maxcode;

        
        }

        public void CheckData()
       {

//维修编号					
//客户编号					
//客户名称					
//区域名称					
//维修联系人					
//联系电话	
//报修日期					
//维修性质					
//客服经理					
//受理工程师					
//主机型号
//故障描述
              System.Data.DataRow maindata = this.EntityTables[0].Table.Rows[0];

           string mesg = string.Empty;
           mesg += CheckIsNull(maindata["RepairMissionCode"],"维修编号不能为空");
           mesg += CheckIsNull(maindata["CustomerCode"], "客户编号不能为空");
           mesg += CheckIsNull(maindata["CustomerName"], "客户名称不能为空");
           mesg += CheckIsNull(maindata["ZoneName"], "区域名称不能为空");
           mesg += CheckIsNull(maindata["RepairContractPeople"], "维修联系人不能为空");
           mesg += CheckIsNull(maindata["ContractNumber"], "联系电话不能为空");
           mesg += CheckIsNull(maindata["RepairType"], "维修性质不能为空");


           mesg += CheckIsNull(maindata["MachineName"], "主机型号不能为空");
           mesg += CheckIsNull(maindata["FaultDetails"], "故障描述不能为空");

           DateTime reportRepairDate = DateTime.Parse(maindata["ReportRepartDate"].ToString());
           DateTime purdate = DateTime.Parse(maindata["PurchaseDate"].ToString());

           if (reportRepairDate < purdate)
           {
               mesg += "[报修日期不能小于购买日期]";
           }


           if (string.IsNullOrEmpty(mesg))
           {
               return;
           }
           else
           {
               throw new Exception(mesg);
           }

	

          

            


        }

        public override string ReturnCreateUserFieldName()
        {
            return string.Empty;
        }
    }
}
