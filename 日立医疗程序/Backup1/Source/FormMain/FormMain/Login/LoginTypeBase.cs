using System;
using System.Collections.Generic;
using System.Text;

namespace FormMain
{
     abstract  class  LoginTypeBase
    {
        public abstract Boolean  Login();
        public abstract System.Data.DataSet ReadFunction();
        public abstract void Authorization(Bao.Interface.IU8Contral ctr1);

    }
}
