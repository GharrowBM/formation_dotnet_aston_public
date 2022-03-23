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
    public partial class EditDogPage : ContentPage
    {
        private Dog _selectedDog;
        public EditDogPage(Dog selectedDog)
        {
            InitializeComponent();

            _selectedDog = selectedDog;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            dogNameEntry.Text = _selectedDog.Name;
            dogDescEntry.Text = _selectedDog.Description;

            var collarColorList = Enum.GetValues(typeof(CollarColor)).Cast<CollarColor>().ToList();
            collarColorPicker.ItemsSource = collarColorList;
            collarColorPicker.SelectedIndex = (int) _selectedDog.CollarColor;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                var masters = conn.Table<Master>().ToList();
                masterPicker.ItemsSource = masters;
                masterPicker.SelectedIndex = _selectedDog.MasterId;
            }
        }

        private void editDogButton_Clicked(object sender, EventArgs e)
        {
            _selectedDog.Name = dogNameEntry.Text;
            _selectedDog.Description = dogDescEntry.Text;
            _selectedDog.CollarColor = (CollarColor) collarColorPicker.SelectedIndex;
            _selectedDog.MasterId = masterPicker.SelectedIndex;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Dog>();
                int nbRows = conn.Update(_selectedDog);

                if (nbRows > 0)
                {
                    DisplayAlert("Reussite", "Le chien a été modifié avec succès", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "Le chien n'a pas pu être modifié en base de données", "Ok");
                }
            }

            Navigation.PopAsync();
        }

        private void delDogButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Dog>();
                int nbRows = conn.Delete(_selectedDog);

                if (nbRows > 0)
                {
                    DisplayAlert("Reussite", "Le chien a été supprimé avec succès", "Ok");
                }
                else
                {
                    DisplayAlert("Echec", "Le chien n'a pas pu être supprimé en base de données", "Ok");
                }
            }

            Navigation.PopAsync();
        }
    }
}