namespace Harvester.IAL
{
	using System;
	using Common;
	using Model;
	using System.Collections.Generic;

	public class FilterService
	{
		public List<PatientFilter> GetFilters()
		{
			try
			{
				return Util.GetDataFromService<List<PatientFilter>>(String.Concat(Config.BaseAddress, "api/filters/", GlobalVariables.ActiveClinic.ClinicId));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetFilters");
			}
		}

		public List<PatientColumnMetaData> GetFilterColumns()
		{
			try
			{
				return Util.GetDataFromService<List<PatientColumnMetaData>>(String.Concat(Config.BaseAddress, "api/filters/columns/"));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetFilterColumns");
			}
		}

		public Filter GetPatients(int queryId, int typeId)
		{
			try
			{
				return Util.GetDataFromService<Filter>(String.Concat(Config.BaseAddress, "api/filters/patients/", GlobalVariables.ActiveClinic.ClinicId, "/", typeId.ToString(), "/", queryId.ToString(), "/"));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetPatients");
			}
		}

		public int InsertCustomFilter(Filter filter)
		{
            try
            {
                return Util.PostDataToService<int>(String.Concat(Config.BaseAddress, "api/filters/customfilter"), filter);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "InsertCustomFilter");
            }
		}

		public int DeleteCustomFilter(int callerId)
		{
			try
			{
				return Util.GetDataFromService<int>(String.Concat(Config.BaseAddress, "api/filters/deletefilter/", GlobalVariables.ActiveClinic.ClinicId, "/", callerId));
			}
			catch (Exception ex)
			{
                throw Util.HandleAPIException(ex, "DeleteCustomFilter");
			}
		}

        public int GetTodaysCallsNotificationCount()
        {
            try
            {
                return Util.GetDataFromService<int>(String.Concat(Config.BaseAddress, "api/CallsNotification/", GlobalVariables.ActiveClinic.ClinicId));
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetTodaysCallsNotificationCount");
            }
        }
	}
}