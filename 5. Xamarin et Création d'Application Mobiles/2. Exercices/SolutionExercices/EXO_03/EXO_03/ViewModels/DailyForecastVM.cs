using EXO_03.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EXO_03.ViewModels
{
    public class DailyForecastVM : INotifyPropertyChanged
    {
        private string _meteoIconURL;
        private string _meteoDate;
        private string _meteoDescription;
        private string _meteoMinTemp;
        private string _meteoMaxTemp;
        private string _meteoPrecipitations;

        public string MeteoIconURL 
        { 
            get => _meteoIconURL; 
            set => _meteoIconURL = value; 
        }
        public string MeteoDate 
        { 
            get => _meteoDate; 
            set => _meteoDate = value; 
        }
        public string MeteoDescription 
        { 
            get => _meteoDescription; 
            set => _meteoDescription = value; 
        }
        public string MeteoMinTemp 
        { 
            get => _meteoMinTemp; 
            set => _meteoMinTemp = value; 
        }
        public string MeteoMaxTemp 
        { 
            get => _meteoMaxTemp; 
            set => _meteoMaxTemp = value; 
        }
        public string MeteoPrecipitations 
        { 
            get => _meteoPrecipitations; 
            set => _meteoPrecipitations = value; 
        }

        public DailyForecastCell cell;

        public event PropertyChangedEventHandler PropertyChanged;

        public DailyForecastVM(DailyForecastCell cell)
        {
            this.cell = cell;
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(property, new PropertyChangedEventArgs(property));
        }
    }
}
