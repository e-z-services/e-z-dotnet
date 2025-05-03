using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Requests;

/// <summary>
/// Represents a request to create a shortened URL.
/// </summary>
public class ShortenerCreateRequest
{
    /// <summary>
    /// The URL to be shortened.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}