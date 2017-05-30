using System.Threading.Tasks;

namespace PUBGSharp
{
    public interface IPUBGSharp
    {
        Task<StatsResponse> GetPlayerStatsAsync(string playerName);
    }
}