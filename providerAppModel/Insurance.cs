using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClariCare.Model;

namespace Harvester.Model
{
    public class Insurance
    {
        public InsuranceType InsuranceType { get; set; }
        public string PolicyHolder { get; set; }
        public string Relationship { get; set; }
        public decimal RemBenefits { get; set; }
		public InsuranceCompany InsuranceCompany { get; set; }
    }

    public enum InsuranceType 
    {
        Primary,
        Secondary
    }
}
