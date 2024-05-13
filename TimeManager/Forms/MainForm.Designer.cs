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
            this.PrevBtn = new System.Windows.Forms.Button();
            this.WeekLabel = new System.Windows.Forms.Label();
            this.NextBtn = new System.Windows.Forms.Button();
            this.AlgorithmStarter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.ScheduleBtn = new System.Windows.Forms.Button();
            this.TaskBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TimeBlockTitlePanel = new System.Windows.Forms.Panel();
            this.TimeBlockView = new System.Windows.Forms.ListView();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.TimeBlockTitlePanel.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // WeekLabel
            // 
            this.WeekLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WeekLabel.Location = new System.Drawing.Point(40, 5);
            this.WeekLabel.Name = "WeekLabel";
            this.WeekLabel.Size = new System.Drawing.Size(130, 30);
            this.WeekLabel.TabIndex = 4;
            this.WeekLabel.Text = "2024.05 2주차";
            this.WeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NextBtn
            // 
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtn.Location = new System.Drawing.Point(170, 5);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(35, 30);
            this.NextBtn.TabIndex = 5;
            this.NextBtn.Text = ">";
            this.NextBtn.UseVisualStyleBackColor = true;
            // 
            // AlgorithmStarter
            // 
            this.AlgorithmStarter.Dock = System.Windows.Forms.DockStyle.Right;
            this.AlgorithmStarter.Location = new System.Drawing.Point(685, 5);
            this.AlgorithmStarter.Name = "AlgorithmStarter";
            this.AlgorithmStarter.Size = new System.Drawing.Size(50, 30);
            this.AlgorithmStarter.TabIndex = 6;
            this.AlgorithmStarter.Text = "계획";
            this.AlgorithmStarter.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AlgorithmStarter);
            this.panel2.Controls.Add(this.NextBtn);
            this.panel2.Controls.Add(this.WeekLabel);
            this.panel2.Controls.Add(this.PrevBtn);
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.MaximumSize = new System.Drawing.Size(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(740, 40);
            this.panel2.TabIndex = 8;
            // 
            // LogTxt
            // 
            this.LogTxt.Location = new System.Drawing.Point(4, 390);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.Size = new System.Drawing.Size(742, 100);
            this.LogTxt.TabIndex = 10;
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
            // 
            // TimeBlockTitlePanel
            // 
            this.TimeBlockTitlePanel.Controls.Add(this.AddBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.TaskBtn);
            this.TimeBlockTitlePanel.Controls.Add(this.ScheduleBtn);
            this.TimeBlockTitlePanel.Location = new System.Drawing.Point(744, 3);
            this.TimeBlockTitlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.TimeBlockTitlePanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.TimeBlockTitlePanel.Name = "TimeBlockTitlePanel";
            this.TimeBlockTitlePanel.Padding = new System.Windows.Forms.Padding(3);
            this.TimeBlockTitlePanel.Size = new System.Drawing.Size(200, 40);
            this.TimeBlockTitlePanel.TabIndex = 11;
            // 
            // TimeBlockView
            // 
            this.TimeBlockView.FullRowSelect = true;
            this.TimeBlockView.HideSelection = false;
            this.TimeBlockView.Location = new System.Drawing.Point(744, 44);
            this.TimeBlockView.Name = "TimeBlockView";
            this.TimeBlockView.Size = new System.Drawing.Size(194, 244);
            this.TimeBlockView.TabIndex = 12;
            this.TimeBlockView.UseCompatibleStateImageBehavior = false;
            // 
            // AddPanel
            // 
            this.AddPanel.Location = new System.Drawing.Point(744, 287);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Padding = new System.Windows.Forms.Padding(5);
            this.AddPanel.Size = new System.Drawing.Size(200, 203);
            this.AddPanel.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.AddPanel);
            this.Controls.Add(this.TimeBlockView);
            this.Controls.Add(this.TimeBlockTitlePanel);
            this.Controls.Add(this.LogTxt);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.panel2.ResumeLayout(false);
            this.TimeBlockTitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Label WeekLabel;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button AlgorithmStarter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox LogTxt;
        private System.Windows.Forms.Button ScheduleBtn;
        private System.Windows.Forms.Button TaskBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Panel TimeBlockTitlePanel;
        private System.Windows.Forms.ListView TimeBlockView;
        private System.Windows.Forms.Panel AddPanel;
    }
}