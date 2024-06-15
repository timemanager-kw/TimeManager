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
        MainForm mainForm;

        public EditAvailableTimeForm(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
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

        private void doneBtn_Click(object sender, EventArgs e)
        {
            //메인 폼에 시간 전달

            Close();
        }
    }
}
