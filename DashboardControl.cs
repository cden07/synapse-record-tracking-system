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
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            // Later: SQL query using studentId
            // SELECT s.StudentID, u.Username, s.FirstName, s.LastName, s.Gender,
            //        s.BirthDate, s.Address, s.ContactNumber
            // FROM Students s
            // JOIN Users u ON s.StudentID = u.UserID
            // WHERE s.StudentID = @studentId;

            lblStudentID.Text = studentId;
            lblUser.Text = "demo_user";
            lblLName.Text = "Doe";
            lblFName.Text = "John";
            lblBirthday.Text = "2000-01-01";
            lblNumber.Text = "09123456789";
            lblGender.Text = "Male";
            lblAddress.Text = "Sample Address";
        }
        public DashboardControl()
        {

            InitializeComponent();

        }
    }
}
