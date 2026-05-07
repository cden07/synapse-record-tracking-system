namespace synapse_record_tracking_system
{
    partial class AdminNavControl
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
            this.btnStudentList = new System.Windows.Forms.Button();
            this.btnGradeManagement = new System.Windows.Forms.Button();
            this.btnStudentRecord = new System.Windows.Forms.Button();
            this.lblNav = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(40, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 53);
            this.label1.TabIndex = 14;
            this.label1.Text = "NAVIGATION";
            // 
            // btnStudentList
            // 
            this.btnStudentList.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentList.Location = new System.Drawing.Point(22, 378);
            this.btnStudentList.Name = "btnStudentList";
            this.btnStudentList.Size = new System.Drawing.Size(311, 60);
            this.btnStudentList.TabIndex = 13;
            this.btnStudentList.Text = "View Student List";
            this.btnStudentList.UseVisualStyleBackColor = true;
            this.btnStudentList.Click += new System.EventHandler(this.btnStudentList_Click);
            // 
            // btnGradeManagement
            // 
            this.btnGradeManagement.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGradeManagement.Location = new System.Drawing.Point(22, 296);
            this.btnGradeManagement.Name = "btnGradeManagement";
            this.btnGradeManagement.Size = new System.Drawing.Size(311, 60);
            this.btnGradeManagement.TabIndex = 12;
            this.btnGradeManagement.Text = "Grade Management";
            this.btnGradeManagement.UseVisualStyleBackColor = true;
            this.btnGradeManagement.Click += new System.EventHandler(this.btnGradeManagement_Click);
            // 
            // btnStudentRecord
            // 
            this.btnStudentRecord.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentRecord.Location = new System.Drawing.Point(22, 215);
            this.btnStudentRecord.Name = "btnStudentRecord";
            this.btnStudentRecord.Size = new System.Drawing.Size(311, 60);
            this.btnStudentRecord.TabIndex = 11;
            this.btnStudentRecord.Text = "Student Record Management ";
            this.btnStudentRecord.UseVisualStyleBackColor = true;
            this.btnStudentRecord.Click += new System.EventHandler(this.btnStudentRecord_Click);
            // 
            // lblNav
            // 
            this.lblNav.AutoSize = true;
            this.lblNav.Font = new System.Drawing.Font("Sitka Small", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNav.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblNav.Location = new System.Drawing.Point(77, 73);
            this.lblNav.Name = "lblNav";
            this.lblNav.Size = new System.Drawing.Size(218, 53);
            this.lblNav.TabIndex = 10;
            this.lblNav.Text = "SYNAPSE ";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(22, 605);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(311, 60);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminNavControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStudentList);
            this.Controls.Add(this.btnGradeManagement);
            this.Controls.Add(this.btnStudentRecord);
            this.Controls.Add(this.lblNav);
            this.Name = "AdminNavControl";
            this.Size = new System.Drawing.Size(369, 708);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStudentList;
        private System.Windows.Forms.Button btnGradeManagement;
        private System.Windows.Forms.Button btnStudentRecord;
        private System.Windows.Forms.Label lblNav;
        private System.Windows.Forms.Button btnLogout;
    }
}
