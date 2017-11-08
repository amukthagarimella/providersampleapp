namespace Harvester.BL
{
	using Model;
	using IAL;
	using System.Threading;

	public static class ProviderBL
	{
		private static ProviderService service = new ProviderService();

		public static ProviderImage GetProviderImage (string providerId, CancellationToken ct)
		{
			return service.GetProviderImage(providerId, ct);
		}

		public static void TestAlive()
		{
			service.TestAlive();
		}
	}
}

