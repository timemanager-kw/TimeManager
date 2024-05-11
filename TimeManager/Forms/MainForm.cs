using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TimeManager.Forms
{
    public partial class MainForm : Form
    {
        private TaskManager _taskManager;
        private ScheduleManager _scheduleManager;

        public void TimeBlockViewForm(TaskManager taskManager, ScheduleManager scheduleManager)
        {
            this._taskManager = taskManager;
            this._scheduleManager = scheduleManager;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Week week = Week.From(DateTime.Now);
            WeekTxtBox.Text = $"{week.Year}.{week.Month} {week.WeekOfMonth}주차";

            TimeBlockView.View = View.Details;

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("Day", "Day");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;
            TimeBlockView.Columns["Day"].TextAlign = HorizontalAlignment.Left;

            UpdateTaskView();
        }

        private void TaskBtn_Click(object sender, EventArgs e)
        {
            UpdateTaskView();
        }

        private void ScheduleBtn_Click(object sender, EventArgs e)
        {
            UpdateScheduleView();
        }

        public void UpdateTaskView()
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

                        lvItem.SubItems[0].Name = task.Name;
                        lvItem.SubItems[1].Name = string.Format(task.EndDate.ToString(), "yyyy-MM-dd");

                        TimeBlockView.Items.Add(lvItem);
                    }
                }
            }
            else
            {
                LogTxt.Text = "업무가 없습니다";
            }
        }

        public void UpdateScheduleView()
        {
            if (_scheduleManager == null) return;

            TimeBlockView.Clear();

            List<Schedule> schedules = _scheduleManager.GetAll().ToList();
            if (schedules.Count > 0)
            {
                foreach (Schedule schedule in schedules)
                {
                    var lvItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

                    lvItem.SubItems[0].Name = schedule.Name;

                    TimeBlockView.Items.Add(lvItem);
                }
            }
            else
            {
                LogTxt.Text = "일정이 없습니다";
            }
        }

        private void PreBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
