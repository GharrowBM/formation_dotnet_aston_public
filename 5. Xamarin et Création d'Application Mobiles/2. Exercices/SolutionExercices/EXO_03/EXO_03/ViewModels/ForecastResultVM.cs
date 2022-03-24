using EXO_03.Models;
using EXO_03.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EXO_03.ViewModels
{
    public class ForecastResultVM : INotifyPropertyChanged
    {
        public ForecastResultPage _page;
        private ForecastAPIResult _APIresults;
        private List<DailyForecast> _forecasts;
        private DailyForecast _selectedForecast;
        private string _pageTitle;

        public string PageTitle
        {
            get { return _pageTitle; }
            set 
            { 
                _pageTitle = value; 
            }
        }

        public List<DailyForecast> Forecasts
        {
            get { return _forecasts; }
            set 
            { 
                _forecasts = value; 
            }
        }

        public DailyForecast SelectedForecast
        {
            get { return _selectedForecast; }
            set
            {
                _selectedForecast = value;
                OnPropertyChanged("SelectedForecast");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ForecastResultVM(ForecastResultPage page, ForecastAPIResult APIresults, string cityName)
        {
            _page = page;
            _APIresults = APIresults;

            PageTitle = $"Prévisions météo pour les 5 prochains jours à {cityName}";
            Forecasts = _APIresults.DailyForecasts.ToList();
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
