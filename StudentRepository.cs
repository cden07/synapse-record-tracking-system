using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace synapse_record_tracking_system
{
	public static class StudentRepository
	{
		// ---------- Student CRUD ----------
		public static void AddStudent(Student s)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = @"INSERT INTO Students 
                            (StudentID, Password, FirstName, LastName, YearLevel, Birthday, Block, ContactNumber, ProgramCourse)
                            VALUES (@id, @pwd, @fname, @lname, @year, @bday, @block, @contact, @program)";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", s.StudentID);
					cmd.Parameters.AddWithValue("@pwd", s.Password);
					cmd.Parameters.AddWithValue("@fname", s.FirstName);
					cmd.Parameters.AddWithValue("@lname", s.LastName);
					cmd.Parameters.AddWithValue("@year", s.YearLevel);
					cmd.Parameters.AddWithValue("@bday", s.Birthday);
					cmd.Parameters.AddWithValue("@block", s.Block);
					cmd.Parameters.AddWithValue("@contact", s.ContactNumber);
					cmd.Parameters.AddWithValue("@program", s.ProgramCourse);
					cmd.ExecuteNonQuery();
				}
			}
		}

		public static Student GetStudentById(int id)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = "SELECT * FROM Students WHERE StudentID = @id";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", id);
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return new Student
							{
								StudentID = reader.GetInt32("StudentID"),
								Password = reader.GetString("Password"),
								FirstName = reader.GetString("FirstName"),
								LastName = reader.GetString("LastName"),
								YearLevel = reader.GetString("YearLevel"),
								Birthday = reader.GetDateTime("Birthday"),
								Block = reader.GetString("Block"),
								ContactNumber = reader.GetString("ContactNumber"),
								ProgramCourse = reader.GetString("ProgramCourse")
							};
						}
					}
				}
			}
			return null;
		}

		public static void UpdateStudent(Student updated)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = @"UPDATE Students SET 
                                Password=@pwd, FirstName=@fname, LastName=@lname, 
                                YearLevel=@year, Birthday=@bday, Block=@block, 
                                ContactNumber=@contact, ProgramCourse=@program
                              WHERE StudentID=@id";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", updated.StudentID);
					cmd.Parameters.AddWithValue("@pwd", updated.Password);
					cmd.Parameters.AddWithValue("@fname", updated.FirstName);
					cmd.Parameters.AddWithValue("@lname", updated.LastName);
					cmd.Parameters.AddWithValue("@year", updated.YearLevel);
					cmd.Parameters.AddWithValue("@bday", updated.Birthday);
					cmd.Parameters.AddWithValue("@block", updated.Block);
					cmd.Parameters.AddWithValue("@contact", updated.ContactNumber);
					cmd.Parameters.AddWithValue("@program", updated.ProgramCourse);
					cmd.ExecuteNonQuery();
				}
			}
		}

		public static void DeleteStudent(int id)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = "DELETE FROM Students WHERE StudentID = @id";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", id);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// ---------- Grades ----------
		public static void AddGrade(Grade grade)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = @"INSERT INTO Grades 
                            (StudentID, Subject, MCP, MA, MQ1Ave, MQ2Ave, MQ3Ave, MQ4Ave, MEave, MLabGrade, MidtermGrade,
                             FCP, FA, FQ1Ave, FQ2Ave, FQ3Ave, FQ4Ave, FEave, FLabGrade, FinalGrade)
                            VALUES (@sid, @subj, @mcp, @ma, @mq1, @mq2, @mq3, @mq4, @me, @mlab, @mid,
                                    @fcp, @fa, @fq1, @fq2, @fq3, @fq4, @fe, @flab, @final)";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@sid", grade.StudentID);
					cmd.Parameters.AddWithValue("@subj", grade.Subject);
					cmd.Parameters.AddWithValue("@mcp", grade.MCP);
					cmd.Parameters.AddWithValue("@ma", grade.MA);
					cmd.Parameters.AddWithValue("@mq1", grade.MQ1Ave);
					cmd.Parameters.AddWithValue("@mq2", grade.MQ2Ave);
					cmd.Parameters.AddWithValue("@mq3", grade.MQ3Ave);
					cmd.Parameters.AddWithValue("@mq4", grade.MQ4Ave);
					cmd.Parameters.AddWithValue("@me", grade.MEave);
					cmd.Parameters.AddWithValue("@mlab", grade.MLabGrade);
					cmd.Parameters.AddWithValue("@mid", grade.MidtermGrade);
					cmd.Parameters.AddWithValue("@fcp", grade.FCP);
					cmd.Parameters.AddWithValue("@fa", grade.FA);
					cmd.Parameters.AddWithValue("@fq1", grade.FQ1Ave);
					cmd.Parameters.AddWithValue("@fq2", grade.FQ2Ave);
					cmd.Parameters.AddWithValue("@fq3", grade.FQ3Ave);
					cmd.Parameters.AddWithValue("@fq4", grade.FQ4Ave);
					cmd.Parameters.AddWithValue("@fe", grade.FEave);
					cmd.Parameters.AddWithValue("@flab", grade.FLabGrade);
					cmd.Parameters.AddWithValue("@final", grade.FinalGrade);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// ---------- Performance ----------
		public static Performance GetPerformance(int studentId)
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = "SELECT FinalGrade FROM Grades WHERE StudentID = @sid";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@sid", studentId);
					var grades = new List<double>();
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
							grades.Add(reader.GetDouble("FinalGrade"));
					}
					if (grades.Count == 0) return null;

					double avg = grades.Average();
					int passed = grades.Count(g => g >= 75);
					int failed = grades.Count(g => g < 75);
					string remarks = avg >= 75 ? "Passed" : "Failed";

					return new Performance
					{
						AverageGrade = avg,
						PassedCount = passed,
						FailedCount = failed,
						Remarks = remarks
					};
				}
			}
		}

		// ---------- For StudentListControl: return DataTable ----------
		public static DataTable GetAllStudentsAsTable()
		{
			DataTable dt = new DataTable();
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = "SELECT StudentID, FirstName, LastName, YearLevel, Block, ProgramCourse, ContactNumber FROM Students";
				using (var cmd = new MySqlCommand(sql, conn))
				using (var adapter = new MySqlDataAdapter(cmd))
				{
					adapter.Fill(dt);
				}
			}
			return dt;
		}
	}
}