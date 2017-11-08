using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class Appointment
    {
        public int AppointmentID;
        public DateTime? AppointmentTime;
        public int AppointmentType;
        public string AppointmentTypeDescription;
        public List<string> ServiceCodes;
        public List<string> ProviderIDs;
		public string AppointmentStatus;
        public short AppointmentTypeId { get; set; }
    }
}
