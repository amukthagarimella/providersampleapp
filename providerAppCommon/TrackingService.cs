namespace Harvester
{
	using System;
	using System.Collections.Generic;
	using Common;
	using HockeyApp;

	public static class TrackingService
	{
		public static void TrackAction(string action)
		{
			TrackAction(action, null, null);
		}

		public static void TrackAction(string action, string label)
		{
			TrackAction(action, label, null);
		}

		public static void TrackAction(string action, string label, int? value)
		{
			TrackScreen(action, label, value);
		}

		public static void TrackScreen(string screen)
		{
			TrackScreen(screen, null, null);
		}

		public static void TrackScreen(string screen, string actions)
		{
			TrackScreen(screen, actions, null);
		}

		public static void TrackScreen(string screen, string action, int? value)
		{
			Dictionary<string, string> properties = CustomPropertiesOnAction(action);

			string eventLog = String.Format("Screen: {0}", screen != null ? screen : "NA");
			if (action != null)
			{
				eventLog += String.Format("- Event: {0}", action);
			}

			MetricsManager.TrackEvent(eventLog, properties, new Dictionary<string, double> { });

		}

		public static void TrackException(string exception, string atevent, string screen)
		{
			Dictionary<string, string> exceptionDict = new Dictionary<string, string>();

			exceptionDict.Add("Exception", exception);
			var result = CustomPropertiesWithException(exceptionDict, atevent);

			MetricsManager.TrackEvent("Exception", result, new Dictionary<string, double> { });

		}

		public static void TrackCrashWithStackTrace(string stackTrace, string exceptionName, string exceptionReason)
		{
			Dictionary<string, string> crashDict = new Dictionary<string, string>();

			crashDict.Add("StackTrace", stackTrace);
			crashDict.Add("ExceptionName", exceptionName);
			crashDict.Add("ExceptionReason", exceptionReason);
			var crashResult = CustomPropertiesWithCrash(crashDict, null);

			MetricsManager.TrackEvent("Crash", crashResult, new Dictionary<string, double> { });
		}

		public static Dictionary<string, string> CustomPropertiesWithException(Dictionary<string, string> exception, string action)
		{
			Dictionary<string, string> properties = CustomPropertiesOnAction(action);

			if (exception != null)
			{
				foreach (var exce in exception)
				{
					properties.Add(exce.Key, exce.Value);
				}
			}
			return properties;
		}


		public static Dictionary<string, string> CustomPropertiesWithCrash(Dictionary<string, string> crash, string action)
		{
			Dictionary<string, string> properties = CustomPropertiesOnAction(action);
			if (properties != null)
			{
				foreach (var exce in properties)
				{
					properties.Add(exce.Key, exce.Value);
				}
			}
			return properties;

		}

		public static Dictionary<string, string> CustomPropertiesOnAction(string action)
		{
			Dictionary<string, string> properties = new Dictionary<string, string>();
			properties.Add("DeviceName", GlobalVariables.DeviceName);
			DateTime dt = DateTime.Now;
			string eventDateTime = String.Format("{0:MM/dd/yyyy HH:mm}", dt);
			properties.Add("EventDateTime", eventDateTime);

			if (action != null)
			{
				properties.Add("Action", action);
			}
			//loginn userdetails

			var ActiveUser = GlobalVariables.ActiveUser;

			if (ActiveUser != null)
			{
				properties.Add("UserID", GlobalVariables.ActiveUser.UserID);
			}
			if (ActiveUser != null)
			{
				properties.Add("UserName", GlobalVariables.ActiveUser.DisplayName);
			}
			if (ActiveUser != null)
			{
				properties.Add("PracticeID", GlobalVariables.PracticeId);
			}
			properties.Add("UserSessionID", GlobalVariables.UserSessionID);
			return properties;
		}
	}
}
