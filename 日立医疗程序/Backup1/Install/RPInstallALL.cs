using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8Global;

namespace Install
{
    public partial class RPInstallALL : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string U8DataBaseName = string.Empty;
        public RPInstallALL()
        {
            InitializeComponent();
        }

        private void RPInstallALL_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.flexMain.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flexDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.ClientCode_tb.Enabled = true;
            this.ClientCode_dx.Enabled = true;
            this.ChuKuCode_tb.Enabled = true;
            this.XShouCode_tb.Enabled = true;
            this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMonths(-1);
            this.dateTimePicker1.Checked = false;
            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;

            ClientCode_tb.BaoSQL = "select cCusCode,cCusAbbName from " + U8DataBaseName + ".Customer where ccccode  like '2%' or ccccode like '1%'";
            ClientCode_tb.BaoTitleNames = "cCusCode=客户编号,cCusAbbName=客户名称";
            this.ClientCode_tb.FrmHigth = 600;
            this.ClientCode_tb.FrmWidth = 450;
            ClientCode_tb.DecideSql = "select  cCusCode,cCusAbbName from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_tb.BaoColumnsWidth = "cCusCode=120,cCusAbbName=280";

            ClientCode_dx.BaoSQL = "select cCusCode,cCusAbbName from " + U8DataBaseName + ".Customer where ccccode  like '2%' or ccccode like '1%'";
            ClientCode_dx.BaoTitleNames = "cCusCode=客户编号,cCusAbbName=客户名称";
            this.ClientCode_dx.FrmHigth = 600;
            this.ClientCode_dx.FrmWidth = 450;
            ClientCode_dx.DecideSql = "select  cCusCode,cCusAbbName from " + U8DataBaseName + ".Customer where cCusCode=";
            ClientCode_dx.BaoColumnsWidth = "cCusCode=120,cCusAbbName=280";

            ChuKuCode_tb.BaoSQL = "select ccode from " + U8DataBaseName + ".rdrecord32";
            ChuKuCode_tb.BaoTitleNames = "ccode=出库单号";
            this.ChuKuCode_tb.FrmHigth = 600;
            this.ChuKuCode_tb.FrmWidth = 250;
            ChuKuCode_tb.DecideSql = "select ccode from " + U8DataBaseName + ".rdrecord32 where ccode=";
            ChuKuCode_tb.BaoColumnsWidth = "ccode=250";

