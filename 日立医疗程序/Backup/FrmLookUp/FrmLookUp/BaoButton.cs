using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FrmLookUp
{
    [DefaultEvent("OnLookUpClosed")]
    public partial class BaoButton : UserControl, ILookupClear
    {
        public delegate void LookUpClosed(object sender, LookUpEventArgs e);
        public delegate void BaoBeforClick(object sender, EventArgs e);

        public BaoButton()
        {
            InitializeComponent();
        }
        #region 成员
        
        private string _dllFullPath="";
        private string _fullClassName="";
        private string _sql="";
        
        private string _titleNames;
		private string _ColumnsWidth;
        private int _frmHigth;
        private int _frmWidth;
        private string _frmTitle;
        private bool _isShowInTaskBar;

     
        private Boolean _ClickClose;
        
        public Boolean BaoClickClose
        {
            get { return _ClickClose; }
            set { _ClickClose = value; }
        }
       
        public string BaoBtnCaption
        {
            get { return this.button1.Text ; }
            set { this.button1.Text = value; }
        }
        #endregion

        public event LookUpClosed OnLookUpClosed;
        public event BaoBeforClick OnBaoBeforClick;
        
        public FrmLookUp.FrmLookUpBase LookForm ;
        
        #region 属性
      
        public Button button2
        {
            get
            {
                return this.button1;
            }
            set
            {
                this.button1 = value;
            }
        }
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
        public override string Text
        {
            get
            {
                return this.button1 .Text ;
            }
            set
            {
                this.button1.Text  = value;
            }
        }

		/// <summary>
		/// 列标题的宽度，列名和宽度之间用 , 号隔开
		/// </summary>
		public string BaoColumnsWidth {
			get {
				return _ColumnsWidth;
			}
			set {
				_ColumnsWidth = value;
			}
		}

        /// <summary>
        /// 选择窗体高度
        /// </summary>
        public int FrmHigth {
            get { return _frmHigth; }
            set { _frmHigth = value; }
        }

        /// <summary>
        /// 选择窗体宽度
        /// </summary>
        public int FrmWidth {
            get { return _frmWidth; }
            set { _frmWidth = value; }
        }

        /// <summary>
        /// 选择窗体标题
        /// </summary>
        public string FrmTitle {
            get { return _frmTitle; }
            set { _frmTitle = value; }
        }

        /// <summary>
        /// 是否显示在任务栏
        /// </summary>
        public bool IsShowInTaskBar {
            get { return _isShowInTaskBar; }
            set { _isShowInTaskBar = value; }
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
        public  void button1_Click(object sender, EventArgs e)
        {
            if (OnBaoBeforClick != null)
            {
                OnBaoBeforClick(sender, e);
            }
            try
            {
                if (LookForm == null) {
                    LookForm = new FrmLookUp.FrmLookUpBase();
                    LookForm.btn = this;
                }
                if (BaoSQL != "")
                {
                    //LookForm = new FrmLookUp.FrmLookUpBase(BaoSQL);
                    
                    LookForm.Init(BaoSQL);
                }
                else
                {
                    if (BaoDataAccDLLFullPath == "" || BaoDataAccDLLFullPath==null)
                    {
                        //return;
                        throw new Exception("属性DataAccDLLFullPath 不能为空");
                    }
                    if (BaoFullClassName == "" || BaoFullClassName==null)
                    {
                        //return;
                        throw new Exception("属性FullClassName 不能为空");
                    }
                    //LookForm = new FrmLookUp.FrmLookUpBase(BaoDataAccDLLFullPath, BaoFullClassName);
                
                    LookForm.Init(BaoDataAccDLLFullPath, BaoFullClassName);

                }
                LookForm._ClickClose = this.BaoClickClose;
                LookForm.objResutlRow = Resultrow;
                this.ParentForm.AddOwnedForm(LookForm);
                LookForm.Show();
                
                LookForm.SetColumnsTitle(BaoTitleNames);
				LookForm.SetColumnsWidth(BaoColumnsWidth);
                LookForm.SetFromSizeAndTitle(_frmWidth, _frmHigth, _frmTitle);
                LookForm.SetShowInTaskBar(_isShowInTaskBar);
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

        #region ILookupClear Members

        public void Clear() {
            
            LookForm = null;

        }

        #endregion
    }
}
