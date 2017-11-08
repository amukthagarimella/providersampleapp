using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harvester.Model;
using Harvester.BL;
using Harvester.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDirectory : ContentPage
    {
        List<User> providerList = MainPage.GetProviders();
        public TeamDirectory()
        {
            InitializeComponent();

            ProviderView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            ProviderView.BindingContext = providerList;
        }

             
        async void ProviderView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {   
            var itemSelected = (User)e.SelectedItem;
            Label Name = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 25
            };
            Label displayName = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                VerticalOptions = LayoutOptions.Center
            };
            foreach (var i in providerList)
            {
                if (itemSelected.FirstName.ToString() == i.FirstName.ToString())
                {
                    Name.Text = i.FirstName +" "+ i.LastName;
                    displayName.Text = i.DisplayName;
                }
            }

            ContentPage page = new ContentPage()
            {
                   Title="Provider Details"
            };
            Button okButton = new Button()
            {
                Text = "OK",
            };
            okButton.Clicked += ((o2, e2) =>
            {
                this.Navigation.PopModalAsync();
            });
            StackLayout stack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(20, 50, 20, 20)
            };
            stack.Children.Add(Name);
            stack.Children.Add(displayName);
            stack.Children.Add(okButton);
            page.Content = stack;

            await Navigation.PushModalAsync(page, false);
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            searchbar.IsVisible = true;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ProviderView.ItemsSource = providerList;
            }

            else
            {   
                ProviderView.ItemsSource = providerList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
    }
}