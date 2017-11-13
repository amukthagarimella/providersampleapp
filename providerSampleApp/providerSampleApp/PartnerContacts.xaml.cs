using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderAppData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace providerSampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartnerContacts : ContentPage
    {
        public static ObservableCollection<PartnerContactInfo> partnerContactsList = new ObservableCollection<PartnerContactInfo>();
       // public static List<PartnerContactInfo> partnerContactsList = new List<PartnerContactInfo>();
        public PartnerContacts()
        {
            InitializeComponent();
            PartnerContactView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            PartnerContactView.BindingContext = partnerContactsList;
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPartnerContact());
            PartnerContactView.BindingContext = partnerContactsList;
        }
        async void PartnerContactView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (PartnerContactInfo)e.SelectedItem;
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
            Label contactNo = new Label()
            {
                FontAttributes = FontAttributes.Bold,
            };
            Label contactEmail = new Label()
            {
                FontAttributes = FontAttributes.Bold,
            };
            foreach (var i in partnerContactsList)
            {
                if (itemSelected.FirstName.ToString() == i.FirstName.ToString())
                {
                    Name.Text = i.FirstName + " " + i.LastName;
                    displayName.Text = i.ProviderName;
                    contactNo.Text = i.ContactNo;
                    contactEmail.Text = i.ContactEmail;
                }
            }

            ContentPage page = new ContentPage()
            {
                Title = "Partner Contact Details"
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
            stack.Children.Add(contactNo);
            stack.Children.Add(contactEmail);
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
                PartnerContactView.ItemsSource = partnerContactsList;
            }

            else
            {
                PartnerContactView.ItemsSource = partnerContactsList.Where(x => x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower())|| x.LastName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }

    }
}