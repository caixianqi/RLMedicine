using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Data.OleDb;
namespace UFBaseLib.BusLib
{
    public class Bus
    {
        #region 业务处理

        #region 外挂程序U8登陆界面,静态方法
        //登陆类型0为发布1为测试
        public static bool Login(Byte loginType, string programName, string DBserver,string DBName, string DBUser, string DBPwd, string iYear, string cAccID, string cUserId, string cOperdate)
        {
           
            Boolean isOk = false;
            if (0 == loginType)//是否是测试0不是测试1为测试
            {
                //声明门户login对象和U8Login对象
                Type LoginType = Type.GetTypeFromProgID("UFSoft.U8.Framework.Login.UI.clsLogin");
                Type U8LoginType = Type.GetTypeFromProgID("U8Login.clsLogin");
                Object LoginObj = Activator.CreateInstance(LoginType);
                U8Login.clsLogin U8LoginObj = (U8Login.clsLogin)Activator.CreateInstance(U8LoginType);
                //门户登陆
                Boolean isSucceed = (Boolean)LoginType.InvokeMember("login", BindingFlags.Default | BindingFlags.InvokeMethod, null, LoginObj, new object[] { "DP" });

                if (isSucceed)
                {
                    //得到userToken
                    string userToken = (string)LoginType.InvokeMember("userToken", BindingFlags.GetProperty | BindingFlags.GetField, null, LoginObj, new object[] { });
                    U8LoginType.InvokeMember("ConstructLogin", BindingFlags.InvokeMethod, null, U8LoginObj, new object[] { userToken });
                    BaseInfo.U8Login = U8LoginObj;//设置U8Login对象
                    BaseInfo.UserId = (string)U8LoginType.InvokeMember("cUserId", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });
                    BaseInfo.UserName = (string)U8LoginType.InvokeMember("cUserName", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });
                    BaseInfo.userRole = BaseInfo.UserId;//角色扮演
                    BaseInfo.Password = (string)U8LoginType.InvokeMember("cUserPassWord", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//密码
                    BaseInfo.AccID = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套ID
                    BaseInfo.AccID = BaseInfo.AccID.Substring(BaseInfo.AccID.IndexOf("@") + 1);
                    BaseInfo.iYear = (string)U8LoginType.InvokeMember("cIYear", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套年度
                    BaseInfo.cSubID = (string)U8LoginType.InvokeMember("cSub_Id", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//子系统号
                    BaseInfo.AppServer = (string)U8LoginType.InvokeMember("cServer", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//应用服务器
                    BaseInfo.DataSource = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//数据源
                    BaseInfo.UfDbName = (string)U8LoginType.InvokeMember("UfDbName", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//年度库的连接串
                    BaseInfo.operDate = ((DateTime)U8LoginType.InvokeMember("CurDate", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { })).ToShortDateString();//登陆界面的业务日期
                    BaseInfo.LanguageID = (int)U8LoginType.InvokeMember("LanguageID", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
                    BaseInfo.IsAdmin = (bool)U8LoginType.InvokeMember("IsAdmin", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
                    BaseInfo.DBServerName = BaseInfo.getStrValue(BaseInfo.UfDbName, "data source");//数据库服务器名称
                    BaseInfo.DBUserID = BaseInfo.getStrValue(BaseInfo.UfDbName, "user id");//数据库登陆用户名
                    BaseInfo.DBPwd = BaseInfo.getStrValue(BaseInfo.UfDbName, "password");//数据库登陆密码
                    BaseInfo.DBName = DBName;
                    BaseInfo.DefConnStr = "server=" + BaseInfo.DBServerName.Trim() + ";database=" + BaseInfo.DBName + ";user id=" + BaseInfo.DBUserID + ";password=" + BaseInfo.DBPwd;
                    BaseInfo.ProgramName = programName.Trim();
                    isOk = true;
                }
            }
            else
            {
                BaseInfo.ProgramName = programName;
                BaseInfo.operDate = cOperdate;
                BaseInfo.DBServerName = DBserver.Trim();
                BaseInfo.DBUserID = DBUser.Trim();
                BaseInfo.DBPwd = DBPwd;
                BaseInfo.DBName = DBName;
                BaseInfo.DefConnStr = "server=" + DBserver.Trim() + ";database=" + BaseInfo.DBName + ";user id=" + DBUser.Trim() + ";password=" + DPwd(DBPwd);
                BaseInfo.AccID = cAccID.Trim();//帐套ID
                BaseInfo.iYear = iYear.Trim();//帐套年度
                BaseInfo.UserId = cUserId.Trim();
                BaseInfo.userRole = BaseInfo.UserId;//角色扮演
                isOk = true;

            }
            BaseInfo.ProgramType = 0;//外挂程序
            return isOk;

        }
        #endregion

        #region 内嵌程序Show方法
        public static string Show(Int64 Hwnd, U8Login.clsLogin U8LoginObj, Object mRepManage, Object mRepSysInfo, string programName)
        {
            string mess = null;
            try
            {
                Type U8LoginType = Type.GetTypeFromProgID( "U8Login.clsLogin" );
                BaseInfo.U8Login = U8LoginObj;//设置U8Login对象
                BaseInfo.UserId = (string)U8LoginType.InvokeMember("cUserId", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });
                BaseInfo.UserName = (string)U8LoginType.InvokeMember("cUserName", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });
                BaseInfo.userRole = BaseInfo.UserId;//角色扮演
                BaseInfo.Password = (string)U8LoginType.InvokeMember("cUserPassWord", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//密码
                BaseInfo.AccID = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套ID
                BaseInfo.AccID = BaseInfo.AccID.Substring(BaseInfo.AccID.IndexOf("@") + 1);
                BaseInfo.iYear = (string)U8LoginType.InvokeMember("cIYear", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//帐套年度
                BaseInfo.cSubID = (string)U8LoginType.InvokeMember("cSub_Id", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//子系统号
                BaseInfo.AppServer = (string)U8LoginType.InvokeMember("cServer", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//应用服务器
                BaseInfo.DataSource = (string)U8LoginType.InvokeMember("DataSource", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//数据源
                BaseInfo.UfDbName = (string)U8LoginType.InvokeMember("UfDbName", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//年度库的连接串
                BaseInfo.operDate = ((DateTime)U8LoginType.InvokeMember("CurDate", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { })).ToShortDateString();//登陆界面的业务日期
                BaseInfo.LanguageID = (int)U8LoginType.InvokeMember("LanguageID", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
                BaseInfo.IsAdmin = (bool)U8LoginType.InvokeMember("IsAdmin", BindingFlags.GetField | BindingFlags.GetProperty, null, U8LoginObj, new object[] { });//语言
                BaseInfo.DBServerName = BaseInfo.getStrValue(BaseInfo.UfDbName, "data source");//数据库服务器名称
                BaseInfo.DBName = UFAppConfigXmlDoc.SelectSingleNode("/ufconfig/datasource[.='u8']").Attributes["dbname"].Value;
                BaseInfo.DBUserID = BaseInfo.getStrValue(BaseInfo.UfDbName, "user id");//数据库登陆用户名
                BaseInfo.DBPwd = BaseInfo.getStrValue(BaseInfo.UfDbName, "password");//数据库登陆密码
                BaseInfo.DefConnStr = "server=" + BaseInfo.DBServerName.Trim() + ";database=" + BaseInfo.DBName + ";user id=" + BaseInfo.DBUserID + ";password=" + BaseInfo.DBPwd;
                BaseInfo.ProgramName = programName.Trim();
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;

        }
        #endregion

        #region 创建U8单号对象
        public static string GetBillComponent(out object BillComponentObj)
        {
            string mess = null;
            BillComponentObj = null;
            try
            {
                Type BillComponentType = Type.GetTypeFromProgID("UFBillComponent.clsBillComponent");
                BillComponentObj = Activator.CreateInstance(BillComponentType); 
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion

        #region 获取U8单据编号
        public static string GetU8BillNumber( out string sDocNo ,object BillComponentObj,string sBillName,Boolean bSaveAndValidate )
        {
            string mess = null;
            sDocNo = null;
            try
            {
                Type BillComponentType = BillComponentObj.GetType();
                if ((bool)BillComponentType.InvokeMember("InitBill", BindingFlags.InvokeMethod, null, BillComponentObj, new object[] { UFBaseLib.BusLib.BaseInfo.UfDbName, sBillName }))
                {
                    string sXml = (string)BillComponentType.InvokeMember("GetBillFormat", BindingFlags.InvokeMethod, null, BillComponentObj, new object[] {  });
                    sDocNo = (string)BillComponentType.InvokeMember("GetNumber", BindingFlags.InvokeMethod, null, BillComponentObj, new object[] { sXml,bSaveAndValidate });
                }

            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion

        #region 创建数据库dataAdapter
        public static SqlDataAdapter BuildDataAdpter(SqlCommand _insertCommand, SqlCommand _updateCommand, SqlCommand _deleteCommand, SqlTransaction _tran)
        {
            SqlDataAdapter _da = new SqlDataAdapter();
            _da.InsertCommand = _insertCommand;
            _da.InsertCommand.CommandTimeout = 3600;//设置超时为1小时
            _da.InsertCommand.Connection = _tran.Connection;
            _da.InsertCommand.Transaction = _tran;

            _da.UpdateCommand = _updateCommand;
            _da.UpdateCommand.CommandTimeout = 3600;
            _da.UpdateCommand.Connection = _tran.Connection;
            _da.UpdateCommand.Transaction = _tran;

            _da.DeleteCommand = _deleteCommand;
            _da.DeleteCommand.CommandTimeout = 3600;
            _da.DeleteCommand.Connection = _tran.Connection;
            _da.DeleteCommand.Transaction = _tran;

            return _da;
        }

        public static SqlDataAdapter BuildDataAdpter(string selectCmd)
        {
            SqlDataAdapter _da = new SqlDataAdapter(selectCmd, UFBaseLib.BusLib.Bus.DefSqlConn);
            _da.SelectCommand.CommandTimeout = 3600;//设置超时为1小时
            return _da;
        }
        #endregion

        #region 创建SqlCommand
        public static SqlCommand BuildCommand(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, UFBaseLib.BusLib.Bus.DefSqlConn);
            cmd.CommandTimeout = 3600;
            return cmd;
        }
        #endregion

        #region get 默认数据库连接
        public static SqlConnection DefSqlConn
        {
            get
            {
                return DBLib.DB.DefSqlConn;
            }
        }
        #endregion

        #region 获取指定条件的数据表列值
        public static string getColValue(DataTable dt, string resCol, string ResValue, string tagCol, out string tagValue)
        {
            string mess = null;
            tagValue = "";
            try
            {
                DataRow[] drArr = dt.Select(resCol.Trim() + "='" + ResValue.Trim() + "'");
                if (0 < drArr.Length)
                {
                    tagValue = drArr[0][tagCol].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message.Trim();
            }

            return mess;
        }
        #endregion

        #region 通过其它格式的数据文件生成数据表重载版本
        //现只支持xls,dbf fileTable=要查询的数据文件中的表名
        public static string BuildDTByOtherDataFile(out DataTable resultDT, string fileName, string fileTableName, string sqlWhere)
        {
            string mess = null;
            resultDT = new DataTable();
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                //检测该文件是否存在
                if (!fInfo.Exists)
                {
                    mess = "文件\'" + fileName + "\'不存在";
                    return mess;
                }
                string strConn = "";
                switch (fInfo.Extension.ToUpper().Trim())
                {
                    case ".XLS":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fInfo.FullName + ";Extended Properties=Excel 8.0;";
                        break;
                    default:
                        mess = "数据文件格式不正确";
                        return mess;
                }

                //oledb数据连接
                OleDbConnection oleDbConn = new OleDbConnection(strConn);
                OleDbDataAdapter oleAdapter = new OleDbDataAdapter("select * from " + fileTableName + " " + sqlWhere, oleDbConn);
                oleAdapter.Fill(resultDT);
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion

        #region 64位编码
        public static string Base64Encode(string str)
        {
            byte[] barray;
            barray = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(barray);
        }
        #endregion

        #region 64位解码
        public static string Base64Decode(string str)
        {
            byte[] barray;
            barray = Convert.FromBase64String(str);
            return Encoding.Default.GetString(barray);
        }
        #endregion

        #region 加密解密
        public static string EPwd(string res)
        {
            res += "xueray";
            string pwd = Base64Encode(res);
            //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
            pwd = ChangeStringPosi(pwd, 6, 2, 2);
            //进一步编码
            pwd = Base64Encode(pwd);
            return pwd;
        }

        public static string DPwd(string pwd)
        {
            string res = "";
            try
            {
                res = Base64Decode(pwd);
                //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
                res = ChangeStringPosi(res, 6, 2, 2);
                //进一步编码
                res = Base64Decode(res);
                res = res.Substring(0, res.Length - "xueray".Length);
            }
            catch (Exception ex)
            {
                res = "";
            }
            return res;
        }

        #endregion

        #region 字符串中的字符位置调换
        //功能举例说明:字符串"abcdefd"中，"fd"与"bc"调换位置
        public static string ChangeStringPosi(string resStr, int bakPos1, int bakPos2, int length)
        {
            string a01 = resStr.Substring(0, resStr.Length - bakPos1);
            string a02 = resStr.Substring(resStr.Length - bakPos1, length);
            string a03 = resStr.Substring(resStr.Length - bakPos1 + length, bakPos1 - bakPos2 - length);
            string a04 = resStr.Substring(resStr.Length - length);
            return a01 + a04 + a03 + a02;
        }
        #endregion

        //#region 设置表格只读
        //public static void setGridReadonly(DevExpress.XtraGrid.Views.Grid.GridView _gridview, Boolean isReadonly)
        //{
        //    for (int i = 0; i < _gridview.Columns.Count; i++)
        //    {
        //        _gridview.Columns[i].OptionsColumn.AllowEdit = !isReadonly;
        //    }
        //}
        //#endregion

        #region 获取指定次序的XLS文件表名(sheet名)
        public static string GetXlsTableName(string fileName,int tableIndex)
        {
            string tableName = "";
            if (File.Exists(fileName))
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0\";Data Source=" + fileName))
                    {
                        conn.Open();
                        DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        tableName = dt.Rows[tableIndex][2].ToString().Trim();
                    }
                }
                catch (Exception ex)
                {
                    tableName = "";
                }
            }
            return tableName;
        }
        #endregion

        //#region DevExpress.XtraGrid.Views.Grid.GridView 导出xls文件
        //public static string EXToExcel(DevExpress.XtraGrid.Views.Grid.GridView _gridView)
        //{
        //    string mess = null;
        //    System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog();
        //    //只能导出EXCEL文件
        //    _sfd.Filter = "xls文件 (*.xls)| *.xls";
        //    //是否确定保存
        //    try
        //    {
        //        if (System.Windows.Forms.DialogResult.OK == _sfd.ShowDialog())
        //        {
        //            //导出文件
        //            _gridView.ExportToXls(_sfd.FileName);
        //            mess = "导出成功!!";
        //        }
        //        else
        //        {
        //            mess = "取消导出!!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mess = ex.Message.Trim();
        //    }
        //    //返回是否保存成功
        //    return mess;
        //}
        //#endregion

        #endregion

        #region EAI处理
        #region 获取可导入的EAI单据类型列表(属性)
        public static string[] EaiDocTypeList
        {
            get
            {
                DataSet xmlDS = new DataSet();
                xmlDS.ReadXml("EaiConfig.xml");
                string xmlStr = "";
                foreach (DataRow dr in xmlDS.Tables["ufinterface"].Select("", "seq"))
                {
                    xmlStr += (xmlStr.Trim().Equals("")) ? dr["doctype"].ToString().Trim() : ("," + dr["doctype"].ToString().Trim());
                }
                return xmlStr.Split(',');
            }
        }
        #endregion

        #region 获取指定单据的EAI模板数据集，header为主表,
        //body为子表为,HB关系名称,headerAttr and bodyAttr 分别是主表和子表的属性表
        public static string GetEaiTemplateDS(out DataSet templateDS, string docType)
        {
            string mess = null;
            //EAI模板数据集
            templateDS = new DataSet();
            try
            {
                //根据EaiConfig.xml生成原配置数据集
                DataSet eaiConfigDS = new DataSet();
                eaiConfigDS.ReadXml("EaiConfig.xml");

                //根据docType求出roottag
                string xmlRoottag, xmlDocType;
                xmlRoottag = eaiConfigDS.Tables["ufinterface"].Select("doctype='" + docType + "'")[0]["roottag"].ToString();
                xmlDocType = eaiConfigDS.Tables["ufinterface"].Select("roottag='" + xmlRoottag + "' and istemplate=1")[0]["doctype"].ToString();
                //EAI模板列属性表，为反回后用
                DataTable hAttrTD = eaiConfigDS.Tables["header"].Clone();
                hAttrTD.TableName = "headerAttr";
                DataTable bAttrTD = eaiConfigDS.Tables["body"].Clone();
                bAttrTD.TableName = "bodyAttr";
                templateDS.Tables.Add(hAttrTD);
                templateDS.Tables.Add(bAttrTD);

                DataTable tmpHDT = eaiConfigDS.Tables["header"].Copy();
                tmpHDT.TableName = "headerAttr";
                DataTable tmpBDT = eaiConfigDS.Tables["body"].Copy();
                tmpBDT.TableName = "bodyAttr";

                templateDS.Merge(tmpHDT.Select("doctype='" + xmlDocType + "'"));
                templateDS.Merge(tmpBDT.Select("doctype='" + xmlDocType + "'"));
                //header表
                DataTable headerDT = new DataTable();
                headerDT.TableName = "header";
                foreach (DataRow dr in eaiConfigDS.Tables["header"].Select("doctype='" + xmlDocType + "'", "seq"))
                {
                    DataColumn dc = new DataColumn(dr["colenglish"].ToString().Trim(), typeof(string));
                    headerDT.Columns.Add(dc);
                }

                //body表
                DataTable bodyDT = new DataTable();
                bodyDT.TableName = "body";
                foreach (DataRow dr in eaiConfigDS.Tables["body"].Select("doctype='" + xmlDocType + "'", "seq"))
                {
                    DataColumn dc = new DataColumn(dr["colenglish"].ToString().Trim(), typeof(string));
                    bodyDT.Columns.Add(dc);
                }

                templateDS.Tables.Add(headerDT);
                templateDS.Tables.Add(bodyDT);
                //建立主子表关系
                string sKey = eaiConfigDS.Tables["header"].Select("iskey='1'")[0]["colenglish"].ToString().Trim();
                templateDS.Relations.Add("HB", templateDS.Tables["header"].Columns[sKey], templateDS.Tables["body"].Columns[sKey]);
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion

        #region 根据EAI数据集生成EAI数据XML字符串
        public static string BuildEAIXML(out string sXml, DataSet xmlDS, string docType)
        {
            string mess = null;
            sXml = "";
            try
            {
                //根据EaiConfig.xml生成原配置数据集
                DataSet eaiConfigDS = new DataSet();
                eaiConfigDS.ReadXml("EaiConfig.xml");
                //xmldocument 对象
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(
                    "<?xml version='1.0' encoding='utf-8'?>" +
                    "<ufinterface />"
                    );

                DataRow interfaceDR = eaiConfigDS.Tables["ufinterface"].Select("doctype='" + docType + "'")[0];
                string roottag = interfaceDR["roottag"].ToString().Trim();
                #region ufinterface 节点
                XmlAttribute xmlAttr;
                xmlAttr = doc.CreateAttribute("sender");
                xmlAttr.Value = interfaceDR["sender"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("receiver");
                xmlAttr.Value = interfaceDR["receiver"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("roottag");
                xmlAttr.Value = interfaceDR["roottag"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("docid");
                xmlAttr.Value = interfaceDR["docid"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("proc");
                xmlAttr.Value = interfaceDR["proc"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("codeexchanged");
                xmlAttr.Value = interfaceDR["codeexchanged"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("exportneedexch");
                xmlAttr.Value = interfaceDR["exportneedexch"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("display");
                xmlAttr.Value = interfaceDR["display"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);

                xmlAttr = doc.CreateAttribute("family");
                xmlAttr.Value = interfaceDR["family"].ToString().Trim();
                doc.DocumentElement.Attributes.Append(xmlAttr);
                #endregion

                #region head and body
                //每一张单据(主表)
                foreach (DataRow dr in xmlDS.Tables["header"].Rows)
                {
                    XmlElement hRowEle = doc.CreateElement(roottag);
                    //header 节点
                    XmlElement headerEle = doc.CreateElement("header");

                    //该行的每一列(主表)
                    foreach (DataColumn headDC in xmlDS.Tables["header"].Columns)
                    {
                        //该列是否放在EAI里
                        if (0 < eaiConfigDS.Tables["header"].Select("isputineai='0' and colenglish='" + headDC.ColumnName + "'").Length)
                        {
                            continue;
                        }
                        XmlElement hColEle = doc.CreateElement(headDC.ColumnName);
                        if (!dr[headDC.ColumnName].ToString().Trim().Equals(""))
                        {
                            hColEle.InnerText = dr[headDC.ColumnName].ToString().Trim();
                        }
                        headerEle.AppendChild(hColEle);
                    }
                    hRowEle.AppendChild(headerEle);
                    //body节点
                    XmlElement bodyEle = doc.CreateElement("body");
                    foreach (DataRow bodyDR in dr.GetChildRows("HB"))
                    {
                        XmlElement entryEle = doc.CreateElement("entry");
                        foreach (DataColumn bodyDC in xmlDS.Tables["body"].Columns)
                        {
                            //该列是否放在EAI里
                            if (0 < eaiConfigDS.Tables["body"].Select("isputineai='0' and colenglish='" + bodyDC.ColumnName + "'").Length)
                            {
                                continue;
                            }
                            XmlElement bColEle = doc.CreateElement(bodyDC.ColumnName);
                            if (!bodyDR[bodyDC.ColumnName].ToString().Trim().Equals(""))
                            {
                                bColEle.InnerText = bodyDR[bodyDC.ColumnName].ToString().Trim();
                            }
                            entryEle.AppendChild(bColEle);
                        }
                        bodyEle.AppendChild(entryEle);
                    }
                    hRowEle.AppendChild(bodyEle);
                    doc.DocumentElement.AppendChild(hRowEle);
                }
                #endregion

                //设置sXml=xmldocument 对象字符串
                sXml = doc.OuterXml;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion

        #region 根据xml字符串导入单据到U8
        public static string EAIImport(out string sResult, string sXml)
        {
            string mess = null;
            sResult = "";
            try
            {
                Type eaiType = Type.GetTypeFromProgID("U8Distribute.iDistribute");
                object eaiObj = Activator.CreateInstance(eaiType);
                sResult = (string)eaiType.InvokeMember("Process", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, eaiObj, new object[1] { sXml });
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            return mess;
        }
        #endregion
        #endregion

        #region 获取UFAppConfig
        public static XmlDocument UFAppConfigXmlDoc
        {
            get
            {
                if (null == BaseInfo.xmlDoc)
                {
                    BaseInfo.xmlDoc = new XmlDocument();
                    BaseInfo.xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"Xmls\Config\UFAppConfig.xml");
                }
                return BaseInfo.xmlDoc;

            }
        }
        #endregion

        #region 保存UFAppConfig
        public static void SaveUFConfigXmlDoc(XmlDocument xdoc)
        {
            xdoc.Save(AppDomain.CurrentDomain.BaseDirectory + @"Xmls\Config\UFAppConfig.xml");
            BaseInfo.xmlDoc = new XmlDocument();
            BaseInfo.xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"Xmls\Config\UFAppConfig.xml");
        }
        #endregion

        #region 获取UFEAIConfig
        public static XmlDocument UFEAIConfigXmlDoc
        {
            get
            {
               XmlDocument xmlDoc = new XmlDocument();
               xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"Xmls\EAI\Config\UFEAIConfig.xml");
               return xmlDoc;

            }
        }
        #endregion

        #region 根据单据名称获取SqlDoc
        public static XmlDocument UFEAISqlDoc(string docName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"Config\EAIConfig\Sqls\" + docName.Trim() + ".xml");
            return xmlDoc;
        }
        #endregion

        #region 根据单据名称获取ControlDoc
        public static XmlDocument UFEAICtlDoc(string docName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"Config\EAIConfig\Controls\" + docName.Trim() + ".xml");
            return xmlDoc;
        }
        #endregion

        #region 根据路径获取xmlDoc
        public static XmlDocument GetXmlDoc(string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            return xDoc;
        }
        #endregion
    }
}
