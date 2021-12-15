using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RiLiGlobal
{
    public class ExcelReader
    {
        private string filePath;
        private string fileName;
        private OleDbConnection conn;
        private DataTable readDataTable;
        private string connString;
        private FileType fileType = FileType.noset;

        public ExcelReader()
        {

        }

        private void SetFileInfo(string path)
        {
            filePath = path;

            fileName = this.filePath.Remove(0, this.filePath.LastIndexOf("\\") + 1);
            switch ((fileName.Split('.')[1]).ToLower())
            {
                case "xls": connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'"; fileType = FileType.xls;
                    break;
                case "xlsx": connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'"; fileType = FileType.xlsx;
                    break;
                case "csv": connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.Remove(filePath.LastIndexOf("\\") + 1) + ";Extended Properties='Text;FMT=Delimited;HDR=YES;'"; fileType = FileType.csv;
                    break;
            }
        }


        //DataInterface.Method
        /// <summary>
        /// 读取2007版本excel
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回一个表</returns>
        public System.Data.DataTable GetExcel2007(string filePath)
        {
            try
            {
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX =1\"";

                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                //获取Excel文件中第一个（按字母排序的）sheet页的页名。
                string tableName = schemaTable.Rows[0][2].ToString().Trim();

                string strExcel = "SELECT  * FROM [" + tableName + "]";
                OleDbDataAdapter myCommand = null;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "dtSource");
                System.Data.DataTable table = ds.Tables["dtSource"];
                conn.Close();
                return table;
            }
            catch
            {
                return null;
            }
        }

        public DataTable ReadFile(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    SetFileInfo(path);
                    OleDbDataAdapter myCommand = null;
                    DataSet ds = null;

                    using (conn = new OleDbConnection(connString))
                    {
                        conn.Open();

                        DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        string tableName = fileType == FileType.csv ? fileName : schemaTable.Rows[0][2].ToString().Trim();

                        string strExcel = string.Empty;

                        strExcel = "Select   *   From   [" + tableName + "]";
                        myCommand = new OleDbDataAdapter(strExcel, conn);

                        ds = new DataSet();

                        myCommand.Fill(ds, tableName);

                        //原来旧的
                        //readDataTable = ds.Tables[0];

                        //新优化（去除空的行）
                        readDataTable = ds.Tables[0].Clone(); //克隆一个结构一样的表
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[0].ToString() != "" || dr[1].ToString() != "")
                            {
                                readDataTable.Rows.Add(dr.ItemArray);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show("出错信息：" + ex.Message);

            }
            return readDataTable;
        }

        private enum FileType
        {
            noset,
            xls,
            xlsx,
            csv
        }
    }
}
