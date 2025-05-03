namespace EZDotNet.Core;

public class AuthHeaderHandler(string apiKey) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("key", apiKey);
        return await base.SendAsync(request, cancellationToken);
    }
}