using System.Collections.Generic;

namespace PUBGSharp.Net.Model
{
    public class StatsResponse
    {
        public string accountId { get; set; }
        public string Avatar { get; set; }
        public string LastUpdated { get; set; }
        public string nickname { get; set; }
        public int pubgTrackerId { get; set; }
        public List<StatsRoot> Stats { get; set; }
        public List<LiveTrackingStat> LiveTracking { get; set; }
        public List<MatchHistoryStat> MatchHistory { get; set; }
    }
}