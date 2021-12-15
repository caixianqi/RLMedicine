using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class PrdType
    {

        public System.Data.DataTable GetInfo()
        {
            string sql="Select [InventoryClass_InventoryClass].[cInvCCode],[InventoryClass_InventoryClass].[cInvCName]"+
                            "FROM [InventoryClass] AS [InventoryClass_InventoryClass] "+
                            "order by cInvCCode ASC ";
           return  Bao.DataAccess.DataAcc.ExecuteQuery(sql,"PrdType");
           
        }
    }
}
