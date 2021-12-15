using System;
using System.Collections.Generic;
using System.Text;

namespace FrmLookUp
{
    public class LookUpEventArgs:EventArgs
    {
        private System.Data.DataRow _ReturnRow1 ;
        public LookUpEventArgs(System.Data.DataRow row1)
        {
            _ReturnRow1 = row1;
        }
        public System.Data.DataRow ReturnRow1
        {
            get
            {
                return _ReturnRow1;
            }
        }
    }
}
