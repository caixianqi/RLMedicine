using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
namespace FrmLookUp
{
    public delegate void LookUpClosed(object sender,LookUpEventArgs e);
    public partial class LookUpBox : DevExpress.XtraEditors.Repository.RepositoryItem
    {
        #region 成员
        private string _dllFullPath="";
        private string _fullClassName="";
        private string _sql="";
        public string _titleNames;
        #endregion
        
        public event LookUpClosed OnLookUpClosed;
        
        public FrmLookUp.FrmLookUpBase LookForm;
        #region 属性
        
        /// <summary>
        /// 列标题的中文名称，名称之间用，号分割
        /// </summary>
        public string BaoTitleNames
        {
            get
            {
                return _titleNames;
            }
            set
            {
                _titleNames = value;
            }
        }
        public string BaoText
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        /// <summary>
        /// 继承自ILookUp接口的类所在的DLL名称
        /// </summary>
        public string BaoDataAccDLLFullPath
        {
            get 
            {
                return _dllFullPath;
            }
            set
            {
                if (value == null)
                    _dllFullPath = "";
                else
                    _dllFullPath = value;
                if (_dllFullPath.Trim() != "")
                    _sql = "";

            }
 
        }
         
        /// <summary>
        /// 继承自ILookUp接口的类名称
        /// </summary>
        public  string BaoFullClassName
        {
            get 
            {
                return _fullClassName;
            }
            set
            {
                if (value == null)
                    _fullClassName = "";
                else
                    _fullClassName = value;
                if (_fullClassName.Trim() != "")
                    _sql = "";
            }
 
        }

        public string BaoSQL
        {
            get
            {
                return _sql;
            }
            set
            {
                if (null ==value )
                    _sql = "";
                else
                    _sql = value;
                if (_sql.Trim() != "")
                {
                    _dllFullPath = "";
                    _fullClassName = "";
                }
            }
        }
        #endregion 
        #region 构造函数
        public LookUpBox()
        {
            InitializeComponent();

        }
        #endregion 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (BaoSQL != "")
                {
                    LookForm = new FrmLookUp.FrmLookUpBase(BaoSQL);
                }
                else
                {
                    if (BaoDataAccDLLFullPath == "")
                    {
                        //return;
                        throw new Exception("属性DataAccDLLFullPath 不能为空");
                    }
                    if (BaoFullClassName == "")
                    {
                        //return;
                        throw new Exception("属性FullClassName 不能为空");
                    }
                    LookForm = new FrmLookUp.FrmLookUpBase(BaoDataAccDLLFullPath, BaoFullClassName);

                }
                LookForm.objResutlRow = Resultrow;
                LookForm.Show();
                LookForm.SetColumnsTitle(BaoTitleNames);
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
         

        }

        private void LookUpBox_Load(object sender, EventArgs e)
        {
            
        }
        public void Resultrow(System.Data.DataRow row1)
        {
            if (OnLookUpClosed != null)
            {
                OnLookUpClosed(this, new LookUpEventArgs(row1));
            }
        }
       
    }
}
