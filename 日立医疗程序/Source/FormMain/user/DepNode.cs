using System;

namespace WorkFlow.user
{
	/// <summary>
	/// DepNode 的摘要说明。
	/// </summary>
	public class DepNode:System.Windows.Forms.TreeNode
	{
		private long depid;  //部门编号
		private string depcode;//部门编码

		public DepNode(string depname,long depid,int imageIndex)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.Text = depname; 
			this.depid = depid;
			this.ImageIndex = imageIndex;
		}
		public DepNode(string depname,string depcode,int imageIndex)
		{
			this.Text = depname;
			this.depcode = depcode;
			this.ImageIndex = imageIndex;
		}
		public long getDepID()
		{
			return this.depid;
		}
		public string getDepCode()
		{
			return this.depcode;
		}
	}
}
