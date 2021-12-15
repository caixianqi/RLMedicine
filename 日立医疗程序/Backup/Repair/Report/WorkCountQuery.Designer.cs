namespace Repair.Report
{
    partial class WorkCountQuery
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
            this.bcomplete = new System.Windows.Forms.CheckBox();
            this.breport = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CompleteBeginTime = new System.Windows.Forms.DateTimePicker();
            this.CompleteEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BeginTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bcomplete
            // 
            this.bcomplete.AutoSize = true;
            this.bcomplete.Location = new System.Drawing.Point(438, 186);
            this.bcomplete.Name = "bcomplete";
            this.bcomplete.Size = new System.Drawing.Size(72, 16);
            this.bcomplete.TabIndex = 20;
            this.bcomplete.Text = "是否启用";
            this.bcomplete.UseVisualStyleBackColor = true;
            // 
            // breport
            // 
            this.breport.AutoSize = true;
            this.breport.Location = new System.Drawing.Point(438, 128);
            this.breport.Name = "breport";
            this.breport.Size = new System.Drawing.Size(72, 16);
            this.breport.TabIndex = 19;
            this.breport.Text = "是否启用";
            this.breport.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "完成日期范围：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "到";
            // 
            // CompleteBeginTime
            // 
            this.CompleteBeginTime.Location = new System.Drawing.Point(116, 182);
            this.CompleteBeginTime.Name = "CompleteBeginTime";
            this.CompleteBeginTime.Size = new System.Drawing.Size(124, 21);
            this.CompleteBeginTime.TabIndex = 16;
            // 
            // CompleteEndTime
            // 
            this.CompleteEndTime.Location = new System.Drawing.Point(291, 182);
            this.CompleteEndTime.Name = "CompleteEndTime";
            this.CompleteEndTime.Size = new System.Drawing.Size(141, 21);
            this.CompleteEndTime.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "报修日期范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "到";
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(116, 128);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(124, 21);
            this.BeginTime.TabIndex = 12;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(291, 128);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(141, 21);
            this.EndTime.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkCountQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 348);
            this.Controls.Add(this.button1);
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
            this.Name = "WorkCountQuery";
            this.Text = "WorkCountQuery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkCountQuery_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox bcomplete;
        private System.Windows.Forms.CheckBox breport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker CompleteBeginTime;
        private System.Windows.Forms.DateTimePicker CompleteEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker BeginTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Button button1;
    }
}