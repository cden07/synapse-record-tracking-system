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
    public partial class DeleteStudentControl : UserControl
    {
        public DeleteStudentControl()
        {
            InitializeComponent();
            this.Load += DeleteStudentControl_Load;
        }


        private void DeleteStudentControl_Load(object sender, EventArgs e)
        {

        }





        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtStudentID.Text, out id))
            {
                var result = MessageBox.Show("Are you sure you want to delete this student?",
                                             "Confirm Delete",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    StudentRepository.DeleteStudent(id);
                    MessageBox.Show("Student deleted successfully!");
                    ClearFields();
                }
            }
        }


        private void ClearFields()
        {
            txtStudentID.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtContactNumber.Clear();
            cmbYearLevel.SelectedIndex = -1;
            cmbBlock.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            dtpBirthday.Value = DateTime.Now;
        }


        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtStudentID.Text, out id))
            {
                var student = StudentRepository.GetStudentById(id);
                if (student != null)
                {
                    // Fill fields with existing data
                    txtFname.Text = student.FirstName;
                    txtLname.Text = student.LastName;
                    cmbYearLevel.Text = student.YearLevel;
                    dtpBirthday.Value = student.Birthday;
                    cmbBlock.Text = student.Block;
                    txtContactNumber.Text = student.ContactNumber;
                    cmbProgram.Text = student.ProgramCourse;
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Student ID.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
