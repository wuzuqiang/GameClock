using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameControledClock
{
    //public class RingControledClockSet
    //{   //添加闹钟时就排序好，并将第一个要响应的闹钟专门保存在firstRingControledClock
    //    List<ControledClock> listOrderedRingControledClock = new List<ControledClock>();   //从从前到以后
    //    /// <summary>
    //    /// 最先的闹钟，保存好可以使用它更及时的响铃
    //    /// </summary>
    //    public ControledClock firstRingControledClock = new ControledClock();
    //    public void AddAndSetfirstring(ControledClock ControledClockToAdd)
    //    {
    //        int insertIndex = listOrderedRingControledClock.Count();
    //        for (int i = 0; i < listOrderedRingControledClock.Count; i++)
    //        {
    //            if (0 < DateTime.Compare(ControledClockToAdd.RingTime, listOrderedRingControledClock[i].RingTime))
    //            {
    //                insertIndex = i;
    //                break;
    //            }
    //        }
    //        listOrderedRingControledClock.Insert(insertIndex, ControledClockToAdd);
    //        if (0 == insertIndex)
    //        {
    //            UpdatefirstRingControledClock();
    //        }
    //    }
    //    public void RemoveRingControledClock(string ID)
    //    {
    //        int removeIndex = listOrderedRingControledClock.Count();
    //        for (int i = 0; i < listOrderedRingControledClock.Count; i++)
    //        {
    //            if (listOrderedRingControledClock[i].ID == ID)
    //            {
    //                removeIndex = i;
    //                break;
    //            }
    //        }
    //        if (removeIndex < listOrderedRingControledClock.Count())
    //        {
    //            listOrderedRingControledClock.RemoveAt(removeIndex);
    //        }
    //        if (removeIndex == 0)
    //        {
    //            UpdatefirstRingControledClock();
    //        }
    //    }
    //    public void UpdateRingControledClock(ControledClock ControledClock)
    //    {
    //        int removeIndex = listOrderedRingControledClock.Count();
    //        for (int i = 0; i < listOrderedRingControledClock.Count; i++)
    //        {
    //            if (listOrderedRingControledClock[i].ID == ControledClock.ID)
    //            {
    //                removeIndex = i;
    //                break;
    //            }
    //        }
    //        if (removeIndex < listOrderedRingControledClock.Count() && listOrderedRingControledClock[removeIndex].RingTime == ControledClock.RingTime)
    //        {   //如果闹铃时间没变就直接更新就好了
    //        }
    //        else if (removeIndex < listOrderedRingControledClock.Count())
    //        {   //如果闹铃时间变了，就先移出，然后添加这个闹钟，好排序要
    //            listOrderedRingControledClock.RemoveAt(removeIndex);
    //        }
    //        else
    //        {
    //            throw new Exception("不可能找不到这个闹钟的！");
    //        }
    //        if (removeIndex == 0)
    //        {
    //            UpdatefirstRingControledClock();
    //        }
    //    }
    //    private void UpdatefirstRingControledClock()
    //    {
    //        firstRingControledClock = new ControledClock()
    //        {
    //            RingTime = listOrderedRingControledClock[0].RingTime,    //因为已经是排序好的闹钟
    //            TaskContent = listOrderedRingControledClock[0].TaskContent
    //        };
    //    }
    //}
}
