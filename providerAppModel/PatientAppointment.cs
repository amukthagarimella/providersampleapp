using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class PatientAppointment
    {
		public int TotalYearsPatient { get; set; }
		public int TotalAppointmentsCount { get; set; }
		public int TotalFailedAppointments { get; set; }
		public int TotalCancelledAppointments { get; set; }
		public int TotalProposedTreatments { get; set; }
		public int TotalRejectedTreatments { get; set; }
		public bool? FamilyCompliance { get; set; }
		public bool? IsNewPatient { get; set; }
		public bool? HasInsurance { get; set; }
		public string RecallStatus { get; set; }

		public DateTime? FirstVisitDate { get; set; }
		public DateTime? LastDateSeen { get; set; }
		public DateTime? LastComprehensiveDate { get; set; }
		public DateTime? LastLimitedDate { get; set; }
		public DateTime? LastPeriodonticDate { get; set; }
		public DateTime? LastBiteWingDate { get; set; }
		public DateTime? LastIntraOralDate { get; set; }
		public DateTime? BiteWingDueDate { get; set; }
		public DateTime? IntraOralDueDate { get; set; }
		public DateTime? LastPanoramicDate { get; set; }
		public DateTime? LastFullMouthDate { get; set; }
		public DateTime? LastRegularAppointmentDate { get; set; }
		public DateTime? LastPreventiveApptDate { get; set; }
		public DateTime? NextRegularAppointment { get; set; }
		public DateTime? NextPreventiveAppointment { get; set; }

		public List<Appointment> ScheduledAppointments { get; set; }
        
    }
}
