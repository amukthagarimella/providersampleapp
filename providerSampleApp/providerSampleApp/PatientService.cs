using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harvester.Common;
using Harvester.BL;
using Harvester.Model;
using Xamarin.Forms;

namespace providerSampleApp
{
    public class PatientService 
    {
        public static Filter GetPatients(int queryId, int typeId)
        {
            var patientInfo= PracticeBL.GetPracticeUrls("CC_DEMO");
            Config.BaseAddress = patientInfo.InternetUrl + "harvester//";
            GlobalVariables.ActiveClinic = new Clinic()
            {
                ClinicName = "Default",
                ClinicId = "1"
            };
            try
            {
                return Util.GetDataFromService<Filter>(String.Concat(Config.BaseAddress, "api/filters/patients/", GlobalVariables.ActiveClinic.ClinicId, "/", typeId.ToString(), "/", queryId.ToString(), "/"));
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetPatients");
            }
        }
        public static Patient GetPatientDetails(string patientID, string expandQuery)
        {
            try
            {
                return Util.GetDataFromService<Patient>(String.Concat(Config.BaseAddress, String.Format("api/patients/{0}/{1}", GlobalVariables.ActiveClinic.ClinicId, patientID), "?expand=", expandQuery));
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetPatientDetails");
            }
        }
        public static PatientImage GetPatientImage(string patientId, int imageId)
        {
            try
            {
                return new PatientImage() { Picture = Util.GetDataFromService<string>(String.Concat(Config.BaseAddress, "api/patients/image/", GlobalVariables.ActiveClinic.ClinicId, "/", patientId, "/", imageId.ToString())) };
            }
            catch (Exception ex)
            {
                throw Util.HandleAPIException(ex, "GetPatientImage");
            }
        }
    }
}