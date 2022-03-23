using FirstAppTodoList.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstAppTodoList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsTodoPage : ContentPage
    {
        private Todo _selectedTodo;
        public DetailsTodoPage(Todo selectedTodo)
        {
            InitializeComponent();
            _selectedTodo = selectedTodo;
            todoTitleEntry.Text = _selectedTodo.Title;
            todoDescriptionEntry.Text = _selectedTodo.Description;
            todoCreatedDateEntry.Date = _selectedTodo.CreatedDate;
            UrgencePicker.ItemsSource = Enum.GetValues(typeof(Urgence)).Cast<Urgence>().ToList();
            UrgencePicker.SelectedItem = _selectedTodo.Urgence;
            IsDonneCheck.IsChecked = _selectedTodo.IsDone;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new EditTodoPage(_selectedTodo),false);
        }

        private async void buttonListTodo_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new HomePage());
        }
        private async void buttonDeleteTodo_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
           
                if (await DisplayAlert("Question?", "Would you like Delete", "Yes", "No"))
                {
                    conn.CreateTable<Todo>();
                    int nbrRow = conn.Delete(_selectedTodo);

                    if (nbrRow > 0)
                    {
                        DisplayAlert("Reussi", "Votre todo est supprimer avec succes!", "Ok");
                    }
                    await Navigation.PopAsync();
                }
              
               
            }
        }
    }
}