using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace UFBaseLib.BusLib
{
    public class BaseInfo
    {
        #region ��̬����
        #region ��̬����
        public static XmlDocument xmlDoc=null;
        /// <summary>
        /// U8��½����
        /// </summary>
        public static U8Login.clsLogin U8Login = null;
        public static string userRole = "demo";
        public static string ProgramName;
        /// <summary>
        /// �û����
        /// </summary>
        public static string UserId;//�û���
        /// <summary>
        /// �û�����
        /// </summary>
        public static string UserName;
        /// <summary>
        /// ����
        /// </summary>
        public static string Password;//����
        /// <summary>
        /// ����Id
        /// </summary>
        public static string AccID;//����ID
        /// <summary>
        /// �������
        /// </summary>
        public static string iYear;//�������
        /// <summary>
        /// ��ϵͳ��
        /// </summary>
        public static string cSubID;//��ϵͳ��
        /// <summary>
        /// Ӧ�÷�����
        /// </summary>
        public static string AppServer;//Ӧ�÷�����		
        /// <summary>
        /// ����Դ
        /// </summary>
        public static string DataSource;//����Դ
        /// <summary>
        /// ��ȿ�����Ӵ�
        /// </summary>
        public static string UfDbName;//��ȿ�����Ӵ�
        /// <summary>
        /// ��������
        /// </summary>
        public static string operDate;//��½�����ҵ������
        /// <summary>
        /// ����վ��Ψһ���к�
        /// </summary>
        public static string WorkStationSerial;//����վ��Ψһ���к�
        /// <summary>
        /// ����
        /// </summary>
        public static int LanguageID;//����
        /// <summary>
        /// �Ƿ�������=true,���Ű�
        /// </summary>
        public static bool IsCompanyVer;//�Ƿ�������=true,���Ű�
        /// <summary>
        /// �Ƿ����Ա
        /// </summary>
        public static bool IsAdmin;//�Ƿ����Ա
        /// <summary>
        /// ���ݿ����������
        /// </summary>
        public static string DBServerName; //���ݿ����������
        /// <summary>
        /// ���ݿ��½�û���
        /// </summary>
        public static string DBUserID;//���ݿ��½�û���
        /// <summary>
        /// ���ݿ��½����
        /// </summary>
        public static string DBPwd;//���ݿ��½����
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static string DBName; //���ݿ�����
        /// <summary>
        /// ����ҽ�����,0=��� 1=��Ƕ
        /// </summary>
        public static int ProgramType;//����ҽ�����,0=��� 1=��Ƕ
        #endregion

        #endregion

        #region get Ĭ�ϵ����������ַ���
        public static string m_DefConnStr;
        public static string DefConnStr
        {
            get
            {
                return m_DefConnStr;
            }
            set
            {
                m_DefConnStr = value;
            }
        }
        #endregion

        #region �ַ����л�ȡֵ,���ַ��� 'abc="aa";'�� abc��ֵ
        public static string getStrValue(string resStr, string valStr)
        {
            resStr = resStr.Trim();
            valStr += "=";
            int len_resStr = resStr.Length;
            int len_valStr = valStr.Length;
            int start = resStr.IndexOf(valStr) + len_valStr;
            int end = resStr.IndexOf(";", start);
            if (0 > end)
            {
                end = len_resStr;
            }
            return resStr.Substring(start, end - start).Trim('"');
        }
        #endregion


    }
}
