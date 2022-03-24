using C07_Xamarin.Models;
using Newtonsoft.Json;
using RestSharp;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C07_Xamarin.Helpers
{
    public class InitDBResults
    {
        public IList<Dog> Dogs { get; set; }
        public IList<Master> Masters { get; set; }
        public IList<Address> Addresses { get; set; }
    }

    public static class DBClient
    {
        public static async Task InitializeDB()
        {
            var url = "https://drive.google.com/uc?export=download&id=1DzVAbwDTC4vha4_0QbO4-d9mD7EbC5D0";

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTables<Dog, Master, Address>();

                using (RestClient client = new RestClient())
                {
                    client.AddDefaultHeader("Accept", "application/json");
                    var request = new RestRequest(url, Method.Get);
                    var response = await client.ExecuteAsync(request);

                    if (response.IsSuccessful)
                    {
                        var json = response.Content.ToString();
                        var result = JsonConvert.DeserializeObject<InitDBResults>(json);

                        if (!conn.Table<Dog>().ToList().Any())
                        {
                            foreach (var dog in result.Dogs)
                            {
                                conn.Insert(dog);
                            }
                        }

                        if (!conn.Table<Master>().ToList().Any())
                        {
                            foreach (var master in result.Masters)
                            {
                                conn.Insert(master);
                            }
                        }

                        if (!conn.Table<Address>().ToList().Any())
                        {
                            foreach (var address in result.Addresses)
                            {
                                conn.Insert(address);
                            }
                        }

                    }

                }

            }
        }
    }
}
