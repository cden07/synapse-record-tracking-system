using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace synapse_record_tracking_system
{

    public class Performance
    {
        public double AverageGrade { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public string Remarks { get; set; }
    }
}
