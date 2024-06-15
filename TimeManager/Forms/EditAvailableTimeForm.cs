using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManager.Forms
{
    public partial class EditAvailableTimeForm : Form
    {
        public EditAvailableTimeForm()
        {
            InitializeComponent();
        }

        private void selectedTimes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                string.Join("\n", weeklyTimeTableSelectableControl1
                .GetSelectedBlocks()
                .Select(block =>
                    block.DayOfWeek.ToString()
                    + ": "
                    + block.StartTime.ToString("HH:mm")
                    + " ~ "
                    + block.EndTime.ToString("HH:mm")
                )
            ));
        }
    }
}
