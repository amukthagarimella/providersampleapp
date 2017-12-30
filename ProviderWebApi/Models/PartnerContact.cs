using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProviderWebApi.Models
{
    public class PartnerContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProviderName { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }
       // public string UserId { get; set; }
    }
}