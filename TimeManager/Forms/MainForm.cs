using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TimeManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Week week = Week.From(DateTime.Now);
            WeekTxtBox.Text = $"{week.Year}.{week.Month} {week.WeekOfMonth}주차";

            TimeBlockView.View = View.Details;

            TimeBlockView.Columns.Add("Name", "Name");
            TimeBlockView.Columns.Add("Day", "Day");
            TimeBlockView.Columns.Add("last", "last");

            TimeBlockView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            TimeBlockView.Columns.RemoveByKey("last");

            TimeBlockView.Columns[0].TextAlign = HorizontalAlignment.Left;
            TimeBlockView.Columns["Day"].TextAlign = HorizontalAlignment.Right;
        }
    }
}
