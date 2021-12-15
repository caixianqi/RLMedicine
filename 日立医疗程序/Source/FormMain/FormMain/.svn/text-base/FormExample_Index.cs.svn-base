using System;
using System.Windows.Forms;
using System.Collections;


namespace FormMain
{
	/// <summary>
	/// FormExample_Index 的摘要说明。
	/// </summary>
	public class FormExample_Index
	{
		public FormExample_Index()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public FormExample_SubIndex SubFormArray = new FormExample_SubIndex();
		public static ArrayList FormArray = new ArrayList();
		
		public  void MoveForm(string FormTitle)
		{
			int index=FindForm(FormTitle.Trim());
			if (index!=-1)
			{
				FormArray.RemoveAt(index);
			}
		}
		public int Count
		{
			get{return FormArray.Count;}
		}

		public FormExampleData this [ int index ]
		{
			get
			{
				if (( index >= 0 )&&( index < FormArray.Count))
					return ((FormExampleData)FormArray[index]);
				else 
					throw new ArgumentOutOfRangeException("索引值溢出.");
			}
		}

		/// <summary>
		/// 查找    根据标题查找窗体索引
		/// </summary>
		/// <param name="FormTitle">窗体标题</param>
		/// <returns>索引</returns>
		public  int FindForm(string FormTitle)
		{
			int found = -1;			
			for (int i =0; i < this.Count; i++)
			{				
				if (this[i].formtitle.Trim() == FormTitle.Trim())
				{
					found = i;
					break;
				}
			}
			return found;
		}

		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="FormExample"></param>
		/// <param name="X"></param>
		/// <param name="Y"></param>
		public void AddForm(Form FormExample,int X,int Y)
		{			
			FormArray.Add(new FormExampleData(FormExample,FormExample.Text,FormExample.MdiParent,FormExample.WindowState,X,Y));
		}

		public void UnShowForm()
		{
			for(int i=0; i < this.Count; i++)
			{				
				//(this[i].formexample).Opacity  = 0;
				//(this[i].formexample).Visible  = false;
				this[i].formexample.WindowState = FormWindowState.Minimized;
				//(this[i].formexample).WindowState = FormWindowState.Minimized;
				//移出三级窗体
				SubFormArray.MoveOutSubForm(this[i].formexample);				
			}
		}
		public void ActivateForm(int index)
		{
			this[index].ActivateForm();
		}
		/// <summary>
		/// 显示指定标题的窗口
		/// </summary>
		/// <param name="FormTitle">窗口标题</param>
		public void ShowForm(string FormTitle)
		{						
			if (FormTitle == "主界面")
			{
				UnShowForm();
				return ;
			}
			int index = FindForm(FormTitle);
			if ( index != -1)
			{
				//UnShowForm();				
				//(this[index].formexample).Visible = true;
				//this[index].formexample.WindowState = FormWindowState.Maximized;
				//(this[index].formexample).Opacity = 1;
				//(this[index].formexample).WindowState = fdata.formstate;
				//添加三级窗体
				SubFormArray.MoveInSubForm(this[index].formexample);
				//(this[index].formexample).Opacity = 0;
			}
		}

		/// <summary>
		/// 填充列表框   
		/// </summary>
		/// <param name="combobox">源combobox对像</param>
		/// <param name="Form_Index">二级窗体集合</param>
		public void GetAllForm(ComboBox combobox)  //,FormExample_Index Form_Index
		{
			combobox.Items.Clear();
			combobox.Items.Add("主界面");
			for(int i=0; i < this.Count; i++)  //Form_Index.Count
			{
				combobox.Items.Add(this[i].formtitle);
				//combobox.Items.Add(Form_Index[i].formtitle);
			}
		}

	}
}
