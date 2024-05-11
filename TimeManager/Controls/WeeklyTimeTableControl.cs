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

namespace TimeManager.Controls
{
    public partial class WeeklyTimeTableControl : UserControl
    {
        private TimeTable _timeTable;
        private Week _week;

        public WeeklyTimeTableControl(TimeTable timeTable, Week week)
        {
            InitializeComponent();

            _timeTable = timeTable;
            _week = week;
        }

        private void WeeklyTimeTableControl_Load(object sender, EventArgs e)
        {
            InitializeRows();
        }

        public void InitializeRows()
        {
            for (int i = 0; i < 48; i++)
            {
                DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddMinutes(i * 30);

                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = dateTime.ToString("HH:mm");
            }
        }
    }
}
