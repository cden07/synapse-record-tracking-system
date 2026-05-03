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
            string FitemQ1 = cboFItemsQ1.SelectedItem.ToString();
            //Convert.ToDouble(txtFQ1.Text);
            //formula to get the Q1 AVE: (Score / Item) * 60 + 40 /

            Double FQ1;
            Double.TryParse(txtFQ1.Text, out FQ1);

            FQ1Ave = (FQ1 / Convert.ToDouble(FitemQ1)) * 60 + 40;
            txtFQ1Ave.Text = FQ1Ave.ToString();
            ComputeGrade();
        }

        private void txtFQ2_TextChanged(object sender, EventArgs e)
        {
            string FitemQ2 = cboFItemsQ2.SelectedItem.ToString();
            //Convert.ToDouble(txtFQ2.Text);
            //formula to get the Q2 AVE: (Score / Item) * 60 + 40 /

            Double FQ2;
            Double.TryParse(txtFQ2.Text, out FQ2);

            FQ2Ave = (FQ2 / Convert.ToDouble(FitemQ2)) * 60 + 40;
            txtFQ2Ave.Text = FQ2Ave.ToString();
            ComputeGrade();
        }

        private void txtFQ3_TextChanged(object sender, EventArgs e)
        {
            string FitemQ3 = cboFItemsQ3.SelectedItem.ToString();
            //Convert.ToDouble(txtFQ3.Text);
            //formula to get the Q3 AVE: (Score / Item) * 60 + 40 /

            Double FQ3;
            Double.TryParse(txtFQ3.Text, out FQ3);

            FQ3Ave = (FQ3 / Convert.ToDouble(FitemQ3)) * 60 + 40;
            txtFQ3Ave.Text = FQ3Ave.ToString();
            ComputeGrade();
        }

        private void txtFQ4_TextChanged(object sender, EventArgs e)
        {
            string FitemQ4 = cboFItemsQ4.SelectedItem.ToString();
            //Convert.ToDouble(txtFQ4.Text);
            //formula to get the Q4 AVE: (Score / Item) * 60 + 40 /

            Double FQ4;
            Double.TryParse(txtFQ4.Text, out FQ4);

            FQ4Ave = (FQ4 / Convert.ToDouble(FitemQ4)) * 60 + 40;
            txtFQ4Ave.Text = FQ4Ave.ToString();
            ComputeGrade();
        }

        private void txtFE_TextChanged(object sender, EventArgs e)
        {
            string FitemFE = cboFItemsFE.SelectedItem.ToString();
            //Convert.ToDouble(txtFE.Text);
            //formula to get the FE AVE: (Score / Item) * 60 + 40 /

            Double FE;
            Double.TryParse(txtFE.Text, out FE);

            FEave = (FE / Convert.ToDouble(FitemFE)) * 60 + 40;
            txtFEAve.Text = FEave.ToString();
            ComputeGrade();
        }

        private void txtMQ2_TextChanged(object sender, EventArgs e)
        {
            string MitemQ2 = cboMItemsQ2.SelectedItem.ToString();
            //Convert.ToDouble(txtMQ2.Text);
            //formula to get the Q2 AVE: (Score / Item) * 60 + 40 /

            Double MQ2;
            Double.TryParse(txtMQ2.Text, out MQ2);

            MQ2Ave = (MQ2 / Convert.ToDouble(MitemQ2)) * 60 + 40;
            txtMQ2Ave.Text = MQ2Ave.ToString();
            ComputeGrade();
        }

        private void txtMQ3_TextChanged(object sender, EventArgs e)
        {
            string MitemQ3 = cboMItemsQ3.SelectedItem.ToString();
            //Convert.ToDouble(txtMQ3.Text);
            //formula to get the Q3 AVE: (Score / Item) * 60 + 40 /

            Double MQ3;
            Double.TryParse(txtMQ3.Text, out MQ3);

            MQ3Ave = (MQ3 / Convert.ToDouble(MitemQ3)) * 60 + 40;
            txtMQ3Ave.Text = MQ3Ave.ToString();
            ComputeGrade();
        }

        private void txtMQ4_TextChanged(object sender, EventArgs e)
        {
            string MitemQ4 = cboMItemsQ4.SelectedItem.ToString();
            //Convert.ToDouble(txtMQ4.Text);
            //formula to get the Q4 AVE: (Score / Item) * 60 + 40 /

            Double MQ4;
            Double.TryParse(txtMQ4.Text, out MQ4);

            MQ4Ave = (MQ4 / Convert.ToDouble(MitemQ4)) * 60 + 40;
            txtMQ4Ave.Text = MQ4Ave.ToString();
            ComputeGrade();
        }

        private void txtME_TextChanged(object sender, EventArgs e)
        {
            string MItemsMe = cboMItemsME.SelectedItem.ToString();
            //Convert.ToDouble(txtME.Text);
            //formula to get the ME AVE: (Score / Item) * 60 + 40 /

            Double ME;
            Double.TryParse(txtME.Text, out ME);

            MEave = (ME / Convert.ToDouble(MItemsMe)) * 60 + 40;
            txtMEAve.Text = MEave.ToString();
            ComputeGrade();
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
            string MitemQ1 = cboMItemsQ1.SelectedItem.ToString();
            //Convert.ToDouble(txtMQ1.Text);
            //formula to get the Q1 AVE: (Score / Item) * 60 + 40 /

            Double MQ1;
            Double.TryParse(txtMQ1.Text, out MQ1);

            MQ1Ave = (MQ1 / Convert.ToDouble(MitemQ1)) * 60 + 40;
            txtMQ1Ave.Text = MQ1Ave.ToString();
            ComputeGrade();
        }



    }

}
