namespace TimeManager.Forms
{
    partial class AddTaskForm
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
            this.AddTaskMemoPanel = new System.Windows.Forms.Panel();
            this.AddTaskMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddCanclePanel = new System.Windows.Forms.Panel();
            this.AddTaskCancle = new System.Windows.Forms.Button();
            this.AddTask = new System.Windows.Forms.Button();
            this.AddShortTaskPanel = new System.Windows.Forms.Panel();
            this.AddShortTaskStartDatePanel = new System.Windows.Forms.Panel();
            this.AddShortTaskStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.AddShortTaskEndDatePanel = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.AddShortTaskEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.NamePanel = new System.Windows.Forms.Panel();
            this.AddTaskIsLong = new System.Windows.Forms.CheckBox();
            this.AddTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddLongTaskPanel = new System.Windows.Forms.Panel();
            this.AddLongTaskIsTrue = new System.Windows.Forms.CheckBox();
            this.AddRegularScheduleDays = new System.Windows.Forms.GroupBox();
            this.AddLongTaskSun = new System.Windows.Forms.RadioButton();
            this.AddLongTaskSat = new System.Windows.Forms.RadioButton();
            this.AddLongTaskFri = new System.Windows.Forms.RadioButton();
            this.AddLongTaskThu = new System.Windows.Forms.RadioButton();
            this.AddLongTaskWed = new System.Windows.Forms.RadioButton();
            this.AddLongTaskTue = new System.Windows.Forms.RadioButton();
            this.AddLongTaskMon = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.TaskDurationCmb = new System.Windows.Forms.ComboBox();
            this.AddTaskTimePanel = new System.Windows.Forms.Panel();
            this.AddTaskMemoPanel.SuspendLayout();
            this.AddCanclePanel.SuspendLayout();
            this.AddShortTaskPanel.SuspendLayout();
            this.AddShortTaskStartDatePanel.SuspendLayout();
            this.AddShortTaskEndDatePanel.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.AddLongTaskPanel.SuspendLayout();
            this.AddRegularScheduleDays.SuspendLayout();
            this.AddTaskTimePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTaskMemoPanel
            // 
            this.AddTaskMemoPanel.Controls.Add(this.AddTaskMemo);
            this.AddTaskMemoPanel.Controls.Add(this.label5);
            this.AddTaskMemoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTaskMemoPanel.Location = new System.Drawing.Point(0, 257);
            this.AddTaskMemoPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskMemoPanel.Name = "AddTaskMemoPanel";
            this.AddTaskMemoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddTaskMemoPanel.Size = new System.Drawing.Size(800, 148);
            this.AddTaskMemoPanel.TabIndex = 31;
            // 
            // AddTaskMemo
            // 
            this.AddTaskMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTaskMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddTaskMemo.Location = new System.Drawing.Point(10, 50);
            this.AddTaskMemo.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskMemo.Multiline = true;
            this.AddTaskMemo.Name = "AddTaskMemo";
            this.AddTaskMemo.Size = new System.Drawing.Size(780, 88);
            this.AddTaskMemo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(780, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "메모";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddCanclePanel
            // 
            this.AddCanclePanel.Controls.Add(this.AddTaskCancle);
            this.AddCanclePanel.Controls.Add(this.AddTask);
            this.AddCanclePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddCanclePanel.Location = new System.Drawing.Point(0, 405);
            this.AddCanclePanel.Margin = new System.Windows.Forms.Padding(5);
            this.AddCanclePanel.Name = "AddCanclePanel";
            this.AddCanclePanel.Padding = new System.Windows.Forms.Padding(4);
            this.AddCanclePanel.Size = new System.Drawing.Size(800, 45);
            this.AddCanclePanel.TabIndex = 28;
            // 
            // AddTaskCancle
            // 
            this.AddTaskCancle.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddTaskCancle.Font = new System.Drawing.Font("함초롬바탕 확장", 11F);
            this.AddTaskCancle.Location = new System.Drawing.Point(646, 4);
            this.AddTaskCancle.Name = "AddTaskCancle";
            this.AddTaskCancle.Size = new System.Drawing.Size(75, 37);
            this.AddTaskCancle.TabIndex = 21;
            this.AddTaskCancle.Text = "취소";
            this.AddTaskCancle.UseVisualStyleBackColor = true;
            this.AddTaskCancle.Click += new System.EventHandler(this.AddTaskCancle_Click);
            // 
            // AddTask
            // 
            this.AddTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddTask.Font = new System.Drawing.Font("함초롬바탕 확장", 11F);
            this.AddTask.Location = new System.Drawing.Point(721, 4);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(75, 37);
            this.AddTask.TabIndex = 20;
            this.AddTask.Text = "추가";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // AddShortTaskPanel
            // 
            this.AddShortTaskPanel.Controls.Add(this.AddShortTaskStartDatePanel);
            this.AddShortTaskPanel.Controls.Add(this.AddShortTaskEndDatePanel);
            this.AddShortTaskPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddShortTaskPanel.Location = new System.Drawing.Point(0, 47);
            this.AddShortTaskPanel.Name = "AddShortTaskPanel";
            this.AddShortTaskPanel.Size = new System.Drawing.Size(800, 81);
            this.AddShortTaskPanel.TabIndex = 27;
            // 
            // AddShortTaskStartDatePanel
            // 
            this.AddShortTaskStartDatePanel.Controls.Add(this.AddShortTaskStartDatePicker);
            this.AddShortTaskStartDatePanel.Controls.Add(this.label3);
            this.AddShortTaskStartDatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddShortTaskStartDatePanel.Location = new System.Drawing.Point(0, 40);
            this.AddShortTaskStartDatePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddShortTaskStartDatePanel.Name = "AddShortTaskStartDatePanel";
            this.AddShortTaskStartDatePanel.Padding = new System.Windows.Forms.Padding(6);
            this.AddShortTaskStartDatePanel.Size = new System.Drawing.Size(800, 40);
            this.AddShortTaskStartDatePanel.TabIndex = 16;
            // 
            // AddShortTaskStartDatePicker
            // 
            this.AddShortTaskStartDatePicker.CustomFormat = "yyyy-MM-dd";
            this.AddShortTaskStartDatePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddShortTaskStartDatePicker.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddShortTaskStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddShortTaskStartDatePicker.Location = new System.Drawing.Point(64, 6);
            this.AddShortTaskStartDatePicker.Name = "AddShortTaskStartDatePicker";
            this.AddShortTaskStartDatePicker.Size = new System.Drawing.Size(200, 27);
            this.AddShortTaskStartDatePicker.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "시작일";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddShortTaskEndDatePanel
            // 
            this.AddShortTaskEndDatePanel.Controls.Add(this.checkBox1);
            this.AddShortTaskEndDatePanel.Controls.Add(this.AddShortTaskEndDatePicker);
            this.AddShortTaskEndDatePanel.Controls.Add(this.label2);
            this.AddShortTaskEndDatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddShortTaskEndDatePanel.Location = new System.Drawing.Point(0, 0);
            this.AddShortTaskEndDatePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddShortTaskEndDatePanel.Name = "AddShortTaskEndDatePanel";
            this.AddShortTaskEndDatePanel.Padding = new System.Windows.Forms.Padding(6);
            this.AddShortTaskEndDatePanel.Size = new System.Drawing.Size(800, 40);
            this.AddShortTaskEndDatePanel.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(277, 14);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 19);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "마감일 포함";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AddShortTaskEndDatePicker
            // 
            this.AddShortTaskEndDatePicker.CustomFormat = "yyyy-MM-dd";
            this.AddShortTaskEndDatePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddShortTaskEndDatePicker.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddShortTaskEndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddShortTaskEndDatePicker.Location = new System.Drawing.Point(64, 6);
            this.AddShortTaskEndDatePicker.Name = "AddShortTaskEndDatePicker";
            this.AddShortTaskEndDatePicker.Size = new System.Drawing.Size(200, 27);
            this.AddShortTaskEndDatePicker.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "마감일";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NamePanel
            // 
            this.NamePanel.Controls.Add(this.AddTaskIsLong);
            this.NamePanel.Controls.Add(this.AddTaskName);
            this.NamePanel.Controls.Add(this.label1);
            this.NamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NamePanel.Location = new System.Drawing.Point(0, 0);
            this.NamePanel.Margin = new System.Windows.Forms.Padding(10);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Padding = new System.Windows.Forms.Padding(10);
            this.NamePanel.Size = new System.Drawing.Size(800, 47);
            this.NamePanel.TabIndex = 26;
            // 
            // AddTaskIsLong
            // 
            this.AddTaskIsLong.AutoSize = true;
            this.AddTaskIsLong.Location = new System.Drawing.Point(260, 12);
            this.AddTaskIsLong.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskIsLong.Name = "AddTaskIsLong";
            this.AddTaskIsLong.Size = new System.Drawing.Size(94, 19);
            this.AddTaskIsLong.TabIndex = 3;
            this.AddTaskIsLong.Text = "정기 업무";
            this.AddTaskIsLong.UseVisualStyleBackColor = true;
            this.AddTaskIsLong.CheckedChanged += new System.EventHandler(this.AddTaskIsLong_CheckedChanged);
            // 
            // AddTaskName
            // 
            this.AddTaskName.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddTaskName.Location = new System.Drawing.Point(52, 10);
            this.AddTaskName.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskName.Name = "AddTaskName";
            this.AddTaskName.Size = new System.Drawing.Size(200, 25);
            this.AddTaskName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "업무";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddLongTaskPanel
            // 
            this.AddLongTaskPanel.Controls.Add(this.AddLongTaskIsTrue);
            this.AddLongTaskPanel.Controls.Add(this.AddRegularScheduleDays);
            this.AddLongTaskPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddLongTaskPanel.Location = new System.Drawing.Point(0, 128);
            this.AddLongTaskPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddLongTaskPanel.Name = "AddLongTaskPanel";
            this.AddLongTaskPanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddLongTaskPanel.Size = new System.Drawing.Size(800, 82);
            this.AddLongTaskPanel.TabIndex = 29;
            // 
            // AddLongTaskIsTrue
            // 
            this.AddLongTaskIsTrue.AutoSize = true;
            this.AddLongTaskIsTrue.Location = new System.Drawing.Point(371, 35);
            this.AddLongTaskIsTrue.Margin = new System.Windows.Forms.Padding(10);
            this.AddLongTaskIsTrue.Name = "AddLongTaskIsTrue";
            this.AddLongTaskIsTrue.Size = new System.Drawing.Size(59, 19);
            this.AddLongTaskIsTrue.TabIndex = 17;
            this.AddLongTaskIsTrue.Text = "포함";
            this.AddLongTaskIsTrue.UseVisualStyleBackColor = true;
            this.AddLongTaskIsTrue.CheckedChanged += new System.EventHandler(this.AddLongTaskIsTrue_CheckedChanged);
            // 
            // AddRegularScheduleDays
            // 
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskSun);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskSat);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskFri);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskThu);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskWed);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskTue);
            this.AddRegularScheduleDays.Controls.Add(this.AddLongTaskMon);
            this.AddRegularScheduleDays.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleDays.Font = new System.Drawing.Font("함초롬바탕 확장", 10F);
            this.AddRegularScheduleDays.Location = new System.Drawing.Point(10, 10);
            this.AddRegularScheduleDays.Name = "AddRegularScheduleDays";
            this.AddRegularScheduleDays.Size = new System.Drawing.Size(348, 62);
            this.AddRegularScheduleDays.TabIndex = 16;
            this.AddRegularScheduleDays.TabStop = false;
            this.AddRegularScheduleDays.Text = "요일";
            // 
            // AddLongTaskSun
            // 
            this.AddLongTaskSun.AutoSize = true;
            this.AddLongTaskSun.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskSun.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskSun.ForeColor = System.Drawing.Color.Crimson;
            this.AddLongTaskSun.Location = new System.Drawing.Point(285, 25);
            this.AddLongTaskSun.Name = "AddLongTaskSun";
            this.AddLongTaskSun.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskSun.TabIndex = 6;
            this.AddLongTaskSun.TabStop = true;
            this.AddLongTaskSun.Text = "일";
            this.AddLongTaskSun.UseVisualStyleBackColor = true;
            this.AddLongTaskSun.CheckedChanged += new System.EventHandler(this.AddLongTaskSun_CheckedChanged);
            // 
            // AddLongTaskSat
            // 
            this.AddLongTaskSat.AutoSize = true;
            this.AddLongTaskSat.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskSat.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskSat.ForeColor = System.Drawing.Color.SteelBlue;
            this.AddLongTaskSat.Location = new System.Drawing.Point(238, 25);
            this.AddLongTaskSat.Name = "AddLongTaskSat";
            this.AddLongTaskSat.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskSat.TabIndex = 5;
            this.AddLongTaskSat.TabStop = true;
            this.AddLongTaskSat.Text = "토";
            this.AddLongTaskSat.UseVisualStyleBackColor = true;
            this.AddLongTaskSat.CheckedChanged += new System.EventHandler(this.AddLongTaskSat_CheckedChanged);
            // 
            // AddLongTaskFri
            // 
            this.AddLongTaskFri.AutoSize = true;
            this.AddLongTaskFri.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskFri.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskFri.Location = new System.Drawing.Point(191, 25);
            this.AddLongTaskFri.Name = "AddLongTaskFri";
            this.AddLongTaskFri.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskFri.TabIndex = 4;
            this.AddLongTaskFri.TabStop = true;
            this.AddLongTaskFri.Text = "금";
            this.AddLongTaskFri.UseVisualStyleBackColor = true;
            this.AddLongTaskFri.CheckedChanged += new System.EventHandler(this.AddLongTaskFri_CheckedChanged);
            // 
            // AddLongTaskThu
            // 
            this.AddLongTaskThu.AutoSize = true;
            this.AddLongTaskThu.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskThu.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskThu.Location = new System.Drawing.Point(144, 25);
            this.AddLongTaskThu.Name = "AddLongTaskThu";
            this.AddLongTaskThu.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskThu.TabIndex = 3;
            this.AddLongTaskThu.TabStop = true;
            this.AddLongTaskThu.Text = "목";
            this.AddLongTaskThu.UseVisualStyleBackColor = true;
            this.AddLongTaskThu.CheckedChanged += new System.EventHandler(this.AddLongTaskThu_CheckedChanged);
            // 
            // AddLongTaskWed
            // 
            this.AddLongTaskWed.AutoSize = true;
            this.AddLongTaskWed.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskWed.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskWed.Location = new System.Drawing.Point(97, 25);
            this.AddLongTaskWed.Name = "AddLongTaskWed";
            this.AddLongTaskWed.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskWed.TabIndex = 2;
            this.AddLongTaskWed.TabStop = true;
            this.AddLongTaskWed.Text = "수";
            this.AddLongTaskWed.UseVisualStyleBackColor = true;
            this.AddLongTaskWed.CheckedChanged += new System.EventHandler(this.AddLongTaskWed_CheckedChanged);
            // 
            // AddLongTaskTue
            // 
            this.AddLongTaskTue.AutoSize = true;
            this.AddLongTaskTue.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskTue.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskTue.Location = new System.Drawing.Point(50, 25);
            this.AddLongTaskTue.Name = "AddLongTaskTue";
            this.AddLongTaskTue.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskTue.TabIndex = 1;
            this.AddLongTaskTue.TabStop = true;
            this.AddLongTaskTue.Text = "화";
            this.AddLongTaskTue.UseVisualStyleBackColor = true;
            this.AddLongTaskTue.CheckedChanged += new System.EventHandler(this.AddLongTaskTue_CheckedChanged);
            // 
            // AddLongTaskMon
            // 
            this.AddLongTaskMon.AutoSize = true;
            this.AddLongTaskMon.Checked = true;
            this.AddLongTaskMon.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddLongTaskMon.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddLongTaskMon.Location = new System.Drawing.Point(3, 25);
            this.AddLongTaskMon.Name = "AddLongTaskMon";
            this.AddLongTaskMon.Size = new System.Drawing.Size(47, 34);
            this.AddLongTaskMon.TabIndex = 0;
            this.AddLongTaskMon.TabStop = true;
            this.AddLongTaskMon.Text = "월";
            this.AddLongTaskMon.UseVisualStyleBackColor = true;
            this.AddLongTaskMon.CheckedChanged += new System.EventHandler(this.AddLongTaskMon_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "수행시간";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaskDurationCmb
            // 
            this.TaskDurationCmb.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskDurationCmb.Font = new System.Drawing.Font("굴림", 10F);
            this.TaskDurationCmb.FormattingEnabled = true;
            this.TaskDurationCmb.Location = new System.Drawing.Point(84, 10);
            this.TaskDurationCmb.Name = "TaskDurationCmb";
            this.TaskDurationCmb.Size = new System.Drawing.Size(143, 25);
            this.TaskDurationCmb.TabIndex = 6;
            this.TaskDurationCmb.Text = "00:00";
            // 
            // AddTaskTimePanel
            // 
            this.AddTaskTimePanel.Controls.Add(this.TaskDurationCmb);
            this.AddTaskTimePanel.Controls.Add(this.label8);
            this.AddTaskTimePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddTaskTimePanel.Location = new System.Drawing.Point(0, 210);
            this.AddTaskTimePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskTimePanel.Name = "AddTaskTimePanel";
            this.AddTaskTimePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddTaskTimePanel.Size = new System.Drawing.Size(800, 47);
            this.AddTaskTimePanel.TabIndex = 30;
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.AddTaskMemoPanel);
            this.Controls.Add(this.AddTaskTimePanel);
            this.Controls.Add(this.AddLongTaskPanel);
            this.Controls.Add(this.AddCanclePanel);
            this.Controls.Add(this.AddShortTaskPanel);
            this.Controls.Add(this.NamePanel);
            this.Name = "AddTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.AddTaskMemoPanel.ResumeLayout(false);
            this.AddTaskMemoPanel.PerformLayout();
            this.AddCanclePanel.ResumeLayout(false);
            this.AddShortTaskPanel.ResumeLayout(false);
            this.AddShortTaskStartDatePanel.ResumeLayout(false);
            this.AddShortTaskStartDatePanel.PerformLayout();
            this.AddShortTaskEndDatePanel.ResumeLayout(false);
            this.AddShortTaskEndDatePanel.PerformLayout();
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.AddLongTaskPanel.ResumeLayout(false);
            this.AddLongTaskPanel.PerformLayout();
            this.AddRegularScheduleDays.ResumeLayout(false);
            this.AddRegularScheduleDays.PerformLayout();
            this.AddTaskTimePanel.ResumeLayout(false);
            this.AddTaskTimePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddTaskMemoPanel;
        private System.Windows.Forms.TextBox AddTaskMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel AddCanclePanel;
        private System.Windows.Forms.Button AddTaskCancle;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.Panel AddShortTaskPanel;
        private System.Windows.Forms.Panel NamePanel;
        private System.Windows.Forms.CheckBox AddTaskIsLong;
        private System.Windows.Forms.TextBox AddTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel AddLongTaskPanel;
        private System.Windows.Forms.Panel AddShortTaskEndDatePanel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker AddShortTaskEndDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AddLongTaskIsTrue;
        private System.Windows.Forms.GroupBox AddRegularScheduleDays;
        private System.Windows.Forms.RadioButton AddLongTaskSun;
        private System.Windows.Forms.RadioButton AddLongTaskSat;
        private System.Windows.Forms.RadioButton AddLongTaskFri;
        private System.Windows.Forms.RadioButton AddLongTaskThu;
        private System.Windows.Forms.RadioButton AddLongTaskWed;
        private System.Windows.Forms.RadioButton AddLongTaskTue;
        private System.Windows.Forms.RadioButton AddLongTaskMon;
        private System.Windows.Forms.Panel AddShortTaskStartDatePanel;
        private System.Windows.Forms.DateTimePicker AddShortTaskStartDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox TaskDurationCmb;
        private System.Windows.Forms.Panel AddTaskTimePanel;
    }
}