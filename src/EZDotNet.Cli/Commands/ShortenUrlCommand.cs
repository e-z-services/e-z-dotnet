using System.CommandLine;
using System.CommandLine.Invocation;
using EZDotNet.Core.Extensions;

namespace EZDotNet.Cli.Commands;

public class ShortenCommand : CommandBase
{
    private readonly Option<string> _urlOption = new("--url", "URL to shorten") { IsRequired = true };

    public ShortenCommand() : base("shorten", "Shorten a URL")
    {
        AddOption(_urlOption);

        this.SetHandler(HandleCommandAsync);
    }

    private async Task HandleCommandAsync(InvocationContext context)
    {
        var apiKey = context.ParseResult.GetValueForOption(ApiKeyOption)!;
        var url = context.ParseResult.GetValueForOption(_urlOption)!;

        var client = CreateClient(apiKey);

        try
        {
            var result = await client.Shortener.CreateShortUrlAsync(url);

            if (result is { IsSuccessStatusCode: true, Content: not null })
            {
                Console.WriteLine($"Success: {result.Content.Success}");
                Console.WriteLine($"Shortened URL: {result.Content.ShortenedUrl}");
                Console.WriteLine($"Deletion URL: {result.Content.DeletionUrl}");
            }
            else
            {
                Console.WriteLine($"Failed to shorten URL: {result.Error?.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}