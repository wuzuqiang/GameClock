using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClock
{
    public partial class FrmSetIntervalTime : Form
    {
        public FrmSetIntervalTime()
        {
            InitializeComponent();
        }

        public string day = "0";
        public string hour = "0";
        public string minute = "0";
        public string second = "0";
        private void btn_Click(object sender, EventArgs e)
        {
            day = numDay.Value.ToString();
            hour = numHour.Value.ToString();
            minute = numMinute.Value.ToString();
            second = numSecond.Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmSetIntervalTime_Load(object sender, EventArgs e)
        {
            numDay.Value = day.ToInt32();
            numHour.Value = hour.ToInt32();
            numMinute.Value = minute.ToInt32();
            numSecond.Value = second.ToInt32();
        }
    }
}
