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
    public partial class AddAddressPage : ContentPage
    {
        public AddAddressPage()
        {
            InitializeComponent();
        }

        private void addAddressButton_Clicked(object sender, EventArgs e)
        {
            Address newAddress = new Address()
            {
                StreetNumber = int.Parse(addressStreetNumberEntry.Text),
                StreetName = addressStreetNameEntry.Text,
                PostalCode = int.Parse(addressPostalCodeEntry.Text),
                CityName = addressCityNameEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                int nbRows = conn.Insert(newAddress);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "L'ajout de l'addresse a bien été effectué !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "L'ajout de l'addresse n'a pas pu être réalisé en base de donnée", "Ok");
                }
            }

            Navigation.PopAsync();
        }
    }
}