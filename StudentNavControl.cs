using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace synapse_record_tracking_system
{
	public partial class StudentNavControl : UserControl
	{
		private int studentId;

		// Constructor now expects string (from Form2) but converts to int
		public StudentNavControl(string studentId)
		{
			InitializeComponent();
			// Convert the string ID to int (safe parse, assume valid)
			this.studentId = int.Parse(studentId);
		}

		private void btnDashboard_Click(object sender, EventArgs e)
		{
			((Form2)this.ParentForm).LoadControl(new DashboardControl(studentId));
		}

		private void btnViewGrades_Click(object sender, EventArgs e)
		{
			((Form2)this.ParentForm).LoadControl(new GradesControl(studentId.ToString()));
		}

		private void btnPerformance_Click(object sender, EventArgs e)
		{
			((Form2)this.ParentForm).LoadControl(new PerformanceControl(studentId));
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to log out?",
										   "Logout",
										   MessageBoxButtons.YesNo,
										   MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Form2 parentForm = (Form2)this.ParentForm;
				parentForm.Hide();

				Form1 loginForm = new Form1();
				loginForm.Show();
			}
		}
	}
}