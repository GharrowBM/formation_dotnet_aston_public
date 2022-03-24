using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP03.ViewModels.Commands;
using TP03.Views;
using Xamarin.Essentials;

namespace TP03.ViewModels
{
    public class MainVM
    {
        public MainPage page;
        public StartAppCommand StartAppCommand { get; set; }
        public MainVM(MainPage page)
        {
            this.page = page;

            StartAppCommand = new StartAppCommand(this);
        }
        public MainVM()
        {

        }

        public async void TakePicture()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await page.DisplayAlert("Erreur", "La caméra n'est pas disponible", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "facepic.jpg",
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                {
                    return;
                }

                await page.Navigation.PushAsync(new ScanPage(file), false);
            }
            else
            {
                page.DisplayAlert("Erreur", "Vous n'êtes pas connecté au réseau !", "OK");
            }
        }
    }
}
