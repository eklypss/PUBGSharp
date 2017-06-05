using System;
using System.Linq;
using System.Threading.Tasks;

namespace PUBGSharp.Examples
{
    internal class Program
    {
        private Program()
        {
        }

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            // Create client and send a stats request
            var statsClient = new PUBGStatsClient("api_key_here");
            var stats = await statsClient.GetPlayerStatsAsync("Mithrain");

            // Print out player name and date the stats were last updated at.
            Console.WriteLine($"{stats.PlayerName}, last updated at: {stats.LastUpdated}");

            // Print out amount of players KDR (Stat.KDR) in DUO mode (Mode.Duo) in ALL regions
            // (Region.AGG) in SEASON 1 (Season.EASeason1).
            var duoStats = stats.Stats.Find(x => x.Mode == Mode.Duo && x.Region == Region.AGG && x.Season == Season.EASeason1);
            var duoKDR = duoStats.Stats.Find(x => x.Stat == Stat.KDR);
            Console.WriteLine($"DUO KDR: {duoKDR.Value}, percentile: {duoKDR.Percentile}");
            // Print out amount of headshots kills in SOLO mode in NA region in SEASON 2.
            var soloStats = stats.Stats.Find(x => x.Mode == Mode.Solo && x.Region == Region.NA && x.Season == Season.EASeason2);
            Console.WriteLine(duoStats.Stats.Find(x => x.Stat == Stat.HeadshotKills).Value);

            /* Outputs:
            Mithrain, last updated at: 2017-06-01T20:15:46.5702623Z
            DUO KDR: 2.87, percentile: 8
            67
            */

            await Task.Delay(-1);
        }
    }
}