using System;

namespace Harvester.Model
{
	public class CallNotes
	{
		public int CallNotesID { get; set; }
		//public int CallerID { get; set; }
		public string CallerName { get; set; }
		public string Notes { get; set; }
		public DateTime CalledDate { get; set; }
	}
}

