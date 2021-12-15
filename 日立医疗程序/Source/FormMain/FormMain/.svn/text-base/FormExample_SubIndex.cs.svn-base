using System;
using System.Windows.Forms;
using System.Collections;

namespace FormMain
{
	/// <summary>
	/// FormExample_SubIndex 的摘要说明。
	/// </summary>
	public class FormExample_SubIndex
	{
		public FormExample_SubIndex()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		ArrayList SubFormArray = new ArrayList();

		public int SubCount
		{
			get{return SubFormArray.Count;}
		}

		public FormExampleData this [ int index ]
		{
			get
			{
				if (( index >= 0 )&&( index < SubFormArray.Count))
					return ((FormExampleData)SubFormArray[index]);
				else 
					throw new ArgumentOutOfRangeException("索引值溢出.");
			}
		}

		/// <summary>
		/// 查找   根据父窗体实例查找子窗体索引
		/// </summary>
		/// <param name="FormParent">父窗体实例</param>
		/// <returns>返回三级窗体索引</returns>
		public int FindSubForm(Form FormParent)
		{
			int found = -1;			
			for (int i =0; i < SubFormArray.Count; i++)
			{				
				if (this[i].formparent == FormParent)
				{
					found = i;
					break;
				}
			}
			return found;
		}

		/// <summary>
		/// 查找   根据窗体实例查找索引
		/// </summary>
		/// <param name="FormParent">自身实例</param>
		/// <returns>返回索引</returns>
		public int FindForm_Sub(Form FormExample)
		{
			int found = -1;			
			for (int i =0; i <  SubFormArray.Count; i++)
			{				
				if (this[i].formexample == FormExample)
				{
					found = i;
					break;
				}
			}
			return found;
		}

		/// <summary>
		/// 往三级窗体集合中添加窗体
		/// </summary>
		/// <param name="FormExample">窗体实例</param>
		/// <param name="FormParent">父窗体实例</param>
		/// <param name="X">显示位置</param>
		/// <param name="Y">显示位置</param>
		public void AddSubForm(Form FormExample,Form FormParent,int X,int Y)
		{			
			SubFormArray.Add(new FormExampleData(FormExample,FormExample.Text,FormParent,FormExample.WindowState,X,Y));
		}

		/// <summary>
		/// 删除三级窗体
		/// </summary>
		/// <param name="FormParent">父窗体实例</param>
		public void RemoveSubForm(Form FormParent)
		{
			int index = FindSubForm(FormParent);
			if ( index != -1)
			{
				//关闭三级窗体				
				this[index].formexample.Close();
				//将三级窗体从集合中移出
				SubFormArray.RemoveAt(index);				
			}
		}

		/// <summary>
		/// 修改窗体显示位置
		/// </summary>
		/// <param name="FormExample">自身实例</param>
		/// <param name="x">X显示位置</param>
		/// <param name="y">Y显示位置</param>
		public void EditShowLocation(Form FormExample,int x,int y)
		{
			int index = FindForm_Sub(FormExample);
			if (index != -1)
			{				
				this[index].x = x;
				this[index].y = y;
			}
		}

		/// <summary>
		/// 移除窗体   将三级窗体从二级窗体中移出
		/// </summary>
		/// <param name="FormParent">父窗体实例<</param>
		public void MoveOutSubForm(Form FormParent)
		{
			int index = FindSubForm(FormParent);
			if ( index != -1)
			{				
				FormParent.RemoveOwnedForm(this[index].formexample);
			}
		}

		/// <summary>
		/// 加载窗体   将三级窗体添加到二级窗体中
		/// </summary>
		/// <param name="FormParent">父窗体实例</param>
		public void MoveInSubForm(Form FormParent)
		{			
			int index = FindSubForm(FormParent);
			if ( index != -1)
			{				
				FormParent.AddOwnedForm(this[index].formexample);
				this[index].formexample.Opacity = 1;
				//this[index].formexample.Show();

				//this[index].formexample.Visible = true;
				//this[index].formexample.WindowState = FormWindowState.Maximized;
			}
		}
	}
}
