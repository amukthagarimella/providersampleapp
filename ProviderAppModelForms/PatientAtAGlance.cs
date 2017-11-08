using System;

namespace Harvester.Model
{
	public class PatientAtAGlance
	{
		public string Title {
			get;
			set;
		}
		public string ImagePath {
			get;
			set;
		}
		public string SubTitle {
			get;
			set;
		}
		public bool ShowLink {
			get;
			set;
		}

		public string LinkName {
			get;
			set;
		}

		public bool Highlighted {
			get;
			set;
		}

		public string Tag {
			get;
			set;
		}
	}
}

