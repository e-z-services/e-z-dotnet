using System.CommandLine;
using System.CommandLine.Invocation;
using EZDotNet.Core.Extensions;

namespace EZDotNet.Cli.Commands;

public class UploadCommand : CommandBase
{
    private readonly Option<string?> _filePathOption = new("--file", "Path to the file to upload");

    public UploadCommand() : base("upload", "Upload a file")
    {
        AddOption(_filePathOption);

        this.SetHandler(HandleCommandAsync);
    }

    private async Task HandleCommandAsync(InvocationContext context)
    {
        var apiKey = context.ParseResult.GetValueForOption(ApiKeyOption)!;
        var filePath = context.ParseResult.GetValueForOption(_filePathOption);

        var client = CreateClient(apiKey);

        try
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("No file specified. Use --file to specify a file.");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var result = await client.Files.UploadFileFromPathAsync(filePath);

            if (result is { IsSuccessStatusCode: true, Content: not null })
            {
                Console.WriteLine("File uploaded successfully!");
                Console.WriteLine($"Image URL: {result.Content.ImageUrl}");
                Console.WriteLine($"Raw URL: {result.Content.RawUrl}");
                Console.WriteLine($"Deletion URL: {result.Content.DeletionUrl}");
            }
            else
            {
                Console.WriteLine($"Failed to upload file: {result.StatusCode}");
                if (result.Error != null)
                {
                    Console.WriteLine($"Error details: {result.Error.Message}");
                }
                if (result.Content?.Message != null)
                {
                    Console.WriteLine($"Server message: {result.Content.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}