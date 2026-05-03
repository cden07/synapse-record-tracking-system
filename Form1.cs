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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Placeholder role logic
            string role;
            if (username == "admin" && password == "admin123")
                role = "Admin";
            else
                role = "Student";

            Form2 form2 = new Form2(role);
            form2.Show();
            this.Hide();
        }

    }

}
