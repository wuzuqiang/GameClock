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
                if (operedClock.Status != "Stop")
                    BeginRingClock(operedClock);
                //将添加闹钟事件记录在闹钟历史信息中
                FileHelper.AddControledClockInfoToHistoryFile(operedClock, "新增");
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
                                BeginRingClock(operedClock);
                            }
                        }
                        else
                        {   //原先是开始状态
                            if ("Start" == operedClock.Status)
                            {
                                BeginRingClock(operedClock);
                            }
                        }
                        FileHelper.AddControledClockInfoToHistoryFile(operedClock, "编辑：");
                        break;
                    }
                }
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
            BindListBox();
        }
        Thread worker;
        private void btnStartRing_Click(object sender, EventArgs e)
        {
            ControledClock clk = new ControledClock();
            BeginRingClock(clk);
        }

        SynchronizationContext m_SynContext = null;
        private void BeginRingClock(ControledClock clk)
        {   //如何保证  运行时占用内存小；到响铃时还能快速响应。
            //占用内存小，控制方法：不循环；不拼命在堆栈上创建变量
            //响铃时能快速响应，控制方法：系统等着这件事情发生就马上执行；。涉及到系统运行程序的运行机制，时间片。
            //textBox1.Text = string.Format("需要响铃，时间为{0}", clk.RingTime);
            worker = new Thread(new ParameterizedThreadStart(ClockRing));
            worker.Start(clk);
            //worker.IsBackground = true;
        }
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
                string excuteId = clk.ExcuteId;
                ringTime = clk.RingTime;
                ID = clk.ID;
                taskContent = clk.TaskContent;
                interval = clk.Interval;
                //LogTextHelper.WriteLine("ClockRing:\t" + JsonConvert.SerializeObject(m_RingSet.firstRingClock));
                DateTime dtNow = DateTime.Now;
                #endregion
                //休眠到响铃时间
                Thread.Sleep(ringTime - dtNow);
                //睡醒之后，如果突然发现：咦，你这闹钟变了。因为变了之后是使用另外的线程去响铃了，这线程被抛弃了。停止他
                #region 
                if(ringTime != clk.RingTime)
                { return; }
                #endregion
                #region  如果在响铃之前这闹钟已经被删除或被停止了，那么也没必要往下执行这线程了
                bool bRingClockExist = false;
                foreach (ControledClock temp in listControlClock)
                {
                    if (ID == temp.ID)
                    {
                        bRingClockExist = true;
                        if(temp.Status == "Stop")   //如果被改成暂停了也没必要往下执行
                        {
                            bRingClockExist = false;
                        }
                    }
                }
                if (!bRingClockExist)
                { return; }
                #endregion
                //其实这里最好要锁住那个响铃闹钟，防止刚好响铃时，那个闹钟被更改
                //开始响铃
                RingClockSet.MciStartRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                //闹钟依据间隔继续使用？
                string tips = string.Format("响铃时间：{0}\n内容：{1}\nID：{2}", ringTime.ToStandardTimeStr(), taskContent, ID); 
                #region 继续响铃？
                if (DialogResult.Yes == MessageBox.Show(tips, "继续响铃？", MessageBoxButtons.YesNo))
                {   //修改响铃闹钟集以及控制闹钟列表
                    FileHelper.AddControledClockInfoToHistoryFile(clk, "响铃后继续");
                    //更新listBoxControledClock，新信息显示在listBox1
                    for (int i = 0; i < listControlClock.Count(); i++)
                    {
                        if (ID == listControlClock[i].ID)
                        {
                            listControlClock[i].RingTime = ringTime.AddSeconds(interval);   //如果加上了interval，还是小于当前时间，怎么处理？？
                            listControlClock[i].Status = "Start";
                            if(ringTime.AddSeconds(interval) < DateTime.Now.AddSeconds(1))  //给1秒运行时间
                            {
                                MessageBox.Show("抱歉！设置的闹铃时间已过！自动为您停止！");
                                listControlClock[i].Status = "Stop";
                                m_SynContext.Post(SetListBoxSafePost, "");
                                RingClockSet.MciStopRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                            }
                            else
                            {
                                m_SynContext.Post(SetListBoxSafePost, "");
                                RingClockSet.MciStopRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                                //ClockRing(listControlClock[i]);   //这种方式想着不用创建线程更节省内存，但会造成MciRing函数只响上一次未响完的那一段。
                                BeginRingClock(listControlClock[i]);    //线程中重启线程
                            }
                        }
                    }
                }
                else
                {
                    //从响铃闹钟类中移除闹钟，并设置此闹钟状态为停止
                    FileHelper.AddControledClockInfoToHistoryFile(clk, "响铃后不继续");
                    //更新listBoxControledClock，新信息显示在listBox1
                    for (int i = 0; i < listControlClock.Count(); i++)
                    {
                        if (ID == listControlClock[i].ID)
                        {
                            listControlClock[i].Status = "Stop";
                            m_SynContext.Post(SetListBoxSafePost, "");
                            RingClockSet.MciStopRing(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wav\\" + WavToTaskcontent.GetWavfilename(taskContent)));
                        }
                    }
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
            BindListBox();
        }
    }
}
