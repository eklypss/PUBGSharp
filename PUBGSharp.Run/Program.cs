using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGSharp.Data;
using PUBGSharp.Exceptions;
using PUBGSharp.Helpers;
namespace PUBGSharp.Run
{
    class Program
    {
        private Program()
        {
        }

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            // Create client and send a stats request You can either use the "using" keyword or
            // dispose the PUBGStatsClient manually with the Dispose method.
            using (var statsClient = new PUBGStatsClient("api-key-here"))
            {
                // Searching for Player and Mode
                var stats = await statsClient.GetPlayerStatsAsync("shroud", mode: Mode.Solo).ConfigureAwait(false);

                // Searching for Player and specific value
                // the 1 seconds throttle applies her too, keep that in mind
                var test = await statsClient.GetPlayerStatsValue("shroud", mode: Mode.Solo, value: Stats.KDR);

                // Searching for Player, Region, Mode
               // var stats = await statsClient.GetPlayerStatsAsync("shroud",region: Region.NA, mode: Mode.Solo).ConfigureAwait(false);

                // Searching for Player, Region
               // var stats = await statsClient.GetPlayerStatsAsync("shroud", region: Region.NA).ConfigureAwait(false);

                // Print out player name and date the stats were last updated at.
                Console.WriteLine($"{stats.nickname}, last updated at: {stats.LastUpdated}");

                try
                {
                    //Print out Region chosen with mode selected
                    // Stats[0] = the region u selected, eg EU in this example
                    // Stats[1] = region AGG. The API also outputs the AGG values even when you select a specific region.
                    var latestKillstats = stats.Stats[0].Stats.Find(x => x.Stat == Stats.Kills);
                    // Print out amount of kills in the last season player has played in:
                    // This old searching method from the APIv1 still works!
                    var latestSeasonSoloStats = stats.Stats.FindLast(x => x.Mode == Mode.Solo);
                    var kills = latestSeasonSoloStats.Stats.Find(x => x.Stat == Stats.Kills);
                    Console.WriteLine($"Season: {latestSeasonSoloStats.Season}, kills: {kills.Value}");
                }
                /* IMPORTANT STUFF ABOUT EXCEPTIONS:
                 The LINQ and other selector methods (e.g. .Find) will throw NullReferenceException in case the stats don't exist.
                 So if player has no stats in specified region or game mode, it will throw NullReferenceException.
                 For example, if you only have played in Europe and try to look up your stats in the Asia server, instead of showing 0's everywhere it throws this. */
                catch (PUBGSharpException ex)
                {
                    Console.WriteLine($"Could not retrieve stats for {stats.nickname}, error: {ex.Message}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"Could not retrieve stats for {stats.nickname}.");
                    Console.WriteLine("The player might not exist or have stats in the specified mode or region.");
                }

                /* Outputs:
                Mithrain, last updated at: 2017-09-07T19:53:40.3611629Z
                Duo KDR: 2.87
                Stat: Headshot Kills, value: 69, Rank: #
                Season: 2017-pre4, kills: 32
                */
            }

            await Task.Delay(-1);
        }
    }
}
