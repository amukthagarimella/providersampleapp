using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
	public enum BucketType
	{
		TodaysPatients = 1,
		BrokenAppointments = 2,
		AccountsReceivable = 3,
		Restorative = 4,
		Recall = 5,
		BenefitMax = 6,
		Discard = 7,
		Custom = 8
	}
}