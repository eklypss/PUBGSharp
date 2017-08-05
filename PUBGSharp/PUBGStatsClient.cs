using System;
using System.Threading.Tasks;
using PUBGSharp.Data;
using PUBGSharp.Net;
using PUBGSharp.Net.Model;

namespace PUBGSharp
{
    public class PUBGStatsClient : IPUBGStatsClient, IDisposable
    {
        private readonly HttpRequester _httpRequester;

        /// <summary>
        /// Initialises a <see cref="PUBGStatsClient"/>.
        /// </summary>
        /// <param name="apiKey">Your tracker network API key. (https://pubgtracker.com/site-api)</param>
        /// <param name="throttle">
        /// Enable or disable throttling, pubgtracker wants to have ~1 request per sec. It is
        /// recommended to keep this enabled.
        /// </param>
        public PUBGStatsClient(string apiKey, bool throttle = true)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key cannot be empty.");
            }
            _httpRequester = throttle ? new HttpRequesterThrottle(apiKey) : new HttpRequester(apiKey);
        }

        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName, Region region = Region.AGG)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException("Player name cannot be empty.");
            }
            return await _httpRequester.RequestAsync(playerName, region).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpRequester?.Dispose();
        }
    }
}