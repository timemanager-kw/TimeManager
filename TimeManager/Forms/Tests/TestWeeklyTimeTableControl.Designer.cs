namespace TimeManager.Forms.Tests
{
    partial class TestWeeklyTimeTableControl
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
            this.weeklyTimeTableControl1 = new TimeManager.Controls.WeeklyTimeTableControl();
            this.SuspendLayout();
            // 
            // weeklyTimeTableControl1
            // 
            this.weeklyTimeTableControl1.Location = new System.Drawing.Point(72, 38);
            this.weeklyTimeTableControl1.Name = "weeklyTimeTableControl1";
            this.weeklyTimeTableControl1.Size = new System.Drawing.Size(784, 321);
            this.weeklyTimeTableControl1.TabIndex = 0;
            this.weeklyTimeTableControl1.timeTable = null;
            this.weeklyTimeTableControl1.Load += new System.EventHandler(this.weeklyTimeTableControl1_Load);
            // 
            // TestWeeklyTimeTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 449);
            this.Controls.Add(this.weeklyTimeTableControl1);
            this.Name = "TestWeeklyTimeTableControl";
            this.Text = "TestWeeklyTimeTableControl";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WeeklyTimeTableControl weeklyTimeTableControl1;
    }
}