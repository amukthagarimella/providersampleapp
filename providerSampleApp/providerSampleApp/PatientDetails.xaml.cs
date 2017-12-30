using Harvester.Common;
using Harvester.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientDetails : ContentPage
    {
        public PatientDetails(object selectedItem)
        {
            InitializeComponent();
            var patientSelected = (Patient)selectedItem;
            firstnamevalue.Text = Util.TrimWithNullHandling(patientSelected.FirstName.ToString());
            lastNamevalue.Text = Util.TrimWithNullHandling(patientSelected.LastName.ToString());
            PatientImage patientImage = PatientService.GetPatientImage(patientSelected.PatientID, patientSelected.PatientImageID ?? default(int));
            //patientimage.Source = patientImage;
            Patient patient = PatientService.GetPatientDetails(patientSelected.PatientID, "contactinformation, personalinformation, provider, AppointmentDetails, FamilyMembers, alerts, account, insurances, treatmentplans, RecallDecisionActionID");
            if (patient.PersonalInformation.Gender.ToString() == "2")
            {
                gendervalue.Text = "F";
            }
            else if (patient.PersonalInformation.Gender.ToString() == "1")
            {
                gendervalue.Text = "M";
            }
            else
            {
                gendervalue.Text = "Unknown";
            }
            
            agevalue.Text = Util.TrimWithNullHandling(patient.PersonalInformation.Age.ToString());
            birthdayvalue.Text = Util.TrimWithNullHandling(patient.PersonalInformation.Birthday.ToString());
            respPartyValue.Text = Util.TrimWithNullHandling(patient.ResponsiblePartyName.ToString());
            workphonevalue.Text = Util.TrimWithNullHandling(patient.ContactInformation.WorkPhone.ToString());
            cellphoneValue.Text = Util.TrimWithNullHandling(patient.ContactInformation.CellPhone.ToString());
            homephonevalue.Text = Util.TrimWithNullHandling(patient.ContactInformation.HomePhone.ToString());
            emailValue.Text = Util.TrimWithNullHandling(patient.ContactInformation.Email.ToString());
            homeaddressvalue.Text = Util.TrimWithNullHandling(String.Concat(patient.ContactInformation.HomeAddress.Address1.ToString(), patient.ContactInformation.HomeAddress.Address2.ToString(), patient.ContactInformation.HomeAddress.City.ToString()," ", patient.ContactInformation.HomeAddress.State.ToString()," ", patient.ContactInformation.HomeAddress.Zipcode.ToString()));
            lastBitewingValue.Text = Util.TrimWithNullHandling(patient.AppointmentDetails.LastBiteWingDate.ToString());
            lastfmxValue.Text = Util.TrimWithNullHandling(patient.AppointmentDetails.LastFullMouthDate.ToString());
            lastpanoramicValue.Text = Util.TrimWithNullHandling(patient.AppointmentDetails.LastPanoramicDate.ToString());
            lastperiochartValue.Text = Util.TrimWithNullHandling(patient.AppointmentDetails.LastPeriodonticDate.ToString());

            
            foreach(var i in patient.PreferredProviders)
            {
                if(i.ProviderType==Provider.Type.Dentist)
                {
                    doctorValue.Text = Util.TrimWithNullHandling(i.FullName.ToString());
                }

            }
            foreach (var i in patient.PreferredProviders)
            {
                if (i.ProviderType == Provider.Type.Hygienist)
                {
                    hygenistValue.Text = Util.TrimWithNullHandling(i.FullName.ToString());
                }

            }
            
        }
        
    }
}