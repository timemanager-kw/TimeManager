using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeManager.Data.Model;

namespace TimeManager.Forms
{
    public partial class AddTaskForm : Form
    {
        MainForm MainForm;

        Task Task;

        public AddTaskForm(MainForm mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;

            Task = new Task();

            for (int i = 30; i < 6000; i += 30)
            {
                TaskDurationCmb.Items.Add($"{i / 60}:{i % 60}");
            }
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            Action[] AddType = new Action[]
            {
                () => {
                    Task.StartDate = AddShortTaskStartDatePicker.Value;
                    Task.EndDate = AddShortTaskEndDatePicker.Value;

                    if (Task.StartDate.CompareTo(Task.EndDate) >= 0)
                    {
                        MessageBox.Show("시작일이 마감일 뒤에 올 수 없습니다.");
                        return;
                    }

                    Task.Duration = (TimeSpan)(Task.StartDate - Task.EndDate);
                    Task.FocusDays = AddLongTaskIsTrue.Checked ? (int)Task.Duration.Value.TotalDays + 1 : (int)Task.Duration.Value.TotalDays;

                    MainForm.CloseAddTask(true, Task);
                    Close();
                },
                () => {

                    MainForm.CloseAddTask(true, Task);
                    Close();
                }
            };
            Task.Name = AddTaskName.Text;
            //ID 추가
            Task.Type = AddTaskIsLong.Checked ? ETaskType.LongTerm : ETaskType.ShortTerm;
            Task.Description = AddTaskMemo.Text;

            AddType[(int)Task.Type]();
        }
    }
}
