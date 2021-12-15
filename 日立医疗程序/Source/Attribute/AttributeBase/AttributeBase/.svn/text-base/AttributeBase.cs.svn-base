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
    //从ProxyAttribute继承，自动实现RealProxy植入
    [AttributeUsage(AttributeTargets.Class)]
    public abstract   class AttributeBase : ProxyAttribute
    {
        private string MethodName;
        //private string ProxyClassName;
        public AttributeBase(string methodName)
        {
            MethodName = methodName;
           // ProxyClassName = proxyClassName;
        }
        //覆写CreateInstance函数，返回我们自建的代理
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            
            MarshalByRefObject obj = base.CreateInstance(serverType);
            //object[] args= new object[3];
            //args[0]=serverType;
            //args[1]= obj;
            //args[2]=MethodName;
            //Type t = Type.GetType(ProxyClassName);
            //ProxyBase proxy = (ProxyBase)Activator.CreateInstance(t, args);
            ProxyBase proxy = CreateProxy(serverType, obj, MethodName);
            return (MarshalByRefObject)proxy.GetTransparentProxy();
        }
        protected abstract ProxyBase CreateProxy(Type serverType, MarshalByRefObject obj, string MethodName);
        
       

    }
}
