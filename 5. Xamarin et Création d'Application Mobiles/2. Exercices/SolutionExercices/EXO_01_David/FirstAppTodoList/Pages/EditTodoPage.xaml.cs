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
    public partial class EditTodoPage : ContentPage
    {
        private Todo _seletedTodo;
        public EditTodoPage(Todo seletedTodo)
        {
            _seletedTodo = seletedTodo;
            InitializeComponent();

            todoTitleEntry.Text = _seletedTodo.Title;
            todoDescriptionEntry.Text = _seletedTodo.Description;
            todoCreatedDateEntry.Date = _seletedTodo.CreatedDate;
            UrgencePicker.ItemsSource = Enum.GetValues(typeof(Urgence)).Cast<Urgence>().ToList();
            UrgencePicker.SelectedItem = _seletedTodo.Urgence;
            IsDonneCheck.IsChecked = _seletedTodo.IsDone;

        }

        private async void buttonEditTodo_Clicked(object sender, EventArgs e)
        {
            _seletedTodo.Title = todoTitleEntry.Text;
            _seletedTodo.Description = todoDescriptionEntry.Text;
            _seletedTodo.CreatedDate = _seletedTodo.CreatedDate;
            _seletedTodo.Urgence = UrgencePicker.SelectedItem as Urgence?;
            _seletedTodo.IsDone = IsDonneCheck.IsChecked;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Todo>();
                int nbrRow = conn.Update(_seletedTodo);

                if (nbrRow > 0)
                {
                  await DisplayAlert("Reussi", "Votre todo est édité avec succes!", "Ok");
                }
            }
            var existingPages = Navigation.NavigationStack.ToList();

            await Navigation.PushAsync(new HomePage());
          
        }
    }
}