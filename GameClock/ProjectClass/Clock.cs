using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClock;

namespace GameClock.ProjectClass
{
    public class Clock
    {
        public DateTime RingTime;
        public string TaskContent;
        public string ID = System.Guid.NewGuid().ToString();
        public string ToBuildString()
        {
            string content = "\n";
            content += string.Format(RingTime.ToStandardTimeStr().PadRight(30, ' '));
            content += string.Format(TaskContent.PadRight(30, ' '));
            return content;
        }
    }
    public class RingClockSet
    {
        /// <summary>
        /// 添加闹钟时就排序好，并将第一个要响应的闹钟专门保存在firstRingControledClock
        /// </summary>
        public List<ControledClock> listOrderedRingControledClock = new List<ControledClock>();   //从从前到以后
        /// <summary>
        /// 最先的闹钟，保存好可以使用它更及时的响铃
        /// </summary>
        public ControledClock firstRingClock = new ControledClock();
        public void AddAndSetfirstring(ControledClock ControledClockToAdd)
        {
            int insertIndex = 0;
            for (int i = 0; i < listOrderedRingControledClock.Count; i++)
            {
                if (0 < DateTime.Compare(ControledClockToAdd.RingTime, listOrderedRingControledClock[i].RingTime))
                {
                    insertIndex = i;
                    break;
                }
            }
            listOrderedRingControledClock.Insert(insertIndex, ControledClockToAdd);
            if (0 == insertIndex)
            {
                UpdatefirstRingControledClock();
            }
        }
        public void RemoveRingControledClock(string ID)
        {
            int removeIndex = listOrderedRingControledClock.Count();
            for (int i = 0; i < listOrderedRingControledClock.Count; i++)
            {
                if (listOrderedRingControledClock[i].ID == ID)
                {
                    removeIndex = i;
                    break;
                }
            }
            if (removeIndex < listOrderedRingControledClock.Count())
            {
                listOrderedRingControledClock.RemoveAt(removeIndex);
            }
            if (removeIndex == 0)
            {
                UpdatefirstRingControledClock();
            }
        }
        /// <summary>
        /// 更新闹钟，条件：闹钟类参数的状态是Start的。
        /// </summary>
        /// <param name="ControledClock"></param>
        public void UpdateRingControledClock(ControledClock ControledClock)
        {
            int removeIndex = listOrderedRingControledClock.Count();
            for (int i = 0; i < listOrderedRingControledClock.Count; i++)
            {
                if (listOrderedRingControledClock[i].ID == ControledClock.ID)
                {
                    removeIndex = i;
                    break;
                }
            }
            if (removeIndex < listOrderedRingControledClock.Count() && listOrderedRingControledClock[removeIndex].RingTime == ControledClock.RingTime)
            {   //如果闹铃时间没变就直接更新就好了
                listOrderedRingControledClock[removeIndex].Interval = ControledClock.Interval;
            }
            else if (removeIndex < listOrderedRingControledClock.Count())
            {   //如果闹铃时间变了，就先移出，然后添加这个闹钟，好顺便排序
                listOrderedRingControledClock.RemoveAt(removeIndex);
                listOrderedRingControledClock.Add(ControledClock);
            }
            else
            {
                throw new Exception("不可能找不到这个闹钟的！");
            }
            if (removeIndex == 0)
            {
                UpdatefirstRingControledClock();
            }
        }

        public static void Beep(string fileName)
        {   //播放铃声 
            System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer(fileName);    //wav格式的铃声 
            sndPlayer.PlayLooping(); 
        }

        public static void MciStartRing(string fileName)
        {   //只会响一遍
            WavPlayer.mciPlay(fileName);
        }

        public static void MciStopRing(string fileName)
        {   //只会响一遍
            WavPlayer.mciStop(fileName);
        }
        public static void StopBeep(string fileName)
        {   //播放铃声 
            System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer(fileName);    //wav格式的铃声 
            sndPlayer.Stop();
        }
        /// <summary>
        /// 更新最先的响铃时间
        /// </summary>
        private void UpdatefirstRingControledClock()
        {
            if (listOrderedRingControledClock.Count == 0)
                return;
            firstRingClock = new ControledClock()
            {
                RingTime = listOrderedRingControledClock[0].RingTime,    //因为已经是排序好的闹钟
                TaskContent = listOrderedRingControledClock[0].TaskContent,
                ID = listOrderedRingControledClock[0].ID,
                Interval = listOrderedRingControledClock[0].Interval,
                //Status = listOrderedRingControledClock[0].Status
            };
        }
    }

    public class ControledClock : Clock
    {
        public Int32 Interval = 0;
        public string Status = "Null";
        //闹铃时要使用的线程ID
        public string ExcuteId = System.Guid.NewGuid().ToString();
        public static string FormatControlledClock(ControledClock ctrlClock)
        {
            string content = "";
            content += ctrlClock.RingTime.ToStandardTimeStr().RightFormatLen(ClockListRowItemWidth.RingTime);
            content += ctrlClock.TaskContent.RightFormatLen(ClockListRowItemWidth.TaskContent);
            content += ctrlClock.Interval.ToString().RightFormatLen(ClockListRowItemWidth.Interval);
            content += ctrlClock.Status.RightFormatLen(ClockListRowItemWidth.Status); ;
            content += ctrlClock.ID.RightFormatLen(ClockListRowItemWidth.ID);
            return content;
        }

        public static ControledClock GetCtrlClockFromRowString(string row)
        {
            ControledClock OperedClock = new ControledClock();
            OperedClock.RingTime = row.Substring(0, ClockListRowItemWidth.RingTime - 1).ToDateTime();
            //中文加英文形成的字符串，要依据位置索引来截取字符串，是很麻烦的方法，现在假设除了内容包含中文，其他都是英文的吧。好尽快完成项目
            int num = row.Substring(ClockListRowItemWidth.RingTime).GetHanziNum();
            OperedClock.TaskContent = row.Substring(ClockListRowItemWidth.RingTime, ClockListRowItemWidth.TaskContent - num - 1).Trim();
            OperedClock.Interval = row.Substring(ClockListRowItemWidth.RingTime + ClockListRowItemWidth.TaskContent - num
                  , ClockListRowItemWidth.Interval - 1).ToInt32();
            OperedClock.Status = row.Substring(ClockListRowItemWidth.RingTime + ClockListRowItemWidth.TaskContent + ClockListRowItemWidth.Interval
                    - num
                  , ClockListRowItemWidth.Status - 1).Trim();
            OperedClock.ID = row.Substring(row.Length - ClockListRowItemWidth.ID).Trim();
            return OperedClock;
        }

    }

    public class ClockOperHistory : ControledClock
    {
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime BeginTime = DateTime.Now;
        public string OperType = "";
        public DateTime OperTime = DateTime.Now;
    }


    class ExcClock
    {
        public static bool IsRingtime(ClockOperHistory clock)
        {
            return clock.RingTime == DateTime.Now;
        }
    }
}
