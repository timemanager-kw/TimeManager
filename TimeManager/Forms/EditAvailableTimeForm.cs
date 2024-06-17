using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;

namespace TimeManager.Forms
{
    public partial class EditAvailableTimeForm : Form
    {
        MainForm mainForm;
        TimeTable timeTable;

        List<WeeklyDateTimeBlock> weeklyTimeTableBlocks;

        public EditAvailableTimeForm(MainForm mainForm, TimeTable timeTable, Week week)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.timeTable = timeTable;

            weeklyTimeTableBlocks = timeTable.GetWeeklyWorkTimes(week);
            MessageBox.Show($"{weeklyTimeTableBlocks[0].StartTime}\r\n");
            weeklyTimeTableSelectableControl1.UpdateSelectedBlocks(weeklyTimeTableBlocks);
        }

        private void selectedTimes_Click(object sender, EventArgs e)
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

        private void doneBtn_Click(object sender, EventArgs e)
        {
            List<DateTimeBlock> blocksTmp = new List<DateTimeBlock>();

            foreach(WeeklyDateTimeBlock block in weeklyTimeTableSelectableControl1.GetSelectedBlocks())
            {
                blocksTmp.Add(new DateTimeBlock(block.StartTime, block.EndTime));
            }

            timeTable.SetWorkTimes(blocksTmp);

            mainForm.CloseAvailableTime(timeTable);

            Close();
        }
    }
}
