using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Interfaces;

/// <summary>
/// Provides functionality for creating and managing pastes on https://e-z.host.
/// </summary>
public interface IPasteService
{
    /// <summary>
    /// Creates a new paste with the specified content and settings.
    /// </summary>
    /// <param name="request">The paste creation request containing the content and settings.</param>
    /// <returns>A response containing the created paste's details and URLs.</returns>
    [Post("/paste")]
    [Headers("Content-Type: application/json")]
    Task<ApiResponse<PasteCreateResponse>> CreatePasteAsync([Body] PasteCreateRequest request);
}