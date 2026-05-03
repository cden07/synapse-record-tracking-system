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
    public partial class StudentRecordControl : UserControl
    {
        public StudentRecordControl()
        {
            InitializeComponent();
        }

        private void StudentRecordControl_Load(object sender, EventArgs e)
        {

        }

        private void LoadSubControl(UserControl control)
        {
            splitContainer1.Panel2.Controls.Clear();
            control.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(control);
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            LoadSubControl(new AddStudentControl());
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            LoadSubControl(new EditStudentControl());
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            LoadSubControl(new DeleteStudentControl());
        }
    }
}
