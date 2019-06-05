using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using GameClock.ProjectClass;
using GameClock;

namespace GameClock
{
    class FileHelper
    {
        public static List<string> getContentList(string fileName)
        {
            List<string> listClock = new List<string>();
            if (File.Exists(fileName))
            {
                listClock = new List<string>(File.ReadAllLines(fileName, Encoding.UTF8));
            }
            return listClock;
        }

        public static bool writeToFile(string content, string fileName)
        {
            bool isSuccess = false;
            try
            {
                File.WriteAllText(fileName, content, Encoding.UTF8);
                isSuccess = true;

            }catch(Exception ex)
            {
            }
            return isSuccess;
        }

        public static bool appendToFile(string content, string fileName)
        {
            bool isSuccess = false;
            try
            {
                StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
                sw.Write(content);
                sw.Close();
                isSuccess = true;
            }
            catch (Exception ex)
            {
            }
            return isSuccess;
        }

        public static void AddControledClockInfoToFile(List<ControledClock> listCtrlClock)
        {
            string fileName = "./InfoSaved/需要控制的闹钟信息.txt";
            //FileStream fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            //fStream.Close();
            StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
            string content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("状态".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            foreach (ControledClock ctrlClock in listCtrlClock)
            {
                content += "\r\n";
                content += ControledClock.FormatControlledClock(ctrlClock);
            }
            sw.WriteLine(content);
            sw.Close();
        }

        public static void AddControledClockInfoToFile(ControledClock ctrlClock)
        {
            string fileName = "./InfoSaved/需要控制的闹钟信息.txt";
            //FileStream fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
            string content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("状态".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            content += "\r\n" + ControledClock.FormatControlledClock(ctrlClock);
            sw.Write(content);
            sw.Flush();
            sw.Close();
        }

        public static void AddControledClockInfoToHistoryFile(ControledClock ctrlClock, string operType)
        {   //删除闹钟时，会执行这个函数
            string fileName = "./InfoSaved/所有闹钟信息.txt";
            //FileStream fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            string content = "\r\n操作类型：" + operType + "\r\n";
            content += FormatHistoryClock(ctrlClock);
            sw.Write(content);
            sw.Flush();
            sw.Close();
        }
        private static string FormatHistoryClock(ControledClock ctrlClock)
        {
            string content = "";
            content += ctrlClock.RingTime.ToStandardTimeStr().RightFormatLen(ClockListRowItemWidth.RingTime);
            content += ctrlClock.TaskContent.RightFormatLen(ClockListRowItemWidth.TaskContent);
            content += ctrlClock.Interval.ToString().RightFormatLen(ClockListRowItemWidth.Interval);
            content += ctrlClock.Status.RightFormatLen(ClockListRowItemWidth.Status);
            content += "".RightFormatLen(ClockListRowItemWidth.BeginTime);
            content += DateTime.Now.ToStandardTimeStr().RightFormatLen(ClockListRowItemWidth.RecordTime);
            content += ctrlClock.ID.RightFormatLen(ClockListRowItemWidth.ID);
            return content;
        }
    }
}
