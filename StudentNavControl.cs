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
        public StudentNavControl()
        {
            InitializeComponent();
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
    }
}
