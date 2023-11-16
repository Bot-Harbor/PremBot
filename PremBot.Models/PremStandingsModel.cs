using System.Text.Json.Serialization;

namespace PremBot.Models;

public class Area
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("flag")] public string Flag { get; set; }
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

public class PremStandingsModel
{
    [JsonPropertyName("filters")] public Filters Filters { get; set; }

    [JsonPropertyName("area")] public Area Area { get; set; }

    [JsonPropertyName("competition")] public Competition Competition { get; set; }

    [JsonPropertyName("season")] public Season Season { get; set; }

    [JsonPropertyName("standings")] public List<Standing> Standings { get; set; }
}

public class Season
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("startDate")] public string StartDate { get; set; }

    [JsonPropertyName("endDate")] public string EndDate { get; set; }

    [JsonPropertyName("currentMatchday")] public int CurrentMatchday { get; set; }

    [JsonPropertyName("winner")] public object Winner { get; set; }
}

public class Standing
{
    [JsonPropertyName("stage")] public string Stage { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("group")] public object Group { get; set; }

    [JsonPropertyName("table")] public List<Table> Table { get; set; }
}

public class Table
{
    [JsonPropertyName("position")] public int Position { get; set; }

    [JsonPropertyName("team")] public Team Team { get; set; }

    [JsonPropertyName("playedGames")] public int PlayedGames { get; set; }

    [JsonPropertyName("form")] public object Form { get; set; }

    [JsonPropertyName("won")] public int Won { get; set; }

    [JsonPropertyName("draw")] public int Draw { get; set; }

    [JsonPropertyName("lost")] public int Lost { get; set; }

    [JsonPropertyName("points")] public int Points { get; set; }

    [JsonPropertyName("goalsFor")] public int GoalsFor { get; set; }

    [JsonPropertyName("goalsAgainst")] public int GoalsAgainst { get; set; }

    [JsonPropertyName("goalDifference")] public int GoalDifference { get; set; }
}

public class Team
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }

    [JsonPropertyName("tla")] public string Tla { get; set; }

    [JsonPropertyName("crest")] public string Crest { get; set; }
}