using System.Threading.Tasks;
using PUBGSharp.Net.Model;

namespace PUBGSharp
{
    public interface IPUBGStatsClient
    {
        Task<StatsResponse> GetPlayerStatsAsync(string playerName);
    }
}