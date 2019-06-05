using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GameClock.ProjectClass;
using System.Threading;
using Newtonsoft.Json;

namespace GameClock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //获取UI线程同步上下文
            m_SynContext = SynchronizationContext.Current;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            changedFirstring += RingClock;
            Clock clc = new Clock();
            listBox1.Items.Clear();
            //List<string> listContent = FileHelper.getContentList("./InfoSaved/历史闹钟信息.txt");
            List<string> listContent = FileHelper.getContentList("./InfoSaved/需要控制的闹钟信息.txt");
            int indexFirstRing = -1;
            DateTime dtInit = "2017-1-1".ToDateTime();
            for (int i = 0; i < listContent.Count; i++)
            {
                if (i > 0)
                {
                    string row = listContent[i];
                    ControledClock clk = ControledClock.GetCtrlClockFromRowString(row);
                    //如果响铃时间小于当前时间(给一秒运行时间缓存)，证明是过期闹钟，主动设置为Stop，好不让用户看懵
                    if (clk.RingTime <= DateTime.Now.AddSeconds(-1))
                    {
                        clk.Status = "Stop";
                    }
                    if(clk.RingTime >= dtInit && clk.RingTime > DateTime.Now && clk.Status == "Start")
                    {
                        indexFirstRing = i;
                    }
                    listControlClock.Add(clk);
                }
            }
            if( -1 != indexFirstRing)
            {
                m_RingSet.firstRingClock = ControledClock.GetCtrlClockFromRowString(listContent[indexFirstRing]);
            }
            BindListBox();
        }

        private void BindListBox()
        {
            listBox1.Items.Clear();
            string content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("状态".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            listBox1.Items.Add(content);
            //对listControlClock进行响铃时间的ASC排序
            List<ControledClock> listOrder = listControlClock.OrderBy(a => a.RingTime).ToList()
                .OrderBy(a => a.Status).ToList();
            foreach (ControledClock ctrlClock in listOrder)
            {
                listBox1.Items.Add(ControledClock.FormatControlledClock(ctrlClock));
            }
        }

        //选中的行号，如1表选中第一行
        string strCheckedLine = "1";
        List<ControledClock> listControlClock = new List<ControledClock>();

        private void btnAddClock_Click(object sender, EventArgs e)
        {
            FrmSetClock dlg = new FrmSetClock();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                ControledClock operedClock = new ControledClock()
                {
                    RingTime = dlg.OperedClock.RingTime,
                    TaskContent = dlg.OperedClock.TaskContent.Trim(),
                    Interval = dlg.OperedClock.Interval,
                    Status = dlg.OperedClock.Status.Trim(),
                    ID = dlg.OperedClock.ID.Trim()
                };
                listControlClock.Add(operedClock);
                //将闹钟添加进闹钟集合
                if(operedClock.Status != "Stop")
                    m_RingSet.AddAndSetfirstring(operedClock);
                //将添加闹钟事件记录在闹钟历史信息中
                FileHelper.AddControledClockInfoToHistoryFile(operedClock, "新增");
                JudgeRestartring();
                BindListBox();
            }
        }

        private void btnEditClock_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 1)
            {
                MessageBox.Show("抱歉！请先选择一行！");
                return;
            }
            FrmSetClock dlg = new FrmSetClock();
            dlg.listExistedClk = m_RingSet.listOrderedRingControledClock;
            dlg.operType = "Edit";
            //获取项目ID
            string row = listBox1.SelectedItem.ToString();
            ControledClock temp = ControledClock.GetCtrlClockFromRowString(row);
            dlg.OperedClock.RingTime = temp.RingTime;
            dlg.OperedClock.TaskContent = temp.TaskContent;
            dlg.OperedClock.Interval = temp.Interval;
            dlg.OperedClock.Status = temp.Status.Trim();
            dlg.OperedClock.ID = temp.ID.Trim();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                ControledClock operedClock = new ControledClock()
                {
                    RingTime = dlg.OperedClock.RingTime,
                    TaskContent = dlg.OperedClock.TaskContent,
                    Interval = dlg.OperedClock.Interval,
                    Status = dlg.OperedClock.Status,
                    ID = dlg.OperedClock.ID
                };
                for(int i = 0; i < listControlClock.Count(); i++)
                {
                    if (listControlClock[i].ID.Equals(operedClock.ID))
                    {
                        listControlClock[i] = operedClock;
                        if ("Stop" == temp.Status)
                        {   //原先是暂停状态就不会存在于闹钟集里 //如果新闹钟又是启动状态，则可以添加，反之无需添加
                            if ("Start" == operedClock.Status)
                            {
                                m_RingSet.AddAndSetfirstring(operedClock);
                            }
                        }
                        else
                        {   //原先是开始状态
                            if ("Start" == operedClock.Status)
                            {
                                m_RingSet.UpdateRingControledClock(operedClock);
                            }
                            else
                            {   //停止状态，需要从响铃集合中移除这项
                                m_RingSet.RemoveRingControledClock(operedClock.ID);
                            }
                        }
                        FileHelper.AddControledClockInfoToHistoryFile(operedClock, "编辑：");
                        break;
                    }
                }
                JudgeRestartring();
                BindListBox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   //初始化模板文件
            string content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("状态".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            content += string.Format("起始时间".RightFormatLen(ClockListRowItemWidth.BeginTime));
            content += string.Format("记录时间".RightFormatLen(ClockListRowItemWidth.RecordTime));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            //content += "\r\n";
            //content += string.Format("2018/9/1 1:1:1".RightFormatLen(20));
            //content += string.Format("任务1".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            //content += string.Format("2".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            //content += string.Format("Start".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            //content += string.Format("2018/9/1 0:0:0".RightFormatLen(20, ' '));
            //content += string.Format("2018/9/1 0:0:0".RightFormatLen(20, ' '));
            //content += string.Format(System.Guid.NewGuid().ToString().RightFormatLen(ClockListRowItemWidth.ID));
            if (FileHelper.writeToFile(content, "./InfoSaved/所有闹钟信息.txt"))
            {
                MessageBox.Show("恭喜，初始化所有闹钟信息成功！");
            }

            content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("状态".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            //content += "\r\n";
            //content += string.Format("2018/9/1 1:1:1".RightFormatLen(20));
            //content += string.Format("任务1".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            //content += string.Format("2".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            //content += string.Format("Start".RightFormatLen(ClockListRowItemWidth.Status, ' '));
            //content += string.Format(System.Guid.NewGuid().ToString().RightFormatLen(ClockListRowItemWidth.ID));
            if (FileHelper.writeToFile(content, "./InfoSaved/需要控制的闹钟信息.txt"))
            {
                MessageBox.Show("恭喜，初始化需要控制的闹钟信息成功！");
            }

            content = "";
            content += string.Format("响铃时间".RightFormatLen(ClockListRowItemWidth.RingTime, ' '));
            content += string.Format("闹钟内容".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            content += string.Format("闹钟间隔".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            content += string.Format("ID".RightFormatLen(ClockListRowItemWidth.ID));
            //content += "\r\n";
            //content += string.Format("2018/9/1 1:1:1".RightFormatLen(20));
            //content += string.Format("任务1".RightFormatLen(ClockListRowItemWidth.TaskContent, ' '));
            //content += string.Format("2".RightFormatLen(ClockListRowItemWidth.Interval, ' '));
            //content += string.Format(System.Guid.NewGuid().ToString().RightFormatLen(ClockListRowItemWidth.ID));
            if (FileHelper.writeToFile(content, "./InfoSaved/要响铃的闹钟信息.txt"))
            {
                MessageBox.Show("恭喜，初始化要响铃的闹钟信息成功！");
            }
            listControlClock = new List<ControledClock>();
            m_RingSet = new RingClockSet();
            m_UsingRingtime = "";
            BindListBox();
        }

        public delegate void ChangedFirstringHandle();
        public event ChangedFirstringHandle changedFirstring;
        /// <summary>
        /// 是否需要重新响铃，判断依据：第一闹钟被改变
        /// </summary>
        public void JudgeRestartring()
        {   //是否已经变动了最新响铃，需要重新改变响铃？
            int iNeedRingNum = 0;
            if(0 == m_RingSet.listOrderedRingControledClock.Count())
            {   //都没闹钟要响，不用响铃

            }
            else if ((m_UsingRingtime != m_RingSet.firstRingClock.RingTime.ToStandardTimeStr()))
            {   //第一闹钟被改变
                //changedFirstring();   //没必要委托了
                RingClock();
            }

        }
        /// <summary>
        /// 原先要响铃的时间，和Ringset.Ringtime保持一致，那东西是类会自动赋值的
        /// </summary>
        string m_UsingRingtime = (new DateTime()).ToStandardTimeStr();
        RingClockSet m_RingSet = new RingClockSet();
        Thread worker;
        private void btnStartRing_Click(object sender, EventArgs e)
        {
            RingClock();
        }
        object locker = new object();

        SynchronizationContext m_SynContext = null;
        private void RingClock()
        {   //如何保证  运行时占用内存小；到响铃时还能快速响应。
            //占用内存小，控制方法：不循环；不拼命在堆栈上创建变量
            //响铃时能快速响应，控制方法：系统等着这件事情发生就马上执行；。涉及到系统运行程序的运行机制，时间片。
            textBox1.Text = string.Format("准备响铃，时间为{0}", m_RingSet.firstRingClock.RingTime.ToStandardTimeStr());
            worker = new Thread(new ParameterizedThreadStart(ClockRing));
            worker.Start();
            //worker.IsBackground = true;
        }
        private void NewRingThread()
        {

        }
        /// <summary>
        /// 闹钟ID可以映射到执行ID
        /// </summary>
        Dictionary<string, string> dicClockidToExcuteid = new Dictionary<string, string>();
        /// <summary>
        /// 取消的闹钟ID的映射ID。在更改某闹钟时，此list要从词典中依据闹钟ID找出映射ID，然后移除它，线程才知道不能继续进行下去了
        /// </summary>
        List<string> listNeedExcuteid = new List<string>();
        private void ClockRing(object obj)
        {
            try
            {
                ControledClock clk = obj as ControledClock;
                #region 把要使用的变量都用新的内存保存起来
                DateTime ringTime = new DateTime();
                string ID = "";
                string taskContent = "";
                int interval = 0;
                ringTime = clk.RingTime;
                ID = clk.ID;
                taskContent = clk.TaskContent;
                interval = clk.Interval;
                //LogTextHelper.WriteLine("ClockRing:\t" + JsonConvert.SerializeObject(m_RingSet.firstRingClock));
                DateTime dtNow = DateTime.Now;
                #endregion
                m_UsingRingtime = ringTime.ToStandardTimeStr();    //将此闹钟设置为正在使用标志
                //休眠到响铃时间
                Thread.Sleep(ringTime - dtNow);
                //睡醒之后，如果突然发现：咦，你这闹钟变了。因为变了之后是使用另外的线程去响铃了，这线程被抛弃了。停止他
                //如果已经能进行到下面了，
                #region 
                if (!listNeedExcuteid.Contains(dicClockidToExcuteid[ID]))
                {
                    //需要执行的ThreadId不存在
                    return;
                }
                #endregion
                //开始响铃
                RingClockSet.MciStartRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                //闹钟依据间隔继续使用？
                string tips = string.Format("响铃时间：{0}\n内容：{1}\nID：{2}", ringTime.ToStandardTimeStr(), taskContent, ID); 
                #region 继续响铃？
                if (DialogResult.Yes == MessageBox.Show(tips, "继续响铃？", MessageBoxButtons.YesNo))
                {   //修改响铃闹钟集以及控制闹钟列表
                    FileHelper.AddControledClockInfoToHistoryFile(m_RingSet.firstRingClock, "响铃后继续");
                    //更新listBoxControledClock，新信息显示在listBox1
                    for (int i = 0; i < listControlClock.Count(); i++)
                    {
                        if (ID == listControlClock[i].ID)
                        {
                            listControlClock[i].RingTime = ringTime.AddSeconds(interval);   //如果加上了interval，还是小于当前时间，怎么处理？？
                            listControlClock[i].Status = "Start";
                            m_RingSet.UpdateRingControledClock(listControlClock[i]);
                        }
                    }
                    m_SynContext.Post(SetListBoxSafePost, "");
                    RingClockSet.MciStopRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                    ClockRing(0);
                }
                else
                {
                    //从响铃闹钟类中移除闹钟，并设置此闹钟状态为停止
                    m_RingSet.RemoveRingControledClock(ID);
                    FileHelper.AddControledClockInfoToHistoryFile(m_RingSet.firstRingClock, "响铃后不继续");
                    //更新listBoxControledClock，新信息显示在listBox1
                    for (int i = 0; i < listControlClock.Count(); i++)
                    {
                        if (ID == listControlClock[i].ID)
                        {
                            listControlClock[i].Status = "Stop";
                        }
                    }
                    m_SynContext.Post(SetListBoxSafePost, "");
                    RingClockSet.MciStopRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.WriteLine("响铃时出现错误！ERROR：" + ex.ToString());
            }
        }
        private void SetListBoxSafePost(object text)
        {
            listBox1.Items.Clear();
            BindListBox();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //new Thread(WaitTip).Start();
            //Thread t2 = new Thread(SaveControledClock);
            //t2.Start();
            //t2.Join();
            SaveControledClock();
            #region 后续再研究遮罩层
            //Common.ShowProcessing("正在处理中，请稍候...", this, (obj) =>
            //{
            //    //这里写处理耗时的代码，代码处理完成则自动关闭该窗口
            //    for (int i = 0; i < 5 * 1; i++)
            //    {

            //    }
            //}, null);
            #endregion
        }
        private void WaitTip()
        {
            FrmWait dlg = new FrmWait();
            dlg.Show();
        }
        private void SaveControledClock()
        {
            //Thread.Sleep(10000);
            //MessageBox.Show("abc");
            // 闹钟信息添加进文件 "需要控制的闹钟信息.txt"
            try
            {
                FileHelper.AddControledClockInfoToFile(listControlClock);
            }
            catch(Exception ex)
            {

            }
        }

        private void btnStopClock_Click(object sender, EventArgs e)
        {
            RingClockSet.StopBeep(AppDomain.CurrentDomain.BaseDirectory + "\\wav\\beep.wav");
        }

        private void btnChangeFirstring_Click(object sender, EventArgs e)
        {
            //改变第一闹钟
            ControledClock clk = new ControledClock();
            clk.RingTime = DateTime.Now.AddSeconds(10);
            clk.Interval = 10;
            clk.Status = "Start";
            clk.TaskContent = "添加先于原有的闹钟";
            listControlClock.Add(clk);
            m_RingSet.AddAndSetfirstring(clk);
            JudgeRestartring();
            FileHelper.AddControledClockInfoToHistoryFile(clk, "测试时，添加打断原有进程的闹钟。。。");
            BindListBox();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 1)
            {
                MessageBox.Show("抱歉！请先选择一行！");
                return;
            }
            FrmSetClock dlg = new FrmSetClock();
            dlg.operType = "Edit";
            //获取项目ID
            string row = listBox1.SelectedItem.ToString();
            ControledClock temp = ControledClock.GetCtrlClockFromRowString(row);
            int removeIndex = listControlClock.Count;
            for (int i = 0; i < listControlClock.Count; i++ )
            {
                if(temp.ID == listControlClock[i].ID)
                {
                    removeIndex = i;
                }
            }
            if(removeIndex != listControlClock.Count)
                listControlClock.RemoveAt(removeIndex);
            m_RingSet.RemoveRingControledClock(temp.ID);
            JudgeRestartring();
            BindListBox();
        }
    }
}
