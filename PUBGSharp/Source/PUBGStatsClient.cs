using System.Threading.Tasks;

namespace PUBGSharp
{
    public class PUBGStatsClient : IPUBGStatsClient
    {
        private Requester _requester;

        public PUBGStatsClient(string apiKey)
        {
            _requester = new Requester(apiKey);
        }

        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName)
        {
            return await _requester.RequestAsync(playerName);
        }
    }
}