namespace Bao.BillBase.Audit
{
    partial class FrmBillAuditFlowSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       // private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlFlowSearchSet = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FlowId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFlowSearchSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlFlowSearchSet
            // 
            this.gridControlFlowSearchSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFlowSearchSet.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlFlowSearchSet.EmbeddedNavigator.Name = "";
            this.gridControlFlowSearchSet.Location = new System.Drawing.Point(0, 0);
            this.gridControlFlowSearchSet.MainView = this.gridView1;
            this.gridControlFlowSearchSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlFlowSearchSet.Name = "gridControlFlowSearchSet";
            this.gridControlFlowSearchSet.Size = new System.Drawing.Size(645, 485);
            this.gridControlFlowSearchSet.TabIndex = 12;
            this.gridControlFlowSearchSet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridControlFlowSearchSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlFlowSearchSet_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.FlowId,
            this.FlowName});
            this.gridView1.GridControl = this.gridControlFlowSearchSet;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // Id
            // 
            this.Id.Caption = "自动编号";
            this.Id.FieldName = "autoId";
            this.Id.Name = "Id";
            this.Id.Width = 67;
            // 
            // FlowId
            // 
            this.FlowId.Caption = "流程号";
            this.FlowId.FieldName = "FlowId";
            this.FlowId.Name = "FlowId";
            this.FlowId.OptionsColumn.AllowEdit = false;
            this.FlowId.Visible = true;
            this.FlowId.VisibleIndex = 0;
            this.FlowId.Width = 136;
            // 
            // FlowName
            // 
            this.FlowName.Caption = "流程名称";
            this.FlowName.FieldName = "FlowName";
            this.FlowName.Name = "FlowName";
            this.FlowName.OptionsColumn.AllowEdit = false;
            this.FlowName.Visible = true;
            this.FlowName.VisibleIndex = 1;
            this.FlowName.Width = 247;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlFlowSearchSet;
            this.gridView2.Name = "gridView2";
            // 
            // FrmBillAuditFlowSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 485);
            this.Controls.Add(this.gridControlFlowSearchSet);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBillAuditFlowSearch";
            this.Text = "选择流程";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFlowSearchSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlFlowSearchSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn FlowId;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn FlowName;
    }
}