using EZDotNet.Core.Interfaces;
using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Extensions;

public static class ShortenerServiceExtension
{
    public static async Task<ApiResponse<ShortenerCreateResponse>> CreateShortUrlAsync(
        this IShortenerService fileService,
        string url)
    {
        return await fileService.CreateShortUrlAsync(new ShortenerCreateRequest
        {
            Url = url
        });
    }
}