using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class CallActionResult
	{
		public int PatientId { get; set;}
		public int CallActionId { get; set;}
		public int CallerId { get; set;}
		public IEnumerable<CallNotes> Notes { get; set;}
		public bool Result { get; set;}
	}
}

