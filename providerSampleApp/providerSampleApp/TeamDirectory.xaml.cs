using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harvester.Model;
using Harvester.BL;
using Harvester.Common;
using providerSampleApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using providerSampleApp.Services;
using System.Threading;
using providerSampleApp.Models;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDirectory : ContentPage
    {
        List<Provider> providerList = ProviderService.GetProviders();
        List<Provider> DentistList = new List<Provider>();
        List<Provider> HygienistList = new List<Provider>();
        List<Provider> OtherList = new List<Provider>();
        List<ProviderImageList> ImagesList = new List<ProviderImageList>();

        public TeamDirectory()
        {
            InitializeComponent();
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            foreach (var i in providerList)
            {
                foreach(var j in ImagesList)
                {
                    j.providerImage = ProviderService.GetProviderImage(i.ProviderID, token);
                }

                if (i.ProviderType == Provider.Type.Dentist)
                {
                    DentistList.Add(i);
                }
                else if (i.ProviderType == Provider.Type.Hygienist)
                {
                    HygienistList.Add(i);
                }
                else
                {
                    OtherList.Add(i);
                }
            }

            ImageView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            ImageView.BindingContext = ImagesList;
            DentistView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            DentistView.BindingContext = DentistList;
            HygienistView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            HygienistView.BindingContext = HygienistList;
            OthersView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            OthersView.BindingContext = OtherList;

        }


        async void ProviderView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Provider)e.SelectedItem;

            await Navigation.PushAsync(new ProviderDetails(itemSelected));
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            searchbar.IsVisible = true;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                DentistView.ItemsSource = DentistList;
                HygienistView.ItemsSource = HygienistList;
                OthersView.ItemsSource = OtherList;
            }

            else
            {
                DentistView.ItemsSource = DentistList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()));
                HygienistView.ItemsSource = HygienistList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()));
                OthersView.ItemsSource = OtherList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
    }
   
}