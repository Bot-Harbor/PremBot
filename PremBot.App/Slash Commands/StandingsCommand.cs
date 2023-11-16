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

        var standingsEmbed = new DiscordEmbedBuilder()
        {
            Title = $"Premiere League Standings",
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
                $"Goal Against: {standing.GoalsAgainst}\n" +
                $"Goal Difference: {standing.GoalDifference}\n" +
                $"Points: {standing.Points}\n", inline: true);
        }

        standingsEmbed.WithFooter($"Time Stamp: {DateTime.Now}");

        await context.CreateResponseAsync(standingsEmbed);
    }
}