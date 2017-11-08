using System;
using System.Collections.Generic;
using System.Linq;

namespace Harvester.Model
{
	public class Phase
	{
		public int PhaseNumber {
			get;
			set;
		}

		public string PhaseName {
			get;
			set;
		}

		public decimal ProposedRevenue {
			get;
			set;
		}

		public List<PhaseItem> PhaseItems {
			get;
			set;
		}

		public bool IsExpand {
			get;
			set;
		}


		public float Height {
			get {
				if (!IsExpand || PhaseItems == null) {
					return 46;
				} 
				return Convert.ToSingle (46 + PhaseItems.Sum (item => item.Height));
			}
		}

	}
}

