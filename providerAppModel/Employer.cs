using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class Employer
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public short FeeSchedule { get; set; }
        public double YearlyDeductible { get; set; }
        public string Notes { get; set; }
    }
}
