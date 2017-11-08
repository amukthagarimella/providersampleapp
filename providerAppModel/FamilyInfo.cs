using System;

namespace Harvester.Model
{
	public class FamilyInfo
	{
		public string MemberID { get; set; }

		public string MemberName { get; set; }

		public string FullName {
			get { return String.Format("{0}, {1}", MemberName.Split(' ')[1], MemberName.Split(' ')[0]); }
		}

		public string RecallStatus { get; set; }

		public DateTime? RecallDate { get; set; }

		public DateTime? NextPreventiveApptDate { get; set; }

		public string PlanStatus { get; set; }

		public decimal TotalProposedRevenue {
			get;
			set;
		}
	}
}
