namespace Harvester.IAL
{
	using System;
	using Model;
	using System.Collections.Generic;
	using System.Net;
	using Common;

	public class PracticeService
	{
		public PracticeInfo GetPracticeUrls(string practiceId)
		{
			try
			{
				Dictionary<string, string> headers = new Dictionary<string, string>();
				headers.Add("PracticeId", practiceId);
				return Util.GetDataFromService<PracticeInfo>(String.Concat(Config.SupportBaseAddress.TrimEnd('/'), "/api/practice/info"), headers);
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetPracticeUrls");
			}
		}

		public List<User> GetUsers ()
		{
			try
			{
				return Util.GetDataFromService<List<User>>(String.Concat(Config.BaseAddress, "api/practice/users/", GlobalVariables.ActiveClinic.ClinicId));
			}
			catch (Exception ex)
			{
                throw Util.HandleAPIException(ex, "GetUsers");
			}
		}

		public List<Clinic> GetActiveClinics()
		{
			try
			{
				return Util.GetDataFromService<List<Clinic>>(String.Concat(Config.BaseAddress, "api/practice/clinics"));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetActiveClinics");
			}
		}

		public TokenResponse Login (Login login)
		{
            try
            {
                return Util.PostDataToService<TokenResponse>(String.Concat(Config.BaseAddress, "api/practice/login"), login);
            }
            catch (Exception ex)
            {
                if (((ex.InnerException as WebException).Response as HttpWebResponse).StatusCode == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();
                else
                    throw Util.HandleAPIException(ex, "Login");
            }
		}
	}
}

