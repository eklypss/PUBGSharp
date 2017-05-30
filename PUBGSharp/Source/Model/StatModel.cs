using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PUBGSharp
{
    public class StatModel
    {
        [JsonProperty("label")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Stat Stat { get; set; }

        public string Value { get; set; }
        public int? Rank { get; set; }
        public double? Percentile { get; set; }
    }
}