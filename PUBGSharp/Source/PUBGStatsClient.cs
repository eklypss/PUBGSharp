using System;
using System.Threading.Tasks;

namespace PUBGSharp
{
    public class PUBGStatsClient : IPUBGStatsClient
    {
        private Requester _requester;

        public PUBGStatsClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey)) throw new ArgumentException("API Key cannot be empty.", innerException: null);
            _requester = new Requester(apiKey);
        }

        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name cannot be empty.", innerException: null);
            return await _requester.RequestAsync(playerName);
        }
    }
}