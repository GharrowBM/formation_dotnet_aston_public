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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            List<Todo> todos = new List<Todo>();
            Todo TodoToDelete = todos.FirstOrDefault();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Todo>();
                todos = conn.Table<Todo>().OrderBy(x => x.CreatedDate).ToList();
            }

            todoListView.ItemsSource = todos;
          
        }

        private void addTodoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTodoPage());
        }

        private void todoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Todo selectTodo = todoListView.SelectedItem as Todo;
            Navigation.PushAsync(new DetailsTodoPage(selectTodo));
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTodoPage());
        }

    }
}