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
                    // Fill fields with existing data
                    txtFname.Text = student.FirstName;
                    txtLname.Text = student.LastName;
                    txtUsername.Text = student.Username;
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

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtStudentID.Text, out id))
            {
                var updated = new Student
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

                StudentRepository.UpdateStudent(updated);
                MessageBox.Show("Student updated successfully!");
            }
        }

    }
}

