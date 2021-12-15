using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace RiLiGlobal
{
    public class NPOIExcel
    {

        /*注意：操作Excel2003与操作Excel2007使用的是不同的命名空间下的内容
 使用NPOI.HSSF.UserModel空间下的HSSFWorkbook操作Excel2003

 使用NPOI.XSSF.UserModel空间下的XSSFWorkbook操作Excel2007*/

        public static DataTable ImportExcelFile2007(string filePath)
        {
            XSSFWorkbook xssfworkbook;
            #region//初始化信息
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    xssfworkbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion

            NPOI.SS.UserModel.ISheet sheet = xssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            rows.MoveNext();
            XSSFRow row = (XSSFRow)rows.Current;
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                //将第一列作为列表头
                dt.Columns.Add(row.GetCell(j).ToString());
            }
            while (rows.MoveNext())
            {
                row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }



        public static DataTable ImportExcelFile2003(string filePath)
        {
            HSSFWorkbook hssfworkbook;
            #region//初始化信息
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion
 
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            rows.MoveNext();
            HSSFRow row = (HSSFRow)rows.Current;
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                //将第一列作为列表头
                dt.Columns.Add(row.GetCell(j).ToString ());
            }
            while (rows.MoveNext())
            {
                 row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }



        /// <summary>
        /// 将Excel文件中的数据读出到DataTable中(xlsx)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
      /*  public static DataTable ExcelToTableForXLSX(string file)
        {
            DataTable dt = new DataTable();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                ISheet sheet = xssfworkbook.GetSheetAt(0);

                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        //continue;
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 将DataTable数据导出到Excel文件中(xlsx)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void TableToExcelForXLSX(DataTable dt, string file)
        {
            XSSFWorkbook xssfworkbook = new XSSFWorkbook();
            ISheet sheet = xssfworkbook.CreateSheet("Test");

            //表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            xssfworkbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }

        /// <summary>
        /// 获取单元格类型(xlsx)
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueTypeForXLSX(XSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.BLANK: //BLANK:
                    return null;
                case CellType.BOOLEAN: //BOOLEAN:
                    return cell.BooleanCellValue;
                case CellType.NUMERIC: //NUMERIC:
                    return cell.NumericCellValue;
                case CellType.STRING: //STRING:
                    return cell.StringCellValue;
                case CellType.ERROR: //ERROR:
                    return cell.ErrorCellValue;
                case CellType.FORMULA: //FORMULA:
                default:
                    return "=" + cell.CellFormula;
            }

        }
        */

         /* public static DataTable ImportExcelFile2003(string filePath)
          {
              HSSFWorkbook hssfworkbook;
             
              try
              {
                  using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                  {
                      hssfworkbook = new HSSFWorkbook(file);
                  }
              }
              catch (Exception e)
              {
                  throw e;
              }
             


              NPOI.SS.UserModel.Sheet sheet = hssfworkbook.GetSheetAt(0);
              System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
              DataTable dt = new DataTable();
              rows.MoveNext();
              HSSFRow row = (HSSFRow)rows.Current;
              for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
              {
                  //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                  //将第一列作为列表头
                  dt.Columns.Add(row.GetCell(j).ToString());
              }
              while (rows.MoveNext())
              {
                  row = (HSSFRow)rows.Current;
                  DataRow dr = dt.NewRow();
                  for (int i = 0; i < row.LastCellNum; i++)
                  {
                      NPOI.SS.UserModel.Cell cell = row.GetCell(i);
                      if (cell == null)
                      {
                          dr[i] = null;
                      }
                      else
                      {
                          dr[i] = cell.ToString();
                      }
                  }
                  dt.Rows.Add(dr);
              }
              return dt;
          }*/

       }
    }
