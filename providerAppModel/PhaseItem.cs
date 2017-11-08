using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harvester.Model
{
	public class PhaseItem
	{
		public string ServiceCode { get; set; }

		public string ServiceDescription { get; set; }

		public DateTime? AppointmentDate { get; set; }

		public string PhaseItemStatus { get; set; }

		public string ToothRange { get; set; }

		public decimal Fee { get; set; }

		public decimal InsuranceCost { get; set; }

		public decimal Balance { get; set; }

		public decimal ProposedRevenue {
			get;
			set;
		}

		public float Height {
			get {
				return 46;
			}
		}
	}
}
