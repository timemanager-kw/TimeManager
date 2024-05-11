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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.WeekTxtBox = new System.Windows.Forms.TextBox();
            this.PreBtn = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.week7 = new System.Windows.Forms.TextBox();
            this.week6 = new System.Windows.Forms.TextBox();
            this.week5 = new System.Windows.Forms.TextBox();
            this.week4 = new System.Windows.Forms.TextBox();
            this.week3 = new System.Windows.Forms.TextBox();
            this.week2 = new System.Windows.Forms.TextBox();
            this.week1 = new System.Windows.Forms.TextBox();
            this.week0 = new System.Windows.Forms.TextBox();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ScheduleBtn = new System.Windows.Forms.Button();
            this.TaskBtn = new System.Windows.Forms.Button();
            this.TimeBlockView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(878, 496);
            this.splitContainer1.SplitterDistance = 682;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.button1);
            this.splitContainer4.Panel1.Controls.Add(this.NextBtn);
            this.splitContainer4.Panel1.Controls.Add(this.WeekTxtBox);
            this.splitContainer4.Panel1.Controls.Add(this.PreBtn);
            this.splitContainer4.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(682, 496);
            this.splitContainer4.SplitterDistance = 28;
            this.splitContainer4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(619, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "계획";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NextBtn
            // 
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtn.Location = new System.Drawing.Point(183, 3);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(40, 22);
            this.NextBtn.TabIndex = 4;
            this.NextBtn.Text = ">";
            this.NextBtn.UseVisualStyleBackColor = true;
            // 
            // WeekTxtBox
            // 
            this.WeekTxtBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.WeekTxtBox.Location = new System.Drawing.Point(43, 3);
            this.WeekTxtBox.Multiline = true;
            this.WeekTxtBox.Name = "WeekTxtBox";
            this.WeekTxtBox.ReadOnly = true;
            this.WeekTxtBox.Size = new System.Drawing.Size(140, 22);
            this.WeekTxtBox.TabIndex = 3;
            this.WeekTxtBox.Text = "2024.05 2주차";
            this.WeekTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PreBtn
            // 
            this.PreBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.PreBtn.Location = new System.Drawing.Point(3, 3);
            this.PreBtn.Name = "PreBtn";
            this.PreBtn.Size = new System.Drawing.Size(40, 22);
            this.PreBtn.TabIndex = 0;
            this.PreBtn.Text = "<";
            this.PreBtn.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.LogTxt);
            this.splitContainer5.Size = new System.Drawing.Size(682, 464);
            this.splitContainer5.SplitterDistance = 380;
            this.splitContainer5.TabIndex = 0;
            this.splitContainer5.TabStop = false;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.week7);
            this.splitContainer6.Panel1.Controls.Add(this.week6);
            this.splitContainer6.Panel1.Controls.Add(this.week5);
            this.splitContainer6.Panel1.Controls.Add(this.week4);
            this.splitContainer6.Panel1.Controls.Add(this.week3);
            this.splitContainer6.Panel1.Controls.Add(this.week2);
            this.splitContainer6.Panel1.Controls.Add(this.week1);
            this.splitContainer6.Panel1.Controls.Add(this.week0);
            this.splitContainer6.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer6.Size = new System.Drawing.Size(682, 380);
            this.splitContainer6.SplitterDistance = 30;
            this.splitContainer6.TabIndex = 0;
            // 
            // week7
            // 
            this.week7.Dock = System.Windows.Forms.DockStyle.Left;
            this.week7.Location = new System.Drawing.Point(450, 3);
            this.week7.Name = "week7";
            this.week7.ReadOnly = true;
            this.week7.Size = new System.Drawing.Size(63, 25);
            this.week7.TabIndex = 7;
            this.week7.Text = "일";
            this.week7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week6
            // 
            this.week6.Dock = System.Windows.Forms.DockStyle.Left;
            this.week6.Location = new System.Drawing.Point(387, 3);
            this.week6.Name = "week6";
            this.week6.ReadOnly = true;
            this.week6.Size = new System.Drawing.Size(63, 25);
            this.week6.TabIndex = 6;
            this.week6.Text = "토";
            this.week6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week5
            // 
            this.week5.Dock = System.Windows.Forms.DockStyle.Left;
            this.week5.Location = new System.Drawing.Point(324, 3);
            this.week5.Name = "week5";
            this.week5.ReadOnly = true;
            this.week5.Size = new System.Drawing.Size(63, 25);
            this.week5.TabIndex = 5;
            this.week5.Text = "금";
            this.week5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week4
            // 
            this.week4.Dock = System.Windows.Forms.DockStyle.Left;
            this.week4.Location = new System.Drawing.Point(261, 3);
            this.week4.Name = "week4";
            this.week4.ReadOnly = true;
            this.week4.Size = new System.Drawing.Size(63, 25);
            this.week4.TabIndex = 4;
            this.week4.Text = "목";
            this.week4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week3
            // 
            this.week3.Dock = System.Windows.Forms.DockStyle.Left;
            this.week3.Location = new System.Drawing.Point(198, 3);
            this.week3.Name = "week3";
            this.week3.ReadOnly = true;
            this.week3.Size = new System.Drawing.Size(63, 25);
            this.week3.TabIndex = 3;
            this.week3.Text = "수";
            this.week3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week2
            // 
            this.week2.Dock = System.Windows.Forms.DockStyle.Left;
            this.week2.Location = new System.Drawing.Point(135, 3);
            this.week2.Name = "week2";
            this.week2.ReadOnly = true;
            this.week2.Size = new System.Drawing.Size(63, 25);
            this.week2.TabIndex = 2;
            this.week2.Text = "화";
            this.week2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week1
            // 
            this.week1.Dock = System.Windows.Forms.DockStyle.Left;
            this.week1.Location = new System.Drawing.Point(72, 3);
            this.week1.Name = "week1";
            this.week1.ReadOnly = true;
            this.week1.Size = new System.Drawing.Size(63, 25);
            this.week1.TabIndex = 1;
            this.week1.Text = "월";
            this.week1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // week0
            // 
            this.week0.Dock = System.Windows.Forms.DockStyle.Left;
            this.week0.Location = new System.Drawing.Point(3, 3);
            this.week0.Name = "week0";
            this.week0.ReadOnly = true;
            this.week0.Size = new System.Drawing.Size(69, 25);
            this.week0.TabIndex = 0;
            // 
            // LogTxt
            // 
            this.LogTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTxt.Location = new System.Drawing.Point(0, 0);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.Size = new System.Drawing.Size(682, 80);
            this.LogTxt.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(191, 496);
            this.splitContainer2.SplitterDistance = 239;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ScheduleBtn);
            this.splitContainer3.Panel1.Controls.Add(this.TaskBtn);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TimeBlockView);
            this.splitContainer3.Size = new System.Drawing.Size(191, 239);
            this.splitContainer3.SplitterDistance = 35;
            this.splitContainer3.TabIndex = 0;
            // 
            // ScheduleBtn
            // 
            this.ScheduleBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScheduleBtn.Location = new System.Drawing.Point(53, 3);
            this.ScheduleBtn.Name = "ScheduleBtn";
            this.ScheduleBtn.Size = new System.Drawing.Size(50, 29);
            this.ScheduleBtn.TabIndex = 1;
            this.ScheduleBtn.Text = "일정";
            this.ScheduleBtn.UseVisualStyleBackColor = true;
            // 
            // TaskBtn
            // 
            this.TaskBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskBtn.Location = new System.Drawing.Point(3, 3);
            this.TaskBtn.Name = "TaskBtn";
            this.TaskBtn.Size = new System.Drawing.Size(50, 29);
            this.TaskBtn.TabIndex = 0;
            this.TaskBtn.Text = "업무";
            this.TaskBtn.UseVisualStyleBackColor = true;
            this.TaskBtn.Click += new System.EventHandler(this.TaskBtn_Click);
            // 
            // TimeBlockView
            // 
            this.TimeBlockView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeBlockView.HideSelection = false;
            this.TimeBlockView.Location = new System.Drawing.Point(0, 0);
            this.TimeBlockView.Name = "TimeBlockView";
            this.TimeBlockView.Size = new System.Drawing.Size(191, 200);
            this.TimeBlockView.TabIndex = 0;
            this.TimeBlockView.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 506);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button ScheduleBtn;
        private System.Windows.Forms.Button TaskBtn;
        private System.Windows.Forms.ListView TimeBlockView;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button PreBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.TextBox WeekTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TextBox LogTxt;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.TextBox week0;
        private System.Windows.Forms.TextBox week2;
        private System.Windows.Forms.TextBox week1;
        private System.Windows.Forms.TextBox week3;
        private System.Windows.Forms.TextBox week6;
        private System.Windows.Forms.TextBox week5;
        private System.Windows.Forms.TextBox week4;
        private System.Windows.Forms.TextBox week7;
    }
}