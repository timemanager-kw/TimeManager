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
using TimeManager.Scheduler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        Schedule focusedSchedule;
        Task focusedTask;

        List<Schedule> testSchedule;
        List<Task> testTask;

        DateTime StandardTime;

        TimeTableType viewType = TimeTableType.Schedule;

        Panel[] schedulePanels;
        Panel[] taskPanels;

        public Action[] UpdateView;
        public Action[] CurrentTimeBlockInfo;

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
            MainPanel.Size = new Size(this.Size.Width * 37 / 48, this.Size.Height * 2 / 27);
            TitlePanel.Size = new Size(MainPanel.Size.Width, MainPanel.Height);
            PrevBtn.Size = new Size(PrevBtn.Size.Height * 7 / 6, PrevBtn.Size.Height);
            WeekLabel.Size = new Size(WeekLabel.Size.Height * 13 / 3, WeekLabel.Size.Height);
            NextBtn.Size = new Size(NextBtn.Size.Height * 7 / 6, NextBtn.Size.Height);
            AlgorithmStarter.Size = new Size(AlgorithmStarter.Size.Height, AlgorithmStarter.Size.Height);

            for(int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Width = (dataGridView.Width - 65) / 7 - 1;
            }
            dataGridView.RowHeadersWidth = dataGridView.Width - dataGridView.Columns[0].Width * 7 - 3;

            TimeBlockTitlePanel.Size = new Size(TimeBlockTitlePanel.Size.Width, this.Size.Height * 2 / 27);
            ScheduleBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, ScheduleBtn.Size.Height);
            TaskBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, TaskBtn.Size.Height);
            AddBtn.Size = new Size(AddBtn.Size.Height, AddBtn.Size.Height);

            TimeBlockView.Size = new Size(TimeBlockTitlePanel.Size.Width, this.Size.Height * 11 / 27);
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
            ClearEditPanel();

            TimeBlockView.Clear();

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;

            if (_scheduleManager == null)
            {
                foreach (Schedule schedule in testSchedule)
                {
                    var lvItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

                    lvItem.SubItems[0].Text = schedule.Name;

                    TimeBlockView.Items.Add(lvItem);
                }

                return;
            }

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
            ClearEditPanel();

            TimeBlockView.Clear();

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("Date", "Date");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;
            TimeBlockView.Columns[1].TextAlign = HorizontalAlignment.Left;

            if (_taskManager == null)
            {
                foreach (Task task in testTask)
                {
                    if (task.EndDate > DateTime.Now)
                    {
                        var lvItem = new ListViewItem(new string[2]);

                        lvItem.SubItems[0].Text = task.Name;
                        lvItem.SubItems[1].Text = string.Format(task.EndDate.ToString(), "yyyy-MM-dd");

                        TimeBlockView.Items.Add(lvItem);
                    }
                }
                return;
            }

            List<Task> tasks = _taskManager.GetAll().ToList();
            if (tasks.Count > 0)
            {
                foreach (Task task in tasks)
                {
                    if (task.EndDate > DateTime.Now)
                    {
                        var lvItem = new ListViewItem(new string[2]);

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

        void EditScheduleForm()
        {
            ClearEditPanel();

            Action[] scheduleSet = new Action[2]
            {
                () => {
                    ScheduleNameTxt.Text = focusedSchedule.Name;
                    ScheduleDatePicker.Text = focusedSchedule.TimeBlock.StartDate.ToString("yyyy-MM-dd");
                    ScheduleStartTime.Text = focusedSchedule.TimeBlock.StartDate.ToString("HH:mm");
                    ScheduleEndTime.Text = focusedSchedule.TimeBlock.EndDate.ToString("HH:mm");
                },
                () => {
                    ScheduleRNameTxt.Text = focusedSchedule.Name;
                    ScheduleRDay.Text = "월";
                    DayCheck.Checked = focusedSchedule.RegularTimeBlocks[0].DayOfWeek == DayOfWeek.Monday;
                    ScheduleRStartTime.Text = DayCheck.Checked ? focusedSchedule.RegularTimeBlocks[0].StartTime.ToString("HH:mm") : "";
                    ScheduleREndTime.Text = DayCheck.Checked ? focusedSchedule.RegularTimeBlocks[0].EndTime.ToString("HH:mm") : "";
                }
            };
            scheduleSet[(int)testSchedule[TimeBlockView.FocusedItem.Index].Type]();

            //TaskPanel.Visible = false;
            schedulePanels[(int)focusedSchedule.Type].Visible = true;
        }

        void EditTaskForm()
        {
            ClearEditPanel();

            //TaskPanel.Visible = true;
            SingleSchedulePanel.Visible = false;
        }

        void ClearEditPanel()
        {
            foreach (var panelTmp in schedulePanels)
            {
                panelTmp.Visible = false;
            }
            /*foreach (var panelTmp in taskPanels)
            {
                panelTmp.Visible = false;
            }*/
        }

        public MainForm()
        {
            InitializeComponent();

            StandardTime = DateTime.Now;
            StandardTime.AddDays(-(int)StandardTime.DayOfWeek);

            UpdateView = new Action[] { UpdateScheduleView, UpdateTaskView };

            CurrentTimeBlockInfo = new Action[] { EditScheduleForm, EditTaskForm };

            schedulePanels = new Panel[] { SingleSchedulePanel, RegularSchedulePanel };

            for (int i = 0; i < 24; i++)
            {
                ScheduleStartTime.Items.Add($"{i}:00");
                ScheduleStartTime.Items.Add($"{i}:30");
                ScheduleRStartTime.Items.Add($"{i}:00");
                ScheduleRStartTime.Items.Add($"{i}:30");

                ScheduleEndTime.Items.Add($"{i}:00");
                ScheduleEndTime.Items.Add($"{i}:30");
                ScheduleREndTime.Items.Add($"{i}:00");
                ScheduleREndTime.Items.Add($"{i}:30");
            }

            testSchedule = new List<Schedule>
            {
                new Schedule(),
                new Schedule()
            };
            testSchedule[0].Id = 1;
            testSchedule[0].Name = "Test Schedule1";
            testSchedule[0].Type = EScheduleType.Singular;
            testSchedule[0].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 14, 18, 30, 0));

            testSchedule[1].Id = 2;
            testSchedule[1].Name = "Test Schedule2";
            testSchedule[1].Type = EScheduleType.Regular;
            testSchedule[1].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 25));
            WeeklyDateTimeBlock test1 = new WeeklyDateTimeBlock();
            WeeklyDateTimeBlock test2 = new WeeklyDateTimeBlock();
            WeeklyDateTimeBlock test3 = new WeeklyDateTimeBlock();
            test1.DayOfWeek = DayOfWeek.Monday;
            test2.DayOfWeek = DayOfWeek.Saturday;
            test3.DayOfWeek = DayOfWeek.Sunday;
            test1.StartTime = DateTime.Now.AddMinutes(30);
            test1.EndTime = DateTime.Now.AddMinutes(90);
            test2.StartTime = DateTime.Now.AddMinutes(60);
            test2.EndTime = DateTime.Now.AddMinutes(120);
            test3.StartTime = DateTime.Now.AddMinutes(90);
            test3.EndTime = DateTime.Now.AddMinutes(180);
            List<WeeklyDateTimeBlock> testSchedulTimeBlocks = new List<WeeklyDateTimeBlock>()
            {
                test1,
                test2,
                test3
            };
            testSchedule[1].RegularTimeBlocks = testSchedulTimeBlocks;

            testTask = new List<Task>
            {
                new Task(),
                new Task()
            };
            testTask[0].Id = 3;
            testTask[0].Name = "Test Task1";
            testTask[0].EndDate = new DateTime(2024, 5, 20);

            testTask[1].Id = 4;
            testTask[1].Name = "Test Task2";
            testTask[1].EndDate = new DateTime(2024, 5, 25);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeForm();

            TimeBlockView.View = View.Details;

            viewType = TimeTableType.Schedule;

            UpdateView[0]();

            UpdateWeekText();

            SingleSchedulePanel.Visible = false;
            //TaskPanel.Visible = false;
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
            Action[] focusedSet = new Action[]
            {
                () =>
                {
                    focusedTask = null;
                    focusedSchedule = TimeBlockView.FocusedItem != null ? testSchedule[TimeBlockView.FocusedItem.Index] : null;
                },
                () =>
                {
                    focusedSchedule = null;
                    focusedTask = TimeBlockView.FocusedItem != null ? testTask[TimeBlockView.FocusedItem.Index] : null;
                }
            };

            focusedSet[(int)viewType]();
            if (focusedSchedule != null || focusedTask != null) CurrentTimeBlockInfo[(int)viewType]();
        }

        private void ScheduleEditCancle_Click(object sender, EventArgs e)
        {
            SingleSchedulePanel.Visible = false;
        }

        private void ScheduleEditOk_Click(object sender, EventArgs e)
        {
            focusedSchedule.Name = ScheduleNameTxt.Text;

            string[] startHM = ScheduleStartTime.Text.Split(':');
            string[] endHM = ScheduleEndTime.Text.Split(':');
            DateTime startTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(startHM[0]), int.Parse(startHM[1]), 0);
            DateTime endTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(endHM[0]), int.Parse(endHM[1]), 0);

            focusedSchedule.TimeBlock = new DateTimeBlock(startTmp, endTmp);
        }

        private void ScheduleRDayCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DayOfWeek dayOfWeek;

            switch (ScheduleRDay.Text)
            {
                case "월":
                    dayOfWeek = DayOfWeek.Monday; break;

                case "화":
                    dayOfWeek = DayOfWeek.Tuesday; break;

                case "수":
                    dayOfWeek = DayOfWeek.Wednesday; break;

                case "목":
                    dayOfWeek = DayOfWeek.Thursday; break;

                case "금":
                    dayOfWeek = DayOfWeek.Friday; break;

                case "토":
                    dayOfWeek = DayOfWeek.Saturday; break;

                case "일":
                    dayOfWeek = DayOfWeek.Sunday; break;

                default:
                    dayOfWeek= DayOfWeek.Saturday; break;
            }

            DayCheck.Checked = false;
            ScheduleRStartTime.Text = "";
            ScheduleREndTime.Text = "";

            foreach (var dayList in focusedSchedule.RegularTimeBlocks)
            {
                if (dayList.DayOfWeek == dayOfWeek)
                {
                    DayCheck.Checked = true;
                    ScheduleRStartTime.Text = dayList.StartTime.ToString("HH:mm");
                    ScheduleREndTime.Text = dayList.EndTime.ToString("HH:mm");

                    break;
                }
            }
        }
    }
}

