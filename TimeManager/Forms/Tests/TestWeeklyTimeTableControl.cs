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
            assignedSchedule1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 8, 0, 0), new DateTime(2024, 5, 6, 12, 0, 0)));

            AssignedTask assignedTask1 = new AssignedTask();
            assignedTask1.TaskId = 1;
            assignedTask1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 13, 0, 0), new DateTime(2024, 5, 6, 17, 0, 0)));

            timeTable = new TimeTable(new List<DateTimeBlock>(), new List<AssignedSchedule> { assignedSchedule1 }, new List<AssignedTask>());

            Week week = new Week();
            week.Year = 2024;
            week.Month = 5;
            week.WeekOfMonth = 1;

            weeklyTimeTableControl1.DrawSchedules(timeTable, week);
        }
    }
}
