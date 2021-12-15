namespace Repair.Report
{
    partial class InvUserFilter
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
            this.CustomerCode = new FrmLookUp.ButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnclient = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.MainType_beText = new System.Windows.Forms.TextBox();
            this.client = new System.Windows.Forms.Label();
            this.BtnRemoved1 = new System.Windows.Forms.Button();
            this.MainType_be = new FrmLookUp.ButtonEdit();
            this.bzhuji = new System.Windows.Forms.CheckBox();
            this.beng = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.EngName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.EngNameText = new FrmLookUp.ButtonEdit();
            this.bstd = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.InventoryStdText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.InventoryStd = new FrmLookUp.ButtonEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.ReturnDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ReturnDateBegin = new System.Windows.Forms.DateTimePicker();
            this.cb_Application = new System.Windows.Forms.CheckBox();
            this.cb_Return = new System.Windows.Forms.CheckBox();
            this.cb_ReportRepart = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ReportRepartDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.ReportRepartDateBegin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 409);
            this.panel1.Size = new System.Drawing.Size(655, 42);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "申请时间范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "到";
            // 
            // BeginTime
            // 
            this.BeginTime.Location = new System.Drawing.Point(130, 90);
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Size = new System.Drawing.Size(124, 21);
            this.BeginTime.TabIndex = 10;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(305, 90);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(141, 21);
            this.EndTime.TabIndex = 11;
            // 
            // CustomerCode
            // 
            this.CustomerCode.BaoBtnCaption = "";
            this.CustomerCode.BaoClickClose = false;
            this.CustomerCode.BaoColumnsWidth = null;
            this.CustomerCode.BaoDataAccDLLFullPath = "";
            this.CustomerCode.BaoFullClassName = "";
            this.CustomerCode.BaoSQL = "";
            this.CustomerCode.BaoTitleNames = null;
            this.CustomerCode.CodeValue = null;
            this.CustomerCode.DecideSql = "";
            this.CustomerCode.FrmHigth = 0;
            this.CustomerCode.FrmTitle = null;
            this.CustomerCode.FrmWidth = 0;
            this.CustomerCode.IsShowInTaskBar = false;
            this.CustomerCode.Location = new System.Drawing.Point(94, 0);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(184, 21);
            this.CustomerCode.TabIndex = 22;
            this.CustomerCode.Tag = "9999";
            this.CustomerCode.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "客户编号";
            this.label3.Visible = false;
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(225, 170);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(40, 23);
            this.btnclient.TabIndex = 29;
            this.btnclient.Text = ">>";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(271, 170);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(175, 52);
            this.listBox1.TabIndex = 26;
            // 
            // MainType_beText
            // 
            this.MainType_beText.BackColor = System.Drawing.SystemColors.Window;
            this.MainType_beText.Location = new System.Drawing.Point(94, 172);
            this.MainType_beText.Name = "MainType_beText";
            this.MainType_beText.ReadOnly = true;
            this.MainType_beText.Size = new System.Drawing.Size(89, 21);
            this.MainType_beText.TabIndex = 28;
            // 
            // client
            // 
            this.client.AutoSize = true;
            this.client.Location = new System.Drawing.Point(35, 175);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(53, 12);
            this.client.TabIndex = 24;
            this.client.Text = "主机型号";
            // 
            // BtnRemoved1
            // 
            this.BtnRemoved1.Location = new System.Drawing.Point(452, 170);
            this.BtnRemoved1.Name = "BtnRemoved1";
            this.BtnRemoved1.Size = new System.Drawing.Size(51, 23);
            this.BtnRemoved1.TabIndex = 27;
            this.BtnRemoved1.Text = "移除";
            this.BtnRemoved1.UseVisualStyleBackColor = true;
            this.BtnRemoved1.Click += new System.EventHandler(this.BtnRemoved1_Click);
            // 
            // MainType_be
            // 
            this.MainType_be.BaoBtnCaption = "";
            this.MainType_be.BaoClickClose = true;
            this.MainType_be.BaoColumnsWidth = null;
            this.MainType_be.BaoDataAccDLLFullPath = "";
            this.MainType_be.BaoFullClassName = "";
            this.MainType_be.BaoSQL = "";
            this.MainType_be.BaoTitleNames = null;
            this.MainType_be.CodeValue = null;
            this.MainType_be.DecideSql = "";
            this.MainType_be.FrmHigth = 0;
            this.MainType_be.FrmTitle = null;
            this.MainType_be.FrmWidth = 0;
            this.MainType_be.IsShowInTaskBar = false;
            this.MainType_be.Location = new System.Drawing.Point(189, 172);
            this.MainType_be.Name = "MainType_be";
            this.MainType_be.Size = new System.Drawing.Size(30, 21);
            this.MainType_be.TabIndex = 25;
            this.MainType_be.Tag = "99999";
            this.MainType_be.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.MainType_be_OnLookUpClosed);
            // 
            // bzhuji
            // 
            this.bzhuji.AutoSize = true;
            this.bzhuji.Location = new System.Drawing.Point(509, 170);
            this.bzhuji.Name = "bzhuji";
            this.bzhuji.Size = new System.Drawing.Size(72, 16);
            this.bzhuji.TabIndex = 30;
            this.bzhuji.Text = "是否启用";
            this.bzhuji.UseVisualStyleBackColor = true;
            // 
            // beng
            // 
            this.beng.AutoSize = true;
            this.beng.Location = new System.Drawing.Point(509, 243);
            this.beng.Name = "beng";
            this.beng.Size = new System.Drawing.Size(72, 16);
            this.beng.TabIndex = 37;
            this.beng.Text = "是否启用";
            this.beng.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(271, 243);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(175, 52);
            this.listBox2.TabIndex = 33;
            // 
            // EngName
            // 
            this.EngName.BackColor = System.Drawing.SystemColors.Window;
            this.EngName.Location = new System.Drawing.Point(94, 245);
            this.EngName.Name = "EngName";
            this.EngName.ReadOnly = true;
            this.EngName.Size = new System.Drawing.Size(89, 21);
            this.EngName.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "英文名称";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(452, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "移除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // EngNameText
            // 
            this.EngNameText.BaoBtnCaption = "";
            this.EngNameText.BaoClickClose = true;
            this.EngNameText.BaoColumnsWidth = null;
            this.EngNameText.BaoDataAccDLLFullPath = "";
            this.EngNameText.BaoFullClassName = "";
            this.EngNameText.BaoSQL = "";
            this.EngNameText.BaoTitleNames = null;
            this.EngNameText.CodeValue = null;
            this.EngNameText.DecideSql = "";
            this.EngNameText.FrmHigth = 0;
            this.EngNameText.FrmTitle = null;
            this.EngNameText.FrmWidth = 0;
            this.EngNameText.IsShowInTaskBar = false;
            this.EngNameText.Location = new System.Drawing.Point(189, 245);
            this.EngNameText.Name = "EngNameText";
            this.EngNameText.Size = new System.Drawing.Size(30, 21);
            this.EngNameText.TabIndex = 32;
            this.EngNameText.Tag = "99999";
            this.EngNameText.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.EngNameText_OnLookUpClosed);
            // 
            // bstd
            // 
            this.bstd.AutoSize = true;
            this.bstd.Location = new System.Drawing.Point(509, 321);
            this.bstd.Name = "bstd";
            this.bstd.Size = new System.Drawing.Size(72, 16);
            this.bstd.TabIndex = 44;
            this.bstd.Text = "是否启用";
            this.bstd.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(225, 321);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 23);
            this.button5.TabIndex = 43;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(271, 321);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(175, 52);
            this.listBox3.TabIndex = 40;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // InventoryStdText
            // 
            this.InventoryStdText.BackColor = System.Drawing.SystemColors.Window;
            this.InventoryStdText.Location = new System.Drawing.Point(94, 323);
            this.InventoryStdText.Name = "InventoryStdText";
            this.InventoryStdText.ReadOnly = true;
            this.InventoryStdText.Size = new System.Drawing.Size(89, 21);
            this.InventoryStdText.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "配件型号";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(452, 321);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 23);
            this.button6.TabIndex = 41;
            this.button6.Text = "移除";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // InventoryStd
            // 
            this.InventoryStd.BaoBtnCaption = "";
            this.InventoryStd.BaoClickClose = true;
            this.InventoryStd.BaoColumnsWidth = null;
            this.InventoryStd.BaoDataAccDLLFullPath = "";
            this.InventoryStd.BaoFullClassName = "";
            this.InventoryStd.BaoSQL = "";
            this.InventoryStd.BaoTitleNames = null;
            this.InventoryStd.CodeValue = null;
            this.InventoryStd.DecideSql = "";
            this.InventoryStd.FrmHigth = 0;
            this.InventoryStd.FrmTitle = null;
            this.InventoryStd.FrmWidth = 0;
            this.InventoryStd.IsShowInTaskBar = false;
            this.InventoryStd.Location = new System.Drawing.Point(189, 323);
            this.InventoryStd.Name = "InventoryStd";
            this.InventoryStd.Size = new System.Drawing.Size(30, 21);
            this.InventoryStd.TabIndex = 39;
            this.InventoryStd.Tag = "99999";
            this.InventoryStd.OnLookUpClosed += new FrmLookUp.ButtonEdit.LookUpClosed(this.InventoryStd_OnLookUpClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "归还时间范围：";
            // 
            // ReturnDateEnd
            // 
            this.ReturnDateEnd.Location = new System.Drawing.Point(305, 124);
            this.ReturnDateEnd.Name = "ReturnDateEnd";
            this.ReturnDateEnd.Size = new System.Drawing.Size(141, 21);
            this.ReturnDateEnd.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "到";
            // 
            // ReturnDateBegin
            // 
            this.ReturnDateBegin.Location = new System.Drawing.Point(130, 124);
            this.ReturnDateBegin.Name = "ReturnDateBegin";
            this.ReturnDateBegin.Size = new System.Drawing.Size(124, 21);
            this.ReturnDateBegin.TabIndex = 46;
            // 
            // cb_Application
            // 
            this.cb_Application.AutoSize = true;
            this.cb_Application.Location = new System.Drawing.Point(453, 94);
            this.cb_Application.Name = "cb_Application";
            this.cb_Application.Size = new System.Drawing.Size(72, 16);
            this.cb_Application.TabIndex = 49;
            this.cb_Application.Text = "是否启用";
            this.cb_Application.UseVisualStyleBackColor = true;
            // 
            // cb_Return
            // 
            this.cb_Return.AutoSize = true;
            this.cb_Return.Location = new System.Drawing.Point(452, 126);
            this.cb_Return.Name = "cb_Return";
            this.cb_Return.Size = new System.Drawing.Size(72, 16);
            this.cb_Return.TabIndex = 50;
            this.cb_Return.Text = "是否启用";
            this.cb_Return.UseVisualStyleBackColor = true;
            // 
            // cb_ReportRepart
            // 
            this.cb_ReportRepart.AutoSize = true;
            this.cb_ReportRepart.Location = new System.Drawing.Point(453, 67);
            this.cb_ReportRepart.Name = "cb_ReportRepart";
            this.cb_ReportRepart.Size = new System.Drawing.Size(72, 16);
            this.cb_ReportRepart.TabIndex = 55;
            this.cb_ReportRepart.Text = "是否启用";
            this.cb_ReportRepart.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "报修时间范围：";
            // 
            // ReportRepartDateEnd
            // 
            this.ReportRepartDateEnd.Location = new System.Drawing.Point(305, 63);
            this.ReportRepartDateEnd.Name = "ReportRepartDateEnd";
            this.ReportRepartDateEnd.Size = new System.Drawing.Size(141, 21);
            this.ReportRepartDateEnd.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "到";
            // 
            // ReportRepartDateBegin
            // 
            this.ReportRepartDateBegin.Location = new System.Drawing.Point(130, 63);
            this.ReportRepartDateBegin.Name = "ReportRepartDateBegin";
            this.ReportRepartDateBegin.Size = new System.Drawing.Size(124, 21);
            this.ReportRepartDateBegin.TabIndex = 52;
            // 
            // InvUserFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 451);
            this.Controls.Add(this.cb_ReportRepart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ReportRepartDateEnd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ReportRepartDateBegin);
            this.Controls.Add(this.cb_Return);
            this.Controls.Add(this.cb_Application);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ReturnDateEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ReturnDateBegin);
            this.Controls.Add(this.bstd);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.InventoryStdText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.InventoryStd);
            this.Controls.Add(this.beng);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.EngName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.EngNameText);
            this.Controls.Add(this.bzhuji);
            this.Controls.Add(this.btnclient);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.MainType_beText);
            this.Controls.Add(this.client);
            this.Controls.Add(this.BtnRemoved1);
            this.Controls.Add(this.MainType_be);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginTime);
            this.Name = "InvUserFilter";
            this.Text = "备件使用情况查询";
            this.OnSearchWhere += new Bao.Report.FormFilterBase.SearchWhere1(this.InvUserFilter_OnSearchWhere);
            this.Controls.SetChildIndex(this.BeginTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.EndTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CustomerCode, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.MainType_be, 0);
            this.Controls.SetChildIndex(this.BtnRemoved1, 0);
            this.Controls.SetChildIndex(this.client, 0);
            this.Controls.SetChildIndex(this.MainType_beText, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            this.Controls.SetChildIndex(this.btnclient, 0);
            this.Controls.SetChildIndex(this.bzhuji, 0);
            this.Controls.SetChildIndex(this.EngNameText, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.EngName, 0);
            this.Controls.SetChildIndex(this.listBox2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.beng, 0);
            this.Controls.SetChildIndex(this.InventoryStd, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.InventoryStdText, 0);
            this.Controls.SetChildIndex(this.listBox3, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.bstd, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ReturnDateBegin, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.ReturnDateEnd, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cb_Application, 0);
            this.Controls.SetChildIndex(this.cb_Return, 0);
            this.Controls.SetChildIndex(this.ReportRepartDateBegin, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.ReportRepartDateEnd, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cb_ReportRepart, 0);
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
        private FrmLookUp.ButtonEdit CustomerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox MainType_beText;
        private System.Windows.Forms.Label client;
        private System.Windows.Forms.Button BtnRemoved1;
        private FrmLookUp.ButtonEdit MainType_be;
        private System.Windows.Forms.CheckBox bzhuji;
        private System.Windows.Forms.CheckBox beng;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox EngName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private FrmLookUp.ButtonEdit EngNameText;
        private System.Windows.Forms.CheckBox bstd;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.TextBox InventoryStdText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private FrmLookUp.ButtonEdit InventoryStd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ReturnDateEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker ReturnDateBegin;
        private System.Windows.Forms.CheckBox cb_Application;
        private System.Windows.Forms.CheckBox cb_Return;
        private System.Windows.Forms.CheckBox cb_ReportRepart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker ReportRepartDateEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker ReportRepartDateBegin;
    }
}