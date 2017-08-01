using System;
using System.Runtime.Serialization;

namespace PUBGSharp.Data
{
    /// <summary>
    /// Season to retrieve stats from.
    /// </summary>
    [Obsolete("Use the static PUBGSharp.Helpers.Seasons class instead.")]
    public enum Season
    {
        [EnumMember(Value = "2017-pre1")]
        EASeason1,

        [EnumMember(Value = "2017-pre2")]
        EASeason2,

        [EnumMember(Value = "2017-pre3")]
        EASeason3
    }
}