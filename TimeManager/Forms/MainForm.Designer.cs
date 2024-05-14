namespace TimeManager.Forms
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.AlgorithmStarter = new System.Windows.Forms.Button();
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
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.TitlePanel.SuspendLayout();
            this.TimeBlockTitlePanel.SuspendLayout();
            this.SingleSchedulePanel.SuspendLayout();
            this.RegularSchedulePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.dataGridView);
            this.MainPanel.Controls.Add(this.LogTxt);
            this.MainPanel.Controls.Add(this.TitlePanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanel.Location = new System.Drawing.Point(1, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(740, 493);
            this.MainPanel.TabIndex = 1;
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
            this.dataGridView.Location = new System.Drawing.Point(0, 40);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 65;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(740, 393);
            this.dataGridView.TabIndex = 2;
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
            this.ColumnSaturday.HeaderText = "토";
            this.ColumnSaturday.MinimumWidth = 6;
            this.ColumnSaturday.Name = "ColumnSaturday";
            this.ColumnSaturday.ReadOnly = true;
            this.ColumnSaturday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSaturday.Width = 85;
            // 
            // ColumnSunday
            // 
            this.ColumnSunday.HeaderText = "일";
            this.ColumnSunday.MinimumWidth = 6;
            this.ColumnSunday.Name = "ColumnSunday";
            this.ColumnSunday.ReadOnly = true;
            this.ColumnSunday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSunday.Width = 85;
            // 
            // LogTxt
            // 
            this.LogTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogTxt.Location = new System.Drawing.Point(0, 433);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxt.Size = new System.Drawing.Size(740, 60);
            this.LogTxt.TabIndex = 1;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.AlgorithmStarter);
            this.TitlePanel.Controls.Add(this.NextBtn);
            this.TitlePanel.Controls.Add(this.WeekLabel);
            this.TitlePanel.Controls.Add(this.PrevBtn);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Padding = new System.Windows.Forms.Padding(5);
            this.TitlePanel.Size = new System.Drawing.Size(740, 40);
            this.TitlePanel.TabIndex = 0;
            // 
            // AlgorithmStarter
            // 
            this.AlgorithmStarter.Dock = System.Windows.Forms.DockStyle.Right;
            this.AlgorithmStarter.Location = new System.Drawing.Point(700, 5);
            this.AlgorithmStarter.Name = "AlgorithmStarter";
            this.AlgorithmStarter.Size = new System.Drawing.Size(35, 30);
            this.AlgorithmStarter.TabIndex = 3;
            this.AlgorithmStarter.UseVisualStyleBackColor = true;
            this.AlgorithmStarter.Click += new System.EventHandler(this.AlgorithmStarter_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtn.Location = new System.Drawing.Point(160, 5);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(35, 30);
            this.NextBtn.TabIndex = 2;
            this.NextBtn.Text = ">";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // WeekLabel
            // 
            this.WeekLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WeekLabel.Location = new System.Drawing.Point(40, 5);
            this.WeekLabel.Name = "WeekLabel";
            this.WeekLabel.Size = new System.Drawing.Size(120, 30);
            this.WeekLabel.TabIndex = 1;
            this.WeekLabel.Text = "2024.05 2주차";
            this.WeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrevBtn
            // 
            this.PrevBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.PrevBtn.Location = new System.Drawing.Point(5, 5);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(35, 30);
            this.PrevBtn.TabIndex = 0;
            this.PrevBtn.Text = "<";
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PreBtn_Click);
            // 
            // TimeBlockTitlePanel
            // 
            this.TimeBlockTitlePanel.Controls.Add(this.AddBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.TaskBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.ScheduleBtn);
            this.TimeBlockTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockTitlePanel.Location = new System.Drawing.Point(741, 0);
            this.TimeBlockTitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TimeBlockTitlePanel.Name = "TimeBlockTitlePanel";
            this.TimeBlockTitlePanel.Padding = new System.Windows.Forms.Padding(5);
            this.TimeBlockTitlePanel.Size = new System.Drawing.Size(200, 40);
            this.TimeBlockTitlePanel.TabIndex = 3;
            // 
            // AddBtn
            // 
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddBtn.Location = new System.Drawing.Point(162, 5);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(33, 30);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // TaskBtn
            // 
            this.TaskBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskBtn.Location = new System.Drawing.Point(50, 5);
            this.TaskBtn.Name = "TaskBtn";
            this.TaskBtn.Size = new System.Drawing.Size(45, 30);
            this.TaskBtn.TabIndex = 2;
            this.TaskBtn.Text = "업무";
            this.TaskBtn.UseVisualStyleBackColor = true;
            this.TaskBtn.Click += new System.EventHandler(this.TaskBtn_Click);
            // 
            // ScheduleBtn
            // 
            this.ScheduleBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScheduleBtn.Location = new System.Drawing.Point(5, 5);
            this.ScheduleBtn.Name = "ScheduleBtn";
            this.ScheduleBtn.Size = new System.Drawing.Size(45, 30);
            this.ScheduleBtn.TabIndex = 1;
            this.ScheduleBtn.Text = "일정";
            this.ScheduleBtn.UseVisualStyleBackColor = true;
            this.ScheduleBtn.Click += new System.EventHandler(this.ScheduleBtn_Click);
            // 
            // TimeBlockView
            // 
            this.TimeBlockView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockView.HideSelection = false;
            this.TimeBlockView.Location = new System.Drawing.Point(741, 40);
            this.TimeBlockView.MultiSelect = false;
            this.TimeBlockView.Name = "TimeBlockView";
            this.TimeBlockView.Size = new System.Drawing.Size(200, 220);
            this.TimeBlockView.TabIndex = 7;
            this.TimeBlockView.UseCompatibleStateImageBehavior = false;
            this.TimeBlockView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.TimeBlockView_ItemSelectionChanged);
            this.TimeBlockView.SelectedIndexChanged += new System.EventHandler(this.TimeBlockView_SelectedIndexChanged);
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
            this.SingleSchedulePanel.Location = new System.Drawing.Point(741, 260);
            this.SingleSchedulePanel.Name = "SingleSchedulePanel";
            this.SingleSchedulePanel.Size = new System.Drawing.Size(200, 233);
            this.SingleSchedulePanel.TabIndex = 8;
            // 
            // ScheduleDatePicker
            // 
            this.ScheduleDatePicker.CustomFormat = "yyyy-MM-dd";
            this.ScheduleDatePicker.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ScheduleDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ScheduleDatePicker.Location = new System.Drawing.Point(70, 45);
            this.ScheduleDatePicker.Name = "ScheduleDatePicker";
            this.ScheduleDatePicker.Size = new System.Drawing.Size(120, 25);
            this.ScheduleDatePicker.TabIndex = 14;
            // 
            // ScheduleEditOk
            // 
            this.ScheduleEditOk.Location = new System.Drawing.Point(150, 195);
            this.ScheduleEditOk.Name = "ScheduleEditOk";
            this.ScheduleEditOk.Size = new System.Drawing.Size(45, 30);
            this.ScheduleEditOk.TabIndex = 13;
            this.ScheduleEditOk.Text = "수정";
            this.ScheduleEditOk.UseVisualStyleBackColor = true;
            // 
            // ScheduleEditCancle
            // 
            this.ScheduleEditCancle.Location = new System.Drawing.Point(105, 195);
            this.ScheduleEditCancle.Name = "ScheduleEditCancle";
            this.ScheduleEditCancle.Size = new System.Drawing.Size(45, 30);
            this.ScheduleEditCancle.TabIndex = 12;
            this.ScheduleEditCancle.Text = "취소";
            this.ScheduleEditCancle.UseVisualStyleBackColor = true;
            // 
            // ScheduleEndTime
            // 
            this.ScheduleEndTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleEndTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleEndTime.FormattingEnabled = true;
            this.ScheduleEndTime.Location = new System.Drawing.Point(70, 125);
            this.ScheduleEndTime.Name = "ScheduleEndTime";
            this.ScheduleEndTime.Size = new System.Drawing.Size(100, 23);
            this.ScheduleEndTime.TabIndex = 9;
            // 
            // ScheduleLabel물결
            // 
            this.ScheduleLabel물결.Location = new System.Drawing.Point(5, 125);
            this.ScheduleLabel물결.Name = "ScheduleLabel물결";
            this.ScheduleLabel물결.Size = new System.Drawing.Size(60, 25);
            this.ScheduleLabel물결.TabIndex = 8;
            this.ScheduleLabel물결.Text = "~";
            this.ScheduleLabel물결.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleStartTime
            // 
            this.ScheduleStartTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleStartTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleStartTime.FormattingEnabled = true;
            this.ScheduleStartTime.Location = new System.Drawing.Point(70, 85);
            this.ScheduleStartTime.Name = "ScheduleStartTime";
            this.ScheduleStartTime.Size = new System.Drawing.Size(100, 23);
            this.ScheduleStartTime.TabIndex = 5;
            // 
            // ScheduleTimeLabel
            // 
            this.ScheduleTimeLabel.Location = new System.Drawing.Point(5, 85);
            this.ScheduleTimeLabel.Name = "ScheduleTimeLabel";
            this.ScheduleTimeLabel.Size = new System.Drawing.Size(60, 25);
            this.ScheduleTimeLabel.TabIndex = 4;
            this.ScheduleTimeLabel.Text = "시간";
            this.ScheduleTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleDayLabel
            // 
            this.ScheduleDayLabel.Location = new System.Drawing.Point(5, 45);
            this.ScheduleDayLabel.Name = "ScheduleDayLabel";
            this.ScheduleDayLabel.Size = new System.Drawing.Size(60, 25);
            this.ScheduleDayLabel.TabIndex = 2;
            this.ScheduleDayLabel.Text = "날짜";
            this.ScheduleDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleNameTxt
            // 
            this.ScheduleNameTxt.Location = new System.Drawing.Point(70, 5);
            this.ScheduleNameTxt.Name = "ScheduleNameTxt";
            this.ScheduleNameTxt.Size = new System.Drawing.Size(120, 25);
            this.ScheduleNameTxt.TabIndex = 1;
            // 
            // ScheduleNameLabel
            // 
            this.ScheduleNameLabel.Location = new System.Drawing.Point(5, 5);
            this.ScheduleNameLabel.Name = "ScheduleNameLabel";
            this.ScheduleNameLabel.Size = new System.Drawing.Size(60, 25);
            this.ScheduleNameLabel.TabIndex = 0;
            this.ScheduleNameLabel.Text = "일정 명";
            this.ScheduleNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "일정 명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleRNameTxt
            // 
            this.ScheduleRNameTxt.Location = new System.Drawing.Point(70, 5);
            this.ScheduleRNameTxt.Name = "ScheduleRNameTxt";
            this.ScheduleRNameTxt.Size = new System.Drawing.Size(120, 25);
            this.ScheduleRNameTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
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
            this.ScheduleRDay.Location = new System.Drawing.Point(70, 45);
            this.ScheduleRDay.Name = "ScheduleRDay";
            this.ScheduleRDay.Size = new System.Drawing.Size(50, 23);
            this.ScheduleRDay.TabIndex = 3;
            this.ScheduleRDay.SelectedValueChanged += new System.EventHandler(this.ScheduleRDayCmb_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "시간";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleRStartTime
            // 
            this.ScheduleRStartTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleRStartTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleRStartTime.FormattingEnabled = true;
            this.ScheduleRStartTime.Location = new System.Drawing.Point(70, 85);
            this.ScheduleRStartTime.Name = "ScheduleRStartTime";
            this.ScheduleRStartTime.Size = new System.Drawing.Size(100, 23);
            this.ScheduleRStartTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScheduleREndTime
            // 
            this.ScheduleREndTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ScheduleREndTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ScheduleREndTime.FormattingEnabled = true;
            this.ScheduleREndTime.Location = new System.Drawing.Point(70, 125);
            this.ScheduleREndTime.Name = "ScheduleREndTime";
            this.ScheduleREndTime.Size = new System.Drawing.Size(100, 23);
            this.ScheduleREndTime.TabIndex = 9;
            // 
            // ScheduleRCancle
            // 
            this.ScheduleRCancle.Location = new System.Drawing.Point(105, 195);
            this.ScheduleRCancle.Name = "ScheduleRCancle";
            this.ScheduleRCancle.Size = new System.Drawing.Size(45, 30);
            this.ScheduleRCancle.TabIndex = 12;
            this.ScheduleRCancle.Text = "취소";
            this.ScheduleRCancle.UseVisualStyleBackColor = true;
            this.ScheduleRCancle.Click += new System.EventHandler(this.ScheduleEditCancle_Click);
            // 
            // ScheduleREdit
            // 
            this.ScheduleREdit.Location = new System.Drawing.Point(150, 195);
            this.ScheduleREdit.Name = "ScheduleREdit";
            this.ScheduleREdit.Size = new System.Drawing.Size(45, 30);
            this.ScheduleREdit.TabIndex = 13;
            this.ScheduleREdit.Text = "수정";
            this.ScheduleREdit.UseVisualStyleBackColor = true;
            this.ScheduleREdit.Click += new System.EventHandler(this.ScheduleEditOk_Click);
            // 
            // DayCheck
            // 
            this.DayCheck.Location = new System.Drawing.Point(132, 48);
            this.DayCheck.Name = "DayCheck";
            this.DayCheck.Size = new System.Drawing.Size(18, 17);
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
            this.RegularSchedulePanel.Location = new System.Drawing.Point(741, 260);
            this.RegularSchedulePanel.Name = "RegularSchedulePanel";
            this.RegularSchedulePanel.Size = new System.Drawing.Size(200, 233);
            this.RegularSchedulePanel.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.RegularSchedulePanel);
            this.Controls.Add(this.SingleSchedulePanel);
            this.Controls.Add(this.TimeBlockView);
            this.Controls.Add(this.TimeBlockTitlePanel);
            this.Controls.Add(this.MainPanel);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.TitlePanel.ResumeLayout(false);
            this.TimeBlockTitlePanel.ResumeLayout(false);
            this.SingleSchedulePanel.ResumeLayout(false);
            this.SingleSchedulePanel.PerformLayout();
            this.RegularSchedulePanel.ResumeLayout(false);
            this.RegularSchedulePanel.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSunday;
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
    }
}