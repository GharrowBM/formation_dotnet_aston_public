using EXO_03.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_03
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
