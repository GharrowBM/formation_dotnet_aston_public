using C07_Xamarin.Helpers;
using C07_Xamarin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("Oswald-VariableFont_wght.ttf", Alias ="Oswald")]
namespace C07_Xamarin
{
    public partial class App : Application
    {
        public static string DatabaseLocation;
        public static string Token;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            DatabaseLocation = databaseLocation;
            Token = string.Empty;

            DBClient.InitializeDB();
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
