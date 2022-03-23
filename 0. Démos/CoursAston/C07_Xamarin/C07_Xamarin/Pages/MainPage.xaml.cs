using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C07_Xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StartAnimations();
        }

        private void StartAnimations()
        {
            ImageInfiniteRotation(dogIcon, 1, 10);
            ButtonInfiniteScaling(loginButton, 1);
        }

        private async void ButtonInfiniteScaling(Button button, uint speed)
        {
            while(true)
            {
                await button.ScaleTo(1.05, 1000 * speed);
                await button.ScaleTo(1, 1000 * speed);
            }
        }

        private async void ImageInfiniteRotation(Image image, int direction, uint speed)
        {
            while (true)
            {
                await image.RotateTo(360 * direction, 1000 * speed);
                image.Rotation = 0;
            }
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            if (loginEntry.Text == "user@example.com" && passwordEntry.Text == "Pa$$w0rd")
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}