namespace Repair.Report
{
    partial class AmountManagementFilter
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReviewBeginTime = new System.Windows.Forms.DateTimePicker();
            this.ReviewEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AppBeginTime = new System.Windows.Forms.DateTimePicker();
            this.AppEndTime = new System.Windows.Forms.DateTimePicker();
            this.txtregionName = new System.Windows.Forms.TextBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.BtnRemoved3 = new System.Windows.Forms.Button();
            this.txtregion = new FrmLookUp.ButtonEdit();
            this.btnregion = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bprice = new System.Windows.Forms.CheckBox();
            this.breview = new System.Windows.Forms.CheckBox();
            this.bapp = new System.Windows.Forms.CheckBox();
            this.bregion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Size = new System.Drawing.Size(643, 42);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "报价日期范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "到";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(121, 61);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(124, 21);
            this.BeginTime.TabIndex = 6;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(296, 61);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(141, 21);
            this.EndTime.TabIndex = 7;
            this.EndTime.ValueChanged += new System.EventHandler(this.EndTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "报价回执日期范围：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "到";
            // 
            // ReviewBeginTime
            // 
            this.ReviewBeginTime.Location = new System.Drawing.Point(121, 123);
            this.ReviewBeginTime.Name = "ReviewBeginTime";
            this.ReviewBeginTime.Size = new System.Drawing.Size(124, 21);
            this.ReviewBeginTime.TabIndex = 10;
            // 
            // ReviewEndTime
            // 
            this.ReviewEndTime.Location = new System.Drawing.Point(296, 122);
            this.ReviewEndTime.Name = "ReviewEndTime";
            this.ReviewEndTime.Size = new System.Drawing.Size(141, 21);
            this.ReviewEndTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "申请开票日期范围：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "到";
            // 
            // AppBeginTime
            // 
            this.AppBeginTime.Location = new System.Drawing.Point(121, 173);
            this.AppBeginTime.Name = "AppBeginTime";
            this.AppBeginTime.Size = new System.Drawing.Size(124, 21);
            this.AppBeginTime.TabIndex = 14;
            // 
            // AppEndTime
            // 
            this.AppEndTime.Location = new System.Drawing.Point(296, 173);
            this.AppEndTime.Name = "AppEndTime";
            this.AppEndTime.Size = new System.Drawing.Size(141, 21);
            this.AppEndTime.TabIndex = 15;
            // 
            // txtregionName
            // 
            this.txtregionName.BackColor = System.Drawing.SystemColors.Window;
            this.txtregionName.Location = new System.Drawing.Point(180, 231);
            this.txtregionName.Name = "txtregionName";
            this.txtregionName.ReadOnly = true;
            this.txtregionName.Size = new System.Drawing.Size(110, 21);
            this.txtregionName.TabIndex = 81;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(343, 231);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(119, 64);
            this.listBox3.TabIndex = 76;
            // 
            // BtnRemoved3
            // 
            this.BtnRemoved3.Location = new System.Drawing.Point(468, 231);
            this.BtnRemoved3.Name = "BtnRemoved3";
            this.BtnRemoved3.Size = new System.Drawing.Size(51, 23);
            this.BtnRemoved3.TabIndex = 78;
            this.BtnRemoved3.Text = "移除";
            this.BtnRemoved3.UseVisualStyleBackColor = true;
            this.BtnRemoved3.Click += new System.EventHandler(this.BtnRemoved3_Click);
            // 
            // txtregion
            // 
            this.txtregion.BaoBtnCaption = "";
            this.txtregion.BaoClickClose = false;
            this.txtregion.BaoColumnsWidth = null;
            this.txtregion.BaoDataAccDLLFullPath = "";
            this.txtregion.BaoFullClassName = "";
            this.txtregion.BaoSQL = "";
            this.txtregion.BaoTitleNames = null;
            this.txtregion.CodeValue = null;
            this.txtregion.DecideSql = "";
            this.txtregion.FrmHigth = 0;
            this.txtregion.FrmTitle = null;
            this.txtregion.FrmWidth = 0;
            this.txtregion.IsShowInTaskBar = false;
            this.txtregion.Location = new System.Drawing.Point(61, 231);
            this.txtregion.Name = "txtregion";
            this.txtregion.Size = new System.Drawing.Size(113, 21);
            this.txtregion.TabIndex = 80;
            this.txtregion.Tag = "9999";
            this.txtregion.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.txtregion_OnLookUpClosed);
            // 
            // btnregion
            // 
            this.btnregion.Location = new System.Drawing.Point(296, 231);
            this.btnregion.Name = "btnregion";
            this.btnregion.Size = new System.Drawing.Size(41, 23);
            this.btnregion.TabIndex = 79;
            this.btnregion.Text = ">>";
            this.btnregion.UseVisualStyleBackColor = true;
            this.btnregion.Click += new System.EventHandler(this.btnregion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 77;
            this.label7.Text = "区域";
            // 
            // bprice
            // 
            this.bprice.AutoSize = true;
            this.bprice.Location = new System.Drawing.Point(459, 63);
            this.bprice.Name = "bprice";
            this.bprice.Size = new System.Drawing.Size(72, 16);
            this.bprice.TabIndex = 82;
            this.bprice.Text = "是否启用";
            this.bprice.UseVisualStyleBackColor = true;
            // 
            // breview
            // 
            this.breview.AutoSize = true;
            this.breview.Location = new System.Drawing.Point(459, 120);
            this.breview.Name = "breview";
            this.breview.Size = new System.Drawing.Size(72, 16);
            this.breview.TabIndex = 83;
            this.breview.Text = "是否启用";
            this.breview.UseVisualStyleBackColor = true;
            // 
            // bapp
            // 
            this.bapp.AutoSize = true;
            this.bapp.Location = new System.Drawing.Point(459, 173);
            this.bapp.Name = "bapp";
            this.bapp.Size = new System.Drawing.Size(72, 16);
            this.bapp.TabIndex = 84;
            this.bapp.Text = "是否启用";
            this.bapp.UseVisualStyleBackColor = true;
            // 
            // bregion
            // 
            this.bregion.AutoSize = true;
            this.bregion.Location = new System.Drawing.Point(537, 236);
            this.bregion.Name = "bregion";
            this.bregion.Size = new System.Drawing.Size(72, 16);
            this.bregion.TabIndex = 85;
            this.bregion.Text = "是否启用";
            this.bregion.UseVisualStyleBackColor = true;
            // 
            // AmountManagementFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 342);
            this.Controls.Add(this.bregion);
            this.Controls.Add(this.bapp);
            this.Controls.Add(this.breview);
            this.Controls.Add(this.bprice);
            this.Controls.Add(this.txtregionName);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.BtnRemoved3);
            this.Controls.Add(this.txtregion);
            this.Controls.Add(this.btnregion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AppBeginTime);
            this.Controls.Add(this.AppEndTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ReviewBeginTime);
            this.Controls.Add(this.ReviewEndTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginTime);
            this.Controls.Add(this.EndTime);
            this.Name = "AmountManagementFilter";
            this.Text = "金额管理表";
            this.OnExceSQL += new Bao.Report.FormFilterBase.ExecSQL(this.AmountManagementFilter_OnExceSQL);
            this.OnSearchWhere += new Bao.Report.FormFilterBase.SearchWhere1(this.AmountManagementFilter_OnSearchWhere);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.EndTime, 0);
            this.Controls.SetChildIndex(this.BeginTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ReviewEndTime, 0);
            this.Controls.SetChildIndex(this.ReviewBeginTime, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.AppEndTime, 0);
            this.Controls.SetChildIndex(this.AppBeginTime, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnregion, 0);
            this.Controls.SetChildIndex(this.txtregion, 0);
            this.Controls.SetChildIndex(this.BtnRemoved3, 0);
            this.Controls.SetChildIndex(this.listBox3, 0);
            this.Controls.SetChildIndex(this.txtregionName, 0);
            this.Controls.SetChildIndex(this.bprice, 0);
            this.Controls.SetChildIndex(this.breview, 0);
            this.Controls.SetChildIndex(this.bapp, 0);
            this.Controls.SetChildIndex(this.bregion, 0);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ReviewBeginTime;
        private System.Windows.Forms.DateTimePicker ReviewEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker AppBeginTime;
        private System.Windows.Forms.TextBox txtregionName;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button BtnRemoved3;
        private FrmLookUp.ButtonEdit txtregion;
        private System.Windows.Forms.Button btnregion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox bprice;
        private System.Windows.Forms.CheckBox breview;
        private System.Windows.Forms.CheckBox bapp;
        private System.Windows.Forms.DateTimePicker AppEndTime;
        private System.Windows.Forms.CheckBox bregion;
    }
}