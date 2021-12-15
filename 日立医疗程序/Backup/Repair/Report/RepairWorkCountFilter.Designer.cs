namespace Repair.Report
{
    partial class RepairQualityAndWorkFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.BeginTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CompleteBeginTime = new System.Windows.Forms.DateTimePicker();
            this.CompleteEndTime = new System.Windows.Forms.DateTimePicker();
            this.breport = new System.Windows.Forms.CheckBox();
            this.bcomplete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 300);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "报修日期范围：";
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(107, 124);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(124, 21);
            this.BeginTime.TabIndex = 2;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(282, 124);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(141, 21);
            this.EndTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "完成日期范围：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "到";
            // 
            // CompleteBeginTime
            // 
            this.CompleteBeginTime.Location = new System.Drawing.Point(107, 178);
            this.CompleteBeginTime.Name = "CompleteBeginTime";
            this.CompleteBeginTime.Size = new System.Drawing.Size(124, 21);
            this.CompleteBeginTime.TabIndex = 6;
            // 
            // CompleteEndTime
            // 
            this.CompleteEndTime.Location = new System.Drawing.Point(282, 178);
            this.CompleteEndTime.Name = "CompleteEndTime";
            this.CompleteEndTime.Size = new System.Drawing.Size(141, 21);
            this.CompleteEndTime.TabIndex = 7;
            // 
            // breport
            // 
            this.breport.AutoSize = true;
            this.breport.Location = new System.Drawing.Point(430, 125);
            this.breport.Name = "breport";
            this.breport.Size = new System.Drawing.Size(72, 16);
            this.breport.TabIndex = 9;
            this.breport.Text = "是否启用";
            this.breport.UseVisualStyleBackColor = true;
            // 
            // bcomplete
            // 
            this.bcomplete.AutoSize = true;
            this.bcomplete.Location = new System.Drawing.Point(430, 184);
            this.bcomplete.Name = "bcomplete";
            this.bcomplete.Size = new System.Drawing.Size(72, 16);
            this.bcomplete.TabIndex = 10;
            this.bcomplete.Text = "是否启用";
            this.bcomplete.UseVisualStyleBackColor = true;
            // 
            // RepairQualityAndWorkFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 342);
            this.Controls.Add(this.bcomplete);
            this.Controls.Add(this.breport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CompleteBeginTime);
            this.Controls.Add(this.CompleteEndTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginTime);
            this.Controls.Add(this.EndTime);
            this.Name = "RepairQualityAndWorkFilter";
            this.Text = "维修质量与工作量统计";
            this.OnSearchWhere += new Bao.Report.FormFilterBase.SearchWhere1(this.RepairQualityAndWorkFilter_OnSearchWhere);
            this.Controls.SetChildIndex(this.EndTime, 0);
            this.Controls.SetChildIndex(this.BeginTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.CompleteEndTime, 0);
            this.Controls.SetChildIndex(this.CompleteBeginTime, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.breport, 0);
            this.Controls.SetChildIndex(this.bcomplete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker BeginTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker CompleteBeginTime;
        private System.Windows.Forms.DateTimePicker CompleteEndTime;
        private System.Windows.Forms.CheckBox breport;
        private System.Windows.Forms.CheckBox bcomplete;
    }
}