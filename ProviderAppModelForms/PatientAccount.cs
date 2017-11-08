using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class PatientAccount
    {
		public decimal EstimatedInsuranceBalance { get; set; }
		public AgingBalance OutOfPocketBalance { get; set; }
		public decimal RemainingBenefits { get; set; }
		public AgingBalance TotalBalance { get; set; }
		public AgingBalance OutStandingInsuranceBalance { get; set; }
		public decimal TotalCollected { get; set; }
		public decimal TotalProposedRevenue { get; set; }
		public decimal TotalRejectedRevenue { get; set; }
    }
}
