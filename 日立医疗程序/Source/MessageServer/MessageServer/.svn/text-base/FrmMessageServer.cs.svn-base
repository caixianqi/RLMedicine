using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bao.MessageServer
{
    /// <summary>
    /// 定时扫描消息表（tMessageAuto）将
    /// </summary>
    public partial class FrmMessageServer : Form
    {
        public FrmMessageServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BtnStart.Text == "开始")
            {
                timer1.Enabled = false;
                BtnStart.Text = "停止";
            }
            else
            {
                timer1.Enabled = true;
                BtnStart.Text = "开始";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////得到当前日期的消息
            //string sql = " select * into #ab from BaoSystem..tMessageAuto " +
            //        "where CONVERT (char(10), MessageDate ,120)=CONVERT (char(10), GETDATE() ,120)  " ;
            ////将固定星期或月的消息发送到消息表中。
            /////Left outer join 的目的是确保消息只发送一次。
            //sql=sql+" select a.* from ( " +
            //            "select a.*,b.FunctionName from BaoSystem..TMessageSet a,BaoSystem..TFunctions b  " +
            //            "where a.FunctionId=b.FunctionId and (tipsweekDay=DATEPART(weekday, GETDATE()) " +
            //            "or tipsmonthDay=DATEPART(Day, GETDATE())) " +
            //        ") a left outer join #ab b on a.autouserId=b.descuserId and a.functionid=b.functionid " +
            //        " where b.Functionid is null "+
            //        " drop   table   #ab";
            //System.Data.DataTable table1 = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
            //foreach (System.Data.DataRow row1 in table1.Rows)
            //{
            //    Bao.Message.CMessage.SendMessage(row1["FunctionName"].ToString(),"",row1["AutoUserId"].ToString(),"1",
            //                                     row1["FunctionId"].ToString(),"");
            //}

            ///得到所有正在审批的审批流程
            string sql = "select a.BillId,b.FunctionId  into #aa  "+
                    "from BaoSystem..AuditFlowLine a, BaoSystem..AuditFlowDefin b " +
                    "where a.AutoFlowId=b.AutoFlowId and auditFlag<>'2'  " +
                    "group by a.BillId,b.FunctionId "+
                    " having count(a.AutoFlowId)-sum(CAST(a.AuditFlag AS int)) >0 "+

                    "select a.* "+
                    "from BaoSystem..AuditFlowLine a,#aa b " +
                    "where  a.BillId=b.BillId and b.FunctionId=a.FunctionId and FlowFlag='0' and auditFlag='0'  " +              
                    "order by a.FunctionId,SortId "+

                   " drop table #aa";
            System.Data.DataTable table1  = Bao.DataAccess.DataAcc.ExecuteQuery(sql);
             
             foreach (System.Data.DataRow row1 in table1.Rows)
             {
                // if (row1["BillId"].ToString() == "J09090001")
                //     System.Diagnostics.Debug.WriteLine("J09090001");
                 //得到该审批流程对应的审批人员
                 sql = "select a.*,b.AuditCycle,b.ManagerUserId " +
                     " from BaoSystem..AuditFlowLineUser a,BaoSystem..AuditFlowDefin b ,BaoSystem..AuditFlowLine c " +
                     "where a.AutoFlowId=b.AutoFlowId  and a.AutoFlowId=c.AutoFlowId  and a.BillId=c.BillId and a.auditNum=c.auditNum  and c.auditFlag<>'2' and a.BillId='" + row1["BillId"].ToString() + 
                     "' and a.AutoFlowId='" + row1["AutoFlowId"].ToString() +
                     "' order by orderId";
                System.Data.DataTable Users=Bao.DataAccess.DataAcc.ExecuteQuery(sql);
                
                if (Users.Rows.Count > 1)
                {
                    for(int i=0;i< Users.Rows.Count;i++ )
                    {
                        //if (row1["AuditUserId"].ToString().Trim() == Users.Rows[i]["AuditUserId"].ToString().Trim())
                        {
                            if (System.DateTime.Parse(row1["UserUpDateDate"].ToString()).AddDays(int.Parse(Users.Rows[i]["AuditCycle"].ToString())) < System.DateTime.Now)
                            {
                                if (i == Users.Rows.Count - 1)  //如果是同一节点最后一个审批人员则给管理员发消息
                                {
                                    string AuditName = Bao.DataAccess.DataAcc.ExecuteScalar("select UserName from BaoSystem..Users where AutoUserId='" + Users.Rows[i]["AuditUserId"].ToString().Trim() + "'");
                                    string ManageId = Bao.DataAccess.DataAcc.ExecuteScalar("select * from BaoSystem..Users where UserId='" + Users.Rows[i]["ManagerUserId"].ToString().Trim() + "'");
                                    Bao.Message.CMessage.SendMessage("审核人员" +
                                            AuditName.Trim() + "没有审核" + row1["BillId"].ToString() + "单据", "", ManageId, "1",
                                                row1["FunctionId"].ToString(), "");
                                    //更新UserUpdateDate的目的是这条消息再等一个审批周期后还没处理才从新发
                                    Bao.DataAccess.DataAcc.ExecuteNotQuery("Update BaoSystem..AuditFlowLine set UserUpdateDate=getdate() " +
                                                " where AutoId='" + row1["AutoId"].ToString() + "'");
                                    break;
                                }
                                else                            //给同一节点的下个人发消息
                                {
                                    string AuditUserId;
                                    if (row1["AuditType"].ToString()=="1")
                                        AuditUserId = Bao.DataAccess.DataAcc.ExecuteScalar("select AutoUserId from BaoSystem..AuditRole_User where roleId='"+Users.Rows[i + 1]["AuditUserId"].ToString().Trim()+"' ");
                                    else
                                        AuditUserId=Users.Rows[i + 1]["AuditUserId"].ToString().Trim();

                                    Bao.Message.CMessage.SendMessage("审核单据", "", AuditUserId, "1", row1["FunctionId"].ToString(), row1["BillId"].ToString());
                                    Bao.DataAccess.DataAcc.ExecuteNotQuery("Update BaoSystem..AuditFlowLine set UserUpdateDate=getdate() " +
                                     " where AutoId='" + row1["AutoId"].ToString() + "'");

                                    break;
                                }
                            }
                        }
                    }
                }
             }

     

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMessageSet dd = new FrmMessageSet();
            dd.Show();
        }
    }
}
