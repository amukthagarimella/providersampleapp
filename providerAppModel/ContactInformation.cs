using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
	public class ContactInformation
	{
		public string HomePhone { get; set; }
		public string CellPhone { get; set; }
		public string WorkPhone { get; set; }
		public string WorkPhoneExtn { get; set; }
		public string Email { get; set; }

		public Address HomeAddress { get; set; }
		public string ContactNotes { get; set; }
	}
}
