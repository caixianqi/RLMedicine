using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.ErrMessage
{
    public class ExceptionBao:Exception 
    {
        public ExceptionBao(string err, string Details)
        {
            this.MainMessage = err;
            this.DetailsMessage = Details;
        }
        public string MainMessage;
        public string DetailsMessage="";
    }
}
