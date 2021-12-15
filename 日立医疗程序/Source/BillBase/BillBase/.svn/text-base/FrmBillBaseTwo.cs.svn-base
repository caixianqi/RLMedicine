using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.BillBase
{
    public partial class FrmBillBaseTwo : Bao.FormChildBase
    {
        private Boolean _HaveAuditFlow=false ;

        public Boolean HaveAuditFlow
        {
            get { return _HaveAuditFlow; }
            set { _HaveAuditFlow = value; }
        }

        public void SetFunctionId(string mFunctionId)
        {
            BO.FunctionId = mFunctionId;
        }
        //public Bao.AuditFlow.AuditField[] FieldInfo;

        public BillBaseTwo BO;
        public FrmBillBaseTwo()
        {
            InitializeComponent();
        }

        private void toolBarBill1_OnBaoAudit(object sender, EventArgs e)
        {
            if (HaveAuditFlow)
            {
                if (BO.BillId == "")
                {
                    throw new Exception("必须对单号'BillId'进行付值。");
                }
                if (BO.FunctionId == "")
                {
                    throw new Exception("必须对功能编号'FunctionId'进行付值。");
                }
                if (UFBaseLib.BusLib.BaseInfo.UserId == "")
                {
                    throw new Exception("必须对登陆用户编号'UFBaseLib.BusLib.BaseInfo.UserId'进行付值。");
                }
                Bao.AuditFlow.AuditExec AuditObj = new Bao.AuditFlow.AuditExec();
                AuditObj.Audit(UFBaseLib.BusLib.BaseInfo.UserId, BO.FunctionId, BO.BillId,"",0);
            }
            BO.Audit();
        }
        private void toolBarBill1_OnBaoNew(object sender, EventArgs e)
        {
            BO.BillId = Bao.DataAccess.DataAcc.MaxBill(BO.TableMainName,"");
            BO.Init(BO.BillId);
            BaoUnDataBinding();
            BaoDataBinding();
            CtrEnable(true);

        }

        private void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            if (HaveAuditFlow)
            {
                if (BO.FunctionId == "")
                {
                    throw new Exception("必须对功能编号'FunctionId'进行付值。");
                }
                if (UFBaseLib.BusLib.BaseInfo.UserId == "")
                {
                    throw new Exception("必须对登陆用户编号'UFBaseLib.BusLib.BaseInfo.UserId'进行付值。");
                }
               // Bao.AuditFlow.AuditFlowExpression Express = new Bao.AuditFlow.AuditFlowExpression(BO.FunctionId);

                //Bao.AuditFlow.AuditField[] Fields = Express.GetFieldName(BO.BillId);
                //if (Fields != null)
                //{
                //    for (int i = 0; i < Fields.Length; i++)
                //    {
                //        for (int j = 0; j < BO.TableMain.Columns.Count; j++)
                //        {
                //            if (Fields[i].FieldName == BO.TableMain.Columns[j].ColumnName)
                //            {
                //                Fields[i].FieldValue = double.Parse(BO.TableMain.Rows[0][BO.TableMain.Columns[j].ColumnName].ToString());
                //            }
                //        }
                //    }
                Bao.AuditFlow.AuditLine AuditObj = new Bao.AuditFlow.AuditLine();
                AuditObj.CreateLine(BO.FunctionId, BO.BillId);

                //}

            }
            this.BindingContext[this.BO.TableMain].EndCurrentEdit();
            this.BindingContext[this.BO.TableItems].EndCurrentEdit();
            if (e.Is_Update)
                BO.UpdateSave();
            else
                BO.NewSave();
            CtrEnable(false);

        }

        private void toolBarBill1_OnBaoSelect(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.BO.BillId = e.ReturnRow1[this.BO.KeyFieldName].ToString();
            this.BO.Init(this.BO.BillId);
            if (BO.TableMain.Rows[0]["AuditFlag"].ToString() == "1")
            {
                toolBarBill1.BtnAudit.Text = "反审核";
            } else
                toolBarBill1.BtnAudit.Text = "审核";

            this.BaoUnDataBinding();
            this.BaoDataBinding();
        }
        
        private void toolBarBill1_OnBaoUpdate(object sender, EventArgs e)
        {
            CtrEnable(true);
        }

        private void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            if (toolBarBill1.BtnAudit.Text == "反审核")
                throw new Exception("该单据已审核，不能删除");
            if (MessageBox.Show("确定要删除！", "提示", System.Windows.Forms.MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                BO.Delete();
                BO.Init("");
                this.BaoUnDataBinding();
                this.BaoDataBinding();
            }
            
        }
        public virtual void BaoUnDataBinding()
        {
            
        }
        public virtual void BaoDataBinding()
        {
 
        }
        public virtual string BaoSelectLookUpSQL()
        {
            return "";
        }
        public virtual string BaoSelectLookUpTitleName()
        {
            return "";
        }
        private void FrmBillBase_Load(object sender, EventArgs e)
        {
            this.toolBarBill1.baoBtnSelect.BaoSQL =BaoSelectLookUpSQL();
            this.toolBarBill1.baoBtnSelect.BaoTitleNames = BaoSelectLookUpTitleName();
            BaoUnDataBinding();
            BaoDataBinding();
            CtrEnable(false);
        }

        private void toolBarBill1_OnBaoSetPrintDataset(object sender, EventArgs e)
        {
            toolBarBill1.PrintData.Tables.Clear();
            toolBarBill1.PrintData.Tables.Add(this.BO.TableMain);
            toolBarBill1.PrintData.Tables.Add(this.BO.TableItems);
        }
        private void CtrEnable(Boolean Flag)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name != "toolBarBill1")
                    this.Controls[i].Enabled = Flag;
            }
        }

        private void toolBarBill1_OnBaoUnAudit(object sender, EventArgs e)
        {

            BO.UnAudit();
        }

    }
}
