namespace RLBase
{
    partial class frmAZUnit
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InstallUnit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemInstallUnit1_CB = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.InstallUnit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemInstallUnit2_CB = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.Dept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit_Dept = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInstallUnit1_CB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInstallUnit2_CB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_Dept)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemInstallUnit1_CB,
            this.repositoryItemInstallUnit2_CB,
            this.repositoryItemTextEdit_Dept});
            this.gridControl1.Size = new System.Drawing.Size(692, 441);
            this.gridControl1.TabIndex = 76;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UserId,
            this.userName,
            this.InstallUnit1,
            this.InstallUnit2,
            this.Dept});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // UserId
            // 
            this.UserId.Caption = "用户编码";
            this.UserId.FieldName = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.OptionsColumn.AllowEdit = false;
            this.UserId.Visible = true;
            this.UserId.VisibleIndex = 0;
            this.UserId.Width = 130;
            // 
            // userName
            // 
            this.userName.Caption = "用户名称";
            this.userName.FieldName = "userName";
            this.userName.Name = "userName";
            this.userName.OptionsColumn.AllowEdit = false;
            this.userName.Visible = true;
            this.userName.VisibleIndex = 1;
            this.userName.Width = 148;
            // 
            // InstallUnit1
            // 
            this.InstallUnit1.Caption = "安装单位1";
            this.InstallUnit1.ColumnEdit = this.repositoryItemInstallUnit1_CB;
            this.InstallUnit1.FieldName = "InstallUnit1";
            this.InstallUnit1.Name = "InstallUnit1";
            this.InstallUnit1.Visible = true;
            this.InstallUnit1.VisibleIndex = 2;
            this.InstallUnit1.Width = 121;
            // 
            // repositoryItemInstallUnit1_CB
            // 
            this.repositoryItemInstallUnit1_CB.AutoHeight = false;
            this.repositoryItemInstallUnit1_CB.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemInstallUnit1_CB.Name = "repositoryItemInstallUnit1_CB";
            // 
            // InstallUnit2
            // 
            this.InstallUnit2.Caption = "安装单位2";
            this.InstallUnit2.ColumnEdit = this.repositoryItemInstallUnit2_CB;
            this.InstallUnit2.FieldName = "InstallUnit2";
            this.InstallUnit2.Name = "InstallUnit2";
            this.InstallUnit2.Visible = true;
            this.InstallUnit2.VisibleIndex = 3;
            this.InstallUnit2.Width = 115;
            // 
            // repositoryItemInstallUnit2_CB
            // 
            this.repositoryItemInstallUnit2_CB.AutoHeight = false;
            this.repositoryItemInstallUnit2_CB.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemInstallUnit2_CB.Name = "repositoryItemInstallUnit2_CB";
            // 
            // Dept
            // 
            this.Dept.Caption = "部门";
            this.Dept.ColumnEdit = this.repositoryItemTextEdit_Dept;
            this.Dept.FieldName = "Dept";
            this.Dept.Name = "Dept";
            this.Dept.Visible = true;
            this.Dept.VisibleIndex = 4;
            this.Dept.Width = 107;
            // 
            // repositoryItemTextEdit_Dept
            // 
            this.repositoryItemTextEdit_Dept.AutoHeight = false;
            this.repositoryItemTextEdit_Dept.Name = "repositoryItemTextEdit_Dept";
            // 
            // frmAZUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "frmAZUnit";
            this.Size = new System.Drawing.Size(692, 441);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInstallUnit1_CB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInstallUnit2_CB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_Dept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn UserId;
        private DevExpress.XtraGrid.Columns.GridColumn userName;
        private DevExpress.XtraGrid.Columns.GridColumn InstallUnit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemInstallUnit1_CB;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemInstallUnit2_CB;
        private DevExpress.XtraGrid.Columns.GridColumn InstallUnit1;
        private DevExpress.XtraGrid.Columns.GridColumn Dept;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit_Dept;
    }
}

