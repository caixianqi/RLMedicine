using System;
using System.Collections.Generic;
using System.Text;

namespace Bao.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    class AttributeTransaction : AttributeBase
    {
        public AttributeTransaction(string methodName)
            : base(methodName)
        {

        }
        /// <summary>
        /// 创建具体代理的实例
        /// </summary>
        /// <param name="serverType"></param>
        /// <param name="obj"></param>
        /// <param name="MethodName"></param>
        /// <returns></returns>
        protected override ProxyBase CreateProxy(Type serverType, MarshalByRefObject obj, string MethodName)
        {
            return new ProxyTransaction(serverType, obj, MethodName);
        }
    }
}
