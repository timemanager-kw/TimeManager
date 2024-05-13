using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;
using TimeManager.Scheduler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

public enum TimeTableType
{
    Schedule,
    Task
}

namespace TimeManager.Forms
{
    public partial class MainForm : Form
    {
        private IScheduler _scheduler;

        private ScheduleManager _scheduleManager;
        private TaskManager _taskManager;

        DateTime StandardTime;

        TimeTableType viewType = TimeTableType.Schedule;

        public Action[] UpdateView;

        Form AddForm;
        Action[] AddForms;

        //public void SchedulerForm(IScheduler scheduler)
        //{
        //    this._scheduler = scheduler;
        //}

        public void TimeBlockViewForm(ScheduleManager scheduleManager, TaskManager taskManager)
        {
            this._scheduleManager = scheduleManager;
            this._taskManager = taskManager;
        }

        void ResizeForm()
        {
            TimeBlockTitlePanel.Size = new Size(TimeBlockTitlePanel.Size.Width, this.Size.Height * 2 / 27);
            ScheduleBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, ScheduleBtn.Size.Height);
            TaskBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, TaskBtn.Size.Height);
            AddBtn.Size = new Size(AddBtn.Size.Height, AddBtn.Size.Height);

            //TitlePanel.Size = new Size(TitlePanel.Size.Width, this.Size.Height * 2 / 27);
            PrevBtn.Size = new Size(PrevBtn.Size.Height * 7 / 6, PrevBtn.Size.Height);
            WeekLabel.Size = new Size(WeekLabel.Size.Height * 13 / 3, WeekLabel.Size.Height);
            NextBtn.Size = new Size(NextBtn.Size.Height * 7 / 6, NextBtn.Size.Height);
            AlgorithmStarter.Size = new Size(AlgorithmStarter.Size.Height * 5 / 3, AlgorithmStarter.Size.Height);

            //TimeBlockSettingPanel.Size = new Size(this.Size.Width * 5 / 24, TimeBlockSettingPanel.Size.Height);


            ScheduleBtn.Font = new Font(ScheduleBtn.Font.FontFamily, ScheduleBtn.Size.Height * 11 / 37);
            TaskBtn.Font = new Font(TaskBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            AddBtn.Font = new Font(AddBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            TimeBlockView.Font = new Font(TimeBlockView.Font.FontFamily, ScheduleBtn.Font.Size);

            PrevBtn.Font = new Font(PrevBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            WeekLabel.Font = new Font(WeekLabel.Font.FontFamily, ScheduleBtn.Font.Size);
            NextBtn.Font = new Font(NextBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            AlgorithmStarter.Font = new Font(AlgorithmStarter.Font.FontFamily, ScheduleBtn.Font.Size);
        }

        void UpdateScheduleView()
        {
            var testItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

            testItem.SubItems[0].Text = "Test1";
            testItem.SubItems[1].Text = "2024.05.15";

            TimeBlockView.Items.Add(testItem);

            if (_scheduleManager == null) return;

            TimeBlockView.Clear();

            List<Schedule> schedules = _scheduleManager.GetAll().ToList();
            if (schedules.Count > 0)
            {
                foreach (Schedule schedule in schedules)
                {
                    var lvItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

                    lvItem.SubItems[0].Text = schedule.Name;

                    TimeBlockView.Items.Add(lvItem);
                }
            }
            else
            {
                LogTxt.Text = "일정이 없습니다";
            }
        }

        void UpdateTaskView()
        {
            if (_taskManager == null) return;

            TimeBlockView.Clear();

            List<Task> tasks = _taskManager.GetAll().ToList();
            if (tasks.Count > 0)
            {
                foreach (Task task in tasks)
                {
                    if (task.EndDate > DateTime.Now)
                    {
                        var lvItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

                        lvItem.SubItems[0].Text = task.Name;
                        lvItem.SubItems[1].Text = string.Format(task.EndDate.ToString(), "yyyy-MM-dd");

                        TimeBlockView.Items.Add(lvItem);
                    }
                }
            }
            else
            {
                LogTxt.Text = "업무가 없습니다";
            }
        }

        public void UpdateWeekText()
        {
            Week week = Week.From(StandardTime);
            WeekLabel.Text = $"{week.Year}.{week.Month} {week.WeekOfMonth}주차";
        }

        void AddScheduleForm()
        {
            if (AddForm != null)
            {
                AddForm.Close();
                AddForm = null;
            }
            AddScheduleForm addScheduleForm = new AddScheduleForm();
            AddForm = addScheduleForm;
            AddForm.MdiParent = this;
            AddForm.Size = AddPanel.Size;
            AddForm.BringToFront();
            //AddForm.Location = AddPanel.Location;
            AddForm.Show();
        }

        void AddTaskForm()
        {
            if (AddForm != null)
            {
                AddForm.Close();
                AddForm = null;
            }
            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.MdiParent = this;
            AddForm = addTaskForm;
            AddForm.Size = AddPanel.Size;
            AddForm.BringToFront();
            //AddForm.Location = AddPanel.Location;
            AddForm.Show();
        }

        public MainForm()
        {
            InitializeComponent();

            StandardTime = DateTime.Now;
            StandardTime.AddDays(-(int)StandardTime.DayOfWeek);

            UpdateView = new Action[] { UpdateScheduleView, UpdateTaskView };
            AddForms = new Action[] { AddScheduleForm, AddTaskForm };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeForm();

            TimeBlockView.View = View.Details;

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("Date", "Date");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;
            TimeBlockView.Columns[1].TextAlign = HorizontalAlignment.Left;

            viewType = TimeTableType.Schedule;

            UpdateScheduleView();

            UpdateWeekText();
        }

        private void ScheduleBtn_Click(object sender, EventArgs e)
        {
            viewType = TimeTableType.Schedule;
            UpdateView[(int)viewType]();
        }

        private void TaskBtn_Click(object sender, EventArgs e)
        {
            viewType = TimeTableType.Task;
            UpdateView[(int)viewType]();
        }

        private void PreBtn_Click(object sender, EventArgs e)
        {
            StandardTime = StandardTime.AddDays(-7);
            UpdateWeekText();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            StandardTime = StandardTime.AddDays(7);
            UpdateWeekText();
        }

        private void AlgorithmStarter_Click(object sender, EventArgs e)
        {
            //scheduler.Run();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddForms[(int)viewType]();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void TimeBlockView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TimeBlockView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (TimeBlockView.FocusedItem != null) AddBtn.Text = "*";
            else AddBtn.Text = "+";
        }
    }
}
