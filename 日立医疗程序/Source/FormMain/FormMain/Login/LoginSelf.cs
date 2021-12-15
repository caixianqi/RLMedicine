using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UFBaseLib.BusLib;
namespace FormMain
{
    class LoginSelf : LoginTypeBase
    {
        public override void Authorization(Bao.Interface.IU8Contral ctr1)
        {
                ((Bao.Interface.IU8Contral)ctr1).Authorization();
        }
        public override Boolean Login()
        {
            FrmLogin login = new FrmLogin();
            login.ShowDialog();
            if (FrmLogin.LoginState == 1)
            {
                login.Visible = false;
                return true;
            }
            else if (FrmLogin.LoginState == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public override System.Data.DataSet ReadFunction()
        {
            System.Data.DataSet Bills = new System.Data.DataSet();
            string Sql = "select DISTINCT a.AutouserId,UserName,d.functionId," +
                        "functionName,DllName,WorkName,Param,Title,TitleGroup,GroupSort,NodeSort  " +
                        "from [Users] a,TFunctions d,UserAuth b,Auth c,TRoleUsers e " +
                        "where  b.authId= c.authId and c.functionid=d.functionid "+
                        " and a.AutoUserId=e.AutoUserId and e.RoleId=b.AutouserId  and d.state='1' and FunctionType='0' " +
                        "and a.AutouserId='" + BaseInfo.UserId + "' and a.password='" + BaseInfo.Password + "' order by GroupSort,NodeSort";
            System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(Sql);
           
            Bills.Tables.Add(table1);
            
            return Bills;
        }
    }
}
