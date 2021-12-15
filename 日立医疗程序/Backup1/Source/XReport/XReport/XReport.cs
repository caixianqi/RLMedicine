using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.XReport
{
    public  class XReport
    {
        public static void  proview(string FormTitle,System.Data.DataSet PreviewDataset)
        {
            PreviewForm FT = new PreviewForm();
            FT.previewControl1.TutorialName = FormTitle;
            //tutorial.Caption =FormTitle;
            FT.previewControl1.BringToFront();
            FT.previewControl1.Focus();
            FT.previewControl1.DataSource = PreviewDataset; 
            FT.previewControl1.Activate();
            
            FT.Show();
        }
    }
}
