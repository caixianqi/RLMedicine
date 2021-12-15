using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bao.Message;
using Bao.BillBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using UFBaseLib.BusLib;
using U8Global;

namespace Repair
{
    public partial class Bill :Bao.BillBase.FrmBillBase,Bao.Interface.IU8Contral
    {
        private FrmLookUp.ButtonEdit MachineCode = new FrmLookUp.ButtonEdit();

        private SaveFileDialog saveFileDialog1;
        private ToolTip tt;
        private ToolTip tt2;

        public Bill()
        {
            InitializeComponent();
            BillId = string.Empty;
            this.BO = new BillBill();
            BO.Init("");
            init();
        }
        public Bill(string id)
        {
            InitializeComponent();
            BillId = id;
            this.BO = new BillBill();
            BO.Init(id);
            init();
            
        }
        public override void toolBarBill1_OnBaoSave(object sender, FrmLookUp.BillUpDateStateEventArgs e)
        {
            this.gridView1.CloseEditor();
            this.gridView1.UpdateCurrentRow();

            this.gridView2.CloseEditor();
            this.gridView2.UpdateCurrentRow();

          

            base.toolBarBill1_OnBaoSave(sender, e);


        }

        private void init()
        {
            //2015-04-14:客户要求，存货不做限制： (cinvcode like 's%' or cinvcode like 'c%' or cinvcode like 'z%' or cinvcode like 'y%' or cinvcode like 'w%' or cinvcode like 'j%')
            MachineCode.BaoSQL = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where 1=1 ";
            MachineCode.BaoTitleNames = "cinvcode=存货编码,cinvname=存货名称,cinvdefine7=英文名称,cInvStd=存货规格";
            this.MachineCode.FrmHigth = 400;
            this.MachineCode.FrmWidth = 750;
            MachineCode.DecideSql = "select cinvcode,cinvname,cEnglishName as cinvdefine7,cInvStd from " + U8DataAcc.U8ServerAndDataBase + ".inventory where cinvcode=";
            MachineCode.BaoColumnsWidth = "cinvcode=100,cinvname=200,cinvdefine7=150,cInvStd=100";
            MachineCode.BaoClickClose = true;
            MachineCode.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(MachineCode_OnLookUpClosed);

            PriceCode.BaoSQL = "select * from Price where UserId = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "' and ( ReviewerID is not null and ReviewerID <>'') and PriceId not in (select PriceId from Bill)";
            PriceCode.BaoTitleNames = "RepairMissionCode=维修任务编码,CustomerName=客户名称,PriceCode=报价单号,InventoryName=主机型号,RepairCost=维修费用,TravelCost=差旅费";
            this.PriceCode.FrmHigth = 400;
            this.PriceCode.FrmWidth = 750;
            PriceCode.DecideSql = "select * from Price where  PriceCode =";
            PriceCode.BaoColumnsWidth = "RepairMissionCode=120,CustomerName=200,PriceCode=120, InventoryName=120,RepairCost=120,TravelCost=120";
            PriceCode.BaoClickClose = true;
            PriceCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(PriceCode_OnLookUpClosed);

            this.button3.Tag = "99999";
            this.button4.Tag = "99999";
            this.button5.Tag = "99999";

            //(Lin 2021-04-17 修改) 日立售后新系统（2021年度需求）
            AuditerCode.BaoSQL = "select u.userName, u.UserId from Users u left join TRoleUsers ru on u.AutoUserId = ru.AutoUserId left join TRole r on ru.RoleId = r.RoleId where r.RoleId = '009'";

            //AuditerCode.BaoSQL于2012-12-06修改
            /*AuditerCode.BaoSQL = string.Format(@"select u.userName, u.UserId from Users u 
                                                                    left join TRoleUsers ru 
                                                                           on u.AutoUserId = ru.AutoUserId 
                                                                    left join TRole r 
                                                                            on ru.RoleId = r.RoleId
			                                        where r.RoleId = '009' 
                                                        and deptNum in 
				                                                            (select b.parentNum from BaseDepartMent b 
											                                                            right join Users u1 
												                                                            on b.deptNum = u1.deptNum 
									                                                            where u1.UserId = '{0}')",UFBaseLib.BusLib.BaseInfo.DBUserID);*/

                //    select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '009'";

            AuditerCode.BaoTitleNames = "userid=人员编码,username=人员姓名";
            AuditerCode.FrmHigth = 400;
            AuditerCode.FrmWidth = 400;
            AuditerCode.DecideSql = "select u.autouserid,userid,username,RoleName,DeptName from users u ,TRole r,TroleUsers ru where u.AutoUserid = ru.AutoUserId and ru.RoleId = r.RoleId  and r.RoleId = '009' and  userid =";
            AuditerCode.BaoColumnsWidth = "userid=150,username=150";

            AuditerCode.BaoClickClose = true;
            AuditerCode.OnLookUpClosed += new FrmLookUp.RiliButtonEdit.LookUpClosed(AuditerCode_OnLookUpClosed);

            /*
             * ----------------------------原始代码--------2012-12-06---------------------------------
             AuditerCode.BaoSQL = string.Format(@"select u.autouserid,u.userid,u.username,r.RoleName,u.DeptName,u.deptNum 
                                        from users u 
                                        left join TroleUsers ru on u.AutoUserid = ru.AutoUserId 
                                        left join TRole r on ru.RoleId = r.RoleId
                                        left join users u1 on u1.deptNum like u.deptNum + '%'
                                        where r.RoleId = '009' and u1.UserId='{0}'",UFBaseLib.BusLib.BaseInfo.DBUserID);
             * -------------------------------------------------------------------------------------------
             */

            //this.toolBarBill1.OnBaoAddLine += new FrmLookUp.ToolBarBill.BaoAddLine(toolBarBill1_OnBaoAddLine);
            //this.toolBarBill1.OnBaoDelLine += new FrmLookUp.ToolBarBill.BaoDelLine(toolBarBill1_OnBaoDelLine);
            
            this.toolBarBill1.OnBaoExcel += new FrmLookUp.ToolBarBill.BaoExcel(toolBarBill1_OnBaoExcel);
            this.toolBarBill1.OnBeforBaoUpdate += new FrmLookUp.ToolBarBill.BeforBaoUpdate(toolBarBill1_OnBeforBaoUpdate);
            this.toolBarBill1.OnAfterBaoSave += new FrmLookUp.ToolBarBill.AfterBaoSave(toolBarBill1_OnAfterBaoSave);
            this.toolBarBill1.OnBaoDelete += new FrmLookUp.ToolBarBill.BaoDelete(toolBarBill1_OnBaoDelete);
            this.toolBarBill1.OnBaoUnAudit += new FrmLookUp.ToolBarBill.BaoUnAudit(toolBarBill1_OnBaoUnAudit);
            this.toolBarBill1.OnBaoAudit += new FrmLookUp.ToolBarBill.BaoAudit(toolBarBill1_OnBaoAudit);

            this.toolBarBill1.tssAddRow.Visible = false;
            this.toolBarBill1.tssAudit.Visible = false;
            this.toolBarBill1.tssPrint.Visible = false;
            this.toolBarBill1.tssUpLoad.Visible = false;
    
            this.toolBarBill1.btnEnd.Visible = false;
          
            this.toolBarBill1.BtnAudit.Visible = true;
            this.toolBarBill1.BtnUnAudit.Visible = true;
            this.toolBarBill1.BtnUpLoad.Visible = false;
            this.toolBarBill1.BtnExcel.Visible = true;
            this.toolBarBill1.BtnAuditList.Visible = false;
            this.toolBarBill1.tssLocation.Visible = false;
            this.toolBarBill1.BtnLocation.Visible = false;
            this.toolBarBill1.BtnUnUpLoad.Visible = false;

            this.RepairMissionCode.Text = string.Empty;

            this.BillType.Text = null;

            if (!(this.BO.EntityTables[0].Table.Rows[0]["PriceId"].ToString() == string.Empty))
            {
                string repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceId ='" + this.BO.EntityTables[0].Table.Rows[0]["PriceId"].ToString() + "'");

                this.RepairMissionCode.Text = repcode;

                this.BillType.Text = this.BO.EntityTables[0].Table.Rows[0]["BillType"].ToString();
                this.BillType.SelectedItem = this.BO.EntityTables[0].Table.Rows[0]["BillType"].ToString();
                this.BillType.SelectedText = this.BO.EntityTables[0].Table.Rows[0]["BillType"].ToString();
                this.BillType.SelectedValue = this.BO.EntityTables[0].Table.Rows[0]["BillType"].ToString();
            }



            if (BO.EntityTables[1].Table.Rows.Count > 0)
            {
                this.gridControl1.DataSource = BO.EntityTables[1].Table;
            }


            if (BO.EntityTables[2].Table.Rows.Count > 0)
            {
                this.gridControl2.DataSource = BO.EntityTables[2].Table;
            }

            if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                this.button3.Text = "提交";
                this.toolBarBill1.BtnUnAudit.Enabled = true;
                this.toolBarBill1.BtnAudit.Enabled = true;
              
            }
            else
            {
                if (this.BO.EntityTables[0].Table.Rows[0]["AuditTime"].ToString() != string.Empty)
                {
                    this.toolBarBill1.BtnAudit.Visible = false;
                    this.toolBarBill1.BtnUnAudit.Visible = true;
                    //this.toolBarBill1.tssAudit
                }
                else
                {
                    this.toolBarBill1.BtnAudit.Visible = true;
                    this.toolBarBill1.BtnUnAudit.Visible = false;
                }
                this.button3.Text = "收回";
                this.toolBarBill1.BtnUnAudit.Enabled = true;
                this.toolBarBill1.BtnAudit.Enabled = true;
               
            }
            if (this.BO.EntityTables[0].Table.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty)
            {
                this.button4.Text = "提交";
            }
            else
            {
                this.button4.Text = "收回";
            }
            if (this.BO.EntityTables[0].Table.Rows[0]["UploadReceivePerson"].ToString() == string.Empty)
            {
                this.button5.Text = "提交";
            }
            else
            {
                this.button5.Text = "收回";
                

            }

