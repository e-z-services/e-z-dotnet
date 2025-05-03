namespace EZDotNet.Core;

public class EZServicesOptions
{
    public required string ApiKey { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}