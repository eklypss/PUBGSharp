using System.Runtime.Serialization;

namespace PUBGSharp.Data
{
    /// <summary>
    /// Season to retrieve stats from.
    /// </summary>
    public enum Season
    {
        [EnumMember(Value = "2017-pre1")]
        EASeason1,

        [EnumMember(Value = "2017-pre2")]
        EASeason2
    }
}