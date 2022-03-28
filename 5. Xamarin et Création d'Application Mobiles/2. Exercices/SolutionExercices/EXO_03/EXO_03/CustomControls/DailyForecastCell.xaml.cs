using EXO_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_03.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyForecastCell : ViewCell
    {
        public DailyForecastCell()
        {
            InitializeComponent();

            //dateLabel.Text = DateTime.Parse(dateLabel.Text).ToString("d");
            //minTempLabel.Text = minTempLabel.Text + "°C";
            //maxTempLabel.Text = maxTempLabel.Text + "°C";
            //hasPrecipitationLabel.Text = bool.Parse(hasPrecipitationLabel.Text) ? "Pluies" : null;
        }
    }
}