using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class PatientFilter
	{
        public string Name
        {
			get;
			set;
		}

        public string DisplayName
        {
			get;
			set;
		}

        public int FilterID
        {
			get;
			set;
		}

        public int PatientCount
        {
			get;
			set;
		}

		public string DefaultSortKey
		{
			get;
			set;
		}

		public int DefaultSortDirection
		{
			get;
			set;
		}

        public string IconName
        {
            get
            {
                if (!String.IsNullOrEmpty(Name))
                {
                    if (PatientFilterType.Name.ToLower().Equals("calllogger"))
                    {
						return "user";
					}
                    return Name.ToLower().Replace(" ", string.Empty);
				}
				return null;
			}
		}

        public string IconPath
        {
            get { return String.Concat("Images/FilterIcons/", IconName, ".png"); }
		}

        public bool IsRule
        {
			get;
			set;
		}

        public PatientFilterType PatientFilterType
        {
			get;
			set;
		}

		public List<PatientColumnMetaData> PatientColumnsMetaData
		{
			get;
			set;
		}

        public int? ParentId { get; set; }
        public List<PatientFilter> SubFilters { get; set; }

		//public List<AndCustomCriteria> AndCustomCriteriaList { get; set; }
		//public List<OrCustomCriteria> OrCustomCriteriaList { get; set; }
		//public List<BetweenCustomCriteria> BetweenCustomCriteriaList { get; set; }
		//public List<DneCustomCriteria> DneCustomCriteriaList { get; set; }
	}
}

