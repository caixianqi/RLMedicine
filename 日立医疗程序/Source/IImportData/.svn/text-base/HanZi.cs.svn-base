using System;
using System.Collections.Generic;
using System.Text;

namespace Bao
{
    public class HanZi
    {
        /// <summary>
        /// 汉字转拼音缩写
        /// Code By MuseStudio@hotmail.com
        /// 2004-11-30
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        public static string HanZiToPYS(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        /// <summary>
        /// 取单个字符的拼音声母
        /// Code By MuseStudio@hotmail.com
        /// 2004-11-30
        /// </summary>
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        private static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";

            return "*";
        }

        /// <summary>
        /// 拼音和汉字的对照字典
        /// </summary>
        private static Dictionary[] Dictionarys = { new Dictionary("A", "吖"),
                                                    new Dictionary("B", "八"),
                                                    new Dictionary("C", "嚓"),
                                             new Dictionary("D", "咑"),
                                             new Dictionary("E", "妸"),
                                             new Dictionary("F", "发"),
                                             new Dictionary("G", "旮"),
                                             new Dictionary("H", "铪"),
                                             new Dictionary("I", "丌"),
                                             new Dictionary("J", "丌"),
                                             new Dictionary("K", "咔"),
                                             new Dictionary("L", "垃"),
                                             new Dictionary("M", "嘸"),
                                             new Dictionary("N", "拏"),
                                             new Dictionary("O", "噢"),
                                             new Dictionary("P", "妑"),
                                             new Dictionary("Q", "七"),
                                             new Dictionary("R", "呥"),
                                             new Dictionary("S", "仨"),
                                             new Dictionary("T", "他"),
                                             new Dictionary("U", "屲"),
                                             new Dictionary("V", "屲"),
                                             new Dictionary("W", "屲"),
                                             new Dictionary("X", "夕"),
                                             new Dictionary("Y", "丫"),
                                             new Dictionary("Z", "帀")
                                           };

        public static string PinYinToHanZi(char a)
        {
            string result = "";
            for (int i = 0; i < Dictionarys.Length; i++)
            {
                if (Dictionarys[i].ZM == a.ToString().ToUpper())
                {
                    result = Dictionarys[i].HZ;
                }
            }
            if (result != "")
            {
                return result;
            }
            else
            {
                return a.ToString();
            }
        }

    }

    public class Dictionary
    {
        private string _zm;
        private string _hz;
        public Dictionary(string ZiMu, string HanZi)
        {
            _zm = ZiMu;
            _hz = HanZi;
        }
        public string ZM
        {
            get { return _zm; }
            
        }
        public string HZ
        {
            get { return _hz; }
           
        }

    }   

}
