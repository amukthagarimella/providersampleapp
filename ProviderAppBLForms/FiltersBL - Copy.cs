namespace Harvester.BL
{
	using Model;
	using System.Collections.Generic;
	using IAL;
	using System.Linq;

	public static class FiltersBL
	{
		private static FilterService filterService = new FilterService();

		public static List<PatientFilter> GetPatientFilters()
		{
			var patientFilterGroup = filterService.GetFilters();
			if (patientFilterGroup != null)
			{
				var headers = patientFilterGroup.Where(filter => filter.ParentId == null);
				foreach (var child in headers)
				{
					child.IsRule = false;
				}
			}
			return patientFilterGroup;
		}

		public static Filter GetPatients(int queryId, int typeId)
		{
			var filter = filterService.GetPatients(queryId, typeId);
			foreach (Patient patient in filter.Patients)
			{
				if (!patient.FilterTypeActionID.HasValue)
					patient.FilterTypeActionID = 1;
			}
			return filter;
		}

        public static int GetTodaysCallsNotificationCount()
        {
            return filterService.GetTodaysCallsNotificationCount();
        }

		//public static int InsertCustomFilter(CustomFilter filter)
		//{
		//	return filterService.InsertCustomFilter(filter);
		//}

		public static int DeleteCustomFilter(int callerId)
		{
			return filterService.DeleteCustomFilter(callerId);
		}

		public static List<PatientColumnMetaData> GetFilterColumns()
		{
			return filterService.GetFilterColumns();
		}
	}	  
}

