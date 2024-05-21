namespace TimeManager.Forms
{
    partial class AddScheduleForm
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
            this.NamePanel = new System.Windows.Forms.Panel();
            this.AddScheduleIsRegular = new System.Windows.Forms.CheckBox();
            this.AddScheduleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddRegularSchedulePanel = new System.Windows.Forms.Panel();
            this.AddSingleScheduleDaysPanel = new System.Windows.Forms.Panel();
            this.AddRegularScheduleDays = new System.Windows.Forms.GroupBox();
            this.AddRegularScheduleMon = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleTue = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleWed = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleThu = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleFri = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleSat = new System.Windows.Forms.RadioButton();
            this.AddRegularScheduleSun = new System.Windows.Forms.RadioButton();
            this.AddSchedule = new System.Windows.Forms.Button();
            this.AddScheduleCancle = new System.Windows.Forms.Button();
            this.AddCanclePanel = new System.Windows.Forms.Panel();
            this.AddSingleSchedulePanel = new System.Windows.Forms.Panel();
            this.AddSingleScheduleDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.AddScheduleTimePanel = new System.Windows.Forms.Panel();
            this.AddRegularEndTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddRegularStartTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddScheduleMemoPanel = new System.Windows.Forms.Panel();
            this.AddScheduleMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NamePanel.SuspendLayout();
            this.AddRegularSchedulePanel.SuspendLayout();
            this.AddSingleScheduleDaysPanel.SuspendLayout();
            this.AddRegularScheduleDays.SuspendLayout();
            this.AddCanclePanel.SuspendLayout();
            this.AddSingleSchedulePanel.SuspendLayout();
            this.AddScheduleTimePanel.SuspendLayout();
            this.AddScheduleMemoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NamePanel
            // 
            this.NamePanel.Controls.Add(this.AddScheduleIsRegular);
            this.NamePanel.Controls.Add(this.AddScheduleName);
            this.NamePanel.Controls.Add(this.label1);
            this.NamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NamePanel.Location = new System.Drawing.Point(0, 0);
            this.NamePanel.Margin = new System.Windows.Forms.Padding(10);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Padding = new System.Windows.Forms.Padding(10);
            this.NamePanel.Size = new System.Drawing.Size(942, 47);
            this.NamePanel.TabIndex = 3;
            // 
            // AddScheduleIsRegular
            // 
            this.AddScheduleIsRegular.AutoSize = true;
            this.AddScheduleIsRegular.Location = new System.Drawing.Point(260, 12);
            this.AddScheduleIsRegular.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleIsRegular.Name = "AddScheduleIsRegular";
            this.AddScheduleIsRegular.Size = new System.Drawing.Size(94, 19);
            this.AddScheduleIsRegular.TabIndex = 3;
            this.AddScheduleIsRegular.Text = "정기 일정";
            this.AddScheduleIsRegular.UseVisualStyleBackColor = true;
            // 
            // AddScheduleName
            // 
            this.AddScheduleName.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddScheduleName.Location = new System.Drawing.Point(52, 10);
            this.AddScheduleName.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleName.Name = "AddScheduleName";
            this.AddScheduleName.Size = new System.Drawing.Size(200, 25);
            this.AddScheduleName.TabIndex = 2;
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
            // AddRegularSchedulePanel
            // 
            this.AddRegularSchedulePanel.Controls.Add(this.AddSingleScheduleDaysPanel);
            this.AddRegularSchedulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddRegularSchedulePanel.Location = new System.Drawing.Point(0, 47);
            this.AddRegularSchedulePanel.Name = "AddRegularSchedulePanel";
            this.AddRegularSchedulePanel.Size = new System.Drawing.Size(942, 77);
            this.AddRegularSchedulePanel.TabIndex = 19;
            // 
            // AddSingleScheduleDaysPanel
            // 
            this.AddSingleScheduleDaysPanel.Controls.Add(this.AddRegularScheduleDays);
            this.AddSingleScheduleDaysPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddSingleScheduleDaysPanel.Location = new System.Drawing.Point(0, 0);
            this.AddSingleScheduleDaysPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddSingleScheduleDaysPanel.Name = "AddSingleScheduleDaysPanel";
            this.AddSingleScheduleDaysPanel.Padding = new System.Windows.Forms.Padding(6);
            this.AddSingleScheduleDaysPanel.Size = new System.Drawing.Size(942, 74);
            this.AddSingleScheduleDaysPanel.TabIndex = 15;
            // 
            // AddRegularScheduleDays
            // 
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleSun);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleSat);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleFri);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleThu);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleWed);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleTue);
            this.AddRegularScheduleDays.Controls.Add(this.AddRegularScheduleMon);
            this.AddRegularScheduleDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddRegularScheduleDays.Font = new System.Drawing.Font("함초롬바탕 확장", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleDays.Location = new System.Drawing.Point(6, 6);
            this.AddRegularScheduleDays.Name = "AddRegularScheduleDays";
            this.AddRegularScheduleDays.Size = new System.Drawing.Size(930, 62);
            this.AddRegularScheduleDays.TabIndex = 3;
            this.AddRegularScheduleDays.TabStop = false;
            this.AddRegularScheduleDays.Text = "요일";
            // 
            // AddRegularScheduleMon
            // 
            this.AddRegularScheduleMon.AutoSize = true;
            this.AddRegularScheduleMon.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleMon.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleMon.Location = new System.Drawing.Point(3, 30);
            this.AddRegularScheduleMon.Name = "AddRegularScheduleMon";
            this.AddRegularScheduleMon.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleMon.TabIndex = 0;
            this.AddRegularScheduleMon.TabStop = true;
            this.AddRegularScheduleMon.Text = "월";
            this.AddRegularScheduleMon.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleTue
            // 
            this.AddRegularScheduleTue.AutoSize = true;
            this.AddRegularScheduleTue.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleTue.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleTue.Location = new System.Drawing.Point(50, 30);
            this.AddRegularScheduleTue.Name = "AddRegularScheduleTue";
            this.AddRegularScheduleTue.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleTue.TabIndex = 1;
            this.AddRegularScheduleTue.TabStop = true;
            this.AddRegularScheduleTue.Text = "화";
            this.AddRegularScheduleTue.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleWed
            // 
            this.AddRegularScheduleWed.AutoSize = true;
            this.AddRegularScheduleWed.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleWed.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleWed.Location = new System.Drawing.Point(97, 30);
            this.AddRegularScheduleWed.Name = "AddRegularScheduleWed";
            this.AddRegularScheduleWed.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleWed.TabIndex = 2;
            this.AddRegularScheduleWed.TabStop = true;
            this.AddRegularScheduleWed.Text = "수";
            this.AddRegularScheduleWed.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleThu
            // 
            this.AddRegularScheduleThu.AutoSize = true;
            this.AddRegularScheduleThu.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleThu.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleThu.Location = new System.Drawing.Point(144, 30);
            this.AddRegularScheduleThu.Name = "AddRegularScheduleThu";
            this.AddRegularScheduleThu.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleThu.TabIndex = 3;
            this.AddRegularScheduleThu.TabStop = true;
            this.AddRegularScheduleThu.Text = "목";
            this.AddRegularScheduleThu.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleFri
            // 
            this.AddRegularScheduleFri.AutoSize = true;
            this.AddRegularScheduleFri.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleFri.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleFri.Location = new System.Drawing.Point(191, 30);
            this.AddRegularScheduleFri.Name = "AddRegularScheduleFri";
            this.AddRegularScheduleFri.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleFri.TabIndex = 4;
            this.AddRegularScheduleFri.TabStop = true;
            this.AddRegularScheduleFri.Text = "금";
            this.AddRegularScheduleFri.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleSat
            // 
            this.AddRegularScheduleSat.AutoSize = true;
            this.AddRegularScheduleSat.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleSat.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleSat.ForeColor = System.Drawing.Color.SteelBlue;
            this.AddRegularScheduleSat.Location = new System.Drawing.Point(238, 30);
            this.AddRegularScheduleSat.Name = "AddRegularScheduleSat";
            this.AddRegularScheduleSat.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleSat.TabIndex = 5;
            this.AddRegularScheduleSat.TabStop = true;
            this.AddRegularScheduleSat.Text = "토";
            this.AddRegularScheduleSat.UseVisualStyleBackColor = true;
            // 
            // AddRegularScheduleSun
            // 
            this.AddRegularScheduleSun.AutoSize = true;
            this.AddRegularScheduleSun.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularScheduleSun.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularScheduleSun.ForeColor = System.Drawing.Color.Crimson;
            this.AddRegularScheduleSun.Location = new System.Drawing.Point(285, 30);
            this.AddRegularScheduleSun.Name = "AddRegularScheduleSun";
            this.AddRegularScheduleSun.Size = new System.Drawing.Size(47, 29);
            this.AddRegularScheduleSun.TabIndex = 6;
            this.AddRegularScheduleSun.TabStop = true;
            this.AddRegularScheduleSun.Text = "일";
            this.AddRegularScheduleSun.UseVisualStyleBackColor = true;
            // 
            // AddSchedule
            // 
            this.AddSchedule.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddSchedule.Font = new System.Drawing.Font("함초롬바탕 확장", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddSchedule.Location = new System.Drawing.Point(863, 4);
            this.AddSchedule.Name = "AddSchedule";
            this.AddSchedule.Size = new System.Drawing.Size(75, 37);
            this.AddSchedule.TabIndex = 20;
            this.AddSchedule.Text = "추가";
            this.AddSchedule.UseVisualStyleBackColor = true;
            // 
            // AddScheduleCancle
            // 
            this.AddScheduleCancle.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddScheduleCancle.Font = new System.Drawing.Font("함초롬바탕 확장", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddScheduleCancle.Location = new System.Drawing.Point(788, 4);
            this.AddScheduleCancle.Name = "AddScheduleCancle";
            this.AddScheduleCancle.Size = new System.Drawing.Size(75, 37);
            this.AddScheduleCancle.TabIndex = 21;
            this.AddScheduleCancle.Text = "취소";
            this.AddScheduleCancle.UseVisualStyleBackColor = true;
            // 
            // AddCanclePanel
            // 
            this.AddCanclePanel.Controls.Add(this.AddScheduleCancle);
            this.AddCanclePanel.Controls.Add(this.AddSchedule);
            this.AddCanclePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddCanclePanel.Location = new System.Drawing.Point(0, 477);
            this.AddCanclePanel.Margin = new System.Windows.Forms.Padding(5);
            this.AddCanclePanel.Name = "AddCanclePanel";
            this.AddCanclePanel.Padding = new System.Windows.Forms.Padding(4);
            this.AddCanclePanel.Size = new System.Drawing.Size(942, 45);
            this.AddCanclePanel.TabIndex = 20;
            // 
            // AddSingleSchedulePanel
            // 
            this.AddSingleSchedulePanel.Controls.Add(this.AddSingleScheduleDatePicker);
            this.AddSingleSchedulePanel.Controls.Add(this.label2);
            this.AddSingleSchedulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddSingleSchedulePanel.Location = new System.Drawing.Point(0, 124);
            this.AddSingleSchedulePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddSingleSchedulePanel.Name = "AddSingleSchedulePanel";
            this.AddSingleSchedulePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddSingleSchedulePanel.Size = new System.Drawing.Size(942, 47);
            this.AddSingleSchedulePanel.TabIndex = 21;
            // 
            // AddSingleScheduleDatePicker
            // 
            this.AddSingleScheduleDatePicker.CustomFormat = "yyyy-MM-dd";
            this.AddSingleScheduleDatePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddSingleScheduleDatePicker.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddSingleScheduleDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddSingleScheduleDatePicker.Location = new System.Drawing.Point(52, 10);
            this.AddSingleScheduleDatePicker.Name = "AddSingleScheduleDatePicker";
            this.AddSingleScheduleDatePicker.Size = new System.Drawing.Size(200, 27);
            this.AddSingleScheduleDatePicker.TabIndex = 15;
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
            // AddScheduleTimePanel
            // 
            this.AddScheduleTimePanel.Controls.Add(this.AddRegularEndTime);
            this.AddScheduleTimePanel.Controls.Add(this.label7);
            this.AddScheduleTimePanel.Controls.Add(this.AddRegularStartTime);
            this.AddScheduleTimePanel.Controls.Add(this.label8);
            this.AddScheduleTimePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddScheduleTimePanel.Location = new System.Drawing.Point(0, 171);
            this.AddScheduleTimePanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleTimePanel.Name = "AddScheduleTimePanel";
            this.AddScheduleTimePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddScheduleTimePanel.Size = new System.Drawing.Size(942, 47);
            this.AddScheduleTimePanel.TabIndex = 23;
            // 
            // AddRegularEndTime
            // 
            this.AddRegularEndTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularEndTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularEndTime.Location = new System.Drawing.Point(224, 10);
            this.AddRegularEndTime.Margin = new System.Windows.Forms.Padding(10);
            this.AddRegularEndTime.Name = "AddRegularEndTime";
            this.AddRegularEndTime.Size = new System.Drawing.Size(143, 27);
            this.AddRegularEndTime.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(195, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = " ~ ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddRegularStartTime
            // 
            this.AddRegularStartTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddRegularStartTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddRegularStartTime.Location = new System.Drawing.Point(52, 10);
            this.AddRegularStartTime.Margin = new System.Windows.Forms.Padding(10);
            this.AddRegularStartTime.Name = "AddRegularStartTime";
            this.AddRegularStartTime.Size = new System.Drawing.Size(143, 27);
            this.AddRegularStartTime.TabIndex = 3;
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
            // AddScheduleMemoPanel
            // 
            this.AddScheduleMemoPanel.Controls.Add(this.AddScheduleMemo);
            this.AddScheduleMemoPanel.Controls.Add(this.label5);
            this.AddScheduleMemoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddScheduleMemoPanel.Location = new System.Drawing.Point(0, 218);
            this.AddScheduleMemoPanel.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleMemoPanel.Name = "AddScheduleMemoPanel";
            this.AddScheduleMemoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.AddScheduleMemoPanel.Size = new System.Drawing.Size(942, 259);
            this.AddScheduleMemoPanel.TabIndex = 25;
            // 
            // AddScheduleMemo
            // 
            this.AddScheduleMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddScheduleMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddScheduleMemo.Location = new System.Drawing.Point(10, 50);
            this.AddScheduleMemo.Margin = new System.Windows.Forms.Padding(10);
            this.AddScheduleMemo.Multiline = true;
            this.AddScheduleMemo.Name = "AddScheduleMemo";
            this.AddScheduleMemo.Size = new System.Drawing.Size(922, 199);
            this.AddScheduleMemo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("함초롬바탕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(922, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "메모";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 522);
            this.ControlBox = false;
            this.Controls.Add(this.AddScheduleMemoPanel);
            this.Controls.Add(this.AddScheduleTimePanel);
            this.Controls.Add(this.AddSingleSchedulePanel);
            this.Controls.Add(this.AddCanclePanel);
            this.Controls.Add(this.AddRegularSchedulePanel);
            this.Controls.Add(this.NamePanel);
            this.Name = "AddScheduleForm";
            this.ShowIcon = false;
            this.TopMost = true;
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.AddRegularSchedulePanel.ResumeLayout(false);
            this.AddSingleScheduleDaysPanel.ResumeLayout(false);
            this.AddRegularScheduleDays.ResumeLayout(false);
            this.AddRegularScheduleDays.PerformLayout();
            this.AddCanclePanel.ResumeLayout(false);
            this.AddSingleSchedulePanel.ResumeLayout(false);
            this.AddSingleSchedulePanel.PerformLayout();
            this.AddScheduleTimePanel.ResumeLayout(false);
            this.AddScheduleTimePanel.PerformLayout();
            this.AddScheduleMemoPanel.ResumeLayout(false);
            this.AddScheduleMemoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NamePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddScheduleName;
        private System.Windows.Forms.CheckBox AddScheduleIsRegular;
        private System.Windows.Forms.Panel AddRegularSchedulePanel;
        private System.Windows.Forms.Panel AddSingleScheduleDaysPanel;
        private System.Windows.Forms.GroupBox AddRegularScheduleDays;
        private System.Windows.Forms.RadioButton AddRegularScheduleSun;
        private System.Windows.Forms.RadioButton AddRegularScheduleSat;
        private System.Windows.Forms.RadioButton AddRegularScheduleFri;
        private System.Windows.Forms.RadioButton AddRegularScheduleThu;
        private System.Windows.Forms.RadioButton AddRegularScheduleWed;
        private System.Windows.Forms.RadioButton AddRegularScheduleTue;
        private System.Windows.Forms.RadioButton AddRegularScheduleMon;
        private System.Windows.Forms.Button AddSchedule;
        private System.Windows.Forms.Button AddScheduleCancle;
        private System.Windows.Forms.Panel AddCanclePanel;
        private System.Windows.Forms.Panel AddSingleSchedulePanel;
        private System.Windows.Forms.DateTimePicker AddSingleScheduleDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel AddScheduleTimePanel;
        private System.Windows.Forms.TextBox AddRegularEndTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AddRegularStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel AddScheduleMemoPanel;
        private System.Windows.Forms.TextBox AddScheduleMemo;
        private System.Windows.Forms.Label label5;
    }
}