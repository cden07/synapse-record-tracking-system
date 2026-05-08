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
    public partial class GradeManagementControl : UserControl
    {

        Double MQ1Ave, MQ2Ave, MQ3Ave, MQ4Ave, MEave;
        Double FQ1Ave, FQ2Ave, FQ3Ave, FQ4Ave, FEave;

        double MCP, MA, MLabGrade, MLectureGrade, MidtermGrade;
        double FCP, FA, FLabGrade, FLectureGrade, FinalGrade;

        private void txtMCP_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtMA_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtMLabGrade_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtMidtermGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFCP_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtFA_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtFLabGrade_TextChanged(object sender, EventArgs e)
        {
            ComputeGrade();
        }

        private void txtFinalGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSA_TextChanged(object sender, EventArgs e)
        {
            if (txtSA.Text == "4")
            {
                FinalAverage = 4.00;
                // (double equivalent, string remarks) = GetEquivalentandRemarks(FinalAverage);
                txtFinalAve.Text = FinalAverage.ToString("F2"); // + " / " + equivalent.ToString("F2");
            }

            else if (txtSA.Text == "6")
            {
                FinalAverage = 6.00;
                // (double equivalent, string remarks) = GetEquivalentandRemarks(FinalAverage);
                txtFinalAve.Text = FinalAverage.ToString("F2"); // + " / " + equivalent.ToString("F2");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
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

            // Save to repository
            StudentRepository.AddGrade(grade);

            MessageBox.Show("Grades saved successfully!");
        }

        

        private void txtMQ1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMQ2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMQ3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMQ4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFQ1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFQ2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFQ3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFQ4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFLabGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtFA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void txtMLabGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnRecompute_Click(object sender, EventArgs e)
        {
            ComputeGrade(); // reuse your existing method
            MessageBox.Show("Grades recomputed successfully.");
        }

        private void txtFinalAve_TextChanged(object sender, EventArgs e)
        {

        }

        double FinalAverage;


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

            MLectureGrade = (MA * .10) + (MCP * .20) + (((MQ1Ave + MQ2Ave + MQ3Ave + MQ4Ave) / 4) * .30) + (MEave * .40);
            MidtermGrade = (MLectureGrade * .60) + (MLabGrade * .40);
            txtMidtermGrade.Text = MidtermGrade.ToString("F2");

            //Finals

            double.TryParse(txtFCP.Text, out FCP);
            double.TryParse(txtFA.Text, out FA);
            double.TryParse(txtFQ1Ave.Text, out FQ1Ave);
            double.TryParse(txtFQ2Ave.Text, out FQ2Ave);
            double.TryParse(txtFQ3Ave.Text, out FQ3Ave);
            double.TryParse(txtFQ4Ave.Text, out FQ4Ave);
            double.TryParse(txtFEAve.Text, out FEave);
            double.TryParse(txtFLabGrade.Text, out FLabGrade);


            FLectureGrade = (FA * .10) + (FCP * .20) + (((FQ1Ave + FQ2Ave + FQ3Ave + FQ4Ave) / 4) * .30) + (FEave * .40);
            FinalGrade = (FLectureGrade * .60) + (FLabGrade * .40);
            txtFinalGrade.Text = FinalGrade.ToString("F2");

            FinalAverage = (MidtermGrade + FinalGrade) / 2;

            //(double equivalent, string remarks) = GetEquivalentandRemarks(FinalAverage);

            txtFinalAve.Text = FinalAverage.ToString("F2"); // + " / " + equivalent.ToString("F2");
        }

        public GradeManagementControl()
        {
            InitializeComponent();
        }




        private void txtFQ1_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboFItemsQ1.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtFQ1.Text, out score))
            {
                double items = Convert.ToDouble(cboFItemsQ1.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtFQ1.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                FQ1Ave = (score / items) * 60 + 40;
                txtFQ1Ave.Text = FQ1Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtFQ1Ave.Text = "";
            }
        }

        private void txtFQ2_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboFItemsQ2.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtFQ2.Text, out score))
            {
                double items = Convert.ToDouble(cboFItemsQ2.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtFQ2.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                FQ2Ave = (score / items) * 60 + 40;
                txtFQ2Ave.Text = FQ2Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtFQ2Ave.Text = "";
            }
        }

        private void txtFQ3_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboFItemsQ3.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtFQ3.Text, out score))
            {
                double items = Convert.ToDouble(cboFItemsQ3.SelectedItem);

                // ✅ Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtFQ3.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                FQ3Ave = (score / items) * 60 + 40;
                txtFQ3Ave.Text = FQ3Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtFQ3Ave.Text = "";
            }
        }

        private void txtFQ4_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboFItemsQ4.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtFQ4.Text, out score))
            {
                double items = Convert.ToDouble(cboFItemsQ4.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtFQ4.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                FQ4Ave = (score / items) * 60 + 40;
                txtFQ4Ave.Text = FQ4Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtFQ4Ave.Text = "";
            }
        }

        private void txtFE_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboFItemsFE.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtFE.Text, out score))
            {
                double items = Convert.ToDouble(cboFItemsFE.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtFE.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                FEave = (score / items) * 60 + 40;
                txtFEAve.Text = FEave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtFEAve.Text = "";
            }
        }

        private void txtMQ2_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboMItemsQ2.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtMQ2.Text, out score))
            {
                double items = Convert.ToDouble(cboMItemsQ2.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtMQ2.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                MQ2Ave = (score / items) * 60 + 40;
                txtMQ2Ave.Text = MQ2Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtMQ2Ave.Text = "";
            }
        }

        private void txtMQ3_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboMItemsQ3.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtMQ3.Text, out score))
            {
                double items = Convert.ToDouble(cboMItemsQ3.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtMQ3.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                MQ3Ave = (score / items) * 60 + 40;
                txtMQ3Ave.Text = MQ3Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtMQ3Ave.Text = "";
            }
        }

        private void txtMQ4_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboMItemsQ4.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtMQ4.Text, out score))
            {
                double items = Convert.ToDouble(cboMItemsQ4.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtMQ4.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                MQ4Ave = (score / items) * 60 + 40;
                txtMQ4Ave.Text = MQ4Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtMQ4Ave.Text = "";
            }
        }

        private void txtME_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboMItemsME.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtME.Text, out score))
            {
                double items = Convert.ToDouble(cboMItemsME.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtME.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                MEave = (score / items) * 60 + 40;
                txtMEAve.Text = MEave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtMQ1Ave.Text = "";
            }
        }


        private void GradeManagementControl_Load(object sender, EventArgs e)
        {

        }

        private void txtSA_Enter(object sender, EventArgs e)
        {
            txtSA.Clear();
        }

        /* private (double, string) GetEquivalentandRemarks(double average)
         {
             if (average == 4.00)
                 return (4.00, "incomplete");
             else if (average == 6.00)
                 return (6.00, "UW");

             if (average >= 97.00 && average <= 100.00)
                 return (1.00, "Passed");
             else if (average >= 94.00 && average < 97.00)
                 return (1.25, "Passed");
             else if (average >= 91.00 && average < 94.00)
                 return (1.50, "Passed");
             else if (average >= 88.00 && average < 91.00)
                 return (1.75, "Passed");
             else if (average >= 85.00 && average < 88.00)
                 return (2.00, "Passed");
             else if (average >= 82.00 && average < 85.00)
                 return (2.25, "Passed");
             else if (average >= 79.00 && average < 82.00)
                 return (2.50, "Passed");
             else if (average >= 76.00 && average < 79.00)
                 return (2.75, "Passed");
             else if (average >= 74.00 && average < 76.00)
                 return (3.00, "Passed");
             else if (average < 74.00)
                 return (5.00, "Failed");

             return (0, "Invalid Grade");
         }
        */
        private void txtMQ1_TextChanged(object sender, EventArgs e)
        {
            // Make sure the ComboBox has a selected item
            if (cboMItemsQ1.SelectedItem == null) return;

            double score;
            if (double.TryParse(txtMQ1.Text, out score))
            {
                double items = Convert.ToDouble(cboMItemsQ1.SelectedItem);

                // Validation: block scores higher than items
                if (score > items)
                {
                    MessageBox.Show("Score cannot be higher than number of items (" + items + ")");
                    txtMQ1.Text = items.ToString(); // reset to max allowed
                    score = items; // use max allowed
                }

                // Compute average
                MQ1Ave = (score / items) * 60 + 40;
                txtMQ1Ave.Text = MQ1Ave.ToString("F2");
                ComputeGrade();
            }
            else
            {
                // Optional: clear average if input is invalid
                txtMQ1Ave.Text = "";
            }

        }

    }
}
