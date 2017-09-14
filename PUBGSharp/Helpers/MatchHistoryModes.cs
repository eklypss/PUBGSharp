namespace PUBGSharp.Helpers
{
    /// <summary>
    /// Modes used by the MatchHistoryStat model as it uses different naming than <see
    /// cref="PUBGSharp.Data.Mode"/> in the API. ///
    /// </summary>

    public class MatchHistoryModes
    {
        public const string SoloTpp = "Solo";
        public const string DuoTpp = "Duo";
        public const string SquadTpp = "Squad";
        public const string SoloFpp = "FP Solo";
        public const string DuoFpp = "FP Duo";
        public const string SquadFpp = "FP Squad";
    }
}