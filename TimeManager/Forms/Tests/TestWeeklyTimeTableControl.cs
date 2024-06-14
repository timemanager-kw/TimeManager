using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Data.Model;

namespace TimeManager.Forms.Tests
{
    public partial class TestWeeklyTimeTableControl : Form
    {
        private TimeTable timeTable;

        public TestWeeklyTimeTableControl()
        {
            InitializeComponent();
        }

        private void weeklyTimeTableControl1_Load(object sender, EventArgs e)
        {
            AssignedSchedule assignedSchedule1 = new AssignedSchedule();
            assignedSchedule1.ScheduleId = 1;
            assignedSchedule1.ScheduleName = "약속";
            assignedSchedule1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 8, 0, 0), new DateTime(2024, 5, 6, 12, 0, 0)));

            AssignedSchedule assignedSchedule2 = new AssignedSchedule();
            assignedSchedule2.ScheduleId = 2;
            assignedSchedule2.ScheduleName = "강의";
            assignedSchedule2.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 8, 9, 0, 0), new DateTime(2024, 5, 8, 12, 0, 0)));

            AssignedTask assignedTask1 = new AssignedTask();
            assignedTask1.TaskId = 1;
            assignedTask1.TaskName = "응소실 과제";
            assignedTask1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 13, 0, 0), new DateTime(2024, 5, 6, 17, 0, 0)));

            AssignedTask assignedTask2 = new AssignedTask();
            assignedTask2.TaskId = 2;
            assignedTask2.TaskName = "운영체제 과제";
            assignedTask2.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 9, 15, 0, 0), new DateTime(2024, 5, 9, 22, 0, 0)));

            List<DateTimeBlock> workTimes = new List<DateTimeBlock>();
            for (int i = 0; i < 7; i++)
            {
                workTimes.Add(new DateTimeBlock(new DateTime(2024, 5, 6 + i, 8, 0, 0), new DateTime(2024, 5, 6 + i, 22, 0, 0)));
            }

            timeTable = new TimeTable(workTimes, 
                new List<AssignedSchedule> { assignedSchedule1, assignedSchedule2 }, 
                new List<AssignedTask> { assignedTask1, assignedTask2 });

            Week week = new Week();
            week.Year = 2024;
            week.Month = 5;
            week.WeekOfMonth = 1;

            weeklyTimeTableControl1.DrawCells(timeTable, week);
        }

        private void weeklyTimeTableControl1_ItemSelected(object sender, Controls.WeeklyTimeTableControlItemEventArgs e)
        {
            label1.Text = "Selected: " + e.AssignedItemType.ToString() + " - " + e.AssignedItemId.ToString();
        }
    }
}
