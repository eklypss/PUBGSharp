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
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://pubgtracker.com/api/profile/pc/{playerName}?region=agg");
                request.Headers.Add("TRN-Api-Key", ApiKey);
                HttpResponseMessage response = await http.SendAsync(request);
                return JsonConvert.DeserializeObject<StatsResponse>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}