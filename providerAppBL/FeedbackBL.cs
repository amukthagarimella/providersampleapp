using System;
using Harvester.Model;
using System.Collections.Generic;
using Harvester.IAL;

namespace Harvester.BL
{
	public static class FeedbackBL
	{
		public static string SaveFeedbackDetails(FeedbackDetails _feedbackDetails)
		{
			FeedbackService service = new FeedbackService();
			return service.SaveFeedbackDetails(_feedbackDetails);
		}
	}
}
