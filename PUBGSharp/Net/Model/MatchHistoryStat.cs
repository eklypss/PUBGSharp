using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PUBGSharp.Data;

namespace PUBGSharp.Net.Model
{
    public class MatchHistoryStat
    {
        public int Id { get; set; }

        public DateTime Updated { get; set; }

        public int Season { get; set; }

        public string SeasonDisplay { get; set; }

        [JsonProperty("MatchDisplay")]
        public string Mode { get; set; }

        public Region Region { get; set; }

        public string RegionDisplay { get; set; }

        public int Rounds { get; set; } //always 1, perhaps for future multi-round games?

        public int Wins { get; set; } //1 if won, 0 otherwise

        public int Kills { get; set; }

        public int Assists { get; set; }

        public int Top10 { get; set; } //1 if in top10, 0 otherwise

        public double Rating { get; set; }

        public double RatingChange { get; set; }

        public int RatingRank { get; set; }

        public int RatingRankChange { get; set; }

        public int Headshots { get; set; }

        public double Kd { get; set; }

        public int Damage { get; set; }

        public double TimeSurvived { get; set; }

        public double MoveDistance { get; set; }
    }
}