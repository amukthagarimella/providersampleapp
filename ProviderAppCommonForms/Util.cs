using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using Harvester.Model;
using System.IO;


namespace Harvester.Common
{
	public static class Util
	{
		public static APIException HandleAPIException (Exception ex, string methodName)
		{
			if (ex.GetType () == typeof(ClariCareServiceNotReachableException)){
				return new APIException ("Unable to connect to the ClariCare service. Please check your internet connection.\nIf the error persists, please contact ClariCare.", ex);
			} 

			if (ex.GetType () == typeof(APIException)){
				return new APIException(ex.Message, ex);
			} 

			if (ex.GetType () == typeof(WebException)){
				var innerex = (ex as WebException);
				return new APIException (String.Format ("Error in {0}: {1}", methodName, innerex.Message), ex);
			} 

			if (ex.InnerException != null){
				if (ex.InnerException.GetType () == typeof(WebException)){
					var innerex = (ex.InnerException as WebException);
					return new APIException (String.Format ("Error in {0}: {1} {2}", methodName, innerex.Status, innerex.Message), ex);
				} 
			}

			return new APIException(String.Format("Error in {0}: {1}", methodName, ex.Message), ex);
		}

		public static void ValidateResponse (string content)
		{
			if (!String.IsNullOrEmpty (content)) {
				if (content.ToLower().StartsWith("<feed", StringComparison.CurrentCulture)) {//servicebus connection doesn't exist
					throw Util.HandleAPIException (new ClariCareServiceNotReachableException (), string.Empty);
				}
			}
		}

		public static HttpClient GetHttpClient (Dictionary<string,string> customheaders)
		{
			var messageHandler = new HttpClientHandler ();
			if (messageHandler.SupportsAutomaticDecompression) // returns true
				messageHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			var httpClient = new HttpClient (messageHandler);
			if (Config.Token != null)
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", Config.Token.AccessToken);
			httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
			httpClient.DefaultRequestHeaders.AcceptEncoding.Add (new StringWithQualityHeaderValue ("gzip"));
			httpClient.DefaultRequestHeaders.AcceptEncoding.Add (new StringWithQualityHeaderValue ("deflate"));
			if (customheaders != null) {
				foreach (var header in customheaders) {
					httpClient.DefaultRequestHeaders.Add (header.Key, header.Value);
				}
			}
			httpClient.DefaultRequestHeaders.Add("DeviceName", GlobalVariables.DeviceName);
			return httpClient;
		}

        public static string TrimWithNullHandling(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "N/A";
            else
                return input.Trim();
        }
       

		public static T GetDataFromService<T> (string url, Dictionary<string,string> headers = null)
		{
			var client = Util.GetHttpClient(headers);
			HttpResponseMessage response = client.GetAsync (url).Result;
			if (response.IsSuccessStatusCode) {					
				var content = response.Content.ReadAsStringAsync ().Result; 
				Util.ValidateResponse (content);
				return JsonConvert.DeserializeObject<T> (content);
			} else
				throw new WebException (response.Content.ReadAsStringAsync ().Result);
		}

        public static T PostDataToService<T>(string url, Object postObject)
        {
            /*Using HttpWebRequest suggests simplifying name to WebRequest*/
            var request = WebRequest.CreateHttp(url);
            if (Config.Token != null)
                request.Headers["Authorization"] = String.Format("Bearer {0}", Config.Token.AccessToken);
            request.Headers["DeviceName"] = GlobalVariables.DeviceName;
            request.Method = "POST";
            request.ContentType = "application/json";
            var reqStream = request.GetRequestStreamAsync().Result;
            using (var streamWriter = new StreamWriter(reqStream))
            {
                string json = JsonConvert.SerializeObject(postObject);
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var response = request.GetResponseAsync().Result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                Util.ValidateResponse(content);
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
        
	}
}

