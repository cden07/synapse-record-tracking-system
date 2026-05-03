namespace synapse_record_tracking_system
{
    partial class PerformanceControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAverageGrade = new System.Windows.Forms.Label();
            this.lblPassedSubjects = new System.Windows.Forms.Label();
            this.lblFailedSubjects = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(189, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "PERFORMANCE OVERVIEW";
            // 
            // lblAverageGrade
            // 
            this.lblAverageGrade.AutoSize = true;
            this.lblAverageGrade.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageGrade.ForeColor = System.Drawing.Color.Gold;
            this.lblAverageGrade.Location = new System.Drawing.Point(72, 157);
            this.lblAverageGrade.Name = "lblAverageGrade";
            this.lblAverageGrade.Size = new System.Drawing.Size(165, 29);
            this.lblAverageGrade.TabIndex = 1;
            this.lblAverageGrade.Text = "Average Grade:";
            // 
            // lblPassedSubjects
            // 
            this.lblPassedSubjects.AutoSize = true;
            this.lblPassedSubjects.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedSubjects.ForeColor = System.Drawing.Color.Gold;
            this.lblPassedSubjects.Location = new System.Drawing.Point(72, 249);
            this.lblPassedSubjects.Name = "lblPassedSubjects";
            this.lblPassedSubjects.Size = new System.Drawing.Size(183, 29);
            this.lblPassedSubjects.TabIndex = 2;
            this.lblPassedSubjects.Text = "Passed Subjects :";
            // 
            // lblFailedSubjects
            // 
            this.lblFailedSubjects.AutoSize = true;
            this.lblFailedSubjects.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedSubjects.ForeColor = System.Drawing.Color.Gold;
            this.lblFailedSubjects.Location = new System.Drawing.Point(72, 397);
            this.lblFailedSubjects.Name = "lblFailedSubjects";
            this.lblFailedSubjects.Size = new System.Drawing.Size(175, 29);
            this.lblFailedSubjects.TabIndex = 3;
            this.lblFailedSubjects.Text = "Failed Subjects :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(72, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remarks : ";
            // 
            // PerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFailedSubjects);
            this.Controls.Add(this.lblPassedSubjects);
            this.Controls.Add(this.lblAverageGrade);
            this.Controls.Add(this.label1);
            this.Name = "PerformanceControl";
            this.Size = new System.Drawing.Size(881, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAverageGrade;
        private System.Windows.Forms.Label lblPassedSubjects;
        private System.Windows.Forms.Label lblFailedSubjects;
        private System.Windows.Forms.Label label2;
    }
}
