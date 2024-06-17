﻿namespace TimeManager.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.openEditAvailableBtn = new System.Windows.Forms.Button();
            this.AlgorithmStarter = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.NextBtn = new System.Windows.Forms.Button();
            this.WeekLabel = new System.Windows.Forms.Label();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.TimeBlockTitlePanel = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TaskBtn = new System.Windows.Forms.Button();
            this.ScheduleBtn = new System.Windows.Forms.Button();
            this.TimeBlockView = new System.Windows.Forms.ListView();
            this.SingleSchedulePanel = new System.Windows.Forms.Panel();
            this.ScheduleDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ScheduleEditOk = new System.Windows.Forms.Button();
            this.ScheduleEditCancle = new System.Windows.Forms.Button();
            this.ScheduleEndTime = new System.Windows.Forms.ComboBox();
            this.ScheduleLabel물결 = new System.Windows.Forms.Label();
            this.ScheduleStartTime = new System.Windows.Forms.ComboBox();
            this.ScheduleTimeLabel = new System.Windows.Forms.Label();
            this.ScheduleDayLabel = new System.Windows.Forms.Label();
            this.ScheduleNameTxt = new System.Windows.Forms.TextBox();
            this.ScheduleNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ScheduleRNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ScheduleRDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ScheduleRStartTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScheduleREndTime = new System.Windows.Forms.ComboBox();
            this.ScheduleRCancle = new System.Windows.Forms.Button();
            this.ScheduleREdit = new System.Windows.Forms.Button();
            this.DayCheck = new System.Windows.Forms.CheckBox();
            this.RegularSchedulePanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.TaskNameTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TaskEditCancleBtn = new System.Windows.Forms.Button();
            this.TaskEditOkBtn = new System.Windows.Forms.Button();
            this.TaskEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.TaskStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.TaskDurationCmb = new System.Windows.Forms.ComboBox();
            this.WithEndDateCheck = new System.Windows.Forms.CheckBox();
            this.ShortTaskPanel = new System.Windows.Forms.Panel();
            this.LongTaskPanel = new System.Windows.Forms.Panel();
            this.TaskLDayCheck = new System.Windows.Forms.CheckBox();
            this.TaskLTime = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TaskLDay = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.taskLongEditOkBtn = new System.Windows.Forms.Button();
            this.TaskLongEditCancleBtn = new System.Windows.Forms.Button();
            this.TaskLName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.TimeBlockTitlePanel.SuspendLayout();
            this.SingleSchedulePanel.SuspendLayout();
            this.RegularSchedulePanel.SuspendLayout();
            this.ShortTaskPanel.SuspendLayout();
            this.LongTaskPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeight = 29;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonday,
            this.ColumnTuesday,
            this.ColumnWednesday,
            this.ColumnThursday,
            this.ColumnFriday,
            this.ColumnSaturday,
            this.ColumnSunday});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 48);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 65;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(925, 473);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // ColumnMonday
            // 
            this.ColumnMonday.HeaderText = "월";
            this.ColumnMonday.MinimumWidth = 6;
            this.ColumnMonday.Name = "ColumnMonday";
            this.ColumnMonday.ReadOnly = true;
            this.ColumnMonday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnMonday.Width = 85;
            // 
            // ColumnTuesday
            // 
            this.ColumnTuesday.HeaderText = "화";
            this.ColumnTuesday.MinimumWidth = 6;
            this.ColumnTuesday.Name = "ColumnTuesday";
            this.ColumnTuesday.ReadOnly = true;
            this.ColumnTuesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnTuesday.Width = 85;
            // 
            // ColumnWednesday
            // 
            this.ColumnWednesday.HeaderText = "수";
            this.ColumnWednesday.MinimumWidth = 6;
            this.ColumnWednesday.Name = "ColumnWednesday";
            this.ColumnWednesday.ReadOnly = true;
            this.ColumnWednesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnWednesday.Width = 85;
            // 
            // ColumnThursday
            // 
            this.ColumnThursday.HeaderText = "목";
            this.ColumnThursday.MinimumWidth = 6;
            this.ColumnThursday.Name = "ColumnThursday";
            this.ColumnThursday.ReadOnly = true;
            this.ColumnThursday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnThursday.Width = 85;
            // 
            // ColumnFriday
            // 
            this.ColumnFriday.HeaderText = "금";
            this.ColumnFriday.MinimumWidth = 6;
            this.ColumnFriday.Name = "ColumnFriday";
            this.ColumnFriday.ReadOnly = true;
            this.ColumnFriday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnFriday.Width = 85;
            // 
            // ColumnSaturday
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            this.ColumnSaturday.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSaturday.HeaderText = "토";
            this.ColumnSaturday.MinimumWidth = 6;
            this.ColumnSaturday.Name = "ColumnSaturday";
            this.ColumnSaturday.ReadOnly = true;
            this.ColumnSaturday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSaturday.Width = 85;
            // 
            // ColumnSunday
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Crimson;
            this.ColumnSunday.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSunday.HeaderText = "일";
            this.ColumnSunday.MinimumWidth = 6;
            this.ColumnSunday.Name = "ColumnSunday";
            this.ColumnSunday.ReadOnly = true;
            this.ColumnSunday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSunday.Width = 85;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.dataGridView);
            this.MainPanel.Controls.Add(this.LogTxt);
            this.MainPanel.Controls.Add(this.TitlePanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanel.Location = new System.Drawing.Point(1, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(925, 592);
            this.MainPanel.TabIndex = 1;
            // 
            // LogTxt
            // 
            this.LogTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogTxt.Location = new System.Drawing.Point(0, 521);
            this.LogTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxt.Size = new System.Drawing.Size(925, 71);
            this.LogTxt.TabIndex = 1;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.openEditAvailableBtn);
            this.TitlePanel.Controls.Add(this.AlgorithmStarter);
            this.TitlePanel.Controls.Add(this.NextBtn);
            this.TitlePanel.Controls.Add(this.WeekLabel);
            this.TitlePanel.Controls.Add(this.PrevBtn);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TitlePanel.MinimumSize = new System.Drawing.Size(0, 36);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TitlePanel.Size = new System.Drawing.Size(925, 48);
            this.TitlePanel.TabIndex = 0;
            this.TitlePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TitlePanel_Paint);
            // 
            // openEditAvailableBtn
            // 
            this.openEditAvailableBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openEditAvailableBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.openEditAvailableBtn.Location = new System.Drawing.Point(831, 6);
            this.openEditAvailableBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openEditAvailableBtn.Name = "openEditAvailableBtn";
            this.openEditAvailableBtn.Size = new System.Drawing.Size(44, 36);
            this.openEditAvailableBtn.TabIndex = 4;
            this.openEditAvailableBtn.UseVisualStyleBackColor = false;
            this.openEditAvailableBtn.Click += new System.EventHandler(this.openEditAvailableBtn_Click);
            // 
            // AlgorithmStarter
            // 
            this.AlgorithmStarter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AlgorithmStarter.Dock = System.Windows.Forms.DockStyle.Right;
            this.AlgorithmStarter.ImageIndex = 0;
            this.AlgorithmStarter.ImageList = this.images;
            this.AlgorithmStarter.Location = new System.Drawing.Point(875, 6);
            this.AlgorithmStarter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlgorithmStarter.Name = "AlgorithmStarter";
            this.AlgorithmStarter.Size = new System.Drawing.Size(44, 36);
            this.AlgorithmStarter.TabIndex = 3;
            this.AlgorithmStarter.UseVisualStyleBackColor = false;
            this.AlgorithmStarter.Click += new System.EventHandler(this.AlgorithmStarter_Click);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "search.png");
            // 
            // NextBtn
            // 
            this.NextBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtn.Location = new System.Drawing.Point(200, 6);
            this.NextBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(44, 36);
            this.NextBtn.TabIndex = 2;
            this.NextBtn.Text = ">";
            this.NextBtn.UseVisualStyleBackColor = false;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // WeekLabel
            // 
            this.WeekLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WeekLabel.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WeekLabel.Location = new System.Drawing.Point(50, 6);
            this.WeekLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeekLabel.Name = "WeekLabel";
            this.WeekLabel.Size = new System.Drawing.Size(150, 36);
            this.WeekLabel.TabIndex = 1;
            this.WeekLabel.Text = "2024.05 2주차";
            this.WeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrevBtn
            // 
            this.PrevBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PrevBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.PrevBtn.Location = new System.Drawing.Point(6, 6);
            this.PrevBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(44, 36);
            this.PrevBtn.TabIndex = 0;
            this.PrevBtn.Text = "<";
            this.PrevBtn.UseVisualStyleBackColor = false;
            this.PrevBtn.Click += new System.EventHandler(this.PreBtn_Click);
            // 
            // TimeBlockTitlePanel
            // 
            this.TimeBlockTitlePanel.Controls.Add(this.AddBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.TaskBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.ScheduleBtn);
            this.TimeBlockTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockTitlePanel.Location = new System.Drawing.Point(926, 0);
            this.TimeBlockTitlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TimeBlockTitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TimeBlockTitlePanel.Name = "TimeBlockTitlePanel";
            this.TimeBlockTitlePanel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TimeBlockTitlePanel.Size = new System.Drawing.Size(251, 48);
            this.TimeBlockTitlePanel.TabIndex = 3;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddBtn.Location = new System.Drawing.Point(204, 6);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(41, 36);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // TaskBtn
            // 
            this.TaskBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TaskBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TaskBtn.Location = new System.Drawing.Point(62, 6);
            this.TaskBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskBtn.Name = "TaskBtn";
            this.TaskBtn.Size = new System.Drawing.Size(56, 36);
            this.TaskBtn.TabIndex = 2;
            this.TaskBtn.Text = "업무";
            this.TaskBtn.UseVisualStyleBackColor = false;
            this.TaskBtn.Click += new System.EventHandler(this.TaskBtn_Click);
            // 
            // ScheduleBtn
            // 
            this.ScheduleBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ScheduleBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScheduleBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleBtn.Location = new System.Drawing.Point(6, 6);
            this.ScheduleBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleBtn.Name = "ScheduleBtn";
            this.ScheduleBtn.Size = new System.Drawing.Size(56, 36);
            this.ScheduleBtn.TabIndex = 1;
            this.ScheduleBtn.Text = "일정";
            this.ScheduleBtn.UseVisualStyleBackColor = false;
            this.ScheduleBtn.Click += new System.EventHandler(this.ScheduleBtn_Click);
            // 
            // TimeBlockView
            // 
            this.TimeBlockView.BackColor = System.Drawing.Color.Honeydew;
            this.TimeBlockView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockView.FullRowSelect = true;
            this.TimeBlockView.HideSelection = false;
            this.TimeBlockView.Location = new System.Drawing.Point(926, 48);
            this.TimeBlockView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TimeBlockView.MultiSelect = false;
            this.TimeBlockView.Name = "TimeBlockView";
            this.TimeBlockView.Size = new System.Drawing.Size(251, 263);
            this.TimeBlockView.TabIndex = 7;
            this.TimeBlockView.UseCompatibleStateImageBehavior = false;
            this.TimeBlockView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.TimeBlockView_ItemSelectionChanged);
            // 
            // SingleSchedulePanel
            // 
            this.SingleSchedulePanel.Controls.Add(this.ScheduleDatePicker);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleEditOk);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleEditCancle);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleEndTime);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleLabel물결);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleStartTime);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleTimeLabel);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleDayLabel);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleNameTxt);
            this.SingleSchedulePanel.Controls.Add(this.ScheduleNameLabel);
            this.SingleSchedulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SingleSchedulePanel.Location = new System.Drawing.Point(926, 311);
            this.SingleSchedulePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SingleSchedulePanel.Name = "SingleSchedulePanel";
            this.SingleSchedulePanel.Size = new System.Drawing.Size(251, 281);
            this.SingleSchedulePanel.TabIndex = 8;
            // 
            // ScheduleDatePicker
            // 
            this.ScheduleDatePicker.CustomFormat = "yyyy-MM-dd";
            this.ScheduleDatePicker.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ScheduleDatePicker.Location = new System.Drawing.Point(100, 54);
            this.ScheduleDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleDatePicker.Name = "ScheduleDatePicker";
            this.ScheduleDatePicker.Size = new System.Drawing.Size(136, 28);
            this.ScheduleDatePicker.TabIndex = 14;
            // 
            // ScheduleEditOk
            // 
            this.ScheduleEditOk.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleEditOk.Location = new System.Drawing.Point(188, 234);
            this.ScheduleEditOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleEditOk.Name = "ScheduleEditOk";
            this.ScheduleEditOk.Size = new System.Drawing.Size(56, 36);
            this.ScheduleEditOk.TabIndex = 13;
            this.ScheduleEditOk.Text = "수정";
            this.ScheduleEditOk.UseVisualStyleBackColor = true;
            this.ScheduleEditOk.Click += new System.EventHandler(this.ScheduleEditOk_Click);
            // 
            // ScheduleEditCancle
            // 
            this.ScheduleEditCancle.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleEditCancle.Location = new System.Drawing.Point(131, 234);
            this.ScheduleEditCancle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleEditCancle.Name = "ScheduleEditCancle";
            this.ScheduleEditCancle.Size = new System.Drawing.Size(56, 36);
            this.ScheduleEditCancle.TabIndex = 12;
            this.ScheduleEditCancle.Text = "취소";
            this.ScheduleEditCancle.UseVisualStyleBackColor = true;
            this.ScheduleEditCancle.Click += new System.EventHandler(this.EditCancle_Click);
            // 
            // ScheduleEndTime
            // 
            this.ScheduleEndTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleEndTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleEndTime.FormattingEnabled = true;
            this.ScheduleEndTime.Location = new System.Drawing.Point(100, 150);
            this.ScheduleEndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleEndTime.Name = "ScheduleEndTime";
            this.ScheduleEndTime.Size = new System.Drawing.Size(124, 26);
            this.ScheduleEndTime.TabIndex = 9;
            // 
            // ScheduleLabel물결
            // 
            this.ScheduleLabel물결.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleLabel물결.Location = new System.Drawing.Point(19, 150);
            this.ScheduleLabel물결.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleLabel물결.Name = "ScheduleLabel물결";
            this.ScheduleLabel물결.Size = new System.Drawing.Size(75, 30);
            this.ScheduleLabel물결.TabIndex = 8;
            this.ScheduleLabel물결.Text = "~";
            this.ScheduleLabel물결.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleStartTime
            // 
            this.ScheduleStartTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleStartTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleStartTime.FormattingEnabled = true;
            this.ScheduleStartTime.Location = new System.Drawing.Point(100, 102);
            this.ScheduleStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleStartTime.Name = "ScheduleStartTime";
            this.ScheduleStartTime.Size = new System.Drawing.Size(124, 26);
            this.ScheduleStartTime.TabIndex = 5;
            // 
            // ScheduleTimeLabel
            // 
            this.ScheduleTimeLabel.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleTimeLabel.Location = new System.Drawing.Point(19, 102);
            this.ScheduleTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleTimeLabel.Name = "ScheduleTimeLabel";
            this.ScheduleTimeLabel.Size = new System.Drawing.Size(75, 30);
            this.ScheduleTimeLabel.TabIndex = 4;
            this.ScheduleTimeLabel.Text = "시간";
            this.ScheduleTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleDayLabel
            // 
            this.ScheduleDayLabel.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleDayLabel.Location = new System.Drawing.Point(19, 54);
            this.ScheduleDayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleDayLabel.Name = "ScheduleDayLabel";
            this.ScheduleDayLabel.Size = new System.Drawing.Size(75, 30);
            this.ScheduleDayLabel.TabIndex = 2;
            this.ScheduleDayLabel.Text = "날짜";
            this.ScheduleDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleNameTxt
            // 
            this.ScheduleNameTxt.Location = new System.Drawing.Point(100, 6);
            this.ScheduleNameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleNameTxt.Name = "ScheduleNameTxt";
            this.ScheduleNameTxt.Size = new System.Drawing.Size(136, 28);
            this.ScheduleNameTxt.TabIndex = 1;
            // 
            // ScheduleNameLabel
            // 
            this.ScheduleNameLabel.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleNameLabel.Location = new System.Drawing.Point(19, 6);
            this.ScheduleNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleNameLabel.Name = "ScheduleNameLabel";
            this.ScheduleNameLabel.Size = new System.Drawing.Size(75, 30);
            this.ScheduleNameLabel.TabIndex = 0;
            this.ScheduleNameLabel.Text = "일정 명";
            this.ScheduleNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(19, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "일정 명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleRNameTxt
            // 
            this.ScheduleRNameTxt.Location = new System.Drawing.Point(100, 6);
            this.ScheduleRNameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleRNameTxt.Name = "ScheduleRNameTxt";
            this.ScheduleRNameTxt.Size = new System.Drawing.Size(136, 28);
            this.ScheduleRNameTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(19, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "요일";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleRDay
            // 
            this.ScheduleRDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleRDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleRDay.FormattingEnabled = true;
            this.ScheduleRDay.Items.AddRange(new object[] {
            "월",
            "화",
            "수",
            "목",
            "금",
            "토",
            "일"});
            this.ScheduleRDay.Location = new System.Drawing.Point(100, 54);
            this.ScheduleRDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleRDay.Name = "ScheduleRDay";
            this.ScheduleRDay.Size = new System.Drawing.Size(62, 26);
            this.ScheduleRDay.TabIndex = 3;
            this.ScheduleRDay.SelectedValueChanged += new System.EventHandler(this.ScheduleRDayCmb_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(19, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "시간";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleRStartTime
            // 
            this.ScheduleRStartTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleRStartTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleRStartTime.FormattingEnabled = true;
            this.ScheduleRStartTime.Location = new System.Drawing.Point(100, 102);
            this.ScheduleRStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleRStartTime.Name = "ScheduleRStartTime";
            this.ScheduleRStartTime.Size = new System.Drawing.Size(124, 26);
            this.ScheduleRStartTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleREndTime
            // 
            this.ScheduleREndTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleREndTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleREndTime.FormattingEnabled = true;
            this.ScheduleREndTime.Location = new System.Drawing.Point(100, 150);
            this.ScheduleREndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleREndTime.Name = "ScheduleREndTime";
            this.ScheduleREndTime.Size = new System.Drawing.Size(124, 26);
            this.ScheduleREndTime.TabIndex = 9;
            // 
            // ScheduleRCancle
            // 
            this.ScheduleRCancle.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleRCancle.Location = new System.Drawing.Point(131, 234);
            this.ScheduleRCancle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleRCancle.Name = "ScheduleRCancle";
            this.ScheduleRCancle.Size = new System.Drawing.Size(56, 36);
            this.ScheduleRCancle.TabIndex = 12;
            this.ScheduleRCancle.Text = "취소";
            this.ScheduleRCancle.UseVisualStyleBackColor = true;
            this.ScheduleRCancle.Click += new System.EventHandler(this.EditCancle_Click);
            // 
            // ScheduleREdit
            // 
            this.ScheduleREdit.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleREdit.Location = new System.Drawing.Point(188, 234);
            this.ScheduleREdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScheduleREdit.Name = "ScheduleREdit";
            this.ScheduleREdit.Size = new System.Drawing.Size(56, 36);
            this.ScheduleREdit.TabIndex = 13;
            this.ScheduleREdit.Text = "수정";
            this.ScheduleREdit.UseVisualStyleBackColor = true;
            this.ScheduleREdit.Click += new System.EventHandler(this.ScheduleEditOk_Click);
            // 
            // DayCheck
            // 
            this.DayCheck.Location = new System.Drawing.Point(175, 58);
            this.DayCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DayCheck.Name = "DayCheck";
            this.DayCheck.Size = new System.Drawing.Size(22, 20);
            this.DayCheck.TabIndex = 14;
            this.DayCheck.UseVisualStyleBackColor = true;
            // 
            // RegularSchedulePanel
            // 
            this.RegularSchedulePanel.Controls.Add(this.DayCheck);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleREdit);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleRCancle);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleREndTime);
            this.RegularSchedulePanel.Controls.Add(this.label1);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleRStartTime);
            this.RegularSchedulePanel.Controls.Add(this.label2);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleRDay);
            this.RegularSchedulePanel.Controls.Add(this.label3);
            this.RegularSchedulePanel.Controls.Add(this.ScheduleRNameTxt);
            this.RegularSchedulePanel.Controls.Add(this.label4);
            this.RegularSchedulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegularSchedulePanel.Location = new System.Drawing.Point(926, 311);
            this.RegularSchedulePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegularSchedulePanel.Name = "RegularSchedulePanel";
            this.RegularSchedulePanel.Size = new System.Drawing.Size(251, 281);
            this.RegularSchedulePanel.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "업무명";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaskNameTxt
            // 
            this.TaskNameTxt.Location = new System.Drawing.Point(100, 6);
            this.TaskNameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskNameTxt.Name = "TaskNameTxt";
            this.TaskNameTxt.Size = new System.Drawing.Size(136, 28);
            this.TaskNameTxt.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 30);
            this.label7.TabIndex = 2;
            this.label7.Text = "마감일";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaskEditCancleBtn
            // 
            this.TaskEditCancleBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TaskEditCancleBtn.Location = new System.Drawing.Point(131, 234);
            this.TaskEditCancleBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskEditCancleBtn.Name = "TaskEditCancleBtn";
            this.TaskEditCancleBtn.Size = new System.Drawing.Size(56, 36);
            this.TaskEditCancleBtn.TabIndex = 12;
            this.TaskEditCancleBtn.Text = "취소";
            this.TaskEditCancleBtn.UseVisualStyleBackColor = true;
            this.TaskEditCancleBtn.Click += new System.EventHandler(this.EditCancle_Click);
            // 
            // TaskEditOkBtn
            // 
            this.TaskEditOkBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TaskEditOkBtn.Location = new System.Drawing.Point(188, 234);
            this.TaskEditOkBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskEditOkBtn.Name = "TaskEditOkBtn";
            this.TaskEditOkBtn.Size = new System.Drawing.Size(56, 36);
            this.TaskEditOkBtn.TabIndex = 13;
            this.TaskEditOkBtn.Text = "수정";
            this.TaskEditOkBtn.UseVisualStyleBackColor = true;
            this.TaskEditOkBtn.Click += new System.EventHandler(this.TaskEditOk_Click);
            // 
            // TaskEndDatePicker
            // 
            this.TaskEndDatePicker.CustomFormat = "yyyy-MM-dd";
            this.TaskEndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TaskEndDatePicker.Location = new System.Drawing.Point(100, 54);
            this.TaskEndDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskEndDatePicker.Name = "TaskEndDatePicker";
            this.TaskEndDatePicker.Size = new System.Drawing.Size(136, 28);
            this.TaskEndDatePicker.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 15;
            this.label5.Text = "시작일";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaskStartDatePicker
            // 
            this.TaskStartDatePicker.CustomFormat = "yyyy-MM-dd";
            this.TaskStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TaskStartDatePicker.Location = new System.Drawing.Point(100, 120);
            this.TaskStartDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskStartDatePicker.Name = "TaskStartDatePicker";
            this.TaskStartDatePicker.Size = new System.Drawing.Size(136, 28);
            this.TaskStartDatePicker.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(6, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 17;
            this.label6.Text = "수행 시간";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaskDurationCmb
            // 
            this.TaskDurationCmb.FormattingEnabled = true;
            this.TaskDurationCmb.Location = new System.Drawing.Point(100, 156);
            this.TaskDurationCmb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskDurationCmb.Name = "TaskDurationCmb";
            this.TaskDurationCmb.Size = new System.Drawing.Size(136, 26);
            this.TaskDurationCmb.TabIndex = 18;
            // 
            // WithEndDateCheck
            // 
            this.WithEndDateCheck.AutoSize = true;
            this.WithEndDateCheck.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WithEndDateCheck.Location = new System.Drawing.Point(100, 90);
            this.WithEndDateCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WithEndDateCheck.Name = "WithEndDateCheck";
            this.WithEndDateCheck.Size = new System.Drawing.Size(126, 27);
            this.WithEndDateCheck.TabIndex = 19;
            this.WithEndDateCheck.Text = "마감일 포함";
            this.WithEndDateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WithEndDateCheck.UseVisualStyleBackColor = true;
            // 
            // ShortTaskPanel
            // 
            this.ShortTaskPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ShortTaskPanel.Controls.Add(this.WithEndDateCheck);
            this.ShortTaskPanel.Controls.Add(this.TaskDurationCmb);
            this.ShortTaskPanel.Controls.Add(this.label6);
            this.ShortTaskPanel.Controls.Add(this.TaskStartDatePicker);
            this.ShortTaskPanel.Controls.Add(this.label5);
            this.ShortTaskPanel.Controls.Add(this.TaskEndDatePicker);
            this.ShortTaskPanel.Controls.Add(this.TaskEditOkBtn);
            this.ShortTaskPanel.Controls.Add(this.TaskEditCancleBtn);
            this.ShortTaskPanel.Controls.Add(this.label7);
            this.ShortTaskPanel.Controls.Add(this.TaskNameTxt);
            this.ShortTaskPanel.Controls.Add(this.label8);
            this.ShortTaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortTaskPanel.Location = new System.Drawing.Point(926, 311);
            this.ShortTaskPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShortTaskPanel.Name = "ShortTaskPanel";
            this.ShortTaskPanel.Size = new System.Drawing.Size(251, 281);
            this.ShortTaskPanel.TabIndex = 21;
            // 
            // LongTaskPanel
            // 
            this.LongTaskPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.LongTaskPanel.Controls.Add(this.TaskLDayCheck);
            this.LongTaskPanel.Controls.Add(this.TaskLTime);
            this.LongTaskPanel.Controls.Add(this.label10);
            this.LongTaskPanel.Controls.Add(this.TaskLDay);
            this.LongTaskPanel.Controls.Add(this.label11);
            this.LongTaskPanel.Controls.Add(this.taskLongEditOkBtn);
            this.LongTaskPanel.Controls.Add(this.TaskLongEditCancleBtn);
            this.LongTaskPanel.Controls.Add(this.TaskLName);
            this.LongTaskPanel.Controls.Add(this.label12);
            this.LongTaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LongTaskPanel.Location = new System.Drawing.Point(926, 311);
            this.LongTaskPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LongTaskPanel.Name = "LongTaskPanel";
            this.LongTaskPanel.Size = new System.Drawing.Size(251, 281);
            this.LongTaskPanel.TabIndex = 22;
            // 
            // TaskLDayCheck
            // 
            this.TaskLDayCheck.Location = new System.Drawing.Point(181, 61);
            this.TaskLDayCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskLDayCheck.Name = "TaskLDayCheck";
            this.TaskLDayCheck.Size = new System.Drawing.Size(22, 20);
            this.TaskLDayCheck.TabIndex = 21;
            this.TaskLDayCheck.UseVisualStyleBackColor = true;
            // 
            // TaskLTime
            // 
            this.TaskLTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TaskLTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TaskLTime.FormattingEnabled = true;
            this.TaskLTime.Location = new System.Drawing.Point(106, 106);
            this.TaskLTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskLTime.Name = "TaskLTime";
            this.TaskLTime.Size = new System.Drawing.Size(124, 26);
            this.TaskLTime.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(25, 106);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 30);
            this.label10.TabIndex = 17;
            this.label10.Text = "시간";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaskLDay
            // 
            this.TaskLDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TaskLDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TaskLDay.FormattingEnabled = true;
            this.TaskLDay.Items.AddRange(new object[] {
            "월",
            "화",
            "수",
            "목",
            "금",
            "토",
            "일"});
            this.TaskLDay.Location = new System.Drawing.Point(106, 58);
            this.TaskLDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskLDay.Name = "TaskLDay";
            this.TaskLDay.Size = new System.Drawing.Size(62, 26);
            this.TaskLDay.TabIndex = 16;
            this.TaskLDay.SelectedValueChanged += new System.EventHandler(this.TaskLDay_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(25, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 30);
            this.label11.TabIndex = 15;
            this.label11.Text = "요일";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taskLongEditOkBtn
            // 
            this.taskLongEditOkBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.taskLongEditOkBtn.Location = new System.Drawing.Point(188, 234);
            this.taskLongEditOkBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.taskLongEditOkBtn.Name = "taskLongEditOkBtn";
            this.taskLongEditOkBtn.Size = new System.Drawing.Size(56, 36);
            this.taskLongEditOkBtn.TabIndex = 13;
            this.taskLongEditOkBtn.Text = "수정";
            this.taskLongEditOkBtn.UseVisualStyleBackColor = true;
            this.taskLongEditOkBtn.Click += new System.EventHandler(this.TaskEditOk_Click);
            // 
            // TaskLongEditCancleBtn
            // 
            this.TaskLongEditCancleBtn.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TaskLongEditCancleBtn.Location = new System.Drawing.Point(131, 234);
            this.TaskLongEditCancleBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskLongEditCancleBtn.Name = "TaskLongEditCancleBtn";
            this.TaskLongEditCancleBtn.Size = new System.Drawing.Size(56, 36);
            this.TaskLongEditCancleBtn.TabIndex = 12;
            this.TaskLongEditCancleBtn.Text = "취소";
            this.TaskLongEditCancleBtn.UseVisualStyleBackColor = true;
            this.TaskLongEditCancleBtn.Click += new System.EventHandler(this.EditCancle_Click);
            // 
            // TaskLName
            // 
            this.TaskLName.Location = new System.Drawing.Point(100, 6);
            this.TaskLName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TaskLName.Name = "TaskLName";
            this.TaskLName.Size = new System.Drawing.Size(136, 28);
            this.TaskLName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("함초롬바탕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(6, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "업무명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1178, 592);
            this.Controls.Add(this.LongTaskPanel);
            this.Controls.Add(this.RegularSchedulePanel);
            this.Controls.Add(this.ShortTaskPanel);
            this.Controls.Add(this.SingleSchedulePanel);
            this.Controls.Add(this.TimeBlockView);
            this.Controls.Add(this.TimeBlockTitlePanel);
            this.Controls.Add(this.MainPanel);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.TitlePanel.ResumeLayout(false);
            this.TimeBlockTitlePanel.ResumeLayout(false);
            this.SingleSchedulePanel.ResumeLayout(false);
            this.SingleSchedulePanel.PerformLayout();
            this.RegularSchedulePanel.ResumeLayout(false);
            this.RegularSchedulePanel.PerformLayout();
            this.ShortTaskPanel.ResumeLayout(false);
            this.ShortTaskPanel.PerformLayout();
            this.LongTaskPanel.ResumeLayout(false);
            this.LongTaskPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label WeekLabel;
        private System.Windows.Forms.TextBox LogTxt;
        private System.Windows.Forms.Button AlgorithmStarter;
        private System.Windows.Forms.Panel TimeBlockTitlePanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button TaskBtn;
        private System.Windows.Forms.Button ScheduleBtn;
        private System.Windows.Forms.ListView TimeBlockView;
        private System.Windows.Forms.Panel SingleSchedulePanel;
        private System.Windows.Forms.DateTimePicker ScheduleDatePicker;
        private System.Windows.Forms.Button ScheduleEditOk;
        private System.Windows.Forms.Button ScheduleEditCancle;
        private System.Windows.Forms.ComboBox ScheduleEndTime;
        private System.Windows.Forms.Label ScheduleLabel물결;
        private System.Windows.Forms.ComboBox ScheduleStartTime;
        private System.Windows.Forms.Label ScheduleTimeLabel;
        private System.Windows.Forms.Label ScheduleDayLabel;
        private System.Windows.Forms.TextBox ScheduleNameTxt;
        private System.Windows.Forms.Label ScheduleNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ScheduleRNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ScheduleRDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ScheduleRStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ScheduleREndTime;
        private System.Windows.Forms.Button ScheduleRCancle;
        private System.Windows.Forms.Button ScheduleREdit;
        private System.Windows.Forms.CheckBox DayCheck;
        private System.Windows.Forms.Panel RegularSchedulePanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TaskNameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button TaskEditCancleBtn;
        private System.Windows.Forms.Button TaskEditOkBtn;
        private System.Windows.Forms.DateTimePicker TaskEndDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker TaskStartDatePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TaskDurationCmb;
        private System.Windows.Forms.CheckBox WithEndDateCheck;
        private System.Windows.Forms.Panel ShortTaskPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSunday;
        private System.Windows.Forms.Panel LongTaskPanel;
        private System.Windows.Forms.Button taskLongEditOkBtn;
        private System.Windows.Forms.Button TaskLongEditCancleBtn;
        private System.Windows.Forms.TextBox TaskLName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button openEditAvailableBtn;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.CheckBox TaskLDayCheck;
        private System.Windows.Forms.ComboBox TaskLTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TaskLDay;
        private System.Windows.Forms.Label label11;
    }
}