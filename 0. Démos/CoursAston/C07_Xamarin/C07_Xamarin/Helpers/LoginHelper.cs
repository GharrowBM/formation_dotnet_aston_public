using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C07_Xamarin.Helpers
{
    public static class LoginHelper
    {
        public static async Task<Tuple<bool, string>> TryLogin(string email, string password)
        {
            string url = "https://IP:PORT/authenticate";
            using (RestClient client = new RestClient())
            {
                client.AddDefaultHeader("Accept", "application/json");
                var request = new RestRequest(url, Method.Post);
                request.AddBody(new
                {
                    Email = email,
                    Password = password
                });

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var results = JsonConvert.DeserializeObject<AuthenticateAPIResults>(response.Content.ToString());
                    return Tuple.Create(true, results.Token);
                }
            }

            return Tuple.Create(false, string.Empty);
        }
    }

    public class AuthenticateAPIResults 
    { 
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

}
