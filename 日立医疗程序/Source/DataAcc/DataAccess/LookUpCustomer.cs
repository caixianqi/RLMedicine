using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class LookUpCustomer:ILookUp
    {
        #region ILookUp ≥…‘±

        public System.Data.DataTable  GetInfo()
        {
             
            string sql="select ccuscode,cCusName,ccusAbbName,cCCCode,"+
                        "cCusAddress,cCusPerson,cCusPhone,cCusHand,"+
                        "cCusFax from customer ";
          
            return Bao.DataAccess.DataAcc.ExecuteQuery(sql,"Customer");
            
        }

        #endregion
    }
}
