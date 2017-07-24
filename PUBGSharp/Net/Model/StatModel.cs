using Newtonsoft.Json;

namespace PUBGSharp.Net.Model
{
    public class StatModel
    {
        [JsonProperty("label")]
        public string Stat { get; set; }

        public string Value { get; set; }
        public int? Rank { get; set; }
        public double? Percentile { get; set; }

        // Custom ToString() method. Percentile isn't displayed as it seems to be empty in most stats.
        public override string ToString()
        {
            return $"Stat: {Stat}, value: {Value}, Rank: #{Rank}";
        }
    }
}