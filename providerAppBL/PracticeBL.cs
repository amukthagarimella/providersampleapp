namespace Harvester.BL
{
	using Model;
	using IAL;
	using System.Collections.Generic;

	public static class PracticeBL
	{
		private static PracticeService service = new PracticeService();

		public static PracticeInfo GetPracticeUrls (string practiceId)
		{
			return service.GetPracticeUrls (practiceId);
		}

		public static List<Clinic> GetActiveClinics()
		{
			return service.GetActiveClinics();
		} 

		public static List<User> GetUsers ()
		{
			return service.GetUsers ();
		}

		public static TokenResponse Login (Login login)
		{
			return service.Login (login);
		}
	}
}

