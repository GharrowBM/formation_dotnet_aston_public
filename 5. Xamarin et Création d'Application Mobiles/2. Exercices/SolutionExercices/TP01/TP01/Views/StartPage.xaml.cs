using FFImageLoading.Svg.Forms;
using TP01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartVM VM { get; set; }

        public StartPage()
        {
            InitializeComponent();

            BindingContext = VM = new StartVM(this);

            InfiniteRotation(star1, -1);
            InfiniteRotation(star2);
            InfiniteRotation(star3, -1);
            InfiniteRotation(star4);
            InfiniteRotation(star5, -1);
            InfiniteRotation(star6);
            InfiniteScaling(startButton);

        }

        private async void InfiniteRotation(SvgCachedImage svgImage, int rotationDirection = 1)
        {
            do
            {
                await svgImage.RotateTo(360 * rotationDirection, 3000);
                svgImage.Rotation = 0;
            } while (true);
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