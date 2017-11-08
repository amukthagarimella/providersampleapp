namespace Harvester.IAL
{
    using System;
    using Harvester.Common;
    using System.Net;
    using System.IO;

	public class InfraService
	{
		public void LogError (string error)
		{
			try 
			{
				var request = WebRequest.CreateHttp (String.Concat (Config.BaseAddress, "api/log/error"));
				request.Method = "POST";
				request.ContentType = "application/json";
				var reqStream = request.GetRequestStreamAsync ().Result;
				using (var streamWriter = new StreamWriter (reqStream)) {
					streamWriter.Write (String.Format ("\"{0}\"", error));
					streamWriter.Flush ();
				}					
				var response = request.GetResponseAsync ().Result;
				using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
					var content = reader.ReadToEnd ();
				}
			} 
			catch
			{
				//throw Util.HandleAPIException (ex, "LogError"); //Comment to avoid error log failure
			}
		}
	}
}

