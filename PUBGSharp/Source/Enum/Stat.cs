using System.Runtime.Serialization;

namespace PUBGSharp
{
    public enum Stat
    {
        [EnumMember(Value = "K/D Ratio")]
        KDR,

        [EnumMember(Value = "Win %")]
        WinPercentage,

        [EnumMember(Value = "Time Survived")]
        TimeSurvived,

        [EnumMember(Value = "Rounds Played")]
        RoundsPlayed,

        Wins,

        [EnumMember(Value = "Win Top 10 Ratio")]
        WinTop10Ratio,

        [EnumMember(Value = "Top 10s")]
        Top10,

        [EnumMember(Value = "Top 10 Ratio")]
        Top10Ratio,

        Losses,
        Rating,

        [EnumMember(Value = "Best Rating")]
        BestRating,

        [EnumMember(Value = "Damage Pg")]
        DamagePerGame,

        [EnumMember(Value = "Headshot Kills Pg")]
        HeadshotKillsPerGame,

        [EnumMember(Value = "Heals Pg")]
        HealsPerGame,

        [EnumMember(Value = "Kills Pg")]
        KillsPerGame,

        [EnumMember(Value = "Move Distance Pg")]
        MoveDistancePerGame,

        [EnumMember(Value = "Revives Pg")]
        RevivesPerGame,

        [EnumMember(Value = "Road Kills Pg")]
        RoadKillsPerGame,

        [EnumMember(Value = "Team Kills Pg")]
        TeamKillsPerGame,

        [EnumMember(Value = "Time Survived Pg")]
        TimeSurvivedPerGame,

        [EnumMember(Value = "Top 10s Pg")]
        Top10sPerGame,

        Kills,
        Assists,
        Suicides,

        [EnumMember(Value = "Team Kills")]
        TeamKills,

        [EnumMember(Value = "Headshot Kills")]
        HeadshotKills,

        [EnumMember(Value = "Headshot Kill Ratio")]
        HeadshotKillRatio,

        [EnumMember(Value = "Vehicle Destroys")]
        VehiclesDestroyed,

        [EnumMember(Value = "Road Kills")]
        RoadKills,

        [EnumMember(Value = "Daily Kills")]
        DailyKills,

        [EnumMember(Value = "Weekly Kills")]
        WeeklyKills,

        [EnumMember(Value = "Round Most Kills")]
        RoundMostKills,

        [EnumMember(Value = "Max Kill Streaks")]
        MaxKillStreaks,

        Days,

        [EnumMember(Value = "Longest Time Survived")]
        LongestTimeSurvived,

        [EnumMember(Value = "Most Survival Time")]
        MostSurvivalTime,

        [EnumMember(Value = "Avg Survival Time")]
        AverageSurvivalTime,

        [EnumMember(Value = "Win Points")]
        WinPoints,

        [EnumMember(Value = "Walk Distance")]
        WalkDistance,

        [EnumMember(Value = "Ride Distance")]
        RideDistance,

        [EnumMember(Value = "Move Distance")]
        MoveDistance,

        [EnumMember(Value = "Avg Walk Distance")]
        AverageWalkDistance,

        [EnumMember(Value = "Avg Ride Distance")]
        AverageRideDistance,

        [EnumMember(Value = "Longest Kill")]
        LongestKill,

        Heals,
        Revives,
        Boosts,

        [EnumMember(Value = "Damage Dealt")]
        DamageDealt,

        DBNOs
    }
}