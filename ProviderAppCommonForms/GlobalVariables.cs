using System;
using Harvester.Model;
using System.Collections.Generic;

namespace Harvester.Common
{
	public static class GlobalVariables
	{
		public static User ActiveUser;
		public static List<PatientFilter> AllFilters;
		public static List<PatientFilter> AllSubFilters;
		public static List<Clinic> AllClinics;
		public static Clinic ActiveClinic;
		public static string DeviceName;
		public static string UserSessionID;
		public static string PracticeId;
		public static string PracticeName;
	}
}

