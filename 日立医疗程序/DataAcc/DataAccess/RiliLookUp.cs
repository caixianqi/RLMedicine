using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class RiliLookUp : ILookUp
    {
        public string SQL = "";
        #region ILookUp 成员

        public System.Data.DataTable GetInfo()
        {
            string sql = SQL;

            return RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
        }

        #endregion

        #region ILookUp 成员


        public System.Data.DataTable GetRiLiInfo()
        {
            return null;
        }

        #endregion
    }
}
