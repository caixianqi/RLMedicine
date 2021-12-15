namespace Repair.Report
{
    partial class InstallWorkCountFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.CompleteBeginTime = new System.Windows.Forms.DateTimePicker();
            this.CompleteEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.AppointBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.AppointEndTime = new System.Windows.Forms.DateTimePicker();
            this.bTask = new System.Windows.Forms.CheckBox();
            this.bappoit = new System.Windows.Forms.CheckBox();
            this.bcomplete = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "完成日期范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "到";
            // 
            // CompleteBeginTime
            // 
            this.CompleteBeginTime.Location = new System.Drawing.Point(106, 165);
            this.CompleteBeginTime.Name = "CompleteBeginTime";
            this.CompleteBeginTime.Size = new System.Drawing.Size(124, 21);
            this.CompleteBeginTime.TabIndex = 14;
            // 
            // CompleteEndTime
            // 
            this.CompleteEndTime.Location = new System.Drawing.Point(281, 165);
            this.CompleteEndTime.Name = "CompleteEndTime";
            this.CompleteEndTime.Size = new System.Drawing.Size(141, 21);
            this.CompleteEndTime.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "任务发起时间：";
            // 
            // TaskBeginTime
            // 
            this.TaskBeginTime.Location = new System.Drawing.Point(106, 47);
            this.TaskBeginTime.Name = "TaskBeginTime";
            this.TaskBeginTime.Size = new System.Drawing.Size(123, 21);
            this.TaskBeginTime.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "到";
            // 
            // TaskEndTime
            // 
            this.TaskEndTime.Location = new System.Drawing.Point(281, 47);
            this.TaskEndTime.Name = "TaskEndTime";
            this.TaskEndTime.Size = new System.Drawing.Size(141, 21);
            this.TaskEndTime.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "指派时间：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // AppointBeginTime
            // 
            this.AppointBeginTime.Location = new System.Drawing.Point(106, 104);
            this.AppointBeginTime.Name = "AppointBeginTime";
            this.AppointBeginTime.Size = new System.Drawing.Size(123, 21);
            this.AppointBeginTime.TabIndex = 22;
            this.AppointBeginTime.ValueChanged += new System.EventHandler(this.AppointBeginTime_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "到";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // AppointEndTime
            // 
            this.AppointEndTime.Location = new System.Drawing.Point(281, 104);
            this.AppointEndTime.Name = "AppointEndTime";
            this.AppointEndTime.Size = new System.Drawing.Size(141, 21);
            this.AppointEndTime.TabIndex = 24;
            this.AppointEndTime.ValueChanged += new System.EventHandler(this.AppointEndTime_ValueChanged);
            // 
            // bTask
            // 
            this.bTask.AutoSize = true;
            this.bTask.Location = new System.Drawing.Point(428, 51);
            this.bTask.Name = "bTask";
            this.bTask.Size = new System.Drawing.Size(72, 16);
            this.bTask.TabIndex = 25;
            this.bTask.Text = "是否启用";
            this.bTask.UseVisualStyleBackColor = true;
            // 
            // bappoit
            // 
            this.bappoit.AutoSize = true;
            this.bappoit.Location = new System.Drawing.Point(428, 106);
            this.bappoit.Name = "bappoit";
            this.bappoit.Size = new System.Drawing.Size(72, 16);
            this.bappoit.TabIndex = 26;
            this.bappoit.Text = "是否启用";
            this.bappoit.UseVisualStyleBackColor = true;
            // 
            // bcomplete
            // 
            this.bcomplete.AutoSize = true;
            this.bcomplete.Location = new System.Drawing.Point(428, 169);
            this.bcomplete.Name = "bcomplete";
            this.bcomplete.Size = new System.Drawing.Size(72, 16);
            this.bcomplete.TabIndex = 27;
            this.bcomplete.Text = "是否启用";
            this.bcomplete.UseVisualStyleBackColor = true;
            this.bcomplete.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InstallWorkCountFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bcomplete);
            this.Controls.Add(this.bappoit);
            this.Controls.Add(this.bTask);
            this.Controls.Add(this.AppointEndTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AppointBeginTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TaskEndTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TaskBeginTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompleteBeginTime);
            this.Controls.Add(this.CompleteEndTime);
            this.Name = "InstallWorkCountFilter";
            this.Text = "安装工作量报表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker CompleteBeginTime;
        private System.Windows.Forms.DateTimePicker CompleteEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TaskBeginTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TaskEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker AppointBeginTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker AppointEndTime;
        private System.Windows.Forms.CheckBox bTask;
        private System.Windows.Forms.CheckBox bappoit;
        private System.Windows.Forms.CheckBox bcomplete;
        private System.Windows.Forms.Button button1;
    }
}