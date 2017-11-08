using System;

namespace Harvester.Model
{
    public class CallAction
    {
        public int? CallActionId;
        public int CallerId;
        public string Notes;
        public DateTime? CallBackDate;
        public int AppointmentId { get; set; }
		public bool IsCustomCall { get; set;}
		public int FilterTypeId { get; set; }
		public string CallerName { get; set;}
    }
}

