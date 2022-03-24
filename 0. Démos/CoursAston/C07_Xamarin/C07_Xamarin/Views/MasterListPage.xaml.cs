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
    public partial class MasterListPage : ContentPage
    {
        public MasterListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Master>();
                mastersListView.ItemsSource = conn.Table<Master>().ToList();
            }
        }

        private void addMasterTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMasterPage());
        }

        private void mastersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Master selectedMaster = (Master) mastersListView.SelectedItem;
            
            Navigation.PushAsync(new EditMasterPage(selectedMaster));
        }
    }
}