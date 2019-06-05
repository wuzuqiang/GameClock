using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GameClock.ProjectClass;
using System.IO;

namespace GameClock
{
    public partial class TestManyThread : Form
    {
        public TestManyThread()
        {
            InitializeComponent();
            m_SynContext = SynchronizationContext.Current;
        }

        Thread m_Worker;
        int iNum = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            //if (iNum <= 760)
            {
                m_Worker = new Thread(new ParameterizedThreadStart(RingBeingreadyMciPlay));
                m_Worker.Name = "Workerthread" + iNum;
                m_Worker.Start(iNum);
                //m_Worker.IsBackground = true;
                //RingBeingreadyMciPlay(iNum);
                iNum += 1;
            }
        }
        SynchronizationContext m_SynContext = null;
        private void RingBeingready(object threadNum)
        {
            //开始响铃
            RingClockSet.Beep(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\第{0}测试.wav", ((int)threadNum) % 6).ToString()));
            m_SynContext.Post(SetRichTextSafePost, threadNum);
            Thread.Sleep(1000);
            //MessageBox.Show(string.Format("线程{0}在{1}执行\n", threadNum, DateTime.Now.ToStandardTimeStr()));
            RingClockSet.StopBeep(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\第{0}测试.wav", ((int)threadNum) % 6).ToString()));
            //FileHelper.appendToFile("记录时间" + DateTime.Now.ToStandardTimeStr(), AppDomain.CurrentDomain.BaseDirectory + "\\temp.txt");
        }
        private void RingBeingreadyMciPlay(object threadNum)
        {
            try
            {

                m_SynContext.Post(SetRichTextSafePost, threadNum + "-1");
                Thread.Sleep(4000);
                Thread.CurrentThread.Join();
                WavPlayer.mciPlay(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\第{0}次测试.wav", ((int)threadNum) % 5 + 1).ToString()));
                //SetRichTextSafePost(threadNum);
                //Thread.CurrentThread.Abort();
                #region //继续响铃？
                if (DialogResult.OK == (new FrmSetTime()).ShowDialog())
                {
                    LogTextHelper.WriteLine("DialogResult.OK");
                }
                else
                {
                    LogTextHelper.WriteLine("DialogResult....");
                }
                #endregion
                m_SynContext.Post(SetRichTextSafePost, threadNum + "-2");
                //WavPlayer.mciStop(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\第{0}次测试.wav", ((int)threadNum) % 5 + 1).ToString()));
                return;

                m_SynContext.Post(SetRichTextSafePostByContent, DateTime.Now.ToString() + "开始");
                LogTextHelper.WriteLine("正常执行m_SynContext.Post");
                #region //继续响铃？
                //if (DialogResult.OK == (new FrmSetTime()).ShowDialog())
                //{
                //    LogTextHelper.WriteLine("DialogResult.OK");
                //}
                //else
                //{
                //    LogTextHelper.WriteLine("DialogResult....");
                //}
                #endregion
                //LogTextHelper.WriteLine("在弹窗后执行");
                //Thread.Sleep(20000);
                m_SynContext.Post(SetRichTextSafePostByContent, DateTime.Now + "结束");
                LogTextHelper.WriteLine("休眠后结束");
            }
            catch(ThreadAbortException ex)
            {
                m_SynContext.Post(SetRichTextSafePostByContent, DateTime.Now + "进入Catch ThreadAbortException");
                //RingBeingreadyMciPlay(threadNum);
                Thread.ResetAbort();
            }
            catch (ThreadInterruptedException ex)
            {
                RingBeingreadyMciPlay(threadNum);
            }
            m_SynContext.Post(SetRichTextSafePost, string.Format(threadNum + "---End"));

            return;
            bool reRing = true;
            do
            {
                //WavPlayer.mciPlay(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));
                //m_SynContext.Post(SetRichTextSafePost, threadNum);
                ////SetRichTextSafePost(threadNum);
                //Thread.Sleep(4000);
                //WavPlayer.mciStop(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));

                WavPlayer.mciPlay(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\平凡之路.wav").ToString()));
                m_SynContext.Post(SetRichTextSafePost, threadNum);
                //SetRichTextSafePost(threadNum);
                Thread.Sleep(4000);
                //WavPlayer.mciStop(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\平凡之路.wav").ToString()));
            } while (false);
        }
        private void RingBeingready3(object threadNum)
        {
            bool reRing = true;
            do
            {
                WavPlayer.Play(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));
                m_SynContext.Post(SetRichTextSafePost, threadNum);
                Thread.Sleep(3000);
                //WavPlayer.Stop(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));
            } while (reRing);
        }
        private void RingBeingreadySndPlay(object threadNum)
        {
            bool reRing = true;
            do
            {
                WavPlayer.sndPlay(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));
                m_SynContext.Post(SetRichTextSafePost, threadNum);
                Thread.Sleep(3000);
                //WavPlayer.Stop(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("wav\\{0}.wav", ((int)threadNum) % 6).ToString()));
            } while (reRing);
        }
        private void SetRichTextSafePost(object threadNum)
        {
            richTextBox1.Text += string.Format("线程{0}在{1}执行\n", threadNum, DateTime.Now.ToStandardTimeStr());
        }
        private void SetRichTextSafePostByContent(object content)
        {
            richTextBox1.Text += string.Format("{0}\n", content);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now + "跳过线程sleep时间，往下执行" + "\r\n";
            m_Worker.Interrupt();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //终止线程
            m_Worker.Abort();
            richTextBox1.Text += DateTime.Now + "m_Worker.Abort();" + "\r\n";
        }

        List<Thread> m_ListWorkerThread = new List<Thread>();
        private void button4_Click(object sender, EventArgs e)
        {   //新增线程保存于List   好查看如果线程中执行另外一个线程，前一个线程会自动清理掉，不占用内存吗
            m_Worker = new Thread(new ParameterizedThreadStart(UseListThreadRingBeingready));
            m_Worker.Name = "Workerthread" + iNum;
            m_Worker.Start(iNum);
            m_ListWorkerThread.Add(m_Worker);
            //m_Worker.IsBackground = true;
            //RingBeingreadyMciPlay(iNum);
            iNum += 1;

        }
        private void UseListThreadRingBeingready(object threadNum)
        {
            #region 线程里面重新调用启动线程
            if (iNum < 100)
            {
                m_SynContext.Post(SetRichTextSafePost, threadNum + "-1");
                button4_Click(null, null);
            }
            #endregion
            return;
        }
    }
}
