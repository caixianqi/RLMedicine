using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using U8Global;

namespace Install
{
    public partial class RPInstallImport : Bao.FormChildBase, Bao.Interface.IU8Contral
    {
        private string U8DataBaseName = string.Empty;
        private DataTable InstallTask_Excel;
        private DataTable InsAccessory_Excel;
        private DataTable InsAccessoryOld_Excel;
        private DataTable InsDetail_Excel;

        DataTable Faildt = new DataTable(); //记录不合法败的数据
      


        public RPInstallImport()
        {
            InitializeComponent();

            U8DataBaseName = U8Global.U8DataAcc.U8ServerAndDataBase;
        }

        public void Authorization()
        {

        }

        /// <summary>
        /// 安装单上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstallTask_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel2007(*.xlsx)|*.xlsx|Excel2003(*.xls)|*.xls|Excel(*.csv)|*.csv";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
                {
                    if (openFileDialog1.FileName.IndexOf("安装单模板") < 0)
                    {
                        this.txtInstallTask.Text = "";
                        MessageBox.Show("上传的模板错误，请检查是否安装单模板");
                        return;
                    }

                    //RiLiGlobal.ExcelReader xlsreader = new RiLiGlobal.ExcelReader();
                    //InstallTask_Excel = xlsreader.ReadFile(openFileDialog1.FileName.Trim());

                    InstallTask_Excel = RiLiGlobal.NPOIExcel.ImportExcelFile2007(openFileDialog1.FileName.Trim());

                    if (InstallTask_Excel.Rows.Count > 0)
                    {
                        //检查模板格式
                        if (InstallTask_Excel.Columns.Contains("新任务编号") && InstallTask_Excel.Columns.Contains("安装类型") && InstallTask_Excel.Columns.Contains("任务状态") && InstallTask_Excel.Columns.Contains("销售代理店编码") && InstallTask_Excel.Columns.Contains("编码") && InstallTask_Excel.Columns.Contains("客户编码") && InstallTask_Excel.Columns.Contains("制造编号"))
                        {
                            this.txtInstallTask.Text = openFileDialog1.FileName.Trim();
                        }
                        else
                        {
                            this.txtInstallTask.Text = "";
                            MessageBox.Show("上传的模板数据格式错误，请检查数据格式");
                        }
                    }
                    else
                    {
                        this.txtInstallTask.Text = "";
                        MessageBox.Show("上传的模板没任何数据");
                    }


                }
                else
                {
                    this.txtInstallTask.Text = "";
                    MessageBox.Show("请选择要上传的模板数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("原因:" + ex.Message, "错误提示");
            }
        }

        /// <summary>
        /// 安装配件明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsAccessory_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.Filter = "Excel2007(*.xlsx)|*.xlsx|Excel2003(*.xls)|*.xls|Excel(*.csv)|*.csv";

            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK && openFileDialog2.FileName != "")
                {
                    if (openFileDialog2.FileName.IndexOf("安装配件明细模板") < 0)
                    {
                        this.txtInsAccessory.Text = "";
                        MessageBox.Show("上传的模板错误，请检查是否安装配件明细模板");
                        return;
                    }

                    //RiLiGlobal.ExcelReader xlsreader = new RiLiGlobal.ExcelReader();
                    //InsAccessory_Excel = xlsreader.ReadFile(openFileDialog2.FileName.Trim());
                    InsAccessory_Excel = RiLiGlobal.NPOIExcel.ImportExcelFile2007(openFileDialog2.FileName.Trim());

                    if (InsAccessory_Excel.Rows.Count > 0)
                    {
                        //检查模板格式
                        if (InsAccessory_Excel.Columns.Contains("新任务编码") && InsAccessory_Excel.Columns.Contains("配件编号") && InsAccessory_Excel.Columns.Contains("制造编号") && InsAccessory_Excel.Columns.Contains("GC出库日期"))
                        {
                            this.txtInsAccessory.Text = openFileDialog2.FileName.Trim();
                        }
                        else
                        {
                            this.txtInsAccessory.Text = "";
                            MessageBox.Show("上传的模板数据格式错误，请检查数据格式");
                        }
                    }
                    else
                    {
                        this.txtInsAccessory.Text = "";
                        MessageBox.Show("上传的模板没任何数据");
                    }


                }
                else
                {
                    this.txtInsAccessory.Text = "";
                    MessageBox.Show("请选择要上传的模板数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("原因:" + ex.Message, "错误提示");
            }
        }

