using System;
using System.Threading.Tasks;
using PUBGSharp.Net;
using PUBGSharp.Net.Model;

namespace PUBGSharp
{
    public class PUBGStatsClient : IPUBGStatsClient, IDisposable
    {
        private readonly HttpRequester _httpRequester;

        public PUBGStatsClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey)) {
                throw new ArgumentException("API key cannot be empty.");
            }
                
            _httpRequester = new HttpRequester(apiKey);
        }

        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException("Player name cannot be empty.");
            }

            return await _httpRequester.RequestAsync(playerName);
        }

        public void Dispose()
        {
            _httpRequester?.Dispose();
        }
    }
}