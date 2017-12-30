using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace providerSampleApp
{
    public class PartnerContactInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProviderName { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }
        //public string UserId { get; set; }
        //Image providerImage { get; set; }

       public PartnerContactInfo(string firstName, string lastName, string providerName, string contactNo, string contactEmail)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ProviderName = providerName;
            this.ContactNo = contactNo;
            this.ContactEmail = contactEmail;
            //this.UserId = MainPage.currentUserID;
        }
    }
}