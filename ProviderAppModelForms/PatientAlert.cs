using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class PatientAlert
    {
        public int AlertID { get; set; }
        public string AlertType { get; set; }
        public string Description { get; set; }
        public string PatientID { get; set; }
    }
}
