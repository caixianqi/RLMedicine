using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class LookUpSQL : ILookUp
    {
        #region ILookUp ≥…‘±
        public string SQL = "";
        public System.Data.DataTable GetInfo()
        {
            string sql = SQL;

            return U8Global.U8DataAcc.ExecuteQuery(sql);
        }
        public System.Data.DataTable GetRiLiInfo()
        {
            string sql = SQL;

            return RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
        }
        #endregion
    }
}
