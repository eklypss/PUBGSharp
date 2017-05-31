using System.Threading.Tasks;

namespace PUBGSharp
{
    public interface IPUBGStatsClient
    {
        Task<StatsResponse> GetPlayerStatsAsync(string playerName);
    }
}