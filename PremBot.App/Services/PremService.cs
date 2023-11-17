using System.Text.Json;
using PremBot.App.Secrets;
using PremBot.Models;

namespace PremBot.App.Services;

public class PremService
{
    private static PremService _instance;
    public SeasonStanding SeasonStanding { get; set; } = null;
    public List<Match> Matches { get; set; } = null;
    public List<Table> Tables { get; set; } = null;

    private PremService()
    {
    }

    public static PremService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new PremService();
        }

        return _instance;
    }

    public async Task<List<Table>> GetTable()
    {
        if (Tables != null)
        {
            return Tables;
        }
        
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync("http://api.football-data.org/v4/competitions/PL/standings");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var standings = JsonSerializer.Deserialize<PremStandingsModel>(json);
            Tables = standings.Standings[0].Table;

            return Tables;
        }

        return new List<Table>();
    }

    public async Task<List<Match>> GetMatches(int id)
    {
        if (Matches != null)
        {
            return Matches;
        }
        
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync($"https://api.football-data.org/v4/teams/{id}/matches?status=SCHEDULED");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var fixtures = JsonSerializer.Deserialize<PremFixtureModel>(json);
            Matches = fixtures.Matches;
            
            return Matches;
        }

        return new List<Match>();
    }

    public async Task<SeasonStanding> GetSeason()
    {
        if (SeasonStanding != null)
        {
            return SeasonStanding;
        }
        
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync($"http://api.football-data.org/v4/competitions/PL/standings");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var standings = JsonSerializer.Deserialize<PremStandingsModel>(json);
            SeasonStanding = standings.Season;
            
            return SeasonStanding;
        }

        return new SeasonStanding();
    }
}