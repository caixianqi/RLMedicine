using System;
using System.Collections.Generic;
using System.Text;

namespace FrmLookUp
{
    public class BillUpDateStateEventArgs : EventArgs   
    {
        private Boolean _State;

        public Boolean Is_Update
        {
            get { return _State; }
        }
        public BillUpDateStateEventArgs(Boolean mState)
        {
            _State = mState;
        }
        
    }
}
