using EXO_02.Helpers;
using EXO_02.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EXO_02.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Result>> GetVenues(double latitude, double longitude)
        {
            List<Result> nearbyPlaces = new List<Result>();

            var url = Venue.GenerateURL(latitude, longitude);

            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await client.ExecuteAsync(request);
            var json = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<NearbyPlacesAPIResult>(json);
            nearbyPlaces = result.results.ToList();

            return nearbyPlaces;
        }
    }
}
