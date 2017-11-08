using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class Provider
    {
        public enum Type
        {
            Dentist = 1,
            Hygienist = 2
        };

        //provider basic Imformation
        public string ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string FullName { get{ return String.Format ("{0} {1}", FirstName, LastName); } }
        public Type ProviderType { get; set; }
        //public System.Drawing.Color ProviderColor { get; set; }
        public Gender Gender { get; set; }
		//for test review
    }
}
