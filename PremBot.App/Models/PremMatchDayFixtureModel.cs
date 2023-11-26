using System.Text.Json.Serialization;

namespace PremBot.Models;

public class Area
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("flag")] public string Flag { get; set; }
}

public class MatchAwayTeam
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }

    [JsonPropertyName("tla")] public string Tla { get; set; }

    [JsonPropertyName("crest")] public string Crest { get; set; }
}

public class Competition
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("emblem")] public string Emblem { get; set; }
}

public class Filters
{
    [JsonPropertyName("season")] public string Season { get; set; }
}

public class MatchDayFullTime
{
    [JsonPropertyName("home")] public int Home { get; set; }

    [JsonPropertyName("away")] public int Away { get; set; }
}

public class MatchDayHalfTime
{
    [JsonPropertyName("home")] public int Home { get; set; }

    [JsonPropertyName("away")] public int Away { get; set; }
}

public class MatchDayHomeTeam
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }

    [JsonPropertyName("tla")] public string Tla { get; set; }

    [JsonPropertyName("crest")] public string Crest { get; set; }
}

public class MatchDayMatch
{
    [JsonPropertyName("area")] public Area Area { get; set; }

    [JsonPropertyName("competition")] public Competition Competition { get; set; }

    [JsonPropertyName("season")] public Season Season { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("utcDate")] public DateTime UtcDate { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("matchday")] public int Matchday { get; set; }

    [JsonPropertyName("stage")] public string Stage { get; set; }

    [JsonPropertyName("group")] public object Group { get; set; }

    [JsonPropertyName("lastUpdated")] public DateTime LastUpdated { get; set; }

    [JsonPropertyName("homeTeam")] public HomeTeam HomeTeam { get; set; }

    [JsonPropertyName("awayTeam")] public AwayTeam AwayTeam { get; set; }

    [JsonPropertyName("score")] public MatchDayScore Score { get; set; }

    [JsonPropertyName("odds")] public MatchDayOdds Odds { get; set; }

    [JsonPropertyName("referees")] public List<Referee> Referees { get; set; }
}

public class MatchDayOdds
{
    [JsonPropertyName("msg")] public string Msg { get; set; }
}

public class Referee
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("nationality")] public string Nationality { get; set; }
}

public class MatchDayResultSet
{
    [JsonPropertyName("count")] public int Count { get; set; }

    [JsonPropertyName("first")] public string First { get; set; }

    [JsonPropertyName("last")] public string Last { get; set; }

    [JsonPropertyName("played")] public int Played { get; set; }
}

public class PremMatchDayFixtureModel
{
    [JsonPropertyName("filters")] public Filters Filters { get; set; }

    [JsonPropertyName("resultSet")] public ResultSet ResultSet { get; set; }

    [JsonPropertyName("competition")] public Competition Competition { get; set; }

    [JsonPropertyName("matches")] public List<MatchDayMatch> Matches { get; set; }
}

public class MatchDayScore
{
    [JsonPropertyName("winner")] public string Winner { get; set; }

    [JsonPropertyName("duration")] public string Duration { get; set; }

    [JsonPropertyName("fullTime")] public FullTime FullTime { get; set; }

    [JsonPropertyName("halfTime")] public HalfTime HalfTime { get; set; }
}

public class Season
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("startDate")] public string StartDate { get; set; }

    [JsonPropertyName("endDate")] public string EndDate { get; set; }

    [JsonPropertyName("currentMatchday")] public int CurrentMatchday { get; set; }

    [JsonPropertyName("winner")] public object Winner { get; set; }
}