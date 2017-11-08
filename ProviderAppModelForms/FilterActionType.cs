using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public enum FilterActionType
    {
        ToCall = 1,
        Completed = 2,//Scheduled Appointment
        CallBack = 3,
        NoFollowUp = 4,
        MaintainStatus = 5,
        Discard_Invalid_Status = 6,
        Discard_Unresponsive_Status = 7,
        Discard_Collections_Status = 8,
        Discard_Other_Status = 9,
        //Reactive = 10,
		Reactivated = 10
    }
}
