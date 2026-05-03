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
    public partial class StudentListControl : UserControl
    {
        public StudentListControl()
        {
            InitializeComponent();
        }

        private void StudentListControl_Load(object sender, EventArgs e)
        {

            dgvStudents.DataSource = StudentRepository.Students;
        }

    }
}
