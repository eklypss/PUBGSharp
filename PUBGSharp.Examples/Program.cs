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
            var statsClient = new PUBGStatsClient("api-key-here");
            var stats = await statsClient.GetPlayerStatsAsync("Mithrain");

            // Print out player name and date the stats were last updated at.
            Console.WriteLine($"{stats.PlayerName}, last updated at: {stats.LastUpdated}");

            try
            {
                // Print out amount of players KDR (Stat.KDR) in DUO mode (Mode.Duo) in ALL
                // regions(Region.AGG) in SEASON 1 (Season.EASeason1).
                var kdr = stats.Stats.Find(x => x.Mode == Mode.Duo && x.Region == Region.AGG && x.Season == Season.EASeason1).Stats.Find(x => x.Stat == Stat.KDR).Value;
                Console.WriteLine($"Duo KDR: {kdr}");
                // Print out amount of headshots kills in SOLO mode in NA region in SEASON 2.
                var headshotKills = stats.Stats.Find(x => x.Mode == Mode.Solo && x.Region == Region.NA && x.Season == Season.EASeason2).Stats.Find(x => x.Stat == Stat.HeadshotKills);
                // You can also display the stats by using .ToString() on the stat object, e.g:
                Console.WriteLine(headshotKills.ToString());
            }
            /* IMPORTANT STUFF ABOUT EXCEPTIONS:
             The LINQ and other selector methods (e.g. .Find) will throw NullReferenceException in case the stats don't exist.
             So if player has no stats in specified region or game mode, it will throw NullReferenceException.
             For example, if you only have played in Europe and try to look up your stats in the Asia server, instead of showing 0's everywhere it throws this. */
            catch (PUBGSharpException ex)
            {
                Console.WriteLine($"Could not retrieve stats for {stats.PlayerName}, error: {ex.Message}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Could not retrieve stats for {stats.PlayerName}.");
                Console.WriteLine("The player might not exist or have stats in the specified mode or region.");
            }

            /* Outputs:
            Mithrain, last updated at: 2017-06-13T19:12:24.0579462Z
            Duo KDR: 2.87
            Stat: HeadshotKills, value: 54, Rank: #533
            */

            await Task.Delay(-1);
        }
    }
}