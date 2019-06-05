using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameClock.ProjectClass;

namespace GameClock
{
    public partial class FrmSetClock : Form
    {
        public FrmSetClock()
        {
            InitializeComponent();
        }

        public List<ControledClock> listExistedClk = new List<ControledClock>();

        /// <summary>
        /// 设置间隔时长(秒)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetInv_Click(object sender, EventArgs e)
        {
            FrmSetIntervalTime dlg = new FrmSetIntervalTime();
            int i1 = txtInvSecond.Text.ToInt32() / (24 * 60 * 60);
            dlg.day = (txtInvSecond.Text.ToInt32() / (24 * 60 * 60)).ToString();
            dlg.hour = (txtInvSecond.Text.ToInt32() / (60 * 60) - dlg.day.ToInt32() * 24).ToString();
            dlg.minute = (txtInvSecond.Text.ToInt32() / 60 - dlg.day.ToInt32() * 24 * 60 - dlg.hour.ToInt32() * 60).ToString();
            dlg.second = (txtInvSecond.Text.ToInt32() - dlg.day.ToInt32() * 24 * 60 * 60 - dlg.hour.ToInt32() * 60 * 60 
                - dlg.minute.ToInt32()*60).ToString();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string strInv = dlg.day + "天";
                strInv += dlg.hour + "时";
                strInv += dlg.minute + "分";
                strInv += dlg.second + "秒";
                txtInv.Text = strInv;
                txtInvSecond.Text = (dlg.day.ToInt32() * 24 * 60 * 60
                    + dlg.hour.ToInt32() * 60*60  + dlg.minute.ToInt32() * 60
                    + dlg.second.ToInt32()).ToString();
                txtClocktime.Text = txtStarttime.Text.ToDateTime().AddSeconds(txtInvSecond.Text.ToInt32()).ToStandardTimeStr();
            }
        }

        public string operType = "Add";
        public string ID = "";
        public ClockOperHistory OperedClock = new ClockOperHistory();
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(!CheckInput())
            {
                return;
            }
            OperedClock.RingTime = txtClocktime.Text.ToDateTime();
            OperedClock.BeginTime = txtStarttime.Text.ToDateTime();
            OperedClock.Interval = txtInvSecond.Text.ToInt32();
            OperedClock.TaskContent = txtTaskContent.Text.Trim();
            OperedClock.Status = cbxStart.Checked ? "Start" : "Stop";
            OperedClock.OperType = operType;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool CheckInput()
        {
            bool isRight = true;
            ////不得和已有的闹钟集合间隔五秒中之内。
            ////也是防止插队闹钟离当前太近，程序运行其他都没一点点时间，很容易出错
            //foreach(ControledClock clk in listExistedClk)
            //{
            //    TimeSpan ts = clk.RingTime - txtClocktime.Text.ToDateTime();
            //    if(ts.Seconds <= 5 || ts.Seconds >= -5)
            //    {
            //        MessageBox.Show("抱歉！已有的闹钟相差在五秒之内！间隔太小，响铃会模糊！");
            //        return false;
            //    }
            //}
            //插队时，给5秒的反应时间
            if (txtClocktime.Text.ToDateTime().AddSeconds(-5) <= DateTime.Now)
            {
                MessageBox.Show("任务都即将来到，还不先去任务。。。。。抱歉！响铃时间减5秒不得小于当前时间！间隔太小，响铃会模糊！");
                return false;
            }
            return isRight;
        }

        private void btnSetBegintime_Click(object sender, EventArgs e)
        {
            FrmSetTime dlg = new FrmSetTime();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtStarttime.Text = dlg.time;
                txtClocktime.Text = dlg.time.ToDateTime().AddSeconds(txtInvSecond.Text.ToInt32()).ToStandardTimeStr();
            }
        }

        private void btnSetEndtime_Click(object sender, EventArgs e)
        {
            FrmSetTime dlg = new FrmSetTime();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtClocktime.Text = dlg.time;
                txtStarttime.Text = dlg.time.ToDateTime().AddSeconds(0 - txtInvSecond.Text.ToInt32()).ToStandardTimeStr();
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if ("Edit" == operType)
            {
                cbxStart.Checked = OperedClock.Status == "Start" ? true : false;
                txtTaskContent.Text = OperedClock.TaskContent;
                txtInvSecond.Text = OperedClock.Interval.ToString();
                txtClocktime.Text = OperedClock.RingTime.ToStandardTimeStr();
                txtStarttime.Text = (OperedClock.RingTime.AddSeconds(0 - OperedClock.Interval).ToStandardTimeStr());
            }
            else
            {
                txtInvSecond.Text = "20";
                txtStarttime.Text = DateTime.Now.ToStandardTimeStr();
                txtClocktime.Text = DateTime.Now.AddSeconds(20).ToStandardTimeStr();
                txtTaskContent.Text = "这是一个测试闹钟";
            }
        }

        private string GetHMS(int iSecondSum)
        {
            string iDay, iHour, iMinute, iSecond;
            iDay = (iSecondSum / (24 * 60 * 60)).ToString();
            iHour = (iSecondSum / (60 * 60) - iDay.ToInt32() * 24).ToString();
            iMinute = (iSecondSum / 60 - iDay.ToInt32() * 24 * 60 - iHour.ToInt32() * 60).ToString();
            iSecond = (iSecondSum - iDay.ToInt32() * 24 * 60 * 60 - iHour.ToInt32() * 60 * 60
                - iMinute.ToInt32() * 60).ToString();
            return string.Format("{0}天{1}时{2}分{3}秒", iDay, iHour, iMinute, iSecond);
        }

        private void FrmSetClock_Load(object sender, EventArgs e)
        {
            int iIndex = 0;
            foreach(KeyValuePair<string, string> kvp in WavToTaskcontent.dicWavToTaskcontent)
            {
                if(0 == iIndex)
                {
                    txtTaskContent.Text = kvp.Key;
                    iIndex += 1;
                }
                txtTaskContent.Items.Add(kvp.Key);
            }
            if ("Edit" == operType)
            {
                cbxStart.Checked = OperedClock.Status == "Start" ? true : false;
                txtTaskContent.Text = OperedClock.TaskContent;
                txtTaskContent.Enabled = false;
                txtInvSecond.Text = OperedClock.Interval.ToString();
                txtInv.Text = GetHMS(OperedClock.Interval);
                txtClocktime.Text = OperedClock.RingTime.ToStandardTimeStr();
                txtStarttime.Text = (OperedClock.RingTime.AddSeconds(0 - OperedClock.Interval).ToStandardTimeStr());
            }
            else
            {
                txtInvSecond.Text = "20";
                txtInv.Text = GetHMS(20);
                txtStarttime.Text = DateTime.Now.ToStandardTimeStr();
                txtClocktime.Text = DateTime.Now.AddSeconds(20).ToStandardTimeStr();
                txtTaskContent.SelectedIndex = 0;
            }
        }

        private void btnSetNowStart_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            txtStarttime.Text = dtNow.ToStandardTimeStr();
            txtClocktime.Text = dtNow.AddSeconds(txtInvSecond.Text.ToInt32()).ToStandardTimeStr();
        }

        private void btnSetNowEnd_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            txtClocktime.Text = dtNow.ToStandardTimeStr();
            txtStarttime.Text = dtNow.AddSeconds(0 - txtInvSecond.Text.ToInt32()).ToStandardTimeStr();
        }
    }
}
