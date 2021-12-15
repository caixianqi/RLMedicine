using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface ILookUp2
    {
        
        System.Data.DataSet GetInfo();

    }

    public interface ILookUp
    {
        System.Data.DataTable  GetInfo();
        System.Data.DataTable GetRiLiInfo();
    }
}
