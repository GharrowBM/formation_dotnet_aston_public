using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01.Models.Enums;
using TP01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GameVM VM { get; set; }
        
        public GamePage(Difficulties difficulty)
        {
            InitializeComponent();

            BindingContext = VM = new GameVM(this, difficulty);

            InfiniteScaling(guessButton);
        }

        private async void InfiniteScaling(Button button)
        {
            do
            {
                await button.ScaleTo(1.1, 1000);
                await button.ScaleTo(1, 1000);
            } while (true);
        }
    }
}