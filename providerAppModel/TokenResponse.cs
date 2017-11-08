using System;

namespace Harvester.Model
{
	public class TokenResponse
	{
		public string AccessToken { get; set; }

		public string TokenType { get; set; }

		public double ExpiresIn { get; set; }

		public string ExpireDateTimeUtc { get; set; }

		public string Scope { get; set; }

		public string Error { get; set; }
	}
}

