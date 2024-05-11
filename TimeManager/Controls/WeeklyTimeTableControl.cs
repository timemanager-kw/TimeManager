using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Data.Model;
using TimeManager.Extensions;

namespace TimeManager.Controls
{
    public partial class WeeklyTimeTableControl : UserControl
    {
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
            DrawWorkTimes(timeTable);
            DrawSchedules(timeTable, week);
            DrawTasks(timeTable, week);
        }

        private void DrawWorkTimes(TimeTable timeTable)
        {
            foreach (DateTimeBlock block in timeTable.WorkTimes)
            {
                int startRow = block.StartDate.Hour * 2 + block.StartDate.Minute / 30;
                int endRow = block.EndDate.Hour * 2 + block.EndDate.Minute / 30;

                for (int i = startRow; i < endRow; i++)
                {
                    dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = Color.White;
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
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = schedule.ScheduleId;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = Color.LightBlue;
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
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Value = task.TaskId;
                        dataGridView.Rows[i].Cells[block.StartDate.GetDayOfWeekIndex()].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void MergeCellsVertical(PaintEventArgs e, int columnIndex, int rowIndexStart, int rowIndexEnd)
        {
            Rectangle rect = dataGridView.GetCellDisplayRectangle(columnIndex, rowIndexStart, false);
            int width = rect.Width;
            int height = rect.Height;

            rect.X -= 1;
            rect.Y -= 1;
            rect.Width = width;
            rect.Height = height * (rowIndexEnd - rowIndexStart);

            e.Graphics.FillRectangle(new SolidBrush(dataGridView.Rows[rowIndexStart].Cells[columnIndex].InheritedStyle.BackColor), rect);
            e.Graphics.DrawRectangle(new Pen(dataGridView.GridColor), rect);

        }

        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // restrict selection
            dataGridView.ClearSelection();
        }
    }
}
