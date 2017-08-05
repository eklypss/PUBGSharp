using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PUBGSharp.Data;
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

        public virtual async Task<StatsResponse> RequestAsync(string playerName, Region region)
        {
            try
            {
                using (var response = await _client.GetAsync($"https://pubgtracker.com/api/profile/pc/{playerName}?region={region.ToString().ToLower()}").ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new PUBGSharpException($"Could not retrieve stats, status code: {response.StatusCode}.");
                    }
                    var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var result = JsonConvert.DeserializeObject<StatsResponse>(responseData);
                    if (result.AccountId == null)
                    {
                        throw new PUBGSharpException("Player data is not valid. Player might not exist, or their stats have not been updated yet.");
                    }
                    return result;
                }
            }
            catch (JsonException ex)
            {
                throw new PUBGSharpException($"Failed to deserialize data: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}