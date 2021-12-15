using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace XtraReportsDemos
{
    public class MainFeaturesControl : XtraReportsDemos.ModuleControl
	{
		private System.Windows.Forms.RichTextBox rtbFeatures;
		private System.ComponentModel.IContainer components = null;

		public MainFeaturesControl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rtbFeatures = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// rtbFeatures
			// 
			this.rtbFeatures.BackColor = System.Drawing.Color.White;
			this.rtbFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbFeatures.ForeColor = System.Drawing.Color.Black;
			this.rtbFeatures.Name = "rtbFeatures";
			this.rtbFeatures.ReadOnly = true;
			this.rtbFeatures.Size = new System.Drawing.Size(184, 124);
			this.rtbFeatures.TabIndex = 0;
			this.rtbFeatures.Text = "";
			// 
			// MainFeaturesControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.rtbFeatures});
			this.Name = "MainFeaturesControl";
			this.Size = new System.Drawing.Size(184, 124);
			this.ResumeLayout(false);

		}
		#endregion
		public override void Activate() {
            System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("XtraReportsDemos.BaseForms.ReportsAbout.rtf");
			rtbFeatures.LoadFile(stream,RichTextBoxStreamType.RichText);
		}
	}
}

