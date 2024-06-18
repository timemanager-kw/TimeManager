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
        MainForm MainForm;

        Schedule Schedule;

        DayOfWeek dayOfWeek;

        List<WeeklyDateTimeBlock> weeklyDateTimeBlocks;
        WeeklyDateTimeBlock[] weeklyBlock = new WeeklyDateTimeBlock[7];

        bool[] daysBool = new bool[] { false, false, false, false, false, false, false };

        public AddScheduleForm(MainForm mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;

            dayOfWeek = DayOfWeek.Monday;

            Schedule = new Schedule();

            weeklyDateTimeBlocks = new List<WeeklyDateTimeBlock>();

            for (int i = 0; i < 7; i++)
            {
                weeklyBlock[i].DayOfWeek = (DayOfWeek)i;
                weeklyBlock[i].StartTime = DateTime.Now;
                weeklyBlock[i].EndTime = DateTime.Now;
            }

            for (int i = 0; i < 24; i++)
            {
                AddScheduleStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                AddScheduleStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");

                AddScheduleEndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                AddScheduleEndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");
            }

            AddScheduleTimePanel.Enabled = false;

            UpdateAddScheduleView();
        }

        void UpdateAddScheduleView()
        {
            if (!AddScheduleIsRegular.Checked)
            {
                AddSingleSchedulePanel.Visible = true;
                AddRegularSchedulePanel.Visible = false;
                AddScheduleTimePanel.Enabled = true;

                return;
            }
            AddSingleSchedulePanel.Visible = !AddScheduleIsRegular.Checked;
            AddRegularSchedulePanel.Visible = AddScheduleIsRegular.Checked;
            AddScheduleTimePanel.Enabled = daysBool[(int)DayOfWeek.Monday];
        }

        void UpdateTimeBlock()
        {
            if (!AddRegularScheduleIsTrue.Checked) return;
            string[] hm = AddScheduleStartTime.Text.Split(':');
            weeklyBlock[(int)dayOfWeek].StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
            hm = AddScheduleEndTime.Text.Split(':');
            weeklyBlock[(int)dayOfWeek].EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
        }

        void UpdateRegularScheduleView()
        {
            AddRegularScheduleIsTrue.Checked = daysBool[(int)dayOfWeek];
            if (!daysBool[(int)dayOfWeek])
            {
                AddScheduleStartTime.Text = "00:00";
                AddScheduleEndTime.Text = "00:00";
            }
            else
            {
                AddScheduleStartTime.Text = weeklyBlock[(int)dayOfWeek].StartTime.ToString("HH:mm");
                AddScheduleEndTime.Text = weeklyBlock[(int)dayOfWeek].EndTime.ToString("HH:mm");
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
                    Schedule.TimeBlock = dateTimeBlock;

                    if (dateTimeBlock.StartDate.CompareTo(dateTimeBlock.EndDate) >= 0)
                    {
                        MessageBox.Show("시작 시간이 종료 시간 뒤에 올 수 없습니다.");
                        return;
                    }

                    MainForm.CloseAddSchedule(true, Schedule);
                    Close();
                },
                () => {
                    UpdateTimeBlock();
                    for (int i = 0;i < 7; i++)
                    {
                        if (daysBool[i])
                        {
                            if (weeklyBlock[i].StartTime.CompareTo(weeklyBlock[i].EndTime) >= 0)
                            {
                                MessageBox.Show("시작 시간이 종료 시간 뒤에 올 수 없습니다.");
                                return;
                            }
                            weeklyDateTimeBlocks.Add(weeklyBlock[i]);
                        }
                    }
                    Schedule.RegularTimeBlocks = weeklyDateTimeBlocks;

                    MainForm.CloseAddSchedule(true, Schedule);
                    Close();
                }
            };
            Schedule.Name = AddScheduleName.Text;
            Schedule.Type = AddScheduleIsRegular.Checked ? EScheduleType.Regular : EScheduleType.Singular;
            Schedule.Description = AddScheduleMemo.Text;

            AddType[(int)Schedule.Type]();
        }

        private void AddRegularScheduleIsTrue_CheckedChanged(object sender, EventArgs e)
        {
            daysBool[(int)dayOfWeek] = AddRegularScheduleIsTrue.Checked;
            AddScheduleTimePanel.Enabled = daysBool[(int)dayOfWeek];
        }

        private void AddScheduleCancle_Click(object sender, EventArgs e)
        {
            MainForm.CloseAddSchedule(false, null);
            Close();
        }

        private void AddScheduleIsRegular_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAddScheduleView();
        }

        private void AddRegularScheduleMon_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleMon.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Monday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleTue_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleTue.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Tuesday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleWed_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleWed.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Wednesday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleThu_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleThu.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Thursday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleFri_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleFri.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Friday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleSat_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleSat.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Saturday;

            UpdateRegularScheduleView();
        }

        private void AddRegularScheduleSun_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddRegularScheduleSun.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Sunday;

            UpdateRegularScheduleView();
        }
    }
}
