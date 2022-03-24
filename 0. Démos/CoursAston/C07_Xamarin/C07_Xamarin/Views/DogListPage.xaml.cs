using C07_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;

namespace C07_Xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogListPage : ContentPage
    {
        public DogListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Dog> list = new List<Dog>();
            Dog dogToDelete = list.FirstOrDefault();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Dog>();
                list = conn.Table<Dog>().OrderBy(x => x.Name).ToList();
            }

            dogsListView.ItemsSource = list;
        }

        private void dogsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Dog selectedDog = dogsListView.SelectedItem as Dog;

            Navigation.PushAsync(new EditDogPage(selectedDog));
        }

        private void addDogTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDogPage());
        }
    }
}