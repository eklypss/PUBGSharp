using System.Collections.Generic;

namespace PUBGSharp
{
    public class StatsResponse
    {
        public string AccountId { get; set; }
        public string Avatar { get; set; }
        public string DefaultRegion { get; set; }
        public string LastUpdated { get; set; }
        public string PlayerName { get; set; }
        public int PubgTrackerId { get; set; }
        public List<StatsRoot> Stats { get; set; }
    }
}