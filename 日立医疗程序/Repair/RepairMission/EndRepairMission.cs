using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bao.BillBase;

namespace Repair
{
    public partial class EndRepairMission :UserControl,Bao.Interface.IU8Contral
    {
        public EndRepairMission()
        {
            
            InitializeComponent();

            this.comboBox1.SelectedIndex = 0;
            this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMonths(-1);
            GetData();
            
        }
        //private void GetData(DateTime beginTime,DateTime endTime)
        //{
        //    DataTable dt003 = new DataTable();
        //    DataTable dtmaster = new DataTable();
        //    DataTable dtmanger = new DataTable();
        //    if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
        //    {
        //        string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineModel,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";



        //        dt003 = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
        //    }
        //    if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
        //    {
        //        string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineModel,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm   where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";

        //        dtmaster = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

        //    }
        //    if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
        //    {
        //        string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineModel,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";


        //        dtmanger = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

        //        dtmanger.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineModel,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")  and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));

        //    }

        //    dt003.Merge(dtmanger);
        //    dt003.Merge(dtmaster);
        //    string[] distinctcols = new string[(dt003.Columns.Count)];
        //    foreach (DataColumn dc in dt003.Columns)
        //    {
        //        distinctcols[dc.Ordinal] = dc.ColumnName;
        //    }


        //    dt003 = dt003.DefaultView.ToTable(true, distinctcols);


        //    foreach (DataRow item in dt003.Rows)
        //    {
        //        item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
        //        item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
        //        item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
        //        item["出货"] = SendCout(item["RepairMissionCode"].ToString());
        //        item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
        //        item["申请"] = AppCount(item["RepairMissionCode"].ToString());
        //        item["维修进度"] = GetReMissionState(item["RepairMissionCode"].ToString());

        //    }

        //    this.gridControl1.DataSource = dt003;






        //}

        private void GetData()
        {
            DataTable dt003 = new DataTable();
            string relation = string.Format(" and  ReportRepartDate between ''{0}'' and ''{1}''", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            if (this.comboBox1.SelectedIndex == 0)
                relation += " and isnull(rm.IsEnd,'''') = ''''";
            else
                relation += " and rm.IsEnd = ''已结案''";

            try
            {
                string ss = string.Format(" exec sp_EndRepairMission '{0}', '{1}'", relation, UFBaseLib.BusLib.BaseInfo.DBUserID);

                dt003 = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
                
                this.gridControl1.DataSource = dt003;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化界面失败：" + ex.Message);
            }
           
        }

        private object GetReMissionState(string code)
        {
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + code + "'");

            if (RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'") == string.Empty)
            {
                return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from RepairMission where RepairMissionID = '" + id + "'");
            }
            else
            {
                string AuditPerson = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditPerson] from [FaultFeedback] where RepairMissionId = '" + id + "'");



                if (AuditPerson == string.Empty)
                {
                    return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select ProcessingStatus from FaultFeedback where RepairMissionID = '" + id + "'");
                }
                else
                {
                    return "已审核";
                }
               
            }

           
        }
        public string GetPriceState(string code)
        {
            //if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from price where (Reviewerid is not null and Reviewerid<>'')  and RepairMissionCode = '" + code + "'").Rows.Count > 0)
            //{
            //    return "已回执";
            //}
            //else if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from price where  RepairMissionCode = '" + code + "' and (Reviewerid is null or Reviewerid = '') ").Rows.Count > 0)
            //{
            //    return "已申请";
            //}
            //else

            //{ return "未申请"; }

            return RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select State from price where  RepairMissionCode = '" + code + "'");
        }

        public string GetFreeState(string code)
        {
            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select IsPass from FreeApplication where RepairMissionCode = '" + code + "'");
        }

        public string GetBillState(string code)
        {
            string Priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceCode from Price where RepairMissionCode = '" + code + "'");
            return RiLiGlobal.RiLiDataAcc.ExecuteScalar("select BillState from Bill where PriceCode = '" + Priceid + "'");
        }

        private double AppCount(string p)
        {




            int cout = int.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsApplication a,PartsApplicationDetails b where a.PartsApplicationID = b.PartsApplicationID and a.RepairMissionCode = '" + p + "' "));

            return cout;

        }


     



