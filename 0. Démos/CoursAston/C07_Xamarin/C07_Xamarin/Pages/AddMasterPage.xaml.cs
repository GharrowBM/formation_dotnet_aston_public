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
    public partial class AddMasterPage : ContentPage
    {
        public AddMasterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                masterAddressPicker.ItemsSource = conn.Table<Address>().ToList();
            }
        }

        private void addMasterButton_Clicked(object sender, EventArgs e)
        {
            Master newMaster = new Master()
            {
                FirstName = masterFirstNameEntry.Text,
                LastName = masterLastNameEntry.Text,
                Email = masterEmailEntry.Text,
                Phone = masterPhoneEntry.Text,
                DateOfBirth = masterDOBPicker.Date,
                AddressId = (int)masterAddressPicker.SelectedIndex
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                int nbRows = conn.Insert(newMaster);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "Le maître a été ajouté avec succès !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "La maître n'a pas pu être ajouté en base de données", "Ok");
                }
            }

            Navigation.PopAsync();
        }
    }
}