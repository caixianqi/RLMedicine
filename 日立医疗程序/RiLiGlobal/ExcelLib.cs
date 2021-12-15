using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace RiLiGlobal
{
    public class ExcelLib
    {
        private ApplicationClass _app = null;
        private _Workbook _wb = null;
        private _Worksheet _ws = null;
        private string _filePath = "";
        private int _shIndex = 0; // 1 based index   

        public event EventHandler ExcelExceptionOccured;

        private _Worksheet CurentWorkSheet;

        public _Worksheet _CurentWorkSheet
        {
            get { return CurentWorkSheet; }
            set { CurentWorkSheet = value; }
        }

        /// <summary>   
        /// 当前Sheet   
        /// </summary>   
        public int SheetIndex { get { return this._shIndex; } }

        /// <summary>   
        /// 当前文件名   
        /// </summary>   
        public string FileName { get { return this._filePath; } }

        #region private operations
        /// <summary>   
        /// 打开App   
        /// </summary>   
        private void OpenApp()
        {
            this._app = new ApplicationClass();
            this._app.Visible = false;
        }

        /// <summary>   
        /// 释放资源   
        /// </summary>   
        /// <param name="o"></param>   
        private void ReleaseCom()
        {
            try
            {
                _app.Quit();
                //强制释放对象 
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)_app);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)_wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)_ws);
            }
            finally
            {
                _app = null;
                _wb = null;
                _ws = null;
                GC.Collect();
            }
        }

        /// <summary>   
        /// 检查App   
        /// </summary>   
        private bool CheckApp()
        {
            if (this._app == null)
            {
                if (this.ExcelExceptionOccured != null)
                {
                    this.ExcelExceptionOccured(this, new ErrorEventArgs(new Exception("Application对象未初始化")));
                }
                return false;
            }

            return true;
        }

        /// <summary>   
        /// 检查Book   
        /// </summary>   
        private bool CheckWorkBook()
        {
            if (this._wb == null)
            {
                if (this.ExcelExceptionOccured != null)
                {
                    this.ExcelExceptionOccured(this, new ErrorEventArgs(new Exception("Workbook对象未初始化")));
                }

                return false;
            }

            return true;
        }

        /// <summary>   
        /// 检查Sheet   
        /// </summary>   
        private bool CheckSheet()
        {
            if (this._ws == null)
            {
                if (this.ExcelExceptionOccured != null)
                {
                    this.ExcelExceptionOccured(this, new ErrorEventArgs(new Exception("Worksheet对象未初始化")));
                }

                return false;
            }

            return true;
        }
        #endregion

        #region basic operation
        /// <summary>   
        /// 打开文件   
        /// </summary>   
        /// <param name="filePath"></param>   
        public void Open(string filePath)
        {
            // Check Application    
            if (!this.CheckApp()) return;

            // Open workbook   
            this._filePath = filePath;
            this._wb = this._app.Workbooks._Open(filePath, false, true, Missing.Value, Missing.Value
                    , Missing.Value, Missing.Value, Missing.Value, Missing.Value
                    , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            // set default sheet   
            this.SetCurrentSheet(1);
        }

        /// <summary>   
        /// 自动打开Excel对象   
        /// </summary>   
        public ExcelLib()
        {
            this.OpenApp();
        }

        /// <summary>   
        /// 打开excel文件   
        /// </summary>   
        /// <param name="filePath"></param>   
        public ExcelLib(string filePath)
        {
            //必需的日期验证

        
            this.OpenApp();
            this.Open(filePath);


        }

      

        /// <summary>   
        /// 保存当前文档   
        /// </summary>   
        public void Save()
        {
            // check workbook    
            if (!this.CheckWorkBook()) return;

            // save the book   
            this._wb.Save();

        }

        /// <summary>   
        /// 另存当前文档   
        /// </summary>   
        /// <param name="filePath"></param>   
        public void Save(string filePath)
        {
            // check workbook    
            if (!this.CheckWorkBook()) return;

            // save work book   
            this._filePath = filePath;
            bool b = this._app.DisplayAlerts;
            this._app.DisplayAlerts = false;

            // save work book               
            this._wb.SaveAs(this._filePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            this._app.DisplayAlerts = b;
        }


        /// <summary>
        /// 关闭excel
        /// </summary>
        /// <returns></returns>
        public bool CloseExcel()
        {
            try
            {
                if (this._app != null) // isRunning是判断xlApp是怎么启动的flag.    
                {
                    this._app.Quit();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_app);
                    //释放COM组件，其实就是将其引用计数减1    
                    //foreach (System.Diagnostics.Process theProc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                    //{
                    //    //先关闭图形窗口。如果关闭失败...有的时候在状态里看不到图形窗口的excel了，    
                    //    //但是在进程里仍然有EXCEL.EXE的进程存在，那么就需要杀掉它:p    
                    //    if (theProc.CloseMainWindow() == false)
                    //    {
                    //        theProc.Kill();
                    //    }
                    //}

                    ReleaseCom();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        /// <summary>   
        /// 设置当前工作Sheet（序号：从1记起）   
        /// </summary>   
        /// <param name="sheetIndex"></param>   
        public void SetCurrentSheet(int sheetIndex)
        {
            // check workbook    
            if (!this.CheckWorkBook()) return;

            // set sheet object   
            this._shIndex = sheetIndex;
            this._ws = (_Worksheet)this._wb.Worksheets[sheetIndex];
            this.CurentWorkSheet = _ws;
           
        }

        /// <summary>   
        /// 设置当前工作Sheet（序号：从1记起）   
        /// </summary>   
        /// <param name="sheetIndex"></param>   
        public void SetCurrentSheet(string SheetName)
        {
            // check workbook    
            if (!this.CheckWorkBook()) return;

            // set sheet object   
            this._ws = (_Worksheet)this._wb.Worksheets[SheetName];
            this._shIndex = this._ws.Index;
        }


        /// <summary>
        /// 获取当前Worksheet
        /// </summary>
        /// <param name="sheetIndex">第几个Sheet（序号：从1记起）</param>
        /// <returns></returns>
        public _Worksheet GetCurrentSheet(int sheetIndex)
        {
            return (_Worksheet)this._wb.Worksheets[sheetIndex];
        }

        /// <summary>   
        /// 删除一个工作表   
        /// </summary>   
        /// <param name="SheetName"></param>   
        public void DeleteSheet()
        {
            // check workbook    
            if (!this.CheckSheet()) return;

            this._ws.Delete();
        }

        /// <summary>   
        /// 改名   
        /// </summary>   
        /// <param name="newName"></param>   
        public void RenameSheet(string newName)
        {
            // check workbook    
            if (!this.CheckSheet()) return;

            this._ws.Name = newName;
        }

        /// <summary>   
        /// 创建Sheet   
        /// </summary>   
        /// <param name="newName"></param>   
        public void CreateSheet(string newName)
        {
            // check workbook    
            if (!this.CheckWorkBook()) return;

            this._wb.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        }

        /// <summary>   
        /// 获取数量   
        /// </summary>   
        /// <returns></returns>   
        public int GetSheetCount()
        {
            // check workbook    
            if (!this.CheckWorkBook()) return -1;

            return this._wb.Worksheets.Count;
        }
        #endregion

        #region sheet operation

        /// <summary>
        /// 删除指定列的数据
        /// </summary>
        /// <param name="w"></param>
        /// <param name="columnNum"></param>
        public void DeleteColumnData(_Worksheet w, int columnNum)
        {
            ((Range)(w.Columns[columnNum, System.Type.Missing])).Delete(System.Type.Missing);
        }
        /// <summary>
        /// 指定位置插入指定数量的行
        /// </summary>
        /// <param name="w"></param>
        /// <param name="columnNum"></param>
        public void InsertRow( int x,  int count)
        {

            object dd = ((Excel.Range)_CurentWorkSheet.Rows[x, System.Type.Missing]);

            for (int i = 0; i < count; i++)
            {
                ((Excel.Range)_CurentWorkSheet.Rows[x, System.Type.Missing]).EntireRow.Insert(0);
                ((Excel.Range)_CurentWorkSheet.Rows[x, System.Type.Missing]).EntireRow.Copy(((Excel.Range)_CurentWorkSheet.Rows[x+1, System.Type.Missing]));
            } 
        }


        /// <summary>   
        /// 设置单元值   
        /// </summary>   
        /// <param name="x"></param>   
        /// <param name="y"></param>   
        /// <param name="value"></param>   
        public void SetCellValue(int x, int y, object value)
        {
            if (!this.CheckSheet()) return;
            this._ws.Cells[x, y] = value;
        }

        /// <summary>   
        /// 合并单元格   
        /// </summary>   
        /// <param name="x1"></param>   
        /// <param name="y1"></param>   
        /// <param name="x2"></param>   
        /// <param name="y2"></param>   
        public void UniteCells(int x1, int y1, int x2, int y2)
        {
            if (!this.CheckSheet()) return;
            this._ws.get_Range(this._ws.Cells[x1, y1], this._ws.Cells[x2, y2]).Merge(Type.Missing);
        }

        /// <summary>   
        /// 将内存中数据表格插入到Excel指定工作表的指定位置 为在使用模板时控制格式时使用一   
        /// </summary>   
        /// <param name="dt"></param>   
        /// <param name="startX"></param>   
        /// <param name="startY"></param>   
        public void InsertTable(System.Data.DataTable dt, int startX, int startY)
        {
            if (!this.CheckSheet()) return;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    this._ws.Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();

                }

            }
        }

        /// <summary>   
        /// 获取单元格值   
        /// </summary>   
        /// <param name="cellName"></param>   
        /// <returns></returns>   
        public object GetCellValue(string cellName)
        {
            if (!this.CheckSheet()) return null;

            Range range = this._ws.get_Range(cellName, Type.Missing);

            

            return range.Value2;
        }

        /// <summary>   
        /// 获取单元格值： Value2 
        /// </summary>   
        /// <param name="row"></param>   
        /// <param name="col"></param>   
        /// <returns></returns>   
        public object GetCellValue(int row, int col)
        {
            if (!this.CheckSheet()) return null;

            Range range = (Range)this._ws.Cells[row, col];

            return range.Value2;

        }
      

        public int RowCount
        {
            get { return this._ws.Rows.Count ; }
          
        }
        public int ColumnCount
        {
            get { return this._ws.Columns.Count ; }

        }

        /// <summary>   
        /// 获取单元格值：Text；读取日期时使用，因excel2003和excel2007读取日期时range.Value2的值不同
        /// </summary>   
        /// <param name="row"></param>   
        /// <param name="col"></param>   
        /// <returns></returns>   
        public object GetCellValue1(int row, int col)
        {
            if (!this.CheckSheet()) return null;

            Range range = (Range)this._ws.Cells[row, col];

            return range.Text;
        }



        public string GetStringValue(string cellName)
        {
            object val = this.GetCellValue(cellName);
            string result = "";

            if (val != null) result = val.ToString();

            return result;
        }

        public string GetStringValue(int row, int col)
        {
            object val = this.GetCellValue(row, col);
            string result = "";

            if (val != null) result = val.ToString();

            return result;
        }

        public double GetDoubleValue(string cellName)
        {
            object val = this.GetCellValue(cellName);
            string result = "";

            if (val != null) result = val.ToString();

            double number = 0d;
            if (double.TryParse(result, out number))
            {
                number = double.Parse(result);
            }
            else
            {
                number = 0d;
            }

            return number;
        }

        public double GetDoubleValue(int row, int col)
        {
            object val = this.GetCellValue(row, col);
            string result = "";

            if (val != null) result = val.ToString();

            double number = 0d;
            if (double.TryParse(result, out number))
            {
                number = double.Parse(result);
            }
            else
            {
                number = 0d;
            }

            return number;
        }


        /// <summary>
        /// 读取excel日期时使用
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public DateTime GetDatetimeValue(int row, int col)
        {
            object val = this.GetCellValue1(row, col);
            DateTime result = new DateTime();

            if (result != null)
                result = Convert.ToDateTime(val.ToString());

            return result;
        }

        #endregion   
    }
}
