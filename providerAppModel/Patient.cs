using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class Patient
	{
		//patient basic Information

		#region

		public string FullName
		{
			get { return String.Format("{0}, {1}", LastName, FirstName); }
		}

		public string PatientID { get; set; }

		public string PatientDB { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int? PatientImageID
		{
			get;
			set;
		}

		public string PatientImage
		{
			get;
			set;
		}

		#endregion

		public int AppointmentId { get; set; }

		public PersonalInformation PersonalInformation { get; set; }

		public ContactInformation ContactInformation { get; set; }

		public PatientAppointment AppointmentDetails { get; set; }

		//preferred providers
		public List<Provider> PreferredProviders { get; set; }

		//Primary Provider
		public string PrimaryProvider { get; set; }

		//patient family
		public List<FamilyInfo> FamilyMembers { get; set; }

		public List<Insurance> Insurances { get; set; }

		public PatientAccount Account { get; set; }

		public Employer Employer { get; set; }

		public List<PatientAlert> Alerts { get; set; }

		public List<Note> Notes { get; set; }

		public List<Chart> Charts { get; set; }

		public List<TreatmentPlan> TreatmentPlans { get; set; }

		public List<IntraOral> IntraOrals { get; set; }

		public string ResponsibleParty { get; set; }

		public string ResponsiblePartyDB { get; set; }

		public string ResponsiblePartyName { get; set; }

		public string ResponsiblePartyStatus { get; set; }

		public bool Premedication { get; set; }

		public string PatientPlanStatus { get; set; }

		public string RecallStatus { get; set; }

		public int? FilterTypeActionID { get; set; }

		public int? CallLogActionID { get; set; }

		public DateTime? RecallDate { get; set; }

		public DateTime? AppointmentDate { get; set; }

		public CallDetails CallDetails { get; set; }

		public decimal BalanceDue { get; set; }

		public DateTime? LastVisitDate { get; set; }

		public DateTime? LastPaymentDate { get; set; }

		public DateTime? NextScheduledAppt { get; set; }

		public string CallBucket { get; set; }

		public int RecallSortIndex { get; set; }

		public decimal BenefitsRemaining { get; set; }

		public decimal TotalProposedRevenue { get; set;}

		public decimal TotalOffplanRevenue { get; set;}

		public decimal TotalRejectedRevenue { get; set; }

		public string AppointmentType { get; set; }

		public string HasInsurance { get; set; }

		public DateTime? LastRecallAppointment { get; set;}

		public List<int> CallBucketIds { get; set; }

		public bool IsChecked { set; get; }

		public string MissedTypeAppointment { get; set; }

		public string BenefitsIndicator { get; set; } = "red";

	}
}

