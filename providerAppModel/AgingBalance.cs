using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
	public class AgingBalance
	{
		public decimal CurrentBalance { get; set; }
		public decimal NetAmount { get; set; }
		public decimal? NinetyPlusBalance { get; set; }
		public decimal? SixtyToNinetyBalance { get; set; }
		public decimal? ThirtyToSixtyBalance { get; set; }
	}
}