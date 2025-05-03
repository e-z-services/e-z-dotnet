using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

public class ShortenerCreateResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("shortendUrl")] // This is a misspelt word in the API
    public required string ShortenedUrl { get; set; }
    
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}