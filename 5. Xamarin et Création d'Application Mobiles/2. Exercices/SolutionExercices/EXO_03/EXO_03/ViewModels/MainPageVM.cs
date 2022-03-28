using EXO_03.Helpers;
using EXO_03.Models;
using EXO_03.Pages;
using EXO_03.ViewModels.Commands;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EXO_03.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public MainPage page;
        private string _citySearchQuery;
        List<LocationAPIResult> _locations;
        LocationAPIResult _selectedLocation;

        public string CitySearchQuery 
        { 
            get { return _citySearchQuery; } 
            set 
            {
                _citySearchQuery = value;
                OnPropertyChanged("CitySearchQuery");
            } 
        }

        public List<LocationAPIResult> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged("Locations");
            }
        }

        public LocationAPIResult SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged("SelectedLocation");
                SearchForecastbyCity(_selectedLocation);
            }
        }

        public SearchCitiesByNameCommand SearchCitiesByNameCommand { get; set; }
        public MainPageVM(MainPage page)
        {
            this.page = page;
            _locations = new List<LocationAPIResult>();

            SearchCitiesByNameCommand = new SearchCitiesByNameCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async Task SearchCitiesByName()
        {
            string url = string.Format(Constants.LOCATIONAPI_URL, Constants.API_KEY, _citySearchQuery);

            using (var client = new RestClient(url))
            {
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", $"Bearer {Constants.API_KEY}");
                RestResponse response = await client.ExecuteAsync(request);
                var json = response.Content.ToString();
                var result = JsonConvert.DeserializeObject<LocationAPIResult[]>(json);
                Locations = result.ToList();
            }
        }

        public async Task SearchForecastbyCity(LocationAPIResult selectedLocation)
        {
            string url = string.Format(Constants.FORECAST_5DAYS_URL, selectedLocation.Key, Constants.API_KEY);

            using (var client = new RestClient(url))
            {
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", $"Bearer {Constants.API_KEY}");
                RestResponse response = await client.ExecuteAsync(request);
                var json = response.Content.ToString();
                var results = JsonConvert.DeserializeObject<ForecastAPIResult>(json);
                await page.Navigation.PushAsync(new ForecastResultPage(results, selectedLocation.LocalizedName));

            }
        }
    }
}
