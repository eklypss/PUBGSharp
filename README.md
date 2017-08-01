[![Build status](https://ci.appveyor.com/api/projects/status/hb3fiwht7531imv6?svg=true)](https://ci.appveyor.com/project/eklypss/pubgsharp)
[![NuGet version](https://badge.fury.io/nu/PUBGSharp.svg)](https://badge.fury.io/nu/PUBGSharp)

# PUBGSharp
C# wrapper for PUBG stats API provided by https://pubgtracker.com

## Notes
* The API is maintained and provided by pubgtracker.com and all credits go to them. This project just wraps the API for easy usage in C#.
* The project targets .NET Framework 4.5 and .NET Core 1.1.
* No need to implement throttling yourself, PUBGSharp does this for you.

## Installation
To add PUBGSharp to your project, run the following command in the NuGet Package Manager Console:
>Install-Package PUBGSharp

## Getting API key
You can get your API key from here: https://pubgtracker.com/site-api

## Usage
A very basic example, getting the amount of kills player has in duo mode, in all regions combined in Early Access Season 1.
```
var statsClient = new PUBGStatsClient("api-key-here");
var stats = await statsClient.GetPlayerStatsAsync("player-name-here");
try
{
    var kills = stats.Stats.Find(x => x.Mode == Mode.Duo && x.Region == Region.AGG && x.Season == Seasons.EASeason1).Stats.Find(x => x.Stat == Stats.KDR);
    Console.WriteLine($"Solo kills: {kills.Value}");
}
catch (NullReferenceException)
{
    Console.WriteLine($"Could not retrieve stats for {stats.PlayerName}..");
}
```
For a bit more detailed examples, see the Examples project.
