using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harvester.Model;
using Harvester.Common;
using Harvester.BL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Patients : ContentPage
    {
        Filter patientList = PatientService.GetPatients(9, 6);
        public Patients()
        {
            InitializeComponent();
            var patientDetailList = patientList.Patients;
            PatientView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            PatientView.BindingContext = patientDetailList;


        }
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            searchbar.IsVisible = true;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var patientDetailList = patientList.Patients;
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                PatientView.ItemsSource = patientDetailList;
            }

            else
            {
                PatientView.ItemsSource = patientDetailList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()) || x.LastName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
        async void PatientView_ItemSelected(object sender, SelectedItemChangedEventArgs e) => await Navigation.PushAsync(new PatientDetails(e.SelectedItem));
    }
}