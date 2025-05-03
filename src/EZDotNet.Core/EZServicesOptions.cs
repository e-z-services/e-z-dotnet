namespace EZDotNet.Core;

/// <summary>
/// Configuration options for the EZ Services client.
/// </summary>
public class EZServicesOptions
{
    /// <summary>
    /// The API key used for authentication with https://e-z.host services.
    /// This is required for all API calls.
    /// </summary>
    public required string ApiKey { get; set; }

    /// <summary>
    /// The timeout period for API requests.
    /// Defaults to 30 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}