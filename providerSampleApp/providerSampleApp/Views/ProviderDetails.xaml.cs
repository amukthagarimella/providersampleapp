using Harvester.Common;
using Harvester.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace providerSampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProviderDetails : ContentPage
    {
        public ProviderDetails(object selectedItem)
        {
            Provider selectedProvider = (Provider)selectedItem;
            providerId.Text = Util.TrimWithNullHandling(selectedProvider.ProviderID.ToString());
            name.Text = Util.TrimWithNullHandling(selectedProvider.FullName.ToString());
            gender.Text = Util.TrimWithNullHandling(selectedProvider.Gender.ToString());
            providertype.Text = Util.TrimWithNullHandling(selectedProvider.ProviderType.ToString());
            InitializeComponent();
        }
    }
}