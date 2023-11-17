using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using PremBot.App.Services;

namespace PremBot.App.Slash_Commands;

public class StandingsCommand : ApplicationCommandModule
{
    [SlashCommand("standings", "Displays current standings for the Premiere League.")]
    public async Task StandingsCommandAsync(InteractionContext context)
    {
        var instance = PremService.GetInstance();
        var standings = await instance.GetTable();
        var season = await instance.GetSeason();

        if (standings.Count != 0)
        {
            var standingsEmbed = new DiscordEmbedBuilder()
            {
                Title = $"Premiere League Standings: {season.StartDate.Substring(0, 4)}/" +
                        $"{season.EndDate.Substring(0, 4)} ⚽ 🦁",
                Color = DiscordColor.SpringGreen,
            };

            foreach (var standing in standings)
            {
                standingsEmbed.AddField($"{standing.Team.Name}",
                    $"Position: {standing.Position}\n" +
                    $"Matches Played: {standing.PlayedGames}\n" +
                    $"Wins: {standing.Won}\n" +
                    $"Draws: {standing.Draw}\n" +
                    $"Loses: {standing.Lost}\n" +
                    $"Goals For: {standing.GoalsFor}\n" +
                    $"Goals Against: {standing.GoalsAgainst}\n" +
                    $"Goal Difference: {standing.GoalDifference}\n" +
                    $"Points: {standing.Points}\n", inline: true);
            }

            standingsEmbed.WithFooter($"Time Stamp: {DateTime.Now}");

            await context.CreateResponseAsync(standingsEmbed);
        }
        else
        {
            var errorEmbed = new DiscordEmbedBuilder()
            {
                Title = "⚠️ No standings available at this time.",
                Color = DiscordColor.Red,
            };

            errorEmbed.WithFooter($"Time Stamp: {DateTime.Now}");

            await context.CreateResponseAsync(errorEmbed);
        }
    }
}