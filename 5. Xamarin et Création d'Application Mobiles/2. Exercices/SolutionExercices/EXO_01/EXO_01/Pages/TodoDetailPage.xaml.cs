using EXO_01.Models;
using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_01.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoDetailPage : ContentPage
    {
        public TodoItem selectedTodo;
        public TodoDetailPage(TodoItem selectedTodo)
        {
            InitializeComponent();
            this.selectedTodo = selectedTodo;

            titleEntry.Text = selectedTodo.Title;
            descEntry.Text = selectedTodo.Description;
            dateLabel.Text = $"Le {selectedTodo.CreatedAt.ToString("d")} à {selectedTodo.CreatedAt.ToString("t")}";
            statusCheckBox.IsChecked = selectedTodo.IsDone;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedTodo.Title = titleEntry.Text;
            selectedTodo.Description = descEntry.Text;
            selectedTodo.IsDone = statusCheckBox.IsChecked;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int nbRows = conn.Update(selectedTodo);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "La tâche a été modifiée avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Erreur", "Un problème est survenu lors de l'édition de la tâche", "Ok");
                }
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int nbRows = conn.Delete(selectedTodo);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "La tâche a été supprimée avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Erreur", "Un problème est survenu lors de la suppression de la tâche", "Ok");
                }
            }
        }
    }
}