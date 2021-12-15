using System;
using System.Windows.Forms;

namespace FormMain
{
	/// <summary>
	/// FormExample 的摘要说明。
	/// </summary>
	public class FormExampleData
	{
		public FormExampleData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Form _formexample;
		private string _formtitle;
		private Form _formparent;
		private FormWindowState _formstate;
		private int _x;
		private int _y;

		public Form formexample
		{
			get{return _formexample;}
			set{_formexample = value;}
		}
		public string formtitle
		{
			get{return _formtitle;}
			set{_formtitle = value;}
		}
		public Form formparent
		{
			get{return _formparent;}
			set{_formparent = value;}
		}
		public FormWindowState formstate
		{
			get{return _formstate;}
			set{_formstate = value;}
		}
		public int x
		{
			get{return _x;}
			set{_x = value;}
		}
		public int y
		{
			get{return _y;}
			set{_y = value;}
		}

		public FormExampleData(Form FormExample,string FormTitle,Form FormParent,FormWindowState FormState,int X,int Y)
		{
			_formexample=FormExample;
			_formtitle=FormTitle;
			_formparent=FormParent;
			_formstate=FormState;
			_x=X;
			_y=Y;
		}
		public void ActivateForm()
		{
			formexample.Activate();
		}
	}
}
