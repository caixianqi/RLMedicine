namespace Bao.XReport
{
    partial class PreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.previewControl1 = new XtraReportsDemos.PreviewControl();
            this.SuspendLayout();
            // 
            // previewControl1
            // 
            this.previewControl1.Caption = new DevExpress.Utils.Frames.ApplicationCaption();
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Location = new System.Drawing.Point(0, 0);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.Report = null;
            this.previewControl1.Size = new System.Drawing.Size(771, 480);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.TutorialName = "";
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 480);
            this.Controls.Add(this.previewControl1);
            this.Name = "PreviewForm";
            this.Text = "PreviewForm";
            this.ResumeLayout(false);

        }

        #endregion

        public XtraReportsDemos.PreviewControl previewControl1;

    }
}