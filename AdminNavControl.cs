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
    public partial class AdminNavControl : UserControl
    {
        public AdminNavControl()
        {
            InitializeComponent();
        }

        private void btnStudentRecord_Click(object sender, EventArgs e)
        {
            ((Form2)this.ParentForm).LoadControl(new StudentRecordControl());
        }

        private void btnGradeManagement_Click(object sender, EventArgs e)
        {
            ((Form2)this.ParentForm).LoadControl(new GradeManagementControl());
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            ((Form2)this.ParentForm).LoadControl(new StudentListControl());
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

