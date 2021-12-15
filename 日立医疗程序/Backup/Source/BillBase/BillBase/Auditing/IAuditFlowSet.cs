using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.BillBase.Auditing
{
    public interface IAuditFlowSet
    {

        string  FuncId
        {
            get;
            set;
        }
        Boolean  IsNew
        {
            get;
            set;
        }
        Boolean IsUpdate
        {
            get;
            set;
        }
        string AuditNode
        {
            get;
            set;
        }
        string ManagerUserId
        {
            get;
            set;
        }
        int SortId
        {
            get;
            set;
        }

        void ChangeSaveStateToEnable(Boolean flag);
        
        
    }
}
