using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Services;

namespace Bao.Attribute
{
    abstract public class ProxyBase : RealProxy
    {
        protected MarshalByRefObject _target = null;
        string MethodName;
        public ProxyBase(Type type, MarshalByRefObject target, string methodName)
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
                
                if (MethodName.IndexOf(call.MethodName) >= 0)
                {
                    back = ExecMessage(call);
                    
                }
                else
                {
                    back = RemotingServices.ExecuteMessage(_target, call);
                }
            }

            return back;

        }
        public abstract IMethodReturnMessage ExecMessage(IMethodCallMessage call);
   
    }
}
