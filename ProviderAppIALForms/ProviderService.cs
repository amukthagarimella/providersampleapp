namespace Harvester.IAL
{
	using System;
	using System.Net;
	using System.IO;
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using Model;
	using Common;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading;

	public class ProviderService
	{
		public List<Provider> GetProviders ()
		{
			try
			{
				return Util.GetDataFromService<List<Provider>>(String.Concat(Config.BaseAddress, "api/providers/", GlobalVariables.ActiveClinic.ClinicId));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetProviders");
			}
		}

		public ProviderImage GetProviderImage (string providerId, CancellationToken ct)
		{
			try
			{
				var request = WebRequest.CreateHttp(String.Concat(Config.BaseAddress, "api/providers/image/", GlobalVariables.ActiveClinic.ClinicId, "/", providerId));
				using (ct.Register(() => request.Abort(), false))
				{
					var response = request.GetResponseAsync().Result;
					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						var content = reader.ReadToEnd();
						Util.ValidateResponse(content);
						return new ProviderImage() { Picture = JsonConvert.DeserializeObject<string>(content) };
					}
				}
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetProviderImage");
			}
		}

		public bool TestAlive()
		{
			var messageHandler = new HttpClientHandler();
			if (messageHandler.SupportsAutomaticDecompression) // returns true
				messageHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			var httpClient = new HttpClient(messageHandler);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
			httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
			httpClient.Timeout = new TimeSpan(0, 0, 2);
			HttpResponseMessage response = httpClient.GetAsync(String.Concat(Config.BaseAddress, "api/providers/testalive")).Result;
			if (response.IsSuccessStatusCode)
			{
				var content = response.Content.ReadAsStringAsync().Result;
				Util.ValidateResponse(content);
				return JsonConvert.DeserializeObject<bool>(content);
			}
			else
				throw new WebException(response.Content.ReadAsStringAsync().Result);
		}
	}
}

