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
            this.TimeBlockSettingPanel = new System.Windows.Forms.Panel();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.TimeBlockPanel = new System.Windows.Forms.Panel();
            this.TimeBlockView = new System.Windows.Forms.ListView();
            this.TimeBlockTitlePanel = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TaskBtn = new System.Windows.Forms.Button();
            this.ScheduleBtn = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.NextBtn = new System.Windows.Forms.Button();
            this.WeekLabel = new System.Windows.Forms.Label();
            this.AlgorithmStarter = new System.Windows.Forms.Button();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.CalendarPanel = new System.Windows.Forms.Panel();
            this.TimeBlockSettingPanel.SuspendLayout();
            this.TimeBlockPanel.SuspendLayout();
            this.TimeBlockTitlePanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeBlockSettingPanel
            // 
            this.TimeBlockSettingPanel.Controls.Add(this.AddPanel);
            this.TimeBlockSettingPanel.Controls.Add(this.TimeBlockPanel);
            this.TimeBlockSettingPanel.Controls.Add(this.TimeBlockTitlePanel);
            this.TimeBlockSettingPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TimeBlockSettingPanel.Location = new System.Drawing.Point(741, 0);
            this.TimeBlockSettingPanel.Name = "TimeBlockSettingPanel";
            this.TimeBlockSettingPanel.Size = new System.Drawing.Size(200, 493);
            this.TimeBlockSettingPanel.TabIndex = 2;
            // 
            // AddPanel
            // 
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPanel.Location = new System.Drawing.Point(0, 290);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Padding = new System.Windows.Forms.Padding(5);
            this.AddPanel.Size = new System.Drawing.Size(200, 203);
            this.AddPanel.TabIndex = 3;
            // 
            // TimeBlockPanel
            // 
            this.TimeBlockPanel.Controls.Add(this.TimeBlockView);
            this.TimeBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockPanel.Location = new System.Drawing.Point(0, 40);
            this.TimeBlockPanel.Name = "TimeBlockPanel";
            this.TimeBlockPanel.Padding = new System.Windows.Forms.Padding(3);
            this.TimeBlockPanel.Size = new System.Drawing.Size(200, 250);
            this.TimeBlockPanel.TabIndex = 2;
            // 
            // TimeBlockView
            // 
            this.TimeBlockView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeBlockView.HideSelection = false;
            this.TimeBlockView.Location = new System.Drawing.Point(3, 3);
            this.TimeBlockView.Name = "TimeBlockView";
            this.TimeBlockView.Size = new System.Drawing.Size(194, 244);
            this.TimeBlockView.TabIndex = 0;
            this.TimeBlockView.UseCompatibleStateImageBehavior = false;
            // 
            // TimeBlockTitlePanel
            // 
            this.TimeBlockTitlePanel.Controls.Add(this.AddBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.TaskBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.ScheduleBtn);
            this.TimeBlockTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeBlockTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TimeBlockTitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TimeBlockTitlePanel.Name = "TimeBlockTitlePanel";
            this.TimeBlockTitlePanel.Padding = new System.Windows.Forms.Padding(3);
            this.TimeBlockTitlePanel.Size = new System.Drawing.Size(200, 40);
            this.TimeBlockTitlePanel.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddBtn.Location = new System.Drawing.Point(163, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(34, 34);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // TaskBtn
            // 
            this.TaskBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskBtn.Location = new System.Drawing.Point(48, 3);
            this.TaskBtn.Name = "TaskBtn";
            this.TaskBtn.Size = new System.Drawing.Size(46, 34);
            this.TaskBtn.TabIndex = 1;
            this.TaskBtn.Text = "업무";
            this.TaskBtn.UseVisualStyleBackColor = true;
            this.TaskBtn.Click += new System.EventHandler(this.TaskBtn_Click);
            // 
            // ScheduleBtn
            // 
            this.ScheduleBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScheduleBtn.Location = new System.Drawing.Point(3, 3);
            this.ScheduleBtn.Name = "ScheduleBtn";
            this.ScheduleBtn.Size = new System.Drawing.Size(45, 34);
            this.ScheduleBtn.TabIndex = 0;
            this.ScheduleBtn.Text = "일정";
            this.ScheduleBtn.UseVisualStyleBackColor = true;
            this.ScheduleBtn.Click += new System.EventHandler(this.ScheduleBtn_Click);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.NextBtn);
            this.TitlePanel.Controls.Add(this.WeekLabel);
            this.TitlePanel.Controls.Add(this.AlgorithmStarter);
            this.TitlePanel.Controls.Add(this.PrevBtn);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(1, 0);
            this.TitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Padding = new System.Windows.Forms.Padding(5);
            this.TitlePanel.Size = new System.Drawing.Size(740, 40);
            this.TitlePanel.TabIndex = 3;
            // 
            // NextBtn
            // 
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtn.Location = new System.Drawing.Point(170, 5);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(35, 30);
            this.NextBtn.TabIndex = 4;
            this.NextBtn.Text = ">";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // WeekLabel
            // 
            this.WeekLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WeekLabel.Location = new System.Drawing.Point(40, 5);
            this.WeekLabel.Name = "WeekLabel";
            this.WeekLabel.Size = new System.Drawing.Size(130, 30);
            this.WeekLabel.TabIndex = 3;
            this.WeekLabel.Text = "2024.05 2주차";
            this.WeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlgorithmStarter
            // 
            this.AlgorithmStarter.Dock = System.Windows.Forms.DockStyle.Right;
            this.AlgorithmStarter.Location = new System.Drawing.Point(685, 5);
            this.AlgorithmStarter.Name = "AlgorithmStarter";
            this.AlgorithmStarter.Size = new System.Drawing.Size(50, 30);
            this.AlgorithmStarter.TabIndex = 2;
            this.AlgorithmStarter.Text = "계획";
            this.AlgorithmStarter.UseVisualStyleBackColor = true;
            this.AlgorithmStarter.Click += new System.EventHandler(this.AlgorithmStarter_Click);
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
            // LogTxt
            // 
            this.LogTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogTxt.Location = new System.Drawing.Point(1, 393);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.Size = new System.Drawing.Size(740, 100);
            this.LogTxt.TabIndex = 5;
            // 
            // CalendarPanel
            // 
            this.CalendarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarPanel.Location = new System.Drawing.Point(1, 40);
            this.CalendarPanel.Name = "CalendarPanel";
            this.CalendarPanel.Size = new System.Drawing.Size(740, 353);
            this.CalendarPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.CalendarPanel);
            this.Controls.Add(this.LogTxt);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.TimeBlockSettingPanel);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.TimeBlockSettingPanel.ResumeLayout(false);
            this.TimeBlockPanel.ResumeLayout(false);
            this.TimeBlockTitlePanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TimeBlockSettingPanel;
        private System.Windows.Forms.Panel TimeBlockTitlePanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button TaskBtn;
        private System.Windows.Forms.Button ScheduleBtn;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label WeekLabel;
        private System.Windows.Forms.Button AlgorithmStarter;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.Panel TimeBlockPanel;
        private System.Windows.Forms.ListView TimeBlockView;
        private System.Windows.Forms.TextBox LogTxt;
        private System.Windows.Forms.Panel CalendarPanel;
    }
}