        /// <summary>
        /// 安装销售出库明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsAccessoryOld_Click(object sender, EventArgs e)
        {
            //客户要求取消安装销售出库明细

           /* openFileDialog3.FileName = "";
            openFileDialog3.Filter = "Excel2007(*.xlsx)|*.xlsx|Excel2003(*.xls)|*.xls|Excel(*.csv)|*.csv";

            try
            {
                if (openFileDialog3.ShowDialog() == DialogResult.OK && openFileDialog3.FileName != "")
                {
                    if (openFileDialog3.FileName.IndexOf("安装销售出库单模板") < 0)
                    {
                        this.txtInsAccessoryOld.Text = "";
                        MessageBox.Show("上传的模板错误，请检查是否安装销售出库单模板");
                        return;
                    }

                    RiLiGlobal.ExcelReader xlsreader = new RiLiGlobal.ExcelReader();
                    InsAccessoryOld_Excel = xlsreader.ReadFile(openFileDialog3.FileName.Trim());
                    if (InsAccessoryOld_Excel.Rows.Count > 0)
                    {
                        //检查模板格式
                        if (InsAccessoryOld_Excel.Columns.Contains("任务编号") && InsAccessoryOld_Excel.Columns.Contains("新任务编号") && InsAccessoryOld_Excel.Columns.Contains("配件编号") && InsAccessoryOld_Excel.Columns.Contains("制造编号") && InsAccessoryOld_Excel.Columns.Contains("GC出库日期"))
                        {
                            this.txtInsAccessoryOld.Text = openFileDialog3.FileName.Trim();
                        }
                        else
                        {
                            this.txtInsAccessoryOld.Text = "";
                            MessageBox.Show("上传的模板数据格式错误，请检查数据格式");
                        }
                    }
                    else
                    {
                        this.txtInsAccessoryOld.Text = "";
                        MessageBox.Show("上传的模板没任何数据");
                    }


                }
                else
                {
                    this.txtInsAccessoryOld.Text = "";
                    MessageBox.Show("请选择要上传的模板数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("原因:" + ex.Message, "错误提示");
            }*/

        }

