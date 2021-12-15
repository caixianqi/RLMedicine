using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.Report
{
    public class TableEventArge : EventArgs
    {
         private System.Data.DataSet   _dataset1;

        public System.Data.DataSet  DataSet1
        {
            get { return _dataset1; }
          
        }
        public TableEventArge(System.Data.DataSet dataset1)
        {
            _dataset1 = dataset1;
        }
      
    }
}
