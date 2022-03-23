using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXO_01.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_01.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                var todos = conn.Table<TodoItem>().OrderBy(x => x.CreatedAt).ToList();
                todosListView.ItemsSource = todos;
            }
        }

        private void addToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTodoPage());
        }

        private void todosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = todosListView.SelectedItem as TodoItem;
            if (selectedPost != null)
            {
                Navigation.PushAsync(new TodoDetailPage(selectedPost));
            }
        }
    }
}