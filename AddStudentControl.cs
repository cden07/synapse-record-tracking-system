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
    public partial class AddStudentControl : UserControl
    {
        public AddStudentControl()
        {
            InitializeComponent();
        }

        private void both(object sender, ScrollEventArgs e)
        {

        }

        private void AddStudentControl_Load(object sender, EventArgs e)
        {

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create new student from admin input
            var student = new Student
            {
                StudentID = int.Parse(txtStudentID.Text),
                Password = txtPassword.Text,   // Admin sets this
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                YearLevel = cmbYearLevel.Text,
                ProgramCourse = cmbProgram.Text,
                Birthday = dtpBirthday.Value,
                Block = cmbBlock.Text,
                ContactNumber = txtContactNumber.Text
            };

            // Save to repository
            StudentRepository.AddStudent(student);
            MessageBox.Show("Student added successfully!");
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

        // Username: letters, digits, underscore
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_')
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
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Username is required.");
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

