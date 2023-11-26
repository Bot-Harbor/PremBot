using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using PremBot.App.Secrets;
using PremBot.App.Slash_Commands;

namespace PremBot.App;

public abstract class Bot
{
    public static DiscordClient Client { get; set; }

    public static async Task RunBotAsync()
    {
        var discord = new Discord();
        
        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = discord.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true
        };

        Client = new DiscordClient(discordConfig);

        Client.Ready += Client_Ready;
        
        SlashCommands();
        
        await Client.ConnectAsync();
        await Task.Delay(-1);
    }
    
    private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }

    private static void SlashCommands()
    {
        var slashCommands = Client.UseSlashCommands();
        
        slashCommands.RegisterCommands<PingCommand>();
        slashCommands.RegisterCommands<CaptionCommand>();
        slashCommands.RegisterCommands<StandingsCommand>();
        slashCommands.RegisterCommands<FixtureCommand>();
        slashCommands.RegisterCommands<MatchDayFixture>();
        slashCommands.RegisterCommands<HelpCommand>();
    }
}