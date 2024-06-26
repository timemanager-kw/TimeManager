﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManager.Forms.Tests
{
    public partial class TestWeeklyTimeTableSelectableControl : Form
    {
        public TestWeeklyTimeTableSelectableControl()
        {
            InitializeComponent();
        }

        private void btnShowSelected_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                string.Join("\n", weeklyTimeTableSelectableControl1
                .GetSelectedBlocks()
                .Select(block => 
                    block.DayOfWeek.ToString() 
                    + ": " 
                    + block.StartTime.ToString("HH:mm")
                    + " ~ "
                    + block.EndTime.ToString("HH:mm")
                )
            ));
        }
    }
}
