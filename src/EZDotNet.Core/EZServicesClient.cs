using EZDotNet.Core.Interfaces;
using Refit;

namespace EZDotNet.Core;

/// <summary>
/// Client for interacting with https://e-z.host services.
/// </summary>
public class EZServicesClient : IDisposable
{
    /// <summary>
    /// Provides access to file upload services.
    /// </summary>
    public IFileService Files { get; }

    /// <summary>
    /// Provides access to URL shortening services.
    /// </summary>
    public IShortenerService Shortener { get; }

    /// <summary>
    /// Provides access to paste creation services.
    /// </summary>
    public IPasteService Paste { get; }
    
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the EZServicesClient.
    /// </summary>
    /// <param name="options">Configuration options for the client.</param>
    /// <exception cref="ArgumentNullException">Thrown when options are null.</exception>
    public EZServicesClient(EZServicesOptions options)
    {
        var ezServicesOptions = options ?? throw new ArgumentNullException(nameof(options));
        
        var authHandler = new AuthHeaderHandler(ezServicesOptions.ApiKey);
        _httpClient = new HttpClient(authHandler)
        {
            BaseAddress = new Uri("https://api.e-z.host"),
            Timeout = options.Timeout,
        };
        
        Files = RestService.For<IFileService>(_httpClient);
        Shortener = RestService.For<IShortenerService>(_httpClient);
        Paste = RestService.For<IPasteService>(_httpClient);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}