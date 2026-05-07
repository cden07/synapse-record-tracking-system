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
    public partial class StudentNavControl : UserControl
    {

        private string studentId;
        public StudentNavControl(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ((Form2)this.ParentForm).LoadControl(new DashboardControl());
        }

        private void btnViewGrades_Click(object sender, EventArgs e)
        {
            ((Form2)this.ParentForm).LoadControl(new GradesControl());
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {

            ((Form2)this.ParentForm).LoadControl(new PerformanceControl());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                           "Logout",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form2 parentForm = (Form2)this.ParentForm;
                parentForm.Hide();

                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }
    }
}