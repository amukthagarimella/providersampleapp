using Harvester.BL;
using Harvester.Common;
using Harvester.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace providerSampleApp.Services
{
    class ProviderService
    {
        public static List<Provider> GetProviders()
        {
            var practiceInfo = PracticeBL.GetPracticeUrls("CC_DEMO");
            Config.BaseAddress = practiceInfo.InternetUrl + "harvester//";
            var addressHuddle = practiceInfo.InternetUrl + "huddle//";
            GlobalVariables.ActiveClinic = new Clinic()
            {
                ClinicName = "Default",
                ClinicId = "1"
            };
            try
            {
                return Util.GetDataFromService<List<Provider>>(String.Concat(addressHuddle, "api/providers/", GlobalVariables.ActiveClinic.ClinicId));
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetProviders");
            }
        }

        public static ProviderImage GetProviderImage(string providerId, CancellationToken ct)
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

    }
}
