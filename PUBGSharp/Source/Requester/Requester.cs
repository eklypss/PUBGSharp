using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PUBGSharp
{
    public class Requester
    {
        private string ApiKey { get; set; }

        public Requester(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<StatsResponse> RequestAsync(string playerName)
        {
            using (HttpClient http = new HttpClient())
            {
                StatsResponse result = new StatsResponse();
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://pubgtracker.com/api/profile/pc/{playerName}?region=agg");
                    request.Headers.Add("TRN-Api-Key", ApiKey);
                    HttpResponseMessage response = await http.SendAsync(request);
                    if (!response.IsSuccessStatusCode) throw new HttpRequestException("Could not retrieve stats.");
                    string t = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<StatsResponse>(t);
                    if (result.AccountId == null) throw new JsonException("Player data is not valid. Player might not exist, or their stats haven't been updated yet.");
                    Console.WriteLine(t);
                }
                catch (JsonException)
                {
                    throw new JsonException("Failed to deserialize data. Player might not exist or have stats in specified region or gamemode.");
                }
                return result;
            }
        }
    }
}