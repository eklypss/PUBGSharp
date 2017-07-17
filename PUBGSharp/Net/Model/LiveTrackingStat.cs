using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PUBGSharp.Data;
using System;

namespace PUBGSharp.Net.Model
{
    public class LiveTrackingStat
    {
        [JsonProperty("MatchDisplay")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Region Region { get; set; }

        public DateTime Date { get; set; }

        public double Delta { get; set; }

        public double Value { get; set; }

        public string Message { get; set; }
    }
}