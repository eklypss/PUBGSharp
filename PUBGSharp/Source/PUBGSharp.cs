using System.Threading.Tasks;

namespace PUBGSharp
{
    public class PUBGSharp : IPUBGSharp
    {
        private Requester _requester;

        public PUBGSharp(string apiKey)
        {
            _requester = new Requester(apiKey);
        }

        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName)
        {
            return await _requester.RequestAsync(playerName);
        }
    }
}