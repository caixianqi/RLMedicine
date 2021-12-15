using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase.Auditing
{
    public partial class FrmAuditGroup : Bao.BillBase.LookUpBasis, Bao.BillBase.IChildForm 
    {
        public FrmAuditGroup()
        {
            InitializeComponent();
        }



        #region IChildForm 成员

        DataTable Bao.BillBase.IChildForm.GetTableList()
        {
            return Bao.DataAccess.DataAcc.ExecuteQuery("select * from AuditGroup ");
        }

        void Bao.BillBase.IChildForm.Append()
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("insert into AuditGroup(AuditGroupId,AuditGroupName)values ('"+txtAuditGroupId.Text.Trim()+"','"+txtAuditGroupName.Text.Trim()+"')  ");
        }

        void Bao.BillBase.IChildForm.Update()
        {
            Bao.DataAccess.DataAcc.ExecuteNotQuery("Update AuditGroup set AuditGroupName='" + txtAuditGroupName.Text.Trim() + "' where AuditGroupId='"+txtAuditGroupId.Text.Trim()+"'  ");
           
        }

        void Bao.BillBase.IChildForm.Delete(DataRow row1)
        {
            int dd = int.Parse(Bao.DataAccess.DataAcc.ExecuteScalar("select count(AuditGroupId) from AuditFlowDefin where AuditGroupId='" + row1["AuditGroupId"].ToString().Trim() + "'"));
            if (dd > 0)
            {
                throw new Exception("该审批组已被使用，不能删除");
            }
            dd = int.Parse(Bao.DataAccess.DataAcc.ExecuteScalar("select count(AuditGroupId) from users where AuditGroupId='" + row1["AuditGroupId"].ToString().Trim() + "'"));
            if (dd > 0)
            {
                throw new Exception("该审批组已被使用，不能删除");
            }
            Bao.DataAccess.DataAcc.ExecuteNotQuery("delete AuditGroup  where AuditGroupId='" + row1["AuditGroupId"].ToString().Trim() + "' ");
        }

        void Bao.BillBase.IChildForm.SetValueToControl(DataRow row1, Boolean Is_Update)
        {
            txtAuditGroupId.Text =row1["AuditGroupId"].ToString().Trim();
            txtAuditGroupName.Text = row1["AuditGroupName"].ToString().Trim();
        }

        #endregion
    }
}
