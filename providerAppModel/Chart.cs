using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class Chart
	{
		public DateTime? PlannedDate { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public string ServiceCode { get; set; }
		public string ToothRange { get; set; }
	}
}

