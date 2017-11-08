using System;
namespace Harvester.Model
{
	public class EmailMessage
	{
		public string ToEmailAddress { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public string Attachment { get; set; }
		public string ProviderID { get; set; }
		public string PatientID { get; set; }
		public string AttachmentName { get; set; }
		public string PracticeName { get; set; }
	}
}
