﻿namespace TimeManager.Forms
{
    partial class EditAvailableTimeForm
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
            this.selectedTimesBtn = new System.Windows.Forms.Button();
            this.doneBtn = new System.Windows.Forms.Button();
            this.weeklyTimeTableSelectableControl1 = new TimeManager.Controls.WeeklyTimeTableSelectableControl();
            this.SuspendLayout();
            // 
            // selectedTimesBtn
            // 
            this.selectedTimesBtn.Location = new System.Drawing.Point(413, 326);
            this.selectedTimesBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectedTimesBtn.Name = "selectedTimesBtn";
            this.selectedTimesBtn.Size = new System.Drawing.Size(125, 26);
            this.selectedTimesBtn.TabIndex = 0;
            this.selectedTimesBtn.Text = "선택 시간";
            this.selectedTimesBtn.UseVisualStyleBackColor = true;
            this.selectedTimesBtn.Click += new System.EventHandler(this.selectedTimes_Click);
            // 
            // doneBtn
            // 
            this.doneBtn.Location = new System.Drawing.Point(543, 326);
            this.doneBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(125, 26);
            this.doneBtn.TabIndex = 2;
            this.doneBtn.Text = "완료";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
            // 
            // weeklyTimeTableSelectableControl1
            // 
            this.weeklyTimeTableSelectableControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyTimeTableSelectableControl1.Location = new System.Drawing.Point(0, 0);
            this.weeklyTimeTableSelectableControl1.Name = "weeklyTimeTableSelectableControl1";
            this.weeklyTimeTableSelectableControl1.Size = new System.Drawing.Size(680, 321);
            this.weeklyTimeTableSelectableControl1.TabIndex = 1;
            // 
            // EditAvailableTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 360);
            this.ControlBox = false;
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.weeklyTimeTableSelectableControl1);
            this.Controls.Add(this.selectedTimesBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditAvailableTimeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectedTimesBtn;
        private Controls.WeeklyTimeTableSelectableControl weeklyTimeTableSelectableControl1;
        private System.Windows.Forms.Button doneBtn;
    }
}