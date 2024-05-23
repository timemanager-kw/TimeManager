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
            this.AddScheduleMemoPanel = new System.Windows.Forms.Panel();
            this.AddTaskMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddScheduleTimePanel = new System.Windows.Forms.Panel();
            this.AddTaskEndTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddTaskStartTime = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddSingleSchedulePanel = new System.Windows.Forms.Panel();
            this.AddShortTaskDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.AddCanclePanel = new System.Windows.Forms.Panel();
            this.AddTaskCancle = new System.Windows.Forms.Button();
            this.AddTask = new System.Windows.Forms.Button();
            this.AddRegularSchedulePanel = new System.Windows.Forms.Panel();
            this.AddSingleScheduleDaysPanel = new System.Windows.Forms.Panel();
            this.AddLongTaskIsTrue = new System.Windows.Forms.CheckBox();
            this.AddRegularScheduleDays = new System.Windows.Forms.GroupBox();
            this.AddLongTaskSun = new System.Windows.Forms.RadioButton();
            this.AddLongTaskSat = new System.Windows.Forms.RadioButton();
            this.AddLongTaskFri = new System.Windows.Forms.RadioButton();
            this.AddLongTaskThu = new System.Windows.Forms.RadioButton();
            this.AddLongTaskWed = new System.Windows.Forms.RadioButton();
            this.AddLongTaskTue = new System.Windows.Forms.RadioButton();
            this.AddLongTaskMon = new System.Windows.Forms.RadioButton();
            this.NamePanel = new System.Windows.Forms.Panel();
            this.AddTaskIsLong = new System.Windows.Forms.CheckBox();
            this.AddTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddScheduleMemoPanel.SuspendLayout();
            this.AddScheduleTimePanel.SuspendLayout();
            this.AddSingleSchedulePanel.SuspendLayout();
            this.AddCanclePanel.SuspendLayout();
            this.AddRegularSchedulePanel.SuspendLayout();
            this.AddSingleScheduleDaysPanel.SuspendLayout();
            this.AddRegularScheduleDays.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddScheduleMemoPanel
            // 
            this.AddScheduleMemoPanel.Controls.Add(this.AddTaskMemo);
            this.AddScheduleMemoPanel.Controls.Add(this.label5);
            this.AddScheduleMemoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddScheduleMemoPanel.Location = new System.Drawing.Point(0, 218);
            this.AddScheduleMemoPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleMemoPanel.Name = "AddScheduleMemoPanel";
            this.AddScheduleMemoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddScheduleMemoPanel.Size = new System.Drawing.Size(800, 187);
            this.AddScheduleMemoPanel.TabIndex = 31;
            // 
            // AddTaskMemo
            // 
            this.AddTaskMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTaskMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddTaskMemo.Location = new System.Drawing.Point(10, 50);
            this.AddTaskMemo.Margin = new System.Windows.Forms.Padding(10);
            this.AddTaskMemo.Multiline = true;
            this.AddTaskMemo.Name = "AddTaskMemo";
            this.AddTaskMemo.Size = new System.Drawing.Size(780, 127);
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
            // AddScheduleTimePanel
            // 
            this.AddScheduleTimePanel.Controls.Add(this.AddTaskEndTime);
            this.AddScheduleTimePanel.Controls.Add(this.label7);
            this.AddScheduleTimePanel.Controls.Add(this.AddTaskStartTime);
            this.AddScheduleTimePanel.Controls.Add(this.label8);
            this.AddScheduleTimePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddScheduleTimePanel.Location = new System.Drawing.Point(0, 171);
            this.AddScheduleTimePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleTimePanel.Name = "AddScheduleTimePanel";
            this.AddScheduleTimePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddScheduleTimePanel.Size = new System.Drawing.Size(800, 47);
            this.AddScheduleTimePanel.TabIndex = 30;
            // 
            // AddTaskEndTime
            // 
            this.AddTaskEndTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddTaskEndTime.Font = new System.Drawing.Font("굴림", 10F);
            this.AddTaskEndTime.FormattingEnabled = true;
            this.AddTaskEndTime.Location = new System.Drawing.Point(224, 10);
            this.AddTaskEndTime.Name = "AddTaskEndTime";
            this.AddTaskEndTime.Size = new System.Drawing.Size(143, 25);
            this.AddTaskEndTime.TabIndex = 8;
            this.AddTaskEndTime.Text = "00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(195, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = " ~ ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddTaskStartTime
            // 
            this.AddTaskStartTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddTaskStartTime.Font = new System.Drawing.Font("굴림", 10F);
            this.AddTaskStartTime.FormattingEnabled = true;
            this.AddTaskStartTime.Location = new System.Drawing.Point(52, 10);
            this.AddTaskStartTime.Name = "AddTaskStartTime";
            this.AddTaskStartTime.Size = new System.Drawing.Size(143, 25);
            this.AddTaskStartTime.TabIndex = 6;
            this.AddTaskStartTime.Text = "00:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "시간";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddSingleSchedulePanel
            // 
            this.AddSingleSchedulePanel.Controls.Add(this.AddShortTaskDatePicker);
            this.AddSingleSchedulePanel.Controls.Add(this.label2);
            this.AddSingleSchedulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddSingleSchedulePanel.Location = new System.Drawing.Point(0, 124);
            this.AddSingleSchedulePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddSingleSchedulePanel.Name = "AddSingleSchedulePanel";
            this.AddSingleSchedulePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddSingleSchedulePanel.Size = new System.Drawing.Size(800, 47);
            this.AddSingleSchedulePanel.TabIndex = 29;
            // 
            // AddShortTaskDatePicker
            // 
            this.AddShortTaskDatePicker.CustomFormat = "yyyy-MM-dd";
            this.AddShortTaskDatePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddShortTaskDatePicker.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddShortTaskDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddShortTaskDatePicker.Location = new System.Drawing.Point(52, 10);
            this.AddShortTaskDatePicker.Name = "AddShortTaskDatePicker";
            this.AddShortTaskDatePicker.Size = new System.Drawing.Size(200, 27);
            this.AddShortTaskDatePicker.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "날짜";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // 
            // AddRegularSchedulePanel
            // 
            this.AddRegularSchedulePanel.Controls.Add(this.AddSingleScheduleDaysPanel);
            this.AddRegularSchedulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddRegularSchedulePanel.Location = new System.Drawing.Point(0, 47);
            this.AddRegularSchedulePanel.Name = "AddRegularSchedulePanel";
            this.AddRegularSchedulePanel.Size = new System.Drawing.Size(800, 77);
            this.AddRegularSchedulePanel.TabIndex = 27;
            // 
            // AddSingleScheduleDaysPanel
            // 
            this.AddSingleScheduleDaysPanel.Controls.Add(this.AddLongTaskIsTrue);
            this.AddSingleScheduleDaysPanel.Controls.Add(this.AddRegularScheduleDays);
            this.AddSingleScheduleDaysPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddSingleScheduleDaysPanel.Location = new System.Drawing.Point(0, 0);
            this.AddSingleScheduleDaysPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddSingleScheduleDaysPanel.Name = "AddSingleScheduleDaysPanel";
            this.AddSingleScheduleDaysPanel.Padding = new System.Windows.Forms.Padding(6);
            this.AddSingleScheduleDaysPanel.Size = new System.Drawing.Size(800, 74);
            this.AddSingleScheduleDaysPanel.TabIndex = 15;
            // 
            // AddLongTaskIsTrue
            // 
            this.AddLongTaskIsTrue.AutoSize = true;
            this.AddLongTaskIsTrue.Location = new System.Drawing.Point(367, 36);
            this.AddLongTaskIsTrue.Margin = new System.Windows.Forms.Padding(10);
            this.AddLongTaskIsTrue.Name = "AddLongTaskIsTrue";
            this.AddLongTaskIsTrue.Size = new System.Drawing.Size(59, 19);
            this.AddLongTaskIsTrue.TabIndex = 4;
            this.AddLongTaskIsTrue.Text = "포함";
            this.AddLongTaskIsTrue.UseVisualStyleBackColor = true;
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
            this.AddRegularScheduleDays.Location = new System.Drawing.Point(6, 6);
            this.AddRegularScheduleDays.Name = "AddRegularScheduleDays";
            this.AddRegularScheduleDays.Size = new System.Drawing.Size(348, 62);
            this.AddRegularScheduleDays.TabIndex = 3;
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
            this.label1.Text = "일정";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.AddScheduleMemoPanel);
            this.Controls.Add(this.AddScheduleTimePanel);
            this.Controls.Add(this.AddSingleSchedulePanel);
            this.Controls.Add(this.AddCanclePanel);
            this.Controls.Add(this.AddRegularSchedulePanel);
            this.Controls.Add(this.NamePanel);
            this.Name = "AddTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.AddScheduleMemoPanel.ResumeLayout(false);
            this.AddScheduleMemoPanel.PerformLayout();
            this.AddScheduleTimePanel.ResumeLayout(false);
            this.AddScheduleTimePanel.PerformLayout();
            this.AddSingleSchedulePanel.ResumeLayout(false);
            this.AddSingleSchedulePanel.PerformLayout();
            this.AddCanclePanel.ResumeLayout(false);
            this.AddRegularSchedulePanel.ResumeLayout(false);
            this.AddSingleScheduleDaysPanel.ResumeLayout(false);
            this.AddSingleScheduleDaysPanel.PerformLayout();
            this.AddRegularScheduleDays.ResumeLayout(false);
            this.AddRegularScheduleDays.PerformLayout();
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddScheduleMemoPanel;
        private System.Windows.Forms.TextBox AddTaskMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel AddScheduleTimePanel;
        private System.Windows.Forms.ComboBox AddTaskEndTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox AddTaskStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel AddSingleSchedulePanel;
        private System.Windows.Forms.DateTimePicker AddShortTaskDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel AddCanclePanel;
        private System.Windows.Forms.Button AddTaskCancle;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.Panel AddRegularSchedulePanel;
        private System.Windows.Forms.Panel AddSingleScheduleDaysPanel;
        private System.Windows.Forms.CheckBox AddLongTaskIsTrue;
        private System.Windows.Forms.GroupBox AddRegularScheduleDays;
        private System.Windows.Forms.RadioButton AddLongTaskSun;
        private System.Windows.Forms.RadioButton AddLongTaskSat;
        private System.Windows.Forms.RadioButton AddLongTaskFri;
        private System.Windows.Forms.RadioButton AddLongTaskThu;
        private System.Windows.Forms.RadioButton AddLongTaskWed;
        private System.Windows.Forms.RadioButton AddLongTaskTue;
        private System.Windows.Forms.RadioButton AddLongTaskMon;
        private System.Windows.Forms.Panel NamePanel;
        private System.Windows.Forms.CheckBox AddTaskIsLong;
        private System.Windows.Forms.TextBox AddTaskName;
        private System.Windows.Forms.Label label1;
    }
}