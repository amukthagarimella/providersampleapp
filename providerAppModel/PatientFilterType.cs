using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class PatientFilterType
	{
		public string Name {
			get;
			set;
		}

		public string DisplayName {
			get;
			set;
		}

		public int FilterTypeID{
			get;
			set;
		}

		public List<FilterAction> FilterActions {
			get;
			set;
		}
	}
}

