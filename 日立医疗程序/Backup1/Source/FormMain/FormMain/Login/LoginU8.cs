using System;
using System.Collections.Generic;
using System.Text;
using UFBaseLib.BusLib;

namespace FormMain
{
    class LoginU8 : LoginTypeBase
    {
        public override void Authorization(Bao.Interface.IU8Contral ctr1)
        {
           // if (UFBaseLib.BusLib.BaseInfo.U8Login == null)
           //     throw new Exception("登陆对象为空,可能是Interop.U8Login.dll 文件存在问题");
           // else
                ((Bao.Interface.IU8Contral)ctr1).Authorization();
        }
        public override Boolean  Login()
        {
            return UFBaseLib.BusLib.Bus.Login(0, "asdfds", "", "", "", "", "", "", "", "");
            
        }
        public override System.Data.DataSet  ReadFunction()
        {
      //     System.Data.DataSet Bills=new System.Data.DataSet() ;
      ////     Bills.ReadXml(System.Windows.Forms.Application.StartupPath + "\\" + "SFDll.XML");
      //     return Bills;

            System.Data.DataSet Bills = new System.Data.DataSet();
            //string Sql = "select DISTINCT a.AutouserId,UserName,d.functionId," +
            //            "functionName,DllName,WorkName,Param,Title,TitleGroup  " +
            //            "from [Users] a,TFunctions d,UserAuth b,Auth c,TRoleUsers e " +
            //            "where  b.authId= c.authId and c.functionid=d.functionid " +
            //            " and a.AutoUserId=e.AutoUserId and e.RoleId=b.AutouserId  and d.state='1' and FunctionType='0' " +
            //            "and a.AutouserId='" + BaseInfo.UserId + "' and a.password='" + BaseInfo.Password + "'";

            //string SQL = " select DISTINCT a.cuser_id,cUser_Name,d.functionId,"+
            //            "functionName,DllName,WorkName,Param,Title,TitleGroup"+ 
            //            "FROM UFSystem..UA_User a, TFunctions d,UFSystem..UA_HoldAuth u where a.cuser_id = u.cuser_id and u.cauth_id = d."+"functionid   and d.state='1' and FunctionType='0'" +
            //            " and cuser_id = '"+BaseInfo.UserId+"' ";
            //System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(SQL);

            //Bills.Tables.Add(table1);

            return Bills;
        }
    }
}
