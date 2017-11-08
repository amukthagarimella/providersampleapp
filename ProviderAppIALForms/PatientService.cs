namespace Harvester.IAL
{
	using System;
	using System.Collections.Generic;
	using Model;
	using Common;
	using System.Threading.Tasks;

	public class PatientService
	{
		public List<Patient> GetPatientSearch (string name)
		{
			try 
			{
				return Util.GetDataFromService<List<Patient>> (String.Concat (Config.BaseAddress, "api/patients/search/",GlobalVariables.ActiveClinic.ClinicId,"/", name));
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatientSearch");
			}
		}

		public Filter GetPatients (int queryId, int typeId)
		{
			try 
			{
				return Util.GetDataFromService<Filter>(String.Concat(Config.BaseAddress, "api/filters/patients/", GlobalVariables.ActiveClinic.ClinicId, "/", typeId.ToString(), "/", queryId.ToString(), "/") );
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatients");
			}
		}

		public PatientImage GetPatientImage (string patientId, int imageId)
		{
			try 
			{
				return  new PatientImage (){ Picture = Util.GetDataFromService<string> (String.Concat (Config.BaseAddress, "api/patients/image/", GlobalVariables.ActiveClinic.ClinicId, "/", patientId, "/", imageId.ToString ())) };
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatientImage");
			}
		}

		public List<Chart> GetPatientCharts (string patientID)
		{
			try 
			{
				return  Util.GetDataFromService<List<Chart>> (String.Concat (Config.BaseAddress, "api/patients/chart/",GlobalVariables.ActiveClinic.ClinicId, "/", patientID));
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatientCharts");
			}
		}

		public Rtbc271 RunPatientRtbc271(string patientID)
		{
			try
			{
				return Util.GetDataFromService<Rtbc271>(String.Concat(Config.BaseAddress, "api/patients/newrtbc/", GlobalVariables.ActiveClinic.ClinicId, "/", patientID, "/"));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "RunNewPatientRtbc");
			}
		}

		public Rtbc271 GetPatientLastRtbc(string patientID)
		{
			try
			{
				return Util.GetDataFromService<Rtbc271>(String.Concat(Config.BaseAddress, "api/patients/getrtbc/", GlobalVariables.ActiveClinic.ClinicId, "/", patientID, "/"));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetLastPatientRtbc");
			}
		}

		public List<Note> GetPatientNotes (string patientID)
		{
			try 
			{
				return  Util.GetDataFromService<List<Note>> (String.Concat (Config.BaseAddress, "api/patients/notes/",GlobalVariables.ActiveClinic.ClinicId, "/", patientID));
			} 
			catch 
			{
				return null;
			}
		}

		public Patient GetPatientDetails(string patientID, string expandQuery)
		{
			try
			{
				return Util.GetDataFromService<Patient>(String.Concat(Config.BaseAddress, String.Format("api/patients/{0}/{1}",GlobalVariables.ActiveClinic.ClinicId, patientID), "?expand=", expandQuery));
			}
			catch (Exception ex)
			{
				throw Util.HandleAPIException(ex, "GetPatientDetails");
			}
		}

		public Patient GetPatientDetails (string patientID, string appointmentId, string expandQuery)
		{
			try 
			{
				return  Util.GetDataFromService<Patient> (String.Concat (Config.BaseAddress, String.Format("api/patients/{0}/{1}?appointment={2}",GlobalVariables.ActiveClinic.ClinicId, patientID, appointmentId), "&&expand=", expandQuery));
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatientDetails");
			}
		}

		public CallActionResult InsertCallLoggerAction(string patientID, CallAction action)
		{
            try
            {
                return Util.PostDataToService<CallActionResult>(String.Concat(Config.BaseAddress, "api/patients/callaction/", GlobalVariables.ActiveClinic.ClinicId, "/", patientID), action);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "InsertCallLoggerAction");
            }
		}

		public List<ImageExam> GetPatientIntraOral (string patientId)
		{
			try 
			{
				return  Util.GetDataFromService<List<ImageExam>> (String.Concat (Config.BaseAddress, "api/patients/imageexams/", GlobalVariables.ActiveClinic.ClinicId, "/", patientId, "/intraoral"));
			} 
			catch (Exception ex) 
			{
				throw Util.HandleAPIException (ex, "GetPatientIntraOral");
			}
		}

		public async Task<List<string>> SendEmailDetails(EmailDetails _emailDetails)
		{
			try
			{
                var result = await Task.Run(() =>
                {
                    return Util.PostDataToService<List<string>>(String.Concat(Config.BaseAddress, "api/patients/sendemail/"), _emailDetails);
                });
                return result;
			}
			catch (Exception ex)
			{
                throw Util.HandleAPIException(ex, "SendEmailDetails");
			}
		}

        public async Task<List<Rtbc271>> RunRtbcMultiplePatients(List<EmailPatientDetails> _emailPatientDetails)
		{
            try
            {
                var result = await Task.Run(() =>
                {
                    return Util.PostDataToService<List<Rtbc271>>(String.Concat(Config.BaseAddress, "api/patients/runrtbcmultiple/"), _emailPatientDetails);
                });
                return result;
            }
            catch (TimeoutException)
            {
                return new List<Rtbc271>();
            }
            catch (Exception ex)
            {
                Util.HandleAPIException(ex, "RunRtbcMultiplePatients");
                return null;
            }
		}

		public string SendRTBCEmail(EmailMessage _emailMessage)
		{
            try
            {
                return Util.PostDataToService<string>(String.Concat(Config.BaseAddress, "api/patients/sendpdf/"), _emailMessage);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "SendRTBCEmail");
            }
		}

		public string UpdateEmail(string patientId, ContactInformation _contactInformation)
		{
            try
            {
                return Util.PostDataToService<string>(String.Concat(Config.BaseAddress, "api/patients/contactinformation/", GlobalVariables.ActiveClinic.ClinicId, "/", patientId), _contactInformation);
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "UpdateEmail");
            }
		}

		public async Task<List<string>> SendTextMessage(SMS _sms)
		{
            try
            {
                var result = await Task.Run(() =>
                {
                    return Util.PostDataToService<List<string>>(String.Concat(Config.BaseAddress, "api/patients/sendsms/"), _sms);
                });
                return result;
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "SendTextMessage");
            }
		}
	}
}

