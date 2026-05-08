using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace synapse_record_tracking_system
{
    public class Grade
    {
        public int StudentID { get; set; }
        public string Subject { get; set; }

       
        public double MCP { get; set; }        
        public double MA { get; set; }        
        public double MQ1Ave { get; set; }
        public double MQ2Ave { get; set; }
        public double MQ3Ave { get; set; }
        public double MQ4Ave { get; set; }
        public double MEave { get; set; }     
        public double MLabGrade { get; set; }
        public double MidtermGrade { get; set; }

        
        public double FCP { get; set; }        
        public double FA { get; set; }       
        public double FQ1Ave { get; set; }
        public double FQ2Ave { get; set; }
        public double FQ3Ave { get; set; }
        public double FQ4Ave { get; set; }
        public double FEave { get; set; }      
        public double FLabGrade { get; set; }
        public double FinalGrade { get; set; }

    
        public double FinalAverage
        {
            get { return (MidtermGrade + FinalGrade) / 2; }
        }

        public string Remarks
        {
            get
            {
                return FinalAverage >= 75 ? "Passed" : "Failed";
            }
        }
    }
}
