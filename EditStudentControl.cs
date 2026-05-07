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
    public partial class EditStudentControl : UserControl
    {
        public EditStudentControl()
        {
            InitializeComponent();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {

            int id;
            if (int.TryParse(txtStudentID.Text, out id))
            {
                var student = StudentRepository.GetStudentById(id);

                if (student != null)
                {
                    // Fill fields
                    txtFname.Text = student.FirstName;
                    txtLname.Text = student.LastName;
                    txtUsername.Text = student.Username;
                    cmbYearLevel.Text = student.YearLevel;
                    dtpBirthday.Value = student.Birthday;
                    cmbBlock.Text = student.Block;
                    txtContactNumber.Text = student.ContactNumber;
                    cmbProgram.Text = student.ProgramCourse;

                    // ✅ Unlock fields
                    txtFname.Enabled = true;
                    txtLname.Enabled = true;
                    txtUsername.Enabled = true;
                    cmbYearLevel.Enabled = true;
                    dtpBirthday.Enabled = true;
                    cmbBlock.Enabled = true;
                    txtContactNumber.Enabled = true;
                    cmbProgram.Enabled = true;
                    btnSave.Enabled = true;
                    btnClear.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Student not found.");
                    LockFields(); // keep locked if not found
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Student ID.");
                LockFields();
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return; // stop if any field invalid

            int id = int.Parse(txtStudentID.Text);
            var student = new Student
            {
                StudentID = id,
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                Username = txtUsername.Text,
                YearLevel = cmbYearLevel.Text,
                Birthday = dtpBirthday.Value,
                Block = cmbBlock.Text,
                ContactNumber = txtContactNumber.Text,
                ProgramCourse = cmbProgram.Text
            };

            StudentRepository.UpdateStudent(student);
            MessageBox.Show("Student record updated successfully!");
            LockFields();
        }

        private void EditStudentControl_Load(object sender, EventArgs e)
        {
            LockFields();
        }

        private void LockFields()
        {
            txtUsername.Enabled = false;
            cmbYearLevel.Enabled = false;
            cmbBlock.Enabled = false;
            txtLname.Enabled = false;
            txtFname.Enabled = false;
            dtpBirthday.Enabled = false;
            txtContactNumber.Enabled = false;
            cmbProgram.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtUsername.Clear();
            cmbYearLevel.SelectedIndex = -1;
            dtpBirthday.Value = DateTime.Today;
            cmbBlock.SelectedIndex = -1;
            txtContactNumber.Clear();
            cmbProgram.SelectedIndex = -1;

            LockFields(); // relock everything
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
        !char.IsLetterOrDigit(e.KeyChar) &&
        e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block numbers/symbols
            }

        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block numbers/symbols
            }
        }

        private bool ValidateFields()
        {
            bool isValid = true;
            errorProvider1.Clear(); // reset previous errors

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
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Username is required.");
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


