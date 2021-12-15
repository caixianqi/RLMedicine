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
    public partial class BaoButton : UserControl
    {
        public delegate void LookUpClosed(object sender, LookUpEventArgs e);
        public delegate void BaoBeforClick(object sender, EventArgs e);

        public BaoButton()
        {
            InitializeComponent();
        }
        #region ��Ա
        
        private string _dllFullPath="";
        private string _fullClassName="";
        private string _sql="";
        
        private string _titleNames;

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
        
        public FrmLookUp.FrmLookUpBase LookForm;
        #region ����
      
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
        /// �б�����������ƣ�����֮���ã��ŷָ�
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
        /// �̳���ILookUp�ӿڵ������ڵ�DLL����
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
        /// �̳���ILookUp�ӿڵ�������
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
                if (BaoSQL != "")
                {
                    LookForm = new FrmLookUp.FrmLookUpBase(BaoSQL);
                }
                else
                {
                    if (BaoDataAccDLLFullPath == "" || BaoDataAccDLLFullPath==null)
                    {
                        //return;
                        throw new Exception("����DataAccDLLFullPath ����Ϊ��");
                    }
                    if (BaoFullClassName == "" || BaoFullClassName==null)
                    {
                        //return;
                        throw new Exception("����FullClassName ����Ϊ��");
                    }
                    LookForm = new FrmLookUp.FrmLookUpBase(BaoDataAccDLLFullPath, BaoFullClassName);

                }
                LookForm._ClickClose = this.BaoClickClose;
                LookForm.objResutlRow = Resultrow;
                this.ParentForm.AddOwnedForm(LookForm);
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
