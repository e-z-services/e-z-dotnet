using System.CommandLine;
using System.CommandLine.Invocation;
using EZDotNet.Core.Models.Enums;
using EZDotNet.Core.Models.Requests;

namespace EZDotNet.Cli.Commands;

public class PasteCommand : CommandBase
{
    private readonly Option<string> _titleOption = new("--title", "Title of the paste");
    private readonly Option<string> _descriptionOption = new("--description", "Description of the paste");
    private readonly Option<string> _textOption = new("--text", "Content of the paste") { IsRequired = true };
    private readonly Option<PasteLanguage> _languageOption = new(
        "--language",
        () => PasteLanguage.Plaintext,
        "Programming language for syntax highlighting");

    public PasteCommand() : base("paste", "Create a new paste")
    {
        AddOption(_titleOption);
        AddOption(_descriptionOption);
        AddOption(_textOption);
        AddOption(_languageOption);

        this.SetHandler(HandleCommandAsync);
    }

    private async Task HandleCommandAsync(InvocationContext context)
    {
        var apiKey = context.ParseResult.GetValueForOption(ApiKeyOption)!;
        var title = context.ParseResult.GetValueForOption(_titleOption);
        var description = context.ParseResult.GetValueForOption(_descriptionOption);
        var text = context.ParseResult.GetValueForOption(_textOption)!;
        var language = context.ParseResult.GetValueForOption(_languageOption);

        var client = CreateClient(apiKey);
        
        try
        {
            var result = await client.Paste.CreatePasteAsync(new PasteCreateRequest
            {
                Title = title,
                Description = description,
                Text = text,
                Language = language
            });

            if (result is { IsSuccessStatusCode: true, Content: not null })
            {
                Console.WriteLine("Paste created successfully!");
                Console.WriteLine($"Paste URL: {result.Content.PasteUrl}");
                Console.WriteLine($"Raw URL: {result.Content.RawUrl}");
                Console.WriteLine($"Deletion URL: {result.Content.DeletionUrl}");
            }
            else
            {
                Console.WriteLine($"Failed to create paste: {result.Error?.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}