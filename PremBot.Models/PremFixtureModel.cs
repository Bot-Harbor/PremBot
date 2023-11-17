using System.Text.Json.Serialization;

namespace PremBot.Models;

public class AreaFixture
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("flag")] public string Flag { get; set; }
}

public class AwayTeam
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }

    [JsonPropertyName("tla")] public string Tla { get; set; }

    [JsonPropertyName("crest")] public string Crest { get; set; }
}

public class CompetitionFixture
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("emblem")] public string Emblem { get; set; }
}

public class FiltersFixture
{
    [JsonPropertyName("competitions")] public string Competitions { get; set; }

    [JsonPropertyName("permission")] public string Permission { get; set; }

    [JsonPropertyName("status")] public List<string> Status { get; set; }

    [JsonPropertyName("limit")] public int Limit { get; set; }
}

public class FullTime
{
    [JsonPropertyName("home")] public object Home { get; set; }

    [JsonPropertyName("away")] public object Away { get; set; }
}

public class HalfTime
{
    [JsonPropertyName("home")] public object Home { get; set; }

    [JsonPropertyName("away")] public object Away { get; set; }
}

public class HomeTeam
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }

    [JsonPropertyName("tla")] public string Tla { get; set; }

    [JsonPropertyName("crest")] public string Crest { get; set; }
}

public class Match
{
    [JsonPropertyName("area")] public AreaFixture Area { get; set; }

    [JsonPropertyName("competition")] public CompetitionFixture Competition { get; set; }

    [JsonPropertyName("season")] public SeasonFixture Season { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("utcDate")] public DateTime UtcDate { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("matchday")] public int Matchday { get; set; }

    [JsonPropertyName("stage")] public string Stage { get; set; }

    [JsonPropertyName("group")] public object Group { get; set; }

    [JsonPropertyName("lastUpdated")] public DateTime LastUpdated { get; set; }

    [JsonPropertyName("homeTeam")] public HomeTeam HomeTeam { get; set; }

    [JsonPropertyName("awayTeam")] public AwayTeam AwayTeam { get; set; }

    [JsonPropertyName("score")] public Score Score { get; set; }

    [JsonPropertyName("odds")] public Odds Odds { get; set; }

    [JsonPropertyName("referees")] public List<object> Referees { get; set; }
}

public class Odds
{
    [JsonPropertyName("msg")] public string Msg { get; set; }
}

public class ResultSet
{
    [JsonPropertyName("count")] public int Count { get; set; }

    [JsonPropertyName("competitions")] public string Competitions { get; set; }

    [JsonPropertyName("first")] public string First { get; set; }

    [JsonPropertyName("last")] public string Last { get; set; }

    [JsonPropertyName("played")] public int Played { get; set; }

    [JsonPropertyName("wins")] public int Wins { get; set; }

    [JsonPropertyName("draws")] public int Draws { get; set; }

    [JsonPropertyName("losses")] public int Losses { get; set; }
}

public class PremFixtureModel
{
    [JsonPropertyName("filters")] public FiltersFixture Filters { get; set; }

    [JsonPropertyName("resultSet")] public ResultSet ResultSet { get; set; }

    [JsonPropertyName("matches")] public List<Match> Matches { get; set; }
}

public class Score
{
    [JsonPropertyName("winner")] public object Winner { get; set; }

    [JsonPropertyName("duration")] public string Duration { get; set; }

    [JsonPropertyName("fullTime")] public FullTime FullTime { get; set; }

    [JsonPropertyName("halfTime")] public HalfTime HalfTime { get; set; }
}

public class SeasonFixture
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("startDate")] public string StartDate { get; set; }

    [JsonPropertyName("endDate")] public string EndDate { get; set; }

    [JsonPropertyName("currentMatchday")] public int CurrentMatchday { get; set; }

    [JsonPropertyName("winner")] public object Winner { get; set; }
}