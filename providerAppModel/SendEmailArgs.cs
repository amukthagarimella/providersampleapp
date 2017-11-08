using System;
namespace Harvester
{
	public class SendEmailArgs : EventArgs
	{
		private string _emailToText;
		private String _emailSubject;
		private string _emailDescription;
		private string _emailAttachment;
		private string _contactNotes;

		public string AttachmentName
		{
			get
			{
				return _emailAttachment;
			}
		}

		public string EmailToText
		{
			get
			{
				return _emailToText;
			}
		}

		public string EmailSubject
		{
			get
			{
				return _emailSubject;
			}
		}

		public string EmailDescription
		{
			get
			{
				return _emailDescription;
			}
		}
		public string ContactNotes
		{
			get
			{
				return _contactNotes;
			}
		}
		public SendEmailArgs(IntPtr h) : base ()
		{
		}

		public SendEmailArgs(string emailToText, string ContactNotes)
		{
			_emailToText = emailToText;
			_contactNotes = ContactNotes;
		}

		public SendEmailArgs(string emailToText, string emailSubject, string emailDescription)
		{
			_emailToText = emailToText;
			_emailSubject = emailSubject;
			_emailDescription = emailDescription;
		}

		public SendEmailArgs(string emailToText, string emailSubject, string emailDescription, string emailAttachmentName)
		{
			_emailToText = emailToText;
			_emailSubject = emailSubject;
			_emailDescription = emailDescription;
			_emailAttachment = emailAttachmentName;
		}
	}
}



				