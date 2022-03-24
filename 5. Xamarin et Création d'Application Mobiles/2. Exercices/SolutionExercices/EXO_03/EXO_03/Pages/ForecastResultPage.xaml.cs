using EXO_03.Models;
using EXO_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_03.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastResultPage : ContentPage
    {

        public ForecastResultPage(ForecastAPIResult results, string cityName)
        {
            InitializeComponent();

            this.BindingContext = new ForecastResultVM(this, results, cityName);
        }
    }
}