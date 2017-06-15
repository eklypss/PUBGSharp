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
                    if (!response.IsSuccessStatusCode) throw new PUBGSharpException($"Could not retrieve stats, status code: {response.StatusCode}.");
                    result = JsonConvert.DeserializeObject<StatsResponse>(await response.Content.ReadAsStringAsync());
                    if (result.AccountId == null) throw new PUBGSharpException("Player data is not valid. Player might not exist, or their stats haven't been updated yet.");
                }
                catch (JsonException ex)
                {
                    throw new PUBGSharpException($"Failed to deserialize data: {ex.Message}", ex);
                }
                return result;
            }
        }
    }
}