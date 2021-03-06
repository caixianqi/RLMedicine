using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bao
{
    public partial class FormChildBase : Form
    {
        public System.Data.DataTable FormList=new DataTable();
        public FormChildBase()
        {
            InitializeComponent();
        }

        private void FormChildBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Data.DataRow row1 in FormList.Rows)
            {
                if (row1["Form"] != System.DBNull.Value)
                    if (this.Handle == ((System.Windows.Forms.Form)row1["Form"]).Handle)
                        row1["Form"] = System.DBNull.Value;
            }
            
        }

        /// <summary>
        /// 根据维修编号获取维修负责经理
        /// </summary>
        /// <param name="RepairCode"></param>
        /// <returns></returns>
        public string GetRepManager(string RepairCode)
        {
          
              return  RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select CustomerManagerCode from RepairMission where [RepairMissionCode] = '" + RepairCode + "'");
           
        }

        /// <summary>
        /// 根据维修编号获取维修负责工程师
        /// </summary>
        /// <param name="RepairCode"></param>
        /// <returns></returns>
        public  string GetRepEnger(string RepairCode)
        {
            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairPersonCode from RepairMission where [RepairMissionCode] = '" + RepairCode + "'");
        }


        /// <summary>
        /// 根据单号来获得单据的内容
        /// </summary>
        public virtual void GetBillInfo(string BillId)
        {

        }
        public virtual void SetFunctionId(string mFunctionId)
        {
            
        }

    }
}
