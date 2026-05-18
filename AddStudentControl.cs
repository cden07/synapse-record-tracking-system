using System;
using System.Text;
using System.Windows.Forms;

namespace synapse_record_tracking_system
{
	public partial class AddStudentControl : UserControl
	{
		private static readonly Random _random = new Random();

		public AddStudentControl()
		{
			InitializeComponent();
		}

		private void both(object sender, ScrollEventArgs e) { }
		private void AddStudentControl_Load(object sender, EventArgs e) { }

		// Generate a random 6-character password (letters, digits, symbols)
		private string GenerateRandomPassword()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
			var sb = new StringBuilder();
			for (int i = 0; i < 6; i++)
			{
				sb.Append(chars[_random.Next(chars.Length)]);
			}
			return sb.ToString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidateFields()) return;

			int studentId = int.Parse(txtStudentID.Text);
			if (StudentRepository.GetStudentById(studentId) != null)
			{
				MessageBox.Show("Student ID already exists! Please use a different ID.");
				return;
			}

			// Generate random 6-character password
			string randomPassword = GenerateRandomPassword();

			var student = new Student
			{
				StudentID = studentId,
				Password = randomPassword,      // auto-generated
				FirstName = txtFname.Text,
				LastName = txtLname.Text,
				YearLevel = cmbYearLevel.Text,
				ProgramCourse = cmbProgram.Text,
				Birthday = dtpBirthday.Value,
				Block = cmbBlock.Text,
				ContactNumber = txtContactNumber.Text
			};

			StudentRepository.AddStudent(student);
			MessageBox.Show($"Student added successfully!\nUsername: {student.StudentID}\nPassword: {randomPassword}",
							"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			ClearForm();
		}

		private void ClearForm()
		{
			txtStudentID.Clear();
			txtFname.Clear();
			txtLname.Clear();
			cmbYearLevel.SelectedIndex = -1;
			cmbBlock.SelectedIndex = -1;
			cmbProgram.SelectedIndex = -1;
			txtContactNumber.Clear();
			dtpBirthday.Value = DateTime.Now;
		}

		// Names: only letters + space
		private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
				e.Handled = true;
		}

		private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
				e.Handled = true;
		}

		// Contact Number: only digits
		private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				e.Handled = true;
		}

		private bool ValidateFields()
		{
			bool isValid = true;
			errorProvider1.Clear();

			if (string.IsNullOrWhiteSpace(txtStudentID.Text))
			{
				errorProvider1.SetError(txtStudentID, "Student ID is required.");
				isValid = false;
			}
			if (string.IsNullOrWhiteSpace(txtFname.Text))
			{
				errorProvider1.SetError(txtFname, "First name is required.");
				isValid = false;
			}
			if (string.IsNullOrWhiteSpace(txtLname.Text))
			{
				errorProvider1.SetError(txtLname, "Last name is required.");
				isValid = false;
			}
			if (cmbYearLevel.SelectedIndex == -1)
			{
				errorProvider1.SetError(cmbYearLevel, "Select a Year Level.");
				isValid = false;
			}
			if (cmbBlock.SelectedIndex == -1)
			{
				errorProvider1.SetError(cmbBlock, "Select a Block.");
				isValid = false;
			}
			if (cmbProgram.SelectedIndex == -1)
			{
				errorProvider1.SetError(cmbProgram, "Select a Program Course.");
				isValid = false;
			}
			if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
			{
				errorProvider1.SetError(txtContactNumber, "Contact number is required.");
				isValid = false;
			}
			else if (txtContactNumber.Text.Length < 10)
			{
				errorProvider1.SetError(txtContactNumber, "Contact number must be at least 10 digits.");
				isValid = false;
			}

			return isValid;
		}
	}
}