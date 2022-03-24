using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_02.Helpers
{
    public  class Constants
    {
        public const string PLACE_API_URL = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&rankby=distance&key={2}";
        public const string VENUE_SERCH = "https://api.foursquare.com/v3/places/nearby?ll={0:0.00},{1:0.00}";
        public const string API_KEY = "MY_API_KEY";
    }
}
