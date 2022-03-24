using EXO_02.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_02.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TravelEvent>();
                var events = conn.Table<TravelEvent>().OrderBy(x => x.Date).ToList();
                eventsListView.ItemsSource = events;
            }
        }

        private void addEventToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEventPage());
        }

        private void eventsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedEvent = eventsListView.SelectedItem as TravelEvent;

            if (selectedEvent != null)
            {
                Navigation.PushAsync(new EventDetailsPage(selectedEvent));
            }
        }
    }
}