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
    public partial class EventDetailsPage : ContentPage
    {
        public TravelEvent selectedEvent;
        public EventDetailsPage(TravelEvent selectedEvent)
        {
            InitializeComponent();

            this.selectedEvent = selectedEvent;

            titleEntry.Text = selectedEvent.Title;
            descEntry.Text = selectedEvent.Description;
            datePicker.Date = selectedEvent.Date;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedEvent.Title = titleEntry.Text;
            selectedEvent.Description = descEntry.Text;
            selectedEvent.Date = datePicker.Date;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TravelEvent>();
                int nbRows = conn.Update(selectedEvent);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "L'évènement a été édité avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Erreur", "Un problème est survenu lors de l'édition de l'évènement", "Ok");
                }
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TravelEvent>();
                int nbRows = conn.Delete(selectedEvent);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "L'évènement a été supprimé avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Erreur", "Un problème est survenu lors de la suppression de l'évènement", "Ok");
                }
            }
        }
    }
}