using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        [Description("본 컨트롤에 그려진 아이템(Schedule 혹은 Task)가 선택되었을 때 발생하는 이벤트입니다."), Category("아이템")]
        public event EventHandler<WeeklyTimeTableControlItemEventArgs> ItemSelected;

        private TimeTableManager _timeTableManager;
        private ScheduleManager _scheduleManager;
        private TaskManager _taskManager;
        private TimeTable timeTable;
        private ThunderScheduler _scheduler;

        private ThunderSchedulerStrategy schedulerStrategy;

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

        Color noneSelectedColor, selectedColor;

        Dictionary<long, Color> assignedScheduleColor = new Dictionary<long, Color>();
        Dictionary<long, Color> assignedTaskColor = new Dictionary<long, Color>();

        AddScheduleForm AddScheduleForm;
        AddTaskForm AddTaskForm;
        EditAvailableTimeForm EditAvailableTimeForm;

        bool onEditForms;

        DayOfWeek focusedDayOfWeek = DayOfWeek.Monday;

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

            timeTable = _timeTableManager.Get();

            DrawCells(week);
            UpdateHeaderDate();
        }

        private void UpdateHeaderDate()
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridView.Columns[i].HeaderText = Week.From(StandardTime).GetDay(i).ToString("ddd (MM\"/\"dd)");
            }
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

                    Color assignColor;

                    if (!assignedScheduleColor.ContainsKey(schedule.ScheduleId))
                    {
                        Random random = new Random();
                        int g = random.Next(100, 256);
                        int r = random.Next(0, Math.Min(200, g));
                        int b = random.Next(0, Math.Min(200, g));
                        assignColor = Color.FromArgb(255, r, g, b);

                        for (bool isColorIn = true, pass = false; isColorIn && !pass;)
                        {
                            pass = true;

                            random = new Random();
                            g = random.Next(100, 256);
                            r = random.Next(0, Math.Min(200, g));
                            b = random.Next(0, Math.Min(200, g));
                            assignColor = Color.FromArgb(255, r, g, b);

                            foreach (Color v in assignedScheduleColor.Values)
                            {
                                if (v == assignColor)
                                {
                                    pass = false;
                                    isColorIn = true;
                                    break;
                                }
                            }
                        }
                        assignedScheduleColor.Add(schedule.ScheduleId, assignColor);
                    }
                    else
                    {
                        assignedScheduleColor.TryGetValue(schedule.ScheduleId, out assignColor);
                    }

                    for (int i = startRow; i < endRow; i++)
                    {
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "(S" + schedule.ScheduleId + ") " + _scheduleManager.GetById(schedule.ScheduleId).Name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = assignColor;
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

                    Color assignColor;

                    if (!assignedTaskColor.ContainsKey(task.TaskId))
                    {
                        Random random = new Random();
                        int r = random.Next(100, 256);
                        int g = random.Next(0, Math.Min(200, r));
                        int b = random.Next(0, Math.Min(200, r));
                        assignColor = Color.FromArgb(255, r, g, b);

                        for (bool isColorIn = true, pass = false; isColorIn && !pass;)
                        {
                            pass = true;

                            r = random.Next(100, 256);
                            g = random.Next(0, Math.Min(200, r));
                            b = random.Next(0, Math.Min(200, r));
                            assignColor = Color.FromArgb(255, r, g, b);

                            foreach (Color v in assignedTaskColor.Values)
                            {
                                if (v == assignColor)
                                {
                                    pass = false;
                                    isColorIn = true;
                                    break;
                                }
                            }
                        }
                        assignedTaskColor.Add(task.TaskId, assignColor);
                    }
                    else
                    {
                        assignedTaskColor.TryGetValue(task.TaskId, out assignColor);
                    }

                    for (int i = startRow; i < endRow; i++)
                    {
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "(T" + task.TaskId + ") " + _taskManager.GetById(task.TaskId).Name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = assignColor;
                    }
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // if select one is schedule or task, raise event
            if (dataGridView.SelectedCells.Count == 1 && dataGridView.SelectedCells[0].Style.BackColor != Color.White && dataGridView.SelectedCells[0].Style.BackColor != Color.LightGray)
            {
                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                int columnIndex = dataGridView.SelectedCells[0].ColumnIndex;

                if (rowIndex < 1 || columnIndex < 0) return;

                string cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                EAssignedItemType assignedItemType = cellValue.Contains("(S") ? EAssignedItemType.Schedule : EAssignedItemType.Task;
                int assignedItemId = int.Parse(cellValue.Substring(2, cellValue.IndexOf(")") - 2));

                int i;

                if (assignedItemType == EAssignedItemType.Schedule)
                {
                    viewType = TimeTableType.Schedule;

                    i = scheduleList.FindIndex(s => s.Id == assignedItemId);

                    UpdateView[(int)viewType]();

                    if (i != -1)
                    {
                        TimeBlockView.Items[i].Selected = true;
                        TimeBlockView.FocusedItem = TimeBlockView.Items[i];

                        focusedSchedule = scheduleList[i];

                        CurrentTimeBlockInfo[(int)viewType]();
                    }
                }
                else
                {
                    viewType = TimeTableType.Task;

                    i = taskList.FindIndex(s => s.Id == assignedItemId);

                    UpdateView[(int)viewType]();

                    if (i != -1)
                    {
                        TimeBlockView.Items[i].Selected = true;
                        TimeBlockView.FocusedItem = TimeBlockView.Items[i];

                        focusedTask = taskList[i];

                        CurrentTimeBlockInfo[(int)viewType]();
                    }
                }
            }

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

        private void MoveScrollToNow()
        {
            int nowRow = DateTime.Now.Hour * 2 + DateTime.Now.Minute / 30;
            dataGridView.FirstDisplayedScrollingRowIndex = nowRow;
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
            focusedDayOfWeek = DayOfWeek.Monday;
            TimeTableView();
            ScheduleBtn.BackColor = selectedColor;
            TaskBtn.BackColor = noneSelectedColor;

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

            scheduleList = _scheduleManager.GetAll().ToList();
            List<Schedule> removeSchedules = new List<Schedule>();
            if (scheduleList.Count > 0)
            {
                LogTxt.Text = "메모장\r\n";

                foreach (Schedule schedule in scheduleList)
                {
                    if (schedule.Type == EScheduleType.Singular && schedule.TimeBlock.EndDate.CompareTo(DateTime.Now) <= 0)
                    {
                        removeSchedules.Add(schedule);
                        continue;
                    }
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

                foreach(Schedule remove in removeSchedules)
                {
                    scheduleList.Remove(remove);
                }
            }
            else
            {
                LogTxt.Text = "일정이 없습니다";
            }
        }

        void UpdateTaskView()
        {
            focusedDayOfWeek = DayOfWeek.Monday;
            TimeTableView();
            ScheduleBtn.BackColor = noneSelectedColor;
            TaskBtn.BackColor = selectedColor;

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

            taskList = _taskManager.GetAll().ToList();
            List<Task> removeTasks = new List<Task>();

            if (taskList.Count > 0)
            {
                LogTxt.Text = $"메모장\r\n남은 업무: {taskList.Count}";

                foreach (Task task in taskList)
                {
                    var lvItem = new ListViewItem(new string[2]);

                    lvItem.SubItems[0].Text = task.Name;
                    if (task.Type == ETaskType.ShortTerm)
                    {
                        if (task.EndDate.Value.CompareTo(DateTime.Now) <= 0)
                        {
                            removeTasks.Add(task);
                            continue;
                        }
                        lvItem.SubItems[1].Text = ((DateTime)task.EndDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        string days = string.Empty;
                        foreach (var dayOfWeek in task.WeeklyTimesWanted)
                        {
                            days += $"{DayOfWeekToString(dayOfWeek.dayOfWeek)} | ";
                        }
                        days = days.Remove(days.Length - 3);
                        lvItem.SubItems[1].Text = days;
                    }

                    TimeBlockView.Items.Add(lvItem);
                }

                foreach (Task remove in removeTasks)
                {
                    taskList.Remove(remove);
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
                    ScheduleStartTime.Text = $"{(focusedSchedule.TimeBlock.StartDate.Hour < 10 ? $"0{focusedSchedule.TimeBlock.StartDate.Hour}" : $"{focusedSchedule.TimeBlock.StartDate.Hour}")}:{(focusedSchedule.TimeBlock.StartDate.Minute == 0 ? "00" : "30")}";
                    ScheduleEndTime.Text = $"{(focusedSchedule.TimeBlock.EndDate.Hour < 10 ? $"0{focusedSchedule.TimeBlock.EndDate.Hour}" : $"{focusedSchedule.TimeBlock.EndDate.Hour}")}:{(focusedSchedule.TimeBlock.EndDate.Minute == 0 ? "00" : "30")}";
                },
                () => {
                    ScheduleRNameTxt.Text = focusedSchedule.Name;
                    ScheduleRDay.Text = "월";

                    bool checkTmp = false;
                    string timeTmp1 = "00:00", timeTmp2 = "00:00";

                    foreach (WeeklyDateTimeBlock timeBlock in focusedSchedule.RegularTimeBlocks)
                    {
                        if (timeBlock.DayOfWeek == DayOfWeek.Monday)
                        {
                            checkTmp = true;

                            timeTmp1 = $"{(timeBlock.StartTime.Hour < 10 ? $"0{timeBlock.StartTime.Hour}" : $"{timeBlock.StartTime.Hour}")}:{(timeBlock.StartTime.Minute == 0 ? "00" : "30")}";
                            timeTmp2 = $"{(timeBlock.EndTime.Hour < 10 ? $"0{timeBlock.EndTime.Hour}" : $"{timeBlock.EndTime.Hour}")}:{(timeBlock.EndTime.Minute == 0 ? "00" : "30")}";
                            break;
                        }
                    }

                    DayCheck.Checked = checkTmp;
                    ScheduleRStartTime.Text = timeTmp1;
                    ScheduleREndTime.Text = timeTmp2;
                }
            };
            LogTxt.Text = focusedSchedule.Description;
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

                    TaskEndDatePicker.Text = focusedTask.EndDate.Value.ToString("yyyy-MM-dd");
                    TaskStartDatePicker.Text = focusedTask.StartDate.ToString("yyyy-MM-dd");

                    int totMin = (int)focusedTask.Duration.Value.TotalMinutes;
                    TaskDurationCmb.Text = $"{(totMin / 60 < 10 ? $"0{totMin / 60}" : $"{totMin / 60}")}:{(totMin % 60 == 0 ? "00" : "30")}";
                },
                () => {
                    TaskLName.Text = focusedTask.Name;
                    TaskLDay.Text = "월";

                    bool checkTmp = false;
                    string timeTmp = "00:00";

                    foreach (longTermProperties longTerm in focusedTask.WeeklyTimesWanted)
                    {
                        if (longTerm.dayOfWeek == DayOfWeek.Monday)
                        {
                            checkTmp = true;
                            timeTmp = $"{((int)(longTerm.time.TotalMinutes / 60) < 10 ? $"0{(int)(longTerm.time.TotalMinutes / 60)}" : $"{(int)(longTerm.time.TotalMinutes / 60)}")}:{((int)(longTerm.time.TotalMinutes % 60) == 0 ? "00" : "30")}";
                            break;
                        }
                    }

                    TaskLDayCheck.Checked = checkTmp;
                    TaskLTime.Text = timeTmp;
                }
            };
            LogTxt.Text = focusedTask.Description;
            taskSet[(int)taskList[TimeBlockView.FocusedItem.Index].Type]();

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

        public MainForm(TimeTableManager timeTableManager, ScheduleManager scheduleManager, TaskManager taskManager)
        {
            InitializeComponent();

            _timeTableManager = timeTableManager;
            _scheduleManager = scheduleManager;
            _taskManager = taskManager;

            schedulerStrategy = new ThunderSchedulerStrategy();
            _scheduler = new ThunderScheduler(schedulerStrategy, _timeTableManager, _scheduleManager, _taskManager);

            selectedColor = ScheduleBtn.BackColor;
            noneSelectedColor = TaskBtn.BackColor;

            StandardTime = DateTime.Now;
            StandardTime.AddDays(-(int)StandardTime.DayOfWeek);

            UpdateView = new Action[] { UpdateScheduleView, UpdateTaskView };

            CurrentTimeBlockInfo = new Action[] { EditScheduleForm, EditTaskForm };

            schedulePanels = new Panel[] { SingleSchedulePanel, RegularSchedulePanel };
            taskPanels = new Panel[] { ShortTaskPanel, LongTaskPanel };

            for (int i = 0; i < 24; i++)
            {
                ScheduleStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                ScheduleStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");
                ScheduleRStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                ScheduleRStartTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");

                ScheduleEndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                ScheduleEndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");
                ScheduleREndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                ScheduleREndTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");

                TaskLTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:00");
                TaskLTime.Items.Add($"{(i < 10 ? $"0{i}" : i.ToString())}:30");
            }

            for (int i = 30; i < 6000; i += 30)
            {
                TaskDurationCmb.Items.Add($"{(i / 60 < 10 ? $"0{i / 60}" : (i / 60).ToString())}:{(i % 60 == 0 ? "00" : "30")}");
            }

            ScheduleRDay.Text = "월";
            TaskLDay.Text = "월";

            scheduleList = _scheduleManager.GetAll().ToList();

            taskList = _taskManager.GetAll().ToList();

            timeTable = _timeTableManager.Get();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeForm();

            InitializeRows();
            MoveScrollToNow();
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
            _scheduler.Run(Week.From(StandardTime).GetDay(6));
            TimeTableView();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (viewType == TimeTableType.Schedule)
            {
                AddScheduleForm = new AddScheduleForm(this);
                AddScheduleForm.Show();
            }
            else
            {
                AddTaskForm = new AddTaskForm(this);
                AddTaskForm.Show();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (UpdateView == null) return;
            ResizeForm();

            UpdateView[(int)viewType]();
        }

        private void TimeBlockView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Action[] focusedSet = new Action[]
            {
                () =>
                {
                    focusedSchedule = TimeBlockView.FocusedItem != null ? scheduleList[TimeBlockView.FocusedItem.Index] : null;
                    focusedTask = null;
                },
                () =>
                {
                    focusedSchedule = null;
                    focusedTask = TimeBlockView.FocusedItem != null ? taskList[TimeBlockView.FocusedItem.Index] : null;
                }
            };

            focusedSet[(int)viewType]();
            if (focusedSchedule != null || focusedTask != null)
            {
                CurrentTimeBlockInfo[(int)viewType]();
            }
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
                timeTable.ReassignSchedule(focusedSchedule.Id, new List<DateTimeBlock>() { new DateTimeBlock(focusedSchedule.TimeBlock.StartDate, focusedSchedule.TimeBlock.EndDate) });
                _timeTableManager.Save(timeTable);
                _scheduler.AssignSchdules(Week.From(StandardTime).GetDay(6));
            }
            else
            {
                focusedSchedule.Name = ScheduleRNameTxt.Text;

                foreach (var items in focusedSchedule.RegularTimeBlocks)
                {
                    if (items.StartTime >= items.EndTime)
                    {
                        MessageBox.Show("시작 시간이 종료 시간 뒤에 올 수 없습니다.");
                        return;
                    }
                }
                List<DateTimeBlock> dateTimeBlocksTmp = new List<DateTimeBlock>();
                foreach(WeeklyDateTimeBlock d in focusedSchedule.RegularTimeBlocks)
                {
                    dateTimeBlocksTmp.Add(new DateTimeBlock(d.StartTime, d.EndTime));
                }
                timeTable.ReassignSchedule(focusedSchedule.Id, dateTimeBlocksTmp);
                _timeTableManager.Save(timeTable);
                _scheduler.AssignSchdules(Week.From(StandardTime).GetDay(6));
            }
            focusedSchedule.Description = LogTxt.Text;

            _scheduleManager.Update(focusedSchedule);
            UpdateView[(int)viewType]();
        }

        private void TaskEditOk_Click(object sender, EventArgs e)
        {
            if (focusedTask.Type == ETaskType.ShortTerm)
            {
                focusedTask.Name = TaskNameTxt.Text;

                focusedTask.StartDate = TaskStartDatePicker.Value;
                focusedTask.EndDate = TaskEndDatePicker.Value;

                focusedTask.Duration = new TimeSpan(0, int.Parse(TaskDurationCmb.Text.Split(':')[0]) * 60 + int.Parse(TaskDurationCmb.Text.Split(':')[1]), 0);
                focusedTask.FocusDays = (int)(TaskEndDatePicker.Value - TaskStartDatePicker.Value).TotalDays + 1;
            }
            else
            {
                focusedTask.Name = TaskLName.Text;
            }
            focusedTask.Description = LogTxt.Text;

            _taskManager.Update(focusedTask);
            UpdateView[(int)viewType]();
        }

        public void CloseAddSchedule(bool isAdd, Schedule schedule)
        {
            if (isAdd)
            {
                _scheduleManager.Add(schedule);

                if (schedule.Type == EScheduleType.Singular)
                {
                    timeTable.AssignSchedule(schedule.Id, new List<DateTimeBlock>() { schedule.TimeBlock });
                    _timeTableManager.Save(timeTable);
                    _scheduler.AssignSchdules(Week.From(StandardTime).GetDay(6));
                }
                else
                {
                    List<DateTimeBlock> dateTimeBlocksTmp = new List<DateTimeBlock>();
                    foreach (WeeklyDateTimeBlock d in schedule.RegularTimeBlocks)
                    {
                        dateTimeBlocksTmp.Add(new DateTimeBlock(d.StartTime, d.EndTime));
                    }
                    timeTable.AssignSchedule(schedule.Id, dateTimeBlocksTmp);
                    _timeTableManager.Save(timeTable);
                    _scheduler.AssignSchdules(Week.From(StandardTime).GetDay(6));
                }
            }

            AddScheduleForm = null;
            UpdateScheduleView();
        }

        private void openEditAvailableBtn_Click(object sender, EventArgs e)
        {
            EditAvailableTimeForm = new EditAvailableTimeForm(this, timeTable, Week.From(StandardTime));
            EditAvailableTimeForm.Show();
        }

        public void CloseAddTask(bool isAdd, Task task)
        {
            if (isAdd)
            {
                _taskManager.Add(task);
            }
            AddTaskForm = null;
            UpdateTaskView();
        }

        private void TaskLDayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (focusedTask == null || onEditForms || !TaskLDayCheck.Visible) return;
            try
            {
                bool modified = false;
                List<longTermProperties> taskTmp = new List<longTermProperties>();

                for (int i = 0; i < focusedTask.WeeklyTimesWanted.Count; i++)
                {
                    if (TaskLDayCheck.Checked)
                    {
                        TaskLTime.Enabled = true;
                        if (focusedTask.WeeklyTimesWanted[i].dayOfWeek <= focusedDayOfWeek)
                        {
                            taskTmp.Add(focusedTask.WeeklyTimesWanted[i]);
                        }
                        else
                        {
                            taskTmp.Add(new longTermProperties(focusedDayOfWeek, new TimeSpan()));
                            modified = true;
                        }
                    }
                    else
                    {
                        if (focusedTask.WeeklyTimesWanted[i].dayOfWeek != focusedDayOfWeek)
                        {
                            taskTmp.Add(focusedTask.WeeklyTimesWanted[i]);
                        }
                    }
                }
                if (!modified && TaskLDayCheck.Checked)
                {
                    TaskLTime.Enabled = true;
                    taskTmp.Add(new longTermProperties(focusedDayOfWeek, new TimeSpan()));
                }

                focusedTask.WeeklyTimesWanted = taskTmp;

                TaskLDay_SelectedValueChanged(null, null);
            }
            catch (Exception E) { string x = E.Message; }
        }

        private void DayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (focusedSchedule == null || onEditForms || !DayCheck.Visible) return;
            try
            {
                bool modified = false;
                List<WeeklyDateTimeBlock> weeklyTmp = new List<WeeklyDateTimeBlock>();

                for (int i = 0; i < focusedSchedule.RegularTimeBlocks.Count; i++)
                {
                    if (DayCheck.Checked)
                    {
                        ScheduleRStartTime.Enabled = true;
                        ScheduleREndTime.Enabled = true;
                        if (focusedSchedule.RegularTimeBlocks[i].DayOfWeek <= focusedDayOfWeek)
                        {
                            weeklyTmp.Add(focusedSchedule.RegularTimeBlocks[i]);
                        }
                        else
                        {
                            weeklyTmp.Add(new WeeklyDateTimeBlock(focusedDayOfWeek, new DateTime(), new DateTime()));
                            modified = true;
                        }
                    }
                    else
                    {
                        if (focusedSchedule.RegularTimeBlocks[i].DayOfWeek != focusedDayOfWeek)
                        {
                            weeklyTmp.Add(focusedSchedule.RegularTimeBlocks[i]);
                        }
                    }
                }

                if (!modified && DayCheck.Checked)
                {
                    ScheduleRStartTime.Enabled = true;
                    ScheduleREndTime.Enabled = true;
                    weeklyTmp.Add(new WeeklyDateTimeBlock(focusedDayOfWeek, new DateTime(), new DateTime()));
                }

                focusedSchedule.RegularTimeBlocks = weeklyTmp;

                ScheduleRDay_SelectedValueChanged(null, null);
            }
            catch (Exception E) { string x = E.Message; }
        }

        private void TaskLDay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (focusedTask == null || focusedDayOfWeek == StringToDayOfWeek(TaskLDay.Text)) return;
            focusedDayOfWeek = StringToDayOfWeek(TaskLDay.Text);
            onEditForms = true;
            try
            {
                TaskLDayCheck.Checked = false;
                TaskLTime.Enabled = false;
                TaskLTime.Text = "00:00";

                foreach (longTermProperties longTerm in focusedTask.WeeklyTimesWanted)
                {
                    if (longTerm.dayOfWeek == focusedDayOfWeek)
                    {
                        TaskLDayCheck.Checked = true;
                        TaskLTime.Text = $"{(int)(longTerm.time.TotalMinutes / 60)}:{(int)(longTerm.time.TotalMinutes % 60)}";
                        TaskLTime.Enabled = true;

                        break;
                    }
                }
            }
            catch (Exception E) { string x = E.Message; }
            onEditForms = false;
        }

        private void TaskLTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (focusedTask == null || onEditForms || !TaskLDayCheck.Visible) return;
            try
            {
                for (int i = 0; i < focusedTask.WeeklyTimesWanted.Count; i++)
                {
                    if (focusedTask.WeeklyTimesWanted[i].dayOfWeek == focusedDayOfWeek)
                    {
                        focusedTask.WeeklyTimesWanted[i] = new longTermProperties(focusedDayOfWeek, new TimeSpan(0, int.Parse(TaskLTime.Text.Split(':')[0]) * 60 + int.Parse(TaskLTime.Text.Split(':')[1]), 0));
                    }
                }
            }
            catch (Exception E) { string x = E.Message; }
        }

        private void ScheduleRDay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (focusedSchedule == null || focusedDayOfWeek == StringToDayOfWeek(ScheduleRDay.Text)) return;
            focusedDayOfWeek = StringToDayOfWeek(ScheduleRDay.Text);
            onEditForms = true;
            try
            {
                DayCheck.Checked = false;
                ScheduleRStartTime.Enabled = false;
                ScheduleREndTime.Enabled = false;
                ScheduleRStartTime.Text = "00:00";
                ScheduleREndTime.Text = "00:00";

                foreach (var dayList in focusedSchedule.RegularTimeBlocks)
                {
                    if (dayList.DayOfWeek == focusedDayOfWeek)
                    {
                        DayCheck.Checked = true;
                        ScheduleRStartTime.Text = dayList.StartTime.ToString("HH:mm");
                        ScheduleREndTime.Text = dayList.EndTime.ToString("HH:mm");
                        ScheduleRStartTime.Enabled = true;
                        ScheduleREndTime.Enabled = true;

                        break;
                    }
                }
            }
            catch (Exception E) { string x = E.Message; }

            onEditForms = false;
        }

        private void ScheduleRStartTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (focusedSchedule == null || onEditForms || !DayCheck.Visible) return;
            try
            {
                DayOfWeek dayTmp = StringToDayOfWeek(ScheduleRDay.Text);
                for (int i = 0; i < focusedSchedule.RegularTimeBlocks.Count; i++)
                {
                    if (focusedSchedule.RegularTimeBlocks[i].DayOfWeek == dayTmp)
                    {
                        string[] hm = ScheduleRStartTime.Text.Split(':');
                        DateTime dateStartTimeTmp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);

                        focusedSchedule.RegularTimeBlocks[i] = new WeeklyDateTimeBlock(dayTmp, dateStartTimeTmp, focusedSchedule.RegularTimeBlocks[i].EndTime);
                    }
                }
            }
            catch (Exception E) { string x = E.Message; }
        }

        private void ScheduleREndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (focusedSchedule == null || onEditForms || !DayCheck.Visible) return;
            try
            {
                DayOfWeek dayTmp = StringToDayOfWeek(ScheduleRDay.Text);
                for (int i = 0; i < focusedSchedule.RegularTimeBlocks.Count; i++)
                {
                    if (focusedSchedule.RegularTimeBlocks[i].DayOfWeek == dayTmp)
                    {
                        string[] hm = ScheduleREndTime.Text.Split(':');
                        DateTime dateEndTimeTmp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hm[0]), int.Parse(hm[1]), 0);

                        focusedSchedule.RegularTimeBlocks[i] = new WeeklyDateTimeBlock(dayTmp, focusedSchedule.RegularTimeBlocks[i].StartTime, dateEndTimeTmp);
                    }
                }
            }
            catch (Exception E) { string x = E.Message; }
        }

        private void ScheduleSRemoveBtn_Click(object sender, EventArgs e)
        {
            assignedScheduleColor.Remove(focusedSchedule.Id);
            List<AssignedSchedule> assignedSchedules = timeTable.GetAllAssignedSchedules();

            if (assignedSchedules.Count > 0)
            {
                if (assignedSchedules.FindIndex(s => s.ScheduleId == focusedSchedule.Id) != -1)
                {
                    timeTable.UnassignSchedule(focusedSchedule.Id);
                    _timeTableManager.Save(timeTable);
                }
                _scheduleManager.Delete(focusedSchedule);
            }

            focusedSchedule = null;
            UpdateView[(int)viewType]();
        }

        private void ScheduleRRemoveBtn_Click(object sender, EventArgs e)
        {
            assignedScheduleColor.Remove(focusedSchedule.Id);
            List<AssignedSchedule> assignedSchedules = timeTable.GetAllAssignedSchedules();

            if (assignedSchedules.Count > 0)
            {
                if (assignedSchedules.FindIndex(s => s.ScheduleId == focusedSchedule.Id) != -1)
                {
                    timeTable.UnassignSchedule(focusedSchedule.Id);
                    _timeTableManager.Save(timeTable);
                }
                _scheduleManager.Delete(focusedSchedule);
            }

            focusedSchedule = null;
            UpdateView[(int)viewType]();
        }

        private void TaskSRemoveBtn_Click(object sender, EventArgs e)
        {
            assignedTaskColor.Remove(focusedTask.Id);
            List<AssignedTask> assignedTasks = timeTable.GetAllAssignedTasks();

            if (assignedTasks.Count > 0)
            {
                if (assignedTasks.FindIndex(t => t.TaskId == focusedTask.Id) != -1)
                {
                    timeTable.UnassignTask(focusedTask.Id);
                    _timeTableManager.Save(timeTable);
                }
                _taskManager.Delete(focusedTask);
            }

            focusedTask = null;
            UpdateView[(int)viewType]();
        }

        private void TaskLRemoveBtn_Click(object sender, EventArgs e)
        {
            assignedTaskColor.Remove(focusedTask.Id);
            List<AssignedTask> assignedTasks = timeTable.GetAllAssignedTasks();

            if (assignedTasks.Count > 0)
            {
                if (assignedTasks.FindIndex(t => t.TaskId == focusedTask.Id) != -1)
                {
                    timeTable.UnassignTask(focusedTask.Id);
                    _timeTableManager.Save(timeTable);
                }
                _taskManager.Delete(focusedTask);
            }

            focusedTask = null;
            UpdateView[(int)viewType]();
        }

        public void CloseAvailableTime(TimeTable updateBlock)
        {
            timeTable = updateBlock;
            _timeTableManager.Save(timeTable);
            TimeTableView();
        }
    }
}

