using System;
using System.Collections.Generic;
using System.Text;

namespace FormMain
{
    class LoginNone : LoginTypeBase
    {
        public override void Authorization(Bao.Interface.IU8Contral ctr1)
        {
            
        }
        public override Boolean Login()
        {
            return UFBaseLib.BusLib.Bus.Login(1, "dddd", "U871", "BaoU8", "sa", "", "", "", "", "");

        }
        public override System.Data.DataSet ReadFunction()
        {
            System.Data.DataSet Bills = new System.Data.DataSet();
            Bills.ReadXml(System.Windows.Forms.Application.StartupPath + "\\" + "SFDll.XML");
            return Bills;
        }
    }
}
