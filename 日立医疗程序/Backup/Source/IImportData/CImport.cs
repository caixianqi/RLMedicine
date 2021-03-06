using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Bao.DataAccess;
namespace Bao.Analysis
{
    class CImport
    {
        private Bao.Analysis.IAnalysisAndSQL IObj;
        //private System.Reflection.Assembly ass;

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="AObj"></param>
        /// <param name="mErr"></param>
        private void UpLoad(string path, Bao.Analysis.IAnalysis AObj, Bao.ErrMessage.IdelegateError mErr, Bao.Analysis.IFileToDataTable  FileObj)
        {
            System.DateTime begindate = DateTime.Now;
            if (path.Trim() == "") return;
            

            System.Data.DataTable SourceDataTable = FileObj.ReadFileToDataTable(mErr);
            
            System.Data.DataTable DestTable = AObj.CreateDescTable();

            int RowCount = SourceDataTable.Rows.Count;
            int j = 0;
            int baifen = 0;
            double h = RowCount / 100;
            AObj.BeforJieXi(SourceDataTable);
            foreach (System.Data.DataRow row1 in SourceDataTable.Rows)
            {
                System.Data.DataRow destRow1 = DestTable.NewRow();
                if (AObj.JieXi(row1, destRow1, mErr))
                    DestTable.Rows.Add(destRow1);
                j++;
                baifen++;
                //if (baifen > h)
                {
                    baifen = 0;
                    mErr.ProcJD(j/RowCount);
                }
            }
            // MessageBox.Show(DestTable.Rows.Count.ToString());
            Bao.DataAccess.DataAcc.DataUpLoad(IObj, DestTable, mErr);
            IObj.AfterCommit();
            mErr.ProccErr("完成提交" + path + "  用时:" + begindate.ToString() + "--" + DateTime.Now.ToString());

        }

    }
}
