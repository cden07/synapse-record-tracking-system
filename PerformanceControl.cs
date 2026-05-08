using synapse_record_tracking_system;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synapse_record_tracking_system
{
    public partial class PerformanceControl : UserControl
    {
        public PerformanceControl()
        {
            InitializeComponent();

        }

        private void PerformanceControl_Load(object sender, EventArgs e)
        {
            // Clear labels initially
            lblAverageGrade.Text = "Average Grade: -";
            lblPassedSubjects.Text = "Passed Subjects: -";
            lblFailedSubjects.Text = "Failed Subjects: -";
            lblRemarks.Text = "Remarks: -";


        }

        // Method to load performance for a given student
        public void LoadPerformance(int studentId)
        {
            var performance = StudentRepository.GetPerformance(studentId);

            if (performance != null)
            {
                lblAverageGrade.Text = $"Average Grade: {performance.AverageGrade:F2}";
                lblPassedSubjects.Text = $"Passed Subjects: {performance.PassedCount}";
                lblFailedSubjects.Text = $"Failed Subjects: {performance.FailedCount}";
                lblRemarks.Text = $"Remarks: {performance.Remarks}";
            }
            else
            {
                lblAverageGrade.Text = "Average Grade: N/A";
                lblPassedSubjects.Text = "Passed Subjects: N/A";
                lblFailedSubjects.Text = "Failed Subjects: N/A";
                lblRemarks.Text = "Remarks: N/A";
            }
        }
    }
}