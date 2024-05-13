namespace TimeManager.Forms
{
    partial class ScheduleSelectedPanel
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.MinTimeCmb = new System.Windows.Forms.ComboBox();
            this.MinTimeLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TaskTypeCmb = new System.Windows.Forms.ComboBox();
            this.TaskTypeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TaskName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.MinTimeCmb);
            this.panel4.Controls.Add(this.MinTimeLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 153);
            this.panel4.Margin = new System.Windows.Forms.Padding(10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(259, 37);
            this.panel4.TabIndex = 20;
            // 
            // MinTimeCmb
            // 
            this.MinTimeCmb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinTimeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinTimeCmb.FormattingEnabled = true;
            this.MinTimeCmb.Location = new System.Drawing.Point(106, 6);
            this.MinTimeCmb.Name = "MinTimeCmb";
            this.MinTimeCmb.Size = new System.Drawing.Size(147, 23);
            this.MinTimeCmb.TabIndex = 8;
            // 
            // MinTimeLabel
            // 
            this.MinTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MinTimeLabel.Location = new System.Drawing.Point(6, 6);
            this.MinTimeLabel.Name = "MinTimeLabel";
            this.MinTimeLabel.Size = new System.Drawing.Size(100, 25);
            this.MinTimeLabel.TabIndex = 3;
            this.MinTimeLabel.Text = "최소 시간";
            this.MinTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.EndDatePicker);
            this.panel3.Controls.Add(this.EndDateLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6);
            this.panel3.Size = new System.Drawing.Size(259, 37);
            this.panel3.TabIndex = 19;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd";
            this.EndDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(106, 6);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(147, 25);
            this.EndDatePicker.TabIndex = 4;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.EndDateLabel.Location = new System.Drawing.Point(6, 6);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(100, 25);
            this.EndDateLabel.TabIndex = 3;
            this.EndDateLabel.Text = "*마감일";
            this.EndDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StartDatePicker);
            this.panel2.Controls.Add(this.StartDateLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 79);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(259, 37);
            this.panel2.TabIndex = 18;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd";
            this.StartDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(106, 6);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(147, 25);
            this.StartDatePicker.TabIndex = 4;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartDateLabel.Location = new System.Drawing.Point(6, 6);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(100, 25);
            this.StartDateLabel.TabIndex = 3;
            this.StartDateLabel.Text = "예정 시작일";
            this.StartDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TaskTypeCmb);
            this.panel5.Controls.Add(this.TaskTypeLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 42);
            this.panel5.Margin = new System.Windows.Forms.Padding(10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(6);
            this.panel5.Size = new System.Drawing.Size(259, 37);
            this.panel5.TabIndex = 17;
            // 
            // TaskTypeCmb
            // 
            this.TaskTypeCmb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskTypeCmb.FormattingEnabled = true;
            this.TaskTypeCmb.Items.AddRange(new object[] {
            "일시적",
            "정기적"});
            this.TaskTypeCmb.Location = new System.Drawing.Point(106, 6);
            this.TaskTypeCmb.Name = "TaskTypeCmb";
            this.TaskTypeCmb.Size = new System.Drawing.Size(147, 23);
            this.TaskTypeCmb.TabIndex = 4;
            // 
            // TaskTypeLabel
            // 
            this.TaskTypeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskTypeLabel.Location = new System.Drawing.Point(6, 6);
            this.TaskTypeLabel.Name = "TaskTypeLabel";
            this.TaskTypeLabel.Size = new System.Drawing.Size(100, 25);
            this.TaskTypeLabel.TabIndex = 3;
            this.TaskTypeLabel.Text = "*업무 유형";
            this.TaskTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TaskName);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(259, 37);
            this.panel1.TabIndex = 16;
            // 
            // TaskName
            // 
            this.TaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskName.Location = new System.Drawing.Point(106, 6);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(147, 25);
            this.TaskName.TabIndex = 4;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NameLabel.Location = new System.Drawing.Point(6, 6);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(100, 25);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "*업무 명";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScheduleSelectedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 288);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "ScheduleSelectedPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ScheduleSelectedPanel_Load);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox MinTimeCmb;
        private System.Windows.Forms.Label MinTimeLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox TaskTypeCmb;
        private System.Windows.Forms.Label TaskTypeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TaskName;
        private System.Windows.Forms.Label NameLabel;
    }
}