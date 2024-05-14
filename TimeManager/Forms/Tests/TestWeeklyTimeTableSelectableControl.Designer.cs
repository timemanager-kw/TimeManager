namespace TimeManager.Forms.Tests
{
    partial class TestWeeklyTimeTableSelectableControl
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
            this.weeklyTimeTableSelectableControl1 = new TimeManager.Controls.WeeklyTimeTableSelectableControl();
            this.SuspendLayout();
            // 
            // weeklyTimeTableSelectableControl1
            // 
            this.weeklyTimeTableSelectableControl1.Location = new System.Drawing.Point(12, 12);
            this.weeklyTimeTableSelectableControl1.Name = "weeklyTimeTableSelectableControl1";
            this.weeklyTimeTableSelectableControl1.Size = new System.Drawing.Size(767, 321);
            this.weeklyTimeTableSelectableControl1.TabIndex = 0;
            // 
            // TestWeeklyTimeTableSelectableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weeklyTimeTableSelectableControl1);
            this.Name = "TestWeeklyTimeTableSelectableControl";
            this.Text = "TestWeeklyTimeTableSelectableControl";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WeeklyTimeTableSelectableControl weeklyTimeTableSelectableControl1;
    }
}