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
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weeklyTimeTableSelectableControl1
            // 
            this.weeklyTimeTableSelectableControl1.Location = new System.Drawing.Point(12, 12);
            this.weeklyTimeTableSelectableControl1.Name = "weeklyTimeTableSelectableControl1";
            this.weeklyTimeTableSelectableControl1.Size = new System.Drawing.Size(785, 321);
            this.weeklyTimeTableSelectableControl1.TabIndex = 0;
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Location = new System.Drawing.Point(628, 346);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(159, 23);
            this.btnShowSelected.TabIndex = 1;
            this.btnShowSelected.Text = "선택 시간 보기";
            this.btnShowSelected.UseVisualStyleBackColor = true;
            this.btnShowSelected.Click += new System.EventHandler(this.btnShowSelected_Click);
            // 
            // TestWeeklyTimeTableSelectableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 383);
            this.Controls.Add(this.btnShowSelected);
            this.Controls.Add(this.weeklyTimeTableSelectableControl1);
            this.Name = "TestWeeklyTimeTableSelectableControl";
            this.Text = "TestWeeklyTimeTableSelectableControl";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WeeklyTimeTableSelectableControl weeklyTimeTableSelectableControl1;
        private System.Windows.Forms.Button btnShowSelected;
    }
}