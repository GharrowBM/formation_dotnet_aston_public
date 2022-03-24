using C07_Xamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C07_Xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressesListPage : ContentPage
    {
        public AddressesListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                addressesListView.ItemsSource = conn.Table<Address>().ToList();
            }
        }

        private void addAddressTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAddressPage());
        }

        private void addressesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Address selectedAddress = (Address) addressesListView.SelectedItem;

            Navigation.PushAsync(new EditAddressPage(selectedAddress));
        }
    }
}