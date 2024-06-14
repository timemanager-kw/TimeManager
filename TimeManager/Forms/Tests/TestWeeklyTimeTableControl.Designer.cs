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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // weeklyTimeTableControl1
            // 
            this.weeklyTimeTableControl1.Location = new System.Drawing.Point(30, 23);
            this.weeklyTimeTableControl1.Name = "weeklyTimeTableControl1";
            this.weeklyTimeTableControl1.Size = new System.Drawing.Size(825, 321);
            this.weeklyTimeTableControl1.TabIndex = 0;
            this.weeklyTimeTableControl1.ItemSelected += new System.EventHandler<TimeManager.Controls.WeeklyTimeTableControlItemEventArgs>(this.weeklyTimeTableControl1_ItemSelected);
            this.weeklyTimeTableControl1.Load += new System.EventHandler(this.weeklyTimeTableControl1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // TestWeeklyTimeTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weeklyTimeTableControl1);
            this.Name = "TestWeeklyTimeTableControl";
            this.Text = "TestWeeklyTimeTableControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WeeklyTimeTableControl weeklyTimeTableControl1;
        private System.Windows.Forms.Label label1;
    }
}