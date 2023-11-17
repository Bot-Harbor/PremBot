using System.Text.Json;
using PremBot.App.Secrets;
using PremBot.Models;

namespace PremBot.App.Services;

public class PremService
{
    private static PremService _instance;
    
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
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync("http://api.football-data.org/v4/competitions/PL/standings");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var standings = JsonSerializer.Deserialize<PremStandingsModel>(json);

            return standings.Standings[0].Table;
        }

        return new List<Table>();
    }

    public async Task<List<Match>> GetMatches(int id)
    {
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync($"https://api.football-data.org/v4/teams/{id}/matches?status=SCHEDULED");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var fixtures = JsonSerializer.Deserialize<PremFixtureModel>(json);

            return fixtures.Matches;
        }

        return new List<Match>();
    }

    public async Task<SeasonStanding> GetSeason()
    {
        using var client = new HttpClient();
        var premApi = new PremApi();

        client.DefaultRequestHeaders.Add("X-Auth-Token", premApi.Token);
        var result = await client.GetAsync($"http://api.football-data.org/v4/competitions/PL/standings");

        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            var standings = JsonSerializer.Deserialize<PremStandingsModel>(json);
            
            return standings.Season;
        }

        return new SeasonStanding();
    }
}