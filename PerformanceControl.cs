using System;
using System.Windows.Forms;

namespace synapse_record_tracking_system
{
	public partial class PerformanceControl : UserControl
	{
		private int studentId;

		public PerformanceControl(int studentId)
		{
			InitializeComponent();
			this.studentId = studentId;
			LoadPerformance(studentId);
		}

		// Parameterless constructor for designer support
		public PerformanceControl()
		{
			InitializeComponent();
		}

		private void PerformanceControl_Load(object sender, EventArgs e)
		{
		}

		public void LoadPerformance(int studentId)
		{
			var performance = StudentRepository.GetPerformance(studentId);

			if (performance != null)
			{
				lblStudentGrade.Text = performance.AverageGrade.ToString("F2");
				lblSubjectsPassed.Text = performance.PassedCount.ToString();
				lblSubjectsFailed.Text = performance.FailedCount.ToString();
				lblRemarks.Text = performance.Remarks;
			}
			else
			{
				lblStudentGrade.Text = "N/A";
				lblSubjectsPassed.Text = "N/A";
				lblSubjectsFailed.Text = "N/A";
				lblRemarks.Text = "No grades recorded.";
			}
		}
	}
}