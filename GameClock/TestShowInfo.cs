﻿using System;
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
    public partial class TestShowInfo : Form
    {
        public TestShowInfo()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            else
            {
                string site = listView1.SelectedItems[0].Text;
                string type = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }
    }
}
