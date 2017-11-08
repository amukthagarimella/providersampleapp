namespace Harvester.BL
{
	using Model;
	using System.Collections.Generic;
	using IAL;
	using System.Threading.Tasks;

	public static class PatientBL
	{
		private static PatientService service = new PatientService();

		public static List<Patient> GetPatientSearch (string name)
		{
			return service.GetPatientSearch(name);
		}

		public static CallActionResult InsertCallLoggerAction(string patientID, CallAction action)
		{
			return service.InsertCallLoggerAction (patientID, action);
		}

		public static Patient GetPatientDetails (string patientID, int appointmentId, string expandQuery)
		{
			return service.GetPatientDetails (patientID, appointmentId.ToString(), expandQuery);
		}

		public static Patient GetPatientDetails(string patientID, string expandQuery)
		{
			return service.GetPatientDetails(patientID, expandQuery);
		}

		public static List<Chart> GetPatientCharts (string patientID)
		{
			return service.GetPatientCharts (patientID);
		}

		public static List<Note> GetPatientNotes (string patientID)
		{
			return service.GetPatientNotes (patientID);
		}

		public static PatientImage GetPatientImage (string patientID, int imageID)
		{
			return service.GetPatientImage (patientID, imageID);
		}

		public static List<ImageExam> GetPatientIntraOral (string patientId)
		{
			return service.GetPatientIntraOral (patientId);
		}

		public static async Task<List<string>> SendEmailDetails(EmailDetails _emailDetails)
		{
			return await service.SendEmailDetails(_emailDetails);
		}

        public static async Task<List<Rtbc271>> RunRtbcMultiplePatients(List<EmailPatientDetails> _emailPatientDetails)
		{
			return await service.RunRtbcMultiplePatients(_emailPatientDetails);
		}

		public static Rtbc271 RunPatientRtbc271(string patientId)
		{
			return service.RunPatientRtbc271(patientId);
		}

		public static Rtbc271 GetPatientLastRtbc(string patientId)
		{
			return service.GetPatientLastRtbc(patientId);
		}

		public static string SendRTBCEmail(EmailMessage _emailMessage)
		{
			return service.SendRTBCEmail(_emailMessage);
		}

		public static string UpdateEmail(string patientId, ContactInformation _contactInformation)
		{
			return service.UpdateEmail(patientId, _contactInformation);
		}

		public static async Task<List<string>> SendTextMessage(SMS _sms)
		{
			return await service.SendTextMessage(_sms);
		}
	}
}

