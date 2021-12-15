namespace Repair.Report
{
    partial class ServiceQualityFilter
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
            this.BeginTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.EngList = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(43, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "报修日期范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "到";
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(138, 124);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(124, 21);
            this.BeginTime.TabIndex = 6;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(313, 124);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(141, 21);
            this.EndTime.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(411, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // EngList
            // 
            this.EngList.Location = new System.Drawing.Point(138, 165);
            this.EngList.Name = "EngList";
            this.EngList.Size = new System.Drawing.Size(267, 21);
            this.EngList.TabIndex = 16;
            this.EngList.TextChanged += new System.EventHandler(this.EngList_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "工程师：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ServiceQualityFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 342);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.EngList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginTime);
            this.Controls.Add(this.EndTime);
            this.Name = "ServiceQualityFilter";
            this.Text = "服务质量明细";
            this.OnExceSQL += new Bao.Report.FormFilterBase.ExecSQL(this.ServiceQualityFilter_OnExceSQL);
            this.OnSearchWhere += new Bao.Report.FormFilterBase.SearchWhere1(this.ServiceQualityFilter_OnSearchWhere);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.EndTime, 0);
            this.Controls.SetChildIndex(this.BeginTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.EngList, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker BeginTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox EngList;
        private System.Windows.Forms.Label label6;
    }
}