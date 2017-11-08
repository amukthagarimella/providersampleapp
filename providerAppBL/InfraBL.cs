namespace Harvester.BL
{
	using IAL;

	public static class InfraBL
	{
		private static InfraService service = new InfraService();

		public static void LogError (string error)
		{
			service.LogError(error);
		}
	}
}

