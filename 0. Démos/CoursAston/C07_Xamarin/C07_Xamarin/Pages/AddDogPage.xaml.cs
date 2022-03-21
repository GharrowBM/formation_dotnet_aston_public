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

        private void addDogButton_Clicked(object sender, EventArgs e)
        {
            Dog newDog = new Dog
            {
                Name = dogDescEntry.Text,
                Description = dogDescEntry.Text,
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