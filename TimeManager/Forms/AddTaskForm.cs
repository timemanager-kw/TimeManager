using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeManager.Data.Model;

namespace TimeManager.Forms
{
    public partial class AddTaskForm : Form
    {
        MainForm MainForm;

        Task Task;

        DayOfWeek dayOfWeek;

        List<longTermProperties> weeklyWanted;
        longTermProperties[] weeklyBlock = new longTermProperties[7];

        bool[] daysBool = new bool[] { false, false, false, false, false, false, false };

        public AddTaskForm(MainForm mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;

            Task = new Task();

            for (int i = 0; i < 7; i++)
            {
                weeklyBlock[i].dayOfWeek = (DayOfWeek)i;
                weeklyBlock[i].time = new TimeSpan(0);
            }

            for (int i = 30; i < 6000; i += 30)
            {
                TaskDurationCmb.Items.Add($"{(i / 60 < 10 ? $"0{i / 60}" : $"{i / 60}")}:{(i % 60 == 0 ? "00" : "30")}");
            }

            weeklyWanted = new List<longTermProperties>();
            dayOfWeek = DayOfWeek.Monday;

            UpdateAddTaskView();
        }

        void UpdateAddTaskView()
        {
            AddShortTaskPanel.Visible = !AddTaskIsLong.Checked;
            AddLongTaskPanel.Visible = AddTaskIsLong.Checked;
            TaskDurationCmb.Enabled = !AddTaskIsLong.Checked;
        }

        void UpdateLongTaskView()
        {
            LongTaskIsTrue.Checked = daysBool[(int)dayOfWeek];
            if (!daysBool[(int)dayOfWeek])
            {
                TaskDurationCmb.Text = "00:00";
            }
            else
            {
                TaskDurationCmb.Text = weeklyBlock[(int)dayOfWeek].time.TotalMinutes == 0 ? "00:00" : $"{(int)(weeklyBlock[(int)dayOfWeek].time.TotalMinutes / 60)}:{weeklyBlock[(int)dayOfWeek].time.TotalMinutes % 60}";
            }
        }

        void UpdateTimeBlock()
        {
            if (!LongTaskIsTrue.Checked) return;
            string[] hm = TaskDurationCmb.Text.Split(':');
            weeklyBlock[(int)dayOfWeek].time = new TimeSpan(int.Parse(hm[0]), int.Parse(hm[1]), 0);
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            Action[] AddType = new Action[]
            {
                () => {
                    Task.StartDate = AddShortTaskStartDatePicker.Value;
                    Task.EndDate = AddShortTaskEndDatePicker.Value;

                    if (Task.StartDate.CompareTo(Task.EndDate) >= 0)
                    {
                        MessageBox.Show("시작일이 마감일 뒤에 올 수 없습니다.");
                        return;
                    }

                    Task.Duration = new TimeSpan(0, int.Parse(TaskDurationCmb.Text.Split(':')[0]) * 60 + int.Parse(TaskDurationCmb.Text.Split(':')[1]), 0);
                    Task.FocusDays = (int)(AddShortTaskEndDatePicker.Value - AddShortTaskStartDatePicker.Value).TotalDays + 1;

                    MainForm.CloseAddTask(true, Task);
                    Close();
                },
                () => {
                    UpdateTimeBlock();
                    for (int i = 0;i < 7; i++)
                    {
                        if (daysBool[i])
                        {
                            if (weeklyBlock[i].time.TotalMinutes <= 0)
                            {
                                MessageBox.Show("시작 시간이 종료 시간 뒤에 올 수 없습니다.");
                                return;
                            }
                            weeklyWanted.Add(weeklyBlock[i]);
                        }
                    }
                    Task.WeeklyTimesWanted = weeklyWanted;

                    MainForm.CloseAddTask(true, Task);
                    Close();
                }
            };
            Task.Name = AddTaskName.Text;
            Task.Type = AddTaskIsLong.Checked ? ETaskType.LongTerm : ETaskType.ShortTerm;
            Task.Description = AddTaskMemo.Text;

            AddType[(int)Task.Type]();
        }

        private void AddTaskIsLong_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAddTaskView();
        }

        private void AddLongTaskMon_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskMon.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Monday;

            UpdateLongTaskView();
        }

        private void AddLongTaskTue_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskTue.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Tuesday;

            UpdateLongTaskView();
        }

        private void AddLongTaskWed_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskWed.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Wednesday;

            UpdateLongTaskView();
        }

        private void AddLongTaskThu_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskThu.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Thursday;

            UpdateLongTaskView();
        }

        private void AddLongTaskFri_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskFri.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Friday;

            UpdateLongTaskView();
        }

        private void AddLongTaskSat_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskSat.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Saturday;

            UpdateLongTaskView();
        }

        private void AddLongTaskSun_CheckedChanged(object sender, EventArgs e)
        {
            if (!AddLongTaskSun.Checked) return;

            UpdateTimeBlock();

            dayOfWeek = DayOfWeek.Sunday;

            UpdateLongTaskView();
        }

        private void AddLongTaskIsTrue_CheckedChanged(object sender, EventArgs e)
        {
            daysBool[(int)dayOfWeek] = LongTaskIsTrue.Checked;
            TaskDurationCmb.Enabled = daysBool[(int)dayOfWeek];
        }

        private void AddTaskCancle_Click(object sender, EventArgs e)
        {
            MainForm.CloseAddTask(false, null);
            Close();
        }
    }
}