            XShouCode_tb.BaoSQL = "select cDefine2 as xcode from " + U8DataBaseName + ".rdrecord32 where cDefine2 is not null";
            XShouCode_tb.BaoTitleNames = "xcode=销售订单号";
            this.XShouCode_tb.FrmHigth = 600;
            this.XShouCode_tb.FrmWidth = 250;
            XShouCode_tb.DecideSql = "select cDefine2 as xcode from " + U8DataBaseName + ".rdrecord32 where cDefine2=";
            XShouCode_tb.BaoColumnsWidth = "xcode=250";
        }

        private void ClientCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ClientCode_tb.Text = dr["cCusCode"].ToString();
            ClientName_tb.Text = dr["cCusAbbName"].ToString();
        }

        private void ChuKuCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ChuKuCode_tb.Text = dr["ccode"].ToString();
            ChuKuCode_textBox.Text = dr["ccode"].ToString();
        }

        private void XShouCode_tb_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            XShouCode_tb.Text = dr["xcode"].ToString();
            XShouCode_textBox.Text = dr["xcode"].ToString();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            this.LoadDisplay("-1","001");
            string relation = "1=1 ";
            if (this.dateTimePicker1.Checked)
            {
                relation += string.Format(" and a.ddate >= '{0}'", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
            if (this.dateTimePicker2.Checked)
            {
                relation += string.Format(" and a.ddate <= '{0}'", this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            }
            if (this.ClientName_tb.Text.Trim().Length > 0)
            {
                relation += " and a.cdefine11 = '" + this.ClientName_tb.Text.Trim() + "'";
            }

            if(this.ChuKuCode_textBox.Text.Trim().Length > 0)
            {
                relation += " and a.ccode = '" + this.ChuKuCode_textBox.Text.Trim() + "' ";
            }

            if (this.ClientCode_dx.Text.Trim().Length > 0)
            {
                relation += " and a.cCusCode = '" + this.ClientCode_dx.Text.Trim() + "' ";
            }

            if (this.XShouCode_textBox.Text.Trim().Length > 0)
            {
                relation += " and a.cDefine2 = '" + this.XShouCode_textBox.Text.Trim() + "' ";
            }
            //a.iverifystate = 2
            string strother = "1=1";
            //if (UFBaseLib.BusLib.BaseInfo.DBUserID.ToLower() != "zhouzhi"
            //    && UFBaseLib.BusLib.BaseInfo.DBUserID.ToLower() != "huangli"
            //    && UFBaseLib.BusLib.BaseInfo.DBUserID.ToLower() != "demo")
            //{
            //    strother = "f.cMaker = '" + UFBaseLib.BusLib.BaseInfo.UserName + "'";
            //}

            string sql ="";
            string sqlAccount="";

            string U8AccountNum = "";
            string U8DataBaseNameBy009="";


            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            if(RiLiGlobal.RiLiDataAcc.AccountNum=="009")
            {
                //若是009售后账套，则读取对应U8 001，003，005的合并数据
                sqlAccount = "select AccountNum,U8Server,U8DataBase from [U13SHOUHOU].dbo.RL_DBInfo where AccountNum in ('001','003','005')";
                DataTable dtAccount = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sqlAccount);
                if(dtAccount!=null && dtAccount.Rows.Count>0)
                {
                    for(int i=0;i<dtAccount.Rows.Count;i++)
                    {
                        U8AccountNum = dtAccount.Rows[i]["AccountNum"].ToString().Trim();

                        U8DataBaseNameBy009=string.Format("[{0}].[{1}].dbo",dtAccount.Rows[i]["U8Server"].ToString().Trim(),dtAccount.Rows[i]["U8DataBase"].ToString().Trim());

                        sql += string.Format(@"select '{3}' as U8AccountNum, a.ID,a.ccode,a.ddate,e.ccuscode,a.cdefine11 as ccusname,a.cCusCode as xcCusCode,b.cCusAbbName as xccusname,
			                                        a.cDefine2 as xcode,ag.cPersonName as acPersonName,i.ccCName as cDCName,isnull(h.cDCName,i.ccCName) as djDCName,
				                                        e.cCusAddress,e.cCusPerson,e.cCusPhone,a.cwhcode,c.cwhname,a.cDefine8 as RepairMonth --,g.cPersonName as xcPersonName, 
	                                        from {0}.rdrecord32 a
                                            left join {0}.customer b on a.ccuscode = b.ccuscode
                                            left join {0}.warehouse c on a.cwhcode = c.cwhcode
                                            left join {0}.customer e on a.cdefine11 = e.cCusAbbName
                                            left join {0}.SO_SOmain f on a.cDefine2 = f.cDefine2 --f.csocode
                                            left join {0}.person g on f.cPersonCode = g.cPersonCode
                                            left join {0}.person ag on a.cPersonCode = ag.cPersonCode 
                                            left join {0}.DistrictClass h on e.cDCCode = h.cdccode
                                            left join {0}.CustomerClass i on e.cCCCode = i.cCCCode
	                                        where a.cHandler is not null and ISNULL(f.cCloser, '') = '' and (e.ccccode  like '2%' or e.ccccode like '1%') and {1} and {2}
                                                    and a.ddate>='2013-03-01'
							                      and exists 
                                                      (select a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                                            ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                                            ,c1.cinvSN,sum(d1.qty) as qty
                                                            ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as unQty
                                                        from {0}.rdrecords32 a1
                                                        inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                                        left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                                        left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                                        where a1.id = a.id 
                                                        group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN
	                                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end
                                                        having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)
                                                    )
"
                                                                                                , U8DataBaseNameBy009, relation, strother, U8AccountNum);

                         if(i!=dtAccount.Rows.Count-1)
                         {
                              sql+= " union all ";
                         }

                    }
                }

            }
            else
            {
                sql = string.Format(@"select '{3}' as U8AccountNum, a.ID,a.ccode,a.ddate,e.ccuscode,a.cdefine11 as ccusname,a.cCusCode as xcCusCode,b.cCusAbbName as xccusname,
			                                        a.cDefine2 as xcode,ag.cPersonName as acPersonName,i.ccCName as cDCName,isnull(h.cDCName,i.ccCName) as djDCName,
				                                        e.cCusAddress,e.cCusPerson,e.cCusPhone,a.cwhcode,c.cwhname,a.cDefine8 as RepairMonth --,g.cPersonName as xcPersonName, 
	                                        from {0}.rdrecord32 a
                                            left join {0}.customer b on a.ccuscode = b.ccuscode
                                            left join {0}.warehouse c on a.cwhcode = c.cwhcode
                                            left join {0}.customer e on a.cdefine11 = e.cCusAbbName
                                            left join {0}.SO_SOmain f on a.cDefine2 = f.cDefine2 --f.csocode
                                            left join {0}.person g on f.cPersonCode = g.cPersonCode
                                            left join {0}.person ag on a.cPersonCode = ag.cPersonCode 
                                            left join {0}.DistrictClass h on e.cDCCode = h.cdccode
                                            left join {0}.CustomerClass i on e.cCCCode = i.cCCCode
	                                        where a.cHandler is not null and ISNULL(f.cCloser, '') = '' and (e.ccccode  like '2%' or e.ccccode like '1%') and {1} and {2}
                                                    and a.ddate>='2013-03-01'
							                      and exists 
                                                      (select a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                                            ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                                            ,c1.cinvSN,sum(d1.qty) as qty
                                                            ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as unQty
                                                        from {0}.rdrecords32 a1
                                                        inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                                        left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                                        left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                                        where a1.id = a.id 
                                                        group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN
	                                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end
                                                        having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)
                                                    )
"
                                                                                                , U8DataBaseName, relation, strother, RiLiGlobal.RiLiDataAcc.AccountNum);

            }

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);
            this.flexMain.DataSource = dt;
            this.flexDetail.DataSource = dt.Clone();
            this.FormatFlex(this.flexMain);
            this.FormatFlex(this.flexDetail);
        }

        private void FormatFlex(C1.Win.C1FlexGrid.C1FlexGrid flex)
        {
            flex.Cols["ID"].Visible = false;
            flex.Cols["cwhcode"].Visible = false;
            flex.Cols["cwhname"].Visible = false;
            flex.Cols["xcCusCode"].Visible = false;

            flex.Cols["U8AccountNum"].Caption = "U8账套";
            flex.Cols["ccode"].Caption = "出库单号";
            flex.Cols["ddate"].Caption = "出库日期";
            flex.Cols["ccuscode"].Caption = "最终客户编码";
            flex.Cols["ccusname"].Caption = "最终客户";
            flex.Cols["xcCusCode"].Caption = "销售代理店";
            flex.Cols["xccusname"].Caption = "销售代理店";
            flex.Cols["xcode"].Caption = "销售订单号";
            flex.Cols["acPersonName"].Caption = "销售负责人";
            flex.Cols["cDCName"].Caption = "省份";
            flex.Cols["djDCName"].Caption = "地区";
            flex.Cols["cCusAddress"].Caption = "客户地址";
            flex.Cols["cCusPerson"].Caption = "联系人";
            flex.Cols["cCusPhone"].Caption = "电话";
            flex.Cols["RepairMonth"].Caption = "保修周期";

            flex.Cols["U8AccountNum"].Width = 80;
            flex.Cols["ccode"].Width = 80;
            flex.Cols["ddate"].Width = 70;
            flex.Cols["ccuscode"].Width = 80;
            flex.Cols["ccusname"].Width = 150;
            flex.Cols["xcCusCode"].Width = 80;
            flex.Cols["xccusname"].Width = 150;
            flex.Cols["xcode"].Width = 70;
            flex.Cols["acPersonName"].Width = 60;
            flex.Cols["cDCName"].Width = 80;
            flex.Cols["djDCName"].Width = 80;
            flex.Cols["cCusAddress"].Width = 150;
            flex.Cols["cCusPerson"].Width = 80;
            flex.Cols["cCusPhone"].Width = 80;
            flex.Cols["RepairMonth"].Width = 50;
        }

        public void Authorization()
        {

        }

        /// <summary>
        /// 增加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int index = this.flexMain.Row;
            this.ChanageRow(this.flexMain, this.flexDetail, index);
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.flexDetail.Row;
            this.ChanageRow(this.flexDetail, this.flexMain, index);
        }


        /// <summary>
        /// 交换行
        /// </summary>
        /// <param name="flex1"></param>
        /// <param name="flex2"></param>
        /// <param name="row"></param>
        private void ChanageRow(C1.Win.C1FlexGrid.C1FlexGrid flex1,C1.Win.C1FlexGrid.C1FlexGrid flex2,int row)
        {
            if (row <= 0)
                return;

            C1.Win.C1FlexGrid.Row dr = flex1.Rows[row];
            C1.Win.C1FlexGrid.Row drnew = flex2.Rows.Add();
            
            foreach (C1.Win.C1FlexGrid.Column cl in this.flexMain.Cols)
            {
                if (cl.Name.Length <= 0)
                    continue;
                drnew[cl.Name] = dr[cl.Name];
            }
            flex1.Rows.Remove(dr);
        }

        /// <summary>
        /// 生成安装单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.button4_Click(null, null);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            string sql = string.Empty;
            string strInfo = string.Empty;
            string strtInsCode = string.Empty;  //安装单号
            string strtInsType = string.Empty;      //安装类别
            string strtMaiCode = string.Empty;      //主机型号
            string strcSNDefine1 = string.Empty;        //本部发货日期

            string jqjbcode = string.Empty; //主机编码
            string MachineModel = string.Empty; //主机型号
            string MachineLevel = string.Empty; //主机级别
            string MachineType = string.Empty; //主机类别
            string Color = string.Empty; //颜色
            string tMakeCode = string.Empty;    //主机编号

            string ProductLine = string.Empty;  //产品线

            string U8AccountNum = string.Empty; //U8来源账套
            try
            {
                HJ.Data.SQLDBConnect.SQLDBconntion.SQLTransBegin();

                //已选中出库单数据
                foreach (C1.Win.C1FlexGrid.Row dr in this.flexDetail.Rows)
                {
                    if (dr.Index <= 0)
                        continue;

                    //ID 为U8销售出库单，表头ID

                    U8AccountNum = dr["U8AccountNum"].ToString();
                    DataTable dtDetail = this.GetSaleRecordDetail(dr["ID"].ToString(),dr["U8AccountNum"].ToString(), false);
                    
                    //如果有多个主机的出库单，则不能生成安装单，然后判断下一个出库
                    //if (IsMaiCount(dtDetail))
                    //{
                    //    MessageBox.Show("出库单号[" + dr["ccode"].ToString() + "]有多个主机，不能生成安装单！", "温馨提示！");
                    //    continue;
                    //}

                    //判断是主机安装，还是配件安装
                    strtInsType = this.GetInstallType(dtDetail, out strtMaiCode, out strcSNDefine1);
                    if (strtInsType == "主机安装")
                    {
                        strtInsCode = RiLiGlobal.GetCode.GetInsCode();//主机安装 获取安装任务编号
                        //若是主机安装，获取机器级别档案数据
                        this.DragoutMachineCode(dtDetail, out jqjbcode, out MachineModel, out MachineLevel, out MachineType, out Color, out strtMaiCode, out tMakeCode, out ProductLine);
                    }
                    if (strtInsType == "选配件安装")
                    {
                        strtInsCode = RiLiGlobal.GetCode.GetOPCode();//配件安装 获取配件安装编号
                    }

                    if (dr["acPersonName"].ToString() == "")
                        dr["acPersonName"] = " ";
                    sql = string.Format(@"insert into InstallTask(tID,tInsCode,tCusCode,tCusName,
                                                    tComName,tComPhone,tAgeStore,tAgePerson,tRegName,tAddress,
                                                    tSendTime,tInsType,tSummary,tStartPerson,tState,City,dtimegc,xsalecode,xoutcode,xwhcode,tMaiCode,dtimefh
                                                    ,jqjbcode,MachineModel,MachineLevel,MachineType,Color,tMakeCode,tRepMonth,billDate,U8AccountNum,ProductLine)                                      values(NEWID(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{9}','{15}','{16}','{17}','{18}'
                                                ,'{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}',GETDATE(),'{27}','{28}')"
                            , strtInsCode, dr["ccuscode"].ToString(), dr["ccusname"].ToString(), dr["cCusPerson"].ToString(), dr["cCusPhone"].ToString()
                            , dr["xccusname"].ToString(), dr["acPersonName"].ToString(), dr["cDCName"].ToString(), dr["cCusAddress"].ToString()
                            , dr["ddate"].ToString(), strtInsType, "", UFBaseLib.BusLib.BaseInfo.DBUserID, "新任务", dr["djDCName"].ToString()
                            , dr["xcode"].ToString(), dr["ccode"].ToString(), dr["cwhcode"].ToString(), strtMaiCode, strcSNDefine1
                            , jqjbcode, MachineModel, MachineLevel, MachineType, Color, tMakeCode, dr["RepairMonth"].ToString(), U8AccountNum, ProductLine
                        );

                    HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteNonQuery(sql.Replace("''","null"));

                    //插入表体
                    this.SaveDetail(dtDetail, strtInsCode);

                    if (strtInsType == "主机安装")
                        RiLiGlobal.GetCode.SetInsCode();
                    else
                        RiLiGlobal.GetCode.SetOPCode();

                    strInfo += "[" + strtInsCode + "],";

                }

                HJ.Data.SQLDBConnect.SQLDBconntion.SQLTransCommit();
            }
            catch (Exception ex)
            {
                HJ.Data.SQLDBConnect.SQLDBconntion.SQLRollback();
                MessageBox.Show("生成安装时出错："+ex.Message, "错误");
                return false;
            }
            MessageBox.Show("生成安装单成功：" + strInfo,"提示");
            return true;
        }

        /// <summary>
        /// 插入表体
        /// </summary>
        /// <param name="dtdetail"></param>
        /// <param name="strtInsCode"></param>
        /// <returns></returns>
        private bool SaveDetail(DataTable dtdetail, string strtInsCode)
        {
            string sql = string.Empty;
            //foreach (DataRow dr in dtdetail.Select("not (((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%')"))
            foreach (DataRow dr in dtdetail.Rows)
            {
                if (Convert.ToDecimal(dr["unQty"]) > 0)
                {
                    sql = string.Format(@"insert into InsAccessory(aID,sautoid,aTaskCode,aAccCode,aAccName,cEnglishName,aAccStd,aMakeCode,qty,aSummary,dtimefh,dtimegc,U8AccountNum)
                                    values(newid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"
                                        , dr["autoid"].ToString(), strtInsCode, dr["cinvcode"].ToString(), dr["cinvname"].ToString(), dr["cEnglishName"].ToString(), dr["cInvStd"].ToString(), dr["cinvSN"].ToString()
                                        , Convert.ToInt32(dr["unQty"]), "", dr["cSNDefine1"].ToString(), dr["ddate"].ToString(), dr["U8AccountNum"].ToString());
                    HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteNonQuery(sql.Replace("''", "null"));
                }
                sql = string.Format(@"insert into InsAccessoryOld(aID,sautoid,aTaskCode,aAccCode,aAccName,cEnglishName,aAccStd,aMakeCode,qty,aSummary,dtimefh,dtimegc,U8AccountNum)
                                     values(newid(),{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"
                                    , dr["autoid"].ToString(),strtInsCode,  dr["cinvcode"].ToString(), dr["cinvname"].ToString(), dr["cEnglishName"].ToString()
                                    , dr["cInvStd"].ToString(), dr["cinvSN"].ToString(), Convert.ToInt32(dr["iquantity"]), "", dr["cSNDefine1"].ToString(), dr["ddate"].ToString(), dr["U8AccountNum"].ToString());
                HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteNonQuery(sql.Replace("''", "null"));
            }
            return true;
        }

        /// <summary>
        /// 加载销售出库明细  (true，显示所有销售出库明细)
        /// </summary>
        /// <param name="saleCode"></param>
        /// <returns></returns>
        private DataTable GetSaleRecordDetail(string ID, string U8AccountNum, bool flag)
        {
            /*
            string sql = string.Format(@"select a.autoid,a.cinvcode,b.cinvname,cinvdefine7 as cEnglishName,b.cInvStd 
		                                        ,case when isnull(c.cinvSN,'') = '' then a.iquantity else 1 end as iquantity
		                                        ,c.cinvSN
                                        from {1}.rdrecords32 a
                                        inner join {1}.Inventory b on a.cinvcode = b.cinvcode
                                        left join {1}.ST_SNDetail_SaleOut c on a.autoid = c.ivouchsid
                                        where a.id = '{0}'
                                                and exists (select isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0) as amount
											                    from {1}.rdrecords32 bb
													                    left join (select qty, sautoid 
																	                    from InsAccessory ia 
																	                    where ia.sautoid is not null) iaa 
														                    on bb.autoid = iaa.sautoid
											                    where bb.autoid = a.autoid
											                    group by bb.iquantity, iaa.qty
											                    having isnull(bb.iquantity, 0)-ISNULL(iaa.qty, 0) > 0)", ID, U8DataBaseName);
             */
            

            //旧U8系统取数条件
            /*string sql = string.Format(@"select a1.autoid,a1.cinvcode,b1.cinvname,b1.cinvdefine7 as cEnglishName,b1.cInvStd 
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                        ,c1.cinvSN,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as unQty
                                        ,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                   -- left join {0}.customer a3 on a2.ccuscode = a3.ccuscode
                                    --left join {0}.customer a4 on a2.cdefine1 = a4.cCusAbbName
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where a1.id = '{1}'
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cinvdefine7 ,b1.cInvStd ,c1.cinvSN,c1.cSNDefine1,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end
                                ", U8DataBaseName, ID);*/


            //新取U8 13.0系统取数条件
            string sql = "";
            string sqlAccount = "";

            string U8DataBaseNameBy009 = "";

             //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            if (RiLiGlobal.RiLiDataAcc.AccountNum == "009")
            {
                //若是009售后账套，则读取对应U8 001，003，005 ,即根据参数 U8AccountNum
                sqlAccount = string.Format("select AccountNum,U8Server,U8DataBase from [U13SHOUHOU].dbo.RL_DBInfo where AccountNum='{0}'", U8AccountNum);

                DataTable dtAccount = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sqlAccount);
                if (dtAccount != null && dtAccount.Rows.Count > 0)
                {
                    U8DataBaseNameBy009 = string.Format("[{0}].[{1}].dbo", dtAccount.Rows[0]["U8Server"].ToString().Trim(), dtAccount.Rows[0]["U8DataBase"].ToString().Trim());

                    sql = string.Format(@"select '{2}' as U8AccountNum,a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                        ,c1.cinvSN,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as unQty
                                        ,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                  
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join (select * from InsAccessory where U8AccountNum='{2}')  d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where a1.id = '{1}'
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,c1.cSNDefine1,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end
                                ", U8DataBaseNameBy009, ID, U8AccountNum);

                    if (!flag)
                    {
                        sql += " having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)";
                    }

                }
            }
            else
            {

                sql = string.Format(@"select '{2}' as U8AccountNum, a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName,b1.cInvStd 
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end as iquantity
                                        ,c1.cinvSN,sum(d1.qty) as qty
                                        ,(case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0) as unQty
                                        ,c1.cSNDefine1,a2.ddate
                                    from {0}.rdrecords32 a1
                                    inner join {0}.rdrecord32 a2 on a1.id = a2.id
                                  
                                    inner join {0}.Inventory b1 on a1.cinvcode = b1.cinvcode
                                    left join {0}.ST_SNDetail_SaleOut c1 on a1.autoid = c1.ivouchsid
                                    left join InsAccessory d1 on a1.autoid = d1.sautoid and isnull(c1.cinvSN,'') = ISNULL(d1.aMakeCode,'')
                                    where a1.id = '{1}'
                                    group by a1.autoid,a1.cinvcode,b1.cinvname,b1.cEnglishName ,b1.cInvStd ,c1.cinvSN,c1.cSNDefine1,a2.ddate
                                        ,case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end
                                ", U8DataBaseName, ID, U8AccountNum);

                if (!flag)
                {
                    sql += " having ((case when isnull(c1.cinvSN,'') = '' then a1.iquantity else 1 end)-ISNULL(sum(d1.qty),0)>0)";
                }
            }

            return HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(sql).Tables[0];
        }


        /// <summary>
        /// 销售出库单中是否包括主机安装
        /// </summary>
        /// <param name="saleCode"></param>
        /// <returns></returns>
        private string GetInstallType(DataTable dt, out string strtMaiCode, out string cSNDefine1)
        {
            string strInfo = "选配件安装";
            strtMaiCode = string.Empty;
            cSNDefine1 = string.Empty;
            //if (dt.Select("cinvcode like 'A%' and len(cinvcode) = 3").Length > 0)

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            /*if (dt.Select("((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045'").Length > 0)
            {
                strInfo = "主机安装";

                //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
                cSNDefine1 = dt.Select("((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045' ")[0]["cSNDefine1"].ToString();
            }*/


            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            if (dt.Select("(cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')").Length > 0)
            {
                strInfo = "主机安装";

                //Lin 2020_07_14 新售后系统主机规则要求
                //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
                //2】 B1012015,B1012016,B1012003
                //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
                cSNDefine1 = dt.Select("(cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')")[0]["cSNDefine1"].ToString();
            }

            return strInfo;
        }

        /// <summary>
        /// 销售出库单中有一个以上的主机，是就返回真
        /// </summary>
        /// <param name="saleCode"></param>
        /// <returns></returns>
        private bool IsMaiCount(DataTable dt)
        {
            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            //DataRow[] drs = dt.Select("((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045'");


            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            DataRow[] drs = dt.Select("(cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')");
            if (drs.Length > 1)
                return true;
            else
                return false;
        }

        private void ClientCode_tb_Leave(object sender, EventArgs e)
        {
            if (this.ClientCode_tb.Text.Trim().Length <= 0)
            {
                this.ClientName_tb.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearCondition();
        }


        /// <summary>
        /// 清空条件
        /// </summary>
        private void ClearCondition()
        {
            ChuKuCode_tb.Text = string.Empty;
            ChuKuCode_textBox.Text = string.Empty;
            XShouCode_tb.Text = string.Empty;
            XShouCode_textBox.Text = string.Empty;
            ClientCode_tb.Text = string.Empty;
            ClientName_tb.Text = string.Empty;
            ClientCode_dx.Text = string.Empty;
            ClientName_dx.Text = string.Empty;
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker2.Checked = false;
        }

        private void ChuKuCode_tb_Leave(object sender, EventArgs e)
        {
            if (this.ChuKuCode_tb.Text.Trim().Length <= 0)
            {
                this.ChuKuCode_textBox.Text = string.Empty;
            }
        }

        private void XShouCode_tb_Leave(object sender, EventArgs e)
        {
            if (this.XShouCode_tb.Text.Trim().Length <= 0)
            {
                this.XShouCode_textBox.Text = string.Empty;
            }
        }

        private void flexMain_SelChange(object sender, EventArgs e)
        {
            if (this.flexMain.DataSource != null && this.flexMain.Row >= 0 && this.flexMain.Cols.Contains("ID"))
            {
                this.LoadDisplay(this.flexMain.Rows[this.flexMain.Row]["ID"].ToString(), this.flexMain.Rows[this.flexMain.Row]["U8AccountNum"].ToString());
            }
        }

        /// <summary>
        /// 加载剩余数量
        /// </summary>
        /// <param name="ID"></param>
        private void LoadDisplay(string ID,string U8AccountNum)
        {
            this.flexDisp.DataSource = this.GetSaleRecordDetail(ID, U8AccountNum, true);

            this.flexDisp.Cols["U8AccountNum"].Caption = "U8账套";
            this.flexDisp.Cols["cinvcode"].Caption = "存货编码";
            this.flexDisp.Cols["cinvname"].Caption = "存货名称";
            this.flexDisp.Cols["cEnglishName"].Caption = "英文名";
            this.flexDisp.Cols["cInvStd"].Caption = "规格";
            this.flexDisp.Cols["iquantity"].Caption = "出库数量";
            this.flexDisp.Cols["cinvSN"].Caption = "制造编号";

            this.flexDisp.Cols["qty"].Caption = "安装单已用";
            this.flexDisp.Cols["unQty"].Caption = "剩余可用";

            this.flexDisp.Cols["cSNDefine1"].Caption = "本部发货日期";
            this.flexDisp.Cols["ddate"].Caption = "GC出库日期";
            this.flexDisp.Cols["autoid"].Visible = false;
        }

        private void ClientCode_dx_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            DataRow dr = e.ReturnRow1;
            ClientCode_dx.Text = dr["cCusCode"].ToString();
            ClientName_dx.Text = dr["cCusAbbName"].ToString();
        }

        private void ClientCode_dx_Leave(object sender, EventArgs e)
        {
            if (this.ClientCode_dx.Text.Trim().Length <= 0)
            {
                this.ClientName_dx.Text = string.Empty;
            }
        }

        private void flexDetail_SelChange(object sender, EventArgs e)
        {
            if (this.flexDetail.DataSource != null && this.flexDetail.Row >= 0 && this.flexDetail.Cols.Contains("ID"))
            {
                this.LoadDisplay(this.flexDetail.Rows[this.flexDetail.Row]["ID"].ToString(), this.flexDetail.Rows[this.flexDetail.Row]["U8AccountNum"].ToString());
            }
        }

        /// <summary>
        /// 根据安装单号查找机器级别
        /// </summary>
        /// <param name="taskcode"></param>
        public void DragoutMachineCode(DataTable dtdetail, out string jqjbcode, out string MachineModel, out string MachineLevel, out string MachineType, out string Color, out string tMaiCode, out string aMakeCode, out string ProductLine)
        {
            jqjbcode = "";
            MachineModel = "";
            MachineLevel = "";
            MachineType = "";
            Color = "";
            tMaiCode = "";
            aMakeCode = "";
            ProductLine = "";

            string aAccCode;

            //获取主机的规格型号，否则返回空 aAccCode 为存货编码, aMakeCode为序列号
            GetAccCode(dtdetail, out aAccCode, out aMakeCode);
            if (aAccCode == string.Empty)
                return;

            string sql = string.Format(@"select code,type,grade,model,cinvstd,isnull(productline,'') as productline from BaseMachineGrade where code = '{0}'", aAccCode);
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery(sql);

            if (dtdetail != null && dtdetail.Rows.Count > 0 && dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                //this.txtJiQiJB.Text = dr["code"].ToString();
                //this.MachineLevel.Text = dr["grade"].ToString();
                //this.MachineType.Text = dr["type"].ToString();
                //修改：有两个颜色重复，所以在这里增加绑定
                //this.Color.Text = dr["type"].ToString();
                //string str = dr["type"].ToString();
                jqjbcode = dr["code"].ToString();
                MachineModel = dr["model"].ToString();
                MachineLevel = dr["grade"].ToString();
                MachineType = dr["type"].ToString(); ;
                Color = dr["type"].ToString();
                tMaiCode = dr["cinvstd"].ToString();
                ProductLine = dr["productline"].ToString();
            }
        }

        /// <summary>
        /// 获取主机的规格型号，否则返回空
        /// </summary>
        /// <param name="saleCode"></param>
        /// <returns></returns>
        private void GetAccCode(DataTable dt, out string cinvcode, out string aMakeCode)
        {
            cinvcode = string.Empty;
            aMakeCode = "";

            //Lin 2019_10_23 按客户要求，新增编码：A100045也是主机
            //DataRow[] drs = dt.Select("((cinvcode like 'A%' or cinvcode like 'B%') and cinvcode like '%0001') or cinvcode like 'Z11%' or cinvcode like 'Z21%' or cinvcode='A100045' ");

            //Lin 2020_07_14 新售后系统主机规则要求
            //1】A11,A21,F11,F8101,F8201,G11,G8101,H11,H21,J81,J82
            //2】 B1012015,B1012016,B1012003
            //3】J8101,J8201,K8101,L8101,L8201 客户新增 2021-03-15
            DataRow[] drs = dt.Select("( cinvcode like 'A11%' or cinvcode like 'A21%' or cinvcode like 'F11%' or cinvcode like 'F8101%' or cinvcode like 'F8201%' or cinvcode like 'G11%' or cinvcode like 'G8101%' or cinvcode like 'H11%' or cinvcode like 'H21%' or cinvcode like 'J81%'  or cinvcode like 'J82%' or cinvcode='B1012015' or cinvcode='B1012016' or cinvcode='B1012003' or cinvcode like 'J8101%' or cinvcode like 'J8201%' or cinvcode like 'K8101%' or cinvcode like 'L8101%' or cinvcode like 'L8201%')");
            if (drs.Length > 0)
            {
                cinvcode = drs[0]["cinvcode"].ToString();;
                aMakeCode = drs[0]["cinvSN"].ToString();
            }
        }
    }
}
