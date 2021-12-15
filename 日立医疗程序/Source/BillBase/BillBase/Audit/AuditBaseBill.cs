using System;

namespace Bao.AuditFlow
{
    class AuditBaseBill : Bao.BillBase.BillBase
    {
        //public string FunctionId;
        public string JFWId;
        public AuditBaseBill()
        {
            ///此处创建该单据的所有EntityTable
            this.EntityTables = new Bao.BillBase.EntityTable[1];
            this.EntityTables[0] = new AuditBaseTable ();
            this.KeyFieldName = "BillId";

        }

        public override void NewBefor()
        {

        }

        public override void NewAfter()
        {

        }

        public override void UpBefor()
        {

        }

        public override void UpAfter()
        {

        }

        public override void DelBefor()
        {

        }

        public override void DelAfter()
        {

        }

        
        public override void SetBillState()
        {
            
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

        public override void GetCode(Bao.BillBase.FrmBillBase Sender)
        {
            
        }
    }
}
