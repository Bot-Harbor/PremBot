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

            if (standings.Standings.Count > 0)
            {
                return standings.Standings[0]?.Table;
            }
        }
        else       
        {
            Console.WriteLine($"Http Status Code: {result.StatusCode}");
        }

        return new List<Table>();
    }
}