using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using PremBot.App.Enums;
using PremBot.App.Services;

namespace PremBot.App.Slash_Commands;

public class FixtureCommand : ApplicationCommandModule
{
    [SlashCommand("fixture", "Displays the matches for the corresponding team.")]
    public async Task FixtureCommandAsync(InteractionContext context,
        [Option("Team", "Fixtures for a team")]
        Team team)
    {
        await context.DeferAsync();

        var instance = PremService.GetInstance();
        var fixtures = await instance.GetMatches(Convert.ToInt32(team)); //add season to standings

        var fixtureEmbed = new DiscordEmbedBuilder();

        foreach (var fixture in fixtures)
        {
            fixtureEmbed.Title = $"{team.GetName()} Fixtures: {fixture.Season.StartDate.Substring(0, 4)}/" +
                                 $"{fixture.Season.EndDate.Substring(0, 4)} ⚽ 🦁";
            fixtureEmbed.Description = "*Note that these are the next 25 games and not the full fixture";
            fixtureEmbed.Color = DiscordColor.SpringGreen;
        }

        if (fixtures.Count != 0)
        {
            foreach (var fixture in fixtures.Take(25))
            {
                fixtureEmbed.AddField(
                    $"{fixture.HomeTeam.Name} vs. {fixture.AwayTeam.Name}",
                    $"{fixture.UtcDate.ToLocalTime().ToString($"MMMM dd, h:mm tt")}\n", inline: true);
            }

            fixtureEmbed.WithFooter($"Time Stamp: {DateTime.Now}");

            await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(fixtureEmbed));
        }
        else
        {
            var errorEmbed = new DiscordEmbedBuilder()
            {
                Title = "⚠️ No fixtures available at this time.",
                Color = DiscordColor.Red,
            };

            errorEmbed.WithFooter($"Time Stamp: {DateTime.Now}");

            await context.CreateResponseAsync(errorEmbed);
        }
    }
}