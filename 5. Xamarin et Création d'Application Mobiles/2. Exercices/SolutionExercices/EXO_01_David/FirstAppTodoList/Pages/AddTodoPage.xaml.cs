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
    public partial class AddTodoPage : ContentPage
    {
        public AddTodoPage()
        {
            InitializeComponent();
            UrgencePicker.ItemsSource = Enum.GetValues(typeof(Urgence)).Cast<Urgence>().ToList();
        }

        private void buttonAddTodo_Clicked(object sender, EventArgs e)
        {
            Todo todo = new Todo()
            {
                Title = todoTitleEntry.Text,
                Description = todoDescriptionEntry.Text,
                CreatedDate = todoCreatedDateEntry.Date,
                Urgence = (Urgence?)UrgencePicker.SelectedItem,
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Todo>();
                int nbrRow = conn.Insert(todo);

                if (nbrRow > 0)
                {
                    DisplayAlert("Reussi", "Votre todo est ajoutée avec succes!", "Ok");
                }
            }

            Navigation.PopAsync();
        }
    }
}