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
    public partial class EditMasterPage : ContentPage
    {
        private Master _selectedMaster;

        public EditMasterPage(Master selectedMaster)
        {
            InitializeComponent();
            _selectedMaster = selectedMaster;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            masterFirstNameEntry.Text = _selectedMaster.FirstName;
            masterLastNameEntry.Text = _selectedMaster.LastName;
            masterEmailEntry.Text = _selectedMaster.Email;
            masterPhoneEntry.Text = _selectedMaster.Phone;
            masterDOBPicker.Date = _selectedMaster.DateOfBirth;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Address>();
                var addresses = conn.Table<Address>().ToList();
                masterAddressPicker.ItemsSource = addresses;
                masterAddressPicker.SelectedIndex = _selectedMaster.AddressId;
            }
        }

        private void editMasterButton_Clicked(object sender, EventArgs e)
        {
            _selectedMaster.FirstName = masterFirstNameEntry.Text;
            _selectedMaster.LastName = masterLastNameEntry.Text;
            _selectedMaster.Email = masterEmailEntry.Text;
            _selectedMaster.Phone = masterPhoneEntry.Text;
            _selectedMaster.DateOfBirth = masterDOBPicker.Date;
            _selectedMaster.AddressId = (int) masterAddressPicker.SelectedIndex;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                int nbRows = conn.Update(_selectedMaster);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "Le maître a été modifié avec succès !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "La maître n'a pas pu être modifié en base de données", "Ok");
                }
            }

            Navigation.PopAsync();

        }

        private void delMasterButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                int nbRows = conn.Delete(_selectedMaster);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "Le maître a été supprimé avec succès !", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "La maître n'a pas pu être supprimé en base de données", "Ok");
                }
            }

            Navigation.PopAsync();

        }
    }
}