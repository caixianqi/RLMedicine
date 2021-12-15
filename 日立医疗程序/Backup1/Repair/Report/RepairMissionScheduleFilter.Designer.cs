namespace Repair.Report
{
    partial class RepairMissionScheduleFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CustomerList = new System.Windows.Forms.TextBox();
            this.ManagerList = new System.Windows.Forms.TextBox();
            this.ZoneList = new System.Windows.Forms.TextBox();
            this.EngList = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dtAE = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtAS = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_ReportRepart = new System.Windows.Forms.CheckBox();
            this.cb_Audit = new System.Windows.Forms.CheckBox();
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
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "报修日期范围：";
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(107, 36);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(119, 21);
            this.BeginTime.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(282, 36);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(124, 21);
            this.EndTime.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "客户：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "科长：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "省份：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "工程师：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CustomerList
            // 
            this.CustomerList.Location = new System.Drawing.Point(107, 128);
            this.CustomerList.Name = "CustomerList";
            this.CustomerList.Size = new System.Drawing.Size(267, 21);
            this.CustomerList.TabIndex = 10;
            // 
            // ManagerList
            // 
            this.ManagerList.Location = new System.Drawing.Point(107, 172);
            this.ManagerList.Name = "ManagerList";
            this.ManagerList.Size = new System.Drawing.Size(267, 21);
            this.ManagerList.TabIndex = 11;
            // 
            // ZoneList
            // 
            this.ZoneList.Location = new System.Drawing.Point(107, 209);
            this.ZoneList.Name = "ZoneList";
            this.ZoneList.Size = new System.Drawing.Size(267, 21);
            this.ZoneList.TabIndex = 12;
            // 
            // EngList
            // 
            this.EngList.Location = new System.Drawing.Point(107, 249);
            this.EngList.Name = "EngList";
            this.EngList.Size = new System.Drawing.Size(267, 21);
            this.EngList.TabIndex = 13;
            this.EngList.TextChanged += new System.EventHandler(this.EngList_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(380, 247);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(380, 207);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(380, 170);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dtAE
            // 
            this.dtAE.Location = new System.Drawing.Point(282, 74);
            this.dtAE.Name = "dtAE";
            this.dtAE.Size = new System.Drawing.Size(124, 21);
            this.dtAE.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "至";
            // 
            // dtAS
            // 
            this.dtAS.Location = new System.Drawing.Point(107, 74);
            this.dtAS.Name = "dtAS";
            this.dtAS.Size = new System.Drawing.Size(119, 21);
            this.dtAS.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "审核日期范围：";
            // 
            // cb_ReportRepart
            // 
            this.cb_ReportRepart.AutoSize = true;
            this.cb_ReportRepart.Location = new System.Drawing.Point(413, 41);
            this.cb_ReportRepart.Name = "cb_ReportRepart";
            this.cb_ReportRepart.Size = new System.Drawing.Size(72, 16);
            this.cb_ReportRepart.TabIndex = 21;
            this.cb_ReportRepart.Text = "是否启用";
            this.cb_ReportRepart.UseVisualStyleBackColor = true;
            // 
            // cb_Audit
            // 
            this.cb_Audit.AutoSize = true;
            this.cb_Audit.Location = new System.Drawing.Point(413, 78);
            this.cb_Audit.Name = "cb_Audit";
            this.cb_Audit.Size = new System.Drawing.Size(72, 16);
            this.cb_Audit.TabIndex = 22;
            this.cb_Audit.Text = "是否启用";
            this.cb_Audit.UseVisualStyleBackColor = true;
            // 
            // RepairMissionScheduleFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 342);
            this.Controls.Add(this.cb_Audit);
            this.Controls.Add(this.cb_ReportRepart);
            this.Controls.Add(this.dtAE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtAS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ManagerList);
            this.Controls.Add(this.EngList);
            this.Controls.Add(this.ZoneList);
            this.Controls.Add(this.CustomerList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginTime);
            this.Controls.Add(this.label1);
            this.Name = "RepairMissionScheduleFilter";
            this.Text = "维修进度报表查询";
            this.OnExceSQL += new Bao.Report.FormFilterBase.ExecSQL(this.RepairMissionScheduleFilter_OnExceSQL);
            this.OnSearchWhere += new Bao.Report.FormFilterBase.SearchWhere1(this.RepairMissionScheduleFilter_OnSearchWhere);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.BeginTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.EndTime, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.CustomerList, 0);
            this.Controls.SetChildIndex(this.ZoneList, 0);
            this.Controls.SetChildIndex(this.EngList, 0);
            this.Controls.SetChildIndex(this.ManagerList, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dtAS, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.dtAE, 0);
            this.Controls.SetChildIndex(this.cb_ReportRepart, 0);
            this.Controls.SetChildIndex(this.cb_Audit, 0);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox CustomerList;
        private System.Windows.Forms.TextBox ManagerList;
        private System.Windows.Forms.TextBox ZoneList;
        private System.Windows.Forms.TextBox EngList;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dtAE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtAS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_ReportRepart;
        private System.Windows.Forms.CheckBox cb_Audit;
    }
}