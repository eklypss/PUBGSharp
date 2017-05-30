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
            var statsClient = new PUBGSharp("api_key_here");
            var stats = await statsClient.GetPlayerStatsAsync("OmniDestiny");

            // Print out player name and date the stats were last updated at.
            Console.WriteLine($"{stats.PlayerName}, last updated at: {stats.LastUpdated}");

            // Print out amount of players WINS (Stat.Wins) in SQUAD mode (Mode.Squad) in ALL regions (Region.AGG)
            var squadStats = stats.Stats.Where(x => x.Mode == Mode.Squad && x.Region == Region.AGG).FirstOrDefault();
            var squadWins = squadStats.Stats.Where(x => x.Stat == Stat.Wins).FirstOrDefault();
            Console.WriteLine($"Squad wins: {squadWins.Value}, rank: {squadWins.Rank}, percentile: {squadWins.Percentile}");
            // Print out amount of headshots kills in DUO mode in NA region
            var duoStats = stats.Stats.Where(x => x.Mode == Mode.Duo && x.Region == Region.NA).FirstOrDefault();
            Console.WriteLine(duoStats.Stats.Where(x => x.Stat == Stat.HeadshotKills).FirstOrDefault().Value);

            /*
            OmniDestiny, last updated at: 2017-05-30T17:51:06.2705727Z
            Squad wins: 1, rank: 464228, percentile: 100
            117
            */

            await Task.Delay(-1);
        }
    }
}