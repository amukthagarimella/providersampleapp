using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class CallDetails
	{
		public int? CallerID { get; set; }
		//public string CallerName { get; set; }
		public List<CallNotes> CallNotes { get; set; }
		public string CallScript { get; set; }
		public DateTime? CallBackDate { get; set; }
		public DateTime? ActionDate { get; set; }
		public List<CallAction> CallActions { get; set;}
	}
}