        private int ReturnCout(string p)
        {

            int cout = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsUseAndReturnInfo where    PartsInventoryID in (select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' )"), out cout);

            return cout;


        }
        private double SendCout(string p)
        {


            int cout = 0;

            int.TryParse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select case when  sum(iquantity) >0 then sum(iquantity) else 0  end from PartsInventoryDetails where    PartsInventoryID in (select PartsInventoryID from PartsInventory where RepairMissionCode = '" + p + "' )"), out cout);

            return cout;
        }


        private string GetInvState(string code)
        {
            string sate = string.Empty;
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
            {
                sate = "已申请";
            }
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsApplication where   RepairMissionCode = '" + code + "'").Rows.Count > 0 && RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PartsInventory where   RepairMissionCode = '" + code + "'").Rows.Count > 0)
            {
                sate = "已出货";
            }
            else

            { sate = string.Empty; }

            return sate;
        }

        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();

            EndThisTask(code,true);

            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();
            DisEndThisTask(code);
            GetData();
        }

        private bool EndThisTask(string Code,bool flgDisplay)
        {

            if (!EndThisTaskCondtion(Code, flgDisplay))
                return false;

            string sql = "Update RepairMission set IsEnd = '已结案' where RepairMissionCode = '" + Code + "'";

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);

            if (flgDisplay) System.Windows.Forms.MessageBox.Show("结案成功");

            return true;

        }

        /// <summary>
        /// 结案条件
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="flgDisplay"></param>
        /// <returns></returns>
        private bool EndThisTaskCondtion(string Code, bool flgDisplay)
        {
            if (RiLiGlobal.RiLiDataAcc.ExecuteScalar("select IsEnd from RepairMission where RepairMissionCode = '" + Code + "'") == "已结案")
            {
                if (flgDisplay)  MessageBox.Show("已结案！", "提示");
                return false;
            }

            //是否完成
            string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + Code + "'");
            //string ERR = string.Empty;
            if (RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditPerson] from [FaultFeedback] where RepairMissionId = '" + id + "'") == string.Empty)
            {
                if (flgDisplay) MessageBox.Show("故障反馈未审核，不能结案!", "提示");
                return false;
            }

            //是否保外项目
            string strType = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairtypeNew from RepairMission where RepairMissionCode = '" + Code + "'").ToUpper();
            if (strType == "C")
            {
                //是否免费
                if (!CheckFree(id))
                {
                    string priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceId from Price where RepairMissionCode = '" + Code + "'");
                    if (priceid == string.Empty)
                    {
                        if (flgDisplay) MessageBox.Show("[保外任务，未作报价单，不能结案!]", "提示");
                        return false;
                    }

                    string billState = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [BillState] from [Bill] where PriceId = '" + priceid + "'");

                    if (billState != "到款")
                    {
                        if (flgDisplay) MessageBox.Show("【发票没有寄票，或开票申请未通过，或者是开票未申请，或者未到款】", "提示");
                        return false;
                    }
                }
            }
           
            //先看是否做配件申请单
            DataTable invapp = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from PartsApplication where RepairMissionCode = '" + Code + "'");
            if (invapp.Rows.Count > 0)
            {
                //验证是否出库完成
                DataTable reslut = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select StateReturn,PartsInventoryId from PartsInventory where RepairMissionCode = '" + Code + "'");
                if (reslut.Rows.Count == 0)
                {
                    if (flgDisplay) MessageBox.Show("【未做配件出入单】", "提示");
                    return false;
                }
                foreach (DataRow item in reslut.Rows)
                {
                    if (item["StateReturn"].ToString() != "归还完成")
                    {
                        if (flgDisplay) MessageBox.Show("【还有出库单未归还完成】", "提示");
                        return false;
                    }
                }
            }
            //if (strType != "C")  //非C类才需要判断，维修的完成日期，15天结案
            //{
            //    DateTime completeDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [CompleteDate] from [FaultFeedback] where RepairMissionId = '" + id + "'"));
            //    if (RiLiGlobal.RiLiDataAcc.GetNow().AddDays(-15) <= completeDate)
            //    {
            //        string dd = (15 - (RiLiGlobal.RiLiDataAcc.GetNow() - completeDate).TotalDays).ToString("0.0");
            //        if (flgDisplay) MessageBox.Show("还差" + dd + "天才能结案", "提示");
            //        return false;
            //    }
            //}

            DateTime completeDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [CompleteDate] from [FaultFeedback] where RepairMissionId = '" + id + "'"));
            if (RiLiGlobal.RiLiDataAcc.GetNow().AddDays(-15) <= completeDate)
            {
                string dd = (15 - (RiLiGlobal.RiLiDataAcc.GetNow() - completeDate).TotalDays).ToString("0.0");
                if (flgDisplay) MessageBox.Show("还差" + dd + "天才能结案", "提示");
                return false;
            }

            return true;
        }


        public bool CheckPrice(string id)
        {

            return false;
          
        }
        public bool CheckFree(string id)
        {

            string sql = "select IsPass from [FreeApplication] where RepairMissionId = '" + id + "'";

            string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

            if (result == "同意")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckBill(string id)
        {
            return false;
        }
        private void DisEndThisTask(string Code)
        {
            string Person = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionCode = '" + Code + "'");

            if (!(UFBaseLib.BusLib.BaseInfo.userRole.Contains("009")))
            {
                throw new Exception("只有部长可以反结案");
            }
            string sql = "Update RepairMission set IsEnd = null,IsEndText = null where RepairMissionCode = '" + Code + "'";

            RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionID"].ToString();

            foreach (Form item in this.ParentForm.MdiChildren)
            {
                if (item is FrmBillBase)
                {
                    if (((FrmBillBase)item).BO.BillId == id)
                    {
                        item.Activate();
                        return;
                    }
                }
            }



        

            Repair.RepairMission mision = new RepairMission(id);

            mision.MdiParent = this.Parent.FindForm().ParentForm;

            mision.Show();
        }

        public int outCout(string invid)
        {
            string sql = "select sum(iquantity) from PartsInventoryDetails  where PartsInventoryID = '" + invid + "'";

            string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

            if (result == string.Empty)

                return 0;

            else
            {
                return int.Parse(result);
            }

        }
        public int returnCout(string invid)
        {
            string sql = "select sum(iquantity) from PartsUseAndReturnInfo  where PartsInventoryID = '" + invid + "'";

            string result = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar(sql);

            if (result == string.Empty)

                return 0;

            else
            {
                return int.Parse(result);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sucess = 0;
            int fail = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                try
                {
                    string code = gridView1.GetDataRow(i)["RepairMissionCode"].ToString();

                    EndThisTask(code,false);

                    sucess++;
                    continue;
                }
                catch (Exception ex)
                {
                    fail++;
                    continue;
                }

            }

            this.GetData();


            System.Windows.Forms.MessageBox.Show("结案成功:" + sucess.ToString() + "结案失败:"+fail.ToString());
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            try
            {
                string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();

                string Person = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionCode = '" + code + "'");

                if (!(Person == UFBaseLib.BusLib.BaseInfo.DBUserID))
                {
                    System.Windows.Forms.MessageBox.Show("只有自己负责的维修任务才能结案");
                    return;
                }

                if (!EndThisTask(code, true))
                {
                    this.RepairMissionEnd();
                }

             
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("不能结案原因："+ex.Message);
                this.RepairMissionEnd();               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void 结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();

            if (!EndThisTask(code, true))
                return;

            GetData();
        }

        private void 批量结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sucess = 0;
            int fail = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string code = gridView1.GetDataRow(i)["RepairMissionCode"].ToString();

                if (EndThisTask(code,false))
                    sucess++;
                else
                    fail++;
            }
            this.GetData();


            System.Windows.Forms.MessageBox.Show("结案成功:" + sucess.ToString() + "结案失败:" + fail.ToString());
        }

        private void 手工结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();

                if (!(UFBaseLib.BusLib.BaseInfo.userRole.Contains("002") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009")))
                {
                    System.Windows.Forms.MessageBox.Show("只有客服部长和客服科长可以手工结案");
                    return;
                 
                }
                if (!EndThisTask(code, true))
                {
                    this.RepairMissionEnd();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("不能结案原因：" + ex.Message);
                this.RepairMissionEnd();
                return;
            }
        }

        /// <summary>
        /// 手工结案 
        /// </summary>
        private void RepairMissionEnd()
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();
            if (MessageBox.Show("是否确定要手工结案？", "提示", System.Windows.Forms.MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                Message.SendDefineMsg msg = new Message.SendDefineMsg();

                msg.Text = "手工结案原因";

                msg.ShowDialog();

                if (msg.Msg.ToString() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("必须输入原因");
                    return;
                }

                string sql = "Update RepairMission set IsEnd = '已结案',IsEndText = '" + msg.Msg + "' where RepairMissionCode = '" + code + "'";


                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql);

                System.Windows.Forms.MessageBox.Show("手工结案成功");
                this.GetData();
            }

        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ListQuery lq = new ListQuery();
            //lq.label2.Text = "报修日期范围";
            //lq.ShowDialog();

            //GetData(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.AddDays(1).Date);
        }

        private void 反结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();


            DisEndThisTask(code);
            GetData();
        }
    }
}
