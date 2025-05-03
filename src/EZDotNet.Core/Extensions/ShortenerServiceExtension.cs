using EZDotNet.Core.Interfaces;
using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Extensions;

/// <summary>
/// Extension methods for the shortener service interface.
/// </summary>
public static class ShortenerServiceExtension
{
    /// <summary>
    /// Creates a shortened URL from the provided URL string.
    /// </summary>
    /// <param name="shortenerService">The shortener service instance.</param>
    /// <param name="url">The URL to shorten.</param>
    /// <returns>A response containing the shortened URL details.</returns>
    public static async Task<ApiResponse<ShortenerCreateResponse>> CreateShortUrlAsync(
        this IShortenerService shortenerService,
        string url)
    {
        return await shortenerService.CreateShortUrlAsync(new ShortenerCreateRequest
        {
            Url = url
        });
    }
}