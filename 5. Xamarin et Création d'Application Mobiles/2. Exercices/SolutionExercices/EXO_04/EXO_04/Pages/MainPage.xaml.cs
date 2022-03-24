using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EXO_02.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            if(emailEntry.Text == "user@example.com" && passwordEntry.Text == "Pa$$w0rd")
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