            this.RoleControl();
        }

        void toolBarBill1_OnBaoAudit(object sender, EventArgs e)
        {
            if (this.BO.BillId.Length > 0)
            {
                string id = this.BO.BillId;
                Repair.Bill ff = new Bill(id);
                ff.MdiParent = this.MdiParent;

                this.Hide();

                ff.Show();

                this.Close();
            }
          

           // this.toolBarBill1_OnBaoCancel(null, null);
        }

        void toolBarBill1_OnBaoUnAudit(object sender, EventArgs e)
        {
            this.toolBarBill1_OnBaoAudit(null, null);
        }

       
        void toolBarBill1_OnBaoDelete(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = null;
            this.gridControl2.DataSource = null;
        }

        void toolBarBill1_OnAfterBaoSave(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
            this.button5.Enabled = true;
            this.button4.Enabled = true;
        }
        void AuditerCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            this.AuditerCode.BaoBtnCaption = e.ReturnRow1["userid"].ToString();
            this.AuditerName.Text = e.ReturnRow1["username"].ToString();
        }

        void toolBarBill1_OnBeforBaoUpdate(object sender, EventArgs e)
        {
            if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            {
                toolBarBill1.BtnAddRow.Enabled = true;
                toolBarBill1.BtnDeleteRow.Enabled = true;
            }
            else
            {
                toolBarBill1.BtnAddRow.Enabled = false;
                toolBarBill1.BtnDeleteRow.Enabled = false;
            }
        }

        void toolBarBill1_OnBaoExcel(object sender, EventArgs e)
        {
            try
            {
                RiLiGlobal.ExcelLib ex = new RiLiGlobal.ExcelLib(AppDomain.CurrentDomain.BaseDirectory + "RptTemplet\\开票申请.xls");

                string repcode = RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select RepairMissionCode from Price where PriceId ='" + this.BO.EntityTables[0].Table.Rows[0]["PriceId"].ToString() + "'");
                ex.SetCellValue(6, 7, this.RepairMissionCode.Text);
                ex.SetCellValue(8, 7, this.BillType.Text);

                ex.SetCellValue(10, 7, this.BillTitle.Text);
                ex.SetCellValue(10, 34, this.TaxRegNum.Text);
                ex.SetCellValue(12, 7, this.BankName.Text);
                ex.SetCellValue(12, 34, "'" + this.BankAccount.Text.ToString());
                ex.SetCellValue(14, 14, this.CompanyProvince.Text + " " + this.CompanyArea.Text + " " + this.CompanyAddress.Text + "/" + this.AreaCode.Text + "-" + this.Number.Text);

                decimal amount = 0;
                int k = this.BO.EntityTables[1].Table.Rows.Count;
                if (this.BO.EntityTables[1].Table.Rows.Count > 0)
                {
                    decimal money;
                    for (int i = 0; i < this.BO.EntityTables[1].Table.Rows.Count; i++)
                    {
                        ex.InsertRow(19 + i, 1);

                        ex.UniteCells(19 + i, 1, 19 + i, 8);
                        ex.SetCellValue(19 + i, 1, this.BO.EntityTables[1].Table.Rows[i]["InventoryCode"]);

                        ex.UniteCells(19 + i, 9, 19 + i, 21);
                        ex.SetCellValue(19 + i, 9, this.BO.EntityTables[1].Table.Rows[i]["InventoryName"]);

                        ex.UniteCells(19 + i, 22, 19 + i, 31);
                        ex.SetCellValue(19 + i, 22, this.BO.EntityTables[1].Table.Rows[i]["InventoryStd"]);

                        ex.UniteCells(19 + i, 32, 19 + i, 34);
                        ex.SetCellValue(19 + i, 32, this.BO.EntityTables[1].Table.Rows[i]["InventoryEngName"]);

                        ex.UniteCells(19 + i, 35, 19 + i, 40);
                        ex.SetCellValue(19 + i, 35, this.BO.EntityTables[1].Table.Rows[i]["iquantity"]);

                        ex.UniteCells(19 + i, 41, 19 + i, 46);
                        ex.SetCellValue(19 + i, 41, this.BO.EntityTables[1].Table.Rows[i]["money"]);
                    }
                }
                if (RepairCost.Text.Trim().Length > 0)
                {
                    ex.InsertRow(19 + k, 1);

                    ex.UniteCells(19 + k, 1, 19 + k, 8);
                    ex.UniteCells(19 + k, 9, 19 + k, 21);
                    ex.UniteCells(19 + k, 22, 19 + k, 31);
                    ex.UniteCells(19 + k, 32, 19 + k, 34);
                    ex.UniteCells(19 + k, 35, 19 + k, 40);
                    ex.UniteCells(19 + k, 41, 19 + k, 46);

                    ex.SetCellValue(19 + k, 9, "维修费");
                    //ex.SetCellValue(19 + k, 26, this.BO.EntityTables[1].Table.Rows[i]["iquantity"]);
                    ex.SetCellValue(19 + k, 41, RepairCost.Text.Trim());
                    amount += Convert.ToDecimal(RepairCost.Text.Trim());
                    k++;
                }
                if (TravelCost.Text.Trim().Length > 0)
                {
                    ex.InsertRow(19 + k, 1);

                    ex.UniteCells(19 + k, 1, 19 + k, 8);
                    ex.UniteCells(19 + k, 9, 19 + k, 21);
                    ex.UniteCells(19 + k, 22, 19 + k, 31);
                    ex.UniteCells(19 + k, 32, 19 + k, 34);
                    ex.UniteCells(19 + k, 35, 19 + k, 40);
                    ex.UniteCells(19 + k, 41, 19 + k, 46);

                    ex.SetCellValue(19 + k, 9, "差旅费");
                    //ex.SetCellValue(19 + k, 26, this.BO.EntityTables[1].Table.Rows[i]["iquantity"]);
                    ex.SetCellValue(19 + k, 41, TravelCost.Text.Trim());
                    amount += Convert.ToDecimal(TravelCost.Text.Trim());
                    k++;
                }
                if (this.BO.EntityTables[1].Table.Rows.Count > 0)
                    amount += decimal.Parse(this.BO.EntityTables[1].Table.Compute("sum(money)", string.Empty).ToString());
                ex.SetCellValue(20 + k, 11, CmycurD(amount));
                ex.SetCellValue(20 + k, 35, Decimal.Round(amount, 2).ToString() + "元");
                ex.SetCellValue(22 + k, 11, this.SendBillProvince.Text + " " + this.SendBillArea.Text + " " + this.SendBillAddress.Text);
                ex.SetCellValue(24 + k, 5, this.ZipCode.Text);
                ex.SetCellValue(24 + k, 24, this.ReceivePerson.Text);
                ex.SetCellValue(24 + k, 41, this.ContractAreaCode.Text + "-" + this.ContractNum.Text);
                ex.SetCellValue(26 + k, 5, this.Remarks.Text);

                ex.SetCellValue(28 + k, 8, this.AppPerson.Text);




                this.saveFileDialog1 = new SaveFileDialog();
                this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";


                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    ex.Save(saveFileDialog1.FileName);
                    ex.CloseExcel();
                    MessageBox.Show("单据导出成功！");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以tr2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

//        void toolBarBill1_OnBaoDelLine(object sender, EventArgs e)
//        {
//            this.gridView1.DeleteSelectedRows();
//            this.gridView1.RefreshData();
//        }

//        void toolBarBill1_OnBaoAddLine(object sender, EventArgs e)
//        {
//            BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null, 0, 0);
//            this.gridControl1.DataSource = BO.EntityTables[1].Table;
//        }

        void PriceCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {

            this.PriceCode.BaoBtnCaption = e.ReturnRow1["PriceCode"].ToString();
            this.PriceID.Text = e.ReturnRow1["PriceID"].ToString();
            this.BO.TempId = e.ReturnRow1["PriceID"].ToString();
            this.RepairMissionCode.Text = e.ReturnRow1["RepairMissionCode"].ToString();
            this.TaxRegNum.Text = e.ReturnRow1["TaxRegistrationNumber"].ToString();
            this.BankAccount.Text = e.ReturnRow1["Account"].ToString();
            this.BankName.Text = e.ReturnRow1["BankName"].ToString();
            this.RepairCost.Text = e.ReturnRow1["RepairCost"].ToString();
            this.TravelCost.Text = e.ReturnRow1["TravelCost"].ToString();

            AuditerCode.BaoSQL = string.Format(@"select distinct u.userName, u.UserId 
	                                                from Users u 
	                                                left join TRoleUsers ru   on u.AutoUserId = ru.AutoUserId 
	                                                left join TRole r on ru.RoleId = r.RoleId
	                                                left join RegionToProvince r1 on r1.deptNum like u.deptNum + '%'
	                                                left join RepairMission r2 on r2.City = r1.ProvinceName
	                                                where r.RoleId = '009' and r2.RepairMissionCode = '{0}'", this.RepairMissionCode.Text);

            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from PriceDetails where PriceID = '" + e.ReturnRow1["PriceID"].ToString() + "'");

            CopyTable(dt);
        }

        /// <summary>
        /// 从报价单的配件表复制到开票申请的配件表上
        /// </summary>
        /// <param name="dt"></param>
        private void CopyTable(DataTable dt)
        {
            if (dt == null && dt.Rows.Count <= 0)
                return;

            foreach(DataRow dr in dt.Rows)
                BO.EntityTables[1].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId, null,
                                                        dr["InventoryNum"].ToString(), dr["Money"].ToString(),
                                                            dr["InventoryCode"].ToString(), dr["InventoryName"].ToString(),
                                                                dr["InventoryStd"].ToString(), dr["InventoryEngName"].ToString());

            this.gridControl1.DataSource = BO.EntityTables[1].Table;
        }

        public override void BaoDataBinding()
        {
            base.BaoDataBinding();
            this.PriceCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "PriceCode");
            
            this.PriceID.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "PriceID");
            this.BillType.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BillType");

            this.BillType.DataBindings.Add("SelectedValue", this.BO.EntityTables[0].Table, "BillType");
            this.BillType.DataBindings.Add("SelectedItem", BO.EntityTables[0].Table, "BillType");
      
          

            this.AppPerson.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AppPerson");
            this.SerialNumber.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SerialNumber");
            this.BillTitle.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BillTitle");
            this.TaxRegNum.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "TaxRegNum");
            this.BankName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BankName");
            this.BankAccount.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BankAccount");
            this.RepairCost.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "RepairCost");
            this.TravelCost.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "TravelCost");
            this.CompanyAddress.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CompanyAddress");
            this.CompanyArea.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CompanyArea");
            this.CompanyProvince.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "CompanyProvince");
            this.Number.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "Number");
            this.AreaCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AreaCode");
            this.SendBillAddress.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SendBillAddress");
            this.SendBillArea.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SendBillArea");
            this.SendBillProvince.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SendBillProvince");
            this.ContractNum.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ContractNum");
            this.ContractAreaCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ContractAreaCode");
            this.ReceivePerson.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ReceivePerson");
            this.AuditerName.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "AuditerName");
            this.AuditerCode.DataBindings.Add("BaoBtnCaption", this.BO.EntityTables[0].Table, "AuditerCode");
            this.ZipCode.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "ZipCode");
            this.Remarks.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "Remarks");
            this.BillNum.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "BillNum");
            this.EMSNum.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "EMSNum");
            this.SendBillDate.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SendBillDate");
            this.SendBillRemarks.DataBindings.Add("Text", this.BO.EntityTables[0].Table, "SendBillRemarks");
         
        }


        public override void BaoUnDataBinding()
        {
            base.BaoUnDataBinding();
            foreach (Control item in this.GroupBox1.Controls)
            {
                item.DataBindings.Clear();
            }

            foreach (Control item in this.groupBox2.Controls)
            {
                item.DataBindings.Clear();
            }
            foreach (Control item in this.groupBox3.Controls)
            {
                item.DataBindings.Clear();
            }

           
        }
        #region IU8Contral 成员

        public void Authorization()
        {
           
        }

        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BO.EntityTables[2].Table.Rows.Add(Guid.NewGuid().ToString(), BO.BillId,  RiLiGlobal.RiLiDataAcc.GetNow().ToShortDateString(), 0, null);
            this.gridControl2.DataSource = BO.EntityTables[2].Table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.gridView2.DeleteSelectedRows();
            this.gridView2.RefreshData();
        }

        public override void NewButtonAfter()
        {
            base.NewButtonAfter();

            this.button3.Text = "提交";
            this.button4.Text = "提交";
            this.button5.Text = "提交";
            this.gridControl1.DataSource = null;
            this.gridControl2.DataSource = null;
            foreach (Control item in this.GroupBox1.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox2.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox3.Controls)
            {

                item.Enabled = false;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {

                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = true;
                }
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
            {

                foreach (Control item in this.groupBox2.Controls)
                {

                    item.Enabled = true;
                }
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
            {


                foreach (Control item in this.groupBox3.Controls)
                {

                    item.Enabled = true;
                }
            }
        }

        public override void NewButtonBefor()
        {
            BO.BillId = Guid.NewGuid().ToString();
        }

        public override void UpdateButtonBefor()
        {
            base.UpdateButtonBefor();

            foreach (Control item in this.GroupBox1.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox2.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox3.Controls)
            {

                item.Enabled = false;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {

                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = true;
                }
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
            {

                foreach (Control item in this.groupBox2.Controls)
                {

                    item.Enabled = true;
                }
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
            {


                foreach (Control item in this.groupBox3.Controls)
                {

                    item.Enabled = true;
                }
            }
            this.button3.Enabled = true;
            this.button5.Enabled = true;
            this.button4.Enabled = true;
        }

        public override void UpdateButtonAfter()
        {
            base.UpdateButtonAfter();

          
            toolBarBill1.BtnAddRow.Enabled = false;
            toolBarBill1.BtnDeleteRow.Enabled = false;
            foreach (Control item in this.GroupBox1.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox2.Controls)
            {

                item.Enabled = false;
            }
            foreach (Control item in this.groupBox3.Controls)
            {

                item.Enabled = false;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {

                foreach (Control item in this.GroupBox1.Controls)
                {
                 
                    item.Enabled = true;
                }
               

            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("007"))
            {

                foreach (Control item in this.groupBox2.Controls)
                {

                    item.Enabled = true;
                }
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
            {


                foreach (Control item in this.groupBox3.Controls)
                {

                    item.Enabled = true;
                }
            }


            DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from bill where billid = '" + this.BO.BillId + "'");
            //如果已经开票，则UploadPerson不为空，但是[UploadSendBillPerson]为空，第二个亮起，其他关闭，除了按钮
            if (!(dt.Rows[0]["UploadPerson"].ToString() == string.Empty) && dt.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty)
            {
                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = false;
                }
                //foreach (Control item in this.groupBox3.Controls)
                //{

                //    item.Enabled = false;
                //}


            }
            //如果已经寄票，则

         
            if (!(dt.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty) && dt.Rows[0]["UploadReceivePerson"].ToString() == string.Empty)
            {
                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = false;
                }
                foreach (Control item in this.groupBox2.Controls)
                {

                    item.Enabled = false;
                }
            }




            if (dt.Rows[0]["BillState"].ToString() == "到款")
            {
                foreach (Control item in this.groupBox3.Controls)
                {

                    item.Enabled = false;
                }
                foreach (Control item in this.groupBox2.Controls)
                {

                    item.Enabled = false;
                }
                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = false;
                }

                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        public void RoleControl()
        {
            //工程师

            this.toolBarBill1.BtnAddRow.Visible = false;
            this.toolBarBill1.BtnDeleteRow.Visible = false;

            this.toolBarBill1.BtnAddNew.Visible = false;
            foreach (Control item in this.GroupBox1.Controls)
            {
               
                item.Enabled = false;
            }
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;

            foreach (Control item in this.groupBox2.Controls)
            {
               
                item.Enabled = false;
            }
            foreach (Control item in this.groupBox3.Controls)
            {
               
                item.Enabled = false;
            }

            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("003"))
            {
             
               
                this.button3.Visible = true;

                this.toolBarBill1.BtnAddNew.Visible = true;
            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
            {

               
                this.button4.Visible = true;

            }
            if (UFBaseLib.BusLib.BaseInfo.userRole.Contains("001"))
            {


                

                this.button5.Visible = true;
            }

            if (!(this.BO.BillId == string.Empty))
            {
                DataTable dt = RiLiGlobal.RiLiDataAcc.RiLiExecuteQuery("select * from bill where billid = '" + this.BO.BillId + "'");

                //如果已经开票，则UploadPerson不为空，但是[UploadSendBillPerson]为空，第二个亮起，其他关闭，除了按钮
                if (!(dt.Rows[0]["UploadPerson"].ToString() == string.Empty) && dt.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty)
                {
                    foreach (Control item in this.GroupBox1.Controls)
                    {

                        item.Enabled = false;
                    }
                    foreach (Control item in this.groupBox3.Controls)
                    {

                        item.Enabled = false;
                    }


                }
                //如果已经寄票，则
                if (!(dt.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty) && dt.Rows[0]["UploadReceivePerson"].ToString() == string.Empty)
                {
                    foreach (Control item in this.GroupBox1.Controls)
                    {

                        item.Enabled = false;
                    }
                    foreach (Control item in this.groupBox2.Controls)
                    {

                        item.Enabled = false;
                    }
                }




                if (dt.Rows[0]["BillState"].ToString() == "到款")
                {
                    foreach (Control item in this.groupBox3.Controls)
                    {

                        item.Enabled = false;
                    }
                    foreach (Control item in this.groupBox2.Controls)
                    {

                        item.Enabled = false;
                    }
                    foreach (Control item in this.GroupBox1.Controls)
                    {

                        item.Enabled = false;
                    }

                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.button5.Enabled = true;
                }
            }
            //if (this.BO.EntityTables[0].Table.Rows[0]["UploadReceivePerson"].ToString() == string.Empty && !(this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty))
            //{
            //    foreach (Control item in this.GroupBox1.Controls)
            //    {

            //        item.Enabled = false;
            //    }
            //}
            // if (this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString() == string.Empty)
            //{
            //    foreach (Control item in this.groupBox2.Controls)
            //    {

            //        item.Enabled = false;
            //    }
            //    foreach (Control item in this.groupBox3.Controls)
            //    {

            //        item.Enabled = false;
            //    }
            //}

            //黄欣

            //800客服
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }

        private bool BillCommit1()
        {
            if (RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Bill where BillID = '" + this.BO.BillId + "'").Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("未保存，不能提交");
                return false;
            }
            if (this.AuditerName.Text == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("未指定客服部长，不能提交");
                return false;
            }
            string sql = @"select 1 from PartsApplication a 
                        left join PartsInventory b on a.PartsApplicationID = b.PartsApplicationID
                        where a.RepairMissionCode = '" + this.RepairMissionCode.Text + "' and isnull(StateReturn,'') <> '归还完成'";

            if (Bao.DataAccess.DataAcc.ExecuteScalar(sql).Length > 0)
            {
                System.Windows.Forms.MessageBox.Show("配件申请，有未归还情况，不能提交");
                return false;
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (this.toolBarBill1.BtnSave.Enabled)
            {

                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }

            RiLiGlobal.RiLiDataAcc.IsEnd(this.RepairMissionCode.Text);
           
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Bill where BillID = '" + this.BO.BillId + "'");

            if (!(dt.Rows[0]["AppPersonId"].ToString() == UFBaseLib.BusLib.BaseInfo.DBUserID))
            {
                System.Windows.Forms.MessageBox.Show("您没有权限");
                return;
            }

         
            if (this.button3.Text == "提交")
            {
                
               
                if (!BillCommit1())
                    return;
                //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "开票申请";
                //this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                //this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                //this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"] = this.AuditerCode.Text;
                //this.BO.EntityTables[0].Table.Rows[0]["AuditerName"] = this.AuditerName.Text;
                
                //this.BO.UpdateSave();

                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '开票申请',UploadPerson = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',UploadDate = getdate(),AuditerCode = '" + this.AuditerCode.Text + "',AuditerName = '" + this.AuditerName.Text + "' where BillID = '" + this.BO.BillId + "'");

                

                foreach (Control item in this.GroupBox1.Controls)
                {

                    item.Enabled = false;
                }
                this.button3.Enabled = true;
                //发消息给指定的部长
                CMessage.SendMessage("开票申请", "工程师提交了开票申请，请处理", this.BO.EntityTables[0].Table.Rows[0]["AuditerCode"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);

                System.Windows.Forms.MessageBox.Show("提交成功,信息发至[" + AuditerName.Text + "]!");

                CtrEnable(false);

                this.toolBarBill1.BtnSave.Enabled = false;
                this.button3.Text = "收回";

                // CMessage.SendMessage("新维修任务", "有新的维修任务，指派工程师", userid, UFBaseLib.BusLib.BaseInfo.DBUserID, "Rep001", this.BO.BillId);

               // CMessage.SendMessageToRoleNoDepartment("开票申请", "工程师提交了开票申请，请处理", "007", UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);

               // CMessage.SendMessage("开票申请", "工程师提交了开票申请，请处理", "huangxin", UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);
            }
            else
            {
                //寄票信息已经填写
                if (dt.Rows[0]["BillState"].ToString() == "开票申请")
                {
                    //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "开票申请";
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = null;
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadDate"] = DBNull.Value;

                    //this.BO.UpdateSave();



                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '开票申请',UploadPerson = null,UploadDate = null  where BillID = '" + this.BO.BillId + "'");

                    this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"] = null;

                    System.Windows.Forms.MessageBox.Show("收回成功,信息发至[" + AuditerName.Text + "]!");
                    this.button3.Text = "提交";
                    
                }
                else
                {
                    throw new Exception("开票申请已经被部长审核，无法收回");
                }
            }

            RoleControl();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {

                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }
            RiLiGlobal.RiLiDataAcc.IsEnd(this.RepairMissionCode.Text);
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Bill where BillID = '" + this.BO.BillId + "'");
            if (this.button4.Text == "提交")
            {
                if (BillNum.Text == string.Empty || EMSNum.Text == string.Empty)
                {

                    System.Windows.Forms.MessageBox.Show("请填写好寄票信息");
                    return;
                }

                if (dt.Rows[0]["BillState"].ToString() == "审核通过")
                {


                    //this.BO.EntityTables[0].Table.Rows[0]["UploadSendBillPerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadSendBillDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                    //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "寄票";
                    //this.BO.UpdateSave();

                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '寄票',UploadSendBillPerson = '" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',UploadSendBillDate = '" + this.SendBillDate.Value.ToString("yyyy-MM-dd hh:ss") + "'  where BillID = '" + this.BO.BillId + "'");

                    // CMessage.SendMessageToRoleNoDepartment("开票申请", "助理填写了寄票信息，请处理","001", UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);

                    CMessage.SendMessage("开票申请", "助理填写了寄票信息，请催款", this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);
                    System.Windows.Forms.MessageBox.Show("提交成功,信息发至[" + AppPerson.Text + "]!");

                    CtrEnable(false);

                    this.toolBarBill1.BtnSave.Enabled = false;

                    this.button4.Text = "收回";

                    foreach (Control item in this.groupBox2.Controls)
                    {

                        item.Enabled = false;
                    }
                    this.button4.Enabled = true;
                }
                else
                {
                    throw new Exception("发票未审核，不能提交寄票信息");

                }
            }
            else
            {
                //寄票信息未填写
                if (dt.Rows[0]["UploadReceivePerson"].ToString() == string.Empty)
                {
                    //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "审核通过";
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadSendBillPerson"] = string.Empty;
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadSendBillDate"] = DBNull.Value;
                 
                  
                    //this.BO.UpdateSave();

                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '审核通过',UploadSendBillPerson =null,UploadSendBillDate = null  where BillID = '" + this.BO.BillId + "'");

                    System.Windows.Forms.MessageBox.Show("收回成功");
                    this.button4.Text = "提交";
                    CtrEnable(false);
                }
                else
                {
                    throw new Exception("收款信息已经填写,无法收回");
                }
            }
            RoleControl();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.toolBarBill1.BtnSave.Enabled)
            {

                System.Windows.Forms.MessageBox.Show("请先保存再做操作");
                return;
            }
            DataTable dt = RiLiGlobal.RiLiDataAcc.ExecuteQuery("select * from Bill where BillID = '" + this.BO.BillId + "'");
            RiLiGlobal.RiLiDataAcc.IsEnd(this.RepairMissionCode.Text);
            if (this.button5.Text == "提交")
            {
                if (dt.Rows[0]["UploadPerson"].ToString() == string.Empty)
                {
                    throw new Exception("发票申请未提交，不能提交收款纪录");
                }

                if (dt.Rows[0]["UploadSendBillPerson"].ToString() == string.Empty)
                {
                    throw new Exception("未填写寄票信息或已经被收回，不能提交");
                }
                decimal repair_travel_money = 0;
                decimal appmoney = 0;
                decimal remoney = 0;
                decimal.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("  select SUM(RepairCost) + SUM(TravelCost) from Bill where BillID = '" + this.BO.BillId + "'"), out repair_travel_money);
                decimal.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select sum(money) from BillDetails where BillID = '"+this.BO.BillId+"'"),out appmoney);
                decimal.TryParse(RiLiGlobal.RiLiDataAcc.RiLiExecuteScalar("select sum(money) from MoneyReceive where BillID = '" + this.BO.BillId + "'"), out remoney);
                 if (!(appmoney + repair_travel_money == remoney))
                 {
                     throw new Exception("到款金额不等于申请金额，不能提交");
                 }
                //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "到款";


                //this.BO.EntityTables[0].Table.Rows[0]["UploadReceivePerson"] = UFBaseLib.BusLib.BaseInfo.DBUserID;
                //this.BO.EntityTables[0].Table.Rows[0]["UploadReceiveDate"] =  RiLiGlobal.RiLiDataAcc.GetNow();
                //this.BO.UpdateSave();

                RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '到款',UploadReceivePerson ='" + UFBaseLib.BusLib.BaseInfo.DBUserID + "',UploadReceiveDate = getdate()  where BillID = '" + this.BO.BillId + "'");

                System.Windows.Forms.MessageBox.Show("提交成功");

                CMessage.SendMessage("已经到款", "该张发票已经到款", this.BO.EntityTables[0].Table.Rows[0]["UploadPerson"].ToString(), UFBaseLib.BusLib.BaseInfo.UserId, "Bil001", this.BO.BillId);
                
                this.button5.Text = "收回";
                foreach (Control item in this.groupBox3.Controls)
                {

                    item.Enabled = false;
                }
                this.button5.Enabled = true;

            }
            else
            {

                    //this.BO.EntityTables[0].Table.Rows[0]["BillState"] = "寄票";
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadReceivePerson"] = string.Empty;
                    //this.BO.EntityTables[0].Table.Rows[0]["UploadReceiveDate"] = DBNull.Value;
                   

                    //this.BO.UpdateSave();


                    RiLiGlobal.RiLiDataAcc.RiLiExecuteNotQuery("Update Bill set BillState = '寄票',UploadReceivePerson =null,UploadReceiveDate = null  where BillID = '" + this.BO.BillId + "'");

                    System.Windows.Forms.MessageBox.Show("收回成功");
                    this.button5.Text = "提交";

               
            }
            RoleControl();
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PriceCode_OnLookUpClosed_1(object sender, FrmLookUp.LookUpEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tt != null)
                {
                    tt.Dispose();
                    tt = null;
                    return;

                }
                tt = new ToolTip();
                tt.ShowAlways = true;

                tt.Show(Remarks.Text, Remarks);

                if (tt2 != null)
                {
                    tt2.Dispose();
                    tt2 = null;
                    return;

                }
                tt2 = new ToolTip();
                tt2.ShowAlways = true;


                tt2.Show(SendBillRemarks.Text, SendBillRemarks);
            }
        }

        void MachineCode_OnLookUpClosed(object sender, FrmLookUp.LookUpEventArgs e)
        {
            int rowid = int.Parse(MachineCode.CodeValue.ToString());
            this.gridView1.SetRowCellValue(rowid, "InventoryCode", e.ReturnRow1["cinvcode"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryName", e.ReturnRow1["cinvname"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryStd", e.ReturnRow1["cInvStd"].ToString());

            this.gridView1.SetRowCellValue(rowid, "InventoryEngName", e.ReturnRow1["cinvdefine7"].ToString());

            this.gridView1.SetRowCellValue(rowid, "iquantity", 1);
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
//            GridView gv = ((GridControl)sender).MainView as GridView;
//            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gv.CalcHitInfo(new Point(e.X, e.Y));
//            if (((e.Button & MouseButtons.Left) != 0) && (hInfo.InRow) && (!gv.IsGroupRow(hInfo.RowHandle)) && (!gv.IsFilterRow(hInfo.RowHandle)))
//           {
//                if (hInfo.InRowCell)
//                {
                    //判断光标是否在行范围内

//                    if (this.toolBarBill1.BtnModify.Enabled == false)
//                    {

//                        if (hInfo.Column.FieldName == "InventoryName" || hInfo.Column.FieldName == "InventoryStd" || hInfo.Column.FieldName == "InventoryEngName" || hInfo.Column.FieldName == "InventoryCode")
//                        {
                            //this.cVenCode.ShowRef();

                            //if (!(this.cVenCode.Text == string.Empty))
                            //{
                            //    gv.SetRowCellValue(hInfo.RowHandle, "FactoryCode", this.cVenCode.Text);

                            //    gv.SetRowCellValue(hInfo.RowHandle, "FactoryName", this.cVenCode.DisplayText);
                            //}
                            //this.MachineCode.LookForm = new FrmLookUp.FrmLookUpBase();

                            //this.MachineCode.LookForm.ShowDialog();
//                            this.MachineCode.CodeValue = hInfo.RowHandle.ToString();

//                            this.MachineCode.ShowForm();
//                       }
//                  }
//               }

//            }
        }
    }
}
