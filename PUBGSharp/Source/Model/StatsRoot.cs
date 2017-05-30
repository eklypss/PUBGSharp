using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PUBGSharp
{
    public class StatsRoot
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Region Region { get; set; }

        public string Season { get; set; }

        [JsonProperty("Match")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        [JsonProperty("Stats")]
        public List<StatModel> Stats { get; set; }
    }
}