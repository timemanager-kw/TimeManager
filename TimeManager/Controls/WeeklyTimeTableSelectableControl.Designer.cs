namespace TimeManager.Controls
{
    partial class WeeklyTimeTableSelectableControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeight = 34;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonday,
            this.ColumnTuesday,
            this.ColumnWednesday,
            this.ColumnThursday,
            this.ColumnFriday,
            this.ColumnSaturday,
            this.ColumnSunday});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 65;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(1096, 482);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            this.dataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // ColumnMonday
            // 
            this.ColumnMonday.HeaderText = "월";
            this.ColumnMonday.MinimumWidth = 8;
            this.ColumnMonday.Name = "ColumnMonday";
            this.ColumnMonday.ReadOnly = true;
            this.ColumnMonday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnMonday.Width = 150;
            // 
            // ColumnTuesday
            // 
            this.ColumnTuesday.HeaderText = "화";
            this.ColumnTuesday.MinimumWidth = 8;
            this.ColumnTuesday.Name = "ColumnTuesday";
            this.ColumnTuesday.ReadOnly = true;
            this.ColumnTuesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnTuesday.Width = 150;
            // 
            // ColumnWednesday
            // 
            this.ColumnWednesday.HeaderText = "수";
            this.ColumnWednesday.MinimumWidth = 8;
            this.ColumnWednesday.Name = "ColumnWednesday";
            this.ColumnWednesday.ReadOnly = true;
            this.ColumnWednesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnWednesday.Width = 150;
            // 
            // ColumnThursday
            // 
            this.ColumnThursday.HeaderText = "목";
            this.ColumnThursday.MinimumWidth = 8;
            this.ColumnThursday.Name = "ColumnThursday";
            this.ColumnThursday.ReadOnly = true;
            this.ColumnThursday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnThursday.Width = 150;
            // 
            // ColumnFriday
            // 
            this.ColumnFriday.HeaderText = "금";
            this.ColumnFriday.MinimumWidth = 8;
            this.ColumnFriday.Name = "ColumnFriday";
            this.ColumnFriday.ReadOnly = true;
            this.ColumnFriday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnFriday.Width = 150;
            // 
            // ColumnSaturday
            // 
            this.ColumnSaturday.HeaderText = "토";
            this.ColumnSaturday.MinimumWidth = 8;
            this.ColumnSaturday.Name = "ColumnSaturday";
            this.ColumnSaturday.ReadOnly = true;
            this.ColumnSaturday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSaturday.Width = 150;
            // 
            // ColumnSunday
            // 
            this.ColumnSunday.HeaderText = "일";
            this.ColumnSunday.MinimumWidth = 8;
            this.ColumnSunday.Name = "ColumnSunday";
            this.ColumnSunday.ReadOnly = true;
            this.ColumnSunday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSunday.Width = 150;
            // 
            // WeeklyTimeTableSelectableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WeeklyTimeTableSelectableControl";
            this.Size = new System.Drawing.Size(1096, 482);
            this.Load += new System.EventHandler(this.WeeklyTimeTableControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSunday;
    }
}
