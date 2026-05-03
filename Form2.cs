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
    public partial class Form2 : Form
    {

        private string UserRole;

        public Form2(string role)
        {
            InitializeComponent();
            UserRole = role;
        }

        // Helper method to load content into Panel2
        public void LoadControl(UserControl control)
        {
            splitContainer1.Panel2.Controls.Clear();
            control.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(control);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            if (UserRole == "Admin")
                splitContainer1.Panel1.Controls.Add(new AdminNavControl());
            else
                splitContainer1.Panel1.Controls.Add(new StudentNavControl());
        }
    }

}
