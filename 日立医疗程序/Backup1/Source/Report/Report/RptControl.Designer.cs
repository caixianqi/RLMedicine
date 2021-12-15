namespace Bao.Report
{
    partial class RptControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptControl));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._MentItemPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this._MentItemPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this._MentItemPrint3 = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this._MentItemPrint4 = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this._MentItemPrint5 = new System.Windows.Forms.ToolStripMenuItem();
            this.所有行ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择的行ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.列显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.列显示ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查询ToolStripMenuItem.Image = global::Report.Properties.Resources.search1;
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.hTMLToolStripMenuItem,
            this.文本ToolStripMenuItem});
            this.导出ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.导出ToolStripMenuItem.Image = global::Report.Properties.Resources.worksheet;
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem,
            this.选择的行ToolStripMenuItem});
            this.excelToolStripMenuItem.Image = global::Report.Properties.Resources.bill;
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // 所有行ToolStripMenuItem
            // 
            this.所有行ToolStripMenuItem.Name = "所有行ToolStripMenuItem";
            this.所有行ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.所有行ToolStripMenuItem.Text = "所有行";
            this.所有行ToolStripMenuItem.Click += new System.EventHandler(this.所有行ToolStripMenuItem_Click);
            // 
            // 选择的行ToolStripMenuItem
            // 
            this.选择的行ToolStripMenuItem.Name = "选择的行ToolStripMenuItem";
            this.选择的行ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.选择的行ToolStripMenuItem.Text = "选择的行";
            this.选择的行ToolStripMenuItem.Click += new System.EventHandler(this.选择的行ToolStripMenuItem_Click);
            // 
            // hTMLToolStripMenuItem
            // 
            this.hTMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem1,
            this.选择的行ToolStripMenuItem1});
            this.hTMLToolStripMenuItem.Image = global::Report.Properties.Resources.bar_10;
            this.hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            this.hTMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hTMLToolStripMenuItem.Text = "HTML";
            // 
            // 所有行ToolStripMenuItem1
            // 
            this.所有行ToolStripMenuItem1.Name = "所有行ToolStripMenuItem1";
            this.所有行ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.所有行ToolStripMenuItem1.Text = "所有行";
            this.所有行ToolStripMenuItem1.Click += new System.EventHandler(this.所有行ToolStripMenuItem1_Click);
            // 
            // 选择的行ToolStripMenuItem1
            // 
            this.选择的行ToolStripMenuItem1.Name = "选择的行ToolStripMenuItem1";
            this.选择的行ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.选择的行ToolStripMenuItem1.Text = "选择的行";
            this.选择的行ToolStripMenuItem1.Click += new System.EventHandler(this.选择的行ToolStripMenuItem1_Click);
            // 
            // 文本ToolStripMenuItem
            // 
            this.文本ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem2,
            this.选择的行ToolStripMenuItem2});
            this.文本ToolStripMenuItem.Image = global::Report.Properties.Resources.detail;
            this.文本ToolStripMenuItem.Name = "文本ToolStripMenuItem";
            this.文本ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文本ToolStripMenuItem.Text = "文本";
            // 
            // 所有行ToolStripMenuItem2
            // 
            this.所有行ToolStripMenuItem2.Name = "所有行ToolStripMenuItem2";
            this.所有行ToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.所有行ToolStripMenuItem2.Text = "所有行";
            this.所有行ToolStripMenuItem2.Click += new System.EventHandler(this.所有行ToolStripMenuItem2_Click);
            // 
            // 选择的行ToolStripMenuItem2
            // 
            this.选择的行ToolStripMenuItem2.Name = "选择的行ToolStripMenuItem2";
            this.选择的行ToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.选择的行ToolStripMenuItem2.Text = "选择的行";
            this.选择的行ToolStripMenuItem2.Click += new System.EventHandler(this.选择的行ToolStripMenuItem2_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MentItemPrint1,
            this._MentItemPrint2,
            this._MentItemPrint3,
            this._MentItemPrint4,
            this._MentItemPrint5});
            this.打印ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.打印ToolStripMenuItem.Image = global::Report.Properties.Resources.打印;
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // _MentItemPrint1
            // 
            this._MentItemPrint1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem5,
            this.选择的行ToolStripMenuItem5});
            this._MentItemPrint1.Image = global::Report.Properties.Resources._1;
            this._MentItemPrint1.Name = "_MentItemPrint1";
            this._MentItemPrint1.Size = new System.Drawing.Size(152, 22);
            this._MentItemPrint1.Text = "格式1";
            // 
            // 所有行ToolStripMenuItem5
            // 
            this.所有行ToolStripMenuItem5.Name = "所有行ToolStripMenuItem5";
            this.所有行ToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.所有行ToolStripMenuItem5.Text = "所有行";
            this.所有行ToolStripMenuItem5.Click += new System.EventHandler(this.所有行ToolStripMenuItem5_Click);
            // 
            // 选择的行ToolStripMenuItem5
            // 
            this.选择的行ToolStripMenuItem5.Name = "选择的行ToolStripMenuItem5";
            this.选择的行ToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.选择的行ToolStripMenuItem5.Text = "选择的行";
            this.选择的行ToolStripMenuItem5.Click += new System.EventHandler(this.选择的行ToolStripMenuItem5_Click);
            // 
            // _MentItemPrint2
            // 
            this._MentItemPrint2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem6,
            this.选择的行ToolStripMenuItem6});
            this._MentItemPrint2.Image = global::Report.Properties.Resources._2;
            this._MentItemPrint2.Name = "_MentItemPrint2";
            this._MentItemPrint2.Size = new System.Drawing.Size(152, 22);
            this._MentItemPrint2.Text = "格式2";
            // 
            // 所有行ToolStripMenuItem6
            // 
            this.所有行ToolStripMenuItem6.Name = "所有行ToolStripMenuItem6";
            this.所有行ToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.所有行ToolStripMenuItem6.Text = "所有行";
            this.所有行ToolStripMenuItem6.Click += new System.EventHandler(this.所有行ToolStripMenuItem5_Click);
            // 
            // 选择的行ToolStripMenuItem6
            // 
            this.选择的行ToolStripMenuItem6.Name = "选择的行ToolStripMenuItem6";
            this.选择的行ToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.选择的行ToolStripMenuItem6.Text = "选择的行";
            this.选择的行ToolStripMenuItem6.Click += new System.EventHandler(this.选择的行ToolStripMenuItem5_Click);
            // 
            // _MentItemPrint3
            // 
            this._MentItemPrint3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem7,
            this.选择的行ToolStripMenuItem7});
            this._MentItemPrint3.Image = ((System.Drawing.Image)(resources.GetObject("_MentItemPrint3.Image")));
            this._MentItemPrint3.Name = "_MentItemPrint3";
            this._MentItemPrint3.Size = new System.Drawing.Size(152, 22);
            this._MentItemPrint3.Text = "格式3";
            // 
            // 所有行ToolStripMenuItem7
            // 
            this.所有行ToolStripMenuItem7.Name = "所有行ToolStripMenuItem7";
            this.所有行ToolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.所有行ToolStripMenuItem7.Text = "所有行";
            this.所有行ToolStripMenuItem7.Click += new System.EventHandler(this.所有行ToolStripMenuItem5_Click);
            // 
            // 选择的行ToolStripMenuItem7
            // 
            this.选择的行ToolStripMenuItem7.Name = "选择的行ToolStripMenuItem7";
            this.选择的行ToolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.选择的行ToolStripMenuItem7.Text = "选择的行";
            this.选择的行ToolStripMenuItem7.Click += new System.EventHandler(this.选择的行ToolStripMenuItem5_Click);
            // 
            // _MentItemPrint4
            // 
            this._MentItemPrint4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem8,
            this.选择的行ToolStripMenuItem8});
            this._MentItemPrint4.Image = ((System.Drawing.Image)(resources.GetObject("_MentItemPrint4.Image")));
            this._MentItemPrint4.Name = "_MentItemPrint4";
            this._MentItemPrint4.Size = new System.Drawing.Size(152, 22);
            this._MentItemPrint4.Text = "格式4";
            // 
            // 所有行ToolStripMenuItem8
            // 
            this.所有行ToolStripMenuItem8.Name = "所有行ToolStripMenuItem8";
            this.所有行ToolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.所有行ToolStripMenuItem8.Text = "所有行";
            this.所有行ToolStripMenuItem8.Click += new System.EventHandler(this.所有行ToolStripMenuItem5_Click);
            // 
            // 选择的行ToolStripMenuItem8
            // 
            this.选择的行ToolStripMenuItem8.Name = "选择的行ToolStripMenuItem8";
            this.选择的行ToolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.选择的行ToolStripMenuItem8.Text = "选择的行";
            this.选择的行ToolStripMenuItem8.Click += new System.EventHandler(this.选择的行ToolStripMenuItem5_Click);
            // 
            // _MentItemPrint5
            // 
            this._MentItemPrint5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有行ToolStripMenuItem9,
            this.选择的行ToolStripMenuItem9});
            this._MentItemPrint5.Image = ((System.Drawing.Image)(resources.GetObject("_MentItemPrint5.Image")));
            this._MentItemPrint5.Name = "_MentItemPrint5";
            this._MentItemPrint5.Size = new System.Drawing.Size(152, 22);
            this._MentItemPrint5.Text = "格式5";
            // 
            // 所有行ToolStripMenuItem9
            // 
            this.所有行ToolStripMenuItem9.Name = "所有行ToolStripMenuItem9";
            this.所有行ToolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.所有行ToolStripMenuItem9.Text = "所有行";
            this.所有行ToolStripMenuItem9.Click += new System.EventHandler(this.所有行ToolStripMenuItem5_Click);
            // 
            // 选择的行ToolStripMenuItem9
            // 
            this.选择的行ToolStripMenuItem9.Name = "选择的行ToolStripMenuItem9";
            this.选择的行ToolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.选择的行ToolStripMenuItem9.Text = "选择的行";
            this.选择的行ToolStripMenuItem9.Click += new System.EventHandler(this.选择的行ToolStripMenuItem5_Click);
            // 
            // 列显示ToolStripMenuItem
            // 
            this.列显示ToolStripMenuItem.Checked = true;
            this.列显示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.列显示ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.列显示ToolStripMenuItem.Image = global::Report.Properties.Resources.column;
            this.列显示ToolStripMenuItem.Name = "列显示ToolStripMenuItem";
            this.列显示ToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.列显示ToolStripMenuItem.Text = "显示列";
            this.列显示ToolStripMenuItem.Click += new System.EventHandler(this.列显示ToolStripMenuItem_Click);
            // 
            // RptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "RptControl";
            this.Size = new System.Drawing.Size(780, 23);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文本ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _MentItemPrint3;
        private System.Windows.Forms.ToolStripMenuItem _MentItemPrint4;
        private System.Windows.Forms.ToolStripMenuItem _MentItemPrint5;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem 所有行ToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem 选择的行ToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem _MentItemPrint1;

        
        private System.Windows.Forms.ToolStripMenuItem _MentItemPrint2;
        private System.Windows.Forms.ToolStripMenuItem 列显示ToolStripMenuItem;
        
    }
}
