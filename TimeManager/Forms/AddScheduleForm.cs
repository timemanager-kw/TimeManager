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
    public partial class AddScheduleForm : Form
    {
        Schedule Schedule;

        DayOfWeek dayOfWeek;

        List<WeeklyDateTimeBlock> weeklyDateTimeBlocks;
        WeeklyDateTimeBlock[] weeklyBlock = new WeeklyDateTimeBlock[7];
            
        bool[] daysBool = new bool[] { false, false, false, false, false, false, false };

        public AddScheduleForm()
        {
            InitializeComponent();

            dayOfWeek = DayOfWeek.Monday;

            Schedule = new Schedule();

            weeklyDateTimeBlocks = new List<WeeklyDateTimeBlock>();
            
            for (int i = 0; i < 7; i++) weeklyBlock[i].DayOfWeek = (DayOfWeek)i;

            for (int i = 0; i < 24; i++)
            {
                AddScheduleStartTime.Items.Add($"{i}:00");

                AddScheduleEndTime.Items.Add($"{i}:00");
            }

            UpdateAddScheduleView();
        }

        void UpdateAddScheduleView()
        {
            AddSingleSchedulePanel.Visible = !AddScheduleIsRegular.Checked;
            AddRegularSchedulePanel.Visible = AddScheduleIsRegular.Checked;
        }

        void UpdateTimeBlock()
        {
            if (!AddRegularScheduleIsTrue.Checked) return;
            string[] hm = AddScheduleStartTime.Text.Split(':');
            weeklyBlock[(int)dayOfWeek].DayOfWeek = dayOfWeek;
            weeklyBlock[(int)dayOfWeek].StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
            hm = AddScheduleEndTime.Text.Split(':');
            weeklyBlock[(int)dayOfWeek].StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
        }

        void UpdateRegularScheduleView()
        {
            if (!daysBool[(int)dayOfWeek])
            {
                AddScheduleStartTime.Text = "00:00";
                AddScheduleEndTime.Text = "00:00";
                AddScheduleTimePanel.Enabled = false;
            }
            else
            {
                AddScheduleStartTime.Text = weeklyBlock[(int)dayOfWeek].StartTime.ToString("HH:mm");
                AddScheduleEndTime.Text = weeklyBlock[(int)dayOfWeek].EndTime.ToString("HH:mm");
                AddScheduleTimePanel.Enabled = true;
            }
        }

        private void AddSchedule_Click(object sender, EventArgs e)
        {
            Action[] AddType = new Action[]
            {
                () => {
                    string[] hm = AddScheduleStartTime.Text.Split(':');
                    DateTimeBlock dateTimeBlock= new DateTimeBlock();
                    dateTimeBlock.StartDate = new DateTime(AddSingleScheduleDatePicker.Value.Year, AddSingleScheduleDatePicker.Value.Month, AddSingleScheduleDatePicker.Value.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
                    hm = AddScheduleEndTime.Text.Split(':');
                    dateTimeBlock.EndDate = new DateTime(AddSingleScheduleDatePicker.Value.Year, AddSingleScheduleDatePicker.Value.Month, AddSingleScheduleDatePicker.Value.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
                },
                () => {
                    for (int i = 0;i < 7; i++)
                    {
                        if (daysBool[i]) weeklyDateTimeBlocks.Add(weeklyBlock[i]);
                    }
                }
            };
            Schedule.Name = AddScheduleName.Text;
            //ID 추가
            Schedule.Type = AddScheduleIsRegular.Checked ? EScheduleType.Regular : EScheduleType.Singular;
            Schedule.Description = AddScheduleMemo.Text;

            Close();
        }

        private void AddRegularScheduleIsTrue_CheckedChanged(object sender, EventArgs e)
        {
            daysBool[(int)dayOfWeek] = AddRegularScheduleIsTrue.Checked;
            AddScheduleTimePanel.Enabled = true;
        }

        private void AddRegularScheduleMon_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Monday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleTue_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Tuesday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleWed_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Wednesday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleThu_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Thursday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleFri_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Friday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleSat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Saturday;
            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleSun_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeBlock();
            dayOfWeek = DayOfWeek.Sunday;
            UpdateRegularScheduleView();
        }

        private void AddScheduleCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddScheduleIsRegular_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAddScheduleView();
        }
    }
}
