using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

/// <summary>
/// Represents the response received after creating a shortened URL.
/// </summary>
public class ShortenerCreateResponse
{
    /// <summary>
    /// Indicates whether the URL shortening was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }
    
    /// <summary>
    /// The shortened URL.
    /// </summary>
    [JsonPropertyName("shortendUrl")] // This is still mispelled in the API response.
    public required string ShortenedUrl { get; set; }
    
    /// <summary>
    /// The URL that can be used to delete the shortened URL.
    /// </summary>
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}