using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace synapse_record_tracking_system
{
	public partial class GradesControl : UserControl
	{
		private string studentId;

		// Constructor that accepts student ID
		public GradesControl(string studentId)
		{
			InitializeComponent();
			this.studentId = studentId;
			LoadGrades();
		}

		private void label1_Click(object sender, EventArgs e) { }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

		private void LoadGrades()
		{
			dgvGrades.Rows.Clear();
			if (string.IsNullOrEmpty(studentId)) return;

			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				// Fetch both MidtermGrade and FinalGrade
				string sql = @"SELECT Subject, MidtermGrade, FinalGrade FROM Grades WHERE StudentID = @sid";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@sid", studentId);
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							string subject = reader["Subject"].ToString();
							double midterm = Convert.ToDouble(reader["MidtermGrade"]);
							double final = Convert.ToDouble(reader["FinalGrade"]);
							double finalAverage = (midterm + final) / 2.0;
							string remarks = finalAverage >= 75 ? "Passed" : "Failed";

							// Add row with exactly 5 columns in the order defined in the designer:
							// CourseSubject (Subject), Column1 (Midterm), ddd (Final), FinalGrade (Final Average), Remarks
							dgvGrades.Rows.Add(
								subject,                      // Subject
								midterm.ToString("F2"),       // Midterm Grade
								final.ToString("F2"),         // Final Grade
								finalAverage.ToString("F2"),  // Final Average
								remarks                       // Remarks
							);
						}
					}
				}
			}
		}
	}
}