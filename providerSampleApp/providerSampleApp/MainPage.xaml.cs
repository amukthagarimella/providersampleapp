using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Harvester.Model;
using Harvester.Common;
using Harvester.BL;

namespace providerSampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                var providerList = GetProviders();

                //username = User ID, pass = blank
                if (Username.Text == null)
                {
                    await DisplayAlert("Invalid", "Please enter a valid Username", "Continue");
                }
                else
                {
                    if (providerList.Any(x => x.UserID == Username.Text))
                    {
                        Config.Token = PracticeBL.Login(new Login()
                        {
                            ClinicId = GlobalVariables.ActiveClinic.ToString(),
                            UserId = Username.Text,
                            Password = string.Empty,
                        });

                        var currentUserID = Username.Text;
                        Test.IsVisible = Convert.ToBoolean(false);
                        await Navigation.PushAsync(new Page1());
                    }
                    else
                    {
                        Test.IsVisible = Convert.ToBoolean(true);
                        Test.Text = "Invalid Username";
                        Test.TextColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                var t = ex;
            }
        }
        public static List<User> GetProviders()
        {
            var practiceInfo = PracticeBL.GetPracticeUrls("CC_DEMO");
            Harvester.Common.Config.BaseAddress = practiceInfo.InternetUrl + "harvester//";
            Harvester.Common.GlobalVariables.ActiveClinic = new Harvester.Model.Clinic()
            {
                ClinicName = "Default",
                ClinicId = "1"
            };
            return Harvester.BL.PracticeBL.GetUsers();
        }
    }
}
