using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace FrmLookUp
{
  
    
    public partial class RiliFrmLookUpBase : Form
    {
        //FieldList[] ObjFieldList;
        public GetResultRow objResutlRow;
        public  DataAccess.ILookUp objLookUp;
        private System.Data.DataTable table1;
        public  Boolean _ClickClose = true;
        public FrmLookUp.ILookupClear btn;
        #region 构造函数
        public RiliFrmLookUpBase(string DllFullPath, string FullClassName)
        {
            InitializeComponent();
            System.Reflection.Assembly ass;
            ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + @"\" + DllFullPath);
            objLookUp = (DataAccess.ILookUp)ass.CreateInstance(FullClassName);
        }

        public RiliFrmLookUpBase(string SQL)
        {
            InitializeComponent();
            objLookUp = new DataAccess.RiliLookUp();
            ((DataAccess.LookUpSQL)objLookUp).SQL = SQL;

        }

        public RiliFrmLookUpBase()
        {
            InitializeComponent();

        }
        public void Init(string SQL) {
            objLookUp = new DataAccess.RiliLookUp();
            ((DataAccess.RiliLookUp)objLookUp).SQL = SQL;
            Exec();
        }
        public void Init(string DllFullPath, string FullClassName) {
            System.Reflection.Assembly ass;
            ass = System.Reflection.Assembly.LoadFile(Application.StartupPath + @"\" + DllFullPath);
            objLookUp = (DataAccess.ILookUp)ass.CreateInstance(FullClassName);
        }

        public void Init(DataTable dt)
        {
            this.gridControl1.DataSource = dt;
        }

        #endregion 
        /// <summary>
        /// 产生列表内容
        /// </summary>
        public void Exec()
        {
            try
            {
                table1 = objLookUp.GetInfo();

                //this.gridView1.Columns.Clear();
                //for (int i = 0; i <table1.Columns.Count; i++)
                //{
                //    DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                //    gridColumn1.FieldName = table1.Columns[i].ColumnName;
                //    gridColumn1.OptionsColumn.AllowFocus = false;
                //    gridColumn1.OptionsColumn.ReadOnly = true;
                //    gridColumn1.Visible = true;
                //    gridColumn1.VisibleIndex = 0;
                //    gridColumn1.Width = 79;
                //    gridView1.Columns.Add(gridColumn1 );

                //}

                // this.dataGridView1.DataSource = table1;
                this.gridControl1.DataSource = table1;
            }
            catch (Exception ex)
            {
                
            }
            
            
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLookUpBase_Load(object sender, EventArgs e)
        {
            this.gridView1.IndicatorWidth = 40;
            Exec();
            
        }
        //public void SetColumnsTitle(string Titles)
        //{
        //    if (Titles == "" || Titles==null) return;
        //    char[] Cr=new char[1];
        //    Cr[0] = ',';
        //    int k=0;
        //    string[] ColumnsTitle = Titles.Split(Cr[0]);
        //    for(int i=0;i<this.dataGridView1.Columns.Count ;i++)
        //    {
        //        for (int j = 0; j < ColumnsTitle.Length; j++)
        //        {
        //            if (dataGridView1.Columns[i].DataPropertyName.ToUpper() == ColumnsTitle[j].Substring(0, ColumnsTitle[j].IndexOf("=")).ToUpper())
        //            {
        //                this.dataGridView1.Columns[i].HeaderText = ColumnsTitle[j].Substring(ColumnsTitle[j].IndexOf("=") + 1, ColumnsTitle[j].Length - ColumnsTitle[j].IndexOf("=")-1 ).ToString();
        //                break;
        //            }
        //        }
        //    }
        //    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
        //    {
        //        if (dataGridView1.Columns[i].DataPropertyName.ToUpper() == dataGridView1.Columns[i].HeaderText.ToUpper())
        //        {
        //            this.dataGridView1.Columns[i].Visible = false;
        //        }
        //        else
        //        {
        //            k++;
        //        }
        //    }
        //    ObjFieldList = new FieldList[k];
        //    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
        //    {
        //        if (this.dataGridView1.Columns[i].Visible == true)
        //        {
        //            //ObjFieldList[i] = new FieldList(dataGridView1.Columns[i].HeaderText.ToString(), dataGridView1.Columns[i].DataPropertyName.ToString());


        //            this.ComBoFieldTitle.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
        //            if (null == titleHT)
        //            {
        //                titleHT = new Hashtable();

        //            }

        //            titleHT.Add(dataGridView1.Columns[i].HeaderText.ToString(), dataGridView1.Columns[i].Name.ToString());
        //        }
        //    }

        //    this.ComBoFieldTitle.SelectedIndex = 0;
            
            
        //}

		/// <summary>
		/// 设置列标题
		/// </summary>
		/// <param name="Titles"></param>
        public void SetColumnsTitle(string Titles)
        {
            if (Titles == "" || Titles == null) return;
            char[] Cr = new char[1];
            Cr[0] = ',';
            int k = 0;
            string[] ColumnsTitle = Titles.Split(Cr[0]);
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                for (int j = 0; j < ColumnsTitle.Length; j++)
                {
                    if (gridView1.Columns[i].FieldName.Trim().ToUpper() == ColumnsTitle[j].Substring(0, ColumnsTitle[j].IndexOf("=")).Trim().ToUpper())
                    {
                        this.gridView1.Columns[i].Caption = ColumnsTitle[j].Substring(ColumnsTitle[j].IndexOf("=") + 1, ColumnsTitle[j].Length - ColumnsTitle[j].IndexOf("=") - 1).ToString();
                        this.gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                        this.gridView1.Columns[i].Width = 200;
                        break;
                    }
                }
            }
			//循环所有列，如果列名和列标题相同，则将该列隐藏
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName.ToUpper() == gridView1.Columns[i].Caption.ToUpper())
                {
                    this.gridView1.Columns[i].Visible = false;
                }
                else
                {
                    k++;
                }
            }
           

        }

		/// <summary>
		/// 设置列的宽
		/// </summary>
		/// <param name="ColumnsWidth"></param>
		public void SetColumnsWidth(string ColumnsWidth) {
			if (ColumnsWidth == "" || ColumnsWidth == null)
				return;
			char[] Cr = new char[1];
			Cr[0] = ',';
			string[] ColumnsTitle = ColumnsWidth.Split(Cr[0]);
			for (int i = 0; i < this.gridView1.Columns.Count; i++) {
				for (int j = 0; j < ColumnsTitle.Length; j++) {
					if (gridView1.Columns[i].FieldName.ToUpper() == ColumnsTitle[j].Substring(0, ColumnsTitle[j].IndexOf("=")).ToUpper()) {
						this.gridView1.Columns[i].Width = Convert.ToInt32(ColumnsTitle[j].Substring(ColumnsTitle[j].IndexOf("=") + 1, ColumnsTitle[j].Length - ColumnsTitle[j].IndexOf("=") - 1));
						this.gridView1.Columns[i].OptionsColumn.AllowEdit = false;
						break;
					}
				}
			}
		}

        /// <summary>
        /// 设置窗体大小和标题
        /// </summary>
        /// <param name="_frmWidth">宽度</param>
        /// <param name="_frmHigth">高度</param>
        /// <param name="_frmTitle">窗体标题</param>
        public void SetFromSizeAndTitle(int _frmWidth,int _frmHigth,string _frmTitle) {
            if (_frmWidth > 0 || _frmHigth > 0) {
                this.Size = new Size(_frmWidth, _frmHigth);
            }
            if (string.IsNullOrEmpty(_frmTitle) == false) {
                this.Text = _frmTitle;
            }
        }

        /// <summary>
        /// 是否显示在任务栏
        /// </summary>
        /// <param name="_isShowInTaskBar">是否显示(true代表显示，false表示不显示)</param>
        public void SetShowInTaskBar(bool _isShowInTaskBar) {
            this.ShowInTaskbar = _isShowInTaskBar;
        }

        private Hashtable titleHT=null;
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            System.Data.DataRowView ee = (System.Data.DataRowView)dataGridView1.CurrentRow.DataBoundItem;
            objResutlRow(ee.Row);
            if (_ClickClose)
                this.Close();
            
        }
        private string FieldType(string FieldName)
        {   
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if ((this.dataGridView1.DataSource as DataTable).Columns[i].ColumnName.Trim() == FieldName)
                {
                    return (this.dataGridView1.DataSource as DataTable).Columns[i].DataType.ToString();
                }
            }
            return "";
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            //Boolean Like=true;
            //for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            //{
            //    if (titleHT[this.ComBoFieldTitle.Text].ToString().Trim() == (this.dataGridView1.DataSource as DataTable).Columns[i].ColumnName .Trim())
            //    {
            //        if ((this.dataGridView1.DataSource as DataTable).Columns[i].DataType.ToString() == "System.DateTime")
            //        {
            //            Like = false;
            //        }
            //    }
            //}
            if (FieldType(titleHT[this.ComBoFieldTitle.Text].ToString().Trim()) == "System.DateTime")
            {
               // DateTime dd = DateTime.Parse(this.txtFieldValue.Text.Trim());
                (this.dataGridView1.DataSource as DataTable).DefaultView.RowFilter = 
                        titleHT[this.ComBoFieldTitle.Text].ToString().Trim() + " >='" + this.dateTime1.Value.ToShortDateString() + "' and "
                        + titleHT[this.ComBoFieldTitle.Text].ToString().Trim() + "<='" + this.dateTime1.Value.AddDays(1).ToShortDateString() + "' ";
            }
            else
            {
                (this.dataGridView1.DataSource as DataTable).DefaultView.RowFilter = titleHT[this.ComBoFieldTitle.Text].ToString().Trim() + " like '%" + this.txtFieldValue.Text.Trim() + "%'";
            }
         }

      

        private void ComBoFieldTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FieldType(titleHT[this.ComBoFieldTitle.Text].ToString().Trim()) == "System.DateTime")
            {
                dateTime1.Visible = true;
                txtFieldValue.Visible = false;
            }
            else
            {
                dateTime1.Visible = false;
                txtFieldValue.Visible = true;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                objResutlRow(this.gridView1.GetDataRow(gridView1.FocusedRowHandle));
                if (_ClickClose)
                    this.Hide();
            }
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e) {
            //this.gridView1.IndicatorWidth = 40;
            //e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //if (e.RowHandle<0)
            //{
            //    e.Info.DisplayText = "序号";
            //}

            if (e.Info.IsRowIndicator && e.RowHandle >= 0) {
                e.Info.DisplayText = Convert.ToString(Convert.ToInt32(e.RowHandle.ToString()) + 1);
            }
        }

        private void FrmLookUpBase_FormClosing(object sender, FormClosingEventArgs e) {
           // this.Hide();
           // e.Cancel = true;
        }

        private void FrmLookUpBase_FormClosed(object sender, FormClosedEventArgs e) {
            this.Dispose();
            btn.Clear ();
        }
    }



   
}