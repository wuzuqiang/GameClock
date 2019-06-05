using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace GameClock
{
    public partial class FrmSetTime : Form
    {
        public FrmSetTime()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            year = dtpStartYMD.Value.Year.ToString();
            month = dtpStartYMD.Value.Month.ToString();
            day = dtpStartYMD.Value.Day.ToString();
            hour = numHour.Value.ToString();
            minute = numMinute.Value.ToString();
            second = numSecond.Value.ToString();
            SetFullTime();
        }

        public string time = "";
        private string year = "2018";
        private string month = "1";
        private string day = "1";
        string hour = "0";
        private string minute = "0";
        private string second = "1";
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            time = txtStarttime.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSetNow_Click(object sender, EventArgs e)
        {
            txtStarttime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {   //这里只改变年月日
            year = dtpStartYMD.Value.Year.ToString();
            month = dtpStartYMD.Value.Month.ToString();
            day = dtpStartYMD.Value.Day.ToString();
            SetFullTime();
        }

        private void numHour_ValueChanged(object sender, EventArgs e)
        {
            hour = numHour.Value.ToString();
            SetFullTime();
        }

        private void numMinute_ValueChanged(object sender, EventArgs e)
        {
            minute = numMinute.Value.ToString();
            SetFullTime();
        }

        private void numSecond_ValueChanged(object sender, EventArgs e)
        {
            second = numSecond.Value.ToString();
            SetFullTime();
        }

        private void SetFullTime()
        {
            txtStarttime.Text = string.Format("{0}/{1}/{2} {3}:{4}:{5}", year, month, day, hour, minute, second);
        }
        private void Test()
        {
            
        }

        private void SetStartTime_Load(object sender, EventArgs e)
        {
            txtStarttime.Text = DateTime.Now.ToStandardTimeStr();
        }

        private void btnSetHms_Click(object sender, EventArgs e)
        {
            DateTime dtime = DateTime.Now;
            numHour.Value = dtime.Hour;
            numMinute.Value = dtime.Day;
            numSecond.Value = dtime.Second;
        }

        private void btnSetYMD_Click(object sender, EventArgs e)
        {
            DateTime dtime = DateTime.Now;
            dtpStartYMD.Value = DateTime.Now;
        }
    }
}
