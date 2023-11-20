using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace PremBot.App.Slash_Commands;

public class CaptionCommand : ApplicationCommandModule
{
    [SlashCommand("caption", "Give any image a caption.")]
    public async Task CaptionCommandAsync(InteractionContext context,
        [Option("caption", "The caption you want the image to have")]
        string caption,
        [Option("image", "The image you want to upload")]
        DiscordAttachment image)
    {
        await context.DeferAsync();

        var captionEmbed = new DiscordEmbedBuilder()
        {
            Title = caption,
            ImageUrl = image.Url,
            Color = DiscordColor.Blue
        };

        var easternTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
            TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        
        captionEmbed.WithFooter
        (
            $"Time Stamp: {easternTime.ToString($"MMMM dd, yyyy h:mm tt")}"
        );

        await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(captionEmbed));
    }
}