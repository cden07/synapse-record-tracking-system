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
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ddd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FinalGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvGrades
			// 
			this.dgvGrades.AllowUserToOrderColumns = true;
			this.dgvGrades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvGrades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvGrades.ColumnHeadersHeight = 29;
			this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseSubject,
            this.Column1,
            this.ddd,
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
			// Column1
			// 
			this.Column1.HeaderText = "Midterm Grade";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.Width = 125;
			// 
			// ddd
			// 
			this.ddd.HeaderText = "Final Grade";
			this.ddd.MinimumWidth = 6;
			this.ddd.Name = "ddd";
			this.ddd.Width = 125;
			// 
			// FinalGrade
			// 
			this.FinalGrade.HeaderText = "Final Average Grade";
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ddd;
		private System.Windows.Forms.DataGridViewTextBoxColumn FinalGrade;
		private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
	}
}
