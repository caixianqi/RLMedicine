using System;

namespace WorkFlow.user
{
	/// <summary>
	/// SingleRight 的摘要说明。
	/// </summary>
	public class SingleRight
	{		
		private String functionName; //功能菜单项名称
		public String FunctionName
		{
			get
			{
				return this.functionName;
			}
			set 
			{
				this.functionName=value;
			}
		}		
		public SingleRight()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
