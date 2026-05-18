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
	public partial class DashboardControl : UserControl
	{
		// Constructor used by the code (pass studentId)
		public DashboardControl(int studentId)
		{
			InitializeComponent();
			LoadStudentInfo(studentId);
		}

		// Optional: parameterless constructor for design-time support (does nothing)
		public DashboardControl()
		{
			InitializeComponent();
		}

		public void LoadStudentInfo(int studentId)
		{
			var student = StudentRepository.GetStudentById(studentId);
			if (student != null)
			{
				// Correct label assignments (match the names in Designer.cs)
				lblStudentID.Text = student.StudentID.ToString();   // NOT lblID
				lblLName.Text = student.LastName;
				lblFName.Text = student.FirstName;
				lblProgram.Text = student.ProgramCourse;
				lblNumber.Text = student.ContactNumber;
				lblBirthday.Text = student.Birthday.ToShortDateString();
			}
			else
			{
				MessageBox.Show("Student not found.");
			}
		}

		private void DashboardControl_Load(object sender, EventArgs e)
		{

		}
	}
}