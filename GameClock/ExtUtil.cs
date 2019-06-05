using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GameClock
{
    public static class ExtUtil
    {
        public static string ToStandardTimeStr(this DateTime dt)
        {
            return dt.ToString("yyyy/MM/dd HH:mm:ss");
        }
        public static DateTime ToDateTime(this string str)
        {
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(str);
            }catch(Exception ex)
            {
                dt = Convert.ToDateTime("2017/1/1");
            }
            return dt;
        }

        public static Int32 ToInt32(this string str)
        {
            int i = Convert.ToInt32(str);
            return i;
        }

        public static string RightFormatLen(this string str, int width, char replaceChar = ' ')
        {
            string result = "";
            if(string.IsNullOrEmpty(str))
            {
                str = "";
            }
            Regex regex = new Regex(@"[\u4E00-\u9FA5]{1}");  //汉字
            int a = regex.Matches(str).Count;
            if (width < a * 2 | width < str.Length)
                throw new Exception("格式化时所设置长度太小");
            result = str.PadRight(width - a, replaceChar);    //每多一个汉字就要减一长度，好匹配上字母数字。
            return result;
        }

        /// <summary>
        /// 获取字符串中的汉字个数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetHanziNum(this string str)
        {
            Regex regex = new Regex(@"[\u4E00-\u9FA5]{1}");  //汉字
            return regex.Matches(str).Count;
        }

        public static string DelExtraSpace(this string str)
        {
            string result = "";
            Regex reg = new Regex(@"\s+");
            result = reg.Replace(str, " ");
            return result;
        }
    }
}
