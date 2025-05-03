namespace EZDotNet.Core;

/// <summary>
/// Handles authentication for https://e-z.host API requests by adding the API key header.
/// </summary>
public class AuthHeaderHandler : DelegatingHandler
{
    private readonly string _apiKey;

    /// <summary>
    /// Initializes a new instance of the AuthHeaderHandler.
    /// </summary>
    /// <param name="apiKey">The API key to use for authentication.</param>
    public AuthHeaderHandler(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        InnerHandler = new HttpClientHandler();
    }

    /// <summary>
    /// Adds the API key header to outgoing requests.
    /// </summary>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, 
        CancellationToken cancellationToken)
    {
        request.Headers.Add("key", _apiKey);
        return await base.SendAsync(request, cancellationToken);
    }
}