        /// <summary>
        /// 任务反馈明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsDetail_Click(object sender, EventArgs e)
        {
            openFileDialog4.FileName = "";
            openFileDialog4.Filter = "Excel2007(*.xlsx)|*.xlsx|Excel2003(*.xls)|*.xls|Excel(*.csv)|*.csv";

            try
            {
                if (openFileDialog4.ShowDialog() == DialogResult.OK && openFileDialog4.FileName != "")
                {
                    if (openFileDialog4.FileName.IndexOf("安装任务反馈明细模板") < 0)
                    {
                        this.txtInsDetail.Text = "";
                        MessageBox.Show("上传的模板错误，请检查是否安装任务反馈明细模板");
                        return;
                    }

                    //RiLiGlobal.ExcelReader xlsreader = new RiLiGlobal.ExcelReader();
                    //InsDetail_Excel = xlsreader.ReadFile(openFileDialog4.FileName.Trim());
                    InsDetail_Excel = RiLiGlobal.NPOIExcel.ImportExcelFile2007(openFileDialog4.FileName.Trim());

                    if (InsDetail_Excel.Rows.Count > 0)
                    {
                        //检查模板格式
                        if (InsDetail_Excel.Columns.Contains("新任务编号") && InsDetail_Excel.Columns.Contains("实际安装人") && InsDetail_Excel.Columns.Contains("安装开始日期") && InsDetail_Excel.Columns.Contains("安装结束日期"))
                        {
                            this.txtInsDetail.Text = openFileDialog4.FileName.Trim();
                        }
                        else
                        {
                            this.txtInsDetail.Text = "";
                            MessageBox.Show("上传的模板数据格式错误，请检查数据格式");
                        }
                    }
                    else
                    {
                        this.txtInsDetail.Text = "";
                        MessageBox.Show("上传的模板没任何数据");
                    }

                }
                else
                {
                    this.txtInsDetail.Text = "";
                    MessageBox.Show("请选择要上传的模板数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("原因:" + ex.Message, "错误提示");
            }
        }


        /// <summary>
        /// 确认上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            int ncount = 0;
            string strtInsType = "";//安装类型
            string tInsCode = ""; //最大的任务编号
            string tNewInsCode = ""; //新任务编号

            string tStartPerson = ""; //制单人编码
            string tInsManger = ""; //安装负责人编码

            string tAgeStoreName = ""; //销售代理店
            string tCustName = ""; //客户名称

            string MachineModel="";//机器型号
            string MachineType=""; //机器颜色
            string MachineLevel=""; //机器级别
            string ProductLine="";//产线
            string tMaiCode = ""; //U8存货代码

            string tMessagedate=""; //任务发起日期 	
            string tAuditMessagedate="";  //任务指派日期	
            string fMessagedate="";  //任务完成时间	
            string tAuditTime="";  //审核日期	
            string tCheckTime = "";  //核对日期

            string tSaleType = "";//选购件类型
            string tRegName = ""; //省份名称
            string tCity = ""; //地级市

            string U8AccountNum="";
            string aAccName = ""; //配件名称
            string aAccStd = ""; //规格型号
            string cEnglishName = ""; //英文名称

            Faildt = new DataTable();
            DataColumn dcNum = new DataColumn("Num"); //序号
            DataColumn dctInsType = new DataColumn("tInsType"); //安装类型
            DataColumn dctNewInsCode = new DataColumn("tNewInsCode"); //新任务编号
            DataColumn dcErrMsg = new DataColumn("ErrMsg"); //错误原因

            Faildt.Columns.Add(dcNum);
            Faildt.Columns.Add(dctInsType);
            Faildt.Columns.Add(dctNewInsCode);
            Faildt.Columns.Add(dcErrMsg);

            if (string.IsNullOrEmpty(this.txtInstallTask.Text) == true || string.IsNullOrEmpty(this.txtInsAccessory.Text) == true)
            {
                MessageBox.Show("安装单模板与安装配件明细模板为必导入项，请导入！");
                return;
            }

            //检查数据的正确性
            bool CheckOK = false;

            Bao.StringCommon stringcommon = new Bao.StringCommon();
            Bao.WaitForm _waitform = new Bao.WaitForm();
            try
            {
                StringBuilder sql = new StringBuilder();
                DataRow[] InsAccessory_drs;
                //DataRow[] InsAccessoryOld_drs;
                DataRow[] InsDetail_drs;

                DataRow[] tStartPerson_drs; //制单人
                DataRow[] tInsManger_drs; //安装负责人编码
                DataRow[] tAgeStore_drs; //销售代理店
                DataRow[] tCustName_drs; //客户
                DataRow[] tMachineGrade_drs; //机器级别档案

                DataRow[] tInventory_drs;// 存货档案
                DataRow[] InsAccessorydt_drs;//制造编号

                int iCount = 0;
                int ErriCount = 0;
                int nTotalCount = InstallTask_Excel.Rows.Count;

                //售后用户档案
                DataTable Userdt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet("select * from Users").Tables[0];

                //机器级别档案
                DataTable MachineGradedt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet("select * from BaseMachineGrade").Tables[0];

                //销售代理店档案
                DataTable SellClientdt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet("select cCusCode,cCusAbbName as cCusName from " + U8DataBaseName + ".Customer where ccccode  like '2%' or  ccccode like '1%'").Tables[0];

                //客户档案 省份名称 地级市
                DataTable Customerdt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(string.Format(@"select a.cCusCode,a.cCusAbbName as cCusName, c.ccCName,isnull(b.cDCName,c.ccCName) as cDCName from {0}.Customer a inner join {0}.DistrictClass b on a.cDCCode = b.cDCCode left join {0}.CustomerClass c on a.cCCCode = c.cCCCode where a.ccccode  like '2%' or a.ccccode like '1%'", U8DataBaseName)).Tables[0];

                //存货档案
               /* DataTable Inventorydt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(@"select * from (select '001' as U8AccountNum ,cinvcode,cinvname,cEnglishName, cInvStd  from [192.168.0.220,7521].UFDATA_001_2020.dbo.Inventory
Union all
select '003' as U8AccountNum ,cinvcode,cinvname,cEnglishName, cInvStd  from [192.168.0.220,7521].UFDATA_003_2020.dbo.Inventory
Union all
select '005' as U8AccountNum ,cinvcode,cinvname,cEnglishName, cInvStd  from [192.168.0.220,7521].UFDATA_005_2020.dbo.Inventory) T ").Tables[0];*/

                DataTable Inventorydt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet(string.Format(@"select cinvcode,cinvname,cEnglishName, cInvStd from {0}.Inventory ", U8DataBaseName)).Tables[0];

                //序列号唯一性
                DataTable InsAccessorydt = HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteDataSet("select aTaskCode,aAccCode,aMakeCode from InsAccessory").Tables[0];

                //检查数据的正确性

                _waitform.Show("正在验证导入的Excel数据中，请稍等.......");

                //检查安装单数据
#region 检查安装单数据
                foreach (DataRow InstallTask_checkdr in InstallTask_Excel.Rows)
                {
                    if (string.IsNullOrEmpty(InstallTask_checkdr["新任务编号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = "";
                        r["ErrMsg"] = "新任务编号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (InstallTask_Excel.Select("新任务编号='" + InstallTask_checkdr["新任务编号"].ToString() + "'").Length >= 2)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "新任务编号不存在唯一性，出现重复编号！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["U8来源账号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "U8来源账号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if ((InstallTask_checkdr["U8来源账号"].ToString() == "001" || InstallTask_checkdr["U8来源账号"].ToString() == "003" || InstallTask_checkdr["U8来源账号"].ToString() == "005" || InstallTask_checkdr["U8来源账号"].ToString() == "其他") == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "U8来源账号录入错误，只能填001或者003或者005或者其他！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["安装类型"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "安装类型为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if ((InstallTask_checkdr["安装类型"].ToString() == "主机安装" || InstallTask_checkdr["安装类型"].ToString() == "选配件安装") == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "安装类型录入错误，只能填主机安装或者选配件安装！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["选购件类型"].ToString()) == true && InstallTask_checkdr["安装类型"].ToString() == "选配件安装")
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "当安装类型为选配件安装，选购件类型需填入内容！";
                        Faildt.Rows.Add(r);
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["选购件类型"].ToString()) == false && InstallTask_checkdr["安装类型"].ToString() == "选配件安装")
                    {
                        if ((InstallTask_checkdr["选购件类型"].ToString() == "放射配件" || InstallTask_checkdr["选购件类型"].ToString() == "超声配件" || InstallTask_checkdr["选购件类型"].ToString() == "其他")==false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "当安装类型为选配件安装，选购件类型只能填放射配件或者超声配件或者其他！";
                            Faildt.Rows.Add(r);
                        }
                    }


                    if (string.IsNullOrEmpty(InstallTask_checkdr["任务状态"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "任务状态为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if ((InstallTask_checkdr["任务状态"].ToString() == "新任务" || InstallTask_checkdr["任务状态"].ToString() == "已核对") == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "任务状态录入错误，只能填新任务或者已核对！";
                            Faildt.Rows.Add(r);
                        }
                    }


                    if (string.IsNullOrEmpty(InstallTask_checkdr["制单人"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "制单人为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (Userdt.Select(string.Format("userName ='{0}'", InstallTask_checkdr["制单人"].ToString())).Length <= 0)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "录入的制单人在售后系统用户档案中不存在！";
                            Faildt.Rows.Add(r);
                        }
                    }


                    if (string.IsNullOrEmpty(InstallTask_checkdr["发货日期"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "发货日期为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (stringcommon.IsDateTime(InstallTask_checkdr["发货日期"].ToString()) == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "发货日期错误！";
                            Faildt.Rows.Add(r);
                        }
                    }


                    if (string.IsNullOrEmpty(InstallTask_checkdr["保修改周期月"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "保修改周期月为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (stringcommon.IsIntNum(InstallTask_checkdr["保修改周期月"].ToString()) == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "保修改周期月要为整数！";
                            Faildt.Rows.Add(r);
                        }
                    }

                   
                    if (string.IsNullOrEmpty(InstallTask_checkdr["销售代理店编码"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "销售代理店编码为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (SellClientdt.Select(string.Format("cCusCode='{0}'", InstallTask_checkdr["销售代理店编码"].ToString())).Length <= 0)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "销售代理店编码不存在！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["销售负责人"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "销售负责人为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }

                    if (string.IsNullOrEmpty(InstallTask_checkdr["客户编码"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "客户编码为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        //cCusCode
                        if (Customerdt.Select(string.Format("cCusCode='{0}'", InstallTask_checkdr["客户编码"].ToString())).Length <= 0)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装单模板";
                            r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "客户编码不存在！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    
                    if (string.IsNullOrEmpty(InstallTask_checkdr["装机联系人"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "装机联系人为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }



                    /*if (InstallTask_checkdr["安装类型"].ToString() == "主机安装" && string.IsNullOrEmpty(InstallTask_checkdr["编码"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "编码为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }*/

                    if (string.IsNullOrEmpty(InstallTask_checkdr["制造编号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "制造编号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }

                    //用户负责人
                    if (string.IsNullOrEmpty(InstallTask_checkdr["用户负责人"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "用户负责人为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }

                    //联系电话
                    if (string.IsNullOrEmpty(InstallTask_checkdr["联系电话"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装单模板";
                        r["tNewInsCode"] = InstallTask_checkdr["新任务编号"].ToString();
                        r["ErrMsg"] = "联系电话为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }


                }
                #endregion 检查安装单数据

                //检查安装配件明细数据
                #region 检查安装配件明细数据
                foreach (DataRow InsAccessory_checkdr in InsAccessory_Excel.Rows)
                {

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["新任务编码"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = "";
                        r["ErrMsg"] = "新任务编码为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["U8来源账号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "U8来源账号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if ((InsAccessory_checkdr["U8来源账号"].ToString() == "001" || InsAccessory_checkdr["U8来源账号"].ToString() == "003" || InsAccessory_checkdr["U8来源账号"].ToString() == "005" || InsAccessory_checkdr["U8来源账号"].ToString() == "其他") == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装配件明细模板";
                            r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                            r["ErrMsg"] = "U8来源账号录入错误，只能填001或者003或者005或者其他！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["状态"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "状态为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if ((InsAccessory_checkdr["状态"].ToString() == "新任务" || InsAccessory_checkdr["状态"].ToString() == "已核对") == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装配件明细模板";
                            r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                            r["ErrMsg"] = "任务状态录入错误，只能填新任务或者已核对！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["配件编号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "配件编号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        //cinvcode
                        if (Inventorydt.Select(string.Format("cinvcode='{0}'", InsAccessory_checkdr["配件编号"].ToString())).Length <= 0)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装配件明细模板";
                            r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                            r["ErrMsg"] = "配件编号不存在！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    /*if (string.IsNullOrEmpty(InsAccessory_checkdr["配件名称"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "配件名称为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }*/

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["制造编号"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "制造编号为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        //制造编号是唯一性
                        InsAccessorydt_drs = InsAccessorydt.Select("aAccCode='" + InsAccessory_checkdr["配件编号"].ToString() + "' and aMakeCode='" + InsAccessory_checkdr["制造编号"].ToString() + "'");
                        if (InsAccessorydt_drs.Length > 0)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装配件明细模板";
                            r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                            r["ErrMsg"] = "制造编号是唯一性,在安装单号：" + InsAccessorydt_drs[0]["aTaskCode"].ToString() + "已存在相同的配件编号:" + InsAccessory_checkdr["配件编号"].ToString() + "与制造编号:" + InsAccessory_checkdr["制造编号"].ToString() + "！";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (string.IsNullOrEmpty(InsAccessory_checkdr["数量"].ToString()) == true)
                    {
                        ErriCount = ErriCount + 1;

                        DataRow r = Faildt.NewRow();
                        r["Num"] = ErriCount.ToString();
                        r["tInsType"] = "安装配件明细模板";
                        r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                        r["ErrMsg"] = "数量为必填项，不能为空！";
                        Faildt.Rows.Add(r);
                    }
                    else
                    {
                        if (stringcommon.IsInt(InsAccessory_checkdr["数量"].ToString()) == false)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装配件明细模板";
                            r["tNewInsCode"] = InsAccessory_checkdr["新任务编码"].ToString();
                            r["ErrMsg"] = "数量非数字，不能为空！";
                            Faildt.Rows.Add(r);
                        }
                    }

                }
                #endregion

                //检查安装任务反馈明细数据
                #region 检查安装任务反馈明细数据

                if (InsDetail_Excel != null)
                {
                    foreach (DataRow InsDetail_checkdr in InsDetail_Excel.Rows)
                    {
                        if (string.IsNullOrEmpty(InsDetail_checkdr["新任务编号"].ToString()) == true)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装任务反馈明细模板";
                            r["tNewInsCode"] = "";
                            r["ErrMsg"] = "新任务编号为必填项，不能为空！";
                            Faildt.Rows.Add(r);
                        }

                        if (string.IsNullOrEmpty(InsDetail_checkdr["U8来源账号"].ToString()) == true)
                        {
                            ErriCount = ErriCount + 1;

                            DataRow r = Faildt.NewRow();
                            r["Num"] = ErriCount.ToString();
                            r["tInsType"] = "安装任务反馈明细模板";
                            r["tNewInsCode"] = InsDetail_checkdr["新任务编号"].ToString();
                            r["ErrMsg"] = "U8来源账号为必填项，不能为空！";
                            Faildt.Rows.Add(r);
                        }
                        else
                        {
                            if ((InsDetail_checkdr["U8来源账号"].ToString() == "001" || InsDetail_checkdr["U8来源账号"].ToString() == "003" || InsDetail_checkdr["U8来源账号"].ToString() == "005" || InsDetail_checkdr["U8来源账号"].ToString() == "其他") == false)
                            {
                                ErriCount = ErriCount + 1;

                                DataRow r = Faildt.NewRow();
                                r["Num"] = ErriCount.ToString();
                                r["tInsType"] = "安装任务反馈明细模板";
                                r["tNewInsCode"] = InsDetail_checkdr["新任务编号"].ToString();
                                r["ErrMsg"] = "U8来源账号录入错误，只能填001或者003或者005或者其他！";
                                Faildt.Rows.Add(r);
                            }
                        }
                    }
                }
                #endregion

                if (Faildt.Rows.Count > 0)
                {
                    CheckOK = false;
                }
                else
                {
                    CheckOK = true;
                }


                if (CheckOK)
                {
                    HJ.Data.SQLDBConnect.SQLDBconntion.SQLTransBegin();


                    foreach (DataRow InstallTask_dr in InstallTask_Excel.Rows)
                    {
                        sql = new StringBuilder();
                        iCount = iCount + 1;
                        _waitform.Show("正在导入数据中(" + (iCount) + "/" + nTotalCount + ")，请稍等.......");

                        tNewInsCode = InstallTask_dr["新任务编号"].ToString().Trim();
                        strtInsType = InstallTask_dr["安装类型"].ToString().Trim();

                        if (strtInsType == "主机安装")
                        {
                            tInsCode = RiLiGlobal.GetCode.GetInsCode();
                        }
                        else
                        {
                            tInsCode = RiLiGlobal.GetCode.GetOPCode();//配件安装 获取配件安装编号
                        }

                        //InstallTask_DataTest 为测试表

                        tStartPerson = "";
                        tStartPerson_drs = Userdt.Select(string.Format("userName ='{0}'", InstallTask_dr["制单人"].ToString()));
                        if (tStartPerson_drs.Length > 0)
                        {
                            tStartPerson = tStartPerson_drs[0]["UserId"].ToString();
                        }

                        tInsManger = ""; //安装负责人编码
                        if(string.IsNullOrEmpty(InstallTask_dr["安装负责人姓名"].ToString())==false)
                        {
                             tInsManger_drs = Userdt.Select(string.Format("userName ='{0}'", InstallTask_dr["安装负责人姓名"].ToString()));
                            if (tInsManger_drs.Length > 0)
                            {
                                tInsManger = tInsManger_drs[0]["UserId"].ToString();
                            }
                        }
                     

                        tAgeStoreName = "";
                        tAgeStore_drs = SellClientdt.Select(string.Format("cCusCode ='{0}'", InstallTask_dr["销售代理店编码"].ToString()));
                        if (tStartPerson_drs.Length > 0)
                        {
                            tAgeStoreName = tAgeStore_drs[0]["cCusName"].ToString();
                        }

                        tCustName="";
                        tRegName = InstallTask_dr["省份名称"].ToString(); //省份名称
                        tCity = InstallTask_dr["地级市"].ToString(); //地级市
                        tCustName_drs = Customerdt.Select(string.Format("cCusCode ='{0}'", InstallTask_dr["客户编码"].ToString()));
                        if (tCustName_drs.Length > 0)
                        {
                            tCustName = tCustName_drs[0]["cCusName"].ToString();
                            tRegName = tCustName_drs[0]["ccCName"].ToString();
                            tCity = tCustName_drs[0]["cDCName"].ToString();
                        }

                         MachineModel = "";//机器型号
                         MachineType = ""; //机器颜色
                         MachineLevel = ""; //机器级别
                         ProductLine = "";//产线
                         tMaiCode = ""; //U8存货代码

                         if (string.IsNullOrEmpty(InstallTask_dr["编码"].ToString()) == false)
                         {
                             tMachineGrade_drs = MachineGradedt.Select(string.Format("code='{0}'", InstallTask_dr["编码"].ToString()));
                             if (tMachineGrade_drs.Length > 0)
                             {
                                 MachineModel = tMachineGrade_drs[0]["model"].ToString();//机器型号
                                 MachineType = tMachineGrade_drs[0]["type"].ToString(); //机器颜色
                                 MachineLevel = tMachineGrade_drs[0]["grade"].ToString(); //机器级别
                                 ProductLine = tMachineGrade_drs[0]["productline"].ToString();//产线
                                 tMaiCode = tMachineGrade_drs[0]["cinvstd"].ToString(); //U8存货代码
                             }
                         }

                         //tMessagedate 任务发起日期 	
                         tMessagedate = InstallTask_dr["任务发起日期"].ToString();
                         if (InstallTask_dr["任务状态"].ToString().Trim() == "已核对" && string.IsNullOrEmpty(InstallTask_dr["任务发起日期"].ToString()) == true)
                         {
                             tMessagedate = System.DateTime.Now.ToString("yyyy-MM-dd");
                         }

                         //tAuditMessagedate 任务指派日期	
                         tAuditMessagedate = InstallTask_dr["任务指派日期"].ToString();
                         if (InstallTask_dr["任务状态"].ToString().Trim() == "已核对" && string.IsNullOrEmpty(InstallTask_dr["任务指派日期"].ToString()) == true)
                         {
                             tAuditMessagedate = System.DateTime.Now.ToString("yyyy-MM-dd");
                         }

                         //fMessagedate 任务完成时间	
                         fMessagedate = InstallTask_dr["任务完成时间"].ToString();
                         if (InstallTask_dr["任务状态"].ToString().Trim() == "已核对" && string.IsNullOrEmpty(InstallTask_dr["任务完成时间"].ToString()) == true)
                         {
                             fMessagedate = System.DateTime.Now.ToString("yyyy-MM-dd");
                         }

                         //tAuditTime 审核日期	
                         tAuditTime = InstallTask_dr["审核日期"].ToString();
                         if (InstallTask_dr["任务状态"].ToString().Trim() == "已核对" && string.IsNullOrEmpty(InstallTask_dr["审核日期"].ToString()) == true)
                         {
                             tAuditTime = System.DateTime.Now.ToString("yyyy-MM-dd");
                         }

                         //tCheckTime 核对日期
                         tCheckTime = InstallTask_dr["核对日期"].ToString();
                         if (InstallTask_dr["任务状态"].ToString().Trim() == "已核对" && string.IsNullOrEmpty(InstallTask_dr["核对日期"].ToString()) == true)
                         {
                             tCheckTime = System.DateTime.Now.ToString("yyyy-MM-dd");
                         }


                         //选购件类型 若为"主机安装"，则为空值
                         if (InstallTask_dr["安装类型"].ToString().Trim() == "主机安装")
                         {
                             tSaleType = "";
                         }
                         else
                         {
                             tSaleType = InstallTask_dr["选购件类型"].ToString().Trim();
                         }
                        


                        sql.Append(" insert into InstallTask(tID,U8AccountNum,tOldInsCode,tInsCode,tSaleType,tInsType,tState,tStartPerson,tSendTime,tRepMonth,tAgeStore,tAgePerson,tCusCode,tCusName,tRegName,City,tAddress,tComName,tComPhone,MachineModel,MachineType,MachineLevel,ProductLine,tMaiCode,tMakeCode,tMessagedate,tMessageId,tAuditMessagedate,tAuditMessageId,fMessagedate,fMessageId,tAuditTime,tAuditPerson,tCheckTime,tCheckPerson,tInsManger,tInsMangerName,InstallUnit1,InstallUnit2) values ");
                        sql.Append("(NewID(),'" + InstallTask_dr["U8来源账号"].ToString().Trim() + "','" + InstallTask_dr["任务编号"].ToString().Trim() + "','" + tInsCode + "','" + tSaleType + "','" + InstallTask_dr["安装类型"].ToString().Trim() + "','" + InstallTask_dr["任务状态"].ToString().Trim() + "','" + tStartPerson + "','" + InstallTask_dr["发货日期"].ToString().Trim() + "'," + InstallTask_dr["保修改周期月"].ToString().Trim() + ",'" + tAgeStoreName + "','" + InstallTask_dr["销售负责人"].ToString().Trim() + "','" + InstallTask_dr["客户编码"].ToString().Trim() + "','" + tCustName + "','" + tRegName + "','" + tCity + "','" + InstallTask_dr["客户地址"].ToString().Trim() + "','" + InstallTask_dr["装机联系人"].ToString().Trim() + "','" + InstallTask_dr["装机联系人电话"].ToString().Trim() + "','" + MachineModel + "','" + MachineType + "','" + MachineLevel + "','" + ProductLine + "','" + tMaiCode + "','" + InstallTask_dr["制造编号"].ToString().Trim() + "','" + tMessagedate + "',Null,'" + tAuditMessagedate + "',Null,'" + fMessagedate + "',Null,'" + tAuditTime + "',Null,'" + tCheckTime + "',Null,'" + tInsManger + "','" + InstallTask_dr["安装负责人姓名"].ToString().Trim() + "',Null,Null )");

                        /* NewID(),U8来源账号,任务编号,新任务编号,'',安装类型,任务状态,u.UserId,发货日期,保修改周期月,销售代理店,isnull(销售负责人,''),isnull(客户编码,''),客户名称,省份名称,地级市,客户地址,装机联系人,装机联系人电话,型号,颜色,机器级别,'',主机编号,制造编号,任务发起日期,任务发起人,任务指派日期,任务指派人,任务完成时间,任务完成人,审核日期,审核人,核对日期,核对人,安装负责人编号,安装负责人姓名,安装单位1,安装单位2*/

                        sql.Append(" insert into InsFeedback(fID,fOldTaskCode,fTaskCode,fPostCode,fCliManger,fCliPhone,fMainVersion,fEndTime,fFeed,fSummary,fSoftVersion,fSN2) values ");
                        sql.Append("(NewID(),'" + InstallTask_dr["任务编号"].ToString().Trim() + "','" + tInsCode + "',Null,'"+ InstallTask_dr["用户负责人"].ToString().Trim()+"','" + InstallTask_dr["联系电话"].ToString().Trim() + "',Null,'" + InstallTask_dr["验收日期"].ToString().Trim() + "',Null,Null,Null,'" + InstallTask_dr["SN2"].ToString().Trim() + "' )");

                        /* NewID(),任务编号,新任务编号,isnull(邮政编码,''),isnull(用户负责人,''),isnull(联系电话,''),isnull(软件版本,'') ,验收日期,isnull(安装情况反馈,'') ,isnull(备注,'')*/

                        //安装配件明细
                        InsAccessory_drs = InsAccessory_Excel.Select("新任务编码='" + tNewInsCode + "'");
                        foreach (DataRow InsAccessory_dr in InsAccessory_drs)
                        {
                            //U8AccountNum,aAccName,aAccStd,cEnglishName
                            U8AccountNum=InsAccessory_dr["U8来源账号"].ToString().Trim();
                            aAccName = InsAccessory_dr["配件名称"].ToString().Replace("'", "’").Trim();
                            aAccStd = InsAccessory_dr["规格型号"].ToString().Replace("'", "’").Trim();
                            cEnglishName = InsAccessory_dr["英文名称"].ToString().Replace("'", "’").Trim();
                            
                            //tInventory_drs = Inventorydt.Select(string.Format("U8AccountNum='{0}' and cinvcode='{1}'", U8AccountNum, InsAccessory_dr["配件编号"].ToString().Trim()));
                            tInventory_drs = Inventorydt.Select(string.Format("cinvcode='{0}'",InsAccessory_dr["配件编号"].ToString().Trim()));
                            if (tInventory_drs.Length > 0)
                            {
                                aAccName = tInventory_drs[0]["cinvname"].ToString().Replace("'", "’").Trim();
                                aAccStd = tInventory_drs[0]["cInvStd"].ToString().Replace("'", "’").Trim();
                                cEnglishName = tInventory_drs[0]["cEnglishName"].ToString().Replace("'", "’").Trim();
                            }

                            sql.Append(" insert into InsAccessory(aID,aOldTaskCode,aTaskCode,aAccCode,aAccName,aAccStd,cEnglishName,aMakeCode,qty,dtimefh,dtimegc,aSummary,U8AccountNum) values ");
                            sql.Append("(NewID(),'" + InsAccessory_dr["任务编号"].ToString().Trim() + "','" + tInsCode + "','" + InsAccessory_dr["配件编号"].ToString().Trim() + "','" + aAccName + "','" + aAccStd + "','" + cEnglishName + "','" + InsAccessory_dr["制造编号"].ToString().Trim() + "'," + InsAccessory_dr["数量"].ToString().Trim() + ",'" + InsAccessory_dr["本部发货日期"].ToString().Trim() + "','" + InsAccessory_dr["GC出库日期"].ToString().Trim() + "','" + InsAccessory_dr["备注"].ToString().Replace("'", "’").Trim() + "','" + U8AccountNum + "' )");
                        }

                        /* NewID(),任务编号,新任务编码,isnull(配件编号,''),isnull(配件名称,''),isnull(规格型号,''),isnull(英文名称,''),isnull(制造编号,''),isnull(数量,0),本部发货日期,GC出库日期,isnull(备注,'')*/


                        //安装销售出库单(客户要求取消)
                        /*if (InsAccessoryOld_Excel != null)
                        {
                            InsAccessoryOld_drs = InsAccessoryOld_Excel.Select("新任务编号='" + tNewInsCode + "'");
                            foreach (DataRow InsAccessoryOld_dr in InsAccessoryOld_drs)
                            {
                                sql.Append(" insert into InsAccessoryOld(aID,aOldTaskCode,aTaskCode, aAccCode,aAccName,aAccStd,cEnglishName,aMakeCode,qty,dtimefh,dtimegc,aSummary) values ");

                                sql.Append("(NewID(),'" + InsAccessoryOld_dr["任务编号"].ToString().Trim() + "','" + tInsCode + "','" + InsAccessoryOld_dr["配件编号"].ToString().Trim() + "','" + InsAccessoryOld_dr["配件名称"].ToString().Replace("'", "’").Trim() + "','" + InsAccessoryOld_dr["规格型号"].ToString().Replace("'", "’").Trim() + "','" + InsAccessoryOld_dr["英文名称"].ToString().Replace("'", "’").Trim() + "','" + InsAccessoryOld_dr["制造编号"].ToString().Trim() + "'," + InsAccessoryOld_dr["数量"].ToString().Trim() + ",'" + InsAccessoryOld_dr["本部发货日期"].ToString().Trim() + "','" + InsAccessoryOld_dr["GC出库日期"].ToString().Trim() + "','" + InsAccessoryOld_dr["备注"].ToString().Replace("'", "’").Trim() + "' )");

                            }
                        }*/

                        /*NewID(),任务编号,新任务编号,isnull(配件编号,''),isnull(配件名称,''),isnull(规格型号,''),isnull(英文名称,''),isnull(制造编号,''),isnull(数量,0),本部发货日期,GC出库日期,isnull(备注,'')*/

                        //安装任务反馈明细
                        if (InsDetail_Excel != null)
                        {
                            InsDetail_drs = InsDetail_Excel.Select("新任务编号='" + tNewInsCode + "'");
                            foreach (DataRow InsDetail_dr in InsDetail_drs)
                            {
                                sql.Append(" insert into InsDetail(rID,rOldTaskCode,rTaskCode,rInsName,rInsStart,rInsEnd,rInsSummary) values ");

                                sql.Append("(NewID(),'" + InsDetail_dr["任务编号"].ToString().Trim() + "','" + tInsCode + "','" + InsDetail_dr["实际安装人"].ToString() + "','" + InsDetail_dr["安装开始日期"].ToString() + "','" + InsDetail_dr["安装结束日期"].ToString() + "','" + InsDetail_dr["备注"].ToString().Replace("'", "’") + "' )");
                            }
                        }

                        /*
                         NewID(),任务编号,新任务编号,isnull(实际安装人,''),安装开始日期,安装结束日期,isnull(备注,'')*/

                        if (HJ.Data.SQLDBConnect.SQLDBconntion.ExecuteNonQuery(sql.ToString().Replace("''", "null")) > 0)
                        {
                            if (strtInsType == "主机安装")
                            {
                                RiLiGlobal.GetCode.SetInsCode();
                            }
                            else
                            {
                                RiLiGlobal.GetCode.SetOPCode();
                            }

                            ncount = ncount + 1;
                        }
                        else
                        {
                            DataRow r = Faildt.NewRow();
                            r["Num"] = (ncount + 1).ToString();
                            r["tInsType"] = strtInsType;
                            r["tNewInsCode"] = tNewInsCode;
                            r["ErrMsg"] = "错误原因：写入Sql数据有误";
                            Faildt.Rows.Add(r);
                        }
                    }

                    if (ncount == InstallTask_Excel.Rows.Count)
                    {
                        HJ.Data.SQLDBConnect.SQLDBconntion.SQLTransCommit();
                        MessageBox.Show("已成功导入共计：" + ncount + "条数据！");
                    }
                    else
                    {
                        HJ.Data.SQLDBConnect.SQLDBconntion.SQLRollback();
                    }
                }

            }
            catch (Exception ex)
            {
                DataRow r = Faildt.NewRow();
                r["Num"] = (ncount + 1).ToString();
                r["tInsType"] = strtInsType;
                r["tNewInsCode"] = tNewInsCode;
                r["ErrMsg"] = "错误原因：" + ex.Message;
                Faildt.Rows.Add(r);

                if (CheckOK)
                {
                    HJ.Data.SQLDBConnect.SQLDBconntion.SQLRollback();
                }
                //MessageBox.Show("原因:" + ex.Message, "错误提示");
            }
            finally
            {
                _waitform.Close();
                this.gridControl1.DataSource = Faildt;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             InstallTask_Excel=null;
             InsAccessory_Excel=null;
             InsAccessoryOld_Excel=null;
             InsDetail_Excel=null;

             this.txtInstallTask.Text = "";
             this.txtInsAccessory.Text = "";
             this.txtInsAccessoryOld.Text = "";
             this.txtInsDetail.Text = "";

             Faildt.Clear();
             this.gridControl1.DataSource = Faildt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                if (dt != null && dt.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "文件另存为";
                    sfd.Filter = "Excel2007|.xls";
                    sfd.FileName = "批量导入安装单上传结果_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    string savePath = "";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        savePath = sfd.FileName;
                    }
                    if (string.IsNullOrEmpty(savePath))
                    {
                        MessageBox.Show("请选择导出路径！");
                        return;
                    }

                    gridView1.ExportToExcelOld(savePath);

                    MessageBox.Show("数据导出成功！");

                }
                else
                {
                    MessageBox.Show("无数据可导出！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误提示:" + ex.Message + "！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}
