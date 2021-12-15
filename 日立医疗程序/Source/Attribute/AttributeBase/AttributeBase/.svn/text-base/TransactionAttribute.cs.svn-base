using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Services;
using System.Diagnostics;
using System.Collections.Generic;
using Bao.DataAccess;
using System.Data.SqlClient;

namespace Bao.Attribute
{
     class MyProxy1 : RealProxy
    {
         MarshalByRefObject _target = null;
        string MethodName;
        public MyProxy1(Type type, MarshalByRefObject target,string methodName)
            : base(type)
        {
            MethodName = methodName;
            this._target = target;
        }

        //覆写Invoke，处理RealProxy截获的各种消息,
        //此种方式最简捷，但不能截获远程对象的激活,好在我们并不是真的要Remoting
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage call = (IMethodCallMessage)msg;
            IConstructionCallMessage ctr = call as IConstructionCallMessage;

            IMethodReturnMessage back = null;

            //构造函数，只有ContextBoundObject(Inherit from MarshalByRefObject)对象才能截获构造函数
            if (ctr != null)
            {
                Console.WriteLine("调用" + ctr.ActivationType.Name + "类型的构造函数");

                RealProxy defaultProxy = RemotingServices.GetRealProxy(_target);

                //如果不做下面这一步，_target还是一个没有直正实例化被代理对象的透明代理，
                //这样的话，会导致没有直正构建对象。
                defaultProxy.InitializeServerObject(ctr);

                //本类是一个RealProxy，它可通过GetTransparentProxy函数得到透明代理
                back = EnterpriseServicesHelper.CreateConstructionReturnMessage(ctr, (MarshalByRefObject)GetTransparentProxy());
            }
            //MarshalByRefObject对象就可截获普通的调用消息，
            //MarshalByRefObject对象告诉编译器，不能将其内部简单的成员函数优化成内联代码，
            //这样才能保证函数调用都能截获。
            else
            {
                //Console.Write("调用成员函数:" + call.MethodName);
                
                //back = RemotingServices.ExecuteMessage(_target, call);

                //Console.WriteLine(",返回结果为:" + back.ReturnValue.ToString());
                if (MethodName.IndexOf(call.MethodName) >= 0)
                {
                    SqlTransaction sqlTran = Bao.DataAccess.DataAcc.MainConn.BeginTransaction();
                    DataAcc.UpLoadCmd.Transaction = sqlTran;
                    try
                    {
                        back = RemotingServices.ExecuteMessage(_target, call);

                        sqlTran.Commit();

                    }
                    catch (Exception e)
                    {
                        sqlTran.Rollback();

                        throw new Exception(e.Message);
                    }
                    
                }
                else
                {
                    back = RemotingServices.ExecuteMessage(_target, call);
                }
            }

            return back;

        }
    }
}

namespace Bao.Attribute
{
    //从ProxyAttribute继承，自动实现RealProxy植入
    [AttributeUsage(AttributeTargets.Class )]
   public class TransationAttribute1 : ProxyAttribute
    {
        private string MethodName;
        public TransationAttribute1(string methodName)
        {
            MethodName = methodName;
        }
        //覆写CreateInstance函数，返回我们自建的代理
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            MarshalByRefObject obj = base.CreateInstance(serverType);
            MyProxy1 proxy = new MyProxy1(serverType, obj,MethodName);
            return (MarshalByRefObject)proxy.GetTransparentProxy();
        }

    }
}



namespace DotNetAOP.UsingRealProxy
{
    //[Bao.Attribute.TransationAttribute1("Add")]
    [Bao.Attribute.AttributeTransaction ( "Add")]
    class MyCBO : ContextBoundObject
    {
        public MyCBO()
        {
            System.Diagnostics.Debug.WriteLine("ddd");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetAOP.UsingRealProxy.MyCBO cbo = new DotNetAOP.UsingRealProxy.MyCBO();

            int i = cbo.Add(1, 2);
            Console.WriteLine("值:" + i.ToString());
            i = cbo.Divide(6, 3);
            Console.WriteLine("值:" + i.ToString());

            Console.ReadLine();


        }

    }

}