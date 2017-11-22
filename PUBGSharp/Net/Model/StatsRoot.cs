using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PUBGSharp.Data;

namespace PUBGSharp.Net.Model
{
    public class StatsRoot
    {
        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Region Region { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        [JsonProperty("stats")]
        public List<StatModel> Stats { get; set; }
    }
}