using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_03.Helpers
{
    public class Constants
    {
        public const string LOCATIONAPI_URL = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey={0}&q={1}&language=fr-fr";
        public const string FORECAST_5DAYS_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=fr-fr&metric=true";
        public const string API_KEY = "MY_API_KEY";
    }
}
