namespace Harvester.IAL
{
    using System;
    using Harvester.Model;
    using Harvester.Common;

	public class FeedbackService
	{
		public string SaveFeedbackDetails(FeedbackDetails _feedbackDetails)
		{
            try
            {
                return Util.PostDataToService<string>(String.Concat(Config.BaseAddress, "api/Feedback/SaveFeedBack"), _feedbackDetails);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "SaveFeedbackDetails");
            }
		}
	}
}
