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

            string enteredId = txtStudentID.Text;
            string enteredPassword = txtPassword.Text;

            // ✅ Admin login
            if (enteredId == "admin" && enteredPassword == "admin123")
            {
                Form2 adminForm = new Form2("Admin");
                adminForm.Show();
                this.Hide();
                return;
            }

            // ✅ Student login
            int studentId;
            if (!int.TryParse(enteredId, out studentId))
            {
                MessageBox.Show("Invalid Student ID format.");
                return;
            }

            var student = StudentRepository.GetStudentById(studentId);
            if (student != null && student.Password == enteredPassword)
            {
                Form2 studentForm = new Form2("Student");
                studentForm.Tag = student.StudentID; // pass ID into Form2
                studentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Student ID or Password.");
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

        private bool ValidateLogin()
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                errorProvider1.SetError(txtStudentID, "Username is required.");
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
