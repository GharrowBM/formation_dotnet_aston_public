using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using EXO_02.Models;

namespace EXO_02.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public IGeolocator locator = CrossGeolocator.Current;
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetLocation();

            GetPosts();
        }

        private void GetPosts()
        {
            List<TravelEvent> list = new List<TravelEvent>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TravelEvent>();
                list = conn.Table<TravelEvent>().ToList();

            }

            GetPinsOnMap(list);
        }

        private void GetPinsOnMap(List<TravelEvent> travelEvents)
        {
            try
            {
                foreach(var evnt in travelEvents)
                {
                    var pinCoordinates = new Xamarin.Forms.Maps.Position(evnt.Latitude, evnt.Longitude);
                    var pin = new Pin
                    {
                        Address = evnt.Address,
                        Label = evnt.Title,
                        Position = pinCoordinates,
                        Type = PinType.SavedPin
                    };

                    locationsMap.Pins.Add(pin);
                }
            }
            catch (NullReferenceException nullRefEx) { }
            catch (Exception ex) { }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            locator.StopListeningAsync();
        }

        private async Task GetLocation()
        {
            var status = await CheckAndRequestLocationPermission();
            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();

                
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(new TimeSpan(0,1,0), 100);

                locationsMap.IsShowingUser = true;

                CenterMap(location.Latitude, location.Longitude);
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double latitude, double longitude)
        {
            Xamarin.Forms.Maps.Position centerPosition = new Xamarin.Forms.Maps.Position(latitude, longitude);
            MapSpan span = new MapSpan(centerPosition, 1, 1);
            locationsMap.MoveToRegion(span);
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted) return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                DisplayAlert("Erreur", "Vous devriez autoriser l'application à accéder à la location dans les paramètres de votre iPhone", "Ok");
                return status;
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }
    }
}