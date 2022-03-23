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
    public partial class EditAddressPage : ContentPage
    {
        private Address _selectedAddress;

        public EditAddressPage(Address selectedAddress)
        {
            InitializeComponent();
            _selectedAddress = selectedAddress;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            addressStreetNumberEntry.Text = _selectedAddress.StreetNumber.ToString();
            addressStreetNameEntry.Text = _selectedAddress.StreetName;
            addressPostalCodeEntry.Text = _selectedAddress.PostalCode.ToString();
            addressCityNameEntry.Text = _selectedAddress.CityName;
        }

        private void editAddressButton_Clicked(object sender, EventArgs e)
        {
            _selectedAddress.StreetNumber = int.Parse(addressStreetNumberEntry.Text);
            _selectedAddress.StreetName = addressStreetNameEntry.Text;
            _selectedAddress.PostalCode = int.Parse(addressPostalCodeEntry.Text);
            _selectedAddress.CityName = addressCityNameEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                int nbRows = conn.Update(_selectedAddress);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "La modification de l'addresse a bien été effectuée !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "La modification de l'address n'a pas pu être réalisée en base de données", "Ok");
                }
            }

            Navigation.PopAsync();

        }

        private void delAddressButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                int nbRows = conn.Delete(_selectedAddress);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "La suppression de l'addresse a bien été effectuée !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "La suppression de l'address n'a pas pu être réalisée en base de données", "Ok");
                }
            }

            Navigation.PopAsync();

        }
    }
}