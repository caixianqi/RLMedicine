using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class LookUpCustomer:ILookUp
    {
        #region ILookUp ??Ա

        public System.Data.DataTable  GetInfo()
        {
             
            string sql="select ccuscode,cCusName,ccusAbbName,cCCCode,"+
                        "cCusAddress,cCusPerson,cCusPhone,cCusHand,"+
                        "cCusFax from customer ";

            return U8Global.U8DataAcc.ExecuteQuery(sql, "Customer");
            
        }

        #endregion

        #region ILookUp ??Ա


        public System.Data.DataTable GetRiLiInfo()
        {
            return null;
        }

        #endregion
    }
}
