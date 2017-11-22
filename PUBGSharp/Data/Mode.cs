using System.Runtime.Serialization;

namespace PUBGSharp.Data
{
    /// <summary>
    /// Gamemode to retrieve stats from.
    /// </summary>
    public enum Mode
    {
        Solo,
        Duo,
        Squad,

        [EnumMember(Value = "solo-fpp")]
        SoloFpp,

        [EnumMember(Value = "duo-fpp")]
        DuoFpp,

        [EnumMember(Value = "squad-fpp")]
        SquadFpp,

        [EnumMember(Value = "all")]
        All,
    }
}