using Harvester.Common;
using Harvester.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace providerSampleApp.Services
{
    class PartnerContactService
    {
        public static ObservableCollection<PartnerContactInfo> GetPartnerContacts(/*string UserId*/)
        {
            Config.BaseAddress = "http://providerwebapi20171212013001.azurewebsites.net/api/PartnerContacts";
            
            try
            {
                return Util.GetDataFromService<ObservableCollection<PartnerContactInfo>>(Config.BaseAddress);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetPartnerContacts");
            }
        }
        public static PartnerContactInfo PostPartnerContact(PartnerContactInfo partnerContact)
        {
            Config.BaseAddress = "http://providerwebapi20171212013001.azurewebsites.net/api/PartnerContacts";
            
            try
            {
                return Util.PostDataToService<PartnerContactInfo>(Config.BaseAddress, partnerContact);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "PostPartnerContact");
            }
        }
    }
}
