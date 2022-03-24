using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.ViewModels;
using Xamarin.Forms;

namespace TP03.Views
{
    public partial class MainPage : ContentPage
    {
        public MainVM VM;
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = VM = new MainVM(this); 
        }
    }
}
