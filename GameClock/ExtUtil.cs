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

        /// <summary>
        /// 将秒数转换X天X时X分X秒
        /// </summary>
        /// <param name="iSecond"></param>
        /// <returns></returns>
        public static string ToYMDFormat(this int iSumSecond)
        {
            string strYMD = "0天0时0分0秒";
            int iDay, iHour, iMinute, iSecond;
            iDay = iSumSecond / (24 * 60 * 60);
            iHour = iSumSecond / (60 * 60) - iDay * 24;
            iMinute = iSumSecond / 60 - iDay * 24 * 60 - iHour * 60;
            iSecond = iSumSecond - iDay * 24 * 60 * 60 - iHour * 60 * 60 - iMinute * 60;
            strYMD = string.Format("{0}天{1}时{2}分{3}秒", iDay, iHour, iMinute, iSumSecond);
            return strYMD;
        }

        /// <summary>
        /// 将X天X时X分X秒转换为共Y秒
        /// </summary>
        /// <param name="strYMD"></param>
        /// <returns></returns>
        public static int ToSumSecond(this string strYMD)
        {
            int iDay, iHour, iMinute, iSecond;
            iDay = strYMD.Substring(0, strYMD.IndexOf('天')).ToInt32();
            iHour = strYMD.Substring(strYMD.IndexOf('天') + 1, strYMD.IndexOf('时')).ToInt32();
            iMinute = strYMD.Substring(strYMD.IndexOf('时') + 1, strYMD.IndexOf('分')).ToInt32();
            iSecond = strYMD.Substring(strYMD.IndexOf('分') + 1, strYMD.IndexOf('秒')).ToInt32();
            int iSumSecond = (iDay * 24 * 60 * 60 + iHour * 60 * 60 + iMinute * 60 + iSecond);
            return iSumSecond;
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
