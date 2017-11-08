using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class Filter
	{
		public int FilterId { get; set;}
		public int FilterTypeID { get; set;}
		public IEnumerable<FilterActionCount> Actions { get; set;}
		public IEnumerable<Patient> Patients { get; set;}

	}
}

