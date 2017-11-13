using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderAppData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPartnerContact : ContentPage
    {
        public AddPartnerContact()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            PartnerContactInfo partnerContact = new PartnerContactInfo(firstName.Text, lastName.Text, providerName.Text, contactNo.Text, emailId.Text);
            PartnerContacts.partnerContactsList.Add(partnerContact);
            await Navigation.PopAsync();

        }
    }
}