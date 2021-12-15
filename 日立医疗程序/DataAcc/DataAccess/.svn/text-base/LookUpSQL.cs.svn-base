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

            return Bao.DataAccess.DataAcc.ExecuteQuery(sql);
        }

        #endregion
    }
}
