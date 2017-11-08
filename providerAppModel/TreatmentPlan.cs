using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
	public class TreatmentPlan
	{
		public long TreatmentPlanID { get; set; }
		public string TreatmentPlanTitle { get; set; }
		public string TreatmentPlanStatus { get; set; }
		public decimal ProposedRevenue { get; set; }
		public string Notes { get; set; }
		public int PhaseCount { get; set; }

		public bool IsExpand {
			get;
			set;
		}


		public float Height {
			get {
				if (!IsExpand || Phases == null) {
					return 46;
				} 
				return Convert.ToSingle (46 + Phases.Sum (phase => phase.Height));
			}
		}

		public List<Phase> Phases { get; set; }
	}
}
