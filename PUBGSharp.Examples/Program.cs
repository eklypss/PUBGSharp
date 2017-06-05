using System;
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

            try
            {
                // Print out amount of players KDR (Stat.KDR) in DUO mode (Mode.Duo) in ALL
                // regions(Region.AGG) in SEASON 1 (Season.EASeason1).
                var duoStats = stats.Stats.Find(x => x.Mode == Mode.Duo && x.Region == Region.AGG && x.Season == Season.EASeason1);
                var duoKDR = duoStats.Stats.Find(x => x.Stat == Stat.KDR);
                Console.WriteLine($"DUO KDR: {duoKDR.Value}, percentile: {duoKDR.Percentile}");
                // Print out amount of headshots kills in SOLO mode in NA region in SEASON 2.
                var soloStats = stats.Stats.Find(x => x.Mode == Mode.Solo && x.Region == Region.NA && x.Season == Season.EASeason2);
                Console.WriteLine(duoStats.Stats.Find(x => x.Stat == Stat.HeadshotKills).Value);
            }
            /* IMPORTANT STUFF ABOUT EXCEPTIONS:
             The LINQ and other selector methods (e.g. stats.Find) will throw NullReferenceException in case the stats don't exist.
             So if player has no stats in specified region or game mode, it will throw NullReferenceException.
             For example, if you only have played in Europe and try to look up your stats in the Asia server, instead of showing 0's everywhere it throws this.
             This method will be re-worked in the future so the wrapper doesn't rely on LINQ, but meanwhile you can just use try/catch and catch the NullReferenceException.
             */
            catch (NullReferenceException)
            {
                Console.WriteLine($"Could not retrieve stats for {stats.PlayerName}..");
            }

            /* Outputs:
            Mithrain, last updated at: 2017-06-01T20:15:46.5702623Z
            DUO KDR: 2.87, percentile: 8
            67
            */

            await Task.Delay(-1);
        }
    }
}