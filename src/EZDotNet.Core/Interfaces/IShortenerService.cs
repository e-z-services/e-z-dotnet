using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Interfaces;

/// <summary>
/// Provides functionality for creating and managing shortened URLs on https://e-z.host.
/// </summary>
public interface IShortenerService
{
    /// <summary>
    /// Creates a shortened URL from the provided request.
    /// </summary>
    /// <param name="request">The URL shortening request details.</param>
    /// <returns>A response containing the shortened URL information.</returns>
    [Post("/shortener")]
    [Headers("Content-Type: application/json")]
    Task<ApiResponse<ShortenerCreateResponse>> CreateShortUrlAsync([Body] ShortenerCreateRequest request);
}