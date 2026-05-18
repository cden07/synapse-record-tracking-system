using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace synapse_record_tracking_system
{
	public partial class GradeManagementControl : UserControl
	{
		Double MQ1Ave, MQ2Ave, MQ3Ave, MQ4Ave, MEave;
		Double FQ1Ave, FQ2Ave, FQ3Ave, FQ4Ave, FEave;

		double MCP, MA, MLabGrade, MLectureGrade, MidtermGrade;
		double FCP, FA, FLabGrade, FLectureGrade, FinalGrade;
		double FinalAverage;

		public GradeManagementControl()
		{
			InitializeComponent();
			this.dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
		}

		private void GradeManagementControl_Load(object sender, EventArgs e)
		{
			LoadAllStudents();
		}

		// Load all students into dgvStudents
		private void LoadAllStudents()
		{
			using (var conn = DbConnectionHelper.GetConnection())
			{
				conn.Open();
				string sql = "SELECT StudentID, FirstName, LastName, ProgramCourse, YearLevel FROM Students";
				using (var cmd = new MySqlCommand(sql, conn))
				using (var adapter = new MySqlDataAdapter(cmd))
				{
					DataTable dt = new DataTable();
					adapter.Fill(dt);
					dgvStudents.DataSource = dt;
				}
			}
		}

		// When a student row is selected, fill the top fields
		private void dgvStudents_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvStudents.CurrentRow == null) return;

			DataGridViewRow row = dgvStudents.CurrentRow;
			int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
			string firstName = row.Cells["FirstName"].Value.ToString();
			string lastName = row.Cells["LastName"].Value.ToString();
			string program = row.Cells["ProgramCourse"].Value.ToString();
			string yearLevel = row.Cells["YearLevel"].Value.ToString();

			// Fill the student info fields
			txtSN.Text = studentId.ToString();
			txtSurname.Text = lastName;
			txtFirstname.Text = firstName;
			cboProgram.Text = program;
			cboYear.Text = yearLevel;

			// Enable or clear grade fields (optional)
			ClearGradeFields();
			// Ensure fields are enabled when a new student is selected
			EnableAllGradeInputs();
		}

		private void ClearGradeFields()
		{
			// Midterm fields
			txtMCP.Clear();
			txtMA.Clear();
			txtMQ1.Clear();
			txtMQ2.Clear();
			txtMQ3.Clear();
			txtMQ4.Clear();
			txtME.Clear();
			txtMLabGrade.Clear();
			txtMQ1Ave.Clear();
			txtMQ2Ave.Clear();
			txtMQ3Ave.Clear();
			txtMQ4Ave.Clear();
			txtMEAve.Clear();
			txtMidtermGrade.Clear();

			// Final fields
			txtFCP.Clear();
			txtFA.Clear();
			txtFQ1.Clear();
			txtFQ2.Clear();
			txtFQ3.Clear();
			txtFQ4.Clear();
			txtFE.Clear();
			txtFLabGrade.Clear();
			txtFQ1Ave.Clear();
			txtFQ2Ave.Clear();
			txtFQ3Ave.Clear();
			txtFQ4Ave.Clear();
			txtFEAve.Clear();
			txtFinalGrade.Clear();

			txtFinalAve.Clear();
			txtSA.Clear();

			// Reset combo boxes to default
			cboMItemsQ1.SelectedIndex = -1;
			cboMItemsQ2.SelectedIndex = -1;
			cboMItemsQ3.SelectedIndex = -1;
			cboMItemsQ4.SelectedIndex = -1;
			cboMItemsME.SelectedIndex = -1;
			cboFItemsQ1.SelectedIndex = -1;
			cboFItemsQ2.SelectedIndex = -1;
			cboFItemsQ3.SelectedIndex = -1;
			cboFItemsQ4.SelectedIndex = -1;
			cboFItemsFE.SelectedIndex = -1;
		}

		private void txtMCP_TextChanged(object sender, EventArgs e) { ComputeGrade(); }
		private void txtMA_TextChanged(object sender, EventArgs e) { ComputeGrade(); }
		private void txtMLabGrade_TextChanged(object sender, EventArgs e) { ComputeGrade(); }
		private void txtFCP_TextChanged(object sender, EventArgs e) { ComputeGrade(); }
		private void txtFA_TextChanged(object sender, EventArgs e) { ComputeGrade(); }
		private void txtFLabGrade_TextChanged(object sender, EventArgs e) { ComputeGrade(); }

		private void txtSA_TextChanged(object sender, EventArgs e)
		{
			string val = txtSA.Text.Trim();
			string normalized = val.TrimEnd('0').TrimEnd('.');
			if (normalized != "4" && normalized != "6")
			{
				EnableAllGradeInputs();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSN.Text))
			{
				MessageBox.Show("Please select a student first.");
				return;
			}

			string specialAssessment = txtSA.Text.Trim();
			string normalized = specialAssessment.TrimEnd('0').TrimEnd('.');
			if (normalized == "4" || normalized == "6")
			{
				DisableAllGradeInputs();
				MessageBox.Show($"Special Assessment set to {specialAssessment}. Grade entry has been cleared and disabled.",
								"Grades Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return; // Do not save grades
			}

			var grade = new Grade
			{
				StudentID = int.Parse(txtSN.Text),
				Subject = txtSubject.Text,
				MCP = MCP,
				MA = MA,
				MQ1Ave = MQ1Ave,
				MQ2Ave = MQ2Ave,
				MQ3Ave = MQ3Ave,
				MQ4Ave = MQ4Ave,
				MEave = MEave,
				MLabGrade = MLabGrade,
				MidtermGrade = MidtermGrade,
				FCP = FCP,
				FA = FA,
				FQ1Ave = FQ1Ave,
				FQ2Ave = FQ2Ave,
				FQ3Ave = FQ3Ave,
				FQ4Ave = FQ4Ave,
				FEave = FEave,
				FLabGrade = FLabGrade,
				FinalGrade = FinalGrade
			};

			StudentRepository.AddGrade(grade);
			MessageBox.Show("Grades saved successfully for Student ID: " + txtSN.Text);
			ClearGradeFields();  // clears but does not disable
		}

		private void btnRecompute_Click(object sender, EventArgs e)
		{
			ComputeGrade();
			MessageBox.Show("Grades recomputed successfully.");
		}

		public void ComputeGrade()
		{
			double.TryParse(txtMCP.Text, out MCP);
			double.TryParse(txtMA.Text, out MA);
			double.TryParse(txtMQ1Ave.Text, out MQ1Ave);
			double.TryParse(txtMQ2Ave.Text, out MQ2Ave);
			double.TryParse(txtMQ3Ave.Text, out MQ3Ave);
			double.TryParse(txtMQ4Ave.Text, out MQ4Ave);
			double.TryParse(txtMEAve.Text, out MEave);
			double.TryParse(txtMLabGrade.Text, out MLabGrade);

			MLectureGrade = (MA * 0.10) + (MCP * 0.20) + (((MQ1Ave + MQ2Ave + MQ3Ave + MQ4Ave) / 4) * 0.30) + (MEave * 0.40);
			MidtermGrade = (MLectureGrade * 0.60) + (MLabGrade * 0.40);
			txtMidtermGrade.Text = MidtermGrade.ToString("F2");

			double.TryParse(txtFCP.Text, out FCP);
			double.TryParse(txtFA.Text, out FA);
			double.TryParse(txtFQ1Ave.Text, out FQ1Ave);
			double.TryParse(txtFQ2Ave.Text, out FQ2Ave);
			double.TryParse(txtFQ3Ave.Text, out FQ3Ave);
			double.TryParse(txtFQ4Ave.Text, out FQ4Ave);
			double.TryParse(txtFEAve.Text, out FEave);
			double.TryParse(txtFLabGrade.Text, out FLabGrade);

			FLectureGrade = (FA * 0.10) + (FCP * 0.20) + (((FQ1Ave + FQ2Ave + FQ3Ave + FQ4Ave) / 4) * 0.30) + (FEave * 0.40);
			FinalGrade = (FLectureGrade * 0.60) + (FLabGrade * 0.40);
			txtFinalGrade.Text = FinalGrade.ToString("F2");

			FinalAverage = (MidtermGrade + FinalGrade) / 2;
			txtFinalAve.Text = FinalAverage.ToString("F2");
		}

		// ---- KeyPress events (only digits) ----
		private void txtMQ1_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMQ2_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMQ3_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMQ4_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtME_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFQ1_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFQ2_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFQ3_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFQ4_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFE_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFLabGrade_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFCP_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtFA_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMCP_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMA_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
		private void txtMLabGrade_KeyPress(object sender, KeyPressEventArgs e)
		{ if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }

		// ---- Quiz average computation events ----
		private void txtFQ1_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboFItemsQ1, txtFQ1, ref FQ1Ave, txtFQ1Ave); }
		private void txtFQ2_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboFItemsQ2, txtFQ2, ref FQ2Ave, txtFQ2Ave); }
		private void txtFQ3_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboFItemsQ3, txtFQ3, ref FQ3Ave, txtFQ3Ave); }
		private void txtFQ4_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboFItemsQ4, txtFQ4, ref FQ4Ave, txtFQ4Ave); }
		private void txtFE_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboFItemsFE, txtFE, ref FEave, txtFEAve); }
		private void txtMQ1_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboMItemsQ1, txtMQ1, ref MQ1Ave, txtMQ1Ave); }
		private void txtMQ2_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboMItemsQ2, txtMQ2, ref MQ2Ave, txtMQ2Ave); }
		private void txtMQ3_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboMItemsQ3, txtMQ3, ref MQ3Ave, txtMQ3Ave); }
		private void txtMQ4_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboMItemsQ4, txtMQ4, ref MQ4Ave, txtMQ4Ave); }
		private void txtME_TextChanged(object sender, EventArgs e) { ComputeQuizAverage(cboMItemsME, txtME, ref MEave, txtMEAve); }

		private void ComputeQuizAverage(ComboBox cboItems, TextBox txtScore, ref double averageVar, TextBox txtAverage)
		{
			if (cboItems.SelectedItem == null) return;
			if (double.TryParse(txtScore.Text, out double score))
			{
				double items = Convert.ToDouble(cboItems.SelectedItem);
				if (score > items)
				{
					MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
					txtScore.Text = items.ToString();
					score = items;
				}
				averageVar = (score / items) * 60 + 40;
				txtAverage.Text = averageVar.ToString("F2");
				ComputeGrade();
			}
			else
			{
				txtAverage.Text = "";
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearGradeFields();
		}

		private void txtSA_Enter(object sender, EventArgs e)
		{
			txtSA.Clear();
		}

		private void txtMidtermGrade_TextChanged(object sender, EventArgs e) { }
		private void txtFinalGrade_TextChanged(object sender, EventArgs e) { }
		private void txtFinalAve_TextChanged(object sender, EventArgs e) { }

		// Disable all grade input controls and clear their values
		private void DisableAllGradeInputs()
		{
			DisableControlsInContainer(midtermGradingTab);
			DisableControlsInContainer(finalGradingTab);
		}

		private void DisableControlsInContainer(Control parent)
		{
			foreach (Control ctrl in parent.Controls)
			{
				if (ctrl is TextBox txt)
				{
					txt.Clear();
					txt.Enabled = false;
				}
				else if (ctrl is ComboBox cb)
				{
					cb.SelectedIndex = -1;
					cb.Enabled = false;
				}
				if (ctrl.HasChildren)
					DisableControlsInContainer(ctrl);
			}
		}

		// Re-enable all grade inputs (call when special assessment is cleared)
		private void EnableAllGradeInputs()
		{
			EnableControlsInContainer(midtermGradingTab);
			EnableControlsInContainer(finalGradingTab);
		}

		private void EnableControlsInContainer(Control parent)
		{
			foreach (Control ctrl in parent.Controls)
			{
				if (ctrl is TextBox txt)
					txt.Enabled = true;
				else if (ctrl is ComboBox cb)
					cb.Enabled = true;

				if (ctrl.HasChildren)
					EnableControlsInContainer(ctrl);
			}
		}
	}
}