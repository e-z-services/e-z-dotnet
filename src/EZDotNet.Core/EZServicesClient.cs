using EZDotNet.Core.Interfaces;
using Refit;

namespace EZDotNet.Core;

public class EZServicesClient : IDisposable
{
    public IFileService Files { get; }
    public IShortenerService Shortener { get; }
    public IPasteService Paste { get; }
    
    private readonly HttpClient _httpClient;

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