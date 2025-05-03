using System.CommandLine;
using EZDotNet.Cli.Commands;

namespace EZDotNet.Cli;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("e-z.host CLI tool for file uploads, URL shortening, and creating pastes");

        rootCommand.AddCommand(new PasteCommand());
        rootCommand.AddCommand(new UploadCommand());
        rootCommand.AddCommand(new ShortenCommand());

        return await rootCommand.InvokeAsync(args);
    }
}