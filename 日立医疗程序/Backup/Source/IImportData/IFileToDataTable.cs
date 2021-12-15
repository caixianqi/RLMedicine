using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.Analysis
{
    public interface IFileToDataTable
    {
        System.Data.DataTable   ReadFileToDataTable(Bao.ErrMessage.IdelegateError mErr);
    }
}
