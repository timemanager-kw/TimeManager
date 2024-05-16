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

        public void TimeBlockViewForm(TimeTableManager timeTableManager, ScheduleManager scheduleManager, TaskManager taskManager)
        {
            this._timeTableManager = timeTableManager;
            this._scheduleManager = scheduleManager;
            this._taskManager = taskManager;
        }

        void ResizeForm()
        {
            MainPanel.Size = new Size(this.Size.Width * 37 / 48, this.Size.Height);
            TitlePanel.Size = new Size(MainPanel.Size.Width, this.Size.Height * 2 / 27);
            PrevBtn.Size = new Size(PrevBtn.Size.Height * 7 / 6, TitlePanel.Size.Height * 3 / 4);
            WeekLabel.Size = new Size(WeekLabel.Size.Height * 13 / 3, TitlePanel.Size.Height * 3 / 4);
            NextBtn.Size = new Size(NextBtn.Size.Height * 7 / 6, TitlePanel.Size.Height * 3 / 4);
            AlgorithmStarter.Size = new Size(AlgorithmStarter.Size.Height, TitlePanel.Size.Height * 3 / 4);

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


            ScheduleBtn.Font = new Font(ScheduleBtn.Font.FontFamily, Mathf.Clampf(ScheduleBtn.Size.Height * 11 / 35, 7, 9));
            TaskBtn.Font = new Font(TaskBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            AddBtn.Font = new Font(AddBtn.Font.FontFamily, ScheduleBtn.Font.Size);
            TimeBlockView.Font = new Font(TimeBlockView.Font.FontFamily, ScheduleBtn.Font.Size + 1);

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

        string ViewOffset()
        {
            string offset = "";
            int offsetTmp = Mathf.Clamp((int)Math.Pow(1.2f, TimeBlockView.Width / 20), 0, 23);
            for (int i = 0; i < offsetTmp; i++) offset += " ";
            return offset;
        }

        void UpdateScheduleView()
        {
            CleanEditPanel();

            TimeBlockView.Clear();

            TimeBlockView.Columns.Add("Name", "일정" + ViewOffset());
            TimeBlockView.Columns.Add("Date", "날짜(요일)" + ViewOffset());
            TimeBlockView.Columns.Add("last", "last");

            int colWidth = TextRenderer.MeasureText(TimeBlockView.Columns[0].Text, TimeBlockView.Font).Width + 10;
            if (colWidth > TimeBlockView.Columns[0].Width) TimeBlockView.Columns[0].Width = colWidth;
            colWidth = TextRenderer.MeasureText(TimeBlockView.Columns[1].Text, TimeBlockView.Font).Width + 10;
            if (colWidth > TimeBlockView.Columns[1].Width) TimeBlockView.Columns[1].Width = colWidth;

            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;

            if (_scheduleManager == null)
            {
                foreach (Schedule schedule in scheduleList)
                {
                    var lvItem = new ListViewItem(new string[TimeBlockView.Columns.Count]);

                    lvItem.SubItems[0].Text = schedule.Name;
                    if (schedule.Type == EScheduleType.Singular) lvItem.SubItems[1].Text = schedule.TimeBlock.EndDate.ToString("yyyy-MM-dd");
                    else
                    {
                        string days = string.Empty;
                        foreach (var dayOfWeek in schedule.RegularTimeBlocks)
                        {
                            days += $"{DayOfWeekToString(dayOfWeek.DayOfWeek)} | ";
                        }
                        days = days.Remove(days.Length - 3);
                        lvItem.SubItems[1].Text = days;
                    }

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
                    if (schedule.Type == EScheduleType.Singular) lvItem.SubItems[1].Text = schedule.TimeBlock.EndDate.ToString("yyyy-MM-dd");
                    else
                    {
                        string days = string.Empty;
                        foreach (var dayOfWeek in schedule.RegularTimeBlocks)
                        {
                            days += $"{DayOfWeekToString(dayOfWeek.DayOfWeek)} | ";
                        }
                        days = days.Remove(days.Length - 3);
                        lvItem.SubItems[1].Text = days;
                    }

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

            TimeBlockView.Columns.Add("Name", "업무" + ViewOffset());
            TimeBlockView.Columns.Add("Date", "마감일" + ViewOffset());
            TimeBlockView.Columns.Add("last", "last");

            int colWidth = TextRenderer.MeasureText(TimeBlockView.Columns[0].Text, TimeBlockView.Font).Width + 10;
            if (colWidth > TimeBlockView.Columns[0].Width) TimeBlockView.Columns[0].Width = colWidth;
            colWidth = TextRenderer.MeasureText(TimeBlockView.Columns[1].Text, TimeBlockView.Font).Width + 10;
            if (colWidth > TimeBlockView.Columns[1].Width) TimeBlockView.Columns[1].Width = colWidth;

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
                        lvItem.SubItems[1].Text = ((DateTime)task.EndDate).ToString("yyyy-MM-dd");

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

                    TaskEndDatePicker.Text = ((DateTime)focusedTask.EndDate).ToString("yyyy-MM-dd");
                    TaskStartDatePicker.Text = focusedTask.StartDate.ToString("yyyy-MM-dd");

                    int totMin = (int)((TimeSpan)focusedTask.Duration).TotalMinutes;
                    TaskDurationCmb.Text = $"{totMin / 60}:{totMin % 60}";

                    WithEndDateCheck.Checked = (int)((TimeSpan)(focusedTask.EndDate - focusedTask.StartDate)).TotalDays != focusedTask.FocusDays;
                },
                () => {
                    TaskNameTxt.Text = focusedTask.Name;

                    TaskEndDatePicker.Text = ((DateTime)focusedTask.EndDate).ToString("yyyy-MM-dd");
                    TaskStartDatePicker.Text = focusedTask.StartDate.ToString("yyyy-MM-dd");
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
                    return DayOfWeek.Monday;
            }
        }

        public char DayOfWeekToString(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return '월';

                case DayOfWeek.Tuesday:
                    return '화';

                case DayOfWeek.Wednesday:
                    return '수';

                case DayOfWeek.Thursday:
                    return '목';

                case DayOfWeek.Friday:
                    return '금';

                case DayOfWeek.Saturday:
                    return '토';

                case DayOfWeek.Sunday:
                    return '일';

                default:
                    return '월';
            }
        }

        public MainForm()
        {
            InitializeComponent();

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

            for (int i = 30; i < 6000; i += 30)
            {
                TaskDurationCmb.Items.Add($"{i / 60}:{i % 60}");
            }

            scheduleList = new List<Schedule>
            {
                new Schedule(),
                new Schedule(),
                new Schedule()
            };
            scheduleList[0].Id = 1;
            scheduleList[0].Name = "Test Schedule1";
            scheduleList[0].Type = EScheduleType.Singular;
            scheduleList[0].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 18, 18, 30, 0));

            scheduleList[1].Id = 2;
            scheduleList[1].Name = "Test Schedule2";
            scheduleList[1].Type = EScheduleType.Singular;
            scheduleList[1].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 18, 20, 30, 0));

            scheduleList[2].Id = 3;
            scheduleList[2].Name = "Test Schedule3";
            scheduleList[2].Type = EScheduleType.Regular;
            scheduleList[2].TimeBlock = new DateTimeBlock(DateTime.Now, new DateTime(2024, 5, 25));
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
            scheduleList[2].RegularTimeBlocks = testSchedulTimeBlocks;

            taskList = new List<Task>
            {
                new Task(),
                new Task(),
                new Task()
            };
            taskList[0].Id = 4;
            taskList[0].Name = "Test Task1";
            taskList[0].Type = ETaskType.ShortTerm;
            taskList[0].StartDate = new DateTime(2024, 5, 17);
            taskList[0].EndDate = new DateTime(2024, 5, 20);
            taskList[0].Duration = new TimeSpan(10, 30, 0);
            taskList[0].FocusDays = 3;

            taskList[1].Id = 5;
            taskList[1].Name = "Test Task2";
            taskList[1].Type = ETaskType.ShortTerm;
            taskList[1].StartDate = new DateTime(2024, 5, 19);
            taskList[1].EndDate = new DateTime(2024, 5, 22);
            taskList[1].Duration = new TimeSpan(10, 30, 0);
            taskList[1].FocusDays = 4;

            taskList[2].Id = 6;
            taskList[2].Name = "Test Task3";
            taskList[2].Type = ETaskType.LongTerm;
            taskList[2].StartDate = new DateTime(2024, 5, 20);
            taskList[2].EndDate = new DateTime(2024, 5, 25);


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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeForm();

            InitializeRows();
            dataGridView.ClearSelection();

            TimeBlockView.View = View.Details;

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

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
            if (UpdateView == null) return;
            ResizeForm();

            UpdateView[(int)viewType]();
        }

        private void TimeBlockView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            focusedSchedule = null;
            focusedTask = null;

            Action[] focusedSet = new Action[]
            {
                () =>
                {
                    focusedSchedule = TimeBlockView.FocusedItem != null ? scheduleList[TimeBlockView.FocusedItem.Index] : null;
                },
                () =>
                {
                    focusedTask = TimeBlockView.FocusedItem != null ? taskList[TimeBlockView.FocusedItem.Index] : null;
                }
            };

            focusedSet[(int)viewType]();
            if (focusedSchedule != null || focusedTask != null) CurrentTimeBlockInfo[(int)viewType]();
        }

        private void EditCancle_Click(object sender, EventArgs e)
        {
            CleanEditPanel();
        }

        private void ScheduleEditOk_Click(object sender, EventArgs e)
        {
            if (focusedSchedule.Type == EScheduleType.Singular)
            {
                focusedSchedule.Name = ScheduleNameTxt.Text;

                string[] startHM = ScheduleStartTime.Text.Split(':');
                string[] endHM = ScheduleEndTime.Text.Split(':');
                DateTime startTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(startHM[0]), int.Parse(startHM[1]), 0);
                DateTime endTmp = new DateTime(ScheduleDatePicker.Value.Year, ScheduleDatePicker.Value.Month, ScheduleDatePicker.Value.Day, int.Parse(endHM[0]), int.Parse(endHM[1]), 0);

                focusedSchedule.TimeBlock = new DateTimeBlock(startTmp, endTmp);
            }
            else
            {
                focusedSchedule.Name = ScheduleRNameTxt.Text;

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

            UpdateView[(int)viewType]();
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
            if (focusedTask.Type == ETaskType.ShortTerm)
            {
                focusedTask.Name = TaskNameTxt.Text;

                focusedTask.StartDate = TaskStartDatePicker.Value;
                focusedTask.EndDate = TaskEndDatePicker.Value;

                focusedTask.FocusDays = (int)((TimeSpan)(focusedTask.EndDate - focusedTask.StartDate)).TotalDays + (WithEndDateCheck.Checked ? 1 : 0);
                string[] hm = TaskDurationCmb.Text.Split(':');
                focusedTask.Duration = new TimeSpan(int.Parse(hm[0]), int.Parse(hm[1]), 0);
            }
            else
            {

            }

            UpdateView[(int)viewType]();
        }
    }
}

