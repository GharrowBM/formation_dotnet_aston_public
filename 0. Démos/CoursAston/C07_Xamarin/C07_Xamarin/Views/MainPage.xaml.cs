using C07_Xamarin.ViewModels;
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
        public MainPageVM VM;
        private bool _isAnimated;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = VM = new MainPageVM(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartAnimations();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isAnimated = false;
        }

        private void StartAnimations()
        {
            _isAnimated = true;
            //ImageInfiniteRotation(dogIcon, 1, 10);
            ButtonInfiniteScaling(loginButton, 1);
        }

        private async void ButtonInfiniteScaling(Button button, uint speed)
        {
            while(_isAnimated)
            {
                await button.ScaleTo(1.05, 1000 * speed);
                await button.ScaleTo(1, 1000 * speed);
            }
        }

        private async void ImageInfiniteRotation(Image image, int direction, uint speed)
        {
            while (_isAnimated)
            {
                await image.RotateYTo(360 * direction, 1000 * speed);
                image.RotationY = 0;
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