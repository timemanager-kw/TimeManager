using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TimeManager.Controls;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;
using TimeManager.Extensions;
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
        private TimeTableManager _timeTableManager;
        private ScheduleManager _scheduleManager;
        private TaskManager _taskManager;

        private TimeTable timeTable;
        private Schedule focusedSchedule;
        private Task focusedTask;

        private List<Schedule> scheduleList;
        private List<Task> taskList;

        private DateTime StandardTime;

        private TimeTableType viewType = TimeTableType.Schedule;

        private Panel[] schedulePanels;
        private Panel[] taskPanels;

        public Action[] UpdateView;
        public Action[] CurrentTimeBlockInfo;

        //public void SchedulerForm(IScheduler scheduler)
        //{
        //    this._scheduler = scheduler;
        //}

        public void TimeBlockViewForm(TimeTableManager timeTableManager, ScheduleManager scheduleManager, TaskManager taskManager)
        {
            this._timeTableManager = timeTableManager;
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
                dataGridView.Columns[i].Width = (dataGridView.Width - 65) / 7 - 4;
            }
            dataGridView.RowHeadersWidth = dataGridView.Width - dataGridView.Columns[0].Width * 7 - 20;

            TimeBlockTitlePanel.Size = new Size(TimeBlockTitlePanel.Size.Width, this.Size.Height * 2 / 27);
            ScheduleBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, ScheduleBtn.Size.Height);
            TaskBtn.Size = new Size(TimeBlockTitlePanel.Size.Height * 45 / 34, TaskBtn.Size.Height);
            AddBtn.Size = new Size(AddBtn.Size.Height, AddBtn.Size.Height);

            TimeBlockView.Size = new Size(TimeBlockTitlePanel.Size.Width, this.Size.Height * 11 / 27);


            ScheduleBtn.Font = new Font(ScheduleBtn.Font.FontFamily, ScheduleBtn.Size.Height * 11 / 37);
            TaskBtn.Font = new Font(TaskBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            AddBtn.Font = new Font(AddBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            TimeBlockView.Font = new Font(TimeBlockView.Font.FontFamily, ScheduleBtn.Font.Size);

            PrevBtn.Font = new Font(PrevBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            WeekLabel.Font = new Font(WeekLabel.Font.FontFamily, ScheduleBtn.Font.Size);
            NextBtn.Font = new Font(NextBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            AlgorithmStarter.Font = new Font(AlgorithmStarter.Font.FontFamily, ScheduleBtn.Font.Size);
        }

        public void TimeTableView()
        {
            Week week = Week.From(StandardTime);
            WeekLabel.Text = $"{week.Year}.{week.Month} {week.WeekOfMonth}주차";

            //timeTable = _timeTableManager.Get();

            //DrawCells(timeTable, week);

            AssignedSchedule assignedSchedule1 = new AssignedSchedule();
            assignedSchedule1.ScheduleId = 1;
            assignedSchedule1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 8, 0, 0), new DateTime(2024, 5, 6, 12, 0, 0)));

            AssignedTask assignedTask1 = new AssignedTask();
            assignedTask1.TaskId = 1;
            assignedTask1.AssignedBlocks.Add(new DateTimeBlock(new DateTime(2024, 5, 6, 13, 0, 0), new DateTime(2024, 5, 6, 17, 0, 0)));

            List<DateTimeBlock> workTimes = new List<DateTimeBlock>();
            for (int i = 0; i < 7; i++)
            {
                workTimes.Add(new DateTimeBlock(new DateTime(2024, 5, 6 + i, 8, 0, 0), new DateTime(2024, 5, 6 + i, 22, 0, 0)));
            }

            timeTable = new TimeTable(workTimes, new List<AssignedSchedule> { assignedSchedule1 }, new List<AssignedTask> { assignedTask1 });

            DrawCells(week);
        }

        private void InitializeRows()
        {
            for (int i = 0; i < 48; i++)
            {
                DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddMinutes(i * 30);

                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = dateTime.ToString("HH:mm");
            }
        }

        public void CleanCells()
        {
            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = null;
                    dataGridView.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                }
            }
        }

        public void DrawCells(Week week)
        {
            CleanCells();
            DrawWorkTimes(week);
            DrawSchedules(week);
            DrawTasks(week);
        }

        private void DrawWorkTimes(Week week)
        {
            foreach (WeeklyDateTimeBlock block in timeTable.GetWeeklyWorkTimes(week))
            {
                int startRow = block.StartTime.Hour * 2 + block.StartTime.Minute / 30;
                int endRow = block.EndTime.Hour * 2 + block.EndTime.Minute / 30;

                for (int i = startRow; i < endRow; i++)
                {
                    dataGridView.Rows[i].Cells[block.DayOfWeek.GetDayOfWeekIndex()].Style.BackColor = Color.White;
                }
            }
        }

        private void DrawSchedules(Week week)
        {
            List<AssignedSchedule> schedules = timeTable.GetWeeklyAssignedSchedules(week);

            foreach (AssignedSchedule schedule in schedules)
            {
                foreach (DateTimeBlock block in schedule.AssignedBlocks)
                {
                    if (!week.IsInWeek(block.StartDate)) continue;

                    int startRow = block.StartDate.Hour * 2 + block.StartDate.Minute / 30;
                    int endRow = block.EndDate.Hour * 2 + block.EndDate.Minute / 30;

                    for (int i = startRow; i < endRow; i++)
                    {
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "Schedule " + schedule.ScheduleId;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void DrawTasks(Week week)
        {
            List<AssignedTask> tasks = timeTable.GetWeeklyAssignedTasks(week);

            foreach (AssignedTask task in tasks)
            {
                foreach (DateTimeBlock block in task.AssignedBlocks)
                {
                    if (!week.IsInWeek(block.StartDate)) continue;

                    int startRow = block.StartDate.Hour * 2 + block.StartDate.Minute / 30;
                    int endRow = block.EndDate.Hour * 2 + block.EndDate.Minute / 30;

                    for (int i = startRow; i < endRow; i++)
                    {
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "Task " + task.TaskId;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // restrict selection
            dataGridView.ClearSelection();
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                e.AdvancedBorderStyle.Top = dataGridView.AdvancedCellBorderStyle.Top;
                return;
            }

            if (IsSameCellValue(e.ColumnIndex, e.RowIndex))
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            else
                e.AdvancedBorderStyle.Top = dataGridView.AdvancedCellBorderStyle.Top;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 1) return;

            if (IsSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private bool IsSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView[column, row];
            DataGridViewCell cell2 = dataGridView[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }

            return cell1.Value.Equals(cell2.Value);
        }

        void UpdateScheduleView()
        {
            CleanEditPanel();

            TimeBlockView.Clear();

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;

            if (_scheduleManager == null)
            {
                foreach (Schedule schedule in scheduleList)
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
            CleanEditPanel();

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
                foreach (Task task in taskList)
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

        void EditScheduleForm()
        {
            CleanEditPanel();

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
            scheduleSet[(int)scheduleList[TimeBlockView.FocusedItem.Index].Type]();

            schedulePanels[(int)focusedSchedule.Type].Visible = true;
        }

        void EditTaskForm()
        {
            CleanEditPanel();

            Action[] taskSet = new Action[2]
            {
                () => {
                    TaskNameTxt.Text = focusedTask.Name;

                    TaskDatePicker.Text = ((DateTime)focusedTask.EndDate).ToString("yyyy-MM-dd");
                    TaskStartDatePicker.Text = focusedTask.StartDate.ToString("yyyy-MM-dd");
                },
                () => {
                    ScheduleRNameTxt.Text = focusedSchedule.Name;
                    ScheduleRDay.Text = "월";
                    DayCheck.Checked = focusedSchedule.RegularTimeBlocks[0].DayOfWeek == DayOfWeek.Monday;
                    ScheduleRStartTime.Text = DayCheck.Checked ? focusedSchedule.RegularTimeBlocks[0].StartTime.ToString("HH:mm") : "";
                    ScheduleREndTime.Text = DayCheck.Checked ? focusedSchedule.RegularTimeBlocks[0].EndTime.ToString("HH:mm") : "";
                }
            };
            taskSet[(int)scheduleList[TimeBlockView.FocusedItem.Index].Type]();

            taskPanels[(int)focusedTask.Type].Visible = true;
        }

        void CleanEditPanel()
        {
            foreach (var panelTmp in schedulePanels)
            {
                panelTmp.Visible = false;
            }
            foreach (var panelTmp in taskPanels)
            {
                panelTmp.Visible = false;
            }
        }

        public DayOfWeek StringToDayOfWeek(string dayStr)
        {
            switch (dayStr)
            {
                case "월":
                    return DayOfWeek.Monday;

                case "화":
                    return DayOfWeek.Tuesday;

                case "수":
                    return DayOfWeek.Wednesday;

                case "목":
                    return DayOfWeek.Thursday;

                case "금":
                    return DayOfWeek.Friday;

                case "토":
                    return DayOfWeek.Saturday;

                case "일":
                    return DayOfWeek.Sunday;

                default:
                    return DayOfWeek.Saturday;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            //scheduleList = (List<Schedule>)_scheduleManager.GetAll();
            //taskList = (List<Task>)_taskManager.GetAll();

            StandardTime = DateTime.Now;
            StandardTime.AddDays(-(int)StandardTime.DayOfWeek);

            UpdateView = new Action[] { UpdateScheduleView, UpdateTaskView };

            CurrentTimeBlockInfo = new Action[] { EditScheduleForm, EditTaskForm };

            schedulePanels = new Panel[] { SingleSchedulePanel, RegularSchedulePanel };
            taskPanels = new Panel[] { ShortTaskPanel };

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

            scheduleList = new List<Schedule>
            {
                new Schedule(),
                new Schedule()
            };
            scheduleList[0].Id = 1;
            scheduleList[0].Name = "Test Schedule1";
            scheduleList[0].Type = EScheduleType.Singular;
            scheduleList[0].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 14, 18, 30, 0));

            scheduleList[1].Id = 2;
            scheduleList[1].Name = "Test Schedule2";
            scheduleList[1].Type = EScheduleType.Regular;
            scheduleList[1].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 25));
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
            scheduleList[1].RegularTimeBlocks = testSchedulTimeBlocks;

            taskList = new List<Task>
            {
                new Task(),
                new Task()
            };
            taskList[0].Id = 3;
            taskList[0].Name = "Test Task1";
            taskList[0].EndDate = new DateTime(2024, 5, 20);

            taskList[1].Id = 4;
            taskList[1].Name = "Test Task2";
            taskList[1].EndDate = new DateTime(2024, 5, 25);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeForm();

            InitializeRows();
            dataGridView.ClearSelection();

            TimeBlockView.View = View.Details;

            viewType = TimeTableType.Schedule;

            UpdateView[0]();

            TimeTableView();

            CleanEditPanel();
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
            TimeTableView();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            StandardTime = StandardTime.AddDays(7);
            TimeTableView();
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

        private void TimeBlockView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Action[] focusedSet = new Action[]
            {
                () =>
                {
                    focusedTask = null;
                    focusedSchedule = TimeBlockView.FocusedItem != null ? scheduleList[TimeBlockView.FocusedItem.Index] : null;
                },
                () =>
                {
                    focusedSchedule = null;
                    focusedTask = TimeBlockView.FocusedItem != null ? taskList[TimeBlockView.FocusedItem.Index] : null;
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
            if (focusedSchedule.Type == EScheduleType.Singular)
            {
                string[] startHM = ScheduleStartTime.Text.Split(':');
                string[] endHM = ScheduleEndTime.Text.Split(':');
                DateTime startTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(startHM[0]), int.Parse(startHM[1]), 0);
                DateTime endTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(endHM[0]), int.Parse(endHM[1]), 0);

                focusedSchedule.TimeBlock = new DateTimeBlock(startTmp, endTmp);
            }
            else
            {
                List<WeeklyDateTimeBlock> weeklyDateTimeBlock = new List<WeeklyDateTimeBlock>();

                DayOfWeek dayOfWeek = StringToDayOfWeek(ScheduleRDay.Text);

                foreach (var items in focusedSchedule.RegularTimeBlocks)
                {
                    if (items.DayOfWeek < dayOfWeek)
                    {
                        weeklyDateTimeBlock.Add(items);
                    }
                    else
                    {
                        WeeklyDateTimeBlock weeklyDateTimeBlockTmp = new WeeklyDateTimeBlock();
                        weeklyDateTimeBlockTmp.DayOfWeek = dayOfWeek;
                        string[] hm = ScheduleRStartTime.Text.Split(':');
                        weeklyDateTimeBlockTmp.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);
                        hm = ScheduleREndTime.Text.Split(':');
                        weeklyDateTimeBlockTmp.EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);

                        weeklyDateTimeBlock.Add(weeklyDateTimeBlockTmp);
                    }
                }

                focusedSchedule.RegularTimeBlocks = weeklyDateTimeBlock;
            }
        }

        private void ScheduleRDayCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DayOfWeek dayOfWeek = StringToDayOfWeek(ScheduleRDay.Text);

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

        private void TaskEditOk_Click(object sender, EventArgs e)
        {
            focusedTask.Name = TaskNameTxt.Text;

            string[] startHM = ScheduleStartTime.Text.Split(':');
            string[] endHM = ScheduleEndTime.Text.Split(':');
            DateTime startTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(startHM[0]), int.Parse(startHM[1]), 0);
            DateTime endTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(endHM[0]), int.Parse(endHM[1]), 0);

            focusedSchedule.TimeBlock = new DateTimeBlock(startTmp, endTmp);
        }
    }
}

