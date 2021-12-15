using System;
using System.Collections.Generic;
using System.Text;

namespace BillBase
{
    interface IDataModel
    {
        int aaa
        {
            get;
            set;
        }
    
        void NewBefor();
        void NewSave();
        void NewAfter();

        void UpBefor();
        void UpSave();
        void UpAfter();

        void Delete();

        void Init(string BillId);

        void AuditBefor();
        void Audit();
        void AuditAfter();

        void SetDefaultValue();
    }
}
