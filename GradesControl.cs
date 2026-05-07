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
    public partial class GradesControl : UserControl
    {


        private string studentId;

        public GradesControl()
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadGrades();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadGrades()
        {
            // Later: SQL query using studentId
            // SELECT sub.SubjectName, g.QuizScore, g.ExamScore, g.ProjectScore,
            //        g.FinalGrade, g.Remarks
            // FROM Grades g
            // JOIN Subjects sub ON g.SubjectID = sub.SubjectID
            // WHERE g.StudentID = @studentId;

            // For now, demo rows:
            dgvGrades.Rows.Clear();
            dgvGrades.Rows.Add("Math", "90", "85", "88", "87", "Passed");
            dgvGrades.Rows.Add("Science", "80", "78", "82", "80", "Passed");
            dgvGrades.Rows.Add("English", "70", "65", "72", "69", "Conditional");
        }
    }
}
