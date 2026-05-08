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
        private string studentId;

        public DashboardControl(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadStudentInfo(int.Parse(studentId));
        }

        public void LoadStudentInfo(int studentId)
        {


            var student = StudentRepository.GetStudentById(studentId);
            if (student != null)
            {
                lblID.Text = student.StudentID.ToString();
                lblFName.Text = student.FirstName;
                lblLName.Text = student.LastName;

                lblProgram.Text = student.ProgramCourse;
             
                lblNumber.Text = student.ContactNumber;
                lblBirthday.Text = student.Birthday.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }
        public DashboardControl()
        {

            InitializeComponent();

        }
    }
}
