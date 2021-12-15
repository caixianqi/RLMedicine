using System;

namespace FormMain
{
	/// <summary>
	/// 该类用于在实体类的属性的set{}中验证value的值
	/// </summary>
	/// 

	public class EntityValidator
	{
		public EntityValidator()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//检查字符串
		public  static void CheckString(string valClassName,string valAttributeName,string valSetValue,bool valIsRemandNotEmpty,int valCheckMaxLength)
		{
			//检查传入的参数
             EntityValidator.CheckClassAndAttributeHint(valClassName,valAttributeName);
			if(valCheckMaxLength<=0)
				throw new ArgumentOutOfRangeException("valCheckMaxLength  ",valCheckMaxLength,"参数要求是大于零的整数  ");
            //按要求对valSetValue执行验证
			if(valIsRemandNotEmpty)
			{
				if(valSetValue==string.Empty)
					throw new ArgumentOutOfRangeException(valClassName+"的"+valAttributeName+"属性  ",string.Empty,"该属性必须是非空字符串  ");
			}
			if(valSetValue.Length>valCheckMaxLength)
      			throw new ArgumentOutOfRangeException(valClassName+"的"+valAttributeName+"属性  ",string.Empty,"该字符串属性的长度不可以超过"+valCheckMaxLength.ToString()+"位  ");
		}

		//检查整数
		public static void CheckInteger(string valClassName,string valAttributeName,int valSetValue,bool valIsRemandPlus,int valCheckMaxLength)
		{
			//检查传入的参数
            EntityValidator.CheckClassAndAttributeHint(valClassName,valAttributeName);
			if(valCheckMaxLength<=0)
				throw new ArgumentOutOfRangeException("valCheckMaxLength  ",valCheckMaxLength,"参数要求是大于零的整数  ");
			//按要求对valSetValue执行验证
			if(valIsRemandPlus)
			{
				if(valSetValue<=0)
					throw new ArgumentOutOfRangeException(valClassName+"的"+valAttributeName+"属性  ",valSetValue,"该属性必须是非空字符串  ");
			}
			if(valSetValue.ToString().Length>valCheckMaxLength)
				throw new ArgumentOutOfRangeException(valClassName+"的"+valAttributeName+"属性  ",valSetValue,"该整型属性的长度不可以超过"+valCheckMaxLength.ToString()+"位  ");
		}

		//检查实数类型
		public static void CheckFloat()
		{
		}

		//检查日期类型
		public static void CheckDate()
		{
		}

		//检查高精度数值类型
		public static void CheckDecimal()
		{
		}

		//检查对象
		public static void CheckObjectNotNull(string valClassName,string valAttributeName,object valSetValue)
		{
			//检查传入的参数
			 EntityValidator.CheckClassAndAttributeHint(valClassName,valAttributeName);
			//按要求对valSetValue执行验证
			if(valSetValue==null)
                throw new ArgumentOutOfRangeException(valClassName+"的"+valAttributeName+"属性  ",null,"该属性必须是非空的对象类型  ");
		}


		//私有方法
		private static void CheckClassAndAttributeHint(string valClassName,string valAttributeName)
		{
			if((valClassName==string.Empty)||(valAttributeName==string.Empty))
				throw new ArgumentOutOfRangeException("valClassName,valAttributeName  ","参数要求是不为空的字符串  ");
		}

	}//class
}//namespace
