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
using TimeManager.Extensions;

namespace TimeManager.Controls
{
    public partial class WeeklyTimeTableControl : UserControl
    {
        [Description("본 컨트롤에 그려진 아이템(Schedule 혹은 Task)가 선택되었을 때 발생하는 이벤트입니다."), Category("아이템")]
        public event EventHandler<WeeklyTimeTableControlItemEventArgs> ItemSelected;

        private IScheduleManager _scheduleManager;
        private ITaskManager _taskManager;

        private Color _ScheduleBackColor = Color.LightBlue;
        private Color _TaskBackColor = Color.LightGreen;

        public WeeklyTimeTableControl()
        {
            InitializeComponent();
        }

        private void WeeklyTimeTableControl_Load(object sender, EventArgs e)
        {
            InitializeRows();
            dataGridView.ClearSelection();
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

        public void DrawCells(TimeTable timeTable, Week week)
        {
            CleanCells();
            DrawWorkTimes(timeTable, week);
            DrawSchedules(timeTable, week);
            DrawTasks(timeTable, week);
        }

        private void DrawWorkTimes(TimeTable timeTable, Week week)
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
        
        private void DrawSchedules(TimeTable timeTable, Week week)
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
                        string name = this._scheduleManager.GetById(schedule.ScheduleId).Name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "(S" + schedule.ScheduleId + ") " + name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = _ScheduleBackColor;
                    }
                }
            }
        }

        private void DrawTasks(TimeTable timeTable, Week week)
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
                        string name = this._taskManager.GetById(task.TaskId).Name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = "(T" + task.TaskId + ") " + name;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = _TaskBackColor;
                    }
                }
            }
        }

        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // if select one is schedule or task, raise event
            if (dataGridView.SelectedCells.Count == 1 && (dataGridView.SelectedCells[0].Style.BackColor == _ScheduleBackColor || dataGridView.SelectedCells[0].Style.BackColor == _TaskBackColor))
            {
                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                int columnIndex = dataGridView.SelectedCells[0].ColumnIndex;

                if (rowIndex < 1 || columnIndex < 0) return;

                string cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                EAssignedItemType assignedItemType = cellValue.Contains("(S") ? EAssignedItemType.Schedule : EAssignedItemType.Task;
                int assignedItemId = int.Parse(cellValue.Substring(2, cellValue.IndexOf(")") - 2));

                ItemSelected?.Invoke(this, new WeeklyTimeTableControlItemEventArgs { AssignedItemType = assignedItemType, AssignedItemId = assignedItemId });
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
    }
}
