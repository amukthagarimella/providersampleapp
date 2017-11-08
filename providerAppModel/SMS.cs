using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class SMS
	{
		public IEnumerable<string> patientIds { get; set; }
		public string ClinicId { get; set; }
		public string Message { get; set; }
	}
}
