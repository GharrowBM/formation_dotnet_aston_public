using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanVM VM;
        public ScanPage(MediaFile file)
        {
            InitializeComponent();

            BindingContext = VM = new ScanVM(this, file);

            NavigationPage.SetHasNavigationBar(this, false);

            faceImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStreamWithImageRotatedForExternalStorage();
                return stream;
            });
        }

        public ScanPage()
        {

        }
    }
}