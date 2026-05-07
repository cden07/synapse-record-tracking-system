namespace synapse_record_tracking_system
{
    partial class GradesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CourseSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToOrderColumns = true;
            this.dgvGrades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseSubject,
            this.Subject,
            this.ExamScore,
            this.ProjectScore,
            this.FinalGrade,
            this.Remarks});
            this.dgvGrades.Location = new System.Drawing.Point(0, 112);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 24;
            this.dgvGrades.Size = new System.Drawing.Size(1269, 621);
            this.dgvGrades.TabIndex = 0;
            this.dgvGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(426, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "SUBJECT GRADE RECORD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CourseSubject
            // 
            this.CourseSubject.HeaderText = "Subject";
            this.CourseSubject.MinimumWidth = 6;
            this.CourseSubject.Name = "CourseSubject";
            this.CourseSubject.ReadOnly = true;
            this.CourseSubject.Width = 125;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Quiz Score";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.Width = 125;
            // 
            // ExamScore
            // 
            this.ExamScore.HeaderText = "Exam Score";
            this.ExamScore.MinimumWidth = 6;
            this.ExamScore.Name = "ExamScore";
            this.ExamScore.ReadOnly = true;
            this.ExamScore.Width = 125;
            // 
            // ProjectScore
            // 
            this.ProjectScore.HeaderText = "Project Score";
            this.ProjectScore.MinimumWidth = 6;
            this.ProjectScore.Name = "ProjectScore";
            this.ProjectScore.ReadOnly = true;
            this.ProjectScore.Width = 125;
            // 
            // FinalGrade
            // 
            this.FinalGrade.HeaderText = "Final Grade";
            this.FinalGrade.MinimumWidth = 6;
            this.FinalGrade.Name = "FinalGrade";
            this.FinalGrade.Width = 125;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 125;
            // 
            // GradesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrades);
            this.Name = "GradesControl";
            this.Size = new System.Drawing.Size(1269, 736);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}
