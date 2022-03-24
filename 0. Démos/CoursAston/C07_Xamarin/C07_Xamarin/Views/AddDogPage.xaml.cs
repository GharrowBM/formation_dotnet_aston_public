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
    public partial class AddDogPage : ContentPage
    {
        public AddDogPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var collarColorList = Enum.GetValues(typeof(CollarColor)).Cast<CollarColor>().ToList();
            collarColorPicker.ItemsSource = collarColorList;
            collarColorPicker.SelectedIndex = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                var masters = conn.Table<Master>().ToList();
                masterPicker.ItemsSource = masters;
                masterPicker.SelectedIndex = 0;
            }
        }

        private void addDogButton_Clicked(object sender, EventArgs e)
        {
            Dog newDog = new Dog
            {
                Name = dogNameEntry.Text,
                Description = dogDescEntry.Text,
                CollarColor = (CollarColor) collarColorPicker.SelectedItem,
                MasterId = masterPicker.SelectedIndex
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Dog>();
                int nbRows = conn.Insert(newDog);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussite", "Le chien a été ajouté avec succès dans la base de données", "Ok");
                }
            }

            Navigation.PopAsync();
        }
    }
}