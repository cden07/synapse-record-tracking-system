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
            var student = new Student
            {
                StudentID = int.Parse(txtStudentID.Text),
                Username = txtUsername.Text,
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                YearLevel = cmbYearLevel.Text,
                Birthday = dtpBirthday.Value,
                Block = cmbBlock.Text,
                ContactNumber = txtContactNumber.Text,
                ProgramCourse = cmbProgram.Text
            };

            StudentRepository.AddStudent(student);
            MessageBox.Show("Student added successfully!");
        }

    }
}

