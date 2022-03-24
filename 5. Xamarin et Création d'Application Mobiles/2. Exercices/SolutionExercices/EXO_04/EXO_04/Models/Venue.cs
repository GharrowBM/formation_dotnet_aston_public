using EXO_02.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_02.Models
{
    public class Venue
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constants.PLACE_API_URL, latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.'), Constants.API_KEY);
        }
    }
}
