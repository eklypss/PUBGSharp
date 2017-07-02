using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PUBGSharp.Exceptions;
using PUBGSharp.Net.Model;

namespace PUBGSharp.Net
{
    public class HttpRequester : IDisposable
    {
        private readonly HttpClient _client;

        public HttpRequester(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("TRN-Api-Key", apiKey);
        }

        public async Task<StatsResponse> RequestAsync(string playerName, string region = "agg")
        {
            var result = new StatsResponse();

            try
            {
                using (var response = await _client.GetAsync($"https://pubgtracker.com/api/profile/pc/{playerName}?region={region}"))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new PUBGSharpException($"Could not retrieve stats, status code: {response.StatusCode}.");
                    }

                    result = JsonConvert.DeserializeObject<StatsResponse>(await response.Content.ReadAsStringAsync());

                    if (result.AccountId == null)
                    {
                        throw new PUBGSharpException("Player data is not valid. Player might not exist, or their stats have not been updated yet.");
                    }
                }
            }
            catch (JsonException ex)
            {
                throw new PUBGSharpException($"Failed to deserialize data: {ex.Message}", ex);
            }

            return result;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}