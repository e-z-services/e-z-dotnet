using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Interfaces;

public interface IShortenerService
{
    [Post("/shortener")]
    [Headers("Content-Type: application/json")]
    Task<ApiResponse<ShortenerCreateResponse>> CreateShortUrlAsync([Body] ShortenerCreateRequest request);
}