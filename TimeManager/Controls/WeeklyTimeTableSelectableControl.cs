﻿using System;
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
    public partial class WeeklyTimeTableSelectableControl : UserControl
    {
        private bool[,] _isSelectedCells = new bool[48, 7];
        private bool _isMouseDownInCell = false;

        public WeeklyTimeTableSelectableControl()
        {
            InitializeComponent();
        }

        private void WeeklyTimeTableControl_Load(object sender, EventArgs e)
        {
            InitializeRows();
            dataGridView.ClearSelection();
            CleanCells();
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
                    _isSelectedCells[i, j] = false;
                    dataGridView.Rows[i].Cells[j].Value = null;
                    dataGridView.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                }
            }
        }

        public IEnumerable<WeeklyDateTimeBlock> GetSelectedBlocks()
        {
            List<WeeklyDateTimeBlock> blocks = new List<WeeklyDateTimeBlock>();
            int nContinuousBlocks = 0;

            DateTime today = DateTime.Today;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 48+1; j++)
                {
                    if (j < 48 && _isSelectedCells[j, i])
                    {
                        nContinuousBlocks++;
                    }
                    else
                    {
                        if (nContinuousBlocks > 0)
                        {
                            DayOfWeek dayOfWeek = (DayOfWeek) ((i + 1) % 7);
                            DateTime start = today.AddMinutes((j - nContinuousBlocks) * 30);
                            DateTime end = today.AddMinutes(j * 30);

                            blocks.Add(new WeeklyDateTimeBlock(dayOfWeek, start, end));
                            nContinuousBlocks = 0;
                        }
                    }
                }
            }

            return blocks;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // restrict selection
            dataGridView.ClearSelection();
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_isMouseDownInCell)
                ToggleCell(e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _isMouseDownInCell = true;
            ToggleCell(e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            _isMouseDownInCell = false;
        }

        private void ToggleCell(int rowIndex, int columnIndex)
        {
            _isSelectedCells[rowIndex, columnIndex] = !_isSelectedCells[rowIndex, columnIndex];

            if (_isSelectedCells[rowIndex, columnIndex])
                dataGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Beige;
            else
                dataGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.LightGray;
        }
    }
}
