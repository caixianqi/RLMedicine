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


            GetData();
            
        }
        private void GetData(DateTime beginTime,DateTime endTime)
        {
            DataTable dt003 = new DataTable();
            DataTable dtmaster = new DataTable();
            DataTable dtmanger = new DataTable();
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";



                dt003 = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm   where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ") and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";

                dtmaster = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002"))
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'";


                dtmanger = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

                dtmanger.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")  and ReportRepartDate between '" + beginTime.Date.ToShortDateString() + "' and '" + endTime.AddSeconds(86399).ToString() + "'"));

            }

            dt003.Merge(dtmanger);
            dt003.Merge(dtmaster);
            string[] distinctcols = new string[(dt003.Columns.Count)];
            foreach (DataColumn dc in dt003.Columns)
            {
                distinctcols[dc.Ordinal] = dc.ColumnName;
            }


            dt003 = dt003.DefaultView.ToTable(true, distinctcols);


            foreach (DataRow item in dt003.Rows)
            {
                item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
                item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
                item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
                item["出货"] = SendCout(item["RepairMissionCode"].ToString());
                item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
                item["申请"] = AppCount(item["RepairMissionCode"].ToString());
                item["维修进度"] = GetReMissionState(item["RepairMissionCode"].ToString());

            }

            this.gridControl1.DataSource = dt003;






        }

        private void GetData()
        {
            DataTable dt003 = new DataTable();
            DataTable dtmaster = new DataTable();
            DataTable dtmanger = new DataTable();
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where RepairPersonCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'";



                dt003 = Bao.DataAccess.DataAcc.ExecuteQuery(ss);
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("008") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009"))
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm   where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")";

                dtmaster = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("002") )
            {
                string ss = "select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where CustomerManagerCode = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "'";


                dtmanger = RiLiGlobal.RiLiDataAcc.ExecuteQuery(ss);

                dtmanger.Merge(RiLiGlobal.RiLiDataAcc.ExecuteQuery("select rm.RepairMissionId,rm.RepairMissionCode,rm.CustomerName,rm.RepairPersonName,rm.ZoneName,MachineName,manufactureCode,ReportRepartDate,RepairType,RepairSource,CustomerDepartmentName,CustomerManagerName,IsEndText,ReportRepartDate,'' as '报价进度' ,'' as '申请免费' ,'' as '开票进度',0 as '出货',0 as '归还',0 as '申请',rm.IsEnd,'' as '维修进度' from RepairMission rm  where ZoneCode  in (" + RiLiGlobal.RegionHelper.GetProvinceIdListByUserForSQL(UFBaseLib.BusLib.BaseInfo.DBUserID) + ")"));

            }

            dt003.Merge(dtmanger);
            dt003.Merge(dtmaster);
            string[] distinctcols = new string[(dt003.Columns.Count)];
            foreach (DataColumn dc in dt003.Columns)
            {
                distinctcols[dc.Ordinal] = dc.ColumnName;
            }


            dt003 = dt003.DefaultView.ToTable(true, distinctcols);


            foreach (DataRow item in dt003.Rows)
                {
                    item["报价进度"] = GetPriceState(item["RepairMissionCode"].ToString());
                    item["申请免费"] = GetFreeState(item["RepairMissionCode"].ToString());
                    item["开票进度"] = GetBillState(item["RepairMissionCode"].ToString());
                    item["出货"] = SendCout(item["RepairMissionCode"].ToString());
                    item["归还"] = ReturnCout(item["RepairMissionCode"].ToString());
                    item["申请"] = AppCount(item["RepairMissionCode"].ToString());
                    item["维修进度"] = GetReMissionState(item["RepairMissionCode"].ToString());

                }

            this.gridControl1.DataSource = dt003;


         

            
           
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

            EndThisTask(code);

            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();
            DisEndThisTask(code);
            GetData();
        }

        private void EndThisTask(string Code)
        {

            //是不是本人

            //string Person = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionCode = '" + Code + "'");

            //if (!(Person == UFBaseLib.BusLib.BaseInfo.DBUserID))
            //{
            //    throw new Exception("只有自己负责的维修任务才能结案");
            //}
           
            
            //是否完成
               string id = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairMissionId from RepairMission where RepairMissionCode = '" + Code + "'");

               string ERR = string.Empty;

            //已经审核通过的情况下
               if (!(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [AuditPerson] from [FaultFeedback] where RepairMissionId = '" + id + "'") == string.Empty))
              {
                
                 

                      //验证报价部分的
                      if (CheckFree(id))
                      {
                          ERR += string.Empty;
                        
                      }
                      //只有在保外的前提才做验证
                      else
                      {
                          if (RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairType from RepairMission where RepairMissionCode = '" + Code + "'") == "保外")
                          {

                              //如果“最终故障解决方式”中选择“电话解决”或者“暂不维修”，则在结案的条件中无需验证是否到款或者免费申请是否通过
                              if (RiLiGlobal.RiLiDataAcc.ExecuteScalar("select Finalsolution from FaultFeedback where RepairMissionID = '" + id + "'") == "电话" || RiLiGlobal.RiLiDataAcc.ExecuteScalar("select Finalsolution from FaultFeedback where RepairMissionID = '" + id + "'") == "暂不维修")
                              {
                                  ERR += string.Empty;

                              }
                              else
                              {
                              string priceid = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select PriceId from Price where RepairMissionCode = '" + Code + "'");

                              if (priceid == string.Empty)
                              {



                                  ERR += "[保外任务，未作报价单]";

                              
                              }
                              else
                              {
                                  string billState = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [BillState] from [Bill] where PriceId = '" + priceid + "'");

                                  if (billState == "到款")
                                  {
                                      ERR += string.Empty;
                                  }
                                  else if (billState == "寄票")
                                  {
                                      ERR += string.Empty;

                                      ERR += "【发票已经寄票，但是未到款】";

                                     // System.Windows.Forms.MessageBox.Show("注意：发票已经是寄票状态，但是未到款。如不确定，请结案后再反结案");
                                  }
                                  else
                                  {
                                      ERR += "【发票没有寄票，或开票申请未通过，或者是开票未申请】";
                                  }

                              }
                              }
                          }
                       
                      }
                  //先看是否做配件申请单

                      DataTable invapp = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from PartsApplication where RepairMissionCode = '" + Code + "'");

                      if (invapp.Rows.Count > 0)
                      {
                          //
                          //验证是否出库完成
                          DataTable reslut = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select StateReturn,PartsInventoryId from PartsInventory where RepairMissionCode = '" + Code + "'");

                          if (reslut.Rows.Count == 0)
                          {
                              ERR += "【未做配件出入单】";
                          }
                          else
                          {

                              foreach (DataRow item in reslut.Rows)
                              {
                                  if (item["StateReturn"].ToString() == "归还完成")
                                  {
                                      //每张单的存货的出库数和归还数是不是一样的。

                                      //if (outCout(item["PartsInventoryId"].ToString()) == returnCout(item["PartsInventoryId"].ToString()))
                                      //continue;
                                      //else
                                      //    ERR += "【检查发现，仍然有出库单，出库数不等于归还数】";




                                  }
                                  else
                                  {
                                      ERR += "【还有出库单未归还完成】";
                                      break;
                                      
                                  }
                              }
                          }
                      }


                      //是否是完成15天后
                      DateTime completeDate = DateTime.Parse(RiLiGlobal.RiLiDataAcc.ExecuteScalar("select [CompleteDate] from [FaultFeedback] where RepairMissionId = '" + id + "'"));
                      if ( RiLiGlobal.RiLiDataAcc.GetNow().AddDays(-15) > completeDate)
                      {
                         
                      }
                       else
                      {
                          string dd = (15-( RiLiGlobal.RiLiDataAcc.GetNow() - completeDate).TotalDays).ToString("0.0");
                          ERR +="还差" +dd+"天才能结案";
                      }

                     
                      if (ERR == string.Empty)
                      {
                          string sql = "Update RepairMission set IsEnd = '已结案' where RepairMissionCode = '" + Code + "'";

                          RiLiGlobal.RiLiDataAcc.ExecuteNotQuery(sql);

                          System.Windows.Forms.MessageBox.Show("结案成功");
                      }
                      else
                      {
                          throw new Exception(ERR);
                      }
                  
              
                
              }
              else
              {
                  throw new Exception("未审核，不能结案");
              }


         
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

                    EndThisTask(code);

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

                EndThisTask(code);

             
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("不能结案原因："+ex.Message);

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

                    string sql = "Update RepairMission set IsEnd = '已结案',IsEndText = '"+msg.Msg+"' where RepairMissionCode = '" + code + "'";


                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery(sql);

                    System.Windows.Forms.MessageBox.Show("手工结案成功");
                }


               
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

            EndThisTask(code);

            GetData();
        }

        private void 批量结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sucess = 0;
            int fail = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                try
                {
                    string code = gridView1.GetDataRow(i)["RepairMissionCode"].ToString();

                    EndThisTask(code);

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


            System.Windows.Forms.MessageBox.Show("结案成功:" + sucess.ToString() + "结案失败:" + fail.ToString());
        }

        private void 手工结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();

                //string Person = RiLiGlobal.RiLiDataAcc.ExecuteScalar("select RepairPersonCode from RepairMission where RepairMissionCode = '" + code + "'");

                //if (!(Person == UFBaseLib.BusLib.BaseInfo.DBUserID))
                //{
                //    System.Windows.Forms.MessageBox.Show("只有自己负责的维修任务才能结案");
                //    return;
                //}

                if (!(UFBaseLib.BusLib.BaseInfo.userRole.Contains("002") || UFBaseLib.BusLib.BaseInfo.userRole.Contains("009")))
                {
                    System.Windows.Forms.MessageBox.Show("只有部长和科长可以手工结案");
                    return;
                 
                }

             
                EndThisTask(code);



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("不能结案原因：" + ex.Message);

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
                }



            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListQuery lq = new ListQuery();
            lq.label2.Text = "报修日期范围";
            lq.ShowDialog();

            GetData(lq.dateTimePicker1.Value.Date, lq.dateTimePicker2.Value.AddDays(1).Date);
        }

        private void 反结案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = gridView1.GetDataRow(gridView1.FocusedRowHandle)["RepairMissionCode"].ToString();


            DisEndThisTask(code);
            GetData();
        }
    }
}
