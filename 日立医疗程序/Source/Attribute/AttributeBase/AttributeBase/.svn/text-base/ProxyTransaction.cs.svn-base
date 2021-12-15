using System;
using System.Collections.Generic;
using System.Text;
using Bao.DataAccess;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Services;
using System.Data.SqlClient;
namespace Bao.Attribute
{
     class ProxyTransaction:ProxyBase
    {
         public ProxyTransaction(Type type, MarshalByRefObject target, string methodName)
            : base(type,target,methodName)
        {
        }
         public override IMethodReturnMessage ExecMessage(IMethodCallMessage call)
        {
            IMethodReturnMessage back = null;
            SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
            DataAcc.UpLoadCmd.Transaction = sqlTran;
            try
            {
                back= RemotingServices.ExecuteMessage(_target, call);

                sqlTran.Commit();

            }
            catch (Exception e)
            {

                sqlTran.Rollback();
                throw new Exception(e.Message);
            }
            return back;
        }
    }
}
