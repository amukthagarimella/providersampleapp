using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class EmailDetails
	{
		public IEnumerable<EmailPatientDetails> PatientDetails { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public string PracticeName
		{
			get;
			set;
		}
	}
}
