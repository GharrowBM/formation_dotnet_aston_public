using EXO_01.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_01.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTodoPage : ContentPage
    {
        public AddTodoPage()
        {
            InitializeComponent();
        }

        private void saveToolbarItem_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int nbRows = conn.Insert(new TodoItem
                {
                    Title = titleEntry.Text,
                    Description = descEntry.Text,
                    CreatedAt = DateTime.Now,
                    IsDone = false
                });

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "La tâche a été ajoutée avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else 
                { 
                    DisplayAlert("Erreur", "Un problème est survenu lors de l'ajout de la tâche", "Ok"); 
                }
            }

        }
    }
}