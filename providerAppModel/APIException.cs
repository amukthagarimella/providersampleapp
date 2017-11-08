using System;

namespace Harvester.Model
{
	public class APIException : Exception
	{
		public new string Message = string.Empty;
		public Exception Ex = null;

		public APIException (string message, Exception ex)
		{
			Message = message;
			Ex = ex;
		}
	}

	public class HarvestrHandledException: Exception
	{
		public string Id = string.Empty;
		public new string Message = string.Empty;

		public HarvestrHandledException (string message, string id)
		{
			Message = message;
			Id = id;
		}
	}

	public class NetworkNotReachableException: Exception
	{
		public new string Message = string.Empty;

		public NetworkNotReachableException (string message)
		{
			Message = message;
		}
	}

	public class InvalidTokenException: Exception
	{
		public new string Message = string.Empty;

		public InvalidTokenException (string message)
		{
			Message = message;
		}
	}

	public class ClariCareServiceNotReachableException: Exception
	{
		public ClariCareServiceNotReachableException ()
		{
		}
	}
}

