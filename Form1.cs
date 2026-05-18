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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			// First, validate that fields are not empty
			if (!ValidateLogin())
				return;

			string enteredId = txtStudentID.Text.Trim();
			string enteredPassword = txtPassword.Text;

			// --- ADMIN LOGIN ---
			if (enteredId == "admin")
			{
				// Admin password check
				if (enteredPassword == "admin123")
				{
					Form2 adminForm = new Form2("Admin");
					adminForm.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Invalid admin password.", "Login Failed",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return; // Stop here – not a student
			}

			// --- STUDENT LOGIN ---
			// Try to parse Student ID as integer
			if (!int.TryParse(enteredId, out int studentId))
			{
				MessageBox.Show("Student ID must be a number.", "Invalid Input",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Check database for student
			var student = StudentRepository.GetStudentById(studentId);
			if (student != null && student.Password == enteredPassword)
			{
				Form2 studentForm = new Form2("Student");
				studentForm.Tag = student.StudentID;
				studentForm.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Invalid Student ID or Password.", "Login Failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Allow only letters, digits, underscore, and control keys (backspace, etc.)
			if (!char.IsControl(e.KeyChar) &&
				!char.IsLetterOrDigit(e.KeyChar) &&
				e.KeyChar != '_')
			{
				e.Handled = true;
			}
		}

		private bool ValidateLogin()
		{
			bool isValid = true;
			errorProvider1.Clear();

			if (string.IsNullOrWhiteSpace(txtStudentID.Text))
			{
				errorProvider1.SetError(txtStudentID, "Student ID / Admin username is required.");
				isValid = false;
			}
			if (string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				errorProvider1.SetError(txtPassword, "Password is required.");
				isValid = false;
			}

			return isValid;
		}
	}
}