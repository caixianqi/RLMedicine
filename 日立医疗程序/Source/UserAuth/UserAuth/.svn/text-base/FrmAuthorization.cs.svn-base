using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using UFBaseLib.BusLib;
namespace Bao.UserAuth
{
    public partial class FrmAuthorization : Form
    {
        System.Data.DataTable tableAuth;
        private string _AutoUserId;
        public FrmAuthorization(string AutoUserId)
        {
            
            InitializeComponent();
            _AutoUserId = AutoUserId;
        }

       

        private void FrmAuthorization_Load(object sender, EventArgs e)
        {
            //列出所有权限
            string sql = "select 999 ParentID,FunctionId,FunctionName from tFunctions " +
                       "union all " +
                       "select functionId,authId,authName from auth ";
            tableAuth = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            tableAuth.Columns.Add("Flag", System.Type.GetType("System.Boolean"));

            foreach (System.Data.DataRow row1 in tableAuth.Rows)
            {
                row1["Flag"] = false;
            }
            //将登陆用户有的权限打上标记
            System.Data.DataTable dd = Bao.DataAccess.DataAcc.ExecuteQuery("select a.* from UserAuth a where AutoUserId='" + _AutoUserId + "'");
            foreach (System.Data.DataRow row1 in dd.Rows)
            {
                foreach (System.Data.DataRow row2 in tableAuth.Rows)
                {
                    if (row1["AuthId"].ToString() == row2["FunctionId"].ToString())
                    {
                        row2["Flag"] = true;
                        DataRow[] rs= tableAuth.Select("FunctionId='"+row2["ParentId"].ToString()+"'");
                        if (rs.Count() >0)
                        {
                            rs[0]["Flag"]=true;
                        }
                    }
                }
            }
            this.treeList1.DataSource = tableAuth;
            
           
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                
                if (hInfo.Column !=null &&  hInfo.Column.FieldName =="Flag")
                    SetCheckedNode(hInfo.Node);
            }
        }
        private void SetCheckedNode(TreeListNode node)
        {
            Boolean  check = (Boolean) node.GetValue("Flag");
            if (check == false ) check = true;
            else check = false;
            treeList1.FocusedNode = node;
            treeList1.BeginUpdate();
            node["Flag"] = check;
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
            treeList1.EndUpdate();
        }
        private void SetCheckedChildNodes(TreeListNode node, Boolean  check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i]["Flag"] = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, Boolean  check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (!check.Equals(node.ParentNode.Nodes[i]["Flag"]))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode["Flag"] = b ? true : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            foreach (System.Data.DataRow row1 in tableAuth.Rows)
            {
                if (row1["ParentId"].ToString() != "")
                {
                    
                    if ( Boolean.Parse(row1["Flag"].ToString()) == false)
                    {
                        Bao.DataAccess.DataAcc.ExecuteNotQuery("delete UserAuth where AutoUserId='" + _AutoUserId + "'");
                    }
                    else
                    {
                        Bao.DataAccess.DataAcc.ExecuteNotQuery("delete UserAuth where AutoUserId='" + _AutoUserId +
                            "' and authId='" + row1["FunctionId"].ToString() +
                            "'  insert into userAuth (autouserId,AuthId) values ('" + _AutoUserId + "','" + row1["FunctionId"].ToString() + "')");
                    }
                }
            }
        }
    }
}
