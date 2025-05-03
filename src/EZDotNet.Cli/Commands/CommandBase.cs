using System.CommandLine;
using EZDotNet.Core;

namespace EZDotNet.Cli.Commands;

public abstract class CommandBase : Command
{
    protected readonly Option<string> ApiKeyOption = new("--api-key", "Your e-z.host API key") { IsRequired = true };

    protected CommandBase(string name, string description) : base(name, description)
    {
        AddOption(ApiKeyOption);
    }

    protected static EZServicesClient CreateClient(string apiKey) =>
        new(new EZServicesOptions { ApiKey = apiKey });
}
